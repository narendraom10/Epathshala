<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Epathshala.master" AutoEventWireup="true"
    CodeFile="SendAssesmentMail.aspx.cs" Inherits="Dashboard_SendAssesmentMail" %>

<%@ Register Src="~/UserControl/SendMailToStudent.ascx" TagName="StudentList" TagPrefix="StudentList" %>
<%@ PreviousPageType VirtualPath="~/Dashboard/EducationalResource.aspx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="width: 90%; margin: auto">
        <StudentList:StudentList ID="stdlist" runat="server" PageTitle="" />
    </div>
</asp:Content>
