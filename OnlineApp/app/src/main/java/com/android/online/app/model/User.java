package com.android.online.app.model;

import com.google.gson.annotations.SerializedName;

import java.util.Date;

public class User {
//    * {"FirstName":"SimpleUserFirstName_1","LastName":"SimpleUserLastName_2","Login":"SimpleUser1","BirthDate":"1994-06-21T00:00:00","Email":"ramazan.333a@gmail.com","Sex":0,"Balance":10000.0,"tariffId":null,"tariffName":null}

  @SerializedName("FirstName")
  public String firstName;

  @SerializedName("LastName")
  public String lastName;

  @SerializedName("Login")
  public String login;

  @SerializedName("BirthDate")
  public Date birthdate;

  @SerializedName("Email")
  public String email;

  @SerializedName("Sex")
  public int gender;

  @SerializedName("Balance")
  public float balance;
}
