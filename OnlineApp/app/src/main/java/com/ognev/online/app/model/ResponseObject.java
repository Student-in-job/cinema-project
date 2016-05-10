package com.ognev.online.app.model;

public class ResponseObject<T> {

  public int responseCode;

  public String status;

  public ResponseError error;


  public T data;
}
