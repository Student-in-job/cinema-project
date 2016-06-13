package com.ognev.online.app.activity;

import android.content.Intent;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.v7.widget.GridLayoutManager;
import android.support.v7.widget.RecyclerView;
import android.view.MenuItem;
import android.view.View;
import android.widget.AdapterView;
import android.widget.TextView;
import android.widget.Toast;
import butterknife.Bind;
import butterknife.OnClick;
import com.ognev.online.app.Constants;
import com.ognev.online.app.R;
import com.ognev.online.app.adapter.EpisodeAdapter;
import com.ognev.online.app.adapter.VideoReviewAdapter;
import com.ognev.online.app.model.*;
import org.parceler.Parcels;
import retrofit.Callback;
import retrofit.RetrofitError;
import retrofit.client.Response;

public class SeasonActivity extends BaseActivity {
  private VideoReviewAdapter commentsAdapter;
  private EpisodeAdapter episodeAdapter;
  @Bind(R.id.recyclerview)

  RecyclerView recyclerView;

  @Bind(R.id.buy) TextView buyBtn;
  @Bind(R.id.name) TextView name;
  @Bind(R.id.director) TextView director;
  @Bind(R.id.price) TextView price;
  @Bind(R.id.sub_name) TextView subName;

  private Season season;
  private BaseVideo serial;

  @Override
  protected void onCreate(@Nullable Bundle savedInstanceState) {
    super.onCreate(savedInstanceState);
    setContentView(R.layout.season_activity);
    getSupportActionBar().setDisplayHomeAsUpEnabled(true);


    serial = Parcels.unwrap(getIntent().getParcelableExtra(Constants.SERIAL));
    season = serial.seasons.get(getIntent().getIntExtra(Constants.SEASON,0));
    name.setText(serial.name);
    director.setText(serial.director);
    subName.setText(getString(R.string.season) + " " + season.seasonNumber);
    price.setText(season.price + " сум.");
    episodeAdapter = new EpisodeAdapter(this, season.episodes);
    episodeAdapter.setOnItemClickListener(new AdapterView.OnItemClickListener() {
      @Override
      public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
//        if() // todo purchased
          Samples.Sample sample = Samples.HLS[0];
          Intent mpdIntent = new Intent(SeasonActivity.this, PlayerEpisodeActivity.class)
              .putExtra(PlayerActivity.CONTENT_ID_EXTRA, sample.contentId)
              .putExtra(PlayerActivity.CONTENT_TYPE_EXTRA, sample.type)
              .putExtra(Constants.EPISODE, Parcels.wrap(season.episodes.get(position)))
              .putExtra(PlayerActivity.PROVIDER_EXTRA, sample.provider);
          startActivity(mpdIntent);

      }
    });

    GridLayoutManager layoutManager
        = new GridLayoutManager(this, 4);

    recyclerView.setLayoutManager(layoutManager);
    recyclerView.setAdapter(episodeAdapter);

    videoService.checkSeason(season.id, new Callback<ResponseObject<MovieHistoryWrapper>>() {
      @Override
      public void success(ResponseObject<MovieHistoryWrapper> movieHistoryWrapperResponseObject, Response response) {
        if(Constants.SUCCESS.equals(movieHistoryWrapperResponseObject.status)) {
          buyBtn.setVisibility(View.GONE);
        } else {
          buyBtn.setVisibility(View.VISIBLE);
        }
      }

      @Override
      public void failure(RetrofitError error) {
        showInfoDialog(error.getMessage());
      }
    });

  }

  @OnClick(R.id.buy)
  public void buySeason() {
    videoService.buySeason(season.id, new Callback<ResponseObject<MovieHistoryWrapper>>() {
      @Override
      public void success(ResponseObject<MovieHistoryWrapper> movieHistoryWrapperResponseObject, Response response) {
        if(Constants.SUCCESS.equals(movieHistoryWrapperResponseObject.status))
        showInfoDialog(getString(R.string.success_purchased_season, season.seasonNumber, serial.name));
        else Toast.makeText(getApplicationContext(), movieHistoryWrapperResponseObject.status, Toast.LENGTH_SHORT).show();
      }

      @Override
      public void failure(RetrofitError error) {
        showInfoDialog(error.getMessage());
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
