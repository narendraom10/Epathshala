<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/CommonHeaderFooter.master"
    AutoEventWireup="true" CodeFile="LoginCancellationPolicy.aspx.cs" Inherits="Policy_LoginCancellationPolicy" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        *
        {
            /* text-align: justify; */
        }
    </style>
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
            /*text-align: justify; */
        }
    </style>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="Section1">
    <h3>Cancellation Policy</h3>
    <hr />
        <p>
            <span lang="EN-US">As of now we do not provide any option for non-utilization of services
                for which you have made payment or subscribed. Once you have selected portion to
                access and made payment, we cannot provide any refund, either totally or partially.
                We suggest that first you go through the demos and/or free to use contents/products/services
                before you pay / subscribe from our site, www.epathshala.co.in
                <br />
                <br />
            </span>
        </p>
        <p>
            <b><span lang="EN-US">Refund in case of failed transactions</span></b>
        </p>
        <p>
            <span lang="EN-US">Though Epathshala’s payment reconciliation team works on a Daily
                basis except holidays, there are other organizations involved in processing of online
                transactions, which could result in delays in credit of refunds to customer account.
                Usually credit towards failed transaction will be made within 15 / 20 working days.
                <br />
                <br />
            </span>
        </p>
        <p>
            <b><span lang="EN-US">Refund in case of Duplication in Payment</span></b>
        </p>
        <p>
            <span lang="EN-US">Similar to clause as mentioned under ‘Refund towards Failed Transaction’,
                our payment reconciliation team will be monitoring continuously regarding receipt
                of payments and on observing case of duplicate payment for same services (package)
                if it is noticed that payment is made twice, one payment will be credited back to
                the same account from which payment is made within 15/20 working days.
                <br />
            </span>
        </p>
    </div>
</asp:Content>
