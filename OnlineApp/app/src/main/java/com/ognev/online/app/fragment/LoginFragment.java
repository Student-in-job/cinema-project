package com.ognev.online.app.fragment;

import android.app.ProgressDialog;
import android.content.DialogInterface;
import android.content.Intent;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.design.widget.TextInputLayout;
import android.support.v7.app.AlertDialog;
import android.text.TextUtils;
import android.view.MenuItem;
import android.view.View;
import android.widget.EditText;
import android.widget.Toast;
import butterknife.Bind;
import com.ognev.online.app.R;
import com.ognev.online.app.activity.BaseActivity;
import com.ognev.online.app.activity.MainActivity;
import com.ognev.online.app.model.LoginModel;
import com.ognev.online.app.service.RegisterModel;
import com.ognev.online.app.ui.MaterialLoginView;
import com.ognev.online.app.ui.MaterialLoginViewListener;
import com.ognev.online.app.util.Prefs;
import retrofit.Callback;
import retrofit.RetrofitError;
import retrofit.client.Response;

public class LoginFragment extends BaseFragment {
  @Bind(R.id.email) EditText login;
  @Bind(R.id.password) EditText password;
  @Bind(R.id.login) MaterialLoginView materialLoginView;


  public TextInputLayout registerFirstName;
  private TextInputLayout registerLastName;
  private TextInputLayout registerUser;
  private TextInputLayout registerPass;
  private TextInputLayout registerPassRep;
  private ProgressDialog dialog;


  @Override
  public void onCreate(@Nullable Bundle savedInstanceState) {
    super.onCreate(savedInstanceState);
    setHasOptionsMenu(true);
    dialog = new ProgressDialog(getActivity());
    dialog.setCancelable(false);
  }

