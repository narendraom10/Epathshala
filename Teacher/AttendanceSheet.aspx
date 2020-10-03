<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AttendanceSheet.aspx.cs"
    Inherits="Teacher_AttenceSheet" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

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
        <table cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td align="center">
                    <asp:Button ID="btnFillAttence" runat="server" Text="Fill Attence" 
                        OnClick="btnFillAttence_Click" meta:resourcekey="btnFillAttenceResource1" />
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:GridView ID="gvAttence" runat="server" AutoGenerateColumns="False" 
                        DataKeyNames="StudentID,RollNo,FullName" meta:resourcekey="gvAttenceResource1">
                        <Columns>
                            <asp:TemplateField HeaderText="Fill" meta:resourcekey="TemplateFieldResource1">
                                <ItemTemplate>
                                    <table>
                                        <tr>
                                            <td align="center">
                                                <asp:CheckBox ID="chkAttence" runat="server" 
                                                    meta:resourcekey="chkAttenceResource1" />
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="RollNo" HeaderText="RollNo" 
                                meta:resourcekey="BoundFieldResource1" />
                            <asp:BoundField DataField="FullName" HeaderText="StudentName" 
                                meta:resourcekey="BoundFieldResource2" />
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <%--<tr>
             <td>
             <asp:DataList ID="DataListAttendance" runat="server" RepeatColumns="3" BackColor="White" BorderStyle="None"
                                    BorderWidth="0px" CellSpacing="0" RepeatDirection="Horizontal" Width="100%" Height="100%"
                                    HorizontalAlign="Center">
                                    <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                                    <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                                    <SelectedItemStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                                    <ItemTemplate>
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="LblStdId" runat="server" Text='<%#Eval("StudentID") %>' Visible="false"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:CheckBox ID="Chk" runat="server" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="Lbl" runat="server" Width="60px" Text='<%#Eval("FirstName")+" " +Eval("MiddleName")+" "+Eval("LastName") %>'></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="LblRollNo" runat="server" Width="20px" Text='<%#Eval("RollNo") %>'></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:DataList>
             </td>
            </tr>--%>
        </table>
    </div>
    </form>
</body>
</html>
