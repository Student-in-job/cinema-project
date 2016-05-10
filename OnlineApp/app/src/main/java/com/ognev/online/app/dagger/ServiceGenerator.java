package com.ognev.online.app.dagger;

import com.ognev.online.app.Constants;
import com.ognev.online.app.service.VideoService;
import com.ognev.online.app.util.Prefs;
import com.squareup.okhttp.OkHttpClient;
import retrofit.RequestInterceptor;
import retrofit.RestAdapter;
import retrofit.client.OkClient;

public class ServiceGenerator {

  public static VideoService createVideoService() {
    RestAdapter mRestAdapter = new RestAdapter.Builder()
        .setEndpoint(Constants.BASE_URL)
        .setClient(new OkClient(new OkHttpClient()))
        .setRequestInterceptor(getRequestInterceptor())
        .setLogLevel(RestAdapter.LogLevel.FULL)
        .build();
    return mRestAdapter.create(VideoService.class);
  }

  private static RequestInterceptor getRequestInterceptor() {
    return new RequestInterceptor() {
      @Override
      public void intercept(RequestFacade requestFacade) {
        requestFacade.addHeader("Accept", "application/json");
        requestFacade.addHeader("token", Prefs.getUserId());
        requestFacade.addHeader("user_id", Prefs.getUserId());
      }
    };
  }
}
