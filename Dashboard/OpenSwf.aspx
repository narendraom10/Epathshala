<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OpenSwf.aspx.cs" Inherits="Dashboard_OpenSwf" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ePathshala</title>
    <script language="javascript" type="text/javascript">
        function onbodyLoad() 
        {
            window.location.hash = 'category-name';
        }
    </script>
    <%--<style type="text/css">
        .loginBody
        {
            width: 100%;
            height: 100%;
            margin: 0;
            padding: 0;
            background: black; /* for non-css3 browsers */
            filter: progid:DXImageTransform.Microsoft.gradient(startColorstr='black', endColorstr='black'); /* for IE */
            background: -webkit-gradient(linear, left top, left bottom, from(black), to(black)); /* for webkit browsers */
            background: -moz-linear-gradient(top,  black, black); /* for firefox 3.6+ */
        }
    </style>--%>
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
<%--<body class="loginBody">--%>
<body onload="Javascript:onbodyLoad();">
    <form id="form1" runat="server">
    <%--<table id="tblHelp" runat="server" cellpadding="0" cellspacing="0" border="0" style="vertical-align: top;
        height: 100%; width: 100%">
        <tr>
            <td align="center" valign="top" >
                <asp:Literal ID="lterResource" runat="server"></asp:Literal>
             </td>
        </tr>
    </table>--%>
    </form>
</body>
</html>
