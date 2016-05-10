package com.ognev.online.app.dagger.modules;

import com.ognev.online.app.dagger.AppRestAdapter;
import com.google.gson.Gson;
import com.squareup.okhttp.OkHttpClient;
import dagger.Module;
import dagger.Provides;
import retrofit.RestAdapter;
import retrofit.client.Client;
import retrofit.client.OkClient;
import retrofit.converter.GsonConverter;

import javax.inject.Singleton;

@Module
public class ApiModule {

  @Provides
  @Singleton
  @SuppressWarnings("unused")
  Client provideClient() {
    OkHttpClient okHttpClient = new OkHttpClient();
//    okHttpClient.interceptors().add(new TokenExpiredInterceptor(account));
    return new OkClient(okHttpClient);
  }

  @Provides
  @Singleton
  @SuppressWarnings("unused")
  RestAdapter provideRestAdapter(AppRestAdapter appRestAdapter) {
    return appRestAdapter.getAdapter();
  }

  @Provides
  @Singleton
  @SuppressWarnings("unused")
  GsonConverter provideGsonConverter(Gson gson) {
    return new GsonConverter(gson);
  }
}
