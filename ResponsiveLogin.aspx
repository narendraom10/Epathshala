<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ResponsiveLogin.aspx.cs"
    Inherits="ResponsiveLogin" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ePathshala</title>
    <meta name="viewport" content="width=device-width, initial-scale=1, minimum-scale=1, maximum-scale=1" />
    <style type="text/css">
        body
        {
            font-family: 'Roboto' , serif;
        }
        *
        {
            margin: 0;
            padding: 0;
        }
        
        
        .languageResponsive
        {
            width: 100px;
        }
        
        #loginResponsive
        {
            width: 300px;
            background-color: #AC2B28;
            margin: 150px auto;
            color: #fff;
            padding: 5px;
            height: 290px;
            box-shadow: 1px 1px 2px #444;
        }
        
        #txtUserName, #txtUserPassword
        {
            padding: 4px;
            width: 100%;
        }
        
        #ddlUserType
        {
            padding: 0;
            margin: 0 0 15px 0;
            border: none;
        }
        
        #loginResponsive h4
        {
            font-size: 1.4em;
            font-weight: 400;
            margin: 10px 0 10px 10px;
        }
        
        #loginResponsive .Ulresponsive
        {
            width: 250px;
            height: auto;
            float: right;
            position: relative;
        }
        
        .unResponsive
        {
            height: 30px;
        }
        
        .Ulresponsive li
        {
            width: 200px;
        }
        
        .forgotpwresponsive, .keeplinresponsive
        {
            font-size: 0.95em;
        }
        
        .forgotpwresponsive:hover
        {
            text-decoration: underline;
        }
        
        .forgotpwresponsive, .keeplinresponsive, .submitResponsive
        {
            width: 200px;
            margin: 0 0 5px 50px;
            position: relative;
            float: left;
        }
        
        .submitResponsive #btnGo
        {
            float: left;
            margin-right: 20px;
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
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="languageResponsive">
        <!--<asp:Label ID="lblLanguage" runat="server" Text="Language: "></asp:Label>-->
        <%-- <asp:DropDownList runat="server" ID="ddlLanguage" AutoPostBack="True" SkinID="DdlWidth80"
            meta:resourcekey="ddlLanguageResource1">
            <asp:ListItem Text="English" Value="en-US" Selected="True"></asp:ListItem>
            <asp:ListItem Text="ગુજરાતી" Value="gu-IN"></asp:ListItem>
            <asp:ListItem Text="हिन्दी" Value="hi-IN"></asp:ListItem>
        </asp:DropDownList>--%>
    </div>
    <div id="loginResponsive" style="z-index: 1001; margin: auto;">
        <h4>
            Sign In</h4>
        <ul class="Ulresponsive">
            <%-- <li>
                <asp:Label ID="lblIam" Text="I am" runat="server"></asp:Label>
            </li>
            <li class="unResponsive">
                <asp:DropDownList ID="ddlUserType" runat="server">
                    <asp:ListItem Text="Student" Selected="True" Value="0"></asp:ListItem>
                    <asp:ListItem Text="Teacher" Value="1"></asp:ListItem>
                </asp:DropDownList>
            </li>--%>
            <li>
                <asp:Label ID="lblUserName" runat="server" Text="Username: "></asp:Label>
            </li>
            <li class="unResponsive">
                <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rqdUserName" runat="server" ControlToValidate="txtUsername"
                    ErrorMessage="Please Enter Username." ValidationGroup="Login">*</asp:RequiredFieldValidator>
            </li>
            <li>
                <asp:Label ID="lblUserPassword" runat="server" Text="Password: "></asp:Label></li>
            <li>
                <asp:TextBox ID="txtUserPassword" runat="server" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rqdPassword" runat="server" ControlToValidate="txtUserPassword"
                    ErrorMessage="Please Enter Password." ValidationGroup="TeacherLogin">*</asp:RequiredFieldValidator>
                <asp:ValidationSummary ID="vsumTeacherLogin" runat="server" ValidationGroup="Login"
                    ShowMessageBox="True" ShowSummary="False" />
            </li>
            <li>
                <%--<a href="#" class="go">Go</a>--%>
            </li>
        </ul>
        <div class="keeplinresponsive">
            <%--<input type="checkbox">&nbsp;Keep me logged in</input>--%>
            <asp:CheckBox ID="chkRememberMe" runat="server" Text="Keep me logged in." />
        </div>
        <div class="forgotpwresponsive">
            <%-- <a href="#" style="color: #fff;">Forgot your password ?</a>--%>
            <asp:LinkButton ID="lnkForgetPasssword" Style="color: #fff;" runat="server" Text="Forget your password?"></asp:LinkButton>
        </div>
        <div class="submitResponsive">
            <asp:Button ID="btnGo" runat="server" CssClass="go" Text="GO" ValidationGroup="Login"
                OnClick="btnGo_Click" />
        </div>
    </div>
    <asp:Button ID="btnShow" runat="server" Text="Show Modal Popup" Style="display: none"
        meta:resourcekey="btnShowResource1" />
    <cc1:ModalPopupExtender ID="mp1" runat="server" PopupControlID="pnlSelectBMS" TargetControlID="btnShow"
        BackgroundCssClass="modalBackground" Enabled="True" CancelControlID="btnClose">
    </cc1:ModalPopupExtender>
    <asp:Panel ID="pnlSelectBMS" runat="server" CssClass="modalPopup RoundTop" align="center"
        Style="display: none;" meta:resourcekey="pnlSelectBMSResource1">
        <asp:UpdatePanel ID="upSelectBMS" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <table style="vertical-align: middle;" cellspacing="0" width="100%" class="InnerTableStyle RoundTop tblControls"
                    cellpadding="0" align="center">
                    <tr>
                        <td colspan="2" align="center" class="Header12 GridViewHeadercssTestAssessment RoundTop">
                            <asp:Label ID="Label1" runat="server" Text="Login With" meta:resourcekey="lblBMSResource1"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="right">
                            <asp:Label ID="lblRequiredField" runat="server" Text="* Indicates required field."
                                meta:resourcekey="lblRequiredFieldResource1" ForeColor="Red" Font-Size="8pt"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="Required LoginLabel">
                            <asp:Label ID="lblBoard" runat="server" Text="BMS:" ToolTip="Board/Medium/Standard"
                                meta:resourcekey="lblBoardResource1"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlBoard" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlBoard_SelectedIndexChanged"
                                meta:resourcekey="ddlBoardResource1">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rqdDdlBoard" runat="server" ControlToValidate="ddlBoard"
                                InitialValue="-- Select --" ErrorMessage="Please Select Board." ValidationGroup="PnlBMS"
                                meta:resourcekey="rqdDdlBoardResource1">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="Required LoginLabel">
                            <asp:Label ID="lblSubject" runat="server" Text="Subject:" meta:resourcekey="lblSubjectResource1"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlSubject" runat="server" Enabled="False" meta:resourcekey="ddlSubjectResource1">
                                <asp:ListItem Text="-- Select --" meta:resourcekey="ListItemResource4"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rqdDdlSubject" runat="server" ControlToValidate="ddlSubject"
                                InitialValue="--  Subject --" ErrorMessage="Please Select Subject." ValidationGroup="PnlBMS"
                                meta:resourcekey="rqdDdlSubjectResource1">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="Required LoginLabel">
                            <asp:Label ID="lblDivision" runat="server" Text="Division:" meta:resourcekey="lblDivisionResource1"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlDivision" runat="server" Enabled="False" meta:resourcekey="ddlDivisionResource1">
                                <asp:ListItem Text="-- Select --" meta:resourcekey="ListItemResource5"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rqdDdlDivision" runat="server" ControlToValidate="ddlDivision"
                                InitialValue="-- Select --" ErrorMessage="Please Select Division." ValidationGroup="PnlBMS"
                                meta:resourcekey="rqdDdlDivisionResource1">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnOk" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnClose" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
        <table align="center" width="90%">
            <tr>
                <td align="right">
                    <asp:Button ID="btnOk" Text="Ok" runat="server" CssClass="gobutton" OnClick="btnOk_Click"
                        ValidationGroup="PnlBMS" meta:resourcekey="btnOkResource1" />
                </td>
                <td>
                    <asp:Button ID="btnClose" runat="server" Text="Close" CssClass="gobutton" OnClick="btnClose_Click"
                        CausesValidation="False" meta:resourcekey="btnCloseResource1" />
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:ValidationSummary ID="vsumPnlBMS" runat="server" ValidationGroup="PnlBMS" ShowMessageBox="True"
                        ShowSummary="False" meta:resourcekey="vsumPnlBMSResource1" />
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Label ID="lblError1" runat="server"></asp:Label>
    </form>
</body>
</html>
