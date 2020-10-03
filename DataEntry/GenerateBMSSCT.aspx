<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Epathshala.master" AutoEventWireup="true"
    CodeFile="GenerateBMSSCT.aspx.cs" Inherits="DataEntry_GenerateBMSSCT" Culture="auto"
    meta:resourcekey="PageResource1" UICulture="auto" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="RoundTop InnerTableStyle TableControl" width="90%" cellpadding="0"
        cellspacing="0">
        <tr>
            <td colspan="3" class="Header12 GridViewHeadercssTestAssessment RoundTop">
                <asp:Label ID="LblBMS" runat="server" Text="Generate BMS SCT" meta:resourcekey="LblBMSResource1"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <table class="tblControl1">
                    <tr>
                        <td class="Required">
                            <asp:Label ID="lblBoard" runat="server" Text="BMS:" meta:resourcekey="lblBoardResource1"></asp:Label>
                        </td>
                        <td colspan="2" style="text-align: left;">
                            <asp:DropDownList ID="ddlBoard" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlBoard_SelectedIndexChanged"
                                meta:resourcekey="ddlBoardResource1">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RFVDdlBoard" runat="server" ControlToValidate="DdlBoard"
                                InitialValue="-- Select --" ErrorMessage="Please Select BMS." ValidationGroup="PnlBMS"
                                meta:resourcekey="RFVDdlBoardResource1">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="Required">
                            <asp:Label ID="LblSubject" runat="server" Text="Subject:" meta:resourcekey="LblSubjectResource1"></asp:Label>
                        </td>
                        <td style="text-align: left;">
                            <asp:DropDownList ID="ddlSubject" runat="server" Enabled="False" SkinID="DdlWidth150"
                                OnSelectedIndexChanged="ddlSubject_SelectedIndexChanged" AutoPostBack="True"
                                meta:resourcekey="ddlSubjectResource1">
                                <asp:ListItem Text="-- Select --" meta:resourcekey="ListItemResource1"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RFVDdlSubject" runat="server" ControlToValidate="DdlSubject"
                                InitialValue="-- Select --" ErrorMessage="Please Select Subject." ValidationGroup="PnlBMS"
                                meta:resourcekey="RFVDdlSubjectResource1">*</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="Required">
                            <asp:Label ID="LblChapter" runat="server" Text="Chapter:" meta:resourcekey="LblChapterResource1"></asp:Label>
                        </td>
                        <td style="text-align: left;">
                            <asp:DropDownList ID="ddlChapter" runat="server" Enabled="False" SkinID="DdlWidth150"
                                AutoPostBack="True" OnSelectedIndexChanged="ddlChapter_SelectedIndexChanged"
                                meta:resourcekey="ddlChapterResource1">
                                <asp:ListItem Text="-- Select --" meta:resourcekey="ListItemResource2"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RFVDdlChapter" runat="server" ControlToValidate="DdlChapter"
                                InitialValue="-- Select --" ErrorMessage="Please Select Chapter." ValidationGroup="PnlBMS"
                                meta:resourcekey="RFVDdlChapterResource1">*</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <div id="DivChapterAdd" runat="server" visible="false">
                                <asp:TextBox ID="TxtChapterIndex" runat="server" Width="50px" meta:resourcekey="TxtChapterIndexResource1"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rqdTxtChapterIndex" runat="server" ControlToValidate="TxtChapterIndex"
                                    ErrorMessage="Please Enter Chapter Index." ValidationGroup="ChapterAdd" meta:resourcekey="rqdTxtChapterIndexResource1">*</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revchapterindex" runat="server" ControlToValidate="TxtChapterIndex"
                                    ErrorMessage="Please Enter Number Only" ValidationGroup="ChapterAdd" ValidationExpression="[\d]{1,5}">*</asp:RegularExpressionValidator>
                                <asp:TextBox ID="TxtChapterName" runat="server" Width="120px" meta:resourcekey="TxtChapterNameResource1"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rqdTxtChapterName" runat="server" ControlToValidate="TxtChapterName"
                                    ErrorMessage="Please Enter Chapter Name." ValidationGroup="ChapterAdd" meta:resourcekey="rqdTxtChapterNameResource1">*</asp:RequiredFieldValidator>
                                <asp:Button runat="server" ID="BtnChapterAdd" Text="Add" CssClass="gobutton" OnClick="BtnChapterAdd_Click"
                                    ValidationGroup="ChapterAdd" meta:resourcekey="BtnChapterAddResource1" />
                                <asp:ValidationSummary ID="vsChapterAdd" runat="server" ValidationGroup="ChapterAdd"
                                    ShowMessageBox="True" ShowSummary="False" meta:resourcekey="vsChapterAddResource1" />
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td class="Required">
                            <asp:Label ID="LblTopic" runat="server" Text="Topic:" meta:resourcekey="LblTopicResource1"></asp:Label>
                        </td>
                        <td style="text-align: left;">
                            <asp:DropDownList ID="ddlTopic" runat="server" Enabled="False" SkinID="DdlWidth150"
                                AutoPostBack="True" OnSelectedIndexChanged="ddlTopic_SelectedIndexChanged" meta:resourcekey="ddlTopicResource1">
                                <asp:ListItem Text="-- Select --" meta:resourcekey="ListItemResource3"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RFVDdlTopic" runat="server" ControlToValidate="DdlTopic"
                                InitialValue="-- Select --" ErrorMessage="Please Select Topic." ValidationGroup="PnlBMS"
                                meta:resourcekey="RFVDdlTopicResource1">*</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <div id="DivTopicAdd" runat="server" visible="false">
                                <asp:TextBox ID="TxtToipcIndex" runat="server" Width="50px" meta:resourcekey="TxtToipcIndexResource1"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RFVTxtToipcIndex" runat="server" ControlToValidate="TxtToipcIndex"
                                    ErrorMessage="Please Enter Topic Index." ValidationGroup="TopicAdd" meta:resourcekey="RFVTxtToipcIndexResource1">*</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revTopicindex" runat="server" ControlToValidate="TxtToipcIndex"
                                    ErrorMessage="Please Enter Number Only" ValidationGroup="TopicAdd" ValidationExpression="[\d]{1,5}">*</asp:RegularExpressionValidator>
                                <asp:TextBox ID="TxtTopicName" runat="server" Width="120px" meta:resourcekey="TxtTopicNameResource1"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rqdTxtTopicName" runat="server" ControlToValidate="TxtTopicName"
                                    ErrorMessage="Please Enter Topic Name." ValidationGroup="TopicAdd" meta:resourcekey="rqdTxtTopicNameResource1">*</asp:RequiredFieldValidator>
                                <asp:Button runat="server" ID="BtnTopicAdd" Text="Add" CssClass="gobutton" OnClick="BtnTopicAdd_Click"
                                    ValidationGroup="TopicAdd" meta:resourcekey="BtnTopicAddResource1" />
                                <asp:ValidationSummary ID="vsTopicAdd" runat="server" ValidationGroup="TopicAdd"
                                    ShowMessageBox="True" ShowSummary="False" meta:resourcekey="vsTopicAddResource1" />
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td colspan="2" align="left">
                            <table>
                                <tr>
                                    <td>
                                        <asp:Button ID="BtnGenerate" Text="Generate" runat="server" CssClass="gobutton" ValidationGroup="PnlBMS"
                                            OnClick="BtnGenerate_Click" meta:resourcekey="BtnGenerateResource1" />
                                    </td>
                                    <td>
                                        <asp:Button ID="btnReset" runat="server" CssClass="gobutton" Text="Reset" CausesValidation="False"
                                            OnClick="btnReset_Click" meta:resourcekey="btnResetResource1" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">
                            <asp:ValidationSummary ID="VSPnlBMS" runat="server" ValidationGroup="PnlBMS" ShowMessageBox="True"
                                ShowSummary="False" meta:resourcekey="VSPnlBMSResource1" />
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
            </td>
        </tr>
    </table>
</asp:Content>
