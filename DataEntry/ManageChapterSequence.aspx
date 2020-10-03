<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Epathshala.master" AutoEventWireup="true"
    CodeFile="ManageChapterSequence.aspx.cs" Inherits="DataEntry_ManageChapterSequence"
    Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="../Scripts/Jquery1.9.1.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {

            $("#<%= ImgBtnSearch.ClientID%>").click(function () {
                if ($("#<%= PnlSearch.ClientID%>").is(':Visible')) {
                    $("#<%= PnlSearch.ClientID%>").removeClass("Visible").addClass("InVisible");
                } else {
                    $("#<%= PnlSearch.ClientID%>").removeClass("InVisible").addClass("Visible");
                }
                return false;
            });
        });
    </script>
    <table cellpadding="0" cellspacing="0" width="75%" class="RoundTop InnerTableStyle TableControl">
        <tr>
            <td class="Header12 GridViewHeadercssTestAssessment RoundTop">
                <asp:Label ID="LblManageChap" runat="server" Text="Manage Chapter Sequence" meta:resourcekey="LblManageChapResource1"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <table class="ActionBarTable" cellpadding="0" cellspacing="0">
                    <tr>
                        <td class="LeftCorner">
                        </td>
                        <td class="Center">
                            <table cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td class="InnerLeftRound">
                                    </td>
                                    <td class="Divider">
                                    </td>
                                    <td class="Buttons">
                                        <asp:ImageButton ID="ImgBtnSearch" runat="server" ImageUrl="~/App_Themes/Images/ButtonBarView.png"
                                            ToolTip="Search" meta:resourcekey="ImgBtnSearchResource1" />
                                    </td>
                                    <td class="Buttons">
                                        <asp:ImageButton ID="ImgBtnRefresh" runat="server" ImageUrl="~/App_Themes/Images/ButtonBarRefresh.png"
                                            ToolTip="Refresh" OnClick="ImgBtnRefresh_Click" meta:resourcekey="ImgBtnRefreshResource1" />
                                    </td>
                                    <td class="Buttons">
                                        <asp:ImageButton ID="ibtnSetSeq" runat="server" Text="Set Chapter Sequence." ImageUrl="~/App_Themes/Images/ButtonBarNew.png"
                                            ToolTip="Set Chapter Sequence." OnClick="ibtnSetSeq_Click" meta:resourcekey="ibtnSetSeqResource1" />
                                    </td>
                                    <td class="InnerRightRound">
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td class="RightCorner">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="center">
                <table width="100%">
                    <tr>
                        <td colspan="3" class="panel">
                            <asp:UpdatePanel runat="server" ID="upMain" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:Panel ID="PnlSearch" CssClass="Visible" runat="server" meta:resourcekey="PnlSearchResource1">
                                        <fieldset>
                                            <legend>
                                                <asp:Label ID="LblFLSearch" runat="server" Text="Search" CssClass="SubTitle" meta:resourceKey="LblFLSearchResource1"></asp:Label></legend>
                                            <table class="tblControls">
                                                <tr>
                                                    <td class="Required">
                                                        <asp:Label ID="lblBoard" runat="server" Text="BMS:" meta:resourceKey="lblBoardResource1"></asp:Label>
                                                    </td>
                                                    <td colspan="2">
                                                        <asp:DropDownList ID="ddlBoard" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlBoard_SelectedIndexChanged"
                                                            meta:resourceKey="ddlBoardResource1">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RFVDdlBoard" runat="server" ControlToValidate="DdlBoard"
                                                            InitialValue="-- Select --" ErrorMessage="Please Select BMS." ValidationGroup="PnlBMS"
                                                            meta:resourceKey="RFVDdlBoardResource1">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="Required">
                                                        <asp:Label ID="LblSubject" runat="server" Text="Subject:" meta:resourceKey="LblSubjectResource1"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlSubject" runat="server" Enabled="False" OnSelectedIndexChanged="ddlSubject_SelectedIndexChanged"
                                                            meta:resourceKey="ddlSubjectResource1">
                                                            <asp:ListItem Text="-- Select --" meta:resourceKey="ListItemResource1"></asp:ListItem>
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RFVDdlSubject" runat="server" ControlToValidate="DdlSubject"
                                                            InitialValue="-- Select --" ErrorMessage="Please Select Subject." ValidationGroup="PnlBMS"
                                                            meta:resourceKey="RFVDdlSubjectResource1">*</asp:RequiredFieldValidator>
                                                    </td>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right">
                                                        &nbsp;
                                                    </td>
                                                    <td>
                                                        <table>
                                                            <tr>
                                                                <td>
                                                                    <asp:Button ID="BtnGo" runat="server" Text="Go" CssClass="gobutton" ValidationGroup="PnlBMS"
                                                                        OnClick="BtnGo_Click" meta:resourceKey="BtnGoResource1" />
                                                                </td>
                                                                <td>
                                                                    <asp:Button ID="btnReset" runat="server" Text="Reset" CausesValidation="False" OnClick="btnReset_Click"
                                                                        CssClass="gobutton" meta:resourceKey="btnResetResource1" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </fieldset>
                                    </asp:Panel>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddlBoard" />
                                    <asp:AsyncPostBackTrigger ControlID="ddlSubject" />
                                    <asp:PostBackTrigger ControlID="BtnGo" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" align="center">
                            <asp:GridView ID="grdChapter" runat="server" DataKeyNames="BMSSCTID,ChapterID,TopicID"
                                AutoGenerateColumns="False" EmptyDataText="No Data Found." OnSorting="grdChapter_Sorting"
                                meta:resourcekey="grdChapterResource1" SkinID="WithoutPageSize1">
                                <Columns>
                                    <asp:TemplateField HeaderText="Sr. No" meta:resourcekey="TemplateFieldResource1">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex +1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Chapter" HeaderText="Chapter" SortExpression="Chapter"
                                        meta:resourcekey="BoundFieldResource1" />
                                    <asp:BoundField DataField="Topic" HeaderText="Topic" SortExpression="Topic" meta:resourcekey="BoundFieldResource2" />
                                    <asp:TemplateField HeaderText="Sequence No." SortExpression="SequenceNo" meta:resourcekey="TemplateFieldResource2">
                                        <ItemTemplate>
                                            <asp:TextBox ID="TxtSequenceNo" runat="server" Text='<%# Bind("SequenceNo") %>' meta:resourcekey="TxtSequenceNoResource1"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RFVTxtSequenceNo" runat="server" ControlToValidate="TxtSequenceNo"
                                                InitialValue="0" Display="None" ErrorMessage="Please Enter Sequence value" ValidationGroup="PnlBMS"
                                                meta:resourcekey="RFVTxtSequenceNoResource1" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" align="center">
                            <asp:Button ID="BtnSetSeq" Text="Set Sequence" runat="server" ValidationGroup="PnlBMS"
                                Visible="False" meta:resourcekey="BtnSetSeqResource1" />
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" align="center">
                            <asp:ValidationSummary ID="VSPnlBMS" runat="server" ValidationGroup="PnlBMS" ShowMessageBox="True"
                                ShowSummary="False" meta:resourcekey="VSPnlBMSResource1" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" align="center">
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <!-- LoaderPart -->
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
