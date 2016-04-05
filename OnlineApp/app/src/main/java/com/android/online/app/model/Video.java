package com.android.online.app.model;

import com.google.gson.annotations.SerializedName;
import org.parceler.Parcel;
import org.parceler.ParcelConstructor;

@Parcel
public class Video {

  public int id;
  public String name;
  @SerializedName("age_limit")
  public int ageLimit;
  public String details;
  public String director;
  public int type;
  @SerializedName("img_url")
  public String imageUrl;

  @ParcelConstructor
  public Video() {
  }
}
