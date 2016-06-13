package com.ognev.online.app.fragment;

import android.content.Intent;
import android.net.Uri;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.v7.widget.GridLayoutManager;
import android.support.v7.widget.RecyclerView;
import android.view.View;
import android.widget.ImageView;
import butterknife.Bind;
import butterknife.OnClick;
import com.ognev.online.app.Constants;
import com.ognev.online.app.R;
import com.ognev.online.app.activity.BaseActivity;
import com.ognev.online.app.activity.MovieListFragment;
import com.ognev.online.app.adapter.SimpleAdapter;
import com.ognev.online.app.model.Banner;
import com.ognev.online.app.model.BaseVideo;
import com.ognev.online.app.model.ResponseObject;
import com.ognev.online.app.model.VideoDataListWrapper;
import com.squareup.picasso.Picasso;
import retrofit.Callback;
import retrofit.RetrofitError;
import retrofit.client.Response;

import java.util.ArrayList;
import java.util.List;

public class MainVideoFragment extends BaseFragment {

  @Bind(R.id.new_list)
  RecyclerView newRecyclerView;
  @Bind(R.id.popular_list)
  RecyclerView popularRecyclerView;
  @Bind(R.id.all_list)
  RecyclerView allRecyclerView;

  @Bind(R.id.banner) ImageView banner1;
  @Bind(R.id.banner_2) ImageView banner2;
  Banner b1;
  Banner b2;

  private SimpleAdapter newAdapter;
  private SimpleAdapter popularAdapter;
  private SimpleAdapter allAdapter;

  private List<VideoDataListWrapper> newVideos;
  private List<VideoDataListWrapper> popularVideos;
  private List<VideoDataListWrapper> allVideos;


  @Override
  public void onCreate(@Nullable Bundle savedInstanceState) {
    super.onCreate(savedInstanceState);

    newVideos = new ArrayList<>();
    popularVideos = new ArrayList<>();
    allVideos = new ArrayList<>();
    newAdapter = new SimpleAdapter(getActivity(), newVideos);
    popularAdapter = new SimpleAdapter(getActivity(), popularVideos);
    allAdapter = new SimpleAdapter(getActivity(), allVideos);

  }

  @Override
  public int getLayoutId() {
    return R.layout.main_video;
  }

  @Override
  public void onViewCreated(View view, @Nullable Bundle savedInstanceState) {
    super.onViewCreated(view, savedInstanceState);

    newRecyclerView.setHasFixedSize(true);
    newRecyclerView.setLayoutManager(new GridLayoutManager(getActivity(), 4));
    popularRecyclerView.setHasFixedSize(true);
    popularRecyclerView.setLayoutManager(new GridLayoutManager(getActivity(), 4));
    allRecyclerView.setHasFixedSize(true);
    allRecyclerView.setLayoutManager(new GridLayoutManager(getActivity(), 4));

    newRecyclerView.setAdapter(newAdapter);
    popularRecyclerView.setAdapter(popularAdapter);
    allRecyclerView.setAdapter(allAdapter);

    videoService.getBanner(new Callback<ResponseObject<Banner>>() {
      @Override
      public void success(ResponseObject<Banner> banner, Response response) {
        if(!Constants.ERROR.equals(banner.status)) {
          banner2.setVisibility(View.VISIBLE);
          b2 = banner.data;
          Picasso.with(getActivity()).load(Constants.BASE_URL + "/uploads/" + banner.data.imgUrl).fit().into(banner2);
        }
        else banner2.setVisibility(View.GONE);
        videoService.getBanner(new Callback<ResponseObject<Banner>>() {
          @Override
          public void success(ResponseObject<Banner> banner, Response response) {
            if(!Constants.ERROR.equals(banner.status)) {
              banner1.setVisibility(View.VISIBLE);
              b1 = banner.data;
              Picasso.with(getActivity()).load(Constants.BASE_URL + "/uploads/" + banner.data.imgUrl).fit().into(banner1);
            }
            else banner1.setVisibility(View.GONE);

          }

          @Override
          public void failure(RetrofitError error) {

          }
        });
      }

      @Override
      public void failure(RetrofitError error) {

      }
    });



    videoService.getNewVideos(Constants.EIGHT, new Callback<ResponseObject<List<BaseVideo>>>() {
      @Override
      public void success(final ResponseObject<List<BaseVideo>> videoDataListWrappers1, Response response) {

        newVideos.addAll(videoDataListWrappers1.data);
        videoService.getPopularVideos(Constants.EIGHT, new Callback<ResponseObject<List<BaseVideo>>>() {
          @Override
          public void success(ResponseObject<List<BaseVideo>> videoDataListWrappers2, Response response) {
            popularVideos.addAll(videoDataListWrappers2.data);

            videoService.getVideos(Constants.EIGHT, new Callback<ResponseObject<List<BaseVideo>>>() {
              @Override
              public void success(ResponseObject<List<BaseVideo>> videoDataListWrappers, Response response) {
                allVideos.addAll(videoDataListWrappers.data);
                newAdapter.notifyDataSetChanged();
                popularAdapter.notifyDataSetChanged();
                allAdapter.notifyDataSetChanged();

              }

              @Override
              public void failure(RetrofitError error) {

              }
            });

          }

          @Override
          public void failure(RetrofitError error) {

          }
        });
      }

      @Override
      public void failure(RetrofitError error) {

      }
    });

  }

  @OnClick(R.id.banner)
  public void onBannerClicked() {
    Intent intent= new Intent(Intent.ACTION_VIEW, Uri.parse("http://" + b1.url));
    startActivity(intent);
  }

  @OnClick(R.id.banner_2)
  public void onBanner2Clicked() {
    Intent intent= new Intent(Intent.ACTION_VIEW, Uri.parse("http://" + b2.url));
    startActivity(intent);
  }

  @OnClick(R.id.new_card)
  public void onNewClicked() {
    ((BaseActivity) getActivity()).showFragment(MovieListFragment.newInstance(Constants.NEW));
  }

  @OnClick(R.id.popular_card)
  public void onPopularClicked() {
    ((BaseActivity) getActivity()).showFragment(MovieListFragment.newInstance(Constants.POPULAR));

  }

  @OnClick(R.id.all_card)
  public void onAllClicked() {
    ((BaseActivity) getActivity()).showFragment(MovieListFragment.newInstance(Constants.ALL));

  }

  public static MainVideoFragment newInstance() {
    MainVideoFragment fragment = new MainVideoFragment();
    Bundle bundle = new Bundle();
    fragment.setArguments(bundle);
    return fragment;
  }
}
