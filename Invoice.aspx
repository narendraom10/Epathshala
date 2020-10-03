<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Invoice.aspx.cs" Inherits="Invoice"
    Theme="Green" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>ePathshala</title>
    <style type="text/css">
        table
        {
            border-collapse: collapse;
            border: 1px solid black;
        }
        
        .tdstyle
        {
            border-color: #000000;
            border-right-style: solid;
            border-right-width: 1px;
        }
        
        
        .style2
        {
            border-right: 1px solid #000000;
            width: 30%;
            height: 37px;
            border-left-color: #000000;
            border-top-color: #000000;
            border-bottom-color: #000000;
        }
        .style3
        {
            border-right: 1px solid #000000;
            width: 10%;
            height: 37px;
            border-left-color: #000000;
            border-top-color: #000000;
            border-bottom-color: #000000;
        }
        .style4
        {
            width: 30%;
            height: 32px;
        }
        .style5
        {
            width: 10%;
            height: 32px;
        }
        .style6
        {
            width: 29%;
            height: 32px;
        }
        .style7
        {
            border-right: 1px solid #000000;
            width: 29%;
            height: 37px;
            border-left-color: #000000;
            border-top-color: #000000;
            border-bottom-color: #000000;
        }
    </style>
    <script type="text/javascript">
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
    <form id="form1" runat="server" class="container">

    <div class="row" >
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding: 15px; overflow: auto;">
            <div class="col-md-8 col-md-offset-2">
                <table width="100%;" cellpadding="10">
                    <tr style="border-color: #000000; border-bottom-style: solid; border-bottom-width: 1px;">
                        <td style="width: 80%;">
                            <%--<img src="App_Themes/Responsive/web/logo.png" alt="Epathshala logo" id="dvICICIEpath"
                                runat="server" />--%>SWAACADEMY
                        </td>
                        <td align="right" style="width: 20%;">
                            <div align="left">
                                B-13, 13/1 & 14, Electronic Estate,
                                <br />
                                GIDC Sector-25, Ghandinagar-382 024,
                                <br />
                                Gujarat,India.
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <%--<span>Student Name:</span> <u><span style="padding-left: 10px;">Nilofar Dabhi </span></u>--%>
                            <br />
                            <asp:Label ID="lblstudentname" runat="server" Text="Student Name: Nilofar Dabhi"></asp:Label>
                            <br />
                            <table style="border: none; width: 100%;">
                                <tr style="width: 100%;">
                                    <td style="width: 20%;">
                                        <asp:Label ID="lblboard" runat="server" Text="Board: Gujarat Board"></asp:Label>
                                    </td>
                                    <td style="width: 20%;">
                                        <asp:Label ID="lblmideum" runat="server" Text="Medium: Guajati Medium"></asp:Label>
                                    </td>
                                    <td align="right" style="padding-right: 40px;">
                                        <asp:Label ID="lblstandard" runat="server" Text="Standard: Standard 7 (sem - 01)"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <%-- <span>Board:</span> <u><span style="padding-left: 10px;">Gujarat</span> </u><span
                        style="padding-left: 40px;">Midium:</span> <u><span style="padding-left: 10px;">Gujarati
                        </span></u><span style="padding-left: 40px">Standard:</span> <u><span style="padding-left: 10px;">
                            standard 7 (sem-02) </span></u>--%>
                            <br />
                        </td>
                        <td style="min-width=100px;">
                            <asp:Label ID="lblinvoicenumber" runat="server"></asp:Label>
                            <br />
                            <asp:Label ID="lblinvoicedate" runat="server" Text="Invoice Date:"></asp:Label>
                            <%--<span>Invoice Date: </span>23 Apr,2015--%>
                        </td>
                    </tr>
                    <%--<tr>
                <td class="style1">
                </td>
                <td class="style1">
                </td>
            </tr>--%>
                    <tr>
                        <td colspan="2">
                            <div>

                                <style>
                                    #packageDetail *{
                                        padding:5px;
                                    }

                                    #packageDetail tr td:nth-child(4),
                                    #packageDetail tr td:nth-child(5) {
                                        min-width:111px !important; 
                                    }

                                    #packageDetail th {
                                        text-align: center !important;
                                    }

                                    #packageDetail tr td:nth-child(6) {
                                        min-width: 75px !important;
                                    }

                                </style>

                                <table width="100%" style="border-left: 0px solid rgb(0, 0, 0); border-bottom: 0px solid rgb(0, 0, 0);
                                    border-right: 0px solid rgb(0, 0, 0);" id="packageDetail">
                                    <tr style="border-color: #000000; border-bottom-style: solid; border-bottom-width: 1px;">
                                        <th style="border-right: 1px solid #000000; border-left-color: #000000; border-top-color: #000000;
                                            border-bottom-color: #000000;" class="style4">
                                            Package Name
                                        </th>
                                        <th style="border-right: 1px solid #000000; border-left-color: #000000; border-top-color: #000000;
                                            border-bottom-color: #000000;" class="style6">
                                            Subject
                                        </th>
                                        <th style="border-right: 1px solid #000000; border-left-color: #000000; border-top-color: #000000;
                                            border-bottom-color: #000000;" class="style5">
                                            No Of Days
                                        </th>
                                        <th style="border-right: 1px solid #000000; border-left-color: #000000; border-top-color: #000000;
                                            border-bottom-color: #000000;" class="style5">
                                            Valid From
                                        </th>
                                        <th style="border-right: 1px solid #000000; border-left-color: #000000; border-top-color: #000000;
                                            border-bottom-color: #000000;" class="style5">
                                            Valid Till
                                        </th>
                                        <th style="border-right: 1px solid #000000; border-left-color: #000000; border-top-color: #000000;
                                            border-bottom-color: #000000;" class="style5">
                                            Price
                                        </th>
                                    </tr>
                                    <tr>
                                        <td class="style2">
                                            <asp:Label ID="lblpackagename" runat="server"></asp:Label>
                                        </td>
                                        <td class="style7">
                                            <asp:Label ID="lblsubject" runat="server"></asp:Label>
                                        </td>
                                        <td class="style3" align="right" style="padding-right: 4px;">
                                            <asp:Label ID="lblmonth" runat="server"></asp:Label>
                                        </td>
                                        <td class="style3" align="center">
                                            <asp:Label ID="lblfromdate" runat="server"></asp:Label>
                                        </td>
                                        <td class="style3" align="center">
                                            <asp:Label ID="lblvalidtill" runat="server"></asp:Label>
                                        </td>
                                        <td class="style3" align="right">
                                            <asp:Label ID="price" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr style="border-color: #000000; border-top-style: solid; border-top-width: 1px;">
                                        <td colspan="5" align="right" style="border-color: #000000; border-right-style: solid;
                                            border-right-width: 1px;">
                                            <span style="padding-right: 10px;">Total</span>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lbltotal" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="5" align="right" style="border-color: #000000; border-right-style: solid;
                                            border-right-width: 1px;">
                                            <span style="padding-right: 10px;">Discount</span>
                                        </td>
                                        <td align="right">
                                            -&nbsp;
                                            <asp:Label ID="lbldiscount" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="5" align="right" style="border-color: #000000; border-right-style: solid;
                                            border-right-width: 1px;">
                                            <span style="padding-right: 10px;">Tax</span>
                                        </td>
                                        <td align="right">
                                            +&nbsp;
                                            <asp:Label ID="lbltax" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr style="border-color: #000000; border-top-style: solid; border-top-width: 1px;
                                        border-bottom-style: solid; border-bottom-width: 1px;">
                                        <td colspan="5" align="right" style="border-right-style: solid; border-right-width: 1px;
                                            border-right-color: #000000">
                                            <span style="padding-right: 10px;">Grand Total</span>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lblgrandtotal" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="6" style="height: 20%; border-color: #000000; border-bottom-style: solid;
                                            border-bottom-width: 1px;">
                                            <asp:Label ID="lblnumericstring" runat="server"></asp:Label>
                                            <br />
                                            <br />
                                            Thanks for your purchase.
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" style="font-size: 12px">
                                            <u><b><span>Terms and condition</span> </b></u>
                                            <br />
                                            This is computer generated invoice and do not require any stamp or signature.
                                            <br />
                                            The package(s) purchased is/are not transferable and refundable.
                                            <br />
                                            By using our electronic billing service, you accept that you will no longer receive
                                            paper bills or statements.
                                            <br />
                                            Toal payable amount is quoted in Indian Rupees, inclusive of all taxes and any additional
                                            charges.
                                            <br />
                                            Terms and conditions subject to change without any notice.
                                            <br />
                                            If you have any question regarding this invoice, contact shailesh.vaishnav@epath.net.in
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
