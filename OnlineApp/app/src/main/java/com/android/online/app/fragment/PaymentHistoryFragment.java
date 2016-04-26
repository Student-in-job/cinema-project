package com.android.online.app.fragment;

import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.v7.widget.LinearLayoutManager;
import android.support.v7.widget.RecyclerView;
import android.view.View;
import butterknife.Bind;
import com.android.online.app.R;
import com.android.online.app.adapter.UserVideoHistoryAdapter;
import com.android.online.app.model.PurchaseWrapper;
import com.android.online.app.model.UserVideo;
import retrofit.Callback;
import retrofit.RetrofitError;
import retrofit.client.Response;

import java.util.ArrayList;
import java.util.List;

public class PaymentHistoryFragment extends BaseFragment {

  @Bind(R.id.list)
  RecyclerView mRecyclerView;
  private UserVideoHistoryAdapter mAdapter;

  private List<UserVideo> movieHistories;


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
    videoService.getProfilePurchases(new Callback<PurchaseWrapper>() {
      @Override
      public void success(PurchaseWrapper purchaseWrapper, Response response) {
        movieHistories.addAll(purchaseWrapper.purchases);
        mAdapter = new UserVideoHistoryAdapter(getActivity(), movieHistories);
        mRecyclerView.setAdapter(mAdapter);
      }

      @Override
      public void failure(RetrofitError error) {

      }
    });
  }

  public static PaymentHistoryFragment newInstance() {
    PaymentHistoryFragment fragment = new PaymentHistoryFragment();
    Bundle bundle = new Bundle();
    fragment.setArguments(bundle);
    return fragment;
  }
}
