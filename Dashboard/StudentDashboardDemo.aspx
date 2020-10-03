<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StudentDashboardDemo.aspx.cs"
    Inherits="Dashboard_StudentDashboardDemo" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>ePathshala</title>
    <style type="text/css">
        label
        {
            display: inline-block;
            width: 5em;
        }
        #wrap
        {
            width: auto;
            position: relative;
        }
        
        .left, .right
        {
            float: left;
        }
        
        .right
        {
            float: right;
        }
    </style>
    <style type="text/css">
        .textlabelDemo
        {
            width: 85px;
            float: left;
            height: auto;
            clear: both;
            padding-top: 4px;
            white-space: nowrap;
        }
        .tblDashboard tr td
        {
            vertical-align: top;
            text-align: left;
            padding: 3px;
        }
        
        .tblDashboard .Header
        {
            color: #096B6B;
            text-align: center;
            padding: 5px;
            margin: 25px;
        }
        
        
        .tblDashboard .LeftPart
        {
            padding-right: 15px;
        }
        
        .Width300
        {
            min-width: 300px;
            max-width: 300px;
        }
        .Width700
        {
            min-width: 700px;
            max-width: 700px;
        }
        
        .Width1000px
        {
            min-width: 1000px;
            max-width: 1000px;
            max-height: 700px;
        }
        
        .MarginBottom15px
        {
            margin-bottom: 15px;
        }
        
        .RBPadding
        {
            padding: 15px;
            width: 100%;
        }
        
        
        .RBPadding input[type="radio"]
        {
            margin: 3px;
        }
        
        #header1
        {
            max-width: 100%;
        }
        #header1
        {
            background-color: #FFF;
            position: relative;
            display: inline-block;
            min-width: 100%;
            height: 140px;
        }
        
        #logo2 a img
        {
            float: left;
            margin-top: 35px;
            position: relative;
            margin-bottom: 0px;
        }
        img
        {
            border: medium none;
        }
        
        
        
        #btnopenflv
        {
            background-color: White !important;
            color: Black !important;
            border: none !important;
            box-shadow: 0.00em 0.00em 0.000em #444 !important;
            text-align: left !important;
        }
        
        #btnopenflv:link
        {
            color: #ff0000 !important;
        }
        #btnopenflv:visited
        {
            color: #0000ff !important;
        }
        #btnopenflv:hover
        {
            color: Blue !important;
        }
        
        .hideshowbutton
        {
            visibility: hidden;
            display: none;
        }
    </style>
    <script src="../JavaScript/jquery-1.4.2.js" type="text/javascript"></script>
    <script src="../App_Themes/Responsive/js/jquery-2.1.1.js" type="text/javascript"></script>

    
 <%--   <script type="text/javascript" >




        $(document).ready(function () {

            jQuery(function ($) {
                debugger;
                $('#showme')
            .bind('beforeShow', function () {
                debugger;
                alert('beforeShow');
            })
            .bind('afterShow', function () {
                debugger;
                alert('afterShow');
            })
            .show(1000, function () {
                if ($('#showme').attr("style").toString() == "visibility: visible;") {

                    $('#showme').animate({ left: '250px', height: '328px', top: '150px' },
                         {
                             duration: 900,
                             specialEasing:
                             {
                                 top: "easeOutBounce",
                                 left: "linear"
                             }
                         });

                }
            });

            });
        });
    </script>--%>
    
<script>
    (function (i, s, o, g, r, a, m) {
        i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {
            (i[r].q = i[r].q || []).push(arguments)
        }, i[r].l = 1 * new Date(); a = s.createElement(o),
  m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
    })(window, document, 'script', '//www.google-analytics.com/analytics.js', 'ga');

    ga('create', 'UA-69363607-1', 'auto');
    ga('send', 'pageview');

</script>

