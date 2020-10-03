<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StudentPreTestPostTestResult.aspx.cs"
    Inherits="Dashboard_Default" Culture="auto" meta:resourcekey="PageResource2"
    UICulture="auto" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ePathshala</title>
    <style type="text/css">
        #tblTestResult
        {
            height: 1318px;
        }
    </style>
    <link href='http://fonts.googleapis.com/css?family=Roboto:400,300,500,700' rel='stylesheet'
        type='text/css'>
        
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
    <table width="100%">
        <tr>
            <td align="center" valign="middle" style="padding-top: 0;">
                <table cellpadding="0" cellspacing="0">
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
                            <asp:Label ID="lblTitle" runat="server" Text="Student Test Result" meta:resourcekey="lblTitleResource1"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="border: thin solid #F1991A;" width="100%" align="center">
                            <table>
                                <tr id="trError" runat="server" visible="false">
                                    <td>
                                        <asp:Label ID="lblErrorMsg" runat="server" Text="Test not conducted for this topic."
                                            ForeColor="Red" Font-Bold="True" meta:resourcekey="lblErrorMsgResource1"></asp:Label>
                                    </td>
                                </tr>
                                <tr id="tblTestResult" runat="server">
                                    <td>
                                        <table cellpadding="10" cellspacing="10" width="100%">
                                            <tr>
                                                <td colspan="2">
                                                    <asp:Label ID="lblBMS" runat="server" Text="BMS:" meta:resourcekey="lblBMSResource1"></asp:Label>
                                                    &nbsp;&nbsp;
                                                    <asp:Label ID="lblBMSValue" runat="server" meta:resourcekey="lblBMSValueResource1"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblSubject" Text="Subject:" runat="server" meta:resourcekey="lblSubjectResource1" />
                                                    &nbsp;&nbsp;
                                                    <asp:Label ID="lblSubjectValue" runat="server" meta:resourcekey="lblSubjectValueResource1"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="labelChapter" runat="server" Text="Chapter:" meta:resourcekey="labelChapterResource1"></asp:Label>
                                                    &nbsp;&nbsp;
                                                    <asp:Label ID="lblChapterValue" runat="server" meta:resourcekey="lblChapterValueResource1"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="labelTopic" runat="server" Text="Topic:" meta:resourcekey="labelTopicResource1"></asp:Label>
                                                    &nbsp;&nbsp;
                                                    <asp:Label ID="lblTopicValue" runat="server" meta:resourcekey="lblTopicValueResource1"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblAverage" runat="server" Text="Performance In (%):" meta:resourcekey="lblAverageResource1"></asp:Label>&nbsp;&nbsp;
                                                    <asp:Label ID="lblAverageValue" runat="server" meta:resourcekey="lblAverageValueResource1"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr align="right">
                                                <td colspan="2">
                                                    <asp:Label ID="lblRightAnsColor" runat="server" BackColor="Green" Width="20px" Height="10px"></asp:Label>
                                                    <asp:Label ID="lblRightAns" runat="server" Text="Right answer given by student" meta:resourcekey="lblRightAnsResource1"></asp:Label>
                                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:Label ID="lblGiveAnsColor" runat="server" BackColor="Red" Width="20px" Height="10px"></asp:Label>
                                                    <asp:Label ID="lblGivenAns" runat="server" Text="Wrong answer given by student" meta:resourcekey="lblGivenAnsResource1"></asp:Label>
                                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:Label ID="lblRightSolColor" runat="server" BackColor="Yellow" Width="20px" Height="10px"></asp:Label>
                                                    <asp:Label ID="lblRightSol" runat="server" Text="Right answer given by system" meta:resourcekey="lblRightSolResource1"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" class="InnerTableStyle">
                                                    <asp:GridView ID="gvAnalysis" runat="server" OnRowDataBound="gvAnalysis_RowDataBound"
                                                        OnPageIndexChanging="gvAnalysis_PageIndexChanging" OnRowCreated="gvAnalysis_RowCreated"
                                                        OnSorting="gvAnalysis_Sorting" SkinID="TestAssessment" meta:resourcekey="gvAnalysisResource1"
                                                        AutoGenerateColumns="False">
                                                        <Columns>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" meta:resourcekey="TemplateFieldResource1">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="Label4" Text="Assessment" runat="server" Font-Bold="True" meta:resourcekey="Label4Resource1"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <table width="100%" style="border: solid 1px #4CBCBB;">
                                                                        <tr class="DatalistHeader">
                                                                            <td align="right" valign="top" style="border-bottom: solid 1px #4CBCBB; border-top: none;
                                                                                border-right: none; border-left: none" width="15%">
                                                                                <asp:Label ID="lblQ" runat="server" Text="Ques" ForeColor="#4CBCBB" Font-Bold="True"
                                                                                    meta:resourcekey="lblQResource1"></asp:Label>
                                                                                <span style="color: #4CBCBB; font-weight: bold">
                                                                                    <asp:Label ID="lblNo" runat="server" ForeColor="#4CBCBB" Font-Bold="True" Text='<%# Container.DataItemIndex +1 %>'
                                                                                        meta:resourcekey="lblNoResource1"></asp:Label>: </span>
                                                                            </td>
                                                                            <td align="left" colspan="4" style="border-bottom: solid 1px #4CBCBB; border-top: none;
                                                                                border-right: none; border-left: none" width="85%">
                                                                                <asp:Literal ID="ltQuestion" runat="server" Text='<%# Eval("Question") %>'></asp:Literal>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="right" valign="top" style="border: none;">
                                                                                <asp:Label ID="lblCorrectAns" runat="server" ForeColor="#4CBCBB" Text="Options:"
                                                                                    Font-Bold="True" meta:resourcekey="lblCorrectAnsResource1"></asp:Label>
                                                                            </td>
                                                                            <td align="left" style="border: none;">
                                                                                <table cellspacing="10px" cellpadding="10px">
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:Literal ID="Option1" runat="server" Text='A' meta:resourcekey="Option1Resource1"></asp:Literal>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:Literal ID="Option2" runat="server" Text='B' meta:resourcekey="Option2Resource1"></asp:Literal>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:Literal ID="Option3" runat="server" Text='C' meta:resourcekey="Option3Resource1"></asp:Literal>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:Literal ID="Option4" runat="server" Text='D' meta:resourcekey="Option4Resource1"></asp:Literal>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                            <td align="right" style="border: none;">
                                                                            </td>
                                                                            <td align="left" style="border: none;">
                                                                                <asp:Label ID="lblSrNo" runat="server" meta:resourcekey="lblSrNoResource1"></asp:Label>
                                                                            </td>
                                                                            <td rowspan="3" valign="middle" style="padding-right: 10px; border: none" align="right">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="right" style="border: none;">
                                                                                <asp:Label ID="lblResu" runat="server" ForeColor="#4CBCBB" Text="Result:" Font-Bold="True"
                                                                                    meta:resourcekey="lblResuResource1"></asp:Label>
                                                                            </td>
                                                                            <td align="left" style="border: none;">
                                                                                <asp:Label ID="lblResult" runat="server" Text='<%# Eval("Result") %>' meta:resourcekey="lblResultResource2"></asp:Label>
                                                                            </td>
                                                                            <td align="right" style="border: none;">
                                                                            </td>
                                                                            <td align="left" style="border: none;">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="right" valign="top" style="border: none;">
                                                                                <asp:Label ID="lblSolutionTitle" runat="server" ForeColor="#4CBCBB" Text="Solution:"
                                                                                    Font-Bold="True" meta:resourcekey="lblSolutionTitleResource1"></asp:Label>
                                                                            </td>
                                                                            <td align="left" style="border: none;">
                                                                                <asp:Literal ID="lblSolution" runat="server" Text='<%# Eval("Solution") %>'></asp:Literal>
                                                                            </td>
                                                                            <td align="right" style="border: none;">
                                                                                <asp:Literal ID="ltAns" runat="server" meta:resourcekey="ltAnsResource1"></asp:Literal>
                                                                            </td>
                                                                            <td align="left" style="border: none;">
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <PagerTemplate>
                                                            <asp:ImageButton Text="First" CommandName="Page" CommandArgument="First" runat="server"
                                                                ImageUrl="~/App_Themes/Images/first.png" ID="ibtnFirst" ToolTip="Move First Page"
                                                                meta:resourcekey="ibtnFirstResource1" />
                                                            <asp:ImageButton Text="Previous" CommandName="Page" CommandArgument="Prev" runat="server"
                                                                ImageUrl="~/App_Themes/Images/previous.png" ID="ibtnPrevious" ToolTip="Move Previous Page"
                                                                meta:resourcekey="ibtnPreviousResource1" />
                                                            <asp:Label ID="lblPage" runat="server" Text="Page" meta:resourcekey="lblPageResource1"></asp:Label>
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
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:Button ID="btnClose" runat="server" Text="Back" OnClick="btnClose_Click" meta:resourcekey="btnCloseResource1" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
