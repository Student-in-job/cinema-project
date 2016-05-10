package com.ognev.online.app.activity;

import android.os.Bundle;
import android.webkit.WebView;
import butterknife.Bind;
import butterknife.OnClick;
import com.ognev.online.app.Constants;
import com.ognev.online.app.R;
import com.ognev.online.app.model.Banner;
import org.parceler.Parcels;

public class TeaserActivity extends BaseActivity {

  private Banner banner;

  @Bind(R.id.image) WebView bannerImage;

  @Override
  protected void onCreate(Bundle savedInstanceState) {
    super.onCreate(savedInstanceState);
    setContentView(R.layout.advertiser_view);
    banner = Parcels.unwrap(getIntent().getParcelableExtra(Constants.BANNER));
    String d = "<!DOCTYPE html><html><body><img src=" + Constants.BASE_URL + "/uploads/" + banner.imgUrl + " alt=\"Smileyface\" width=\"100%\" height=\"340%\"></body></html>";
    bannerImage.loadData(d, "text/html", "utf-8");

  }

  @OnClick(R.id.close) public void onCloseClocked() {
    finish();
  }
}
