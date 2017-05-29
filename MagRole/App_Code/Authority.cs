using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;


	/// <summary>
	/// 类Authority。
	/// </summary>
	public class Authority
	{
		public Authority()
		{}
		#region Model
		private int _authorityid;
		private int _roleid;
		private int _moduleid;
		/// <summary>
		/// 
		/// </summary>
		public int AuthorityID
		{
			set{ _authorityid=value;}
			get{return _authorityid;}
		}
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
		public int MODULEID
		{
			set{ _moduleid=value;}
			get{return _moduleid;}
		}
		#endregion Model


		#region  成员方法

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int AuthorityID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Authority where AuthorityID="+AuthorityID+""  );
			return DbHelperSQL.Exists(strSql.ToString());
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add()
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Authority](");
			strSql.Append("ROLEID,MODULEID");
			strSql.Append(")");
			strSql.Append(" values (");
			strSql.Append(""+ROLEID+",");
			strSql.Append(""+MODULEID+"");
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
			strSql.Append("update Authority set ");
			strSql.Append("ROLEID="+ROLEID+",");
			strSql.Append("MODULEID="+MODULEID+"");
			strSql.Append(" where AuthorityID="+AuthorityID+" ");
			DbHelperSQL.ExecuteSql(strSql.ToString());
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int AuthorityID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete Authority ");
			strSql.Append(" where AuthorityID="+AuthorityID+"" );
				DbHelperSQL.ExecuteSql(strSql.ToString());
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public void GetModel(int AuthorityID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  ");
			strSql.Append("AuthorityID,ROLEID,MODULEID ");
			strSql.Append(" from Authority ");
			strSql.Append(" where AuthorityID="+AuthorityID+"" );
			DataSet ds=DbHelperSQL.Query(strSql.ToString());
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["AuthorityID"].ToString()!="")
				{
					AuthorityID=int.Parse(ds.Tables[0].Rows[0]["AuthorityID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ROLEID"].ToString()!="")
				{
					ROLEID=int.Parse(ds.Tables[0].Rows[0]["ROLEID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["MODULEID"].ToString()!="")
				{
					MODULEID=int.Parse(ds.Tables[0].Rows[0]["MODULEID"].ToString());
				}
			}
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select [AuthorityID],[ROLEID],[MODULEID] ");
			strSql.Append(" FROM Authority ");
			if(strWhere.Trim()!="")
			{

				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		#endregion  成员方法
	}

