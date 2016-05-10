package com.ognev.online.app.activity;

import android.app.SearchManager;
import android.content.Context;
import android.content.Intent;
import android.os.Bundle;
import android.support.v4.app.FragmentTransaction;
import android.support.v4.widget.DrawerLayout;
import android.support.v7.widget.SearchView;
import android.view.Menu;
import android.view.MenuItem;
import com.ognev.online.app.Constants;
import com.ognev.online.app.R;
import com.ognev.online.app.fragment.MainVideoFragment;
import com.ognev.online.app.fragment.SearchVideoFragment;
import com.ognev.online.app.model.BaseVideo;
import com.ognev.online.app.model.ResponseObject;
import retrofit.Callback;
import retrofit.RetrofitError;
import retrofit.client.Response;

import java.util.List;


public class MainActivity extends MenuActivity implements SearchView.OnQueryTextListener {



  @Override
  protected void onCreate(Bundle savedInstanceState) {
    super.onCreate(savedInstanceState);
    setContentView(R.layout.activity_main);
    FragmentTransaction fragmentTransaction = getSupportFragmentManager().beginTransaction();
//    fragmentTransaction.setTransition(FragmentTransaction.TRANSIT_FRAGMENT_OPEN);
    fragmentTransaction.replace(R.id.root, MainVideoFragment.newInstance());
    fragmentTransaction.addToBackStack(null);
    fragmentTransaction.commit();


  }


  @Override
  public boolean onCreateOptionsMenu(Menu menu) {
    getMenuInflater().inflate(R.menu.menu_main, menu);

    MenuItem searchItem = menu.findItem(R.id.action_search);

    SearchManager searchManager = (SearchManager) MainActivity.this.getSystemService(Context.SEARCH_SERVICE);

    SearchView searchView = null;
    if (searchItem != null) {
      searchView = (SearchView) searchItem.getActionView();
      searchView.setOnQueryTextListener(this);
      searchView.setOnCloseListener(new SearchView.OnCloseListener() {
        @Override
        public boolean onClose() {
          getSupportFragmentManager().popBackStack();
          return false;
        }
      });
    }
//    if (searchView != null) {
//      searchView.setSearchableInfo(searchManager.getSearchableInfo(MainActivity.this.getComponentName()));
//    }
    return super.onCreateOptionsMenu(menu);
  }

  @Override
  public boolean onOptionsItemSelected(MenuItem item) {
    switch (item.getItemId()) {
      case android.R.id.home:
        if(mDrawerLayout.getDrawerLockMode(navigationView) == DrawerLayout.LOCK_MODE_UNLOCKED)
        mDrawerLayout.openDrawer(navigationView);
        break;
    }
    return super.onOptionsItemSelected(item);

  }

  @Override
  public boolean onQueryTextSubmit(String query) {

    videoService.searchVideo(query, new Callback<ResponseObject<List<BaseVideo>>>() {
      @Override
      public void success(ResponseObject<List<BaseVideo>> listResponseObject, Response response) {

      }

      @Override
      public void failure(RetrofitError error) {

      }
    });

    return false;
  }

  @Override
  public boolean onQueryTextChange(String newText) {
    if(SearchVideoFragment.isDead)
    showFragment(SearchVideoFragment.newInstance());
    sendBroadcast(new Intent(Constants.SEARCH).putExtra(Constants.QUERY, newText));
    return false;
  }


//  @Override
//  public boolean onCreateOptionsMenu(Menu menu) {
//    // Inflate the menu; this adds items to the action bar if it is present.
//    getMenuInflater().inflate(R.menu.menu_main, menu);
//    return true;
//  }

//  @Override
//  public boolean onOptionsItemSelected(MenuItem item) {
//    // Handle action bar item clicks here. The action bar will
//    // automatically handle clicks on the Home/Up button, so long
//    // as you specify a parent activity in AndroidManifest.xml.
//    int id = item.getItemId();
//
//    //noinspection SimplifiableIfStatement
//    if (id == R.id.action_settings) {
//      return true;
//    }
//
//    return super.onOptionsItemSelected(item);
//  }
}
