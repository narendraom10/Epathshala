<%@ Page Title="" Language="C#" MasterPageFile="~/NewPublic/epath2016.Master" AutoEventWireup="true"
    CodeFile="login.aspx.cs" Inherits="NewPublic_login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="epath-page-title-1" data-stellar-background-ratio="0.5">
        <div class="container">
            <div class="row">
                <div class="col-lg-9 col-md-9 col-sm-9">
                    <h1>
                        ePathshala <strong>Login</strong></h1>
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
                            <strong>Login</strong> here</h2>
                        <div class="envor-f1">
                            <p>
                                <label>
                                    User ID:*</label>
                                <asp:TextBox ID="uctxtUserName" runat="server" placeholder="User ID"></asp:TextBox>
                                <%--<input type="text" name="drop-name" id="drop-name">--%>
                                <asp:RequiredFieldValidator ID="ucrqdUserName" runat="server" ControlToValidate="uctxtUserName"
                                    ErrorMessage="Please Enter Username." ValidationGroup="ucLogin" Display="None"></asp:RequiredFieldValidator>
                            </p>
                            <p>
                                <label>
                                    Password:*</label>
                                <asp:TextBox ID="uctxtUserPassword" runat="server" TextMode="Password" placeholder="Password"></asp:TextBox>
                                <%--<input type="text" name="drop-email" id="drop-email">--%>
                                <asp:RequiredFieldValidator ID="ucrqdPassword" runat="server" ControlToValidate="uctxtUserPassword"
                                    ErrorMessage="Please Enter Password." ValidationGroup="ucLogin" Display="None"></asp:RequiredFieldValidator>
                            </p>
                            <p>
                                <label>
                                    Remember Me:</label>
                                <asp:CheckBox ID="ucchkRememberMe" runat="server" Text="" />
                            </p>
                            <p style="text-align: left;">
                                <asp:Button ID="ucbtnGo" runat="server" ClientIDMode="Static" Text="Log in" ValidationGroup="ucLogin"
                                    OnClick="btnGo_Click" CssClass="epath-btn epath-btn-normal epath-btn-primary" />
                                <asp:Button ID="btncancel" runat="server" Text="Cancel" CssClass="epath-btn epath-btn-normal epath-btn-primary"
                                    Style="margin: 0px; padding: 5px 15px 5px 15px; min-width: 101px;" OnClick="btncancel_Click"
                                    CausesValidation="false" Visible="false" />
                            </p>
                            <p>
                                <a href="register.aspx"><span style="text-decoration: underline;">Create New Account</span></a>
                            </p>
                            <p>
                                <a href="forgotpassword.aspx"><span style="text-decoration: underline;">Forgot Password?</span></a>
                            </p>
                            <p>
                                <asp:ValidationSummary ID="ucvsumTeacherLogin" runat="server" ValidationGroup="ucLogin"
                                    CssClass="Summary" ShowMessageBox="false" ShowSummary="true" />
                            </p>
                            <p>
                                <asp:Label ID="ucinvalididpassword" runat="server" ForeColor="Red"></asp:Label>
                            </p>
                        </div>
                    </div>
                </div>
                <div class="col-lg-12 col-md-12">
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
                </div>
            </div>
        </div>
    </section>
</asp:Content>
