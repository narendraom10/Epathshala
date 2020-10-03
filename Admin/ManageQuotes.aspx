<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Epathshala.master" AutoEventWireup="true"
    CodeFile="ManageQuotes.aspx.cs" Inherits="Admin_ManageQuotes" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="../Scripts/Jquery1.9.1.js" type="text/javascript"></script>
    <script type="text/javascript">
        var TotalChkBx;
        var Counter;

        Counter = 0;


        function SelectAll(CheckBox) {

            var TargetBaseControl = document.getElementById('<%= this.gvQuotes.ClientID %>');

            var TargetChildControl = "chkselect";
            var Inputs = TargetBaseControl.getElementsByTagName("input");
            for (var n = 0; n < Inputs.length; ++n)
                if (Inputs[n].type == 'checkbox')
                    Inputs[n].checked = CheckBox.checked;
            Counter = CheckBox.checked ? TotalChkBx : 0;
        }

        function ChildClick(CheckBox) {

            TotalChkBx = parseInt('<%= this.gvQuotes.Rows.Count %>');

            var HeaderCheckBox = document.getElementById('ctl00_ContentPlaceHolder1_grvSYS_Districtdetail_ctl01_chkHeaderchkSelect');
            if (CheckBox.checked && Counter < TotalChkBx)
                Counter++;
            else if (Counter > 0)
                Counter--;
            if (Counter < TotalChkBx)
                HeaderCheckBox.checked = false;
            else if (Counter == TotalChkBx)
                HeaderCheckBox.checked = true;
        }

    
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="0" cellspacing="0" class="RoundTop InnerTableStyle TableControl"
        width="90%">
        <tr>
            <td class="Header12 GridViewHeadercssTestAssessment RoundTop">
                <asp:Label ID="lblTitle" runat="server" Text="Manage Quotes"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <%--<table cellpadding="0" cellspacing="0" class="ActionBarTable">
                    <tr>
                        <td>
                            <table cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td>
                                        <asp:ImageButton ID="ibtnSearch" runat="server" ImageUrl="~/App_Themes/Images/ButtonBarView.png"
                                            ToolTip="Search" />
                                    </td>
                                    <td>
                                        <asp:ImageButton ID="ibtnRefresh" runat="server" ImageUrl="~/App_Themes/Images/ButtonBarRefresh.png"
                                            ToolTip="Refresh" />
                                    </td>
                                    <td>
                                        <asp:ImageButton ID="ibtnAdd" runat="server" ImageUrl="~/App_Themes/Images/ButtonBarAdd.png"
                                            ToolTip="Create Offers" />
                                    </td>
                                    <td>
                                        <asp:ImageButton ID="ibtnEdit" runat="server" ImageUrl="~/App_Themes/Images/ButtonBarEdit.png"
                                            ToolTip="Edit" />
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>--%>
                <%--<asp:UpdatePanel ID="upDetails" runat="server" UpdateMode="Always">--%>
                <%--<ContentTemplate>--%>
                <table id="tblGrid" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td class="panel">
                            <%--<asp:Panel ID="pnlSearch" runat="server" CssClass="inv" meta:resourcekey="pnlSearchResource1">
                                        <fieldset id="fsSearchInfo" runat="server" style="margin: 5px">
                                            <legend>
                                                <asp:Label ID="lblSearchTitle" runat="server" Text="Search" CssClass="SubTitle"></asp:Label>
                                            </legend>
                                            <table class="tblControl1">
                                            </table>
                                        </fieldset>
                                    </asp:Panel>--%>
                            <asp:Panel ID="pnlAdd" runat="server">
                                <fieldset id="fsAdd" runat="server" style="margin: 5px">
                                    <legend>
                                        <asp:Label ID="lblAddTitle" runat="server" Text="Add New Quote" CssClass="SubTitle"></asp:Label>
                                    </legend>
                                    <table cellpadding="4" cellspacing="4">
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label1" Text="Quote" runat="server" />
                                            </td>
                                            <td>
                                                :
                                            </td>
                                            <td style="text-align: left;">
                                                &nbsp;&nbsp;<asp:TextBox ID="txtQuoteText" MaxLength="1024" runat="server" TextMode="MultiLine"
                                                    Width="500" />
                                                <asp:RequiredFieldValidator ID="ReqQuoteText" runat="server" ErrorMessage="Quote Text field is required."
                                                    ControlToValidate="txtQuoteText" ValidationGroup="a">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label2" Text="By " runat="server" />
                                            </td>
                                            <td>
                                                :
                                            </td>
                                            <td style="text-align: left;">
                                                &nbsp;&nbsp;<asp:TextBox ID="txtbyWhom" runat="server" Width="500" />
                                                <asp:RequiredFieldValidator ID="ReqBywhom" runat="server" ErrorMessage="ByWhom field is Required"
                                                    ControlToValidate="txtbyWhom" ValidationGroup="a">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3">
                                                <asp:ValidationSummary ID="valSum_Offers" runat="server" ValidationGroup="a" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                                <asp:Button ID="btnSave" Text="Save" runat="server" ValidationGroup="a" OnClick="btnSave_Click" />
                                                &nbsp;
                                                <asp:Button ID="btnReset" Text="Reset" runat="server" OnClick="btnReset_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </fieldset>
                            </asp:Panel>
                            <asp:Panel ID="pnlEdit" runat="server" CssClass="InVisible">
                                <fieldset id="fsEmpStdSubEdit" runat="server" style="margin: 5px">
                                    <legend>
                                        <asp:Label ID="lblEditTitle" runat="server" Text="Edit" CssClass="SubTitle"></asp:Label>
                                    </legend>
                                    <table class="tblControl1">
                                    </table>
                                </fieldset>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:GridView ID="gvQuotes" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                DataKeyNames="QuoteId,ByWhom" CellPadding="4" Width="100%" AllowSorting="True"
                                OnPageIndexChanging="gvQuotes_PageIndexChanging" OnRowCancelingEdit="gvQuotes_RowCancelingEdit"
                                OnRowCreated="gvQuotes_RowCreated" OnRowDeleting="gvQuotes_RowDeleting" OnRowEditing="gvQuotes_RowEditing"
                                OnRowUpdating="gvQuotes_RowUpdating">
                                <Columns>
                                    <%-- <asp:TemplateField>
                                        <HeaderTemplate>
                                            <table>
                                                <tr>
                                                    <td align="center">
                                                        <asp:CheckBox ID="chkHeaderchkSelect" runat="server" onclick="javascript:SelectAll(this);" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <table>
                                                <tr>
                                                    <td align="center">
                                                        <asp:CheckBox ID="chkSelect" runat="server" onclick="javascript:ChildClick(this);" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="5px" />
                                    </asp:TemplateField>--%>
                                    <asp:TemplateField HeaderText="Sr.No">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex +1 %>
                                        </ItemTemplate>
                                        <ItemStyle Width="5px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="QuoteID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblQuoteID" Text='<%# Bind("QuoteId") %>' runat="server" />
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:Label ID="lblEditQuoteID" Text='<%# Bind("QuoteId") %>' runat="server" />
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Quote">
                                        <ItemTemplate>
                                            <asp:Label ID="lblQuoteText" Text='<%# Bind("QuoteText") %>' runat="server" />
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtEditQuoteText" TextMode="MultiLine" Width="500" Text='<%# Bind("QuoteText") %>'
                                                runat="server" />
                                            <asp:RequiredFieldValidator ID="reqEditQuoteText" runat="server" ErrorMessage="*"
                                                ControlToValidate="txtEditQuoteText" ValidationGroup="gv"></asp:RequiredFieldValidator>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="BY">
                                        <ItemTemplate>
                                            <asp:Label ID="lblByWhom" Text='<%# Bind("ByWhom") %>' runat="server" />
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtEditbyWhom" Text='<%# Bind("ByWhom") %>' runat="server" />
                                            <asp:RequiredFieldValidator ID="reqEditOfferlink" runat="server" ErrorMessage="*"
                                                ControlToValidate="txtEditbyWhom" ValidationGroup="gv"></asp:RequiredFieldValidator>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="EDIT" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="imgbtnEdit" Text="Edit" runat="server" CommandName="edit" OnClientClick="javascript:return confirm('Edit this record?')" />
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:LinkButton ID="imgbtnUpdate" Text="Update" runat="server" CommandName="update"
                                                ValidationGroup="gv" />
                                            <asp:LinkButton ID="imgbtnCancelupdate" Text="Cancel" runat="server" CommandName="cancel" />
                                        </EditItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="DELETE" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton1" Text="Delete" runat="server" OnClientClick="javascript:return confirm('Delete this record?')"
                                                CommandName="delete" />
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:TemplateField>
                                </Columns>
                                <PagerTemplate>
                                    <asp:ImageButton Text="First" CommandName="Page" CommandArgument="First" runat="server"
                                        ImageUrl="~/App_Themes/Images/first.png" ID="ibtnFirst" ToolTip="Move First Page" />
                                    <asp:ImageButton Text="Previous" CommandName="Page" CommandArgument="Prev" runat="server"
                                        ImageUrl="~/App_Themes/Images/previous.png" ID="ibtnPrevious" ToolTip="Move Previous Page" />
                                    <asp:Label ID="lblPage" runat="server" Text="Page" ForeColor="Black"></asp:Label>
                                    <asp:DropDownList ID="ddlPageSelector" runat="server" AutoPostBack="True" SkinID="DdlWidth50"
                                        OnSelectedIndexChanged="ddlPageSelector_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:ImageButton Text="Next" CommandName="Page" CommandArgument="Next" runat="server"
                                        ImageUrl="~/App_Themes/Images/NEXT.png" ID="ibtnNext" ToolTip="Move Next Page" />
                                    <asp:ImageButton Text="Last" CommandName="Page" CommandArgument="Last" runat="server"
                                        ImageUrl="~/App_Themes/Images/last.png" ID="ibtnLast" ToolTip="Move Last Page" />
                                </PagerTemplate>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
                <%-- <asp:TemplateField>
                                        <HeaderTemplate>
                                            <table>
                                                <tr>
                                                    <td align="center">
                                                        <asp:CheckBox ID="chkHeaderchkSelect" runat="server" onclick="javascript:SelectAll(this);" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <table>
                                                <tr>
                                                    <td align="center">
                                                        <asp:CheckBox ID="chkSelect" runat="server" onclick="javascript:ChildClick(this);" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="5px" />
                                    </asp:TemplateField>--%>
            </td>
        </tr>
    </table>
</asp:Content>
