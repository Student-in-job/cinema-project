package com.ognev.online.app.ui;

import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.Intent;
import com.ognev.online.app.Constants;
import com.ognev.online.app.activity.PlayerActivity;
import com.ognev.online.app.activity.TeaserActivity;
import com.ognev.online.app.dagger.ServiceGenerator;
import com.ognev.online.app.model.Banner;
import org.parceler.Parcels;
import retrofit.Callback;
import retrofit.RetrofitError;
import retrofit.client.Response;

public class TeaserReceiver extends BroadcastReceiver {

    @Override
    public void onReceive(final Context context, Intent intent) {
      if(!PlayerActivity.isOnPause)
      ServiceGenerator.createVideoService().getTeaser(new Callback<Banner>() {
        @Override
        public void success(Banner banner, Response response) {
          Intent i = new Intent(context, TeaserActivity.class)
              .putExtra(Constants.BANNER, Parcels.wrap(banner));
          i.setFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
          context.startActivity(i);
        }

        @Override
        public void failure(RetrofitError error) {

        }
      });
    }
  }