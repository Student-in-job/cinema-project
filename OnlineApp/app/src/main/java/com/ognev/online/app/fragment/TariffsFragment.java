package com.ognev.online.app.fragment;

import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.v7.widget.LinearLayoutManager;
import android.support.v7.widget.RecyclerView;
import android.view.View;
import butterknife.Bind;
import com.ognev.online.app.R;
import com.ognev.online.app.activity.BaseActivity;
import com.ognev.online.app.adapter.TariffAdapter;
import com.ognev.online.app.model.ResponseObject;
import com.ognev.online.app.model.Tariff;
import retrofit.Callback;
import retrofit.RetrofitError;
import retrofit.client.Response;

import java.util.ArrayList;
import java.util.List;

public class TariffsFragment extends BaseFragment {
  private TariffAdapter tariffAdapter;
  private List<Tariff> tariffs;

  @Bind(R.id.tariff_list) RecyclerView tariffList;

  @Override
  public int getLayoutId() {
    return R.layout.tariffs_fragment;
  }


  @Override
  public void onCreate(@Nullable Bundle savedInstanceState) {
    super.onCreate(savedInstanceState);

    tariffs = new ArrayList<>();

    tariffAdapter = new TariffAdapter((BaseActivity) getActivity(), tariffs);

  }

  @Override
  public void onViewCreated(View view, @Nullable Bundle savedInstanceState) {
    super.onViewCreated(view, savedInstanceState);

    ((BaseActivity) getActivity()).tariffService.getTariffs(new Callback<ResponseObject<List<Tariff>>>() {
      @Override
      public void success(ResponseObject<List<Tariff>> tariffsr, Response response) {
        tariffs.addAll(tariffsr.data);
        tariffAdapter.notifyDataSetChanged();
      }

      @Override
      public void failure(RetrofitError error) {

      }
    });
    tariffList.setLayoutManager(new LinearLayoutManager(getActivity()));
    tariffList.setHasFixedSize(true);
//    tariffList.addItemDecoration(new DividerItemDecoration(getActivity(), DividerItemDecoration.VERTICAL_LIST));
    tariffList.setAdapter(tariffAdapter);
  }

  public static TariffsFragment newInstance() {
    TariffsFragment fragment = new TariffsFragment();
    return fragment;
  }
}
