using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// ConfigHelper 的摘要说明
/// </summary>
public class ConfigHelper
{
	public ConfigHelper()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}
    public static String GetValueByKey(String Key)
    {
        return ConfigurationManager.ConnectionStrings["Mag_Role_ConnectionString"].ConnectionString;
    }
}
