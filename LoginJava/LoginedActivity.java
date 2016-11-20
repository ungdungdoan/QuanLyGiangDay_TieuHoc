package com.example.logined;

import android.content.Intent;
import android.os.Bundle;
import android.support.v7.app.ActionBarActivity;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;

import com.example.loginregister1.MainActivity;
import com.example.loginregister1.MyFunctions;
import com.example.loginregister1.R;

public class LoginedActivity extends ActionBarActivity {

	TextView tv;
	Button bt_logout;
	MyFunctions myfunctions;

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_logined);
		tv=(TextView)findViewById(R.id.textView1);
		bt_logout=(Button)findViewById(R.id.button1);
		
		myfunctions=new MyFunctions(getApplicationContext());
		String s=tv.getText().toString();
		tv.setText(s+"\n"+myfunctions.getEmail());
		
		//nut logout
		bt_logout.setOnClickListener(new View.OnClickListener() {
			
			public void onClick(View v) {
				// TODO Auto-generated method stub
				myfunctions.logOut();
				Intent i=new Intent(getApplicationContext(),MainActivity.class);
				startActivity(i);
				finish();
			}
		});

	}

	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		// Inflate the menu; this adds items to the action bar if it is present.
		getMenuInflater().inflate(R.menu.logined, menu);
		return true;
	}

	@Override
	public boolean onOptionsItemSelected(MenuItem item) {
		// Handle action bar item clicks here. The action bar will
		// automatically handle clicks on the Home/Up button, so long
		// as you specify a parent activity in AndroidManifest.xml.
		int id = item.getItemId();
		if (id == R.id.action_settings) {
			return true;
		}
		return super.onOptionsItemSelected(item);
	}
}
