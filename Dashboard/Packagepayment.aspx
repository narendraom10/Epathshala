<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Epathshala.master" AutoEventWireup="true"
    CodeFile="Packagepayment.aspx.cs" Inherits="Dashboard_Packagepayment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .inline-rb input[type="radio"]
        {
            width: auto;
        }
        
        .inline-rb label
        {
            padding-bottom: 10px;
            padding-left: 5px;
        }
        
        
        label
        {
            display: inline-block;
            padding-left: 10px !important;
        }
        #header1
        {
            width: 600px;
            background-color: #3A3D91;
            border-color: #3db5d8;
            color: #fff;
        }
        
        #section
        {
            width: 350px;
        }
        .panel1
        {
            width: 598px;
            border-top: 1px solid #3A3D91;
            border-left: 1px solid #3A3D91;
            border-bottom: 1px solid #3A3D91;
            border-right: 1px solid #3A3D91;
            background-color: white;
        }
        .trlable
        {
            width: 25%;
            height: 41px;
            text-align: right;
            padding-right: 10px;
            padding-bottom: 5px;
            vertical-align: top;
        }
        
        .trcontrol
        {
            width: 70%;
            height: 41px;
            padding-bottom: 10px;
            padding-left: 5px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div align="center">
        <div id="header1">
            <h2>
                Payment Details
            </h2>
        </div>
        <div class="panel1">
            <table>
                <%--    <tr>
                    <td>
                        <asp:Label ID="lblpaymenttype" runat="server" Text="Payment Type"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlpaymenttype" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlpaymenttype_SelectedIndexChanged">
                            <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                            <asp:ListItem Text="NB Tansfer" Value="NBFundTransfer"></asp:ListItem>
                            <asp:ListItem Text="CC Transfer" Value="CCFundTransfer"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>--%>
                <tr>
                    <td class="trlable">
                        <br />
                        <asp:Label ID="lblamt" runat="server" Text="Amount:"></asp:Label>
                    </td>
                    <td class="trcontrol">
                        <br />
                        <asp:TextBox ID="txtamt" runat="server" ReadOnly="True" CssClass="textBoxCls" Width="200px"></asp:TextBox>
                        <br />
                        <br />
                    </td>
                </tr>
                <tr>
                    <td class="trlable">
                        <asp:Label ID="lbltransactiontype" runat="server" Text="Transaction Type:"></asp:Label>
                    </td>
                    <td class="trcontrol">
                        <asp:RadioButtonList ID="rblfieldvalue" runat="server" RepeatDirection="Vertical"
                            CssClass="inline-rb">
                            <asp:ListItem Text="Net Banking" Value="NB" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="Credit Card" Value="CC"></asp:ListItem>
                            <asp:ListItem Text="Debit Card" Value="DC"></asp:ListItem>
                            <asp:ListItem Text="IMPS" Value="IMPS"></asp:ListItem>
                            <asp:ListItem Text="American Express" Value="AMEX"></asp:ListItem>
                            <asp:ListItem Text="Visa Debit Card" Value="VISADC"></asp:ListItem>
                            <asp:ListItem Text="Atom Prepaid Wallet" Value="WALLET"></asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:CheckBox ID="chkcheck" runat="server" 
                            Text="   I have read and agree to the Terms & Conditions." AutoPostBack="True" 
                            oncheckedchanged="chkcheck_CheckedChanged" />
                    </td>
                </tr>
                <%--<tr>
                    <td colspan="2">
                        <asp:Panel ID="pnlacknowledgement" runat="server">
                            I HAVE READ AND UNDERSTAND THIS AGREEMENT, AND I ACCEPT AND AGREE TO ALL OF ITS
                            TERMS AND CONDITIONS. I ENTER INTO THIS AGREEMENT VOLUNTARILY, WITH FULL KNOWLEDGE
                            OF ITS EFFECT.
                        </asp:Panel>
                    </td>
                </tr>--%>
            </table>
            <asp:Button runat="server" Text="Pay" ID="btnpay" OnClick="btnpay_Click" />
        </div>
        <asp:Panel ID="pnlpackageconfirmation" runat="server">
            <asp:Label ID="lblpackageconfirmation" runat="server"></asp:Label>
        </asp:Panel>
    </div>
    <%--  <br />
    <br />--%>
    <div>
        <table width="100%">
            <tr>
                <td style="padding-left: 370PX; font-weight: bold;">
                    We Accept:
                </td>
            </tr>
            <tr align="center">
                <td colspan="5" style="width: 100%;" align="center" valign="bottom" width="40%">
                    <%--    <img src="../App_Themes/Responsive/PaymentType/netbanking.png" />
                    <img src="../App_Themes/Responsive/PaymentType/images.png" 
                        style="height: 53px" />&nbsp;
                    <img src="../App_Themes/Responsive/PaymentType/amex.png" style="width: 51px" />--%>
                    <%-- <img src="../App_Themes/Responsive/PaymentType/index.jpg" 
                        style="width: 362px; height: 67px" />--%>
                    <%--  <img src="../App_Themes/Responsive/PaymentType/All.jpg" 
                        style="width: 448px; height: 67px"/>
                    <img src="../App_Themes/Responsive/PaymentType/new.jpg"  
                        style="width: 75px; height: 67px"/>
                    <img src="../App_Themes/Responsive/PaymentType/netbanking.png" style="height: 67px"/>--%>
                    <img src="../App_Themes/Responsive/PaymentType/AllInOne1.png" style="width: 597px"
                        alt="Payment Type" />
                </td>
            </tr>
        </table>
    </div>
    <div>
        <table width="100%">
            <tr align="center">
                <td colspan="5" style="width: 100%; background-color: #333;" align="center" valign="bottom"
                    width="40%">
                    <a href="PrivacyPolicy.htm" target="_blank" style="color: #FFFFFF">Privacy Policy</a>
                    | <a href="TermsAndCondition.htm" target="_blank" style="color: #FFFFFF">Terms &amp;
                        Condition</a> | <a href="CancellationPolicy.htm" target="_blank" style="color: #FFFFFF">
                            Cancellation Policy</a>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
