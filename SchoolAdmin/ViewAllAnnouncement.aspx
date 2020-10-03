<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewAllAnnouncement.aspx.cs"
    Inherits="SchoolAdmin_ViewAllAnnouncement" Culture="auto" meta:resourcekey="PageResource2"
    UICulture="auto" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        .HiddenCol
        {
            display: none;
        }
    </style>
</head>
<body style="background-color: #fff;">
    <form id="form1" runat="server">
    <div>
        <center>
            <table style="vertical-align: middle; border: 2px solid  #EE9F19; margin: 50px" class="RoundTop">
                <%-- <tr>
                    <td class="PageHeader" align="center">
                        <asp:Label ID="lblTitle" runat="server" Text="All Announcements" CssClass="SubTitle"
                            Font-Bold="true"></asp:Label>
                    </td>
                </tr>--%>
                <tr style="display: none;">
                    <td>
                        <asp:GridView ID="gvAnnouncementDetails" runat="server" AutoGenerateColumns="False"
                            DataKeyNames="Announcement,AnnouncementID,StartDate,EndDate,BMSID,DivisionID"
                            AllowPaging="True" AllowSorting="True" OnPageIndexChanging="gvAnnouncementDetails_PageIndexChanging"
                            OnRowCreated="gvAnnouncementDetails_RowCreated" OnSorting="gvAnnouncementDetails_Sorting"
                            meta:resourcekey="gvAnnouncementDetailsResource1">
                            <Columns>
                                <asp:TemplateField HeaderStyle-CssClass="HiddenCol" meta:resourcekey="TemplateFieldResource1">
                                    <ItemTemplate>
                                        <table width="100%" style="border: 0 none white;">
                                            <tr>
                                                <td style="border: 0 none white;">
                                                    <%# Container.DataItemIndex +1 %>.
                                                    <asp:Literal ID="ltrAnnouncement" runat="server" Text='<%# Eval("Announcement") %>'></asp:Literal>
                                                    <asp:Label ID="lblFor" runat="server" Text=" For Standard:" Font-Bold="True" meta:resourcekey="lblForResource1"></asp:Label>
                                                    <asp:Label ID="lblBMS" runat="server" Text='<%# Eval("BMS") %>' meta:resourcekey="lblBMSResource1"></asp:Label>
                                                    <asp:Label ID="lblDivisionTitle" runat="server" Text="Division:" Font-Bold="True"
                                                        meta:resourcekey="lblDivisionTitleResource1"></asp:Label>
                                                    <asp:Label ID="lblDivision" runat="server" Text='<%# Eval("Division") %>' meta:resourcekey="lblDivisionResource1"></asp:Label><br />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" style="border: 0 none white; width: 10px;">
                                                    <asp:Label ID="lblAnnouncementDate" runat="server" Text="- Date:" Font-Bold="True"
                                                        meta:resourcekey="lblAnnouncementDateResource1"></asp:Label>
                                                    <asp:Label ID="lblDate" runat="server" Text='<%# string.Format("{0:dd-MMM-yyyy}", Eval("StartDate")) %>'
                                                        meta:resourcekey="lblDateResource1"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                        <hr />
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="HiddenCol"></HeaderStyle>
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
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Repeater ID="RepDetails" runat="server">
                            <HeaderTemplate>
                                <table style="border: 1px solid #EE9F19;" cellpadding="0">
                                    <tr style="color: White">
                                        <td colspan="2" class="Header12 GridViewHeadercssTestAssessment RoundTop">
                                            <asp:Label ID="lblAnnTitle" runat="server" Text="All Announcements" meta:resourcekey="lblAnnTitleResource1"></asp:Label>
                                        </td>
                                    </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr style="background-color: #62C5C5">
                                    <td>
                                        <table style="background-color: #EBEFF0; border-top: 1px dotted #EE9F19; width: 100%">
                                            <tr>
                                                <td>
                                                    <%# (Container).ItemIndex + 1%>.
                                                    <asp:Label ID="lblSubject" runat="server" Text='<%# Eval("Announcement") %>' meta:resourcekey="lblSubjectResource1" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 100%;">
                                        <table style="background-color: #EBEFF0; border-top: 1px dotted #EE9F19; border-bottom: 1px solid #EE9F195;
                                            width: 100%">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblAnnouncement" runat="server" Text='<%# Eval("BMS") %>' meta:resourcekey="lblAnnouncementResource1"></asp:Label>
                                                    <asp:Label ID="lblDivision" runat="server" Text='<%# Eval("Division") %>' meta:resourcekey="lblDivisionResource2" />
                                                </td>
                                                <td align="right">
                                                    <asp:Label ID="lblDate" runat="server" Text='<%# string.Format("{0:dd-MMM-yyyy}", Eval("StartDate")) %>'
                                                        meta:resourcekey="lblDateResource2" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        &nbsp;
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Button ID="btnBackHomePage" runat="server" Text="Back To Home Page" CssClass="gobutton"
                            OnClick="btnBackHomePage_Click" meta:resourcekey="btnBackHomePageResource1" />
                    </td>
                </tr>
            </table>
        </center>
    </div>
    </form>
</body>
</html>
