<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Epathshala.master" AutoEventWireup="true"
    CodeFile="StudentAttendance.aspx.cs" Inherits="Teacher_StudentAttendance" Culture="auto"
    meta:resourcekey="PageResource1" UICulture="auto" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit.HTMLEditor"
    TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--  <asp:UpdatePanel ID="up1" runat="server">
        <ContentTemplate>--%>
    <asp:UpdatePanel ID="up1" runat="server" class="tblDashboard">
        <ContentTemplate>
            <div class="tblDashboard1">
                <div class="firstpanel">
                    <div class="activitydivfull">
                        <div class="ActivityHeader">
                            <asp:Label ID="LblStudentAttendance" runat="server" Text="Attendance" meta:resourcekey="LblStudentAttendanceResource1"></asp:Label>
                        </div>
                        <div class="ActivityContent">
                            <div>
                                <asp:Panel ID="PnlStandardDetails" runat="server" Visible="false">
                                    <fieldset id="flClassDetail" runat="server">
                                        <legend>
                                            <asp:Label ID="lblClassDetails" runat="server" Text="Class Attendance Details" CssClass="SubTitle"
                                                meta:resourcekey="lblClassDetailsResource1"></asp:Label></legend>
                                        <table class="tblControls">
                                            <tr>
                                                <td colspan="4">
                                                    <asp:Label ID="lblBMSDesc" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </fieldset>
                                </asp:Panel>
                            </div>
                            <div>
                                <asp:Panel ID="PnlAdminCriteria" runat="server" Visible="false">
                                    <fieldset>
                                        <legend>
                                            <asp:Label ID="LblSearch" runat="server" Text="Search" CssClass="SubTitle" meta:resourcekey="LblSearchResource1"></asp:Label></legend>
                                        <table class="tblControls">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblBMSDisplay" runat="server" Text="BMS:" ToolTip="Board/Medium/Standard"
                                                        meta:resourcekey="lblBMSDisplayResource1"></asp:Label>
                                                </td>
                                                <td colspan="3">
                                                    <asp:DropDownList ID="ddlBMS" runat="server" AutoPostBack="true" SkinID="DdlWidth400"
                                                        OnSelectedIndexChanged="ddlBMS_SelectedIndexChanged">
                                                        <asp:ListItem Text="-- Select --" Value="0"></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="rqdBMS" Text="." InitialValue="0" runat="server"
                                                        ErrorMessage="Board/Medium/Standard is required." ValidationGroup="searchAttendance"
                                                        ControlToValidate="ddlBMS"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblDivision" runat="server" Text="Division:" meta:resourcekey="lblDivisionResource1"></asp:Label>
                                                </td>
                                                <td colspan="3">
                                                    <asp:DropDownList ID="ddlDivision" runat="server" AutoPostBack="true" Enabled="false">
                                                        <asp:ListItem Text="-- Select --" Value="0"></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="rqdDivision" Text="." InitialValue="0" runat="server"
                                                        ErrorMessage="Division is required." ValidationGroup="searchAttendance" ControlToValidate="ddlDivision"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblDate" runat="server" Text="Date:" meta:resourcekey="lblDateResource1"></asp:Label>
                                                </td>
                                                <td colspan="3">
                                                    <asp:TextBox ID="txtDate" runat="server"></asp:TextBox>
                                                    <asp:ImageButton ID="ibtnDate" runat="server" ImageUrl="~/App_Themes/Images/Calender.gif"
                                                        Width="20px" />
                                                    <cc2:CalendarExtender ID="calExt" runat="server" TargetControlID="txtDate" PopupButtonID="ibtnDate"
                                                        Enabled="true" Format="dd-MMM-yyyy">
                                                    </cc2:CalendarExtender>
                                                    <asp:RequiredFieldValidator ID="rqdDate" runat="server" ErrorMessage="Date is required"
                                                        Text="." ControlToValidate="txtDate" ValidationGroup="searchAttendance"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                </td>
                                                <td>
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnsubmit_Click"
                                                                    CssClass="gobutton" ValidationGroup="searchAttendance" meta:resourcekey="btnSubmitResource1" />
                                                            </td>
                                                            <td>
                                                                <asp:Button ID="btnReset" runat="server" CssClass="gobutton" Text="Reset" OnClick="btnReset_Click"
                                                                    meta:resourcekey="btnResetResource1" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4">
                                                    <asp:ValidationSummary ID="vsumAttendance" runat="server" ShowMessageBox="true" ShowSummary="false"
                                                        ValidationGroup="searchAttendance" />
                                                </td>
                                            </tr>
                                        </table>
                                    </fieldset>
                                </asp:Panel>
                            </div>
                            <div>
                                <fieldset>
                                    <legend>
                                        <asp:Label ID="lblPerLegend" runat="server" Text="Attendance Details" CssClass="SubTitle"
                                            meta:resourcekey="lblPerLegendResource1"></asp:Label></legend>
                                    <table class="tblControls" id="tblPercentage" runat="server" style="width: 80%;">
                                        <tr>
                                            <td colspan="2">
                                                <asp:Label ID="lblAttendanceDateDisplay" runat="server" Text="Attendance Date:" meta:resourcekey="lblAttendanceDateDisplayResource1"></asp:Label>
                                                <asp:Label ID="lblAttendanceDate" runat="server"></asp:Label>
                                            </td>
                                            <td colspan="2">
                                                <asp:Label ID="lblSortBy" runat="server" Text="SortBy:" meta:resourcekey="lblSortByResource1"></asp:Label>
                                                <asp:DropDownList ID="ddlSorting" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlSorting_SelectedIndexChanged"
                                                    Enabled="false">
                                                    <asp:ListItem Value="0" Text="RollNo" Selected="True"></asp:ListItem>
                                                    <asp:ListItem Value="1" Text="Name"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblTotalAttendanceDisplay" runat="server" Text="Total Attendance:"
                                                    meta:resourcekey="lblTotalAttendanceDisplayResource1"></asp:Label>
                                            </td>
                                            <td colspan="3">
                                                <div>
                                                    <asp:Label ID="lblPresentPerVal" runat="server"></asp:Label>
                                                    <asp:Label ID="lblPresentPer" runat="server" CssClass="ApChartGreen" Height="25px"></asp:Label><asp:Label
                                                        ID="lblAbsentPer" runat="server" CssClass="ApChartRed" Height="25px"></asp:Label>
                                                    <asp:Label ID="lblAbsentPerVal" runat="server"></asp:Label>
                                                </div>
                                            </td>
                                            <td style="vertical-align: bottom;">
                                                <div>
                                                    <asp:Label ID="lblPresent" runat="server" BackColor="Green" Width="10px" Height="10px"></asp:Label>
                                                    <asp:Label ID="lblPre" runat="server" Text="Present" meta:resourcekey="lblPreResource1"></asp:Label>
                                                    <asp:Label ID="lblPval" runat="server"></asp:Label>
                                                    <br />
                                                    <asp:Label ID="lblAbsent" runat="server" BackColor="Red" Width="10px" Height="10px"></asp:Label>
                                                    <asp:Label ID="lblAbs" runat="server" Text="Absent" meta:resourcekey="lblAbsResource1"></asp:Label>
                                                    <asp:Label ID="lblAval" runat="server"></asp:Label>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </fieldset>
                            </div>
                            <div>
                                <fieldset style="width: 100%;">
                                    <legend>
                                        <asp:Label ID="lgdStudentList" runat="server" Text="Student List" CssClass="SubTitle"
                                            meta:resourcekey="lgdStudentListResource1"></asp:Label></legend>
                                    <table class="tblControls" id="tblStudentList" runat="server" style="width: 100%;">
                                        <tr>
                                            <td colspan="4" style="background-color: #DDDEE0;">
                                                <asp:DataList ID="DlStudentAttendance" runat="server" RepeatColumns="2" BackColor="#ffffff"
                                                    CellSpacing="3" RepeatDirection="Horizontal" Height="100%" Width="100%" HorizontalAlign="Center"
                                                    CellPadding="3" meta:resourcekey="DlStudentAttendanceResource1">
                                                    <SelectedItemStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                                                    <HeaderTemplate>
                                                        <tr>
                                                            <th>
                                                            </th>
                                                            <th align="left">
                                                                <asp:Label ID="lblRollNoHead" runat="server" Text="Roll No" Style="font-size: 1.2em;"
                                                                    meta:resourcekey="lblRollNoHeadResource1"></asp:Label>
                                                            </th>
                                                            <th align="left">
                                                                <asp:Label ID="lblNameHead" runat="server" Text="Name" Style="font-size: 1.2em;"
                                                                    meta:resourcekey="lblNameHeadResource1"></asp:Label>
                                                            </th>
                                                            <th>
                                                            </th>
                                                            <th>
                                                            </th>
                                                            <th>
                                                            </th>
                                                        </tr>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td>
                                                                <asp:CheckBox ID="ChkAttendance" runat="server" Checked='<%#Eval("Status") %>' meta:resourcekey="ChkAttendanceResource1" />
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="LblIndex" runat="server" Text='<%# Eval("RollNo") %>' meta:resourcekey="LblSequenceResource1"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="LblStudentName" runat="server" Text='<%# Eval("Student") %>' meta:resourcekey="LblStudentNameResource1"></asp:Label>
                                                            </td>
                                                            <td style="padding-left: 5px;">
                                                                <asp:Label ID="LblStudentID" runat="server" Text='<%#Eval("StudentID") %>' Enabled="false"
                                                                    Visible="false"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="LblAttendanceID" runat="server" Text='<%# Eval("AttendanceID") %>'
                                                                    meta:resourcekey="LblStudentIDResource1" Visible="false"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="LblASID" runat="server" Text='<%# Eval("ASID") %>' meta:resourcekey="LblStudentIDResource1"
                                                                    Visible="false"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </ItemTemplate>
                                                </asp:DataList>
                                            </td>
                                        </tr>
                                    </table>
                                </fieldset>
                            </div>
                            <div>
                                <asp:Button ID="BtnFillAttedance" runat="server" Text="Fill Attendance" OnClick="BtnFillAttedance_Click"
                                    meta:resourcekey="BtnFillAttedanceResource1" />
                                <asp:Button Text="Back" PostBackUrl="../Dashboard/TeacherDashboard.aspx" runat="server" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="ddlBMS" />
            <asp:AsyncPostBackTrigger ControlID="btnSubmit" />
        </Triggers>
    </asp:UpdatePanel>
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
    <%--  </ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>
