package com.example.register;

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
import android.widget.TextView;

import com.example.loginregister1.MainActivity;
import com.example.loginregister1.MyFunctions;
import com.example.loginregister1.R;

public class RegisterActivity extends ActionBarActivity {
	EditText et_name,et_password,et_email;
	TextView tv_thongbao;
	Button bt_register, bt_login;

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_register);
		et_name=(EditText)findViewById(R.id.editText1);
		et_email=(EditText)findViewById(R.id.editText2);
		et_password=(EditText)findViewById(R.id.editText3);
		
		tv_thongbao=(TextView)findViewById(R.id.textView2);
		bt_register=(Button)findViewById(R.id.button1);
		bt_login=(Button)findViewById(R.id.button2);	
		
		bt_login.setOnClickListener(new View.OnClickListener() {
			
			public void onClick(View v) {
				// TODO Auto-generated method stub
				Intent i=new Intent(getApplicationContext(),MainActivity.class);
				startActivity(i);
				finish();
			}
		});
		bt_register.setOnClickListener(new View.OnClickListener() {
			
			public void onClick(View v) {
				// TODO Auto-generated method stub
				new thucthiregister().execute();
				
			}
		});



	}
	
	class thucthiregister extends AsyncTask<Void,Void,String>
	{
		String name;
		String email;
		String password;
		MyFunctions myfunctions;
		@Override
		protected String doInBackground(Void... params) {
			// TODO Auto-generated method stub
			name=et_name.getText().toString();
			email=et_email.getText().toString();
			password=et_password.getText().toString();
			String thanhcong=null;
			try
			{
				myfunctions=new MyFunctions(getApplicationContext());
				JSONObject jsonobject=myfunctions.registerUser(name, email, password);
				thanhcong=jsonobject.getString("thanhcong");
				
			}catch(Exception e)
			{
				Log.d("loi", "khong tao json duoc, khong dang ki duoc " + e.toString());
			}
			return thanhcong;
		}

		@Override
		protected void onPostExecute(String thanhcong) {
			// TODO Auto-generated method stub
			super.onPostExecute(thanhcong);
			if(Integer.parseInt(thanhcong)==1)//dang ki thanh cong
			{
				tv_thongbao.setText("dang ki thanh cong \n email:\n" + 
	                                           email+ "\n nhan nut login ben duoi");
			}
			else
			{
				tv_thongbao.setText("dang ki khong thanh cong hoac email da ton tai");
			}
		}
		
	}


	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		// Inflate the menu; this adds items to the action bar if it is present.
		getMenuInflater().inflate(R.menu.register, menu);
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
