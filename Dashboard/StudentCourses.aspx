<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Epathshala.master" AutoEventWireup="true"
    CodeFile="StudentCourses.aspx.cs" Inherits="Dashboard_StudentCourses" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table id="tblTeacherNotes" runat="server" class="InnerTableStyle RoundTop tblControls"
        cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td class="Header round" colspan="2">
                <asp:Label ID="lblStudentCoursesHeader" runat="server" Text="Student Courses" 
                    meta:resourcekey="lblStudentCoursesHeaderResource1"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="gvStudentSubjects" runat="server" AutoGenerateColumns="False" 
                    Visible="False" meta:resourcekey="gvStudentSubjectsResource1">
                    <Columns>
                        <asp:BoundField DataField="Subject" HeaderText="Subject" 
                            meta:resourcekey="BoundFieldResource1" />
                        <asp:BoundField DataField="Name" HeaderText="Package Type" 
                            meta:resourcekey="BoundFieldResource2" />
                        <asp:BoundField DataField="FromDate" HeaderText="Valid From" 
                            meta:resourcekey="BoundFieldResource3" />
                        <asp:BoundField DataField="ValidTill" HeaderText="Valid Till" 
                            meta:resourcekey="BoundFieldResource4" />
                    </Columns>
                </asp:GridView>
                <asp:GridView ID="gvStudentCombo" runat="server" AutoGenerateColumns="False" 
                    Visible="False" meta:resourcekey="gvStudentComboResource1">
                    <Columns>
                        <asp:BoundField DataField="Standard" HeaderText="Standard" 
                            meta:resourcekey="BoundFieldResource5" />
                        <asp:BoundField DataField="Name" HeaderText="Package Type" 
                            meta:resourcekey="BoundFieldResource6" />
                        <asp:BoundField DataField="FromDate" HeaderText="Valid From" 
                            meta:resourcekey="BoundFieldResource7" />
                        <asp:BoundField DataField="ValidTill" HeaderText="Valid Till" 
                            meta:resourcekey="BoundFieldResource8" />
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
