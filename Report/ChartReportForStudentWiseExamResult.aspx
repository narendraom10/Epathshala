﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Epathshala.master" AutoEventWireup="true" CodeFile="ChartReportForStudentWiseExamResult.aspx.cs" Inherits="Report_ChartReportForStudentWiseExamResult" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:Label ID="lblstudentname" runat = "server"></asp:Label>
    <asp:Chart ID="Chart1" runat="server">
    
        <Series >
            <asp:Series Name="Series1" IsValueShownAsLabel="true">
            </asp:Series>
        </Series>
        <ChartAreas >
            <asp:ChartArea Name="ChartArea1" >
            </asp:ChartArea>
        </ChartAreas>
    </asp:Chart>
    
</asp:Content>

