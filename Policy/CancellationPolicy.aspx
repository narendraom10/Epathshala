<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Epathshala.master" AutoEventWireup="true"
    CodeFile="CancellationPolicy.aspx.cs" Inherits="Policy_CancellationPolicy" %>

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
                You are here: <span style="color:White;">Cancellation Policy</span>
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
                <b><span lang="EN-US">Cancellation Policy </span></b>
            </p>
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
                    <br />
                </span>
            </p>
            </div>
        </div>
    </div>
</asp:Content>
