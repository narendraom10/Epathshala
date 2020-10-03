<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Epathshala.master" AutoEventWireup="true"
    EnableEventValidation="false" CodeFile="SubjectWiseReportF.aspx.cs" Inherits="Report_SubjectWiseReportF"
    Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>

<%@ Register Src="../UserControl/ReportControl.ascx" TagName="ReportControl" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="tblDashboard">
        <div class="sidepanel">
            <div class="activitydivside">
                <div class="ActivityHeader">
                    <asp:Label ID="lblTitleFirst" runat="server" Text="Subject wise result report" meta:resourcekey="lblTitleFirstResource1"></asp:Label>
                </div>
                <div class="ActivityContent" id="FirstRpt" runat="server" visible="true">
                    <div>
                        <asp:Label ID="lblSchool" runat="server" Text="School:" CssClass="textlabel" ToolTip="School Name :"
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
                        <asp:Button ID="btnview" runat="server" Text="View Report" CssClass="textlabel" OnClick="btnview_Click"
                            ValidationGroup="a" meta:resourcekey="btnviewResource1" />
                        <asp:Button ID="btnReset" runat="server" Text="Reset" OnClick="btnReset_Click" meta:resourcekey="btnResetResource1" />
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                            ShowSummary="False" ValidationGroup="a" meta:resourcekey="ValidationSummary1Resource1" />
                    </div>
                </div>
            </div>
        </div>
        <div class="sidepanel1">
            <div>
                <div class="activitydivside1">
                    <div class="ActivityHeader">
                        <asp:Label ID="lblTitleSecond" runat="server" Text="Subject wise result report" Visible="true"
                            meta:resourcekey="lblTitleSecondResource1"></asp:Label>
                    </div>
                    <div class="ActivityContent" id="secondRpt" runat="server" visible="false">
                        <div class="subactiviycontent">
                            <div>
                                <asp:Label ID="slblSchool" runat="server" Text="School:" CssClass="textlabel" ToolTip="School Name"
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
                        </div>
                        <div class="subactiviycontent">
                            <div>
                                <asp:Label ID="slblsubject" runat="server" Text="Subject:" CssClass="textlabel" meta:resourcekey="slblsubjectResource1"></asp:Label>
                                <asp:Label ID="slblsubjectValue" runat="server" CssClass="controllabel" meta:resourcekey="slblsubjectValueResource1"></asp:Label>
                            </div>
                            <div>
                                <asp:Label ID="slblFromDate" runat="server" Text="From Date:" CssClass="textlabel"
                                    meta:resourcekey="slblFromDateResource1"></asp:Label>
                                <asp:Label ID="slblFromDateValue" runat="server" CssClass="controllabel" meta:resourcekey="slblFromDateValueResource1"></asp:Label>
                            </div>
                            <div>
                                <asp:Label ID="slblToDate" runat="server" Text="To Date:" CssClass="textlabel" meta:resourcekey="slblToDateResource1"></asp:Label>
                                <asp:Label ID="slblToDateValue" runat="server" CssClass="controllabel" meta:resourcekey="slblToDateValueResource1"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="ActivityContent" id="thirdRpt" runat="server" visible="false">
                        <div class="subactiviycontent">
                            <div>
                                <asp:Label ID="TlblSchool" runat="server" Text="School:" CssClass="textlabel" ToolTip="School Name"
                                    meta:resourcekey="TlblSchoolResource1"></asp:Label>
                                <asp:Label ID="TlblSchoolValue" runat="server" CssClass="controllabel" meta:resourcekey="TlblSchoolValueResource1"></asp:Label>
                            </div>
                            <div>
                                <asp:Label ID="TlblBoard" runat="server" Text="Board:" CssClass="textlabel" ToolTip="Board"
                                    meta:resourcekey="TlblBoardResource1"></asp:Label>
                                <asp:Label ID="TlblBoardValue" runat="server" CssClass="controllabel" ToolTip="Board"
                                    meta:resourcekey="TlblBoardValueResource1"></asp:Label>
                            </div>
                            <div>
                                <asp:Label ID="TlblMedium" runat="server" Text="Medium:" CssClass="textlabel" meta:resourcekey="TlblMediumResource1"></asp:Label>
                                <asp:Label ID="TlblMediumValue" runat="server" CssClass="controllabel" meta:resourcekey="TlblMediumValueResource1"></asp:Label>
                            </div>
                            <div>
                                <asp:Label ID="TlblStandard" runat="server" Text="Standard:" CssClass="textlabel"
                                    meta:resourcekey="TlblStandardResource1"></asp:Label>
                                <asp:Label ID="TlblStandardValue" runat="server" CssClass="controllabel" meta:resourcekey="TlblStandardValueResource1"></asp:Label>
                            </div>
                        </div>
                        <div class="subactiviycontent">
                            <div>
                                <asp:Label ID="Tlblsubject" runat="server" Text="Subject:" CssClass="textlabel" meta:resourcekey="TlblsubjectResource1"></asp:Label>
                                <asp:Label ID="TlblsubjectValue" runat="server" CssClass="controllabel" meta:resourcekey="TlblsubjectValueResource1"></asp:Label>
                            </div>
                            <div>
                                <asp:Label ID="Tlblteacher" runat="server" Text="Teacher:" CssClass="textlabel" meta:resourcekey="TlblteacherResource1"></asp:Label>
                                <asp:Label ID="TlblteacherValue" runat="server" CssClass="controllabel" meta:resourcekey="TlblteacherValueResource1"></asp:Label>
                            </div>
                            <div>
                                <asp:Label ID="TlblFromDate" runat="server" Text="From Date:" CssClass="textlabel"
                                    meta:resourcekey="TlblFromDateResource1"></asp:Label>
                                <asp:Label ID="TlblFromDateValue" runat="server" CssClass="controllabel" meta:resourcekey="TlblFromDateValueResource1"></asp:Label>
                            </div>
                            <div>
                                <asp:Label ID="TlblToDate" runat="server" Text="To Date:" CssClass="textlabel" meta:resourcekey="TlblToDateResource1"></asp:Label>
                                <asp:Label ID="TlblToDateValue" runat="server" CssClass="controllabel" meta:resourcekey="TlblToDateValueResource1"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="ActivityContent" id="fourthRpt" runat="server" visible="false">
                        <div class="subactiviycontent">
                            <div>
                                <asp:Label ID="flblSchool" runat="server" Text="School:" CssClass="textlabel" ToolTip="School Name"
                                    meta:resourcekey="flblSchoolResource1"></asp:Label>
                                <asp:Label ID="flblSchoolValue" runat="server" CssClass="controllabel" meta:resourcekey="flblSchoolValueResource1"></asp:Label>
                            </div>
                            <div>
                                <asp:Label ID="flblBoard" runat="server" Text="Board:" CssClass="textlabel" ToolTip="Board"
                                    meta:resourcekey="flblBoardResource1"></asp:Label>
                                <asp:Label ID="flblBoardValue" runat="server" CssClass="controllabel" ToolTip="Board"
                                    meta:resourcekey="flblBoardValueResource1"></asp:Label>
                            </div>
                            <div>
                                <asp:Label ID="flblMedium" runat="server" Text="Medium:" CssClass="textlabel" meta:resourcekey="flblMediumResource1"></asp:Label>
                                <asp:Label ID="flblMediumValue" runat="server" CssClass="controllabel" meta:resourcekey="flblMediumValueResource1"></asp:Label>
                            </div>
                            <div>
                                <asp:Label ID="flblStandard" runat="server" Text="Standard:" CssClass="textlabel"
                                    meta:resourcekey="flblStandardResource1"></asp:Label>
                                <asp:Label ID="flblStandardValue" runat="server" CssClass="controllabel" meta:resourcekey="flblStandardValueResource1"></asp:Label>
                            </div>
                            <div>
                                <asp:Label ID="flblsubject" runat="server" Text="Subject:" CssClass="textlabel" meta:resourcekey="flblsubjectResource1"></asp:Label>
                                <asp:Label ID="flblsubjectValue" runat="server" CssClass="controllabel" meta:resourcekey="flblsubjectValueResource1"></asp:Label>
                            </div>
                        </div>
                        <div class="subactiviycontent">
                            <div>
                                <asp:Label ID="flblteacher" runat="server" Text="Teacher:" CssClass="textlabel" meta:resourcekey="flblteacherResource1"></asp:Label>
                                <asp:Label ID="flblteacherValue" runat="server" CssClass="controllabel" meta:resourcekey="flblteacherValueResource1"></asp:Label>
                            </div>
                            <div>
                                <asp:Label ID="flblStudent" runat="server" Text="Student:" CssClass="textlabel" meta:resourcekey="flblStudentResource1"></asp:Label>
                                <asp:Label ID="flblStudentValue" runat="server" CssClass="controllabel" meta:resourcekey="flblStudentValueResource1"></asp:Label>
                            </div>
                            <div>
                                <asp:Label ID="flblFromDate" runat="server" Text="From Date:" CssClass="textlabel"
                                    meta:resourcekey="flblFromDateResource1"></asp:Label>
                                <asp:Label ID="flblFromDateValue" runat="server" CssClass="controllabel" meta:resourcekey="flblFromDateValueResource1"></asp:Label>
                            </div>
                            <div>
                                <asp:Label ID="flblToDate" runat="server" Text="To Date:" CssClass="textlabel" meta:resourcekey="flblToDateResource1"></asp:Label>
                                <asp:Label ID="flblToDateValue" runat="server" CssClass="controllabel" meta:resourcekey="flblToDateValueResource1"></asp:Label>
                            </div>
                            <div>
                                <asp:Label ID="flblPerc" runat="server" Text="Percentage:" CssClass="textlabel" meta:resourcekey="flblPercResource1"></asp:Label>
                                <asp:Label ID="flblPercValue" runat="server" CssClass="controllabel" meta:resourcekey="flblPercValueResource1"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="ActivityContent" id="fifthRpt" runat="server" visible="false">
                        <div class="subactiviycontent">
                            <div>
                                <asp:Label ID="filblSchool" runat="server" Text="School:" CssClass="textlabel" ToolTip="School Name"
                                    meta:resourcekey="filblSchoolResource1"></asp:Label>
                                <asp:Label ID="filblSchoolValue" runat="server" CssClass="controllabel" meta:resourcekey="filblSchoolValueResource1"></asp:Label>
                            </div>
                            <div>
                                <asp:Label ID="filblBoard" runat="server" Text="Board:" CssClass="textlabel" ToolTip="Board"
                                    meta:resourcekey="filblBoardResource1"></asp:Label>
                                <asp:Label ID="filblBoardValue" runat="server" CssClass="controllabel" ToolTip="Board"
                                    meta:resourcekey="filblBoardValueResource1"></asp:Label>
                            </div>
                            <div>
                                <asp:Label ID="filblMedium" runat="server" Text="Medium:" CssClass="textlabel" meta:resourcekey="filblMediumResource1"></asp:Label>
                                <asp:Label ID="filblMediumValue" runat="server" CssClass="controllabel" meta:resourcekey="filblMediumValueResource1"></asp:Label>
                            </div>
                            <div>
                                <asp:Label ID="filblStandard" runat="server" Text="Standard:" CssClass="textlabel"
                                    meta:resourcekey="filblStandardResource1"></asp:Label>
                                <asp:Label ID="filblStandardValue" runat="server" CssClass="controllabel" meta:resourcekey="filblStandardValueResource1"></asp:Label>
                            </div>
                            <div>
                                <asp:Label ID="filblsubject" runat="server" Text="Subject:" CssClass="textlabel"
                                    meta:resourcekey="filblsubjectResource1"></asp:Label>
                                <asp:Label ID="filblsubjectValue" runat="server" CssClass="controllabel" meta:resourcekey="filblsubjectValueResource1"></asp:Label>
                            </div>
                            <div>
                                <asp:Label ID="filblChapter" runat="server" Text="Chapter:" CssClass="textlabel"
                                    meta:resourcekey="filblChapterResource1"></asp:Label>
                                <asp:Label ID="filblChapterValue" runat="server" CssClass="controllabel" meta:resourcekey="filblChapterValueResource1"></asp:Label>
                            </div>
                            <div>
                                <asp:Label ID="filbltopic" runat="server" Text="Topic:" CssClass="textlabel" meta:resourcekey="filbltopicResource1"></asp:Label>
                                <asp:Label ID="filbltopicValue" runat="server" CssClass="controllabel" meta:resourcekey="filbltopicValueResource1"></asp:Label>
                            </div>
                        </div>
                        <div class="subactiviycontent">
                            <div>
                                <asp:Label ID="filblDate" runat="server" Text="Date:" CssClass="textlabel" meta:resourcekey="filblDateResource1"></asp:Label>
                                <asp:Label ID="filblDateValue" runat="server" CssClass="controllabel" meta:resourcekey="filblDateValueResource1"></asp:Label>
                            </div>
                            <div>
                                <asp:Label ID="filblteacher" runat="server" Text="Teacher:" CssClass="textlabel"
                                    meta:resourcekey="filblteacherResource1"></asp:Label>
                                <asp:Label ID="filblteacherValue" runat="server" CssClass="controllabel" meta:resourcekey="filblteacherValueResource1"></asp:Label>
                            </div>
                            <div>
                                <asp:Label ID="filblStudent" runat="server" Text="Student:" CssClass="textlabel"
                                    meta:resourcekey="filblStudentResource1"></asp:Label>
                                <asp:Label ID="filblStudentValue" runat="server" CssClass="controllabel" meta:resourcekey="filblStudentValueResource1"></asp:Label>
                            </div>
                            <div>
                                <asp:Label ID="filblTrueAns" runat="server" Text="True Ans:" CssClass="textlabel"
                                    meta:resourcekey="filblTrueAnsResource1"></asp:Label>
                                <asp:Label ID="filblTrueAnsValue" runat="server" CssClass="controllabel" meta:resourcekey="filblTrueAnsValueResource1"></asp:Label>
                            </div>
                            <div>
                                <asp:Label ID="filblFalseAns" runat="server" Text="False Ans:" CssClass="textlabel"
                                    meta:resourcekey="filblFalseAnsResource1"></asp:Label>
                                <asp:Label ID="filblFalseAnsValue" runat="server" CssClass="controllabel" meta:resourcekey="filblFalseAnsValueResource1"></asp:Label>
                            </div>
                            <div>
                                <asp:Label ID="filblResult" runat="server" Text="Result (%):" CssClass="textlabel"
                                    meta:resourcekey="filblResultResource1"></asp:Label>
                                <asp:Label ID="filblResultValue" runat="server" CssClass="controllabel" meta:resourcekey="filblResultValueResource1"></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="activitydivside1" style="margin-top: 15px;">
                    <div class="ActivityHeader">
                        <asp:Label ID="Label3" runat="server" Text="Report List"></asp:Label>
                    </div>
                    <div class="ActivityContent" id="userControlDv" runat="server" visible="true">
                        <uc1:ReportControl ID="ReportControl1" runat="server" />
                    </div>
                </div>
                <div id="notusercontroldv" runat="server" visible="false">
                    <div class="activitydivside1" style="margin-top: 15px;" id="ExamResult" runat="server"
                        width="50%">
                        <div class="ActivityHeader">
                        </div>
                        <div class="ActivityContent">
                            <div style="width: 100%;">
                                <div class="subactiviycontent" style="border: 1px solid blue;">
                                    <div style="width: 100%; text-align: center; background-color: #ccc; margin-bottom: 5px;
                                        font-family: Roboto-Regular; padding: 2px 0;">
                                        <asp:Label ID="lblASum" runat="server" Text="Assessment summary" meta:resourcekey="lblASumResource1"></asp:Label>
                                    </div>
                                    <div style="float: left; margin: 0 25px 5px 10px;">
                                        <asp:Label ID="Label8" runat="server" ForeColor="#484CE2" Text="Total Question:"
                                            meta:resourcekey="Label8Resource1"></asp:Label>
                                        <asp:Label ID="lblTotalQues" runat="server" ForeColor="#484CE2" Text="0" meta:resourcekey="lblTotalQuesResource1"></asp:Label>
                                    </div>
                                    <div style="float: left; margin-right: 20px;">
                                        <asp:Label ID="Label11" runat="server" ForeColor="#484CE2" Text="Correct:" meta:resourcekey="Label11Resource1"></asp:Label>
                                        <asp:Label ID="Label1" runat="server" ForeColor="#484CE2" Text="0" meta:resourcekey="Label1Resource1"></asp:Label>
                                    </div>
                                    <div style="float: left; margin-right: 20px;">
                                        <asp:Label ID="Label13" runat="server" ForeColor="#484CE2" Text="False:" meta:resourcekey="Label13Resource1"></asp:Label>
                                        <asp:Label ID="Label2" runat="server" ForeColor="#484CE2" Text="0" meta:resourcekey="Label2Resource1"></asp:Label>
                                    </div>
                                </div>
                                <div class="subactiviycontent" style="border: 1px solid blue; float: right;">
                                    <div style="width: 100%; text-align: center; background-color: #ccc; margin-bottom: 5px;
                                        font-family: Roboto-Regular; padding: 2px 0;">
                                        <asp:Label ID="lbluserScore" runat="server" Text="You have score :" meta:resourcekey="lbluserScoreResource1"></asp:Label>
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
    </div>
</asp:Content>
