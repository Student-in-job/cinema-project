package com.ognev.online.app.model;

import com.google.gson.annotations.SerializedName;

import java.util.List;

public class PurchaseWrapper {

  @SerializedName("Usermovies")
  public List<UserVideo> purchases;

}
