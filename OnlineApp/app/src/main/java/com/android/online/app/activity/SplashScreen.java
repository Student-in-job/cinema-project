package com.android.online.app.activity;

import android.content.Intent;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.v7.app.AppCompatActivity;
import com.android.online.app.R;
import com.android.online.app.util.Prefs;

import java.util.Timer;
import java.util.TimerTask;

public class SplashScreen extends AppCompatActivity {
  public static final int SPLASH_TIMEOUT = 2000;

  @Override
  protected void onCreate(@Nullable Bundle savedInstanceState) {
    super.onCreate(savedInstanceState);
    setContentView(R.layout.splash_screen);
    new Timer().schedule(new TimerTask() {
      @Override
      public void run() {
        proceed();
      }
    }, SPLASH_TIMEOUT);


  }

  private void proceed() {
    if (this.isFinishing()) {
      return;
    }
    if(Prefs.hasId()) {
      startActivity(new Intent(SplashScreen.this, MainActivity.class));
    } else {
      startActivity(new Intent(SplashScreen.this, LoginActivity.class));
    }
    finish();
  }
}
