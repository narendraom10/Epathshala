<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Epathshala.master" AutoEventWireup="true"
    CodeFile="ClasswiseCoveredSyllabusNew.aspx.cs" Inherits="Report_ClasswiseCoveredSyllabusNew"
    EnableEventValidation="false" Culture="auto" meta:resourcekey="PageResource1"
    UICulture="auto" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/UserControl/ReportControl.ascx" TagName="ReportControl" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="tblDashboard">
        <div class="sidepanel">
            <div class="activitydivside">
                <div class="ActivityHeader">
                    <asp:Label ID="lblFirstTitle" runat="server" Text="Classwise covered syllabus details"
                        meta:resourcekey="lblFirstTitleResource1"></asp:Label>
                </div>
                <div class="ActivityContent">
                    <asp:UpdatePanel runat="server" ID="upTopics" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div id="ClasswiseReport" runat="server" visible="true">
                                <div>
                                    <asp:Label ID="lblFirstSchool" runat="server" Text="School:" CssClass="textlabel"
                                        meta:resourcekey="lblFirstSchoolResource1"></asp:Label>
                                    <asp:DropDownList ID="ddlSchool" runat="server" Width="140px" AutoPostBack="True"
                                        OnSelectedIndexChanged="ddlSchool_SelectedIndexChanged" 
                                        meta:resourcekey="ddlSchoolResource1">
                                        <asp:ListItem Text="-- Select --"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="ReqFieldSchool" runat="server" ErrorMessage="Please select school."
                                        c ValidationGroup="a" ControlToValidate="ddlSchool" InitialValue="0" meta:resourcekey="ReqFieldSchoolResource1">*</asp:RequiredFieldValidator>
                                </div>
                                <div>
                                    <asp:Label ID="lblBoard" runat="server" Text="Board:" CssClass="textlabel" meta:resourcekey="lblBoardResource1"></asp:Label>
                                    <asp:DropDownList ID="ddlBoard" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlBoard_SelectedIndexChanged"
                                        Enabled="False" meta:resourcekey="ddlBoardResource1" Width="140px">
                                        <asp:ListItem Value="0" Text="-- Select --" meta:resourcekey="ListItemResource1"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div>
                                    <asp:Label ID="lblMedium" runat="server" Text="Medium:" CssClass="textlabel" meta:resourcekey="lblMediumResource1"></asp:Label>
                                    <asp:DropDownList ID="ddlMedium" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlMedium_SelectedIndexChanged"
                                        Enabled="False" meta:resourcekey="ddlMediumResource1" Width="140px">
                                        <asp:ListItem Value="0" Text="-- Select --" meta:resourcekey="ListItemResource2"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div>
                                    <asp:Label ID="lblStandard" runat="server" Text="Standard:" CssClass="textlabel"
                                        meta:resourcekey="lblStandardResource1"></asp:Label>
                                    <asp:DropDownList ID="ddlStandard" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlStandard_SelectedIndexChanged"
                                        Enabled="False" meta:resourcekey="ddlStandardResource1" Width="140px">
                                        <asp:ListItem Value="0" Text="-- Select --" meta:resourcekey="ListItemResource3"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div>
                                    <asp:Label ID="lblSubject" runat="server" Text="Subject:" CssClass="textlabel" meta:resourcekey="lblSubjectResource1"></asp:Label>
                                    <asp:DropDownList ID="ddlSubject" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSubject_SelectedIndexChanged"
                                        Enabled="False" meta:resourcekey="ddlSubjectResource1" Width="140px">
                                        <asp:ListItem Value="0" Text="-- Select --" meta:resourcekey="ListItemResource4"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div>
                                    <asp:Label ID="lblChapter" runat="server" Text="Chapter:" CssClass="textlabel" meta:resourcekey="lblChapterResource1"></asp:Label>
                                    <asp:DropDownList ID="ddlChapter" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlChapter_SelectedIndexChanged"
                                        Enabled="False" meta:resourcekey="ddlChapterResource1" Width="140px">
                                        <asp:ListItem Value="0" Text="-- Select --" meta:resourcekey="ListItemResource5"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div>
                                    <asp:Label ID="lblTopic" runat="server" Text="Topic:" CssClass="textlabel" meta:resourcekey="lblTopicResource1"></asp:Label>
                                    <asp:DropDownList ID="ddlTopic" runat="server" AutoPostBack="True" Enabled="False"
                                        OnSelectedIndexChanged="ddlTopic_SelectedIndexChanged" 
                                        meta:resourcekey="ddlTopicResource1" Width="140px">
                                        <asp:ListItem Value="0" Text="-- Select --" meta:resourcekey="ListItemResource6"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div>
                                    <asp:Label ID="lblDivision" runat="server" Text="Division:" CssClass="textlabel"
                                        meta:resourcekey="lblDivisionResource1"></asp:Label>
                                    <asp:DropDownList ID="ddlDivision" runat="server" AutoPostBack="True" Enabled="False"
                                        meta:resourcekey="ddlDivisionResource1" Width="140px">
                                        <asp:ListItem Value="0" Text="-- Select --" meta:resourcekey="ListItemResource7"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="gobotton">
                                    <asp:Button ID="btnViewReport" runat="server" Text="ViewReport" CssClass="gobutton"
                                        OnClick="btnViewReport_Click" meta:resourcekey="btnViewReportResource1" ValidationGroup="a" />
                                    <asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="gobutton" OnClick="btnReset_Click"
                                        meta:resourcekey="btnResetResource1" width="100px" />
                                </div>
                                <asp:ValidationSummary ID="ValSumSyllabus" runat="server" ShowMessageBox="true" ShowSummary="false"
                                    ValidationGroup="a" />
                            </div>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="ddlSchool" />
                            <asp:AsyncPostBackTrigger ControlID="ddlBoard" />
                            <asp:AsyncPostBackTrigger ControlID="ddlMedium" />
                            <asp:AsyncPostBackTrigger ControlID="ddlStandard" />
                            <asp:AsyncPostBackTrigger ControlID="ddlSubject" />
                            <asp:AsyncPostBackTrigger ControlID="ddlChapter" />
                            <asp:AsyncPostBackTrigger ControlID="ddlTopic" />
                            <asp:AsyncPostBackTrigger ControlID="ddlDivision" />
                            <asp:PostBackTrigger ControlID="btnViewReport" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
        <div class="sidepanel1" visible="False" meta:resourcekey="lblSecondTitleResource1">
            <div class="activitydivside1" id="SubjectwiseReport" runat="server" visible="false">
                <div class="ActivityHeader">
                    <asp:Label ID="lblSecondTitle" runat="server" Text="Subjectwise Syllabus Covered"></asp:Label>
                </div>
                <div class="activitycontent">
                    <div>
                        <asp:Label ID="lblSchoolSecond" runat="server" Text="School:" CssClass="textlabel"
                            meta:resourcekey="lblSchoolSecondResource1"></asp:Label>
                        <asp:Label ID="lblSchoolValueSecond" runat="server" CssClass="controllabel" meta:resourcekey="lblSchoolValueSecondResource1"></asp:Label>
                    </div>
                    <div>
                        <asp:Label ID="lblBMSSecond" runat="server" Text="BMS:" CssClass="textlabel" meta:resourcekey="lblBMSSecondResource1"></asp:Label>
                        <asp:Label ID="lblBMSValueSecond" runat="server" CssClass="controllabel" meta:resourcekey="lblBMSValueSecondResource1"></asp:Label>
                    </div>
                    <div>
                        <asp:Label ID="lblDivSecond" runat="server" Text="Division:" CssClass="textlabel"
                            meta:resourcekey="lblDivSecondResource1"></asp:Label>
                        <asp:Label ID="lblDivValueSecond" runat="server" CssClass="controllabel" meta:resourcekey="lblDivValueSecondResource1"></asp:Label>
                    </div>
                    <div>
                        <asp:Label ID="lblCoveredSyllabusSecond" runat="server" Text="Total Covered Syllabus:"
                            CssClass="textlabel" Style="width: 160px;" meta:resourcekey="lblCoveredSyllabusSecondResource1"></asp:Label>
                        <asp:Label ID="lblCoveredSyllabusValueSecond" CssClass="controllabel" runat="server"
                            meta:resourcekey="lblCoveredSyllabusValueSecondResource1"></asp:Label>
                    </div>
                </div>
            </div>
            <div class="activitydivside1" id="ChapterwiseReport" runat="server" visible="false">
                <div class="ActivityHeader">
                    <asp:Label ID="lblThirdTitle" runat="server" Text="Chapterwise covered syllabus details"
                        Visible="False" meta:resourcekey="lblThirdTitleResource1"></asp:Label>
                </div>
                <div class="ActivityContent">
                    <div>
                        <asp:Label ID="lblSchoolThird" runat="server" Text="School:" CssClass="textlabel"
                            meta:resourcekey="lblSchoolThirdResource1"></asp:Label>
                        <asp:Label ID="lblSchoolValueThird" runat="server" CssClass="controllabel" meta:resourcekey="lblSchoolValueThirdResource1"></asp:Label>
                    </div>
                    <div>
                        <asp:Label ID="lblBMSThird" runat="server" Text="BMS:" CssClass="textlabel" meta:resourcekey="lblBMSThirdResource1"></asp:Label>
                        <asp:Label ID="lblBMSValueThird" runat="server" CssClass="controllabel" meta:resourcekey="lblBMSValueThirdResource1"></asp:Label>
                    </div>
                    <div>
                        <asp:Label ID="lblDivThird" runat="server" Text="Division:" CssClass="textlabel"
                            meta:resourcekey="lblDivThirdResource1"></asp:Label>
                        <asp:Label ID="lblDivValueThird" runat="server" CssClass="controllabel" meta:resourcekey="lblDivValueThirdResource1"></asp:Label>
                    </div>
                    <div>
                        <asp:Label ID="lblSubjectThird" runat="server" Text="Subject:" CssClass="textlabel"
                            meta:resourcekey="lblSubjectThirdResource1"></asp:Label>
                        <asp:Label ID="lblSubjectValueThird" runat="server" CssClass="controllabel" meta:resourcekey="lblSubjectValueThirdResource1"></asp:Label>
                    </div>
                    <div>
                        <asp:Label ID="lblCoveredSyllabusThird" runat="server" Text="Total Covered Syllabus:"
                            CssClass="textlabel" Style="width: 160px;" meta:resourcekey="lblCoveredSyllabusThirdResource1"></asp:Label>
                        <asp:Label ID="lblCoveredSyllabusValueThird" runat="server" CssClass="controllabel"
                            meta:resourcekey="lblCoveredSyllabusValueThirdResource1"></asp:Label>
                    </div>
                </div>
            </div>
            <div class="activitydivside1" id="TopicwiseReport" runat="server" visible="false">
                <div class="ActivityHeader">
                    <asp:Label ID="lblForthTitle" runat="server" Text="Topicwise covered syllabus details"
                        Visible="False" meta:resourcekey="lblForthTitleResource1"></asp:Label>
                </div>
                <div class="ActivityContent">
                    <div class="subcontdiv">
                        <asp:Label ID="lblSchoolForth" runat="server" Text="School:" CssClass="textlabel"
                            meta:resourcekey="lblSchoolForthResource1"></asp:Label>
                        <asp:Label ID="lblSchoolValueForth" runat="server" CssClass="controllabel" meta:resourcekey="lblSchoolValueForthResource1"></asp:Label>
                    </div>
                    <div>
                        <asp:Label ID="lblBMSForth" runat="server" Text="BMS:" CssClass="textlabel" meta:resourcekey="lblBMSForthResource1"></asp:Label>
                        <asp:Label ID="lblBMSValueForth" runat="server" CssClass="controllabel" meta:resourcekey="lblBMSValueForthResource1"></asp:Label>
                    </div>
                    <div>
                        <asp:Label ID="lblDivForth" runat="server" Text="Division:" CssClass="textlabel"
                            meta:resourcekey="lblDivForthResource1"></asp:Label>
                        <asp:Label ID="lblDivValueForth" runat="server" CssClass="controllabel" meta:resourcekey="lblDivValueForthResource1"></asp:Label>
                    </div>
                    <div>
                        <asp:Label ID="lblSubjectForth" runat="server" Text="Subject:" CssClass="textlabel"
                            meta:resourcekey="lblSubjectForthResource1"></asp:Label>
                        <asp:Label ID="lblSubjectValueForth" runat="server" CssClass="controllabel" meta:resourcekey="lblSubjectValueForthResource1"></asp:Label>
                    </div>
                    <div>
                        <asp:Label ID="lblChapterForth" runat="server" Text="Chapter:" CssClass="textlabel"
                            meta:resourcekey="lblChapterForthResource1"></asp:Label>
                        <asp:Label ID="lblChapterValueForth" runat="server" CssClass="controllabel" meta:resourcekey="lblChapterValueForthResource1"></asp:Label>
                    </div>
                    <div>
                        <asp:Label ID="lblCoveredSyllabusForth" runat="server" Text="Total Covered Syllabus:"
                            CssClass="textlabel" Style="width: 160px;" meta:resourcekey="lblCoveredSyllabusForthResource1"></asp:Label>
                        <asp:Label ID="lblCoveredSyllabusValueForth" runat="server" CssClass="controllabel"
                            meta:resourcekey="lblCoveredSyllabusValueForthResource1"></asp:Label>
                    </div>
                </div>
            </div>
            <div id="userControlDiv" runat="server" visible="true" class="activitydivside1" style="margin-top: 15px;">
                <div class="ActivityHeader">
                    Report List
                </div>
                <div class="ActivityContent">
                    <uc1:ReportControl ID="ClasswiseSyllabusGrid" runat="server" Visible="False" />
                    <uc1:ReportControl ID="SubjectwiseSyllabusGrid" runat="server" Visible="false" />
                    <uc1:ReportControl ID="ChapterwiseSyllabusGrid" runat="server" Visible="False" />
                    <uc1:ReportControl ID="TopicwiseSyllabusGrid" runat="server" Visible="false" />
                </div>
            </div>
            <div style="width: 100px; margin: auto;">
                <asp:Button ID="btnBack" runat="server" Text="Back" Visible="False" OnClick="btnBack_Click"
                    meta:resourcekey="btnBackResource1" />
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
