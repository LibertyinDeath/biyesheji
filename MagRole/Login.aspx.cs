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

    }
    protected void bt_login_Click(object sender, EventArgs e)
    {
        USER myuser = new USER();
        myuser.USERNAME = this.tb_username.Text; 
        string pwd = this.tb_password.Text;
        string sqlGetUserID = "SELECT USERID FROM [USER] WHERE USERNAME='"+this.tb_username .Text +"'";
        int userid = Convert .ToInt16 (DbHelperSQL.GetSingle(sqlGetUserID));
        myuser.GetModel(userid);
        if (userid!=0)
        {
            if (myuser.PASSWORD.Trim() == pwd.Trim())
            {
                Response.Write(MessageBox.Show("登入成功"));
                ROLE myrole = new ROLE();
                myrole.ROLEID = myuser.ROLEID;
                myrole.GetModel(myrole.ROLEID);
                Session["roleid"] = Convert.ToInt16(myrole.ROLEID);
                Response.Redirect("index.aspx");
            }
            else
            {
                Response.Write(MessageBox.Show("登入失败"));
            }
        }
       
        
    }
}
