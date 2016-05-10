package com.ognev.online.app.activity;

import android.app.Dialog;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.v7.widget.LinearLayoutManager;
import android.support.v7.widget.RecyclerView;
import android.text.TextUtils;
import android.view.*;
import android.widget.Button;
import android.widget.EditText;
import android.widget.RatingBar;
import android.widget.Toast;
import butterknife.Bind;
import com.ognev.online.app.Constants;
import com.ognev.online.app.R;
import com.ognev.online.app.adapter.SeasonAdapter;
import com.ognev.online.app.adapter.VideoReviewAdapter;
import com.ognev.online.app.model.BaseVideo;
import com.ognev.online.app.model.Comment;
import com.ognev.online.app.model.ResponseObject;
import com.ognev.online.app.util.Prefs;
import org.parceler.Parcels;
import retrofit.Callback;
import retrofit.RetrofitError;
import retrofit.client.Response;

public class SerialActivity extends BaseActivity {

  private VideoReviewAdapter commentsAdapter;
  private SeasonAdapter seasonAdapter;
  @Bind(R.id.recyclerview)
  RecyclerView recyclerView;


  @Bind(R.id.rate)
  RatingBar ratingBar;

  @Bind(R.id.comments)
  RecyclerView commentsRecyclerView;

  private BaseVideo serial;
  @Override
  protected void onCreate(@Nullable Bundle savedInstanceState) {
    super.onCreate(savedInstanceState);
    setContentView(R.layout.serial_view);
    getSupportActionBar().setDisplayHomeAsUpEnabled(true);
    serial = Parcels.unwrap(getIntent().getParcelableExtra(Constants.SERIAL));
    commentsAdapter = new VideoReviewAdapter(this, serial.comments);
    seasonAdapter = new SeasonAdapter(this, serial.seasons);

    LinearLayoutManager layoutManager
        = new LinearLayoutManager(this, LinearLayoutManager.HORIZONTAL, false);

    commentsRecyclerView.setLayoutManager(new LinearLayoutManager(this, LinearLayoutManager.VERTICAL, false));
    commentsRecyclerView.setAdapter(commentsAdapter);
    recyclerView.setLayoutManager(layoutManager);
    recyclerView.setAdapter(seasonAdapter);

    ratingBar.setOnRatingBarChangeListener(new RatingBar.OnRatingBarChangeListener() {
      @Override
      public void onRatingChanged(RatingBar ratingBar, final float rating, boolean fromUser) {
        // custom dialog
        final Dialog dialog = new Dialog(SerialActivity.this);
        View view = LayoutInflater.from(SerialActivity.this).inflate(R.layout.review_dialog, null);
        final RatingBar rate = ((RatingBar)view.findViewById(R.id.rate));
        final EditText review  = (EditText) view.findViewById(R.id.review);
        Button send  = (Button) view.findViewById(R.id.send);

        rate.setRating(ratingBar.getRating());
        send.setOnClickListener(new View.OnClickListener() {
          @Override
          public void onClick(View v) {
            Comment comment = new Comment();
            comment.rating = rate.getRating();
            if(!TextUtils.isEmpty(review.getText()) && !TextUtils.isEmpty(review.getText().toString()))
              comment.comment = review.getText().toString();
            comment.videoId = serial.id;
            comment.authorId = Prefs.getUserId();
            dialog.dismiss();
            reviewService.saveReview(comment, new Callback<ResponseObject<Object>>() {
              @Override
              public void success(ResponseObject<Object> o, Response response) {
                if(o.data == null) {
                  showInfoDialog(o.error.message);
                } else
                Toast.makeText(getApplicationContext(), "Комментарий сохранен", Toast.LENGTH_SHORT).show();
              }

              @Override
              public void failure(RetrofitError error) {
                showInfoDialog(error.getMessage());
              }
            });
          }
        });

        dialog.setContentView(view);
        WindowManager.LayoutParams lp = new WindowManager.LayoutParams();
        Window window = dialog.getWindow();
        lp.copyFrom(window.getAttributes());
//This makes the dialog take up the full width
        lp.width = WindowManager.LayoutParams.MATCH_PARENT;
        lp.height = WindowManager.LayoutParams.WRAP_CONTENT;
        window.setAttributes(lp);
        dialog.show();
      }
    });

  }


  @Override
  public boolean onOptionsItemSelected(MenuItem item) {
    switch (item.getItemId()) {
      case android.R.id.home:
        finish();
        break;
    }

    return super.onOptionsItemSelected(item);
  }
}
