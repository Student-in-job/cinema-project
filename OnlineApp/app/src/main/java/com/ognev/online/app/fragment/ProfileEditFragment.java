package com.ognev.online.app.fragment;

import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.design.widget.TextInputEditText;
import android.view.View;
import butterknife.Bind;
import butterknife.OnClick;
import com.ognev.online.app.Constants;
import com.ognev.online.app.R;
import com.ognev.online.app.model.User;
import org.parceler.Parcels;

public class ProfileEditFragment extends SingleFragment {

  @Bind(R.id.first_name) TextInputEditText firstName;
  @Bind(R.id.last_name) TextInputEditText lastName;
  @Bind(R.id.login) TextInputEditText login;
  @Bind(R.id.email) TextInputEditText email;
  @Bind(R.id.birth_date) TextInputEditText birthDate;
  private User user;

  @Override
  public int getLayoutId() {
    return R.layout.profile_edit;
  }

  public static ProfileEditFragment newInstance(User user) {
    ProfileEditFragment fragment = new ProfileEditFragment();
    Bundle bundle = new Bundle();
    bundle.putParcelable(Constants.USER, Parcels.wrap(user));
    fragment.setArguments(bundle);
    return fragment;
  }

  @Override
  public void onViewCreated(View view, @Nullable Bundle savedInstanceState) {
    super.onViewCreated(view, savedInstanceState);
    user = Parcels.unwrap(getArguments().getParcelable(Constants.USER));
    firstName.setText(user.firstName);
    lastName.setText(user.lastName);
    login.setText(user.login);
    email.setText(user.email);
//    birthDate.setText(user.birthdate);
  }

  @OnClick(R.id.fab)
  public void onFabClicked() {
    getActivity().onBackPressed();
  }
}
