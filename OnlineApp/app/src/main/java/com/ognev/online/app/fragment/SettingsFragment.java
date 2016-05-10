package com.ognev.online.app.fragment;

import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.v4.widget.DrawerLayout;
import android.view.View;
import android.widget.EditText;
import butterknife.Bind;
import butterknife.OnClick;
import com.ognev.online.app.Constants;
import com.ognev.online.app.R;
import com.ognev.online.app.activity.MenuActivity;
import com.ognev.online.app.util.Prefs;

public class SettingsFragment extends BaseFragment {

  @Bind(R.id.ip) EditText serverIp;

  @Override
  public int getLayoutId() {
    return R.layout.settings;
  }

  @Override
  public void onCreate(@Nullable Bundle savedInstanceState) {
    super.onCreate(savedInstanceState);
  }

  @Override
  public void onResume() {
    super.onResume();
    ((MenuActivity) getActivity()).mDrawerLayout.setDrawerLockMode(DrawerLayout.LOCK_MODE_LOCKED_CLOSED);
//    ((MenuActivity) getActivity()).toolbar.setVisibility(View.GONE);
  }

  @Override
  public void onPause() {
    super.onPause();
    ((MenuActivity) getActivity()).mDrawerLayout.setDrawerLockMode(DrawerLayout.LOCK_MODE_UNLOCKED);
//    ((MenuActivity) getActivity()).toolbar.setVisibility(View.VISIBLE);
  }


  @Override
  public void onViewCreated(View view, @Nullable Bundle savedInstanceState) {
    super.onViewCreated(view, savedInstanceState);
//    ((MainActivity) getActivity()).getSupportActionBar().setDisplayHomeAsUpEnabled(true);
//    ((MainActivity) getActivity()).getSupportActionBar().setTitle("");
    serverIp.setText(Prefs.getIp().replace("http://",""));
  }

  @OnClick(R.id.save) public void save() {
    Prefs.saveIp(serverIp.getText().toString());
    Constants.setBASE_URL(Prefs.getIp());
  }

  public static SettingsFragment newInstance() {
    SettingsFragment settingsFragment = new SettingsFragment();
    return settingsFragment;
  }
}
