package com.ognev.online.app.adapter;

import android.content.Context;
import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;
import butterknife.Bind;
import butterknife.ButterKnife;
import com.ognev.online.app.R;
import com.ognev.online.app.model.ProfileDetails;

import java.util.List;

public class ProfileDetailsAdapter extends RecyclerView.Adapter<ProfileDetailsAdapter.ProfileDetailsViewHolder> {

  private Context context;
  private List<ProfileDetails> list;

  public ProfileDetailsAdapter(Context context, List<ProfileDetails> list) {
    this.context = context;
    this.list = list;
  }

  @Override
  public ProfileDetailsAdapter.ProfileDetailsViewHolder onCreateViewHolder(ViewGroup viewGroup, int i) {
    View view  = LayoutInflater.from(context).inflate(R.layout.profile_details_item, viewGroup, false);
    ProfileDetailsViewHolder holder = new ProfileDetailsViewHolder(view);
    return holder;
  }

  @Override
  public void onBindViewHolder(ProfileDetailsAdapter.ProfileDetailsViewHolder holder, int i) {
    holder.key.setText(list.get(i).key);
    holder.value.setText(list.get(i).value);
  }

  @Override
  public int getItemCount() {
    return list.size();
  }

  public class ProfileDetailsViewHolder extends RecyclerView.ViewHolder {
    @Bind(R.id.key) TextView key;
    @Bind(R.id.value) TextView value;

    public ProfileDetailsViewHolder(View itemView) {
      super(itemView);
      ButterKnife.bind(this, itemView);
    }
  }
}
