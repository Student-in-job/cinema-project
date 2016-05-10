package com.ognev.online.app.dagger.components;


import com.ognev.online.app.activity.BaseActivity;
import com.ognev.online.app.activity.ReviewsActivity;
import com.ognev.online.app.dagger.modules.AppModule;
import com.ognev.online.app.dagger.modules.ServiceModule;
import com.ognev.online.app.fragment.BaseFragment;
import com.google.gson.Gson;
import com.ognev.online.app.service.*;
import dagger.Component;
import retrofit.RestAdapter;

import javax.inject.Singleton;

@Singleton
@Component(modules = {ServiceModule.class, AppModule.class})
public interface ServiceComponent {

  void inject(BaseActivity baseActivity);
  void inject(ReviewsActivity baseActivity);

  void inject(BaseFragment baseFragment);

  Gson gson();

  RestAdapter restAdapter();

  LoginService loginService();

  VideoService videoService();

  ReviewService reviewService();

  TariffService tariffService();

  ProfileService profileService();


}
