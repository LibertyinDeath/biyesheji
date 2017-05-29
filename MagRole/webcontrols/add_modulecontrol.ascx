<%@ Control Language="C#" AutoEventWireup="true" CodeFile="add_modulecontrol.ascx.cs" Inherits="webcontrols_add_modulecontrol" %>
<table>
    <tr>
        <td style="height: 21px">
            Module_Name:</td>
        <td style="height: 21px">
            <asp:TextBox ID="tb_modulename" runat="server"></asp:TextBox></td>
        <td style="width: 48px; height: 21px">
        </td>
    </tr>
    <tr>
        <td style="height: 26px">
            Module_Description:</td>
        <td style="height: 26px">
            <asp:TextBox ID="tb_moduledescription" runat="server"></asp:TextBox></td>
        <td style="width: 48px; height: 26px">
        </td>
    </tr>
    <tr>
        <td style="height: 26px;">
            Module_Url:</td>
        <td style="height: 26px;">
            <asp:TextBox ID="tb_moduleurl" runat="server"></asp:TextBox></td>
        <td style="width: 48px; height: 26px;">
        </td>
    </tr>
    <tr>
        <td>
            是否为根节点：</td>
        <td>
            <asp:RadioButton ID="rab_genyes" runat="server" Text="是" AutoPostBack="True" Checked="True" GroupName="genrab" OnCheckedChanged="rab_genyes_CheckedChanged" />
            <asp:RadioButton ID="rab_genno" runat="server" Text="否" AutoPostBack="True" GroupName="genrab" OnCheckedChanged="rab_genno_CheckedChanged" /><br />
            &nbsp;</td>
        <td style="width: 48px;">
        </td>
    </tr>
    <tr>
        <td>
        </td>
        <td>
            <asp:Panel ID="panel_genno" runat="server" Height="50px" Width="125px" style="width: 100%" Visible="False">
                根节点是:<asp:DropDownList ID="drpl_gen" runat="server" DataSourceID="SqlDataSource1"
                    DataTextField="MODULE_NAME" DataValueField="MODULEID">
                </asp:DropDownList><asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Mag_Role_ConnectionString %>"
                    SelectCommand="SELECT [MODULEID], [MODULE_NAME] FROM [MODULE] WHERE ([MODULE_FATHERID] = @MODULE_FATHERID)">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="0" Name="MODULE_FATHERID" Type="Int32" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </asp:Panel>
        </td>
        <td style="width: 48px">
        </td>
    </tr>
    <tr>
        <td>
        </td>
        <td>
            <asp:Button ID="bt_moduleadd" runat="server" OnClick="bt_moduleadd_Click" Text="添加模块" /></td>
        <td style="width: 48px">
        </td>
    </tr>
    <tr>
        <td>
        </td>
        <td>
        </td>
        <td style="width: 48px">
        </td>
    </tr>
</table>
