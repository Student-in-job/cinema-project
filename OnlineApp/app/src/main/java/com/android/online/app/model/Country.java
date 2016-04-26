package com.android.online.app.model;

import com.google.gson.annotations.SerializedName;
import org.parceler.Parcel;

@Parcel
public class Country {
  public int id;
  @SerializedName("Name")
  public String name;
}