package com.ognev.online.app.model;

import org.parceler.Parcel;

import java.util.Date;

@Parcel
public class Subscription {

  public int id;
  public int tariffId;
  public String tariffName;
  public Date start;
  public Date end;
}
