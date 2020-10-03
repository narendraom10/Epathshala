<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LoginControl.ascx.cs"
    Inherits="UserControl_LoginControl" %>
<style type="text/css">
    .ErrorControl
    {
        background-color: #FBE3E4;
        border: solid 1px Red;
    }
    
    .Summary
    {
        margin-left: 15px;
    }
    
    .txtLoginControl
    {
        width: 100%;
        min-width: 250px;
        max-width: 350px;
        border: 1px solid black;
        margin-bottom: 5px;
        padding: 3px;
    }
</style>
<script type="text/javascript">
    function showSignup() {
        //alert("in show func");
        var elem = document.getElementById('ucaregistration');
        var dvreg = document.getElementById('ucdvsignup');
        var dvforgotpass = document.getElementById('ucdvforgetpassword');
        var dvlogin = document.getElementById('ucdvlogin');


        dvforgotpass.style.visibility = 'hidden';
        dvforgotpass.style.display = 'none';

        dvlogin.style.visibility = 'hidden';
        dvlogin.style.display = 'none';

        dvreg.style.visibility = 'visible';
        dvreg.style.display = 'block';

        var elemusername = document.getElementById('uctxtUserName');
        var elempassword = document.getElementById('uctxtUserPassword');


    }

    function showForgotPassword() {
        //alert("in show func");
        var elem = document.getElementById('ucaregistration');
        var dvreg = document.getElementById('ucdvsignup');
        var dvforgotpass = document.getElementById('ucdvforgetpassword');
        var dvlogin = document.getElementById('ucdvlogin');


        dvforgotpass.style.visibility = 'visible';
        dvforgotpass.style.display = 'block';

        dvlogin.style.visibility = 'hidden';
        dvlogin.style.display = 'none';

        dvreg.style.visibility = 'hidden';
        dvreg.style.display = 'none';
    }

    function showLogin() {
        //alert("in show func");
        var elem = document.getElementById('ucaregistration');
        var dvreg = document.getElementById('ucdvsignup');
        var dvforgotpass = document.getElementById('ucdvforgetpassword');
        var dvlogin = document.getElementById('ucdvlogin');


        dvforgotpass.style.visibility = 'hidden';
        dvforgotpass.style.display = 'none';

        dvlogin.style.visibility = 'visible';
        dvlogin.style.display = 'block';

        dvreg.style.visibility = 'hidden';
        dvreg.style.display = 'none';
    }

</script>
<style type="text/css">
    .panel-heading
    {
        padding: 0px;
        font-size: 26px;
        line-height: 26px;
        margin: 0px;
        color: #666;
        text-align: center;
        max-height: 80px;
    }
