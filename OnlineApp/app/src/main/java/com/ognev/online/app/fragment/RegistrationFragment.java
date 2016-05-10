package com.ognev.online.app.fragment;

import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.v4.app.Fragment;
import butterknife.OnClick;
import com.ognev.online.app.R;

public class RegistrationFragment extends BaseFragment {
  @Override
  public int getLayoutId() {
    return R.layout.registration_fragment;
  }

  @Override
  public void onCreate(@Nullable Bundle savedInstanceState) {
    super.onCreate(savedInstanceState);
  }

  public static Fragment newInstance() {
    RegistrationFragment fragment = new RegistrationFragment();
    return fragment;
  }

  @OnClick(R.id.login)
  public void onBackClicked() {
    getActivity().onBackPressed();
  }
}
