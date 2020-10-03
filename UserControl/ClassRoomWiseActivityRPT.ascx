<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ClassRoomWiseActivityRPT.ascx.cs"
    Inherits="UserControl_ClassRoomWiseActivityRPT" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<table cellpadding="0" cellspacing="0" width="100%">
    <tr>
        <td class="PageHeader">
            <asp:Label ID="lblTitle" runat="server" Text="Classroomwise Result Report" 
                meta:resourcekey="lblTitleResource1"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            <table cellpadding="2" cellspacing="2" width="100%" style="margin: 5px 5px 5px 5px">
                <tr>
                    <td align="right">
                        <asp:Label ID="lblSchool" runat="server" Text="School:" ToolTip="School Name:" 
                            meta:resourcekey="lblSchoolResource1"></asp:Label>
                    </td>
                    <td colspan="3">
                        <asp:DropDownList ID="ddlSchool" runat="server" Width="450px" AutoPostBack="True"
                            OnSelectedIndexChanged="ddlSchool_SelectedIndexChanged" 
                            meta:resourcekey="ddlSchoolResource1">
                            <asp:ListItem Text="-- Select --" Value="0" 
                                meta:resourcekey="ListItemResource1"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RFVddlSchool" runat="server" ControlToValidate="ddlSchool"
                            InitialValue="0" ErrorMessage="Please Select School." ValidationGroup="a" 
                            meta:resourcekey="RFVddlSchoolResource1">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="lblBoard" runat="server" Text="Board:" ToolTip="Board" 
                            meta:resourcekey="lblBoardResource1"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlBoard" runat="server" AutoPostBack="True" AppendDataBoundItems="True"
                            OnSelectedIndexChanged="ddlBoard_SelectedIndexChanged" 
                            meta:resourcekey="ddlBoardResource1">
                            <asp:ListItem Text="-- Select --" Value="0" 
                                meta:resourcekey="ListItemResource2"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="ReqFieldBoard" runat="server" ErrorMessage="Please select board"
                            ValidationGroup="a" InitialValue="0" ControlToValidate="ddlBoard" 
                            meta:resourcekey="ReqFieldBoardResource1">*</asp:RequiredFieldValidator>
                    </td>
                    <td align="right">
                        <asp:Label ID="lblMedium" runat="server" Text="Medium:" 
                            meta:resourcekey="lblMediumResource1"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlMedium" runat="server" AutoPostBack="True" AppendDataBoundItems="True"
                            Enabled="False" OnSelectedIndexChanged="ddlMedium_SelectedIndexChanged" 
                            meta:resourcekey="ddlMediumResource1">
                            <asp:ListItem Text="-- Select --" Value="0" 
                                meta:resourcekey="ListItemResource3"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="ReqFieldMedium" runat="server" ErrorMessage="Please select medium"
                            ValidationGroup="a" InitialValue="0" ControlToValidate="ddlMedium" 
                            meta:resourcekey="ReqFieldMediumResource1">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="lblStandard" runat="server" Text="Standard:" 
                            meta:resourcekey="lblStandardResource1"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlStandard" runat="server" AppendDataBoundItems="True" Enabled="False"
                            AutoPostBack="True" 
                            OnSelectedIndexChanged="ddlStandard_SelectedIndexChanged" 
                            meta:resourcekey="ddlStandardResource1">
                            <asp:ListItem Text="-- Select --" Value="0" 
                                meta:resourcekey="ListItemResource4"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td align="right">
                        <asp:Label ID="lblsubject" runat="server" Text="Subject:" 
                            meta:resourcekey="lblsubjectResource1"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlsubject" runat="server" AppendDataBoundItems="True" Enabled="False"
                            AutoPostBack="True" 
                            OnSelectedIndexChanged="ddlsubject_SelectedIndexChanged" 
                            meta:resourcekey="ddlsubjectResource1">
                            <asp:ListItem Text="-- Select --" Value="0" 
                                meta:resourcekey="ListItemResource5"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="lblChapter" runat="server" Text="Chapter:" 
                            meta:resourcekey="lblChapterResource1"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlchapter" runat="server" AppendDataBoundItems="True" Enabled="False"
                            AutoPostBack="True" 
                            OnSelectedIndexChanged="ddlchapter_SelectedIndexChanged" 
                            meta:resourcekey="ddlchapterResource1">
                            <asp:ListItem Text="-- Select --" Value="0" 
                                meta:resourcekey="ListItemResource6"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td align="right">
                        <asp:Label ID="lbltopic" runat="server" Text="Topic:" 
                            meta:resourcekey="lbltopicResource1"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddltopic" runat="server" AppendDataBoundItems="True" Enabled="False"
                            OnSelectedIndexChanged="ddltopic_SelectedIndexChanged" 
                            meta:resourcekey="ddltopicResource1">
                            <asp:ListItem Text="-- Select --" Value="0" 
                                meta:resourcekey="ListItemResource7"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="lblfrmdate" runat="server" Text="From date:" 
                            meta:resourcekey="lblfrmdateResource1"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtfromdate" runat="server" 
                            meta:resourcekey="txtfromdateResource1"></asp:TextBox><asp:ImageButton ID="ibtnDate"
                            runat="server" ImageUrl="~/App_Themes/Images/Calender.gif" Width="20px" 
                            meta:resourcekey="ibtnDateResource1" /><asp:RequiredFieldValidator
                                ID="RequiredFieldValidator1" runat="server" 
                            ControlToValidate="txtfromdate" ValidationGroup="a"
                                ErrorMessage="Please enter From date" 
                            meta:resourcekey="RequiredFieldValidator1Resource1">*</asp:RequiredFieldValidator>
                        <cc2:CalendarExtender ID="ceDate" runat="server" Format="dd-MMM-yyyy" TargetControlID="txtfromdate"
                            PopupButtonID="ibtnDate" Enabled="True">
                        </cc2:CalendarExtender>
                    </td>
                    <td align="right">
                        <asp:Label ID="lbltodate" runat="server" Text="To date:" 
                            meta:resourcekey="lbltodateResource1"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txttodate" runat="server" 
                            meta:resourcekey="txttodateResource1"></asp:TextBox><asp:ImageButton ID="ibtnToDate"
                            runat="server" ImageUrl="~/App_Themes/Images/Calender.gif" Width="20px" 
                            meta:resourcekey="ibtnToDateResource1" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txttodate"
                            ValidationGroup="a" ErrorMessage="Please enter to date" 
                            meta:resourcekey="RequiredFieldValidator2Resource1">*</asp:RequiredFieldValidator>
                        <cc2:CalendarExtender ID="ceTodate" runat="server" Format="dd-MMM-yyyy" TargetControlID="txttodate"
                            PopupButtonID="ibtnToDate" Enabled="True">
                        </cc2:CalendarExtender>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        &nbsp;
                    </td>
                    <td colspan="2" align="left">
                        <asp:Button ID="btnview" runat="server" Text="View Report" OnClick="btnview_Click"
                            ValidationGroup="a" meta:resourcekey="btnviewResource1" />
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                            ShowSummary="False" ValidationGroup="a" 
                            meta:resourcekey="ValidationSummary1Resource1" />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
