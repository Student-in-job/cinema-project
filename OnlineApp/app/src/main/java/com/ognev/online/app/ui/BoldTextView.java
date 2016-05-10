package com.ognev.online.app.ui;

import android.content.Context;
import android.graphics.Typeface;
import android.util.AttributeSet;
import android.widget.TextView;

public class BoldTextView extends TextView {
  public BoldTextView(Context context) {
    super(context);
    setTypeface(Typeface.createFromAsset(getContext().getAssets(), "AvenirNext-BoldItalic.ttf"));
  }

  public BoldTextView(Context context, AttributeSet attrs) {
    super(context, attrs);
    setTypeface(Typeface.createFromAsset(getContext().getAssets(), "AvenirNext-BoldItalic.ttf"));
  }

  public BoldTextView(Context context, AttributeSet attrs, int defStyleAttr) {
    super(context, attrs, defStyleAttr);
    setTypeface(Typeface.createFromAsset(getContext().getAssets(), "AvenirNext-BoldItalic.ttf"));
  }

  public BoldTextView(Context context, AttributeSet attrs, int defStyleAttr, int defStyleRes) {
    super(context, attrs, defStyleAttr, defStyleRes);
    setTypeface(Typeface.createFromAsset(getContext().getAssets(), "AvenirNext-BoldItalic.ttf"));
  }
}
