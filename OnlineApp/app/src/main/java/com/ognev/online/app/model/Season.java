package com.ognev.online.app.model;

import com.google.gson.annotations.SerializedName;
import org.parceler.Parcel;

import java.io.Serializable;
import java.util.ArrayList;
import java.util.List;

@Parcel
public class Season implements Serializable {

  public int id;

  @SerializedName("season_number")
  public int seasonNumber;

  public String title;

  public float price;

  public List<Episode> episodes;

  public Season() {
    this.episodes=new ArrayList<>();
//    episodes.add(new Episode());
//    episodes.add(new Episode());
//    episodes.add(new Episode());
  }

  //  public Trailer trailer;
}
