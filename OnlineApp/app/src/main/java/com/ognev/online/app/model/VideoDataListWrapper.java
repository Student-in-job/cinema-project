package com.ognev.online.app.model;

import org.parceler.Parcel;

import java.io.Serializable;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;

@Parcel
public class VideoDataListWrapper implements Serializable {

  public int id;

  public String name = "s";

  public int agelimit;

  public Date releaseDate;

  public String scenario;

  public String director;

  public String poster = "ss";

  public float rating;


  public List<Actor> actors;
  public List<Genre> genres;
  public List<Country> countries;
  public List<Movie> movies;
  public List<File> files = new ArrayList<>();

  public List<Comment> comments = new ArrayList<>();

  public VideoDataListWrapper() {
  }

  public VideoDataListWrapper(String name, String scenario) {
    this.name = name;
    this.scenario = scenario;
  }
}
