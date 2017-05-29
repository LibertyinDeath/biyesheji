using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

/// <summary>
/// ROLE 的摘要说明
/// </summary>
public class ROLE
{
	public ROLE()
		{}
		#region Model
		private int _roleid;
		private string _rolename;
		private string _roledescription;
		/// <summary>
		/// 
		/// </summary>
		public int ROLEID
		{
			set{ _roleid=value;}
			get{return _roleid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ROLENAME
		{
			set{ _rolename=value;}
			get{return _rolename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ROLEDESCRIPTION
		{
			set{ _roledescription=value;}
			get{return _roledescription;}
		}
		#endregion Model


		#region  成员方法

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ROLEID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from ROLE where ROLEID="+ROLEID+" " );
			return DbHelperSQL.Exists(strSql.ToString());
		}
    /// <summary>
    /// 非代码自动生成 根据名称查看是否存在该记录
    /// </summary>
    /// <param name="ROLENAME"></param>
    /// <returns></returns>
    public bool Exists(String ROLENAME)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("SELECT COUNT(1) FROM ROLE WHERE ROLENAME='" + ROLENAME + "'");
        return DbHelperSQL.Exists(strSql.ToString());
    }

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add()
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [ROLE](");
			strSql.Append("ROLENAME,ROLEDESCRIPTION");
			strSql.Append(")");
			strSql.Append(" values (");
			strSql.Append("'"+ROLENAME+"',");
			strSql.Append("'"+ROLEDESCRIPTION+"'");
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
			strSql.Append("update ROLE set ");
			strSql.Append("ROLENAME='"+ROLENAME+"',");
			strSql.Append("ROLEDESCRIPTION='"+ROLEDESCRIPTION+"'");
			strSql.Append(" where ROLEID="+ROLEID+" ");
			DbHelperSQL.ExecuteSql(strSql.ToString());
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int ROLEID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete ROLE ");
			strSql.Append(" where ROLEID="+ROLEID+"" );
				DbHelperSQL.ExecuteSql(strSql.ToString());
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public void GetModel(int ROLEID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  ");
			strSql.Append("ROLEID,ROLENAME,ROLEDESCRIPTION ");
			strSql.Append(" from ROLE ");
			strSql.Append(" where ROLEID="+ROLEID+"");
			DataSet ds=DbHelperSQL.Query(strSql.ToString());
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ROLEID"].ToString()!="")
				{
					ROLEID=int.Parse(ds.Tables[0].Rows[0]["ROLEID"].ToString());
				}
				ROLENAME=ds.Tables[0].Rows[0]["ROLENAME"].ToString();
				ROLEDESCRIPTION=ds.Tables[0].Rows[0]["ROLEDESCRIPTION"].ToString();
			}
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select [ROLEID],[ROLENAME],[ROLEDESCRIPTION] ");
			strSql.Append(" FROM ROLE ");
			if(strWhere.Trim()!="")
			{

				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		#endregion  成员方法
}
