package com.ognev.online.app.dagger;

import com.ognev.online.app.Constants;
import com.ognev.online.app.util.Prefs;
import retrofit.RequestInterceptor;
import retrofit.RestAdapter;
import retrofit.client.Client;
import retrofit.converter.GsonConverter;

import javax.inject.Inject;

public class AppRestAdapter {

  private final Client client;
  private final GsonConverter jsonConverter;

  @Inject
  public AppRestAdapter(Client client, GsonConverter converter) {
    this.client = client;
    this.jsonConverter = converter;
  }

  public RestAdapter getAdapter() {
    return new RestAdapter.Builder()
        .setEndpoint(Constants.BASE_URL)
        .setClient(client)
        .setConverter(jsonConverter)
        .setRequestInterceptor(getRequestInterceptor())
        .setLogLevel(Constants.REST_ADAPTER_LOG_LEVEL)
        .build();
  }

  private RequestInterceptor getRequestInterceptor() {
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