</style>
<div style="margin: 25px auto 25px auto; border: 4px solid orange; box-shadow: 0px 0px 0px white;
    min-width: 270px; max-width: 375px; padding: 5px; padding-left: 7px; background-color: #FFFFFF;">
    <div class="panel-heading">
        <img src="~/App_Themes/Green/Images/Logo.png" alt="Epathshala" id="ucdvEpathLogo"
            runat="server" height="90" />
    </div>
    <div id="ucdvlogin">
        <div>
            <h3 style="margin: 15px -4px 25px; font-size: 18px; color: #FFF; padding: 12px 20px;
                background: rgba(0, 0, 0, 0.3) none repeat scroll 0% 0%; text-align: center;">
                Login</h3>
        </div>
        <div style="padding-left: 0px;">
            <asp:TextBox ID="uctxtUserName" runat="server" placeholder="User ID" CssClass="txtLoginControl"></asp:TextBox>
            <asp:RequiredFieldValidator ID="ucrqdUserName" runat="server" ControlToValidate="uctxtUserName"
                ErrorMessage="Please Enter Username." ValidationGroup="ucLogin">Uer ID Required</asp:RequiredFieldValidator>
        </div>
        <div style="padding-left: 0px;">
            <asp:TextBox ID="uctxtUserPassword" runat="server" TextMode="Password" placeholder="Password"
                CssClass="txtLoginControl"></asp:TextBox>
            <asp:RequiredFieldValidator ID="ucrqdPassword" runat="server" ControlToValidate="uctxtUserPassword"
                ErrorMessage="Please Enter Password." ValidationGroup="ucLogin">Password Required</asp:RequiredFieldValidator>
            <div>
                <asp:ValidationSummary ID="ucvsumTeacherLogin" runat="server" ValidationGroup="ucLogin"
                    CssClass="Summary" ShowMessageBox="false" ShowSummary="false" />
            </div>
        </div>
        <div>
            <div style="float: left;">
                <asp:CheckBox ID="ucchkRememberMe" runat="server" Text="Remember Me" />
            </div>
            <br />
            <div style="float: right;">
                <asp:Button ID="ucbtnGo" runat="server" ClientIDMode="Static" Text="Log in" ValidationGroup="ucLogin"
                    OnClick="btnGo_Click" CssClass="LoginButton" Style="margin: 0px; padding: 5px 15px 5px 15px;
                    min-width: 101px;" />
                <asp:Button ID="btncancel" runat="server" Text="Cancel" CssClass="LoginButton" Style="margin: 0px;
                    padding: 5px 15px 5px 15px; min-width: 101px;" onclick="btncancel_Click" />
            </div>
            <br />
            <br />
            <br />
            
            <div >
                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div>
                            <asp:Label ID="ucinvalididpassword" runat="server" ForeColor="Red"></asp:Label>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ucbtnGo" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
        <div align="center" style="line-height: 0.65em; margin-top: 10px; text-align: center;">
            <a class="LoginLink" style="white-space: nowrap;" id="ucaregistration" href="../OtherPages/Registration.aspx">
                Create New Account</a>
            <br />
            <br />
            <a class="LoginLink" style="cursor: pointer; white-space: nowrap;" id="ucForgotPasswordLink"
                onclick="showForgotPassword()">Forgot Password</a>
        </div>
        <br />
        <div align="right" style="line-height: 0.65em;">
        </div>
    </div>
    <div id="ucdvforgetpassword" style="display: none; visibility: hidden;">
        <div>
            <h3 style="margin: 15px -4px 25px; font-size: 18px; color: #FFF; padding: 12px 20px;
                background: rgba(0, 0, 0, 0.3) none repeat scroll 0% 0%; text-align: center;">
                Forget Password
            </h3>
        </div>
        <div>
            <asp:Label ID="uclblEmail" runat="server" Text="Email Address:"></asp:Label>
            <asp:TextBox ID="uctxtEmail" CssClass="text" Style="padding: 0 5px; width: 90%;"
                runat="server" placeholder="abc@domainname.com"></asp:TextBox>
            <asp:RequiredFieldValidator ID="ucRequrdFeldValidatrEmail" ValidationGroup="ForgetPwd"
                ControlToValidate="uctxtEmail" runat="server" ErrorMessage="The email field is required"
                Text="*"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="ucRegulrExprsnValidtrEmail" ValidationGroup="ForgetPwd"
                ControlToValidate="uctxtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                runat="server" Text="*" ErrorMessage="Enter a valid emailid"></asp:RegularExpressionValidator>
        </div>
        <br />
        <div class="text-center">
            <asp:Button ID="ucbtnSubmit" runat="server" Text="Submit" ValidationGroup="ForgetPwd"
                OnClick="BttnSubmit_Click" CssClass="LoginButton" Style="margin: 0px; padding: 5px 15px 5px 15px;
                min-width: 101px;" />
            &nbsp;&nbsp;
            <%--<asp:Button ID="btncancelforgotpassword" runat="server" Text="Cancel" CssClass="LoginButton"
                Style="margin: 0px; padding: 5px 15px 5px 15px; min-width: 101px;" />--%>
            <input type="button" id="ucbtncancelforgotpassword" value="Cancel" style="margin: 0px;
                padding: 5px 15px 5px 15px; min-width: 101px;" onclick="showLogin()" />
        </div>
        <div>
        </div>
        <asp:ValidationSummary ID="ucvs1" ShowMessageBox="true" ShowSummary="false" ValidationGroup="ForgetPwd"
            runat="server" />
    </div>
    <div id="ucdvsignup" style="display: none; visibility: hidden;">
        <div>
            <h3 style="margin: 15px -4px 25px; font-size: 18px; color: #FFF; padding: 12px 20px;
                background: rgba(0, 0, 0, 0.3) none repeat scroll 0% 0%; text-align: center;">
                Create Account
            </h3>
        </div>
        <div style="padding-left: 0px;">
            <asp:TextBox ID="uctxtfname" runat="server" placeholder="First Name" CssClass="txtLoginControl"></asp:TextBox>
        </div>
        <div style="padding-left: 0px;">
            <asp:TextBox ID="uctxtpass" runat="server" TextMode="Password" placeholder="Last Name"
                CssClass="txtLoginControl"></asp:TextBox>
        </div>
        <div class="text-center">
            <asp:Button ID="ucButton1" runat="server" Text="Create an account" ValidationGroup="ForgetPwd"
                OnClick="BttnSubmit_Click" CssClass="LoginButton" Style="margin: 0px; padding: 5px 15px 5px 15px;
                min-width: 101px;" />
            &nbsp;&nbsp;
            <%--<asp:Button ID="btncancelsignup" runat="server" Text="Cancel" CssClass="LoginButton"
                Style="margin: 0px; padding: 5px 15px 5px 15px; min-width: 101px;" />--%>
            <input type="button" id="ucbtncancelsignup" value="Cancel" style="margin: 0px; padding: 5px 15px 5px 15px;
                min-width: 101px;" onclick="showLogin()" />
        </div>
    </div>
</div>
