<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PaymentResponseATOM.aspx.cs"
    Inherits="PaymentResponcePage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ePathshala</title>
    <style type="text/css">
        #rcorners2
        {
            border-radius: 25px;
            border: 2px solid #8AC007;
            padding: 20px;
            width: 500px;
            height: 50px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div align="center" style="vertical-align: middle; margin-top: 110px; margin-left: 170px;
        width: 70%">
        <table style="border-width: 1px; height: 167px; width: 70%; border-collapse: collapse;
            border: 1px solid black;">
            
            <tr>
                <td align="left" style="width: 20%; padding-left: 10px; padding-bottom: 30px; padding-top: 20px;">
                    <img src="../App_Themes/Green/Images/logo.png" alt="Epathshala Logo" />
                </td>
                <td align="left" style="width: 80%; padding-left: 50px; padding-bottom: 30px; padding-top: 20px;">
                    <h1>
                        <asp:Label ID="lblthankyou" runat="server" ></asp:Label></h1>
                    <br />
                    <h3>
                        <asp:Label ID="lbltransactionnumber" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label runat="server" ID="lblmessage1"></asp:Label>
                    </h3>
                </td>
            </tr>
            
            <tr align="center">
                <td colspan="2" style="width: 100%; height: 2px;" >
                    Please do not refresh the page or click the "Back" or "Close" button of your browser.
                    <img src="../App_Themes/Responsive/web/v11_wait_bar.gif" height="30px" width="100%"
                        alt="Please wait" />
                </td>
            </tr>
        </table>
    </div>
    </div>
    </form>
</body>
</html>
