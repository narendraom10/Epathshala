﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Epathshala.master" AutoEventWireup="true"
    CodeFile="TermsAndConditions.aspx.cs" Inherits="Policy_TermsAndConditions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        *
        {
            text-align: justify;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row DBHeader">
        <div class="col-sm-8 NoPadding">
            <div class="DashboardHeading">
                You are here: <span style="color: White;">Terms and Conditions</span>
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
                <p>
                    <b><span lang="EN-US">Terms & Conditions for Online Utilization of Services of Content
                    </span></b>
                </p>
                <p>
                    <span lang="EN-US">User who wish to avail services of content, will be required to register
                        on our website, www.epathshala.co.in
                        <ul style="padding:20px;color:black;">
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
                        <ul style="padding:20px;color:black;">
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
            </div>
            <div style="display: none;">
                <input type="checkbox" id="chkAgree" runat="server" name="chkAgree" value="" onchange="checkbox_changed()" /><span
                    style="margin-left: 5px;">I agree to the Arraycom (India) Ltd. Terms of Service
                    and Privacy Policy. </span>
                <input type="button" id="btnAgree" runat="server" name="btnAgree" value="Submit"
                    disabled="disabled" style="margin-left: 15px;" />
            </div>
        </div>
    </div>
</asp:Content>
