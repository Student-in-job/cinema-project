package com.android.online.app.dagger.modules;

import com.android.online.app.service.LoginService;
import com.android.online.app.service.ReviewService;
import com.android.online.app.service.VideoService;
import dagger.Module;
import dagger.Provides;
import retrofit.RestAdapter;

import javax.inject.Singleton;

@Module
public class ServiceModule {

  @Provides
  @Singleton
  @SuppressWarnings("unused")
  LoginService provideLoginService(RestAdapter restAdapter) {
    return restAdapter.create(LoginService.class);
  }

  @Provides
  @Singleton
  @SuppressWarnings("unused")
  VideoService provideVideoService(RestAdapter restAdapter) {
    return restAdapter.create(VideoService.class);
  }

  @Provides
  @Singleton
  @SuppressWarnings("unused")
  ReviewService provideReviewService(RestAdapter restAdapter) {
    return restAdapter.create(ReviewService.class);
  }
}
