package com.ognev.online.app.activity;

import android.content.Intent;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.widget.TextView;
import android.widget.Toast;
import butterknife.Bind;
import butterknife.OnClick;
import com.ognev.online.app.R;
import com.ognev.online.app.model.LoginModel;
import com.ognev.online.app.service.RegisterModel;
import com.ognev.online.app.util.Prefs;
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
    registerModel.UserName = name.getText().toString();
    registerModel.Email = email.getText().toString();
    registerModel.LastName = lastName.getText().toString();
    registerModel.Password = password.getText().toString();
    registerModel.ConfirmPassword = password.getText().toString();
    registerModel.FirstName = name.getText().toString();
//    registerModel.BirthDate = Calendar.getInstance().getTime();
    registerModel.Sex = 0;

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
            Prefs.saveUserId(o);
            startActivity(new Intent(RegistrationActivity.this, MainActivity.class));
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
