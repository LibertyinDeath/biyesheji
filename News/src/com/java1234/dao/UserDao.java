package com.java1234.dao;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;

import com.java1234.model.User;

public class UserDao {

	public User login(Connection con,User user)throws Exception{
		User resultUser=null;
		String sql="select * from bbs_ucenter_member where id=? and username=?";
		PreparedStatement pstmt=con.prepareStatement(sql);
		pstmt.setInt(1, user.getUserId());
		pstmt.setString(2, user.getUserName());
		ResultSet rs=pstmt.executeQuery();
		if(rs.next()){
			resultUser=new User();
			resultUser.setUserId(rs.getInt("id"));
			resultUser.setUserName(rs.getString("username"));
		}
		return resultUser;
	}
}
