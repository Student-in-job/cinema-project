package com.android.online.app.activity;

import android.content.Intent;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.widget.TextView;
import android.widget.Toast;
import butterknife.Bind;
import butterknife.OnClick;
import com.android.online.app.R;
import com.android.online.app.model.LoginModel;
import com.android.online.app.service.RegisterModel;
import retrofit.Callback;
import retrofit.RetrofitError;
import retrofit.client.Response;

public class RegistrationActivity extends BaseActivity {

  @Bind(R.id.name) TextView name;
  @Bind(R.id.last_name) TextView lastName;
  @Bind(R.id.email) TextView email;
  @Bind(R.id.password) TextView password;
  @Override
  protected void onCreate(@Nullable Bundle savedInstanceState) {
    super.onCreate(savedInstanceState);
    setContentView(R.layout.registration_view);

  }

  @OnClick(R.id.enter)
  public void  onCLick() {
    RegisterModel registerModel = new RegisterModel();
    registerModel.username = name.getText().toString();
    registerModel.Email = name.getText().toString();
    registerModel.LastName = lastName.getText().toString();
    registerModel.Password = password.getText().toString();
    registerModel.FirstName = name.getText().toString();
    registerModel.sex = 0;

    loginService.register(registerModel, new Callback<Object>() {
      @Override
      public void success(Object o, Response response) {

        LoginModel loginModel = new LoginModel();
        loginModel.userName = name.getText().toString();
        loginModel.password = password.getText().toString();

        Toast.makeText(getApplicationContext(), o.toString(), Toast.LENGTH_SHORT).show();
        loginService.login(loginModel, new Callback<String>() {
          @Override
          public void success(String o, Response response) {
            startActivity(new Intent(RegistrationActivity.this, LoginActivity.class));
          }

          @Override
          public void failure(RetrofitError error) {

          }
        });

      }

      @Override
      public void failure(RetrofitError error) {

      }
    });
  }
}
