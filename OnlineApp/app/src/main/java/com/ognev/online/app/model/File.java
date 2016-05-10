package com.ognev.online.app.model;

import com.google.gson.annotations.SerializedName;
import org.parceler.Parcel;

@Parcel
public class File {

  public int id;
  public float price;
  public int quality;
  public String url;
  @SerializedName("season_id")
  public int seasonId;
    @SerializedName("episode_id")
  public int apisodeId;

  public boolean trailer;

}
