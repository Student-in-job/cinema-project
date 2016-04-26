package com.android.online.app;

import android.app.Application;
import com.android.online.app.util.Prefs;

public class App extends Application {

  /*
  http://10.42.0.8/OnlineCinemaProject/api/user/profile
  * {"FirstName":"SimpleUserFirstName_1","LastName":"SimpleUserLastName_2","Login":"SimpleUser1","BirthDate":"1994-06-21T00:00:00","Email":"ramazan.333a@gmail.com","Sex":0,"Balance":10000.0,"tariffId":null,"tariffName":null}
  *
  * http://10.42.0.8/OnlineCinemaProject/api/user/history
  *
  * {"Episodehistories":[],"Moviehistories":[{"id":23,"videoImgUrl":"gods_of_egypt.jpg","movieId":4,"videoName":"Боги Египта","watchingDate":"2016-04-07T16:05:32"},{"id":24,"videoImgUrl":"gods_of_egypt.jpg","movieId":4,"videoName":"Боги Египта","watchingDate":"2016-04-07T16:18:18"}]}
  *
  * http://10.42.0.8/OnlineCinemaProject/api/user/purchases
  *
  * {

  "$id": "1",

  "Userseasons": [],

  "Usermovies": [

    {

      "$id": "2",

      "id": 1,

      "videoImgUrl": "gods_of_egypt.jpg",

      "movieId": 4,

      "videoName": "Боги Египта",

      "purchaseDate": "2016-04-06T05:22:11",

      "price": 10000.0

    }

  ]

}
  * */
  @Override
  public void onCreate() {
    super.onCreate();
    new Prefs(getApplicationContext());
    Constants.setBASE_URL(Prefs.getIp());
  }
}
