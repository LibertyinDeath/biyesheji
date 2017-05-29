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

//该源码下载自www.51aspx.com(５１aｓｐx．ｃｏｍ)

using System.Data.SqlClient;
public partial class webcontrols_treeview : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        #region 获取当前权限表
        ROLE myrole = new ROLE();
        myrole.ROLEID = Convert.ToInt16(Session["roleid"].ToString());
        myrole.GetModel(myrole.ROLEID);
        //获取整个表，里面包含当前所有权限的moduleid
        DataSet ds = new DataSet();
        Authority myauthority = new Authority();
        ds = myauthority.GetList("RoleID=" + myrole.ROLEID + "");
        #endregion
        #region  父节点添加
        //建立int来防止fathermoduleid相同来判断并且只建立一个fathernode
        int fathermoduleid = 100;
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            MODULE mymodule = new MODULE();
            //设立查询的moduleid
            mymodule.MODULEID = Convert.ToInt16(ds.Tables[0].Rows[i].ItemArray[2]);
            //获取实例module
            mymodule.GetModel(mymodule.MODULEID);
            
            //查询父节点
            //获取父节点编号
            int Ofathernodeid = Convert.ToInt16(mymodule.MODULE_FATHERID);
            //查询所有父节点的模块
            MODULE fathermodule = new MODULE();
            fathermodule.MODULEID = Ofathernodeid;
            fathermodule.GetModel(fathermodule.MODULEID);

            //查询结果中有重复取消在循环中进行判断，将重复的不执行
            if (fathermoduleid != fathermodule.MODULEID)
            { //将当前查询到的父节点的id负值给Ofathernodeid
                fathermoduleid = fathermodule.MODULEID;
                //实例化本父节点
                TreeNode FatherNode = new TreeNode(fathermodule.MODULE_NAME, fathermodule.MODULEID.ToString(), "", fathermodule.MODULE_URL, "_blank");
                
                this.Tree_left.Nodes.Add(FatherNode);
            }

        }
        #endregion 
        #region 子节点添加
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            MODULE mymodule = new MODULE();
            //设立查询的moduleid
            mymodule.MODULEID = Convert.ToInt16(ds.Tables[0].Rows[i].ItemArray[2]);
            //获取实例module
            mymodule.GetModel(mymodule.MODULEID);
            //实例化本子节点
            if (mymodule.MODULE_FATHERID != 0)
            {
                //建立子节点
                TreeNode Childnode = new TreeNode(mymodule.MODULE_NAME, mymodule.MODULEID.ToString().Trim(), "", mymodule.MODULE_URL, "_blank");
                //this.Tree_left.Nodes.Add(Childnode);
                //遍历所有treenode查询出需要的treenode
                foreach (TreeNode myfathernode in Tree_left.Nodes)
                {
                    MODULE mymodule1 = new MODULE();
                    mymodule1.MODULEID = Convert.ToInt16(myfathernode.Value);
                    mymodule1.GetModel(mymodule1.MODULEID);
                    if (Convert.ToInt16(mymodule1.MODULE_FATHERID) == 0 && mymodule.MODULE_FATHERID == mymodule1.MODULEID)
                    {
                        myfathernode.ChildNodes.Add(Childnode);
                    }
                }
            }
        }
        #endregion
    }
}
