<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Epathshala.master" AutoEventWireup="true"
    CodeFile="SchoolList.aspx.cs" Inherits="Admin_SchoolList" Culture="auto" meta:resourcekey="PageResource1"
    UICulture="auto" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="../Scripts/Jquery1.9.1.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {

            $("#<%= ibtnSearch.ClientID%>").click(function () {
                if ($("#<%= pnlSearch.ClientID%>").is(':visible')) {
                    $("#<%= pnlSearch.ClientID%>").removeClass("Visible").addClass("InVisible");
                } else {
                    $("#<%= pnlSearch.ClientID%>").removeClass("InVisible").addClass("Visible");
                }
                return false;
            });
            $("#<%= ibtnActiveDe.ClientID%>").click(function () {
                if ($("#<%= pnlActDeact.ClientID%>").is(':visible')) {
                    $("#<%= pnlActDeact.ClientID%>").removeClass("Visible").addClass("InVisible");
                } else {
                    $("#<%= pnlActDeact.ClientID%>").removeClass("InVisible").addClass("Visible");
                }
                return false;
            });

            $("#<%= ibtnRejApp.ClientID%>").click(function () {
                if ($("#<%= pnlRejApp.ClientID%>").is(':visible')) {
                    $("#<%= pnlRejApp.ClientID%>").removeClass("Visible").addClass("InVisible");
                } else {
                    $("#<%= pnlRejApp.ClientID%>").removeClass("InVisible").addClass("Visible");
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

            var TargetBaseControl = document.getElementById('<%= this.gvSchooldetail.ClientID %>');

            var TargetChildControl = "chkselect";
            var Inputs = TargetBaseControl.getElementsByTagName("input");
            for (var n = 0; n < Inputs.length; ++n)
                if (Inputs[n].type == 'checkbox')
                    Inputs[n].checked = CheckBox.checked;
            Counter = CheckBox.checked ? TotalChkBx : 0;
        }

        function ChildClick(CheckBox) {

            TotalChkBx = parseInt('<%= this.gvSchooldetail.Rows.Count %>');

            var HeaderCheckBox = document.getElementById('ctl00_ContentPlaceHolder1_gvSchooldetail_ctl01_chkHeaderchkSelect');
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
    <table cellpadding="0" cellspacing="0" width="90%" class="RoundTop InnerTableStyle TableControl">
        <tr>
            <td class="Header12 GridViewHeadercssTestAssessment RoundTop">
                <asp:Label ID="lblTitle" runat="server" Text="School Management" meta:resourcekey="lblTitleResource1"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <table cellpadding="0" cellspacing="0" class="ActionBarTable">
                    <tr>
                        <td class="LeftCorner">
                        </td>
                        <td class="Center">
                            <table cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td class="InnerLeftRound">
                                    </td>
                                    <td class="Divider">
                                    </td>
                                    <td class="Buttons">
                                        <%-- <img id="ImgSearch" src="../Images/ButtonBarView.gif" alt="View" onmouseover="this.src='../Images/ButtonBarViewOver.gif'"
                                                    onmouseout="this.src='../Images/ButtonBarView.gif'" onmousedown="this.src='../Images/ButtonBarViewOver.gif'" />--%>
                                        <asp:ImageButton ID="ibtnSearch" runat="server" ImageUrl="~/App_Themes/Images/ButtonBarView.png"
                                            ToolTip="Search" meta:resourcekey="ibtnSearchResource1" />
                                    </td>
                                    <td class="Buttons">
                                        <asp:ImageButton ID="ibtnRefresh" runat="server" ImageUrl="~/App_Themes/Images/ButtonBarRefresh.png"
                                            OnClick="ibtnRefresh_Click" CausesValidation="False" ToolTip="Refresh" meta:resourcekey="ibtnRefreshResource1" />
                                        <%-- <img id="ImgRefresh" src="../Images/ButtonBarRefresh.gif" alt="Refresh" onmouseout="this.src='../Images/ButtonBarRefresh.gif'"
                                                    onmouseover="this.src='../Images/ButtonBarRefreshOver.gif'" />--%>
                                    </td>
                                    <td class="Buttons">
                                        <asp:ImageButton ID="ibtnApproveSchDetails" runat="server" Text="Approved School Details"
                                            OnClick="ibtnApproveSchDetails_Click" ImageUrl="~/App_Themes/Images/ButtonBarNew.png"
                                            ToolTip="Approve School" meta:resourcekey="ibtnApproveSchDetailsResource1" />
                                    </td>
                                    <td class="Buttons">
                                        <asp:ImageButton ID="ibtnView" runat="server" OnClick="ibtnView_Click" ImageUrl="~/App_Themes/Images/ButtonBarViewDetail.png"
                                            ToolTip="View School Details" meta:resourcekey="ibtnViewResource1" />
                                    </td>
                                    <td class="Buttons">
                                        <asp:ImageButton ID="ibtnShowUsers" ImageUrl="~/App_Themes/Images/ButtonBarShowUsers.png"
                                            runat="server" OnClick="ibtnShowUsers_Click" ToolTip="Show User" meta:resourcekey="ibtnShowUsersResource1" />
                                    </td>
                                    <td class="Buttons">
                                        <asp:ImageButton ID="ibtnActiveDe" runat="server" Text="Active/Deactive" ImageUrl="~/App_Themes/Images/ButtonBarActiveDeactive.png"
                                            ToolTip="Activate/Deactivate School" meta:resourcekey="ibtnActiveDeResource1"
                                            Visible="false" />
                                    </td>
                                    <td class="Buttons">
                                        <asp:ImageButton ID="ibtnRejApp" runat="server" Text="Approve/Reject" ImageUrl="~/App_Themes/Images/ButtonBarApproveReject.png"
                                            ToolTip="Approve/Reject School" meta:resourcekey="ibtnRejAppResource1" Visible="false" />
                                    </td>
                                    <td class="Buttons">
                                        <asp:ImageButton ID="imbchangestatus" runat="server" Text="Change Status" ImageUrl="~/App_Themes/Images/ButtonBarApproveReject.png"
                                            ToolTip="Change School Status" OnClick="imbchangestatus_Click" />
                                    </td>
                                    <td class="InnerRightRound">
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td class="RightCorner">
                        </td>
                    </tr>
                </table>
                <asp:UpdatePanel ID="upSchoolDetails" runat="server">
                    <Triggers>
                        <asp:PostBackTrigger ControlID="btnGo" />
                        <asp:PostBackTrigger ControlID="btnActDeactSub" />
                        <asp:PostBackTrigger ControlID="btnAppRejSubmit" />
                    </Triggers>
                    <ContentTemplate>
                        <table id="tblGrid" cellpadding="0" cellspacing="0" width="100%" style="padding: 5px;">
                            <tr>
                                <td class="panel">
                                    <asp:Panel ID="pnlSearch" CssClass="Visible" runat="server" meta:resourcekey="pnlSearchResource1">
                                        <fieldset id="fsSchoolGeneralInfo" runat="server">
                                            <legend>
                                                <asp:Label ID="lblSearchTitle" runat="server" CssClass="SubTitle" Text="Search" meta:resourcekey="lblSearchTitleResource1"></asp:Label>
                                            </legend>
                                            <table class="tblControl1">
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblStatus" runat="server" Text="Status:" meta:resourcekey="lblStatusResource1"></asp:Label>
                                                    </td>
                                                    <td style="width: auto; text-align: left;">
                                                        <asp:DropDownList ID="ddlStatus" runat="server" AutoPostBack="True" AppendDataBoundItems="True"
                                                            meta:resourcekey="ddlStatusResource1">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblSchName" runat="server" Text="School Name:" meta:resourcekey="lblSchNameResource1"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtSchName" runat="server" Text='<%# Bind("Name") %>' meta:resourcekey="txtSchNameResource1"></asp:TextBox>
                                                        <cc1:AutoCompleteExtender ID="TxtSchName_AutoCompleteExtender" runat="server" DelimiterCharacters=""
                                                            Enabled="True" ServiceMethod="GetSchoolName" ServicePath="" TargetControlID="txtSchName"
                                                            UseContextKey="True">
                                                        </cc1:AutoCompleteExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblState" runat="server" Text="State:" meta:resourcekey="lblStateResource1"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtState" runat="server" meta:resourcekey="txtStateResource1"></asp:TextBox>
                                                        <cc1:AutoCompleteExtender ID="TxtState_AutoCompleteExtender" runat="server" DelimiterCharacters=""
                                                            Enabled="True" ServiceMethod="GetState" ServicePath="" TargetControlID="txtState"
                                                            UseContextKey="True">
                                                        </cc1:AutoCompleteExtender>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblDistrict" runat="server" Text="District:" meta:resourcekey="lblDistrictResource1"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtDistrict" runat="server" meta:resourcekey="txtDistrictResource1"></asp:TextBox>
                                                        <cc1:AutoCompleteExtender ID="TxtDistrict_AutoCompleteExtender" runat="server" DelimiterCharacters=""
                                                            Enabled="True" ServiceMethod="GetDistrict" ServicePath="" TargetControlID="txtDistrict"
                                                            UseContextKey="True">
                                                        </cc1:AutoCompleteExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblPincode" runat="server" Text="Pincode:" meta:resourcekey="lblPincodeResource1"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtPincode" runat="server" meta:resourcekey="txtPincodeResource1"></asp:TextBox>
                                                        <cc1:AutoCompleteExtender ID="TxtPincode_AutoCompleteExtender" runat="server" DelimiterCharacters=""
                                                            Enabled="True" ServiceMethod="GetPinCode" ServicePath="" TargetControlID="txtPincode"
                                                            UseContextKey="True">
                                                        </cc1:AutoCompleteExtender>
                                                    </td>
                                                    <td align="center">
                                                        <asp:Button ID="btnGo" runat="server" Text="Go" OnClick="btnGo_Click" CssClass="gobutton"
                                                            meta:resourcekey="btnGoResource1" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </fieldset>
                                    </asp:Panel>
                                    <asp:Panel ID="pnlActDeact" runat="server" CssClass="InVisible" meta:resourcekey="pnlActDeactResource1">
                                        <fieldset id="fsActDeact" runat="server">
                                            <legend>
                                                <asp:Label ID="lblActDeactTitle" runat="server" Text="Active/Deactive School" meta:resourcekey="lblActDeactTitleResource1"></asp:Label>
                                            </legend>
                                            <table cellspacing="1" style="margin: 5px">
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
                                                            meta:resourcekey="btnActDeactSubResource1" CssClass="gobutton" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </fieldset>
                                    </asp:Panel>
                                    <asp:Panel ID="pnlRejApp" runat="server" CssClass="InVisible" meta:resourcekey="pnlRejAppResource1">
                                        <fieldset id="fsApprReject" runat="server">
                                            <legend>
                                                <asp:Label ID="lblAppRejTitle" runat="server" Text="Approve/Reject School" meta:resourcekey="lblAppRejTitleResource1"></asp:Label>
                                            </legend>
                                            <table cellspacing="1" style="margin: 5px">
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblPnlRejApp" runat="server" Text="Please Select Action:" meta:resourcekey="lblPnlRejAppTitleResource1"></asp:Label>
                                                        <asp:RadioButton ID="rbApprove" runat="server" Text=" Approve" GroupName="AppReje"
                                                            Checked="True" meta:resourcekey="rbApproveResource1" />
                                                        <asp:RadioButton ID="rbReject" runat="server" Text=" Reject" GroupName="AppReje"
                                                            meta:resourcekey="rbRejectResource1" />
                                                    </td>
                                                    <td>
                                                        <asp:Button ID="btnAppRejSubmit" runat="server" Text="Submit" OnClick="btnAppRejSubmit_Click"
                                                            meta:resourcekey="btnAppRejSubmitResource1" CssClass="gobutton" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </fieldset>
                                    </asp:Panel>
                                    <asp:Panel ID="PnlChangeStatus" runat="server" CssClass="InVisible" meta:resourcekey="pnlRejAppResource1">
                                        <fieldset id="Fieldset1" runat="server">
                                            <legend>
                                                <asp:Label ID="lblchangestatus" runat="server" Text="Change School Status" meta:resourcekey="lblAppRejTitleResource1"></asp:Label>
                                            </legend>
                                            <table cellspacing="1" style="margin: 5px">
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblaction" runat="server" Text="Please Select Action:" meta:resourcekey="lblPnlRejAppTitleResource1"></asp:Label>
                                                        <asp:RadioButton ID="rbActive1" runat="server" Text=" Active" GroupName="Status1" />
                                                        <asp:RadioButton ID="rbDeactive1" runat="server" Text=" Deactive" GroupName="Status1" />
                                                        <asp:RadioButton ID="rbApprove1" runat="server" Text=" Approve" GroupName="Status1" />
                                                        <asp:RadioButton ID="rbReject1" runat="server" Text=" Reject" GroupName="Status1" />
                                                        <asp:RadioButton ID="rbApplied1" runat="server" Text=" Applied" GroupName="Status1" />
                                                    </td>
                                                    <td>
                                                        <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="btnAppRejSubmit_Click"
                                                            meta:resourcekey="btnAppRejSubmitResource1" CssClass="gobutton" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </fieldset>
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:GridView ID="gvSchooldetail" runat="server" DataKeyNames="SchoolID,Name,PloteNo,BlockNo,Address,CountryID,StateID,DistrictID,City,PinCode,LandLineNo,FaxNo,MobileNo,EmailID,WebSiteURL,SchoolStartYear,Comment,StatusID,CreatedOn,CreatedBy,ModifiedOn,ModifiedBy"
                                        OnPageIndexChanging="gvSchooldetail_PageIndexChanging" OnSorting="gvEmpStdSubAllocationDetails_Sorting"
                                        OnRowCreated="gvEmpStdSubAllocationDetails_RowCreated" meta:resourcekey="gvSchooldetailResource1">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Select" ItemStyle-HorizontalAlign="Center">
                                                <HeaderTemplate>
                                                    <asp:CheckBox ID="chkHeaderchkSelect" runat="server" onclick="javascript:SelectAll(this);"
                                                        meta:resourcekey="chkheaderResource1"  AutoPostBack="true" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkSelect" runat="server" meta:resourcekey="chkSelectResource1" AutoPostBack="true"
                                                        OnCheckedChanged="chkheaderselect_checkedchanged" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--<HeaderTemplate>
                                                    <table>
                                                        <tr>
                                                            <td align="center">
                                                                <asp:CheckBox ID="chkHeaderchkSelect" runat="server" onclick="javascript:SelectAll(this);"
                                                                    meta:resourcekey="chkheaderResource1" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </HeaderTemplate>--%>
                                            <%--<ItemTemplate>
                                                    <table>
                                                        <tr>
                                                            <td align="center">
                                                                <asp:CheckBox ID="chkSelect" runat="server" onclick="javascript:ChildClick(this);"
                                                                    meta:resourcekey="chkSelectResource1" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>--%>
                                            <asp:TemplateField HeaderText="Sr. No" meta:resourcekey="TemplateFieldResource2">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex +1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="School" SortExpression="Name" meta:resourcekey="TemplateFieldResource3">
                                                <ItemTemplate>
                                                    <asp:HyperLink ID="HypLink" runat="server" Text='<%# Bind("Name") %>' NavigateUrl='<%# Bind("WebSiteURL") %>'
                                                        Target="_blank"></asp:HyperLink>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="State" HeaderText="State" SortExpression="State" meta:resourcekey="BoundFieldResource1" />
                                            <asp:BoundField DataField="District" HeaderText="District" SortExpression="District"
                                                meta:resourcekey="BoundFieldResource2" />
                                            <asp:BoundField DataField="PinCode" HeaderText="Pincode" SortExpression="PinCode"
                                                meta:resourcekey="BoundFieldResource3" />
                                            <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" meta:resourcekey="BoundFieldResource4" />
                                        </Columns>
                                        <PagerTemplate>
                                            <asp:ImageButton Text="First" CommandName="Page" CommandArgument="First" runat="server"
                                                ImageUrl="~/App_Themes/Images/first.png" ID="ibtnFirst" meta:resourcekey="ibtnFirstResource1"
                                                ToolTip="Move First Page" />
                                            <asp:ImageButton Text="Previous" CommandName="Page" CommandArgument="Prev" runat="server"
                                                ImageUrl="~/App_Themes/Images/previous.png" ID="ibtnPrevious" ToolTip="Move Previous Page"
                                                meta:resourcekey="ibtnPreviousResource1" />
                                            <asp:Label ID="lblPage" runat="server" Text="Page" meta:resourcekey="lblPageResource1"
                                                ForeColor="Black"></asp:Label>
                                            <asp:DropDownList ID="ddlPageSelector" OnSelectedIndexChanged="ddlPageSelector_SelectedIndexChanged"
                                                runat="server" AutoPostBack="True" meta:resourcekey="ddlPageSelectorResource1">
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
