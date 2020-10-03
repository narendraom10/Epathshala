<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EpathDemo.aspx.cs" Inherits="EpathDemo"
    MasterPageFile="~/MasterPage/LoginMasterPage.master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>ePathshala</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="upVideo" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <div id="dvfull" runat="server" style="width: 60%; text-align: center; margin: auto;">
                <div id="dvMainVideo" runat="server" style="width: 80%; text-align: center; float: left;
                    margin-top: 25px;">
                </div>
                <div id="dvList" runat="server" style="width: 10%; text-align: center; float: right;
                    margin-top: 25px;">
                    <asp:GridView ID="grvList" runat="server" AutoGenerateColumns="false" OnRowCommand="grvList_RowCommand"
                        ShowHeader="false">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnPlayVideo" runat="server" ImageUrl='<%# Eval("ImageURL") %>'
                                        Width="150px" AlternateText="Update PNG File" CommandArgument='<%# Eval("ValueURL") %>'
                                        CommandName="ShowVideo" ToolTip='<%# Eval("DiaplayName") %>' />
                                    <div style="text-align: center;">
                                        <%# Eval("DiaplayName") %>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
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
    </script>
</asp:Content>
