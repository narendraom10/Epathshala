<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Epathshala.master" AutoEventWireup="true"
    EnableEventValidation="false" CodeFile="SchoolExamReports.aspx.cs" Inherits="Admin_SchoolExamReports" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<%@ Register Src="../UserControl/SchoolExamReports.ascx" TagName="SchoolExamReports"
    TagPrefix="uc1" %>
<%@ Register Src="../UserControl/SchoolExamReportsClassRpt.ascx" TagName="SchoolExamReports2"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <uc1:SchoolExamReports ID="SchoolExamReports1" runat="server" />
    <uc2:SchoolExamReports2 ID="SchoolExamReports2" runat="server" />
</asp:Content>
