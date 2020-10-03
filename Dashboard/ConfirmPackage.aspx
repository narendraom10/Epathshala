<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ConfirmPackage.aspx.cs" Inherits="Dashboard_ConfirmPackage"
    Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" MasterPageFile="~/MasterPage/Epathshala.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        body
        {
            font-family: 'Roboto-Light' , serif;
        }
        
        
        
        .BodyTable
        {
            margin: 10px auto 10px auto;
        }
        
        
        
        .youin
        {
            width: 450px;
            margin: 5% auto 5% auto;
            padding: 10px;
            background-color: #f5f5f5;
            font-weight: 300;
            font-size: 1.05em;
            border-radius: 5px;
            box-shadow: 1px 1px 2px #444;
        }
        .Margin500px
        {
            font-size: 1.45em;
            padding: 5px 10px;
        }
        
        .PackageMessage
        {
            float: left;
            padding: 2px 10px;
        }
        
        #lblYourInfo, #lblStandard
        {
            font-weight: 300;
        }
        
        .help
        {
            float: left;
            margin-bottom: 10px;
        }
        
        
        
        #lnkCombo, #lnksingle
        {
            color: #000;
            float: left;
            padding: 2px 5px;
            margin: 10px;
            text-decoration: underline;
        }
        
        .Margin450px
        {
            margin: 10px auto 0 auto;
            width: 420px;
        }
        
        fieldset
        {
            padding: 5px 10px;
            border-radius: 5px;
        }
        
        .footerMargin
        {
            margin: 10px 10px 10px 10px;
        }
        
        .GridViewCss label
        {
            visibility: hidden;
            display: none;
        }
        
        
        
        .BalloonStyle
        {
            background-color: #D7FAFA;
            color: #C2C2C2;
            overflow: hidden;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="youin">
        <div class="Margin500px">
            <b>
                <asp:Label ID="lblYourInfo" runat="server" Text="You are in:" meta:resourcekey="lblYourInfoResource1"></asp:Label>
                <asp:Label ID="lblStandard" runat="server" meta:resourcekey="lblStandardResource1"></asp:Label>
            </b>
        </div>
        <div class="Margin500px">
        </div>
        <table class="BodyTable">
            <tr>
                <td>
                    <asp:Label ID="lblMsg" runat="server" Text="Please confirm your package to continue your study."
                        meta:resourcekey="lblMsgResource1"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Panel ID="pnlCombo" runat="server" Visible="False" meta:resourcekey="pnlComboResource1">
                        <fieldset>
                            <legend>
                                <asp:Label ID="lblComboLegend" runat="server" CssClass="SubTitle" Text="Your Selected Combo"
                                    meta:resourceKey="lblComboLegendResource1"></asp:Label></legend>
                            <table>
                                <tr>
                                    <td>
                                        <asp:GridView ID="dlCombo" runat="server" AutoGenerateColumns="False" meta:resourceKey="dlComboResource1">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Package Type" meta:resourceKey="TemplateFieldResource1">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblName" runat="server" Text='<%# Eval("Name") %>' meta:resourceKey="lblNameResource1"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Price" meta:resourceKey="TemplateFieldResource2">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblPrice" runat="server" Text='<%# Eval("Price") %>' meta:resourceKey="lblPriceResource1"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="PackageFD_ID" Visible="False" meta:resourceKey="TemplateFieldResource3">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblID" runat="server" Text='<%# Eval("ID") %>' meta:resourceKey="lblIDResource1"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="PriceStyle">
                                        <asp:Label ID="lblComboAmount" runat="server" Text="Total:" meta:resourceKey="lblComboAmountResource1"></asp:Label>
                                        <asp:Label ID="lblComboAmountValue" runat="server" meta:resourceKey="lblComboAmountValueResource1"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="footerMargin">
                                        <asp:Button ID="btnComboSubmit" Text="Submit" runat="server" OnClick="btnComboSubmit_Click"
                                            meta:resourceKey="btnComboSubmitResource1" />
                                        <asp:Button ID="btnComboLogin" Text="Go Back" runat="server" OnClick="btnComboLogin_Click"
                                            meta:resourceKey="btnComboLoginResource1" />
                                    </td>
                                </tr>
                            </table>
                        </fieldset>
                    </asp:Panel>
                    <asp:Panel ID="pnlSingle" runat="server" Visible="False" meta:resourcekey="pnlSingleResource1">
                        <fieldset>
                            <legend>
                                <asp:Label ID="lblLegendSubject" runat="server" CssClass="SubTitle" Text="Your Selected Subject"
                                    meta:resourceKey="lblLegendSubjectResource1"></asp:Label></legend>
                            <table>
                                <tr>
                                    <td>
                                        <asp:GridView ID="gvSubjects" runat="server" AutoGenerateColumns="False" meta:resourceKey="gvSubjectsResource1">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Subject" meta:resourceKey="TemplateFieldResource4">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSubject" runat="server" Text='<%# Eval("Subject") %>' meta:resourceKey="lblSubjectResource1"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Package Type" meta:resourceKey="TemplateFieldResource5">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblName" runat="server" Text='<%# Eval("Name") %>' meta:resourceKey="lblNameResource2"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Price" meta:resourceKey="TemplateFieldResource6">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblPrice" runat="server" Text='<%# Eval("Price") %>' meta:resourceKey="lblPriceResource2"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="PackageFD_ID" Visible="False" meta:resourceKey="TemplateFieldResource7">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblID" runat="server" Text='<%# Eval("ID") %>' meta:resourceKey="lblIDResource2"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="PriceStyle">
                                        <asp:Label ID="lblSubjectAmount" runat="server" Text="Total:" meta:resourceKey="lblSubjectAmountResource1"></asp:Label>
                                        <asp:Label ID="lblSubjectAmountValue" runat="server" meta:resourceKey="lblSubjectAmountValueResource1"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="footerMargin">
                                        <asp:Button ID="btnSubmit" Text="Submit" runat="server" OnClick="btnSubmit_Click"
                                            meta:resourceKey="btnSubmitResource1" />
                                        <asp:Button ID="btnBackToLogin" Text="Go Back " runat="server" OnClick="btnBackToLogin_Click"
                                            meta:resourceKey="btnBackToLoginResource1" />
                                    </td>
                                </tr>
                            </table>
                        </fieldset>
                    </asp:Panel>
                    <asp:Panel ID="pnlselectedpackage" runat="server">
                        <asp:ListView ID="lvCustomers" runat="server" ItemPlaceholderID="itemPlaceHolder1">
                            <LayoutTemplate>
                                <asp:PlaceHolder runat="server" ID="itemPlaceHolder1"></asp:PlaceHolder>
                            </LayoutTemplate>
                            <ItemTemplate>
                                <div>
                                    <div style="display: inline; font-weight: bold; color: Black; padding: 7px;">
                                        <%# Eval("Name") %>
                                    </div>
                                    <div style="display: inline; float: right; padding: 2px; width: 40%;">
                                        <span><b>Login ID:</b> </span>
                                        <%# Eval("NoOfMonths") %><br />
                                    </div>
                                    <div style="display: block; padding: 5px; color: Black;">
                                        <%# Eval("BMS") %>
                                    </div>
                                    <div style="display: block; padding: 0px 0px 7px 7px;">
                                        <%# Eval("Price") %>
                                    </div>
                                    <div style="display: block; padding: 0px 0px 7px 7px;">
                                           <%# Eval("Subject") %>
                                        </div>
                                    </div>
                                </div>
                            </ItemTemplate>
                            <EmptyDataTemplate>
                                <div style="text-align: center;">
                                    No Record Available</div>
                            </EmptyDataTemplate>
                        </asp:ListView>
                    </asp:Panel>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
