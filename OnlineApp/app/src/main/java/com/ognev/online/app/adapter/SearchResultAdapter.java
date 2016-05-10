package com.ognev.online.app.adapter;

import android.content.Context;
import android.content.Intent;
import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.*;
import butterknife.Bind;
import butterknife.ButterKnife;
import com.ognev.online.app.Constants;
import com.ognev.online.app.R;
import com.ognev.online.app.activity.VideoActivity;
import com.ognev.online.app.model.VideoDataListWrapper;
import com.squareup.picasso.Picasso;
import org.parceler.Parcels;

import java.util.List;

public class SearchResultAdapter extends RecyclerView.Adapter<SearchResultAdapter.ViewHolder> implements Filterable {
  private Context context;
  private List<VideoDataListWrapper> items;
  private LayoutInflater inflater;

  public SearchResultAdapter(Context context, List<VideoDataListWrapper> items) {
    this.context = context;
    this.items = items;
    inflater = LayoutInflater.from(context);
  }

  @Override
  public ViewHolder onCreateViewHolder(ViewGroup parent, int viewType) {
    return new ViewHolder(inflater.inflate(R.layout.search_result_item, parent, false));
  }

  @Override
  public void onBindViewHolder(ViewHolder holder, final int position) {
    holder.name.setText(items.get(position).name);
    holder.year.setText(items.get(position).director);

    Picasso.with(context).cancelTag(holder.poster);
    Picasso.with(context).load(Constants.BASE_URL + "/uploads/" + items.get(position).poster).into(holder.poster);

    holder.itemView.setOnClickListener(new View.OnClickListener() {
      @Override
      public void onClick(View v) {
        context.startActivity(new Intent(context, VideoActivity.class).putExtra(Constants.VIDEO, Parcels.wrap(items.get(position))));
      }
    });

  }

  @Override
  public int getItemCount() {
    return items.size();
  }

  @Override
  public Filter getFilter() {
    return null;
  }

  public class ViewHolder extends RecyclerView.ViewHolder {
    @Bind(R.id.poster) ImageView poster;
    @Bind(R.id.name) TextView name;
    @Bind(R.id.genre) TextView genre;
    @Bind(R.id.year) TextView year;
    @Bind(R.id.rate) RatingBar ratingBar;

    public ViewHolder(View itemView) {
      super(itemView);
      ButterKnife.bind(this, itemView);
    }
  }
}
