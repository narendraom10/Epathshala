<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Epathshala.master" AutoEventWireup="true"
    CodeFile="ActivityFeedbackReport.aspx.cs" Inherits="ActivityFeedbackReport" Culture="auto" EnableEventValidation="false"
    meta:resourcekey="PageResource1" UICulture="auto" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="../JavaScript/jquery-1.2.6.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
        function pageLoad() {


            $("Panel.Rating > a").each(function () {
                debugger
                alert(this.title);
                var rate = this.title;
                if (rate != 0) {
                    this.title = "Rated " + rate + " star(s)";
                } else {
                    this.title = "Not yet rated.";
                }
            });
        }
    </script>
    <style type="text/css">
        .pnlCSS
        {
            font-weight: bold;
            cursor: pointer;
            border: solid 1px #c0c0c0;
            width: 30%;
        }
    </style>
    <style type="text/css">
        .onestar
        {
            background-color: Red;
        }
        
        .twostar
        {
            background-color: Orange;
        }
        
        .threestar
        {
            background-color: Yellow;
        }
        
        .fourstar
        {
            background-color: #CCFF99;
        }
        
        .fivestar
        {
            background-color: Green;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="tblDashboard">
        <div class="sidepanel">
            <div class="activitydivside">
                <div class="ActivityHeader">
                    <asp:Label ID="lblTitleFirst" runat="server" Text="Activity Feedback Report" meta:resourcekey="lblTitleFirstResource1"></asp:Label>
                    <asp:Label ID="lblTitleSecond" runat="server" Text="Schoolwise Subject result report"
                        Visible="False" meta:resourcekey="lblTitleSecondResource1"></asp:Label>
                    <asp:Label ID="lblTitleThird" runat="server" Text="Schoolwise all exam result report"
                        Visible="False" meta:resourcekey="lblTitleThirdResource1"></asp:Label>
                    <asp:Label ID="lblTitleFourth" runat="server" Text="Exam Detail summary" Visible="False"
                        meta:resourcekey="lblTitleFourthResource1"></asp:Label>
                </div>
                <asp:UpdatePanel runat="server" ID="upTopics" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="ActivityContent" id="ClasswiseReport" runat="server" visible="true">
                            <div>
                                <asp:Label ID="lblSchool" runat="server" Text="School:" CssClass="textlabel" meta:resourcekey="lblSchoolResource1"></asp:Label>
                                <asp:DropDownList ID="ddlSchool" runat="server" Width="140px" AutoPostBack="True"
                                    OnSelectedIndexChanged="ddlSchool_SelectedIndexChanged" meta:resourcekey="ddlSchoolResource1">
                                    <asp:ListItem Text="-- Select --" Value="0" meta:resourcekey="ListItemResource1"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RFVddlSchool" runat="server" ControlToValidate="ddlSchool"
                                    InitialValue="0" ErrorMessage="Please Select School." ValidationGroup="a" meta:resourcekey="RFVddlSchoolResource1"
                                    Text="*"></asp:RequiredFieldValidator>
                            </div>
                            <div>
                                <asp:Label ID="lblBoard" runat="server" Text="Board:" CssClass="textlabel" meta:resourcekey="lblBoardResource1"></asp:Label>
                                <asp:DropDownList ID="ddlBoard" runat="server" AutoPostBack="True" AppendDataBoundItems="True"
                                    OnSelectedIndexChanged="ddlBoard_SelectedIndexChanged" meta:resourcekey="ddlBoardResource1"
                                    Width="140px">
                                    <asp:ListItem Text="-- Select --" Value="0" meta:resourcekey="ListItemResource2"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="ReqFieldBoard" runat="server" ErrorMessage="Please select board"
                                    ValidationGroup="a" InitialValue="0" ControlToValidate="ddlBoard" meta:resourcekey="ReqFieldBoardResource1"
                                    Text="*"></asp:RequiredFieldValidator>
                            </div>
                            <div>
                                <asp:Label ID="lblMedium" runat="server" Text="Medium:" CssClass="textlabel" meta:resourcekey="lblMediumResource1"></asp:Label>
                                <asp:DropDownList ID="ddlMedium" runat="server" AutoPostBack="True" AppendDataBoundItems="True"
                                    Enabled="False" OnSelectedIndexChanged="ddlMedium_SelectedIndexChanged" meta:resourcekey="ddlMediumResource1"
                                    Width="140px">
                                    <asp:ListItem Text="-- Select --" Value="0" meta:resourcekey="ListItemResource3"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="ReqFieldMedium" runat="server" ErrorMessage="Please select medium"
                                    ValidationGroup="a" InitialValue="0" ControlToValidate="ddlMedium" meta:resourcekey="ReqFieldMediumResource1"
                                    Text="*"></asp:RequiredFieldValidator>
                            </div>
                            <div>
                                <asp:Label ID="lblStandard" runat="server" Text="Standard:" CssClass="textlabel"
                                    meta:resourcekey="lblStandardResource1"></asp:Label>
                                <asp:DropDownList ID="ddlStandard" runat="server" AppendDataBoundItems="True" Enabled="False"
                                    AutoPostBack="True" OnSelectedIndexChanged="ddlStandard_SelectedIndexChanged"
                                    meta:resourcekey="ddlStandardResource1" Width="140px">
                                    <asp:ListItem Text="-- Select --" Value="0" meta:resourcekey="ListItemResource4"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="ReqFieldStandard" runat="server" ErrorMessage="Please select standard"
                                    ValidationGroup="a" InitialValue="0" ControlToValidate="ddlStandard" meta:resourcekey="ReqFieldStandardResource1"
                                    Text="*"></asp:RequiredFieldValidator>
                            </div>
                            <div>
                                <asp:Label ID="lblsubject" runat="server" Text="Subject:" CssClass="textlabel" meta:resourcekey="lblsubjectResource1"></asp:Label>
                                <asp:DropDownList ID="ddlsubject" runat="server" AppendDataBoundItems="True" Enabled="False"
                                    AutoPostBack="True" OnSelectedIndexChanged="ddlsubject_SelectedIndexChanged"
                                    meta:resourcekey="ddlsubjectResource1" Width="140px">
                                    <asp:ListItem Text="-- Select --" Value="0" meta:resourcekey="ListItemResource5"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="ReqFieldSubject" runat="server" ErrorMessage="Please select Subject"
                                    ValidationGroup="a" InitialValue="0" ControlToValidate="ddlsubject" meta:resourcekey="ReqFieldSubjectResource1"
                                    Text="*"></asp:RequiredFieldValidator>
                            </div>
                            <div>
                                <asp:Label ID="lblChapter" runat="server" Text="Chapter:" CssClass="textlabel" meta:resourcekey="lblChapterResource1"></asp:Label>
                                <asp:DropDownList ID="ddlchapter" runat="server" AppendDataBoundItems="True" Enabled="False"
                                    AutoPostBack="True" OnSelectedIndexChanged="ddlchapter_SelectedIndexChanged"
                                    meta:resourcekey="ddlchapterResource1" Width="140px">
                                    <asp:ListItem Text="-- Select --" Value="0" meta:resourcekey="ListItemResource6"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="ReqFieldChapter" runat="server" ErrorMessage="Please select Chapter"
                                    ValidationGroup="a" InitialValue="0" ControlToValidate="ddlchapter" meta:resourcekey="ReqFieldChapterResource1"
                                    Text="*"></asp:RequiredFieldValidator>
                            </div>
                            <div>
                                <asp:Label ID="lbltopic" runat="server" Text="Topic:" CssClass="textlabel" meta:resourcekey="lbltopicResource1"></asp:Label>
                                <asp:DropDownList ID="ddltopic" runat="server" AppendDataBoundItems="True" Enabled="False"
                                    OnSelectedIndexChanged="ddltopic_SelectedIndexChanged" meta:resourcekey="ddltopicResource1"
                                    Width="140px">
                                    <asp:ListItem Text="-- Select --" Value="0" meta:resourcekey="ListItemResource7"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="ReqFieldtopic" runat="server" ErrorMessage="Please select Topic"
                                    ValidationGroup="a" InitialValue="0" ControlToValidate="ddltopic" meta:resourcekey="ReqFieldtopicResource1"
                                    Text="*"></asp:RequiredFieldValidator>
                            </div>
                            <div>
                                <asp:Label ID="lblDivision" runat="server" Text="Division:" CssClass="textlabel"
                                    meta:resourcekey="lbldivision"></asp:Label>
                                <asp:DropDownList ID="ddlDivision" runat="server" AutoPostBack="True" Enabled="False"
                                    meta:resourcekey="ddlDivisionResource1" Width="140px">
                                    <asp:ListItem Value="0" Text="-- Select --" meta:resourcekey="ListItemResource7"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="gobotton">
                                <asp:Button ID="btnview" runat="server" Text="View Report" OnClick="btnview_Click"
                                    ValidationGroup="a" meta:resourcekey="btnviewResource1" />
                                <asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="gobutton" OnClick="btnReset_Click"
                                    meta:resourcekey="btnResetResource1" Width="106px" />
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                    ShowSummary="False" ValidationGroup="a" meta:resourcekey="ValidationSummary1Resource1" />
                            </div>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlSchool" />
                        <asp:AsyncPostBackTrigger ControlID="ddlBoard" />
                        <asp:AsyncPostBackTrigger ControlID="ddlMedium" />
                        <asp:AsyncPostBackTrigger ControlID="ddlStandard" />
                        <asp:AsyncPostBackTrigger ControlID="ddlsubject" />
                        <asp:AsyncPostBackTrigger ControlID="ddlchapter" />
                        <asp:AsyncPostBackTrigger ControlID="ddltopic" />
                        <asp:AsyncPostBackTrigger ControlID="ddlDivision" />
                        <asp:PostBackTrigger ControlID="btnview" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
        <div class="sidepanel1">
            <div class="activitydivside1">
                <div class="ActivityHeader">
                    <asp:Label ID="lblBMSSCTname" runat="server"></asp:Label>
                </div>
                <div class="ActivityContent">
                    <div id="pnlandratingtable">
                        <asp:Panel ID="pnlreport" runat="server" Visible="False" meta:resourcekey="pnlreportResource1"
                            Height="100px">
                            <table align="center" class="ratingtable" cellpadding="0" cellspacing="0" width="100%"
                                style="margin: auto">
                                <tr>
                                    <td colspan="2">
                                        <asp:UpdatePanel ID="UPRatingFeedback" runat="server">
                                            <ContentTemplate>
                                                <cc1:Rating ID="ratingFeedback" CurrentRating="0" StarCssClass="ratingEmpty" WaitingStarCssClass="ratingSaved"
                                                    EmptyStarCssClass="ratingEmpty" FilledStarCssClass="ratingFilled" runat="server"
                                                    ReadOnly="True" BehaviorID="ratingFeedback_RatingExtender" meta:resourcekey="ratingFeedbackResource1"
                                                    Visible="false">
                                                </cc1:Rating>
                                                <asp:Label ID="lblPer" runat="server" meta:resourcekey="lblPerResource1" Visible="false"></asp:Label>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <span>5 Star</span>
                                    </td>
                                    <td align="center">
                                        <span>4 Star</span>
                                    </td>
                                    <td align="center">
                                        <span>3 Star</span>
                                    </td>
                                    <td align="center">
                                        <span>2 Star</span>
                                    </td>
                                    <td align="center">
                                        <span>1 Star</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="fivestar">
                                        &nbsp;
                                    </td>
                                    <td class="fourstar">
                                        &nbsp;
                                    </td>
                                    <td class="threestar">
                                        &nbsp;
                                    </td>
                                    <td class="twostar">
                                        &nbsp;
                                    </td>
                                    <td class="onestar">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td style="margin: 15px" align="center">
                                        <asp:Label ID="lbl5star" runat="server" Text="0%" meta:resourcekey="lbl5starResource1"></asp:Label>
                                    </td>
                                    <td align="center">
                                        <asp:Label ID="lbl4star" runat="server" Text="0%" meta:resourcekey="lbl4starResource1"></asp:Label>
                                    </td>
                                    <td align="center">
                                        <asp:Label ID="lbl3star" runat="server" Text="0%" meta:resourcekey="lbl3starResource1"></asp:Label>
                                    </td>
                                    <td align="center">
                                        <asp:Label ID="lbl2star" runat="server" Text="0%" meta:resourcekey="lbl2starResource1"></asp:Label>
                                    </td>
                                    <td align="center">
                                        <asp:Label ID="lbl1star" runat="server" Text="0%" meta:resourcekey="lbl1starResource1"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                        <table id="ratingtable" align="center" cellpadding="0" cellspacing="0" width="95%">
                            <tr>
                                <th align="left" style="border-bottom-style: ridge; border-width: thin">
                                    <asp:Label ID="lblreview" runat="server" Text="Review and Rating" meta:resourcekey="lblreviewResource1"
                                        Visible="False"></asp:Label>
                                </th>
                            </tr>
                            <tr>
                                <td>
                                    <asp:ListView ID="ListView1" runat="server" OnItemCommand="ListView1_OnItemCommand"
                                        GroupPlaceholderID="groupPlaceHolder1" DataKeyNames="ID" ItemPlaceholderID="itemPlaceHolder1"
                                        OnPagePropertiesChanging="OnPagePropertiesChanging">
                                        <EmptyDataTemplate>
                                            <span>No data was returned.</span>
                                        </EmptyDataTemplate>
                                        <ItemTemplate>
                                            <table width="100%" style="border: 1px solid black;">
                                                <tr style="border-style: groove; border-width: thin; width: 60%">
                                                    <td align="left">
                                                        <span><strong></strong>
                                                            <asp:Label ID="lbltype" runat="server" Style="font-weight: 700" Text='<%# Eval("Type") %>'
                                                                meta:resourcekey="FirstNameResource1" Visible="false" />
                                                            <asp:Label ID="lblid" runat="server" Style="font-weight: 700" Text='<%# Eval("ID") %>'
                                                                meta:resourcekey="FirstNameResource1" Visible="false" />
                                                            <asp:Label ID="lblfirstname" runat="server" Style="font-weight: 700" Text='<%# Eval("FirstName") %>'
                                                                meta:resourcekey="FirstNameResource1" />
                                                    </td>
                                                    <td align="right" style="width: 20%">
                                                        <asp:Label ID="lbldivision" runat="server" Style="font-weight: 700" Text='<%# Eval("Division") %>'
                                                            meta:resourcekey="FirstNameResource1" />
                                                        <asp:Label ID="lbldivisionid" runat="server" Style="font-weight: 700" Text='<%# Eval("DivisionID") %>'
                                                            meta:resourcekey="FirstNameResource1" Visible="false" />
                                                        <%--<asp:LinkButton ID="FirstName" runat="server" Style="font-weight: 700" Text='<%# Eval("FirstName") %>'
                                            meta:resourcekey="FirstNameResource1" CommandName="ID"></asp:LinkButton>--%>
                                                    </td>
                                                    <%--
                                <td>
                                    <span style="font-weight: bold">Review: </span>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("Feedback") %>' meta:resourcekey="FeedbackResource2" />
                                </td>--%>
                                                </tr>
                                                <%-- <tr>
                                <td colspan="2">
                                    <span style="font-weight: bold">Review: </span>
                                    <asp:Label ID="Feedback" runat="server" Text='<%# Eval("Feedback") %>' meta:resourcekey="FeedbackResource2" />
                                </td>
                            </tr>--%>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblreview" runat="server" Text="Rating" Font-Bold="True"></asp:Label>
                                                        <cc1:Rating ID="rating" CurrentRating='<%# Eval("Rating") %>' StarCssClass="ratingEmpty"
                                                            WaitingStarCssClass="ratingSaved" EmptyStarCssClass="ratingEmpty" FilledStarCssClass="ratingFilled"
                                                            runat="server" ReadOnly="True" BehaviorID="rating_RatingExtender" meta:resourcekey="ratingResource1">
                                                        </cc1:Rating>
                                                        <asp:LinkButton ID="LinkButton1" runat="server" Style="font-weight: 700" meta:resourcekey="FirstNameResource1"
                                                            CommandName="Image">
                                            <img src="../Images/uparrow.jpg"  alt="hide"/></asp:LinkButton>
                                                        <asp:LinkButton ID="LinkButton2" runat="server" Style="font-weight: 700" meta:resourcekey="FirstNameResource1"
                                                            CommandName="Image" Visible="false">
                                        <img src="../Images/downarrow.jpg" alt="Show" /></asp:LinkButton>
                                                    </td>
                                                    <td colspan="2" align="right">
                                                        <span style="font-weight: bold">Review: </span>
                                                        <asp:LinkButton ID="LinkButton3" runat="server" Style="font-weight: 700" meta:resourcekey="FirstNameResource1"
                                                            CommandName="Image1">
                                            <img src="../Images/uparrow.jpg"  alt="hide"/></asp:LinkButton>
                                                        <asp:LinkButton ID="LinkButton4" runat="server" Style="font-weight: 700" meta:resourcekey="FirstNameResource1"
                                                            CommandName="Image1" Visible="false">
                                        <img src="../Images/downarrow.jpg" alt="Show" /></asp:LinkButton>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <asp:Panel ID="pnlgrid" runat="server">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td colspan="2">
                                                                        <asp:GridView ID="grdFeedback1" runat="server" AutoGenerateColumns="false" Width="75%"
                                                                            Enabled="false">
                                                                            <Columns>
                                                                                <asp:TemplateField HeaderText="Feedback" ItemStyle-Width="80%">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblFeedBackQuestion" runat="server" Text='<%#Eval("FeedbackQuestion") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Rating" ItemStyle-Width="20%">
                                                                                    <ItemTemplate>
                                                                                        <cc1:Rating ID="ratingFeedback" CurrentRating='<%#Eval("Rating") %>' MaxRating="5"
                                                                                            StarCssClass="ratingEmpty" WaitingStarCssClass="ratingSaved" EmptyStarCssClass="ratingEmpty"
                                                                                            FilledStarCssClass="ratingFilled" runat="server" Enabled="false" ReadOnly="true">
                                                                                        </cc1:Rating>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                        </asp:GridView>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2">
                                                                        <asp:Label ID="Feedback" runat="server" Text='<%# Eval("Feedback") %>' meta:resourcekey="FeedbackResource2"
                                                                            Visible="false" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                        <LayoutTemplate>
                                            <table width="100%">
                                                <asp:PlaceHolder runat="server" ID="groupPlaceHolder1"></asp:PlaceHolder>
                                                <tr>
                                                    <td align="center">
                                                        <asp:DataPager ID="DataPager1" runat="server" PagedControlID="ListView1" PageSize="10">
                                                            <Fields>
                                                                <asp:NextPreviousPagerField ShowFirstPageButton="True" ShowPreviousPageButton="true"
                                                                    ShowNextPageButton="false" ButtonType="Image" FirstPageImageUrl="../App_Themes/Images/first.png"
                                                                    LastPageImageUrl="../App_Themes/Images/last.png" NextPageImageUrl="../App_Themes/Images/NEXT.png"
                                                                    PreviousPageImageUrl="../App_Themes/Images/previous.png" ShowLastPageButton="false"
                                                                    RenderDisabledButtonsAsLabels="False" />
                                                                <asp:NumericPagerField />
                                                                <asp:NextPreviousPagerField ShowFirstPageButton="false" ShowPreviousPageButton="false"
                                                                    ShowNextPageButton="true" ButtonType="Image" FirstPageImageUrl="../App_Themes/Images/first.png"
                                                                    LastPageImageUrl="../App_Themes/Images/last.png" NextPageImageUrl="../App_Themes/Images/NEXT.png"
                                                                    PreviousPageImageUrl="../App_Themes/Images/previous.png" ShowLastPageButton="True"
                                                                    RenderDisabledButtonsAsLabels="False" />
                                                            </Fields>
                                                        </asp:DataPager>
                                                    </td>
                                                </tr>
                                            </table>
                                        </LayoutTemplate>
                                        <GroupTemplate>
                                            <asp:PlaceHolder runat="server" ID="itemPlaceHolder1"></asp:PlaceHolder>
                                            <%-- <div id="Div2" runat="server" style="margin: 3px; float: left;">
                            <asp:PlaceHolder runat="server" ID="itemPlaceHolder1" />
                        </div>--%>
                                        </GroupTemplate>
                                        <GroupSeparatorTemplate>
                                            <div id="Div1" runat="server">
                                                <div style="clear: both">
                                                    <hr />
                                                </div>
                                            </div>
                                        </GroupSeparatorTemplate>
                                    </asp:ListView>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- LoaderPart -->
    <asp:Button ID="btnLoader" runat="server" Style="display: none" />
    <asp:Button ID="btnCancel" runat="server" Style="display: none" />
    <cc1:ModalPopupExtender ID="ModalPopup" runat="server" PopupControlID="dvPopup" CancelControlID="btnCancel"
        TargetControlID="btnLoader" BackgroundCssClass="modalBackground" Enabled="True">
    </cc1:ModalPopupExtender>
    <!-- LoaderPart -->
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
    </script>
</asp:Content>
