<%@ Page Title="" Language="C#" MasterPageFile="~/NewPublic/epath2016.Master" AutoEventWireup="true"
    CodeFile="contact.aspx.cs" Inherits="NewPublic_contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function SubmitQuery() {
            var name = document.getElementById('<%= name.ClientID %>').value;
            if (name == null || name.trim() == "") {
                alert('Please enter Name.');
                document.getElementById('<%= name.ClientID %>').focus();
                return false; // cancel submission
            }
            var email = document.getElementById('<%= email.ClientID %>').value;
            if (email == null || email.trim() == "") {
                alert('Please enter Email.');
                document.getElementById('<%= email.ClientID %>').focus();
                return false; // cancel submission
            }

            //            var pattern = /^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$/;
            //            var isemail = pattern.test(email);
            //            if (!isemail) {
            //                alert('Please enter valid Email');
            //                document.getElementById('<%= email.ClientID %>').focus();
            //                return false;
            //            }

            var phone = document.getElementById('<%= phone.ClientID %>').value;
            if (phone == null || phone.trim() == "") {
                alert('Please enter Phone number.');
                document.getElementById('<%= phone.ClientID %>').focus();
                return false; // cancel submission
            }
            var pattern = /^\d{8,12}$/;
            var isphone = pattern.test(phone);
            if (!isphone) {
                alert('Please enter valid phone Number');
                document.getElementById('<%= phone.ClientID %>').focus();
                return false;
            }
            var comment = document.getElementById('<%= comment.ClientID %>').value;
            if (comment == null || comment.trim() == "") {
                alert('Please enter comment');
                document.getElementById('<%= comment.ClientID %>').focus();
                return false; // cancel submission
            }
            return true;
        }
    </script> 
    <style type="text/css">
        .textarea1
        {
            min-width: 250px !important;
            max-height: 75px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="epath-page-title-1" data-stellar-background-ratio="0.5">
        <div class="container">
            <div class="row">
                <div class="col-lg-9 col-md-9 col-sm-9">
                    <h1>
                        Contact <strong>us</strong></h1>
                </div>
            </div>
        </div>
    </section>
    <section class="epath-section">
        <div class="container">
            <div class="row">
                <div class="col-lg-3 col-md-3">
                    <h3>
                        <strong>Contact</strong> Info</h3>
                    <p class="contact-item">
                        <i class="fa fa-map-marker"></i>B-13, 13/1 & 14, Electronic Estate, GIDC Sector
                        - 25, Gandhinagar - 382 024</p>
                    <p class="contact-item">
                        <i class="fa fa-phone"></i>+91 79 2328 7030 / 32 / 33 / 36</p>
                    <p class="contact-item">
                        <i class="fa fa-envelope"></i><a href="mailto:info@epath.net.in">info@epath.net.in</a></p>
                   
                    <div class="epath-team-1-details">
                      
                      <p class="links">
                        <a href="https://www.facebook.com/myepathshala" target="_blank"><i class="fa fa-facebook"></i></a>
                        <a href="https://twitter.com/myepathshala" target="_blank"><i class="fa fa-twitter"></i></a>
                        <a href="https://plus.google.com/107382785045892082006" target="_blank"><i class="fa fa-google"></i></a>
                        <a href="https://www.youtube.com/channel/UCxoGyrJicnxPvZZMwezAK6Q" target="_blank"><i class="fa fa-youtube"></i></a>
                      </p>
                    </div>
                    
                </div>
                <div class="col-lg-3 col-md-3">
                    <h3>
                        Drop us a <strong>Line</strong></h3>
                    <div class="epath-f1">
                        <p>
                            <label >
                                Your name:*</label><input type="text" id="name" placeholder="Name" runat="server" /></p>
                        <p>
                            <label >
                                Your email:*</label><input type="text" id="email" placeholder="Email" runat="server" /></p>
                        <p>
                            <label >
                                Phone:*</label><input type="text" id="phone" name="phone" placeholder="Contact Number"
                                    runat="server" /></p>
                        <p>
                            <label>
                                Comments:</label>
                            <textarea class="textarea1" rows="7" id="comment" placeholder="Your message..." runat="server"
                                style="line-height: 100%; height: 70px; width: 50px;" cols="50"></textarea>
                        </p>
                        <p>
                            <asp:Button ID="btnsubmitquery" Text="Send Message" class="epath-btn epath-btn-normal epath-btn-primary riva-prev-tab margin-left-0"
                                runat="server" OnClientClick="javascript:return SubmitQuery();" OnClick="btnsubmitquery_Click" />
                        </p>
                    </div>
                </div>
                <div class="col-lg-6 col-md-6">
                    <div id="map-canvas">
                        <div>
                            <iframe allowfullscreen="true" width="100%" height="400" style="border: 0" src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d14662.591533681545!2d72.62934682100358!3d23.2558970812226!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x0%3A0x703c5a7cb2a743d4!2sePathshala!5e0!3m2!1sen!2s!4v1446463381240">
                            </iframe>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
