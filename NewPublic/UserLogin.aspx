<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserLogin.aspx.cs" Inherits="NewPublic_UserLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
     
   
      
    <link href="../App_Themes/bootstrap-3.3.7-dist/css/bootstrap.min.css" rel="stylesheet" />
    <script src="../App_Themes/bootstrap-3.3.7-dist/js/bootstrap.min.js"></script>
    <script src="../assets/js/core/jquery.min.js" type="text/javascript"></script>
    <link href="../App_Themes/Responsive/css/font-awesome.min.css" rel="stylesheet" />
    <link href="../App_Themes/login.css" rel="stylesheet" />
   
   
</head>

    <body>
       
         <div class="container">
             <div class="row">
                  
               
                  <div class="Absolute-center">
                    <div class="col-xs-4 col-xs-offset-4 col-sm-4 col-sm-offset-4">

                       
                         <form runat="server" id="loginform">

                              <h2 class="text-center">Login</h2>   

                                <div class="form-group">

                                     <asp:Label ID="Label2" runat="server" text="Email"></asp:Label>
                                      <asp:TextBox ID="uctxtUserName" runat="server" CssClass="form-control" placeholder="Email" ></asp:TextBox>

                                    <asp:RequiredFieldValidator ID="ucrqdUserName" runat="server" ControlToValidate="uctxtUserName"
                                     ErrorMessage="Please Enter Username." ValidationGroup="ucLogin" Display="None" ></asp:RequiredFieldValidator>
                                     
                                </div>
                                <div class="form-group">

                                    <asp:Label ID="Label1" runat="server" text="Password"></asp:Label>
                                    <asp:TextBox ID="uctxtUserPassword" runat="server" TextMode="Password" placeholder="Password" CssClass="form-control"></asp:TextBox>

                                    <asp:RequiredFieldValidator ID="ucrqdPassword" runat="server" ControlToValidate="uctxtUserPassword"
                                        ErrorMessage="Please Enter Password." ValidationGroup="ucLogin" Display="None"></asp:RequiredFieldValidator>


                                </div>
                                <div class="form-group">
                               
                                     <asp:Button ID="ucbtnGo" runat="server" ClientIDMode="Static" Text="Log in" ValidationGroup="ucLogin"
                                            OnClick="btnGo_Click" OnClientClick="javascript:return Validemail();" CssClass="btn login-btn btn-block" />
                                
                                 </div > 

                                <div class="clearfix">

                                     <label class="pull-left checkbox-inline" style="padding-top:3  px!important;"><asp:CheckBox ID="ucchkRememberMe" runat="server" Text="" />Remember</span></label>
                                     <%--    <a href="" class="pull-right" id="FP" data-toggle="modal" data_targer="#forgot-password">Forgot Password?</a>--%>
                                        <button class="btn-link pull-right" id="button1"  type="button" data-target="#forgot-password" data-toggle="modal">Forgot Password?</button>

                                </div>
                                 <div class="form-group">

                                    <p>
                                        <asp:ValidationSummary ID="ucvsumTeacherLogin" runat="server" ValidationGroup="ucLogin"
                                            CssClass="Summary" ShowMessageBox="false" ShowSummary="true" />
                                     <p>
                                        <asp:Label ID="ucinvalididpassword" runat="server" ForeColor="Red"></asp:Label>
                                    </p>
                                 </div>

                                 <%--<div class="or-seperator"><i>or</i></div>
                                  <div class="form-group">
                                     

                                <asp:Button ID="ucbtnfblogin" runat="server" ClientIDMode="Static" Text="Log in with facebook" ValidationGroup="ucLogin"
                                    OnClick="btnGo_Click" CssClass="btn login-btn btn-block" >
                                    
                                     </asp:Button>--%>
                                
                         </div > 


                              <div class="modal  " tabindex="-1" role="dialog" id="forgot-password" aria-labelledby="Forgotpasswordlabel" aria-hidden="true" style="width:500px;">

                                        <div class="modal-dialog" role="document" style="width:400px;margin:20px;" >

                                            <div class="modal-content" >

                                                <div class="modal-header">
                                                     <button type="button" class="close" aria-label="Close" onclick="CloseModal();"><span aria-hidden="true">&times;</span></button>
                                                    <h4 class="modal-title" id="Forgotpasswordlabel"><span class="glyphicon glyphicon-lock"></span>Recover Password!</h4>
                                                </div>
                                                <div class="modal-body">
                    

                                                        <div class="form-group">
                                                          
                                                                <asp:Label ID="Label3" runat="server" text="Email"></asp:Label>
                                                               
                                  
                                                                <asp:TextBox ID="uctxtEmail" runat="server" CssClass="form-control input-lg" placeholder="Enter Email"></asp:TextBox>

                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="uctxtEmail"
                                                                    ErrorMessage="Please Enter Email." ValidationGroup="ucforgot" Display="None"></asp:RequiredFieldValidator>
                                                            </div>
                                                       
                                                          <asp:Button ID="btnforgot" runat="server" ClientIDMode="Static" Text="Submit" ValidationGroup="ucforgot"
                                                                    OnClick="btnforgot_Click" CssClass="btn  btn-block login-btn" UseSubmitBehavior="false" />
                                                      </div>
                                                      
                                                         
                                                            
                                                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="ucforgot"
                                                                    CssClass="Summary" ShowMessageBox="false" ShowSummary="true" />
                         
                                                             
                                                        
                    
                                              
                                                <div class="modal-footer">
                                                                     <p>Remember Password ? <a id="loginModal1" href="UserLogin.aspx">Login Here!</a></p>
                                                </div>
                                            </div>

                                        </div>
        
                                    </div>


                         </form>
                            
                     </div>
                 </div>
                


             </div>
          

    
          


        <script>
            
            function Validemail() {
                
                    var email = document.getElementById("<%=uctxtUserName.ClientID%>");
                    var filter = /^([a-zA-Z0-9_.-])+@(([a-zA-Z0-9-])+.)+([a-zA-Z0-9]{2,4})+$/;
                    if (!filter.test(email.value)) {
                        alert('Please provide a valid email address');
                        email.focus;
                        return false;
                    }
                    return true;
            }
            function CloseModal()
            {
               

                $("#forgot-password").hide();
                $("#loginform").show();
            }
        </script>

        <script>

           
            $(document).ready(function () {
                $("#button1").click(function () {
                   
                    $("#forgot-password").show();
                    //$("#loginform").hide();
                });
            });
        </script>
     
</body>

 
</html>
