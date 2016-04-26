package com.android.online.app.adapter;

import android.content.Context;
import android.support.annotation.Nullable;
import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;
import butterknife.Bind;
import butterknife.ButterKnife;
import com.android.online.app.R;
import com.android.online.app.model.Comment;
import com.android.online.app.model.VideoDataListWrapper;
import com.android.online.app.service.ReviewService;

import java.util.List;

public class ReviewAdapter extends RecyclerView.Adapter<ReviewAdapter.CommentViewHolder> {
  private LayoutInflater inflater;
  private Context context;
  private List<Comment> comments;

  public ReviewAdapter(Context context, List<Comment> comments) {
    this.context = context;
    this.comments = comments;
    inflater = LayoutInflater.from(context);
  }
  @Override
  public CommentViewHolder onCreateViewHolder(ViewGroup parent, int viewType) {
    View view = inflater.inflate(R.layout.comment_item, parent, false);

    return new CommentViewHolder(view);
  }

  @Override
  public void onBindViewHolder(CommentViewHolder holder, int position) {
    holder.comment.setText(comments.get(position).comment);
    holder.userName.setText(comments.get(position).author);
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

