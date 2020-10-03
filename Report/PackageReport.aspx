<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Epathshala.master" AutoEventWireup="true"
    CodeFile="PackageReport.aspx.cs" Inherits="Report_PackageReport" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="../UserControl/ReportControl.ascx" TagName="ReportControl" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .trlable
        {
            width: 20%;
            height: 41px;
            text-align: right;
            padding-right: 10px;
            padding-bottom: 5px;
        }
        
        .trcontrol
        {
            width: 75%;
            height: 41px;
            padding-bottom: 10px;
            padding-left: 5px;
        }
        table
        {
            border-collapse: collapse;
        }
        
        table
        {
            border: 1px solid black;
        }
        
   
        table
        {
            border: 0px solid #000;
        }
        
        .GreenBoard input[type="text"], .GreenBoard input[type="password"]
        {
          /*  min-width: 80% !important;
            width: 80% !important;
            height: 30px !important;*/
        }
    </style>
    <style type="text/css">
        .imgcalender
        {
            vertical-align: middle;
        }
    </style>



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
    <div class="row DBHeader">
        <div class="col-sm-6 NoPadding">
            <div class="DashboardHeading">
                You are here: <span style="color: White;">Package Report</span>
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
        <asp:Panel runat="server" ID="pnlfilter" Enabled="false">
            <div class="Activity">
                <div class="ActivityHeading">
                    <asp:Label ID="Label2" runat="server" Text="Package Report"></asp:Label>
                </div>
                <div class="Content">
                    <div>
                        <%--<asp:DropDownList ID="ddlStudents" runat="server" AutoPostBack="True" CssClass="form-control2 input-sm2"
                            Enabled="false" Style="width: 80%;">
                            <asp:ListItem Value="0" Text="Select Student"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="ReqFieldStudents" runat="server" InitialValue="Select Student"
                            ErrorMessage="Select Student." ForeColor="White" ValidationGroup="a" ControlToValidate="ddlStudents">*</asp:RequiredFieldValidator>--%>
                        <asp:TextBox ID="txtstudent" runat="server" placeholder="Student Name" CssClass="form-control2 input-sm2"></asp:TextBox>
                        <br />
                        <%--<asp:RequiredFieldValidator ID="ReqFieldStudents" runat="server" ErrorMessage="Enter Student Name."
                            ForeColor="White" ValidationGroup="a" ControlToValidate="txtstudent">*</asp:RequiredFieldValidator>--%>
                    </div>
                      <div>
                        
                        <asp:TextBox ID="txtpackagename" runat="server" placeholder="Package Name" CssClass="form-control2 input-sm2"></asp:TextBox>
                        <br />
                        <%--<asp:RequiredFieldValidator ID="Reqtxtpackagename" runat="server" ErrorMessage="Enter Package Name."
                            ForeColor="White" ValidationGroup="a" ControlToValidate="txtpackagename">*</asp:RequiredFieldValidator>--%>
                    </div>
                    <div>
                        <asp:DropDownList ID="ddldatefilter" runat="server" AutoPostBack="false" CssClass="form-control2 input-sm2"
                            Style="width: 50%;">
                            <asp:ListItem Value="0" Text="Select Date Type"></asp:ListItem>
                            <asp:ListItem Value="1" Text="Purchased Date"></asp:ListItem>
                            <asp:ListItem Value="2" Text="From Date"></asp:ListItem>
                            <asp:ListItem Value="3" Text="End Date"></asp:ListItem>
                        </asp:DropDownList>
                        <br />
                        <br />
                        <%--<asp:RequiredFieldValidator ID="ReqFieldDate" runat="server" InitialValue="Select Date Type"
                            ErrorMessage="Select date type." ForeColor="White" ValidationGroup="a" ControlToValidate="ddldatefilter">*</asp:RequiredFieldValidator>--%>
                    </div>
                    <div>
                        <asp:TextBox ID="txtFdate" runat="server" placeholder="From Date" CssClass="form-control2 input-sm2"></asp:TextBox>
                        <%--<asp:ImageButton ID="ibtnStartDate" runat="server" ImageUrl="~/App_Themes/Images/calendar12.png"
                                    Width="20px" meta:resourcekey="ibtnStartDateResource1" />--%>
                        <%--<asp:RequiredFieldValidator ID="ReqFieldFromdate" runat="server" ErrorMessage="Select From Date."
                            ForeColor="White" ValidationGroup="a" ControlToValidate="txtFdate">*</asp:RequiredFieldValidator>--%>
                        <cc1:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtFdate"
                            PopupButtonID="txtFdate" Enabled="True" Format="dd MMM yyyy">
                        </cc1:CalendarExtender>
                        <br />
                    </div>
                    <div>
                        <asp:TextBox ID="txtTodate1" runat="server" placeholder="To Date" CssClass="form-control2 input-sm2"></asp:TextBox>
                        <%--<asp:ImageButton ID="ibtnEndDate" runat="server" ImageUrl="~/App_Themes/Images/calendar12.png"
                                    Width="20px" meta:resourcekey="ibtnEndDateResource1" />--%>
                        <%--<asp:RequiredFieldValidator ID="ReqFieldTodate" runat="server" ErrorMessage="Select To Date."
                            ForeColor="White" ValidationGroup="a" ControlToValidate="txtTodate1">*</asp:RequiredFieldValidator>--%>
                        <cc1:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtTodate1"
                            PopupButtonID="txtTodate1" Enabled="True" Format="dd MMM yyyy">
                        </cc1:CalendarExtender>
                        <br />
                    </div>
                    <div class="text-center">
                        <asp:Button ID="btnViewReport" runat="server" Text="View" ValidationGroup="a" OnClick="btnViewReport_Click" />
                        <asp:Button ID="Button1" runat="server" Text="Reset" onclick="Button1_Click" />
                    </div>
                    <div style="padding-left: 15px;">
                        <asp:ValidationSummary ID="valgroupa" runat="server" ValidationGroup="a" />
                    </div>
                </div>
            </div>
        </asp:Panel>
    </div>
    <div class="col-sm-8">
        <div class="Activity">
            <div class="ActivityHeading">
                <%--<asp:Label ID="Label1" runat="server" Text="General Details"></asp:Label>--%>
                Board, Medium, Standard
            </div>
            <div class="Content" id="Div_GeneralDetails" runat="server" style="margin-top: -10px;">
                <%--<div id="div_no_general_data" runat="server" style="border: 1px dotted #2E8E6E; margin: 5px;
                    padding: 10px; text-align: center; color: White;">
                    <span>No report data available to display currently.!</span>
                </div>--%>
                <div id="div_general" runat="server" visible="true" style="overflow: auto;">
                    <table border="0" cellpadding="3" cellspacing="3" class="table table-condensed">
                        <tr>
                            <td style="width:25%;">
                                <asp:Label ID="lblboard1" runat="server" Text="Board"></asp:Label>
                            </td>
                            <td style="width:5%;">
                                :
                            </td>
                            <td style="width:70%;">
                                <asp:Label ID="lblboard" runat="server" Text="-"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblmedium1" runat="server" Text="Medium"></asp:Label>
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <asp:Label ID="lblmedium" runat="server" Text="-"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblstandard1" runat="server" Text="Standard"></asp:Label>
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <asp:Label ID="lblstandard" runat="server" Text="-"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
    </div>
    <div class="Activity" style="margin-top: 10px;">
        <div class="ActivityHeading">
            <asp:Label ID="Label3" runat="server" Text="Details"></asp:Label>
        </div>
        <div class="Content">
            <div class="row" style="overflow: auto;">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <div style="overflow: auto; margin-top: -28px;">
                        <uc1:ReportControl ID="gvboard" runat="server" Visible="False" />
                        <asp:Label ID="lblgvboard" runat="server" Visible="false"></asp:Label>
                        <asp:Label ID="lbltotalboard" runat="server" Visible="false"></asp:Label>
                        <uc1:ReportControl ID="gvmedium" runat="server" Visible="false" />
                        <asp:Label ID="lbltotalmedium" runat="server" Visible="false"></asp:Label>
                        <asp:Button ID="btnbackboard" runat="server" Text="Back" Visible="false" OnClick="btnbackboard_Click" />
                        <uc1:ReportControl ID="gvstandard" runat="server" Visible="False" />
                        <asp:Label ID="lbltotalstandard" runat="server" Visible="false"></asp:Label>
                        <asp:Button ID="btnbackmedium" runat="server" Text="Back" Visible="false" OnClick="btnbackmedium_Click" />
                        <uc1:ReportControl ID="gvStudentList" runat="server" Visible="false" />
                        <asp:Label ID="lbltotalstudent" runat="server" Visible="false"></asp:Label>
                        <asp:Button ID="btnstandard" runat="server" Text="Back" Visible="false" OnClick="btnstandard_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div>
    </div>
    </div>
    </div>

    <div class="row" style="padding: 20px 0px 5px 1px;">
        <div class="SearchPnl">
            <div class="col-lg-2  col-md-4  col-sm-6 col-xs-12" style="display: none; visibility: hidden;">
                <div class="Label">
                    From Date</div>
                <asp:TextBox ID="txtfromdate" runat="server" AutoCompleteType="None"></asp:TextBox>
                <asp:ImageButton ID="ibtnStartDate" runat="server" ImageUrl="~/App_Themes/Images/Calender.png"
                    BackColor="#444" Width="25px" CssClass="imgcalender" meta:resourcekey="ibtnStartDateResource1" />
                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtfromdate"
                    PopupButtonID="ibtnStartDate" Enabled="True" Format="dd-MMM-yyyy">
                </cc1:CalendarExtender>
            </div>
            <div class="col-lg-2  col-md-4  col-sm-6 col-xs-12" style="display: none; visibility: hidden;">
                <div class="Label">
                    To Date</div>
                <asp:TextBox ID="txttodate" runat="server" AutoCompleteType="None"></asp:TextBox>
                <asp:ImageButton ID="imgtodate" runat="server" ImageUrl="~/App_Themes/Images/Calender.png"
                    BackColor="#444" Width="25px" CssClass="imgcalender" />
                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txttodate"
                    PopupButtonID="imgtodate" Enabled="True" Format="dd-MMM-yyyy">
                </cc1:CalendarExtender>
            </div>
        </div>
    </div>
    <div class="row" runat="server" id="dvfilter" visible="false">
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
            <asp:Button ID="btnsubmit" runat="server" Text="Submit" OnClick="btnsubmit_Click1" />
            <asp:Button ID="btnreset" runat="server" Text="Reset" OnClick="btnreset_Click" />
        </div>
    </div>
</asp:Content>
