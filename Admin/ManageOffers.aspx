<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Epathshala.master" AutoEventWireup="true"
    CodeFile="ManageOffers.aspx.cs" Inherits="Admin_ManageOffers" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="../Scripts/Jquery1.9.1.js" type="text/javascript"></script>
    <script type="text/javascript">
        var TotalChkBx;
        var Counter;

        Counter = 0;


        function SelectAll(CheckBox) {

            var TargetBaseControl = document.getElementById('<%= this.gvOfferDetails.ClientID %>');

            var TargetChildControl = "chkselect";
            var Inputs = TargetBaseControl.getElementsByTagName("input");
            for (var n = 0; n < Inputs.length; ++n)
                if (Inputs[n].type == 'checkbox')
                    Inputs[n].checked = CheckBox.checked;
            Counter = CheckBox.checked ? TotalChkBx : 0;
        }

        function ChildClick(CheckBox) {

            TotalChkBx = parseInt('<%= this.gvOfferDetails.Rows.Count %>');

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

        //        function alphanumeric() {
        //            var x = document.getElementById('<%= txtValidity.ClientID %>');
        //            var letters = /^[0-9]+$/;
        //            if (x.value.match(letters)) {
        //                return true;
        //            }
        //            else {
        //                alert('User address must have alphanumeric characters only');
        //                uadd.focus();
        //                return false;
        //            }
        //        }  

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--<div class="sidepanel">
        <div class="activitydivside">
            <div class="ActivityHeader">
                Create Offers
            </div>
            <div class="ActivityContent">
                <div class="Control">
                    <asp:Label ID="Label1" Text="Offer Text" runat="server" />
                    <asp:TextBox runat="server" ID="txtOfferText" CssClass="textBoxCls" />
                </div>
                <div class="Control">
                    <asp:Label ID="Label2" Text="OfferLink" runat="server" />
                    <asp:TextBox runat="server" ID="TextBox1" CssClass="textBoxCls" />
                </div>
                <div class="Control">
                    <asp:Label ID="Label3" Text="Valid Days" runat="server" />
                    <asp:TextBox runat="server" ID="TextBox2" CssClass="textBoxCls" />
                </div>
                <div class="Control">
                    <asp:Button ID="btnCreateOffer" Text="Create" runat="server" />
                    <asp:Button ID="btnReset" Text="Reset" runat="server" />
                </div>
            </div>
        </div>
    </div>
    <div class="sidepanel1">
        <div class="activitydivside1">
            <div class="ActivityHeader">
                Manage Offers
            </div>
            <div class="ActivityContent">
                <div class="Control">
                    <asp:GridView runat="server" Width="100%" />
                </div>
            </div>
        </div>
    </div>--%>
    <table cellpadding="0" cellspacing="0" class="RoundTop InnerTableStyle TableControl"
        width="90%">
        <tr>
            <td class="Header12 GridViewHeadercssTestAssessment RoundTop">
                <asp:Label ID="lblTitle" runat="server" Text="Manage Offers"></asp:Label>
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
                                        <asp:Label ID="lblAddTitle" runat="server" Text="Add New Offer" CssClass="SubTitle"></asp:Label>
                                    </legend>
                                    <table cellpadding="4" cellspacing="4">
                                        <tr>
                                            <td>
                                                <asp:Label Text="Offer Text" runat="server" />
                                            </td>
                                            <td>
                                                :
                                            </td>
                                            <td style="text-align: left;">
                                                &nbsp;&nbsp;<asp:TextBox ID="txtOfferText" MaxLength="1024" runat="server" TextMode="MultiLine"
                                                    Width="500" />
                                                <asp:RequiredFieldValidator ID="ReqOfferText" runat="server" ErrorMessage="Offer Text Field is required."
                                                    ControlToValidate="txtOfferText" ValidationGroup="a">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label Text="Offer Link" runat="server" />
                                            </td>
                                            <td>
                                                :
                                            </td>
                                            <td style="text-align: left;">
                                                &nbsp;&nbsp;<asp:TextBox ID="txtOfferLink" runat="server" Width="500" />
                                                <asp:RequiredFieldValidator ID="ReqOfferLink" runat="server" ErrorMessage="Link is Required"
                                                    ControlToValidate="txtOfferLink" ValidationGroup="a">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label1" Text="Validity" runat="server" />
                                            </td>
                                            <td>
                                                :
                                            </td>
                                            <td style="text-align: left;">
                                                &nbsp;&nbsp;<asp:TextBox ID="txtValidity" runat="server" 
                                                    placeholder="Numbers only" MaxLength="3" />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Validity is required."
                                                    ControlToValidate="txtValidity" ValidationGroup="a">*</asp:RequiredFieldValidator>
                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterMode="ValidChars" TargetControlID="txtValidity"
                                                    ValidChars="0123456789">
                                                </cc1:FilteredTextBoxExtender>
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
                            <asp:GridView ID="gvOfferDetails" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                DataKeyNames="OfferCreatedDate,ValidDays,OfferExpireDate" CellPadding="4" Width="100%"
                                OnRowCancelingEdit="gvOfferDetails_RowCancelingEdit" OnRowEditing="gvOfferDetails_RowEditing"
                                OnRowDeleting="gvOfferDetails_RowDeleting" OnRowUpdating="gvOfferDetails_RowUpdating"
                                AllowSorting="True" OnPageIndexChanging="gvOfferDetails_PageIndexChanging" OnRowCreated="gvOfferDetails_RowCreated"
                                OnSorting="gvOfferDetails_Sorting">
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
                                    <asp:TemplateField HeaderText="OfferID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lbloffferID" Text='<%# Bind("OfferID") %>' runat="server" />
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:Label ID="lblEditoffferID" Text='<%# Bind("OfferID") %>' runat="server" />
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Offer Text">
                                        <ItemTemplate>
                                            <asp:Label ID="lblOfferText" Text='<%# Bind("OfferDisplayText") %>' runat="server" />
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtEditOfferText" TextMode="MultiLine" Width="500" Text='<%# Bind("OfferDisplayText") %>'
                                                runat="server" />
                                            <asp:RequiredFieldValidator ID="reqEditOfferText" runat="server" ErrorMessage="*"
                                                ControlToValidate="txtEditOfferText" ValidationGroup="gv"></asp:RequiredFieldValidator>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Offer Link">
                                        <ItemTemplate>
                                            <asp:Label ID="lblOfferlink" Text='<%# Bind("OfferLink") %>' runat="server" />
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtEditOfferLink" Text='<%# Bind("OfferLink") %>' runat="server" />
                                            <asp:RequiredFieldValidator ID="reqEditOfferlink" runat="server" ErrorMessage="*"
                                                ControlToValidate="txtEditOfferLink" ValidationGroup="gv"></asp:RequiredFieldValidator>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Created on" SortExpression="OfferCreatedDate" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCreatedon" Text='<%# Bind("OfferCreatedDate","{0:dd-MM-yyyy}") %>'
                                                runat="server" />
                                        </ItemTemplate>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Validity" SortExpression="ValidDays" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblvalidays" Text='<%# Bind("ValidDays") %>' runat="server" />
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtEditValidity" Text='<%# Bind("ValidDays") %>' runat="server"
                                                placeholder="Numbers Only" MaxLength="3" />
                                            <asp:RequiredFieldValidator ID="reqEditOffervalidity" runat="server" ErrorMessage="*"
                                                ControlToValidate="txtEditValidity" ValidationGroup="gv"></asp:RequiredFieldValidator>
                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterMode="ValidChars" TargetControlID="txtEditValidity"
                                                    ValidChars="0123456789">
                                                </cc1:FilteredTextBoxExtender>
                                        </EditItemTemplate>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Expiry Date" SortExpression="OfferExpireDate" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblExpirydate" Text='<%# Bind("OfferExpireDate","{0:dd-MM-yyyy}") %>'
                                                runat="server" />
                                        </ItemTemplate>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
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
                                            <asp:LinkButton Text="Delete" runat="server" OnClientClick="javascript:return confirm('Delete this record?')"
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
                <%--    </ContentTemplate>
                </asp:UpdatePanel>--%>
            </td>
        </tr>
    </table>
</asp:Content>
