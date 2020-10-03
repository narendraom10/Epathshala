<%@ Page Language="C#" AutoEventWireup="true" CodeFile="License.aspx.cs" Inherits="Dashboard_License" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href='http://fonts.googleapis.com/css?family=Roboto:400,300,500,700' rel='stylesheet'
        type='text/css'>
    <title>ePathshala</title>
    <style type="text/css">
        .BodyHead
        {
            min-width: 145px;
            max-width: 145px;
            margin: 20px auto 0 auto;
        }
        .PunchLine
        {
            margin: 0 0 1% 50%;
            max-width: 185px;
            min-width: 185px;
        }
        
        body
        {
            font-family: 'Roboto-Light' , serif;
        }
        
        input
        {
            min-height: 25px;
            letter-spacing: 0.1em;
            padding: 0 3px;
        }
        
        .Container
        {
            margin-top: 10px;
            min-width: 320px;
            max-width: 480px;
            width: 100%;
            clear: both;
        }
        
        .Label
        {
            font-weight: bold;
            max-width: 51px;
            min-width: 51px;
            padding: 5px;
            float: left;
            line-height: 30px;
            vertical-align: middle;
            color: #fff;
            font-size: 1.20em;
            font-weight: 400;
        }
        
        .Control
        {
            padding: 5px;
            float: left;
            line-height: 30px;
            vertical-align: middle;
        }
        
        
        #License
        {
            min-width: 320px;
            max-width: 480px;
            width: 100%;
            margin: 2% auto 0 auto;
            border-radius: 4px;
            background-color: #4b4fd7;
            box-shadow: 1px 1px 2px #444;
            padding: 10px 0;
        }
        
        .MainTableReg
        {
            margin: auto;
            vertical-align: top;
            min-width: 320px;
            max-width: 480px;
            width: 100%;
            text-align: center;
            font-size: 1.95em;
            background-color: #4b4fd7;
            border-radius: 4px;
            color: #fff;
        }
        
        #lblTitle
        {
            font-weight: 300;
            border-bottom: 1px solid #fff;
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
    <form id="form1" runat="server">
    <div>
        <div class="PageHeading">
            <div class="BodyHead">
                <img src="../App_Themes/Responsive/web/logo.png" alt="Epathshala Logo" />
            </div>
            <div class="PunchLine" style="display: none;">
                <img src="../App_Themes/Responsive/web/tagline.gif" alt="Learning in the cloud." />
            </div>
        </div>
        <hr />
        <div id="License">
            <div class="MainTableReg">
                <asp:Label ID="lblTitle" runat="server" Text="License your product"></asp:Label>
            </div>
            <div class="Container">
                <div class="Label">
                    <asp:Label ID="lblCode" runat="server" Text="Code:"></asp:Label>
                </div>
                <div class="Control">
                    <asp:TextBox ID="txtCode1" runat="server" Width="50px" MaxLength="5"></asp:TextBox>
                    <asp:TextBox ID="txtCode2" runat="server" Width="120px" MaxLength="10"></asp:TextBox>
                    <asp:Button ID="btnSendEmail" runat="server" Text="Send Email" OnClick="btnSendEmail_Click" />
                </div>
            </div>
            <div class="Container">
                <div class="Label">
                    <asp:Label ID="lblKey" runat="server" Text="Key:"></asp:Label>
                </div>
                <div class="Control">
                    <asp:TextBox ID="txtKey" runat="server" MaxLength="48" TextMode="MultiLine" Width="395px"
                        Rows="4"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="ReqValKey" ValidationGroup="License" Text="." ControlToValidate="txtKey"
                        runat="server" ErrorMessage="Key is required."></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="Container">
                <div class="Label">
                </div>
                <div class="Control">
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" ValidationGroup="License"
                        OnClick="btnSubmit_Click" />
                </div>
            </div>
            <div class="Container">
                <div class="Label">
                </div>
                <div class="Control">
                    <asp:ValidationSummary ID="vsLicense" ValidationGroup="License" runat="server" />
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
