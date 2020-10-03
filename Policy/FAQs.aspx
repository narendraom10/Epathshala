<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Epathshala.master" AutoEventWireup="true"
    CodeFile="FAQs.aspx.cs" Inherits="Policy_FAQs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <%--<script type="text/javascript">
    jQuery(document).ready(function () {
        function close_accordion_section() {
            jQuery('.accordion .accordion-section-title').removeClass('active');
            jQuery('.accordion .accordion-section-content').slideUp(300).removeClass('open');
        }

        // To Load Page with First Accordion Panel open by default.
        jQuery("#accordion-1").addClass('active');
        jQuery('.accordion #accordion-1').slideDown(300).addClass('open');

        //*********************************************************************

        jQuery('.accordion-section-title').click(function (e) {
            debugger;
            // Grab current anchor value
            var currentAttrValue = jQuery(this).attr('href');

            if (jQuery(e.target).is('.active')) {
                close_accordion_section();
            } else {
                close_accordion_section();

                // Add active class to section title
                jQuery(this).addClass('active');
                // Open up the hidden content panel
                jQuery('.accordion ' + currentAttrValue).slideDown(300).addClass('open');
            }

            e.preventDefault();
        });
    });
    </script>--%>
    <style type="text/css">
        *
        {
            text-align: justify;
        }
    </style>
    <%--<style type="text/css">
       
        /*------------------------------------*\
-------- DEMO Code: accordion
\*------------------------------------*/
        /*----- Accordion -----*/
        .accordion, .accordion *
        {
            -webkit-box-sizing: border-box;
            -moz-box-sizing: border-box;
            box-sizing: border-box;
        }
        
        .accordion
        {
            overflow: hidden;
            box-shadow: 0px 1px 3px rgba(0,0,0,0.25);
            border-radius: 0px;
            background: #f7f7f7;
            font-family: Calibri;
            
        }
        
        /*----- Section Titles -----*/
        .accordion-section-title
        {
            height:30px;
            margin: 2px 2px 1px 2px;
            width: 100%;
            padding: 8px;
            display: inline-block;
            border-bottom: 1px solid #CE651A;
            background: #F57921;
            transition: all linear 0.15s; /* Type */
            font-size: 1.100em;
            text-shadow: 0px 1px 0px #1a1a1a;
            color: #fff;
            background-image: url('App_Themes/Responsive/images/accord_left.png');
            background-repeat: no-repeat;
            background-position: left;
            text-indent: 20px; /*border-radius: 5px;*/
            background-size: 24px 24px;
        }
        
        .accordion-section-title.active, .accordion-section-title:hover
        {
            background: #CE651A; /* Type */
            text-decoration: none;
            background-image: url('App_Themes/Responsive/images/accord_left.png');
            background-repeat: no-repeat;
            background-position: left;
            text-indent: 20px;
            text-indent: 22px;
        }
        .accordion-section-title.active
        {
            background-image: url('App_Themes/Responsive/images/accord_down.png');
            background-repeat: no-repeat;
            background-position: left;
            text-indent: 20px;
        }
        
        .accordion-section:last-child .accordion-section-title
        {
            border-bottom: none;
        }
        
        /*----- Section Content -----*/
        .accordion-section-content
        {
            padding: 12px;
            margin-left: 2px;
            display: none;
            border: 1px SOLID #CE651A;
            background-color: #E7E7E7;
        }
        .accordion-section-content label
        {
            color: #AC2B28;
            font-weight: bold;
        }
        .accordion-section-content p
        {
            font-size: medium; /*            border-bottom: 1px Dotted GRAY;*/
            color: black;
            line-height: normal;
            text-align: justify;
            margin-bottom: 15px;
            line-height: 1.3em;
            margin-top: 5px;
        }
        ul
        {
            font-size: medium;
            color: Black;
            padding:20px;
        }
        
        *
        {
            text-align:justify;
            }
        
    </style>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row DBHeader">
        <div class="col-sm-8 NoPadding">
            <div class="DashboardHeading">
                You are here: <span style="color: White;">FAQs</span>
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
            <div class="Section1">
                <h3 style="color: #333; font-family: Calibri; font-size: 30px;">
                    <strong>FAQs</strong>
                </h3>
                <label>
                    <b>Q. What is ePathshala?</b></label>
                <p>
                    A: ePathshala is Diagnostic, Remedial and Developmental online school. It Provides
                    Preventive, Curative and Progressive learning measures. It is a user friendly online
                    e-learning product which facilitates educational content of various boards in digital
                    formats. Students can gain knowledge on their own comforts and at their own pace
                    anywhere, any time.
                </p>
                <label>
                    <b>Q. How do I join ePathshala?</b></label>
                <p>
                    A: To join ePathshala, you need to visit www.ePathshala.co.in. There you will need
                    to fill up the registration form available and click on 'Register' button. You will
                    get your login id & password. That's it. Now you can login to ePathshala by entering
                    login id and password which is generated for you.
                </p>
                 <label>
                    <b>Q. How to register with ePathshala ?</b></label>
                <p>
                    A: For Registration process <a href="https://www.youtube.com/watch?v=x4_F_K4csK8"><u>Click here</u></a> to know complete process.  
                </p>
                   <label>
                    <b>Q. How to subscribe ePathshala Package ?</b></label>
                <p>
                    A: For Subscription ePathshala Package <a href="https://www.youtube.com/watch?v=jQn0PsJfRNE"><u>Click here</u></a> to know complete process.  
                </p> 
                <label>
                    <b>Q. Why should I join ePathshala?</b></label>
                <p>
                    A : ePathshala is useful for Students / Parents or Guardian/ Teachers / School and
                    following are just few points how it is useful for whom.
                </p>
                <ul style="padding: 20px; color: black;">
                    <li><b>Student</b>
                        <ul style="padding: 20px; color: black;">
                            <li>Education can be obtained and grasped along with development of memory power with
                                ease and comfort with the help of effective software and through visual aid and
                                creative and artistic presentation. </li>
                            <li>Development of social skills</li>
                            <li>Development of thinking power as well as opportunity to learn in logical manner.</li>
                            <li>Solution oriented as well as development supported education.</li>
                            <li>Practical education.</li>
                        </ul>
                    </li>
                    <li>Parents / Guardians:
                        <ul style="padding: 20px; color: black;">
                            <li>Availability of information of children on their evaluation reports in terms of
                                their performance and statistical information. Reports on Progress of children can
                                be available easily. </li>
                        </ul>
                    </li>
                    <li>Teachers
                        <ul style="padding: 20px; color: black;">
                            <li>Planning for teaching lesson in innovative way</li>
                            <li>Ability and flexibility to design test papers according to interest and level of
                                children</li>
                            <li>Effective utilization of time</li>
                            <li>Preparation of teaching plan can be made easier because of availability of multimedia
                                tool as well as self-assessment facility.</li>
                            <li>Opportunity to interact with students and to provide feedback to students.</li>
                        </ul>
                    </li>
                    <li>Schools
                        <ul style="padding: 20px; color: black;">
                            <li>Effective method of teaching.</li>
                            <li>Effective methods of assessment</li>
                            <li>Utilization of effective education and qualitative methods of school programs</li>
                        </ul>
                    </li>
                </ul>
                <br />
                <label>
                    <b>Q. I forgot my password. What should I do?</b></label>
                <p>
                    A: You can recover your password in case you forgot it. Go to Login page and click
                    on 'Forget your password' link. A box will appear and will ask you to enter your
                    login/registered email address and submit it. Your login details including password
                    will be sent to you on your registered email.
                </p>
                <label>
                    <b>Q. How can I change my ePathshala login password? </b>
                </label>
                <p>
                    A: You can change your ePathshala password by following the steps given below:
                    <ul style="padding: 20px; color: black;">
                        <li>Login to you ePathshala account.</li>
                        <li>Click on 'Change Password' option availble on top right corner.</li>
                        <li>Enter New password and confirm password.</li>
                        <li>Click on Change button.</li>
                        <li>Your new password will be activated.</li>
                    </ul>
                </p>
                <label>
                    <b>Q. How can I modify my Profile?</b></label>
                <p>
                    A: To modify your profile follow the steps below:
                    <ul style="padding: 20px; color: black;">
                        <li>Login to you ePathshala account.</li>
                        <li>Click on 'Update Profile' option availble on top right corner.</li>
                        <li>You will be redirected to Update profile page.</li>
                        <li>Here, you can see your current available details and can modify the same.</li>
                        <li>Click on Update button.</li>
                    </ul>
                </p>
                <label>
                    <b>Q. What is minimum connection speed required to use ePathshala?</b></label>
                <p>
                    <i>Answer :</i> A minimum connection speed required is 512Kbps.
                </p>
                <br />
                <label>
                    Q. What are various types of payment methods available if in case I wish to subscribe
                    for this product service?
                </label>
                <p>
                    A: Following online payment options are available:
                </p>
                <ul style="padding: 20px; color: black;">
                    <li>Net Banking</li>
                    <li>Credit Card</li>
                    <li>Debit Card</li>
                    <li>IMPS</li>
                    <li>Amrerican Express Cards</li>
                </ul>
                <label>
                    Q. Can I cancel my Subscription?
                </label>
                <p>
                    A: No. You cannot unsubscribe package once purchased which mean, once subscription
                    is paid, it is non-refundable.
                </p>
                <label>
                    Q. What will be validity of subscription paid by me?
                </label>
                <p>
                    A: The validity of your course varies according to packages you purchase. For this
                    you need to see validity column of particular package(s) you are buying. Or you
                    can view all the details regarding your active packages and their expiration dates
                    on your package details page.
                </p>
                <label>
                    Q. Will my account opened with ePathshala be disabled after trial package expires?
                </label>
                <p>
                    A: No. Your ePathshala account will be active once registered. However for utilization
                    of services; you will need to pay subscription. User will be able to login to their
                    respective account like before.
                </p>
                <label>
                    Q: What is Payment Gateway?
                </label>
                <p>
                    A: A payment gateway is intermediate interface for payment transaction between merchant
                    and buyer while making payments online.
                </p>
                <label>
                    Q: How to make payment with Online Banking?
                </label>
                <p>
                    A: For those who wish to pay using Online Banking payment method must have active
                    internet banking facility with their respective banks.
                </p>
                <label>
                    <b>Q. What if my online payment transaction fails? </b>
                </label>
                <p>
                    A: Your deducted amount will be refunded back to your same account from where payment
                    was processed in case it is failed due to some technical issue.
                </p>
                <label>
                    <b>Q. I haven't received my payment receipt. What should I do? </b>
                </label>
                <p>
                    A: If your payment is successful and you have not received your acknowledgment receipt,
                    you can download the same by logging to your account and selecting your active package
                    detail page.
                </p>
                <label>
                    <b>Q: Are Online Transactions safe? </b>
                </label>
                <p>
                    A: Yes your online transactions are 3D Secure and completely safe.
                </p>
                <label>
                    Q: What is OTP?</label>
                <p>
                    A: An OTP is a unique One Time Password code which is sent to registred mobile while
                    making online payments through internet banking or Debit cards. The payment process
                    only proceeds once a sent OTP is entered. Once used in transaction it expires as
                    name suggests it is one time.
                </p>
                <label>
                    <b>Q: What is your refund policy? </b>
                </label>
                <p>
                    A: No, Payment once made cannot be refunded or transferred in any case. We do not
                    have refund return policy.
                </p>
            </div>
        </div>
    </div>
</asp:Content>
