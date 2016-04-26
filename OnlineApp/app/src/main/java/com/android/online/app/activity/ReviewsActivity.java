package com.android.online.app.activity;

import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.v7.widget.LinearLayoutManager;
import android.support.v7.widget.RecyclerView;
import android.support.v7.widget.Toolbar;
import android.view.MenuItem;
import butterknife.Bind;
import com.android.online.app.Constants;
import com.android.online.app.R;
import com.android.online.app.adapter.ReviewAdapter;
import com.android.online.app.model.Comment;
import com.android.online.app.model.VideoDataListWrapper;
import org.parceler.Parcels;
import retrofit.Callback;
import retrofit.RetrofitError;
import retrofit.client.Response;

import java.util.List;

public class ReviewsActivity extends BaseActivity {

  private ReviewAdapter commentsAdapter;
  @Bind(R.id.list)
  RecyclerView recyclerView;


  private VideoDataListWrapper video;
  @Override
  protected void onCreate(@Nullable Bundle savedInstanceState) {
    super.onCreate(savedInstanceState);
    setContentView(R.layout.reviews_fragment);

    video = Parcels.unwrap(getIntent().getParcelableExtra(Constants.VIDEO));

    reviewService.getReviews(video.id, new Callback<List<Comment>>() {
      @Override
      public void success(List<Comment> comments, Response response) {
        commentsAdapter = new ReviewAdapter(ReviewsActivity.this, comments);
        recyclerView.setLayoutManager(new LinearLayoutManager(ReviewsActivity.this, LinearLayoutManager.VERTICAL, false));
        recyclerView.setAdapter(commentsAdapter);
      }

      @Override
      public void failure(RetrofitError error) {

      }
    });

  }

  @Override
  public boolean onOptionsItemSelected(MenuItem item) {
    switch (item.getItemId()) {
      case android.R.id.home:
        finish();
        break;
    }
    return super.onOptionsItemSelected(item);
  }

}
