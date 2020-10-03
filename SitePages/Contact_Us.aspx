<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Epathshala.master" AutoEventWireup="true"
    CodeFile="Contact_Us.aspx.cs" Inherits="SitePages_Contact_Us" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row DBHeader">
        <div class="col-sm-8 NoPadding">
            <div class="DashboardHeading">
                You are here: <span style="color: White;">Contact Us</span>
            </div>
        </div>
        <div class="col-sm-4 NoPadding">
            <div class="DashboardHeading">
                <img src="../App_Themes/Green/Images/icon-calendar.png" />
                <%--Today: <asp:Literal runat="server" ID="litDateNow" Text='<%# Eval(DateTime.Now.ToString("DD-MMM-YYYY")) %>'></asp:Literal> --%>
                Today:
                <%=DateTime.Now.ToString("dd MMM, yyyy") %>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-12">
            <div>
                <%--<iframe width="100%" height="400" frameborder="0" src="https://www.google.com/maps/embed?pb=!1m14!1m8!1m3!1d469209.4507867105!2d72.6323771!3d23.254043900000003!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x395c2c09fdc95a85%3A0xf1404f126ff31039!2sArraycom+India+Ltd!5e0!3m2!1sen!2sin!4v1403172940863"
                    style="border: 1px solid #ccc"></iframe>--%>
                <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d14662.591533681545!2d72.62934682100358!3d23.2558970812226!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x0%3A0x703c5a7cb2a743d4!2sePathshala!5e0!3m2!1sen!2s!4v1446463381240"
                    width="100%" height="400" frameborder="0" style="border: 0"></iframe>
            </div>
            <div style="box-shadow: none; margin-top: 15px; color: Black;" class="main-content-part">
                <ul class="contact-us-content" style="list-style: none;">
                    <li>B-13, 13/1 &amp; 14, Electronic Estate, GIDC<br />
                        Sector - 25, Gandhinagar - 382 024</li>
                    <li><strong>Phone:</strong> +91 79 2328 7030 / 32 / 33 / 36</li>
                    <li><strong>Fax: </strong>+91 79 2328 7031</li>
                    <li><strong>Email:</strong> <a href="mailto: info@epath.net.in" style="color: #3f88c5;
                        text-decoration: underline;">info@epath.net.in</a></li>
                </ul>
            </div>
            <div class="main-content-part frm form-item">
                <div>
                    <label>
                        Name <span title="This field is required.">*</span></label>
                    <input type="text" maxlength="128" size="60" id="name" runat="server" placeholder="Name"
                        class="form-control" />
                </div>
                <div>
                    <label>
                        Email <span title="This field is required.">*</span></label>
                    <input type="text" maxlength="128" size="60" id="email" runat="server" placeholder="Email"
                        class="form-control" />
                </div>
                <div>
                    <label>
                        Phone <span title="This field is required.">*</span></label>
                    <input type="text" maxlength="128" size="60" id="phone" runat="server" placeholder=""
                        class="form-control">
                </div>
                <div>
                    <label>
                        Comment
                    </label>
                    <div>
                        <textarea rows="5" cols="60" id="comment" runat="server" class="form-control" placeholder="Place your query here."></textarea><div>
                        </div>
                    </div>
                </div>
                <asp:Button ID="btnsubmitquery" Text="submit" value="Submit" class="form-submit"
                    runat="server" OnClientClick="javascript:return SubmitQuery();" OnClick="btnsubmitquery_Click" />
            </div>
        </div>
    </div>
    <script type="text/javascript">
        function SubmitQuery() {
            var name = document.getElementById('<%= name.ClientID %>').value;
            if (name == null || name.trim() == "") {
                alert('Please enter name');
                document.getElementById('<%= name.ClientID %>').focus();
                return false; // cancel submission
            }
            var email = document.getElementById('<%= email.ClientID %>').value;
            if (email == null || email.trim() == "") {
                alert('Please enter email');
                document.getElementById('<%= email.ClientID %>').focus();
                return false; // cancel submission
            }

            var pattern = /^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$/;
            var isemail = pattern.test(email);
            if (!isemail) {
                alert('Please enter valid email');
                document.getElementById('<%= email.ClientID %>').focus();
                return false;
            }

            var phone = document.getElementById('<%= phone.ClientID %>').value;
            if (phone == null || phone.trim() == "") {
                alert('Please enter phone');
                document.getElementById('<%= phone.ClientID %>').focus();
                return false; // cancel submission
            }

            var pattern = /^\d{8,12}$/;
            var isphone = pattern.test(phone);
            if (!isphone) {
                alert('Please enter valid phone');
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
</asp:Content>
