<%@ Page Title="" Language="C#" MasterPageFile="~/NewPublic/materialMaster.master" AutoEventWireup="true"   EnableEventValidation="false" 
    CodeFile="forgotpassword.aspx.cs" Inherits="NewPublic_forgotpassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="epath-page-title-1" data-stellar-background-ratio="0.5">
        <div class="container">
            <div class="row">
                <div class="col-lg-9 col-md-9 col-sm-9">
                    <h1>
                        Forgot <strong>Password</strong></h1>
                </div>
                <div class="col-lg-3 col-md-3 col-sm-3">
                </div>
            </div>
        </div>
    </section>
    <section class="epath-section">
        <div class="container">
            <div class="row">
                <div class="col-lg-12 col-md-12">
                    <div class="riva-toggle-tab col-lg-4">
                        <h2>
                            <strong>Account</strong> Recovery</h2>
                        <div class="envor-f1">
                            <p>
                                <label for="drop-emailaddress">
                                    Email Address:*</label>
                                <asp:TextBox ID="uctxtEmail" CssClass="text" Style="padding: 0 5px; width: 90%;"
                                    runat="server" placeholder="abc@domainname.com"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ucRequrdFeldValidatrEmail" ValidationGroup="ForgetPwd"
                                    ControlToValidate="uctxtEmail" runat="server" ErrorMessage="The email field is required"
                                    Text="*"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="ucRegulrExprsnValidtrEmail" ValidationGroup="ForgetPwd"
                                    ControlToValidate="uctxtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                    runat="server" Text="*" ErrorMessage="Enter a valid emailid"></asp:RegularExpressionValidator>
                            </p>
                            <p>
                                <asp:Button ID="ucbtnSubmit" runat="server" Text="Submit" ValidationGroup="ForgetPwd"
                                    OnClick="BttnSubmit_Click" CssClass="epath-btn epath-btn-normal epath-btn-primary" />
                                <asp:Button ID="btncancel" runat="server" Text="Back" CausesValidation="false" OnClick="btncancel_click"
                                    CssClass="epath-btn epath-btn-normal epath-btn-primary" />
                            </p>
                        </div>
                    </div>
                </div>
              <%--  <div class="col-lg-12 col-md-12">
                    <div class="riva-toggle-tab col-lg-8">
                        <h2 class="h2">
                            Why one should register for ePathshala?
                        </h2>
                        <p class="epathshalawhilte">
                            is the innovative solution of ePath Arraycom, to make learning simple, easy, interesting
                            and user friendly with the ultimate goal to empower the children in the process
                            of positive development. It opens up new horizon of experiential learning for the
                            children. The heart & soul of any digital school is curriculum based digital content
                            and ePathshala is the result of experience of the experts of the subjects who have
                            developed content by using modern technology like Internet for making topic informative,
                            by taking help of animated pictures(2D/3D animations) graphics etc. ePathshala is
                            child centric offering an opportunity to revisit previous concepts effortlessly.
                            Every interactive lesson is articulated in a simple language breaking the complex
                            theory into an uncomplicated learning process. Each concept is designed with a blend
                            of local requirements and global standards.
                        </p>
                        <p class="epathshalawhilte">
                            is Diagnostic, Remedial and Developmental online school. It Provides Preventive,
                            Curative and Progressive learning measures.<br />
                        </p>
                        <p class="epathshalawhilte">
                            In order to use online services, you must obtain access to the World Wide Web, either
                            directly or through devices that access web-based content, and pay service fees
                            associated with such access. In addition, you will need to have access to all equipment
                            necessary to make such a connection to the World Wide Web, including a computer
                            and modem or other access devices.
                        </p>
                        <p class="epathshalawhilte">
                            offers K-12 solution and the content is developed on the basis of syllabus which
                            can take care of various state education boards like CBSE (English, Hindi), UP,
                            Gujarat etc.</p>
                        <p class="epathshalawhilte">
                            consists of data bank of questions for assessment of children and it offers facilities
                            like Pre Test, Multiple Choice Questions, worksheets (Practice Sheets), Post Test
                            for each subject and chapter.</p>
                        <p class="epathshalawhilte">
                            For more information or for any query please contact info@epath.net.in</p>
                    </div>
                </div>--%>
            </div>
        </div>
    </section>
</asp:Content>
