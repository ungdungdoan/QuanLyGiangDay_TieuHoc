package com.example.loginregister1;

import java.util.ArrayList;
import java.util.List;

import org.apache.http.NameValuePair;
import org.apache.http.message.BasicNameValuePair;
import org.json.JSONObject;

import android.content.Context;
import android.content.SharedPreferences;

public class MyFunctions {
	JSONParser jsonparser;

	String loginurl = "http://10.0.2.2/android_db_1/index.php";
	String registerurl = "http://10.0.2.2/android_db_1/index.php";

	String login_tag = "login";
	String register_tag = "register";

	Context context;

	// ham tao khoi ta doi tuong jsonparser
	public MyFunctions(Context context) {
		jsonparser = new JSONParser();
		this.context = context;
	}

	// doc tu shared neu da log neu chua log tra ve false, log roi tra ve false
	public boolean checkLogin() {
		SharedPreferences lay = context.getSharedPreferences(null,
				context.MODE_WORLD_READABLE);
		String emaillogined = lay.getString("emaillogined", "chua login");
		if (emaillogined.equals("chua login"))
			return false;
		else
			return true;
	}

	// lay email da login
	public String getEmail() {
		SharedPreferences lay = context.getSharedPreferences(null,
				context.MODE_WORLD_READABLE);
		String emaillogined = lay.getString("emaillogined", "chua login");
		return emaillogined;
	}

	// ghi du lieu lai cho emaillogined thanh "chua login"
	public boolean logOut() {
		SharedPreferences ghi = context.getSharedPreferences(null,
				context.MODE_WORLD_WRITEABLE);
		SharedPreferences.Editor editor = ghi.edit();
		editor.putString("emaillogined", "chua login");
		editor.commit();
		return true;
	}

	// khi da login thi luu lai email lenh shared de biet da log
	public boolean setemaillogin(String email) {
		SharedPreferences ghi = context.getSharedPreferences(null,
				context.MODE_WORLD_WRITEABLE);
		SharedPreferences.Editor editor = ghi.edit();
		editor.putString("emaillogined", email);
		editor.commit();
		return true;
	}

	/*
	 * nhan du lieu goi ham va tra ve json chu y ArrayList va BasicNameValuePair
	 */
	public JSONObject loginUser(String email, String password) {
		List<NameValuePair> cacdoiso = new ArrayList<NameValuePair>();
		cacdoiso.add(new BasicNameValuePair("tag", login_tag));
		cacdoiso.add(new BasicNameValuePair("email", email));
		cacdoiso.add(new BasicNameValuePair("password", password));

		JSONObject jobj = jsonparser.getJSONFromUrl(loginurl, cacdoiso);

		setemaillogin(email);// gan len share de nho da login roi

		return jobj;
	}
	/*nhan du lieu dang ki
	 * chu y: tag, register_tag va doi so name
	 */
	public JSONObject registerUser(String name, String email, String password)
	{
		List<NameValuePair> cacdoiso=new ArrayList<NameValuePair>();
		cacdoiso.add(new BasicNameValuePair("tag",register_tag));
		cacdoiso.add(new BasicNameValuePair("name",name));
		cacdoiso.add(new BasicNameValuePair("email", email));
		cacdoiso.add(new BasicNameValuePair("password", password));
		
		JSONObject jobj=jsonparser.getJSONFromUrl(registerurl, cacdoiso);
		return jobj;
	}

}
