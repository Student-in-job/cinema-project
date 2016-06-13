package com.ognev.online.app.activity;

import android.app.Dialog;
import android.content.Intent;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.design.widget.CollapsingToolbarLayout;
import android.support.v7.app.AlertDialog;
import android.support.v7.widget.LinearLayoutManager;
import android.support.v7.widget.RecyclerView;
import android.text.TextUtils;
import android.view.*;
import android.widget.*;
import butterknife.Bind;
import butterknife.OnClick;
import com.ognev.online.app.Constants;
import com.ognev.online.app.R;
import com.ognev.online.app.adapter.AlternativeWatchAdapter;
import com.ognev.online.app.adapter.SimpleAdapter;
import com.ognev.online.app.adapter.VideoReviewAdapter;
import com.ognev.online.app.util.Prefs;
import com.ognev.online.app.model.*;
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
  private BaseVideo video;

  @Bind(R.id.recyclerview)
  RecyclerView recyclerView;

  @Bind(R.id.comments)
  RecyclerView commentsRecyclerView;


  @Bind(R.id.rate)
  RatingBar ratingBar;


  @Bind(R.id.comments_tv)
  TextView commentsTv;

  @Bind(R.id.name)
  TextView name;

  @Bind(R.id.rating)
  TextView rating;

  @Bind(R.id.review_view)
  View reviewView;

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

    video = Parcels.unwrap(getIntent().getParcelableExtra(Constants.VIDEO));
    simpleAdapter = new SimpleAdapter(this, videos);

    rating.setText(getString(R.string.rating) + " " + video.rating);
    if(video.comments != null)
    comments.addAll(video.comments);
    else commentsTv.setText(getString(R.string.no_comment));
    commentsAdapter = new VideoReviewAdapter(this, comments);

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

    if(Prefs.hasId()) {
      reviewView.setVisibility(View.VISIBLE);
    } else {
      reviewView.setVisibility(View.GONE);
    }

    if(video.comments.size() > 0) {
      commentsTv.setVisibility(View.VISIBLE);
    } else {
      commentsTv.setVisibility(View.GONE);
    }

    collapsingToolbar.setTitle(video.name);

    videoService.getPopularVideos(Constants.EIGHT, new Callback<ResponseObject<List<BaseVideo>>>() {
      @Override
      public void success(ResponseObject<List<BaseVideo>> listResponseObject, Response response) {
        videos.addAll(listResponseObject.data);
        simpleAdapter.notifyDataSetChanged();
      }

      @Override
      public void failure(RetrofitError error) {

      }
    });

    videoService.getTeaser(new Callback<ResponseObject<Banner>>() {
      @Override
      public void success(ResponseObject<Banner> banner, Response response) {
        if(!Constants.ERROR.equals(banner.status))
        startActivity(new Intent(VideoActivity.this, TeaserActivity.class)
        .putExtra(Constants.BANNER, Parcels.wrap(banner.data)));
//        BannerFragmentPage bannerPage = new BannerFragmentPage();
//        Bundle bundle = new Bundle();
//        bundle.putString("banner", banner.imgUrl);
//        bannerPage.setArguments(bundle);
//        bannerPage.show(getSupportFragmentManager(), "banner");
      }

      @Override
      public void failure(RetrofitError error) {

      }
    });

//    name.setText(video.name);
    details.setText(video.scenario);
    name.setText(Prefs.getUserName());

    ratingBar.setOnRatingBarChangeListener(new RatingBar.OnRatingBarChangeListener() {
      @Override
      public void onRatingChanged(RatingBar ratingBar, final float rating, boolean fromUser) {
        // custom dialog
        final Dialog dialog = new Dialog(VideoActivity.this);
        View view = LayoutInflater.from(VideoActivity.this).inflate(R.layout.review_dialog, null);
        final RatingBar rate = ((RatingBar)view.findViewById(R.id.rate));
        final EditText review  = (EditText) view.findViewById(R.id.review);
        final TextView name  = (TextView) view.findViewById(R.id.name);
        name.setText(Prefs.getUserName());
        Button send  = (Button) view.findViewById(R.id.send);

        rate.setRating(ratingBar.getRating());
        send.setOnClickListener(new View.OnClickListener() {
          @Override
          public void onClick(View v) {
            final Comment comment = new Comment();
            comment.rating = rate.getRating();
            if(!TextUtils.isEmpty(review.getText()) && !TextUtils.isEmpty(review.getText().toString()))
            comment.comment = review.getText().toString();
            comment.videoId = video.id;
            comment.authorId = Prefs.getUserId();
            comment.user_id = Prefs.getUserId();
            dialog.dismiss();
            reviewService.saveReview(comment, new Callback<ResponseObject<Object>>() {
              @Override
              public void success(ResponseObject<Object> o, Response response) {
                if(!Constants.SUCCESS.equals(o.status)) {
                  showInfoDialog(o.error.message);
                } else {
                  comments.add(comment);
                  commentsAdapter.notifyDataSetChanged();
                }
              }

              @Override
              public void failure(RetrofitError error) {
                showInfoDialog(error.getMessage());
              }
            });
          }
        });
        dialog.setContentView(view);
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


  @OnClick(R.id.trailer)
  public void onWatchTrailerClicked() {
    if(video.trailer != null) {
      Samples.Sample sample = Samples.HLS[0];
      Intent mpdIntent = new Intent(VideoActivity.this, PlayerActivity.class)
//        .setData(Uri.parse("http://172.20.16.2/mobile/panda/panda.m3u8"))
          .putExtra(PlayerActivity.CONTENT_ID_EXTRA, sample.contentId)
          .putExtra(PlayerActivity.CONTENT_TYPE_EXTRA, sample.type)
          .putExtra(Constants.TRAILER, Parcels.wrap(video))
          .putExtra(PlayerActivity.PROVIDER_EXTRA, sample.provider);
      startActivity(mpdIntent);
    } else {
      AlertDialog.Builder builder = new AlertDialog.Builder(VideoActivity.this);
      builder.setMessage(R.string.no_trailer);
      builder.setNeutralButton("OK", null);
      builder.show();
    }
  }

  @OnClick(R.id.watch_video) void onWatchVideoClicked() {
    if(!video.files.isEmpty()) {
      Samples.Sample sample = Samples.HLS[0];
      Intent mpdIntent = new Intent(VideoActivity.this, PlayerActivity.class)
//        .setData(Uri.parse("http://172.20.16.2/mobile/panda/panda.m3u8"))
          .putExtra(PlayerActivity.CONTENT_ID_EXTRA, sample.contentId)
          .putExtra(PlayerActivity.CONTENT_TYPE_EXTRA, sample.type)
          .putExtra(Constants.VIDEO, Parcels.wrap(video))
          .putExtra(PlayerActivity.PROVIDER_EXTRA, sample.provider);
      startActivity(mpdIntent);
    }
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
