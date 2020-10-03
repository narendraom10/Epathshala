<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Epathshala.master" AutoEventWireup="true"
    EnableEventValidation="false" CodeFile="SchoolwiseStudentGenderReportNew.aspx.cs"
    Inherits="Report_SchoolwiseStudentGenderReportNew" Culture="auto" meta:resourcekey="PageResource1"
    UICulture="auto" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1"  %>
<%@ Register Src="~/UserControl/ReportControl.ascx" TagName="ReportControl" TagPrefix="uc1"  %>
<%@ Register Src="~/UserControl/StudentDetail.ascx" TagName="STD" TagPrefix="st1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style1
        {
            width: 89px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="tblDashboard">
        <div class="sidepanel">
            <div class="activitydivside" id="GenderwiseReport1" runat="server" visible="true">
                <div class="ActivityHeader">
                    <asp:Label ID="lblTitleFirst" runat="server" Text="Genderwise student report for this academic year"
                        meta:resourcekey="lblTitleFirstResource1"></asp:Label>
                </div>
                <asp:UpdatePanel runat="server" ID="upTopics" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="ActivityContent">
                            <div>
                                <asp:Label ID="lblFirstSchool" runat="server" Text="School:" meta:resourcekey="lblFirstSchoolResource1"></asp:Label>
                                <asp:DropDownList ID="ddlSchool" runat="server" Width="100%" AutoPostBack="True"
                                    meta:resourcekey="ddlSchoolResource1">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="ReqFieldSchool" runat="server" ErrorMessage="Please select school."
                                    ValidationGroup="a" ControlToValidate="ddlSchool" InitialValue="0" meta:resourcekey="ReqFieldSchoolResource1">*</asp:RequiredFieldValidator>
                            </div>
                            <div>
                                <asp:Button ID="btnViewReport" runat="server" Text="View Report" CssClass="gobutton"
                                    OnClick="btnViewReport_Click" meta:resourcekey="btnViewReportResource1" ValidationGroup="a" />
                                <asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="gobutton" OnClick="btnReset_Click"
                                    meta:resourcekey="btnResetResource1" />
                            </div>
                            <div>
                                <asp:Label ID="lblSchoolFirst" runat="server" Text="School:" Visible="False" meta:resourcekey="lblSchoolFirstResource1"></asp:Label>
                                <asp:Label ID="lblSchoolValueFirst" runat="server" meta:resourcekey="lblSchoolValueFirstResource1"></asp:Label>
                            </div>
                            <asp:ValidationSummary ID="ValSumSYS_Medium" runat="server" ShowMessageBox="true"
                                ShowSummary="false" ValidationGroup="a" />
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlSchool" />
                        <asp:PostBackTrigger ControlID="btnViewReport" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
        <div class="sidepanel1">
            <div class="activitydivside1">
                <div class="ActivityHeader">
                    <asp:Label ID="lblTitleSecond" runat="server" Text="Board Medium Standardwise student gender details"
                        Visible="False" meta:resourcekey="lblTitleSecondResource1"></asp:Label>
                    <asp:Label ID="lblTitleThird" runat="server" Text="Board Medium Standard Divisionwise student gender details"
                        Visible="False" meta:resourcekey="lblTitleThirdResource1"></asp:Label>
                </div>
                <div class="ActivityContent" id="GenderwiseReport2" runat="server" visible="false">
                    <div style="display: inline-block;">
                        <asp:Label ID="lblSchoolSecond" runat="server" Text="School:" CssClass="textlabel"
                            meta:resourcekey="lblSchoolSecondResource1"></asp:Label>
                        <asp:Label ID="lblSchoolValueSecond" runat="server" CssClass="controllabel" meta:resourcekey="lblSchoolValueSecondResource1"></asp:Label>
                    </div>
                   
                            <div>
                                <asp:Label ID="lblBoardSecond" runat="server" Text="Board:" CssClass="textlabel"
                                    meta:resourcekey="lblBoardSecondResource1"></asp:Label>
                                <asp:DropDownList ID="ddlBoardSecond" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlBoardSecond_SelectedIndexChanged"
                                    meta:resourcekey="ddlBoardSecondResource1">
                                    <asp:ListItem Value="0" Text="-- Select --" meta:resourcekey="ListItemResource1"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div>
                                <asp:Label ID="lblMediumSecond" runat="server" Text="Medium:" CssClass="textlabel"
                                    meta:resourcekey="lblMediumSecondResource1"></asp:Label>
                                <asp:DropDownList ID="ddlMediumSecond" runat="server" AutoPostBack="True" Enabled="False"
                                    OnSelectedIndexChanged="ddlMediumSecond_SelectedIndexChanged" meta:resourcekey="ddlMediumSecondResource1">
                                    <asp:ListItem Value="0" Text="-- Select --" meta:resourcekey="ListItemResource2"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div>
                                <asp:Label ID="lblStandardSecond" runat="server" Text="Standard:" CssClass="textlabel"
                                    meta:resourcekey="lblStandardSecondResource1"></asp:Label>
                                <asp:DropDownList ID="ddlStandardSecond" runat="server" AutoPostBack="True" Enabled="False"
                                    meta:resourcekey="ddlStandardSecondResource1">
                                    <asp:ListItem Value="0" Text="-- Select --" meta:resourcekey="ListItemResource3"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                     
                    <div>
                        <asp:Label ID="lblYearSecond" runat="server" Text="Year:" CssClass="textlabel" meta:resourcekey="lblYearSecondResource1"></asp:Label>
                        <asp:Label ID="lblYearValueSecond" runat="server" CssClass="controllabel" meta:resourcekey="lblYearValueSecondResource1"></asp:Label>
                    </div>
                    <div class="gobotton">
                        <asp:Button ID="btnViewReportSecond" runat="server" Text="View Report" CssClass="gobutton"
                            OnClick="btnViewReportSecond_Click" meta:resourcekey="btnViewReportSecondResource1" />
                        <asp:Button ID="btnResetSecond" runat="server" Text="Reset" CssClass="gobutton" OnClick="btnResetSecond_Click"
                            meta:resourcekey="btnResetSecondResource1" />
                    </div>
                </div>
            <div class="ActivityContent" id="GenderwiseReport3" runat="server" visible="false">
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
                    <asp:Label ID="lblDivisionThird" runat="server" Text="Division:" CssClass="textlabel"
                        meta:resourcekey="lblDivisionThirdResource1"></asp:Label>
                    <asp:Label ID="lblDivisionValueThird" runat="server" CssClass="controllabel" meta:resourcekey="lblDivisionValueThirdResource1"></asp:Label>
                </div>
                <div>
                    <asp:Label ID="lblYearThird" runat="server" Text="Year:" CssClass="textlabel" meta:resourcekey="lblYearThirdResource1"></asp:Label>
                    <asp:Label ID="lblYearValueThird" runat="server" CssClass="controllabel" Text="Year:"
                        meta:resourcekey="lblYearThirdResource1"></asp:Label>
                </div>
            </div>
            </div>
            <div id="userControlDiv" runat="server" class="activitydivside1" visible="true" style="margin-top: 15px;">
                <div class="ActivityHeader">
                    <asp:Label ID="Label1" runat="server" Text="Report"></asp:Label>
                </div>
                <div class="ActivityContent">
                    <uc1:ReportControl ID="SchoolwiseStudentGenderGrid" runat="server" Visible="False" />
                    <uc1:ReportControl ID="BMSwiseStudentGender" runat="server" Visible="False" />
                    <uc1:ReportControl ID="BMSwiseStudentList" runat="server" Visible="False" />
                </div>
            </div>
            <div style="width: 100px; margin: auto;">
                <asp:Button ID="btnBack" runat="server" Text="Back" Visible="False" OnClick="btnBack_Click"
                    meta:resourcekey="btnBackResource1" />
            </div>
        </div>
    </div>
    <asp:Button ID="btnShow" runat="server" Text="Show Modal Popup" Style="display: none"
        meta:resourcekey="btnShowResource1" />
    <!-- ModalPopupExtender -->
    <cc1:ModalPopupExtender ID="mpStudent" runat="server" PopupControlID="pnlStudentDetails"
        TargetControlID="btnShow" BackgroundCssClass="modalBackground" DynamicServicePath=""
        Enabled="True">
    </cc1:ModalPopupExtender>
    <!-- ModalPopupExtender -->
    <asp:Panel ID="pnlSelectBMS" runat="server" CssClass="modalPopup RoundTop" Style="display: none;"
        meta:resourcekey="pnlSelectBMSResource1">
        <table id="pnlStudentDetails" runat="server" class="modalPopup InnerTableStyle tblControls"
            style="display: none;" cellpadding="0" cellspacing="0" width="100%">
            <tr style="width: 100%;" runat="server">
                <td style="text-align: center; font-size: 20px; font-weight: bold;" class="Header12"
                    runat="server">
                    <asp:Label ID="lblTitle1" runat="server" Text="Student Details"></asp:Label>
                </td>
                <td style="text-align: right; width: 5px;" class="Header" runat="server">
                    <%--<asp:ImageButton ID="ibtnClose" runat="server" CausesValidation="False" ImageUrl="~/App_Themes/Images/btn_close_up.png"
                        Height="12px"  />--%>
                </td>
            </tr>
            <tr runat="server">
                <td colspan="2" runat="server">
                    <st1:STD ID="std" runat="server" />
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:Button ID="btnClose" runat="server" Text="Close" OnClick="ibtnClose_Click" />
                </td>
            </tr>
        </table>
    </asp:Panel>
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
