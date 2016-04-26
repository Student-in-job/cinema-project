package com.android.online.app;

import retrofit.RestAdapter;

public class Constants {////http://172.20.16.4
  //172.20.16.2 ubuntu qwerty1234
//  public static String BASE_URL = "http://172.20.16.4";
//  public static final String BASE_URL = "http://cinema.i-cloud.uz";
  public static String BASE_URL = "http://10.42.0.8/OnlineCinemaProject";
  public static final RestAdapter.LogLevel REST_ADAPTER_LOG_LEVEL = RestAdapter.LogLevel.FULL;

  public static final String VIDEO = "video";

  public static void setBASE_URL(String BASE_URL) {
    Constants.BASE_URL = BASE_URL;
  }
}
