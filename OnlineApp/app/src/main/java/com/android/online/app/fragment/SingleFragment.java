package com.android.online.app.fragment;

import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.v4.widget.DrawerLayout;
import android.support.v7.widget.Toolbar;
import android.view.MenuItem;
import android.view.View;
import butterknife.Bind;
import com.android.online.app.R;
import com.android.online.app.activity.MainActivity;
import com.android.online.app.activity.MenuActivity;

public class SingleFragment extends BaseFragment {

  @Bind(R.id.toolbar) Toolbar toolbar;

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
    ((MenuActivity) getActivity()).toolbar.setVisibility(View.GONE);
  }

  @Override
  public void onPause() {
    super.onPause();
    ((MenuActivity) getActivity()).mDrawerLayout.setDrawerLockMode(DrawerLayout.LOCK_MODE_UNLOCKED);
    ((MenuActivity) getActivity()).toolbar.setVisibility(View.VISIBLE);
  }

  @Override
  public void onViewCreated(View view, @Nullable Bundle savedInstanceState) {
    super.onViewCreated(view, savedInstanceState);
    ((MainActivity)getActivity()).setSupportActionBar(toolbar);
    ((MainActivity) getActivity()).getSupportActionBar().setDisplayHomeAsUpEnabled(true);
    ((MainActivity) getActivity()).getSupportActionBar().setTitle("");
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
