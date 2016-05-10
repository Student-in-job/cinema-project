package com.ognev.online.app.fragment;

import android.content.Intent;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.view.View;
import android.widget.ProgressBar;
import android.widget.TextView;
import butterknife.Bind;
import butterknife.OnClick;
import com.ognev.online.app.R;
import com.ognev.online.app.activity.TariffActivity;
import com.ognev.online.app.adapter.ProfileDetailsAdapter;
import com.ognev.online.app.model.ProfileDetails;
import com.ognev.online.app.model.User;
import retrofit.Callback;
import retrofit.RetrofitError;
import retrofit.client.Response;

import java.util.ArrayList;
import java.util.List;

public class ProfileDetailsFragment extends BaseFragment {
//  @Bind(R.id.list) RecyclerView recyclerView;
  private ProfileDetailsAdapter profileDetailsAdapter;
  private List<ProfileDetails> detailses;

  @Bind(R.id.tariff_view) View tariffView;
  @Bind(R.id.select_tariff) View selectTariff;
  @Bind(R.id.tariff) TextView tariffTv;
  @Bind(R.id.first_name) TextView firstName;
  @Bind(R.id.last_name) TextView lastName;
  @Bind(R.id.login) TextView login;
  @Bind(R.id.email) TextView email;
  @Bind(R.id.birth_date) TextView birthDate;
  @Bind(R.id.phone) TextView phone;
  @Bind(R.id.balance) TextView balance;
  @Bind(R.id.progress) ProgressBar progressBar;
  @Bind(R.id.content) View content;

  @Override
  public int getLayoutId() {
    return R.layout.profile_details;
  }

  @Override
  public void onViewCreated(View view, @Nullable Bundle savedInstanceState) {
    super.onViewCreated(view, savedInstanceState);
    content.setVisibility(View.GONE);
    progressBar.setVisibility(View.VISIBLE);
    profileService.getProfile(new Callback<User>() {
      @Override
      public void success(User user, Response response) {
        progressBar.setVisibility(View.GONE);
        content.setVisibility(View.VISIBLE);
        initializeUser(user);
      }

      @Override
      public void failure(RetrofitError error) {
        progressBar.setVisibility(View.GONE);
      }
    });


  }

  private void initializeUser(User user) {
    detailses = new ArrayList<>();
    firstName.setText(user.firstName);
    lastName.setText(user.lastName);
    login.setText(user.login);
    email.setText(user.email);
    balance.setText(user.balance + " сум.");
    tariffTv.setText(user.subscription == null ? "подпишитесь на тариф" : user.subscription.tariffName);
//    detailses.add(new ProfileDetails(getString(R.string.first_name), user.firstName));
//    detailses.add(new ProfileDetails(getString(R.string.last_name), user.lastName));
//    detailses.add(new ProfileDetails(getString(R.string.login), user.login));
//    detailses.add(new ProfileDetails(getString(R.string.email), user.email));
//    detailses.add(new ProfileDetails(getString(R.string.birth_date), user.birthdate));
//    detailses.add(new ProfileDetails(getString(R.string.gender), user.gender == 1 ? getString(R.string.male) :  getString(R.string.female)));
//    profileDetailsAdapter = new ProfileDetailsAdapter(getActivity(), detailses);
//    recyclerView.setHasFixedSize(true);
//    recyclerView.setLayoutManager(new LinearLayoutManager(getActivity()));
//    recyclerView.setAdapter(profileDetailsAdapter);

  }

  @OnClick(R.id.tariff_card)
  public void onTariffsClicked() {
    startActivity(new Intent(getActivity(), TariffActivity.class));
  }


  public static ProfileDetailsFragment newInstance() {
    ProfileDetailsFragment fragment = new ProfileDetailsFragment();
    Bundle bundle = new Bundle();
    fragment.setArguments(bundle);
    return fragment;
  }
}
