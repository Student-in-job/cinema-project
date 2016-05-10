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
import com.ognev.online.app.activity.VideoActivity;
import com.ognev.online.app.model.BaseVideo;
import com.squareup.picasso.Picasso;
import org.parceler.Parcels;

import java.util.List;

public class VideoListAdapter extends RecyclerView.Adapter<VideoListAdapter.ViewHolder> {
  private Context context;
  private List<BaseVideo> list;
  private LayoutInflater inflater;

  public VideoListAdapter(Context context, List<BaseVideo> list) {
    this.context = context;
    this.list = list;
    inflater = LayoutInflater.from(context);
  }

  @Override
  public ViewHolder onCreateViewHolder(ViewGroup parent, int viewType) {
    return new ViewHolder(inflater.inflate(R.layout.video_item, parent, false));
  }

  @Override
  public void onBindViewHolder(ViewHolder holder, final int position) {

    Picasso.with(context).cancelTag(holder.videoImage);
    Picasso.with(context).load(Constants.BASE_URL + "/uploads/" + list.get(position).poster).into(holder.videoImage);
    holder.name.setText(list.get(position).name);

    holder.itemView.setOnClickListener(new View.OnClickListener() {
      @Override
      public void onClick(View v) {
        context.startActivity(new Intent(context, VideoActivity.class)
            .putExtra(Constants.VIDEO, Parcels.wrap(list.get(position))));
      }
    });
  }

  @Override
  public int getItemCount() {
    return list.size();
  }

  public class ViewHolder extends RecyclerView.ViewHolder {
    @Bind(R.id.video_image) ImageView videoImage;
    @Bind(R.id.name) TextView name;

    public ViewHolder(View itemView) {
      super(itemView);
      ButterKnife.bind(this, itemView);
    }
  }
}
