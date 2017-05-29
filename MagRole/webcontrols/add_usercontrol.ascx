<%@ Control Language="C#" AutoEventWireup="true" CodeFile="add_usercontrol.ascx.cs" Inherits="webcontrols_add_usercontrol" %>
<table>
    <tr>
        <td style="width: 100px; height: 21px">
            username;</td>
        <td style="width: 100px; height: 21px">
            <asp:TextBox ID="tb_username" runat="server"></asp:TextBox></td>
        <td style="width: 100px; height: 21px">
        </td>
    </tr>
    <tr>
        <td style="width: 100px">
            password:</td>
        <td style="width: 100px">
            <asp:TextBox ID="tb_password" runat="server" TextMode="Password"></asp:TextBox></td>
        <td style="width: 100px">
        </td>
    </tr>
    <tr>
        <td style="width: 100px">
            password:</td>
        <td style="width: 100px">
            <asp:TextBox ID="tb_password2" runat="server" TextMode="Password"></asp:TextBox></td>
        <td style="width: 100px">
        </td>
    </tr>
    <tr>
        <td style="width: 100px">
            role:</td>
        <td style="width: 100px">
            <asp:DropDownList ID="droplist_role" runat="server" DataSourceID="SqlDataSource1"
                DataTextField="ROLENAME" DataValueField="ROLEID">
            </asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Mag_Role_ConnectionString %>"
                SelectCommand="SELECT [ROLENAME], [ROLEID] FROM [ROLE]"></asp:SqlDataSource>
        </td>
        <td style="width: 100px">
        </td>
    </tr>
    <tr>
        <td style="width: 100px">
        </td>
        <td style="width: 100px">
            <asp:Button ID="bt_adduser" runat="server" Text="添加用户" OnClick="bt_adduser_Click" /></td>
        <td style="width: 100px">
        </td>
    </tr>
</table>
