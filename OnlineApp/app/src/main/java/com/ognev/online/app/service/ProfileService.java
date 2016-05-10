package com.ognev.online.app.service;

import com.ognev.online.app.model.PurchaseWrapper;
import com.ognev.online.app.model.ResponseObject;
import com.ognev.online.app.model.User;
import retrofit.Callback;
import retrofit.http.GET;

public interface ProfileService {


  /**
   * API Для получения списка профиля с подпиской
   * @param callback
   */
  @GET("/api/user/profile")
  void getProfile(Callback<User> callback);

  //api/movie/watch/{movieId}/{userId}
  @GET("/api/user/purchases")
  void getProfilePurchases(Callback<ResponseObject<PurchaseWrapper>> callback);
}
