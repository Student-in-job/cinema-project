package com.ognev.online.app.activity;

import android.os.Bundle;
import android.support.annotation.Nullable;
import com.ognev.online.app.R;
import com.ognev.online.app.fragment.TariffsFragment;

public class TariffActivity extends SingleActivity {

  @Override
  protected void onCreate(@Nullable Bundle savedInstanceState) {
    super.onCreate(savedInstanceState);
    setContentView(R.layout.main);

    showFragment(TariffsFragment.newInstance());

  }
}
