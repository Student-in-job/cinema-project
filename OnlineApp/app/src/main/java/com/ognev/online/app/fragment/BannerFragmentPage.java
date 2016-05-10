package com.ognev.online.app.fragment;

import android.app.Dialog;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.v4.app.DialogFragment;
import android.view.*;
import android.widget.ImageView;
import butterknife.ButterKnife;
import butterknife.OnClick;
import com.ognev.online.app.Constants;
import com.ognev.online.app.R;
import com.squareup.picasso.Picasso;

public class BannerFragmentPage extends DialogFragment {

  private String imgUrl;

  @Override
  public void onCreate(@Nullable Bundle savedInstanceState) {
    super.onCreate(savedInstanceState);
  }

  @Override
  public Dialog onCreateDialog(Bundle savedInstanceState) {
    Dialog dialog = super.onCreateDialog(savedInstanceState);

    // request a window without the title
    dialog.getWindow().requestFeature(Window.FEATURE_NO_TITLE);

    WindowManager.LayoutParams lp = new WindowManager.LayoutParams();
    Window window = dialog.getWindow();
    lp.copyFrom(window.getAttributes());
//This makes the dialog take up the full width
    lp.width = WindowManager.LayoutParams.MATCH_PARENT;
    lp.height = WindowManager.LayoutParams.MATCH_PARENT;
    window.setAttributes(lp);

    return dialog;
  }

  @Nullable
  @Override
  public View onCreateView(LayoutInflater inflater,
                           @Nullable ViewGroup container,
                           @Nullable Bundle savedInstanceState) {
    View view = inflater.inflate(R.layout.banner_view, container, false);
    ButterKnife.bind(this, view);

    ImageView imageView = (ImageView) view.findViewById(R.id.image);
    Picasso.with(getContext()).load(Constants.BASE_URL + "/uploads/" + getArguments().getString("banner"))
    .into(imageView);
    return view;
  }

  @OnClick(R.id.close)
  public void onCloseClicked() {
    dismiss();
  }
}
