package com.android.online.app.util;


import android.content.Context;
import android.content.SharedPreferences;
import android.text.TextUtils;
import com.android.online.app.Constants;

public class  Prefs {

  private static final String APP_PREFERENCES = "online_prefs";
  private static final String USER_ID = "user_id";
  private static final String SERVER_IP = "server_ip";

  private static SharedPreferences editor;

  public Prefs(Context context) {
    editor = context.getSharedPreferences(APP_PREFERENCES, Context.MODE_PRIVATE);
  }

  public static String getCountry() {
    return null;
  }

  public static void saveUserId(String id) {
    editor.edit()
        .putString(USER_ID, id)
        .commit();
  }


  public static String getUserId() {
    return editor.getString(USER_ID, "");
  }


  public static boolean hasId() {
    return !TextUtils.isEmpty(editor.getString(USER_ID, null));
  }

  public static void saveIp(String s) {
    editor.edit()
        .putString(SERVER_IP, "http://" + s)
        .commit();
  }

  public static String getIp() {
    return editor.getString(SERVER_IP, Constants.BASE_URL);
  }
}
