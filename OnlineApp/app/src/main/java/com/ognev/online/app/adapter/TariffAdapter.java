package com.ognev.online.app.adapter;

import android.os.Bundle;
import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;
import android.widget.TextView;
import butterknife.Bind;
import butterknife.ButterKnife;
import com.ognev.online.app.Constants;
import com.ognev.online.app.R;
import com.ognev.online.app.activity.BaseActivity;
import com.ognev.online.app.fragment.TariffDetailsDialog;
import com.ognev.online.app.model.Tariff;
import org.parceler.Parcels;

import java.util.List;

public class TariffAdapter extends RecyclerView.Adapter<TariffAdapter.TariffViewHolder> {
  private List<Tariff> tariffs;
  private BaseActivity context;
  private LayoutInflater inflater;

  public TariffAdapter(BaseActivity context, List<Tariff> tariffs) {
    this.tariffs = tariffs;
    this.context = context;
    inflater = LayoutInflater.from(context);
  }

  @Override
  public TariffViewHolder onCreateViewHolder(ViewGroup parent, int viewType) {
    return new TariffViewHolder(inflater.inflate(R.layout.tariff_item, parent, false));
  }

  @Override
  public void onBindViewHolder(TariffViewHolder holder, final int position) {

    holder.name.setText(tariffs.get(position).name);
    holder.price.setText(tariffs.get(position).price + "cум.");
    holder.add.setOnClickListener(new View.OnClickListener() {
      @Override
      public void onClick(View v) {
        TariffDetailsDialog tariffDetailsDialog = new TariffDetailsDialog();
        Bundle bundle = new Bundle();
        bundle.putParcelable(Constants.TARIFF, Parcels.wrap(tariffs.get(position)));
        tariffDetailsDialog.setArguments(bundle);
        tariffDetailsDialog.show(context.getFragmentManager(), TariffDetailsDialog.class.getName());

      }
    });

    holder.itemView.setOnClickListener(new View.OnClickListener() {
      @Override
      public void onClick(View v) {

      }
    });
  }

  @Override
  public int getItemCount() {
    return tariffs.size();
  }

  public class TariffViewHolder extends RecyclerView.ViewHolder {
    @Bind(R.id.name) TextView name;
//    @Bind(R.id.description) TextView description;
    @Bind(R.id.price) TextView price;
    @Bind(R.id.add) ImageView add;
    public TariffViewHolder(View itemView) {
      super(itemView);
      ButterKnife.bind(this, itemView);
    }
  }
}
