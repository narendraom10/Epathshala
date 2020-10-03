<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Epathshala.master" AutoEventWireup="true"
    CodeFile="UpdateUser.aspx.cs" Inherits="Admin_UpdateUser" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="width: 80%; margin: auto;">
        <div class="activitydivside1" id="Div1" runat="server" visible="true">
            <div class="ActivityHeader">
                <asp:Label ID="lblAddTitle" runat="server" Text="Update User"></asp:Label>
            </div>
            <div class="ActivityContent">
                <div class="subheaduserdetail" id="fsEmployeeAdd" runat="server" style="font-size: 1.2em;">
                </div>
                <div class="ActivityContent">
                    <div style="text-align: right;">
                        <asp:Label ID="Label1" runat="server" Text="* Indicates required field." ForeColor="Red"
                            Font-Size="8pt" meta:resourceKey="Label1Resource1"></asp:Label>
                    </div>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 25%; text-align: right; height: 30px; padding-right: 10px;">
                                <asp:Label ID="lblRole" runat="server" Text="Select Role:" Style="margin-bottom: 20px;"></asp:Label>
                            </td>
                            <td class="dropdownwidth">
                                <asp:DropDownList ID="ddlRole" runat="server">
                                </asp:DropDownList>
                                &nbsp;<asp:RequiredFieldValidator ID="rfvRole" runat="server" ControlToValidate="ddlRole"
                                    ErrorMessage="Select Role For User." ValidationGroup="PD" InitialValue="0">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 20%; text-align: right; height: 30px; padding-right: 10px;">
                                <asp:Label ID="lblAddFirstName" runat="server" Text="First Name:" meta:resourceKey="lblAddFirstNameResource1"
                                    Style="margin-bottom: 20px;"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtAddFirstName" runat="server" MaxLength="30" CssClass="controllabel"
                                    onkeypress="return charecteronly(event);" meta:resourceKey="txtAddFirstNameResource1"></asp:TextBox>
                                &nbsp;<asp:RequiredFieldValidator ID="rqdAddFN" runat="server" ControlToValidate="txtAddFirstName"
                                    ErrorMessage="First Name Must Be Required" ValidationGroup="PD" meta:resourceKey="rqdAddFNResource1">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; height: 30px; padding-right: 10px;">
                                <asp:Label ID="lblAddMiddleName" runat="server" Text="Middle Name:" meta:resourceKey="lblAddMiddleNameResource1"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtAddMiddleName" runat="server" MaxLength="30" onkeypress="return charecteronly(event);"
                                    CssClass="controllabel" meta:resourceKey="txtAddMiddleNameResource1"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rqdAddMiddleName" runat="server" ControlToValidate="txtAddMiddleName"
                                    ErrorMessage="Middle Name Must Be Required " ValidationGroup="PD" meta:resourceKey="rqdAddMiddleNameResource1">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; height: 30px; padding-right: 10px;">
                                <asp:Label ID="lblAddLastName" runat="server" Text="Last Name:" meta:resourceKey="lblAddLastNameResource1"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtAddLastName" runat="server" MaxLength="30" onkeypress="return charecteronly(event);"
                                    CssClass="controllabel" meta:resourceKey="txtAddLastNameResource1"></asp:TextBox>
                                &nbsp;<asp:RequiredFieldValidator ID="rqdAddLastName" runat="server" ControlToValidate="txtAddLastName"
                                    ErrorMessage="Last Name Must Be Required " ValidationGroup="PD" meta:resourceKey="rqdAddLastNameResource1">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; height: 30px; padding-right: 10px;">
                                <asp:Label ID="lblLoginId" runat="server" Text="Login ID:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="tLoginId" runat="server" MaxLength="30" CssClass="controllabel"
                                    AutoCompleteType="None"></asp:TextBox>
                                &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tLoginId"
                                    ErrorMessage="Login ID Must Be Required " ValidationGroup="PD">*</asp:RequiredFieldValidator>
                                <asp:Label ID="lblAvailibility" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <%--<tr>
                <td style="text-align: right; height: 30px; padding-right: 10px;">
                    <asp:Label ID="lblpass" runat="server" Text="Password:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="tpassword" runat="server" MaxLength="30" CssClass="controllabel"
                        TextMode="Password"></asp:TextBox>
                    &nbsp;<asp:RequiredFieldValidator ID="rfvpassword" runat="server" ControlToValidate="tpassword"
                        ErrorMessage="Password Must Be Required " ValidationGroup="PD" Display="None"></asp:RequiredFieldValidator>
                </td>
            </tr>--%>
                        <tr>
                            <td style="text-align: right; height: 30px; padding-right: 10px;">
                                <asp:Label ID="lblAddGender" runat="server" Text="Gender:" meta:resourceKey="lblAddGenderResource1"></asp:Label>
                            </td>
                            <td>
                                <div class="controllabel">
                                    <asp:RadioButtonList ID="rlstAddGender" runat="server" RepeatDirection="Horizontal"
                                        meta:resourceKey="rlstAddGenderResource1">
                                        <asp:ListItem Value="M" Text="Male" meta:resourceKey="ListItemResource3"></asp:ListItem>
                                        <asp:ListItem Value="F" Text="Female" meta:resourceKey="ListItemResource4"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; height: 30px; padding-right: 10px;">
                                <asp:Label ID="lblAddDob" runat="server" Text="Date Of Birth:" meta:resourceKey="lblAddDobResource1"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtAddDOB" runat="server" MaxLength="30" CssClass="controllabel"
                                    meta:resourceKey="txtAddDOBResource1"></asp:TextBox>
                                <div style="padding: 2px; background-color: #444; width: 20px; height: 20px; display: inline-block;
                                    margin-left: 4px; border-radius: 4px;">
                                    <asp:ImageButton ID="ibtnAddCalender" runat="server" ImageUrl="~/App_Themes/Responsive/web/Calender.png"
                                        Width="20px" meta:resourceKey="ibtnAddCalenderResource1" />
                                </div>
                                &nbsp;<asp:RequiredFieldValidator ID="rqdAddDOB" runat="server" ControlToValidate="txtAddDOB"
                                    ErrorMessage="Date of birth Must Be Required " ValidationGroup="PD" meta:resourceKey="rqdAddDOBResource1">*</asp:RequiredFieldValidator>
                                &nbsp;<asp:RegularExpressionValidator ID="revDOB" runat="server" ControlToValidate="txtAddDOB"
                                    ErrorMessage="Enter Date in dd-MMM-yyyy Format." ValidationGroup="PD" ValidationExpression="^(([0-9])|([0-2][0-9])|([3][0-1]))\-(Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec)\-\d{4}$">*</asp:RegularExpressionValidator>
                                <asp:CustomValidator ID="cusdatevalidator" runat="server" ControlToValidate="txtAddDOB"
                                    ErrorMessage="Minimum age should be 18 year." ValidationGroup="PD" ClientValidationFunction="CalculateAge">*</asp:CustomValidator>
                                <cc1:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtAddDOB"
                                    PopupButtonID="ibtnAddCalender" Enabled="True" Format="dd-MMM-yyyy">
                                </cc1:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; height: 30px; padding-right: 10px;">
                                <asp:Label ID="lblAddBloodGroup" runat="server" Text="Blood Group:" meta:resourceKey="lblAddBloodGroupResource1"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtAddBloodGroup" runat="server" CssClass="controllabel" MaxLength="20"
                                    meta:resourceKey="txtAddBloodGroupResource1"></asp:TextBox>
                                &nbsp;<asp:RequiredFieldValidator ID="rqdAddBloodGroup" runat="server" ControlToValidate="txtAddBloodGroup"
                                    ErrorMessage="Blood Group Must Be Required" ValidationGroup="PD" meta:resourceKey="rqdAddBloodGroupResource1">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; height: 30px; padding-right: 10px;">
                                <asp:Label ID="lblAddPermanentAddress" runat="server" Text="Permanent Address:" meta:resourceKey="lblAddPermanentAddressResource1"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtAddPermanentAddress" runat="server" CssClass="multiline2 controllabel"
                                    TextMode="MultiLine" meta:resourceKey="txtAddPermanentAddressResource1" Style="width: 325px;"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rqdAddPermanentAddress" runat="server" ControlToValidate="txtAddPermanentAddress"
                                    ErrorMessage="Permanent Address Must be Required" ValidationGroup="PD" meta:resourceKey="rqdAddPermanentAddressResource1">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; height: 30px; padding-right: 10px;">
                                <asp:Label ID="lblAddContactNumber" runat="server" Text="Contact Number:" meta:resourceKey="lblAddContactNumberResource1"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtAddContactNumber" runat="server" CssClass="controllabel" MaxLength="13"
                                    onkeypress="return phonenumber(event);" meta:resourceKey="txtAddContactNumberResource1"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rqdAddMobileNo" runat="server" ControlToValidate="txtAddContactNumber"
                                    ErrorMessage="Contact Number Must be Required" ValidationGroup="PD" meta:resourceKey="rqdAddMobileNoResource1">*</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revcontactnumber" runat="server" ControlToValidate="txtAddContactNumber"
                                    ErrorMessage="Please Enter Number between 8 to 11 digit." ValidationGroup="PD"
                                    ValidationExpression="[\d]{8,11}">*</asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; height: 30px; padding-right: 10px;">
                                <asp:Label ID="lblAddEmail" runat="server" Text="Email:" meta:resourceKey="lblAddEmailResource1"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtAddEmail" runat="server" MaxLength="30" CssClass="controllabel"
                                    meta:resourceKey="txtAddEmailResource1"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rqdAddEmail" runat="server" ControlToValidate="txtAddEmail"
                                    ErrorMessage="Email id Must be Required" ValidationGroup="PD" meta:resourceKey="rqdAddEmailResource1">*</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revAddEMAIL" runat="server" ControlToValidate="txtAddEmail"
                                    ErrorMessage="Enter Valid Email Address" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                    ValidationGroup="PD" meta:resourceKey="revAddEMAILResource1">*</asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; height: 30px; padding-right: 10px;">
                                <asp:Label ID="lblAddQualification" runat="server" Text="Qualification:" meta:resourceKey="lblAddQualificationResource1"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtAddQualification" runat="server" CssClass="controllabel" MaxLength="30"
                                    meta:resourceKey="txtAddQualificationResource1"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rqdAddQualification" runat="server" ControlToValidate="txtAddQualification"
                                    ErrorMessage="Qualification Must be Required" ValidationGroup="PD" meta:resourceKey="rqdAddQualificationResource1">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; height: 30px; padding-right: 10px;">
                                <asp:Label ID="lblAddDesignation" runat="server" Text="Designation:" meta:resourceKey="lblAddDesignationResource1"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtAddDesignation" runat="server" CssClass="controllabel" MaxLength="30"
                                    meta:resourceKey="txtAddDesignationResource1"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rqdAddDesignation" runat="server" ControlToValidate="txtAddDesignation"
                                    ErrorMessage="Designation Must be Required" ValidationGroup="PD" meta:resourceKey="rqdAddDesignationResource1">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <%--<tr>
                <td style="text-align: right; height: 30px; padding-right: 10px;">
                    <asp:Label ID="lblAddSecurityQuestion" runat="server" Text="Security Question:" meta:resourceKey="lblAddSecurityQuestionResource1"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlAddSecurityQues" runat="server" meta:resourceKey="ddlAddSecurityQuesResource1"
                        Style="padding-left: 0px;">
                        <asp:ListItem Selected="True" Value="0" Text="Select Security Question" meta:resourceKey="ListItemResource5"></asp:ListItem>
                        <asp:ListItem Value="1" Text="What is your mother's maiden name?" meta:resourceKey="ListItemResource6"></asp:ListItem>
                        <asp:ListItem Value="2" Text="Where did you vacation last year?" meta:resourceKey="ListItemResource7"></asp:ListItem>
                        <asp:ListItem Value="3" Text="What is your license number?" meta:resourceKey="ListItemResource8"></asp:ListItem>
                        <asp:ListItem Value="4" Text="What is your brother’s birthday?" meta:resourceKey="ListItemResource9"></asp:ListItem>
                        <asp:ListItem Value="5" Text="What school did you attend for sixth grade?" meta:resourceKey="ListItemResource10"></asp:ListItem>
                        <asp:ListItem Value="6" Text="What was your  favourite elementary school teacher?"
                            meta:resourceKey="ListItemResource11"></asp:ListItem>
                        <asp:ListItem Value="7" Text="What is your pet name?" meta:resourceKey="ListItemResource12"></asp:ListItem>
                    </asp:DropDownList>
                    &nbsp;<asp:RequiredFieldValidator ID="rqdddlAddSecurityQues" runat="server" ControlToValidate="ddlAddSecurityQues"
                        ErrorMessage="Security Question Must Be Select." ValidationGroup="PD" Display="None"
                        meta:resourceKey="rqdddlAddSecurityQuesResource1"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="text-align: right; height: 30px; padding-right: 10px;">
                    <asp:Label ID="lblAddSecurityAnswer" runat="server" Text="Security Answer:" meta:resourceKey="lblAddSecurityAnswerResource1"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtAddSecAns" runat="server" MaxLength="30" CssClass="controllabel"
                        meta:resourceKey="txtAddSecAnsResource1"></asp:TextBox>
                    &nbsp;<asp:RequiredFieldValidator ID="rqdtxtAddSecAns" runat="server" ControlToValidate="txtAddSecAns"
                        ErrorMessage="Security Answer Must Be Required" ValidationGroup="PD" Display="None"
                        meta:resourceKey="rqdtxtAddSecAnsResource1"></asp:RequiredFieldValidator>
                </td>
            </tr>--%>
                        <tr>
                            <td colspan="2" style="padding-left: 24.8%; padding-top: 15px;">
                                <asp:Button ID="btnUpdate" runat="server" Text="Update" ValidationGroup="PD" OnClick="btnUpdate_Click"
                                    meta:resourceKey="btnAddSaveResource1" />
                                <asp:Button ID="btnAddReset" runat="server" Text="Reset" OnClientClick="javascript:return ResetAll();"
                                    meta:resourceKey="btnAddResetResource1" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                    </table>
                    <%-- <div>
            <asp:Label ID="lblAddPhoto" runat="server" Text="Photo:" CssClass="textlabel1" meta:resourceKey="lblAddPhotoResource1"></asp:Label>
            <asp:Button ID="btn_upload_FILE" runat="server" class="c_button" Text="Import an EDD"
                OnClick="btn_upload_FILE_Click1" Style="display: none" />
            <div style="width: 200px;" class="controllabel">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:Image ID="imgPhoto" runat="server" AlternateText="Photo" Height="150px" BackColor="Silver"
                            BorderColor="Black" BorderStyle="Solid" ImageAlign="Middle" ImageUrl="~/SchoolAdmin/EmployeePhoto/NoPhoto.jpg" />
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:FileUpload ID="FilePhoto" runat="server" CssClass="dropdownlist controllabel" />
                <div style="color: Blue; font-size: small; float: left;">
                    <asp:Label ID="lblFileFormat" runat="server" Text="(Supported Files:<br /> bmp,jpeg,jpg,gif,png)"
                        meta:resourceKey="lblFileFormatResource1"></asp:Label>
                </div>
            </div>
        </div>--%>
                    <%-- <div>
            <asp:TextBox ID="txtAddFilePath" runat="server" Width="200px" Visible="false" ReadOnly="True"
                meta:resourceKey="txtAddFilePathResource1"></asp:TextBox>
            <asp:HiddenField ID="hfPhoto" runat="server" />
            <asp:RegularExpressionValidator ID="rqdAddUPhoto" runat="server" ErrorMessage="Select Only Image Format Files"
                ValidationExpression="([0-9a-zA-Z :\\-_-!@$%^&amp;*()])+(.jpg|.JPG)$" ControlToValidate="FilePhoto"
                ValidationGroup="PD" meta:resourceKey="rqdAddUPhotoResource1"></asp:RegularExpressionValidator>
            &nbsp;<span style="color: Blue; font-size: small"></span>
        </div>--%>
                    <div>
                        <asp:ValidationSummary ID="vsumRegistration" runat="server" ValidationGroup="PD"
                            Font-Bold="False" ShowMessageBox="True" ShowSummary="False" meta:resourceKey="ValidationSummary1Resource1" />
                    </div>
                    <input type="hidden" id="hdnLoginid" runat="server" />
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#<%= ddlRole.ClientID%>").removeClass("text");
        });
        function ResetAll() {
            $("#<%= txtAddFirstName.ClientID%>").val('');
            $("#<%= txtAddMiddleName.ClientID%>").val('');
            $("#<%= txtAddLastName.ClientID%>").val('');
            $("#<%= txtAddDOB.ClientID%>").val('');
            $("#<%= txtAddBloodGroup.ClientID%>").val('');
            $("#<%= txtAddPermanentAddress.ClientID%>").val('');
            $("#<%= txtAddContactNumber.ClientID%>").val('');
            $("#<%= txtAddEmail.ClientID%>").val('');
            $("#<%= txtAddQualification.ClientID%>").val('');
            $("#<%= txtAddDesignation.ClientID%>").val('');
            $("#<%= ddlRole.ClientID%>").val('0');
            $("#<%= tLoginId.ClientID%>").val('');
            return false;
        }
        //        function cancel(obj) {
        //            document.getElementById(obj.id).value = "";
        //            //alert("Click on Image to write Date");
        //        }
        $("#<%= tLoginId.ClientID%>").blur(function () {
            var OldUsername = $("#<%= hdnLoginid.ClientID%>").val();
            var Username = $("#<%= tLoginId.ClientID%>").val();
            if (OldUsername != Username) {
                if (Username.length > 0) {
                    $("#<%= lblAvailibility.ClientID%>").text("Check Availibility...");
                    $.ajax({
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        url: "../Admin/AddUser.aspx/CheckUserID",
                        data: "{'UserID':'" + Username + "'}",
                        success: function (data) {
                            try {
                                if (data.d.toString() == 'True') {
                                    $("#<%= lblAvailibility.ClientID%>").text('Already Exists');
                                    $("#<%= tLoginId.ClientID%>").val('');
                                }
                                else if (data.d.toString() == 'False') {
                                    $("#<%= lblAvailibility.ClientID%>").text('Login Id Available');
                                }
                                else {
                                    $("#<%= lblAvailibility.ClientID%>").text('Error.');
                                }

                            } catch (e) {
                                return;
                            }
                        },
                        error: function (result) {
                            alert("Error");
                        }
                    });
                }
            }
            else {
                $("#<%= lblAvailibility.ClientID%>").text('');
            }
        });
        // Custom Validator
        function CalculateAge(sender, args) {
            var BirthDate = $("#<%= txtAddDOB.ClientID%>").val();
            if (BirthDate != null) {
                var dob = BirthDate.split('-');
                if (dob.length === 3) {
                    var born = new Date(dob[2], GetMonth(dob[1]) * 1 - 1, dob[0]);
                    var now = new Date();
                    if (now.getMonth() == born.getMonth() && now.getDate() == born.getDate()) {
                        age = now.getFullYear() - born.getFullYear();
                    }
                    else {
                        age = Math.floor((now.getTime() - born.getTime()) / (365.25 * 24 * 60 * 60 * 1000));
                    }
                    if (isNaN(age) || age < 0) {
                        args.IsValid = false;
                        return;
                    }
                    else {
                        if (age < 18) {
                            args.IsValid = false;
                            return;
                        }
                    }
                }
            }
            else {
                args.IsValid = false;
                return;
            }
            args.IsValid = true;
            return;
        }
        function GetMonth(Name) {
            var Month;
            switch (Name) {
                case "Jan":
                    Month = 1;
                    break;
                case "Feb":
                    Month = 2;
                    break;
                case "Mar":
                    Month = 3;
                    break;
                case "Apr":
                    Month = 4;
                    break;
                case "May":
                    Month = 5;
                    break;
                case "Jun":
                    Month = 6;
                    break;
                case "Jul":
                    Month = 7;
                    break;
                case "Aug":
                    Month = 8;
                    break;
                case "Sep":
                    Month = 9;
                    break;
                case "Oct":
                    Month = 10;
                    break;
                case "Nov":
                    Month = 11;
                    break;
                case "Dec":
                    Month = 12;
                    break;
                default:
                    break;
            }
            return Month;
        }
    </script>
</asp:Content>
