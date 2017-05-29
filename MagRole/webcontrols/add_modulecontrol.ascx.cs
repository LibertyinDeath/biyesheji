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

public partial class webcontrols_add_modulecontrol : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    /// <summary>
    /// module添加的方法
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void bt_moduleadd_Click(object sender, EventArgs e)
    {
        MODULE mymodule = new MODULE();
        mymodule.MODULE_NAME = this.tb_modulename.Text;
        mymodule.MODULE_DESCRIPTION = this.tb_moduledescription.Text;
        if (this.rab_genno.Checked ==true )
        {
            mymodule.MODULE_FATHERID = Convert.ToInt16(this.drpl_gen.SelectedValue);
        }
        else
        {
            mymodule .MODULE_FATHERID =0;
        }
        mymodule.MODULE_URL = this.tb_moduleurl.Text;
        mymodule.Add();
        Response.Write(MessageBox .Show ("添加成功！"));
    }
    #region panel更新方法
    protected void rab_genyes_CheckedChanged(object sender, EventArgs e)
    {
        if (rab_genyes.Checked == true && rab_genno.Checked == false)
        {
            this.panel_genno.Visible = false;
        }
        else
        {
            this.panel_genno.Visible = true;
        }
    }
    protected void rab_genno_CheckedChanged(object sender, EventArgs e)
    {

        if (rab_genyes.Checked == true && rab_genno.Checked  == false)
        {
            this.panel_genno.Visible = false;
        }
        else
        {
            this.panel_genno.Visible = true;
        }
    }
    #endregion
}
