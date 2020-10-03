<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DemoEducationResource.aspx.cs"
    Inherits="DemoPages_DemoEducationResource" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ePathshala</title>
    <style type="text/css">
        label
        {
            display: inline-block;
            width: 5em;
        }
        #wrap
        {
            width: auto;
            position: relative;
        }
        
        .left, .right
        {
            float: left;
        }
        
        .right
        {
            float: right;
        }
    </style>
    <style type="text/css">
        .textlabelDemo
        {
            width: 85px;
            float: left;
            height: auto;
            clear: both;
            padding-top: 4px;
            white-space: nowrap;
        }
        .tblDashboard tr td
        {
            vertical-align: top;
            text-align: left;
            padding: 3px;
        }
        
        .tblDashboard .Header
        {
            color: #096B6B;
            text-align: center;
            padding: 5px;
            margin: 25px;
        }
        
        
        .tblDashboard .LeftPart
        {
            padding-right: 15px;
        }
        
        .Width300
        {
            min-width: 300px;
            max-width: 300px;
        }
        .Width700
        {
            min-width: 700px;
            max-width: 700px;
        }
        
        .Width1000px
        {
            min-width: 1000px;
            max-width: 1000px;
            max-height: 700px;
        }
        
        .MarginBottom15px
        {
            margin-bottom: 15px;
        }
        
        .RBPadding
        {
            padding: 15px;
            width: 100%;
        }
        
        
        .RBPadding input[type="radio"]
        {
            margin: 3px;
        }
    </style>
    
<script>
    (function (i, s, o, g, r, a, m) {
        i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {
            (i[r].q = i[r].q || []).push(arguments)
        }, i[r].l = 1 * new Date(); a = s.createElement(o),
  m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
    })(window, document, 'script', '//www.google-analytics.com/analytics.js', 'ga');

    ga('create', 'UA-69363607-1', 'auto');
    ga('send', 'pageview');

</script>

</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="header" style="z-index: 1;">
        <div id="headerwrap">
            <div id="logo" style="margin-left: 150px">
                <a href="#">&nbsp;<img src="../App_Themes/Responsive/web/logo.png" alt="Epathshala logo"
                    id="dvICICIEpath" runat="server" /></a>
            </div>
            <div class="contactMaster">
                <ul>
                    <li class="innerhead"></li>
                    <li class="innerhead">
                        <asp:Label CssClass="Welcome" runat="server" ID="lblWelcome" Style="font-size: 1.05em;
                            color: #2E3192; text-align: right; white-space: nowrap;"></asp:Label>
                    </li>
                    <li class="innerhead">
                        <asp:LinkButton runat="server" ID="lbtnSignOut" Text="Sign Out" CssClass="logoutButton"
                            OnClick="lbtnSignOut_Click"></asp:LinkButton>
                    </li>
                </ul>
            </div>
        </div>
    </div>
    <div style="display: inline-block; width: 100%; background-color: #2E3192; box-shadow: 0 4px 9px #4D4D4D;
        border-top: 2px solid #484ce2; position: relative; z-index: 2;">
        <div class="newmenuwrap" style="position: relative;">
            <ul id="qm3" class="qmmc11">
                <li id="liStudDashboard" runat="server" style="border-right: 1px solid #000000;"><a
                    href="#" target="_self">
                    <asp:Label ID="lblStudDashboard" runat="server" Text="Dashboard"></asp:Label>
                </a></li>
                <li id="liProfile" runat="server" style="border-right: 1px solid #000000;"><a href="#"
                    target="_self">
                    <asp:Label ID="lblProfile" runat="server" Text="Profile"></asp:Label>
                </a></li>
                <li id="liStudentPackage" runat="server" style="border-right: 1px solid #000000;"><a
                    href="#" target="_self">
                    <asp:Label ID="lblStudentPackage" runat="server" Text="Student Packages"></asp:Label>
                </a></li>
                <li id="liSelectPackage" runat="server" style="border-right: 1px solid #000000;"><a
                    href="#" target="_self">
                    <asp:Label ID="lblSelectPackage" runat="server" Text="Buy Package"></asp:Label>
                </a></li>
                <li id="li5" runat="server" style="border-right: 1px solid #000000;"><a href="#"
                    target="_self">
                    <asp:Label ID="Label12" runat="server" Text="Report"></asp:Label>
                </a></li>
                <li id="li4" runat="server"><a href="#" target="_self">
                    <asp:Label ID="Label11" runat="server" Text="Contact Us"></asp:Label>
                </a></li>
            </ul>
        </div>
    </div>
    <div>
        <asp:UpdatePanel ID="upVideo" runat="server" UpdateMode="Always">
            <ContentTemplate>
                <div id="dvfull" runat="server" style="width: 60%; text-align: center; margin: auto;">
                    <div id="dvMainVideo" runat="server" style="width: 80%; text-align: center; float: right;
                        margin-top: 25px;">
                    </div>
                    <br>
                    <div id="dvList" runat="server" style="width: 10%; text-align: center; float: left;
                        margin-top: 25px;">
                        <asp:GridView ID="grvList" runat="server" AutoGenerateColumns="false" OnRowCommand="grvList_RowCommand"
                            ShowHeader="false">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                    
                                        <asp:ImageButton ID="btnPlayVideo" runat="server" ImageUrl="../App_Themes/Images/View1.png"
                                            Width="50px" AlternateText="Update PNG File" CommandArgument='<%# Eval("ValueURL") %>'
                                            CommandName="ShowVideo" ToolTip='<%# Eval("DiaplayName") %>' />
                                        <div style="text-align: center;">
                                            <%# Eval("DiaplayName") %>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </ContentTemplate>
            <Triggers>
            </Triggers>
        </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
