<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OpenPdf.aspx.cs" Inherits="Dashboard_OpenPdf" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ePathshala</title>
<%--    <script type="text/javascript">
        function windowOpen() {
            myWindow = window.open('../PDFViewer/web/viewer.html?lank=../../1/Testing/EduResource/AcceptanceForm19.pdf', '_blank', 'width=200,height=100, scrollbars=no,resizable=no')
            myWindow.focus()
            return false;
        }
</script>--%>
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
    <div>
       <%-- <asp:Button ID="Button1" runat="server" Text="Button" OnClientClick="return windowOpen();" />--%>
    
    </div>
    </form>
</body>
</html>
