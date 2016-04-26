package com.android.online.app.fragment;

import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.v7.widget.LinearLayoutManager;
import android.support.v7.widget.RecyclerView;
import android.view.View;
import butterknife.Bind;
import com.android.online.app.R;
import com.android.online.app.adapter.VideoHistoryAdapter;
import com.android.online.app.model.MovieHistory;
import com.android.online.app.model.MovieHistoryWrapper;
import retrofit.Callback;
import retrofit.RetrofitError;
import retrofit.client.Response;

import java.util.ArrayList;
import java.util.List;

public class VideoHistoryFragment extends BaseFragment {

  @Bind(R.id.list)
  RecyclerView mRecyclerView;
  private VideoHistoryAdapter mAdapter;

  private List<MovieHistory> movieHistories;

  @Override
  public int getLayoutId() {
    return R.layout.recycler_list;
  }


  @Override
  public void onViewCreated(View view, @Nullable Bundle savedInstanceState) {
    super.onViewCreated(view, savedInstanceState);
    movieHistories = new ArrayList<>();
    mRecyclerView.setHasFixedSize(true);
    mRecyclerView.setLayoutManager(new LinearLayoutManager(getActivity()));
    videoService.getHistory(new Callback<MovieHistoryWrapper>() {
      @Override
      public void success(MovieHistoryWrapper movieHistoryWrapper, Response response) {
        movieHistories.addAll(movieHistoryWrapper.histories);
        mAdapter = new VideoHistoryAdapter(getActivity(), movieHistories);
        mRecyclerView.setAdapter(mAdapter);
      }

      @Override
      public void failure(RetrofitError error) {

      }
    });
  }

  public static VideoHistoryFragment newInstance() {
    VideoHistoryFragment fragment = new VideoHistoryFragment();
    Bundle bundle = new Bundle();
    fragment.setArguments(bundle);
    return fragment;
  }
}
