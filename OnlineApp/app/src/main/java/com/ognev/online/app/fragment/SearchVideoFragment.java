package com.ognev.online.app.fragment;

import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.Intent;
import android.content.IntentFilter;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.v7.widget.LinearLayoutManager;
import android.support.v7.widget.RecyclerView;
import android.view.View;
import android.widget.Toast;
import butterknife.Bind;
import com.ognev.online.app.Constants;
import com.ognev.online.app.R;
import com.ognev.online.app.activity.BaseActivity;
import com.ognev.online.app.adapter.SearchResultAdapter;
import com.ognev.online.app.model.BaseVideo;
import com.ognev.online.app.model.ResponseObject;
import com.ognev.online.app.model.VideoDataListWrapper;
import retrofit.Callback;
import retrofit.RetrofitError;
import retrofit.client.Response;

import java.util.ArrayList;
import java.util.List;

public class SearchVideoFragment extends BaseFragment {

  @Bind(R.id.list) RecyclerView recyclerView;
  private SearchResultAdapter searchResultAdapter;

  public static boolean isDead = true;
  private List<VideoDataListWrapper> items;


  @Override
  public void onCreate(@Nullable Bundle savedInstanceState) {
    super.onCreate(savedInstanceState);
    items = new ArrayList<>();
    searchResultAdapter = new SearchResultAdapter(getActivity(), items);
  }

  public static SearchVideoFragment newInstance() {
    SearchVideoFragment searchVideoFragment = new SearchVideoFragment();
    return searchVideoFragment;
  }

  @Override
  public void onResume() {
    super.onResume();
    IntentFilter intentFilter = new IntentFilter();
    intentFilter.addAction(Constants.SEARCH);
    getActivity().registerReceiver(broadcastReceiver, intentFilter);
    isDead = false;
  }

  @Override
  public int getLayoutId() {
    return R.layout.recycler_list;
  }

  @Override
  public void onViewCreated(View view, @Nullable Bundle savedInstanceState) {
    super.onViewCreated(view, savedInstanceState);

    recyclerView.setLayoutManager(new LinearLayoutManager(getActivity()));
    recyclerView.setHasFixedSize(true);
    recyclerView.setAdapter(searchResultAdapter);
  }

  @Override
  public void onPause() {
    super.onPause();
    isDead = true;
    getActivity().unregisterReceiver(broadcastReceiver);
  }

  private BroadcastReceiver broadcastReceiver = new BroadcastReceiver() {
    @Override
    public void onReceive(Context context, Intent intent) {
      items.clear();
      String query = intent.getStringExtra(Constants.QUERY);
      Toast.makeText(getActivity(), query, Toast.LENGTH_SHORT).show();
      ((BaseActivity) getActivity()).videoService.searchVideo(query, new Callback<ResponseObject<List<BaseVideo>>>() {
        @Override
        public void success(ResponseObject<List<BaseVideo>> listResponseObject, Response response) {
          items.addAll(listResponseObject.data);
          searchResultAdapter.notifyDataSetChanged();
        }

        @Override
        public void failure(RetrofitError error) {

        }
      });
    }
  };
}
