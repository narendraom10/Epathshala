<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Print_PDF.aspx.cs" Inherits="Exam_Print_PDF"
    EnableEventValidation="false" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

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
    <table width="30%">
        <tr>
            <td style="text-align: right;">
                <asp:Button ID="BtnPDF" Text="Export to PDF" runat="server" CssClass="gobutton" 
                    OnClick="BtnPDF_Click" meta:resourcekey="BtnPDFResource1" />
            </td>
            <td style="text-align: left;">
                <asp:Button ID="Button1" Text="Export to Excel" runat="server" 
                    CssClass="gobutton" onclick="Button1_Click" 
                    meta:resourcekey="Button1Resource1"/>
            </td>
            <td style="text-align: left;">
                <asp:Button ID="BtnPrint" Text="Take a Print" runat="server" 
                    CssClass="gobutton" OnClientClick="javascript:window.print()" 
                    meta:resourcekey="BtnPrintResource1" />
            </td>
              
            <td colspan="2">
                &nbsp;
            </td>
        </tr>
    </table>
    <div id="ContentDiv" runat="server" style="overflow: auto">
        <table width="80%">
            <tr>
                <td style="text-align: right;">
                    <asp:Label ID="lblExam" runat="server" Text="Exam:" 
                        meta:resourcekey="lblExamResource1"></asp:Label>
                </td>
                <td style="text-align: left;">
                    <asp:Label ID="lblExamName" runat="server" 
                        meta:resourcekey="lblExamNameResource1"></asp:Label>
                </td>
                <td colspan="2">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right;">
                    <asp:Label ID="LblChap" runat="server" Text="Chapter:" 
                        meta:resourcekey="LblChapResource1"></asp:Label>
                </td>
                <td style="text-align: left;">
                    <asp:Label ID="LblChapName" runat="server" 
                        meta:resourcekey="LblChapNameResource1"></asp:Label>
                </td>
                <td style="text-align: right;">
                    <asp:Label ID="LblTopic" runat="server" Text="Topic:" 
                        meta:resourcekey="LblTopicResource1"></asp:Label>
                </td>
                <td style="text-align: left;">
                    <asp:Label ID="LblTopicName" runat="server" 
                        meta:resourcekey="LblTopicNameResource1"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="text-align: right;">
                    <asp:Label ID="lblTotQue" runat="server" Text="Total Questions:" 
                        meta:resourcekey="lblTotQueResource1"></asp:Label>
                </td>
                <td style="text-align: left;">
                    <asp:Label ID="lblTotQue1" runat="server" 
                        meta:resourcekey="lblTotQue1Resource1"></asp:Label>
                </td>
                <td style="text-align: right;">
                    <asp:Label ID="LblTotMarks" runat="server" Text="Total Marks:" 
                        meta:resourcekey="LblTotMarksResource1"></asp:Label>
                </td>
                <td style="text-align: left;">
                    <asp:Label ID="LblTotMarks1" runat="server" 
                        meta:resourcekey="LblTotMarks1Resource1"></asp:Label>
                </td>
            </tr>
        </table>
        <br />
        <div style="width: 100%; height: 70%; overflow: auto">
        <asp:GridView ID="GridStudentList" DataKeyNames="StudentID,RollNo" runat="server"
            Visible="False" SkinID="WithoutPageSize" AutoGenerateColumns="False" 
                Width="80%" meta:resourcekey="GridStudentListResource1" >
            <Columns>
                <asp:BoundField DataField="RollNo" HeaderText="Roll No" 
                    meta:resourcekey="BoundFieldResource1" />
                <asp:BoundField DataField="StudentName" HeaderText=" Student Name" 
                    meta:resourcekey="BoundFieldResource2" />
                <asp:BoundField DataField="Right" HeaderText="Right Answers" 
                    meta:resourcekey="BoundFieldResource3" />
                <asp:BoundField DataField="Worng" HeaderText=" Worng Answers" 
                    meta:resourcekey="BoundFieldResource4" />
            </Columns>
        </asp:GridView>
        <asp:GridView ID="GridStudentListReport" runat="server" SkinID="GridforReport" 
                Visible="False" meta:resourcekey="GridStudentListReportResource1" >
        </asp:GridView>
        </div>
    </div>
    </form>
</body>
</html>
