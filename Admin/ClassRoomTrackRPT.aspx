<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Epathshala.master" AutoEventWireup="true"
    CodeFile="ClassRoomTrackRPT.aspx.cs" Inherits="Admin_ClassRoomTrackRPT" EnableEventValidation="false" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td class="PageHeader">
                <asp:Label ID="lblTitle" runat="server" Text="Class room wise track report" 
                    meta:resourcekey="lblTitleResource1"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <table cellpadding="2" cellspacing="2" width="100%" style="margin: 5px 5px 5px 5px">
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblSchool" runat="server" Text="School :" ToolTip="School Name:" 
                                meta:resourcekey="lblSchoolResource1"></asp:Label>
                        </td>
                        <td style="margin-left: 40px" colspan="5">
                            <asp:DropDownList ID="ddlSchool" runat="server" Width="450px" AutoPostBack="True"
                                OnSelectedIndexChanged="ddlSchool_SelectedIndexChanged" 
                                meta:resourcekey="ddlSchoolResource1">
                                <asp:ListItem Text="-- Select --" meta:resourcekey="ListItemResource1"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RFVddlSchool" runat="server" ControlToValidate="ddlSchool"
                                InitialValue="-- Select --" ErrorMessage="Please Select School." 
                                ValidationGroup="PnlBMS" meta:resourcekey="RFVddlSchoolResource1">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblBoard" runat="server" Text="BMS :" 
                                ToolTip="Board/Medium/Standard" meta:resourcekey="lblBoardResource1"></asp:Label>
                        </td>
                        <td style="margin-left: 40px" colspan="5">
                            <asp:DropDownList ID="ddlBoard" runat="server" Width="450px" AutoPostBack="True"
                                OnSelectedIndexChanged="ddlBoard_SelectedIndexChanged" 
                                meta:resourcekey="ddlBoardResource1">
                                <asp:ListItem Text="-- Select --" meta:resourcekey="ListItemResource2"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rqdDdlBoard" runat="server" ControlToValidate="ddlBoard"
                                InitialValue="-- Select --" ErrorMessage="Please Select BMS." 
                                ValidationGroup="PnlBMS" meta:resourcekey="rqdDdlBoardResource1">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblDivision" runat="server" Text="Division:" 
                                meta:resourcekey="lblDivisionResource1"></asp:Label>
                        </td>
                        <td style="margin-left: 40px" colspan="5">
                            <asp:DropDownList ID="ddlDivision" runat="server" Width="150px" 
                                meta:resourcekey="ddlDivisionResource1">
                                <asp:ListItem Text="-- Select --" meta:resourcekey="ListItemResource3"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rqdDdlDivision" runat="server" ControlToValidate="ddlDivision"
                                InitialValue="-- Select --" ErrorMessage="Please Select Division." 
                                ValidationGroup="PnlBMS" meta:resourcekey="rqdDdlDivisionResource1">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblFdate" runat="server" Text="Activity Date :" 
                                meta:resourcekey="lblFdateResource1"></asp:Label>
                        </td>
                        <td colspan="5" style="margin: 0px;">
                            <table width="70%" style="margin: 0px; padding: 0px" border="0">
                                <tr>
                                    <td align="left" valign="top">
                                        <asp:TextBox ID="txtFdate" runat="server" Width="147px" 
                                            meta:resourcekey="txtFdateResource1"></asp:TextBox>
                                        <asp:ImageButton ID="ibtnStartDate" runat="server" ImageUrl="~/App_Themes/Images/Calender.gif"
                                            Width="20px" meta:resourcekey="ibtnStartDateResource1" />
                                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFdate"
                                            PopupButtonID="ibtnStartDate" Enabled="True" Format="dd-MMM-yyyy">
                                        </cc1:CalendarExtender>
                                    </td>
                                    <td align="right" colspan="3">
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td align="left" width="50px" colspan="2">
                            <table>
                                <tr>
                                    <td>
                                        <asp:Button ID="btnOk" Text="GO" runat="server" CssClass="gobutton" ValidationGroup="PnlBMS"
                                            OnClick="btnOk_Click" meta:resourcekey="btnOkResource1" />&nbsp;
                                    </td>
                                    <td>
                                        <asp:Button ID="btnReset" Text="Reset" runat="server" CssClass="gobutton" 
                                            OnClick="btnReset_Click" meta:resourcekey="btnResetResource1" />&nbsp;
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td colspan="3">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6" align="center">
                            <asp:ValidationSummary ID="vsumPnlBMS" runat="server" ValidationGroup="PnlBMS" ShowMessageBox="True"
                                ShowSummary="False" meta:resourceKey="vsumPnlBMSResource1" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6" align="left">
                            <div id="dataDiv" runat="server" visible="false">
                                <table width="100%">
                                    <tr>
                                        <td align="right" valign="top" width="25%">
                                            &nbsp;
                                        </td>
                                        <td align="left" valign="top" colspan="3" width="75%">
                                            <asp:Button ID="btnExport" runat="server" Text="Export To Excel" 
                                                OnClick="btnExport_Click" meta:resourcekey="btnExportResource1" />
                                        </td>
                                    </tr>
                                    <div id="ContentDiv" runat="server">
                                        <tr>
                                            <td align="right" valign="top" width="25%">
                                                <asp:Label ID="lblActivityLogDate" runat="server" Text="Activity Log on :" 
                                                    meta:resourcekey="lblActivityLogDateResource1"></asp:Label>
                                            </td>
                                            <td align="left" valign="top" colspan="3" width="75%">
                                                <asp:Label ID="lblActivityLogDate1" runat="server" 
                                                    meta:resourcekey="lblActivityLogDate1Resource1"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" valign="top">
                                                <asp:Label ID="lblSchoolName" runat="server" Text="School Name :" 
                                                    meta:resourcekey="lblSchoolNameResource1"></asp:Label>
                                            </td>
                                            <td align="left" valign="top" colspan="3">
                                                <asp:Label ID="lblSchoolName1" runat="server" 
                                                    meta:resourcekey="lblSchoolName1Resource1"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" valign="top">
                                                <asp:Label ID="lblStd" runat="server" Text="Standard :" 
                                                    meta:resourcekey="lblStdResource1"></asp:Label>
                                            </td>
                                            <td align="left" valign="top">
                                                <asp:Label ID="lblStd1" runat="server" meta:resourcekey="lblStd1Resource1"></asp:Label>
                                            </td>
                                            <td align="right" valign="top">
                                                <asp:Label ID="lblDiv" runat="server" Text="Division :" 
                                                    meta:resourcekey="lblDivResource1"></asp:Label>
                                            </td>
                                            <td align="left" valign="top">
                                                <asp:Label ID="lblDiv1" runat="server" meta:resourcekey="lblDiv1Resource1"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" align="left">
                                                <asp:GridView ID="GridReportList" runat="server" SkinID="WithoutPageSize" 
                                                    meta:resourcekey="GridReportListResource1">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Sr.No" meta:resourcekey="TemplateFieldResource1">
                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex +1 %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="ActivityDate" HeaderText="Activity Date" 
                                                            meta:resourcekey="BoundFieldResource1" />
                                                        <asp:BoundField DataField="PageName" HeaderText="Page Name" 
                                                            meta:resourcekey="BoundFieldResource2" />
                                                        <asp:BoundField DataField="ControlName" HeaderText="Control Name" 
                                                            meta:resourcekey="BoundFieldResource3" />
                                                        <asp:BoundField DataField="EventName" HeaderText="Event Name" 
                                                            meta:resourcekey="BoundFieldResource4" />
                                                        <asp:BoundField DataField="Activity" HeaderText="Activity" 
                                                            meta:resourcekey="BoundFieldResource5" />
                                                        <asp:BoundField DataField="Remark" HeaderText="Remark" 
                                                            meta:resourcekey="BoundFieldResource6" />
                                                        <asp:BoundField DataField="Time Difference" HeaderText="Time" 
                                                            meta:resourcekey="BoundFieldResource7" />
                                                        <asp:BoundField DataField="Subject" HeaderText="Subject" 
                                                            meta:resourcekey="BoundFieldResource8" />
                                                        <asp:BoundField DataField="Teacher Name" HeaderText="Teacher Name" 
                                                            meta:resourcekey="BoundFieldResource9" />
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </div>
                                </table>
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
