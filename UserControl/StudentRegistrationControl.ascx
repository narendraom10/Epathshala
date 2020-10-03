<%@ Control Language="C#" AutoEventWireup="true" CodeFile="StudentRegistrationControl.ascx.cs"
    Inherits="UserControl_StudentRegistrationControl" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<html>
<head>
    <title></title>
    <style type="text/css">
        #signup
        {
            width: 325px;
            float: right;
            margin: 40px 40px 50px 0;
            background-color: #2E3192;
            box-shadow: 0px 0px 4px #444;
            border-radius: 15px;
            color: #fff;
            padding: 2% 1%;
            font-size: 1.4em;
        }
        
        #signup f4
        {
            font-size: 1.3em;
            font-weight: 500;
        }
        
        #signupform
        {
            width: 330px;
            height: auto;
            font-size: 0.75em;
            margin: 15px 0 6px 0;
            font-weight: 300;
        }
    </style>
</head>
<body>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="signup">
        <h4>
            <asp:Label ID="lblSignUP" runat="server" Text="New User"></asp:Label>
        </h4>
        <div id="signupform">
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
                    &nbsp
                </div>
                <div class="Control">
                    <asp:Button ID="btnSubmit" runat="server" ValidationGroup="a" OnClick="btnSubmit_Click"
                        Text="Register" CssClass="submit" EnableTheming="false" />
                    <asp:ValidationSummary ID="ValSumStudent" runat="server" ValidationGroup="a" ShowMessageBox="True"
                        ShowSummary="False" meta:resourcekey="ValSumStudentResource1" />
                </div>
            </div>
        </div>
    </div>
</body>
</html>
