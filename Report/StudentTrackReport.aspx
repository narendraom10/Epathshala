<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Epathshala.master" AutoEventWireup="true"
    EnableEventValidation="false" CodeFile="StudentTrackReport.aspx.cs" Inherits="Report_StudentTrackReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="../UserControl/ReportControl.ascx" TagName="ReportControl" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .form-control2
        {
            background-color: #314B3C !important;
            border: 1px solid #273D2F !important;
            border-radius: 0px !important;
            box-shadow: 0 1px 1px rgba(0, 0, 0, 0.075) inset !important;
            color: #f9f9f9 !important;
            display: block !important;
            font-size: 14px !important;
            height: 34px !important;
            line-height: 1.42857 !important;
            padding: 6px 12px !important;
            transition: border-color 0.15s ease-in-out 0s, box-shadow 0.15s ease-in-out 0s !important;
            vertical-align: middle !important;
            width: 100% !important;
        }
        .input-sm2
        {
            border-radius: 0 !important;
            font-size: 12px !important;
            height: 30px !important;
            line-height: 1.5 !important;
            padding: 5px 10px !important;
        }
        .form-control2:focus
        {
            border-color: #48a02b !important;
            outline: 0 !important;
            -webkit-box-shadow: inset 0 1px 1px rgba(0,0,0,.075), 0 0 8px rgba(40, 225, 189, 0.6) !important;
            box-shadow: inset 0 1px 1px rgba(0,0,0,.075), 0 0 8px rgba(40, 225, 189, 0.6) !important;
        }
        .form-inline .form-control2
        {
            display: inline-block !important;
        }
        select
        {
            min-width: 100%;
            color: #6D9B93 !important;
            font-weight: normal !important;
            font-style: normal;
            background: none !important;
            background-color: #314B3C !important;
            border: 1px solid #273D2F !important;
            font-size: 12px !important;
            text-shadow: none !important;
        }
        select:hover
        {
            font-weight: normal !important;
            color: #6D9B93 !important;
            background: none !important;
            background-color: #314B3C !important;
            border: 1px solid #273D2F !important;
        }
        .mypara
        {
            color: #bbc3c8 !important;
            font-family: 'Verdana' , sans-serif;
            font-size: 12px;
            line-height: 20px;
            text-indent: 30px;
            text-align: justify;
            margin: 0;
            text-indent: 0;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--<asp:UpdatePanel runat="server" ID="upCriteria" UpdateMode="Conditional">
        <ContentTemplate>--%>
    <div class="row DBHeader">
        <div class="col-sm-6 NoPadding">
            <div class="DashboardHeading">
                You are here: <span style="color: White;">Student Activity Track Report</span>
            </div>
        </div>
        <div class="col-sm-6 NoPadding">
            <div class="DashboardHeading">
                <img src="../App_Themes/Green/Images/icon-calendar.png" alt="Calender" />
                &nbsp;&nbsp;<i>Today:
                    <%=DateTime.Now.ToString("dd MMM yyyy / hh:mm tt")%>
                </i>
            </div>
        </div>
    </div>
    <div class="row" style="padding: 20px 0px 5px 1px;">
        <div class="col-sm-4">
            <div class="Activity">
                <div class="ActivityHeading">
                    <asp:Label ID="Label2" runat="server" Text="Student Activity Tracking "></asp:Label>
                </div>
                <div class="Content">
                    <div>
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="White" ShowSummary="False"
                            ValidationGroup="a" BorderColor="#8D9691" DisplayMode="List" ShowMessageBox="True" />
                    </div>
                    <div>
                        <asp:DropDownList ID="ddlBoard" runat="server" AutoPostBack="True" CssClass="form-control2 input-sm2"
                            OnSelectedIndexChanged="ddlBoard_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="ReqFieldBoard" runat="server" InitialValue="Select Board"
                            ErrorMessage="Select Board." ForeColor="White" ValidationGroup="a" ControlToValidate="ddlBoard">*</asp:RequiredFieldValidator>
                    </div>
                    <div>
                        <asp:DropDownList ID="ddlMedium" runat="server" AutoPostBack="True" CssClass="form-control2 input-sm2"
                            meta:resourcekey="ddlMediumResource1" Enabled="false" OnSelectedIndexChanged="ddlMedium_SelectedIndexChanged">
                            <asp:ListItem Value="0" Text="Select Medium"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="ReqFieldMedium" runat="server" InitialValue="Select Medium"
                            ErrorMessage="Select Medium" ForeColor="White" ValidationGroup="a" ControlToValidate="ddlMedium">*</asp:RequiredFieldValidator>
                    </div>
                    <div>
                        <asp:DropDownList ID="ddlStandard" runat="server" AutoPostBack="True" CssClass="form-control2 input-sm2"
                            Enabled="false" OnSelectedIndexChanged="ddlStandard_SelectedIndexChanged">
                            <asp:ListItem Value="0" Text="Select Standard"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="ReqFieldStandard" runat="server" InitialValue="Select Standard"
                            ErrorMessage="Select Standard." ForeColor="White" ValidationGroup="a" ControlToValidate="ddlStandard">*</asp:RequiredFieldValidator>
                    </div>
                    <div>
                        <asp:DropDownList ID="ddlStudents" runat="server" AutoPostBack="True" CssClass="form-control2 input-sm2"
                            Enabled="false" OnSelectedIndexChanged="ddlStudent_SelectedIndexChanged" Style="width: 50%;">
                            <asp:ListItem Value="0" Text="Select Student"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="ReqFieldStudents" runat="server" InitialValue="Select Student"
                            ErrorMessage="Select Student." ForeColor="White" ValidationGroup="a" ControlToValidate="ddlStudents">*</asp:RequiredFieldValidator>
                    </div>
                    <div>
                        <asp:TextBox ID="txtFdate" runat="server" meta:resourcekey="txtFdateResource1" placeholder="From Date"
                            CssClass="form-control2 input-sm2"></asp:TextBox>
                        <%--<asp:ImageButton ID="ibtnStartDate" runat="server" ImageUrl="~/App_Themes/Images/calendar12.png"
                                    Width="20px" meta:resourcekey="ibtnStartDateResource1" />--%>
                        <asp:RequiredFieldValidator ID="ReqFieldFromdate" runat="server" ErrorMessage="Select From Date."
                            ForeColor="White" ValidationGroup="a" ControlToValidate="txtFdate">*</asp:RequiredFieldValidator>
                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFdate"
                            PopupButtonID="txtFdate" Enabled="True" Format="dd MMM yyyy">
                        </cc1:CalendarExtender>
                    </div>
                    <div>
                        <asp:TextBox ID="txtTodate" runat="server" placeholder="To Date" meta:resourcekey="txtTodateResource1"
                            CssClass="form-control2 input-sm2"></asp:TextBox>
                        <%--<asp:ImageButton ID="ibtnEndDate" runat="server" ImageUrl="~/App_Themes/Images/calendar12.png"
                                    Width="20px" meta:resourcekey="ibtnEndDateResource1" />--%>
                        <asp:RequiredFieldValidator ID="ReqFieldTodate" runat="server" ErrorMessage="Select To Date."
                            ForeColor="White" ValidationGroup="a" ControlToValidate="txtTodate">*</asp:RequiredFieldValidator>
                        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtTodate"
                            PopupButtonID="txtTodate" Enabled="True" Format="dd MMM yyyy">
                        </cc1:CalendarExtender>
                    </div>
                    <div class="text-center">
                        <asp:Button ID="btnViewReport" runat="server" Text="View" ValidationGroup="a" meta:resourcekey="btnViewReportResource1"
                            OnClick="btnViewReport_Click" />
                        <asp:Button ID="btnReset" runat="server" Text="Reset" meta:resourcekey="btnResetResource1"
                            OnClick="btnReset_Click" />
                    </div>
                </div>
            </div>
        </div>
        <div class="col-sm-8">
            <div class="Activity">
                <div class="ActivityHeading">
                    <asp:Label ID="Label1" runat="server" Text="General Details"></asp:Label>
                </div>
                <div class="Content" id="Div_GeneralDetails" runat="server">
                    <div id="div_no_general_data" runat="server" style="border: 1px dotted #2E8E6E; margin: 5px;
                        padding: 10px; text-align: center; color: #F5CB21;">
                        <span>No General Details available to display currently.!</span>
                    </div>
                    <div id="div_general" runat="server" visible="false" style="overflow: auto;">
                        <table border="0" cellpadding="3" cellspacing="3" class="table table-condensed">
                            <tr>
                                <td>
                                    <asp:Label ID="sLblStudent" runat="server" Text="Student" CssClass="textlabel" ToolTip="Student Name"></asp:Label>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <asp:Label ID="slblStudentValue" runat="server" CssClass="controllabel" ToolTip="Student"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="LblBMS" runat="server" Text="Board Medium Standard" CssClass="textlabel"></asp:Label>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <asp:Label ID="LblBMSValues" runat="server" CssClass="controllabel"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="LblPeriod" runat="server" Text="Activity Period" CssClass="textlabel"></asp:Label>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <asp:Label ID="LblPeriodValues" runat="server" CssClass="controllabel"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="LblSession" runat="server" Text="Session" CssClass="textlabel"></asp:Label>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <asp:Label ID="LblSessionname" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
            <div class="Activity" style="margin-top: 10px;">
                <div class="ActivityHeading">
                    <asp:Label ID="Label3" runat="server" Text="Activity Details"></asp:Label>
                </div>
                <div class="Content">
                    <div id="div_no_reportdetails" runat="server" style="border: 1px dotted #2E8E6E;
                        margin: 5px; padding: 10px; text-align: center; color: #F5CB21;">
                        <span>No Activity Details available to display currently.!</span>
                    </div>
                    <div id="div_reportdetails" runat="server" visible="false" style="overflow: auto;">
                        <uc1:ReportControl ID="RptCtrlSessionSummury" runat="server" Visible="false" />
                        <div id="lblfooterdiv" runat="server" style="border: 1px Solid green; padding: 5px;
                            color: White; background-color: #C8E4CB; color: green;">
                            <asp:Label ID="lblFooterTotal" Text="" runat="server" Font-Bold="True" />
                        </div>
                        <uc1:ReportControl ID="RptCtrlSessionDetails" runat="server" Visible="false" />
                    </div>
                </div>
            </div>
            <div>
                <asp:Button ID="btnback" runat="server" Text="Back" Visible="False" meta:resourcekey="btnbackResource1"
                    OnClick="btnback_Click1" />
            </div>
        </div>
    </div>
    <%--    </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="RptCtrlSessionSummury" />
            <asp:AsyncPostBackTrigger ControlID="RptCtrlSessionDetails" />
            <asp:AsyncPostBackTrigger ControlID="ddlBoard" />
            <asp:AsyncPostBackTrigger ControlID="ddlMedium" />
            <asp:AsyncPostBackTrigger ControlID="ddlStandard" />
            <asp:AsyncPostBackTrigger ControlID="ddlStudents" />
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
