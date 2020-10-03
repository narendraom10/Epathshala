<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Announcement.ascx.cs"
    Inherits="UserControl_Announcement" EnableTheming="false" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<table width="100%">
    <tr>
        <td align="right" style="margin-left: 50px; text-align: right;">
            <asp:LinkButton ID="lbtnTitleAnnouncement" runat="server" Text="Manage Announcement"
                OnClick="lbtnTitleAnnouncement_Click" meta:resourcekey="lbtnTitleAnnouncementResource1"></asp:LinkButton>
        </td>
    </tr>
    <tr>
        <td>
            <table style="margin: 0px 0px 0px 5px;">
                <tr>
                    <td style="margin: 0px 0px 0px 5px; text-align: right">
                        <asp:DataList ID="dlAnnouncement" runat="server" meta:resourcekey="dlAnnouncementResource1">
                            <ItemTemplate>
                                <table>
                                    <tr>
                                        <td colspan="2" style="color: Maroon; text-align: left">
                                            <ul type="circle">
                                                <li>
                                                    <asp:Label ID="lblAnnouncementDate" runat="server" Font-Underline="false" Text='<%# string.Format("{0:dd-MMM-yyyy}", Eval("StartDate")) %>'
                                                        meta:resourcekey="lblAnnouncementDateResource1"></asp:Label></li></ul>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" style="text-align: left; color: Gray; padding: 0 0 0 1px">
                                            <asp:Label ID="lblTeacherAnnouncement" runat="server" Text='<% #Limit(Eval("Announcement"),40)%>'
                                                ToolTip='<%#Eval("Announcement") %>'></asp:Label>
                                        </td>
                                    </tr>
                                    <tr style="border: 4px none gray">
                                        <td colspan="2">
                                            <hr />
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:DataList>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td style="text-align: right;">
            <asp:LinkButton ID="lbtnViewAll" runat="server" Text="View All" OnClick="lbtnViewAll_Click"
                Visible="False" meta:resourcekey="lbtnViewAllResource1"></asp:LinkButton>
        </td>
    </tr>
</table>
<asp:Button ID="btnShow" runat="server" Style="display: none;" meta:resourcekey="btnShowResource1" />
<cc1:ModalPopupExtender ID="mdlextViewMore" runat="server" TargetControlID="btnShow"
    BackgroundCssClass="modalBackground" PopupControlID="pnlViewMore" CancelControlID="btnGoHomePage"
    DynamicServicePath="" Enabled="True">
</cc1:ModalPopupExtender>
<asp:Panel ID="pnlViewMore" runat="server" align="center" Width="60%" CssClass="modalPopup4"
    meta:resourcekey="pnlViewMoreResource1">
    <asp:UpdatePanel ID="upViewMore" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table align="center" cellpadding="2" cellspacing="2">
                <tr>
                    <td>
                        <asp:GridView ID="gvAnnouncementDetails" runat="server" AutoGenerateColumns="False"
                            DataKeyNames="Announcement,AnnouncementID,StartDate,EndDate,BMSID,DivisionID"
                            AllowPaging="True" AllowSorting="True" OnPageIndexChanging="gvAnnouncementDetails_PageIndexChanging"
                            OnRowCreated="gvAnnouncementDetails_RowCreated" OnSorting="gvAnnouncementDetails_Sorting"
                            meta:resourceKey="gvAnnouncementDetailsResource1">
                            <Columns>
                                <asp:TemplateField HeaderText="Sr. No" meta:resourceKey="TemplateFieldResource1">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex +1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Board>>Medium>>Standard" SortExpression="BMS" meta:resourceKey="TemplateFieldResource2">
                                    <ItemTemplate>
                                        <asp:Label ID="gvlblBMS" runat="server" Text='<%# Eval("BMS") %>' meta:resourceKey="gvlblBMSResource1"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Division" SortExpression="DivisionName" meta:resourceKey="TemplateFieldResource3">
                                    <ItemTemplate>
                                        <asp:Label ID="gvlblDivision" runat="server" Text='<%# Eval("Division") %>' meta:resourceKey="gvlblDivisionResource1"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Anouncement" SortExpression="AnnouncementName" meta:resourceKey="TemplateFieldResource4">
                                    <ItemTemplate>
                                        <asp:Literal ID="ltrAnnouncement" runat="server" Text='<%# Eval("Announcement") %>'></asp:Literal>
                                    </ItemTemplate>
                                    <HeaderStyle Wrap="True" />
                                    <ItemStyle Width="5%" Wrap="True" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Start Date" SortExpression="StartDate" meta:resourceKey="TemplateFieldResource5">
                                    <ItemTemplate>
                                        <asp:Label ID="gvlblStartDate" runat="server" Text='<%# string.Format("{0:dd-MMM-yyyy}", Eval("StartDate")) %>'
                                            meta:resourceKey="gvlblStartDateResource1"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="EndDate" SortExpression="EndDate" meta:resourceKey="TemplateFieldResource6">
                                    <ItemTemplate>
                                        <asp:Label ID="gvlblEndDate" runat="server" Text='<%# string.Format("{0:dd-MMM-yyyy}", Eval("EndDate")) %>'
                                            meta:resourceKey="gvlblEndDateResource1"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <PagerTemplate>
                                <asp:ImageButton Text="First" CommandName="Page" CommandArgument="First" runat="server"
                                    ImageUrl="~/App_Themes/Images/first.png" ID="ibtnFirst" ToolTip="Move First Page"
                                    meta:resourcekey="ibtnFirstResource1" />
                                <asp:ImageButton Text="Previous" CommandName="Page" CommandArgument="Prev" runat="server"
                                    ImageUrl="~/App_Themes/Images/previous.png" ID="ibtnPrevious" ToolTip="Move Previous Page"
                                    meta:resourcekey="ibtnPreviousResource1" />
                                <asp:Label ID="lblPage" runat="server" Text="Page" meta:resourcekey="lblPageResource1"></asp:Label>
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
        <Triggers>
            <asp:PostBackTrigger ControlID="btnGoHomePage" />
        </Triggers>
    </asp:UpdatePanel>
    <asp:Button ID="btnGoHomePage" runat="server" Text="Go To Home Page" meta:resourceKey="btnGoHomePageResource1" />
</asp:Panel>