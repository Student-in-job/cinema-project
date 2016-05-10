package com.ognev.online.app.dagger.modules;

import com.ognev.online.app.service.*;
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

  @Provides
  @Singleton
  @SuppressWarnings("unused")
  TariffService provideTariffService(RestAdapter restAdapter) {
    return restAdapter.create(TariffService.class);
  }


  @Provides
  @Singleton
  @SuppressWarnings("unused")
  ProfileService provideProfileService(RestAdapter restAdapter) {
    return restAdapter.create(ProfileService.class);
  }
}
