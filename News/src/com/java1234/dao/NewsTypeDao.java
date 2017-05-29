package com.java1234.dao;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.util.ArrayList;
import java.util.List;

import com.java1234.model.NewsType;

public class NewsTypeDao {

	public List<NewsType> newsTypeList(Connection con)throws Exception{
		List<NewsType> newsTypeList=new ArrayList<NewsType>();
		String sql="select * from bbs_t_newstype";
		PreparedStatement pstmt=con.prepareStatement(sql);
		ResultSet rs=pstmt.executeQuery();
		while(rs.next()){
			NewsType newsType=new NewsType();
			newsType.setNewsTypeId(rs.getInt("newsTypeId"));
			newsType.setTypeName(rs.getString("typeName"));
			newsTypeList.add(newsType);
		}
		return newsTypeList;
	}
	
	public NewsType getNewsTypeById(Connection con,String newsTypeId)throws Exception{
		NewsType newsType=new NewsType();
		String sql="select * from bbs_t_newstype where newsTypeId=?";
		PreparedStatement pstmt=con.prepareStatement(sql);
		pstmt.setString(1, newsTypeId);
		ResultSet rs=pstmt.executeQuery();
		if(rs.next()){
			newsType.setNewsTypeId(rs.getInt("newsTypeId"));
			newsType.setTypeName(rs.getString("typeName"));
		}
		return newsType;
	}
	
	public int newsTypeAdd(Connection con,NewsType newsType)throws Exception{
		String sql="insert into bbs_t_newstype values(null,?)";
		PreparedStatement pstmt=con.prepareStatement(sql);
		pstmt.setString(1, newsType.getTypeName());
		return pstmt.executeUpdate();
	}
	
	public int newsTypeUpdate(Connection con,NewsType newsType)throws Exception{
		String sql="update bbs_t_newstype set typeName=? where newsTypeId=?";
		PreparedStatement pstmt=con.prepareStatement(sql);
		pstmt.setString(1, newsType.getTypeName());
		pstmt.setInt(2, newsType.getNewsTypeId());
		return pstmt.executeUpdate();
	}
	
	public int newsTypeDelete(Connection con,String newsTypeId)throws Exception{
		String sql="delete from bbs_t_newstype where newsTypeId=?";
		PreparedStatement pstmt=con.prepareStatement(sql);
		pstmt.setString(1, newsTypeId);
		return pstmt.executeUpdate();
	}
}
