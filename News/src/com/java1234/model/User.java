package com.java1234.model;

public class User {

	private int id;
	private String username;
	
	
	
	public User() {
		super();
		// TODO Auto-generated constructor stub
	}
	
	
	public User(int userId, String userName) {
		super();
		this.id = userId;
		this.username = userName;
	}


	public int getUserId() {
		return id;
	}
	public void setUserId(int userId) {
		this.id = userId;
	}
	public String getUserName() {
		return username;
	}
	public void setUserName(String userName) {
		this.username = userName;
	}
	
	
}
