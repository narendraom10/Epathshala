<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StudentRegistrationForm.aspx.cs"
    Inherits="DemoPages_StudentRegistrationForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Src="~/UserControl/StudentRegistration.ascx" TagName="RegistrationControl"
    TagPrefix="uc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>ePathshala</title>
    <%--<style type="text/css">
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
            margin-top: 585px;
        }
        #bgregistration
        {
            background-image: url(../App_Themes/Images/Education7.jpg );
            width: 100%;
            height: 99%;
            color: black;
            background-repeat: no-repeat;
            position: absolute;
            display: inline-block;
            background-position: left;
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
            height: 22px;
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
    </style>--%>
    <style type="text/css">
        #banner
        {
            background-image: url(../App_Themes/Images/Education7.jpg ) !important;
            background-size: 100% 100%;
            color: black !important;
            background-repeat: no-repeat !important;
            position: absolute !important;
            display: inline-block !important; /* background-position: left !important; */
            background-position: 0px 0px;
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
    <div>
        <uc1:RegistrationControl ID="UCRegistrationControl" runat="server" />
    </div>
    <div style="position: absolute; bottom: 0px; height: 20px; width: 100%; background-color: #333; color:White; text-align:center;">
        <p >
            Copyright © 2015, All Rights Reserved. <a href="#"  style="background-color: #333; color:White;" >Arraycom (India)
                Ltd. - Epath Division</a>
        </p>
    </div>
    </form>
</body>
</html>
