<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Epathshala.master" AutoEventWireup="true"
    CodeFile="ViewAllTeacherAnnouncement.aspx.cs" Inherits="Teacher_ViewAllTeacherAnnouncement"
    Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="RoundTop InnerTableStyle TableControl" width="75%" cellpadding="0"
        cellspacing="0">
        <tr>
            <td colspan="2" align="center" class="Header12 RoundTop GridViewHeadercssTestAssessment">
                <asp:Label ID="Label1" runat="server" Text="All Announcement" meta:resourcekey="Label1Resource1"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <table>
                    <tr>
                        <td align="center" style="padding: 5px 5px 5px 5px">
                            <asp:DataList ID="dlAnnouncement" runat="server" meta:resourcekey="dlAnnouncementResource1">
                                <ItemTemplate>
                                    <table>
                                        <tr>
                                            <td colspan="2" style="text-align: left; color: Maroon">
                                                <ul type="circle">
                                                    <li>
                                                        <asp:Label ID="lblTeacherAnnouncementDate" runat="server" Text='<%# String.Format("{0:dd-MMM-yyyy}",Eval("StartDate")) %>'
                                                            meta:resourcekey="lblTeacherAnnouncementDateResource1"></asp:Label>
                                                    </li>
                                                </ul>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="text-align: left; color: Gray; padding: 0 0 0 1px">
                                                <asp:Label ID="lblTeacherAnnouncement" runat="server" Text='<%# Limit(Eval("Announcement"),80) %>'
                                                    ToolTip='<%# Eval("Announcement") %>'></asp:Label>
                                            </td>
                                        </tr>
                                        <tr style="border: 4px none gray">
                                            <td colspan="2">
                                                <hr />
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </asp:DataList>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
