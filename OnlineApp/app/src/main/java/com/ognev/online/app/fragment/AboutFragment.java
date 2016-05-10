package com.ognev.online.app.fragment;

import android.support.v4.app.Fragment;
import com.ognev.online.app.R;

public class AboutFragment extends SingleFragment {
  @Override
  public int getLayoutId() {
    return R.layout.about_view;
  }

  public static Fragment newInstance() {
    AboutFragment aboutFragment = new AboutFragment();
    return aboutFragment;
  }
}
