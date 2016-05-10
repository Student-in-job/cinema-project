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
import com.ognev.online.app.activity.SerialActivity;
import com.ognev.online.app.model.BaseVideo;
import com.squareup.picasso.Picasso;
import org.parceler.Parcels;

import java.util.List;

public class SerialAdapter extends RecyclerView.Adapter<SerialAdapter.SerialViewHolder> {
  Context context;
  private List<BaseVideo> videoDataListWrappers;
  private LayoutInflater inflater;

  public SerialAdapter(Context context, List<BaseVideo> videoDataListWrappers) {
    this.context = context;
    this.videoDataListWrappers = videoDataListWrappers;
    inflater = LayoutInflater.from(context);
  }

  @Override
  public SerialViewHolder onCreateViewHolder(ViewGroup parent, int viewType) {
    return new SerialViewHolder(inflater.inflate(R.layout.item_serial, parent, false));
  }

  @Override
  public void onBindViewHolder(SerialViewHolder holder, final int position) {
    holder.videoName.setText(videoDataListWrappers.get(position).name);
    Picasso.with(context).cancelTag(holder.videoImage);
    Picasso.with(context).load(Constants.BASE_URL + "/upload/" + videoDataListWrappers.get(position).poster)
        .fit().centerCrop().into(holder.videoImage);

    holder.itemView.setOnClickListener(new View.OnClickListener() {
      @Override
      public void onClick(View v) {
        Intent mpdIntent = new Intent(context, SerialActivity.class)
            .putExtra(Constants.SERIAL, Parcels.wrap(videoDataListWrappers.get(position)));
        context.startActivity(mpdIntent);
      }
    });

  }

  @Override
  public int getItemCount() {
    return videoDataListWrappers.size();
  }

  public class SerialViewHolder extends RecyclerView.ViewHolder {
    @Bind(R.id.video_image) ImageView videoImage;
    @Bind(R.id.video_name) TextView videoName;

    public SerialViewHolder(View itemView) {
      super(itemView);
      ButterKnife.bind(this, itemView);
    }
  }
}
