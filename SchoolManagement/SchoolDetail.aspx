<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SchoolDetail.aspx.cs" Inherits="Admin_SchoolDetail"
    Culture="auto" meta:resourcekey="PageResource2" UICulture="auto" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ePathshala</title>
    <script src="../Scripts/Jquery1.9.1.js" type="text/javascript"></script>
    <style type="text/css">
        .style1
        {
            width: 12%;
        }
    </style>
    
<script>
    (function (i, s, o, g, r, a, m) {
        i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {
            (i[r].q = i[r].q || []).push(arguments)
        }, i[r].l = 1 * new Date(); a = s.createElement(o),
  m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
    })(window, document, 'script', '//www.google-analytics.com/analytics.js', 'ga');

    ga('create', 'UA-69363607-1', 'auto');
    ga('send', 'pageview');

</script>

</head>
<body>
    <form id="form1" runat="server">
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

            var TargetBaseControl = document.getElementById('<%= this.gvSchoolRegistrationBMSdetail.ClientID %>');

            var TargetChildControl = "chkselect";
            var Inputs = TargetBaseControl.getElementsByTagName("input");
            for (var n = 0; n < Inputs.length; ++n)
                if (Inputs[n].type == 'checkbox')
                    Inputs[n].checked = CheckBox.checked;
            Counter = CheckBox.checked ? TotalChkBx : 0;
        }

        function ChildClick(CheckBox) {

            TotalChkBx = parseInt('<%= this.gvSchoolRegistrationBMSdetail.Rows.Count %>');

            var HeaderCheckBox = document.getElementById('gvSchoolRegistrationBMSdetail_ctl01_chkHeaderchkSelect');
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
    <div style="background-image: url('../App_Themes/Responsive/web/Bannerbg.png');">
        <table cellpadding="0" cellspacing="0" class="RoundTop InnerTableStyle TableControl"
            width="90%">
            <tr>
                <td colspan="4" class="Header12 GridViewHeadercssTestAssessment RoundTop">
                    <asp:Label ID="lblGenInfoTitle" runat="server" Text="General Information" meta:resourcekey="lblGenInfoTitleResource1"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="left" style="margin: auto;">
                    <table style="margin: 10px;" width="90%" class="tblControl1">
                        <tr>
                            <td>
                                <asp:Label ID="lblSchName" runat="server" Text="School Name:" meta:resourcekey="lblSchNameResource1"></asp:Label>
                            </td>
                            <td colspan="3" style="text-align: left;">
                                <asp:TextBox ID="txtSchName" TextMode="MultiLine" runat="server" CssClass="multiline1"
                                    meta:resourcekey="lblValSchNameResource1"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblSchAddress" runat="server" Text="School Address:" meta:resourcekey="lblSchAddressResource1"></asp:Label>
                            </td>
                            <td colspan="3">
                                <asp:TextBox ID="txtValSchAddress" TextMode="MultiLine" CssClass="multiline2" runat="server"
                                    meta:resourcekey="lblValSchAddressResource1"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblPloatNo" runat="server" Text="Plot number:" meta:resourcekey="lblPloatNoResource1"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtValPloatNo" runat="server" meta:resourcekey="lblValPloatNoResource1"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="lblBlockNoSurvey" runat="server" Text="Block No/Survey no:" meta:resourcekey="lblBlockNoSurveyResource1"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtValBlockNoSurvey" runat="server" meta:resourcekey="lblValBlockNoSurveyResource1"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblCountry" runat="server" Text="Country:" meta:resourcekey="lblCountryResource1"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblValCountry" runat="server" meta:resourcekey="lblValCountryResource1"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblState" runat="server" Text="State:" meta:resourcekey="lblStateResource1"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblValState" runat="server" meta:resourcekey="lblValStateResource1"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblDistrict" runat="server" Text="District:" meta:resourcekey="lblDistrictResource1"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblValDistrict" runat="server" meta:resourcekey="lblValDistrictResource1"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblCity" runat="server" Text="City/Village:" meta:resourcekey="lblCityResource1"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtValCity" runat="server" meta:resourcekey="lblValCityResource1"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblPincode" runat="server" Text="Pincode:" meta:resourcekey="lblPincodeResource1"></asp:Label>
                            </td>
                            <td colspan="3">
                                <asp:TextBox ID="txtValPincode" runat="server" meta:resourcekey="lblValPincodeResource1"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblLandline" runat="server" Text="Landline No:" meta:resourcekey="lblLandlineResource1"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtValLandline" runat="server" meta:resourcekey="lblValLandlineResource1"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="lblFaxNo" runat="server" Text="FAX No:" meta:resourcekey="lblFaxNoResource1"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtValFaxNo" runat="server" meta:resourcekey="lblValFaxNoResource1"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblMobileNo" runat="server" Text="Mobile No:" meta:resourcekey="lblMobileNoResource1"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtValMobileNo" runat="server" meta:resourcekey="lblValMobileNoResource1"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="lblSchoolStartYear" runat="server" Text="School start year:" meta:resourcekey="lblSchoolStartYearResource1"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtValSchoolStartYear" runat="server" meta:resourcekey="lblValSchoolStartYearResource1"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblSchlMailID" runat="server" Text="School E-mail ID:" meta:resourcekey="lblSchlMailIDResource1"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtValSchlMailID" runat="server" meta:resourcekey="lblValSchlMailIDResource1"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="lblSchlWebsite" runat="server" Text="School Website URL:" meta:resourcekey="lblSchlWebsiteResource1"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtValSchlWebsite" runat="server" meta:resourcekey="lblValSchlWebsiteResource1"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td class="TitleCell">
                                &nbsp;
                            </td>
                            <td class="ValueCell">
                                &nbsp;
                            </td>
                            <td class="TitleCell">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td class="TitleCell" align="right">
                                <asp:Button ID="btnUpdate" runat="server" Text="Update" ValidationGroup="SchoolGeneralInfo"
                                    meta:resourcekey="btnUpdateResource1" OnClick="btnUpdate_Click" />
                            </td>
                            <td class="ValueCell">
                                &nbsp;
                            </td>
                            <td class="TitleCell">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <asp:ValidationSummary ID="vsumSchoolGeneralInfo" ShowMessageBox="True" ShowSummary="False"
                                    runat="server" ValidationGroup="SchoolGeneralInfo" meta:resourcekey="vsumSchoolGeneralInfoResource1" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <table width="90%" cellpadding="0" cellspacing="0" class="RoundTop InnerTableStyle TableControl">
            <tr>
                <td class="Header12 GridViewHeadercssTestAssessment RoundTop">
                    <asp:Label ID="lblSchoolInformation" runat="server" Text="School Information" meta:resourcekey="lblSchoolInformationResource1"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <table cellpadding="0" cellspacing="0" class="ActionBarTable">
                        <tr>
                            <td class="LeftCorner">
                            </td>
                            <td class="Center">
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td class="InnerLeftRound">
                                        </td>
                                        <td class="Divider">
                                        </td>
                                        <td class="Buttons">
                                            <asp:ImageButton ID="ibtnSearch" runat="server" ImageUrl="~/App_Themes/Images/ButtonBarView.png"
                                                OnClick="ibtnSearch_Click" meta:resourcekey="ibtnSearchResource1" ToolTip="Search School Details" />
                                        </td>
                                        <td class="Buttons">
                                            <asp:ImageButton ID="ibtnRefresh" runat="server" ImageUrl="~/App_Themes/Images/ButtonBarRefresh.png"
                                                OnClick="ibtnRefresh_Click" meta:resourcekey="ibtnRefreshResource1" ToolTip="Refresh" />
                                        </td>
                                        <td class="Buttons" id="tdActDe" runat="server">
                                            <asp:ImageButton ID="ibtnActiveDe" runat="server" Text="Active/Deactive" ImageUrl="~/App_Themes/Images/ButtonBarActiveDeactive.png"
                                                meta:resourcekey="ibtnActiveDeResource1" ToolTip="Active/Deactive School" />
                                        </td>
                                        <td class="Buttons" id="tdApproveReject" runat="server">
                                            <asp:ImageButton ID="ibtnRejApp" runat="server" Text="Approve/Reject" ImageUrl="~/App_Themes/Images/ButtonBarApproveReject.png"
                                                meta:resourcekey="ibtnRejAppResource1" ToolTip="Approve/Reject School" />
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
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Panel ID="pnlSearch" runat="server" CssClass="Visible" meta:resourcekey="pnlSearchResource1">
                        <fieldset id="fsSchoolGeneralInfo" runat="server" style="margin: 5px">
                            <legend>
                                <asp:Label ID="lblSearchTitle" runat="server" Text="Search" meta:resourceKey="lblSearchTitleResource1"></asp:Label>
                            </legend>
                            <table cellspacing="1" style="margin: 5px" class="tblControl1">
                                <tr>
                                    <td>
                                        <asp:Label ID="lblStatus" runat="server" Text="School Status:" meta:resourceKey="lblStatusResource1"></asp:Label>
                                    </td>
                                    <td style="text-align: left;">
                                        <asp:DropDownList ID="ddlStatus" runat="server" AutoPostBack="True" AppendDataBoundItems="True"
                                            meta:resourceKey="ddlStatusResource1">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblSchoolType" runat="server" Text="School Type:" meta:resourceKey="lblSchoolTypeResource1"></asp:Label>
                                    </td>
                                    <td style="text-align: left;">
                                        <asp:DropDownList ID="ddlSchoolType" runat="server" AutoPostBack="True" AppendDataBoundItems="True"
                                            meta:resourceKey="ddlSchoolTypeResource1">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblBoard" runat="server" Text="Board:" meta:resourceKey="lblBoardResource1"></asp:Label>
                                    </td>
                                    <td style="text-align: left;">
                                        <asp:DropDownList ID="ddlBoardI" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlBoardI_SelectedIndexChanged"
                                            AppendDataBoundItems="True" meta:resourceKey="ddlBoardIResource1">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblMedium" runat="server" Text="Medium:" meta:resourceKey="lblMediumResource1"></asp:Label>
                                    </td>
                                    <td style="text-align: left;">
                                        <asp:DropDownList ID="ddlMedium" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlMedium_SelectedIndexChanged"
                                            AppendDataBoundItems="True" meta:resourceKey="ddlMediumResource1">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblStandard" runat="server" Text="Standard:" meta:resourceKey="lblStandardResource1"></asp:Label>
                                    </td>
                                    <td style="text-align: left;">
                                        <asp:DropDownList ID="ddlStandard" runat="server" AutoPostBack="True" AppendDataBoundItems="True"
                                            meta:resourceKey="ddlStandardResource1">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        <asp:Button ID="btnGo" runat="server" OnClick="btnGo_Click" Text="Go" CssClass="gobutton"
                                            meta:resourceKey="btnGoResource1" />
                                    </td>
                                </tr>
                            </table>
                        </fieldset>
                    </asp:Panel>
                    <asp:Panel ID="pnlActDeact" runat="server" CssClass="InVisible" meta:resourcekey="pnlActDeactResource1">
                        <fieldset id="fsActDeact" runat="server" style="margin: 5px">
                            <legend>
                                <asp:Label ID="lblActDeactTitle" runat="server" Text="Active/Deactive Class" meta:resourceKey="lblActDeactTitleResource1"></asp:Label>
                            </legend>
                            <table cellspacing="1" style="margin: 5px">
                                <tr>
                                    <td>
                                        <asp:Label ID="lblActionActDis" runat="server" Text="Please Select Action:" meta:resourceKey="lblActionActDisResource1"></asp:Label>
                                        <asp:RadioButton ID="rbActive" runat="server" Text="Active" GroupName="ActDeact"
                                            Checked="True" meta:resourceKey="rbActiveResource1" />
                                        <asp:RadioButton ID="rbDeactive" runat="server" Text="Deactive" GroupName="ActDeact"
                                            meta:resourceKey="rbDeactiveResource1" />
                                    </td>
                                    <td>
                                        <asp:Button ID="btnActDeactSub" runat="server" Text="Submit" CssClass="gobutton"
                                            OnClick="btnActDeactSub_Click" meta:resourceKey="btnActDeactSubResource1" />
                                    </td>
                                </tr>
                            </table>
                        </fieldset>
                    </asp:Panel>
                    <asp:Panel ID="pnlRejApp" runat="server" CssClass="InVisible" meta:resourcekey="pnlRejAppResource1">
                        <fieldset id="fsApprReject" runat="server" style="margin: 5px">
                            <legend>
                                <asp:Label ID="lblAppRejTitle" runat="server" Text="Approve/Reject Class" meta:resourceKey="lblAppRejTitleResource1"></asp:Label>
                            </legend>
                            <table cellspacing="1" style="margin: 5px">
                                <tr>
                                    <td>
                                        <asp:Label ID="lblAppRej" runat="server" Text=" Please Select Action:" meta:resourceKey="lblAppRejResource1"></asp:Label>
                                        <asp:RadioButton ID="rbApprove" runat="server" Text="Approve" GroupName="AppReje"
                                            Checked="True" meta:resourceKey="rbApproveResource1" />
                                        <asp:RadioButton ID="rbReject" runat="server" Text="Reject" GroupName="AppReje" meta:resourceKey="rbRejectResource1" />
                                    </td>
                                    <td>
                                        <asp:Button ID="btnAppRejSubmit" runat="server" Text="Submit" OnClick="btnAppRejSubmit_Click"
                                            meta:resourceKey="btnAppRejSubmitResource1" CssClass="gobutton" />
                                    </td>
                                </tr>
                            </table>
                        </fieldset>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="gvSchoolRegistrationBMSdetail" runat="server" AllowPaging="True"
                        DataKeyNames="SchoolBMSID,SchoolTypeID,BMSID,SchoolID,NoOfStudents,StartTime,EndTime,StatusID,Status"
                        OnPageIndexChanging="gvSchoolRegistrationBMSdetail_PageIndexChanging" EmptyDataText="No Data Found."
                        AllowSorting="True" OnRowCreated="gvEmpStdSubAllocationDetails_RowCreated" OnSorting="gvEmpStdSubAllocationDetails_Sorting"
                        meta:resourcekey="gvSchoolRegistrationBMSdetailResource1">
                        <Columns>
                            <asp:TemplateField meta:resourcekey="TemplateFieldResource1">
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
                            <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" meta:resourcekey="BoundFieldResource8" />
                        </Columns>
                        <PagerTemplate>
                            <asp:ImageButton Text="First" CommandName="Page" CommandArgument="First" runat="server"
                                ImageUrl="~/App_Themes/Images/first.png" ID="ibtnFirst" meta:resourcekey="ibtnFirstResource1"
                                ToolTip="Move First Page" />
                            <asp:ImageButton Text="Previous" CommandName="Page" CommandArgument="Prev" runat="server"
                                ImageUrl="~/App_Themes/Images/previous.png" ID="ibtnPrevious" meta:resourcekey="ibtnPreviousResource1"
                                ToolTip="Move Previous Page" />
                            <asp:Label ID="lblGoPage" runat="server" Text="Goto Page" meta:resourcekey="lblGoPageResource1"
                                ForeColor="Black"></asp:Label>
                            <asp:DropDownList ID="ddlPageSelector" OnSelectedIndexChanged="ddlPageSelector_SelectedIndexChanged"
                                runat="server" AutoPostBack="True" meta:resourcekey="ddlPageSelectorResource1">
                            </asp:DropDownList>
                            <asp:ImageButton Text="Next" CommandName="Page" CommandArgument="Next" runat="server"
                                ImageUrl="~/App_Themes/Images/NEXT.png" ID="ibtnNext" meta:resourcekey="ibtnNextResource1"
                                ToolTip="Move Next Page" />
                            <asp:ImageButton Text="Last" CommandName="Page" CommandArgument="Last" runat="server"
                                ToolTip="Move Last Page" ImageUrl="~/App_Themes/Images/last.png" ID="ibtnLast"
                                meta:resourcekey="ibtnLastResource1" />
                        </PagerTemplate>
                    </asp:GridView>
                </td>
            </tr>
        </table>
        <table width="100%">
            <tr>
                <td align="center">
                    <asp:Button ID="btnClose" runat="server" CssClass="gobutton" Text="Close" meta:resourcekey="btnCloseResource1"
                        OnClick="btnClose_Click" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
