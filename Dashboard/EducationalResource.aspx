<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Epathshala.master" AutoEventWireup="true"
    CodeFile="EducationalResource.aspx.cs" Inherits="Dashboard_EducationalResource"
    Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        /*
   .Activity, .ActivityContent
    {
        border:3px solid red;
        display:inline;
        min-height:100%;
            
    }*/
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--Eduresource Heading--%>
    <div class="row DBHeader">
        <div class="col-sm-9 NoPadding">
            <div class="DashboardHeading">
                You are here: <span style="color: White;">Education Resources</span> (
                <asp:Label ID="lblSiteMap" runat="server"></asp:Label>
                >
                <asp:Label ID="LblChapterTopic" runat="server"></asp:Label>)
            </div>
        </div>
        <div class="col-sm-3 NoPadding">
            <div class="DashboardHeading">
                <%--Today: <asp:Literal runat="server" ID="litDateNow" Text='<%# Eval(DateTime.Now.ToString("DD-MMM-YYYY")) %>'></asp:Literal> --%>
                <img src="../App_Themes/Green/Images/icon-calendar.png" />
                <i>Today:
                    <%=DateTime.Now.ToString("dd MMM, yyyy") %></i>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-12">
            <asp:Panel ID="pnlClick" runat="server" CssClass="pnlCSS">
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
            <asp:Panel ID="pnlCollapsable" runat="server" Height="0" CssClass="pnlCSS">
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
            <asp:GridView runat="server" ID="gvrecords" DataKeyNames="ResourcePath,Resource,Ext"
                AutoGenerateColumns="false" OnRowCommand="btnDisplay_Click" ShowHeader="false"
                SkinID="GridforEduresource" OnRowDataBound="gvrecords_RowDataBound">
                <Columns>
                    <asp:TemplateField ItemStyle-Width="20px" Visible="false">
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
                            <%# Container.DataItemIndex +1 %>&nbsp;&nbsp;&nbsp;
                            <asp:LinkButton ID="lnkDisplay" Font-Underline="false" Text='<%#Eval("Resource") %>'
                                runat="server" CommandName="View"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField Visible="false">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkSelect" runat="server" />
                        </ItemTemplate>
                        <ItemStyle Width="10%" HorizontalAlign="Center" VerticalAlign="Top" />
                    </asp:TemplateField>
                    <%--<asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:ImageButton ID="BtnQuesSave" runat="server" ImageUrl="../App_Themes/Images/eye_inv.png"
                                                    Width="22px" Height="22px" Visible="false" AlternateText="Last Seen" />
                                                <asp:Label ID="lblmsg" runat="server" Text=""></asp:Label>
                                                <img src="../App_Themes/Images/save.png" />
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                </Columns>
                <RowStyle />
            </asp:GridView>
            <asp:Literal ID="lrLinks" runat="server" meta:resourcekey="lrLinksResource1"></asp:Literal>
            <asp:Literal ID="lr" runat="server" meta:resourcekey="lrResource1"></asp:Literal>
            <div>
                <asp:Button ID="btnFinishActivity" runat="server" Text="Finish Activity" OnClick="btnFinishActivity_Click"
                    meta:resourcekey="btnFinishActivityResource1" Visible="false" />
                <asp:Button ID="btnFinishActStudent" runat="server" Text="Finish Activity" OnClick="btnFinishActStudent_Click"
                    Visible="false" meta:resourcekey="btnFinishActStudent" />
                <asp:Button ID="btnFeedback" runat="server" Text="Feedback" OnClick="btnFeedback_Click"
                    meta:resourcekey="btnFeedback" />
                <asp:Button ID="btnBack" runat="server" Text="Back to search" OnClick="btnBack_Click"
                    Visible="false" />
                <asp:Button ID="btnchooseAction" runat="server" Text="Choose Action" OnClientClick="javascript:return ShowActionPopup();" />
                <asp:Button ID="btnbackEduResource" runat="server" Text="Back" OnClick="btnbackEduResource_Click" />
                <asp:Literal ID="Literal1" runat="server" EnableViewState="False"></asp:Literal>
            </div>
        </div>
    </div>
    <asp:Button ID="btnShow" runat="server" Text="Show Modal Popup" Style="display: none"
        meta:resourcekey="btnShowResource1" />
    <!-- ModalPopupExtender -->
    <cc1:ModalPopupExtender ID="mp1" runat="server" PopupControlID="Display" TargetControlID="btnShow"
        BackgroundCssClass="modalBackground" DynamicServicePath="" Enabled="True">
    </cc1:ModalPopupExtender>
    <!-- ModalPopupExtender -->
    <%--Container Area/Div For ModalPopupExtender--%>
    <div id="Display" runat="server">
        <div class="WoodenBorder" style="position: fixed; top: 0px; left: 0px; width: 100%;
            height: 100%; z-index: 100001;">
            <div class="GreenBoard" style="height: 5%;">
                <asp:Label ID="LblDisplay" runat="server" Text="Display Resource" meta:resourceKey="LblDisplay"
                    Style="display: inline-block;"></asp:Label>
                <div style="position: fixed; top: 22px; right: 22px;">
                    <asp:ImageButton ID="ibtnClose" runat="server" Text="Close" OnClick="btnClose_Click"
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
            <div style="height: 95%; background-image: url('../App_Themes/Green/Images/green-bg.jpg');">
                <iframe id="myframe" width="100%" height="100%" runat="server" allowfullscreen></iframe>
            </div>
        </div>
    </div>
    <%-- </div>--%>
    <asp:Button ID="btnShowPopup" runat="server" Text="Show Modal Popup" Style="display: none" />
    <!-- ModalPopupExtender -->
    <cc1:ModalPopupExtender ID="mpfeedback" runat="server" PopupControlID="tblTeacherFeedbackDetails"
        TargetControlID="btnShowPopup" BackgroundCssClass="modalBackground" DynamicServicePath=""
        Enabled="True" CancelControlID="ImageButton1">
    </cc1:ModalPopupExtender>
    <!-- ModalPopupExtender -->
    <table id="tblTeacherFeedbackDetails" runat="server" align="center" cellpadding="0"
        cellspacing="0" style="margin: 0px;" width="100%">
        <tr>
            <td>
                <asp:UpdatePanel runat="server" ID="UpdatePanel1" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="Activity" style="white-space: 50%;">
                            <div class="ActivityHeading" style="margin-bottom: 0px;">
                                <asp:Label ID="lblTeacherFeedback" runat="server" Text="Feedback" Font-Bold="true"
                                    meta:resourceKey="lblTeacherFeedback"></asp:Label>
                                <div style="float: right">
                                    <asp:ImageButton ID="ImageButton1" runat="server" Text="Close" OnClick="btnClose_Click"
                                        CausesValidation="False" meta:resourceKey="btnCloseResource1" ImageUrl="~/App_Themes/Images/close.png"
                                        Height="20px" Width="20px" />
                                </div>
                            </div>
                            <div class="ActivityContent">
                                <asp:GridView ID="grdFeedback" runat="server" AutoGenerateColumns="false" DataKeyNames="FeedbackQuestionID"
                                    SkinID="NoEmptyMsg">
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
                                <%--<asp:Label ID="lblFeedback" runat="server" Text="Feedback:" meta:resourceKey="lblFeedback"></asp:Label>--%>
                                <asp:TextBox ID="txtFeedback" runat="server" placeholder="Type your feedback here..."
                                    TextMode="MultiLine" Width="100%"></asp:TextBox>
                                <div>
                                    <asp:Label ID="lblNote" runat="server" Text="Note:" ForeColor="Red" Font-Names="Roboto-Light"
                                        Font-Size="14px" meta:resourceKey="lblNote"></asp:Label>
                                    <br />
                                    <asp:Label ID="lblPoor" runat="server" Text="Poor:" Font-Names="Roboto-Light" Font-Size="10px"
                                        meta:resourceKey="lblPoor"></asp:Label>
                                    <span class="ratingFilled" style="float: left;">&nbsp;</span><span class="ratingEmpty"
                                        style="float: left;">&nbsp;</span><span class="ratingEmpty" style="float: left;">&nbsp;</span><span
                                            class="ratingEmpty" style="float: left;">&nbsp;</span><span class="ratingEmpty" style="float: left;">&nbsp;</span>
                                    <br />
                                    <asp:Label ID="lblAverage" runat="server" Text="Average:" Font-Names="Roboto-Light"
                                        Font-Size="10px" meta:resourceKey="lblAverage"></asp:Label>
                                    <span class="ratingFilled" style="float: left;">&nbsp;</span> <span class="ratingFilled"
                                        style="float: left;">&nbsp;</span><span class="ratingEmpty" style="float: left;">&nbsp;</span><span
                                            class="ratingEmpty" style="float: left;">&nbsp;</span><span class="ratingEmpty" style="float: left;">&nbsp;</span>
                                    <br />
                                    <asp:Label ID="lblGood" runat="server" Text="Good:" Font-Names="Roboto-Light" Font-Size="10px"
                                        meta:resourceKey="lblGood"></asp:Label>
                                    <span class="ratingFilled" style="float: left;">&nbsp;</span> <span class="ratingFilled"
                                        style="float: left;">&nbsp;</span> <span class="ratingFilled" style="float: left;">&nbsp;</span><span
                                            class="ratingEmpty" style="float: left;">&nbsp;</span><span class="ratingEmpty" style="float: left;">&nbsp;</span>
                                    <br />
                                    <asp:Label ID="lblVeryGood" runat="server" Text="Very Good:" Font-Names="Roboto-Light"
                                        Font-Size="10px" meta:resourceKey="lblVeryGood"></asp:Label>
                                    <span class="ratingFilled" style="float: left;">&nbsp;</span> <span class="ratingFilled"
                                        style="float: left;">&nbsp;</span> <span class="ratingFilled" style="float: left;">&nbsp;</span>
                                    <span class="ratingFilled" style="float: left;">&nbsp;</span><span class="ratingEmpty"
                                        style="float: left;">&nbsp;</span>
                                    <br />
                                    <asp:Label ID="lblExcellent" runat="server" Text="Excellent:" Font-Names="Roboto-Light"
                                        Font-Size="10px" meta:resourceKey="lblExcellent"></asp:Label>
                                    <span class="ratingFilled" style="float: left;">&nbsp;</span> <span class="ratingFilled"
                                        style="float: left;">&nbsp;</span> <span class="ratingFilled" style="float: left;">&nbsp;</span>
                                    <span class="ratingFilled" style="float: left;">&nbsp;</span> <span class="ratingFilled"
                                        style="float: left;">&nbsp;</span>
                                </div>
                            </div>
                            <div class="ActivityHeading" style="margin-bottom: 0px; text-align: center;">
                                <asp:Button ID="btnOK" runat="server" Style="border: 2px solid #F77408; padding: 8px 15px;
                                    text-decoration: none; border-radius: 34px; display: table-cell; background: none;
                                    color: #F77408;" Text="Submit" OnClick="btnOK_Click" meta:resourceKey="btnOK" />
                                &nbsp; &nbsp; &nbsp;
                                <asp:Button ID="btnReset" Style="border: 2px solid #F77408; padding: 8px 15px; text-decoration: none;
                                    border-radius: 34px; display: table-cell; background: none; color: #F77408;"
                                    runat="server" Text="Reset" OnClick="btnReset_Click" meta:resourceKey="btnReset" />
                                <asp:Button ID="btnback_FinishActivity" runat="server" Text="Back" OnClick="btnback_FinishActivity_Click"
                                    Style="margin-left:25px; border: 2px solid #F77408; padding: 8px 15px; text-decoration: none; border-radius: 34px;
                                    display: table-cell; background: none; color: #F77408;" />
                            </div>
                        </div>
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
    <table id="tblFeedback1" runat="server" align="center" cellpadding="0" cellspacing="0"
        style="margin: 0px; display: none;" width="100%">
        <tr>
            <td>
                <asp:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="Activity">
                            <div class="ActivityHeading" style="margin-bottom: 0px;">
                                <asp:Label ID="Label2" runat="server" Text="Feedback" Font-Bold="true" meta:resourceKey="lblTeacherFeedback"></asp:Label>
                                <div style="float: right">
                                    <asp:ImageButton ID="ImageButton2" runat="server" Text="Close" CausesValidation="False"
                                        meta:resourceKey="btnCloseResource1" ImageUrl="~/App_Themes/Images/close.png"
                                        Height="20px" Width="20px" />
                                </div>
                            </div>
                            <div class="ActivityContent">
                                <asp:GridView ID="grdFeedback1" runat="server" AutoGenerateColumns="false" DataKeyNames="FeedbackQuestionID">
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
                                <%--    <asp:Label ID="lblFeedback1" runat="server" Text="Feedback:" meta:resourceKey="lblFeedback"></asp:Label>--%>
                                <asp:TextBox ID="txtFeedback1" runat="server" TextMode="MultiLine" Width="100%" placeholder="Type your feedback here..."> </asp:TextBox>
                                <div>
                                    <asp:Label ID="Label1" runat="server" Text="Note:" ForeColor="Red" Font-Names="Roboto-Light"
                                        Font-Size="14px" meta:resourceKey="lblNote"></asp:Label>
                                    <br />
                                    <asp:Label ID="Label3" runat="server" Text="Poor:" Font-Names="Roboto-Light" Font-Size="10px"
                                        meta:resourceKey="lblPoor"></asp:Label>
                                    <span class="ratingFilled" style="float: left;">&nbsp;</span><span class="ratingEmpty"
                                        style="float: left;">&nbsp;</span><span class="ratingEmpty" style="float: left;">&nbsp;</span><span
                                            class="ratingEmpty" style="float: left;">&nbsp;</span><span class="ratingEmpty" style="float: left;">&nbsp;</span>
                                    <br />
                                    <asp:Label ID="Label4" runat="server" Text="Average:" Font-Names="Roboto-Light" Font-Size="10px"
                                        meta:resourceKey="lblAverage"></asp:Label>
                                    <span class="ratingFilled" style="float: left;">&nbsp;</span> <span class="ratingFilled"
                                        style="float: left;">&nbsp;</span><span class="ratingEmpty" style="float: left;">&nbsp;</span><span
                                            class="ratingEmpty" style="float: left;">&nbsp;</span><span class="ratingEmpty" style="float: left;">&nbsp;</span>
                                    <br />
                                    <asp:Label ID="Label5" runat="server" Text="Good:" Font-Names="Roboto-Light" Font-Size="10px"
                                        meta:resourceKey="lblGood"></asp:Label>
                                    <span class="ratingFilled" style="float: left;">&nbsp;</span> <span class="ratingFilled"
                                        style="float: left;">&nbsp;</span> <span class="ratingFilled" style="float: left;">&nbsp;</span><span
                                            class="ratingEmpty" style="float: left;">&nbsp;</span><span class="ratingEmpty" style="float: left;">&nbsp;</span>
                                    <br />
                                    <asp:Label ID="Label6" runat="server" Text="Very Good:" Font-Names="Roboto-Light"
                                        Font-Size="10px" meta:resourceKey="lblVeryGood"></asp:Label>
                                    <span class="ratingFilled" style="float: left;">&nbsp;</span> <span class="ratingFilled"
                                        style="float: left;">&nbsp;</span> <span class="ratingFilled" style="float: left;">&nbsp;</span>
                                    <span class="ratingFilled" style="float: left;">&nbsp;</span><span class="ratingEmpty"
                                        style="float: left;">&nbsp;</span>
                                    <br />
                                    <asp:Label ID="Label7" runat="server" Text="Excellent:" Font-Names="Roboto-Light"
                                        Font-Size="10px" meta:resourceKey="lblExcellent"></asp:Label>
                                    <span class="ratingFilled" style="float: left;">&nbsp;</span> <span class="ratingFilled"
                                        style="float: left;">&nbsp;</span> <span class="ratingFilled" style="float: left;">&nbsp;</span>
                                    <span class="ratingFilled" style="float: left;">&nbsp;</span> <span class="ratingFilled"
                                        style="float: left;">&nbsp;</span>
                                </div>
                            </div>
                            <div class="ActivityHeading" style="margin-bottom: 0px; text-align: center;">
                                <asp:Button ID="btnOK1" runat="server" Text="Submit" OnClick="btnOK1_Click" meta:resourceKey="btnOK"
                                    Style="border: 2px solid #F77408; padding: 8px 15px; text-decoration: none; border-radius: 34px;
                                    display: table-cell; background: none; color: #F77408;" />
                                &nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnReset1" runat="server" Text="Reset" OnClick="btnReset1_Click"
                                    meta:resourceKey="btnReset" Style="border: 2px solid #F77408; padding: 8px 15px;
                                    text-decoration: none; border-radius: 34px; display: table-cell; background: none;
                                    color: #F77408;" />
                                <asp:Button ID="btnfeedbackback" runat="server" Text="Back" OnClick="btnfeedbackback_Click"
                                    Style="border: 2px solid #F77408; padding: 8px 15px; margin-left: 20px; text-decoration: none;
                                    border-radius: 34px; display: table-cell; background: none; color: #F77408;" />
                            </div>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="btnOK" />
                        <asp:PostBackTrigger ControlID="ImageButton1" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
    <!--Choose Action Popup-->
    <asp:Button ID="btnshowactionpopup" runat="server" Text="Show Modal Popup" Style="display: none" />
    <asp:Button ID="btncanclelactionpopup" runat="server" Text="Close Modal Popup" Style="display: none" />
    <cc1:ModalPopupExtender ID="mdlaction" runat="server" PopupControlID="pnlAction"
        TargetControlID="btnshowactionpopup" BackgroundCssClass="modalBackground" CancelControlID="btncanclelactionpopup">
    </cc1:ModalPopupExtender>
    <asp:Panel ID="pnlAction" runat="server" Style="display: none;">
        <div class="activitydivfull" style="width: 450px; box-shadow: 0 0 4px #000">
            <div class="ActivityHeader">
                <asp:Label ID="lblactionTitle" runat="server" Text="Select Template"></asp:Label>
            </div>
            <div class="ActivityContent">
                <div style="margin-top: 15px; max-height: 300px; overflow: auto;">
                    <asp:GridView ID="gvtemplate" runat="server" AutoGenerateColumns="False" SkinID="NoPaging">
                        <Columns>
                            <asp:TemplateField HeaderText="SNo.">
                                <ItemTemplate>
                                    <asp:Label ID="GV_LblSRNO" runat="server" Text='<%# Container.DataItemIndex+1 %>' />
                                </ItemTemplate>
                                <ItemStyle CssClass="GridViewRows" Width="10%" HorizontalAlign="Center" VerticalAlign="Top" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Template">
                                <ItemTemplate>
                                    <asp:Label ID="GV_LblTemplateName" runat="server" Text='<%#Eval("title") %>' /></ItemTemplate>
                                <ItemStyle CssClass="GridViewRows" Width="40%" HorizontalAlign="Left" VerticalAlign="Top" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkSelecttemplate" runat="server" onclick="javascript:checkOnlyOne(this);" />
                                </ItemTemplate>
                                <ItemStyle CssClass="GridViewRows" Width="10%" HorizontalAlign="Center" VerticalAlign="Top" />
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            <div style="text-align: center; color: black">
                                No Template Found</div>
                        </EmptyDataTemplate>
                    </asp:GridView>
                </div>
                <div style="margin-top: 10px; text-align: center;">
                    <asp:Button ID="btnSend" runat="server" Text="Send" OnClick="btnSend_Click" PostBackUrl="~/Dashboard/SendAssesmentMail.aspx" />
                    <asp:Button ID="BtnHome" runat="server" Text="Cancel" OnClientClick="javascript:return CloseActionPopup();" />
                </div>
            </div>
        </div>
    </asp:Panel>
    <!--Choose Action Popup-->
    <script type="text/javascript">
        function ShowActionPopup() {
            if ($("#<%= btnshowactionpopup.ClientID%>") != null) {
                $("#<%= btnshowactionpopup.ClientID%>").click();
            }
            return false;
        }
        function CloseActionPopup() {
            if ($("#<%= btncanclelactionpopup.ClientID%>") != null) {
                $("#<%= btncanclelactionpopup.ClientID%>").click();
            }
            return false;
        }
        function checkOnlyOne(obj) {
            try {
                var TargetBaseControl = document.getElementById('<%= gvtemplate.ClientID %>');
                var Inputs = TargetBaseControl.getElementsByTagName("input");
                for (var n = 0; n < Inputs.length; ++n) {
                    if (Inputs[n].type == 'checkbox') {
                        Inputs[n].checked = false;
                    }
                }
                obj.checked = true;
            }
            catch (e) {
                alert("Error");
            }
        }
        function autoResize() {
            var frameid = document.getElementById('<%= myframe.ClientID %>');
            frameid.height = "100%";
        }
    </script>
</asp:Content>
