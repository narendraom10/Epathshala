<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Epathshala.master" AutoEventWireup="true"
    CodeFile="SchoolType.aspx.cs" Inherits="Admin_SchoolType" Culture="auto" meta:resourcekey="PageResource2"
    UICulture="auto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="../Scripts/Jquery1.9.1.js" type="text/javascript"></script>
    <script type="text/javascript">        $(document).ready(function () {
            $("#<%= ibtnSearch.ClientID%>").click(function () {
                if ($("#<%= pnlSearch.ClientID%>").is(':visible')) {
                    $("#<%= pnlSearch.ClientID%>").removeClass("Visible").addClass("InVisible");
                    $("#<%= pnlAdd.ClientID%>").removeClass("Visible").addClass("InVisible");
                    $("#<%= pnlEdit.ClientID%>").removeClass("Visible").addClass("InVisible");
                    $("#<%= pnlActDeact.ClientID%>").removeClass("Visible").addClass("InVisible");
                }
                else {
                    $("#<%= pnlSearch.ClientID%>").removeClass("InVisible").addClass("Visible");
                    $("#<%= pnlAdd.ClientID%>").removeClass("Visible").addClass("InVisible");
                    $("#<%= pnlEdit.ClientID%>").removeClass("Visible").addClass("InVisible");
                    $("#<%= pnlActDeact.ClientID%>").removeClass("Visible").addClass("InVisible");
                }
                return false;
            });

            $("#<%= ibtnAdd.ClientID%>").click(function () {
                if ($("#<%= pnlAdd.ClientID%>").is(':visible')) {
                    $("#<%= pnlAdd.ClientID%>").removeClass("Visible").addClass("InVisible");
                    $("#<%= pnlSearch.ClientID%>").removeClass("InVisible").addClass("Visible");
                    $("#<%= pnlEdit.ClientID%>").removeClass("Visible").addClass("InVisible");
                    $("#<%= pnlActDeact.ClientID%>").removeClass("Visible").addClass("InVisible");
                }
                else {
                    $("#<%= pnlAdd.ClientID%>").removeClass("InVisible").addClass("Visible");
                    $("#<%= pnlSearch.ClientID%>").removeClass("Visible").addClass("InVisible");
                    $("#<%= pnlEdit.ClientID%>").removeClass("Visible").addClass("InVisible");
                    $("#<%= pnlActDeact.ClientID%>").removeClass("Visible").addClass("InVisible");
                }
                return false;
            });
            $("#<%= ibtnActiveDeactive.ClientID%>").click(function () {
                if ($("#<%= pnlAdd.ClientID%>").is(':visible')) {
                    $("#<%= pnlAdd.ClientID%>").removeClass("Visible").addClass("InVisible");
                    $("#<%= pnlSearch.ClientID%>").removeClass("InVisible").addClass("Visible");
                    $("#<%= pnlEdit.ClientID%>").removeClass("Visible").addClass("InVisible");
                    $("#<%= pnlActDeact.ClientID%>").removeClass("Visible").addClass("InVisible");
                }
                else {
                    $("#<%= pnlActDeact.ClientID%>").removeClass("InVisible").addClass("Visible");
                    $("#<%= pnlAdd.ClientID%>").removeClass("Visible").addClass("InVisible");
                    $("#<%= pnlSearch.ClientID%>").removeClass("Visible").addClass("InVisible");
                    $("#<%= pnlEdit.ClientID%>").removeClass("Visible").addClass("InVisible");
                }
                return false;
            });
        });   
    </script>
    <script type="text/javascript">
        var TotalChkBx;
        var Counter;

        Counter = 0;


        function SelectAll(CheckBox) {

            var TargetBaseControl = document.getElementById('<%= this.grvSYS_SchoolTypedetail.ClientID %>');

            var TargetChildControl = "chkselect";
            var Inputs = TargetBaseControl.getElementsByTagName("input");
            for (var n = 0; n < Inputs.length; ++n)
                if (Inputs[n].type == 'checkbox')
                    Inputs[n].checked = CheckBox.checked;
            Counter = CheckBox.checked ? TotalChkBx : 0;
        }

        function ChildClick(CheckBox) {

            TotalChkBx = parseInt('<%= this.grvSYS_SchoolTypedetail.Rows.Count %>');

            var HeaderCheckBox = document.getElementById('ctl00_ContentPlaceHolder1_grvSYS_SchoolTypedetail_ctl01_chkHeaderchkSelect');
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
                <asp:Label ID="lblTitle" runat="server" Text="SchoolType" meta:resourcekey="lblTitleResource1"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <table cellpadding="0" cellspacing="0" class="ActionBarTable">
                    <tr>
                        <td>
                            <table cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td>
                                        <asp:ImageButton ID="ibtnSearch" runat="server" ImageUrl="~/App_Themes/Images/ButtonBarView.png"
                                            ToolTip="Search" meta:resourcekey="ibtnSearchResource1" />
                                    </td>
                                    <td>
                                        <asp:ImageButton ID="ibtnRefresh" runat="server" ImageUrl="~/App_Themes/Images/ButtonBarRefresh.png"
                                            OnClick="ibtnRefresh_Click" ToolTip="Refresh" meta:resourcekey="ibtnRefreshResource1" />
                                    </td>
                                    <td>
                                        <asp:ImageButton ID="ibtnAdd" runat="server" ImageUrl="~/App_Themes/Images/ButtonBarAdd.png"
                                            ToolTip="Add School Type" meta:resourcekey="ibtnAddResource1" />
                                    </td>
                                    <td>
                                        <asp:ImageButton ID="ibtnEdit" runat="server" ImageUrl="~/App_Themes/Images/ButtonBarEdit.png"
                                            OnClick="ibtnEdit_Click" ToolTip="Edit" meta:resourcekey="ibtnEditResource1" />
                                    </td>
                                    <td>
                                        <asp:ImageButton ID="ibtnActiveDeactive" runat="server" ImageUrl="~/App_Themes/Images/ButtonBarActiveDeactive.png"
                                            ToolTip="Active/Deactive SchoolType" meta:resourcekey="ibtnActiveDeactiveResource1" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <asp:UpdatePanel ID="upDetails" runat="server">
                    <ContentTemplate>
                        <table id="tblGrid" cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td class="panel">
                                    <asp:Panel ID="pnlSearch" runat="server" CssClass="Visible" meta:resourcekey="pnlSearchResource1">
                                        <fieldset id="fsSearchInfo" runat="server" style="margin: 5px">
                                            <legend>
                                                <asp:Label ID="lblSearchTitle" runat="server" Text="Search" CssClass="SubTitle" meta:resourcekey="lblSearchTitleResource1"></asp:Label>
                                            </legend>
                                            <table class="tblControl1">
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblTypeSearch" runat="server" Text="Type:" meta:resourcekey="lblTypeSearchResource1"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtTypeSearch" runat="server" meta:resourcekey="txtTypeSearchResource1"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblActive" runat="server" Text="Active:" meta:resourceKey="lblActiveResource1"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:RadioButtonList ID="rlstActive" runat="server" RepeatDirection="Horizontal">
                                                            <asp:ListItem Value="1" Text="Yes" meta:resourceKey="lblActiveListItemResource1"></asp:ListItem>
                                                            <asp:ListItem Value="0" Text="No" meta:resourceKey="lblActiveListItemResource2"></asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td style="text-align: left;">
                                                        <asp:Button ID="btnSearch" ValidationGroup="aSearch" runat="server" Text="Go" AlternateText="Search"
                                                            OnClick="btnSearch_Click" meta:resourcekey="btnSearchResource2" />
                                                        <asp:Button ID="btnSearchReset" runat="server" meta:resourcekey="btnCancelResource1"
                                                            Text="Reset" OnClick="btnSearchReset_Click" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </fieldset>
                                    </asp:Panel>
                                    <asp:Panel ID="pnlAdd" runat="server" CssClass="InVisible" meta:resourcekey="pnlAddResource1">
                                        <fieldset id="fsAdd" runat="server" style="margin: 5px">
                                            <legend>
                                                <asp:Label ID="lblAddTitle" runat="server" Text="Add" CssClass="SubTitle" meta:resourcekey="lblAddTitleResource1"></asp:Label>
                                            </legend>
                                            <table class="tblControl1">
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblType" runat="server" Text="Type:" meta:resourcekey="lblTypeResource1"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtType" runat="server" meta:resourcekey="txtTypeResource1"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="ReqFieldType" runat="server" ErrorMessage="Please Insert Type"
                                                            ValidationGroup="a" ControlToValidate="txtType" meta:resourcekey="ReqFieldTypeResource1">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td style="text-align: left;">
                                                        <asp:Button ID="btnSave" ValidationGroup="a" runat="server" Text="Save" AlternateText="Save"
                                                            OnClick="btnSave_Click" meta:resourcekey="btnSaveResource1" />
                                                        <asp:Button ID="btnCancel" runat="server" Text="Reset" OnClick="btnCancel_Click"
                                                            meta:resourcekey="btnCancelResource1" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="s" align="center">
                                                        <asp:ValidationSummary ID="ValSumSYS_SchoolType" runat="server" ValidationGroup="a"
                                                            meta:resourcekey="ValSumSYS_SchoolTypeResource1" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </fieldset>
                                    </asp:Panel>
                                    <asp:Panel ID="pnlEdit" runat="server" CssClass="InVisible" meta:resourcekey="pnlEditResource1">
                                        <fieldset id="fsEmpStdSubEdit" runat="server" style="margin: 5px">
                                            <legend>
                                                <asp:Label ID="lblEditTitle" runat="server" Text="Edit" CssClass="SubTitle" meta:resourcekey="lblEditTitleResource1"></asp:Label>
                                            </legend>
                                            <table class="tblControl1">
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblTypeEdit" runat="server" Text="Type:" meta:resourcekey="lblTypeEditResource1"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtTypeEdit" runat="server" meta:resourcekey="txtTypeEditResource1"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="ReqFieldTypeEdit" runat="server" ErrorMessage="Please Insert Type"
                                                            ValidationGroup="aEdit" ControlToValidate="txtTypeEdit" meta:resourcekey="ReqFieldTypeEditResource1">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        <asp:Button ID="btnUpdate" ValidationGroup="aEdit" runat="server" Text="Update" AlternateText="Save"
                                                            OnClick="btnUpdate_Click" meta:resourcekey="btnUpdateResource1" />
                                                        <asp:Button ID="btnCancelEdit" runat="server" Text="Cancel" OnClick="btnCancelEdit_Click"
                                                            meta:resourcekey="btnCancelEditResource1" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" align="center">
                                                        <asp:ValidationSummary ID="ValSumSYS_SchoolTypeEdit" runat="server" ValidationGroup="aEdit"
                                                            meta:resourcekey="ValSumSYS_SchoolTypeEditResource1" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </fieldset>
                                    </asp:Panel>
                                    <asp:Panel ID="pnlActDeact" runat="server" CssClass="InVisible" meta:resourcekey="pnlActDeactResource1">
                                        <fieldset id="fsActDeact" runat="server" style="margin: 5px">
                                            <legend>
                                                <asp:Label ID="lblActDeactTitle" runat="server" Text="Active/Deactive " meta:resourcekey="lblActDeactTitleResource1"></asp:Label>
                                            </legend>
                                            <table cellspacing="1" style="margin: 5px" class="tblControl1">
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblPnlActDeactTitle" runat="server" Text="Please Select Action:" meta:resourcekey="lblPnlActDeactTitleResource1"></asp:Label>
                                                        <asp:RadioButton ID="rbActive" runat="server" Text=" Active" GroupName="ActDeact"
                                                            Checked="True" meta:resourcekey="rbActiveResource1" />
                                                        <asp:RadioButton ID="rbDeactive" runat="server" Text=" Deactive" GroupName="ActDeact"
                                                            meta:resourcekey="rbDeactiveResource1" />
                                                    </td>
                                                    <td>
                                                        <asp:Button ID="btnActDeactSub" runat="server" Text="Submit" OnClick="btnActDeactSub_Click"
                                                            meta:resourcekey="btnActDeactSubResource1" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </fieldset>
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:GridView ID="grvSYS_SchoolTypedetail" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                        CellPadding="4" DataKeyNames="SchoolTypeID,Type,IsActive,CreatedOn,CreatedBy"
                                        OnPageIndexChanging="grvSYS_SchoolTypedetail_PageIndexChanging" OnSorting="grvSYS_SchoolTypedetail_Sorting"
                                        OnRowCreated="grvSYS_SchoolTypedetail_RowCreated" meta:resourcekey="grvSYS_SchoolTypedetailResource1">
                                        <Columns>
                                            <asp:TemplateField meta:resourcekey="TemplateFieldResource1">
                                                <HeaderTemplate>
                                                    <table>
                                                        <tr>
                                                            <td align="center">
                                                                <asp:CheckBox ID="chkHeaderchkSelect" runat="server" onclick="javascript:SelectAll(this);"
                                                                    meta:resourcekey="chkHeaderchkSelectResource1" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <table>
                                                        <tr>
                                                            <td align="center">
                                                                <asp:CheckBox ID="chkSelect" runat="server" onclick="javascript:ChildClick(this);"
                                                                    meta:resourcekey="chkSelectResource1" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" Width="5px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Sr. No" meta:resourcekey="TemplateFieldResource2">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex +1 %></ItemTemplate>
                                                <ItemStyle Width="5px" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="Type" SortExpression="Type" HeaderText="Type" meta:resourcekey="BoundFieldResource1" />
                                            <asp:BoundField DataField="CreatedOn" SortExpression="CreatedOn" HeaderText="CreatedOn"
                                                DataFormatString="{0: dd-MMM-yyyy hh:mm tt}" meta:resourcekey="BoundFieldResource3">
                                                <ItemStyle Width="25px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="CreatedBy" SortExpression="CreatedBy" HeaderText="CreatedBy"
                                                meta:resourcekey="BoundFieldResource4">
                                                <ItemStyle Width="20px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Active" SortExpression="Active" HeaderText="Active" meta:resourcekey="BoundFieldResource2">
                                                <ItemStyle Width="5px" />
                                            </asp:BoundField>
                                        </Columns>
                                        <PagerTemplate>
                                            <asp:ImageButton Text="First" CommandName="Page" CommandArgument="First" runat="server"
                                                ImageUrl="~/App_Themes/Images/first.png" ID="ibtnFirst" ToolTip="Move First Page"
                                                meta:resourcekey="ibtnFirstResource1" />
                                            <asp:ImageButton Text="Previous" CommandName="Page" CommandArgument="Prev" runat="server"
                                                ImageUrl="~/App_Themes/Images/previous.png" ID="ibtnPrevious" ToolTip="Move Previous Page"
                                                meta:resourcekey="ibtnPreviousResource1" />
                                            <asp:Label ID="lblPage" runat="server" Text="Page" ForeColor="Black" meta:resourcekey="lblPageResource1"></asp:Label>
                                            <asp:DropDownList ID="ddlPageSelector" OnSelectedIndexChanged="ddlPageSelector_SelectedIndexChanged"
                                                runat="server" AutoPostBack="True" SkinID="DdlWidth50" meta:resourcekey="ddlPageSelectorResource1">
                                            </asp:DropDownList>
                                            <asp:ImageButton Text="Next" CommandName="Page" CommandArgument="Next" runat="server"
                                                ImageUrl="~/App_Themes/Images/NEXT.png" ID="ibtnNext" ToolTip="Move Next Page"
                                                meta:resourcekey="ibtnNextResource1" />
                                            <asp:ImageButton Text="Last" CommandName="Page" CommandArgument="Last" runat="server"
                                                ImageUrl="~/App_Themes/Images/last.png" ID="ibtnLast" ToolTip="Move Last Page"
                                                meta:resourcekey="ibtnLastResource1" />
                                        </PagerTemplate>
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
