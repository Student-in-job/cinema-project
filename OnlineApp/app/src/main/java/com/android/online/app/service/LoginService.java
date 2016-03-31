package com.android.online.app.service;


import com.android.online.app.model.LoginModel;
import retrofit.Callback;
import retrofit.http.Body;
import retrofit.http.GET;
import retrofit.http.POST;

public interface LoginService {

  /**
   * Асинхронный метод получения токена от имени пользователя
   *
   * @param authAccessToken
   * @param callback
   */
  @POST("/api/oauth2/token")
  void getUserAccessToken(
      @Body LoginModel authAccessToken,
      Callback<Object> callback);

  @POST("/api/LoginApi")
  void login(
      @Body LoginModel authAccessToken,
      Callback<String> callback);

  @GET("/api/LoginApi")
  void login(Callback<Object> callback);


  @POST("/api/RegistrationApi")
  void register(@Body RegisterModel authAccessToken, Callback<Object> callback);

}