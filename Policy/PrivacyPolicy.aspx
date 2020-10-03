<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Epathshala.master" AutoEventWireup="true"
    CodeFile="PrivacyPolicy.aspx.cs" Inherits="Policy_PrivacyPolicy" %>

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
                You are here: <span style="color: White;">Privacy Policy</span>
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
            <div class="Section1 clearfix">
                <p>
                    <b><span lang="EN-US">Privacy Policy </span></b>
                </p>
                <p>
                    <span lang="EN-US">By registering yourself as a user and subscribing to avail the services
                        of this Website, it will be deemed that you have read, understood and agreed to
                        fully abide by all the terms and conditions of the Website as contained herein.
                        Further, by registering on the Website, you agree to:
                        <br />
                        <ul style="padding:20px;color:black;">
                            <li>Make your contact details available to Arraycom (India) Ltd. so that you may be
                                contacted by Arraycom (India) Ltd. for education information through email, telephone
                                and SMS.</li>
                            <li>Receive promotional mails/special offers from the Website.</li>
                            <li>Be contacted by Arraycom (India) Ltd. in accordance with the privacy settings set
                                by you.</li>
                        </ul>
                        The right to use the services of the Website is permission basis as per the terms
                        and conditions contained herein. Except the usage of the services during the validity
                        period, the registered users shall not have any right or title over the Website
                        or any of its contents.
                        <br />
                        <br />
                        In order to use online services, you must obtain access to the World Wide Web, either
                        directly or through devices that access web-based content, and pay service fees
                        associated with such access. In addition, you will need to have access to all equipment
                        necessary to make such a connection to the World Wide Web, including a computer
                        and modem or other access devices.
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
                        <br />
                    </span>
                </p>
              
            </div>
        </div>
    </div>
</asp:Content>
