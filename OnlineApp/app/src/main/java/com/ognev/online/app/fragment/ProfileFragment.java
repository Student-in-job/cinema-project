package com.ognev.online.app.fragment;

import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.design.widget.CollapsingToolbarLayout;
import android.support.design.widget.FloatingActionButton;
import android.support.design.widget.TabLayout;
import android.support.v4.view.ViewPager;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.View;
import android.widget.TextView;
import butterknife.Bind;
import butterknife.OnClick;
import com.ognev.online.app.R;
import com.ognev.online.app.activity.MainActivity;
import com.ognev.online.app.adapter.ProfileAdapter;
import com.ognev.online.app.util.Prefs;

import java.util.ArrayList;
import java.util.List;

public class ProfileFragment extends SingleFragment {

  @Bind(R.id.tabs) TabLayout tabLayout;
  @Bind(R.id.viewpager) ViewPager viewPager;
  @Bind(R.id.name) TextView name;
  @Bind(R.id.fab) FloatingActionButton fab;
  @Bind(R.id.collapsing_toolbar) CollapsingToolbarLayout toolbarLayout;


  private ProfileAdapter profileAdapter;
  private List<BaseFragment> baseFragments;

  @Override
  public void onCreate(@Nullable Bundle savedInstanceState) {
    super.onCreate(savedInstanceState);
  }

  @Override
  public int getLayoutId() {
    return R.layout.profile_view;
  }

  @Override
  public void onViewCreated(View view, @Nullable Bundle savedInstanceState) {
    super.onViewCreated(view, savedInstanceState);
    baseFragments = new ArrayList<>();
    baseFragments.add(ProfileDetailsFragment.newInstance());
    baseFragments.add(VideoHistoryFragment.newInstance());
    baseFragments.add(PaymentHistoryFragment.newInstance());

    name.setText(Prefs.getUserName());
    profileAdapter = new ProfileAdapter(getContext(), baseFragments, getChildFragmentManager());
    viewPager.setOffscreenPageLimit(3);
    viewPager.setAdapter(profileAdapter);
    tabLayout.setupWithViewPager(viewPager);
    viewPager.addOnPageChangeListener(new ViewPager.OnPageChangeListener() {
      @Override
      public void onPageScrolled(int position, float positionOffset, int positionOffsetPixels) {

      }

      @Override
      public void onPageSelected(int position) {

        switch (position) {
          case 0:
            fab.setVisibility(View.VISIBLE);
            break;
          default:fab.setVisibility(View.GONE);
            break;
        }
      }

      @Override
      public void onPageScrollStateChanged(int state) {

      }
    });

    profileAdapter.notifyDataSetChanged();

  }

  @OnClick(R.id.fab)
  public void onFabClicked() {
    ((MainActivity) getActivity()).showFragment(ProfileEditFragment.newInstance());
  }


  @Override
  public void onCreateOptionsMenu(Menu menu, MenuInflater inflater) {
    inflater.inflate(R.menu.empty_menu, menu);
    super.onCreateOptionsMenu(menu, inflater);
  }

  public static ProfileFragment newInstance() {
    ProfileFragment profileFragment = new ProfileFragment();
    return profileFragment;
  }
}
