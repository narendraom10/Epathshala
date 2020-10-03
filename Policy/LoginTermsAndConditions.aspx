<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/CommonHeaderFooter.master"
    AutoEventWireup="true" CodeFile="LoginTermsAndConditions.aspx.cs" Inherits="Policy_LoginTermsAndConditions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function checkbox_changed() {
            var checkbox = document.getElementById("chkAgree");
            if (checkbox.checked == true) {
                document.getElementById("btnAgree").disabled = false;
            } else {
                document.getElementById("btnAgree").disabled = true;
            }
        }
    </script>
    <%--<style type="text/css">
        *
        {
            /* text-align: justify; */
        }
        
        ul
        {
            padding: 15px;
        }
    </style>--%>
    <script type="text/javascript">
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
    </script>
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
    <%--<div class="Section1">--%>
    <%--    <p>
            <b><span lang="EN-US">Terms & Conditions for Online Utilization of Services of Content
            </span></b>
        </p>
        <p>
            <span lang="EN-US">User who wish to avail services of content, will be required to register
                on our website, www.epathshala.co.in
                <ul>
                    <li>The Content will be accessed only after successful payment. On successful payment,
                        registration number/login id and password will be sent on mail id of user which
                        is mentioned while registering with us and by using same id & password, user will
                        be able to access the content for which he/she has made payment. </li>
                    <li>The access to content will be permitted only for the chosen/selected portion for
                        which payment is made. </li>
                    <li>The access to content will be continued only for the period for which payment is
                        made. </li>
                    <li>Prices for utilization can be changed any time as per the discretion of Arraycom
                        (India) Ltd.</li>
                    <li>Downloading / copying of whatsoever nature of content is strictly prohibited. It
                        will be traced out and come to the attention of the company that content is copied/downloaded,
                        in that event company may take appropriate action as it deem necessary including
                        legal action.</li>
                    <li>Payment will be allowed through our authorized payment gateway only and no other
                        mode of payment is permitted for utilization of services of content.</li>
                    <li>No dispute will be entertained on the quality of content. However, if dispute is
                        of any other nature, the reference document to communicate with us will be our Invoice
                        which will be generated on making payment for user.</li>
                </ul>
            </span>
        </p>
        <p>
            <b><span lang="EN-US">Payment Options </span></b>
        </p>
        <p>
            <span lang="EN-US">
                <ul>
                    <li>All payment options listed by ATOM. The charges will be billed to your account as
                        "ATOM" .All prices are listed in Indian Rupees. If you use a non-Indian credit/debit
                        card/Net Banking facility, your bank will automatically convert to your home currency
                        based on that day's exchange rates. When you press pay button in the ATOM payment
                        gateway page, the server will process your transaction in about 30 seconds, but
                        it may be longer at certain times. So wait for some more time. To avoid double charge,
                        DO NOT press the Submit button more than once, or press the back or Refresh buttons.
                        Non-authorization of payment more than once by payment gateway will result in deregistration
                        of your account with this site, without any notice. Charges include all applicable
                        taxes.</li>
                    <li>All payments have to be made to under advice to us. You must not make any payment
                        to any other account under any circumstance. Arraycom (India) Ltd. will not be responsible
                        in case you ignore this advice and still make a payment to any unauthorized persons/accounts.</li>
                </ul>
            </span>
        </p>
        <p>
            <b><span lang="EN-US">Delivery / Shipping Policy</span></b>
        </p>
        <p>
            <span lang="EN-US">Our services will be made available for usage to customer immediately
                on making payment.
                <br />
                <br />
            </span>
        </p>--%>
    <div class="Section1">
    <h3>Terms and Condition</h3>
    <hr />
        <p>
            <span lang="EN-US">User who wish to avail services of content, will be required to register
                on our website, www.epathshala.co.in
                <ul>
                    <li>The Content will be accessed only after successful payment. On successful payment,
                        registration number/login id and password will be sent on mail id of user which
                        is mentioned while registering with us and by using same id & password, user will
                        be able to access the content for which he/she has made payment. </li>
                    <li>The access to content will be permitted only for the chosen/selected portion for
                        which payment is made. </li>
                    <li>The access to content will be continued only for the period for which payment is
                        made. </li>
                    <li>Prices for utilization can be changed any time as per the discretion of Arraycom
                        (India) Ltd.</li>
                    <li>Downloading / copying of whatsoever nature of content is strictly prohibited. It
                        will be traced out and come to the attention of the company that content is copied/downloaded,
                        in that event company may take appropriate action as it deem necessary including
                        legal action.</li>
                    <li>Payment will be allowed through our authorized payment gateway only and no other
                        mode of payment is permitted for utilization of services of content.</li>
                    <li>No dispute will be entertained on the quality of content. However, if dispute is
                        of any other nature, the reference document to communicate with us will be our Invoice
                        which will be generated on making payment for user.</li>
                </ul>
            </span>
        </p>
        <p>
            <b><span lang="EN-US">Payment Options </span></b>
        </p>
        <p>
            <span lang="EN-US">
                <ul>
                    <li>All payment options listed by ATOM. The charges will be billed to your account as
                        "ATOM" .All prices are listed in Indian Rupees. If you use a non-Indian credit/debit
                        card/Net Banking facility, your bank will automatically convert to your home currency
                        based on that day's exchange rates. When you press pay button in the ATOM payment
                        gateway page, the server will process your transaction in about 30 seconds, but
                        it may be longer at certain times. So wait for some more time. To avoid double charge,
                        DO NOT press the Submit button more than once, or press the back or Refresh buttons.
                        Non-authorization of payment more than once by payment gateway will result in deregistration
                        of your account with this site, without any notice. Charges include all applicable
                        taxes.</li>
                    <li>All payments have to be made to under advice to us. You must not make any payment
                        to any other account under any circumstance. Arraycom (India) Ltd. will not be responsible
                        in case you ignore this advice and still make a payment to any unauthorized persons/accounts.</li>
                </ul>
            </span>
        </p>
        <p>
            <b><span lang="EN-US">Delivery / Shipping Policy</span></b>
        </p>
        
        <p>
            <span lang="EN-US">Our services will be made available for usage to customer immediately
                on making payment.
                <br />
                <br />
            </span>
        </p>

        <%--<p>
            <b><span lang="EN-US">Terms & Conditions for Online Utilization of Services of Content
            </span></b>
        </p>
        <p>
            <span lang="EN-US">User who wish to avail services of content, will be required to register
                on our website, www.epathshala.co.in
                <ul>
                    <li>The Content will be accessed only after successful payment. On successful payment,
                        registration number/login id and password will be sent on mail id of user which
                        is mentioned while registering with us and by using same id & password, user will
                        be able to access the content for which he/she has made payment. </li>
                    <li>The access to content will be permitted only for the chosen/selected portion for
                        which payment is made. </li>
                    <li>The access to content will be continued only for the period for which payment is
                        made. </li>
                    <li>Prices for utilization can be changed any time as per the discretion of Arraycom
                        (India) Ltd.</li>
                    <li>Downloading / copying of whatsoever nature of content is strictly prohibited. It
                        will be traced out and come to the attention of the company that content is copied/downloaded,
                        in that event company may take appropriate action as it deem necessary including
                        legal action.</li>
                    <li>Payment will be allowed through our authorized payment gateway only and no other
                        mode of payment is permitted for utilization of services of content.</li>
                    <li>No dispute will be entertained on the quality of content. However, if dispute is
                        of any other nature, the reference document to communicate with us will be our Invoice
                        which will be generated on making payment for user.</li>
                </ul>
            </span>
        </p>
        <p>
            <b><span lang="EN-US">Payment Options </span></b>
        </p>
        <p>
            <span lang="EN-US">
                <ul>
                    <li>All payment options listed by ATOM. The charges will be billed to your account as
                        "ATOM" .All prices are listed in Indian Rupees. If you use a non-Indian credit/debit
                        card/Net Banking facility, your bank will automatically convert to your home currency
                        based on that day's exchange rates. When you press pay button in the ATOM payment
                        gateway page, the server will process your transaction in about 30 seconds, but
                        it may be longer at certain times. So wait for some more time. To avoid double charge,
                        DO NOT press the Submit button more than once, or press the back or Refresh buttons.
                        Non-authorization of payment more than once by payment gateway will result in deregistration
                        of your account with this site, without any notice. Charges include all applicable
                        taxes.</li>
                    <li>All payments have to be made to under advice to us. You must not make any payment
                        to any other account under any circumstance. Arraycom (India) Ltd. will not be responsible
                        in case you ignore this advice and still make a payment to any unauthorized persons/accounts.</li>
                </ul>
            </span>
        </p>
        <p>
            <b><span lang="EN-US">Delivery / Shipping Policy</span></b>
        </p>
        <p>
            <span lang="EN-US">Our services will be made available for usage to customer immediately
                on making payment.
                <br />
                <br />
            </span>
        </p>--%>
    </div>
    <%--  </div>--%>
    <%--<div style="float: right; visibility: hidden; display: none;">
        <input type="checkbox" id="chkAgree" runat="server" name="chkAgree" value="" onchange="checkbox_changed()" /><span
            style="margin-left: 5px;">I agree to the Arraycom (India) Ltd. Terms of Service
            and Privacy Policy. </span>
        <input type="button" id="btnAgree" runat="server" name="btnAgree" value="Submit"
            disabled="disabled" style="margin-left: 15px;" />
    </div>--%>
</asp:Content>
