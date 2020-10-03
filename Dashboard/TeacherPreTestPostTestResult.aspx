<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TeacherPreTestPostTestResult.aspx.cs"
    Inherits="Dashboard_Default" Culture="auto" meta:resourcekey="PageResource2"
    EnableEventValidation="false" UICulture="auto" %>

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
<body style="background-image: url('../App_Themes/Responsive/web/bannerbg.png');">
    <form id="form1" runat="server">
    <table width="100%" style="padding: 50px">
        <tr>
            <td style="padding-top: 0;" align="center">
                <table width="80%" cellpadding="0" cellspacing="0">
                    <tr style="padding-left: 2px;">
                        <td>
                            <asp:Menu ID="menuTestType" runat="server" Orientation="Horizontal" OnMenuItemClick="menuTestType_MenuItemClick"
                                meta:resourcekey="menuTestTypeResource1">
                                <StaticMenuItemStyle CssClass="tab" />
                                <StaticSelectedStyle CssClass="tabSelected" />
                                <StaticHoverStyle CssClass="tabhover" />
                                <Items>
                                    <asp:MenuItem Text="Pre-Test" Value="0" Selected="true" meta:resourcekey="MenuItemResource1">
                                    </asp:MenuItem>
                                    <asp:MenuItem Text="Post-Test" Value="1" meta:resourcekey="MenuItemResource2"></asp:MenuItem>
                                </Items>
                            </asp:Menu>
                        </td>
                    </tr>
                    <tr height="30px" style="padding-bottom: 0px; margin: 0px;">
                        <td class="Header12 GridViewHeadercssTestAssessment RoundTop InnerTableStyle" align="center"
                            style="border-top-left-radius: 0em;">
                            <asp:Label ID="lblFirstTitle" runat="server" Text="Topicwise test result" meta:resourcekey="lblFirstTitleResource1"></asp:Label>
                        </td>
                    </tr>
                    <tr id="trError" runat="server" visible="false">
                        <td>
                            <asp:Label ID="lblErrorMsg" runat="server" Text="Test not conducted for this topic."
                                ForeColor="Red" Font-Bold="True" meta:resourcekey="lblErrorMsgResource1"></asp:Label>
                        </td>
                    </tr>
                    <tr style="padding-top: 0px; margin: 0px;">
                        <td style="border: thin solid #F1991A; border-top: thin solid #F1991A">
                            <table id="tblTestResult" runat="server" cellpadding="10" cellspacing="10" width="100%">
                                <tr>
                                    <td>
                                        <asp:Label ID="lblBMS" runat="server" Text="BMS:" meta:resourcekey="lblBMSResource1"></asp:Label>
                                    </td>
                                    <td colspan="3" style="text-align: left;">
                                        <asp:Label ID="lblBMSValue" runat="server" meta:resourcekey="lblBMSValueResource1"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblSubject" Text="Subject:" runat="server" meta:resourcekey="lblSubjectResource1" />
                                    </td>
                                    <td style="text-align: left;">
                                        <asp:Label ID="lblSubjectValue" runat="server" meta:resourcekey="lblSubjectValueResource1"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblDivision" runat="server" Text="Division:" meta:resourcekey="lblDivisionResource1"></asp:Label>
                                    </td>
                                    <td style="text-align: left;">
                                        <asp:Label ID="lblDivisionValue" runat="server" meta:resourcekey="lblDivisionValueResource1"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="labelChapter" runat="server" Text="Chapter:" meta:resourcekey="labelChapterResource1"></asp:Label>
                                    </td>
                                    <td style="text-align: left;">
                                        <asp:Label ID="lblChapterValue" runat="server" meta:resourcekey="lblChapterValueResource1"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="labelTopic" runat="server" Text="Topic:" meta:resourcekey="labelTopicResource1"></asp:Label>
                                    </td>
                                    <td style="text-align: left;">
                                        <asp:Label ID="lblTopicValue" runat="server" meta:resourcekey="lblTopicValueResource1"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4" style="text-align: left;">
                                        <asp:GridView ID="grTestResult" runat="server" DataKeyNames="StudentID,ExamID" OnPageIndexChanging="grTestResult_PageIndexChanging"
                                            OnRowCreated="grTestResult_RowCreated" AutoGenerateColumns="False" OnRowDataBound="grTestResult_RowDataBound"
                                            OnSorting="grTestResult_Sorting" OnSelectedIndexChanged="grTestResult_SelectedIndexChanged"
                                            meta:resourcekey="grTestResultResource1" SkinID="NoEmptyMsg">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Sr. No" meta:resourcekey="TemplateFieldResource1"
                                                    SortExpression="Sr. No">
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex +1 %></ItemTemplate>
                                                    <ItemStyle Width="10px" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="StudentName" HeaderText="Student Name" SortExpression="StudentName"
                                                    meta:resourcekey="BoundFieldResource1" />
                                                <asp:BoundField DataField="ExamDate" HeaderText="Exam Date" SortExpression="ExamDate"
                                                    DataFormatString="{0: dd-MMM-yyyy hh:mm:tt}" meta:resourcekey="BoundFieldResource2" />
                                                <asp:BoundField DataField="Total" HeaderText="Total Question" SortExpression="Total"
                                                    meta:resourcekey="BoundFieldResource7" />
                                                <asp:BoundField DataField="True" HeaderText="True" SortExpression="True" meta:resourcekey="BoundFieldResource3" />
                                                <asp:BoundField DataField="False" HeaderText="False" SortExpression="False" meta:resourcekey="BoundFieldResource4" />
                                                <asp:BoundField DataField="Perc" HeaderText="Percentage(%)" SortExpression="Perc"
                                                    meta:resourcekey="BoundFieldResource5" />
                                                <asp:BoundField DataField="Status1" HeaderText="Present/Absent" SortExpression="Status"
                                                    meta:resourcekey="BoundFieldResource6" />
                                            </Columns>
                                            <PagerTemplate>
                                                <asp:ImageButton Text="First" CommandName="Page" CommandArgument="First" runat="server"
                                                    ImageUrl="~/App_Themes/Images/first.png" ID="ibtnFirst" ToolTip="Move First Page"
                                                    meta:resourcekey="ibtnFirstResource1" />
                                                <asp:ImageButton Text="Previous" CommandName="Page" CommandArgument="Prev" runat="server"
                                                    ImageUrl="~/App_Themes/Images/previous.png" ID="ibtnPrevious" ToolTip="Move Previous Page"
                                                    meta:resourcekey="ibtnPreviousResource1" />
                                                <asp:Label ID="lblPage" runat="server" Text="Page" ForeColor="Black" meta:resourcekey="lblPageResource1"></asp:Label>
                                                <asp:DropDownList ID="ddlPageSelector" OnSelectedIndexChanged="DdlPageSelector_SelectedIndexChanged"
                                                    runat="server" AutoPostBack="True" SkinID="DdlWidth50" meta:resourcekey="ddlPageSelectorResource1">
                                                </asp:DropDownList>
                                                <asp:ImageButton Text="Next" CommandName="Page" CommandArgument="Next" runat="server"
                                                    ImageUrl="~/App_Themes/Images/NEXT.png" ID="ibtnNext" ToolTip="Move Next Page"
                                                    meta:resourcekey="ibtnNextResource1" />
                                                <asp:ImageButton Text="Last" CommandName="Page" CommandArgument="Last" runat="server"
                                                    ImageUrl="~/App_Themes/Images/last.png" ID="ibtnLast" ToolTip="Move Last Page"
                                                    meta:resourcekey="ibtnLastResource1" />
                                            </PagerTemplate>
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:Button ID="btnClose" runat="server" Text="Back" OnClick="btnClose_Click1" meta:resourcekey="btnCloseResource1" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
