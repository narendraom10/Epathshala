<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TeacherActivityFeedback.aspx.cs" Inherits="Teacher_TeacherActivityFeedback" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ePathshala</title>
    
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
 
            <table id="tblTeacherFeedbackDetails" runat="server" class="tblControls">
                <tr>
                    <td style="text-align: right;">
                        <asp:Label ID="lblFeedback" runat="server" Text="Feedback:" 
                            meta:resourcekey="lblFeedbackResource1"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtFeedback" runat="server" TextMode="MultiLine" Width="440px" 
                            meta:resourcekey="txtFeedbackResource1"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <table>
                            <tr>
                                <td>
                                    <asp:Button ID="btnOK" runat="server" Text="OK" CssClass="gobutton" 
                                        onclick="btnOK_Click" meta:resourcekey="btnOKResource1" />
                                </td>
                                <td>
                                    <%--<asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="gobutton" 
                                        onclick="btnCancel_Click" />--%>
                                        &nbsp;
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
       
    </div>
    </form>
</body>
</html>
