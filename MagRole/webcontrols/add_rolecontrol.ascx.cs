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

public partial class webcontrols_add_rolecontrol : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    /// <summary>
    /// 提交角色信息
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btRoleAdd_Click(object sender, EventArgs e)
    {
        ROLE myrole = new ROLE();
        myrole.ROLENAME = this.tb_rolename.Text;
        myrole.ROLEDESCRIPTION = this.tb_rolediscription.Text;
        //判断数据库里面是否存在改名称
        if (myrole.Exists(this.tb_rolename.Text))
        {
            Response.Write(MessageBox.Show("角色" + this.tb_rolename.Text + "：已经存在请重新输入其他的角色名称！"));
            this.tb_rolename.Text = "";
            this.tb_rolediscription.Text = "";
        }
        else
        {

            myrole.Add();

            //查询出ROLEID
            string selectRoleId = "SELECT ROLEID FROM ROLE WHERE ROLENAME='" + this.tb_rolename.Text + "'";
            int myroleid = Convert.ToInt16(DbHelperSQL.GetSingle(selectRoleId));
            //建立关系
            Authority myAuthority = new Authority();
            //设立关系中的 角色id
            myAuthority.ROLEID = myroleid;
            for (int i = 0; i < this.cbl_quanxian.Items.Count; i++)
            {
                //设立关系中的权限id
                myAuthority.MODULEID =Convert .ToInt16 ( this.cbl_quanxian.Items[i].Value);
                //添加关系入数据库
                myAuthority.Add();
            }
            //添加完毕
            Response.Write(MessageBox .Show ("添加成功！"));

        }
        
        
        
    }
    /// <summary>
    /// 选择权限
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void bt_addquanxian_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < this.checkbl_zi.Items.Count; i++)
        {
            if (this.checkbl_zi.Items[i].Selected == true)
            {
                this.cbl_quanxian .Items.Add(this.checkbl_zi.Items[i]);
               
            }

        }
    }
    /// <summary>
    /// 删除多选的权限 
    /// 这里有点问题，可能是删除没有删除好，有人的话帮我看下子。太奇怪了。
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void bt_moveaway_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < cbl_quanxian.Items.Count; i++)
        {
            if (this.cbl_quanxian.Items[i].Selected == true)
            {
                this.cbl_quanxian.Items.Remove(this.cbl_quanxian.Items[i]);
            }
        }
        for (int i = 0; i < cbl_quanxian.Items.Count; i++)
        {
            if (this.cbl_quanxian.Items[i].Selected == true)
            {
                this.cbl_quanxian.Items.Remove(this.cbl_quanxian.Items[i]);
            }
        }
        for (int i = 0; i < cbl_quanxian.Items.Count; i++)
        {
            if (this.cbl_quanxian.Items[i].Selected == true)
            {
                this.cbl_quanxian.Items.Remove(this.cbl_quanxian.Items[i]);
            }
        }
        for (int i = 0; i < cbl_quanxian.Items.Count; i++)
        {
            if (this.cbl_quanxian.Items[i].Selected == true)
            {
                this.cbl_quanxian.Items.Remove(this.cbl_quanxian.Items[i]);
            }
        }

        
    }
}
