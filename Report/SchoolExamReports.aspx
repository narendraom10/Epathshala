<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Epathshala.master" AutoEventWireup="true"
    EnableEventValidation="false" CodeFile="SchoolExamReports.aspx.cs" Inherits="Report_SchoolExamReports"
    Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>

<%@ Register Src="../UserControl/ReportControl.ascx" TagName="ReportControl" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" src="../JavaScript/ASCIIMathML.js"></script>
    <script type="text/javascript" src="../JavaScript/jquery-1.4.2.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
 <%--   <asp:UpdatePanel runat="server" ID="upTopics" UpdateMode="Conditional">
        <ContentTemplate>--%>
            <div class="tblDashboard">
                <div class="sidepanel">
                    <div class="activitydivside">
                        <div class="ActivityHeader">
                            <asp:Label ID="lblTitleFirst" runat="server" Text="Schoolwise result report" meta:resourcekey="lblTitleFirstResource1"></asp:Label>
                        </div>
                        <div class="ActivityContent" id="FirstRpt" runat="server" visible="true">
                            <div>
                                <asp:Label ID="lblSchool" runat="server" Text="School:" CssClass="textlabel" ToolTip="School Name:"
                                    meta:resourcekey="lblSchoolResource1"></asp:Label>
                                <asp:DropDownList ID="ddlSchool" runat="server" Width="100%" AutoPostBack="True"
                                    OnSelectedIndexChanged="ddlSchool_SelectedIndexChanged" meta:resourcekey="ddlSchoolResource1">
                                    <asp:ListItem Text="-- Select --" Value="0" meta:resourcekey="ListItemResource1"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RFVddlSchool" runat="server" ControlToValidate="ddlSchool"
                                    InitialValue="0" ErrorMessage="Please Select School." ValidationGroup="a" meta:resourcekey="RFVddlSchoolResource1">*</asp:RequiredFieldValidator>
                            </div>
                            <div>
                                <asp:Label ID="lblBoard" runat="server" Text="Board:" CssClass="textlabel" ToolTip="Board"
                                    meta:resourcekey="lblBoardResource1"></asp:Label>
                                <asp:DropDownList ID="ddlBoard" runat="server" AutoPostBack="True" AppendDataBoundItems="True"
                                    OnSelectedIndexChanged="ddlBoard_SelectedIndexChanged" meta:resourcekey="ddlBoardResource1">
                                    <asp:ListItem Text="-- Select --" Value="0" meta:resourcekey="ListItemResource2"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="ReqFieldBoard" runat="server" ErrorMessage="Please select board"
                                    ValidationGroup="a" InitialValue="0" ControlToValidate="ddlBoard" meta:resourcekey="ReqFieldBoardResource1">*</asp:RequiredFieldValidator>
                            </div>
                            <div>
                                <asp:Label ID="lblMedium" runat="server" Text="Medium:" CssClass="textlabel" meta:resourcekey="lblMediumResource1"></asp:Label>
                                <asp:DropDownList ID="ddlMedium" runat="server" AutoPostBack="True" AppendDataBoundItems="True"
                                    Enabled="False" OnSelectedIndexChanged="ddlMedium_SelectedIndexChanged" meta:resourcekey="ddlMediumResource1">
                                    <asp:ListItem Text="-- Select --" Value="0" meta:resourcekey="ListItemResource3"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="ReqFieldMedium" runat="server" ErrorMessage="Please select medium"
                                    ValidationGroup="a" InitialValue="0" ControlToValidate="ddlMedium" meta:resourcekey="ReqFieldMediumResource1">*</asp:RequiredFieldValidator>
                            </div>
                            <div>
                                <asp:Label ID="lblStandard" runat="server" Text="Standard:" CssClass="textlabel"
                                    meta:resourcekey="lblStandardResource1"></asp:Label>
                                <asp:DropDownList ID="ddlStandard" runat="server" AppendDataBoundItems="True" Enabled="False"
                                    AutoPostBack="True" OnSelectedIndexChanged="ddlStandard_SelectedIndexChanged"
                                    meta:resourcekey="ddlStandardResource1">
                                    <asp:ListItem Text="-- Select --" Value="0" meta:resourcekey="ListItemResource4"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div>
                                <asp:Label ID="lblsubject" runat="server" Text="Subject:" CssClass="textlabel" meta:resourcekey="lblsubjectResource1"></asp:Label>
                                <asp:DropDownList ID="ddlsubject" runat="server" AppendDataBoundItems="True" Enabled="False"
                                    AutoPostBack="True" OnSelectedIndexChanged="ddlsubject_SelectedIndexChanged"
                                    meta:resourcekey="ddlsubjectResource1">
                                    <asp:ListItem Text="-- Select --" Value="0" meta:resourcekey="ListItemResource5"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div>
                                <asp:Label ID="lblChapter" runat="server" Text="Chapter:" CssClass="textlabel" meta:resourcekey="lblChapterResource1"></asp:Label>
                                <asp:DropDownList ID="ddlchapter" runat="server" AppendDataBoundItems="True" Enabled="False"
                                    AutoPostBack="True" OnSelectedIndexChanged="ddlchapter_SelectedIndexChanged"
                                    meta:resourcekey="ddlchapterResource1">
                                    <asp:ListItem Text="-- Select --" Value="0" meta:resourcekey="ListItemResource6"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div>
                                <asp:Label ID="lbltopic" runat="server" Text="Topic:" CssClass="textlabel" meta:resourcekey="lbltopicResource1"></asp:Label>
                                <asp:DropDownList ID="ddltopic" runat="server" AppendDataBoundItems="True" Enabled="False"
                                    OnSelectedIndexChanged="ddltopic_SelectedIndexChanged" meta:resourcekey="ddltopicResource1">
                                    <asp:ListItem Text="-- Select --" Value="0" meta:resourcekey="ListItemResource7"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div>
                                <asp:Label ID="lblfrmdate" runat="server" Text="From date:" CssClass="textlabel"
                                    meta:resourcekey="lblfrmdateResource1"></asp:Label>
                                <asp:TextBox ID="txtfromdate" runat="server" meta:resourcekey="txtfromdateResource1"
                                    CssClass="textBoxCls"></asp:TextBox><asp:ImageButton ID="ibtnDate" runat="server"
                                        ImageUrl="~/App_Themes/Images/calendar12.png" Width="20px" meta:resourcekey="ibtnDateResource1" /><asp:RequiredFieldValidator
                                            ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtfromdate" ValidationGroup="a"
                                            ErrorMessage="Please enter From date" meta:resourcekey="RequiredFieldValidator1Resource1">*</asp:RequiredFieldValidator>
                                <cc2:CalendarExtender ID="ceDate" runat="server" Format="dd-MMM-yyyy" TargetControlID="txtfromdate"
                                    PopupButtonID="ibtnDate" Enabled="True">
                                </cc2:CalendarExtender>
                            </div>
                            <div>
                                <asp:Label ID="lbltodate" runat="server" Text="To date:" CssClass="textlabel" meta:resourcekey="lbltodateResource1"></asp:Label>
                                <asp:TextBox ID="txttodate" runat="server" meta:resourcekey="txttodateResource1"
                                    CssClass="textBoxCls"></asp:TextBox><asp:ImageButton ID="ibtnToDate" runat="server"
                                        ImageUrl="~/App_Themes/Images/calendar12.png" Width="20px" meta:resourcekey="ibtnToDateResource1" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txttodate"
                                    ValidationGroup="a" ErrorMessage="Please enter to date" meta:resourcekey="RequiredFieldValidator2Resource1">*</asp:RequiredFieldValidator>
                                <cc2:CalendarExtender ID="ceTodate" runat="server" Format="dd-MMM-yyyy" TargetControlID="txttodate"
                                    PopupButtonID="ibtnToDate" Enabled="True">
                                </cc2:CalendarExtender>
                            </div>
                            <div class="gobotton">
                                <asp:Button ID="btnview" runat="server" Text="View Report" OnClick="btnview_Click"
                                    ValidationGroup="a" meta:resourcekey="btnviewResource1" />
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                    ShowSummary="False" ValidationGroup="a" meta:resourcekey="ValidationSummary1Resource1" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="sidepanel1">
                    <div class="activitydivside1">
                        <div class="ActivityHeader">
                            <asp:Label ID="lblTitleSecond" runat="server" Text="Schoolwise Subject result report"
                                Visible="False" meta:resourcekey="lblTitleSecondResource1"></asp:Label>
                            <asp:Label ID="lblTitleThird" runat="server" Text="Schoolwise all exam result report"
                                Visible="False" meta:resourcekey="lblTitleThirdResource1"></asp:Label>
                        </div>
                        <div class="ActivityContent" id="secondRpt" runat="server" visible="false">
                            <div class="subactiviycontent">
                                <div>
                                    <asp:Label ID="slblSchool" runat="server" Text="School:" CssClass="textlabel" ToolTip="School Name:"
                                        meta:resourcekey="slblSchoolResource1"></asp:Label>
                                    <asp:Label ID="slblSchoolValue" runat="server" CssClass="controllabel" meta:resourcekey="slblSchoolValueResource1"></asp:Label>
                                </div>
                                <div>
                                    <asp:Label ID="slblBoard" runat="server" Text="Board:" CssClass="textlabel" ToolTip="Board"
                                        meta:resourcekey="slblBoardResource1"></asp:Label>
                                    <asp:Label ID="slblBoardValue" runat="server" CssClass="controllabel" ToolTip="Board"
                                        meta:resourcekey="slblBoardValueResource1"></asp:Label>
                                </div>
                                <div>
                                    <asp:Label ID="slblMedium" runat="server" Text="Medium:" CssClass="textlabel" meta:resourcekey="slblMediumResource1"></asp:Label>
                                    <asp:Label ID="slblMediumValue" runat="server" CssClass="controllabel" meta:resourcekey="slblMediumValueResource1"></asp:Label>
                                </div>
                                <div>
                                    <asp:Label ID="slblStandard" runat="server" Text="Standard:" CssClass="textlabel"
                                        meta:resourcekey="slblStandardResource1"></asp:Label>
                                    <asp:Label ID="slblStandardValue" runat="server" CssClass="controllabel" meta:resourcekey="slblStandardValueResource1"></asp:Label>
                                </div>
                                <div>
                                    <asp:Label ID="slblsubject" runat="server" Text="Subject:" CssClass="textlabel" meta:resourcekey="slblsubjectResource1"></asp:Label>
                                    <asp:Label ID="slblsubjectValue" runat="server" CssClass="controllabel" meta:resourcekey="slblsubjectValueResource1"></asp:Label>
                                </div>
                            </div>
                            <div class="subactiviycontent">
                                <div>
                                    <asp:Label ID="slblChapter" runat="server" Text="Chapter:" CssClass="textlabel" meta:resourcekey="slblChapterResource1"></asp:Label>
                                    <asp:Label ID="slblChapterValue" runat="server" CssClass="controllabel" meta:resourcekey="slblChapterValueResource1"></asp:Label>
                                </div>
                                <div>
                                    <asp:Label ID="slbltopic" runat="server" Text="Topic:" CssClass="textlabel" meta:resourcekey="slbltopicResource1"></asp:Label>
                                    <asp:Label ID="slbltopicValue" runat="server" CssClass="controllabel" meta:resourcekey="slbltopicValueResource1"></asp:Label>
                                </div>
                                <div>
                                    <asp:Label ID="slblDate" runat="server" Text="Date:" CssClass="textlabel" meta:resourcekey="slblDateResource1"></asp:Label>
                                    <asp:Label ID="slblDateValue" runat="server" CssClass="controllabel" meta:resourcekey="slblDateValueResource1"></asp:Label>
                                </div>
                                <div>
                                    <asp:Label ID="slblteacher" runat="server" Text="Teacher:" CssClass="textlabel" meta:resourcekey="slblteacherResource1"></asp:Label>
                                    <asp:Label ID="slblteacherValue" runat="server" CssClass="controllabel" meta:resourcekey="slblteacherValueResource1"></asp:Label>
                                </div>
                            </div>
                        </div>
                        <div class="ActivityContent" id="thirdRpt" runat="server" visible="false">
                            <div class="subactiviycontent">
                                <div>
                                    <asp:Label ID="tlblSchool" runat="server" Text="School :" CssClass="textlabel" ToolTip="School Name:"
                                        meta:resourcekey="tlblSchoolResource1"></asp:Label>
                                    <asp:Label ID="tlblSchoolValue" runat="server" CssClass="controllabel" meta:resourcekey="tlblSchoolValueResource1"></asp:Label>
                                </div>
                                <div>
                                    <asp:Label ID="tlblBoard" runat="server" Text="Board:" CssClass="textlabel" ToolTip="Board"
                                        meta:resourcekey="tlblBoardResource1"></asp:Label>
                                    <asp:Label ID="tlblBoardValue" runat="server" CssClass="controllabel" ToolTip="Board"
                                        meta:resourcekey="tlblBoardValueResource1"></asp:Label>
                                </div>
                                <div>
                                    <asp:Label ID="tlblMedium" runat="server" Text="Medium:" CssClass="textlabel" meta:resourcekey="tlblMediumResource1"></asp:Label>
                                    <asp:Label ID="tlblMediumValue" runat="server" CssClass="controllabel" meta:resourcekey="tlblMediumValueResource1"></asp:Label>
                                </div>
                                <div>
                                    <asp:Label ID="tlblStandard" runat="server" Text="Standard:" CssClass="textlabel"
                                        meta:resourcekey="tlblStandardResource1"></asp:Label>
                                    <asp:Label ID="tlblStandardValue" runat="server" CssClass="controllabel" meta:resourcekey="tlblStandardValueResource1"></asp:Label>
                                </div>
                                <div>
                                    <asp:Label ID="tlblsubject" runat="server" Text="Subject:" CssClass="textlabel" meta:resourcekey="tlblsubjectResource1"></asp:Label>
                                    <asp:Label ID="tlblsubjectValue" runat="server" CssClass="controllabel" meta:resourcekey="tlblsubjectValueResource1"></asp:Label>
                                </div>
                                <div>
                                    <asp:Label ID="tlblChapter" runat="server" Text="Chapter:" CssClass="textlabel" meta:resourcekey="tlblChapterResource1"></asp:Label>
                                    <asp:Label ID="tlblChapterValue" runat="server" CssClass="controllabel" meta:resourcekey="tlblChapterValueResource1"></asp:Label>
                                </div>
                                <div>
                                    <asp:Label ID="tlbltopic" runat="server" Text="Topic:" CssClass="textlabel" meta:resourcekey="tlbltopicResource1"></asp:Label>
                                    <asp:Label ID="tlbltopicValue" runat="server" CssClass="controllabel" meta:resourcekey="tlbltopicValueResource1"></asp:Label>
                                </div>
                            </div>
                            <div class="subactiviycontent">
                                <div>
                                    <asp:Label ID="tlblDate" runat="server" Text="Date:" CssClass="textlabel" meta:resourcekey="tlblDateResource1"></asp:Label>
                                    <asp:Label ID="tlblDateValue" runat="server" CssClass="controllabel" meta:resourcekey="tlblDateValueResource1"></asp:Label>
                                </div>
                                <div>
                                    <asp:Label ID="tlblteacher" runat="server" Text="Teacher:" CssClass="textlabel" meta:resourcekey="tlblteacherResource1"></asp:Label>
                                    <asp:Label ID="tlblteacherValue" runat="server" CssClass="controllabel" meta:resourcekey="tlblteacherValueResource1"></asp:Label>
                                </div>
                                <div>
                                    <asp:Label ID="tlblStudent" runat="server" Text="Student:" CssClass="textlabel" meta:resourcekey="tlblStudentResource1"></asp:Label>
                                    <asp:Label ID="tlblStudentValue" runat="server" CssClass="controllabel" meta:resourcekey="tlblStudentValueResource1"></asp:Label>
                                </div>
                                <div>
                                    <asp:Label ID="tlblTrueAns" runat="server" Text="True Ans:" CssClass="textlabel"
                                        meta:resourcekey="tlblTrueAnsResource1"></asp:Label>
                                    <asp:Label ID="tlblTrueAnsValue" runat="server" CssClass="controllabel" meta:resourcekey="tlblTrueAnsValueResource1"></asp:Label>
                                </div>
                                <div>
                                    <asp:Label ID="tlblFalseAns" runat="server" Text="False Ans:" CssClass="textlabel"
                                        meta:resourcekey="tlblFalseAnsResource1"></asp:Label>
                                    <asp:Label ID="tlblFalseAnsValue" runat="server" CssClass="controllabel" meta:resourcekey="tlblFalseAnsValueResource1"></asp:Label>
                                </div>
                                <div>
                                    <asp:Label ID="tlblResult" runat="server" Text="Result (%):" CssClass="textlabel"
                                        meta:resourcekey="tlblResultResource1"></asp:Label>
                                    <asp:Label ID="tlblResultValue" runat="server" CssClass="controllabel" meta:resourcekey="tlblResultValueResource1"></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="activitydivside1">
                        <div class="ActivityHeader">
                        </div>
                        <div class="ActivityContent" id="userControlDv" runat="server" visible="true">
                            <uc1:ReportControl ID="ReportControl1" runat="server" Visible="False" />
                        </div>
                    </div>
                    <div class="activitydivside1">
                        <div class="ActivityHeader">
                        </div>
                        <div class="ActivityContent">
                            <div id="notusercontroldv" runat="server" visible="false">
                                <div id="ExamResult" runat="server" width="100%">
                                    <div class="subactiviycontent" style="border: 1px solid blue;">
                                        <div style="width: 100%; text-align: center; background-color: #ccc; margin-bottom: 5px;
                                            font-family: Roboto-Regular; padding: 2px 0;">
                                            <asp:Label ID="lblASum" runat="server" ForeColor="#484CE2" Text="Assessment summary"
                                                meta:resourcekey="lblASumResource1"></asp:Label>
                                        </div>
                                        <div style="float: left; margin: 0 25px 5px 10px;">
                                            <asp:Label ID="Label8" runat="server" ForeColor="#484CE2" Text="Total Question:"
                                                meta:resourcekey="Label8Resource1"></asp:Label>
                                            <asp:Label ID="lblTotalQues" runat="server" ForeColor="#484CE2" Text="0" meta:resourcekey="lblTotalQuesResource1"></asp:Label>
                                        </div>
                                        <div>
                                            <asp:Label ID="Label11" runat="server" ForeColor="#484CE2" Text="Correct:" meta:resourcekey="Label11Resource1"></asp:Label>
                                            <asp:Label ID="Label1" runat="server" ForeColor="#484CE2" Text="0" meta:resourcekey="Label1Resource1"></asp:Label>
                                        </div>
                                        <div>
                                            <asp:Label ID="Label13" runat="server" ForeColor="#484CE2" Text="False:" meta:resourcekey="Label13Resource1"></asp:Label>
                                            <asp:Label ID="Label2" runat="server" ForeColor="#484CE2" Text="0" meta:resourcekey="Label2Resource1"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="subactiviycontent" style="border: 1px solid blue; float: right;">
                                        <div style="width: 100%; text-align: center; background-color: #ccc; margin-bottom: 5px;
                                            font-family: Roboto-Regular; padding: 2px 0;">
                                            <asp:Label ID="lbluserScore" runat="server" ForeColor="#484CE2" Text="You have score :"
                                                meta:resourcekey="lbluserScoreResource1"></asp:Label>
                                        </div>
                                        <div style="margin: 0 0 5px 5px;">
                                            <asp:Label ID="lbluserScoreValue" runat="server" ForeColor="#484CE2" Text="Label"
                                                meta:resourcekey="lbluserScoreValueResource1"></asp:Label><br />
                                        </div>
                                    </div>
                                </div>
                                <div class="assessment">
                                    <asp:GridView ID="gvAnalysis" runat="server" OnRowDataBound="gvAnalysis_RowDataBound"
                                        SkinID="TestAssessment" meta:resourcekey="gvAnalysisResource1">
                                        <Columns>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" meta:resourcekey="TemplateFieldResource1">
                                                <HeaderTemplate>
                                                    <asp:Label ID="Label4" Text="Assessment" runat="server" Font-Bold="True" meta:resourcekey="Label4Resource1"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <table width="100%" style="border: solid 1px #484CE2;">
                                                        <tr class="DatalistHeader">
                                                            <td align="right" valign="top" style="border-bottom: solid 1px #484CE2; border-top: none;
                                                                border-right: none; border-left: none" width="15%">
                                                                <asp:Label ID="lblQ" runat="server" Text="Ques" ForeColor="#484CE2" Font-Bold="True"
                                                                    meta:resourcekey="lblQResource1"></asp:Label>
                                                                <span style="color: #484CE2; font-weight: bold">
                                                                    <asp:Label ID="lblNo" runat="server" ForeColor="#484CE2" Font-Bold="True" Text='<%# Container.DataItemIndex +1 %>'
                                                                        meta:resourcekey="lblNoResource1"></asp:Label>: </span>
                                                            </td>
                                                            <td align="left" colspan="4" style="border-bottom: solid 1px #484CE2; border-top: none;
                                                                border-right: none; border-left: none" width="85%">
                                                                <asp:Literal ID="ltQuestion" runat="server" Text='<%# Eval("Question") %>'></asp:Literal>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right" valign="top" style="border: none;">
                                                                <asp:Label ID="lblCorrectAns" runat="server" ForeColor="#484CE2" Text="Options:"
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
                                                            <td align="right" valign="top" style="border: none;">
                                                                <asp:Label ID="lblSolutionTitle" runat="server" ForeColor="#484CE2" Text="Solution:"
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
                                                        <tr>
                                                            <td align="right" style="border: none;">
                                                                <asp:Label ID="lblResu" runat="server" ForeColor="#484CE2" Text="Result:" Font-Bold="True"
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
                                                    </table>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div>
                        <asp:Button ID="btnback" runat="server" Text="Back" OnClick="btnback_Click" Visible="False"
                            meta:resourcekey="btnbackResource1" />
                    </div>
                </div>
            </div>
       <%-- </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="ddlSchool" />
            <asp:AsyncPostBackTrigger ControlID="ddlBoard" />
            <asp:AsyncPostBackTrigger ControlID="ddlMedium" />
            <asp:AsyncPostBackTrigger ControlID="ddlStandard" />
            <asp:AsyncPostBackTrigger ControlID="ddlSubject" />
            <asp:AsyncPostBackTrigger ControlID="ddlChapter" />
            <asp:AsyncPostBackTrigger ControlID="ddlTopic" />
            <asp:AsyncPostBackTrigger ControlID="btnview" />
        </Triggers>
    </asp:UpdatePanel>--%>
    <!-- LoaderPart -->
    <asp:Button ID="btnLoader" runat="server" Style="display: none" />
    <asp:Button ID="btnCancel" runat="server" Style="display: none" />
    <cc2:ModalPopupExtender ID="ModalPopup" runat="server" PopupControlID="dvPopup" CancelControlID="btnCancel"
        TargetControlID="btnLoader" BackgroundCssClass="modalBackground" Enabled="True">
    </cc2:ModalPopupExtender>
     <table id="dvPopup" runat="server" class="loadingtable" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <img src="../App_Themes/Responsive/web/Loader.gif" alt="Loading Please wait.." />
            </td>
        </tr>
        <tr>
            <td class="loadingtabletd">
                <span>Loading Please Wait..</span>
            </td>
        </tr>
    </table>
    <!-- LoaderPart -->
    <script type="text/javascript">
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_beginRequest(BeginRequestHandler);
        prm.add_endRequest(EndRequestHandler);
        function BeginRequestHandler(sender, args) {
            if ($("#<%= btnLoader.ClientID%>") != null) {
                $("#<%= btnLoader.ClientID%>").click();
            }
        }

        function EndRequestHandler(sender, args) {
            if ($("#<%= btnCancel.ClientID%>") != null) {
                $("#<%= btnCancel.ClientID%>").click();
            }
        }
    </script>
</asp:Content>
