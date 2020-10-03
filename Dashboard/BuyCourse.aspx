<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Epathshala.master" AutoEventWireup="true"
    CodeFile="BuyCourse.aspx.cs" Inherits="Dashboard_BuyCourse" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="up1" runat="server">
        <ContentTemplate>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="lblMsg" runat="server" Text="Dear User, Please select your package to continue your study."
                            Visible="False" meta:resourcekey="lblMsgResource1"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnCombo" runat="server" Text="Combo Package" 
                            OnClick="btnCombo_Click" meta:resourcekey="btnComboResource1" />
                        <asp:Button ID="btnSingle" runat="server" Text="Single Package" 
                            OnClick="btnSingle_Click" meta:resourcekey="btnSingleResource1" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:DropDownList ID="ddl" runat="server" meta:resourcekey="ddlResource1">
                            <asp:ListItem Text="-- Select --" Value="0" meta:resourcekey="ListItemResource1"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Panel ID="pnlCombo" runat="server" Visible="False" 
                            meta:resourcekey="pnlComboResource1">
                            <asp:RadioButton ID="rdbSilverCombo" Text="Silver" runat="server" 
                                GroupName="Combo" meta:resourcekey="rdbSilverComboResource1" />
                            <asp:RadioButton ID="rdbGoldCombo" Text="Gold" runat="server" GroupName="Combo" 
                                meta:resourcekey="rdbGoldComboResource1" />
                            <asp:RadioButton ID="rdbPlatinumCombo" Text="Platinum" runat="server" 
                                GroupName="Combo" meta:resourcekey="rdbPlatinumComboResource1" />
                        </asp:Panel>
                        <asp:Panel ID="pnlSingle" runat="server" Visible="False" 
                            meta:resourcekey="pnlSingleResource1">
                            <asp:GridView ID="gvSubjects" runat="server" AutoGenerateColumns="False" 
                                meta:resourcekey="gvSubjectsResource1">
                            </asp:GridView>
                            <asp:RadioButton ID="rdbSilverSingle" Text="Silver" runat="server" 
                                GroupName="Single" meta:resourcekey="rdbSilverSingleResource1" />
                            <asp:RadioButton ID="rdbGoldSingle" Text="Gold" runat="server" 
                                GroupName="Single" meta:resourcekey="rdbGoldSingleResource1" />
                            <asp:RadioButton ID="rdbPlatinumSingle" Text="Platinum" runat="server" 
                                GroupName="Single" meta:resourcekey="rdbPlatinumSingleResource1" />
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnSubmit" Text="Submit" runat="server" 
                            meta:resourcekey="btnSubmitResource1" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
