package com.android.online.app.adapter;

import android.content.Context;
import android.content.Intent;
import android.support.annotation.Nullable;
import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;
import butterknife.Bind;
import butterknife.ButterKnife;
import com.android.online.app.Constants;
import com.android.online.app.R;
import com.android.online.app.activity.ReviewsActivity;
import com.android.online.app.model.Comment;
import com.android.online.app.model.VideoDataListWrapper;
import com.android.online.app.service.ReviewService;
import org.parceler.Parcels;

import java.util.List;

public class VideoReviewAdapter extends RecyclerView.Adapter<VideoReviewAdapter.CommentViewHolder> {
  private final int FOOTER = 0;
  private final int ITEM = 1;
  private LayoutInflater inflater;
  private Context context;
  private List<Comment> comments;
  private ReviewService reviewService;
  private VideoDataListWrapper video;

  public VideoReviewAdapter(Context context, List<Comment> comments) {
    this.context = context;
    this.comments = comments;
    inflater = LayoutInflater.from(context);
  }

  public void setReviewService(ReviewService reviewService) {
    this.reviewService = reviewService;
  }

  public void setVideo(VideoDataListWrapper video) {
    this.video = video;
  }

  @Override
  public CommentViewHolder onCreateViewHolder(ViewGroup parent, int viewType) {

    View view = null;
    switch (viewType) {
      case ITEM:
        view = inflater.inflate(R.layout.comment_item, parent, false);
        break;

      case FOOTER:
        view = inflater.inflate(R.layout.comment_footer, parent, false);
        break;
    }

    return new CommentViewHolder(view);
  }

  @Override
  public void onBindViewHolder(CommentViewHolder holder, int position) {
    if(getItemViewType(position) != FOOTER) {
      holder.comment.setText(comments.get(position).comment);
      holder.userName.setText(comments.get(position).author);
    } else
    holder.itemView.setOnClickListener(new View.OnClickListener() {
      @Override
      public void onClick(View v) {
        context.startActivity(new Intent(context, ReviewsActivity.class)
        .putExtra(Constants.VIDEO, Parcels.wrap(video)));
      }
    });

  }

  @Override
  public int getItemViewType(int position) {

    return position == 3 ? FOOTER : ITEM;
  }

  @Override
  public int getItemCount() {
    return comments.size();
  }

  public class CommentViewHolder extends RecyclerView.ViewHolder {
    @Nullable @Bind(R.id.username) TextView userName;
    @Nullable @Bind(R.id.date) TextView date;
    @Nullable @Bind(R.id.comment) TextView comment;

    public CommentViewHolder(View itemView) {
      super(itemView);
      ButterKnife.bind(this, itemView);
    }
  }
}
