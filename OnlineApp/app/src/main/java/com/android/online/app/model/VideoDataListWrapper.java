package com.android.online.app.model;

import org.parceler.Parcel;

import java.util.Date;
import java.util.List;

@Parcel
public class VideoDataListWrapper {

  public int id;

  public String name = "s";

  public int agelimit;

  public Date releaseDate;

  public String scenario;

  public String director;

  public String poster = "ss";


  public List<Actor> actors;
  public List<Genre> genres;
  public List<Country> countries;
  public List<Movie> movies;

  public List<Comment> comments;

  public VideoDataListWrapper() {
  }

  public VideoDataListWrapper(String name, String scenario) {
    this.name = name;
    this.scenario = scenario;
  }
}
