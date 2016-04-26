package com.android.online.app.service;

import com.android.online.app.model.*;
import com.android.online.app.model.wrapper.MovieListWrapper;
import retrofit.Callback;
import retrofit.http.GET;
import retrofit.http.Path;

import java.util.List;

public interface VideoService {

  @GET("/api/video")
  void getVideos(Callback<List<VideoDataListWrapper>> callback);

  @GET("/api/video/new")
  void getNewVideos(Callback<List<VideoDataListWrapper>> callback);

  @GET("/api/video/popular")
  void getPopularVideos(Callback<List<VideoDataListWrapper>> callback);

  @GET("/odata/Video({id})/movies")
  void getMovies(@Path("id") int id, Callback<MovieListWrapper> callback);

  @GET("/api/banner")
  void getBanner(Callback<Banner> callback);

  //api/movie/watch/{movieId}/{userId}
  @GET("/api/movie/watch/{movieId}")
  void postShow(@Path("movieId") int movieId,
                Callback<ResponseObject> callback);

  //api/movie/watch/{movieId}/{userId}
  @GET("/api/user/history")
  void getHistory(Callback<MovieHistoryWrapper> callback);

   //api/movie/watch/{movieId}/{userId}
  @GET("/api/user/profile")
  void getProfile(Callback<User> callback);

   //api/movie/watch/{movieId}/{userId}
  @GET("/api/user/purchases")
  void getProfilePurchases(Callback<PurchaseWrapper> callback);

}
