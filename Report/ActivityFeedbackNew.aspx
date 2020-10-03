<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Epathshala.master" AutoEventWireup="true"
    CodeFile="ActivityFeedbackNew.aspx.cs" Inherits="ActivityFeedbackNew" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="0" cellspacing="0" width="100%" class="InnerTableStyle RoundTop Width300 MarginBottom15px">
        <tr>
            <td align="center" class="Header round">
                <asp:Label ID="lblTitleFirst" runat="server" Text="Activity Feedback Report" meta:resourcekey="lblTitleFirstResource1"></asp:Label>
                <asp:Label ID="lblTitleSecond" runat="server" Text="Schoolwise Subject result report"
                    Visible="False" meta:resourcekey="lblTitleSecondResource1"></asp:Label>
                <asp:Label ID="lblTitleThird" runat="server" Text="Schoolwise all exam result report"
                    Visible="False" meta:resourcekey="lblTitleThirdResource1"></asp:Label>
                <asp:Label ID="lblTitleFourth" runat="server" Text="Exam Detail summary" Visible="False"
                    meta:resourcekey="lblTitleFourthResource1"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <div id="FirstRpt" runat="server" visible="true">
                    <table runat="server" id="tblFilter" cellpadding="2" cellspacing="2" width="100%">
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblSchool" runat="server" Text="School:" ToolTip="School Name:" meta:resourcekey="lblSchoolResource1"></asp:Label>
                            </td>
                            <td colspan="3">
                                <asp:DropDownList ID="ddlSchool" runat="server" Width="450px" AutoPostBack="True"
                                    OnSelectedIndexChanged="ddlSchool_SelectedIndexChanged" meta:resourcekey="ddlSchoolResource1">
                                    <asp:ListItem Text="-- Select --" Value="0" meta:resourcekey="ListItemResource1"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RFVddlSchool" runat="server" ControlToValidate="ddlSchool"
                                    InitialValue="0" ErrorMessage="Please Select School." ValidationGroup="a" meta:resourcekey="RFVddlSchoolResource1"
                                    Text="*"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblBoard" runat="server" Text="Board:" ToolTip="Board" meta:resourcekey="lblBoardResource1"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlBoard" runat="server" AutoPostBack="True" AppendDataBoundItems="True"
                                    OnSelectedIndexChanged="ddlBoard_SelectedIndexChanged" meta:resourcekey="ddlBoardResource1">
                                    <asp:ListItem Text="-- Select --" Value="0" meta:resourcekey="ListItemResource2"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="ReqFieldBoard" runat="server" ErrorMessage="Please select board"
                                    ValidationGroup="a" InitialValue="0" ControlToValidate="ddlBoard" meta:resourcekey="ReqFieldBoardResource1"
                                    Text="*"></asp:RequiredFieldValidator>
                            </td>
                            <td align="right">
                                <asp:Label ID="lblMedium" runat="server" Text="Medium:" meta:resourcekey="lblMediumResource1"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlMedium" runat="server" AutoPostBack="True" AppendDataBoundItems="True"
                                    Enabled="False" OnSelectedIndexChanged="ddlMedium_SelectedIndexChanged" meta:resourcekey="ddlMediumResource1">
                                    <asp:ListItem Text="-- Select --" Value="0" meta:resourcekey="ListItemResource3"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="ReqFieldMedium" runat="server" ErrorMessage="Please select medium"
                                    ValidationGroup="a" InitialValue="0" ControlToValidate="ddlMedium" meta:resourcekey="ReqFieldMediumResource1"
                                    Text="*"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblStandard" runat="server" Text="Standard:" meta:resourcekey="lblStandardResource1"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlStandard" runat="server" AppendDataBoundItems="True" Enabled="False"
                                    AutoPostBack="True" OnSelectedIndexChanged="ddlStandard_SelectedIndexChanged"
                                    meta:resourcekey="ddlStandardResource1">
                                    <asp:ListItem Text="-- Select --" Value="0" meta:resourcekey="ListItemResource4"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="ReqFieldStandard" runat="server" ErrorMessage="Please select standard"
                                    ValidationGroup="a" InitialValue="0" ControlToValidate="ddlStandard" meta:resourcekey="ReqFieldStandardResource1"
                                    Text="*"></asp:RequiredFieldValidator>
                            </td>
                            <td align="right">
                                <asp:Label ID="lblsubject" runat="server" Text="Subject:" meta:resourcekey="lblsubjectResource1"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlsubject" runat="server" AppendDataBoundItems="True" Enabled="False"
                                    AutoPostBack="True" OnSelectedIndexChanged="ddlsubject_SelectedIndexChanged"
                                    meta:resourcekey="ddlsubjectResource1">
                                    <asp:ListItem Text="-- Select --" Value="0" meta:resourcekey="ListItemResource5"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="ReqFieldSubject" runat="server" ErrorMessage="Please select Subject"
                                    ValidationGroup="a" InitialValue="0" ControlToValidate="ddlsubject" meta:resourcekey="ReqFieldSubjectResource1"
                                    Text="*"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblChapter" runat="server" Text="Chapter:" meta:resourcekey="lblChapterResource1"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlchapter" runat="server" AppendDataBoundItems="True" Enabled="False"
                                    AutoPostBack="True" OnSelectedIndexChanged="ddlchapter_SelectedIndexChanged"
                                    meta:resourcekey="ddlchapterResource1" Style="height: 22px">
                                    <asp:ListItem Text="-- Select --" Value="0" meta:resourcekey="ListItemResource6"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="ReqFieldChapter" runat="server" ErrorMessage="Please select Chapter"
                                    ValidationGroup="a" InitialValue="0" ControlToValidate="ddlchapter" meta:resourcekey="ReqFieldChapterResource1"
                                    Text="*"></asp:RequiredFieldValidator>
                            </td>
                            <td align="right">
                                <asp:Label ID="lbltopic" runat="server" Text="Topic:" meta:resourcekey="lbltopicResource1"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddltopic" runat="server" AppendDataBoundItems="True" Enabled="False"
                                    OnSelectedIndexChanged="ddltopic_SelectedIndexChanged" meta:resourcekey="ddltopicResource1">
                                    <asp:ListItem Text="-- Select --" Value="0" meta:resourcekey="ListItemResource7"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="ReqFieldtopic" runat="server" ErrorMessage="Please select Topic"
                                    ValidationGroup="a" InitialValue="0" ControlToValidate="ddltopic" meta:resourcekey="ReqFieldtopicResource1"
                                    Text="*"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                &nbsp;
                            </td>
                            <td colspan="2" align="left">
                                <asp:Button ID="btnview" runat="server" Text="View Report" OnClick="btnview_Click"
                                    ValidationGroup="a" meta:resourcekey="btnviewResource1" />
                                <asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="gobutton" OnClick="btnReset_Click"
                                    meta:resourcekey="btnResetResource1" />
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                    ShowSummary="False" ValidationGroup="a" meta:resourcekey="ValidationSummary1Resource1" />
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                    <%-- <table>
                       
                    </table>--%>
                </div>
            </td>
        </tr>
    </table>
    <asp:Panel ID="pnlreport" runat="server" Visible="False" meta:resourcekey="pnlreportResource1">
        <table align="center" cellpadding="0" cellspacing="0" width="40%">
            <tr>
                <td colspan="2">
                    <cc1:Rating ID="ratingFeedback" CurrentRating="0" StarCssClass="ratingEmpty" WaitingStarCssClass="ratingSaved"
                        EmptyStarCssClass="ratingEmpty" FilledStarCssClass="ratingFilled" runat="server"
                        ReadOnly="True" BehaviorID="ratingFeedback_RatingExtender" meta:resourcekey="ratingFeedbackResource1">
                    </cc1:Rating>
                    <asp:Label ID="lblPer" runat="server" meta:resourcekey="lblPerResource1"></asp:Label>
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
    <table align="center" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <th align="left" style="border-bottom-style: ridge; border-width: thin">
                <asp:Label ID="lblreview" runat="server" Text="Review and Rating" meta:resourcekey="lblreviewResource1"></asp:Label>
            </th>
        </tr>
        <tr>
            <td>
                <asp:ListView ID="ListView1" runat="server">
                    <EmptyDataTemplate>
                        <span>No data was returned.</span>
                    </EmptyDataTemplate>
                    <ItemTemplate>
                        <table width="100%">
                            <tr>
                                <td>
                                    <span><strong></strong>
                                        <%--<asp:Label ID="FirstName" runat="server" Style="font-weight: 700" 
                                        Text='<%# Eval("FirstName") %>' meta:resourcekey="FirstNameResource1" />
                                        <cc1:Rating ID="rating" CurrentRating='<%# Eval("AverageRating") %>' StarCssClass="ratingEmpty"
                                            WaitingStarCssClass="ratingSaved" EmptyStarCssClass="ratingEmpty" FilledStarCssClass="ratingFilled"
                                            runat="server" ReadOnly="True" BehaviorID="rating_RatingExtender" 
                                        meta:resourcekey="ratingResource1">--%>
                                        <asp:Label ID="lblid" runat="server" Style="font-weight: 700" Text='<%# Eval("ID") %>'
                                            meta:resourcekey="FirstNameResource1" Visible="false" />
                                        <asp:LinkButton ID="lnkFirstName" runat="server" Style="font-weight: 700" Text='<%# Eval("FirstName") %>'
                                            meta:resourcekey="FirstNameResource1" CommandName="ID" OnClick="lnkFirstName_Click"></asp:LinkButton>
                                        <cc1:Rating ID="rating" CurrentRating='<%# Eval("AverageRating") %>' StarCssClass="ratingEmpty"
                                            WaitingStarCssClass="ratingSaved" EmptyStarCssClass="ratingEmpty" FilledStarCssClass="ratingFilled"
                                            runat="server" ReadOnly="True" BehaviorID="rating_RatingExtender" meta:resourcekey="ratingResource1">
                                        </cc1:Rating>
                                </td>
                            </tr>
                            <tr>
                                <td style="border-bottom-style: inset; border-bottom-width: thin">
                                    <asp:Label ID="Feedback" runat="server" Text='<%# Eval("Feedback") %>' meta:resourcekey="FeedbackResource2" />
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                    <LayoutTemplate>
                        <div id="itemPlaceholderContainer" runat="server" style="font-family: Verdana, Arial, Helvetica, sans-serif;">
                            <span runat="server" id="itemPlaceholder" />
                        </div>
                    </LayoutTemplate>
                </asp:ListView>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
    <asp:Button runat="server" Text="show popup" ID="btnshowpopup" OnClick="btnshowpopup_Click" style="display: none"/>
    <asp:Button runat="server" Text="show popup1" ID="Button1" OnClick="Button1_Click"  style="display: none"/>
    <cc1:ModalPopupExtender ID="modalpop" runat="server" PopupControlID="Display" TargetControlID="Button1"
        BackgroundCssClass="modalBackground1" DynamicServicePath="" Enabled="True">
    </cc1:ModalPopupExtender>
    <table id="Display" runat="server" class="modalPopup3 InnerTableStyle RoundTop tblControls"
        align="center" cellpadding="0" cellspacing="0" style="margin: 0px; display: none;
        border: 1px solid black;" meta:resourcekey="SelectBMSResource1">
        <tr>
            <td>
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
            </td>
        </tr>
        </table>
       
        <asp:Button ID="btnshow" runat="server" Text="Popup window" />
    
</asp:Content>
