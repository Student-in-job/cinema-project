package com.ognev.online.app.adapter;

import android.content.Context;
import android.content.Intent;
import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;
import butterknife.Bind;
import butterknife.ButterKnife;
import com.ognev.online.app.Constants;
import com.ognev.online.app.R;
import com.ognev.online.app.activity.VideoActivity;
import com.ognev.online.app.model.VideoDataListWrapper;
import com.squareup.picasso.Picasso;
import org.parceler.Parcels;

import java.util.List;

public class SimpleAdapter extends RecyclerView.Adapter<SimpleAdapter.SimpleViewHolder> {
    private static final int COUNT = 10;

    private final Context mContext;
    private int mCurrentItemId = 0;
  private List<VideoDataListWrapper> videos;

    public static class SimpleViewHolder extends RecyclerView.ViewHolder {
//       @Bind(R.id.title) TextView title;
      @Bind(R.id.video_image) ImageView videoImage;

        public SimpleViewHolder(View view) {
            super(view);
          ButterKnife.bind(this, view);
        }
    }

    public SimpleAdapter(Context context, List<VideoDataListWrapper> videos) {
        mContext = context;
     this.videos = videos;

    }

    public SimpleViewHolder onCreateViewHolder(ViewGroup parent, int viewType) {
        final View view = LayoutInflater.from(mContext).inflate(R.layout.item, parent, false);
        return new SimpleViewHolder(view);
    }

    @Override
    public void onBindViewHolder(SimpleViewHolder holder, final int position) {
//        holder.title.setText(videos.get(position).name);
      Picasso.with(mContext).cancelTag(holder.videoImage);
      Picasso.with(mContext).load(Constants.BASE_URL + "/uploads/" + videos.get(position).poster).fit().centerInside().into(holder.videoImage);
      holder.itemView.setOnClickListener(new View.OnClickListener() {
        @Override
        public void onClick(View v) {
          Intent mpdIntent = new Intent(mContext, VideoActivity.class)
              .putExtra(Constants.VIDEO, Parcels.wrap(videos.get(position)));
          mContext.startActivity(mpdIntent);
        }
      });
    }

//    public void addItem(int position) {
//        final int id = mCurrentItemId++;
//        mItems.add(position, id);
//        notifyItemInserted(position);
//    }
//
//    public void removeItem(int position) {
//        mItems.remove(position);
//        notifyItemRemoved(position);
//    }

    @Override
    public int getItemCount() {
        return videos.size() > 6 ? 6 : videos.size();
    }
}