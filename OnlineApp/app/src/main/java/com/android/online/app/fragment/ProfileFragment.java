package com.android.online.app.fragment;

import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.design.widget.CollapsingToolbarLayout;
import android.support.design.widget.FloatingActionButton;
import android.support.design.widget.TabLayout;
import android.support.v4.view.ViewPager;
import android.view.View;
import butterknife.Bind;
import butterknife.OnClick;
import com.android.online.app.R;
import com.android.online.app.activity.MainActivity;
import com.android.online.app.adapter.ProfileAdapter;

import java.util.ArrayList;
import java.util.List;

public class ProfileFragment extends SingleFragment {

  @Bind(R.id.tabs) TabLayout tabLayout;
  @Bind(R.id.viewpager) ViewPager viewPager;
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

//    toolbarLayout.setTitle("Сера");
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


  public static ProfileFragment newInstance() {
    ProfileFragment profileFragment = new ProfileFragment();
    return profileFragment;
  }
}
