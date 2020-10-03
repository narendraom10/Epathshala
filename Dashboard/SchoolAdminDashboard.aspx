<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Epathshala.master" AutoEventWireup="true"
    CodeFile="SchoolAdminDashboard.aspx.cs" Inherits="SchoolAdmin_SchoolAdminDashboard"
    Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/UserControl/AttendanceControl.ascx" TagName="Attendens" TagPrefix="uc1" %>
<%@ Register Src="~/UserControl/Announcement.ascx" TagName="Announcement" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
     <link href="../App_Themes/Responsive/media.css" rel="stylesheet" type="text/css" />
    <link href="../App_Themes/Responsive/css.css" rel="stylesheet" type="text/css" />
     <link href="../App_Themes/Responsive/menu.css" rel="stylesheet" type="text/css" />
      
    <link href="../App_Themes/Responsive/GeneralCss.css" rel="stylesheet" type="text/css" />
          
    <link href="../App_Themes/Responsive/GridView.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="tblDashboard">
        <div class="sidepanel">
            <div class="activitydivside">
                <div class="ActivityHeader">
                    <asp:Label ID="lblTitleAnnouncement" runat="server" Text="Announcement" meta:resourcekey="lblTitleAnnouncementResource1"></asp:Label>
                </div>
                <div class="ActivityContent">
                    <uc2:Announcement ID="menuAnnouncement" runat="server" />
                </div>
            </div>
        </div>
        <div class="sidepanel1">
            <div class="activitydivside1">
                <div class="ActivityHeader">
                    <asp:Label ID="lblAttendance" runat="server" Text="Attendance" meta:resourcekey="lblAttendanceResource1"></asp:Label>
                </div>
                <div class="ActivityContent">
                    <uc1:Attendens ID="menuAttendance" runat="server" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
