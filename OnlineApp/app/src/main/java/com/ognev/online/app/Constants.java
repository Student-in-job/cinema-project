package com.ognev.online.app;

import retrofit.RestAdapter;

public class Constants {
  public static final String TARIFF = "tariff";////http://172.20.16.4
  public static final int N_ENOUGH_MONEY = 2008;
  public static final String SERIAL = "serial";
  public static final String EPISODE = "episode";
  public static final String BANNER = "banner";
  public static final String SEARCH = "search";
  public static final String QUERY = "query";
  public static final String FAIL = "fail";
  public static final String TAISER = "teaser";
  public static final String SUCCESS = "success";
  public static final String ERROR = "error";
  public static final int ALL = 0;
  public static final int NEW = 2;
  public static final int POPULAR = 3;
  public static final String CATEGORY = "category";
  public static final String USER = "user";
  public static final int YOU_HAVE_TARIFF = 2010;
  public static final String SEASON = "season";
  public static final int EIGHT = 8;
  public static final String TRAILER = "trailer";
  //172.20.16.2 ubuntu qwerty1234
//  public static String BASE_URL = "http://172.20.16.4";
  public static String BASE_URL = "http://illusion.i-cloud.uz";
//  public static String BASE_URL = "http://10.42.0.8/OnlineCinemaProject";
  public static final RestAdapter.LogLevel REST_ADAPTER_LOG_LEVEL = RestAdapter.LogLevel.FULL;

  public static final String VIDEO = "video";

  public static void setBASE_URL(String BASE_URL) {
    Constants.BASE_URL = BASE_URL;
  }
}
