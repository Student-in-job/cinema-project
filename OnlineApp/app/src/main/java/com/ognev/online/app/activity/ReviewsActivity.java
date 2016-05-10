package com.ognev.online.app.activity;

import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.v7.widget.LinearLayoutManager;
import android.support.v7.widget.RecyclerView;
import android.view.MenuItem;
import android.view.View;
import android.widget.ProgressBar;
import butterknife.Bind;
import com.ognev.online.app.Constants;
import com.ognev.online.app.R;
import com.ognev.online.app.adapter.ReviewAdapter;
import com.ognev.online.app.model.Comment;
import com.ognev.online.app.model.ResponseObject;
import com.ognev.online.app.model.VideoDataListWrapper;
import org.parceler.Parcels;
import retrofit.Callback;
import retrofit.RetrofitError;
import retrofit.client.Response;

import java.util.List;

public class ReviewsActivity extends BaseActivity {

  private ReviewAdapter commentsAdapter;
  @Bind(R.id.list)
  RecyclerView recyclerView;

  @Bind(R.id.progress)
  ProgressBar progressBar;


  private VideoDataListWrapper video;
  @Override
  protected void onCreate(@Nullable Bundle savedInstanceState) {
    super.onCreate(savedInstanceState);
    setContentView(R.layout.reviews_fragment);

    getSupportActionBar().setDisplayHomeAsUpEnabled(true);
    getSupportActionBar().setDisplayShowHomeEnabled(true);
    video = Parcels.unwrap(getIntent().getParcelableExtra(Constants.VIDEO));

    reviewService.getReviews(video.id, new Callback<ResponseObject<List<Comment>>>() {
      @Override
      public void success(ResponseObject<List<Comment>> comments, Response response) {
        progressBar.setVisibility(View.GONE);
        commentsAdapter = new ReviewAdapter(ReviewsActivity.this, comments.data);
        recyclerView.setLayoutManager(new LinearLayoutManager(ReviewsActivity.this, LinearLayoutManager.VERTICAL, false));
        recyclerView.setAdapter(commentsAdapter);
      }

      @Override
      public void failure(RetrofitError error) {
        progressBar.setVisibility(View.GONE);
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
