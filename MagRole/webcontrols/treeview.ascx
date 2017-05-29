<%@ Control Language="C#" AutoEventWireup="true" CodeFile="treeview.ascx.cs" Inherits="webcontrols_treeview" %>
<asp:TreeView ID="Tree_left" runat="server" ImageSet="Contacts" NodeIndent="10">
    <ParentNodeStyle Font-Bold="True" ForeColor="#5555DD" />
    <HoverNodeStyle Font-Underline="False" />
    <SelectedNodeStyle Font-Underline="True" HorizontalPadding="0px" VerticalPadding="0px" />
    <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" HorizontalPadding="5px"
        NodeSpacing="0px" VerticalPadding="0px" />
</asp:TreeView>
<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
