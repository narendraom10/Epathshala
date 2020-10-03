<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Epathshala.master" AutoEventWireup="true"
    CodeFile="District.aspx.cs" Inherits="Admin_District" Culture="auto" meta:resourcekey="PageResource2"
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

            var TargetBaseControl = document.getElementById('<%= this.grvSYS_Districtdetail.ClientID %>');

            var TargetChildControl = "chkselect";
            var Inputs = TargetBaseControl.getElementsByTagName("input");
            for (var n = 0; n < Inputs.length; ++n)
                if (Inputs[n].type == 'checkbox')
                    Inputs[n].checked = CheckBox.checked;
        Counter = CheckBox.checked ? TotalChkBx : 0;
    }

    function ChildClick(CheckBox) {

        TotalChkBx = parseInt('<%= this.grvSYS_Districtdetail.Rows.Count %>');

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
    <style type="text/css">
        .style1
        {
            width: 129px;
        }
        .gobutton
        {
            height: 26px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="0" cellspacing="0" class="RoundTop InnerTableStyle TableControl"
        width="90%">
        <tr>
            <td class="Header12 GridViewHeadercssTestAssessment RoundTop">
                <asp:Label ID="lblTitle" runat="server" Text="District" meta:resourcekey="lblTitleResource1"></asp:Label>
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
                                            ToolTip="Add District" meta:resourcekey="ibtnAddResource1" />
                                    </td>
                                    <td>
                                        <asp:ImageButton ID="ibtnEdit" runat="server" ImageUrl="~/App_Themes/Images/ButtonBarEdit.png"
                                            OnClick="ibtnEdit_Click" ToolTip="Edit" meta:resourcekey="ibtnEditResource1" />
                                    </td>
                                    <td>
                                        <asp:ImageButton ID="ibtnActiveDeactive" runat="server" ImageUrl="~/App_Themes/Images/ButtonBarActiveDeactive.png"
                                            ToolTip="Active/Deactive District" meta:resourcekey="ibtnActiveDeactiveResource1" />
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
                                                        <asp:Label ID="lblCountryIDSearch" runat="server" Text="Country:" meta:resourcekey="lblCountryIDSearchResource1"></asp:Label>
                                                    </td>
                                                    <td style="text-align: left;">
                                                        <asp:DropDownList ID="ddlCountryIDSearch" runat="server" OnSelectedIndexChanged="DdlCountryIDSearch_SelectedIndexChanged"
                                                            AutoPostBack="True" meta:resourcekey="ddlCountryIDSearchResource1">
                                                            <asp:ListItem Value="0" Text="-- Select --" meta:resourcekey="ListItemResource1"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblStateIDSearch" runat="server" Text="State:" meta:resourcekey="lblStateIDSearchResource1"></asp:Label>
                                                    </td>
                                                    <td style="text-align: left;">
                                                        <asp:DropDownList ID="ddlStateIDSearch" runat="server" meta:resourcekey="ddlStateIDSearchResource1">
                                                            <asp:ListItem Value="0" Text="-- Select --" meta:resourcekey="ListItemResource1"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblDistrictSearch" runat="server" Text="District:" meta:resourcekey="lblDistrictSearchResource1"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtDistrictSearch" runat="server" meta:resourcekey="txtDistrictSearchResource1"></asp:TextBox>
                                                    </td>
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
                                                    <td colspan="3" style="text-align: left;">
                                                        <asp:Button ID="btnSearch" ValidationGroup="aSearch" runat="server" Text="Go" AlternateText="Search"
                                                            OnClick="BtnSearch_Click" meta:resourcekey="btnSearchResource2" />
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
                                                        <asp:Label ID="lblCountryID" runat="server" Text="Country:" meta:resourcekey="lblCountryIDResource1"></asp:Label>
                                                    </td>
                                                    <td style="text-align: left;">
                                                        <asp:DropDownList ID="ddlCountryID" runat="server" OnSelectedIndexChanged="DdlCountryID_SelectedIndexChanged"
                                                            AutoPostBack="True" meta:resourcekey="ddlCountryIDResource1">
                                                            <asp:ListItem Value="0" Text="-- Select --" meta:resourcekey="ListItemResource2"></asp:ListItem>
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="ReqFieldCountryID" runat="server" ErrorMessage="Please Insert CountryID"
                                                            ValidationGroup="a" ControlToValidate="ddlCountryID" meta:resourcekey="ReqFieldCountryIDResource1">*</asp:RequiredFieldValidator>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblStateID" runat="server" Text="State:" meta:resourcekey="lblStateIDResource1"></asp:Label>
                                                    </td>
                                                    <td style="text-align: left;">
                                                        <asp:DropDownList ID="ddlStateID" runat="server" meta:resourcekey="ddlStateIDResource1">
                                                            <asp:ListItem Value="0" Text="-- Select --" meta:resourcekey="ListItemResource1"></asp:ListItem>
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="ReqFieldStateID" runat="server" ErrorMessage="Please Insert StateID"
                                                            ValidationGroup="a" ControlToValidate="ddlStateID" meta:resourcekey="ReqFieldStateIDResource1">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblDistrict" runat="server" Text="District:" meta:resourcekey="lblDistrictResource1"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtDistrict" runat="server" meta:resourcekey="txtDistrictResource1"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="ReqFieldDistrict" runat="server" ErrorMessage="Please Insert District"
                                                            ValidationGroup="a" ControlToValidate="txtDistrict" meta:resourcekey="ReqFieldDistrictResource1">*</asp:RequiredFieldValidator>
                                                    </td>
                                                    <td colspan="2" style="text-align: left;">
                                                        <asp:Button ID="btnSave" ValidationGroup="a" runat="server" Text="Save" AlternateText="Save"
                                                            OnClick="BtnSave_Click" meta:resourcekey="btnSaveResource1" />
                                                        <asp:Button ID="btnCancel" runat="server" Text="Reset" OnClick="BtnCancel_Click"
                                                            meta:resourcekey="btnCancelResource1" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4" align="center">
                                                        <asp:ValidationSummary ID="ValSumSYS_District" runat="server" ValidationGroup="a"
                                                            meta:resourcekey="ValSumSYS_DistrictResource1" />
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
                                                        <asp:Label ID="lblCountryIDEdit" runat="server" Text="Country:" meta:resourcekey="lblCountryIDEditResource1"></asp:Label>
                                                    </td>
                                                    <td style="text-align: left;">
                                                        <asp:DropDownList ID="ddlCountryIDEdit" runat="server" meta:resourcekey="ddlCountryIDEditResource1">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="ReqFieldCountryIDEdit" runat="server" ErrorMessage="Please Insert CountryID"
                                                            ValidationGroup="aEdit" ControlToValidate="ddlCountryIDEdit" meta:resourcekey="ReqFieldCountryIDEditResource1">*</asp:RequiredFieldValidator>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblStateIDEdit" runat="server" Text="State:" meta:resourcekey="lblStateIDEditResource1"></asp:Label>
                                                    </td>
                                                    <td style="text-align: left;">
                                                        <asp:DropDownList ID="ddlStateIDEdit" runat="server" meta:resourcekey="ddlStateIDEditResource1">
                                                            <asp:ListItem Value="0" Text="-- Select --" meta:resourcekey="ListItemResource1"></asp:ListItem>
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="ReqFieldStateIDEdit" runat="server" ErrorMessage="Please Insert StateID"
                                                            ValidationGroup="aEdit" ControlToValidate="ddlStateIDEdit" meta:resourcekey="ReqFieldStateIDEditResource1">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblDistrictEdit" runat="server" Text="District:" meta:resourcekey="lblDistrictEditResource1"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtDistrictEdit" runat="server" meta:resourcekey="txtDistrictEditResource1"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="ReqFieldDistrictEdit" runat="server" ErrorMessage="Please Insert District"
                                                            ValidationGroup="aEdit" ControlToValidate="txtDistrictEdit" meta:resourcekey="ReqFieldDistrictEditResource1">*</asp:RequiredFieldValidator>
                                                    </td>
                                                    <td colspan="2" style="text-align: left;">
                                                        <asp:Button ID="btnUpdate" ValidationGroup="aEdit" runat="server" Text="Update" AlternateText="Save"
                                                            OnClick="BtnUpdate_Click" meta:resourcekey="btnUpdateResource1" />
                                                        <asp:Button ID="btnCancelEdit" runat="server" Text="Cancel" OnClick="btnCancelEdit_Click"
                                                            meta:resourcekey="btnCancelEditResource1" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4" align="center">
                                                        <asp:ValidationSummary ID="ValSumSYS_DistrictEdit" runat="server" ValidationGroup="aEdit"
                                                            meta:resourcekey="ValSumSYS_DistrictEditResource1" />
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
                                                        <asp:Button ID="btnActDeactSub" runat="server" Text="Submit" OnClick="BtnActDeactSub_Click"
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
                                    <asp:GridView ID="grvSYS_Districtdetail" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                        CellPadding="4" DataKeyNames="DistrictID,StateID,CountryID,District,IsActive,CreatedOn,CreatedBy"
                                        OnPageIndexChanging="GrvSYS_Districtdetail_PageIndexChanging" OnSorting="GrvSYS_Districtdetail_Sorting"
                                        OnRowCreated="GrvSYS_Districtdetail_RowCreated" meta:resourcekey="grvSYS_DistrictdetailResource1">
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
                                            <asp:BoundField DataField="District" SortExpression="District" HeaderText="District"
                                                meta:resourcekey="BoundFieldResource1" />
                                            <asp:BoundField DataField="State" SortExpression="State" HeaderText="State" meta:resourcekey="BoundFieldResource2" />
                                            <asp:BoundField DataField="Country" SortExpression="Country" HeaderText="Country"
                                                meta:resourcekey="BoundFieldResource3" />
                                            <asp:BoundField DataField="CreatedOn" SortExpression="CreatedOn" HeaderText="CreatedOn"
                                                DataFormatString="{0: dd-MMM-yyyy hh:mm tt}" meta:resourcekey="BoundFieldResource5">
                                                <ItemStyle Width="25px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="CreatedBy" SortExpression="CreatedBy" HeaderText="CreatedBy"
                                                meta:resourcekey="BoundFieldResource6">
                                                <ItemStyle Width="10px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Active" SortExpression="Active" HeaderText="Active" meta:resourcekey="BoundFieldResource4">
                                                <ItemStyle Width="3px" />
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
                                            <asp:DropDownList ID="ddlPageSelector" OnSelectedIndexChanged="DdlPageSelector_SelectedIndexChanged"
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
