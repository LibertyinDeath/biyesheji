<%@ Page Language="C#" AutoEventWireup="true" CodeFile="add_module.aspx.cs" Inherits="add_module" %>

<%@ Register Src="webcontrols/add_modulecontrol.ascx" TagName="add_modulecontrol"
    TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <uc1:add_modulecontrol ID="Add_modulecontrol1" runat="server" OnLoad="Add_modulecontrol1_Load" />
       
    </div>
    </form>
</body>
</html>
