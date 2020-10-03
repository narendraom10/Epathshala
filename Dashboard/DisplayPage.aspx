<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DisplayPage.aspx.cs" Inherits="Dashboard_DisplayPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ePathshala</title>
    
<script type="text/javascript">
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
    <div align="center" style="vertical-align: middle; margin-top: 110px; margin-left: 170px;
        width: 70%">
        <table style="border-width: 1px; height: 167px; width: 70%; border-collapse: collapse;
            border: 1px solid black;">
            <tr>
                <td style="background-color: #000099; width: 100%; height: 40px;" colspan="2">
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td align="left" style="width: 20%; padding-left: 10px; padding-bottom: 30px; padding-top: 20px;">
                    <img src="../App_Themes/Images/Epathshalalogo.png" alt="Epathshala Logo" />
                </td>
                <td align="left" style="width: 80%; padding-left: 50px; padding-bottom: 30px; padding-top: 20px;">
                    <h1>
                        <asp:Label ID="lblthankyou" runat="server" Text="Thank You."></asp:Label></h1>
                    <br />
                    <h3>
                        <asp:Label runat="server" ID="lblmessage" Text="Your payment is successful"></asp:Label>
                        <br />
                        <asp:Label ID="Label1" runat="server" Text="Transaction ID is TXN9"></asp:Label>
                    </h3>
                </td>
            </tr>
            <tr align="center">
                <td colspan="2" style="background-color: #000099; width: 100%; height: 5px;">
                    <h6 style="color: #FFFFFF">
                        Copy right to Arraycom(India) Ltd.</h6>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
