package com.ognev.online.app.model;

import java.util.Date;

public class User {
//    * {"FirstName":"SimpleUserFirstName_1","LastName":"SimpleUserLastName_2","Login":"SimpleUser1","BirthDate":"1994-06-21T00:00:00","Email":"ramazan.333a@gmail.com","Sex":0,"Balance":10000.0,"tariffId":null,"tariffName":null}

  public String firstName;

  public String lastName;

  public String login;

  public Date birthdate;

  public String email;

  public int gender;

  public float balance;

  public Subscription subscription;
}
