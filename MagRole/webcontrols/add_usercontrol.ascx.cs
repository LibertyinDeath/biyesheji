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

public partial class webcontrols_add_usercontrol : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void bt_adduser_Click(object sender, EventArgs e)
    {
        USER myuser = new USER();
        myuser.USERNAME = this.tb_username.Text;
        myuser.PASSWORD = this.tb_password.Text;
        myuser.ROLEID = Convert.ToInt16(this.droplist_role.SelectedValue);
        if (myuser.Exists(tb_username.Text))
        {
            Response .Write (MessageBox .Show ("用户已经存在！"));

        }
        else
        {
            myuser.Add();
            Response.Write(MessageBox.Show(tb_username .Text +":用户添加成功"));
        }
    }
}
