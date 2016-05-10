package com.ognev.online.app.activity;

import android.content.Intent;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.v7.widget.GridLayoutManager;
import android.support.v7.widget.RecyclerView;
import android.view.MenuItem;
import android.view.View;
import android.widget.AdapterView;
import butterknife.Bind;
import com.ognev.online.app.Constants;
import com.ognev.online.app.R;
import com.ognev.online.app.adapter.EpisodeAdapter;
import com.ognev.online.app.adapter.VideoReviewAdapter;
import com.ognev.online.app.model.Samples;
import com.ognev.online.app.model.Season;
import org.parceler.Parcels;

public class SeasonActivity extends BaseActivity {
  private VideoReviewAdapter commentsAdapter;
  private EpisodeAdapter episodeAdapter;
  @Bind(R.id.recyclerview)

  RecyclerView recyclerView;

  private Season season;

  @Override
  protected void onCreate(@Nullable Bundle savedInstanceState) {
    super.onCreate(savedInstanceState);
    setContentView(R.layout.season_activity);
    getSupportActionBar().setDisplayHomeAsUpEnabled(true);


    season = Parcels.unwrap(getIntent().getParcelableExtra(Constants.SERIAL));
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
