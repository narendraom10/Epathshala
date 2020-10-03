<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SineupPayment.aspx.cs" Inherits="Dashboard_SineupPayment" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ePathshala</title>
    <style type="text/css">
        .BodyTable
        {
            margin: 20px 40px 20px 500px;
        }
        
        .BodyHead
        {
            background-position: left top;
            padding: 3px;
            margin: 15px 15px 15px 100px;
            height: 80px;
            background-image: url('../App_Themes/Images/Epathshalalogo.png');
            background-repeat: no-repeat;
            max-height: 80px;
        }
        .Margin500px
        {
            margin: 5px 5px 15px 500px;
        }
        
        .Margin450px
        {
            margin: 40px 40px 40px 450px;
        }
        
        .footerMargin
        {
            margin: 10px 10px 10px 10px;
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
    <div style="margin: 25px">
        <span style="font-weight: bold; font-size: 14px">
            <asp:Label ID="lblStuInformation" runat="server" 
            Text=" Your registration done, for complete registration process pay by below payment option and that require(Please note down for payment) " 
            meta:resourcekey="lblStuInformationResource1"></asp:Label>
            <br />
            <br />
            <%--<asp:RadioButton ID="rbtnIcollect" runat="server" Text="  I Collect SBI Pay" GroupName="A"
                OnCheckedChanged="rbtnIcollect_CheckedChanged" AutoPostBack="True" />--%>
            <a href="PartySignUpOnlineOffline.aspx" target="_blank">I Collect SBI Pay </a>
            <br />
            <br />
            <%-- <asp:RadioButton ID="rbtnPayPalPayment" runat="server" Text="  Online Payment" GroupName="A"
                OnCheckedChanged="rbtnPayPalPayment_CheckedChanged" AutoPostBack="True" />--%>
            <a href="Payment.html" target="_blank">Online Payment </a></span>
    </div>
    </form>
</body>
</html>
