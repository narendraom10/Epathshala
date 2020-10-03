<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OpenFlv.aspx.cs" Inherits="Dashboard_OpenFlv"
    Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ePathshala</title>
    <style type="text/css">
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
    </style>
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
<body class="loginBody">
    <form id="form2" runat="server">
    <table id="tblHelp" runat="server" cellpadding="0" cellspacing="0" border="0" style="vertical-align: top;
        height: 100%; width: 100%; margin: auto;">
        <tr>
            <td align="center" valign="top">
                <asp:Literal ID="lterResource" runat="server" meta:resourcekey="lterResourceResource1"></asp:Literal>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
