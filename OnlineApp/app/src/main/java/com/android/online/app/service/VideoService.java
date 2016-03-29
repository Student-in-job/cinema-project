package com.android.online.app.service;

import com.android.online.app.model.wrapper.MovieListWrapper;
import com.android.online.app.model.wrapper.VideoListWrapper;
import retrofit.Callback;
import retrofit.http.GET;
import retrofit.http.Path;

public interface VideoService {

  @GET("/odata/Video")
  void getVideos(Callback<VideoListWrapper> callback);

  @GET("/odata/Video({id})/movies")
  void getMovies(@Path("id") int id, Callback<MovieListWrapper> callback);
}
