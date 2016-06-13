package com.ognev.online.app.adapter;

import android.content.Context;
import android.content.Intent;
import android.support.annotation.Nullable;
import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.RatingBar;
import android.widget.TextView;
import butterknife.Bind;
import butterknife.ButterKnife;
import com.ognev.online.app.Constants;
import com.ognev.online.app.R;
import com.ognev.online.app.activity.ReviewsActivity;
import com.ognev.online.app.model.BaseVideo;
import com.ognev.online.app.model.Comment;
import com.ognev.online.app.model.VideoDataListWrapper;
import com.ognev.online.app.service.ReviewService;
import org.parceler.Parcels;

import java.util.List;

public class VideoReviewAdapter extends RecyclerView.Adapter<VideoReviewAdapter.CommentViewHolder> {
  private final int FOOTER = 0;
  private final int ITEM = 1;
  private static final int EMPTY = 3;
  private LayoutInflater inflater;
  private Context context;
  private List<Comment> comments;
  private ReviewService reviewService;
  private VideoDataListWrapper video;
  private int count = 1;

  public VideoReviewAdapter(Context context, List<Comment> comments) {
    this.context = context;
    this.comments = comments;
    inflater = LayoutInflater.from(context);
  }

  public void setReviewService(ReviewService reviewService) {
    this.reviewService = reviewService;
  }

  public void setVideo(BaseVideo video) {
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
      holder.ratingBar.setRating(comments.get(position).rating);
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
    int type = position == count-1 ? FOOTER : ITEM;

    return type;
  }

  @Override
  public int getItemCount() {
    count = comments.size() > 2 ? 3 : comments.size();
    return count;
  }

  public class CommentViewHolder extends RecyclerView.ViewHolder {
    @Nullable @Bind(R.id.username) TextView userName;
    @Nullable @Bind(R.id.date) TextView date;
    @Nullable @Bind(R.id.comment) TextView comment;
    @Nullable @Bind(R.id.rate) RatingBar ratingBar;

    public CommentViewHolder(View itemView) {
      super(itemView);
      ButterKnife.bind(this, itemView);
    }
  }
}
