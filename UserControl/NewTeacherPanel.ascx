<%@ Control Language="C#" AutoEventWireup="true" CodeFile="NewTeacherPanel.ascx.cs"
    Inherits="UserControl_NewTeacherPanel" %>
<asp:Panel ID="BMSPanel" runat="server" Width="100%" meta:resourcekey="BMSPanelResource1">
    <div class="activitydiv activityleft">
        <div class="ActivityHeader">
            <asp:Label ID="LblPageTitle" CssClass="BMStitle" runat="server" Text="Not Selected"></asp:Label>
        </div>
        <div class="ActivityContent">
            <div class="bmsdiv">
                <asp:Label ID="lblBoard" runat="server" Text="BMS:" ToolTip="Board/Medium/Standard"
                    CssClass="textlabel" meta:resourceKey="lblBoardResource1"></asp:Label>
                <asp:DropDownList ID="ddlBoard" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlBoard_SelectedIndexChanged"
                    meta:resourceKey="ddlBoardResource1">
                    <asp:ListItem Text="-- Select --" meta:resourceKey="ListItemResource1"></asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rqdDdlBoard" runat="server" ControlToValidate="ddlBoard"
                    InitialValue="-- Select --" ErrorMessage="Please Select BMS." ValidationGroup="PnlBMS"
                    meta:resourceKey="rqdDdlBoardResource1">*</asp:RequiredFieldValidator>
            </div>
            <div>
                <asp:Label ID="lblSubject" runat="server" Text="Subject:" CssClass="textlabel" meta:resourceKey="lblSubjectResource1"></asp:Label>
                <asp:DropDownList ID="ddlSubject" runat="server" meta:resourceKey="ddlSubjectResource1">
                    <asp:ListItem Text="-- Select --" meta:resourceKey="ListItemResource4"></asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rqdDdlSubject" runat="server" ControlToValidate="ddlSubject"
                    InitialValue="-- Select --" ErrorMessage="Please Select Subject." ValidationGroup="PnlBMS"
                    meta:resourceKey="rqdDdlSubjectResource1">*</asp:RequiredFieldValidator>
            </div>
            <div>
                <asp:Label ID="lblDivision" runat="server" Text="Division:" CssClass="textlabel"
                    meta:resourceKey="lblDivisionResource1"></asp:Label>
                <asp:DropDownList ID="ddlDivision" runat="server" meta:resourceKey="ddlDivisionResource1">
                    <asp:ListItem Text="-- Select --" meta:resourceKey="ListItemResource2"></asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rqdDdlDivision" runat="server" ControlToValidate="ddlDivision"
                    InitialValue="-- Select --" ErrorMessage="Please Select Division." ValidationGroup="PnlBMS"
                    meta:resourceKey="rqdDdlDivisionResource1">*</asp:RequiredFieldValidator>
            </div>
            <div class="gobotton">
                <asp:Button ID="btnOk" Text="GO" runat="server" ValidationGroup="PnlBMS" OnClick="btnOk_Click"
                    meta:resourceKey="btnOkResource1" />
            </div>
            <div>
                <asp:ValidationSummary ID="vsumPnlBMS" runat="server" ValidationGroup="PnlBMS" ShowMessageBox="True"
                    ShowSummary="False" meta:resourceKey="vsumPnlBMSResource1" />
            </div>
        </div>
    </div>
</asp:Panel>
