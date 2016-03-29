package com.android.online.app.activity;

import android.os.Bundle;
import android.os.PersistableBundle;
import android.support.annotation.LayoutRes;
import android.support.annotation.Nullable;
import android.support.v7.app.AppCompatActivity;
import butterknife.ButterKnife;
import com.android.online.app.dagger.components.DaggerServiceComponent;
import com.android.online.app.dagger.components.ServiceComponent;
import com.android.online.app.dagger.modules.ServiceModule;
import com.android.online.app.service.LoginService;
import com.android.online.app.service.VideoService;

import javax.inject.Inject;

public abstract class BaseActivity extends AppCompatActivity {
  private ServiceComponent serviceComponent;

  @Inject LoginService loginService;
  @Inject VideoService videoService;

  @Override
  public void onCreate(Bundle savedInstanceState, PersistableBundle persistentState) {
    super.onCreate(savedInstanceState, persistentState);
    initializeInjector();
  }

  @Override
  protected void onCreate(@Nullable Bundle savedInstanceState) {
    super.onCreate(savedInstanceState);
    initializeInjector();
  }

  @Override
  public void setContentView(@LayoutRes int layoutResID) {
    super.setContentView(layoutResID);
    ButterKnife.bind(this);
  }

  private void initializeInjector() {
    serviceComponent = DaggerServiceComponent.builder()
        .serviceModule(new ServiceModule())
        .build();
    serviceComponent.inject(this);
  }

  public ServiceComponent getServiceComponent() {
    return serviceComponent;
  }
}
