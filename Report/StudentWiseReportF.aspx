<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Epathshala.master" AutoEventWireup="true"
    CodeFile="StudentWiseReportF.aspx.cs" Inherits="Report_StudentWiseReportF" EnableEventValidation="false"
    Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="../UserControl/ReportControl.ascx" TagName="WebUserControl" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" src="../JavaScript/ASCIIMathML.js"></script>
    <script type="text/javascript" src="../JavaScript/jquery-1.4.2.js"></script>
      <style type="text/css">
        .Reporttext
        {
            margin: 0px;
            padding: 3px;
            font-size: 1em;
            color: black;
            text-align: left;
            white-space: nowrap;
            min-width: 51px;
            border: 1px solid #2E8E6E;
            background-color: #265F4E;
            color: #ffffff;
            cursor: pointer;
            font-family: Calibri, Cambria ,Trebuchet MS;
            font-size: medium;
            overflow: auto;
        }
        .ReportTextInner
        {
            margin: 0px;
            padding: 3px;
            font-size: 1em;
            text-align: left;
            white-space: nowrap;
            min-width: 51px;
            border-right: 0px solid #2E8E6E;
            border-left: 0px solid #2E8E6E;
            border-top: 0px solid #2E8E6E;
            padding: 8px;
            color: white;
        }
        .imgcalender
        {
            vertical-align: middle;
        }
        
        .SearchPnl .Label
        {
            margin-top: 10px !important;
        }
        .SearchPnl select
        {
            padding: 0px !important;
            min-width: 150px !important;
            max-width: 150px !important;
        }
        
        .SearchPnl input[type="text"]
        {
            min-width: 110px !important;
            max-width: 110px !important;
        }
        .SearchPnl input[type="image"]
        {
            min-width: 23px !important;
            max-width: 23px !important;
        }
        .GridViewItemRightAlignButtonImage
        {
            text-align: center !important;
            color: Blue !important; /*text-decoration: underline; */
        }
        .GridViewItemPadding
        {
            padding-left: 18px !important;
        }
        .GridViewItemRightAlign
        {
            text-align: right !important;
            width: 100px;
            padding-right: 32px !important;
        }
        .empty
        {
            background-color: #aad2ae;
            border: 1px solid #2e8e6e;
            color: black;
            font-size: 1.3em;
            font-weight: bold;
            padding: 3px;
            text-align: center;
            white-space: nowrap;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="tblDashboard">
        <div class="sidepanel">
            <div class="activitydivside">
                <div class="ActivityHeader">
                    <asp:Label ID="lblTitleFirst" runat="server" Text="Studentwise result report" meta:resourcekey="lblTitleFirstResource1"></asp:Label>
                </div>
                <asp:UpdatePanel runat="server" ID="upTopics" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="ActivityContent" id="FirstRpt" runat="server" visible="true">
                            <div>
                                <asp:Label ID="lblSchool" runat="server" Text="School :" CssClass="textlabel" ToolTip="School Name:"
                                    meta:resourcekey="lblSchoolResource1"></asp:Label>
                                <asp:DropDownList ID="ddlSchool" runat="server" Width="140px" AutoPostBack="True"
                                    OnSelectedIndexChanged="ddlSchool_SelectedIndexChanged" meta:resourcekey="ddlSchoolResource1">
                                    <asp:ListItem Text="-- Select --" Value="0" meta:resourcekey="ListItemResource1"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RFVddlSchool" runat="server" ControlToValidate="ddlSchool"
                                    InitialValue="0" ErrorMessage="Please Select School." ValidationGroup="a" meta:resourcekey="RFVddlSchoolResource1">*</asp:RequiredFieldValidator>
                            </div>
                            <div>
                                <asp:Label ID="lblBoard" runat="server" Text="Board :" CssClass="textlabel" ToolTip="Board"
                                    meta:resourcekey="lblBoardResource1"></asp:Label>
                                <asp:DropDownList ID="ddlBoard" runat="server" AutoPostBack="True" AppendDataBoundItems="True"
                                    OnSelectedIndexChanged="ddlBoard_SelectedIndexChanged" meta:resourcekey="ddlBoardResource1"
                                    Width="140px">
                                    <asp:ListItem Text="-- Select --" Value="0" meta:resourcekey="ListItemResource2"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="ReqFieldBoard" runat="server" ErrorMessage="Please select board"
                                    ValidationGroup="a" InitialValue="0" ControlToValidate="ddlBoard" meta:resourcekey="ReqFieldBoardResource1">*</asp:RequiredFieldValidator>
                            </div>
                            <div>
                                <asp:Label ID="lblMedium" runat="server" Text="Medium :" CssClass="textlabel" meta:resourcekey="lblMediumResource1"></asp:Label>
                                <asp:DropDownList ID="ddlMedium" runat="server" AutoPostBack="True" AppendDataBoundItems="True"
                                    Enabled="False" OnSelectedIndexChanged="ddlMedium_SelectedIndexChanged" meta:resourcekey="ddlMediumResource1"
                                    Width="140px">
                                    <asp:ListItem Text="-- Select --" Value="0" meta:resourcekey="ListItemResource3"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="ReqFieldMedium" runat="server" ErrorMessage="Please select medium"
                                    ValidationGroup="a" InitialValue="0" ControlToValidate="ddlMedium" meta:resourcekey="ReqFieldMediumResource1">*</asp:RequiredFieldValidator>
                            </div>
                            <div>
                                <asp:Label ID="lblStandard" runat="server" Text="Standard :" CssClass="textlabel"
                                    meta:resourcekey="lblStandardResource1"></asp:Label>
                                <asp:DropDownList ID="ddlStandard" runat="server" AppendDataBoundItems="True" Enabled="False"
                                    AutoPostBack="True" OnSelectedIndexChanged="ddlStandard_SelectedIndexChanged"
                                    meta:resourcekey="ddlStandardResource1" Width="140px">
                                    <asp:ListItem Text="-- Select --" Value="0" meta:resourcekey="ListItemResource4"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div>
                                <asp:Label ID="lblDivision" runat="server" Text="Division :" CssClass="textlabel"
                                    meta:resourcekey="lblDivisionResource1"></asp:Label>
                                <asp:DropDownList ID="ddlDivision" runat="server" AutoPostBack="True" meta:resourcekey="ddlDivisionResource1"
                                    Width="140px">
                                    <asp:ListItem Text="--Select--" Value="0" meta:resourcekey="ListItemResource5"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div id="Subj" runat="server" visible="false">
                                <asp:Label ID="lblsubject" runat="server" Text="Subject :" CssClass="textlabel" meta:resourcekey="lblsubjectResource1"></asp:Label>
                                <asp:DropDownList ID="ddlsubject" runat="server" AppendDataBoundItems="True" Enabled="False"
                                    AutoPostBack="True" OnSelectedIndexChanged="ddlsubject_SelectedIndexChanged"
                                    meta:resourcekey="ddlsubjectResource1" Width="140px">
                                    <asp:ListItem Text="-- Select --" Value="0" meta:resourcekey="ListItemResource6"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div>
                                <asp:Label ID="lblfrmdate" runat="server" Text="From date :" CssClass="textlabel"
                                    meta:resourcekey="lblfrmdateResource1"></asp:Label>
                                <asp:TextBox ID="txtfromdate" runat="server" meta:resourcekey="txtfromdateResource1"
                                    CssClass="textBoxCls"></asp:TextBox>
                                    <%--<asp:ImageButton ID="ibtnDate" runat="server"
                                        ImageUrl="~/App_Themes/Images/calendar12.png" Width="20px" meta:resourcekey="ibtnDateResource1" />--%>
                                        <asp:RequiredFieldValidator
                                            ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtfromdate" ValidationGroup="a"
                                            ErrorMessage="Please enter From date" meta:resourcekey="RequiredFieldValidator1Resource1">*</asp:RequiredFieldValidator>
                                <cc2:CalendarExtender ID="ceDate" runat="server" Format="dd-MMM-yyyy" TargetControlID="txtfromdate"
                                    PopupButtonID="ibtnDate" Enabled="True">
                                </cc2:CalendarExtender>
                            </div>
                            <div>
                                <asp:Label ID="lbltodate" runat="server" Text="To date :" CssClass="textlabel" meta:resourcekey="lbltodateResource1"></asp:Label>
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
                                <asp:Button ID="btnReset" runat="server" Text="Reset" OnClick="btnReset_Click" meta:resourcekey="btnResetResource1"
                                    Width="106px" />
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                    ShowSummary="False" ValidationGroup="a" meta:resourcekey="ValidationSummary1Resource1" />
                            </div>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlSchool" />
                        <asp:AsyncPostBackTrigger ControlID="ddlBoard" />
                        <asp:AsyncPostBackTrigger ControlID="ddlMedium" />
                        <asp:AsyncPostBackTrigger ControlID="ddlStandard" />
                        <asp:AsyncPostBackTrigger ControlID="ddlDivision" />
                        <asp:AsyncPostBackTrigger ControlID="ddlsubject" />
                        <asp:PostBackTrigger ControlID="btnview" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
        <div class="sidepanel1">
            <div class="activitydivside1">
                <div class="ActivityHeader">
                    <asp:Label ID="lblTitleSecond" runat="server" Text="Student Subject result report"
                        Visible="False" meta:resourcekey="lblTitleSecondResource1"></asp:Label>
                    <asp:Label ID="lblTitleThird" runat="server" Text="Subject all exam result report"
                        Visible="False" meta:resourcekey="lblTitleThirdResource1"></asp:Label>
                </div>
                <div class="ActivityContent" id="secondRpt" runat="server" visible="false">
                    <div class="subactiviycontent">
                        <div>
                            <asp:Label ID="slblSchool" runat="server" Text="School :" CssClass="textlabel" ToolTip="School Name :"
                                meta:resourcekey="slblSchoolResource1"></asp:Label>
                            <asp:Label ID="slblSchoolValue" runat="server" CssClass="controllabel" meta:resourcekey="slblSchoolValueResource1"></asp:Label>
                        </div>
                        <div>
                            <asp:Label ID="slblBoard" runat="server" Text="Board :" CssClass="textlabel" ToolTip="Board"
                                meta:resourcekey="slblBoardResource1"></asp:Label>
                            <asp:Label ID="slblBoardValue" runat="server" CssClass="controllabel" ToolTip="Board"
                                meta:resourcekey="slblBoardValueResource1"></asp:Label>
                        </div>
                        <div>
                            <asp:Label ID="slblMedium" runat="server" Text="Medium :" CssClass="textlabel" meta:resourcekey="slblMediumResource1"></asp:Label>
                            <asp:Label ID="slblMediumValue" runat="server" CssClass="controllabel" meta:resourcekey="slblMediumValueResource1"></asp:Label>
                        </div>
                        <div>
                            <asp:Label ID="slblStandard" runat="server" Text="Standard :" CssClass="textlabel"
                                meta:resourcekey="slblStandardResource1"></asp:Label>
                            <asp:Label ID="slblStandardValue" runat="server" CssClass="controllabel" meta:resourcekey="slblStandardValueResource1"></asp:Label>
                        </div>
                    </div>
                    <div class="subactiviycontent">
                        <div>
                            <asp:Label ID="slblstudent" runat="server" Text="Student :" CssClass="textlabel"
                                meta:resourcekey="slblstudentResource1"></asp:Label>
                            <asp:Label ID="slblstudentValue" runat="server" CssClass="controllabel" meta:resourcekey="slblstudentValueResource1"></asp:Label>
                        </div>
                        <div>
                            <asp:Label ID="slblFromDate" runat="server" Text="From Date :" CssClass="textlabel"
                                meta:resourcekey="slblFromDateResource1"></asp:Label>
                            <asp:Label ID="slblFromDateValue" runat="server" CssClass="controllabel" meta:resourcekey="slblFromDateValueResource1"></asp:Label>
                        </div>
                        <div>
                            <asp:Label ID="slblToDate" runat="server" Text="To Date :" CssClass="textlabel" meta:resourcekey="slblToDateResource1"></asp:Label>
                            <asp:Label ID="slblToDateValue" runat="server" CssClass="controllabel" meta:resourcekey="slblToDateValueResource1"></asp:Label>
                        </div>
                        <div>
                            <asp:Label ID="slblPerc" runat="server" Text="Percentage :" CssClass="textlabel"
                                meta:resourcekey="slblPercResource1"></asp:Label>
                            <asp:Label ID="slblPercValue" runat="server" CssClass="controllabel" meta:resourcekey="slblPercValueResource1"></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="ActivityContent" id="thirdRpt" runat="server" visible="false">
                    <div class="subactiviycontent">
                        <div>
                            <asp:Label ID="tlblSchool" runat="server" Text="School :" CssClass="textlabel" ToolTip="School Name :"
                                meta:resourcekey="tlblSchoolResource1"></asp:Label>
                            <asp:Label ID="tlblSchoolValue" runat="server" CssClass="controllabel" meta:resourcekey="tlblSchoolValueResource1"></asp:Label>
                        </div>
                        <div>
                            <asp:Label ID="tlblBoard" runat="server" Text="Board :" CssClass="textlabel" ToolTip="Board"
                                meta:resourcekey="tlblBoardResource1"></asp:Label>
                            <asp:Label ID="tlblBoardValue" runat="server" CssClass="controllabel" ToolTip="Board"
                                meta:resourcekey="tlblBoardValueResource1"></asp:Label>
                        </div>
                        <div>
                            <asp:Label ID="tlblMedium" runat="server" Text="Medium :" CssClass="textlabel" meta:resourcekey="tlblMediumResource1"></asp:Label>
                            <asp:Label ID="tlblMediumValue" runat="server" CssClass="controllabel" meta:resourcekey="tlblMediumValueResource1"></asp:Label>
                        </div>
                        <div>
                            <asp:Label ID="tlblStandard" runat="server" Text="Standard :" CssClass="textlabel"
                                meta:resourcekey="tlblStandardResource1"></asp:Label>
                            <asp:Label ID="tlblStandardValue" runat="server" CssClass="controllabel" meta:resourcekey="tlblStandardValueResource1"></asp:Label>
                        </div>
                        <div>
                            <asp:Label ID="tlblsubject" runat="server" Text="Subject :" CssClass="textlabel"
                                meta:resourcekey="tlblsubjectResource1"></asp:Label>
                            <asp:Label ID="tlblsubjectValue" runat="server" CssClass="controllabel" meta:resourcekey="tlblsubjectValueResource1"></asp:Label>
                        </div>
                    </div>
                    <div class="subactiviycontent">
                        <div>
                            <asp:Label ID="tlblteacher" runat="server" Text="Teacher :" CssClass="textlabel"
                                meta:resourcekey="tlblteacherResource1"></asp:Label>
                            <asp:Label ID="tlblteacherValue" runat="server" CssClass="controllabel" meta:resourcekey="tlblteacherValueResource1"></asp:Label>
                        </div>
                        <div>
                            <asp:Label ID="tlblStudent" runat="server" Text="Student :" CssClass="textlabel"
                                meta:resourcekey="tlblStudentResource1"></asp:Label>
                            <asp:Label ID="tlblStudentValue" runat="server" CssClass="controllabel" meta:resourcekey="tlblStudentValueResource1"></asp:Label>
                        </div>
                        <div>
                            <asp:Label ID="tlblFromDate" runat="server" Text="From Date :" CssClass="textlabel"
                                meta:resourcekey="tlblFromDateResource1"></asp:Label>
                            <asp:Label ID="tlblFromDateValue" runat="server" CssClass="controllabel" meta:resourcekey="tlblFromDateValueResource1"></asp:Label>
                        </div>
                        <div>
                            <asp:Label ID="tlblToDate" runat="server" Text="To Date :" CssClass="textlabel" meta:resourcekey="tlblToDateResource1"></asp:Label>
                            <asp:Label ID="tlblToDateValue" runat="server" CssClass="controllabel" meta:resourcekey="tlblToDateValueResource1"></asp:Label>
                        </div>
                        <div>
                            <asp:Label ID="tlblPerc" runat="server" Text="Percentage :" CssClass="textlabel"
                                meta:resourcekey="tlblPercResource1"></asp:Label>
                            <asp:Label ID="tlblPercValue" runat="server" CssClass="controllabel" meta:resourcekey="tlblPercValueResource1"></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="ActivityContent" id="fourthRpt" runat="server" visible="false">
                    <div class="subactiviycontent">
                        <div>
                            <asp:Label ID="flblSchool" runat="server" Text="School :" CssClass="textlabel" ToolTip="School Name :"
                                meta:resourcekey="flblSchoolResource1"></asp:Label>
                            <asp:Label ID="flblSchoolValue" runat="server" CssClass="controllabel" meta:resourcekey="flblSchoolValueResource1"></asp:Label>
                        </div>
                        <div>
                            <asp:Label ID="flblBoard" runat="server" Text="Board :" CssClass="textlabel" ToolTip="Board"
                                meta:resourcekey="flblBoardResource1"></asp:Label>
                            <asp:Label ID="flblBoardValue" runat="server" CssClass="controllabel" ToolTip="Board"
                                meta:resourcekey="flblBoardValueResource1"></asp:Label>
                        </div>
                        <div>
                            <asp:Label ID="flblMedium" runat="server" Text="Medium :" CssClass="textlabel" meta:resourcekey="flblMediumResource1"></asp:Label>
                            <asp:Label ID="flblMediumValue" runat="server" CssClass="controllabel" meta:resourcekey="flblMediumValueResource1"></asp:Label>
                        </div>
                        <div>
                            <asp:Label ID="flblStandard" runat="server" Text="Standard :" CssClass="textlabel"
                                meta:resourcekey="flblStandardResource1"></asp:Label>
                            <asp:Label ID="flblStandardValue" runat="server" CssClass="controllabel" meta:resourcekey="flblStandardValueResource1"></asp:Label>
                        </div>
                        <div>
                            <asp:Label ID="flblsubject" runat="server" Text="Subject :" CssClass="textlabel"
                                meta:resourcekey="flblsubjectResource1"></asp:Label>
                            <asp:Label ID="flblsubjectValue" runat="server" CssClass="controllabel" meta:resourcekey="flblsubjectValueResource1"></asp:Label>
                        </div>
                        <div>
                            <asp:Label ID="flblChapter" runat="server" Text="Chapter :" CssClass="textlabel"
                                meta:resourcekey="flblChapterResource1"></asp:Label>
                            <asp:Label ID="flblChapterValue" runat="server" CssClass="controllabel" meta:resourcekey="flblChapterValueResource1"></asp:Label>
                        </div>
                        <div>
                            <asp:Label ID="flbltopic" runat="server" Text="Topic :" CssClass="textlabel" meta:resourcekey="flbltopicResource1"></asp:Label>
                            <asp:Label ID="flbltopicValue" runat="server" CssClass="controllabel" meta:resourcekey="flbltopicValueResource1"></asp:Label>
                        </div>
                    </div>
                    <div class="subactiviycontent">
                        <div>
                            <asp:Label ID="flblDate" runat="server" Text="Date :" CssClass="textlabel" meta:resourcekey="flblDateResource1"></asp:Label>
                            <asp:Label ID="flblDateValue" runat="server" CssClass="controllabel" meta:resourcekey="flblDateValueResource1"></asp:Label>
                        </div>
                        <div>
                            <asp:Label ID="flblteacher" runat="server" Text="Teacher :" CssClass="textlabel"
                                meta:resourcekey="flblteacherResource1"></asp:Label>
                            <asp:Label ID="flblteacherValue" runat="server" CssClass="controllabel" meta:resourcekey="flblteacherValueResource1"></asp:Label>
                        </div>
                        <div>
                            <asp:Label ID="flblStudent" runat="server" Text="Student :" CssClass="textlabel"
                                meta:resourcekey="flblStudentResource1"></asp:Label>
                            <asp:Label ID="flblStudentValue" runat="server" CssClass="controllabel" meta:resourcekey="flblStudentValueResource1"></asp:Label>
                        </div>
                        <div>
                            <asp:Label ID="flblTrueAns" runat="server" Text="True Ans :" CssClass="textlabel"
                                meta:resourcekey="flblTrueAnsResource1"></asp:Label>
                            <asp:Label ID="flblTrueAnsValue" runat="server" CssClass="controllabel" meta:resourcekey="flblTrueAnsValueResource1"></asp:Label>
                        </div>
                        <div>
                            <asp:Label ID="flblFalseAns" runat="server" Text="False Ans :" CssClass="textlabel"
                                meta:resourcekey="flblFalseAnsResource1"></asp:Label>
                            <asp:Label ID="flblFalseAnsValue" runat="server" CssClass="controllabel" meta:resourcekey="flblFalseAnsValueResource1"></asp:Label>
                        </div>
                        <div>
                            <asp:Label ID="flblResult" runat="server" Text="Result (%) :" CssClass="textlabel"
                                meta:resourcekey="flblResultResource1"></asp:Label>
                            <asp:Label ID="flblResultValue" runat="server" CssClass="controllabel" meta:resourcekey="flblResultValueResource1"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
            <div class="activitydivside1" style="margin-top: 15px;">
                <div class="ActivityHeader">
                </div>
                <div class="ActivityContent" id="userControlDv" runat="server" visible="true">
                    <uc1:WebUserControl ID="WebUserControl1" runat="server" Visible="False" />
                    <asp:Chart ID="Chart1" runat="server" Visible="false">
                        <Series>
                            <asp:Series Name="Series1">
                            </asp:Series>
                        </Series>
                        <ChartAreas>
                            <asp:ChartArea Name="ChartArea1">
                            </asp:ChartArea>
                        </ChartAreas>
                    </asp:Chart>
                </div>
            </div>
            <div class="activitydivside1">
                <div class="ActivityHeader">
                    <asp:Label ID="lblTitleFourth" runat="server" Text="Exam Detail summary" Visible="true"
                        meta:resourcekey="lblTitleFourthResource1"></asp:Label>
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
                                    <asp:Label ID="lbluserScoreValue" runat="server" ForeColor="#484CE2" Font-Bold="True"
                                        Text="Label" meta:resourcekey="lbluserScoreValueResource1"></asp:Label><br />
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
    <!-- LoaderPart -->
    <asp:Button ID="btnLoader" runat="server" Style="display: none" />
    <asp:Button ID="btnCancel" runat="server" Style="display: none" />
    <cc1:ModalPopupExtender ID="ModalPopup" runat="server" PopupControlID="dvPopup" CancelControlID="btnCancel"
        TargetControlID="btnLoader" BackgroundCssClass="modalBackground" Enabled="True">
    </cc1:ModalPopupExtender>
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
