package com.android.online.app.model.wrapper;

import com.android.online.app.model.Video;
import com.google.gson.annotations.SerializedName;

import java.util.List;

public class VideoListWrapper {

  @SerializedName("value")
  public List<Video> videos;
}
