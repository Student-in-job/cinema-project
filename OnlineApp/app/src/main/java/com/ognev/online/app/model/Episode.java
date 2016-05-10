package com.ognev.online.app.model;

import com.google.gson.annotations.SerializedName;
import org.parceler.Parcel;

import java.io.Serializable;

@Parcel
public class Episode implements Serializable {

  public int id;
  public int quality;
  public String url;
  @SerializedName("episode_number")
  public int episodeNumber;
  public String title;

}
