using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        USER myuser = new USER();
        myuser.USERNAME = Request.QueryString["user"];
        string pwd = Request.QueryString["password"];
        string sqlGetUserID = "SELECT USERID FROM [USER] WHERE USERNAME='" + Request.QueryString["user"] + "'";
        int userid = Convert.ToInt16(DbHelperSQL.GetSingle(sqlGetUserID));
        myuser.GetModel(userid);
        if (userid == 0)
        {
            Response.Write("{\"success\":0, \"userName\":\"" + Request.QueryString["user"] + "\",\"authority\":\"\"}");
        }
        else
        {
            if (pwd != null)
            {
                if (myuser.PASSWORD.Trim() == pwd.Trim())
                {
                    if (myuser.ROLEID == 25)
                    {
                        Response.Write("{\"success\":1, \"userName\":\"" + Request.QueryString["user"] + "\", \"authority\":\"student\"}");
                    }
                    else
                    {
                        Response.Write("{\"success\":1, \"userName\":\"" + Request.QueryString["user"] + "\", \"authority\":\"teacher\"}");
                    }

                }
                else
                {
                    Response.Write("{\"success\":0, \"userName\":\"" + Request.QueryString["user"] + "\",\"authority\":\"\"}");

                }
            }
        }
            
       
    }
    
   
}
