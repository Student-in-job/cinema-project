package com.ognev.online.app.service;

import com.ognev.online.app.model.Comment;
import com.ognev.online.app.model.ResponseObject;
import retrofit.Callback;
import retrofit.http.Body;
import retrofit.http.GET;
import retrofit.http.POST;
import retrofit.http.Path;

import java.util.List;

public interface ReviewService {

  @GET("/api/overview/{id}")
  void getReviews(@Path("id") int id, Callback<ResponseObject<List<Comment>>> callback);

  @POST("/api/overview")
  void saveReview(@Body Comment comment, Callback<ResponseObject<Object>> callback);

}
