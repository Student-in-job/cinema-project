package com.ognev.online.app.ui;

import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.Intent;
import com.ognev.online.app.Constants;
import com.ognev.online.app.activity.PlayerActivity;
import com.ognev.online.app.activity.TeaserActivity;
import com.ognev.online.app.dagger.ServiceGenerator;
import com.ognev.online.app.model.Banner;
import com.ognev.online.app.model.ResponseObject;
import org.parceler.Parcels;
import retrofit.Callback;
import retrofit.RetrofitError;
import retrofit.client.Response;

public class TeaserReceiver extends BroadcastReceiver {

    @Override
    public void onReceive(final Context context, Intent intent) {
      if(!PlayerActivity.isOnPause)
      ServiceGenerator.createVideoService().getTeaser(new Callback<ResponseObject<Banner>>() {
        @Override
        public void success(ResponseObject<Banner> banner, Response response) {
          if(!Constants.ERROR.equals(banner.status)) {
            Intent i = new Intent(context, TeaserActivity.class);
                i.putExtra(Constants.BANNER, Parcels.wrap(banner.data));
            i.setFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
            context.startActivity(i);
          }
        }

        @Override
        public void failure(RetrofitError error) {

        }
      });
    }
  }