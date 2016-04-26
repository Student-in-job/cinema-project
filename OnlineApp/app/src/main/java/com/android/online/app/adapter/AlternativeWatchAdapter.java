package com.android.online.app.adapter;

import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentManager;
import android.support.v4.app.FragmentPagerAdapter;
import com.android.online.app.fragment.VideoPage;

import java.util.List;

public class AlternativeWatchAdapter extends FragmentPagerAdapter {
  List<VideoPage> pageFragments;
  public AlternativeWatchAdapter(FragmentManager fm, List<VideoPage> pageFragments) {
    super(fm);
    this.pageFragments  = pageFragments;
  }

  @Override
  public Fragment getItem(int position) {
    return pageFragments.get(position);
  }

  @Override
  public int getCount() {
    return pageFragments.size();
  }
}
