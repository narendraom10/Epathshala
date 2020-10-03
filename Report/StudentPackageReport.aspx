<%@ Page Title="" Language="C#" MasterPageFile="~/NewPublic/materialMaster.master" AutoEventWireup="true"
    CodeFile="StudentPackageReport.aspx.cs" Inherits="Report_StudentPackageReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .trlable {
            width: 20%;
            height: 41px;
            text-align: right;
            padding-right: 10px;
            padding-bottom: 5px;
        }

        .trcontrol {
            width: 75%;
            height: 41px;
            padding-bottom: 10px;
            padding-left: 5px;
        }

        .style1 {
            width: 20%;
            height: 41px;
            padding-bottom: 5px;
            padding-left: 5px;
            border-top-style: solid;
            border-bottom-style: solid;
            border-width: 0px;
        }

        .style2 {
            width: 11%;
            height: 41px;
            text-align: right;
            padding-right: 10px;
            padding-bottom: 5px;
        }

        .style3 {
            width: 10%;
            height: 41px;
            text-align: right;
            padding-right: 10px;
            padding-bottom: 5px;
        }

        .style4 {
            padding-bottom: 5px;
            width: 20px;
            border-top-style: solid;
            border-bottom-style: solid;
            border-right-style: solid;
            border-width: 0px;
        }

        table {
            border-collapse: collapse;
        }

        table {
            border: 1px solid black;
        }

        .reportactivityside {
            background-color: #fff; /*fff*/
            width: 87.5%; /*box-shadow: 0.005em 0.005em  0.099em #444;*/
            padding-bottom: 10px;
            font-size: 14px;
            color: #3e3e3e;
            margin-left: 95px;
            border-left: 1px solid #959595;
            border-bottom: 1px solid #959595;
            border-right: 1px solid #959595;
            border-radius: 2px;
            display: inline-block;
        }

        table {
            border: 0px solid #000;
        }

        .GreenBoard input[type="text"], .GreenBoard input[type="password"] {
            min-width: 80% !important;
            width: 80% !important;
            height: 30px !important;
        }
    </style>
    <style type="text/css">
        .SearchPnl .Label {
            margin-top: 10px !important;
        }

        .SearchPnl select {
            padding: 0px !important;
            min-width: 150px !important;
            max-width: 150px !important;
        }

        .SearchPnl input[type="text"] {
            min-width: 125px !important;
            max-width: 125px !important;
        }

        .SearchPnl input[type="image"] {
            min-width: 23px !important;
            max-width: 23px !important;
        }
    </style>
    <style type="text/css">
        .imgcalender {
            vertical-align: middle;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--Responsive start--%>
    <%--<div class="row DBHeader">
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
    </div>--%>
   <%-- <div class="row">
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
            <asp:Label ID="lblBMS" runat="server" Text="BMS" Font-Bold="True"></asp:Label>
        </div>
    </div>--%>
    <br />
    <%-- <table>
                    <tr>
                        <td colspan="6" style="padding-left: 5px; padding-bottom: 15px; height: 10%;">
                            <div>
                                <asp:Label ID="lblBMS" runat="server" Text="BMS" Font-Bold="True"></asp:Label>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td style="border-style: solid; border-width: 0px; width: 12%; padding-left: 2px;">
                            <div>
                                <asp:Label ID="lblpackagetype" runat="server" Text="Package Type:"></asp:Label>
                                <asp:DropDownList ID="ddlpackagetype" runat="server" Height="30px">
                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                    <asp:ListItem Value="1">Combo</asp:ListItem>
                                    <asp:ListItem Value="2">Single</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </td>
                        <td style="border-width: 0px; width: 20%; border-top-style: solid; border-bottom-style: solid;
                            border-left-style: solid; padding-left: 10px;">
                            <asp:Label ID="lblsearchby" runat="server" Text="Search By:"></asp:Label>
                            <div>
                                <asp:DropDownList ID="ddlsearchby" runat="server" Height="30px">
                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                    <asp:ListItem Value="1">Package Activation Date</asp:ListItem>
                                    <asp:ListItem Value="2">Package Registration Date</asp:ListItem>
                                    <asp:ListItem Value="3">Package Expiry Date</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </td>
                        <td class="style1">
                            <div>
                                <asp:Label ID="lblfromdate" runat="server" Text="From Date:"></asp:Label>
                                <asp:TextBox ID="txtfromdate" runat="server" CssClass="textBoxCls"></asp:TextBox>
                                <asp:ImageButton ID="ibtnStartDate" runat="server" ImageUrl="~/App_Themes/Images/calendar12.png"
                                    Width="20px" meta:resourcekey="ibtnStartDateResource1" />
                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtfromdate"
                                    PopupButtonID="ibtnStartDate" Enabled="True" Format="dd-MMM-yyyy">
                                </cc1:CalendarExtender>
                            </div>
                        </td>
                        <td class="style1">
                            <div>
                                <asp:Label ID="lbltodate" runat="server" Text="To Date:"></asp:Label>
                                <asp:TextBox ID="txttodate" runat="server" CssClass="textBoxCls"></asp:TextBox>
                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/App_Themes/Images/calendar12.png"
                                    Width="20px" meta:resourcekey="ibtnStartDateResource1" />
                                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txttodate"
                                    PopupButtonID="ImageButton1" Enabled="True" Format="dd-MMM-yyyy">
                                </cc1:CalendarExtender>
                            </div>
                        </td>
                        <td style="border-style: solid; border-width: 0px; width: 12%; padding-left: 2px;">
                            <div>
                                <asp:Label ID="lblstatus" runat="server" Text="Status:"></asp:Label>
                                <asp:DropDownList ID="ddlstatus" runat="server" Height="30px">
                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                    <asp:ListItem Value="1">Active</asp:ListItem>
                                    <asp:ListItem Value="2">Expired</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </td>
                    </tr>
   <%--             </table>--%>
   <%-- <div class="row">
        <div class="SearchPnl">
            <div class="col-lg-2 col-md-4  col-sm-6 col-xs-12">
                <div class="Label">
                    Package Type
                </div>
                <div>
                    <asp:DropDownList ID="ddlpackagetype" runat="server" Height="30px" Width="90px">
                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                        <asp:ListItem Value="1">Combo</asp:ListItem>
                        <asp:ListItem Value="2">Single</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="col-lg-2 col-md-4  col-sm-6 col-xs-12">
                <div class="Label">
                    Search by
                </div>
                <div>
                    <asp:DropDownList ID="ddlsearchby" runat="server" Height="30px">
                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                        <asp:ListItem Value="1">Package Activation Date</asp:ListItem>
                        <asp:ListItem Value="2">Package Registration Date</asp:ListItem>
                        <asp:ListItem Value="3">Package Expiry Date</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="col-lg-2  col-md-4  col-sm-6 col-xs-12">
                <div class="Label">
                    From Date
                </div>
                <asp:TextBox ID="txtfromdate" runat="server" AutoCompleteType="None"></asp:TextBox>
                <asp:ImageButton ID="ibtnStartDate" runat="server" ImageUrl="~/App_Themes/Images/Calender.png"
                    BackColor="#444" Width="25px" CssClass="imgcalender" meta:resourcekey="ibtnStartDateResource1" />
                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtfromdate"
                    PopupButtonID="ibtnStartDate" Enabled="True" Format="dd-MMM-yyyy">
                </cc1:CalendarExtender>
            </div>
            <div class="col-lg-2 col-md-4 col-sm-6 col-xs-12">
                <div class="Label">
                    To Date
                </div>
                <asp:TextBox ID="txttodate" runat="server" AutoCompleteType="None"></asp:TextBox>
                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/App_Themes/Images/Calender.png"
                    BackColor="#444" Width="25px" CssClass="imgcalender" meta:resourcekey="ibtnStartDateResource1" />
                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txttodate"
                    PopupButtonID="ImageButton1" Enabled="True" Format="dd-MMM-yyyy">
                </cc1:CalendarExtender>
            </div>
            <div class="col-lg-2 col-md-4 col-sm-6 col-xs-12">
                <div class="Label">
                    Status
                </div>
                <asp:DropDownList ID="ddlstatus" runat="server" Height="30px">
                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                    <asp:ListItem Value="1">Active</asp:ListItem>
                    <asp:ListItem Value="2">Expired</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
            <asp:Button ID="btnsubmit" runat="server" Text="Submit" OnClick="btnsubmit_Click1" />
            <asp:Button ID="btnreset" runat="server" Text="Reset" OnClick="btnreset_Click" />
        </div>
    </div>
    --%>
    <style>
        #gvstudentpackagedetails1 th,td
        {
            text-align:center !important;
            color:black !important;
        }

    </style>
    <div class="row" style="margin: 0px; padding: 0px; overflow: auto;">
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 table-responsive" style="padding: 15px; overflow: auto;">
            <h5>Active Packages</h5>
            <asp:GridView runat="server" ClientIDMode="Static" ID="gvstudentpackagedetails1"
                AutoGenerateColumns="False" SkinID="NoPaging" CssClass="table table-striped table-bordered table-hover" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical">
                <AlternatingRowStyle BackColor="#CCCCCC" />
                <Columns>
                    <asp:BoundField DataField="PackageName" HeaderText="Package Name" />
                    <asp:BoundField DataField="PackageType" HeaderText="Package Type"  />
                    <asp:BoundField DataField="Subject" HeaderText="Subject"  />
                    <asp:BoundField DataField="Price" HeaderText="Price" Visible="false" />
                    <asp:BoundField DataField="NoOfMonth" HeaderText="NoOfMonth" Visible="false" />
                    <asp:BoundField DataField="ActivateOn" HeaderText="Registration Date" DataFormatString="{0:dd MMM, yyyy}"  />
                    <asp:BoundField DataField="FromDate" HeaderText="Activation Date" DataFormatString="{0:dd MMM, yyyy}"  />
                    <asp:BoundField DataField="ValidTill" HeaderText="Validity" DataFormatString="{0:dd MMM, yyyy}" />
                    <asp:BoundField DataField="Status" HeaderText="Status" />
                    <asp:TemplateField HeaderText="View">
                        <ItemTemplate>
                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# string.Format("~/Invoice.aspx?PackageName={0}&Subject={1}&ActivateOn={2}&Price={3}&NoOfMonth={4}&ValidTill={5}&TransactionID={6}&RegisteredOn={7}",
                    HttpUtility.UrlEncode(Eval("PackageName").ToString()), HttpUtility.UrlEncode(Eval("Subject").ToString()), HttpUtility.UrlEncode(Eval("FromDate").ToString()) , HttpUtility.UrlEncode(Eval("Price").ToString()), HttpUtility.UrlEncode(Eval("NoOfMonth").ToString()), HttpUtility.UrlEncode(Eval("ValidTill").ToString()), HttpUtility.UrlEncode(Eval("TransactionID").ToString()), HttpUtility.UrlEncode(Eval("ActivateOn").ToString())) %>'
                                Text="View" Target="_blank" ForeColor="Blue" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    <span style="color: #000000; font-size: x-large; font-weight: bold; font-family: 'Times New Roman', Times, serif">No Data Found.</span>
                </EmptyDataTemplate>
                <FooterStyle BackColor="#CCCCCC" />
                <HeaderStyle BackColor="#cfcfcf" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#808080" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#383838" />
            </asp:GridView>
        </div>
    </div>
    <%--Responsive End--%>
    <%--<div class="reportactivityside">
        <div class="ActivityHeader">
            Student Package Detail Report
        </div>
        <div class="ActivityContent">
            
        </div>
    </div>--%>
    <script type="text/javascript">
        //This function is to simply make current page menu item active.
        $(document).ready(function () {
            $('.puerto-menu li .active').removeClass('active');
            $('.puerto-menu li:nth-child(4) a:first()').addClass('active');
        });
    </script>
</asp:Content>
