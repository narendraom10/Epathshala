<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Epathshala.master" AutoEventWireup="true"
    CodeFile="ManageServerConfig.aspx.cs" Inherits="Utility_ManageServerConfig" Culture="auto"
    meta:resourcekey="PageResource1" UICulture="auto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="RoundTop InnerTableStyle TableControl" width="90%" cellpadding="0"
        cellspacing="0">
        <tr>
            <td class="Header12 GridViewHeadercssTestAssessment RoundTop" colspan="4">
                <asp:Label ID="lblFeedBackReportHeader" runat="server" Text="Manage smtp server config"
                    meta:resourcekey="lblFeedBackReportHeaderResource1"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <table class="tblControl1">
                    <tr>
                        <td>
                            <asp:Label ID="lblHost" Text="Host:" runat="server" meta:resourcekey="lblHostResource1"></asp:Label>
                        </td>
                        <td style="text-align: left;">
                            <asp:TextBox ID="txtHost" runat="server" meta:resourcekey="txtHostResource1"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="reqValHost" runat="server" ValidationGroup="server"
                                ErrorMessage="Host is required." Text="." ControlToValidate="txtHost" meta:resourcekey="reqValHostResource1"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:Label ID="lblPort" Text="Port:" runat="server" meta:resourcekey="lblPortResource1"></asp:Label>
                        </td>
                        <td style="text-align: left;">
                            <asp:TextBox ID="txtPort" runat="server" meta:resourcekey="txtPortResource1"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="reqValPort" Text="." runat="server" ValidationGroup="server"
                                ErrorMessage="Port is required" ControlToValidate="txtPort" meta:resourcekey="reqValPortResource1"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revPortNo" runat="server" ErrorMessage="Only numbers and characters are allowed in SMTP Port"
                                ToolTip="Only numbers and characters are allowed in SMTP Port" Text="." ValidationGroup="a"
                                ValidationExpression="^[0-9]+$" ControlToValidate="txtPort" meta:resourcekey="revPortNoResource1"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblUserName" Text="UserName:" runat="server" meta:resourcekey="lblUserNameResource1"></asp:Label>
                        </td>
                        <td style="text-align: left;">
                            <asp:TextBox ID="txtUserName" runat="server" meta:resourcekey="txtUserNameResource1"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="reqValUserName" Text="." runat="server" ValidationGroup="server"
                                ErrorMessage="Username is required." ControlToValidate="txtUserName" meta:resourcekey="reqValUserNameResource1"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:Label ID="lblEmailAddress" Text="EmailAddress:" runat="server" meta:resourcekey="lblEmailAddressResource1"></asp:Label>
                        </td>
                        <td style="text-align: left;">
                            <asp:TextBox ID="txtEmailAddress" runat="server" meta:resourcekey="txtEmailAddressResource1"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="reqValemailAddress" Text="." runat="server" ValidationGroup="server"
                                ErrorMessage="Email address is required." ControlToValidate="txtEmailAddress"
                                meta:resourcekey="reqValemailAddressResource1"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblPassword" Text="Password:" runat="server" meta:resourcekey="lblPasswordResource1"></asp:Label>
                        </td>
                        <td style="text-align: left;">
                            <asp:TextBox ID="txtPassword" runat="server" meta:resourcekey="txtPasswordResource1"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="reqValPassword" runat="server" Text="." ValidationGroup="server"
                                ErrorMessage="Password is required" ControlToValidate="txtPassword" meta:resourcekey="reqValPasswordResource1"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:Label ID="lnlEnableSSL" Text="EnableSSl:" runat="server" meta:resourcekey="lnlEnableSSLResource1"></asp:Label>
                        </td>
                        <td style="text-align: left;">
                            <asp:DropDownList ID="ddlEnableSSl" runat="server" meta:resourcekey="ddlEnableSSlResource1">
                                <asp:ListItem Value="0" Text="False" meta:resourcekey="ListItemResource1"></asp:ListItem>
                                <asp:ListItem Value="1" Text="True" meta:resourcekey="ListItemResource2"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            <asp:Button ID="btnSubmit" runat="server" Text="Submit" ValidationGroup="server"
                                OnClick="btnSubmit_Click" meta:resourcekey="btnSubmitResource1" />
                        </td>
                        <td colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <asp:ValidationSummary ID="valSumServer" runat="server" ShowMessageBox="True" ShowSummary="False"
                                ValidationGroup="server" meta:resourcekey="valSumServerResource1" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
