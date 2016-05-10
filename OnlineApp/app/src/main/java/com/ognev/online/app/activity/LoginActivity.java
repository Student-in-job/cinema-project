package com.ognev.online.app.activity;

import android.os.Bundle;
import android.support.annotation.Nullable;
import com.ognev.online.app.R;
import com.ognev.online.app.fragment.LoginFragment;

public class LoginActivity extends BaseActivity {

  @Override
  protected void onCreate(@Nullable Bundle savedInstanceState) {
    super.onCreate(savedInstanceState);
    setContentView(R.layout.main);
    getSupportActionBar().setDisplayHomeAsUpEnabled(true);
    showFragmentWithoutBackStack(LoginFragment.newInstance());
  }

  @Override
  public void onBackPressed() {
    super.onBackPressed();
  }
}