</head>
<body onclick="clicked=true;">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="header" style="z-index: 1;">
        <div id="headerwrap">
            <div id="logo2" style="margin-left: 70px">
                <a href="#">&nbsp;<img src="../App_Themes/Responsive/web/logo.png" alt="Epathshala logo"
                    id="dvICICIEpath" runat="server" /></a>
            </div>
            <div class="contactMaster">
                <ul>
                    <li class="innerhead">
                        <asp:Label CssClass="Welcome" runat="server" ID="lblWelcome" Style="font-size: 1.05em;
                            color: #2E3192; text-align: right; white-space: nowrap;"></asp:Label>
                    </li>
                    <li class="innerhead">
                        <asp:LinkButton runat="server" ID="lbtnSignOut" Text="Sign Out" CssClass="logoutButton"
                            OnClick="lbtnSignOut_Click"></asp:LinkButton>
                    </li>
                </ul>
            </div>
        </div>
    </div>
    <div style="display: inline-block; width: 100%; background-color: #2E3192; box-shadow: 0 4px 9px #4D4D4D;
        border-top: 2px solid #484ce2; position: relative; z-index: 2;">
        <div class="newmenuwrap" style="position: relative;">
            <ul id="qm3" class="qmmc11">
                <li id="liStudDashboard" runat="server" style="border-right: 1px solid #000000;"><a
                    href="#" target="_self">
                    <asp:Label ID="lblStudDashboard" runat="server" Text="Dashboard"></asp:Label>
                </a></li>
                <li id="liProfile" runat="server" style="border-right: 1px solid #000000;"><a href="#"
                    target="_self">
                    <asp:Label ID="lblProfile" runat="server" Text="Profile"></asp:Label>
                </a></li>
                <li id="liStudentPackage" runat="server" style="border-right: 1px solid #000000;"><a
                    href="#" target="_self">
                    <asp:Label ID="lblStudentPackage" runat="server" Text="Student Packages"></asp:Label>
                </a></li>
                <li id="liSelectPackage" runat="server" style="border-right: 1px solid #000000;"><a
                    href="#" target="_self">
                    <asp:Label ID="lblSelectPackage" runat="server" Text="Buy Package"></asp:Label>
                </a></li>
                <li id="li5" runat="server" style="border-right: 1px solid #000000;"><a href="#"
                    target="_self">
                    <asp:Label ID="Label12" runat="server" Text="Report"></asp:Label>
                </a></li>
                <li id="li4" runat="server"><a href="#" target="_self">
                    <asp:Label ID="Label11" runat="server" Text="Contact Us"></asp:Label>
                </a></li>
            </ul>
        </div>
    </div>
    <%--<div id="banner" style="z-index: 0;">
        <div id="bannerwrap">
        </div>
    </div>--%>
    <div style="width: 90%; margin: auto; position: relative;">
        <div class="firstpanel" style="margin-top: 20px;">
            <div class="activitydiv activityleft">
                <div class="ActivityHeader">
                    <asp:Label ID="Label1" runat="server" Text="Select Subject"></asp:Label>
                </div>
                <%-- <uc1:StudentPanel ID="StudentPanel" runat="server" />--%>
                <asp:RadioButtonList ID="rbSubjectList" runat="server" RepeatDirection="Horizontal"
                    CssClass="RBPadding" RepeatColumns="3" AutoPostBack="True" CellSpacing="10" CellPadding="10"
                    OnSelectedIndexChanged="rbSubjectList_SelectedIndexChanged" meta:resourcekey="rbSubjectListResource1">
                </asp:RadioButtonList>
            </div>
            <div class="activitydiv activityright">
                <div class="ActivityHeader">
                    <asp:Label ID="lblTodayAct" runat="server" Text="Select Chapter and Topic" meta:resourcekey="lblTodayActResource1"></asp:Label>
                </div>
                <div class="ActivityContent">
                    <%--    <div class="radiobotton">
                        <asp:RadioButtonList ID="rblChapters" runat="server" RepeatDirection="Horizontal"
                            AutoPostBack="True" Visible="False" OnSelectedIndexChanged="rblChapters_SelectedIndexChanged"
                            meta:resourcekey="rblChaptersResource1">
                            <asp:ListItem Selected="True" Value="1" Text=" Uncovered Chapters" meta:resourcekey="lblListItem1"></asp:ListItem>
                            <asp:ListItem Value="2" Text=" Covered Chapters" meta:resourcekey="lblListItem2"></asp:ListItem>
                        </asp:RadioButtonList>
                    </div>--%>
                    <div>
                        <asp:Label ID="lblChapter1" runat="server" Text="Chapter:" meta:resourcekey="lblChapterResource1"
                            CssClass="textlabelDemo"></asp:Label>
                        <asp:DropDownList ID="ddlChapter" runat="server" Width="180px" Enabled="False" AutoPostBack="True"
                            meta:resourcekey="ddlChapterResource1" OnSelectedIndexChanged="ddlChapter_SelectedIndexChanged1">
                            <asp:ListItem Text="-- Select --" meta:resourcekey="listItemResource1"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rqdddlChapter" runat="server" ControlToValidate="ddlChapter"
                            InitialValue="-- Select --" ErrorMessage="Please Select Chapter." ValidationGroup="TA"
                            meta:resourcekey="rqdddlChapterResource1">*</asp:RequiredFieldValidator>
                    </div>
                    <div>
                        <asp:Label ID="lblTopic1" runat="server" Text="Topic:" meta:resourcekey="lblTopicResource1"
                            CssClass="textlabel"></asp:Label>
                        <asp:DropDownList ID="ddlTopic" runat="server" Width="180px" Enabled="False" meta:resourcekey="ddlTopicResource1">
                            <asp:ListItem Text="-- Select --" meta:resourcekey="ListItemResource2"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rqdddlTopic" runat="server" ControlToValidate="ddlTopic"
                            InitialValue="-- Select --" ErrorMessage="Please Select Topic." ValidationGroup="TA"
                            meta:resourcekey="rqdddlTopicResource1">*</asp:RequiredFieldValidator>
                    </div>
                    <div class="gobotton">
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" ValidationGroup="TA" CssClass="gobutton"
                            meta:resourcekey="btnSubmitResource1" OnClick="btnSubmit_Click" />
                        <asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="gobutton" OnClick="btnReset_Click"
                            meta:resourcekey="btnResetResource1" />
                        <asp:ValidationSummary ID="vsum" runat="server" ValidationGroup="TA" ShowMessageBox="True"
                            ShowSummary="False" meta:resourcekey="vsumResource1" />
                    </div>
                </div>
            </div>
        </div>
        <div class="firstpanel">
            <div class="activitydiv activityleft">
                <div class="ActivityHeader">
                    <asp:Label ID="lblSyllabus" runat="server" Text="Syllabus Covered" meta:resourcekey="lblSyllabusResource1"></asp:Label>
                </div>
                <div class="ActivityContent">
                    <div class="persentagetagbox" style="visibility: hidden;">
                        <div class="persentagediv">
                            <asp:Label ID="lblCovered1" CssClass="persentage" runat="server" ForeColor="#009B32"></asp:Label>
                            <asp:Label runat="server" ID="LblCoveredChapter" CssClass="ApChartGreen" Height="25px"
                                ForeColor="White"></asp:Label><asp:Label runat="server" ID="LblUncoveredChapter"
                                    CssClass="ApChartRed" ForeColor="White" Height="25px"></asp:Label>
                            <asp:Label ID="lblUncovered1" runat="server" CssClass="persentage" ForeColor="#ED0000"></asp:Label>
                        </div>
                        <div class="lblcover">
                            <asp:Label ID="LblCoveredChapter1" runat="server" BackColor="Green" Width="10px"
                                Height="10px"></asp:Label>
                            <asp:Label ID="LblCoveredChapter2" runat="server" Text="Covered Chapters" Font-Size="14px"
                                meta:resourcekey="LblCoveredChapter2"></asp:Label>
                            <asp:Label ID="lblCovered" runat="server" Font-Size="14px" ForeColor="Green" Font-Names="Roboto-Black"></asp:Label>
                        </div>
                        <div class="lblcover">
                            <asp:Label ID="LblUncoveredChapter1" runat="server" BackColor="Red" Width="10px"
                                Height="10px"></asp:Label>
                            <asp:Label ID="LblUncoveredChapter2" runat="server" Text="Uncovered Chapters" Font-Size="14px"
                                meta:resourcekey="LblUncoveredChapter2"></asp:Label>
                            <asp:Label ID="lblUncovered" runat="server" Font-Size="14px" ForeColor="Red" Font-Names="Roboto-Black"></asp:Label>
                        </div>
                    </div>
                    <div class="chapterlist">
                        <asp:TreeView ID="tvSyllabus" runat="server" meta:resourcekey="tvSyllabusResource1"
                            OnSelectedNodeChanged="tvSyllabus_SelectedNodeChanged">
                            <HoverNodeStyle Font-Underline="false" ForeColor="#5555DD" />
                            <NodeStyle CssClass="Node" HorizontalPadding="5px" NodeSpacing="0px" VerticalPadding="0px" />
                            <ParentNodeStyle Font-Bold="False" />
                            <SelectedNodeStyle Font-Underline="false" ForeColor="#5555DD" HorizontalPadding="0px"
                                VerticalPadding="0px" />
                        </asp:TreeView>
                    </div>
                </div>
            </div>
            <div class="activitydiv activityright" style="margin-bottom: 15px;">
                <div class="ActivityHeader">
                    <asp:Label ID="Label3" runat="server" Text="Search Chapter"></asp:Label>
                </div>
                <div class="ActivityContent">
                    <div style="margin-top: 15px;">
                        <asp:Label ID="lblkeyword" runat="server" Text="Keyword:" Style="padding: 0px 0px 5px 5px;"></asp:Label>
                        <asp:TextBox ID="txtkeyword" CssClass="text" Style="padding: 0 5px; width: 90%;"
                            runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvkeyword" ValidationGroup="vgSearch" ControlToValidate="txtkeyword"
                            runat="server" ErrorMessage="*" Text="*"></asp:RequiredFieldValidator>
                    </div>
                    <div style="margin-top: 10px;">
                        <asp:Button ID="btnsearcksubmit" runat="server" Text="Search" ValidationGroup="vgSearch"
                            OnClick="btnsearcksubmit_Click" />
                        <asp:Button ID="BtnHome" runat="server" Text="Cancel" OnClientClick="javascript:return CloseSearch();" />
                    </div>
                    <div style="font-size: 10px; margin-top: 10px; padding-left: 10px; font-weight: bold;">
                        Search result based on Board, Medium, Standard, Subject, Chapter, Chapter Description
                        and Topic Name
                    </div>
                    <asp:ValidationSummary ID="vsSearch" ShowMessageBox="false" ShowSummary="false" ValidationGroup="vgSearch"
                        runat="server" />
                </div>
            </div>
            <div class="activitydiv activityright">
                <div class="ActivityHeader">
                    <asp:Label ID="lblLastActivity" runat="server" Text="Last Activity" meta:resourcekey="lblLastActivityResource1"></asp:Label>
                </div>
                <div class="ActivityContent">
                    <div>
                        <asp:Label ID="lblLastChapter" runat="server" Text="Chapter:" meta:resourcekey="lblLastChapterResource1"></asp:Label>
                        <span style="padding-left: 16px">
                            <asp:Label ID="lblLastChapterName" runat="server" Text="Chapter Name" meta:resourcekey="lblLastChapterNameResource1"></asp:Label>
                        </span>
                    </div>
                    <div>
                        <asp:Label ID="lblLastTopic" runat="server" Text="Topic:"></asp:Label>
                        <span style="padding-left: 32px">
                            <asp:Label ID="lblLastTopicName" runat="server" Text="Topic Name"></asp:Label>
                        </span>
                    </div>
                    <div class="">
                        <asp:Label ID="lbllastcontent" runat="server" Text="Content:"></asp:Label>
                        <%--<asp:HyperLink ID="hlopenflv" runat="server" Text="Click here to view last content"></asp:HyperLink>--%>
                        <asp:Button ID="btnopenflv" runat="server" Text="click here to view last content"
                            CssClass="two" OnClick="btnopenflv_Click" Width="250px" />
                    </div>
                </div>
            </div>
        </div>
        <div class="firstpanel">
            <div class="activitydiv activityleft" id="fsExpiryNotification" runat="server" visible="true">
                <div class="ActivityHeader">
                    <asp:Label ID="lblLegendExpiryNotification" runat="server" Text="Current Packages"></asp:Label>
                </div>
                <div class="ActivityContent">
                    <%--   <asp:Label ID="lblExpiryMessage" runat="server" Text="Follwing packages will expire in a couple of days."
                        meta:resourcekey="lblExpiryMessageResource1"></asp:Label>--%>
                    <div>
                        <asp:GridView ID="gvSubjectExpiryNotification" runat="server" Visible="true" AutoGenerateColumns="False"
                            meta:resourcekey="gvSubjectExpiryNotificationResource1">
                            <Columns>
                                <asp:BoundField DataField="Subject" HeaderText="Subject" />
                                <asp:BoundField DataField="PackageType" HeaderText="Package Type" />
                                <asp:BoundField DataField="FromDate" HeaderText="Activate On" DataFormatString="{0:dd-MMM-yyyy}" />
                                <asp:BoundField DataField="ValidTill" HeaderText="Expired On" DataFormatString="{0:dd-MMM-yyyy}" />
                            </Columns>
                        </asp:GridView>
                        <asp:GridView ID="gvComboExpiryNotification" runat="server" Visible="False" AutoGenerateColumns="False"
                            meta:resourcekey="gvComboExpiryNotificationResource1">
                            <Columns>
                                <asp:BoundField DataField="Standard" HeaderText="Standard" />
                                <asp:BoundField DataField="Name" HeaderText="Package Type" />
                                <asp:BoundField DataField="FromDate" HeaderText="Activate On" />
                                <asp:BoundField DataField="ValidTill" HeaderText="Expired On" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
            <div class="activitydiv activityright">
                <div class="ActivityHeader">
                    <asp:Label ID="Label2" runat="server" Text="Expired Packages"></asp:Label>
                </div>
                <div class="ActivityContent">
                    <asp:GridView ID="gvExpiredPackageList" runat="server" Visible="true" AutoGenerateColumns="False">
                        <Columns>
                            <asp:BoundField DataField="Subject" HeaderText="Subject" />
                            <asp:BoundField DataField="PackageType" HeaderText="Package Type" />
                            <asp:BoundField DataField="FromDate" HeaderText="Activate On" DataFormatString="{0:dd-MMM-yyyy}" />
                            <asp:BoundField DataField="ValidTill" HeaderText="Expired On" DataFormatString="{0:dd-MMM-yyyy}" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
            <div>
            </div>
        </div>
    </div>
    <%-- Begin Code for view last content--%>
    <asp:Button ID="btnShow" runat="server" Text="Show Modal Popup" Style="display: none"
        meta:resourcekey="btnShowResource1" />
    <!-- ModalPopupExtender -->
    <cc1:ModalPopupExtender ID="mp1" runat="server" PopupControlID="Display" TargetControlID="btnShow"
        BackgroundCssClass="modalBackground" DynamicServicePath="" Enabled="True">
    </cc1:ModalPopupExtender>
    <!-- ModalPopupExtender -->
    <%--Container Area/Div For ModalPopupExtender--%>
    <div id="Display" runat="server" meta:resourcekey="SelectBMSResource1" style="position: fixed;
        top: 0px; left: 0px; width: 100%; height: 100%;">
        <%--Header Area--%>
        <div id="ActivityHeader1" runat="server" class="ActivityHeader1" style="min-height: 35px;
            margin-left: 1px; text-align: left;">
            <asp:Label ID="LblDisplay" runat="server" Text="Display Resource" ForeColor="#777"
                Font-Bold="true" meta:resourceKey="LblDisplay" Style="margin-left: 200px; display: inline-block;"></asp:Label>
            <div style="float: right; padding: 10px 10px 0px 0px;">
                <asp:ImageButton ID="ibtnClose" runat="server" Text="Close" OnClientClick=" return confirm('Do you want to close current activity ?');"
                    CausesValidation="False" meta:resourceKey="btnCloseResource1" ImageUrl="~/App_Themes/Images/close.png"
                    Height="20px" Width="20px" />
            </div>
            <div id="dvICICI" runat="server" visible="false">
                <div style="position: fixed; top: 16px; left: 136px;">
                    <div id="icicilogo">
                        <img src="../App_Themes/Responsive/web/icicic2.png" alt="No Img" style="width: 170px;" />
                    </div>
                </div>
            </div>
        </div>
        <%--Animation Area--%>
        <div class="activitydivfull" style="position: relative; width: 100%; height: 100%;
            margin: auto; top: 0px; left: 0px;">
            <div class="ActivityContent" style="top: 0px; margin: 0px auto; width: auto; height: inherit;">
                <iframe id="myframe" height="90%" width="100%" runat="server"></iframe>
            </div>
        </div>
    </div>
    <asp:LinkButton ID="hitme" Text="SHOW" runat="server" CssClass="hideshowbutton"/>
    <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" PopupControlID="showme"
        ClientIDMode="Static" BackgroundCssClass="modalbg" TargetControlID="hitme">
    </cc1:ModalPopupExtender>
    <div id="showme" runat="server" class="schoolboard" >
        <p>
            You have to register to view this content
            <br />
            Do you want to register now ?
        </p>
        <br />
        <br />
        <asp:LinkButton ID="close" class="btn" Text="Register Now" runat="server" OnClick="close_Click" />
        &nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="LinkButton1" class="btn" Text="No Thanks" runat="server" />
    </div>
    <%--End--%>
    <div id="copyrightfooter" style="z-index: 0;">
        <div class="copyright">
            <p>
                Copyright © 2015, All Rights Reserved. <a href="http://www.epath.net.in" target="_blank">
                    Arraycom (India) Ltd. - Epath Division</a>
            </p>
        </div>
    </div>
    </form>
</body>
</html>
