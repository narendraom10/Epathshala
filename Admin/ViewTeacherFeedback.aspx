<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Epathshala.master" AutoEventWireup="true"
    CodeFile="ViewTeacherFeedback.aspx.cs" Inherits="Admin_ViewTeacherFeedback" EnableEventValidation="false"
    Culture="auto" meta:resourcekey="PageResource2" UICulture="auto" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .popUpTable tr td span
        {
            vertical-align: top;
            color: #777777;
        }
        .style1
        {
            height: 26px;
        }
        .style2
        {
            height: 22px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="upFeedBack" runat="server">
        <ContentTemplate>
            <table class="RoundTop InnerTableStyle TableControl TableControl1" width="90%" cellpadding="0"
                cellspacing="0">
                <tr>
                    <td class="Header12 GridViewHeadercssTestAssessment RoundTop" colspan="4">
                        <asp:Label ID="lblFeedBackReportHeader" runat="server" Text="Teacher Feedback Report"
                            meta:resourcekey="lblFeedBackReportHeaderResource1"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table class="tblControl1">
                            <tr>
                                <td>
                                    <asp:Label ID="lblSchool" runat="server" Text="School:" meta:resourcekey="lblSchoolResource1"></asp:Label>
                                </td>
                                <td style="text-align: left;">
                                    <asp:DropDownList ID="ddlSchool" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSchool_SelectedIndexChanged"
                                        meta:resourcekey="ddlSchoolResource1">
                                        <asp:ListItem Text="-- Select --" Value="0" meta:resourcekey="ListItemResource1"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Label ID="lblDate" runat="server" Text="Date:" meta:resourcekey="lblDateResource1"></asp:Label>
                                </td>
                                <td style="text-align: left;">
                                    <asp:TextBox ID="txtDate" runat="server" meta:resourcekey="txtDateResource1"></asp:TextBox>
                                    <asp:ImageButton ID="ibtnDate" runat="server" ImageUrl="~/App_Themes/Images/Calender.gif"
                                        Width="20px" meta:resourcekey="ibtnDateResource1" />
                                    <cc2:CalendarExtender ID="ceDate" runat="server" Format="dd-MMM-yyyy" TargetControlID="txtDate"
                                        PopupButtonID="ibtnDate" Enabled="True">
                                    </cc2:CalendarExtender>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblBMS" runat="server" Text="BMS:" meta:resourcekey="lblBMSResource1"></asp:Label>
                                </td>
                                <td style="text-align: left;">
                                    <asp:DropDownList ID="ddlBMS" runat="server" OnSelectedIndexChanged="ddlBMS_SelectedIndexChanged"
                                        AutoPostBack="True" meta:resourcekey="ddlBMSResource1">
                                        <asp:ListItem Value="0" Text="-- Select --" meta:resourcekey="ListItemResource2"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Label ID="lblSCT" runat="server" Text="SCT:" meta:resourcekey="lblSCTResource1"></asp:Label>
                                </td>
                                <td style="text-align: left;">
                                    <asp:DropDownList ID="ddlSCT" AutoPostBack="True" runat="server" meta:resourcekey="ddlSCTResource1">
                                        <asp:ListItem Value="0" Text="-- Select --" meta:resourcekey="ListItemResource3"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblTeacher" runat="server" Text="Teacher:" meta:resourcekey="lblTeacherResource1"></asp:Label>
                                </td>
                                <td colspan="3" style="text-align: left;">
                                    <asp:DropDownList ID="ddlTeacher" runat="server" AutoPostBack="True" meta:resourcekey="ddlTeacherResource1">
                                        <asp:ListItem Value="0" Text="-- Select --" meta:resourcekey="ListItemResource4"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td colspan="3" style="text-align: center;">
                                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click"
                                        meta:resourcekey="btnSubmitResource1" />
                                    <asp:Button ID="btnReset" runat="server" Text="Reset" OnClick="btnReset_Click" meta:resourcekey="btnResetResource1" />
                                    <asp:Button ID="btnSendEmail" runat="server" Text="Send Email" OnClick="btnSendEmail_Click"
                                        OnClientClick="return confirm('Are you sure you want to send an email ? ');"
                                        meta:resourcekey="btnSendEmailResource1" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:GridView ID="gvFeedBack" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                            DataKeyNames="SchoolID,Name,BMSID,BMS,Division,BMS_SCT,BMSSCTID,SCTID,EmployeeID,FirstName,CreatedOn,ActivityFeedbackID,Feedback"
                            OnPageIndexChanging="gvFeedBack_PageIndexChanging" OnRowCreated="gvFeedBack_RowCreated"
                            OnSorting="gvFeedBack_Sorting" OnRowCommand="gvFeedBack_RowCommand" meta:resourcekey="gvFeedBackResource1">
                            <Columns>
                                <asp:BoundField DataField="Name" HeaderText="School" meta:resourcekey="BoundFieldResource1" />
                                <asp:BoundField DataField="BMS" HeaderText="Board >> Medium >> Standard" meta:resourcekey="BoundFieldResource2" />
                                <asp:BoundField DataField="Division" HeaderText="Division" meta:resourcekey="BoundFieldResource3" />
                                <asp:BoundField DataField="FirstName" HeaderText="Teacher" meta:resourcekey="BoundFieldResource4" />
                                <asp:TemplateField HeaderText="Date" meta:resourcekey="TemplateFieldResource1">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCreatedOn" runat="server" Text='<%# string.Format("{0:dd-MMM-yyyy}", Eval("CreatedOn")) %>'
                                            meta:resourcekey="lblCreatedOnResource1"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="FeedBack" meta:resourcekey="TemplateFieldResource2">
                                    <ItemTemplate>
                                        <asp:Label ID="lblBrifFeedback" runat="server" Text='<%# Limit(Eval("Feedback"),40) %>'
                                            ToolTip='<%# Eval("Feedback") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Feedback" Visible="False" meta:resourcekey="TemplateFieldResource3">
                                    <ItemTemplate>
                                        <asp:Label ID="lblgvFeedBack" runat="server" Text='<%# Eval("Feedback") %>' meta:resourcekey="lblgvFeedBackResource1"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="View" meta:resourcekey="TemplateFieldResource4">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imgView" CausesValidation="False" CommandName="ViewFeedBack"
                                            Width="12px" CommandArgument='<%# Convert.ToInt32(Container.DataItemIndex) %>'
                                            Height="12px" ToolTip="View" runat="server" ImageUrl="~/App_Themes/Images/View.gif"
                                            meta:resourcekey="imgViewResource1" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <PagerTemplate>
                                <asp:ImageButton Text="First" CommandName="Page" CommandArgument="First" runat="server"
                                    ImageUrl="~/App_Themes/Images/first.png" ID="ibtnFirst" ToolTip="Move First Page"
                                    meta:resourcekey="ibtnFirstResource1" />
                                <asp:ImageButton Text="Previous" CommandName="Page" CommandArgument="Prev" runat="server"
                                    ImageUrl="~/App_Themes/Images/previous.png" ID="ibtnPrevious" ToolTip="Move Previous Page"
                                    meta:resourcekey="ibtnPreviousResource1" />
                                <asp:Label ID="lblPage" runat="server" Text="Page" meta:resourcekey="lblPageResource1"></asp:Label>
                                <asp:DropDownList ID="ddlPageSelector" OnSelectedIndexChanged="ddlPageSelector_SelectedIndexChanged"
                                    runat="server" AutoPostBack="True" SkinID="DdlWidth50" meta:resourcekey="ddlPageSelectorResource1">
                                </asp:DropDownList>
                                <asp:ImageButton Text="Next" CommandName="Page" CommandArgument="Next" runat="server"
                                    ImageUrl="~/App_Themes/Images/NEXT.png" ID="ibtnNext" ToolTip="Move Next Page"
                                    meta:resourcekey="ibtnNextResource1" />
                                <asp:ImageButton Text="Last" CommandName="Page" CommandArgument="Last" runat="server"
                                    ImageUrl="~/App_Themes/Images/last.png" ID="ibtnLast" ToolTip="Move Last Page"
                                    meta:resourcekey="ibtnLastResource1" />
                            </PagerTemplate>
                        </asp:GridView>
                        <asp:Button ID="btnShowPopup" runat="server" Style="display: none" meta:resourcekey="btnShowPopupResource1" />
                        <cc2:ModalPopupExtender ID="ModalPopUpFeedback" runat="server" TargetControlID="btnShowPopup"
                            PopupControlID="PnlPopup" CancelControlID="BtnClose" DynamicServicePath="" Enabled="True">
                        </cc2:ModalPopupExtender>
                        <asp:Panel ID="PnlPopup" runat="server" align="left" CssClass="PopupContent" Style="display: none;"
                            meta:resourcekey="PnlPopupResource1">
                            <asp:UpdatePanel ID="upPopUp" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <table class="popUpTable">
                                        <tr>
                                            <td colspan="4" class="Header round" align="center">
                                                <asp:Label ID="lblPopUpHeader" runat="server" Text="Teacher Feedback" meta:resourcekey="lblPopUpHeaderResource1"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblPopUpSchool" runat="server" Text="School:" meta:resourcekey="lblPopUpSchoolResource1"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblPopUpSchoolValue" runat="server" meta:resourcekey="lblPopUpSchoolValueResource1"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblPopUpDate" runat="server" Text="Date:" meta:resourcekey="lblPopUpDateResource1"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblPopUpDateValue" runat="server" meta:resourcekey="lblPopUpDateValueResource1"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblPopUPBMSSCT" runat="server" Text="BMSSCT:" meta:resourcekey="lblPopUPBMSSCTResource1"></asp:Label>
                                            </td>
                                            <td colspan="3">
                                                <asp:Label ID="lblPopUPBMSSCTValue" runat="server" meta:resourcekey="lblPopUPBMSSCTValueResource1"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblPopUpEmployee" runat="server" Text="Teacher:" meta:resourcekey="lblPopUpEmployeeResource1"></asp:Label>
                                            </td>
                                            <td colspan="3">
                                                <asp:Label ID="lblPopUpEmployeeValue" runat="server" meta:resourcekey="lblPopUpEmployeeValueResource1"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblPopUpFeedBack" runat="server" Text="FeedBack:" meta:resourcekey="lblPopUpFeedBackResource1"></asp:Label>
                                            </td>
                                            <td colspan="3">
                                                <asp:Label ID="lblPopUpFeedBackValue" runat="server" meta:resourcekey="lblPopUpFeedBackValueResource1"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <div>
                                <asp:Button ID="BtnClose" runat="server" Text="Close" meta:resourcekey="BtnCloseResource1" /></div>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
