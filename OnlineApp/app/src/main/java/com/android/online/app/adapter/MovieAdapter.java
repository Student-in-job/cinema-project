package com.android.online.app.adapter;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.ImageView;
import android.widget.TextView;
import com.android.online.app.Constants;
import com.android.online.app.R;
import com.android.online.app.model.Video;
import com.squareup.picasso.Callback;
import com.squareup.picasso.Picasso;

import java.util.List;

public class MovieAdapter extends BaseAdapter {
  Context context;
  List<Video> strings;
  LayoutInflater inflater;

  public MovieAdapter(Context context, List<Video> strings) {
    this.context = context;
    this.strings = strings;
    this.inflater = LayoutInflater.from(context);
  }

  @Override
  public int getCount() {
    return strings.size();
  }

  @Override
  public Object getItem(int position) {
    return null;
  }

  @Override
  public long getItemId(int position) {
    return 0;
  }

  @Override
  public View getView(int position, View convertView, ViewGroup parent) {
    View view = inflater.inflate(R.layout.example, null);
    ((TextView)view.findViewById(R.id.example)).setText(strings.get(position).name);
    ImageView videoImage = (ImageView) view.findViewById(R.id.video_image);
    Picasso.with(context).load(Constants.BASE_URL + "/uploads/" + strings.get(position).imageUrl).fit().centerInside().into(videoImage, new Callback() {
      @Override
      public void onSuccess() {

      }

      @Override
      public void onError() {

      }
    });
    return view;
  }
}
