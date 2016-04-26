package com.android.online.app.fragment;

import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.v4.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import butterknife.ButterKnife;
import com.android.online.app.dagger.components.DaggerServiceComponent;
import com.android.online.app.dagger.components.ServiceComponent;
import com.android.online.app.dagger.modules.ServiceModule;
import com.android.online.app.service.ReviewService;
import com.android.online.app.service.VideoService;

import javax.inject.Inject;

public abstract class BaseFragment extends Fragment {
  private ServiceComponent serviceComponent;

  @Inject VideoService videoService;
  @Inject ReviewService reviewService;


  @Override
  public void onCreate(@Nullable Bundle savedInstanceState) {
    super.onCreate(savedInstanceState);
    initializeInjector();

  }

  private void initializeInjector() {
    serviceComponent = DaggerServiceComponent.builder()
        .serviceModule(new ServiceModule())
        .build();
    serviceComponent.inject(this);
  }

  @Nullable
  @Override
  public final View onCreateView(LayoutInflater inflater,
                           @Nullable ViewGroup container,
                           @Nullable Bundle savedInstanceState) {

    View view = inflater.inflate(getLayoutId(), null);
    ButterKnife.bind(this, view);
    return view;
  }

  public abstract int getLayoutId();

}
