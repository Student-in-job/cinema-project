package com.android.online.app.activity;

import android.content.Intent;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.widget.EditText;
import android.widget.Toast;
import butterknife.Bind;
import butterknife.OnClick;
import com.android.online.app.R;
import com.android.online.app.model.LoginModel;
import com.android.online.app.util.Prefs;
import retrofit.Callback;
import retrofit.RetrofitError;
import retrofit.client.Response;

public class LoginActivity extends BaseActivity {

  @Bind(R.id.email) EditText login;
  @Bind(R.id.password) EditText password;

  @Override
  protected void onCreate(@Nullable Bundle savedInstanceState) {
    super.onCreate(savedInstanceState);
    setContentView(R.layout.login_activity);
  }

  @OnClick(R.id.enter)
  public void onLoginClicked() {
    LoginModel loginModel = new LoginModel();
    loginModel.userName = login.getText().toString();
    loginModel.password = password.getText().toString();

    loginService.login(loginModel, new Callback<String>() {
      @Override
      public void success(String o, Response response) {
        Prefs.saveUserId(o);
        startActivity(new Intent(LoginActivity.this, MainActivity.class));
        finish();
      }

      @Override
      public void failure(RetrofitError error) {
        Toast.makeText(getApplicationContext(), error.getMessage(), Toast.LENGTH_SHORT).show();
      }
    });

  }

  @OnClick(R.id.registration)
  public void onRegisterClicked() {
    startActivity(new Intent(LoginActivity.this, RegistrationActivity.class));
}

}
