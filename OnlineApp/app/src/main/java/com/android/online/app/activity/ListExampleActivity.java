package com.android.online.app.activity;

import android.content.Intent;
import android.net.Uri;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ListView;
import butterknife.Bind;
import com.android.online.app.Constants;
import com.android.online.app.R;
import com.android.online.app.adapter.MovieAdapter;
import com.android.online.app.model.Samples;
import com.android.online.app.model.Video;
import com.android.online.app.model.wrapper.VideoListWrapper;
import org.parceler.Parcels;
import retrofit.Callback;
import retrofit.RetrofitError;
import retrofit.client.Response;

import java.util.ArrayList;
import java.util.List;

public class ListExampleActivity extends MenuActivity {

  @Bind(R.id.list) ListView listView;
  MovieAdapter movieAdapter;
  List<Video> urls;


  @Override
  protected void onCreate(@Nullable Bundle savedInstanceState) {
    super.onCreate(savedInstanceState);
    setContentView(R.layout.list_example);
    urls = new ArrayList<>();
//    urls.add(new Video());
    videoService.getVideos(new Callback<VideoListWrapper>() {
      @Override
      public void success(VideoListWrapper o, Response response) {
        urls.addAll(o.videos);
        movieAdapter.notifyDataSetChanged();
      }

      @Override
      public void failure(RetrofitError error) {

      }
    });


//    urls.add("http://10.42.0.100/mobile/pursuit/pursuit_of_happYness.m3u8");
//    urls.add("http://10.42.0.100/mobile/panda/panda.m3u8");

    movieAdapter = new MovieAdapter(this, urls);
    listView.setAdapter(movieAdapter);
    listView.setOnItemClickListener(new AdapterView.OnItemClickListener() {
      @Override
      public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
        Samples.Sample sample = Samples.HLS[0];
        Intent mpdIntent = new Intent(ListExampleActivity.this, PlayerActivity.class)
            .setData(Uri.parse("http://172.20.16.2/mobile/panda/panda.m3u8"))
            .putExtra(PlayerActivity.CONTENT_ID_EXTRA, sample.contentId)
            .putExtra(PlayerActivity.CONTENT_TYPE_EXTRA, sample.type)
            .putExtra(Constants.VIDEO, Parcels.wrap(urls.get(position)))
            .putExtra(PlayerActivity.PROVIDER_EXTRA, sample.provider);
        startActivity(mpdIntent);
      }
    });
  }
}
