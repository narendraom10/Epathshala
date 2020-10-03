<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Epathshala.master" AutoEventWireup="true"
    CodeFile="TeacherFeedback.aspx.cs" Inherits="Teacher_TeacherFeedback" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="upTeacherFeedback" runat="server">
        <ContentTemplate>
            <table id="tblTeacherFeedback" runat="server" class="InnerTableStyle RoundTop tblControls"
                cellpadding="0" cellspacing="0" width="100%">
                <tr runat="server">
                    <td class="Header round" runat="server">
                        <asp:Label ID="lblTitle" runat="server" Text="Teacher Feedback" 
                            meta:resourcekey="lblTitleResource1"></asp:Label>
                    </td>
                </tr>
                <tr runat="server">
                    <td runat="server">
                        <table id="tblTeacherFeedbackDetails" runat="server" class="tblControls">
                            <tr runat="server">
                                <td style="text-align: right;" runat="server">
                                    <asp:Label ID="lblFeedbackSubjcet" runat="server" Text="Feedback:" 
                                        meta:resourcekey="lblFeedbackSubjcetResource1"></asp:Label>
                                </td>
                                <td runat="server">
                                    <asp:DropDownList ID="ddlFeedbackSubject" runat="server" AutoPostBack="True" 
                                        meta:resourcekey="ddlFeedbackSubjectResource1">
                                        <asp:ListItem Value="0" Text="-- Select --" 
                                            meta:resourcekey="ListItemResource1"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td runat="server">
                                </td>
                            </tr>
                            <tr runat="server">
                                <td style="text-align: right;" runat="server">
                                    <asp:Label ID="lblBMS" runat="server" Text="BMS:" 
                                        meta:resourcekey="lblBMSResource1"></asp:Label>
                                </td>
                                <td colspan="3" runat="server">
                                    <asp:DropDownList ID="ddlBMS" runat="server" OnSelectedIndexChanged="ddlBMS_SelectedIndexChanged"
                                        AutoPostBack="True" Width="440px" meta:resourcekey="ddlBMSResource1">
                                        <asp:ListItem Value="0" Text="-- Select --" 
                                            meta:resourcekey="ListItemResource2"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr runat="server">
                                <td style="text-align: right;" runat="server">
                                    <asp:Label ID="lblSubject" runat="server" Text="Subject:" 
                                        meta:resourcekey="lblSubjectResource1"></asp:Label>
                                </td>
                                <td runat="server">
                                    <asp:DropDownList ID="ddlSubject" runat="server" AutoPostBack="True" 
                                        meta:resourcekey="ddlSubjectResource1">
                                        <asp:ListItem Value="0" Text="-- Select --" 
                                            meta:resourcekey="ListItemResource3"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td style="text-align: right;" runat="server">
                                    <asp:Label ID="lblDivision" runat="server" Text="Division:" 
                                        meta:resourcekey="lblDivisionResource1"></asp:Label>
                                </td>
                                <td runat="server">
                                    <asp:DropDownList ID="ddlDivision" runat="server" AutoPostBack="True" 
                                        meta:resourcekey="ddlDivisionResource1">
                                        <asp:ListItem Value="0" Text="-- Select --" 
                                            meta:resourcekey="ListItemResource4"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr runat="server">
                                <td style="text-align: right;" runat="server">
                                    <asp:Label ID="lblFeedbackDetails" runat="server" Text="Details:" 
                                        meta:resourcekey="lblFeedbackDetailsResource1"></asp:Label>
                                </td>
                                <td colspan="3" runat="server">
                                    <asp:TextBox ID="txtFeedbackDetails" runat="server" TextMode="MultiLine" 
                                        Width="440px" meta:resourcekey="txtFeedbackDetailsResource1"></asp:TextBox>
                                </td>
                            </tr>
                            <tr runat="server">
                                <td runat="server">
                                </td>
                                <td runat="server">
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="gobutton" 
                                                    meta:resourcekey="btnSubmitResource1" />
                                            </td>
                                            <td>
                                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="gobutton" 
                                                    meta:resourcekey="btnCancelResource1" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
