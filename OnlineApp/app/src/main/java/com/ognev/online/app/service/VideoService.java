package com.ognev.online.app.service;

import com.ognev.online.app.model.wrapper.MovieListWrapper;
import com.ognev.online.app.model.*;
import retrofit.Callback;
import retrofit.http.GET;
import retrofit.http.Path;

import java.util.List;

public interface VideoService {

  @GET("/api/{count}/movie")
  void getVideos(@Path("count") int count, Callback<ResponseObject<List<BaseVideo>>> callback);

  @GET("/api/movie/new/{count}")
  void getNewVideos(@Path("count") int count, Callback<ResponseObject<List<BaseVideo>>> callback);

  @GET("/api/movie/popular/{count}")
  void getPopularVideos(@Path("count") int count, Callback<ResponseObject<List<BaseVideo>>> callback);

  @GET("/odata/Video({id})/movies")
  void getMovies(@Path("id") int id, Callback<MovieListWrapper> callback);

  @GET("/api/banner")
  void getBanner(Callback<ResponseObject<Banner>> callback);

  @GET("/api/teaser")
  void getTeaser(Callback<ResponseObject<Banner>> callback);

  //api/movie/watch/{movieId}/{userId}
  @GET("/api/video/watch/{fileId}")
  void postShow(@Path("fileId") int fileId,
                Callback<ResponseObject> callback);

  //api/movie/watch/{movieId}/{userId}
  @GET("/api/user/history")
  void getHistory(Callback<ResponseObject<List<MovieHistory>>> callback);


  /**
   * Покупка фильма
   * @param callback
   */

  @GET("/api/video/purchase/{fileId}")
  void buyVideo(@Path("fileId") int id, Callback<ResponseObject<MovieHistoryWrapper>> callback);

  /**
   * Покупка сезона
   * @param callback
   */
  @GET("/api/season/purchase/{fileId}")
  void buySeason(@Path("fileId") int id, Callback<ResponseObject<MovieHistoryWrapper>> callback);

  /**
   * Проверка сезона
   * @param callback
   */
  @GET("/api/check/season/{id}")
  void checkSeason(@Path("id") int id, Callback<ResponseObject<MovieHistoryWrapper>> callback);

  @GET("/api/{count}/serial")
  void getSerials(@Path("count") int count, Callback<ResponseObject<List<BaseVideo>>> callback);

  @GET("/api/video/search/{query}")
  void searchVideo(@Path("query") String query, Callback<ResponseObject<List<BaseVideo>>> callback);

  @GET("/api/genre")
  void getGenres(Callback<ResponseObject<List<Genre>>> callback);

  @GET("/api/movie/genre/{genreId}")
  void getVideoByGenre(@Path("genreId") int genreId, Callback<ResponseObject<List<BaseVideo>>> callback);


  @GET("/api/serial/genre/{genreId}")
  void getSerialByGenre(@Path("genreId") int genreId, Callback<ResponseObject<List<BaseVideo>>> callback);

}
