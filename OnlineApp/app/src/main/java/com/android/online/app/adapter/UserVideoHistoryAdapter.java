package com.android.online.app.adapter;

import android.content.Context;
import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;
import android.widget.TextView;
import butterknife.Bind;
import butterknife.ButterKnife;
import com.android.online.app.Constants;
import com.android.online.app.R;
import com.android.online.app.model.UserVideo;
import com.squareup.picasso.Picasso;

import java.text.SimpleDateFormat;
import java.util.List;
import java.util.Locale;

public class UserVideoHistoryAdapter extends RecyclerView.Adapter<UserVideoHistoryAdapter.VideoHistoryViewHolder> {

  private Context context;
  private List<UserVideo> movieHistories;
  private SimpleDateFormat mDateFormat;


  public UserVideoHistoryAdapter(Context context, List<UserVideo> movieHistories) {
    this.context = context;
    this.movieHistories = movieHistories;
    mDateFormat = new SimpleDateFormat(
        context.getString(R.string.date_time_format),
        new Locale("ru")); //todo
  }

  @Override
  public VideoHistoryViewHolder onCreateViewHolder(ViewGroup viewGroup, int i) {
    View view = LayoutInflater.from(context).inflate(R.layout.user_video_history_item, viewGroup, false);
    VideoHistoryViewHolder holder = new VideoHistoryViewHolder(view);
    return holder;
  }

  @Override
  public void onBindViewHolder(VideoHistoryViewHolder holder, int i) {
    holder.videoName.setText(movieHistories.get(i).videoName);
    holder.price.setText(movieHistories.get(i).price + "");
    holder.date.setText(mDateFormat.format(movieHistories.get(i).purchaseDate));
    Picasso.with(context).load(Constants.BASE_URL + "/uploads/" + movieHistories.get(i).videoImgUrl).fit().centerInside().into(holder.videoImage);

  }

  @Override
  public int getItemCount() {
    return movieHistories.size();
  }

  class VideoHistoryViewHolder extends RecyclerView.ViewHolder {

    @Bind(R.id.video_name) TextView videoName;
    @Bind(R.id.price) TextView price;
    @Bind(R.id.date) TextView date;
    @Bind(R.id.video_image) ImageView videoImage;

    public VideoHistoryViewHolder(View itemView) {
      super(itemView);
      ButterKnife.bind(this, itemView);
    }
  }
}
