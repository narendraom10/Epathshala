<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Epathshala.master" AutoEventWireup="true"
    CodeFile="SendFinishActivityMail.aspx.cs" Inherits="Dashboard_SendFinishActivityMail" %>

<%@ Register Src="~/UserControl/SendMailToStudent.ascx" TagName="StudentList" TagPrefix="StudentList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="width: 90%; margin: auto">
        <StudentList:StudentList ID="stdlist" runat="server" PageTitle="Finish Activity Mail" />
    </div>
</asp:Content>
