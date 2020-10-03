<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Epathshala.master" AutoEventWireup="true"
    CodeFile="DemoStudentDashboard.aspx.cs" Inherits="Dashboard_DemoStudentDashboard" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/UserControl/StudentPanel.ascx" TagName="StudentPanel" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .tblDashboard tr td
        {
            vertical-align: top;
            text-align: left;
            padding: 3px;
        }
        
        .tblDashboard .Header
        {
            color: #096B6B;
            text-align: center;
            padding: 5px;
            margin: 25px;
        }
        
        
        .tblDashboard .LeftPart
        {
            padding-right: 15px;
        }
        
        .Width300
        {
            min-width: 300px;
            max-width: 300px;
        }
        .Width700
        {
            min-width: 700px;
            max-width: 700px;
        }
        
        .Width1000px
        {
            min-width: 1000px;
            max-width: 1000px;
            max-height: 700px;
        }
        
        .MarginBottom15px
        {
            margin-bottom: 15px;
        }
        
        .RBPadding
        {
            padding: 15px;
            width: 100%;
        }
        
        
        .RBPadding input[type="radio"]
        {
            margin: 3px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="width: 90%; margin: auto; position: relative;">
        <div class="firstpanel">
            <div class="activitydiv activityleft">
                <div class="ActivityHeader">
                    <asp:Label ID="Label1" runat="server" Text="Select Subject"></asp:Label>
                </div>
                <%-- <uc1:StudentPanel ID="StudentPanel" runat="server" />--%>
                <asp:RadioButtonList ID="rbSubjectList" runat="server" RepeatDirection="Horizontal"
                    CssClass="RBPadding" RepeatColumns="3" AutoPostBack="True" CellSpacing="10" CellPadding="10"
                    OnSelectedIndexChanged="rbSubjectList_SelectedIndexChanged" meta:resourcekey="rbSubjectListResource1">
                </asp:RadioButtonList>
            </div>
            <div class="activitydiv activityright">
                <div class="ActivityHeader">
                    <asp:Label ID="lblTodayAct" runat="server" Text="Today's Activity" meta:resourcekey="lblTodayActResource1"></asp:Label>
                </div>
                <div class="ActivityContent">
                    <div class="radiobotton">
                        <asp:RadioButtonList ID="rblChapters" runat="server" RepeatDirection="Horizontal"
                            AutoPostBack="True" Visible="False" OnSelectedIndexChanged="rblChapters_SelectedIndexChanged"
                            meta:resourcekey="rblChaptersResource1">
                            <asp:ListItem Selected="True" Value="1" Text=" Uncovered Chapters" meta:resourcekey="lblListItem1"></asp:ListItem>
                            <asp:ListItem Value="2" Text=" Covered Chapters" meta:resourcekey="lblListItem2"></asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                    <div>
                        <asp:Label ID="lblChapter" runat="server" Text="Chapter:" meta:resourcekey="lblChapterResource1"
                            CssClass="textlabel"></asp:Label>
                        <asp:DropDownList ID="ddlChapter" runat="server" Width="180px" Enabled="False" AutoPostBack="True"
                            meta:resourcekey="ddlChapterResource1" OnSelectedIndexChanged="ddlChapter_SelectedIndexChanged1">
                            <asp:ListItem Text="-- Select --" meta:resourcekey="listItemResource1"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rqdddlChapter" runat="server" ControlToValidate="ddlChapter"
                            InitialValue="-- Select --" ErrorMessage="Please Select Chapter." ValidationGroup="TA"
                            meta:resourcekey="rqdddlChapterResource1">*</asp:RequiredFieldValidator>
                    </div>
                    <div>
                        <asp:Label ID="lblTopic" runat="server" Text="Topic:" meta:resourcekey="lblTopicResource1"
                            CssClass="textlabel"></asp:Label>
                        <asp:DropDownList ID="ddlTopic" runat="server" Width="180px" Enabled="False" meta:resourcekey="ddlTopicResource1">
                            <asp:ListItem Text="-- Select --" meta:resourcekey="ListItemResource2"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rqdddlTopic" runat="server" ControlToValidate="ddlTopic"
                            InitialValue="-- Select --" ErrorMessage="Please Select Topic." ValidationGroup="TA"
                            meta:resourcekey="rqdddlTopicResource1">*</asp:RequiredFieldValidator>
                    </div>
                    <div class="gobotton">
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" ValidationGroup="TA" CssClass="gobutton"
                            meta:resourcekey="btnSubmitResource1" OnClick="btnSubmit_Click" />
                        <asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="gobutton" OnClick="btnReset_Click"
                            meta:resourcekey="btnResetResource1" />
                        <asp:ValidationSummary ID="vsum" runat="server" ValidationGroup="TA" ShowMessageBox="True"
                            ShowSummary="False" meta:resourcekey="vsumResource1" />
                    </div>
                </div>
            </div>
        </div>
        <div class="firstpanel">
            <div class="activitydiv activityleft">
                <div class="ActivityHeader">
                    <asp:Label ID="lblSyllabus" runat="server" Text="Syllabus Covered" meta:resourcekey="lblSyllabusResource1"></asp:Label>
                </div>
                <div class="ActivityContent">
                    <div class="persentagetagbox">
                        <div class="persentagediv">
                            <asp:Label ID="lblCovered1" CssClass="persentage" runat="server" ForeColor="#009B32"></asp:Label>
                            <asp:Label runat="server" ID="LblCoveredChapter" CssClass="ApChartGreen" Height="25px"
                                ForeColor="White"></asp:Label><asp:Label runat="server" ID="LblUncoveredChapter"
                                    CssClass="ApChartRed" ForeColor="White" Height="25px"></asp:Label>
                            <asp:Label ID="lblUncovered1" runat="server" CssClass="persentage" ForeColor="#ED0000"></asp:Label>
                        </div>
                        <div class="lblcover">
                            <asp:Label ID="LblCoveredChapter1" runat="server" BackColor="Green" Width="10px"
                                Height="10px"></asp:Label>
                            <asp:Label ID="LblCoveredChapter2" runat="server" Text="Covered Chapters" Font-Size="14px"
                                meta:resourcekey="LblCoveredChapter2"></asp:Label>
                            <asp:Label ID="lblCovered" runat="server" Font-Size="14px" ForeColor="Green" Font-Names="Roboto-Black"></asp:Label>
                        </div>
                        <div class="lblcover">
                            <asp:Label ID="LblUncoveredChapter1" runat="server" BackColor="Red" Width="10px"
                                Height="10px"></asp:Label>
                            <asp:Label ID="LblUncoveredChapter2" runat="server" Text="Uncovered Chapters" Font-Size="14px"
                                meta:resourcekey="LblUncoveredChapter2"></asp:Label>
                            <asp:Label ID="lblUncovered" runat="server" Font-Size="14px" ForeColor="Red" Font-Names="Roboto-Black"></asp:Label>
                        </div>
                    </div>
                    <div class="chapterlist">
                        <asp:TreeView ID="tvSyllabus" runat="server" meta:resourcekey="tvSyllabusResource1"
                            OnSelectedNodeChanged="tvSyllabus_SelectedNodeChanged">
                            <HoverNodeStyle Font-Underline="false" ForeColor="#5555DD" />
                            <NodeStyle CssClass="Node" HorizontalPadding="5px" NodeSpacing="0px" VerticalPadding="0px" />
                            <ParentNodeStyle Font-Bold="False" />
                            <SelectedNodeStyle Font-Underline="false" ForeColor="#5555DD" HorizontalPadding="0px"
                                VerticalPadding="0px" />
                        </asp:TreeView>
                    </div>
                </div>
            </div>
            <div class="activitydiv activityright" style="margin-bottom: 15px;">
                <div class="ActivityHeader">
                    <asp:Label ID="Label3" runat="server" Text="Search Chapter"></asp:Label>
                </div>
                <div class="ActivityContent">
                    <div style="margin-top: 15px;">
                        <asp:Label ID="lblkeyword" runat="server" Text="Keyword:" Style="padding: 0px 0px 5px 5px;"></asp:Label>
                        <asp:TextBox ID="txtkeyword" CssClass="text" Style="padding: 0 5px; width: 90%;"
                            runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvkeyword" ValidationGroup="vgSearch" ControlToValidate="txtkeyword"
                            runat="server" ErrorMessage="*" Text="*"></asp:RequiredFieldValidator>
                    </div>
                    <div style="margin-top: 10px;">
                        <asp:Button ID="btnsearcksubmit" runat="server" Text="Search" ValidationGroup="vgSearch"
                            OnClick="btnsearcksubmit_Click" />
                        <asp:Button ID="BtnHome" runat="server" Text="Cancel" OnClientClick="javascript:return CloseSearch();" />
                    </div>
                    <div style="font-size: 10px; margin-top: 10px; padding-left: 10px; font-weight: bold;">
                        Search result based on Board, Medium, Standard, Subject, Chapter, Chapter Description
                        and Topic Name
                    </div>
                    <asp:ValidationSummary ID="vsSearch" ShowMessageBox="false" ShowSummary="false" ValidationGroup="vgSearch"
                        runat="server" />
                </div>
            </div>
            <div class="activitydiv activityright">
                <div class="ActivityHeader">
                    <asp:Label ID="lblLastActivity" runat="server" Text="Last Activity" meta:resourcekey="lblLastActivityResource1"></asp:Label>
                </div>
                <div class="ActivityContent">
                    <div>
                        <asp:Label ID="lblLastChapter" runat="server" Text="Chapter:" meta:resourcekey="lblLastChapterResource1"></asp:Label>
                        <asp:Label ID="lblLastChapterName" runat="server" Text="Chapter Name" meta:resourcekey="lblLastChapterNameResource1"></asp:Label>
                    </div>
                    <div>
                        <asp:Label ID="lblLastTopic" runat="server" Text="Topic:" meta:resourcekey="lblLastTopicResource1"></asp:Label>
                        <asp:Label ID="lblLastTopicName" runat="server" Text="Topic Name" meta:resourcekey="lblLastTopicNameResource1"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
        <div class="firstpanel">
            <div class="activitydiv activityleft" id="fsExpiryNotification" runat="server" visible="true">
                <div class="ActivityHeader">
                    <asp:Label ID="lblLegendExpiryNotification" runat="server" Text="Current Packages"></asp:Label>
                </div>
                <div class="ActivityContent">
                    <%--   <asp:Label ID="lblExpiryMessage" runat="server" Text="Follwing packages will expire in a couple of days."
                        meta:resourcekey="lblExpiryMessageResource1"></asp:Label>--%>
                    <div>
                        <asp:GridView ID="gvSubjectExpiryNotification" runat="server" Visible="true" AutoGenerateColumns="False"
                            meta:resourcekey="gvSubjectExpiryNotificationResource1">
                            <Columns>
                                <asp:BoundField DataField="Subject" HeaderText="Subject" />
                                <asp:BoundField DataField="PackageType" HeaderText="Package Type" />
                                <asp:BoundField DataField="FromDate" HeaderText="Activate On" DataFormatString="{0:dd-MMM-yyyy}" />
                                <asp:BoundField DataField="ValidTill" HeaderText="Expired On" DataFormatString="{0:dd-MMM-yyyy}" />
                            </Columns>
                        </asp:GridView>
                        <asp:GridView ID="gvComboExpiryNotification" runat="server" Visible="False" AutoGenerateColumns="False"
                            meta:resourcekey="gvComboExpiryNotificationResource1">
                            <Columns>
                                <asp:BoundField DataField="Standard" HeaderText="Standard" />
                                <asp:BoundField DataField="Name" HeaderText="Package Type" />
                                <asp:BoundField DataField="FromDate" HeaderText="Activate On" />
                                <asp:BoundField DataField="ValidTill" HeaderText="Expired On" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
            <div class="activitydiv activityright">
                <div class="ActivityHeader">
                    <asp:Label ID="Label2" runat="server" Text="Expired Packages"></asp:Label>
                </div>
                <div class="ActivityContent">
                    <asp:GridView ID="gvExpiredPackageList" runat="server" Visible="true" AutoGenerateColumns="False">
                        <Columns>
                            <asp:BoundField DataField="Subject" HeaderText="Subject" />
                            <asp:BoundField DataField="PackageType" HeaderText="Package Type" />
                            <asp:BoundField DataField="FromDate" HeaderText="Activate On" DataFormatString="{0:dd-MMM-yyyy}" />
                            <asp:BoundField DataField="ValidTill" HeaderText="Expired On" DataFormatString="{0:dd-MMM-yyyy}" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
            <div>
            </div>
        </div>
    </div>
    <asp:Button ID="btnTeacherResult" runat="server" Text="Show student test result"
        Style="display: none;" />
    <cc1:ModalPopupExtender ID="mpTestResult" runat="server" PopupControlID="Table1"
        TargetControlID="btnTeacherResult" CancelControlID="ibtnClose1" BackgroundCssClass="modalBackground"
        DynamicServicePath="" Enabled="True">
    </cc1:ModalPopupExtender>
    <asp:Panel ID="pnlSelectBMS" runat="server" CssClass="modalPopup RoundTop" Style="display: none;"
        meta:resourcekey="pnlSelectBMSResource1">
        <table id="Table1" runat="server" class="modalPopup RoundTop tblControls" style="display: none;"
            cellpadding="0" cellspacing="0">
            <tr>
                <td class="Header RoundTop" align="center" style="padding-bottom: 0;">
                    <asp:Label ID="lblTitle" runat="server" Text="Topicwise Test Result" meta:resourceKey="lblTitleResource1"></asp:Label>
                    <div style="float: right">
                        <asp:ImageButton ID="ibtnClose1" runat="server" Text="Close" CausesValidation="False"
                            meta:resourceKey="btnCloseResource1" ImageUrl="~/App_Themes/Images/btn_close_up.png"
                            Height="20px" Width="20px" />
                    </div>
                </td>
            </tr>
            <tr>
                <td align="center" class="InnerTableStyleResult">
                    <%--  <Test:StudentTestResult ID="ucTest" runat="server"></Test:StudentTestResult>--%>
                    <%--<iframe id="myframe" frameborder="0" style="margin: 0px; border: 0px none black;"
                        width="700px" height="450px" runat="server" src="StudentPreTestPostTestResult.aspx">
                    </iframe>--%>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
