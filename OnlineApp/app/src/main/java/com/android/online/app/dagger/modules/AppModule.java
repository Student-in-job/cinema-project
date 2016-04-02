package com.android.online.app.dagger.modules;

import com.google.gson.Gson;
import com.google.gson.GsonBuilder;
import dagger.Module;
import dagger.Provides;

import javax.inject.Singleton;

@Singleton
@Module(includes = ApiModule.class)
public class AppModule {

  @Provides
  @Singleton
  @SuppressWarnings("unused")
  public Gson provideGson() {
    return new GsonBuilder()
        .setDateFormat("yyyy'-'MM'-'dd HH':'mm':'ss")
        .create();
  }

}
