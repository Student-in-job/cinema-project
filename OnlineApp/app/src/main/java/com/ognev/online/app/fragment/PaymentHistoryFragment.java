package com.ognev.online.app.fragment;

import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.v7.widget.LinearLayoutManager;
import android.support.v7.widget.RecyclerView;
import android.view.View;
import butterknife.Bind;
import com.ognev.online.app.R;
import com.ognev.online.app.adapter.UserVideoHistoryAdapter;
import com.ognev.online.app.model.PurchaseWrapper;
import com.ognev.online.app.model.ResponseObject;
import com.ognev.online.app.model.UserVideo;
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
    profileService.getProfilePurchases(new Callback<ResponseObject<PurchaseWrapper>>() {
      @Override
      public void success(ResponseObject<PurchaseWrapper> purchaseWrapper, Response response) {
        if(isAdded()) {
          movieHistories.addAll(purchaseWrapper.data.purchases);
          mAdapter = new UserVideoHistoryAdapter(getActivity(), movieHistories);
          mRecyclerView.setAdapter(mAdapter);
        }
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
