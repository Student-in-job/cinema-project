package com.ognev.online.app.model;

import com.google.gson.annotations.SerializedName;

import java.util.List;

public class MovieHistoryWrapper {

  @SerializedName("Moviehistories")
  public List<MovieHistory> histories;
}
