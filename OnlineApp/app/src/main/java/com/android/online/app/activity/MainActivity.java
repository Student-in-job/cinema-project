package com.android.online.app.activity;

import android.os.Bundle;
import android.support.v7.widget.GridLayoutManager;
import android.support.v7.widget.RecyclerView;
import butterknife.Bind;
import butterknife.ButterKnife;
import com.android.online.app.R;
import com.android.online.app.adapter.SectionedGridRecyclerViewAdapter;
import com.android.online.app.adapter.SimpleAdapter;

import java.util.ArrayList;
import java.util.List;


public class MainActivity extends MenuActivity {

  @Bind(R.id.list)
  RecyclerView mRecyclerView;
  private SimpleAdapter mAdapter;

  @Override
  protected void onCreate(Bundle savedInstanceState) {
    super.onCreate(savedInstanceState);
    setContentView(R.layout.activity_main);
    ButterKnife.bind(this);
    //Your RecyclerView
    mRecyclerView.setHasFixedSize(true);
    mRecyclerView.setLayoutManager(new GridLayoutManager(this, 4));

    //Your RecyclerView.Adapter
    mAdapter = new SimpleAdapter(this);


    //This is the code to provide a sectioned grid
    List<SectionedGridRecyclerViewAdapter.Section> sections =
        new ArrayList<SectionedGridRecyclerViewAdapter.Section>();

    //Sections
    sections.add(new SectionedGridRecyclerViewAdapter.Section(0,"Драма"));
    sections.add(new SectionedGridRecyclerViewAdapter.Section(5,"Мультфильмы"));
//    sections.add(new SectionedGridRecyclerViewAdapter.Section(12,"Section 3"));
//    sections.add(new SectionedGridRecyclerViewAdapter.Section(14,"Section 4"));
//    sections.add(new SectionedGridRecyclerViewAdapter.Section(20,"Section 5"));

    //Add your adapter to the sectionAdapter
    SectionedGridRecyclerViewAdapter.Section[] dummy = new SectionedGridRecyclerViewAdapter.Section[sections.size()];
    SectionedGridRecyclerViewAdapter mSectionedAdapter = new
        SectionedGridRecyclerViewAdapter(this, R.layout.section,
        R.id.section_text, mRecyclerView, mAdapter);
    mSectionedAdapter.setSections(sections.toArray(dummy));
    //Apply this adapter to the RecyclerView
    mRecyclerView.setAdapter(mSectionedAdapter);

  }


//  @Override
//  public boolean onCreateOptionsMenu(Menu menu) {
//    // Inflate the menu; this adds items to the action bar if it is present.
//    getMenuInflater().inflate(R.menu.menu_main, menu);
//    return true;
//  }

//  @Override
//  public boolean onOptionsItemSelected(MenuItem item) {
//    // Handle action bar item clicks here. The action bar will
//    // automatically handle clicks on the Home/Up button, so long
//    // as you specify a parent activity in AndroidManifest.xml.
//    int id = item.getItemId();
//
//    //noinspection SimplifiableIfStatement
//    if (id == R.id.action_settings) {
//      return true;
//    }
//
//    return super.onOptionsItemSelected(item);
//  }
}
