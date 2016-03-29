package com.android.online.app.activity;

import android.content.Intent;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.design.widget.NavigationView;
import android.support.v4.widget.DrawerLayout;
import android.view.View;
import android.widget.ImageView;
import android.widget.TextView;
import butterknife.Bind;
import com.android.online.app.R;

public abstract class MenuActivity extends BaseActivity {
  @Bind(R.id.drawer) DrawerLayout mDrawerLayout;
  @Bind(R.id.navi) NavigationView navigationView;
  private TextView userNametv;
  private ImageView loginIcon;
  private ImageView editIcon;
  protected View headerView;
  private Intent intent;

  @Override
  protected void onCreate(@Nullable Bundle savedInstanceState) {
    super.onCreate(savedInstanceState);
  }

  @Override
  public void setContentView(int layoutResID) {
    super.setContentView(layoutResID);
    setupDrawerContent();
  }


  private void setupDrawerContent() {
    headerView = navigationView.inflateHeaderView(R.layout.left_header);
    userNametv = (TextView) headerView.findViewById(R.id.guest_tv);
    loginIcon = (ImageView) headerView.findViewById(R.id.login_ic);
    editIcon = (ImageView) headerView.findViewById(R.id.edit_ic);

    headerView.setOnClickListener(new View.OnClickListener() {
      @Override
      public void onClick(View v) {
//        onLeftHeaderClicked();
        mDrawerLayout.closeDrawers();
      }
    });

//    navigationView.setNavigationItemSelectedListener(
//        new NavigationView.OnNavigationItemSelectedListener() {
//          @Override
//          public boolean onNavigationItemSelected(MenuItem menuItem) {
//            mDrawerLayout.closeDrawers();
//            return onItemSelected(getActivityIdentifier(), menuItem
//                .getItemId());
//          }
//        });
  }
}
