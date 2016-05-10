package com.ognev.online.app.adapter;

import android.content.Context;
import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentManager;
import android.support.v4.app.FragmentPagerAdapter;
import com.ognev.online.app.R;
import com.ognev.online.app.fragment.BaseFragment;

import java.util.List;

public class ProfileAdapter extends FragmentPagerAdapter {
  private List<BaseFragment> fragments;
  private String[] tabTitles;

  public ProfileAdapter(Context context, List<BaseFragment> fragments, FragmentManager fm) {
    super(fm);
    this.fragments = fragments;
    tabTitles = context.getResources().getStringArray(R.array.profile_tabs);

  }


  @Override
  public int getCount() {
    return fragments.size();
  }

  @Override
  public CharSequence getPageTitle(int position) {
    return tabTitles[position];
  }

  @Override
  public Fragment getItem(int position) {
    return fragments.get(position);
  }

}
