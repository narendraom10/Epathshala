<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TeacherPanel.ascx.cs"
    Inherits="UserControl_TeacherPanel" %>
<asp:Panel ID="BMSPanel" runat="server" Width="800px" 
    meta:resourcekey="BMSPanelResource1">
    <table cellpadding="2" cellspacing="2" width="98%" style="margin: 5px 5px 5px 5px">
        <tr>
            <td align="right">
                <asp:Label ID="lblBoard" runat="server" Text="Board:" 
                    meta:resourceKey="lblBoardResource1"></asp:Label>
            </td>
            <td style="margin-left: 40px">
                <asp:DropDownList ID="ddlBoard" runat="server" Width="150px" 
                    meta:resourceKey="ddlBoardResource1" AutoPostBack="True" 
                    onselectedindexchanged="ddlBoard_SelectedIndexChanged">
                    <asp:ListItem Text="-- Select --" meta:resourceKey="ListItemResource1"></asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rqdDdlBoard" runat="server" ControlToValidate="ddlBoard"
                    InitialValue="-- Select --" ErrorMessage="Must Select Board." 
                    ValidationGroup="PnlBMS" meta:resourceKey="rqdDdlBoardResource1">*</asp:RequiredFieldValidator>
            </td>
            <td align="right">
                <asp:Label ID="lblMedium" runat="server" Text="Medium:" 
                    meta:resourceKey="lblMediumResource1"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlMedium" runat="server" Width="150px" 
                    meta:resourceKey="ddlMediumResource1" AutoPostBack="True" 
                    onselectedindexchanged="ddlMedium_SelectedIndexChanged">
                    <asp:ListItem Text="-- Select --" meta:resourceKey="ListItemResource2"></asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rqdDdlMedium" runat="server" ControlToValidate="ddlMedium"
                    InitialValue="-- Select --" ErrorMessage="Must Select Medium." 
                    ValidationGroup="PnlBMS" meta:resourceKey="rqdDdlMediumResource1">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="lblStandard" runat="server" Text="Standard:" 
                    meta:resourceKey="lblStandardResource1"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlStandard" runat="server" Width="150px" AutoPostBack="True"
                    OnSelectedIndexChanged="ddlStandard_SelectedIndexChanged" 
                    meta:resourceKey="ddlStandardResource1">
                    <asp:ListItem Text="-- Select --" meta:resourceKey="ListItemResource3"></asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rqdDdlStandard" runat="server" ControlToValidate="ddlStandard"
                    InitialValue="-- Select --" ErrorMessage="Must Select Standard." 
                    ValidationGroup="PnlBMS" meta:resourceKey="rqdDdlStandardResource1">*</asp:RequiredFieldValidator>
            </td>
            <td align="right">
                <asp:Label ID="lblSubject" runat="server" Text="Subject:" 
                    meta:resourceKey="lblSubjectResource1"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlSubject" runat="server" Width="150px" 
                    meta:resourceKey="ddlSubjectResource1">
                    <asp:ListItem Text="-- Select --" meta:resourceKey="ListItemResource4"></asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rqdDdlSubject" runat="server" ControlToValidate="ddlSubject"
                    InitialValue="-- Select --" ErrorMessage="Must Select Subject." 
                    ValidationGroup="PnlBMS" meta:resourceKey="rqdDdlSubjectResource1">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="lblDivision" runat="server" Text="Division:" 
                    meta:resourceKey="lblDivisionResource1"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlDivision" runat="server" Width="150px" 
                    meta:resourceKey="ddlDivisionResource1">
                    <asp:ListItem Text="-- Select --" meta:resourceKey="ListItemResource5"></asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rqdDdlDivision" runat="server" ControlToValidate="ddlDivision"
                    InitialValue="-- Select --" ErrorMessage="Must Select Division." 
                    ValidationGroup="PnlBMS" meta:resourceKey="rqdDdlDivisionResource1">*</asp:RequiredFieldValidator>
            </td>
            <td align="right" style="padding-right: 30px">
                <asp:Button ID="btnOk" Text="GO" runat="server" CssClass="gobutton" ValidationGroup="PnlBMS"
                    OnClick="btnOk_Click" meta:resourceKey="btnOkResource1" />
            </td>
        </tr>
        <tr>
            <td colspan="6" align="center">
                <asp:ValidationSummary ID="vsumPnlBMS" runat="server" ValidationGroup="PnlBMS" ShowMessageBox="True"
                    ShowSummary="False" meta:resourceKey="vsumPnlBMSResource1" />
            </td>
        </tr>
    </table>
</asp:Panel>
