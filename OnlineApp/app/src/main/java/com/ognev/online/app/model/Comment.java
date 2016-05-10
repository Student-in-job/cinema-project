package com.ognev.online.app.model;

import com.google.gson.annotations.SerializedName;
import org.parceler.Parcel;

@Parcel
public class Comment {

  public int id;
  public String author;
  public String authorId;
  public String user_id;
  public String creationDate;
  public String comment;

  @SerializedName("video_id")
  public int videoId;

  public float rating;

}
