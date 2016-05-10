package com.ognev.online.app.fragment;

import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.v4.widget.DrawerLayout;
import android.support.v7.widget.Toolbar;
import android.view.MenuItem;
import android.view.View;
import butterknife.Bind;
import com.ognev.online.app.R;
import com.ognev.online.app.activity.BaseActivity;
import com.ognev.online.app.activity.MenuActivity;

public class SingleFragment extends BaseFragment {

  @Nullable @Bind(R.id.toolbar) Toolbar toolbar;

  @Override
  public int getLayoutId() {
    return 0;
  }

  @Override
  public void onCreate(@Nullable Bundle savedInstanceState) {
    super.onCreate(savedInstanceState);
    setHasOptionsMenu(true);
  }

  @Override
  public void onResume() {
    super.onResume();
    ((MenuActivity) getActivity()).mDrawerLayout.setDrawerLockMode(DrawerLayout.LOCK_MODE_LOCKED_CLOSED);
    if(toolbar != null)
      ((MenuActivity) getActivity()).toolbar.setVisibility(View.GONE);
  }

  @Override
  public void onPause() {
    ((MenuActivity) getActivity()).mDrawerLayout.setDrawerLockMode(DrawerLayout.LOCK_MODE_UNLOCKED);
      ((MenuActivity) getActivity()).toolbar.setVisibility(View.VISIBLE);
      ((MenuActivity) getActivity()).toolbar.setNavigationIcon(R.drawable.ic_menu_white_24dp);
      super.onPause();

  }

  @Override
  public void onViewCreated(View view, @Nullable Bundle savedInstanceState) {
    super.onViewCreated(view, savedInstanceState);
    if(toolbar != null)
    ((BaseActivity)getActivity()).setSupportActionBar(toolbar);
    ((BaseActivity) getActivity()).getSupportActionBar().setDisplayHomeAsUpEnabled(true);
    ((BaseActivity) getActivity()).getSupportActionBar().setTitle("");
  }

  @Override
  public boolean onOptionsItemSelected(MenuItem item) {
    switch (item.getItemId()) {
      case android.R.id.home:
        getActivity().onBackPressed();
        break;
    }
    return super.onOptionsItemSelected(item);
  }
}
