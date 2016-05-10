package com.ognev.online.app.adapter;

import android.content.Context;
import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.ImageView;
import android.widget.TextView;
import butterknife.Bind;
import butterknife.ButterKnife;
import com.ognev.online.app.R;
import com.ognev.online.app.model.Episode;

import java.util.List;

public class EpisodeAdapter extends RecyclerView.Adapter<EpisodeAdapter.ViewHolder> {
  private Context context;
  private List<Episode> episodes;
  private LayoutInflater inflater;
  private AdapterView.OnItemClickListener onItemClickListener;

  public EpisodeAdapter(Context context, List<Episode> episodes) {
    this.context = context;
    this.episodes = episodes;
    inflater = LayoutInflater.from(context);
  }

  public void setOnItemClickListener(AdapterView.OnItemClickListener onItemClickListener) {
    this.onItemClickListener = onItemClickListener;
  }
  @Override
  public ViewHolder onCreateViewHolder(ViewGroup parent, int viewType) {
    return new ViewHolder(inflater.inflate(R.layout.episode_item, parent, false));
  }

  @Override
  public void onBindViewHolder(final ViewHolder holder, final int position) {
    holder.name.setText("Эпизод " + episodes.get(position).episodeNumber);

    holder.itemView.setOnClickListener(new View.OnClickListener() {
      @Override
      public void onClick(View v) {
        onItemClickListener.onItemClick(null, holder.itemView, position, position);
      }
    });

  }

  @Override
  public int getItemCount() {
    return episodes.size();
  }

  public class ViewHolder extends RecyclerView.ViewHolder {
    @Bind(R.id.poster) ImageView poster;
    @Bind(R.id.name) TextView name;

    public ViewHolder(View itemView) {
      super(itemView);
      ButterKnife.bind(this, itemView);
    }
  }
}
