<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Epathshala.master" AutoEventWireup="true"
    CodeFile="AgewiseStudentReportF.aspx.cs" Inherits="Report_AgewiseStudentReportF"
    EnableEventValidation="false" Culture="auto" UICulture="auto" meta:resourcekey="PageResource1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="../UserControl/ReportControl.ascx" TagName="ReportControl" TagPrefix="uc1" %>
<%@ Register Src="../UserControl/StudentDetail.ascx" TagName="STD" TagPrefix="st1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" src="../JavaScript/ASCIIMathML.js"></script>
    <script type="text/javascript" src="../JavaScript/jquery-1.4.2.js"></script>
    <style type="text/css">
        .style1
        {
            width: 248px;
        }
        .style2
        {
            width: 140px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="tbldashboard" id="ClasswiseReport" runat="server" visible="true">
        <div class="sidepanel">
            <div class="activitydivside">
                <div class="ActivityHeader">
                    <asp:Label ID="Label2" runat="server" Text="Agewise Student Report"></asp:Label>
                </div>
                <asp:UpdatePanel runat="server" ID="upTopics" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="ActivityContent" id="FirstRpt" runat="server" visible="true">
                            <div>
                                <asp:Label ID="lblSchool" runat="server" Text="School:" CssClass="textlabel" meta:resourcekey="lblSchoolResource1"></asp:Label>
                                <asp:DropDownList ID="ddlSchool" runat="server" Width="140px" AutoPostBack="True"
                                    OnSelectedIndexChanged="ddlSchool_SelectedIndexChanged" meta:resourcekey="ddlSchoolResource1">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RFVddlSchool" runat="server" ErrorMessage="Please Select School."
                                    ControlToValidate="ddlSchool" ValidationGroup="a" InitialValue="0" meta:resourcekey="RFVddlSchoolResource1">*</asp:RequiredFieldValidator>
                            </div>
                            <div>
                                <asp:Label ID="lblBoard" runat="server" Text="Board:" CssClass="textlabel" meta:resourcekey="lblBoardResource1"></asp:Label>
                                <asp:DropDownList ID="ddlBoard" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlBoard_SelectedIndexChanged"
                                    meta:resourcekey="ddlBoardResource1" Width="140px">
                                    <asp:ListItem Value="0" Text="-- Select --" meta:resourcekey="ListItemResource1"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div>
                                <asp:Label ID="lblMedium" runat="server" Text="Medium:" CssClass="textlabel" meta:resourcekey="lblMediumResource1"></asp:Label>
                                <asp:DropDownList ID="ddlMedium" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlMedium_SelectedIndexChanged"
                                    meta:resourcekey="ddlMediumResource1" Width="140px">
                                    <asp:ListItem Value="0" Text="-- Select --" meta:resourcekey="ListItemResource2"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div>
                                <asp:Label ID="lblGroupName" runat="server" Text="Group Name:" CssClass="textlabel"
                                    meta:resourcekey="lblGroupNameResource1"></asp:Label>
                                <asp:DropDownList ID="ddlGroupName" runat="server" AutoPostBack="True" meta:resourcekey="ddlGroupNameResource1"
                                    Width="140px">
                                    <asp:ListItem Value="0" Text="-- Select --" meta:resourcekey="ListItemResource3"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div>
                                <asp:Label ID="lblYear" runat="server" Text="Year:" CssClass="textlabel" meta:resourcekey="lblYearResource1"></asp:Label>
                                <asp:DropDownList ID="ddlYear" runat="server" AutoPostBack="false" meta:resourcekey="ddlYearResource1"
                                    Width="140px">
                                    <asp:ListItem Value="0" Text="-- Select --" meta:resourcekey="ListItemResource4"></asp:ListItem>
                                    <asp:ListItem Value="1" Text="2012-2013" meta:resourcekey="ListItemResource5"></asp:ListItem>
                                    <asp:ListItem Value="2" Text="2013-2014" meta:resourcekey="ListItemResource6"></asp:ListItem>
                                    <asp:ListItem Value="3" Text="2014-2015" meta:resourcekey="ListItemResource7"></asp:ListItem>
                                    <asp:ListItem Value="4" Text="2015-2016" meta:resourcekey="ListItemResource8"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RFVddlYear" runat="server" ErrorMessage="Please Select Year."
                                    ControlToValidate="ddlYear" ValidationGroup="a" InitialValue="0" meta:resourcekey="RFVddlYearResource1">*</asp:RequiredFieldValidator>
                            </div>
                            <div class="gobotton">
                                <asp:Button ID="btnGo" runat="server" Text="Go" ValidationGroup="a" OnClick="btnGo_Click"
                                    meta:resourcekey="btnGoResource1" />
                                <asp:Button ID="btnReset" runat="server" Text="Reset" OnClick="btnReset_Click" meta:resourcekey="btnResetResource1" />
                            </div>
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="a"
                                ShowMessageBox="True" ShowSummary="False" meta:resourcekey="ValidationSummary1Resource1" />
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlSchool" />
                        <asp:AsyncPostBackTrigger ControlID="ddlBoard" />
                        <asp:AsyncPostBackTrigger ControlID="ddlMedium" />
                        <asp:AsyncPostBackTrigger ControlID="ddlGroupName" />
                        <asp:AsyncPostBackTrigger ControlID="ddlYear" />
                        <asp:PostBackTrigger ControlID="btnGo" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
        <div class="sidepanel1">
            <div>
                <div class="activitydivside1" id="SecondRpt" runat="server" visible="false">
                    <div class="ActivityHeader">
                        <asp:Label ID="Label3" runat="server" Text="Genrate Report"></asp:Label>
                    </div>
                    <div class="ActivityContent">
                        <div>
                            <asp:Label ID="Label1" runat="server" Text="School:" CssClass="textlabel" meta:resourcekey="Label1Resource1"></asp:Label>
                            <asp:Label ID="lblSchoolValue" runat="server" CssClass="controllabel" meta:resourcekey="lblSchoolValueResource1"></asp:Label>
                        </div>
                        <div>
                            <asp:Label ID="lblAge" runat="server" Text="Age Group:" CssClass="textlabel" meta:resourcekey="lblAgeResource1"></asp:Label>
                            <asp:Label ID="lblAgeValue" runat="server" CssClass="controllabel" meta:resourcekey="lblAgeValueResource1"></asp:Label>
                        </div>
                        <div>
                            <asp:Label ID="lblYearSecond" runat="server" Text="Year:" CssClass="textlabel" meta:resourcekey="lblYearSecondResource1"></asp:Label>
                            <asp:Label ID="lblYearValue" runat="server" CssClass="controllabel" meta:resourcekey="lblYearValueResource1"></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="activitydivside1" id="ThirdReport" runat="server" visible="false">
                    <div class="ActivityHeader">
                        <asp:Label ID="Label5" runat="server" Text="Genrate Report"></asp:Label>
                    </div>
                    <div class="ActivityContent">
                        <div>
                            <asp:Label ID="lblSchoolThird" runat="server" Text="School:" CssClass="textlabel"
                                meta:resourcekey="lblSchoolThirdResource1"></asp:Label>
                            <asp:Label ID="lblSchoolValTh" runat="server" CssClass="controllabel" meta:resourcekey="lblSchoolValThResource1"></asp:Label>
                        </div>
                        <div>
                            <asp:Label ID="lblBMS" runat="server" Text="BMS :" CssClass="textlabel" meta:resourcekey="lblBMSResource1"></asp:Label>
                            <asp:Label ID="lblBMSValue" runat="server" CssClass="controllabel" meta:resourcekey="lblBMSValueResource1"></asp:Label>
                        </div>
                        <div>
                            <asp:Label ID="lblDiv" runat="server" Text="Div:" CssClass="textlabel" meta:resourcekey="lblDivResource1"></asp:Label>
                            <asp:Label ID="lblDivValue" runat="server" CssClass="controllabel" meta:resourcekey="lblDivValueResource1"></asp:Label>
                        </div>
                        <div>
                            <asp:Label ID="lblTeacher" runat="server" Text="Teacher:" CssClass="textlabel" meta:resourcekey="lblTeacherResource1"></asp:Label>
                            <asp:Label ID="lblTeacherValue" runat="server" CssClass="controllabel" meta:resourcekey="lblTeacherValueResource1"></asp:Label>
                        </div>
                        <div>
                            <asp:Label ID="lblAgeGroup" runat="server" Text="AgeGroup:" CssClass="textlabel"
                                meta:resourcekey="lblAgeGroupResource1"></asp:Label>
                            <asp:Label ID="lblAgeGroupValue" runat="server" CssClass="controllabel" meta:resourcekey="lblAgeGroupValueResource1"></asp:Label>
                        </div>
                    </div>
                </div>
                <div id="userControlDv" runat="server" visible="true" class="activitydivside1" style="margin-top: 15px;">
                    <div class="ActivityHeader">
                        <asp:Label ID="Label4" runat="server" Text="Report List"></asp:Label>
                    </div>
                    <div class="ActivityContent">
                        <uc1:ReportControl ID="rptSchool" runat="server" Visible="False" />
                        <uc1:ReportControl ID="rptAgeGroup" runat="server" Visible="False" />
                        <uc1:ReportControl ID="rptStudent" runat="server" Visible="False" />
                    </div>
                </div>
                <div style="width: 100px; margin: auto;">
                    <asp:Button ID="btnback" runat="server" Text="Back" OnClick="btnback_Click" Visible="False"
                        meta:resourcekey="btnbackResource1" />
                </div>
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
        <table id="pnlStudentDetails" runat="server" class="modalPopup RoundTop InnerTableStyle tblControls"
            style="display: none;" cellpadding="0" cellspacing="0" width="100%">
            <tr id="Tr1" style="width: 100%;" runat="server">
                <td id="Td1" style="text-align: center; font-size: 20px; font-weight: bold; border-top-left-radius: 0.5em;"
                    class="Header12" runat="server">
                    <asp:Label ID="lblTitle1" runat="server" Text="Student Details"></asp:Label>
                </td>
                <td id="Td2" style="text-align: right; border-top-right-radius: 0.5em; width: 5px;"
                    class="Header" runat="server">
                    <%--<asp:ImageButton ID="ibtnClose" runat="server" CausesValidation="False" ImageUrl="~/App_Themes/Images/btn_close_up.png"
                        Height="12px" />--%>
                </td>
            </tr>
            <tr id="Tr2" runat="server">
                <td id="Td3" colspan="2" runat="server">
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
