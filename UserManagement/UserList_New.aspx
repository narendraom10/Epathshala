<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Epathshala.master" AutoEventWireup="true"
    CodeFile="UserList_New.aspx.cs" Inherits="UserManage_UserList" Culture="auto"
    meta:resourcekey="PageResource2" UICulture="auto" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="../Scripts/Jquery1.9.1.js" type="text/javascript"></script>
    <%--  <script type="text/javascript">        $(document).ready(function () {
            $("#<%= ImgBtnSearch.ClientID%>").click(function () {
                if ($("#<%= PnlSearch.ClientID%>").is(':visible')) {
                    $("#<%= PnlSearch.ClientID%>").removeClass("Visible").addClass("InVisible");
                    $("#<%= PnlActivateDeactivate.ClientID%>").removeClass("Visible").addClass("InVisible");
                }
                else {
                    $("#<%= PnlSearch.ClientID%>").removeClass("InVisible").addClass("Visible");
                    $("#<%= PnlActivateDeactivate.ClientID%>").removeClass("Visible").addClass("InVisible");
                }
                return false;
            });

            $("#<%= ImgBtnActivate.ClientID%>").click(function () {
                if ($("#<%= PnlActivateDeactivate.ClientID%>").is(':visible')) {
                    $("#<%= PnlSearch.ClientID%>").removeClass("InVisible").addClass("Visible");
                    $("#<%= PnlActivateDeactivate.ClientID%>").removeClass("Visible").addClass("InVisible");
                }
                else {
                    $("#<%= PnlActivateDeactivate.ClientID%>").removeClass("InVisible").addClass("Visible");
                    $("#<%= PnlSearch.ClientID%>").removeClass("Visible").addClass("InVisible");
                }
                return false;
            });
        });   
    </script>--%>
    <script type="text/javascript">
        function SelectAllCheckboxes(chk) {
            $("#ctl00_ContentPlaceHolder1_GvUserList input:checkbox").attr("checked", function () {
                if (this != chk) {
                    this.checked = chk.checked;

                }
            });
        }

    </script>
    <style type="text/css">
        .gobutton
        {
            height: 26px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="up1" runat="server" class="tblDashboard">
        <ContentTemplate>
            <div class="sidepanel">
                <div class="activitydivside">
                    <div class="ActivityHeader">
                        <asp:Label ID="LblPageTitle" runat="server" Text="User Details" meta:resourcekey="LblPageTitleResource1"></asp:Label>
                    </div>
                    <div>
                        <ul class="standarbtn">
                            <li class="standarbar">
                                <asp:ImageButton ID="ImgBtnSearch" runat="server" ImageUrl="~/App_Themes/Responsive/web/searchuser.png"
                                    ToolTip="Search" meta:resourcekey="ImgBtnSearchResource1" OnClick="ImgBtnSearch_Click" />
                            </li>
                            <li class="standarbar">
                                <asp:ImageButton ID="ImgBtnRefresh" runat="server" ImageUrl="~/App_Themes/Responsive/web/rectreload.png"
                                    OnClick="ImgBtnRefresh_Click" ToolTip="Refresh" meta:resourcekey="ImgBtnRefreshResource1" />
                            </li>
                            <li class="standarbar">
                                <asp:ImageButton ID="ibtnAdd" runat="server" ImageUrl="~/App_Themes/Responsive/web/plus.png"
                                    ToolTip="Add Employee" meta:resourcekey="ibtnAddResource1" OnClick="ibtnAdd_Click"
                                    Visible="false" />
                            </li>
                            <li class="standarbar">
                                <asp:ImageButton ID="ibtnEdit" runat="server" ImageUrl="~/App_Themes/Responsive/web/edit.png"
                                    ToolTip="Edit Employee" OnClick="ibtnEdit_Click" meta:resourcekey="ibtnEditResource1"
                                    OnClientClick="javascript:return selectmessage()" Visible="false" />
                            </li>
                            <li class="standarbar">
                                <asp:ImageButton ID="ImgBtnActivate" runat="server" ImageUrl="~/App_Themes/Responsive/web/activeuser.png"
                                    OnClick="ImgBtnActivate_Click" ToolTip="Active/Deactive Users" meta:resourcekey="ImgBtnActivateResource1" />
                            </li>
                            <li class="standarbar">
                                <asp:ImageButton ID="ImgBtnResetPassword" runat="server" ImageUrl="~/App_Themes/Responsive/web/resetpw.png"
                                    OnClick="ImgBtnResetPassword_Click" ToolTip="Reset Password" meta:resourcekey="ImgBtnResetPasswordResource1" />
                            </li>
                        </ul>
                    </div>
                    <div id="PnlSearch" runat="server" meta:resourcekey="PnlSearchResource1" visible="false">
                        <div class="subheaduserdetail" id="LblFLSearch" runat="server" meta:resourcekey="LblFLSearchResource1">
                            Search</div>
                        <div class="ActivityContent">
                            <div>
                                <asp:Label ID="LblSchoolName" runat="server" Text="School Name:" CssClass="textlabel"
                                    meta:resourceKey="LblSchoolNameResource1"></asp:Label></div>
                            <div>
                                <asp:Literal ID="LtSchoolID" runat="server" Visible="False" meta:resourceKey="LtSchoolIDResource1"></asp:Literal>
                                <asp:DropDownList ID="ddlSchool" Enabled="false" runat="server" AutoPostBack="True"
                                    OnSelectedIndexChanged="ddlSchool_SelectedIndexChanged">
                                    <asp:ListItem Text="-- Select --" Value="0" meta:resourceKey="ListItemResource1"></asp:ListItem>
                                </asp:DropDownList>
                                <%--<asp:TextBox ID="TxtSchoolName" runat="server" meta:resourceKey="TxtSchoolNameResource1"
                                    Enabled="false" OnTextChanged="TxtSchoolName_TextChanged" CssClass="text"></asp:TextBox>
                                <cc1:AutoCompleteExtender ID="TxtSchName_AutoCompleteExtender" runat="server" DelimiterCharacters=""
                                    Enabled="True" ServiceMethod="GetSchoolName" ServicePath="" MinimumPrefixLength="1"
                                    TargetControlID="TxtSchoolName" UseContextKey="True" CompletionInterval="100"
                                    FirstRowSelected="True">
                                </cc1:AutoCompleteExtender>--%>
                            </div>
                            <div>
                                <asp:Label ID="LblRole" runat="server" Text="Role:" CssClass="textlabel" meta:resourceKey="LblRoleResource1"></asp:Label>
                                <asp:DropDownList ID="DdlRole" runat="server" OnSelectedIndexChanged="DdlRole_SelectedIndexChanged"
                                    AutoPostBack="True" meta:resourceKey="DdlRoleResource1">
                                    <asp:ListItem Text="-- Select --" Value="0" meta:resourceKey="ListItemResource1"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div>
                                <asp:Label ID="LblStandard" runat="server" Text="Standard:" CssClass="textlabel"
                                    meta:resourceKey="LblStandardResource1"></asp:Label>
                                <asp:DropDownList ID="DdlStandard" runat="server" Style="width: 140px;" OnSelectedIndexChanged="DdlStandard_SelectedIndexChanged"
                                    AutoPostBack="True" Enabled="false" SkinID="DdlWidth150" meta:resourceKey="DdlStandardResource1">
                                    <asp:ListItem Text="-- Select --" Value="0" meta:resourceKey="ListItemResource2"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div>
                                <asp:Label ID="LblDivision" runat="server" Text="Division:" CssClass="textlabel"
                                    meta:resourceKey="LblDivisionResource1"></asp:Label>
                                <asp:DropDownList ID="DdlDivision" runat="server" AutoPostBack="True" Enabled="false"
                                    meta:resourceKey="DdlDivisionResource1">
                                    <asp:ListItem Text="-- Select --" Value="0" meta:resourceKey="ListItemResource3"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div>
                                <asp:Label ID="lblActive" runat="server" Text="Active:" CssClass="textlabel" meta:resourceKey="lblActiveResource1"></asp:Label>
                                <asp:RadioButtonList ID="rlstActive" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="1" Text="Yes" meta:resourceKey="lblActiveListItemResource1"></asp:ListItem>
                                    <asp:ListItem Value="0" Text="No" meta:resourceKey="lblActiveListItemResource2"></asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                            <div class="gobotton">
                                <asp:Button ID="BtnGo" runat="server" Text="Go" OnClick="BtnGo_Click" CssClass="gobutton"
                                    ValidationGroup="VGSearch" meta:resourceKey="BtnGoResource1" />
                                <asp:Button ID="BtnReset" runat="server" Text="Reset" OnClick="BtnReset_Click" CssClass="gobutton"
                                    meta:resourceKey="BtnResetResource1" />
                                <asp:ValidationSummary ID="VsSearch" ValidationGroup="VGSearch" ShowMessageBox="True"
                                    ShowSummary="False" runat="server" meta:resourceKey="VsSearchResource1" />
                            </div>
                        </div>
                    </div>
                    <div id="PnlActivateDeactivate" runat="server" visible="false" meta:resourcekey="PnlActivateDeactivateResource1">
                        <div class="subheaduserdetail" id="LblFlActDect" runat="server" cssclass="SubTitle"
                            meta:resourcekey="LblFlActDectResource1">
                            Active/Deactive User
                        </div>
                        <div class="ActivityContent">
                            <div>
                                <asp:Label ID="LblActiveAction" runat="server" Text="Action:" CssClass="textlabel"
                                    meta:resourceKey="LblActiveActionResource1"></asp:Label>
                                <asp:RadioButton ID="RdbActive" runat="server" Text="Active" GroupName="ActDeact"
                                    Checked="True" meta:resourceKey="RdbActiveResource1" />
                                <asp:RadioButton ID="RdbDeactive" runat="server" Text="Deactive" GroupName="ActDeact"
                                    meta:resourceKey="RdbDeactiveResource1" />
                            </div>
                            <div class="gobotton">
                                <asp:Button ID="BtnActDeactSub" runat="server" Text="Submit" OnClick="BtnActDeactSub_Click"
                                    CssClass="gobutton" meta:resourceKey="BtnActDeactSubResource1" />
                            </div>
                        </div>
                    </div>
                    <div id="PnlResetPassword" runat="server" visible="False" meta:resourcekey="PnlResetPasswordResource1">
                        <div class="subheaduserdetail" id="LblFlResetPasword" runat="server" meta:resourcekey="LblFlResetPaswordResource1">
                            Reset Password
                        </div>
                        <div class="ActivityContent">
                            <asp:Label ID="LblPassword" runat="server" Text="Enter new password:" meta:resourceKey="LblPasswordResource1"></asp:Label>
                            <asp:TextBox ID="TxtPassword" runat="server" meta:resourceKey="TxtPasswordResource1"
                                Style="line-height: 1.8em; font-size: 1.2em; font-family: Roboto-Light; padding: 0 5px;
                                margin-top: 5px;" TextMode="Password"></asp:TextBox>
                            <asp:Button ID="BtnSubmitPassword" runat="server" Text="Submit" OnClick="BtnSubmitPassword_Click"
                                CssClass="gobutton" meta:resourceKey="BtnSubmitPasswordResource1" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="sidepanel1">
                <div class="activitydivside1">
                    <div class="ActivityHeader">
                        List
                    </div>
                    <div class="ActivityContent">
                        <asp:CheckBoxList ID="ChkUserList" runat="server" CssClass="chkChoice" meta:resourcekey="ChkUserListResource1">
                        </asp:CheckBoxList>
                        <asp:GridView ID="GvUserList" runat="server" DataKeyNames="UserID,RoleID" OnPageIndexChanging="GvUserList_PageIndexChanging"
                            OnSorting="grvEmpStdSubAllocationDetails_Sorting" OnRowCreated="grvEmpStdSubAllocationDetails_RowCreated"
                            meta:resourcekey="GvUserListResource1" AutoGenerateColumns="False">
                            <Columns>
                                <asp:BoundField DataField="UserID" HeaderText="UserID" Visible="False" meta:resourcekey="BoundFieldResource1" />
                                <asp:TemplateField HeaderText="Select" meta:resourcekey="TemplateFieldResource1"
                                    ItemStyle-HorizontalAlign="Center">
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="chkSelectHeader" runat="server" onclick="javascript:SelectAllCheckboxes(this);" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="ChkUserID" runat="server" meta:resourcekey="ChkUserIDResource1" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="FirstName" HeaderText="First Name" SortExpression="FirstName"
                                    meta:resourcekey="BoundFieldResource2" />
                                <asp:BoundField DataField="RoleID" HeaderText="RoleID" SortExpression="RoleID" Visible="false" />
                                <asp:BoundField DataField="RoleName" HeaderText="Role" SortExpression="RoleName"
                                    meta:resourcekey="BoundFieldResource3" />
                                <asp:BoundField DataField="StandardName" HeaderText="Standard" SortExpression="StandardName"
                                    meta:resourcekey="BoundFieldResource4" />
                                <asp:BoundField DataField="DivisionName" HeaderText="Division" SortExpression="DivisionName"
                                    meta:resourcekey="BoundFieldResource5" />
                                <asp:BoundField DataField="SchoolName" HeaderText="School Name" SortExpression="SchoolName"
                                    meta:resourcekey="BoundFieldResource6" />
                                <asp:BoundField DataField="SchoolID" HeaderText="SchoolID" Visible="False" SortExpression="SchoolID"
                                    meta:resourcekey="BoundFieldResource7" />
                                <asp:BoundField DataField="IsActive" HeaderText="IsActive" SortExpression="IsActive"
                                    meta:resourcekey="BoundFieldResource8" />
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
            <asp:PostBackTrigger ControlID="ImgBtnActivate" />
            <asp:PostBackTrigger ControlID="ImgBtnResetPassword" />
            <asp:PostBackTrigger ControlID="BtnActDeactSub" />
            <asp:PostBackTrigger ControlID="BtnSubmitPassword" />
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

        function selectmessage() {
            try {
                var TargetBaseControl = document.getElementById('<%= GvUserList.ClientID %>');
                var AllTick = 0;  //var AllTick = false;
                var Inputs = TargetBaseControl.getElementsByTagName("input");
                for (var n = 0; n < Inputs.length; ++n) {
                    if (Inputs[n].type == 'checkbox') {
                        if (Inputs[n].checked == true) {
                            AllTick++;
                            //                            break;
                        }
                    }
                }
                if (AllTick == 0) {
                    alert("Select one contact for update");
                    return false;
                }
                else if (AllTick > 1) {
                    alert("Only One Record can be Selected for Edit operation");
                    return false;
                }
                else {
                    return true;
                }

            }
            catch (e) {
                alert("Select one contact for update");
            }
        }
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
