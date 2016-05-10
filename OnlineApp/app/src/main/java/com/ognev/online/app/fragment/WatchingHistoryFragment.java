package com.ognev.online.app.fragment;

import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.v7.widget.LinearLayoutManager;
import android.support.v7.widget.RecyclerView;
import android.view.View;
import butterknife.Bind;
import com.ognev.online.app.R;

public class WatchingHistoryFragment extends BaseFragment {

  @Bind(R.id.list) RecyclerView recyclerView;

  @Override
  public int getLayoutId() {
    return R.layout.watch_history;
  }

  @Override
  public void onViewCreated(View view, @Nullable Bundle savedInstanceState) {
    super.onViewCreated(view, savedInstanceState);
    recyclerView.setHasFixedSize(true);
    recyclerView.setLayoutManager(new LinearLayoutManager(getActivity()));
  }

  public static WatchingHistoryFragment newInstance() {
    WatchingHistoryFragment fragment = new WatchingHistoryFragment();
    Bundle bundle = new Bundle();
    fragment.setArguments(bundle);
    return fragment;
  }
}
