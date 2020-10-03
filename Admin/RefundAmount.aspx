<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Epathshala.master" AutoEventWireup="true"
    EnableEventValidation="false" CodeFile="RefundAmount.aspx.cs" Inherits="Admin_RefundAmount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../style.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .hidevalue
        {
            visibility: hidden;
            display: none;
        }
        
        .GridViewItem:Hover
        {
            cursor: pointer;
        }
        
        .textbox
        {
        }
        
        .textbox1
        {
        }
        .style1
        {
            height: 59px;
        }
       
    </style>
    <script language="javascript" type="text/javascript">
        var oldgridSelectedColor;

        function setMouseOverColor(element) {
            debugger
            oldgridSelectedColor = element.style.backgroundColor;
            // element.style.textDecoration = 'underline';
        }

        function setMouseOutColor(element) {
            element.style.backgroundColor = oldgridSelectedColor;
            element.style.textDecoration = 'none';
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="wrap">
        <div id="accordian">
            <div class="step" id="step1">
                <div class="title">
                    <h1>
                        All Transaction</h1>
                </div>
            </div>
            <div class="content" id="dvalltransaction">
                <div style="width: 98%; margin: 10px;">
                    <asp:GridView ID="gvalltransaction" runat="server" AutoGenerateColumns="false" OnSelectedIndexChanged="gvalltransaction_SelectedIndexChanged"
                        OnRowDataBound="gvalltransaction_RowDataBound">
                        <Columns>
                            <asp:BoundField DataField="Name" HeaderText="Student Name" />
                            <asp:BoundField DataField="PackageName" HeaderText="Package Name" />
                            <asp:BoundField DataField="BMS" HeaderText="Board Medium Standard" />
                            <asp:BoundField DataField="Price" HeaderText="Amount" ItemStyle-HorizontalAlign="Right" />
                            <asp:BoundField DataField="CreatedOn" HeaderText="Purchase Date" DataFormatString="{0:dd MMM, yyyy}" />
                            <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblTransactionid" runat="server" Text='<%#Eval("TransactionID")%>'
                                        CssClass="hidevalue"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblpackageid" runat="server" Text='<%#Eval("PackageID") %>' CssClass="hidevalue"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblinvoiceid" runat="server" Text='<%#Eval("InvoiceID") %>' CssClass="hidevalue"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblstatus" runat="server" Text='<%#Eval("Status") %>' CssClass="hidevalue"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblATOMTransactionID" runat="server" Text='<%#Eval("ATOMTransactionID") %>'
                                        CssClass="hidevalue"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblproductid" runat="server" Text='<%#Eval("ProductID") %>' CssClass="hidevalue"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblbankname" runat="server" Text='<%#Eval("BankName") %>' CssClass="hidevalue"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblbanktransactionID" runat="server" Text='<%#Eval("BankTransactionID") %>'
                                        CssClass="hidevalue"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblcustomername" runat="server" Text='<%#Eval("CustomerName") %>'
                                        CssClass="hidevalue"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblcustomeremailid" runat="server" Text='<%#Eval("CustomerEmailID") %>'
                                        CssClass="hidevalue"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblcustomermobileno" runat="server" Text='<%#Eval("CustomerMobileNo") %>'
                                        CssClass="hidevalue"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblBillingAddress" runat="server" Text='<%#Eval("BillingAddress") %>'
                                        CssClass="hidevalue"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblEMIMerchantDataBankName" runat="server" Text='<%#Eval("EMIMerchantDataBankName") %>'
                                        CssClass="hidevalue"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblEMITenure" runat="server" Text='<%#Eval("EMITenure") %>' CssClass="hidevalue"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblEchoBankParameter" runat="server" Text='<%#Eval("EchoBankParameter") %>'
                                        CssClass="hidevalue"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblbmsid" runat="server" Text='<%#Eval("BMSID") %>' CssClass="hidevalue"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblsubjects" runat="server" Text='<%#Eval("Subject") %>' CssClass="hidevalue"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblNoOfMonth" runat="server" Text='<%#Eval("NoOfMonth") %>' CssClass="hidevalue"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblvalidfrom" runat="server" Text='<%#Eval("FromDate") %>' CssClass="hidevalue"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblvalidtill" runat="server" Text='<%#Eval("ValidTill") %>' CssClass="hidevalue"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
            <div class="step" id="step2" runat="server" visible="false">
                <div class="title">
                    <h1>
                        Detail Information</h1>
                </div>
            </div>
            <div class="content" runat="server" visible="false" id="dvdetailcontent">
                
                <table>
                    <tr>
                        <td>
                            <asp:Literal ID="ltcontent" runat="server"></asp:Literal>
                            <br />
                        </td>
                    </tr>
                 
                </table>
                <div style="margin-bottom:20px;" align="center">
                    <asp:Button ID="btnrefund" runat="server" Text="Send Request For Refund" 
                        onclick="btnrefund_Click1" />
                </div>
                <%--<table cellspacing="10" cellpadding="5" style="width: 98%; margin: 10px;">
                    <tr>
                        <td>
                            <asp:Label ID="lblstudentname" runat="server" Text="Student Name:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtstudentname" Width="200px" CssClass="textbox1"
                                Height="15px" ReadOnly="True" Font-Size="15px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="lblpackagename" runat="server" Text="Package Name:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtpackagename" Width="200px" CssClass="textbox"
                                Height="15px" ReadOnly="True" Font-Size="15px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="lblamt" runat="server" Text="Amount:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtamount" Width="200px" Height="15px" 
                                Font-Size="15px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style1">
                            <asp:Label ID="lblmerchanttxnID" runat="server" Text="Merchant Transaction ID:"></asp:Label>
                        </td>
                        <td class="style1">
                            <asp:TextBox runat="server" ID="txtmerchanttxnID" Width="200px" CssClass="textbox"
                                Height="15px" ReadOnly="True" Font-Size="15px"></asp:TextBox>
                        </td>
                        <td class="style1">
                            <asp:Label ID="lblatomtransactionID" runat="server" Text="Atom Transaction ID:"></asp:Label>
                        </td>
                        <td class="style1">
                            <asp:TextBox runat="server" ID="txtatomtxnid" Width="200px" CssClass="textbox" Height="15px"
                                ReadOnly="True" Font-Size="15px"></asp:TextBox>
                        </td>
                        <td class="style1">
                            <asp:Label ID="lblbanktransactionID" runat="server" Text="Bank TransactionID:"></asp:Label>
                        </td>
                        <td class="style1">
                            <asp:TextBox runat="server" ID="txtbanktransactionID" Width="200px" CssClass="textbox"
                                Height="15px" ReadOnly="True" Font-Size="15px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblbankname" runat="server" Text="Bank Name:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtbankname" Width="200px" CssClass="textbox" Height="15px"
                                ReadOnly="True" Font-Size="14px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="lblEMIMerchantDataBankName" runat="server" Text="EMI Merchant Data Bank Name:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtEMIMerchantDataBankName" Width="200px" CssClass="textbox"
                                Height="15px" ReadOnly="True" Font-Size="14px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="lblEMITenure" runat="server" Text="EMI Tenure:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtEMITenure" Width="200px" CssClass="textbox" Height="15px"
                                ReadOnly="True" Font-Size="14px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblcustomername" runat="server" Text="Customer Name:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtcustomername" Width="200px" CssClass="textbox"
                                Height="15px" ReadOnly="True" Font-Size="14px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="lblcustomeremailid" runat="server" Text="Customer EmailID:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtcustomeremailid" Width="200px" CssClass="textbox"
                                Height="15px" ReadOnly="True" Font-Size="14px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="lblcustomermobilenumber" runat="server" Text="Customer Mobile Number:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtcustomermobilenumber" Width="200px" CssClass="textbox"
                                Height="15px" ReadOnly="True" Font-Size="14px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                    
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblcreatedon" runat="server" Text="Payment Date:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtcreatedon" Width="200px" CssClass="textbox" Height="15px"
                                ReadOnly="True" Font-Size="15px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="lblvalidfrom" runat="server" Text="Valid From:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtvalidfrom" Width="200px" CssClass="textbox" Height="15px"
                                ReadOnly="True" Font-Size="15px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="lblvalidtill" runat="server" Text="Valid Till:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtvalidtill" Width="200px" CssClass="textbox" Height="15px"
                                ReadOnly="True" Font-Size="15px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblsubject" runat="server" Text="Subject:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtsubject" Width="200px" CssClass="textbox" Height="15px"
                                ReadOnly="True" Font-Size="15px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="lblnoofmonth" runat="server" Text="No Of Days:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtnoofmonth" Width="200px" CssClass="textbox" Height="15px"
                                ReadOnly="True" Font-Size="15px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6" align="center">
                            <br />
                            <asp:Button ID="btnrefund" runat="server" Text="Send Request For Refund" ValidationGroup="Refund" />
                        </td>
                    </tr>
                </table> --%>
            </div>
        </div>
    </div>
</asp:Content>