  @Override
  public boolean onOptionsItemSelected(MenuItem item) {
    switch (item.getItemId()) {
      case android.R.id.home:
        if(!materialLoginView.isLoginOpened())
        materialLoginView.animateLogin();
        else {
          AlertDialog.Builder builder = new AlertDialog.Builder(getActivity());
          builder.setMessage(getString(R.string.really_want_it));
          builder.setPositiveButton(getString(R.string.ok), new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int which) {
              getActivity().finish();
            }
          });

          builder.setNegativeButton(getString(R.string.no), null);
          builder.show();
        }
        break;
    }
    return super.onOptionsItemSelected(item);
  }

  @Override
  public int getLayoutId() {
    return R.layout.login_fragment_material;
  }

  @Override
  public void onViewCreated(View view, @Nullable Bundle savedInstanceState) {
    super.onViewCreated(view, savedInstanceState);
    materialLoginView.setListener(new MaterialLoginViewListener() {
      @Override
      public void onRegister(TextInputLayout registerFirstName, TextInputLayout registerLastName, TextInputLayout registerUser, TextInputLayout registerPass, TextInputLayout registerPassRep) {
        LoginFragment.this.registerFirstName = registerFirstName;
        LoginFragment.this.registerLastName = registerLastName;
        LoginFragment.this.registerUser = registerUser;
        LoginFragment.this.registerPass = registerPass;
        LoginFragment.this.registerPassRep = registerPassRep;
        registerUser();
      }

      @Override
      public void onLogin(final TextInputLayout loginUser, TextInputLayout loginPass) {
        if(isValidLoginFields(loginUser, loginPass)) {
          dialog.show();
        LoginModel loginModel = new LoginModel();
        loginModel.userName = loginUser.getEditText().getText().toString();
        loginModel.password = loginPass.getEditText().getText().toString();
        ((BaseActivity) getActivity()).loginService.login(loginModel, new Callback<String>() {
          @Override
          public void success(String o, Response response) {
            dialog.dismiss();
            if(o != null) {
              Prefs.saveUserId(o);
              Prefs.saveUserName(loginUser.getEditText().getText().toString());
              startActivity(new Intent(getActivity(), MainActivity.class));
              getActivity().finish();
            } else {
              ((BaseActivity) getActivity()).showInfoDialog("Логин/пароль не верный");
            }
          }

          @Override
          public void failure(RetrofitError error) {
            dialog.dismiss();
            ((BaseActivity) getActivity()).showInfoDialog(error.getMessage());
            Toast.makeText(getActivity(), error.getMessage(), Toast.LENGTH_SHORT).show();
//            startActivity(new Intent(getActivity(), MainActivity.class));
          }
        });
      }
      }
    });
  }

  private boolean isValidLoginFields(TextInputLayout loginUser, TextInputLayout loginPass) {
    boolean isValid = false;
    if (TextUtils.isEmpty(loginUser.getEditText().getText().toString())) {
      loginUser.setError(getString(R.string.fill_field));
    } else {
      loginUser.setError(null);
      isValid = true;
    }

    if (TextUtils.isEmpty(loginPass.getEditText().getText().toString())) {
      loginPass.setError(getString(R.string.fill_field));
    } else {
      loginPass.setError(null);
      isValid = true;
    }



    return isValid;
  }

  private void registerUser() {
    if (isValidFields()) {
      RegisterModel registerModel = new RegisterModel();
      registerModel.UserName = registerFirstName.getEditText().getText().toString();
      registerModel.LastName = registerLastName.getEditText().getText().toString();
      registerModel.Email = registerUser.getEditText().getText().toString();
      registerModel.Password = registerPass.getEditText().getText().toString();
      registerModel.ConfirmPassword = registerPassRep.getEditText().getText().toString();
      registerModel.FirstName = registerFirstName.getEditText().getText().toString();
//    registerModel.BirthDate = Calendar.getInstance().getTime();
      registerModel.Sex = 0;
      dialog.show();

      ((BaseActivity) getActivity()).loginService.register(registerModel, new Callback<Object>() {
        @Override
        public void success(Object o, Response response) {
          dialog.dismiss();
          if(o != null) {
            Prefs.saveUserId(o.toString());
            Prefs.saveUserName(registerFirstName.getEditText().getText().toString());
            startActivity(new Intent(getActivity(), MainActivity.class));
            getActivity().finish();
          } else {
            ((BaseActivity) getActivity()).showInfoDialog("Пользователь с таким логином существует");
          }
//        LoginModel loginModel = new LoginModel();
//        loginModel.userName = name.getText().toString();
//        loginModel.password = password.getText().toString();

        }

        @Override
        public void failure(RetrofitError error) {
          dialog.dismiss();
          ((BaseActivity) getActivity()).showInfoDialog(error.getMessage());
        }
      });
    }
  }

  private boolean isValidFields() {
    boolean isValid = false;
    if (TextUtils.isEmpty(registerFirstName.getEditText().getText().toString())) {
      registerFirstName.setError(getString(R.string.fill_field));
    } else {
      registerFirstName.setError(null);
      isValid = true;
    }

    if (TextUtils.isEmpty(registerLastName.getEditText().getText().toString())) {
      registerLastName.setError(getString(R.string.fill_field));
    } else {
      registerLastName.setError(null);
      isValid = true;
    }

    if (TextUtils.isEmpty(registerUser.getEditText().getText().toString())) {
      registerUser.setError(getString(R.string.fill_field));
    } else {
      registerUser.setError(null);
      isValid = true;
    }
    if (TextUtils.isEmpty(registerPass.getEditText().getText().toString())) {
      registerPass.setError(getString(R.string.fill_field));
    } else {
      registerPass.setError(null);
      isValid = true;
    }
    if (TextUtils.isEmpty(registerPassRep.getEditText().getText().toString())) {
      registerPassRep.setError(getString(R.string.fill_field));
    } else {
      isValid = true;
      registerPassRep.setError(null);
    }
    if (!registerPassRep.getEditText().getText().toString().equals(registerPass.getEditText().getText().toString())) {
      registerPassRep.setError(getString(R.string.password_are_not_equals));
    } else {
      registerPassRep.setError(null);
      isValid = true;
    }


    return isValid;
  }

  public static LoginFragment newInstance() {
    LoginFragment loginFragment = new LoginFragment();
    return loginFragment;

  }
//
//  @OnClick(R.id.enter)
//  public void onLoginClicked() {
//    LoginModel loginModel = new LoginModel();
//    loginModel.userName = login.getText().toString();
//    loginModel.password = password.getText().toString();
//
//    ((BaseActivity) getActivity()).loginService.login(loginModel, new Callback<String>() {
//      @Override
//      public void success(String o, Response response) {
//        Prefs.saveUserId(o);
//        startActivity(new Intent(getActivity(), MainActivity.class));
//        getActivity().finish();
//      }
//
//      @Override
//      public void failure(RetrofitError error) {
//        Toast.makeText(getActivity(), error.getMessage(), Toast.LENGTH_SHORT).show();
//        startActivity(new Intent(getActivity(), MainActivity.class));
//      }
//    });
//
//  }
//
//  @OnClick(R.id.register_fab)
//  public void OnRegisterFabCLicked() {
//    ((LoginActivity) getActivity()).showFragment(RegistrationFragment.newInstance());
//  }
}
