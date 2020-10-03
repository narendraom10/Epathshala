<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SysConfigPage.aspx.cs" Inherits="SysConfigPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ePathshala</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="LblFieldGroup" runat="server" Text="Field Group"></asp:Label>
        <asp:DropDownList ID="ddlFieldGroup" runat="server" 
            AppendDataBoundItems="True" Width="15%" AutoPostBack="True" 
            onselectedindexchanged="DrpDwnLstFieldGroup_SelectedIndexChanged">
            <asp:ListItem Value="0" Text="-- SELECT --"></asp:ListItem>
        </asp:DropDownList>
    </div>
    </form>
</body>
</html>
