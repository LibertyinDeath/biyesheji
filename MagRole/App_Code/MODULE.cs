using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

/// <summary>
/// MODULE 的摘要说明
/// </summary>
public class MODULE
{
	public MODULE()
		{}
		#region Model
		private int _moduleid;
		private string _module_name;
		private string _module_description;
		private string _module_url;
		private int? _module_fatherid;
		/// <summary>
		/// 
		/// </summary>
		public int MODULEID
		{
			set{ _moduleid=value;}
			get{return _moduleid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MODULE_NAME
		{
			set{ _module_name=value;}
			get{return _module_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MODULE_DESCRIPTION
		{
			set{ _module_description=value;}
			get{return _module_description;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MODULE_URL
		{
			set{ _module_url=value;}
			get{return _module_url;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? MODULE_FATHERID
		{
			set{ _module_fatherid=value;}
			get{return _module_fatherid;}
		}
		#endregion Model


		#region  成员方法

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int MODULEID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from MODULE where MODULEID="+MODULEID+""  );
			return DbHelperSQL.Exists(strSql.ToString());
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add()
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [MODULE](");
			strSql.Append("MODULE_NAME,MODULE_DESCRIPTION,MODULE_URL,MODULE_FATHERID");
			strSql.Append(")");
			strSql.Append(" values (");
			strSql.Append("'"+MODULE_NAME+"',");
			strSql.Append("'"+MODULE_DESCRIPTION+"',");
			strSql.Append("'"+MODULE_URL+"',");
			strSql.Append(""+MODULE_FATHERID+"");
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
			strSql.Append("update MODULE set ");
			strSql.Append("MODULE_NAME='"+MODULE_NAME+"',");
			strSql.Append("MODULE_DESCRIPTION='"+MODULE_DESCRIPTION+"',");
			strSql.Append("MODULE_URL='"+MODULE_URL+"',");
			strSql.Append("MODULE_FATHERID="+MODULE_FATHERID+"");
			strSql.Append(" where MODULEID="+MODULEID+" ");
			DbHelperSQL.ExecuteSql(strSql.ToString());
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int MODULEID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete MODULE ");
			strSql.Append(" where MODULEID="+MODULEID+"" );
				DbHelperSQL.ExecuteSql(strSql.ToString());
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public void GetModel(int MODULEID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  ");
			strSql.Append("MODULEID,MODULE_NAME,MODULE_DESCRIPTION,MODULE_URL,MODULE_FATHERID ");
			strSql.Append(" from MODULE ");
			strSql.Append(" where MODULEID="+MODULEID+"" );
			DataSet ds=DbHelperSQL.Query(strSql.ToString());
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["MODULEID"].ToString()!="")
				{
					MODULEID=int.Parse(ds.Tables[0].Rows[0]["MODULEID"].ToString());
				}
				MODULE_NAME=ds.Tables[0].Rows[0]["MODULE_NAME"].ToString();
				MODULE_DESCRIPTION=ds.Tables[0].Rows[0]["MODULE_DESCRIPTION"].ToString();
				MODULE_URL=ds.Tables[0].Rows[0]["MODULE_URL"].ToString();
				if(ds.Tables[0].Rows[0]["MODULE_FATHERID"].ToString()!="")
				{
					MODULE_FATHERID=int.Parse(ds.Tables[0].Rows[0]["MODULE_FATHERID"].ToString());
				}
			}
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select [MODULEID],[MODULE_NAME],[MODULE_DESCRIPTION],[MODULE_URL],[MODULE_FATHERID] ");
			strSql.Append(" FROM MODULE ");
			if(strWhere.Trim()!="")
			{

				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		#endregion  成员方法
}
