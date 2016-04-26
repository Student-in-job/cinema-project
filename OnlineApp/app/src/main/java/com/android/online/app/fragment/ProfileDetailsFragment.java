package com.android.online.app.fragment;

import android.os.Bundle;
import android.support.annotation.Nullable;
import android.view.View;
import com.android.online.app.R;
import com.android.online.app.adapter.ProfileDetailsAdapter;
import com.android.online.app.model.ProfileDetails;
import com.android.online.app.model.User;
import retrofit.Callback;
import retrofit.RetrofitError;
import retrofit.client.Response;

import java.util.ArrayList;
import java.util.List;

public class ProfileDetailsFragment extends BaseFragment {
//  @Bind(R.id.list) RecyclerView recyclerView;
  private ProfileDetailsAdapter profileDetailsAdapter;
  private List<ProfileDetails> detailses;

  @Override
  public int getLayoutId() {
    return R.layout.profile_details;
  }

  @Override
  public void onViewCreated(View view, @Nullable Bundle savedInstanceState) {
    super.onViewCreated(view, savedInstanceState);
    videoService.getProfile(new Callback<User>() {
      @Override
      public void success(User user, Response response) {
        initializeUser(user);
      }

      @Override
      public void failure(RetrofitError error) {

      }
    });


  }

  private void initializeUser(User user) {
    detailses = new ArrayList<>();
    detailses.add(new ProfileDetails(getString(R.string.first_name), user.firstName));
    detailses.add(new ProfileDetails(getString(R.string.last_name), user.lastName));
    detailses.add(new ProfileDetails(getString(R.string.login), user.login));
    detailses.add(new ProfileDetails(getString(R.string.email), user.email));
//    detailses.add(new ProfileDetails(getString(R.string.birth_date), user.birthdate));
    detailses.add(new ProfileDetails(getString(R.string.gender), user.gender == 1 ? getString(R.string.male) :  getString(R.string.female)));
    profileDetailsAdapter = new ProfileDetailsAdapter(getActivity(), detailses);
//    recyclerView.setHasFixedSize(true);
//    recyclerView.setLayoutManager(new LinearLayoutManager(getActivity()));
//    recyclerView.setAdapter(profileDetailsAdapter);

  }

  public static ProfileDetailsFragment newInstance() {
    ProfileDetailsFragment fragment = new ProfileDetailsFragment();
    Bundle bundle = new Bundle();
    fragment.setArguments(bundle);
    return fragment;
  }
}
