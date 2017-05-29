using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

/// <summary>
/// USER 的摘要说明
/// </summary>
public class USER
{
	public USER()
		{}
		#region Model
		private int _userid;
		private string _username;
		private string _password;
		private int _roleid;
		/// <summary>
		/// 
		/// </summary>
		public int USERID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string USERNAME
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PASSWORD
		{
			set{ _password=value;}
			get{return _password;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int ROLEID
		{
			set{ _roleid=value;}
			get{return _roleid;}
		}
		#endregion Model


		#region  成员方法

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int USERID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [USER] where USERID="+USERID+" " );
			return DbHelperSQL.Exists(strSql.ToString());
		}
    /// <summary>
    /// 自己添加 根据姓名判断是否存在记录
    /// </summary>
    /// <param name="USERNAME"></param>
    /// <returns></returns>
    public bool Exists(String USERNAME)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("select count(1) from [USER] where USERNAME='"+USERNAME +"'");
        return DbHelperSQL.Exists(strSql.ToString());
    }

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add()
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [USER](");
			strSql.Append("USERNAME,PASSWORD,ROLEID");
			strSql.Append(")");
			strSql.Append(" values (");
			strSql.Append("'"+USERNAME+"',");
			strSql.Append("'"+PASSWORD+"',");
			strSql.Append(""+ROLEID+"");
			strSql.Append(")");
			strSql.Append(";select @@IDENTITY");
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 1;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update()
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [USER] set ");
			strSql.Append("USERNAME='"+USERNAME+"',");
			strSql.Append("PASSWORD='"+PASSWORD+"',");
			strSql.Append("ROLEID="+ROLEID+"");
			strSql.Append(" where USERID="+USERID+" ");
			DbHelperSQL.ExecuteSql(strSql.ToString());
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int USERID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete [USER] ");
			strSql.Append(" where USERID="+USERID+"" );
				DbHelperSQL.ExecuteSql(strSql.ToString());
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public void GetModel(int USERID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  ");
			strSql.Append("USERID,USERNAME,PASSWORD,ROLEID ");
			strSql.Append(" from [USER] ");
			strSql.Append(" where USERID="+USERID+"" );
			DataSet ds=DbHelperSQL.Query(strSql.ToString());
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["USERID"].ToString()!="")
				{
					USERID=int.Parse(ds.Tables[0].Rows[0]["USERID"].ToString());
				}
				USERNAME=ds.Tables[0].Rows[0]["USERNAME"].ToString();
				PASSWORD=ds.Tables[0].Rows[0]["PASSWORD"].ToString();
				if(ds.Tables[0].Rows[0]["ROLEID"].ToString()!="")
				{
					ROLEID=int.Parse(ds.Tables[0].Rows[0]["ROLEID"].ToString());
				}
			}
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select [USERID],[USERNAME],[PASSWORD],[ROLEID] ");
			strSql.Append(" FROM [USER] ");
			if(strWhere.Trim()!="")
			{

				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		#endregion  成员方法
}
