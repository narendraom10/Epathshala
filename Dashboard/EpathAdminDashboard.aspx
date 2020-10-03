<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Epathshala.master" AutoEventWireup="true"
    CodeFile="EpathAdminDashboard.aspx.cs" Inherits="Admin_EpathAdminDashboard" %>

<%@ Register Src="~/UserControl/TeacherNotes.ascx" TagName="TeacherNotes" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <div style="display: inline-block; float: left; width: 40%; padding-left: 5%;">
            <asp:UpdatePanel ID="upEadmin" runat="server">
                <ContentTemplate>
                    <table class="TableControl" width="100%">
                        <tr>
                            <td>
                                <uc2:TeacherNotes ID="ucNotes" runat="server" />
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div style="display: inline-block; float: left; width: 40%; padding-left: 5%;">
            <table class="TableControl" width="100%">
                <tr>
                    <td>
                        <table class="InnerTableStyle RoundTop" width="100%" align="center" cellpadding="0"
                            cellspacing="0">
                            <tr>
                                <td align="center" class="Header12 GridViewHeadercssTestAssessment RoundTop" colspan="2">
                                    <asp:Label runat="server" Text="Recent Registration"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:GridView ID="gvRegistration" runat="server" AutoGenerateColumns="False" PageSize="5">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Student Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSchool" runat="server" Text='<%# Eval("StudentName") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Contact Number" >
                                                <ItemTemplate>
                                                    <asp:Label ID="lblBMSSCT" runat="server" Text='<%# Eval("ContactNo") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="EmailID" >
                                                <ItemTemplate>
                                                    <asp:Label ID="lblNote" runat="server" Text='<%# Eval("EmailID") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Registration Date">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCreatedOn" runat="server" Text='<%# string.Format("{0:dd-MMM-yyyy}", Eval("CreatedOn")) %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <EmptyDataTemplate>
                                            No Registration Found
                                        </EmptyDataTemplate>
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <asp:LinkButton ID="lnkViewAllAdmission" runat="server" Text="View All" OnClick="lnkViewAllAdmission_Click"></asp:LinkButton>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
