<%@ Page Language="C#" AutoEventWireup="true" CodeFile="add_role.aspx.cs" Inherits="add_role" %>

<%@ Register Src="webcontrols/add_rolecontrol.ascx" TagName="add_rolecontrol" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <uc1:add_rolecontrol ID="Add_rolecontrol1" runat="server" />
    
    </div>
    </form>
</body>
</html>
