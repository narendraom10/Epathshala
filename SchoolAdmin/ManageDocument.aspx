<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Epathshala.master" AutoEventWireup="true"
    CodeFile="ManageDocument.aspx.cs" Inherits="SchoolAdmin_ManageDocument" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div style="width: 80%; margin: auto;">
                <div id="Div1" class="activitydivside1" runat="server" style="margin-bottom: 30px;">
                    <div class="ActivityHeader">
                        <asp:Label ID="lbltitle" runat="server" Text="Manage Documents"></asp:Label>
                        <a href="AddDocument.aspx" id="aaddupdate" runat="server" style="float: right; padding-right: 20px;">
                            Add Document</a>
                    </div>
                    <div class="ActivityContent">
                        <asp:GridView ID="gvdocument" runat="server" AutoGenerateColumns="False" SkinID="NoPaging"
                            OnRowCommand="gvdocument_RowCommand">
                            <Columns>
                                <asp:TemplateField HeaderText="SNo.">
                                    <ItemTemplate>
                                        <asp:Label ID="GV_LblSRNO" runat="server" Text='<%# Container.DataItemIndex+1 %>' />
                                    </ItemTemplate>
                                    <ItemStyle CssClass="GridViewRows" Width="10%" HorizontalAlign="Center" VerticalAlign="Top" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Document">
                                    <ItemTemplate>
                                        <asp:Label ID="GV_LblDocumentName" runat="server" Text='<%#Eval("title") %>' /></ItemTemplate>
                                    <ItemStyle CssClass="GridViewRows" Width="60%" HorizontalAlign="Left" VerticalAlign="Top" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Edit">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LnkEdit" Text="Edit" runat="server" CommandArgument='<%#Eval("title") %>'
                                            CommandName="documentedit"> </asp:LinkButton></ItemTemplate>
                                    <ItemStyle CssClass="GridViewRows" Width="10%" HorizontalAlign="Center" VerticalAlign="Top" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="View">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkview" Text="View" runat="server" CommandArgument='<%#Eval("title") %>'
                                            CommandName="documentview"> </asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle CssClass="GridViewRows" Width="10%" HorizontalAlign="Center" VerticalAlign="Top" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Delete">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkDelete" Text="Delete" runat="server" CommandArgument='<%#Eval("title") %>'
                                            CommandName="documentdelete" OnClientClick="javascript:return showDeletedocument();"> </asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle CssClass="GridViewRows" Width="10%" HorizontalAlign="Center" VerticalAlign="Top" />
                                </asp:TemplateField>
                            </Columns>
                            <EmptyDataTemplate>
                                <div style="text-align: center; color: black">
                                    No Document Found</div>
                            </EmptyDataTemplate>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
        </Triggers>
    </asp:UpdatePanel>
    <!-- LoaderPart start-->
    <asp:Button ID="btnLoader" runat="server" Style="display: none" />
    <asp:Button ID="btnCancel" runat="server" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender ID="ModalPopup" runat="server" PopupControlID="dvPopup"
        CancelControlID="btnCancel" TargetControlID="btnLoader" BackgroundCssClass="modalBackground"
        Enabled="True">
    </ajaxToolkit:ModalPopupExtender>
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
    <!-- LoaderPart end-->
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
        function showDeletedocument() {
            if (confirm('Are you sure you want to delete this document?')) {
                return true;
            } else {
                return false;
            }
        }

    </script>
</asp:Content>
