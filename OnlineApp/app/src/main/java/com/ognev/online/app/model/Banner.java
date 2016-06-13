package com.ognev.online.app.model;

import com.google.gson.annotations.SerializedName;
import org.parceler.Parcel;

@Parcel
public class Banner {

  @SerializedName("img_url")
  public String imgUrl;

  @SerializedName("site_url")
  public String url;
}
