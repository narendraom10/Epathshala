<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default"
    Culture="auto" UICulture="auto" meta:resourcekey="PageResource1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" oncontextmenu="return(false);">
<head runat="server">
    <%--<meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE9 " />--%>
    <%-- <meta http-equiv="X-UA-Compatible" content="IE=8, IE=9"/> --%>
    <title>ePathshala </title>
    <link href="App_Themes/Blue/login-box.css" rel="Stylesheet" runat="server" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1">
    <link href='http://fonts.googleapis.com/css?family=Roboto:400,300,500,700' rel='stylesheet'
        type='text/css'>
        
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
<body id="LoginBody" style="max-width: 1024px; margin: auto; border: none;">
    <div id="LoginControls">
        <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <%--  <cc1:ToolkitScriptManager ID="ts1" runat="server">
        </cc1:ToolkitScriptManager>--%>
        <div id="MainTable" style="max-width: 1024px; margin: auto; border: none;">
            <div class="TopLogin">
            </div>
            <div class="Status" style="max-width: 1024px; margin: auto; border: none;">
                <div class="SignInBar">
                    <div class="SignInBarL">
                    </div>
                    <div class="SignInBarM">
                        <asp:DropDownList runat="server" ID="ddlLanguage" AutoPostBack="True" meta:resourcekey="ddlLanguageResource1">
                            <asp:ListItem Text="English" Value="en-US" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="ગુજરાતી" Value="gu-IN"></asp:ListItem>
                            <asp:ListItem Text="हिन्दी" Value="hi-IN"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="SignInBarR">
                    </div>
                </div>
            </div>
        </div>
        <div class="container">
            <div class="flat-form ">
                <ul class="tabs ">
                    <li><a href="#login" class="active ">
                        <asp:Label Text="Teacher Login" ID="lblTeacher" CssClass="lblTab" runat="server"
                            meta:resourcekey="lblTeacherResource1"></asp:Label>
                    </a></li>
                    <li><a href="#register">
                        <asp:Label Text="Student Login" ID="lblStudent" CssClass="lblTab" runat="server"
                            meta:resourcekey="lblStudentResource1"></asp:Label>
                    </a></li>
                </ul>
                <div id="login" class="form-action show">
                    <asp:Label Text="Login as Teacher" ID="lblTlogin" CssClass="lblHead" runat="server"
                        meta:resourcekey="lblTloginResource1"></asp:Label>
                    <table width="100%" cellpadding="0" cellspacing="0" border="0" class="tblLogin">
                        <tr>
                            <td>
                                <asp:TextBox ID="txtUsername" class="Text-box" runat="server" MaxLength="25" meta:resourcekey="txtUsernameResource1"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rqdUserName" runat="server" ControlToValidate="txtUsername"
                                    ErrorMessage="Please Enter Username." ValidationGroup="TeacherLogin" meta:resourcekey="rqdUserNameResource1">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="txtPassword" class="Text-box" runat="server" MaxLength="25" TextMode="Password"
                                    meta:resourcekey="txtPasswordResource1"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rqdPassword" runat="server" ControlToValidate="txtPassword"
                                    ErrorMessage="Please Enter Password." ValidationGroup="TeacherLogin" meta:resourcekey="rqdPasswordResource1">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnLogin" runat="server" Text="Login" ValidationGroup="TeacherLogin"
                                    CssClass="button" SkinID="LoginButton" OnClick="btnLogin_Click" meta:resourcekey="btnLoginResource1" />
                            </td>
                            <td>
                                <asp:Label ID="lblError1" runat="server" Text="Illegal Attempt!...." CssClass="lblerror"
                                    Visible="false" meta:resourcekey="lblError1Resource1"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="lblLogin">
                                <asp:CheckBox ID="chkRememberMe" runat="server" Text="  Remember Me" meta:resourcekey="chkRememberMeResource1" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:ValidationSummary ID="vsumTeacherLogin" runat="server" ValidationGroup="TeacherLogin"
                                    ShowMessageBox="True" ShowSummary="False" meta:resourcekey="vsumTeacherLoginResource1" />
                            </td>
                        </tr>
                    </table>
                </div>
                <!--/#login.form-action-->
                <div id="register" class="form-action hide">
                    <h1>
                        <asp:Label Text="Login as Student" ID="lblSLogin" CssClass="lblHead" runat="server"
                            meta:resourcekey="lblSLoginResource1"></asp:Label></h1>
                    <table width="100%" cellpadding="0" cellspacing="0" border="0" class="tblLogin">
                        <tr>
                            <td>
                                <asp:TextBox ID="txtSUsername" class="Text-box" runat="server" MaxLength="15" meta:resourcekey="txtSUsernameResource1"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rqdSUserName" runat="server" ControlToValidate="txtSUsername"
                                    ErrorMessage="Please Enter Username." ValidationGroup="StudentLogin" meta:resourcekey="rqdSUserNameResource1">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="txtSPassword" class="Text-box" runat="server" MaxLength="10" TextMode="Password"
                                    meta:resourcekey="txtSPasswordResource1"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rqdSPassword" runat="server" ControlToValidate="txtSPassword"
                                    ErrorMessage="Please Enter Password." ValidationGroup="StudentLogin" meta:resourcekey="rqdSPasswordResource1">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnSLogin" runat="server" SkinID="LoginButton" Text="Login" CssClass="button"
                                    ValidationGroup="StudentLogin" meta:resourcekey="btnSLoginResource1" OnClick="btnSLogin_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td class="lblLogin">
                                <asp:CheckBox ID="chkRememberStudent" runat="server" Text="  Remember Me" meta:resourcekey="chkRememberMeResource1" />
                            </td>
                            <td class="lblLogin">
                                <asp:LinkButton ID="lnlBtnSignUp" runat="server" Text="SignUP.." PostBackUrl="Registration/StudentOnlineReg.aspx"
                                    Font-Underline="false" ForeColor="#666666" Font-Size="13px"></asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:ValidationSummary ID="vsumStudentLogin" runat="server" ValidationGroup="StudentLogin"
                                    ShowMessageBox="True" ShowSummary="False" meta:resourcekey="vsumStudentLoginResource1" />
                            </td>
                        </tr>
                    </table>
                </div>
                <%-- <asp:ListItem Text="मराठी" Value="mr-IN"> </asp:ListItem>--%>
            </div>
        </div>
        <asp:ValidationSummary ID="vsumLogin" runat="server" ValidationGroup="Login" ShowMessageBox="True"
            ShowSummary="False" meta:resourcekey="vsumLoginResource1" />
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
                                <asp:Label ID="lblBMS" runat="server" Text="Login With" meta:resourcekey="lblBMSResource1"></asp:Label>
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
        <div style="text-align: center; margin-top: 5px; font-size: 13px;">
            Copyright &copy; 2014 Arraycom India Ltd. All rights reserved.
        </div>
        </form>
    </div>
    <script src="Scripts/Jquery1.9.1.js" type="text/javascript"></script>
</body>
</html>
<script type="text/javascript">
    (function ($) {
        var SHOW_CLASS = 'show', s
        HIDE_CLASS = 'hide',
      ACTIVE_CLASS = 'active';

        $('.tabs').on('click', 'li a', function (e) {
            e.preventDefault();
            var $tab = $(this),
         href = $tab.attr('href');

            $('.active').removeClass(ACTIVE_CLASS);
            $tab.addClass(ACTIVE_CLASS);

            $('.show')
        .removeClass(SHOW_CLASS)
        .addClass(HIDE_CLASS)
        .hide();

            $(href)
        .removeClass(HIDE_CLASS)
        .addClass(SHOW_CLASS)
        .hide()
        .fadeIn(550);
        });
    })(jQuery);
</script>
