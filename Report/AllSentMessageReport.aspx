<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Epathshala.master" AutoEventWireup="true"
    CodeFile="AllSentMessageReport.aspx.cs" Inherits="Report_AllSentMessageReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div style="width: 80%; margin: auto;">
                <div class="activitydivside1">
                    <div class="ActivityHeader">
                        List
                    </div>
                    <div class="ActivityContent">
                        <asp:GridView ID="GvUserList" runat="server" OnPageIndexChanging="GvUserList_PageIndexChanging"
                            AutoGenerateColumns="False" OnRowCreated="GvUserList_RowCreated">
                            <Columns>
                                <asp:BoundField DataField="FirstName" HeaderText="Student Name" ItemStyle-Width="10%" />
                                <asp:BoundField DataField="SentOnMobileNo" HeaderText="Mobile Number" ItemStyle-Width="15%" />
                                <asp:BoundField DataField="Message" HeaderText="Message" ItemStyle-Width="40%" />
                                <asp:BoundField DataField="IsSendSuccess" HeaderText="Sent" ItemStyle-Width="25%" />
                                <asp:BoundField DataField="CreatedOn" HeaderText="Sent On" ItemStyle-Width="10%" />
                            </Columns>
                            <PagerTemplate>
                                <asp:ImageButton Text="First" CommandName="Page" CommandArgument="First" runat="server"
                                    ImageUrl="~/App_Themes/Responsive/web/first.png" ID="ibtnFirst" ToolTip="Move First Page"
                                    meta:resourcekey="btnFirstResource1" CssClass="playbtn" />
                                <asp:ImageButton Text="Previous" CommandName="Page" CommandArgument="Prev" runat="server"
                                    ImageUrl="~/App_Themes/Responsive/web/previous.png" ID="ibtnPrevious" ToolTip="Move Previous Page"
                                    meta:resourcekey="btnPreviousResource1" CssClass="playbtn" />
                                <asp:Label ID="LblPage" runat="server" Text="Page" ForeColor="Black" meta:resourcekey="LblPageResource1"></asp:Label>
                                <asp:DropDownList ID="ddlPageSelector" OnSelectedIndexChanged="ddlPageSelector_SelectedIndexChanged"
                                    runat="server" AutoPostBack="True" SkinID="DdlWidth50" meta:resourcekey="ddlPageSelectorResource1">
                                </asp:DropDownList>
                                <asp:ImageButton Text="Next" CommandName="Page" CommandArgument="Next" runat="server"
                                    ImageUrl="~/App_Themes/Responsive/web/NEXT.png" ID="ibtnNext" ToolTip="Move Next Page"
                                    meta:resourcekey="btnNextResource1" CssClass="playbtn" />
                                <asp:ImageButton Text="Last" CommandName="Page" CommandArgument="Last" runat="server"
                                    ImageUrl="~/App_Themes/Responsive/web/last.png" ID="ibtnLast" ToolTip="Move Last Page"
                                    meta:resourcekey="btnLastResource1" CssClass="playbtn" />
                            </PagerTemplate>
                        </asp:GridView>
                    </div>
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
