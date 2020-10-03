<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ResponsiveRegister.aspx.cs"
    Inherits="ResponsiveRegister" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href='http://fonts.googleapis.com/css?family=Roboto:400,300,500,700' rel='stylesheet'
        type='text/css'>
    <title>ePathshala</title>
    <style>
        body
        {
            font-family: 'Roboto' , serif;
        }
        #signupwrap
        {
            width: 325px;
            height:370px;
            margin: 90px auto 50px auto;
            background-color: #2E3192;
            box-shadow: 1px 1px 2px #444;
            color: #fff;
            padding: 2% 1%;
            font-size: 1.4em;
        }
        
        
        .submit
        {
            width: 100%;
        }
        
        .submit #btnSubmit
        {
            float: right;
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
    <div class="signupresponsive">
        <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div id="signupwrap">
            <f4><asp:Label ID="lblSignUP" runat="server" Text="Sign Up"></asp:Label></f4>
            <div id="signupform" style="background: red;">
                <div>
                    <div class="Label">
                        <asp:Label ID="lblFirstName" runat="server" Text="First Name"></asp:Label>
                    </div>
                    <div class="Control">
                        <asp:TextBox ID="txtFirstName" runat="server" CssClass="text fourbox"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="ReqFieldFirstName" runat="server" ErrorMessage="Please Insert FirstName"
                            ValidationGroup="a" ControlToValidate="txtFirstName">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revFirstName" runat="server" ErrorMessage="Only characters are allowed in FirstName"
                            ToolTip="Only numbers and characters are allowed in FirstName" Text="." ValidationGroup="a"
                            ValidationExpression="^[a-zA-Z ]+$" ControlToValidate="txtFirstName"></asp:RegularExpressionValidator>
                    </div>
                </div>
                <div>
                    <div class="Label">
                        <asp:Label ID="lblLastName" runat="server" Text="Last Name"></asp:Label>
                    </div>
                    <div class="Control">
                        <asp:TextBox ID="txtLastName" runat="server" CssClass="text fourbox"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="ReqFieldLastName" runat="server" ErrorMessage="Please Insert LastName"
                            ValidationGroup="a" ControlToValidate="txtLastName">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revLastName" runat="server" ErrorMessage="Only characters are allowed in LastName"
                            ToolTip="Only numbers and characters are allowed in LastName" Text="." ValidationGroup="a"
                            ValidationExpression="^[a-zA-Z ]+$" ControlToValidate="txtLastName"></asp:RegularExpressionValidator>
                    </div>
                </div>
                <div>
                    <div class="Label">
                        <asp:Label ID="lblContactNo" runat="server" Text="Contact No"></asp:Label>
                    </div>
                    <div class="Control">
                        <asp:TextBox ID="txtContactNo" runat="server" CssClass="text fourbox" MaxLength="10"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="ReqFieldContactNo" runat="server" ErrorMessage="Contact no is required."
                            ControlToValidate="txtContactNo" ValidationGroup="a">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revContactNo" runat="server" ErrorMessage="Please enter valid ContactNo"
                            ToolTip="Please enter valid ContactNo" Text="." ValidationGroup="a" ValidationExpression="^[0-9]{6,10}"
                            ControlToValidate="txtContactNo"></asp:RegularExpressionValidator>
                    </div>
                </div>
                <div>
                    <div class="Label">
                        <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label>
                    </div>
                    <div class="Control">
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="text fourbox"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="ReqFieldEmailID" runat="server" ErrorMessage="Please Insert EmailID"
                            ValidationGroup="a" ControlToValidate="txtEmail">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revEmailID" runat="server" ErrorMessage="Please enter valid EmailID"
                            ToolTip="Please enter valid EmailID" Text="." ValidationGroup="a" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                            ControlToValidate="txtEmail"></asp:RegularExpressionValidator>
                    </div>
                </div>
                <div>
                    <div class="Label">
                        <asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label>
                    </div>
                    <div class="Control">
                        <asp:TextBox ID="txtPassword" runat="server" CssClass="text passwordnp" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="ReqFieldPassword" runat="server" ErrorMessage="Please Insert Password."
                            ValidationGroup="a" ControlToValidate="txtPassword">*</asp:RequiredFieldValidator>
                    </div>
                </div>
                <div>
                    <div class="Label">
                        <asp:Label ID="lblGender" runat="server" Text="Gender"></asp:Label>
                    </div>
                    <div class="Control">
                        <asp:DropDownList ID="ddlGender" runat="server" CssClass="text gender">
                            <asp:ListItem Value="0" Text="<SELECT>"></asp:ListItem>
                            <asp:ListItem Value="1" Text="Male"></asp:ListItem>
                            <asp:ListItem Value="2" Text="Female"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="ReqFieldGender" runat="server" InitialValue="0" ErrorMessage="Please Select Gender."
                            ValidationGroup="a" ControlToValidate="ddlGender">*</asp:RequiredFieldValidator>
                    </div>
                </div>
                <div>
                    <div class="Label">
                        <asp:Label ID="lblBirthdate" runat="server" Text="Birthdate"></asp:Label>
                    </div>
                    <div class="Control">
                        <asp:TextBox runat="server" ID="txtBirthdate" CssClass="text fourbox"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="ReqFieldBirthDate" runat="server" InitialValue="0"
                            ErrorMessage="Please Select BirthDate" ValidationGroup="a" ControlToValidate="txtBirthdate">*</asp:RequiredFieldValidator>
                        <cc1:CalendarExtender ID="calExeBirthDate" runat="server" TargetControlID="txtBirthdate"
                            PopupButtonID="ibtnDate" Format="dd/MM/yyyy">
                        </cc1:CalendarExtender>
                        <div id="BirthDateImageButton">
                            <asp:ImageButton ID="ibtnDate" runat="server" ImageUrl="~/App_Themes/Images/Calender.gif"
                                Width="20px" />
                        </div>
                    </div>
                </div>
                <div>
                    <div class="Label">
                        <asp:Label ID="lblBMS" runat="server" Text="BMS"></asp:Label>
                    </div>
                    <div class="Control">
                        <asp:DropDownList ID="ddlBMS" runat="server" CssClass="boardoption">
                            <asp:ListItem Value="0" Text="<SELECT>"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="ReqFieldBMSID" runat="server" InitialValue="0" ErrorMessage="Please Select BMS"
                            ValidationGroup="a" ControlToValidate="ddlBMS">*</asp:RequiredFieldValidator>
                    </div>
                </div>
                <div>
                    <div class="Label">
                    </div>
                    <div class="submit">
                        <asp:Button ID="btnSubmit" runat="server" ValidationGroup="a" OnClick="btnSubmit_Click"
                            Text="Register" CssClass="submit" />
                        <asp:ValidationSummary ID="ValSumStudent" runat="server" ValidationGroup="a" ShowMessageBox="True"
                            ShowSummary="False" meta:resourcekey="ValSumStudentResource1" />
                    </div>
                </div>
            </div>
        </div>
        </form>
    </div>
</body>
</html>
