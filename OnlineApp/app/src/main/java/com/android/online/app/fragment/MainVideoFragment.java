package com.android.online.app.fragment;

import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.v7.widget.GridLayoutManager;
import android.support.v7.widget.RecyclerView;
import android.view.View;
import butterknife.Bind;
import com.android.online.app.R;
import com.android.online.app.adapter.SimpleAdapter;
import com.android.online.app.model.VideoDataListWrapper;
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

    videoService.getNewVideos(new Callback<List<VideoDataListWrapper>>() {
      @Override
      public void success(final List<VideoDataListWrapper> videoDataListWrappers1, Response response) {

        newVideos.addAll(videoDataListWrappers1);
        videoService.getPopularVideos(new Callback<List<VideoDataListWrapper>>() {
          @Override
          public void success(List<VideoDataListWrapper> videoDataListWrappers2, Response response) {
            popularVideos.addAll(videoDataListWrappers2);

            videoService.getVideos(new Callback<List<VideoDataListWrapper>>() {
              @Override
              public void success(List<VideoDataListWrapper> videoDataListWrappers, Response response) {
                allVideos.addAll(videoDataListWrappers);
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

  public static MainVideoFragment newInstance() {
    MainVideoFragment fragment = new MainVideoFragment();
    Bundle bundle = new Bundle();
    fragment.setArguments(bundle);
    return fragment;
  }
}
