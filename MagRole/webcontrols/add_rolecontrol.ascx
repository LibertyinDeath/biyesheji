<%@ Control Language="C#" AutoEventWireup="true" CodeFile="add_rolecontrol.ascx.cs" Inherits="webcontrols_add_rolecontrol" %>
<table>
    <tr>
        <td style="width: 100px; height: 21px">
            Rolename:</td>
        <td style="height: 21px">
            <asp:TextBox ID="tb_rolename" runat="server"></asp:TextBox></td>
        <td style="width: 100px; height: 21px">
        </td>
    </tr>
    <tr>
        <td style="width: 100px; height: 21px">
            RoleDiscritption:</td>
        <td style="height: 21px">
            <asp:TextBox ID="tb_rolediscription" runat="server"></asp:TextBox></td>
        <td style="width: 100px; height: 21px">
        </td>
    </tr>
    <tr>
        <td style="width: 100px; height: 21px">
        </td>
        <td style="height: 21px">
        </td>
        <td style="width: 100px; height: 21px">
        </td>
    </tr>
    <tr>
        <td style="width: 100px; height: 21px; vertical-align: top; text-align: left;">
            管理模块：</td>
        <td style="height: 21px; vertical-align: top; text-align: left;">
            根结点：&nbsp;<br />
            <asp:ListBox ID="listb_gen" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource_gen"
                DataTextField="MODULE_NAME" DataValueField="MODULEID"></asp:ListBox>
            <asp:SqlDataSource ID="SqlDataSource_gen" runat="server" ConnectionString="<%$ ConnectionStrings:Mag_Role_ConnectionString %>"
                SelectCommand="SELECT [MODULEID], [MODULE_NAME] FROM [MODULE] WHERE ([MODULE_FATHERID] = @MODULE_FATHERID)">
                <SelectParameters>
                    <asp:Parameter DefaultValue="0" Name="MODULE_FATHERID" Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>
        </td>
        <td style="width: 100px; height: 21px; vertical-align: top; text-align: left;">
            子结点<br />
            <asp:CheckBoxList ID="checkbl_zi" runat="server" DataSourceID="SqlDataSource_zi"
                DataTextField="MODULE_NAME" DataValueField="MODULEID">
            </asp:CheckBoxList>
            <asp:SqlDataSource ID="SqlDataSource_zi" runat="server" ConnectionString="<%$ ConnectionStrings:Mag_Role_ConnectionString %>"
                SelectCommand="SELECT [MODULEID], [MODULE_NAME] FROM [MODULE] WHERE ([MODULE_FATHERID] = @MODULE_FATHERID)">
                <SelectParameters>
                    <asp:ControlParameter ControlID="listb_gen" Name="MODULE_FATHERID" PropertyName="SelectedValue"
                        Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>
            <asp:Button ID="bt_addquanxian" runat="server" Text="添加权限模块" OnClick="bt_addquanxian_Click" /></td>
    </tr>
    <tr>
        <td style="width: 100px; height: 21px; vertical-align: top; text-align: left;">
            当前您选择的权限：</td>
        <td colspan="2" style="vertical-align: top; height: 21px; text-align: left">
            <asp:CheckBoxList ID="cbl_quanxian" runat="server" Width="155px">
            </asp:CheckBoxList>&nbsp;<asp:Button ID="bt_moveaway" runat="server" OnClick="bt_moveaway_Click"
                Text="移除" /></td>
    </tr>
    <tr>
        <td style="width: 100px">
        </td>
        <td>
            <asp:Button ID="btRoleAdd" runat="server" Text="添加权限" OnClick="btRoleAdd_Click" /></td>
        <td style="width: 100px">
        </td>
    </tr>
</table>
