package com.ognev.online.app.activity;

import android.content.Context;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.v4.app.Fragment;
import android.support.v7.widget.GridLayoutManager;
import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.ProgressBar;
import android.widget.TextView;
import butterknife.Bind;
import com.ognev.online.app.Constants;
import com.ognev.online.app.R;
import com.ognev.online.app.adapter.VideoListAdapter;
import com.ognev.online.app.fragment.BaseFragment;
import com.ognev.online.app.model.BaseVideo;
import com.ognev.online.app.model.Genre;
import com.ognev.online.app.model.ResponseObject;
import fr.ganfra.materialspinner.MaterialSpinner;
import retrofit.Callback;
import retrofit.RetrofitError;
import retrofit.client.Response;

import java.util.ArrayList;
import java.util.List;

public class MovieListFragment extends BaseFragment {

  @Bind(R.id.list) RecyclerView recyclerView;
  @Bind(R.id.genre_spinner) MaterialSpinner spinner;
  @Bind(R.id.progress) ProgressBar progressBar;

  private VideoListAdapter adapter;

  private List<BaseVideo> list;
  private List<Genre> genres;

  @Override
  public int getLayoutId() {
    return R.layout.video_list;
  }

  @Override
  public void onCreate(@Nullable Bundle savedInstanceState) {
    super.onCreate(savedInstanceState);
    setHasOptionsMenu(true);
    list = new ArrayList<>();
    genres = new ArrayList<>();
    adapter = new VideoListAdapter(getActivity(), list);

  }

  @Override
  public void onViewCreated(View view, @Nullable Bundle savedInstanceState) {
    super.onViewCreated(view, savedInstanceState);

    recyclerView.setLayoutManager(new GridLayoutManager(getActivity(), 3));
    recyclerView.setAdapter(adapter);


    spinner.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
      @Override
      public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {
        progressBar.setVisibility(View.VISIBLE);
        list.clear();
        adapter.notifyDataSetChanged();
        if(position != -1) {

          ((BaseActivity) getActivity()).videoService.getVideoByGenre(genres.get(position).id, new Callback<ResponseObject<List<BaseVideo>>>() {
            @Override
            public void success(ResponseObject<List<BaseVideo>> listResponseObject, Response response) {
              initAdapter(listResponseObject);
            }

            @Override
            public void failure(RetrofitError error) {
              progressBar.setVisibility(View.INVISIBLE);

            }
          });
        } else {
          switch (getArguments().getInt(Constants.CATEGORY)) {
            case Constants.ALL:
              ((BaseActivity) getActivity()).videoService.getVideos(Constants.ALL, new Callback<ResponseObject<List<BaseVideo>>>() {
                @Override
                public void success(ResponseObject<List<BaseVideo>> listResponseObject, Response response) {
                  initAdapter(listResponseObject);
                }

                @Override
                public void failure(RetrofitError error) {
                  progressBar.setVisibility(View.INVISIBLE);

                }
              });

              break;

            case Constants.NEW:
              ((BaseActivity) getActivity()).videoService.getNewVideos(Constants.ALL,new Callback<ResponseObject<List<BaseVideo>>>() {
                @Override
                public void success(ResponseObject<List<BaseVideo>> listResponseObject, Response response) {
                  initAdapter(listResponseObject);
                }

                @Override
                public void failure(RetrofitError error) {
                  progressBar.setVisibility(View.INVISIBLE);
                }
              });
              break;

            case Constants.POPULAR:
              ((BaseActivity) getActivity()).videoService.getPopularVideos(Constants.ALL,new Callback<ResponseObject<List<BaseVideo>>>() {
                @Override
                public void success(ResponseObject<List<BaseVideo>> listResponseObject, Response response) {
                  initAdapter(listResponseObject);
                }

                @Override
                public void failure(RetrofitError error) {
                  progressBar.setVisibility(View.INVISIBLE);
                }
              });
              break;
          }
        }
      }

      @Override
      public void onNothingSelected(AdapterView<?> parent) {

      }
    });

    progressBar.setVisibility(View.VISIBLE);
    ((BaseActivity) getActivity()).videoService.getGenres(new Callback<ResponseObject<List<Genre>>>() {
      @Override
      public void success(ResponseObject<List<Genre>> listResponseObject, Response response) {
        genres.addAll(listResponseObject.data);
        spinner.setAdapter(new GenreAdapter(getActivity(), genres));
        ((BaseActivity) getActivity()).videoService.getVideoByGenre(genres.get(0).id, new Callback<ResponseObject<List<BaseVideo>>>() {
          @Override
          public void success(ResponseObject<List<BaseVideo>> listResponseObject, Response response) {
            list.addAll(listResponseObject.data);
            adapter.notifyDataSetChanged();
            progressBar.setVisibility(View.INVISIBLE);
          }

          @Override
          public void failure(RetrofitError error) {
            progressBar.setVisibility(View.INVISIBLE);

          }
        });
      }

      @Override
      public void failure(RetrofitError error) {
        progressBar.setVisibility(View.INVISIBLE);

      }
    });
  }

  private void initAdapter(ResponseObject<List<BaseVideo>> listResponseObject) {
    list.addAll(listResponseObject.data);
    adapter.notifyDataSetChanged();
    progressBar.setVisibility(View.INVISIBLE);
  }

  class GenreAdapter extends ArrayAdapter<Genre> {

    private List<Genre> genres;
    private LayoutInflater inflater;
    public GenreAdapter(Context context, List<Genre> genres) {
      super(context, R.layout.spinner_genre_item, genres);
      this.genres = genres;
      inflater = LayoutInflater.from(context);
    }

    @Override
    public View getDropDownView(int position, View convertView, ViewGroup parent) {
      View view = inflater.inflate(R.layout.spinner_genre_item, parent, false);
      ((TextView)view.findViewById(R.id.genre)).setText(genres.get(position).name);
      return view;
    }

    @Override
    public View getView(int position, View convertView, ViewGroup parent) {
      View view = inflater.inflate(R.layout.spinner_genre_item, parent, false);
      ((TextView)view.findViewById(R.id.genre)).setText(genres.get(position).name);
      return view;
    }
  }

  public static Fragment newInstance(int category) {
    MovieListFragment fragment = new MovieListFragment();
    Bundle bundle = new Bundle();
    bundle.putInt(Constants.CATEGORY, category);
    fragment.setArguments(bundle);
    return fragment;
  }
}
