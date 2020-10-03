<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Epathshala.master" AutoEventWireup="true"
    CodeFile="ClassroomWiseAttendanceF.aspx.cs" Inherits="Report_ClassroomWiseAttendanceF"
    EnableEventValidation="false" Culture="auto" meta:resourcekey="PageResource1"
    UICulture="auto" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<%@ Register Src="../UserControl/ReportControl.ascx" TagName="ReportControl" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" src="../JavaScript/ASCIIMathML.js"></script>
    <script type="text/javascript" src="../JavaScript/jquery-1.4.2.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--<div  runat="server" visible="true" id="banner">--%>
  <%--  <asp:UpdatePanel runat="server" ID="upTopics" UpdateMode="Conditional">
        <ContentTemplate>--%>
            <div class="tblDashboard" id="ClasswiseReport" runat="server" visible="true">
                <div class="sidepanel">
                    <div class="activitydivside">
                        <div class="ActivityHeader">
                            <asp:Label ID="lblTitle" runat="server" Text="Classroom wise attendance report of the day"
                                meta:resourcekey="lblTitleResource1"></asp:Label>
                        </div>
                        <div class="ActivityContent" id="Div1" runat="server" visible="true">
                            <div>
                                <asp:Label ID="lblSchool" runat="server" Text="School:" CssClass="textlabel" meta:resourcekey="lblSchoolResource1"></asp:Label>
                                <asp:DropDownList ID="ddlSchool" runat="server" Width="140px" AutoPostBack="True"
                                    OnSelectedIndexChanged="ddlSchool_SelectedIndexChanged" 
                                    meta:resourcekey="ddlSchoolResource1">
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
                                <asp:Label ID="lblStandard" runat="server" Text="Standard:" CssClass="textlabel"
                                    meta:resourcekey="lblStandardResource1"></asp:Label>
                                <asp:DropDownList ID="ddlStandard" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlStandard_SelectedIndexChanged"
                                    meta:resourcekey="ddlStandardResource1" Width="140px">
                                    <asp:ListItem Value="0" Text="-- Select --" meta:resourcekey="ListItemResource3"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div>
                                <asp:Label ID="lblDivision" runat="server" Text="Division:" CssClass="textlabel"
                                    meta:resourcekey="lblDivisionResource1"></asp:Label>
                                <asp:DropDownList ID="ddlDivision" runat="server" AutoPostBack="True" 
                                    meta:resourcekey="ddlDivisionResource1" Width="140px">
                                    <asp:ListItem Value="0" Text="-- Select --" meta:resourcekey="ListItemResource4"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div>
                                <asp:Label ID="lblDate" runat="server" Text="Date:" CssClass="textlabel" meta:resourcekey="lblDateResource1"></asp:Label>
                                <asp:TextBox ID="txtDate" runat="server" onKeypress="return(false)" meta:resourcekey="txtDateResource1"
                                    CssClass="textBoxCls"></asp:TextBox>
                                <asp:ImageButton ID="ibtnDate" runat="server" ImageUrl="~/App_Themes/Images/calendar12.png"
                                    Width="20px" meta:resourcekey="ibtnDateResource1" />
                                <cc2:CalendarExtender ID="calExt" runat="server" TargetControlID="txtDate" PopupButtonID="ibtnDate"
                                    Enabled="True" Format="dd-MMM-yyyy">
                                </cc2:CalendarExtender>
                            </div>
                            <div class="gobotton">
                                <asp:Button ID="btnGo" runat="server" Text="Go" OnClick="btnGo_Click" CssClass="Button"
                                    ValidationGroup="a" meta:resourcekey="btnGoResource1" />
                                <asp:Button ID="btnReset" runat="server" Text="Reset" OnClick="btnReset_Click" meta:resourcekey="btnResetResource1"
                                    CssClass="Button" />
                            </div>
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="a"
                                ShowMessageBox="True" ShowSummary="False" meta:resourcekey="ValidationSummary1Resource1" />
                        </div>
                    </div>
                </div>
                <div class="sidepanel1">
                    <div>
                        <div class="activitydivside1" id="secondRpt" runat="server" visible="false">
                            <div class="ActivityHeader">
                                <asp:Label ID="Label3" runat="server" Text="Genrate Report"></asp:Label>
                            </div>
                            <div class="ActivityContent">
                                <div>
                                    <asp:Label ID="Label1" runat="server" Text="School:" CssClass="textlabel" meta:resourcekey="Label1Resource1"></asp:Label>
                                    <asp:Label ID="lblSchoolValue" runat="server" CssClass="controllabel" meta:resourcekey="lblSchoolValueResource1"></asp:Label>
                                </div>
                                <div>
                                    <asp:Label ID="lblBMS" runat="server" Text="BMS:" CssClass="textlabel" meta:resourcekey="lblBMSResource1"></asp:Label>
                                    <asp:Label ID="lblBMSValue" runat="server" CssClass="controllabel" meta:resourcekey="lblBMSValueResource1"></asp:Label>
                                </div>
                                <div>
                                    <asp:Label ID="lblDiv" runat="server" Text="Division:" CssClass="textlabel" meta:resourcekey="lblDivResource1"></asp:Label>
                                    <asp:Label ID="lblDivValue" runat="server" CssClass="controllabel" meta:resourcekey="lblDivValueResource1"></asp:Label>
                                </div>
                                <div>
                                    <asp:Label ID="Label2" runat="server" Text="Date:" CssClass="textlabel" meta:resourcekey="Label2Resource1"></asp:Label>
                                    <asp:Label ID="lblDateValue" runat="server" CssClass="controllabel" meta:resourcekey="lblDateValueResource1"></asp:Label>
                                </div>
                                <div>
                                    <asp:Label ID="lblAttendance" runat="server" Text="Attendance(%):" CssClass="textlabel"
                                        Style="width: 120px;" meta:resourcekey="lblAttendanceResource1"></asp:Label>
                                    <asp:Label ID="lblAttendanceValue" runat="server" CssClass="controllabel" meta:resourcekey="lblAttendanceValueResource1"></asp:Label>
                                </div>
                            </div>
                        </div>
                        <div class="activitydivside1" style="margin-top: 15px;">
                            <div class="ActivityHeader">
                                <asp:Label ID="Label4" runat="server" Text="Attended Student List"></asp:Label>
                            </div>
                            <div class="ActivityContent">
                                <uc1:ReportControl ID="rptSchoolAttendance" runat="server" Visible="False" />
                                <uc1:ReportControl ID="rptClassAttendance" runat="server" Visible="False" />
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
            <asp:AsyncPostBackTrigger ControlID="ddlDivision" />
            <asp:PostBackTrigger ControlID="btnGo" />
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
