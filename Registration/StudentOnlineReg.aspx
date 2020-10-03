<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeFile="StudentOnlineReg.aspx.cs"
    Inherits="Registration_StudentOnlineReg" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<html>
<head runat="server">
    <title></title>
    <style type="text/css">
        .MainTableReg
        {
            margin: 20px 300px 20px 300px;
            border-color: #26AAAA;
            border-style: solid;
            border-width: 1px;
            vertical-align: top;
        }
        
        
        .RoundTop
        {
            border-top-left-radius: 0.75em;
            border-top-right-radius: 0.75em;
        }
        
        .MainTableReg tr td
        {
            padding: 5px 5px 5px 5px;
            vertical-align: top;
            text-align: left;
        }
        
        
        .MainTableReg .MainTableRegHeader
        {
            border-width: 1px;
            border-style: solid;
            border-color: #26AAAA;
            border-bottom: 0px none black;
            border-left: 0px none black;
            border-right: 0px none black;
            border-top: 0px none black;
            text-align: center; /* font-weight: bold;*/
            padding: 5px;
            background-image: url('../App_Themes/Images/dialogHeaderT.gif'); /*background-image: url('../Images/dialogHeaderT.gif');
            background-repeat: repeat-x; /*border: 0.5px solid #26AAAA;*/
            color: #096B6B;
        }
        
        .MainTableReg .MainTableRegFooter
        {
            text-align: center;
        }
        
        .round
        {
            background: #ade8e8; /* Old browsers */
            background: -moz-linear-gradient(top,  #ade8e8 0%, #4bbbbb 100%); /* FF3.6+ */
            background: -webkit-gradient(linear, left top, left bottom, color-stop(0%,#ade8e8), color-stop(100%,#4bbbbb)); /* Chrome,Safari4+ */
            background: -webkit-linear-gradient(top,  #ade8e8 0%,#4bbbbb 100%); /* Chrome10+,Safari5.1+ */
            background: -o-linear-gradient(top,  #ade8e8 0%,#4bbbbb 100%); /* Opera 11.10+ */
            background: -ms-linear-gradient(top,  #ade8e8 0%,#4bbbbb 100%); /* IE10+ */
            background: linear-gradient(to bottom,  #ade8e8 0%,#4bbbbb 100%); /* W3C */
            filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#ade8e8', endColorstr='#4bbbbb',GradientType=0 ); /* IE6-9 */
            margin-right: 0px;
            border-top-left-radius: 0.5em;
            border-top-right-radius: 0.5em;
            border: 1px solid #35B1B1;
            border-bottom: none;
        }
        .round:hover, .round:active, .round:visited
        {
            background: #24a9a9; /* Old browsers */ /* IE9 SVG, needs conditional override of 'filter' to 'none' */
            background: url(data:image/svg+xml;base64,PD94bWwgdmVyc2lvbj0iMS4wIiA/Pgo8c3ZnIHhtbG5zPSJodHRwOi8vd3d3LnczLm9yZy8yMDAwL3N2ZyIgd2lkdGg9IjEwMCUiIGhlaWdodD0iMTAwJSIgdmlld0JveD0iMCAwIDEgMSIgcHJlc2VydmVBc3BlY3RSYXRpbz0ibm9uZSI+CiAgPGxpbmVhckdyYWRpZW50IGlkPSJncmFkLXVjZ2ctZ2VuZXJhdGVkIiBncmFkaWVudFVuaXRzPSJ1c2VyU3BhY2VPblVzZSIgeDE9IjAlIiB5MT0iMCUiIHgyPSIwJSIgeTI9IjEwMCUiPgogICAgPHN0b3Agb2Zmc2V0PSIwJSIgc3RvcC1jb2xvcj0iIzI0YTlhOSIgc3RvcC1vcGFjaXR5PSIxIi8+CiAgICA8c3RvcCBvZmZzZXQ9IjEwMCUiIHN0b3AtY29sb3I9IiNiM2ViZWIiIHN0b3Atb3BhY2l0eT0iMSIvPgogIDwvbGluZWFyR3JhZGllbnQ+CiAgPHJlY3QgeD0iMCIgeT0iMCIgd2lkdGg9IjEiIGhlaWdodD0iMSIgZmlsbD0idXJsKCNncmFkLXVjZ2ctZ2VuZXJhdGVkKSIgLz4KPC9zdmc+);
            background: -moz-linear-gradient(top,  #24a9a9 0%, #b3ebeb 100%); /* FF3.6+ */
            background: -webkit-gradient(linear, left top, left bottom, color-stop(0%,#24a9a9), color-stop(100%,#b3ebeb)); /* Chrome,Safari4+ */
            background: -webkit-linear-gradient(top,  #24a9a9 0%,#b3ebeb 100%); /* Chrome10+,Safari5.1+ */
            background: -o-linear-gradient(top,  #24a9a9 0%,#b3ebeb 100%); /* Opera 11.10+ */
            background: -ms-linear-gradient(top,  #24a9a9 0%,#b3ebeb 100%); /* IE10+ */
            background: linear-gradient(to bottom,  #24a9a9 0%,#b3ebeb 100%); /* W3C */
            filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#24a9a9', endColorstr='#b3ebeb',GradientType=0 ); /* IE6-8 */ /*
    border-top-left-radius:2em;
	border-top-right-radius:2em;
    */
        }
        
        .roundBottom
        {
            background: #ade8e8; /* Old browsers */
            background: -moz-linear-gradient(top,  #ade8e8 0%, #4bbbbb 100%); /* FF3.6+ */
            background: -webkit-gradient(linear, left top, left bottom, color-stop(0%,#ade8e8), color-stop(100%,#4bbbbb)); /* Chrome,Safari4+ */
            background: -webkit-linear-gradient(top,  #ade8e8 0%,#4bbbbb 100%); /* Chrome10+,Safari5.1+ */
            background: -o-linear-gradient(top,  #ade8e8 0%,#4bbbbb 100%); /* Opera 11.10+ */
            background: -ms-linear-gradient(top,  #ade8e8 0%,#4bbbbb 100%); /* IE10+ */
            background: linear-gradient(to bottom,  #ade8e8 0%,#4bbbbb 100%); /* W3C */
            filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#ade8e8', endColorstr='#4bbbbb',GradientType=0 ); /* IE6-9 */
            margin-right: 0px;
            border-bottom-left-radius: 0.5em;
            border-bottom-right-radius: 0.5em;
            border: 1px solid #35B1B1;
            border-top: none;
        }
        
        .roundBottom:hover, .roundBottom:active, .roundBottom:visited
        {
            background: #24a9a9; /* Old browsers */ /* IE9 SVG, needs conditional override of 'filter' to 'none' */
            background: url(data:image/svg+xml;base64,PD94bWwgdmVyc2lvbj0iMS4wIiA/Pgo8c3ZnIHhtbG5zPSJodHRwOi8vd3d3LnczLm9yZy8yMDAwL3N2ZyIgd2lkdGg9IjEwMCUiIGhlaWdodD0iMTAwJSIgdmlld0JveD0iMCAwIDEgMSIgcHJlc2VydmVBc3BlY3RSYXRpbz0ibm9uZSI+CiAgPGxpbmVhckdyYWRpZW50IGlkPSJncmFkLXVjZ2ctZ2VuZXJhdGVkIiBncmFkaWVudFVuaXRzPSJ1c2VyU3BhY2VPblVzZSIgeDE9IjAlIiB5MT0iMCUiIHgyPSIwJSIgeTI9IjEwMCUiPgogICAgPHN0b3Agb2Zmc2V0PSIwJSIgc3RvcC1jb2xvcj0iIzI0YTlhOSIgc3RvcC1vcGFjaXR5PSIxIi8+CiAgICA8c3RvcCBvZmZzZXQ9IjEwMCUiIHN0b3AtY29sb3I9IiNiM2ViZWIiIHN0b3Atb3BhY2l0eT0iMSIvPgogIDwvbGluZWFyR3JhZGllbnQ+CiAgPHJlY3QgeD0iMCIgeT0iMCIgd2lkdGg9IjEiIGhlaWdodD0iMSIgZmlsbD0idXJsKCNncmFkLXVjZ2ctZ2VuZXJhdGVkKSIgLz4KPC9zdmc+);
            background: -moz-linear-gradient(top,  #24a9a9 0%, #b3ebeb 100%); /* FF3.6+ */
            background: -webkit-gradient(linear, left top, left bottom, color-stop(0%,#24a9a9), color-stop(100%,#b3ebeb)); /* Chrome,Safari4+ */
            background: -webkit-linear-gradient(top,  #24a9a9 0%,#b3ebeb 100%); /* Chrome10+,Safari5.1+ */
            background: -o-linear-gradient(top,  #24a9a9 0%,#b3ebeb 100%); /* Opera 11.10+ */
            background: -ms-linear-gradient(top,  #24a9a9 0%,#b3ebeb 100%); /* IE10+ */
            background: linear-gradient(to bottom,  #24a9a9 0%,#b3ebeb 100%); /* W3C */
            filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#24a9a9', endColorstr='#b3ebeb',GradientType=0 ); /* IE6-8 */ /*
    border-top-left-radius:2em;
	border-top-right-radius:2em;
    */
        }
    </style>
    
<script>
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
    <table class="MainTableReg RoundTop" cellspacing="0" cellpadding="0">
        <tr>
            <td colspan="4" style="padding: 0px;">
                <p class="MainTableRegHeader round InnerTableStyle RoundTop" style="padding: 5px;">
                    <asp:Label ID="lblStReg" runat="server" Text="Student Registration" 
                        meta:resourcekey="lblStRegResource1"></asp:Label></p>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblBMSID" runat="server" Text="BMS:" 
                    meta:resourcekey="lblBMSIDResource1"></asp:Label>
            </td>
            <td colspan="3">
                <asp:DropDownList ID="ddlBMSAdd" runat="server" SkinID="DdlWidth400" 
                    meta:resourcekey="ddlBMSAddResource1">
                    <asp:ListItem Value="0" Text="--Select--" meta:resourcekey="ListItemResource1"></asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="ReqFieldBMSID" runat="server" InitialValue="0" ErrorMessage="Please Insert BMSID"
                    ValidationGroup="a" ControlToValidate="ddlBMSAdd" 
                    meta:resourcekey="ReqFieldBMSIDResource1">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblFirstName" runat="server" Text="FirstName:" 
                    meta:resourcekey="lblFirstNameResource1"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtFirstName" runat="server" MaxLength="20" 
                    meta:resourcekey="txtFirstNameResource1"></asp:TextBox>
                <asp:RequiredFieldValidator ID="ReqFieldFirstName" runat="server" ErrorMessage="Please Insert FirstName"
                    ValidationGroup="a" ControlToValidate="txtFirstName" 
                    meta:resourcekey="ReqFieldFirstNameResource1">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revFirstName" runat="server" ErrorMessage="Only characters are allowed in FirstName"
                    ToolTip="Only numbers and characters are allowed in FirstName" Text="." ValidationGroup="a"
                    ValidationExpression="^[a-zA-Z ]+$" ControlToValidate="txtFirstName" 
                    meta:resourcekey="revFirstNameResource1"></asp:RegularExpressionValidator>
            </td>
            <td>
                <asp:Label ID="lblMiddleName" runat="server" Text="MiddleName:" 
                    meta:resourcekey="lblMiddleNameResource1"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtMiddleName" runat="server" MaxLength="20" 
                    meta:resourcekey="txtMiddleNameResource1"></asp:TextBox>
                <asp:RequiredFieldValidator ID="ReqFieldMiddleName" runat="server" ErrorMessage="Please Insert MiddleName"
                    ValidationGroup="a" ControlToValidate="txtMiddleName" 
                    meta:resourcekey="ReqFieldMiddleNameResource1">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revMiddleName" runat="server" ErrorMessage="Only characters are allowed in MiddleName"
                    ToolTip="Only numbers and characters are allowed in MiddleName" Text="." ValidationGroup="a"
                    ValidationExpression="^[a-zA-Z ]+$" ControlToValidate="txtMiddleName" 
                    meta:resourcekey="revMiddleNameResource1"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblLastName" runat="server" Text="LastName:" 
                    meta:resourcekey="lblLastNameResource1"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtLastName" runat="server" MaxLength="20" 
                    meta:resourcekey="txtLastNameResource1"></asp:TextBox>
                <asp:RequiredFieldValidator ID="ReqFieldLastName" runat="server" ErrorMessage="Please Insert LastName"
                    ValidationGroup="a" ControlToValidate="txtLastName" 
                    meta:resourcekey="ReqFieldLastNameResource1">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revLastName" runat="server" ErrorMessage="Only characters are allowed in LastName"
                    ToolTip="Only numbers and characters are allowed in LastName" Text="." ValidationGroup="a"
                    ValidationExpression="^[a-zA-Z ]+$" ControlToValidate="txtLastName" 
                    meta:resourcekey="revLastNameResource1"></asp:RegularExpressionValidator>
            </td>
            <td>
                <asp:Label ID="lblAddress" runat="server" Text="Address:" 
                    meta:resourcekey="lblAddressResource1"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine" 
                    meta:resourcekey="txtAddressResource1"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblMobileNo" runat="server" Text="MobileNo:" 
                    meta:resourcekey="lblMobileNoResource1"></asp:Label>
            </td>
            <td>
                <%--^[0-9]{10}--%>
                <asp:TextBox ID="txtMobileNo" runat="server" MaxLength="10" 
                    meta:resourcekey="txtMobileNoResource1"></asp:TextBox>
                <asp:TextBoxWatermarkExtender ID="txtMobileNo_TextBoxWatermarkExtender" runat="server"
                    Enabled="True" TargetControlID="txtMobileNo" WatermarkCssClass="watermark" WatermarkText="Ex: 9845689243">
                </asp:TextBoxWatermarkExtender>
                <asp:RegularExpressionValidator ID="revMobileNo" runat="server" ErrorMessage="Please enter valid MobileNo"
                    ToolTip="Only numbers and characters are allowed in Mobile No" Text="." ValidationGroup="a"
                    ValidationExpression="^[0-9]{10}" ControlToValidate="txtMobileNo" 
                    meta:resourcekey="revMobileNoResource1"></asp:RegularExpressionValidator>
            </td>
            <td>
                <asp:Label ID="lblContactNo" runat="server" Text="ContactNo:" 
                    meta:resourcekey="lblContactNoResource1"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtContactNo" runat="server" MaxLength="10" 
                    meta:resourcekey="txtContactNoResource1"></asp:TextBox>
                <asp:TextBoxWatermarkExtender ID="txtContactNo_TextBoxWatermarkExtender" runat="server"
                    Enabled="True" TargetControlID="txtContactNo" WatermarkCssClass="watermark" WatermarkText="Ex: 23254834">
                </asp:TextBoxWatermarkExtender>
                <asp:RequiredFieldValidator ID="ReqFieldContactNo" runat="server" ErrorMessage="Contact no is required."
                    ControlToValidate="txtContactNo" ValidationGroup="a" 
                    meta:resourcekey="ReqFieldContactNoResource1">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revContactNo" runat="server" ErrorMessage="Please enter valid ContactNo"
                    ToolTip="Please enter valid ContactNo" Text="." ValidationGroup="a" ValidationExpression="^[0-9]{6,10}"
                    ControlToValidate="txtContactNo" meta:resourcekey="revContactNoResource1"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblEmailID" runat="server" Text="EmailID:" 
                    meta:resourcekey="lblEmailIDResource1"></asp:Label>
            </td>
            <td style="text-align: left">
                <asp:TextBox ID="txtEmailID" runat="server" 
                    meta:resourcekey="txtEmailIDResource1"></asp:TextBox>
                <asp:TextBoxWatermarkExtender ID="txtEmailID_TextBoxWatermarkExtender" runat="server"
                    Enabled="True" TargetControlID="txtEmailID" WatermarkCssClass="watermark" WatermarkText="Ex: abc@gmail.com">
                </asp:TextBoxWatermarkExtender>
                <asp:RequiredFieldValidator ID="ReqFieldEmailID" runat="server" ErrorMessage="Please Insert EmailID"
                    ValidationGroup="a" ControlToValidate="txtEmailID" 
                    meta:resourcekey="ReqFieldEmailIDResource1">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revEmailID" runat="server" ErrorMessage="Please enter valid EmailID"
                    ToolTip="Please enter valid EmailID" Text="." ValidationGroup="a" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                    ControlToValidate="txtEmailID" meta:resourcekey="revEmailIDResource1"></asp:RegularExpressionValidator>
            </td>
            <td>
               <%-- <asp:Label ID="lblDateOfBirth" runat="server" Text="DateOfBirth:"></asp:Label>--%>
            </td>
            <td>
               <%-- <asp:TextBox ID="txtDateOfBirth" runat="server"></asp:TextBox>
                <asp:ImageButton ID="ibtnDate" runat="server" ImageUrl="~/App_Themes/Images/Calender.gif"
                    Width="20px" />
                <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDateOfBirth"
                    PopupButtonID="ibtnDate" Format="dd/MM/yyyy">
                </asp:CalendarExtender>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Please enter valid DateOfBirth"
                    ToolTip="Please enter valid DateOfBirth" Text="." ValidationGroup="a" ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[-/.](0[1-9]|1[012])[-/.](19|20)\d\d$"
                    ControlToValidate="txtDateOfBirth"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="ReqFieldDateOfBirth" runat="server" ErrorMessage="Please Insert DateOfBirth"
                    ValidationGroup="a" ControlToValidate="txtDateOfBirth">*</asp:RequiredFieldValidator>--%>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblLoginID" runat="server" Text="LoginID:" 
                    meta:resourcekey="lblLoginIDResource1"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtLoginID" runat="server" OnTextChanged="txtLoginID_TextChanged"
                    AutoPostBack="True" MaxLength="15" meta:resourcekey="txtLoginIDResource1"></asp:TextBox>
                <asp:RequiredFieldValidator ID="ReqFieldLoginID" runat="server" ErrorMessage="Please Insert LoginID"
                    ValidationGroup="a" ControlToValidate="txtLoginID" 
                    meta:resourcekey="ReqFieldLoginIDResource1">*</asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:Label ID="lblPassword" runat="server" Text="Password:" 
                    meta:resourcekey="lblPasswordResource1"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" MaxLength="15" 
                    meta:resourcekey="txtPasswordResource1"></asp:TextBox>
                <asp:RequiredFieldValidator ID="ReqFieldPassword" runat="server" ErrorMessage="Please Insert Password"
                    ValidationGroup="a" ControlToValidate="txtPassword" 
                    meta:resourcekey="ReqFieldPasswordResource1">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblGender" runat="server" Text="Gender:" 
                    meta:resourcekey="lblGenderResource1"></asp:Label>
            </td>
            <td>
                <asp:RadioButtonList ID="rdbGenderList" runat="server" ValidationGroup="a" 
                    RepeatDirection="Horizontal" meta:resourcekey="rdbGenderListResource1">
                    <asp:ListItem Value="0" Text="Male" meta:resourcekey="ListItemResource2"></asp:ListItem>
                    <asp:ListItem Value="1" Text="Female" meta:resourcekey="ListItemResource3"></asp:ListItem>
                </asp:RadioButtonList>
                <asp:RequiredFieldValidator ID="ReqFieldGender" runat="server" ErrorMessage="Please Insert Gender"
                    ValidationGroup="a" ControlToValidate="rdbGenderList" 
                    meta:resourcekey="ReqFieldGenderResource1">*</asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:Label ID="lblCountry" runat="server" Text="Country:" 
                    meta:resourcekey="lblCountryResource1"></asp:Label>
            </td>
            <td>
                <asp:RadioButtonList ID="rdbCountry" runat="server" ValidationGroup="a" 
                    RepeatDirection="Horizontal" meta:resourcekey="rdbCountryResource1">
                    <asp:ListItem Value="0" Text="India" meta:resourcekey="ListItemResource4"></asp:ListItem>
                    <asp:ListItem Value="1" Text="other" meta:resourcekey="ListItemResource5"></asp:ListItem>
                </asp:RadioButtonList>
                <asp:RequiredFieldValidator ID="ReqFieldCountry" runat="server" ErrorMessage="Please select country"
                    ValidationGroup="a" ControlToValidate="rdbCountry" 
                    meta:resourcekey="ReqFieldCountryResource1">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td colspan="4" class="MainTableRegFooter">
                <asp:Button ID="btnSave" ValidationGroup="a" runat="server" Text="Register" AlternateText="Save"
                    OnClick="btnSave_Click" meta:resourcekey="btnSaveResource1" />
                <asp:Button ID="btnCancel" runat="server" Text="Reset" 
                    OnClick="btnCancel_Click" meta:resourcekey="btnCancelResource1" />
                <asp:Button ID="btnLogin" runat="server" OnClick="btnLogin_Click" 
                    Text="Back to login" meta:resourcekey="btnLoginResource1" />
            </td>
        </tr>
        <tr>
            <td colspan="4" align="center">
                <asp:ValidationSummary ID="ValSumStudent" runat="server" ValidationGroup="a" ShowMessageBox="True"
                    ShowSummary="False" meta:resourcekey="ValSumStudentResource1" />
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
