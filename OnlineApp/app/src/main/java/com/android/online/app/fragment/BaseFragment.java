package com.android.online.app.fragment;

import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.v4.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import butterknife.ButterKnife;

public abstract class BaseFragment extends Fragment {

  @Nullable
  @Override
  public final View onCreateView(LayoutInflater inflater,
                           @Nullable ViewGroup container,
                           @Nullable Bundle savedInstanceState) {

    View view = inflater.inflate(getLayoutId(), container);
    ButterKnife.bind(this, view);
    return super.onCreateView(inflater, container, savedInstanceState);
  }

  public abstract int getLayoutId();

}
