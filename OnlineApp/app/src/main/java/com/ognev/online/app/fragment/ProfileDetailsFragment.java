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
import com.ognev.online.app.activity.MainActivity;
import com.ognev.online.app.activity.TariffActivity;
import com.ognev.online.app.adapter.ProfileDetailsAdapter;
import com.ognev.online.app.model.ProfileDetails;
import com.ognev.online.app.model.User;
import retrofit.Callback;
import retrofit.RetrofitError;
import retrofit.client.Response;

import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.List;
import java.util.Locale;

  public class ProfileDetailsFragment extends BaseFragment {
    private ProfileDetailsAdapter profileDetailsAdapter;
    private List<ProfileDetails> detailses;

    @Bind(R.id.tariff_view) View tariffView;
    @Bind(R.id.tariff_info) View tariffInfo;
    @Bind(R.id.tariff) TextView tariffTv;
    @Bind(R.id.date) TextView date;
    @Bind(R.id.first_name) TextView firstName;
    @Bind(R.id.last_name) TextView lastName;
    @Bind(R.id.login) TextView login;
    @Bind(R.id.email) TextView email;
    @Bind(R.id.birth_date) TextView birthDate;
    @Bind(R.id.balance) TextView balance;
    @Bind(R.id.account) TextView accountId;
    @Bind(R.id.progress) ProgressBar progressBar;
    @Bind(R.id.content) View content;
    private User user;
    private SimpleDateFormat mDateFormat;


    @Override
    public void onCreate(@Nullable Bundle savedInstanceState) {
      super.onCreate(savedInstanceState);
      mDateFormat = new SimpleDateFormat(
          getString(R.string.birth_date_format),
          new Locale("ru")); //todo
    }

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
          ProfileDetailsFragment.this.user = user;
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

    @Override
    public void onResume() {
      super.onResume();
      if(content != null) {
        content.setVisibility(View.GONE);
        progressBar.setVisibility(View.VISIBLE);
        profileService.getProfile(new Callback<User>() {
          @Override
          public void success(User user, Response response) {
            ProfileDetailsFragment.this.user = user;
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
    }

    private void initializeUser(User user) {
      detailses = new ArrayList<>();
      firstName.setText(user.firstName);
      lastName.setText(user.lastName);
      login.setText(user.login);
      email.setText(user.email);
      accountId.setText(String.valueOf(user.accountId));
      balance.setText(user.balance + " сум.");
      tariffTv.setText(user.subscription == null ? "подпишитесь на тариф" : user.subscription.tariffName);
      if(user.subscription != null) {
        tariffInfo.setVisibility(View.VISIBLE);
        date.setText(mDateFormat.format(user.subscription.end));
      }

    }

    @OnClick(R.id.tariff_card)
    public void onTariffsClicked() {
      startActivity(new Intent(getActivity(), TariffActivity.class));
    }


    @OnClick(R.id.fab)
    public void onFabClicked() {
      ((MainActivity) getActivity()).showFragment(ProfileEditFragment.newInstance(user));
    }

    public static ProfileDetailsFragment newInstance() {
      ProfileDetailsFragment fragment = new ProfileDetailsFragment();
      Bundle bundle = new Bundle();
      fragment.setArguments(bundle);
      return fragment;
    }
  }
