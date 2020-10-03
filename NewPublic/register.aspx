<%@ Page Title="" Language="C#" MasterPageFile="~/NewPublic/epath2016.Master" AutoEventWireup="true"
    CodeFile="register.aspx.cs" Inherits="NewPublic_register" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="epath-page-title-1" data-stellar-background-ratio="0.5">
        <div class="container">
            <div class="row">
                <div class="col-lg-9 col-md-9 col-sm-9">
                    <h1>
                        Student <strong>Registration</strong></h1>
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
                            <strong>Register</strong> here</h2>
                        <div class="epath-f1">
                            <p>
                                <asp:ValidationSummary ID="ValSumStudent" runat="server" ValidationGroup="a" ShowMessageBox="True"
                                    ShowSummary="false" meta:resourcekey="ValSumStudentResource1" />
                            </p>
                            <p>
                                <label>
                                    First Name:*</label>
                                <asp:TextBox ID="txtFirstName" runat="server" placeholder="First name"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ReqFieldFirstName" runat="server" ErrorMessage="Please enter First Name."
                                    ValidationGroup="a" ControlToValidate="txtFirstName" placeholder="First name">*</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revFirstName" runat="server" ErrorMessage="Only characters are allowed in First Name."
                                    ToolTip="Only characters are allowed in First Name." Text="." ValidationGroup="a"
                                    ValidationExpression="^[a-zA-Z ]+$" ControlToValidate="txtFirstName"></asp:RegularExpressionValidator>
                            </p>
                            <p>
                                <label >
                                    Last Name:*</label>
                                <asp:TextBox ID="txtLastName" runat="server" placeholder="Last name"></asp:TextBox>
                                <%--<asp:RequiredFieldValidator ID="ReqFieldLastName" runat="server" ErrorMessage="Please enter Last Name."
                                    ValidationGroup="a" ControlToValidate="txtLastName">*</asp:RequiredFieldValidator>--%>
                                <asp:RegularExpressionValidator ID="revLastName" runat="server" ErrorMessage="Only characters are allowed in Last Name."
                                    ToolTip="Only characters are allowed in Last Name." Text="." ValidationGroup="a"
                                    ValidationExpression="^[a-zA-Z ]+$" ControlToValidate="txtLastName"></asp:RegularExpressionValidator>
                            </p>
                            <p>
                                <label >
                                    Contact Number:*</label>
                                <asp:TextBox ID="txtContactNo" runat="server" MaxLength="20" placeholder="Contact Number"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ReqFieldContactNo" runat="server" ErrorMessage="Please enter Contact Number."
                                    ControlToValidate="txtContactNo" ValidationGroup="a">*</asp:RequiredFieldValidator>
                                <%--<asp:RegularExpressionValidator ID="revContactNo" runat="server" ErrorMessage="Please enter valid Contact Number."
                                    ToolTip="Please enter valid Contact Number." Text="." ValidationGroup="a" ValidationExpression="^[0-9]{6,10}"
                                    ControlToValidate="txtContactNo"></asp:RegularExpressionValidator>--%>
                            </p>
                            <p>
                                <label>
                                    Email \ LoginID:*</label>
                                <asp:TextBox ID="txtEmail" runat="server" placeholder="Email ID"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ReqFieldEmailID" runat="server" ErrorMessage="Please enter EmailID."
                                    ValidationGroup="a" ControlToValidate="txtEmail">*</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revEmailID" runat="server" ErrorMessage="Please enter valid EmailID."
                                    ToolTip="Please enter valid EmailID." Text="." ValidationGroup="a" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                    ControlToValidate="txtEmail"></asp:RegularExpressionValidator>
                            </p>
                            <p>
                                <label>
                                    School Name:*</label>
                                <asp:TextBox ID="txtSchoolname" runat="server" placeholder="School Name"></asp:TextBox>
                                <%--<asp:RequiredFieldValidator ID="ReqFieldSchooname" runat="server" ErrorMessage="Please School Name."
                                    ValidationGroup="a" ControlToValidate="txtSchoolname">*</asp:RequiredFieldValidator>--%>
                            </p>
                            <div>
                                <label>
                                    Board*</label>
                                <asp:DropDownList ID="ddlBoard" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlBoard_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="ReqFieldBoard" runat="server" InitialValue="--Select Board--"
                                    ErrorMessage="Please Select Board." ValidationGroup="a" ControlToValidate="ddlBoard">*</asp:RequiredFieldValidator>
                            </div>
                            <div>
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <label >
                                            Medium:*</label>
                                        <asp:DropDownList ID="ddlMedium" runat="server" AutoPostBack="True" Enabled="False"
                                            OnSelectedIndexChanged="ddlMedium_SelectedIndexChanged">
                                            <asp:ListItem Value="0" Text="Select Medium"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="ReqFieldMedium" runat="server" InitialValue="--Select Medium--"
                                            ErrorMessage="Please Select Medium of Education." ValidationGroup="a" ControlToValidate="ddlMedium">*</asp:RequiredFieldValidator>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="ddlBoard" EventName="SelectedIndexChanged" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>
                            <div>
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <label >
                                            Standard:*</label>
                                        <asp:DropDownList ID="ddlStandard" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlStandard_SelectedIndexChanged"
                                            Enabled="False">
                                            <asp:ListItem Value="0" Text="Select Standard"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="ReqFieldStandard" runat="server" InitialValue="--Select Standard--"
                                            ErrorMessage="Please Select Standard." ValidationGroup="a" ControlToValidate="ddlStandard">*</asp:RequiredFieldValidator>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="ddlMedium" EventName="SelectedIndexChanged" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>
                            <p style="display: none;">
                                <asp:DropDownList ID="ddlBMS" runat="server">
                                    <asp:ListItem Value="0" Text="<SELECT>"></asp:ListItem>
                                </asp:DropDownList>
                                <%--<asp:RequiredFieldValidator ID="ReqFieldBMSID" runat="server" InitialValue="0" ErrorMessage="Please Select BMS."
                                    ValidationGroup="a" ControlToValidate="ddlBMS">*</asp:RequiredFieldValidator>--%>
                            </p>
                            <p>
                                <asp:Button ID="btnSubmit" runat="server" class="epath-btn epath-btn-normal epath-btn-primary"
                                    Text="Register" ValidationGroup="a" EnableTheming="false" OnClick="btnSubmit_Click" />
                                <asp:Button ID="btnBack" runat="server" Text="Back" EnableTheming="false" class="epath-btn epath-btn-normal epath-btn-primary"
                                    Visible="false" OnClick="btnBack_Click" />
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
