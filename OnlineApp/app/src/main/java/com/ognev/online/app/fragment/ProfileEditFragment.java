package com.ognev.online.app.fragment;

import com.ognev.online.app.R;

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
