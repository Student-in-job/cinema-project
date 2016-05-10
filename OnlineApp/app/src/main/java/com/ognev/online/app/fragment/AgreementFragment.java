package com.ognev.online.app.fragment;

import android.support.v4.app.Fragment;
import com.ognev.online.app.R;

public class AgreementFragment extends SingleFragment {
  @Override
  public int getLayoutId() {
    return R.layout.agreement_view;
  }

  public static Fragment newInstance() {
    AgreementFragment fragment = new AgreementFragment();
    return fragment;
  }
}
