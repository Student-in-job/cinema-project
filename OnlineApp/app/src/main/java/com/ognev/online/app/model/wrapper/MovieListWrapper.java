package com.ognev.online.app.model.wrapper;

import com.ognev.online.app.model.Movie;
import com.google.gson.annotations.SerializedName;

import java.util.List;

public class MovieListWrapper {

  @SerializedName("value")
  public List<Movie> movies;

  public boolean hasMovies() {
    return movies !=null && !movies.isEmpty();
  }
}
