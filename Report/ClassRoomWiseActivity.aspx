<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Epathshala.master" AutoEventWireup="true"
    CodeFile="ClassRoomWiseActivity.aspx.cs" EnableEventValidation="false" Inherits="Report_ClassRoomWiseActivity"
    Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="../UserControl/ReportControl.ascx" TagName="ReportControl" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   <%-- <asp:UpdatePanel runat="server" ID="upTopics" UpdateMode="Conditional">
        <ContentTemplate>--%>
            <div class="tblDashboard">
                <div class="sidepanel">
                    <div class="activitydivside">
                        <div class="ActivityHeader">
                            <asp:Label ID="lblTitle" runat="server" Text="Class room wise track report"
                                meta:resourcekey="lblTitleResource1"></asp:Label>
                        </div>
                        <div class="ActivityContent" id="FirstRpt" runat="server" visible="true">
                            <div>
                                <asp:Label ID="lblSchool" runat="server" Text="School:" CssClass="textlabel" meta:resourcekey="lblSchoolResource1"></asp:Label>
                                <asp:DropDownList ID="ddlSchool" runat="server" Width="140px" AutoPostBack="True"
                                    ValidationGroup="a" 
                                    OnSelectedIndexChanged="ddlSchool_SelectedIndexChanged" 
                                    meta:resourcekey="ddlSchoolResource1">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RFVddlSchool" runat="server" ErrorMessage="Please Select School."
                                    ControlToValidate="ddlSchool" ValidationGroup="a" InitialValue="0" meta:resourcekey="RFVddlSchoolResource1">*</asp:RequiredFieldValidator>
                            </div>
                            <div>
                                <asp:Label ID="lblBoard" runat="server" Text="Board:" CssClass="textlabel" meta:resourcekey="lblBoardResource1"></asp:Label>
                                <asp:DropDownList ID="ddlBoard" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlBoard_SelectedIndexChanged"
                                    Enabled="False" Style="height: 22px" meta:resourcekey="ddlBoardResource1" 
                                    Width="140px">
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
                            <div>
                                <asp:Label ID="lblFdate" runat="server" Text="From Date:" CssClass="textlabel" meta:resourcekey="lblFdateResource1"></asp:Label>
                                <asp:TextBox ID="txtFdate" runat="server" Width="125px" meta:resourcekey="txtFdateResource1"
                                    CssClass="textBoxCls"></asp:TextBox>
                                <asp:ImageButton ID="ibtnStartDate" runat="server" ImageUrl="~/App_Themes/Images/calendar12.png"
                                    Width="20px" meta:resourcekey="ibtnStartDateResource1" />
                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFdate"
                                    PopupButtonID="ibtnStartDate" Enabled="True" Format="dd-MMM-yyyy">
                                </cc1:CalendarExtender>
                            </div>
                            <div>
                                <asp:Label ID="lblTdate" runat="server" Text="To Date:" CssClass="textlabel" meta:resourcekey="lblTdateResource1"></asp:Label>
                                <asp:TextBox ID="txtTodate" runat="server" Width="125px" meta:resourcekey="txtTodateResource1"
                                    CssClass="textBoxCls"></asp:TextBox>
                                <asp:ImageButton ID="ibtnEndDate" runat="server" ImageUrl="~/App_Themes/Images/calendar12.png"
                                    Width="20px" meta:resourcekey="ibtnEndDateResource1" />
                                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtTodate"
                                    PopupButtonID="ibtnEndDate" Enabled="True" Format="dd-MMM-yyyy">
                                </cc1:CalendarExtender>
                            </div>
                            <div class="gobotton">
                                <asp:Button ID="btnViewReport" runat="server" Text="ViewReport" OnClick="btnGo_Click"
                                    CssClass="gobutton" ValidationGroup="a" meta:resourcekey="btnViewReportResource1" />
                                <asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="gobutton" OnClick="btnReset_Click"
                                    meta:resourcekey="btnResetResource1" />
                            </div>
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                ShowSummary="False" ValidationGroup="a" meta:resourcekey="ValidationSummary1Resource1" />
                        </div>
                    </div>
                </div>
                <div class="sidepanel1">
                    <div>
                        <div class="activitydivside1" id="secondRpt" runat="server" visible="false">
                            <div class="ActivityHeader">
                                <asp:Label ID="Label1" runat="server" Text="Detail"></asp:Label>
                            </div>
                            <div class="ActivityContent">
                                <div class="subactiviycontent">
                                    <div>
                                        <asp:Label ID="tlblSchool" runat="server" Text="School:" CssClass="textlabel" ToolTip="School Name"
                                            meta:resourcekey="tlblSchoolResource1"></asp:Label>
                                        <asp:Label ID="tlblSchoolValue" runat="server" CssClass="controllabel" meta:resourcekey="tlblSchoolValueResource1"></asp:Label>
                                    </div>
                                    <div>
                                        <asp:Label ID="tlblboard" runat="server" Text="Board:" CssClass="textlabel" ToolTip="Board"
                                            meta:resourcekey="tlblboardResource1"></asp:Label>
                                        <asp:Label ID="tlblboardValue" runat="server" CssClass="controllabel" ToolTip="Board"
                                            meta:resourcekey="tlblboardValueResource1"></asp:Label>
                                    </div>
                                    <div>
                                        <asp:Label ID="tlblmedium" runat="server" Text="Medium:" CssClass="textlabel" meta:resourcekey="tlblmediumResource1"></asp:Label>
                                        <asp:Label ID="tlblmediumValue" runat="server" CssClass="controllabel" meta:resourcekey="tlblmediumValueResource1"></asp:Label>
                                    </div>
                                    <div>
                                        <asp:Label ID="tlblStandard" runat="server" Text="Standard:" CssClass="textlabel"
                                            ToolTip="Standard" meta:resourcekey="tlblStandardResource1"></asp:Label>
                                        <asp:Label ID="tlblStandardValue" runat="server" CssClass="controllabel" ToolTip="Standard"
                                            meta:resourcekey="tlblStandardValueResource1"></asp:Label>
                                    </div>
                                    <div>
                                        <asp:Label ID="tlblSubject" runat="server" Text="Subject:" CssClass="textlabel" meta:resourcekey="tlblSubjectResource1"></asp:Label>
                                        <asp:Label ID="tlblSubjectValue" runat="server" CssClass="controllabel" meta:resourcekey="tlblSubjectValueResource1"></asp:Label>
                                    </div>
                                </div>
                                <div class="subactiviycontent">
                                    <div>
                                        <asp:Label ID="tlblChapter" runat="server" Text="Chapter:" CssClass="textlabel" ToolTip="Chapter"
                                            meta:resourcekey="tlblChapterResource1"></asp:Label>
                                        <asp:Label ID="tlblChapterValue" runat="server" CssClass="controllabel" ToolTip="Chapter"
                                            meta:resourcekey="tlblChapterValueResource1"></asp:Label>
                                    </div>
                                    <div>
                                        <asp:Label ID="tlblTopic" runat="server" Text="Topic:" CssClass="textlabel" meta:resourcekey="tlblTopicResource1"></asp:Label>
                                        <asp:Label ID="tlblTopicValue" runat="server" CssClass="controllabel" meta:resourcekey="tlblTopicValueResource1"></asp:Label>
                                    </div>
                                    <div>
                                        <asp:Label ID="tlblteacher" runat="server" Text="Teacher:" CssClass="textlabel" ToolTip="Teacher"
                                            meta:resourcekey="tlblteacherResource1"></asp:Label>
                                        <asp:Label ID="tlblTeacherValue" runat="server" CssClass="controllabel" ToolTip="Teacher"
                                            meta:resourcekey="tlblTeacherValueResource1"></asp:Label>
                                    </div>
                                    <div>
                                        <asp:Label ID="tlblDate" runat="server" Text="Date:" CssClass="textlabel" meta:resourcekey="tlblDateResource1"></asp:Label>
                                        <asp:Label ID="tlblDateValue" runat="server" CssClass="controllabel" meta:resourcekey="tlblDateValueResource1"></asp:Label>
                                    </div>
                                    <div>
                                        <asp:Label ID="tlblDuration" runat="server" Text="Duration:" CssClass="textlabel"
                                            meta:resourcekey="tlblDurationResource1"></asp:Label>
                                        <asp:Label ID="tlblDurationValue" runat="server" CssClass="controllabel" meta:resourcekey="tlblDurationValueResource1"></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="activitydivside1" style="margin-top: 15px;">
                            <div class="ActivityHeader">
                                <asp:Label ID="Label2" runat="server" Text="List"></asp:Label>
                            </div>
                            <div class="ActivityContent">
                                <uc1:ReportControl ID="ReportControl1" runat="server" Visible="false"/>
                                <uc1:ReportControl ID="ReportControl2" runat="server" Visible="True" />
                                <div id="div1" runat="server" visible="false">
                                </div>
                            </div>
                        </div>
                        <div style="width: 100px; margin: auto;">
                            <asp:Button ID="btnback" runat="server" Text="Back" OnClick="btnback_Click" Visible="False"
                                meta:resourcekey="btnbackResource1" />
                        </div>
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
            <asp:AsyncPostBackTrigger ControlID="ddlDivision" />
            <asp:AsyncPostBackTrigger ControlID="btnViewReport" />
        </Triggers>
    </asp:UpdatePanel>--%>
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
