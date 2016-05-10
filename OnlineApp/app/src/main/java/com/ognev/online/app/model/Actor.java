package com.ognev.online.app.model;

import com.google.gson.annotations.SerializedName;
import org.parceler.Parcel;

@Parcel
public class Actor {

  public int id;
  @SerializedName("Name")
  public String name;


}
