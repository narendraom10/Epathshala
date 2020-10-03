<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Epathshala.master" AutoEventWireup="true"
    EnableEventValidation="false" CodeFile="ClassroomWiseAttendance.aspx.cs" Inherits="Student_Report_ClassroomWiseAttendance"
    Culture="auto" meta:resourcekey="PageResource2" UICulture="auto" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <table cellpadding="0" cellspacing="0" width="100%" class="InnerTableStyle RoundTop tblControls">
            <tr>
                <td class="Header RoundTop">
                    <asp:Label ID="lblTitle" runat="server" Text="Classroom wise attendance report of the day"
                        meta:resourcekey="lblTitleResource1"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <table style="text-align: center;" width="100%" class="tblControls">
                        <tr>
                            <td>
                                <asp:Label ID="lblSchool" runat="server" Text="School:" meta:resourcekey="lblSchoolResource1"></asp:Label>
                            </td>
                            <td style="text-align: left;" colspan="3">
                                <asp:DropDownList ID="ddlSchool" runat="server" Width="450px" AutoPostBack="True"
                                    OnSelectedIndexChanged="ddlSchool_SelectedIndexChanged" meta:resourcekey="ddlSchoolResource1">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RFVddlSchool" runat="server" ErrorMessage="Please Select School."
                                    ControlToValidate="ddlSchool" ValidationGroup="a" InitialValue="0" meta:resourcekey="RFVddlSchoolResource1">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblBoard" runat="server" Text="Board:" meta:resourcekey="lblBoardResource1"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlBoard" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlBoard_SelectedIndexChanged"
                                    meta:resourcekey="ddlBoardResource1">
                                    <asp:ListItem Value="0" Text="-- Select --" meta:resourcekey="ListItemResource1"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Label ID="lblMedium" runat="server" Text="Medium:" meta:resourcekey="lblMediumResource1"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlMedium" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlMedium_SelectedIndexChanged"
                                    meta:resourcekey="ddlMediumResource1">
                                    <asp:ListItem Value="0" Text="-- Select --" meta:resourcekey="ListItemResource2"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblStandard" runat="server" Text="Standard:" meta:resourcekey="lblStandardResource1"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlStandard" runat="server" style="width:140px;" AutoPostBack="True" OnSelectedIndexChanged="ddlStandard_SelectedIndexChanged"
                                    meta:resourcekey="ddlStandardResource1">
                                    <asp:ListItem Value="0" Text="-- Select --" meta:resourcekey="ListItemResource3"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Label ID="lblDivision" runat="server" Text="Division:" meta:resourcekey="lblDivisionResource1"></asp:Label>
                            </td>
                            <td colspan="3" style="text-align: left;">
                                <asp:DropDownList ID="ddlDivision" runat="server" AutoPostBack="True" meta:resourcekey="ddlDivisionResource1">
                                    <asp:ListItem Value="0" Text="-- Select --" meta:resourcekey="ListItemResource4"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblDate" runat="server" Text="Date:" meta:resourcekey="lblDateResource1"></asp:Label>
                            </td>
                            <td colspan="3" style="text-align: left;">
                                <asp:TextBox ID="txtDate" runat="server" onKeypress="return(false)" meta:resourcekey="txtDateResource1"></asp:TextBox>
                                <asp:ImageButton ID="ibtnDate" runat="server" ImageUrl="~/App_Themes/Images/Calender.gif"
                                    Width="20px" meta:resourcekey="ibtnDateResource1" />
                                <cc2:CalendarExtender ID="calExt" runat="server" TargetControlID="txtDate" PopupButtonID="ibtnDate"
                                    Enabled="True" Format="dd-MMM-yyyy">
                                </cc2:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: center;" colspan="4">
                                <table width="100%">
                                    <tr>
                                        <td style="text-align: center;">
                                            <asp:Button ID="btnGo" runat="server" Text="Go" OnClick="btnGo_Click" ValidationGroup="a"
                                                meta:resourcekey="btnGoResource1" />
                                            <asp:Button ID="btnReset" runat="server" Text="Reset" OnClick="btnReset_Click" meta:resourcekey="btnResetResource1" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
                <tr>
                    <td style="text-align: center;">
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="a"
                            ShowMessageBox="True" ShowSummary="False" meta:resourcekey="ValidationSummary1Resource1" />
                    </td>
                </tr>
            </tr>
            <tr>
                <td>
                    <table>
                        <tr>
                            <td>
                                <asp:GridView ID="grdClassroomWiseAttendance" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                    OnPageIndexChanging="grdClassroomWiseAttendance_PageIndexChanging" OnRowCreated="grdClassroomWiseAttendance_RowCreated"
                                    OnSorting="grdClassroomWiseAttendance_Sorting" OnRowDataBound="grdClassroomWiseAttendance_RowDataBound"
                                    Width="100%" DataKeyNames="BMSID,DivisionID,SchoolID,Attendance,Division" meta:resourcekey="grdClassroomWiseAttendanceResource1"
                                    OnSelectedIndexChanged="grdClassroomWiseAttendance_SelectedIndexChanged">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Sr. No" meta:resourcekey="TemplateFieldResource1">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex +1 %></ItemTemplate>
                                            <ItemStyle Width="10px" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="BMS" HeaderText="Board >> Medium >> Standard" SortExpression="BMS" meta:resourcekey="BoundFieldResource1" />
                                        <asp:BoundField DataField="Division" HeaderText="Division" SortExpression="Division"
                                            meta:resourcekey="BoundFieldResource2" />
                                        <asp:BoundField DataField="Attendance" HeaderText="Attendance (%)" SortExpression="Attendance"
                                            meta:resourcekey="BoundFieldResource3" />
                                        <asp:BoundField DataField="Teacher" HeaderText="Class Teacher" SortExpression="Teacher"
                                            meta:resourcekey="BoundFieldResource4" />
                                    </Columns>
                                    <PagerTemplate>
                                        <div style="text-align: center;">
                                            <asp:ImageButton Text="First" CommandName="Page" CommandArgument="First" runat="server"
                                                ImageUrl="~/App_Themes/Images/first.png" ID="ibtnFirst" ToolTip="Move First Page"
                                                meta:resourcekey="ibtnFirstResource1" />
                                            <asp:ImageButton Text="Previous" CommandName="Page" CommandArgument="Prev" runat="server"
                                                ImageUrl="~/App_Themes/Images/previous.png" ID="ibtnPrevious" ToolTip="Move Previous Page"
                                                meta:resourcekey="ibtnPreviousResource1" />
                                            <asp:Label ID="lblPage" runat="server" Text="Page" meta:resourcekey="lblPageResource1"></asp:Label>
                                            <asp:DropDownList ID="ddlPageSelector" OnSelectedIndexChanged="ddlPageSelector_SelectedIndexChanged"
                                                runat="server" AutoPostBack="True" SkinID="DdlWidth50" meta:resourcekey="ddlPageSelectorResource1">
                                            </asp:DropDownList>
                                            <asp:ImageButton Text="Next" CommandName="Page" CommandArgument="Next" runat="server"
                                                ImageUrl="~/App_Themes/Images/NEXT.png" ID="ibtnNext" ToolTip="Move Next Page"
                                                meta:resourcekey="ibtnNextResource1" />
                                            <asp:ImageButton Text="Last" CommandName="Page" CommandArgument="Last" runat="server"
                                                ImageUrl="~/App_Themes/Images/last.png" ID="ibtnLast" ToolTip="Move Last Page"
                                                meta:resourcekey="ibtnLastResource1" />
                                        </div>
                                    </PagerTemplate>
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
