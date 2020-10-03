<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EducationResourceDemo.aspx.cs"
    Inherits="DemoPages_EducationResourceDemo" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ePathshala</title>
    <style type="text/css">
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
    </style>
    
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
<body>
    <form id="form1" runat="server">
    <div>
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
                        href="../Dashboard/StudentDashboardDemo.aspx" target="_self">
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
        <div class="tblDashboard1">
            <div class="firstpanel" style="margin-top:20px;">
                <div class="activitydivfull">
                    <div class="ActivityHeader">
                        <asp:Label ID="lblSiteMap" runat="server"></asp:Label><br />
                        <asp:Label ID="LblChapterTopic" runat="server"></asp:Label>
                    </div>
                    <div class="ActivityContent">
                        <div>
                            <asp:Panel ID="pnlClick" runat="server" CssClass="pnlCSS" Visible="false">
                                <div style="background-color: #ED8A18; height: 30px; vertical-align: middle">
                                    <div style="float: left; color: White; padding: 5px 5px 5px 10px">
                                        Add Resource
                                    </div>
                                    <div style="float: right; color: White; padding: 5px 5px 0 0">
                                        <asp:Label ID="lblMessage" runat="server" Text="Label" />
                                        <asp:Image ID="imgArrows" runat="server" />
                                    </div>
                                    <div style="clear: both">
                                    </div>
                                </div>
                            </asp:Panel>
                            <asp:Panel ID="pnlCollapsable" runat="server" Height="0" CssClass="pnlCSS" Visible="false">
                                <table align="center" width="100%">
                                    <tr>
                                        <td align="right" style="padding-bottom: 10px; padding-top: 5px;">
                                            Resource Name:
                                        </td>
                                        <td style="padding-bottom: 10px; padding-top: 5px; padding-left: 10px;">
                                            <asp:TextBox ID="txtfoldername" runat="server" Width="230px" Height="20px" />
                                            <%--<asp:Label ID="lblmsgforfilenaming" runat="server" Text='<img src="../App_Themes/Responsive/images/Question_mark.png" height="18px" width="18px" />' ToolTip = "Please follow this instractions: For MP4 file give name like Video Presentation for SWF File give name like Animation and for PDF file give name like MCQ."></asp:Label>--%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="padding-bottom: 10px;">
                                            Select Resource:
                                        </td>
                                        <td style="padding-bottom: 10px; padding-left: 10px;">
                                            <%--<asp:FileUpload ID="FileUpload1" runat="server" />--%>
                                            <input type="file" id="FileUpload1" name="FileUpload1" runat="server" style="width: 270px;" />
                                            <asp:Label ID="lblsupportedfile" runat="server" ForeColor="Red" Text="[Supported Format:  .MP4, .PDF, .SWF]"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="padding-bottom: 10px;">
                                            Resource For:
                                        </td>
                                        <td style="padding-bottom: 10px; padding-left: 10px;">
                                            <asp:RadioButton ID="rbteacherstudent" runat="server" Checked="true" GroupName="option"
                                                Text="Teacher and Student" />
                                            <asp:RadioButton ID="rbteacher" runat="server" GroupName="option" Text="Teacher Only" />
                                            <asp:RadioButton ID="rbstudent" runat="server" GroupName="option" Text="Student Only" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="2" style="padding-bottom: 10px; padding-top: 10px;">
                                            <asp:Button ID="btnupload" runat="server" OnClick="btnupload_Click" Text="Upload" />
                                            <asp:Button ID="btnreset2" runat="server" OnClick="btnreset2_Click" Text="Reset" />
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <cc1:CollapsiblePanelExtender ID="pnladdfile" runat="server" CollapseControlID="pnlClick"
                                Collapsed="true" ExpandControlID="pnlClick" TextLabelID="lblMessage" CollapsedText="Show"
                                ExpandedText="Hide" ImageControlID="imgArrows" CollapsedImage="../App_Themes/Responsive/web/downarrow.jpg"
                                ExpandedImage="../App_Themes/Responsive/web/uparrow.jpg" ExpandDirection="Vertical"
                                TargetControlID="pnlCollapsable" ScrollContents="false">
                            </cc1:CollapsiblePanelExtender>
                        </div>
                        <table class="ActionBarTable" cellpadding="0" cellspacing="0">
                            <tr>
                                <td colspan="2" align="center" style="text-align: center; vertical-align: middle;
                                    color: White; padding: 5px;">
                                    <asp:Label ID="lblClassAttendance" runat="server" Text="Educational Resources" meta:resourcekey="lblClassAttendanceResource1"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" valign="top">
                                    <asp:GridView runat="server" ID="gvrecords" DataKeyNames="ResourcePath,Resource,Ext"
                                        AutoGenerateColumns="false" OnRowCommand="btnDisplay_Click" ShowHeader="false"
                                        SkinID="NoPaging" OnRowDataBound="gvrecords_RowDataBound">
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex +1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblResourcePath" runat="server" Text='<%#Eval("ResourcePath") %>'></asp:Label></ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="ResourcePath" Visible="false" />
                                            <%--  <asp:BoundField DataField="Resource" />--%>
                                            <asp:BoundField DataField="Ext" Visible="false" />
                                            <asp:TemplateField Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblResource" runat="server" Text='<%#Eval("Resource") %>'></asp:Label></ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkDisplay" CssClass="LinkButton" Font-Underline="false" Text='<%#Eval("Resource") %>'
                                                        runat="server" CommandName="View"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    
                                                 <%--   <asp:ImageButton ID="Btnicon" runat="server" ImageUrl="../App_Themes/Responsive/images/video_72.png"
                                                    Width="22px" Height="22px" AlternateText="Last Seen" />--%>
                                                    <%--<asp:Label ID="lblmsg" runat="server" Text=""></asp:Label>--%>
                                                    <%--<img src="../App_Themes/Images/save.png" />--%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <RowStyle />
                                    </asp:GridView>
                                    <asp:Literal ID="lrLinks" runat="server" meta:resourcekey="lrLinksResource1"></asp:Literal>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" valign="top">
                                    <asp:Literal ID="lr" runat="server" meta:resourcekey="lrResource1"></asp:Literal>
                                </td>
                            </tr>
                        </table>
                        <div>
                            <asp:Button ID="btnFinishActStudent" runat="server" Text="Finish Activity" Width="100px"
                                CssClass="gobutton" OnClick="btnFinishActStudent_Click" Visible="true" meta:resourcekey="btnFinishActStudent" />
                           
                            <asp:Literal ID="Literal1" runat="server" EnableViewState="False"></asp:Literal>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <%-- </ContentTemplate>
    </asp:UpdatePanel>--%>
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
                    <asp:ImageButton ID="ibtnClose" runat="server" Text="Close" 
                        OnClientClick=" return confirm('Do you want to close current activity ?');" CausesValidation="False"
                        meta:resourceKey="btnCloseResource1" ImageUrl="~/App_Themes/Images/close.png"
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
        <asp:Button ID="btnShowPopup" runat="server" Text="Show Modal Popup" Style="display: none" />
        <!-- ModalPopupExtender -->
        <cc1:ModalPopupExtender ID="mpfeedback" runat="server" PopupControlID="tblTeacherFeedbackDetails"
            TargetControlID="btnShowPopup" BackgroundCssClass="modalBackground" DynamicServicePath=""
            Enabled="True" CancelControlID="ImageButton1">
        </cc1:ModalPopupExtender>
        <!-- ModalPopupExtender -->
        <table id="tblTeacherFeedbackDetails" runat="server" class="modalPopup2 RoundTop"
            align="center" cellpadding="0" cellspacing="0" style="margin: 0px; display: none;"
            width="100%">
            <tr>
                <td>
                    <asp:UpdatePanel runat="server" ID="UpdatePanel1" UpdateMode="Conditional">
                        <ContentTemplate>
                            <table class="InnerTableStyle RoundTop tblControlsRattingPopup" align="center" cellpadding="0"
                                cellspacing="0" width="50%">
                                <tr>
                                    <td align="center" class="Header12 RoundTop GridViewHeadercssTestAssessment" style="width: 100%"
                                        colspan="2">
                                        <asp:Label ID="lblTeacherFeedback" runat="server" Text="Feedback" Font-Bold="true"
                                            meta:resourceKey="lblTeacherFeedback"></asp:Label>
                                        <div style="float: right">
                                            <asp:ImageButton ID="ImageButton1" runat="server" Text="Close" 
                                                CausesValidation="False" meta:resourceKey="btnCloseResource1" ImageUrl="~/App_Themes/Images/close.png"
                                                Height="20px" Width="20px" />
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:GridView ID="grdFeedback" runat="server" AutoGenerateColumns="false" DataKeyNames="FeedbackQuestionID"
                                            Width="50%">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Feedback" meta:resourcekey="btnFeedbackResource1">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblFeedBackQuestion" runat="server" Text='<%#Eval("FeedbackQuestion") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Rating" meta:resourcekey="RatingResource1">
                                                    <ItemTemplate>
                                                        <cc1:Rating ID="ratingFeedback" runat="server" StarCssClass="ratingEmpty" WaitingStarCssClass="ratingSaved"
                                                            EmptyStarCssClass="ratingEmpty" FilledStarCssClass="ratingFilled" Direction="LeftToRight"
                                                            MaxRating='<%#Eval("Feedback Count") %>' CurrentRating='<%#Eval("Rating") %>'>
                                                        </cc1:Rating>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left;">
                                        <asp:Label ID="lblFeedback" runat="server" Text="Feedback:" meta:resourceKey="lblFeedback"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtFeedback" runat="server" TextMode="MultiLine" Width="603px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td align="right">
                                        <table cellpadding="0" cellspacing="0" style="float: right;">
                                            <tr>
                                                <td>
                                                    <tr>
                                                        <td style="text-align: right">
                                                            <asp:Label ID="lblNote" runat="server" Text="Note:" ForeColor="Red" Font-Names="Roboto-Light"
                                                                Font-Size="14px" meta:resourceKey="lblNote"></asp:Label>
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" style="text-align: right">
                                                            <asp:Label ID="lblPoor" runat="server" Text="Poor:" Font-Names="Roboto-Light" Font-Size="10px"
                                                                meta:resourceKey="lblPoor"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <span class="ratingFilled" style="float: left;">&nbsp;</span><span class="ratingEmpty"
                                                                style="float: left;">&nbsp;</span><span class="ratingEmpty" style="float: left;">&nbsp;</span><span
                                                                    class="ratingEmpty" style="float: left;">&nbsp;</span><span class="ratingEmpty" style="float: left;">&nbsp;</span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" style="text-align: right">
                                                            <asp:Label ID="lblAverage" runat="server" Text="Average:" Font-Names="Roboto-Light"
                                                                Font-Size="10px" meta:resourceKey="lblAverage"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <span class="ratingFilled" style="float: left;">&nbsp;</span> <span class="ratingFilled"
                                                                style="float: left;">&nbsp;</span><span class="ratingEmpty" style="float: left;">&nbsp;</span><span
                                                                    class="ratingEmpty" style="float: left;">&nbsp;</span><span class="ratingEmpty" style="float: left;">&nbsp;</span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" style="text-align: right">
                                                            <asp:Label ID="lblGood" runat="server" Text="Good:" Font-Names="Roboto-Light" Font-Size="10px"
                                                                meta:resourceKey="lblGood"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <span class="ratingFilled" style="float: left;">&nbsp;</span> <span class="ratingFilled"
                                                                style="float: left;">&nbsp;</span> <span class="ratingFilled" style="float: left;">&nbsp;</span><span
                                                                    class="ratingEmpty" style="float: left;">&nbsp;</span><span class="ratingEmpty" style="float: left;">&nbsp;</span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" style="text-align: right">
                                                            <asp:Label ID="lblVeryGood" runat="server" Text="Very Good:" Font-Names="Roboto-Light"
                                                                Font-Size="10px" meta:resourceKey="lblVeryGood"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <span class="ratingFilled" style="float: left;">&nbsp;</span> <span class="ratingFilled"
                                                                style="float: left;">&nbsp;</span> <span class="ratingFilled" style="float: left;">&nbsp;</span>
                                                            <span class="ratingFilled" style="float: left;">&nbsp;</span><span class="ratingEmpty"
                                                                style="float: left;">&nbsp;</span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" style="text-align: right">
                                                            <asp:Label ID="lblExcellent" runat="server" Text="Excellent:" Font-Names="Roboto-Light"
                                                                Font-Size="10px" meta:resourceKey="lblExcellent"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <span class="ratingFilled" style="float: right;">&nbsp;</span> <span class="ratingFilled"
                                                                style="float: left;">&nbsp;</span> <span class="ratingFilled" style="float: left;">&nbsp;</span>
                                                            <span class="ratingFilled" style="float: left;">&nbsp;</span> <span class="ratingFilled"
                                                                style="float: left;">&nbsp;</span>
                                                        </td>
                                                    </tr>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td>
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:Button ID="btnOK" runat="server" Text="Submit" CssClass="gobutton" 
                                                        meta:resourceKey="btnOK" />
                                                </td>
                                                <td>
                                                    <asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="gobutton" 
                                                        meta:resourceKey="btnReset" />
                                                    &nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                        <Triggers>
                            <asp:PostBackTrigger ControlID="btnOK1" />
                            <asp:PostBackTrigger ControlID="ImageButton2" />
                        </Triggers>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
        <asp:Button ID="btnShowPopup1" runat="server" Text="Show Modal Popup" Style="display: none" />
        <cc1:ModalPopupExtender ID="mpFeedback1" runat="server" PopupControlID="tblFeedback1"
            TargetControlID="btnShowPopup1" BackgroundCssClass="modalBackground" DynamicServicePath=""
            Enabled="True" CancelControlID="ImageButton2">
        </cc1:ModalPopupExtender>
        <!-- ModalPopupExtender -->
        <table id="tblFeedback1" runat="server" class="modalPopup2 RoundTop" align="center"
            cellpadding="0" cellspacing="0" style="margin: 0px; display: none;" width="50%">
            <tr>
                <td>
                    <asp:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
                        <ContentTemplate>
                            <table class="InnerTableStyle RoundTop tblControlsRattingPopup" align="center" cellpadding="0"
                                cellspacing="0" width="50%">
                                <tr>
                                    <td align="center" class="Header12 RoundTop GridViewHeadercssTestAssessment" style="width: 100%"
                                        colspan="2">
                                        <asp:Label ID="Label2" runat="server" Text="Feedback" Font-Bold="true" meta:resourceKey="lblTeacherFeedback"></asp:Label>
                                        <div style="float: right">
                                            <asp:ImageButton ID="ImageButton2" runat="server" Text="Close" CausesValidation="False"
                                                meta:resourceKey="btnCloseResource1" ImageUrl="~/App_Themes/Images/close.png"
                                                Height="20px" Width="20px" />
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <div>
                                            <asp:GridView ID="grdFeedback1" runat="server" AutoGenerateColumns="false" DataKeyNames="FeedbackQuestionID"
                                                Width="50%">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Feedback" meta:resourcekey="btnFeedbackResource1">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblFeedBackQuestion" runat="server" Text='<%#Eval("FeedbackQuestion") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Rating" meta:resourcekey="RatingResource1">
                                                        <ItemTemplate>
                                                            <cc1:Rating ID="ratingFeedback" CurrentRating='<%#Eval("Rating") %>' MaxRating='<%#Eval("Feedback Count") %>'
                                                                StarCssClass="ratingEmpty" WaitingStarCssClass="ratingSaved" EmptyStarCssClass="ratingEmpty"
                                                                FilledStarCssClass="ratingFilled" runat="server">
                                                            </cc1:Rating>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left;">
                                        <asp:Label ID="lblFeedback1" runat="server" Text="Feedback:" meta:resourceKey="lblFeedback"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtFeedback1" runat="server" TextMode="MultiLine" Width="603px"> </asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td align="right">
                                        <table cellpadding="0" cellspacing="0" style="float: right;">
                                            <tr>
                                                <td>
                                                    <tr>
                                                        <td style="text-align: right">
                                                            <asp:Label ID="lblNote1" runat="server" Text="Note:" ForeColor="Red" Font-Names="Roboto-Light"
                                                                Font-Size="14px" meta:resourceKey="lblNote1"></asp:Label>
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" style="text-align: right">
                                                            <asp:Label ID="lblPoor1" runat="server" Text="Poor:" Font-Names="Roboto-Light" Font-Size="10px"
                                                                meta:resourceKey="lblPoor1"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <span class="ratingFilled" style="float: left;">&nbsp;</span><span class="ratingEmpty"
                                                                style="float: left;">&nbsp;</span><span class="ratingEmpty" style="float: left;">&nbsp;</span><span
                                                                    class="ratingEmpty" style="float: left;">&nbsp;</span><span class="ratingEmpty" style="float: left;">&nbsp;</span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" style="text-align: right">
                                                            <asp:Label ID="lblAverage1" runat="server" Text="Average:" Font-Names="Roboto-Light"
                                                                Font-Size="10px" meta:resourceKey="lblAverage1"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <span class="ratingFilled" style="float: left;">&nbsp;</span> <span class="ratingFilled"
                                                                style="float: left;">&nbsp;</span><span class="ratingEmpty" style="float: left;">&nbsp;</span><span
                                                                    class="ratingEmpty" style="float: left;">&nbsp;</span><span class="ratingEmpty" style="float: left;">&nbsp;</span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" style="text-align: right">
                                                            <asp:Label ID="lblGood1" runat="server" Text="Good:" Font-Names="Roboto-Light" Font-Size="10px"
                                                                meta:resourceKey="lblGood1"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <span class="ratingFilled" style="float: left;">&nbsp;</span> <span class="ratingFilled"
                                                                style="float: left;">&nbsp;</span> <span class="ratingFilled" style="float: left;">&nbsp;</span><span
                                                                    class="ratingEmpty" style="float: left;">&nbsp;</span><span class="ratingEmpty" style="float: left;">&nbsp;</span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" style="text-align: right">
                                                            <asp:Label ID="lblVeryGood1" runat="server" Text="Very Good:" Font-Names="Roboto-Light"
                                                                Font-Size="10px" meta:resourceKey="lblVeryGood1"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <span class="ratingFilled" style="float: left;">&nbsp;</span> <span class="ratingFilled"
                                                                style="float: left;">&nbsp;</span> <span class="ratingFilled" style="float: left;">&nbsp;</span>
                                                            <span class="ratingFilled" style="float: left;">&nbsp;</span><span class="ratingEmpty"
                                                                style="float: left;">&nbsp;</span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" style="text-align: right">
                                                            <asp:Label ID="lblExcellent1" runat="server" Text="Excellent:" Font-Names="Roboto-Light"
                                                                Font-Size="10px" meta:resourceKey="lblExcellent1"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <span class="ratingFilled" style="float: right;">&nbsp;</span> <span class="ratingFilled"
                                                                style="float: left;">&nbsp;</span> <span class="ratingFilled" style="float: left;">&nbsp;</span>
                                                            <span class="ratingFilled" style="float: left;">&nbsp;</span> <span class="ratingFilled"
                                                                style="float: left;">&nbsp;</span>
                                                        </td>
                                                    </tr>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td>
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:Button ID="btnOK1" runat="server" Text="Submit" CssClass="gobutton" 
                                                        meta:resourceKey="btnOK" />
                                                    <asp:Button ID="btnReset1" runat="server" Text="Reset" CssClass="gobutton" 
                                                        meta:resourceKey="btnReset" />
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                        <Triggers>
                            <asp:PostBackTrigger ControlID="btnOK" />
                            <asp:PostBackTrigger ControlID="ImageButton1" />
                        </Triggers>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
