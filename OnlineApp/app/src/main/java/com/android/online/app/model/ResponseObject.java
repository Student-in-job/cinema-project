package com.android.online.app.model;

import com.google.gson.annotations.SerializedName;

public class ResponseObject {

  @SerializedName("ResponseCode")
  public int responseCode;


  @SerializedName("ResponseMessage")
  public String responseMessage;
}
