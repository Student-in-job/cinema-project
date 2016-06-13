package com.ognev.online.app.activity;

import android.content.Intent;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.design.widget.NavigationView;
import android.support.v4.widget.DrawerLayout;
import android.view.MenuItem;
import android.view.View;
import android.widget.ImageView;
import android.widget.TextView;
import butterknife.Bind;
import com.ognev.online.app.Constants;
import com.ognev.online.app.R;
import com.ognev.online.app.fragment.*;
import com.ognev.online.app.util.Prefs;

public abstract class MenuActivity extends BaseActivity {
  @Bind(R.id.drawer) public DrawerLayout mDrawerLayout;
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

    toolbar.setNavigationIcon(R.drawable.ic_menu_white_24dp);

    userNametv.setText(Prefs.getUserName());

    headerView.setOnClickListener(new View.OnClickListener() {
      @Override
      public void onClick(View v) {
//        if(Prefs.hasId())
        showFragment(ProfileFragment.newInstance());
//        else
//          showFragment(LoginFragment.newInstance());

        mDrawerLayout.closeDrawers();
      }
    });

    navigationView.setNavigationItemSelectedListener(
        new NavigationView.OnNavigationItemSelectedListener() {
          @Override
          public boolean onNavigationItemSelected(MenuItem menuItem) {

            switch (menuItem.getItemId()) {
              case R.id.settings:
                showFragment(SettingsFragment.newInstance());
                break;

              case R.id.home:
                showFragment(MainVideoFragment.newInstance());
                break;

              case R.id.tv_series:
                showFragment(SerialsFragment.newInstance(Constants.ALL));
                break;

              case R.id.movies:
                showFragment(MovieListFragment.newInstance(Constants.ALL));
                break;

//              case R.id.agreement:
//                showFragment(AgreementFragment.newInstance());
//                break;

              case R.id.about:
                showFragment(AboutFragment.newInstance());
                break;

              case R.id.logout:
                Prefs.clearProfile();
                finish();
                startActivity(new Intent(MenuActivity.this, LoginActivity.class));
                break;
            }
            mDrawerLayout.closeDrawers();
            return false;
          }
        });
  }


}
