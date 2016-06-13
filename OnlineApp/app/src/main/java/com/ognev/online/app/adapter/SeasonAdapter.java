package com.ognev.online.app.adapter;

import android.content.Context;
import android.content.Intent;
import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;
import android.widget.TextView;
import butterknife.Bind;
import butterknife.ButterKnife;
import com.ognev.online.app.Constants;
import com.ognev.online.app.R;
import com.ognev.online.app.activity.SeasonActivity;
import com.ognev.online.app.model.BaseVideo;
import com.ognev.online.app.model.Season;
import org.parceler.Parcels;

import java.util.List;

public class SeasonAdapter extends RecyclerView.Adapter<SeasonAdapter.ViewHolder> {
  private List<Season> seasons;
  private Context context;
  private LayoutInflater inflater;
  private BaseVideo serial;

  public SeasonAdapter(Context context, List<Season> seasons) {
    this.context = context;
    this.seasons = seasons;
    inflater = LayoutInflater.from(context);
  }

  @Override
  public ViewHolder onCreateViewHolder(ViewGroup parent, int viewType) {
    return new ViewHolder(inflater.inflate(R.layout.season_item, parent, false));
  }

  @Override
  public void onBindViewHolder(ViewHolder holder, final int position) {
    holder.season.setText(context.getString(R.string.season) + " " + seasons.get(position).seasonNumber);
    holder.itemView.setOnClickListener(new View.OnClickListener() {
      @Override
      public void onClick(View v) {
        Intent mpdIntent = new Intent(context, SeasonActivity.class)
            .putExtra(Constants.SEASON, position)
            .putExtra(Constants.SERIAL, Parcels.wrap(serial));
        context.startActivity(mpdIntent);
      }
    });

  }

  @Override
  public int getItemCount() {
    return seasons.size();
  }

  public void setSeason(BaseVideo serial) {
    this.serial = serial;
  }

  public class ViewHolder extends RecyclerView.ViewHolder {
    @Bind(R.id.season) TextView season;
    @Bind(R.id.poster) ImageView poster;
    public ViewHolder(View itemView) {
      super(itemView);
      ButterKnife.bind(this, itemView);
    }
  }
}
