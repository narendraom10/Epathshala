<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Epathshala.master" AutoEventWireup="true"
    CodeFile="ViewAllTeacherNotes.aspx.cs" Inherits="Teacher_ViewAllTeacherNotes"
    Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="upAllNotes" runat="server">
        <ContentTemplate>
            <table class="RoundTop InnerTableStyle TableControl" cellpadding="0" cellspacing="0"
                width="50%">
                <tr>
                    <td class="Header12 GridViewHeadercssTestAssessment RoundTop" colspan="4">
                        <asp:Label ID="lblTeacherNoteHeader" runat="server" Text="All Teacher Note" meta:resourcekey="lblTeacherNoteHeaderResource1"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblSchoolAllNotes" runat="server" Text="School Name" meta:resourcekey="lblSchoolAllNotesResource1"></asp:Label>
                    </td>
                    <td>
                        <asp:Literal ID="LtSchoolID" runat="server" Visible="False" meta:resourceKey="LtSchoolIDResource1"></asp:Literal>
                        <asp:TextBox ID="TxtSchoolName" runat="server" OnTextChanged="TxtSchoolName_TextChanged"
                            meta:resourcekey="TxtSchoolNameResource1"></asp:TextBox>
                        <cc2:AutoCompleteExtender ID="TxtSchName_AutoCompleteExtender" runat="server" DelimiterCharacters=""
                            Enabled="True" ServiceMethod="GetSchoolName" ServicePath="" MinimumPrefixLength="1"
                            TargetControlID="TxtSchoolName" UseContextKey="True" CompletionInterval="100"
                            FirstRowSelected="True">
                        </cc2:AutoCompleteExtender>
                    </td>
                    <td>
                        <asp:Label ID="lblDate" runat="server" Text="Date" meta:resourcekey="lblDateResource1"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDate" runat="server" meta:resourcekey="txtDateResource1"></asp:TextBox>
                        <asp:ImageButton ID="ibtnDate" runat="server" ImageUrl="~/App_Themes/Images/Calender.gif"
                            Width="20px" meta:resourcekey="ibtnDateResource1" />
                        <cc2:CalendarExtender ID="ceDate" runat="server" TargetControlID="txtDate" PopupButtonID="ibtnDate"
                            Enabled="True" Format="dd-MMM-yyyy">
                        </cc2:CalendarExtender>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td colspan="3">
                        <asp:Button ID="btnGo" Text="GO" runat="server" OnClick="btnGo_Click" meta:resourcekey="btnGoResource1" />
                        <asp:Button ID="btnReset" Text="Reset" runat="server" OnClick="btnReset_Click" meta:resourcekey="btnResetResource1" />
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:GridView ID="gvAllNotes" runat="server" AutoGenerateColumns="False" DataKeyNames="Name,BMS_SCT,Note"
                            AllowPaging="True" OnPageIndexChanging="gvAllNotes_PageIndexChanging" OnRowCommand="gvAllNotes_RowCommand"
                            meta:resourcekey="gvAllNotesResource1">
                            <Columns>
                                <asp:TemplateField HeaderText="School" meta:resourcekey="TemplateFieldResource1">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSchool" runat="server" Text='<%# Eval("Name") %>' meta:resourcekey="lblSchoolResource1"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="BMSSCT" Visible="False" meta:resourcekey="TemplateFieldResource2">
                                    <ItemTemplate>
                                        <asp:Label ID="lblBMSSCT" runat="server" Text='<%# Eval("BMS_SCT") %>' meta:resourcekey="lblBMSSCTResource1"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Note" Visible="False" meta:resourcekey="TemplateFieldResource3">
                                    <ItemTemplate>
                                        <asp:Label ID="lblNote" runat="server" Text='<%# Eval("Note") %>' meta:resourcekey="lblNoteResource1"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Date" meta:resourcekey="TemplateFieldResource4">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCreatedOn" runat="server" Text='<%# string.Format("{0:dd-MMM-yyyy}", Eval("CreatedOn")) %>'
                                            meta:resourcekey="lblCreatedOnResource1"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="View" meta:resourcekey="TemplateFieldResource5">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imgView" CausesValidation="False" CommandName="ViewNote" Width="12px"
                                            CommandArgument='<%# Convert.ToInt32(Container.DataItemIndex) %>' Height="12px"
                                            ToolTip="View" runat="server" ImageUrl="~/App_Themes/Images/View.gif" meta:resourcekey="imgViewResource1" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <asp:Button ID="btnShowPopup" runat="server" Style="display: none" meta:resourcekey="btnShowPopupResource1" />
                        <cc2:ModalPopupExtender ID="ModalPopUpNotes" runat="server" TargetControlID="btnShowPopup"
                            PopupControlID="PnlPopup" CancelControlID="BtnClose" DynamicServicePath="" Enabled="True"
                            BackgroundCssClass="modalBackground">
                        </cc2:ModalPopupExtender>
                        <asp:Panel ID="PnlPopup" runat="server" align="left" CssClass="PopupContent" meta:resourcekey="PnlPopupResource1">
                            <asp:UpdatePanel ID="upPopUp" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <table class="modalPopup3 InnerTableStyle RoundTop tblControls" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td colspan="2" class="Header12 RoundTop GridViewHeadercssTestAssessment">
                                                <asp:Label ID="lblPopUpHeader" runat="server" Text="Teacher Note" meta:resourcekey="lblPopUpHeaderResource1"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblSchool" runat="server" Text="School Name:" ForeColor="#777777"
                                                    meta:resourcekey="lblSchoolResource2"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblPopUpSchoolName" runat="server" ForeColor="#777777" meta:resourcekey="lblPopUpSchoolNameResource1"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblPopUpBMSSCTDisplay" runat="server" Text="BMSSCT:" ForeColor="#777777"
                                                    meta:resourcekey="lblPopUpBMSSCTDisplayResource1"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblPopUpBMSSCT" runat="server" ForeColor="#777777" meta:resourcekey="lblPopUpBMSSCTResource1"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblPopUpNoteDisplay" runat="server" Text="Note:" ForeColor="#777777"
                                                    meta:resourcekey="lblPopUpNoteDisplayResource1"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblPopUpNote" runat="server" ForeColor="#777777" meta:resourcekey="lblPopUpNoteResource1"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="text-align: right;">
                                                <asp:Button ID="BtnClose" runat="server" Text="Close" meta:resourcekey="BtnCloseResource1" />
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
