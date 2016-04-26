package com.android.online.app.activity;

import android.os.Bundle;
import android.os.PersistableBundle;
import android.support.annotation.LayoutRes;
import android.support.annotation.Nullable;
import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentTransaction;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.Toolbar;
import butterknife.Bind;
import butterknife.ButterKnife;
import com.android.online.app.R;
import com.android.online.app.dagger.components.DaggerServiceComponent;
import com.android.online.app.dagger.components.ServiceComponent;
import com.android.online.app.dagger.modules.ServiceModule;
import com.android.online.app.service.LoginService;
import com.android.online.app.service.ReviewService;
import com.android.online.app.service.VideoService;

import javax.inject.Inject;

public abstract class BaseActivity extends AppCompatActivity {
  private ServiceComponent serviceComponent;

  @Inject LoginService loginService;
  @Inject VideoService videoService;
  @Inject ReviewService reviewService;
  @Bind(R.id.toolbar) public @Nullable Toolbar toolbar;

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
    if(toolbar != null) {
      setSupportActionBar(toolbar);
      getSupportActionBar().setTitle("");
    }
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

  public void showFragment(Fragment fragment) {
    FragmentTransaction fragmentTransaction = getSupportFragmentManager().beginTransaction();
    fragmentTransaction.replace(R.id.root, fragment);
    fragmentTransaction.addToBackStack(null);
    fragmentTransaction.commit();
  }
}
