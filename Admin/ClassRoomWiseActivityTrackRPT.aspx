<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Epathshala.master" AutoEventWireup="true"
    CodeFile="ClassRoomWiseActivityTrackRPT.aspx.cs" Inherits="Admin_ClassRoomWiseActivityTrackRPT" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <table cellpadding="0" cellspacing="0" width="100%" class="InnerTableStyle RoundTop tblControls">
            <tr>
                <td class="Header RoundTop">
                    <asp:Label ID="lblTitle" runat="server" Text="Classroom wise activity Track log report"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <table style="text-align: center;" width="100%" class="tblControls">
                        <tr>
                            <td>
                                <asp:Label ID="lblSchool" runat="server" Text="School:"></asp:Label>
                            </td>
                            <td style="text-align: left;" colspan="3">
                                <asp:DropDownList ID="ddlSchool" runat="server" Width="450px" AutoPostBack="true"
                                    OnSelectedIndexChanged="ddlSchool_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RFVddlSchool" runat="server" ErrorMessage="Please Select School."
                                    ControlToValidate="ddlSchool" ValidationGroup="a" InitialValue="0">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblBoard" runat="server" Text="Board:"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlBoard" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlBoard_SelectedIndexChanged">
                                    <asp:ListItem Value="0" Text="-- Select --"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Label ID="lblMedium" runat="server" Text="Medium:"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlMedium" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlMedium_SelectedIndexChanged">
                                    <asp:ListItem Value="0" Text="-- Select --"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblStandard" runat="server" Text="Standard:"> </asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlStandard" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlStandard_SelectedIndexChanged">
                                    <asp:ListItem Value="0" Text="-- Select --"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Label ID="lblDivision" runat="server" Text="Division:"></asp:Label>
                            </td>
                            <td colspan="3" style="text-align: left;">
                                <asp:DropDownList ID="ddlDivision" runat="server" AutoPostBack="true">
                                    <asp:ListItem Value="0" Text="-- Select --"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblFromDate" runat="server" Text="From Date:"></asp:Label>
                            </td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtFromDate" runat="server" onKeypress="return(false)"></asp:TextBox>
                                <asp:ImageButton ID="ibtnDate" runat="server" ImageUrl="~/App_Themes/Images/Calender.gif"
                                    Width="20px" />
                                <cc2:CalendarExtender ID="calExt" runat="server" TargetControlID="txtFromDate" PopupButtonID="ibtnDate"
                                    Enabled="true" Format="dd-MM-yyyy">
                                </cc2:CalendarExtender>
                            </td>
                            <td>
                                <asp:Label ID="lblToDate" runat="server" Text="To Date:"></asp:Label>
                            </td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtToDate" runat="server" onKeypress="return(false)"></asp:TextBox>
                                <asp:ImageButton ID="ibtnToDate" runat="server" ImageUrl="~/App_Themes/Images/Calender.gif"
                                    Width="20px" />
                                <cc2:CalendarExtender ID="calExtTodate" runat="server" TargetControlID="txtToDate"
                                    PopupButtonID="ibtnToDate" Enabled="true" Format="dd-MM-yyyy">
                                </cc2:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: center;" colspan="4">
                                <table width="100%">
                                    <tr>
                                        <td style="text-align: center;">
                                            <asp:Button ID="btnGo" runat="server" Text="Go" OnClick="btnGo_Click" ValidationGroup="a" />
                                            &nbsp;
                                             <asp:Button ID="btnreset" runat="server" Text="Reset" CausesValidation="false" 
                                                onclick="btnreset_Click"/>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="text-align: center;">
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="a"
                        ShowMessageBox="true" ShowSummary="false" />
                </td>
            </tr>
            <tr>
                <td>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
