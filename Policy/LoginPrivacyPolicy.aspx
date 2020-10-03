<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/CommonHeaderFooter.master"
    AutoEventWireup="true" CodeFile="LoginPrivacyPolicy.aspx.cs" Inherits="Policy_LoginPrivacyPolicy" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <%-- <style type="text/css">
        *
        {
            font-size: 1em;
            line-height: 2em;
            font-family: Arial;
            text-align: justify;
        }
        body
        {
            max-width: 800px;
            margin: auto;
            padding: 5px;
        }
    </style>
    <style type="text/css">
        *
        {
            text-align: justify;
        }
        
        ul
        {
            padding: 15px;
        }
        ul
        {
            padding: 15px;
        }
    </style>--%>
    
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
    <%--<style type="text/css">
        body
        {
            margin: 0px;
            position: relative;
            z-index: 0;
        }
        .main:before
        {
            width: 100%;
            height: 100%;
            position: absolute;
            top: 0px;
            left: 0px;
            z-index: -1;
            content: '';
            background: -webkit-radial-gradient(30%, rgba(255,255,255,0.15), rgba(0,0,0,0)), url('img/body-bg.png');
            background: -moz-radial-gradient(30%, rgba(255,255,255,0.15), rgba(0,0,0,0)), url('img/body-bg.png');
            background: -o-radial-gradient(30%, rgba(255,255,255,0.15), rgba(0,0,0,0)), url('img/body-bg.png');
            background: radial-gradient(30%, rgba(255,255,255,0.15), rgba(0,0,0,0)), url('img/body-bg.png');
        }
        
        .site-header-wrap
        {
            margin-bottom: 60px;
            border-bottom: 1px solid #cd9ad6;
        }
        
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
            margin-bottom: 35px;
        }
        
        /*----- Section Titles -----*/
        .accordion-section-title
        {
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
            padding: 20px;
        }
        
        *
        {
            /* text-align: justify; */
        }
    </style>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="Section1">
    <h3>Privacy Policy</h3>
    <hr />
        <p>
            <span lang="EN-US">By registering yourself as a user and subscribing to avail the services
                of this Website, it will be deemed that you have read, understood and agreed to
                fully abide by all the terms and conditions of the Website as contained herein.
                Further, by registering on the Website, you agree to:
                <br />
            </span>
            <ul>
                <li>Make your contact details available to Arraycom (India) Ltd. so that you may be
                    contacted by Arraycom (India) Ltd. for education information through email, telephone
                    and SMS.</li>
                <li>Receive promotional mails/special offers from the Website.</li>
                <li>Be contacted by Arraycom (India) Ltd. in accordance with the privacy settings set
                    by you.</li>
            </ul>
            <span>The right to use the services of the Website is permission basis as per the terms
                and conditions contained herein. Except the usage of the services during the validity
                period, the registered users shall not have any right or title over the Website
                or any of its contents. </span>
            <br />
            <br />
            <span>In order to use online services, you must obtain access to the World Wide Web,
                either directly or through devices that access web-based content, and pay service
                fees associated with such access. In addition, you will need to have access to all
                equipment necessary to make such a connection to the World Wide Web, including a
                computer and modem or other access devices.
                <br />
                <br />
            </span>
        </p>
        <p>
            <b><span lang="EN-US">User Obligations </span></b>
        </p>
        <p>
            <span lang="EN-US">In consideration of your use of the services, you agree to provide
                correct, precise, up-to-date and complete information about yourself as required
                by the service's registration form wherever necessary, and maintain and promptly
                update the registration data to keep it true, accurate, current and complete.
                <br />
                <br />
                If you provide any information that is untrue, inaccurate, not up-to-date or incomplete,
                Arraycom (India) Ltd. has the right to suspend or terminate your account and refuse
                any and all current or future use of the services (or any portion thereof).
                <br />
                <br />
                While subscribing as a user of this Website, you represent and warrant that you
                are authorized to subscribe and you possess the legal right and capacity to use
                the services. In case of a minor below the age of 18 years of age, registration
                should be done through parent/ guardian and such a parent/ guardian hereby agrees
                to accordingly register and supervise usage by, and be responsible for the action
                of any such minors who use the computer and/or password to access the content. The
                parent/ guardian shall enter into this agreement on behalf of such minor, and bind
                him/her in accordance with all terms and conditions herein. </span>
            <br />
            <br />
        </p>
        <p>
            <b><span lang="EN-US">Links on this Site may connect you to third party sites. Arraycom
                (India) Ltd. further disclaims any responsibility for the content or usage of any
                such third party site </span></b>
        </p>
        <p>
            <b><span lang="EN-US">
                <br />
                How to contact us </span></b>
        </p>
        <p>
            <span lang="EN-US">If you would like to contact us for any reason, please contact us
                at <a href="mailto:shailesh.vaishnav@epath.net.in"><span>shailesh.vaishnav@epath.net.in</span></a>
                OR Phone Number: + 79 23288513.
                <br />
                <br />
            </span>
        </p>
        <p>
            <b><span lang="EN-US">Revisions to these policies </span></b>
        </p>
        <p>
            <span lang="EN-US">Arraycom (India) Ltd. reserves the right to revise, amend or modify
                any of the policies at any time and in any manner it feels appropriate. Any change
                or revision will be posted on our Website.
                <br />
            </span>
        </p>
    </div>
</asp:Content>
