package com.android.online.app.dagger.components;


import com.android.online.app.activity.BaseActivity;
import com.android.online.app.dagger.modules.AppModule;
import com.android.online.app.dagger.modules.ServiceModule;
import com.android.online.app.fragment.BaseFragment;
import com.android.online.app.service.LoginService;
import com.android.online.app.service.VideoService;
import com.google.gson.Gson;
import dagger.Component;
import retrofit.RestAdapter;

import javax.inject.Singleton;

@Singleton
@Component(modules = {ServiceModule.class, AppModule.class})
public interface ServiceComponent {

  void inject(BaseActivity baseActivity);

  void inject(BaseFragment baseFragment);

  Gson gson();

  RestAdapter restAdapter();

  LoginService loginService();

  VideoService videoService();

}
