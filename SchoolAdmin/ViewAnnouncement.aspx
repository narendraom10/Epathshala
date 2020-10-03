<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewAnnouncement.aspx.cs"
    Inherits="SchoolAdmin_ViewAnnouncement_" MasterPageFile="~/MasterPage/Epathshala.master"
    Culture="auto" meta:resourcekey="PageResource2" UICulture="auto" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit.HTMLEditor"
    TagPrefix="cc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        var TotalChkBx;
        var Counter;

        Counter = 0;


        function SelectAll(CheckBox) {

            var TargetBaseControl = document.getElementById('<%= this.gvAnnouncementDetails.ClientID %>');

            var TargetChildControl = "chkSelect";
            var Inputs = TargetBaseControl.getElementsByTagName("input");
            for (var n = 0; n < Inputs.length; ++n)
                if (Inputs[n].type == 'checkbox')
                    Inputs[n].checked = CheckBox.checked;
            Counter = CheckBox.checked ? TotalChkBx : 0;
        }

        function ChildClick(CheckBox) {

            TotalChkBx = parseInt('<%= this.gvAnnouncementDetails.Rows.Count %>');

            var HeaderCheckBox = document.getElementById('ctl00_ContentPlaceHolder1_gvAnnouncementDetails_ctl01_chkheader');
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
    <div class="tblDashboard1">
        <div class="firstpanel">
            <div class="activitydivfull">
                <div class="ActivityHeader">
                    <asp:Label ID="lblTitle" runat="server" Text="Announcement Management" meta:resourcekey="lblTitleResource1"></asp:Label>
                </div>
                <div class="ActivityContent">
                    <div>
                        <ul class="standarbtn">
                            <li class="standarbar">
                                <asp:ImageButton ID="ibtnSearch" runat="server" ImageUrl="~/App_Themes/Responsive/web/searchuser.png"
                                    ToolTip="Search" OnClick="ibtnSearch_Click" meta:resourcekey="ibtnSearchResource1" /></li>
                            <li class="standarbar">
                                <asp:ImageButton ID="ibtnRefresh" runat="server" ImageUrl="~/App_Themes/Responsive/web/rectreload.png"
                                    CausesValidation="False" ToolTip="Refresh" OnClick="ibtnRefresh_Click" meta:resourcekey="ibtnRefreshResource1" />
                            </li>
                            <li class="standarbar">
                                <asp:ImageButton ID="ibtnAddAnnouncement" runat="server" Text="Add New Announcement"
                                    ImageUrl="~/App_Themes/Responsive/web/plus.png" ToolTip="Add New Announcement"
                                    OnClick="ibtnAddAnnouncement_Click" meta:resourcekey="ibtnAddAnnouncementResource1" />
                            </li>
                            <li class="standarbar">
                                <asp:ImageButton ID="ibtnEditAnnouncement" ImageUrl="~/App_Themes/Responsive/web/edit.png"
                                    runat="server" ToolTip="Edit Announcement" OnClick="ibtnEditAnnouncement_Click"
                                    meta:resourcekey="ibtnEditAnnouncementResource1" />
                            </li>
                            <li class="standarbar">
                                <asp:ImageButton ID="ibtnDelete" runat="server" Text="Remove Announcement" ImageUrl="~/App_Themes/Responsive/web/close.png"
                                    ToolTip="Remove Announcement" OnClick="ibtnDelete_Click" meta:resourcekey="ibtnDeleteResource1" />
                            </li>
                        </ul>
                    </div>
                    <div>
                        <asp:UpdatePanel ID="UpdPnlSchoolDetails" runat="server">
                            <Triggers>
                                <asp:PostBackTrigger ControlID="btnAdd" />
                                <asp:PostBackTrigger ControlID="btnUpdate" />
                                <asp:PostBackTrigger ControlID="ddlBoardMediumStandard" />
                            </Triggers>
                            <ContentTemplate>
                                <div id="tblgv">
                                    <asp:Panel ID="pnlSearch" runat="server" meta:resourcekey="pnlSearchResource1">
                                        <div class="subheaduserdetail">
                                            <asp:Label ID="lblAnnouncementTitle" runat="server" CssClass="SubTitle" Text="Announcement"
                                                meta:resourcekey="lblAnnouncementTitleResource1"></asp:Label>
                                        </div>
                                        <div class="ActivityContent">
                                            <div style="clear:both; display:inline-block; width:100%;">
                                                <asp:Label ID="lblBoardMediumStandard" runat="server" Text="BMS:" CssClass="textlabel"
                                                    ToolTip="Borad/Medium/Standard" meta:resourcekey="lblBoardMediumStandardResource1"></asp:Label>
                                                <asp:DropDownList ID="ddlBoardMediumStandard" runat="server" CssClass="controllabel1"
                                                    OnSelectedIndexChanged="ddlBoardMediumStandard_SelectedIndexChanged" AutoPostBack="True"
                                                    meta:resourcekey="ddlBoardMediumStandardResource1">
                                                </asp:DropDownList>
                                            </div>
                                            <div style="clear: both;display:inline-block;width:100%">
                                                <asp:Label ID="lblDivision" Text="Division:" CssClass="textlabel" runat="server"
                                                    meta:resourcekey="lblDivisionResource1"></asp:Label>
                                                <asp:CheckBoxList ID="clstDivision" runat="server" RepeatDirection="Horizontal" RepeatColumns="4"
                                                    CssClass="chkChoice" meta:resourcekey="clstDivisionResource1">
                                                </asp:CheckBoxList>
                                            </div>
                                            <div style="clear: both;display:inline-block; width:100%">
                                                <asp:Label ID="lblStartDate" runat="server" Text="Start Date:" CssClass="textlabel"
                                                    meta:resourcekey="lblStartDateResource1"></asp:Label>
                                                <asp:TextBox ID="txtStartDate" runat="server" CssClass="controllabel1" meta:resourcekey="txtStartDateResource1"></asp:TextBox>
                                                <div style="padding:2px; background-color:#444; width:20px; height:20px; display:inline-block; margin-left:4px; border-radius:4px;">
                                                <asp:ImageButton ID="ibtnStartDate" runat="server" ImageUrl="~/App_Themes/Responsive/web/calender.png"
                                                    Width="20px" meta:resourcekey="ibtnStartDateResource1" />
                                                </div>
                                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtStartDate"
                                                    PopupButtonID="ibtnStartDate" Enabled="True" Format="dd-MMM-yyyy">
                                                </cc1:CalendarExtender>
                                            </div>
                                            <div style="clear: both; display:inline-block; width:100%">
                                                <asp:Label ID="lblEndDate" runat="server" Text="End Date:" CssClass="textlabel" meta:resourcekey="lblEndDateResource1"></asp:Label>
                                                <asp:TextBox ID="txtEndDate" runat="server" CssClass="controllabel1" meta:resourcekey="txtEndDateResource1"></asp:TextBox>
                                                <div style="padding:2px; background-color:#444; width:20px; height:20px; display:inline-block; margin-left:4px; border-radius:4px;">
                                                <asp:ImageButton ID="ibtnEndDate" runat="server" ImageUrl="~/App_Themes/Responsive/web/calender.png"
                                                    Width="20px" meta:resourcekey="ibtnEndDateResource1" />
                                                </div>
                                                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtEndDate"
                                                    PopupButtonID="ibtnEndDate" Enabled="True" Format="dd-MMM-yyyy">
                                                </cc1:CalendarExtender>
                                            </div>
                                            <div style="clear: both;display:inline-block; width:100%">
                                                <asp:Label ID="lblAnnouncement" runat="server" Text="Announcement:" CssClass="textlabel"
                                                    meta:resourcekey="lblAnnouncementResource1" Style="width: 110px;"></asp:Label>
                                                <cc2:Editor ID="edtAnnouncement" runat="server" CssClass="controllabel1"  Visible="False"
                                                    meta:resourcekey="edtAnnouncementResource1"  />
                                                <asp:TextBox ID="txtSearchAnnouncement" runat="server" TextMode="MultiLine" meta:resourcekey="txtSearchAnnouncementResource1"></asp:TextBox>
                                            </div>
                                            <div class="gobotton" style="margin-left:105px;">
                                                <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" Visible="False"
                                                    meta:resourcekey="btnAddResource1" />
                                                <asp:Button ID="btnUpdate" runat="server" Text="Update" Visible="False" OnClick="btnUpdate_Click"
                                                    meta:resourcekey="btnUpdateResource1" />
                                                <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click"
                                                    meta:resourcekey="btnSearchResource2" />
                                                <asp:Button ID="btnReset" runat="server" Text="Reset" OnClick="btnReset_Click" meta:resourcekey="btnResetResource1" />
                                            </div>
                                        </div>
                                    </asp:Panel>
                                    <div style="clear:both;">
                                        <asp:GridView ID="gvAnnouncementDetails" runat="server" AutoGenerateColumns="False"
                                            DataKeyNames="Announcement,AnnouncementID,StartDate,EndDate,BMSID,DivisionID"
                                            EmptyDataText="No Records Found" OnPageIndexChanging="gvAnnouncementDetails_PageIndexChanging"
                                            OnRowCreated="gvAnnouncementDetails_RowCreated" OnSorting="gvAnnouncementDetails_Sorting"
                                            meta:resourcekey="gvAnnouncementDetailsResource1">
                                            <Columns>
                                                <asp:TemplateField meta:resourcekey="TemplateFieldResource1">
                                                    <HeaderTemplate>
                                                        <table>
                                                            <tr>
                                                                <td align="center">
                                                                    <asp:CheckBox ID="chkheader" runat="server" meta:resourcekey="chkheaderResource1"
                                                                        onclick="javascript:SelectAll(this);" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <table>
                                                            <tr>
                                                                <td>
                                                                    <asp:CheckBox ID="chkSelect" runat="server" meta:resourcekey="chkSelectResource1"
                                                                        onclick="javascript:ChildClick(this);" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </ItemTemplate>
                                                    <HeaderStyle Width="10px" />
                                                    <ItemStyle Width="10px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sr. No" meta:resourcekey="TemplateFieldResource2">
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex +1 %>
                                                    </ItemTemplate>
                                                    <HeaderStyle Width="10px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Board>>Medium>>Standard" SortExpression="BMS" meta:resourcekey="TemplateFieldResource3">
                                                    <ItemTemplate>
                                                        <asp:Label ID="gvlblBMS" runat="server" Text='<%# Eval("BMS") %>' meta:resourcekey="gvlblBMSResource1"></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Width="5px" />
                                                    <ItemStyle Width="5px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Division" SortExpression="DivisionName" meta:resourcekey="TemplateFieldResource4">
                                                    <ItemTemplate>
                                                        <asp:Label ID="gvlblDivision" runat="server" Text='<%# Eval("Division") %>' meta:resourcekey="gvlblDivisionResource1"></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Width="10px" />
                                                    <ItemStyle Width="10px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Anouncement" SortExpression="AnnouncementName" meta:resourcekey="TemplateFieldResource5">
                                                    <ItemTemplate>
                                                        <asp:Literal ID="lrAnnouncement" runat="server" Text='<%# Eval("Announcement") %>'></asp:Literal>
                                                    </ItemTemplate>
                                                    <HeaderStyle Wrap="True" />
                                                    <ItemStyle Width="20%" Wrap="True" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Start Date" SortExpression="StartDate" meta:resourcekey="TemplateFieldResource6">
                                                    <ItemTemplate>
                                                        <asp:Label ID="gvlblStartDate" runat="server" Text='<%# string.Format("{0:dd-MMM-yyyy}", Eval("StartDate")) %>'
                                                            meta:resourcekey="gvlblStartDateResource1"></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Width="10px" />
                                                    <ItemStyle Width="10px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="EndDate" SortExpression="EndDate" meta:resourcekey="TemplateFieldResource7">
                                                    <ItemTemplate>
                                                        <asp:Label ID="gvlblEndDate" runat="server" Text='<%# string.Format("{0:dd-MMM-yyyy}", Eval("EndDate")) %>'
                                                            meta:resourcekey="gvlblEndDateResource1"></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Width="10px" />
                                                    <ItemStyle Width="10px" />
                                                </asp:TemplateField>
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
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
