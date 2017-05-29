package com.java1234.web;

import java.io.IOException;
import java.sql.Connection;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

import com.java1234.dao.UserDao;
import com.java1234.model.User;
import com.java1234.util.DbUtil;

public class UserServlet extends HttpServlet{

	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;
	
	DbUtil dbUtil=new DbUtil();
	UserDao userDao=new UserDao();
	
	
	protected void doGet(HttpServletRequest request, HttpServletResponse response)
			throws ServletException, IOException {
		this.doPost(request, response);
	}

	@Override
	protected void doPost(HttpServletRequest request, HttpServletResponse response)
			throws ServletException, IOException {
		request.setCharacterEncoding("utf-8");
		String action=request.getParameter("action");
		if("login".equals(action)){
			login(request,response);
		}else if("logout".equals(action)){
			logout(request,response);
		}
		
	}
	
	private void login(HttpServletRequest request, HttpServletResponse response)
			throws ServletException, IOException {
		int is_login = 0;
		HttpSession session=request.getSession();
		if(session.getAttribute("is_login") != null){
			is_login = (Integer) session.getAttribute("is_login");
			System.out.println("out: "+"登录了is_login=" + is_login);
		}
		if(is_login==1){
			//request.setAttribute("id", session.getAttribute("id"));
			//request.setAttribute("username", session.getAttribute("username"));
			System.out.println("out: "+"跳转");
			request.setAttribute("mainPage", "/background/default.jsp");
			request.getRequestDispatcher("/background/mainTemp.jsp").forward(request, response);
		}
		
		int userId=Integer.parseInt(request.getParameter("id"));
		String userName= request.getParameter("username");
		Connection con=null;
		try{
			con=dbUtil.getCon();
			User user=new User(userId,userName);
			User currentUser=userDao.login(con, user);
			if(currentUser==null){
				request.setAttribute("error", "用户名或者密码错误！");
				request.setAttribute("id", userId);
				request.setAttribute("username", userName);
				request.getRequestDispatcher("/background/login.jsp").forward(request, response);
			}else{
				session.setAttribute("currentUser", currentUser);
				session.setAttribute("is_login", 1);
				session.setAttribute("id", userId);
				session.setAttribute("username", userName);
				response.sendRedirect("http://localhost/opensns-3.3.0/admin.php?s=/public/login.html&type=1");
				//request.setAttribute("mainPage", "/background/default.jsp");
				//request.getRequestDispatcher("/background/mainTemp.jsp").forward(request, response);
			}
		}catch(Exception e){
			e.printStackTrace();
		}finally{
			try {
				dbUtil.closeCon(con);
			} catch (Exception e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
		}
	}
	
	private void logout(HttpServletRequest request, HttpServletResponse response)
			throws ServletException, IOException {
		request.getSession().invalidate();
		HttpSession session=request.getSession();
		session.setAttribute("is_login", 0);
		response.sendRedirect("http://localhost/opensns-3.3.0/admin.php?s=/public/login.html&type=1");
//		System.out.println(request.getContextPath()+"/background/login.jsp");
//		response.sendRedirect(request.getContextPath()+"/background/login.jsp");
	}

}
