package com.ognev.online.app.service;

import com.ognev.online.app.model.ResponseObject;
import com.ognev.online.app.model.Tariff;
import retrofit.Callback;
import retrofit.http.GET;
import retrofit.http.Path;

import java.util.List;

public interface TariffService {

  /**
   * API Для получения списка тарифов
   * @param callback
   */
  @GET("/api/tariff")
  void getTariffs(Callback<ResponseObject<List<Tariff>>> callback);

  /**
   * API Для получения тарифа по ID
   * @param id
   * @param callback
   */
  @GET("/api/tariff/{id}")
  void getTariff(@Path("id") String id, Callback<Tariff> callback);

  /**
   * API Для подписки на тариф
   * @param id
   * @param callback
   */
  @GET("/api/tariff/subscribe/{tariffId}")
  void subscribeTariff(@Path("tariffId") int id, Callback<ResponseObject<Tariff>> callback);

}
