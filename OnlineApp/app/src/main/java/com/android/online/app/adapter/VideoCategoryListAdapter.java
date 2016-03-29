//package com.android.online.app.adapter;
//
//import android.content.Context;
//import android.support.v7.widget.RecyclerView;
//import android.view.LayoutInflater;
//import android.view.View;
//import android.view.ViewGroup;
//import android.widget.ImageView;
//import android.widget.TextView;
//import android.widget.Toast;
//import butterknife.Bind;
//import butterknife.ButterKnife;
//import butterknife.OnClick;
//import com.android.ipxchange.R;
//import com.android.ipxchange.constants.Const;
//import com.android.ipxchange.models.api.Active;
//import com.android.ipxchange.models.api.Comment;
//import com.android.ipxchange.utils.Util;
//import com.android.online.app.Const;
//import com.android.online.app.model.Video;
//import de.hdodenhof.circleimageview.CircleImageView;
//
//import java.text.SimpleDateFormat;
//import java.util.List;
//
//public class VideoCategoryListAdapter extends RecyclerView.Adapter {
//  private static final int TYPE_CATEGORY = 0;
//  private static final int TYPE_VIDEO = 1;
//  private static final int TYPE_ITEM_ANSWER = 2;
//  private static final int TYPE_FOOTER = 3;
//
//  private Context context;
//  private List<Video> videos;
//
//  public VideoCategoryListAdapter(Context context, List<Video> videos) {
//    this.context = context;
//    this.videos = videos;
//  }
//
//  @Override
//  public RecyclerView.ViewHolder onCreateViewHolder(ViewGroup parent, int viewType) {
//    RecyclerView.ViewHolder holder = null;
//    switch (viewType) {
//      case TYPE_CATEGORY:
//        holder = new HeaderViewHolder(LayoutInflater.from(context)
//            .inflate(R.layout.business_active_detail_header, null));
//        break;
//
//      case TYPE_VIDEO:
//        holder = new QuestionViewHolder(LayoutInflater.from(context)
//            .inflate(R.layout.business_active_detail_comment_question_item, null));
//        break;
//
////       case TYPE_ITEM_ANSWER:
////        holder = new AnswerViewHolder(LayoutInflater.from(context)
////            .inflate(R.layout.business_active_detail_comment_answer_item, null));
////        break;
////
////       case TYPE_FOOTER:
////        holder = new FooterViewHolder(LayoutInflater.from(context)
////            .inflate(R.layout.business_active_detail_comment_footer, null));
//        break;
//    }
//
//
//    return holder;
//  }
//
//
//  @Override
//  public int getItemViewType(int position) {
//    if (isPositionCategory(position)) {
//      return TYPE_CATEGORY;
//    }
//
//    if(isPositionVideo(position)) {
//      return TYPE_VIDEO;
//    }
//
//    return getItemType(position);
//  }
//
//  private boolean isPositionVideo(int position) {
//    return position == getItemCount() -1 ;
//  }
//
//  private boolean isPositionCategory(int position) {
//    return getItemType(position) == TYPE_CATEGORY;
//  }
//
//  @Override
//  public void onBindViewHolder(RecyclerView.ViewHolder holder, int position) {
//    switch (getItemViewType(position)) {
//      case TYPE_CATEGORY:
//        if(active != null)
//        ((HeaderViewHolder) holder).showHeader(active);
//        break;
//    }
//
//  }
//
//  @Override
//  public int getItemCount() {
//    return comments.size();
//  }
//
//  public int getItemType(int position) {
//    return Const.CATEGORY.equals(getItem(position).type)
//        ? TYPE_VIDEO : TYPE_CATEGORY;
//  }
//
//  private Comment getItem(int position) {
//    return comments.get(position);
//  }
//
//  public class HeaderViewHolder extends RecyclerView.ViewHolder {
//  @Bind(R.id.active_image) ImageView activeImage;
//  @Bind(R.id.title) TextView activeTitle;
//  @Bind(R.id.description) TextView activeDescription;
//  @Bind(R.id.cost) TextView activeCost;
//  @Bind(R.id.status) TextView activeStatus;
//  @Bind(R.id.publish_date) TextView activeDate;
//  @Bind(R.id.business_detail_lookups) TextView mActiveLookups;
//  @Bind(R.id.like_count) TextView likeCount;
//  @Bind(R.id.dislike_count) TextView dislikeCount;
//  @Bind(R.id.contacts) TextView mContacts;
//  @Bind(R.id.domen_type) TextView mActiveType;
//  @Bind(R.id.sector) TextView mActiveSection;
//  @Bind(R.id.countries) TextView mActiveCountries;
//  @Bind(R.id.juristic) TextView mActiveJuristic;
//  @Bind(R.id.current_rightholder) TextView mActiveCurrentRight;
//  @Bind(R.id.comment_count) TextView commentSize;
//  @Bind(R.id.protected_image) ImageView protectedImage;
//  @Bind(R.id.checked_image) ImageView checkedImage;
//  @Bind(R.id.rate_image) ImageView rateImage;
//    private SimpleDateFormat simpleDateFormat;
//
//    public HeaderViewHolder(View itemView) {
//      super(itemView);
//      RecyclerView.LayoutParams lp = new RecyclerView.LayoutParams(ViewGroup.LayoutParams.MATCH_PARENT, ViewGroup.LayoutParams.WRAP_CONTENT);
//      itemView.setLayoutParams(lp);
//      ButterKnife.bind(this, itemView);
//      simpleDateFormat = new SimpleDateFormat("dd.MM.yyyy HH.mm");
//    }
//
//    @OnClick(R.id.contacts)
//    public void onContactClicked() {
//      Toast.makeText(context, "click", Toast.LENGTH_SHORT).show();
//    }
//
//    public void showHeader(Active active) {
//      activeTitle.setText(active.data.asset.title);
//      activeDescription.setText(active.data.asset.details);
//      activeCost.setText(context.getString(R.string.cost_price, active.data.asset.cost));
//      activeStatus.setText(Const.ACTIVE.equals(active.data.asset.moderation) ?
//        context.getString(R.string.active) : context.getString(R.string.deactive));
//
//    mActiveLookups.setText(active.data.asset.show);
//      activeDate.setText(context.getString(R.string.published,
//          simpleDateFormat.format(active.data.asset.createdAt)));
//    commentSize.setText(String.valueOf(comments.size()));
//    protectedImage.setPressed(Const.YES.equals(active.data.asset.protectedVal));
//    checkedImage.setPressed(Const.YES.equals(active.data.asset.checked));
//    likeCount.setText(active.like);
//    dislikeCount.setText(active.dislike);
//
//    mActiveCurrentRight.setText(Util.getText(
//        context.getString(R.string.business_detail_current_rightholder, active.data.asset.currentRightHolder)));
//      activeCost.setText(Util.getText(context.getString(R.string.business_detail_cost, active.data.asset.cost)));
//        mActiveType.setText(Util.getText(context.getString(R.string.business_detail_type, "aaa")));
//        mActiveSection.setText(Util.getText(context.getString(R.string.business_detail_section, "aaa")));
//        mActiveCountries.setText(Util.getText(context.getString(R.string.business_detail_countries, "aaa")));
//    }
//  }
//
//  public class QuestionViewHolder extends RecyclerView.ViewHolder {
//
//    @Bind(R.id.user_photo) CircleImageView userPhoto;
//    @Bind(R.id.username) TextView userName;
//    @Bind(R.id.date) TextView publishDate;
//    @Bind(R.id.comment) TextView comment;
//    @Bind(R.id.answer) TextView answer;
//    @Bind(R.id.like_count) TextView likeCount;
//    @Bind(R.id.dislike_count) TextView dislikeCount;
//    @Bind(R.id.comment_count) TextView commentCount;
//
//
//    public QuestionViewHolder(View itemView) {
//      super(itemView);
//      RecyclerView.LayoutParams lp = new RecyclerView.LayoutParams(ViewGroup.LayoutParams.MATCH_PARENT, ViewGroup.LayoutParams.WRAP_CONTENT);
//      itemView.setLayoutParams(lp);
//      ButterKnife.bind(this, itemView);
//    }
//  }
//
//  public class AnswerViewHolder extends RecyclerView.ViewHolder {
//    @Bind(R.id.user_photo) CircleImageView userPhoto;
//    @Bind(R.id.username) TextView userName;
//    @Bind(R.id.date) TextView publishDate;
//    @Bind(R.id.comment) TextView comment;
//
//    public AnswerViewHolder(View itemView) {
//      super(itemView);
//      RecyclerView.LayoutParams lp = new RecyclerView.LayoutParams(ViewGroup.LayoutParams.MATCH_PARENT, ViewGroup.LayoutParams.WRAP_CONTENT);
//      itemView.setLayoutParams(lp);
//      ButterKnife.bind(this, itemView);
//    }
//  }
//
//  public class FooterViewHolder extends RecyclerView.ViewHolder {
//
//    public FooterViewHolder(View itemView) {
//      super(itemView);
//      RecyclerView.LayoutParams lp = new RecyclerView.LayoutParams(ViewGroup.LayoutParams.MATCH_PARENT, ViewGroup.LayoutParams.WRAP_CONTENT);
//      itemView.setLayoutParams(lp);
//      ButterKnife.bind(this, itemView);
//    }
//  }
//}
