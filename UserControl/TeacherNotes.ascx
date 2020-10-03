<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TeacherNotes.ascx.cs"
    Inherits="UserControl_TeacherNotes" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<asp:UpdatePanel runat="server" ID="upNotesControl">
    <ContentTemplate>
        <table class="InnerTableStyle RoundTop" width="98%" align="center" cellpadding="0"
            cellspacing="0">
            <tr>
                <td align="center" class="Header12 GridViewHeadercssTestAssessment RoundTop" colspan="2">
                    <asp:Label ID="lblTeacherNoteHeader" runat="server" Text="Teacher Note" meta:resourcekey="lblTeacherNoteHeaderResource1"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:GridView ID="gvNotes" runat="server" AutoGenerateColumns="False" PageSize="5"
                        DataKeyNames="Name,BMS_SCT,Note" OnRowCommand="gvNotes_RowCommand" AllowPaging="True"
                        OnPageIndexChanging="gvNotes_PageIndexChanging" meta:resourcekey="gvNotesResource1">
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
                    <asp:Panel ID="PnlPopup" runat="server" align="left" class="modalPopup2 RoundTop RoundBottom InnerTableStyle"
                        meta:resourcekey="PnlPopupResource1">
                        <asp:UpdatePanel ID="upPopUp" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <table class="InnerTableStyle RoundTop" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td colspan="2" class="Header12 GridViewHeadercssTestAssessment RoundTop" align="center">
                                            <asp:Label ID="lblPopUpHeader" runat="server" Text="Teacher Note" meta:resourcekey="lblPopUpHeaderResource1"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblSchool" runat="server" Text="School Name:" meta:resourcekey="lblSchoolResource2"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblPopUpSchoolName" runat="server" meta:resourcekey="lblPopUpSchoolNameResource1"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblPopUpBMSSCTDisplay" runat="server" Text="BMSSCT:" meta:resourcekey="lblPopUpBMSSCTDisplayResource1"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblPopUpBMSSCT" runat="server" meta:resourcekey="lblPopUpBMSSCTResource1"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblPopUpNoteDisplay" runat="server" Text="Note:" meta:resourcekey="lblPopUpNoteDisplayResource1"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblPopUpNote" runat="server" meta:resourcekey="lblPopUpNoteResource1"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <div style="vertical-align: middle; text-align: center; padding-bottom: 5px;">
                            <asp:Button ID="BtnClose" runat="server" Text="Close" meta:resourcekey="BtnCloseResource1" /></div>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <asp:LinkButton ID="lnkViewAll" runat="server" OnClick="lnkViewAll_Click" meta:resourcekey="lnkViewAllResource1"
                        Text="View All"></asp:LinkButton>
                </td>
            </tr>
        </table>
    </ContentTemplate>
</asp:UpdatePanel>
