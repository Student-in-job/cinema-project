package com.ognev.online.app.activity;

import android.os.Bundle;
import android.os.PersistableBundle;
import android.support.annotation.LayoutRes;
import android.support.annotation.Nullable;
import android.support.annotation.StringRes;
import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentTransaction;
import android.support.v7.app.AlertDialog;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.Toolbar;
import butterknife.Bind;
import butterknife.ButterKnife;
import com.ognev.online.app.R;
import com.ognev.online.app.dagger.components.DaggerServiceComponent;
import com.ognev.online.app.dagger.components.ServiceComponent;
import com.ognev.online.app.dagger.modules.ServiceModule;
import com.ognev.online.app.service.LoginService;
import com.ognev.online.app.service.ReviewService;
import com.ognev.online.app.service.TariffService;
import com.ognev.online.app.service.VideoService;

import javax.inject.Inject;

public abstract class BaseActivity extends AppCompatActivity {
  private ServiceComponent serviceComponent;

  @Inject public LoginService loginService;
  @Inject public VideoService videoService;
  @Inject public ReviewService reviewService;
  @Inject public TariffService tariffService;
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
 public void showFragmentWithoutBackStack(Fragment fragment) {
    FragmentTransaction fragmentTransaction = getSupportFragmentManager().beginTransaction();
    fragmentTransaction.replace(R.id.root, fragment);
    fragmentTransaction.commit();
  }

  public void showInfoDialog(@StringRes int stringRes) {
    AlertDialog.Builder builder = new AlertDialog.Builder(BaseActivity.this);
    builder.setTitle(stringRes);
    builder.setPositiveButton("ok", null);
    builder.show();
  }

  public void showInfoDialog(String message) {
    AlertDialog.Builder builder = new AlertDialog.Builder(BaseActivity.this);
    builder.setTitle(message);
    builder.setPositiveButton("ok", null);
    builder.show();
  }
}
