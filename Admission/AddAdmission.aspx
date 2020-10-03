<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Epathshala.master" AutoEventWireup="true"
    CodeFile="AddAdmission.aspx.cs" Inherits="Admission_AddAdmission" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .ddl
        {
            border: 1px solid #7d6754;
            padding: 3px;
            -webkit-appearance: none;
            text-indent: 0.01px; /*In Firefox*/
            text-overflow: ''; /*In Firefox*/
            margin: 0px !important;
        }
        .inputform
        {
            width: 100%;
        }
        .inputform tr td.labelname
        {
            width: 30%;
            text-align: right;
            height: 35px;
            padding-right: 10px;
        }
        .ValidationSummary
        {
            border-bottom: 1px solid #FF6C47;
            border-top: 1px solid #FF6C47;
            color: #FF6C47;
            background-color: #FFDAD0;
            display: block;
            font-size: 0.9em;
            font-weight: 600;
            margin-left: 0;
            margin-top: 15px;
            width: 99%;
            padding-left: 10px;
            padding-top: 2px;
            margin-bottom: 15px;
        }
        
        .ValidationSummary ul
        {
            padding-left: 30px;
            margin: 4px;
        }
        
        .ValidationSummary ul li
        {
            padding-top: 1px;
            font-size: 1em;
            font-weight: 600;
            list-style-type: unset;
        }
        .Attachmentchecks label
        {
            margin-left: 80px;
        }
        /*Tab Style Start*/
        
        .fancy-green .ajax__tab_header
        {
            background: url(../App_Themes/Responsive/web/green_bg_Tab.gif) repeat-x;
            cursor: pointer;
        }
        .fancy-green .ajax__tab_hover .ajax__tab_outer, .fancy-green .ajax__tab_active .ajax__tab_outer
        {
            background: url(../App_Themes/Responsive/web/green_left_Tab.gif) no-repeat left top;
        }
        .fancy-green .ajax__tab_hover .ajax__tab_inner, .fancy-green .ajax__tab_active .ajax__tab_inner
        {
            background: url(../App_Themes/Responsive/web/green_right_Tab.gif) no-repeat right top;
        }
        .fancy .ajax__tab_header
        {
            font-size: 13px;
            font-weight: bold;
            color: #000;
            font-family: sans-serif;
        }
        .fancy .ajax__tab_active .ajax__tab_outer, .fancy .ajax__tab_header .ajax__tab_outer, .fancy .ajax__tab_hover .ajax__tab_outer
        {
            height: 46px;
        }
        .fancy .ajax__tab_active .ajax__tab_inner, .fancy .ajax__tab_header .ajax__tab_inner, .fancy .ajax__tab_hover .ajax__tab_inner
        {
            height: 46px;
            margin-left: 16px; /* offset the width of the left image */
        }
        .fancy .ajax__tab_active .ajax__tab_tab, .fancy .ajax__tab_hover .ajax__tab_tab, .fancy .ajax__tab_header .ajax__tab_tab
        {
            margin: 16px 16px 0px 0px;
        }
        .fancy .ajax__tab_hover .ajax__tab_tab, .fancy .ajax__tab_active .ajax__tab_tab
        {
            color: #fff;
        }
        .fancy .ajax__tab_body
        {
            font-family: Arial;
            font-size: 10pt;
            border-top: 0;
            border: 1px solid #999999;
            padding: 8px;
            background-color: #ffffff;
        }
        
        /*Tab Style End*/
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../App_Themes/Responsive/Calender/CSS.css" rel="stylesheet" type="text/css" />
    <script src="../App_Themes/Responsive/Calender/Extension.min.js" type="text/javascript"></script>
    <div style="width: 80%; margin: auto;">
        <div class="activitydivside1">
            <div class="ActivityHeader">
                <asp:Label ID="lblTitle" runat="server" Text="New Admission"></asp:Label>
            </div>
            <div class="ActivityContent">
                <div style="text-align: right;">
                    <asp:Label ID="lblRequiredField" runat="server" Text="* Indicates required field."
                        ForeColor="Red" Font-Size="8pt"></asp:Label>
                </div>
                <div>
                    <asp:ValidationSummary ID="VsumAdmission" CssClass="ValidationSummary" DisplayMode="BulletList"
                        HeaderText="Please resolve following issue and try again" ValidationGroup="VgAdmission"
                        runat="server" />
                </div>
                <cc1:TabContainer ID="TabCon_Admission" runat="server" ActiveTabIndex="0" CssClass="fancy fancy-green">
                    <cc1:TabPanel ID="Tb_PersonalDetails" runat="server" HeaderText="Personal Details">
                        <ContentTemplate>
                            <table class="inputform">
                                <tr>
                                    <td class="labelname">
                                        <asp:Label ID="LblFormNo" runat="server" Text="Form No:"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TxtFormNo" runat="server" MaxLength="50" CssClass="controllabel"
                                            Width="250px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="labelname">
                                        <font color="red">*</font>
                                        <asp:Label ID="LblAdmissionGrade" runat="server" Text="Admission Grade:"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="DdlAdmissionGrade" runat="server" AppendDataBoundItems="True"
                                            Width="262px" CssClass="ddl" SkinID="none">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RqvAdmissionGrade" runat="server" ControlToValidate="DdlAdmissionGrade"
                                            ErrorMessage="Please select admission grade." InitialValue="0" ValidationGroup="VgAdmission">&nbsp;</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="labelname">
                                        <font color="red">*</font>
                                        <asp:Label ID="LblFirstName" runat="server" Text="First Name:"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TxtFirstName" runat="server" MaxLength="60" CssClass="controllabel"
                                            Width="250px"></asp:TextBox>
                                        &nbsp;<asp:RequiredFieldValidator ID="RqdFirstName" runat="server" ControlToValidate="TxtFirstName"
                                            ErrorMessage="Please enter first name." ValidationGroup="VgAdmission">&nbsp;</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="labelname">
                                        <font color="red">*</font>
                                        <asp:Label ID="LblMiddleName" runat="server" Text="Middle Name:"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TxtMiddleName" runat="server" MaxLength="60" CssClass="controllabel"
                                            Width="250px"></asp:TextBox>
                                        &nbsp;<asp:RequiredFieldValidator ID="RqdMiddleName" runat="server" ControlToValidate="TxtMiddleName"
                                            ErrorMessage="Please enter middle name." ValidationGroup="VgAdmission">&nbsp;</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="labelname">
                                        <font color="red">*</font>
                                        <asp:Label ID="LblLastName" runat="server" Text="Last Name:"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TxtLastName" runat="server" MaxLength="60" CssClass="controllabel"
                                            Width="250px"></asp:TextBox>
                                        &nbsp;<asp:RequiredFieldValidator ID="RqdLastName" runat="server" ControlToValidate="TxtLastName"
                                            ErrorMessage="Please enter last name." ValidationGroup="VgAdmission">&nbsp;</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="labelname">
                                        <asp:Label ID="LblMailingAddress" runat="server" Text="Mailing Address:"></asp:Label>
                                    </td>
                                    <td>
                                        <%--CssClass="multiline2 controllabel"--%>
                                        <asp:TextBox ID="TxtMailingAddress" runat="server" TextMode="MultiLine" MaxLength="255"
                                            Style="margin: 5px 0px 5px 0px; resize: none; width: 260px;" Rows="4"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="labelname">
                                        <asp:Label ID="LblPhoto" runat="server" Text="Photo :"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:FileUpload ID="Fu_PassportImage" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="labelname">
                                        <asp:Label ID="LblTelephoneNo" runat="server" Text="Telephone Number:"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TxtTelephoneNo" runat="server" CssClass="controllabel" MaxLength="13"
                                            Width="250px"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RevTelephoneNo" runat="server" ControlToValidate="TxtTelephoneNo"
                                            ErrorMessage="Telephone number should be between 8 to 13 digit." ValidationExpression="[\d]{8,13}"
                                            ValidationGroup="VgAdmission">&nbsp;</asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="labelname">
                                        <font color="red">*</font>
                                        <asp:Label ID="LblCommunicationMail" runat="server" Text="Communication Email:"></asp:Label>
                                    </td>
                                    <td>
                                        &nbsp;<asp:TextBox ID="TxtCommunicationMail" runat="server" CssClass="controllabel"
                                            MaxLength="255" Width="250px"></asp:TextBox>
                                        &nbsp;<asp:RequiredFieldValidator ID="RevCommunicationMail" runat="server" ControlToValidate="TxtCommunicationMail"
                                            ErrorMessage="Please enter Communication Email Address." ValidationGroup="VgAdmission">&nbsp;</asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegExpCommunicatoinEmail" runat="server" ControlToValidate="TxtCommunicationMail"
                                            ErrorMessage="Please enter valid Communication Email." ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                            ValidationGroup="VgAdmission">&nbsp;</asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="labelname">
                                        <font color="red">*</font>
                                        <asp:Label ID="LblMobileNo" runat="server" Text="Emergency Mobile Number:"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TxtMobileNo" runat="server" CssClass="controllabel" MaxLength="11"
                                            Width="250px"></asp:TextBox>
                                        &nbsp;<asp:RequiredFieldValidator ID="RqvMobileNo" runat="server" ControlToValidate="TxtMobileNo"
                                            ErrorMessage="Please enter emergency mobile number." ValidationGroup="VgAdmission">&nbsp;</asp:RequiredFieldValidator>
                                        &nbsp;<asp:RegularExpressionValidator ID="RevMobileNo" runat="server" ControlToValidate="TxtMobileNo"
                                            ErrorMessage="Emergency mobile number should be between 8 to 11 digit." ValidationExpression="[\d]{8,11}"
                                            ValidationGroup="VgAdmission">&nbsp;</asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="labelname">
                                        <font color="red">*</font>
                                        <asp:Label ID="LblGender" runat="server" Text="Gender:"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:RadioButtonList ID="RlstGender" runat="server" RepeatDirection="Horizontal">
                                            <asp:ListItem Value="M" Text="Male" Selected="True"></asp:ListItem>
                                            <asp:ListItem Value="F" Text="Female"></asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="labelname">
                                        <asp:Label ID="LblDateOfBirth" runat="server" Text="Date Of Birth:" Enabled="False"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TxtDateOfBirth" runat="server" CssClass="disable_future_dates controllabel"></asp:TextBox>
                                        <div style="padding: 2px; background-color: #444; width: 20px; height: 20px; display: inline-block;
                                            margin-left: 4px; border-radius: 4px;">
                                            <asp:ImageButton ID="ibtnCalender" runat="server" ImageUrl="~/App_Themes/Responsive/web/Calender.png"
                                                Width="20px" />
                                        </div>
                                        <cc1:CalendarExtender ID="CalExtDateOfBirth" runat="server" TargetControlID="TxtDateOfBirth"
                                            PopupButtonID="ibtnCalender" Enabled="True" Format="dd-MMM-yyyy">
                                        </cc1:CalendarExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="labelname">
                                        <asp:Label ID="LblPlaceOfBirth" runat="server" Text="Place Of Birth:"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TxtPlaceOfBirth" runat="server" MaxLength="60" CssClass="controllabel"
                                            Width="250px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="labelname">
                                        <asp:Label ID="LblNationality" runat="server" Text="Nationality:"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TxtNationality" runat="server" MaxLength="50" CssClass="controllabel"
                                            Width="250px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="labelname">
                                        <asp:Label ID="LblReligion" runat="server" Text="Religion:"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TxtReligion" runat="server" MaxLength="25" CssClass="controllabel"
                                            Width="250px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="labelname">
                                        <asp:Label ID="LblCaste" runat="server" Text="Caste:"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TxtCaste" runat="server" MaxLength="30" CssClass="controllabel"
                                            Width="250px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="labelname">
                                        <asp:Label ID="LblSubCaste" runat="server" Text="SubCaste:"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TxtSubCaste" runat="server" MaxLength="50" CssClass="controllabel"
                                            Width="250px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="labelname">
                                        <asp:Label ID="LblLastSchoolAttended" runat="server" Text="Last School Attended:"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TxtLastSchoolAttended" runat="server" MaxLength="255" CssClass="controllabel"
                                            Width="250px"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </cc1:TabPanel>
                    <cc1:TabPanel runat="server" ID="Tb_Familydetail" HeaderText="Family Details" TabIndex="1">
                        <ContentTemplate>
                            <table class="inputform">
                                <tr>
                                    <td class="labelname">
                                        <asp:Label ID="LblFatherName" runat="server" Text="Father Name:"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TxtFatherName" runat="server" MaxLength="60" CssClass="controllabel"
                                            Width="250px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="labelname">
                                        <asp:Label ID="LblFatherEducation" runat="server" Text="Father Education:"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TxtFatherEducation" runat="server" MaxLength="150" CssClass="controllabel"
                                            Width="250px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="labelname">
                                        <asp:Label ID="LblFatherOccupation" runat="server" Text="Father Occupation:"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TxtFatherOccupation" runat="server" MaxLength="150" CssClass="controllabel"
                                            Width="250px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="labelname">
                                        <asp:Label ID="LblFatherOfficeAddress" runat="server" Text="Father Office Address:"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TxtFatherOfficeAddress" runat="server" TextMode="MultiLine" MaxLength="255"
                                            Style="margin: 5px 0px 5px 0px; resize: none; width: 260px;" Rows="4"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="labelname">
                                        <asp:Label ID="LblFatherTelephoneNo" runat="server" Text="Father Telephone No:"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TxtFatherTelephoneNo" runat="server" CssClass="controllabel" MaxLength="13"
                                            Width="250px"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RevFatherTelephoneNo" runat="server" ControlToValidate="TxtFatherTelephoneNo"
                                            ErrorMessage="Father telephone number should be between 8 to 13 digit." ValidationExpression="[\d]{8,13}"
                                            ValidationGroup="VgAdmission">&nbsp;</asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="labelname">
                                        <asp:Label ID="LblFatherMobileNo" runat="server" Text="Father Mobile No:"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TxtFatherMobileNo" runat="server" CssClass="controllabel" MaxLength="11"
                                            Width="250px"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RevFatherMobileNo" runat="server" ControlToValidate="TxtFatherMobileNo"
                                            ErrorMessage="Father mobile number should be between 8 to 11 digit." ValidationExpression="[\d]{8,11}"
                                            ValidationGroup="VgAdmission">&nbsp;</asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="labelname">
                                        <asp:Label ID="LblFatherEmailId" runat="server" Text="Father Email Id:"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TxtFatherEmailId" runat="server" MaxLength="255" CssClass="controllabel"
                                            Width="250px"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RevFatherEmailId" runat="server" ControlToValidate="TxtFatherEmailId"
                                            ErrorMessage="Please enter valid father email id." ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                            ValidationGroup="VgAdmission">&nbsp;</asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="labelname">
                                        <asp:Label ID="LblMotherName" runat="server" Text="Mother Name:"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TxtMotherName" runat="server" MaxLength="60" CssClass="controllabel"
                                            Width="250px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="labelname">
                                        <asp:Label ID="LblMotherEducation" runat="server" Text="Mother Education:"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TxtMotherEducation" runat="server" MaxLength="150" CssClass="controllabel"
                                            Width="250px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="labelname">
                                        <asp:Label ID="LblMotherOccupation" runat="server" Text="Mother Occupation:"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TxtMotherOccupation" runat="server" MaxLength="150" CssClass="controllabel"
                                            Width="250px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="labelname">
                                        <asp:Label ID="LblMotherOfficeAddress" runat="server" Text="Mother Office Address:"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TxtMotherOfficeAddress" runat="server" TextMode="MultiLine" MaxLength="255"
                                            Style="margin: 5px 0px 5px 0px; resize: none; width: 260px;" Rows="4"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="labelname">
                                        <asp:Label ID="LblMotherTelephoneNo" runat="server" Text="Mother Telephone No:"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TxtMotherTelephoneNo" runat="server" CssClass="controllabel" MaxLength="13"
                                            Width="250px"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RevMotherTelephoneNo" runat="server" ControlToValidate="TxtMotherTelephoneNo"
                                            ErrorMessage="Mother telephone number should be between 8 to 13 digit." ValidationExpression="[\d]{8,13}"
                                            ValidationGroup="VgAdmission">&nbsp;</asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="labelname">
                                        <asp:Label ID="LblMotherMobileNo" runat="server" Text="Mother Mobile No:"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TxtMotherMobileNo" runat="server" CssClass="controllabel" MaxLength="11"
                                            Width="250px"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RevMotherMobileNo" runat="server" ControlToValidate="TxtMotherMobileNo"
                                            ErrorMessage="Mother mobile number should be between 8 to 11 digit." ValidationExpression="[\d]{8,11}"
                                            ValidationGroup="VgAdmission">&nbsp;</asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="labelname">
                                        <asp:Label ID="LblMotherEmailId" runat="server" Text="Mother Email Id:"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TxtMotherEmailId" runat="server" MaxLength="255" CssClass="controllabel"
                                            Width="250px"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RevMotherEmailId" runat="server" ControlToValidate="TxtMotherEmailId"
                                            ErrorMessage="Please enter valid mother email id." ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                            ValidationGroup="VgAdmission">&nbsp;</asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="labelname">
                                        <asp:Label ID="LblMotherTongue" runat="server" Text="Mother Tongue:"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TxtMotherTongue" runat="server" MaxLength="255" CssClass="controllabel"
                                            Width="250px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="labelname">
                                        <asp:Label ID="LblOtherLanguages" runat="server" Text="Other languages spoken at home:"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TxtOtherLanguages" runat="server" MaxLength="255" CssClass="controllabel"
                                            Width="250px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="labelname">
                                        <asp:Label ID="LblIsNuclearorJointFamily" runat="server" Text="Are you a nuclear family or a joint family:"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TxtIsNuclearorJointFamily" runat="server" MaxLength="50" CssClass="controllabel"
                                            Width="250px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="labelname">
                                        <asp:Label ID="LblHowdoyouhearAboutAIS" runat="server" Text="How did you hear about AIS:"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TxtHowdoyouhearAboutAIS" runat="server" MaxLength="255" CssClass="controllabel"
                                            Width="250px"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </cc1:TabPanel>
                    <cc1:TabPanel ID="Tb_Siblings" runat="server" HeaderText="Siblings" TabIndex="2">
                        <ContentTemplate>
                            <asp:UpdatePanel runat="server" ID="UpPnlSibling">
                                <ContentTemplate>
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                        <tbody>
                                            <tr>
                                                <td>
                                                    <asp:TextBox ID="TxtAddSiblingName" runat="server" CssClass="controllabel" placeholder="Name"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="ReqAddSiblingName" runat="server" ControlToValidate="TxtAddSiblingName"
                                                        ErrorMessage="*" ValidationGroup="SiblingMandetory"></asp:RequiredFieldValidator>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtAddSiblingAge" runat="server" CssClass="controllabel" MaxLength="3"
                                                        placeholder="Age" ValidationGroup="SiblingMandetory" Width="50px" onkeypress="javascript:return isNumber (event)"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:RadioButtonList ID="RblstAddSiblingGender" runat="server" CssClass="controllabel"
                                                        RepeatDirection="Horizontal">
                                                        <asp:ListItem Text="Male" Value="M"></asp:ListItem>
                                                        <asp:ListItem Text="Female" Value="F"></asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="TxtAddSiblingSchool" runat="server" CssClass="controllabel" placeholder="School"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="TxtAddSiblingClass" runat="server" CssClass="controllabel" placeholder="Class"
                                                        Width="70px"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:Button ID="BtnAddNewSibling" runat="server" OnClick="BtnAddNewSibling_Click"
                                                        Text="Add New Sibling" ValidationGroup="SiblingMandetory" />
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                    <asp:GridView ID="GvSibling" runat="server" BackColor="White" BorderColor="#336666"
                                        BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal"
                                        Caption="Sibling Details" AutoGenerateColumns="False" Width="100%" OnRowDeleting="GvSibling_RowDeleting">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Sr.No">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblSrno" Text='<%#Container.DataItemIndex + 1%>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblSiblingid" Text='<% #Bind("SiblingId") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Name of Sibling">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblSiblingName" Text='<% #Bind("SiblingName") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Age">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblSiblingAge" Text='<% #Bind("SiblingAge") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Gender">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblSiblingGender" Text='<% #Bind("SiblingGender") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="School">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblSiblingLastSchool" Text='<% #Bind("SiblingSchool") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Class">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblSiblingClass" Text='<% #Bind("SiblingClass") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Delete">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="ImageButton1" ImageUrl="~/App_Themes/Images/ButtonBarDelete.png"
                                                        runat="server" CommandName="Delete" ValidationGroup="other" />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <EmptyDataTemplate>
                                            <div style="text-align: center; color: black">
                                                Sibling Details are not added yet.</div>
                                        </EmptyDataTemplate>
                                        <FooterStyle BackColor="White" ForeColor="#333333" />
                                        <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                                        <RowStyle BackColor="White" ForeColor="#333333" />
                                        <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                                        <SortedAscendingCellStyle BackColor="#F7F7F7" />
                                        <SortedAscendingHeaderStyle BackColor="#487575" />
                                        <SortedDescendingCellStyle BackColor="#E5E5E5" />
                                        <SortedDescendingHeaderStyle BackColor="#275353" />
                                    </asp:GridView>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </ContentTemplate>
                    </cc1:TabPanel>
                    <cc1:TabPanel ID="Tb_Attachments" runat="server" HeaderText="Attachments" TabIndex="3">
                        <ContentTemplate>
                            <asp:Label Text="Please Select attachment(s) from given list" runat="server" />
                            <asp:CheckBoxList runat="server" ID="ChklstAttachmentList" CssClass="Attachmentchecks">
                            </asp:CheckBoxList>
                        </ContentTemplate>
                    </cc1:TabPanel>
                </cc1:TabContainer>
                <table class="inputform">
                    <tr>
                        <td align="left" style="padding-left: 30%; padding-top: 15px;">
                            <%--<br />
                            <button onclick="PrevTab();">
                                < Back
                            </button>
                            <button onclick="NextTab();">
                                Next >
                            </button>--%>
                            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click"
                                ValidationGroup="VgAdmission" />
                            <asp:Button ID="btnReset" runat="server" Text="Reset" OnClick="btnReset_Click" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        // WRITE THE VALIDATION SCRIPT IN THE HEAD TAG.
        function isNumber(evt) {
            var iKeyCode = (evt.which) ? evt.which : evt.keyCode
            if (iKeyCode != 46 && iKeyCode > 31 && (iKeyCode < 48 || iKeyCode > 57))
                return false;

            return true;
        }

        //        function NextTab() {
        //            var active = $find('<%=TabCon_Admission.ClientID%>').get_activeTabIndex();

        //            active = active + 1;
        //            $find('<%=TabCon_Admission.ClientID%>').set_activeTabIndex(active);

        //        }
        //        function PrevTab() {
        //            var active = $find('<%=TabCon_Admission.ClientID%>').get_activeTabIndex();
        //            if (active == 0) {
        //                $find('<%=TabCon_Admission.ClientID%>').set_activeTabIndex(0);
        //            }
        //            else {
        //                active = active - 1;
        //                $find('<%=TabCon_Admission.ClientID%>').set_activeTabIndex(active);
        //            }
        //        }
    </script>
</asp:Content>
