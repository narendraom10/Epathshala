<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Epathshala.master" AutoEventWireup="true"
    CodeFile="ExamSummaryReort.aspx.cs" Inherits="Exam_ExamSummaryReort" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<%@ Register Src="~/UserControl/NewTeacherPanel.ascx" TagName="TeacherPanel" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .gobutton
        {
            height: 26px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td>
                <uc1:TeacherPanel ID="TeacherPanel1" runat="server" />
            </td>
        </tr>
        <tr>
            <td style="padding: 5px 5px 5px 5px">
                <table cellpadding="0" cellspacing="0" width="80%" class="InnerTableStyle RoundTop tblControls">
                    <tr>
                        <td colspan="2" class="Header round">
                            <asp:Label ID="LblExamEntry" runat="server" Text="Summary Report" 
                                meta:resourcekey="LblExamEntryResource1"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="Required" style="text-align: right;">
                            <asp:Label ID="LblChapter" runat="server" Text="Chapter:" 
                                meta:resourcekey="LblChapterResource1"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlChapter" runat="server" Width="215px" Enabled="False" 
                                AutoPostBack="True" 
                                onselectedindexchanged="ddlChapter_SelectedIndexChanged" 
                                meta:resourcekey="ddlChapterResource1">
                                <asp:ListItem Text="-- Select --" meta:resourcekey="ListItemResource1"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RFVDdlChapter" runat="server" ControlToValidate="DdlChapter"
                                InitialValue="-- Select --" ErrorMessage="Please Select Chapter." 
                                ValidationGroup="PnlBMS1" meta:resourcekey="RFVDdlChapterResource1">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="Required" style="text-align: right;">
                            <asp:Label ID="LblTopic" runat="server" Text="Topic:" 
                                meta:resourcekey="LblTopicResource1"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlTopic" runat="server" Width="215px" Enabled="False" 
                                meta:resourcekey="ddlTopicResource1">
                                <asp:ListItem Text="-- Select --" meta:resourcekey="ListItemResource2"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RFVDdlTopic" runat="server" ControlToValidate="DdlTopic"
                                InitialValue="-- Select --" ErrorMessage="Please Select Topic." 
                                ValidationGroup="PnlBMS1" meta:resourcekey="RFVDdlTopicResource1">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            <table>
                                <tr>
                                    <td>
                                        <asp:Button ID="BtnResult" Text="Show Result" runat="server" CssClass="gobutton"
                                            ValidationGroup="PnlBMS1" OnClick="BtnSubmit_Click" 
                                            meta:resourcekey="BtnResultResource1" />
                                    </td>
                                    <td>
                                        <asp:Button ID="btnReset" runat="server" CssClass="gobutton" Text="Reset" CausesValidation="False"
                                            OnClick="btnReset_Click" meta:resourcekey="btnResetResource1" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">
                            <asp:ValidationSummary ID="VSPnlBMS" runat="server" ValidationGroup="PnlBMS1" ShowMessageBox="True"
                                ShowSummary="False" meta:resourcekey="VSPnlBMSResource1" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">
                            <asp:GridView ID="GridStudentList" runat="server" SkinID="GridforReport" 
                                meta:resourcekey="GridStudentListResource1">
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">
                            <asp:Button ID="BtnPDF" Text="PDF View" runat="server" CssClass="gobutton" ValidationGroup="GridValidation"
                                Visible="False" OnClick="BtnPDF_Click" 
                                meta:resourcekey="BtnPDFResource1" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
