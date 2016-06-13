package com.ognev.online.app.fragment;

import android.app.Dialog;
import android.app.DialogFragment;
import android.graphics.drawable.ColorDrawable;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.view.*;
import android.widget.TextView;
import android.widget.Toast;
import butterknife.Bind;
import butterknife.ButterKnife;
import butterknife.OnClick;
import com.ognev.online.app.Constants;
import com.ognev.online.app.R;
import com.ognev.online.app.activity.BaseActivity;
import com.ognev.online.app.model.ResponseObject;
import com.ognev.online.app.model.Tariff;
import org.parceler.Parcels;
import retrofit.Callback;
import retrofit.RetrofitError;
import retrofit.client.Response;

public class TariffDetailsDialog extends DialogFragment {

  private Tariff tariff;

  @Bind(R.id.name)  TextView name;
  @Bind(R.id.description)  TextView description;
  @Override
  public void onCreate(Bundle savedInstanceState) {
    super.onCreate(savedInstanceState);
    tariff = Parcels.unwrap(getArguments().getParcelable(Constants.TARIFF));
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
    dialog.getWindow().setBackgroundDrawable(new ColorDrawable(0));
    return dialog;
  }

  @Nullable
  @Override
  public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
    View view = inflater.inflate(R.layout.tariff_detail_dialog, container, false);
    ButterKnife.bind(this, view);
    return view;
  }

  @Override
  public void onViewCreated(View view, Bundle savedInstanceState) {
    super.onViewCreated(view, savedInstanceState);
    name.setText(tariff.name);
    description.setText(tariff.description);
  }

  @OnClick(R.id.back)
  public void onBackClicked() {
    dismiss();
  }

  @OnClick(R.id.subscribe)
  public void onSubscribeClicked() {
    ((BaseActivity) getActivity()).tariffService.subscribeTariff(tariff.id, new Callback<ResponseObject<Tariff>>() {
      @Override
      public void success(ResponseObject<Tariff> response, Response responses) {
        if(response.error != null)
        switch (response.error.code) {
          case Constants.N_ENOUGH_MONEY:
            ((BaseActivity) getActivity()).showInfoDialog(response.error.message);
            break;

          case Constants.YOU_HAVE_TARIFF:
            ((BaseActivity) getActivity()).showInfoDialog(response.error.message);
            break;
        } else {
          Toast.makeText(getActivity(), getString(R.string.success_purchased_tariff, tariff.name), Toast.LENGTH_SHORT).show();
        }
        dismiss();
      }

      @Override
      public void failure(RetrofitError error) {
        ((BaseActivity) getActivity()).showInfoDialog(error.getMessage());
      }
    });
  }
}
