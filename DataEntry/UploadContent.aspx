<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Epathshala.master" AutoEventWireup="true"
    CodeFile="UploadContent.aspx.cs" Inherits="DataEntry_UploadContent" %>

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
                <asp:UpdatePanel runat="server" ID="upMain" UpdateMode="Conditional">
                    <ContentTemplate>
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
                                </td>
                            </tr>
                            <tr>
                                <td class="Required">
                                    <asp:Label ID="LblTopic" runat="server" Text="Topic:" meta:resourcekey="LblTopicResource1"></asp:Label>
                                </td>
                                <td style="text-align: left;">
                                    <asp:DropDownList ID="ddlTopic" runat="server" Enabled="False" SkinID="DdlWidth150"
                                        meta:resourcekey="ddlTopicResource1">
                                        <asp:ListItem Text="-- Select --" meta:resourcekey="ListItemResource3"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RFVDdlTopic" runat="server" ControlToValidate="DdlTopic"
                                        InitialValue="-- Select --" ErrorMessage="Please Select Topic." ValidationGroup="PnlBMS"
                                        meta:resourcekey="RFVDdlTopicResource1">*</asp:RequiredFieldValidator>
                                </td>
                                <td>
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
                                                <asp:Button ID="BtnUploadContent" Text="Upload Content" runat="server" CssClass="gobutton"
                                                    ValidationGroup="PnlBMS" OnClick="BtnUploadContent_Click" />
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
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlBoard" />
                        <asp:AsyncPostBackTrigger ControlID="ddlSubject" />
                        <asp:AsyncPostBackTrigger ControlID="ddlChapter" />
                        <asp:AsyncPostBackTrigger ControlID="ddlTopic" />
                        <asp:PostBackTrigger ControlID="BtnUploadContent" />
                    </Triggers>
                </asp:UpdatePanel>
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
                    var Id = 0;
                    var MAX = 3;
                    var DivFiles = document.getElementById('MultipleFileUpload1_pnlFiles');
                    var DivListBox = document.getElementById('MultipleFileUpload1_pnlListBox');
                    var BtnAdd = document.getElementById('MultipleFileUpload1_btnAdd');
                    function Add() {
                        var IpFile = GetTopFile();
                        if (IpFile == null || IpFile.value == null || IpFile.value.length == 0) {
                            alert('Please select a file to add.');
                            return;
                        }
                        var NewIpFile = CreateFile();
                        DivFiles.insertBefore(NewIpFile, IpFile);
                        if (MAX != 0 && GetTotalFiles() - 1 == MAX) {
                            NewIpFile.disabled = true;
                            BtnAdd.disabled = true;
                        }
                        IpFile.style.display = 'none';
                        DivListBox.appendChild(CreateItem(IpFile));
                    }
                    function CreateFile() {
                        var IpFile = document.createElement('input');
                        IpFile.id = IpFile.name = 'IpFile_' + Id++;
                        IpFile.type = 'file';
                        return IpFile;
                    }
                    function CreateItem(IpFile) {
                        var Item = document.createElement('div');
                        Item.style.backgroundColor = '#ffffff';
                        Item.style.fontWeight = 'normal';
                        Item.style.textAlign = 'left';
                        Item.style.verticalAlign = 'middle';
                        Item.style.cursor = 'default';
                        Item.style.height = 20 + 'px';
                        var Splits = IpFile.value.split('\\');
                        Item.innerHTML = Splits[Splits.length - 1] + '&nbsp;';
                        Item.value = IpFile.id;
                        Item.title = IpFile.value;
                        var A = document.createElement('a');
                        A.innerHTML = 'Delete';
                        A.id = 'A_' + Id++;
                        A.href = '#';
                        A.style.color = 'blue';
                        A.onclick = function () {
                            DivFiles.removeChild(document.getElementById(this.parentNode.value));
                            DivListBox.removeChild(this.parentNode);
                            if (MAX != 0 && GetTotalFiles() - 1 < MAX) {
                                GetTopFile().disabled = false;
                                BtnAdd.disabled = false;
                            }
                        }
                        Item.appendChild(A);
                        Item.onmouseover = function () {
                            Item.bgColor = Item.style.backgroundColor;
                            Item.fColor = Item.style.color;
                            Item.style.backgroundColor = '#C6790B';
                            Item.style.color = '#ffffff';
                            Item.style.fontWeight = 'bold';
                        }
                        Item.onmouseout = function () {
                            Item.style.backgroundColor = Item.bgColor;
                            Item.style.color = Item.fColor;
                            Item.style.fontWeight = 'normal';
                        }
                        return Item;
                    }
                    function Clear() {
                        DivListBox.innerHTML = '';
                        DivFiles.innerHTML = '';
                        DivFiles.appendChild(CreateFile());
                        BtnAdd.disabled = false;
                    }
                    function GetTopFile() {
                        var Inputs = DivFiles.getElementsByTagName('input');
                        var IpFile = null;
                        for (var n = 0; n < Inputs.length && Inputs[n].type == 'file'; ++n) {
                            IpFile = Inputs[n];
                            break;
                        }
                        return IpFile;
                    }
                    function GetTotalFiles() {
                        var Inputs = DivFiles.getElementsByTagName('input');
                        var Counter = 0;
                        for (var n = 0; n < Inputs.length && Inputs[n].type == 'file'; ++n)
                            Counter++;
                        return Counter;
                    }
                    function GetTotalItems() {
                        var Items = DivListBox.getElementsByTagName('div');
                        return Items.length;
                    }
                    function DisableTop() {
                        if (GetTotalItems() == 0) {
                            alert('Please browse at least one file to upload.');
                            return false;
                        }
                        GetTopFile().disabled = true;
                        return true;
                    }

                </script>
            </td>
        </tr>
    </table>
</asp:Content>
