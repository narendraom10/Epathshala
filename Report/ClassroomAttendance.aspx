<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Epathshala.master" AutoEventWireup="true" EnableEventValidation="false"
    CodeFile="ClassroomAttendance.aspx.cs" Inherits="Student_Report_ClassroomAttendance" culture="auto" meta:resourcekey="PageResource2" uiculture="auto" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <table cellpadding="0" cellspacing="0" width="100%" class="InnerTableStyle RoundTop tblControls">
            <tr>
                <td class="Header RoundTop">
                    <asp:Label ID="lblTitle" runat="server" 
                        Text="Classroom attendance report of the day" 
                        meta:resourcekey="lblTitleResource1"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <table style="text-align: center;" width="100%" class="tblControls">
                        <tr>
                            <td>
                                <asp:Label ID="lblSchool" runat="server" Text="School:" 
                                    meta:resourcekey="lblSchoolResource1"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblSchoolValue" runat="server" 
                                    meta:resourcekey="lblSchoolValueResource1"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblBMS" runat="server" Text="BMS:" 
                                    meta:resourcekey="lblBMSResource1"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblBMSValue" runat="server" 
                                    meta:resourcekey="lblBMSValueResource1"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblDiv" runat="server" Text="Division:" 
                                    meta:resourcekey="lblDivResource1"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblDivValue" runat="server" 
                                    meta:resourcekey="lblDivValueResource1"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblDate" runat="server" Text="Date:" 
                                    meta:resourcekey="lblDateResource1"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblDateValue" runat="server" 
                                    meta:resourcekey="lblDateValueResource1"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblAttendance" runat="server" Text="Attendance(%):" 
                                    meta:resourcekey="lblAttendanceResource1"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblAttendanceValue" runat="server" 
                                    meta:resourcekey="lblAttendanceValueResource1"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2">
                                <asp:GridView ID="grdAttendance" runat="server" AutoGenerateColumns="False" AllowPaging="True"
                                    OnPageIndexChanging="grdClassroomWiseAttendance_PageIndexChanging" OnRowCreated="grdClassroomWiseAttendance_RowCreated"
                                    OnSorting="grdClassroomWiseAttendance_Sorting" ShowFooter="True" 
                                    OnRowDataBound="grdAttendance_RowDataBound" 
                                    meta:resourcekey="grdAttendanceResource1">
                                    <FooterStyle Font-Bold="true" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Sr. No" 
                                            meta:resourcekey="TemplateFieldResource1">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex + 1 %></ItemTemplate>
                                            <ItemStyle Width="10px" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Student" HeaderText="Student" 
                                            SortExpression="Student" meta:resourcekey="BoundFieldResource1" />
                                        <asp:BoundField DataField="Attendance" HeaderText="Attendance" 
                                            SortExpression="Attendance" meta:resourcekey="BoundFieldResource2" />
                                    </Columns>
                                    <PagerTemplate>
                                        <div style="text-align: center;">
                                            <asp:ImageButton Text="First" CommandName="Page" CommandArgument="First" runat="server"
                                                ImageUrl="~/App_Themes/Images/first.png" ID="ibtnFirst" 
                                                ToolTip="Move First Page" meta:resourcekey="ibtnFirstResource1" />
                                            <asp:ImageButton Text="Previous" CommandName="Page" CommandArgument="Prev" runat="server"
                                                ImageUrl="~/App_Themes/Images/previous.png" ID="ibtnPrevious" 
                                                ToolTip="Move Previous Page" meta:resourcekey="ibtnPreviousResource1" />
                                            <asp:Label ID="lblPage" runat="server" Text="Page" 
                                                meta:resourcekey="lblPageResource1"></asp:Label>
                                            <asp:DropDownList ID="ddlPageSelector" OnSelectedIndexChanged="ddlPageSelector_SelectedIndexChanged"
                                                runat="server" AutoPostBack="True" SkinID="DdlWidth50" 
                                                meta:resourcekey="ddlPageSelectorResource1">
                                            </asp:DropDownList>
                                            <asp:ImageButton Text="Next" CommandName="Page" CommandArgument="Next" runat="server"
                                                ImageUrl="~/App_Themes/Images/NEXT.png" ID="ibtnNext" 
                                                ToolTip="Move Next Page" meta:resourcekey="ibtnNextResource1" />
                                            <asp:ImageButton Text="Last" CommandName="Page" CommandArgument="Last" runat="server"
                                                ImageUrl="~/App_Themes/Images/last.png" ID="ibtnLast" 
                                                ToolTip="Move Last Page" meta:resourcekey="ibtnLastResource1" />
                                        </div>
                                    </PagerTemplate>
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="4">
                                <asp:Button ID="btnback" runat="server" Text="Back" OnClick="btnback_Click" 
                                    meta:resourcekey="btnbackResource1" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
