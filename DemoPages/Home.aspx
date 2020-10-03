<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="DemoPages_Home" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Src="../UserControl/StudentRegistrationControl.ascx" TagName="WebUserControl"
    TagPrefix="uc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>ePathshala</title>
    <style type="text/css">
        #NavigationBar
        {
            position: relative;
            background-color: #EFEFEF;
            display: inline-block;
            width: 100%;
            min-height: 25px;
            margin-bottom: 5px;
            vertical-align: middle;
        }
        #dvfooter
        {
            position: relative;
            background-color: #EFEFEF;
            display: inline-block;
            width: 100%;
            min-height: 47px;
            margin-bottom: 0px;
            vertical-align: middle;
            margin-top: 605px;
            position: absolute;
            bottom: 0;
        }
        #bgregistration
        {
            background-image: url(../App_Themes/Images/Education7.jpg );
            background-size: 100% 100%;
            background-position: 0px 40px;
            width: 100%;
            height: 99%;
            color: black;
            background-repeat: no-repeat;
            position: absolute;
            display: inline-block;
        }
        
        #signup1
        {
            width: 360px;
            float: right;
            margin: 40px 100px 50px 0px;
            background-color: #FFF;
            box-shadow: 0px 0px 4px #444;
            border-radius: 15px;
            color: #000;
            padding: 2% 1%;
            font-size: 1.3em;
            padding-right: 100px;
            position: relative;
        } 
       
        
        #signup2
        {
            width: 450px;
            float: left;
            margin: 40px 0px 0px 100px;
            padding: 2% 1%;
            padding-right: 100px;
            color: #FFF;
            font-size: 38px;
            line-height: 44px;
            margin-bottom: 30px;
            text-shadow: none;
            font-weight: 700;
        }
        .TextboxFirstName
        {
            float: left;
            min-width: 95px;
            display: inline-block;
            vertical-align: middle;
            line-height: 35px;
            position: relative;
            font-family: Roboto-Light;
            box-shadow: 0px 0px 4px #444;
            border-radius: 10px;
        }
        
        .DropdownBMS
        {
            width: 135px;
            clear: both;
            border: 5px;
            padding-left: 3px;
            border: none;
            height: 22px;
            box-shadow: 0px 0px 4px #444;
            border-radius: 20px;
            border: 1px solid #959595;
            height: 24px;
        }
        
        
        
        
        
        #signupform .Label, #signupform .Control, #signupform .Control input[type="text"], #signupform .Control input[type="password"]
        {
            float: left;
            min-width: 95px;
            display: inline-block;
            vertical-align: middle;
            line-height: 35px;
            position: relative;
            font-family: Roboto-Light;
            padding-left: 4px;
        }
        
        
        #signupform .Label
        {
            text-align: right;
        }
        
        #signupform .LineBreaker
        {
            clear: both;
        }
        
        
        #signupform input[type="text"], #signupform input[type="password"]
        {
            border: none;
            height: 25px;
            width: 205px;
            font-weight: lighter;
            font-size: 0.9em;
            padding: 3px;
            float: left;
        }
        
        #signupform #txtBirthdate
        {
            border: none;
            height: 22px;
            max-width: 175px;
            font-weight: lighter;
            font-size: 0.9em;
            padding: 3px;
            float: left;
        }
        
        
        
        #signupform select
        {
            width: 210px;
            clear: both;
            border: none;
            box-shadow: 0px 0px 4px #444;
            border-radius: 20px;
            border: 1px solid #959595;
        }
        
        #signupform select option
        {
            padding-left: 3px;
            border: none;
            height: 25px;
        }
        
        #signupform .Control
        {
            display: inline-block;
            float: left;
        }
        
        
        #signupform .Control #txtBirthdate
        {
            display: inline-block;
            min-width: 175px;
        }
        
        .submit1
        {
            width: 100%;
            position: relative;
            border: none;
            font-size: 1.05em;
            margin: 10px 17px 0 5px;
            background-color: #55ACEE;
            padding: 6px 18px;
            color: #fff;
            font-weight: 300;
            border-radius: 2px;
            box-shadow: 0 1px 0.02em #d7f2ad;
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
    <div id="bgregistration">
        <div id="NavigationBar">
            <img id="Home" height="45px" style="float: left; padding-left: 10px;" alt="Epathshala Logo"
                src="../App_Themes/Responsive/images/Epathshala.png" />
            <%--<div id="Logo" style="float: left; display: inline-block; vertical-align: top; padding: 5px;
                padding-left: 15px; font-weight: bold;">--%>
            <div style=" height: 50px; width: 100%; background-color: #EFEFEF; 
                text-align: right;">
                <h2>
                    <span style="margin-right:110px;">Welcome to Epathshala</span>
                </h2>
            </div>
        <%--<div id="signup2">
                <span>Welcome to Epathshala</span>
            </div>--%>
        </div>
        <div id="signup1" style="padding-left: 50px;">
            <h4>
                <asp:Label ID="lblSignUP" runat="server" Text="Enter details for Demo Content"></asp:Label>
            </h4>
            <div id="signupform">
                <div>
                    <div class="Label">
                        <asp:Label ID="lblFirstName" runat="server" Text="Name:"></asp:Label>
                    </div>
                    <div class="Control">
                        <asp:TextBox ID="txtFirstName" runat="server" CssClass="TextboxFirstName"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="ReqFieldFirstName" runat="server" ErrorMessage="Please Insert FirstName"
                            ValidationGroup="a" ControlToValidate="txtFirstName">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revFirstName" runat="server" ErrorMessage="Only characters are allowed in FirstName"
                            ToolTip="Only numbers and characters are allowed in FirstName" Text="." ValidationGroup="a"
                            ValidationExpression="^[a-zA-Z ]+$" ControlToValidate="txtFirstName"></asp:RegularExpressionValidator>
                    </div>
                </div>
                <div>
                    <div class="Label">
                        <asp:Label ID="lblBMS" runat="server" Text="BMS:"></asp:Label>
                    </div>
                    <div>
                        <asp:DropDownList ID="ddlBMS" runat="server" CssClass="DropdownBMS" Width="210px"
                            AutoPostBack="true">
                            <asp:ListItem Value="0" Text="<SELECT>"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="ReqFieldBMSID" runat="server" InitialValue="0" ErrorMessage="Please Select BMS"
                            ValidationGroup="a" ControlToValidate="ddlBMS">*</asp:RequiredFieldValidator>
                    </div>
                </div>
                <div>
                    <div class="Control" align="center">
                        <asp:Button ID="btnSubmit1" runat="server" ValidationGroup="a" Text="View Demo" CssClass="submit1"
                            EnableTheming="false" OnClick="btnSubmit1_Click" />
                        <asp:ValidationSummary ID="ValSumStudent" runat="server" ValidationGroup="a" ShowMessageBox="True"
                            ShowSummary="False" meta:resourcekey="ValSumStudentResource1" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div>
    </div>
    <%--  <div id="dvfooter">
        <div id="Div2" style="float: left; display: inline-block; vertical-align: top; padding: 5px;
            text-align: center; padding-left: 410px; font-weight: bold;">
            Copyright © 2015, All Rights Reserved. Arraycom (India) Ltd. - Epath Division
        </div>
    </div>--%>
    <div style="position: absolute; bottom: 0px; height: 30px; width: 100%; background-color: #EFEFEF;
        text-align: center;">
        Copyright © 2015, All Rights Reserved. Arraycom (India) Ltd. - Epath Division
    </div>
    </form>
</body>
</html>
