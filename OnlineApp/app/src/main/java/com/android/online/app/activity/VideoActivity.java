package com.android.online.app.activity;

import android.app.Dialog;
import android.content.Intent;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.design.widget.CollapsingToolbarLayout;
import android.support.v7.widget.LinearLayoutManager;
import android.support.v7.widget.RecyclerView;
import android.view.Menu;
import android.view.MenuItem;
import android.view.Window;
import android.view.WindowManager;
import android.widget.ImageView;
import android.widget.RatingBar;
import android.widget.TextView;
import butterknife.Bind;
import butterknife.OnClick;
import com.android.online.app.Constants;
import com.android.online.app.R;
import com.android.online.app.adapter.AlternativeWatchAdapter;
import com.android.online.app.adapter.VideoReviewAdapter;
import com.android.online.app.adapter.SimpleAdapter;
import com.android.online.app.fragment.BannerFragmentPage;
import com.android.online.app.model.Banner;
import com.android.online.app.model.Comment;
import com.android.online.app.model.Samples;
import com.android.online.app.model.VideoDataListWrapper;
import com.squareup.picasso.Picasso;
import org.parceler.Parcels;
import retrofit.Callback;
import retrofit.RetrofitError;
import retrofit.client.Response;

import java.util.ArrayList;
import java.util.List;

public class VideoActivity extends BaseActivity {
//  @Bind(R.id.name) TextView name;
  @Bind(R.id.details) TextView details;
  private VideoDataListWrapper video;

  @Bind(R.id.recyclerview)
  RecyclerView recyclerView;

  @Bind(R.id.comments)
  RecyclerView commentsRecyclerView;


  @Bind(R.id.rate)
  RatingBar ratingBar;

  @Bind(R.id.backdrop)
  ImageView backdrop;
  @Bind(R.id.collapsing_toolbar) CollapsingToolbarLayout collapsingToolbar;
  private List<Comment> comments;
  private AlternativeWatchAdapter adapter;
  private SimpleAdapter simpleAdapter;
  private VideoReviewAdapter commentsAdapter;
  private List<VideoDataListWrapper> videos;


  @Override
  protected void onCreate(@Nullable Bundle savedInstanceState) {
    super.onCreate(savedInstanceState);
    setContentView(R.layout.video_view_new);
    videos = new ArrayList<>();
    comments = new ArrayList<>();
    videos.add(new VideoDataListWrapper());
    videos.add(new VideoDataListWrapper());
    videos.add(new VideoDataListWrapper());
    videos.add(new VideoDataListWrapper());
    video = Parcels.unwrap(getIntent().getParcelableExtra(Constants.VIDEO));
    simpleAdapter = new SimpleAdapter(this, videos);
    commentsAdapter = new VideoReviewAdapter(this, video.comments);

    commentsAdapter.setReviewService(reviewService);

    commentsAdapter.setVideo(video);
    getSupportActionBar().setDisplayHomeAsUpEnabled(true);


    LinearLayoutManager layoutManager
        = new LinearLayoutManager(this, LinearLayoutManager.HORIZONTAL, false);

    commentsRecyclerView.setLayoutManager(new LinearLayoutManager(this, LinearLayoutManager.VERTICAL, false));
    commentsRecyclerView.setAdapter(commentsAdapter);
    recyclerView.setLayoutManager(layoutManager);
    recyclerView.setAdapter(simpleAdapter);

    Picasso.with(this).load(Constants.BASE_URL + "/uploads/" + video.poster).fit().centerCrop().into(backdrop);

    collapsingToolbar.setTitle(video.name);
    videoService.getBanner(new Callback<Banner>() {
      @Override
      public void success(Banner banner, Response response) {
        BannerFragmentPage bannerPage = new BannerFragmentPage();
        Bundle bundle = new Bundle();
        bundle.putString("banner", banner.imgUrl);
        bannerPage.setArguments(bundle);
        bannerPage.show(getSupportFragmentManager(), "banner");
      }

      @Override
      public void failure(RetrofitError error) {

      }
    });

//    name.setText(video.name);
    details.setText(video.scenario);

    ratingBar.setOnRatingBarChangeListener(new RatingBar.OnRatingBarChangeListener() {
      @Override
      public void onRatingChanged(RatingBar ratingBar, float rating, boolean fromUser) {
        // custom dialog
        final Dialog dialog = new Dialog(VideoActivity.this);
        dialog.setContentView(R.layout.review_dialog);
        WindowManager.LayoutParams lp = new WindowManager.LayoutParams();
        Window window = dialog.getWindow();
        lp.copyFrom(window.getAttributes());
//This makes the dialog take up the full width
        lp.width = WindowManager.LayoutParams.MATCH_PARENT;
        lp.height = WindowManager.LayoutParams.WRAP_CONTENT;
        window.setAttributes(lp);
        dialog.show();
      }
    });

  }


  @OnClick(R.id.watch_video) void onWatchVideoClicked() {
    Samples.Sample sample = Samples.HLS[0];
    Intent mpdIntent = new Intent(VideoActivity.this, PlayerActivity.class)
//        .setData(Uri.parse("http://172.20.16.2/mobile/panda/panda.m3u8"))
        .putExtra(PlayerActivity.CONTENT_ID_EXTRA, sample.contentId)
        .putExtra(PlayerActivity.CONTENT_TYPE_EXTRA, sample.type)
        .putExtra(Constants.VIDEO, Parcels.wrap(video))
        .putExtra(PlayerActivity.PROVIDER_EXTRA, sample.provider);
    startActivity(mpdIntent);
  }

  @Override
  public boolean onOptionsItemSelected(MenuItem item) {
    switch (item.getItemId()) {
      case android.R.id.home:
        finish();
        break;
      case R.id.share:
        share();
        break;
    }
    return super.onOptionsItemSelected(item);
  }

  @Override
  public boolean onCreateOptionsMenu(Menu menu) {
    getMenuInflater().inflate(R.menu.menu_video, menu);

    return super.onCreateOptionsMenu(menu);
  }

  private void share() {
    if (video != null) {
      Intent sharingIntent = new Intent(android.content.Intent.ACTION_SEND);
      sharingIntent.setType("text/plain");
      String shareBody = getString(R.string.share_content,
          video.name, video.id);
      sharingIntent.putExtra(android.content.Intent.EXTRA_SUBJECT, video.name);
      sharingIntent.putExtra(android.content.Intent.EXTRA_TEXT, shareBody);
      startActivity(Intent.createChooser(sharingIntent, getString(R.string.share_via)));
    }
  }
}
