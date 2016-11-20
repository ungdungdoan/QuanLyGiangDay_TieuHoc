package com.example.loginregister1;

import org.json.JSONObject;

import android.content.Intent;
import android.os.AsyncTask;
import android.os.Bundle;
import android.support.v7.app.ActionBarActivity;
import android.util.Log;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

import com.example.logined.LoginedActivity;
import com.example.register.RegisterActivity;

public class MainActivity extends ActionBarActivity {

	EditText et_email, et_password;
	Button bt_login, bt_register;

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_main);
		et_email = (EditText) findViewById(R.id.editText1);
		et_password = (EditText) findViewById(R.id.editText2);
		bt_login = (Button) findViewById(R.id.button1);
		bt_register = (Button) findViewById(R.id.button2);
		bt_register.setOnClickListener(new View.OnClickListener() {

			public void onClick(View v) {
				// TODO Auto-generated method stub
				Intent i = new Intent(getApplicationContext(),
						RegisterActivity.class);
				startActivity(i);
				finish();
			}
		});

		bt_login.setOnClickListener(new View.OnClickListener() {

			public void onClick(View v) {
				// TODO Auto-generated method stub
				new thucthilogin().execute();
			}
		});

	}

	class thucthilogin extends AsyncTask<Void, Void, String> {
		MyFunctions myfunctions;
		String email;
		String password;

		@Override
		protected String doInBackground(Void... arg0) {
			// TODO Auto-generated method stub
			email = et_email.getText().toString();
			password = et_password.getText().toString();
			String thanhcong = null;

			try {
				myfunctions = new MyFunctions(getApplicationContext());
				JSONObject jsonobject = myfunctions.loginUser(email, password);

				thanhcong = jsonobject.getString("thanhcong");

			} catch (Exception e) {
				Log.d("loi", "khong tao json duoc " + e.toString());
			}
			return thanhcong;
		}

		@Override
		protected void onPostExecute(String thanhcong) {
			// TODO Auto-generated method stub
			super.onPostExecute(thanhcong);
			if (Integer.parseInt(thanhcong) == 1) // dang nhap thanh cong
			{
				myfunctions.setemaillogin(email);// luu mail lai
				Intent i = new Intent(getApplicationContext(),
						LoginedActivity.class);
				startActivity(i);
				finish();
			} else // dang nhap that bai
			{
				Toast.makeText(getApplicationContext(),
						"khong dang nhap duoc email hoac pass sai",
						Toast.LENGTH_SHORT).show();
			}
		}

	}

	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		// Inflate the menu; this adds items to the action bar if it is present.
		getMenuInflater().inflate(R.menu.main, menu);
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
