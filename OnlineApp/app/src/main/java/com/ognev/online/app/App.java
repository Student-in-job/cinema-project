package com.ognev.online.app;

import android.app.Application;
import com.ognev.online.app.util.Prefs;

public class App extends Application {

  private static App app;
  @Override
  public void onCreate() {
    super.onCreate();
    app = this;
    new Prefs(getApplicationContext());
    Constants.setBASE_URL(Prefs.getIp());
  }

  public static App getInstance() {
    return app;
  }

}
