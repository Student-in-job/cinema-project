package com.android.online.app.fragment;

import com.android.online.app.R;

public class ProfileEditFragment extends SingleFragment {
  @Override
  public int getLayoutId() {
    return R.layout.profile_edit;
  }

  public static ProfileEditFragment newInstance() {
    ProfileEditFragment fragment = new ProfileEditFragment();
    return fragment;
  }
}
