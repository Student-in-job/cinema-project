package com.android.online.app.service;

import com.android.online.app.model.Comment;
import retrofit.Callback;
import retrofit.http.Body;
import retrofit.http.GET;
import retrofit.http.POST;
import retrofit.http.Path;

import java.util.List;

public interface ReviewService {

  @GET("/api/overview/{id}")
  void getReviews(@Path("id") int id, Callback<List<Comment>> callback);

  @POST("/api/overview")
  void saveReview(@Body Comment comment, Callback<Object> callback);

}
