<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Epathshala.master" AutoEventWireup="true" CodeFile="ParentDashboard.aspx.cs" Inherits="Dashboard_ParentDashboard" %>




<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/UserControl/NewTeacherPanel.ascx" TagName="TeacherPanel" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .tblDashboard tr td {
            vertical-align: top;
            padding: 3px;
        }

        .tblDashboard .Header {
            color: #096B6B;
            text-align: center;
        }

        .tblDashboard .LeftPart {
            padding-right: 15px;
        }

        .Width300 {
            min-width: 300px;
            max-width: 300px;
        }

        .Width700 {
            min-width: 900px;
            max-width: 900px;
        }

        .Width1000px {
            min-width: 1000px;
            max-width: 1000px;
            max-height: 700px;
        }

        .MarginBottom15px {
            margin-bottom: 15px;
        }

        .modalPopup {
            background-color: #696969;
            filter: alpha(opacity=40);
            opacity: 0.7;
            xindex: -1;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   <%-- <asp:UpdatePanel runat="server" ID="upMain" UpdateMode="Conditional">
        <ContentTemplate>--%>
            <div class="tblDashboard">
                <%--<input type="button" id="btnTopics" runat="server" style="display: none;" onclick="btnTopics_Click" />--%>
                <div class="firstpanel" id="techPanel" runat="server">

                    <div class="activitydiv activityleft">
                        <div class="ActivityHeader">
                            <asp:Label ID="Label3" runat="server" Text="Select Subject"></asp:Label>
                        </div>
                        <%-- <uc1:StudentPanel ID="StudentPanel" runat="server" />--%>
                        <asp:RadioButtonList ID="rbSubjectList" runat="server" RepeatDirection="Horizontal"
                            CssClass="RBPadding" RepeatColumns="3" AutoPostBack="True" CellSpacing="10" CellPadding="10"
                            OnSelectedIndexChanged="rbSubjectList_SelectedIndexChanged" meta:resourcekey="rbSubjectListResource1">
                        </asp:RadioButtonList>
                    </div>
                    <div class="activitydiv activityright">
                        <div class="ActivityHeader" id="LastActivityBookMark">
                            <asp:Label ID="lblLastActivity" runat="server" Text="Last Activity" meta:resourcekey="lblLastActivityResource1"></asp:Label>
                        </div>
                        <div class="ActivityContent">
                            <div>
                                <asp:Label ID="lblLastChapter" runat="server" Text="Chapter:" meta:resourcekey="lblLastChapterResource1"></asp:Label>
                                <asp:Label ID="lblLastChapterName" runat="server" Text="Chapter Name" meta:resourcekey="lblLastChapterNameResource1"></asp:Label>
                            </div>
                            <div>
                                <asp:Label ID="lblLastTopic" runat="server" Text="Chapter:" meta:resourcekey="lblLastChapterResource1"></asp:Label>
                                <asp:Label ID="lblLastTopicName" runat="server" Text="Chapter Name" meta:resourcekey="lblLastChapterNameResource1"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div style="display: none">
                        <uc1:TeacherPanel ID="TeacherPanel1" runat="server" />
                    </div>
                    <div class="activitydiv activityright" style="display:none">
                        <div class="ActivityHeader">
                            <asp:Label ID="Label1" runat="server" Text="Today's Activity" ToolTip="Your today's activity will show over here"
                                meta:resourcekey="lblTodayActResource1"></asp:Label>
                        </div>
                        <div class="ActivityContent">
                            <asp:UpdatePanel runat="server" ID="upTopics" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <div class="radiobotton">
                                        <asp:RadioButtonList ID="rblChapters" runat="server" RepeatDirection="Horizontal"
                                            AutoPostBack="True" OnSelectedIndexChanged="rblChapters_SelectedIndexChanged"
                                            Visible="false" Style="width: 360px; white-space: nowrap;">
                                            <asp:ListItem Selected="True" Value="1" Text=" Uncovered Chapters"></asp:ListItem>
                                            <asp:ListItem Value="2" Text=" Covered Chapters"></asp:ListItem>
                                        </asp:RadioButtonList>
                                    </div>
                                    <div>
                                        <asp:Label ID="lblChapter" runat="server" Text="Chapter:" meta:resourcekey="lblChapterResource1"
                                            CssClass="textlabel"></asp:Label>
                                        <asp:DropDownList ID="ddlChapter" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlChapter_SelectedIndexChanged"
                                            Width="180px" Enabled="False">
                                            <asp:ListItem Text="-- Select --" meta:resourcekey="listItemResource1"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="rqdddlChapter" runat="server" ControlToValidate="ddlChapter"
                                            InitialValue="-- Select --" ErrorMessage="Please Select Chapter." ValidationGroup="TA"
                                            meta:resourcekey="rqdddlChapterResource1">*</asp:RequiredFieldValidator>
                                    </div>
                                    <div style="display: inline-block;">
                                        <asp:Label ID="lblTopic" runat="server" Text="Topic:" meta:resourcekey="lblTopicResource1"
                                            CssClass="textlabel"></asp:Label>
                                        <asp:DropDownList ID="ddlTopic" runat="server" Width="180px" meta:resourcekey="ddlTopicResource1">
                                            <asp:ListItem Text="-- Select --" meta:resourcekey="ListItemResource2"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="rqdddlTopic" runat="server" ControlToValidate="ddlTopic"
                                            InitialValue="-- Select --" ErrorMessage="Please Select Topic." ValidationGroup="TA"
                                            meta:resourcekey="rqdddlTopicResource1">*</asp:RequiredFieldValidator>
                                    </div>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddlChapter" />
                                    <asp:AsyncPostBackTrigger ControlID="rblChapters" />
                                </Triggers>
                            </asp:UpdatePanel>
                            <div class="gobotton">
                                <asp:Button ID="btnSubmit" runat="server" Text="Submit" ValidationGroup="TA" CssClass="gobutton"
                                    OnClick="btnSubmit_Click" meta:resourcekey="btnSubmitResource1" />
                                <asp:Button ID="btnReset" runat="server" Text="Reset" OnClick="btnReset_Click" CssClass="gobutton"
                                    meta:resourcekey="btnResetResource1" />
                                <asp:Button ID="btnOxford" runat="server" Text="Oxford" OnClick="btnOxford_Click"
                                    CssClass="gobutton" />
                                <asp:ValidationSummary ID="vsum" runat="server" ValidationGroup="TA" ShowMessageBox="True"
                                    ShowSummary="False" meta:resourcekey="vsumResource1" />
                            </div>
                        </div>
                    </div>
                </div>
                <div id="activitybottondiv" runat="server" visible="false">
                    <ul>
                        <li class="activitybotton" id="libtnAttendance" runat="server">
                            <asp:LinkButton ID="btnAttendance" runat="server" OnClick="btnAttendance_Click" meta:resourcekey="btnAttendanceResource1" /></li>
                        <li class="activitybotton" id="lilbtnMorningPrayer" runat="server">
                            <asp:LinkButton ID="lbtnMorningPrayer" Text="Morning Prayer" runat="server" OnClick="lbtnMorningPrayer_Click"
                                meta:resourcekey="lbtnMorningPrayerResource1" />
                        </li>
                        <li class="activitybotton" id="lilbtnEveningPrayer" runat="server">
                            <asp:LinkButton ID="lbtnEveningPrayer" Text="Evening Prayer" runat="server" OnClick="lbtnEveningPrayer_Click"
                                meta:resourcekey="lbtnEveningPrayerResource1" />
                        </li>
                        <li class="activitybotton" id="liLastActivityBookMark" runat="server">
                            <%--<asp:LinkButton ID="lbtnLastActivity" Text="Last Activity" runat="server" OnClick="lbtnEveningPrayer_Click"
                        meta:resourcekey="lbtnEveningPrayerResource1" />--%>
                            <a href="#LastActivityBookMark">Last Activity</a> </li>
                        <li class="activitybotton" id="liAnnouncementBookMark" runat="server">
                            <%--<asp:LinkButton ID="lbtnLastActivity" Text="Last Activity" runat="server" OnClick="lbtnEveningPrayer_Click"
                        meta:resourcekey="lbtnEveningPrayerResource1" />--%>
                            <a href="#AnnouncementBookMark">Announcement</a> </li>
                        <li class="activitybotton">
                            <%--<asp:LinkButton ID="lbtnLastActivity" Text="Last Activity" runat="server" OnClick="lbtnEveningPrayer_Click"
                        meta:resourcekey="lbtnEveningPrayerResource1" />--%>
                            <a href="#" onclick="javascript:return showSearch();">Search</a> </li>
                        <li class="activitybotton"><a href="../Teacher/SubjectWiseTestStepOne.aspx">Take Test</a>
                        </li>
                    </ul>
                </div>
                <div class="firstpanel">
                    <div class="activitydiv activityleft">
                        <div class="ActivityHeader">
                            <asp:Label ID="lblSyllabus" runat="server" Text="Syllabus Covered" meta:resourcekey="lblSyllabusResource1"></asp:Label>
                        </div>
                        <div class="ActivityContent">
                            <div class="persentagetagbox">
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
                    <%-- This div is for only AIA Teacher --%>
                    <%-- Start  --%>
                    <div id="dvteachercontentmain" runat="server" style="float: left; padding-bottom: 10px; margin-left: 20px; border-radius: 1px; width: 49%; min-width: 470px;">
                        <div class="activitydiv activityright" runat="server" id="dvteachercontent" style="width: 100%;">
                            <div class="ActivityHeader" id="Div1">
                                <asp:Label ID="Label2" runat="server" Text="Teacher's Content"></asp:Label>
                            </div>
                            <div class="ActivityContent">
                                <table align="center" width="100%">
                                    <tr>
                                        <td align="right" style="padding-bottom: 10px;">Select Resource:
                                        </td>
                                        <td style="padding-bottom: 10px; padding-left: 10px;">
                                            <%--<asp:FileUpload ID="FileUpload1" runat="server" />--%>
                                            <asp:UpdatePanel ID="updatePanel" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <input type="file" id="FileUpload1" name="FileUpload1" runat="server" style="width: 270px;" />
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:PostBackTrigger ControlID="btnupload" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblsupportedfile" runat="server" ForeColor="Red" Text="[Supported Format:  .PDF]"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="3" style="padding-bottom: 10px; padding-top: 10px;">
                                            <asp:Button ID="btnupload" runat="server" OnClick="btnupload_click" Text="Upload" />
                                            <asp:Button ID="btnreset2" runat="server" Text="Reset" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" EmptyDataText="No files uploaded">
                                                <Columns>
                                                    <asp:BoundField DataField="Text" HeaderText="File Name" />
                                                    <asp:TemplateField HeaderText="View">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkDownload" Text="View" CommandArgument='<%# Eval("Value") %>'
                                                                runat="server" OnClick="ViewFile"></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Delete">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkDelete" Text="Delete" CommandArgument='<%# Eval("Value") %>'
                                                                runat="server" OnClick="DeleteFile"></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                 <%--   <asp:Button ID="Button1" runat="server" Text="Show Modal Popup" Style="display: none"
                        meta:resourcekey="btnShowResource1" />--%>
                    <!-- ModalPopupExtender -->
            <%--        <cc1:ModalPopupExtender ID="mppdfviewwer" runat="server" PopupControlID="Display"
                        TargetControlID="Button1" BackgroundCssClass="modalBackground" DynamicServicePath=""
                        Enabled="True">
                    </cc1:ModalPopupExtender>--%>
                    <!-- ModalPopupExtender -->
                    <%--Container Area/Div For ModalPopupExtender--%>
          <%--          <div id="Display" runat="server" meta:resourcekey="SelectBMSResource1" style="position: fixed; top: 0px; left: 0px; width: 90%; height: 90%;">
                       
                        <div id="ActivityHeader1" runat="server" class="ActivityHeader1" style="min-height: 35px; margin-left: 1px; text-align: left;">
                            <asp:Label ID="LblDisplay" runat="server" Text="Display Resource" ForeColor="#777"
                                Font-Bold="true" meta:resourceKey="LblDisplay" Style="margin-left: 200px; display: inline-block;"></asp:Label>
                            <div style="float: right; padding: 10px 10px 0px 0px;">
                                <asp:ImageButton ID="ImageButton1" runat="server" Text="Close" OnClientClick=" return confirm('Do you want to close current activity ?');"
                                    CausesValidation="False" meta:resourceKey="btnCloseResource1" ImageUrl="~/App_Themes/Images/close.png"
                                    Height="20px" Width="20px" />
                            </div>
                        </div>
                    
                        <div class="activitydivfull" style="position: relative; width: 100%; height: 100%; margin: auto; top: 0px; left: 0px;">
                            <div class="ActivityContent" style="top: 0px; margin: 0px auto; width: auto; height: inherit;">
                                <iframe id="myframe" height="90%" width="100%" runat="server"></iframe>
                            </div>
                        </div>
                    </div>--%>
                   
                    <br />
                    <div class="activitydiv activityright" id="Div2" runat="server" >
                        <div class="ActivityHeader">
                            <asp:Label ID="Label4" runat="server" Text="Attendance"></asp:Label>
                        </div>
                        <div class="ActivityContent" style="overflow: scroll;">
                            <asp:GridView ID="grdAttendance" runat="server" AllowPaging="false" SkinID="GridforReport" 
                                    AllowSorting="false" EmptyDataText="No Data Found." Width="100%" AutoGenerateColumns="true"></asp:GridView>
                            </div>
                </div>
                    
                </div>
                <div class="firstpanel" id="dvreschedulemain" runat="server" visible="false" style="display:none">
                    <div class="activitydiv activityleft" id="dvRescheduing" runat="server" visible="false" style="display:none">
                        <div class="ActivityHeader">
                            <asp:Label ID="lblRescheduing" runat="server" Text="Approve Rescheduled Chapter Topic"
                                meta:resourcekey="lblRescheduingResource1"></asp:Label>
                        </div>
                        <div class="ActivityContent">
                            <asp:GridView runat="server" ID="gvRescheduing" DataKeyNames="ReSchedulingID,BMSSCTID,Chapter,Topic"
                                AutoGenerateColumns="false" ShowHeader="true" EmptyDataText="Chapter Topic Not Available."
                                SkinID="NoEmptyMsg" OnRowCommand="gvRescheduing_RowCommand" meta:resourcekey="gvRescheduingResource1">
                                <Columns>
                                    <asp:TemplateField HeaderText="Sr No." SortExpression="Sr. No" meta:resourcekey="SrNoResource1">
                                        <ItemTemplate>
                                            <%# ((GridViewRow)Container).RowIndex + 1%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Chapter" HeaderText="Chapter" SortExpression="Chapter"
                                        meta:resourcekey="ChapterResource1" />
                                    <asp:BoundField DataField="Topic" HeaderText="Topic" SortExpression="Topic" meta:resourcekey="TopicResource1" />
                                    <asp:BoundField DataField="EndDate" HeaderText="Valid upto" SortExpression="EndDate"
                                        meta:resourcekey="EndDateResource1" />
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkDisplay" runat="server" Text="View" meta:resourcekey="lnkDisplayResource1"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                    <div class="activitydiv activityright" id="tblDashBoardAnnouncement" runat="server">
                        <div class="ActivityHeader" id="AnnouncementBookMark">
                            <asp:Label ID="lblAnnounement" runat="server" Text="Announcement" meta:resourcekey="lblAnnounementResource1"></asp:Label>
                        </div>
                        <div class="ActivityContent">
                            <asp:DataList ID="dlAnnouncement" runat="server">
                                <ItemStyle Font-Overline="False" Wrap="True" />
                                <ItemTemplate>
                                    <table>
                                        <tr>
                                            <td colspan="2" style="text-align: left; color: Maroon">
                                                <ul type="circle">
                                                    <li>
                                                        <asp:Label ID="lblTeacherAnnouncementDate" runat="server" Text='<%# String.Format("{0:dd-MMM-yyyy}",Eval("StartDate")) %>'></asp:Label>
                                                    </li>
                                                </ul>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="text-align: left; color: Gray; padding: 0 0 0 1px">
                                                <asp:Label ID="lblTeacherAnnouncement" runat="server" Text='<% #Limit(Eval("Announcement"), 80)%>'
                                                    ToolTip='<%#Eval("Announcement") %>'></asp:Label>
                                            </td>
                                        </tr>
                                        <tr style="border: 4px none gray">
                                            <td colspan="2">
                                                <hr />
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                                <SeparatorStyle Wrap="True" />
                            </asp:DataList>
                            <asp:LinkButton ID="lbtnViewAll" Text="View All" runat="server" OnClick="lnkViewAll_Click"
                                meta:resourcekey="lbtnViewAllResource1"></asp:LinkButton>
                        </div>
                    </div>
                </div>
                
            <asp:Button ID="btnShow" runat="server" Text="Show Modal Popup" Style="display: none"
                meta:resourcekey="btnShowResource1" />
            <!-- ModalPopupExtender -->
            <cc1:ModalPopupExtender ID="mp1" runat="server" PopupControlID="pnlSelectPrayer"
                TargetControlID="btnShow" CancelControlID="ibtnClose" BackgroundCssClass="modalBackground"
                DynamicServicePath="" Enabled="True">
            </cc1:ModalPopupExtender>
            <!-- ModalPopupExtender -->
            <table id="pnlSelectPrayer" runat="server" class="modalPopup2 RoundTop RoundBottom"
                style="display: none;" meta:resourcekey="pnlSelectBMSResource1" cellpadding="0"
                cellspacing="0">
                <tr>
                    <td class="Header12 RoundTop GridViewHeadercssTestAssessment" style="text-align: right">
                        <asp:ImageButton ID="ibtnClose" runat="server" Text="Close" OnClick="btnClose_Click"
                            CausesValidation="False" meta:resourceKey="btnCloseResource1" ImageUrl="~/App_Themes/Images/btn_close_up.png"
                            Height="12px" Width="15px" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:UpdatePanel ID="updPnlSelectBMS" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <div style="margin-left: 10px; margin-top: 10px">
                                    <object type="application/x-shockwave-flash" data="AudioPlayer.swf?mp3=<%=path %>"
                                        width="250" height="25" id="Object2">
                                        <param name="wmode" value="transparent" />
                                        <param name="movie" value="AudioPlayer.swf?mp3=<%=path %>" />
                                    </object>
                                </div>
                                <%--<div id="audply" runat="server">
                            </div>--%>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
       <%-- </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="TeacherPanel1" />
            <asp:PostBackTrigger ControlID="btnSubmit" />
            <asp:PostBackTrigger ControlID="btnOxford" />
        </Triggers>
    </asp:UpdatePanel>--%>
    <!-- LoaderPart start-->
    <asp:Button ID="btnLoader" runat="server" Style="display: none" />
    <asp:Button ID="btnCancel" runat="server" Style="display: none" />
    <cc1:ModalPopupExtender ID="ModalPopup" runat="server" PopupControlID="dvPopup" CancelControlID="btnCancel"
        TargetControlID="btnLoader" BackgroundCssClass="modalBackground" Enabled="True">
    </cc1:ModalPopupExtender>
    <table id="dvPopup" runat="server" class="loadingtable" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <img src="../App_Themes/Responsive/web/Loader.gif" alt="Loading Please wait.." />
            </td>
        </tr>
        <tr>
            <td class="loadingtabletd">
                <span>Loading Please Wait..</span>
            </td>
        </tr>
    </table>
    <!-- LoaderPart end-->
    <asp:Button ID="btnsearch" runat="server" Text="Show Modal Popup" Style="display: none" />
    <asp:Button ID="btnsearchcancel" runat="server" Text="Show Modal Popup" Style="display: none" />
    <!-- ModalPopupExtender -->
    <cc1:ModalPopupExtender ID="mdlsearch" runat="server" PopupControlID="pnlsearch"
        TargetControlID="btnsearch" CancelControlID="btnsearchcancel" BackgroundCssClass="modalBackground"
        DynamicServicePath="" Enabled="True">
    </cc1:ModalPopupExtender>
    <!-- ModalPopupExtender -->
    <asp:Panel ID="pnlsearch" runat="server" Style="display: none;">
        <div class="activitydivfull" runat="server" style="width: 450px; box-shadow: 0 0 4px #000">
            <div class="ActivityHeader">
                <asp:Label ID="lblForgetPass" runat="server" Text="Search Chapter"></asp:Label>
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
    </asp:Panel>
    <script type="text/javascript">
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_beginRequest(BeginRequestHandler);
        prm.add_endRequest(EndRequestHandler);
        function BeginRequestHandler(sender, args) {
            if ($("#<%= btnLoader.ClientID%>") != null) {
                $("#<%= btnLoader.ClientID%>").click();
            }
        }

        function EndRequestHandler(sender, args) {
            if ($("#<%= btnCancel.ClientID%>") != null) {
                $("#<%= btnCancel.ClientID%>").click();
            }
        }
        function showSearch() {
            if ($("#<%= btnsearch.ClientID%>") != null) {
                $("#<%= btnsearch.ClientID%>").click();
            }
        }
        function CloseSearch() {
            if ($("#<%= btnsearchcancel.ClientID%>") != null) {
                $("#<%= btnsearchcancel.ClientID%>").click();
            }
            return false;
        }
    </script>
</asp:Content>
