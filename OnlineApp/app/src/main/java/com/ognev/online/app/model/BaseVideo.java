package com.ognev.online.app.model;

import org.parceler.Parcel;

import java.io.Serializable;
import java.util.ArrayList;
import java.util.List;

@Parcel
public class BaseVideo extends VideoDataListWrapper implements Serializable {

  public List<Season> seasons;

  public BaseVideo() {
    this.seasons = new ArrayList<>();
//    seasons.add(new Season());
//    seasons.add(new Season());
//    seasons.add(new Season());
  }
}
