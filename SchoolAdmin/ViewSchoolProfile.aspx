<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Epathshala.master" AutoEventWireup="true"
    CodeFile="ViewSchoolProfile.aspx.cs" Inherits="SchoolAdmin_ViewSchoolProfile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/UserControl/NewTeacherPanel.ascx" TagName="TeacherPanel" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="../Scripts/Jquery1.9.1.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        $(document).ready(function () {
            debugger;
            $("#<%= ibtnSearch.ClientID%>").click(function () {
                debugger;
                if ($("#<%= pnlSearch.ClientID%>").is(':visible')) {
                    $("#<%= pnlSearch.ClientID%>").removeClass("Visible").addClass("InVisible");
                } else {
                    $("#<%= pnlSearch.ClientID%>").removeClass("InVisible").addClass("Visible");
                }
                return false;
            });


        });
    </script>
    <asp:UpdatePanel runat="server" ID="upMain" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="tblDashboard1">
                <div class="firstpanel">
                    <div class="activitydivfull" style="margin-bottom: 10px;">
                        <div class="ActivityHeader">
                            <asp:Label ID="lblGenInfoTitle" runat="server" Text="General Information" meta:resourcekey="lblGenInfoTitleResource1"></asp:Label>
                        </div>
                        <div class="ActivityContent">
                            <div>
                                <asp:Label ID="lblSchName" runat="server" Text="School Name:" CssClass="textlabel1"
                                    meta:resourcekey="lblSchNameResource1"></asp:Label>
                                <asp:TextBox ID="txtSchName" runat="server" CssClass="controllabel" meta:resourcekey="lblValSchNameResource1"
                                    Enabled="False" Style="width: 50%;"></asp:TextBox>
                            </div>
                            <div style="margin-top: 5px; display: inline-block; width: 100%;">
                                <asp:Label ID="lblSchAddress" runat="server" Text="School Address:" CssClass="textlabel1"
                                    meta:resourcekey="lblSchAddressResource1"></asp:Label>
                                <asp:TextBox ID="txtValSchAddress" TextMode="MultiLine" CssClass="controllabel" runat="server"
                                    meta:resourcekey="lblValSchAddressResource1" Enabled="False" Style="width: 300px;"></asp:TextBox>
                            </div>
                            <div>
                                <div style="margin-top: 5px; display: inline-block; width: 50%; float: left;">
                                    <asp:Label ID="lblPloatNo" runat="server" Text="Plot number:" CssClass="textlabel1"
                                        meta:resourcekey="lblPloatNoResource1"></asp:Label>
                                    <asp:TextBox ID="txtValPloatNo" runat="server" CssClass="controllabel" meta:resourcekey="lblValPloatNoResource1"
                                        Enabled="False"></asp:TextBox>
                                </div>
                                <div style="margin-top: 5px; display: inline-block; width: 50%; float: left;">
                                    <asp:Label ID="lblBlockNoSurvey" runat="server" Text="Block No/Survey no:" CssClass="textlabel1"
                                        meta:resourcekey="lblBlockNoSurveyResource1"></asp:Label>
                                    <asp:TextBox ID="txtValBlockNoSurvey" runat="server" CssClass="controllabel" meta:resourcekey="lblValBlockNoSurveyResource1"
                                        Enabled="False"></asp:TextBox>
                                </div>
                            </div>
                            <div>
                                <div style="margin-top: 5px; display: inline-block; width: 50%; float: left;">
                                    <asp:Label ID="lblCountry" runat="server" Text="Country:" CssClass="textlabel1" meta:resourcekey="lblCountryResource1"></asp:Label>
                                    <asp:Label ID="lblValCountry" runat="server" CssClass="controllabel" meta:resourcekey="lblValCountryResource1"></asp:Label>
                                </div>
                                <div style="margin-top: 5px; display: inline-block; width: 50%; float: left;">
                                    <asp:Label ID="lblState" runat="server" Text="State:" CssClass="textlabel1" meta:resourcekey="lblStateResource1"></asp:Label>
                                    <asp:Label ID="lblValState" runat="server" CssClass="controllabel" meta:resourcekey="lblValStateResource1"></asp:Label>
                                </div>
                            </div>
                            <div>
                                <div style="margin-top: 5px; display: inline-block; width: 50%; float: left;">
                                    <asp:Label ID="lblDistrict" runat="server" Text="District:" CssClass="textlabel1"
                                        meta:resourcekey="lblDistrictResource1"></asp:Label>
                                    <asp:Label ID="lblValDistrict" runat="server" CssClass="controllabel" meta:resourcekey="lblValDistrictResource1"></asp:Label>
                                </div>
                                <div style="margin-top: 5px; display: inline-block; width: 50%; float: left;">
                                    <asp:Label ID="lblCity" runat="server" Text="City/Village:" CssClass="textlabel1"
                                        meta:resourcekey="lblCityResource1"></asp:Label>
                                    <asp:TextBox ID="txtValCity" runat="server" meta:resourcekey="lblValCityResource1"
                                        CssClass="controllabel" Enabled="False"></asp:TextBox>
                                </div>
                            </div>
                            <div style="margin-top: 5px; display: inline-block; width: 100%;">
                                <asp:Label ID="lblPincode" runat="server" Text="Pincode:" CssClass="textlabel1" meta:resourcekey="lblPincodeResource1"></asp:Label>
                                <asp:TextBox ID="txtValPincode" runat="server" CssClass="controllabel" meta:resourcekey="lblValPincodeResource1"
                                    Enabled="False"></asp:TextBox>
                            </div>
                            <div>
                                <div style="margin-top: 5px; display: inline-block; width: 50%; float: left;">
                                    <asp:Label ID="lblLandline" runat="server" Text="Landline No:" CssClass="textlabel1"
                                        meta:resourcekey="lblLandlineResource1"></asp:Label>
                                    <asp:TextBox ID="txtValLandline" runat="server" CssClass="controllabel" meta:resourcekey="lblValLandlineResource1"></asp:TextBox>
                                </div>
                                <div style="margin-top: 5px; display: inline-block; width: 50%; float: left;">
                                    <asp:Label ID="lblFaxNo" runat="server" Text="FAX No:" CssClass="textlabel1" meta:resourcekey="lblFaxNoResource1"></asp:Label>
                                    <asp:TextBox ID="txtValFaxNo" runat="server" CssClass="controllabel" meta:resourcekey="lblValFaxNoResource1"></asp:TextBox>
                                </div>
                            </div>
                            <div>
                                <div style="margin-top: 5px; display: inline-block; width: 50%; float: left;">
                                    <asp:Label ID="lblMobileNo" runat="server" Text="Mobile No:" CssClass="textlabel1"
                                        meta:resourcekey="lblMobileNoResource1"></asp:Label>
                                    <asp:TextBox ID="txtValMobileNo" runat="server" CssClass="controllabel" meta:resourcekey="lblValMobileNoResource1"></asp:TextBox>
                                </div>
                                <div style="margin-top: 5px; display: inline-block; width: 50%; float: left;">
                                    <asp:Label ID="lblSchoolStartYear" runat="server" Text="School start year:" CssClass="textlabel1"
                                        meta:resourcekey="lblSchoolStartYearResource1"></asp:Label>
                                    <asp:TextBox ID="txtValSchoolStartYear" runat="server" CssClass="controllabel" meta:resourcekey="lblValSchoolStartYearResource1"
                                        Enabled="False"></asp:TextBox>
                                </div>
                            </div>
                            <div>
                                <div style="margin-top: 5px; display: inline-block; width: 50%; float: left;">
                                    <asp:Label ID="lblSchlMailID" runat="server" Text="School E-mail ID:" CssClass="textlabel1"
                                        meta:resourcekey="lblSchlMailIDResource1"></asp:Label>
                                    <asp:TextBox ID="txtValSchlMailID" runat="server" CssClass="controllabel" meta:resourcekey="lblValSchlMailIDResource1"></asp:TextBox>
                                </div>
                                <div style="margin-top: 5px; display: inline-block; width: 50%; float: left;">
                                    <asp:Label ID="lblSchlWebsite" runat="server" Text="School Website URL:" CssClass="textlabel1"
                                        meta:resourcekey="lblSchlWebsiteResource1"></asp:Label>
                                    <asp:TextBox ID="txtValSchlWebsite" runat="server" CssClass="controllabel" meta:resourcekey="lblValSchlWebsiteResource1"></asp:TextBox>
                                </div>
                            </div>
                            <div style="margin-left: 120px;">
                                <asp:Button ID="btnUpdate" runat="server" Text="Update" ValidationGroup="SchoolGeneralInfo"
                                    CssClass="gobutton" meta:resourcekey="btnUpdateResource1" OnClick="btnUpdate_Click" />
                            </div>
                        </div>
                    </div>
                    <div class="activitydivfull">
                        <div class="ActivityHeader">
                            <asp:Label ID="lblSchoolInformation" runat="server" Text="School Information" meta:resourcekey="lblSchoolInformationResource1"></asp:Label>
                        </div>
                        <div class="ActivityContent">
                            <div style="width: 100%; clear: both;">
                                <ul class="standarbtn">
                                    <li class="standarbar">
                                        <asp:ImageButton ID="ibtnSearch" runat="server" ImageUrl="~/App_Themes/Responsive/web/searchuser.png"
                                            OnClick="ibtnSearch_Click" meta:resourcekey="ibtnSearchResource1" ToolTip="Search School Details" />
                                    </li>
                                    <li class="standarbar">
                                        <asp:ImageButton ID="ibtnRefresh" runat="server" ImageUrl="~/App_Themes/Responsive/web/rectreload.png"
                                            OnClick="ibtnRefresh_Click" meta:resourcekey="ibtnRefreshResource1" ToolTip="Refresh" />
                                    </li>
                                </ul>
                            </div>
                            <div style="width: 100%; clear: both; border: thin solid #ccc; display: inline-block;
                                margin-bottom: 10px;">
                                <asp:Panel ID="pnlSearch" runat="server" CssClass="Visible" meta:resourcekey="pnlSearchResource1">
                                    <div class="subheaduserdetail">
                                        <asp:Label ID="lblSearchTitle" runat="server" Text="Search" meta:resourceKey="lblSearchTitleResource1"></asp:Label>
                                    </div>
                                    <div class="ActivityContent" id="fsSchoolGeneralInfo" runat="server">
                                        <div>
                                            <div class="subactiviycontent">
                                                <asp:Label ID="lblStatus" runat="server" Text="School Status:" CssClass="textlabel"
                                                    meta:resourceKey="lblStatusResource1"></asp:Label>
                                                <asp:DropDownList ID="ddlStatus" runat="server" CssClass="DdlValueField" AutoPostBack="True"
                                                    AppendDataBoundItems="True" meta:resourceKey="ddlStatusResource1">
                                                </asp:DropDownList>
                                            </div>
                                            <div class="subactiviycontent">
                                                <asp:Label ID="lblSchoolType" runat="server" Text="School Type:" CssClass="textlabel"
                                                    meta:resourceKey="lblSchoolTypeResource1"></asp:Label>
                                                <asp:DropDownList ID="ddlSchoolType" runat="server" CssClass="DdlValueField" AutoPostBack="True"
                                                    AppendDataBoundItems="True" meta:resourceKey="ddlSchoolTypeResource1">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div>
                                            <div class="subactiviycontent">
                                                <asp:Label ID="lblBoard" runat="server" Text="Board:" CssClass="textlabel" meta:resourceKey="lblBoardResource1"></asp:Label>
                                                <asp:DropDownList ID="ddlBoardI" runat="server" CssClass="DdlValueField" AutoPostBack="True"
                                                    OnSelectedIndexChanged="ddlBoardI_SelectedIndexChanged" AppendDataBoundItems="True"
                                                    meta:resourceKey="ddlBoardIResource1">
                                                </asp:DropDownList>
                                            </div>
                                            <div class="subactiviycontent">
                                                <asp:Label ID="lblMedium" runat="server" Text="Medium:" CssClass="textlabel" meta:resourceKey="lblMediumResource1"></asp:Label>
                                                <asp:DropDownList ID="ddlMedium" runat="server" CssClass="DdlValueField" AutoPostBack="True"
                                                    OnSelectedIndexChanged="ddlMedium_SelectedIndexChanged" AppendDataBoundItems="True"
                                                    meta:resourceKey="ddlMediumResource1">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div>
                                            <asp:Label ID="lblStandard" runat="server" Text="Standard:" CssClass="textlabel"
                                                meta:resourceKey="lblStandardResource1"></asp:Label>
                                            <asp:DropDownList ID="ddlStandard" runat="server" CssClass="DdlValueField" AutoPostBack="True"
                                                AppendDataBoundItems="True" meta:resourceKey="ddlStandardResource1">
                                            </asp:DropDownList>
                                        </div>
                                        <div class="gobotton">
                                            <asp:Button ID="btnGo" runat="server" OnClick="btnGo_Click" Text="Go" CssClass="gobutton"
                                                meta:resourceKey="btnGoResource1" />
                                        </div>
                                    </div>
                                </asp:Panel>
                            </div>
                            <div style="width: 100%; clear: both;">
                                <asp:GridView ID="gvSchoolRegistrationBMSdetail" runat="server" AllowPaging="True"
                                    DataKeyNames="SchoolBMSID,SchoolTypeID,BMSID,SchoolID,NoOfStudents,StartTime,EndTime,StatusID,Status"
                                    OnPageIndexChanging="gvSchoolRegistrationBMSdetail_PageIndexChanging" EmptyDataText="No Data Found."
                                    AllowSorting="True" OnRowCreated="gvEmpStdSubAllocationDetails_RowCreated" OnSorting="gvEmpStdSubAllocationDetails_Sorting"
                                    meta:resourcekey="gvSchoolRegistrationBMSdetailResource1" AutoGenerateColumns="false">
                                    <Columns>
                                        <asp:TemplateField meta:resourcekey="TemplateFieldResource1">
                                            <HeaderTemplate>
                                                <table>
                                                    <tr>
                                                        <td align="center">
                                                            <asp:CheckBox ID="chkHeaderchkSelect" runat="server" meta:resourcekey="chkHeaderchkSelectResource1" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <table>
                                                    <tr>
                                                        <td align="center">
                                                            <asp:CheckBox ID="chkSelect" runat="server" meta:resourcekey="chkSelectResource2" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Sr. No" meta:resourcekey="TemplateFieldResource2">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex +1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Board" HeaderText="Board" SortExpression="Board" meta:resourcekey="BoundFieldResource1" />
                                        <asp:BoundField DataField="Medium" HeaderText="Medium" SortExpression="Medium" meta:resourcekey="BoundFieldResource2" />
                                        <asp:BoundField DataField="Standard" HeaderText="Standard" SortExpression="Standard"
                                            meta:resourcekey="BoundFieldResource3" />
                                        <asp:BoundField DataField="Type" HeaderText="School Type" SortExpression="Type" meta:resourcekey="BoundFieldResource4" />
                                        <asp:BoundField DataField="NoOfStudents" HeaderText="Total Student" SortExpression="NoOfStudents"
                                            meta:resourcekey="BoundFieldResource5" />
                                        <asp:BoundField DataField="StartTime" HeaderText="StartTime" SortExpression="StartTime"
                                            meta:resourcekey="BoundFieldResource6" />
                                        <asp:BoundField DataField="EndTime" HeaderText="EndTime" SortExpression="EndTime"
                                            meta:resourcekey="BoundFieldResource7" />
                                    </Columns>
                                    <PagerTemplate>
                                        <asp:ImageButton Text="First" CommandName="Page" CommandArgument="First" runat="server"
                                            ImageUrl="~/App_Themes/Responsive/web/first.png" ID="ibtnFirst" meta:resourcekey="ibtnFirstResource1"
                                            ToolTip="Move First Page" CssClass="playbtn" />
                                        <asp:ImageButton Text="Previous" CommandName="Page" CommandArgument="Prev" runat="server"
                                            ImageUrl="~/App_Themes/Responsive/web/previous.png" ID="ibtnPrevious" meta:resourcekey="ibtnPreviousResource1"
                                            ToolTip="Move Previous Page" CssClass="playbtn" />
                                        <asp:Label ID="lblGoPage" runat="server" Text="Goto Page" Style="color: #000;" meta:resourcekey="lblGoPageResource1"></asp:Label>
                                        <asp:DropDownList ID="ddlPageSelector" OnSelectedIndexChanged="ddlPageSelector_SelectedIndexChanged"
                                            runat="server" AutoPostBack="True" meta:resourcekey="ddlPageSelectorResource1">
                                        </asp:DropDownList>
                                        <asp:ImageButton Text="Next" CommandName="Page" CommandArgument="Next" runat="server"
                                            ImageUrl="~/App_Themes/Responsive/web/next.png" ID="ibtnNext" meta:resourcekey="ibtnNextResource1"
                                            ToolTip="Move Next Page" CssClass="playbtn" />
                                        <asp:ImageButton Text="Last" CommandName="Page" CommandArgument="Last" runat="server"
                                            ToolTip="Move Last Page" ImageUrl="~/App_Themes/Responsive/web/last.png" ID="ibtnLast"
                                            meta:resourcekey="ibtnLastResource1" CssClass="playbtn" />
                                    </PagerTemplate>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="ddlStatus" />
            <asp:AsyncPostBackTrigger ControlID="ddlSchoolType" />
            <asp:AsyncPostBackTrigger ControlID="ddlBoardI" />
            <asp:AsyncPostBackTrigger ControlID="ddlMedium" />
            <asp:AsyncPostBackTrigger ControlID="ddlStandard" />
            <asp:AsyncPostBackTrigger ControlID="btnGo" />
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
