<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Epathshala.master" AutoEventWireup="true"
    CodeFile="EmployeeRegistration.aspx.cs" Inherits="SchoolAdmin_EmployeeRegistration"
    Culture="auto" meta:resourcekey="PageResource2" UICulture="auto" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        $(document).ready(function () {
            $(document).on('change', '#<%= FilePhoto.ClientID %>', function () {
                if (document.getElementById('<%= FilePhoto.ClientID %>').files.length === 0) {
                    return;
                }
                $("#<%= pnlAdd.ClientID%>").removeClass("InVisible").addClass("Visible");
                $("#<%= pnlSearch.ClientID%>").removeClass("Visible").addClass("InVisible");
                $("#<%= pnlEdit.ClientID%>").removeClass("Visible").addClass("InVisible");
                $('#<%= btn_upload_FILE.ClientID %>').trigger('click');
                return false;
            });
        });
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $(document).on('change', '#<%= fupUpdateFileUploadPhoto.ClientID %>', function () {
                if (document.getElementById('<%= fupUpdateFileUploadPhoto.ClientID %>').files.length === 0) {
                    return;
                }
                $("#<%= pnlAdd.ClientID%>").removeClass("Visible").addClass("InVisible");
                $("#<%= pnlSearch.ClientID%>").removeClass("Visible").addClass("InVisible");
                $("#<%= pnlEdit.ClientID%>").removeClass("InVisible").addClass("Visible");
                $('#<%= btnUpdatePhoto.ClientID %>').trigger('click');
                return false;
            });
        });
    </script>
    <script type="text/javascript">        $(document).ready(function () {
            $("#<%= ibtnSearch.ClientID%>").click(function () {
                if ($("#<%= pnlSearch.ClientID%>").is(':visible')) {
                    $("#<%= pnlSearch.ClientID%>").removeClass("Visible").addClass("InVisible");
                    $("#<%= pnlAdd.ClientID%>").removeClass("Visible").addClass("InVisible");
                    $("#<%= pnlEdit.ClientID%>").removeClass("Visible").addClass("Visible");

                }
                else {
                    $("#<%= pnlSearch.ClientID%>").removeClass("InVisible").addClass("Visible");
                    $("#<%= pnlAdd.ClientID%>").removeClass("Visible").addClass("InVisible");
                    $("#<%= pnlEdit.ClientID%>").removeClass("Visible").addClass("InVisible");

                }
                return false;
            });

            $("#<%= ibtnAdd.ClientID%>").click(function () {
                if ($("#<%= pnlAdd.ClientID%>").is(':visible')) {
                    $("#<%= pnlAdd.ClientID%>").removeClass("Visible").addClass("InVisible");
                    $("#<%= pnlSearch.ClientID%>").removeClass("InVisible").addClass("Visible");
                    $("#<%= pnlEdit.ClientID%>").removeClass("Visible").addClass("InVisible");

                }
                else {
                    $("#<%= pnlAdd.ClientID%>").removeClass("InVisible").addClass("Visible");
                    $("#<%= pnlSearch.ClientID%>").removeClass("Visible").addClass("InVisible");
                    $("#<%= pnlEdit.ClientID%>").removeClass("Visible").addClass("InVisible");

                }
                return false;
            });

        });   
    </script>
    <script language="javascript" type="text/javascript">

        function File_OnChangePhoto(sender) {
            val = sender.value;
            document.getElementById('txtAddFilePath').value = val;
            document.getElementById("hfPhoto").value = val;
        }
        function File_OnChangeResume(sender) {
            val = sender.value;
            document.getElementById('ResumeUrl').value = val;
            document.getElementById("ResumeHF").value = val;
        }
        function File_OnChange(sender) {
            val = sender.value;
            document.getElementById('MarksheetUrl').value = val;
            document.getElementById("MarksheetUrlHd").value = val;
        }
        function charecteronly(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && ((charCode < 65 || charCode > 90) && (charCode < 97 || charCode > 122)))
                return false;
            return true;
        }
        function cancel(obj) {
            document.getElementById(obj.id).value = "";
            alert("Click on Image to write Date");
        }
        function copyaddress() {
            var add1 = document.getElementById("CurrentAddress").value;

            if (add1 == "") {
                alert('Current Address cannot be null');
            }
            else {
                document.getElementById("PermanentAddress").value = add1;
            }
        }
        function numeralsOnly(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;
            return true;
        }
        function phonenumber(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57) && charCode != 40 && charCode != 41)
                return false;
            return true;
        }
    </script>
    <script type="text/javascript">
        var TotalChkBx;
        var Counter;

        Counter = 0;


        function SelectAll(CheckBox) {

            var TargetBaseControl = document.getElementById('<%= this.gvEmployeeDetails.ClientID %>');

            var TargetChildControl = "chkselect";
            var Inputs = TargetBaseControl.getElementsByTagName("input");
            for (var n = 0; n < Inputs.length; ++n)
                if (Inputs[n].type == 'checkbox')
                    Inputs[n].checked = CheckBox.checked;
            Counter = CheckBox.checked ? TotalChkBx : 0;
        }

        function ChildClick(CheckBox) {

            TotalChkBx = parseInt('<%= this.gvEmployeeDetails.Rows.Count %>');

            var HeaderCheckBox = document.getElementById('ctl00_ContentPlaceHolder1_gvEmployeeDetails_ctl01_chkHeaderchkSelect');
            if (CheckBox.checked && Counter < TotalChkBx)
                Counter++;
            else if (Counter > 0)
                Counter--;
            if (Counter < TotalChkBx)
                HeaderCheckBox.checked = false;
            else if (Counter == TotalChkBx)
                HeaderCheckBox.checked = true;
        }         
    
    </script>
    <asp:UpdatePanel ID="up1" runat="server">
        <ContentTemplate>
            <div class="tblDashboard1">
                <div class="firstpanel">
                    <div class="activitydivfull">
                        <div class="ActivityHeader">
                            <asp:Label ID="lblTitle" runat="server" Text="Employee Registration" meta:resourcekey="lblTitleResource1"></asp:Label>
                        </div>
                        <div class="ActivityContnet">
                            <div class="standarbtn">
                                <ul>
                                    <li class="standarbar">
                                        <asp:ImageButton ID="ibtnSearch" runat="server" ImageUrl="~/App_Themes/Responsive/web/searchuser.png"
                                            ToolTip="Search Employee" OnClick="ibtnSearch_Click" meta:resourcekey="ibtnSearchResource1" />
                                    </li>
                                    <li class="standarbar">
                                        <asp:ImageButton ID="ibtnRefresh" runat="server" ImageUrl="~/App_Themes/Responsive/web/rectreload.png"
                                            ToolTip="Refresh" OnClick="ibtnRefresh_Click" meta:resourcekey="ibtnRefreshResource1" />
                                    </li>
                                    <li class="standarbar">
                                        <asp:ImageButton ID="ibtnAdd" runat="server" ImageUrl="~/App_Themes/Responsive/web/plus.png"
                                            ToolTip="Add Employee" meta:resourcekey="ibtnAddResource1" OnClick="ibtnAdd_Click" />
                                    </li>
                                    <li class="standarbar">
                                        <asp:ImageButton ID="ibtnEdit" runat="server" ImageUrl="~/App_Themes/Responsive/web/edit.png"
                                            ToolTip="Edit Employee" OnClick="ibtnEdit_Click" meta:resourcekey="ibtnEditResource1" />
                                    </li>
                                    <li class="standarbar">
                                        <asp:ImageButton ID="ImgBtnActivate" runat="server" ImageUrl="~/App_Themes/Responsive/web/activeuser.png"
                                            OnClick="ImgBtnActivate_Click"  meta:resourcekey="ImgBtnActivateResource1" />
                                    </li>
                                    <li class="standarbar">
                                        <asp:ImageButton ID="ibtnDelete" runat="server" ImageUrl="~/App_Themes/Responsive/web/close.png"
                                            ToolTip="Delete Employee" OnClick="ibtnDelete_Click" meta:resourcekey="ibtnDeleteResource1" />
                                    </li>
                                </ul>
                            </div>
                            <div>
                                <asp:Panel ID="pnlSearch" runat="server" CssClass="Visible" meta:resourcekey="pnlSearchResource1">
                                    <div class="subheaduserdetail" id="fsEmployeeSearch" runat="server">
                                        <asp:Label ID="lblSearchTitle" runat="server" Text="Search" meta:resourceKey="lblSearchTitleResource1"></asp:Label>
                                    </div>
                                    <div class="ActivityContent">
                                        <div>
                                            <asp:Label ID="lblSearchFirstName" runat="server" Text="Name:" meta:resourceKey="lblSearchFirstNameResource1"></asp:Label>
                                            <asp:TextBox ID="txtSearchFirstName" runat="server" MaxLength="30" onkeypress="return charecteronly(event);"
                                                meta:resourceKey="txtSearchFirstNameResource1"></asp:TextBox>
                                            <cc1:TextBoxWatermarkExtender ID="WaterExtnFirstName" TargetControlID="txtSearchFirstName"
                                                WatermarkText="First Name" runat="server">
                                            </cc1:TextBoxWatermarkExtender>
                                            <asp:Label ID="lblSearchMiddleName" runat="server" Text="Middle Name:" meta:resourceKey="lblSearchMiddleNameResource1"></asp:Label>
                                            <asp:TextBox ID="txtSearchMiddleName" runat="server" MaxLength="30" onkeypress="return charecteronly(event);"
                                                meta:resourceKey="txtSearchMiddleNameResource1"></asp:TextBox>
                                            <cc1:TextBoxWatermarkExtender ID="WaterExtnMiddleName" TargetControlID="txtSearchMiddleName"
                                                WatermarkText="Middle Name" runat="server">
                                            </cc1:TextBoxWatermarkExtender>
                                            <asp:Label ID="lblSearchLastName" runat="server" Text="Last Name:" meta:resourceKey="lblSearchLastNameResource1"></asp:Label>
                                            <asp:TextBox ID="txtSearchLastName" runat="server" MaxLength="30" onkeypress="return charecteronly(event);"
                                                meta:resourceKey="txtSearchLastNameResource1"></asp:TextBox>
                                            <cc1:TextBoxWatermarkExtender ID="WaterExtnLastName" TargetControlID="txtSearchLastName"
                                                WatermarkText="Last Name" runat="server">
                                            </cc1:TextBoxWatermarkExtender>
                                        </div>
                                        <div>
                                            <asp:Label ID="lblSearchDOB" runat="server" Text="Date Of Birth:" CssClass="textlabel1"
                                                meta:resourceKey="lblSearchDOBResource1"></asp:Label>
                                            <asp:TextBox ID="txtSearchDOB" runat="server" MaxLength="30" CssClass="controllabel"
                                                onkeyup="cancel(this);" meta:resourceKey="txtSearchDOBResource1"></asp:TextBox>
                                            <div style="padding: 2px; background-color: #444; width: 20px; height: 20px; display: inline-block;
                                                margin-left: 4px; border-radius: 4px;">
                                                <asp:ImageButton ID="ibtnSearchCalender" runat="server" ImageUrl="~/App_Themes/Responsive/web/calender.png"
                                                    Width="20px" meta:resourceKey="ibtnSearchCalenderResource1" />
                                            </div>
                                            <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtSearchDOB"
                                                PopupButtonID="ibtnSearchCalender" Enabled="True" Format="dd-MMM-yyyy">
                                            </cc1:CalendarExtender>
                                        </div>
                                        <div>
                                            <asp:Label ID="lblSearchGender" runat="server" Text="Gender:" CssClass="textlabel1"
                                                meta:resourceKey="lblSearchGenderResource1"></asp:Label>
                                            <div class="controllabel">
                                                <asp:RadioButtonList ID="rlstSearchGender" runat="server" RepeatDirection="Horizontal"
                                                    meta:resourceKey="rlstSearchGenderResource1">
                                                    <asp:ListItem Value="M" Text="Male" meta:resourceKey="ListItemResource1"></asp:ListItem>
                                                    <asp:ListItem Value="F" Text="Female" meta:resourceKey="ListItemResource2"></asp:ListItem>
                                                </asp:RadioButtonList>
                                            </div>
                                        </div>
                                        <div>
                                            <asp:Label ID="lblSearchBloodGroup" runat="server" Text="Blood Group:" CssClass="textlabel1"
                                                meta:resourceKey="lblSearchBloodGroupResource1"></asp:Label>
                                            <asp:TextBox ID="txtSearchBloodGroup" runat="server" MaxLength="20" CssClass="controllabel"
                                                meta:resourceKey="txtSearchBloodGroupResource1"></asp:TextBox>
                                        </div>
                                        <div>
                                            <asp:Label ID="lblSearchQualification" runat="server" Text="Qualification:" CssClass="textlabel1"
                                                meta:resourceKey="lblSearchQualificationResource1"></asp:Label>
                                            <asp:TextBox ID="txtSearchQualification" runat="server" CssClass="controllabel" MaxLength="30"
                                                meta:resourceKey="txtSearchQualificationResource1"></asp:TextBox>
                                        </div>
                                        <div>
                                            <asp:Label ID="lblSearchDesignation" runat="server" Text="Designation:" CssClass="textlabel1"
                                                meta:resourceKey="lblSearchDesignationResource1"></asp:Label>
                                            <asp:TextBox ID="txtSearchDesignation" runat="server" CssClass="controllabel" MaxLength="30"
                                                meta:resourceKey="txtSearchDesignationResource1"></asp:TextBox>
                                        </div>
                                        <div>
                                            <asp:Label ID="lblActive" runat="server" Text="Active:" CssClass="textlabel1" meta:resourceKey="lblActiveResource1"></asp:Label>
                                            <div class="controllabel">
                                                <asp:RadioButtonList ID="rlstActive" runat="server" RepeatDirection="Horizontal">
                                                    <asp:ListItem Value="1" Text="Yes" meta:resourceKey="lblActiveListItemResource1"></asp:ListItem>
                                                    <asp:ListItem Value="0" Text="No" meta:resourceKey="lblActiveListItemResource2"></asp:ListItem>
                                                </asp:RadioButtonList>
                                            </div>
                                        </div>
                                        <div class="gobotton">
                                            <asp:Button ID="btnSearchGo" runat="server" Text="Go" OnClick="btnSearchGo_Click"
                                                meta:resourceKey="btnSearchGoResource1" />
                                            <asp:Button ID="btnSearchReset" runat="server" Text="Reset" meta:resourceKey="btnSearchResetResource1"
                                                OnClick="btnSearchReset_Click" />
                                        </div>
                                    </div>
                                </asp:Panel>
                                <asp:Panel ID="pnlAdd" runat="server" CssClass="InVisible" meta:resourcekey="pnlAddResource1">
                                    <div class="subheaduserdetail" id="fsEmployeeAdd" runat="server">
                                        <asp:Label ID="lblAddTitle" runat="server" Text="Add" meta:resourceKey="lblAddTitleResource1"></asp:Label>
                                    </div>
                                    <div class="ActivityContent">
                                        <div style="text-align: right;">
                                            <asp:Label ID="Label1" runat="server" Text="* Indicates required field." ForeColor="Red"
                                                Font-Size="8pt" meta:resourceKey="Label1Resource1"></asp:Label>
                                        </div>
                                        <div>
                                            <asp:Label ID="lblAddFirstName" runat="server" Text="First Name:" meta:resourceKey="lblAddFirstNameResource1"></asp:Label>
                                            <asp:TextBox ID="txtAddFirstName" runat="server" MaxLength="30" onkeypress="return charecteronly(event);"
                                                meta:resourceKey="txtAddFirstNameResource1"></asp:TextBox>
                                            &nbsp;<asp:RequiredFieldValidator ID="rqdAddFN" runat="server" ControlToValidate="txtAddFirstName"
                                                ErrorMessage="First Name Must Be Required" ValidationGroup="PD" Display="None"
                                                meta:resourceKey="rqdAddFNResource1"></asp:RequiredFieldValidator>
                                            <asp:Label ID="lblAddMiddleName" runat="server" Text="Middle Name:" meta:resourceKey="lblAddMiddleNameResource1"></asp:Label>
                                            <asp:TextBox ID="txtAddMiddleName" runat="server" MaxLength="30" onkeypress="return charecteronly(event);"
                                                meta:resourceKey="txtAddMiddleNameResource1"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rqdAddMiddleName" runat="server" ControlToValidate="txtAddMiddleName"
                                                ErrorMessage="Middle Name Must Be Required " ValidationGroup="PD" Display="None"
                                                meta:resourceKey="rqdAddMiddleNameResource1"></asp:RequiredFieldValidator>
                                            <asp:Label ID="lblAddLastName" runat="server" Text="Last Name:" meta:resourceKey="lblAddLastNameResource1"></asp:Label>
                                            <asp:TextBox ID="txtAddLastName" runat="server" MaxLength="30" onkeypress="return charecteronly(event);"
                                                meta:resourceKey="txtAddLastNameResource1"></asp:TextBox>
                                            &nbsp;<asp:RequiredFieldValidator ID="rqdAddLastName" runat="server" ControlToValidate="txtAddLastName"
                                                ErrorMessage="Last Name Must Be Required " ValidationGroup="PD" Display="None"
                                                meta:resourceKey="rqdAddLastNameResource1"></asp:RequiredFieldValidator>
                                        </div>
                                        <div>
                                            <asp:Label ID="lblAddDob" runat="server" Text="Date Of Birth:" CssClass="textlabel1"
                                                meta:resourceKey="lblAddDobResource1"></asp:Label>
                                            <asp:TextBox ID="txtAddDOB" runat="server" MaxLength="30" CssClass="controllabel"
                                                onkeyup="cancel(this);" meta:resourceKey="txtAddDOBResource1"></asp:TextBox>
                                            <div style="padding: 2px; background-color: #444; width: 20px; height: 20px; display: inline-block;
                                                margin-left: 4px; border-radius: 4px;">
                                                <asp:ImageButton ID="ibtnAddCalender" runat="server" ImageUrl="~/App_Themes/Responsive/web/Calender.png"
                                                    Width="20px" meta:resourceKey="ibtnAddCalenderResource1" />
                                            </div>
                                            &nbsp;<asp:RequiredFieldValidator ID="rqdAddDOB" runat="server" ControlToValidate="txtAddDOB"
                                                ErrorMessage="Date of birth Must Be Required " ValidationGroup="PD" Display="None"
                                                meta:resourceKey="rqdAddDOBResource1"></asp:RequiredFieldValidator>
                                            <cc1:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtAddDOB"
                                                PopupButtonID="ibtnAddCalender" Enabled="True" Format="dd-MMM-yyyy">
                                            </cc1:CalendarExtender>
                                        </div>
                                        <div>
                                            <asp:Label ID="lblAddGender" runat="server" Text="Gender:" CssClass="textlabel1"
                                                meta:resourceKey="lblAddGenderResource1"></asp:Label>
                                            <div class="controllabel">
                                                <asp:RadioButtonList ID="rlstAddGender" runat="server" RepeatDirection="Horizontal"
                                                    meta:resourceKey="rlstAddGenderResource1">
                                                    <asp:ListItem Value="M" Text="Male" meta:resourceKey="ListItemResource3"></asp:ListItem>
                                                    <asp:ListItem Value="F" Text="Female" meta:resourceKey="ListItemResource4"></asp:ListItem>
                                                </asp:RadioButtonList>
                                            </div>
                                        </div>
                                        <div>
                                            <asp:Label ID="lblAddBloodGroup" runat="server" Text="Blood Group:" CssClass="textlabel1"
                                                meta:resourceKey="lblAddBloodGroupResource1"></asp:Label>
                                            <asp:TextBox ID="txtAddBloodGroup" runat="server" CssClass="controllabel" MaxLength="20"
                                                meta:resourceKey="txtAddBloodGroupResource1"></asp:TextBox>
                                            &nbsp;<asp:RequiredFieldValidator ID="rqdAddBloodGroup" runat="server" ControlToValidate="txtAddBloodGroup"
                                                ErrorMessage="Blood Group Must Be Required" ValidationGroup="PD" Display="None"
                                                meta:resourceKey="rqdAddBloodGroupResource1"></asp:RequiredFieldValidator>
                                        </div>
                                        <div>
                                            <asp:Label ID="lblAddPermanentAddress" runat="server" Text="Permanent Address:" CssClass="textlabel1"
                                                meta:resourceKey="lblAddPermanentAddressResource1"></asp:Label>
                                            <asp:TextBox ID="txtAddPermanentAddress" runat="server" CssClass="multiline2 controllabel"
                                                TextMode="MultiLine" meta:resourceKey="txtAddPermanentAddressResource1"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rqdAddPermanentAddress" runat="server" ControlToValidate="txtAddPermanentAddress"
                                                ErrorMessage="Permanent Address Must be Required" ValidationGroup="PD" Display="None"
                                                meta:resourceKey="rqdAddPermanentAddressResource1"></asp:RequiredFieldValidator>
                                        </div>
                                        <div>
                                            <asp:Label ID="lblAddContactNumber" runat="server" Text="Contact Number:" CssClass="textlabel1"
                                                meta:resourceKey="lblAddContactNumberResource1"></asp:Label>
                                            <asp:TextBox ID="txtAddContactNumber" runat="server" CssClass="controllabel" MaxLength="13"
                                                onkeypress="return phonenumber(event);" meta:resourceKey="txtAddContactNumberResource1"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rqdAddMobileNo" runat="server" ControlToValidate="txtAddContactNumber"
                                                ErrorMessage="Contact Number Must be Required" ValidationGroup="PD" Display="None"
                                                meta:resourceKey="rqdAddMobileNoResource1"></asp:RequiredFieldValidator>
                                        </div>
                                        <div>
                                            <asp:Label ID="lblAddEmail" runat="server" Text="Email:" CssClass="textlabel1" meta:resourceKey="lblAddEmailResource1"></asp:Label>
                                            <asp:TextBox ID="txtAddEmail" runat="server" MaxLength="30" CssClass="controllabel"
                                                meta:resourceKey="txtAddEmailResource1"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rqdAddEmail" runat="server" ControlToValidate="txtAddEmail"
                                                ErrorMessage="Email id Must be Required" ValidationGroup="PD" Display="None"
                                                meta:resourceKey="rqdAddEmailResource1"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="revAddEMAIL" runat="server" ControlToValidate="txtAddEmail"
                                                Display="None" ErrorMessage="Enter Valid Email Address" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                ValidationGroup="PD" meta:resourceKey="revAddEMAILResource1"></asp:RegularExpressionValidator>
                                        </div>
                                        <div>
                                            <asp:Label ID="lblAddQualification" runat="server" Text="Qualification:" CssClass="textlabel1"
                                                meta:resourceKey="lblAddQualificationResource1"></asp:Label>
                                            <asp:TextBox ID="txtAddQualification" runat="server" CssClass="controllabel" MaxLength="30"
                                                meta:resourceKey="txtAddQualificationResource1"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rqdAddQualification" runat="server" ControlToValidate="txtAddQualification"
                                                ErrorMessage="Qualification Must be Required" ValidationGroup="PD" Display="None"
                                                meta:resourceKey="rqdAddQualificationResource1"></asp:RequiredFieldValidator>
                                        </div>
                                        <div>
                                            <asp:Label ID="lblAddDesignation" runat="server" Text="Designation:" CssClass="textlabel1"
                                                meta:resourceKey="lblAddDesignationResource1"></asp:Label>
                                            <asp:TextBox ID="txtAddDesignation" runat="server" CssClass="controllabel" MaxLength="30"
                                                meta:resourceKey="txtAddDesignationResource1"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rqdAddDesignation" runat="server" ControlToValidate="txtAddDesignation"
                                                ErrorMessage="Designation Must be Required" ValidationGroup="PD" Display="None"
                                                meta:resourceKey="rqdAddDesignationResource1"></asp:RequiredFieldValidator>
                                        </div>
                                        <div>
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
                                        </div>
                                        <div>
                                            <asp:TextBox ID="txtAddFilePath" runat="server" Width="200px" Visible="false" ReadOnly="True"
                                                meta:resourceKey="txtAddFilePathResource1"></asp:TextBox>
                                            <asp:HiddenField ID="hfPhoto" runat="server" />
                                            <asp:RegularExpressionValidator ID="rqdAddUPhoto" runat="server" ErrorMessage="Select Only Image Format Files"
                                                ValidationExpression="([0-9a-zA-Z :\\-_-!@$%^&amp;*()])+(.jpg|.JPG)$" ControlToValidate="FilePhoto"
                                                ValidationGroup="PD" meta:resourceKey="rqdAddUPhotoResource1"></asp:RegularExpressionValidator>
                                            &nbsp;<span style="color: Blue; font-size: small"></span>
                                        </div>
                                        <div>
                                            <asp:Label ID="lblAddSecurityQuestion" runat="server" Text="Security Question:" CssClass="textlabel1"
                                                meta:resourceKey="lblAddSecurityQuestionResource1"></asp:Label>
                                            <div class="controllabel">
                                                <asp:DropDownList ID="ddlAddSecurityQues" runat="server" meta:resourceKey="ddlAddSecurityQuesResource1">
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
                                            </div>
                                            &nbsp;<asp:RequiredFieldValidator ID="rqdddlAddSecurityQues" runat="server" ControlToValidate="ddlAddSecurityQues"
                                                ErrorMessage="Security Question Must Be Select." ValidationGroup="PD" Display="None"
                                                meta:resourceKey="rqdddlAddSecurityQuesResource1"></asp:RequiredFieldValidator>
                                        </div>
                                        <div>
                                            <asp:Label ID="lblAddSecurityAnswer" runat="server" Text="Security Answer:" CssClass="textlabel1"
                                                meta:resourceKey="lblAddSecurityAnswerResource1"></asp:Label>
                                            <asp:TextBox ID="txtAddSecAns" runat="server" MaxLength="30" CssClass="controllabel"
                                                meta:resourceKey="txtAddSecAnsResource1"></asp:TextBox>
                                            &nbsp;<asp:RequiredFieldValidator ID="rqdtxtAddSecAns" runat="server" ControlToValidate="txtAddSecAns"
                                                ErrorMessage="Security Answer Must Be Required" ValidationGroup="PD" Display="None"
                                                meta:resourceKey="rqdtxtAddSecAnsResource1"></asp:RequiredFieldValidator>
                                        </div>
                                        <div>
                                            <asp:ValidationSummary ID="vsumRegistration" runat="server" ValidationGroup="PD"
                                                Font-Bold="False" ShowMessageBox="True" ShowSummary="False" meta:resourceKey="ValidationSummary1Resource1" />
                                        </div>
                                        <div class="gobotton">
                                            <asp:Button ID="btnAddSave" runat="server" Text="Save" ValidationGroup="PD" OnClick="btnAddSave_Click"
                                                meta:resourceKey="btnAddSaveResource1" />
                                            <asp:Button ID="btnAddReset" runat="server" Text="Reset" OnClick="btnAddReset_Click"
                                                meta:resourceKey="btnAddResetResource1" />
                                        </div>
                                    </div>
                                </asp:Panel>
                                <asp:Panel ID="pnlEdit" runat="server" CssClass="InVisible" meta:resourcekey="pnlEditResource1">
                                    <div class="subheaduserdetail" id="fsEmployeeUpdate" runat="server">
                                        <asp:Label ID="lblUpdateTitle" runat="server" Text="Update" meta:resourceKey="lblUpdateTitleResource1"></asp:Label>
                                    </div>
                                    <div class="ActivityContent">
                                        <div style="text-align: right;">
                                            <asp:Label ID="lblRequiredField" runat="server" Text="* Indicates required field."
                                                ForeColor="Red" Font-Size="8pt" meta:resourceKey="lblRequiredFieldResource1"></asp:Label>
                                        </div>
                                        <div>
                                            <asp:Label ID="lblUpdateFirstName" runat="server" Text="First Name:" CssClass="textlabel1"
                                                meta:resourceKey="lblUpdateFirstNameResource1"></asp:Label>
                                            <asp:TextBox ID="txtUpdateFirstName" runat="server" MaxLength="30" onkeypress="return charecteronly(event);"
                                                meta:resourceKey="txtUpdateFirstNameResource1"></asp:TextBox>
                                            &nbsp;<asp:RequiredFieldValidator ID="rqdUpdateFN" runat="server" ControlToValidate="txtUpdateFirstName"
                                                ErrorMessage="First Name Must Be Required" ValidationGroup="PD1" Display="None"
                                                meta:resourceKey="rqdUpdateFNResource1"></asp:RequiredFieldValidator>
                                            <asp:Label ID="lblUpdateMiddleName" runat="server" Text="Middle Name:" meta:resourceKey="lblUpdateMiddleNameResource1"></asp:Label>
                                            <asp:TextBox ID="txtUpdateMiddleName" runat="server" MaxLength="30" onkeypress="return charecteronly(event);"
                                                meta:resourceKey="txtUpdateMiddleNameResource1"></asp:TextBox>
                                            &nbsp;<asp:RequiredFieldValidator ID="rqdUpdateMiddleName" runat="server" ControlToValidate="txtUpdateMiddleName"
                                                ErrorMessage="Middle Name Must Be Required " ValidationGroup="PD1" Display="None"
                                                meta:resourceKey="rqdUpdateMiddleNameResource1"></asp:RequiredFieldValidator>
                                            <asp:Label ID="lblUpdateLastName" runat="server" Text="Last Name:" meta:resourceKey="lblUpdateLastNameResource1"></asp:Label>
                                            <asp:TextBox ID="txtUpdateLastName" runat="server" MaxLength="30" onkeypress="return charecteronly(event);"
                                                meta:resourceKey="txtUpdateLastNameResource1"></asp:TextBox>
                                            &nbsp;<asp:RequiredFieldValidator ID="rqdUpdateLastName" runat="server" ControlToValidate="txtUpdateLastName"
                                                ErrorMessage="Last Name Must Be Required " ValidationGroup="PD1" Display="None"
                                                meta:resourceKey="rqdUpdateLastNameResource1"></asp:RequiredFieldValidator>
                                        </div>
                                        <div>
                                            <asp:Label ID="lblUpdateDob" runat="server" Text="Date Of Birth:" CssClass="textlabel1"
                                                meta:resourceKey="lblUpdateDobResource1"></asp:Label>
                                            <div class="controllabel">
                                                <asp:TextBox ID="txtUpdateDOB" runat="server" MaxLength="30" onkeyup="cancel(this);"
                                                    meta:resourceKey="txtUpdateDOBResource1" CssClass="controllabel"></asp:TextBox>
                                                <div style="padding: 2px; background-color: #444; width: 20px; height: 20px; display: inline-block;
                                                    margin-left: 4px; border-radius: 4px;">
                                                    <asp:ImageButton ID="ibtnUpdateCalender" runat="server" ImageUrl="~/App_Themes/Responsive/web/Calender.png"
                                                        Width="20px" meta:resourceKey="ibtnUpdateCalenderResource1" />
                                                </div>
                                                &nbsp;<asp:RequiredFieldValidator ID="rqdUpdateDOB" runat="server" ControlToValidate="txtUpdateDOB"
                                                    ErrorMessage="Date of birth Must Be Required " ValidationGroup="PD1" Display="None"
                                                    meta:resourceKey="rqdUpdateDOBResource1"></asp:RequiredFieldValidator>
                                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtUpdateDOB"
                                                    PopupButtonID="ibtnUpdateCalender" Enabled="True" Format="dd-MMM-yyyy">
                                                </cc1:CalendarExtender>
                                            </div>
                                        </div>
                                        <div>
                                            <asp:Label ID="lblUpdateGender" runat="server" Text="Gender:" CssClass="textlabel1"
                                                meta:resourceKey="lblUpdateGenderResource1"></asp:Label>
                                            <div class="controllabel">
                                                <asp:RadioButtonList ID="rlstUpdateGender" runat="server" RepeatDirection="Horizontal"
                                                    meta:resourceKey="rlstUpdateGenderResource1">
                                                    <asp:ListItem Value="M" Text="Male" meta:resourceKey="ListItemResource13"></asp:ListItem>
                                                    <asp:ListItem Value="F" Text="Female" meta:resourceKey="ListItemResource14"></asp:ListItem>
                                                </asp:RadioButtonList>
                                            </div>
                                        </div>
                                        <div>
                                            <asp:Label ID="lblUpdateBloodGroup" runat="server" Text="Blood Group:" CssClass="textlabel1"
                                                meta:resourceKey="lblUpdateBloodGroupResource1"></asp:Label>
                                            <asp:TextBox ID="txtUpdateBloodGroup" runat="server" CssClass="controllabel" MaxLength="20"
                                                meta:resourceKey="txtUpdateBloodGroupResource1"></asp:TextBox>
                                            &nbsp;<asp:RequiredFieldValidator ID="rqdUpdateBloodGroup" runat="server" ControlToValidate="txtUpdateBloodGroup"
                                                ErrorMessage="Blood Group Must Be Required" ValidationGroup="PD1" Display="None"
                                                meta:resourceKey="rqdUpdateBloodGroupResource1"></asp:RequiredFieldValidator>
                                        </div>
                                        <div>
                                            <asp:Label ID="lblUpdatePermanentAddress" runat="server" CssClass="textlabel1" Text="Permanent Address:"
                                                meta:resourceKey="lblUpdatePermanentAddressResource1"></asp:Label>
                                            <div class="controllabel" style="width: 300px; height: 100px;">
                                                <asp:TextBox ID="txtUpdatePermanentAddress" runat="server" MaxLength="250" CssClass="multiline2"
                                                    TextMode="MultiLine" meta:resourceKey="txtUpdatePermanentAddressResource1"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rqdUpdatePermanentAddress" runat="server" ControlToValidate="txtUpdatePermanentAddress"
                                                    ErrorMessage="Permanent Address Must be Required" ValidationGroup="PD1" Display="None"
                                                    meta:resourceKey="rqdUpdatePermanentAddressResource1"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div>
                                            <asp:Label ID="lblUpdateContactNumber" runat="server" CssClass="textlabel1" Text="Contact Number:"
                                                meta:resourceKey="lblUpdateContactNumberResource1"></asp:Label>
                                            <asp:TextBox ID="txtUpdateContactNo" runat="server" CssClass="controllabel" MaxLength="13"
                                                onkeypress="return phonenumber(event);" meta:resourceKey="txtUpdateContactNoResource1"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rqdUpdateContactNo" runat="server" ControlToValidate="txtUpdateContactNo"
                                                ErrorMessage="Mobile Number Must be Required" ValidationGroup="PD1" Display="None"
                                                meta:resourceKey="rqdUpdateContactNoResource1"></asp:RequiredFieldValidator>
                                        </div>
                                        <div>
                                            <asp:Label ID="lblUpdateEmail" runat="server" Text="Email:" CssClass="textlabel1"
                                                meta:resourceKey="lblUpdateEmailResource1"></asp:Label>
                                            <asp:TextBox ID="txtUpdateEmail" runat="server" CssClass="controllabel" MaxLength="30"
                                                meta:resourceKey="txtUpdateEmailResource1"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rqdUpdateEmail" runat="server" ControlToValidate="txtUpdateEmail"
                                                ErrorMessage="Email id Must be Required" ValidationGroup="PD1" Display="None"
                                                meta:resourceKey="rqdUpdateEmailResource1"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="revUpdateEMAIL" runat="server" ControlToValidate="txtUpdateEmail"
                                                Display="None" ErrorMessage="Enter Valid Email Address" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                ValidationGroup="PD1" meta:resourceKey="revUpdateEMAILResource1"></asp:RegularExpressionValidator>
                                        </div>
                                        <div>
                                            <asp:Label ID="lblUpdateQualification" runat="server" CssClass="textlabel1" Text="Qualification:"
                                                meta:resourceKey="lblUpdateQualificationResource1"></asp:Label>
                                            <asp:TextBox ID="txtUpdateQualification" runat="server" CssClass="controllabel" MaxLength="30"
                                                meta:resourceKey="txtUpdateQualificationResource1"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rqdUpdateQualification" runat="server" ControlToValidate="txtUpdateQualification"
                                                ErrorMessage="Qualification Must be Required" ValidationGroup="PD1" Display="None"
                                                meta:resourceKey="rqdUpdateQualificationResource1"></asp:RequiredFieldValidator>
                                        </div>
                                        <div>
                                            <asp:Label ID="lblUpdateDesignation" runat="server" CssClass="textlabel1" Text="Designation:"
                                                meta:resourceKey="lblUpdateDesignationResource1"></asp:Label>
                                            <asp:TextBox ID="txtUpdateDesignation" runat="server" CssClass="controllabel" MaxLength="30"
                                                meta:resourceKey="txtUpdateDesignationResource1"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rqdUpdateDesignation" runat="server" ControlToValidate="txtUpdateDesignation"
                                                ErrorMessage="Designation Must be Required" ValidationGroup="PD1" Display="None"
                                                meta:resourceKey="rqdUpdateDesignationResource1"></asp:RequiredFieldValidator>
                                        </div>
                                        <div>
                                            <asp:Label ID="lblUpdatePhoto" runat="server" Text="Photo:" CssClass="textlabel1"
                                                meta:resourceKey="lblUpdatePhotoResource1"></asp:Label>
                                            <div class="controllabel" style="width: 200px;">
                                                <asp:FormView ID="FormView1" runat="server" Width="125px" Height="125px" BorderColor="#999966"
                                                    BorderStyle="Double" BorderWidth="2px">
                                                    <ItemTemplate>
                                                        <img id="imgDiplay" alt="" src='Handler.ashx?EmployeeID=<%# Eval("EmployeeID") %> '
                                                            height="125px" width="125px" />
                                                    </ItemTemplate>
                                                </asp:FormView>
                                                <asp:Button ID="btnUpdatePhoto" runat="server" class="c_button" Text="Import an EDD"
                                                    OnClick="btn_update_FILE_Click" Style="display: none" />
                                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                    <ContentTemplate>
                                                        <asp:Image ID="imgUpdate" runat="server" AlternateText="Photo" Height="150px" Width="150px"
                                                            BackColor="Silver" BorderColor="Black" BorderStyle="Solid" ImageAlign="Middle"
                                                            ImageUrl="~/SchoolAdmin/EmployeePhoto/NoPhoto.jpg" Visible="false" />
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <%--<asp:AsyncPostBackTrigger ControlID="ddlStandard" EventName="SelectedIndexChanged" />--%>
                                                        <%--<asp:AsyncPostBackTrigger ControlID="btnUpdatePhoto" EventName="Click" />--%>
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                                <asp:FileUpload ID="fupUpdateFileUploadPhoto" runat="server" onchange="File_OnChangePhoto(this)"
                                                    meta:resourceKey="fupUpdateFileUploadPhotoResource1" />
                                                <div style="color: Blue; font-size: small">
                                                    <asp:Label ID="lblUPhoto" runat="server" Text="(Supported Files:<br /> bmp,jpeg,jpg,gif,png)"
                                                        meta:resourceKey="lblUPhotoResource1"></asp:Label>
                                                </div>
                                                <asp:TextBox ID="txtUpdatePhotoPath" runat="server" ReadOnly="True" meta:resourceKey="txtUpdatePhotoPathResource1"></asp:TextBox>
                                                <asp:HiddenField ID="PhotoHF" runat="server" />
                                                <asp:RegularExpressionValidator ID="rqdUpdateUPhoto" runat="server" ErrorMessage="Select Only Image Format Files"
                                                    ValidationExpression="([0-9a-zA-Z :\\-_-!@$%^&amp;*()])+(.jpg|.JPG|.jpeg|.JPEG|.bmp|.BMP|.gif|.GIF|.png|.PNG)$"
                                                    ControlToValidate="fupUpdateFileUploadPhoto" ValidationGroup="PD1" meta:resourceKey="rqdUpdateUPhotoResource1"></asp:RegularExpressionValidator>
                                                &nbsp;<span style="color: Blue; font-size: small"></span>
                                            </div>
                                        </div>
                                        <div>
                                            <asp:Label ID="lblUpdateSecurityQuestion" runat="server" CssClass="textlabel1" Text="Security Question:"
                                                meta:resourceKey="lblUpdateSecurityQuestionResource1"></asp:Label>
                                            <div class="controllabel">
                                                <asp:DropDownList ID="ddlUpdateSecurityQues" runat="server" meta:resourceKey="ddlUpdateSecurityQuesResource1">
                                                    <asp:ListItem Selected="True" Value="0" Text="Select Security Question" meta:resourceKey="ListItemResource15"></asp:ListItem>
                                                    <asp:ListItem Value="1" Text="What is your mother's maiden name?" meta:resourceKey="ListItemResource16"></asp:ListItem>
                                                    <asp:ListItem Value="2" Text="Where did you vacation last year?" meta:resourceKey="ListItemResource17"></asp:ListItem>
                                                    <asp:ListItem Value="3" Text="What is your license number?" meta:resourceKey="ListItemResource18"></asp:ListItem>
                                                    <asp:ListItem Value="4" Text="What is your brother’s birthday?" meta:resourceKey="ListItemResource19"></asp:ListItem>
                                                    <asp:ListItem Value="5" Text="What school did you attend for sixth grade?" meta:resourceKey="ListItemResource20"></asp:ListItem>
                                                    <asp:ListItem Value="6" Text="What was your  favourite elementary school teacher?"
                                                        meta:resourceKey="ListItemResource21"></asp:ListItem>
                                                    <asp:ListItem Value="7" Text="What is your pet name?" meta:resourceKey="ListItemResource22"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            &nbsp;<asp:RequiredFieldValidator ID="rqdddlUpdateSecurityQues" runat="server" ControlToValidate="ddlUpdateSecurityQues"
                                                ErrorMessage="Security Question Must Be Required." ValidationGroup="PD1" Display="None"
                                                meta:resourceKey="rqdddlUpdateSecurityQuesResource1"></asp:RequiredFieldValidator>
                                        </div>
                                        <div>
                                            <asp:Label ID="lblUpdateSecurityAnswer" runat="server" CssClass="textlabel1" Text="Security Answer:"
                                                meta:resourceKey="lblUpdateSecurityAnswerResource1"></asp:Label>
                                            <asp:TextBox ID="txtUpdateSecAns" runat="server" CssClass="controllabel" MaxLength="30"
                                                meta:resourceKey="txtUpdateSecAnsResource1"></asp:TextBox>
                                            &nbsp;<asp:RequiredFieldValidator ID="rqdtxtUpdateSecAns" runat="server" ControlToValidate="txtUpdateSecAns"
                                                ErrorMessage="Security Answer Must Be Required" ValidationGroup="PD1" Display="None"
                                                meta:resourceKey="rqdtxtUpdateSecAnsResource1"></asp:RequiredFieldValidator>
                                        </div>
                                        <div>
                                            <asp:ValidationSummary ID="vsumPD" runat="server" ValidationGroup="PD1" Font-Bold="False"
                                                ShowMessageBox="True" ShowSummary="False" meta:resourceKey="vsumPDResource1" />
                                        </div>
                                        <div class="gobotton">
                                            <asp:Button ID="btnUpdate" ValidationGroup="PD1" runat="server" Text="Update" OnClick="btnUpdate_Click"
                                                meta:resourceKey="btnUpdateResource1" />
                                            <asp:Button ID="btnUpdateReset" runat="server" Text="Reset" OnClick="btnUpdateReset_Click"
                                                meta:resourceKey="btnUpdateResetResource1" />
                                        </div>
                                    </div>
                                </asp:Panel>
                                <div id="PnlActivateDeactivate" runat="server" visible="false" meta:resourcekey="PnlActivateDeactivateResource1">
                                    <div class="subheaduserdetail" id="LblFlActDect" runat="server" cssclass="SubTitle"
                                        meta:resourcekey="LblFlActDectResource1">
                                        Active/Deactive User
                                    </div>
                                    <div class="ActivityContent">
                                        <div>
                                            <asp:Label ID="LblActiveAction" runat="server" Text="Action:" CssClass="textlabel"
                                                meta:resourceKey="LblActiveActionResource1"></asp:Label>
                                            <asp:RadioButton ID="RdbActive" runat="server" Text="Active" GroupName="ActDeact"
                                                Checked="True" meta:resourceKey="RdbActiveResource1" />
                                            <asp:RadioButton ID="RdbDeactive" runat="server" Text="Deactive" GroupName="ActDeact"
                                                meta:resourceKey="RdbDeactiveResource1" />
                                        </div>
                                        <div class="gobotton">
                                            <asp:Button ID="BtnActDeactSub" runat="server" Text="Submit" CssClass="gobutton"
                                                meta:resourceKey="BtnActDeactSubResource1" OnClick="BtnActDeactSub_Click" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div style="float: left;">
                                <asp:GridView ID="gvEmployeeDetails" runat="server" DataKeyNames="EmployeeID,Code,RoleID,SchoolID,LoginID,IsActive,AllowMultipleSession"
                                    AutoGenerateColumns="False" OnPageIndexChanging="gvEmployeeDetails_PageIndexChanging"
                                    OnRowCreated="gvEmployeeDetails_RowCreated" OnSorting="gvEmployeeDetails_Sorting"
                                    meta:resourcekey="gvEmployeeDetailsResource1">
                                    <Columns>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" meta:resourcekey="TemplateFieldResource1">
                                            <HeaderTemplate>
                                                <table>
                                                    <tr>
                                                        <td align="center">
                                                            <asp:CheckBox ID="chkHeaderchkSelect" runat="server" onclick="javascript:SelectAll(this);"
                                                                meta:resourcekey="chkHeaderchkSelectResource1" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <table>
                                                    <tr>
                                                        <td align="center">
                                                            <asp:CheckBox ID="chkSelect" runat="server" onclick="javascript:ChildClick(this);"
                                                                meta:resourcekey="chkSelectResource2" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Sr. No" meta:resourcekey="TemplateFieldResource2">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex +1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="EmpName" HeaderText="Employee" SortExpression="EmpName"
                                            meta:resourcekey="BoundFieldResource1" />
                                       <%-- <asp:BoundField DataField="DateOfBirth" HeaderText="Date Of Birthday" SortExpression="DOB"
                                            DataFormatString="{0: dd-MMM-yyyy}" meta:resourcekey="BoundFieldResource2" />
                                        <asp:BoundField DataField="Gender" HeaderText="Gender" SortExpression="Gender" meta:resourcekey="BoundFieldResource3" />
                                        <asp:BoundField DataField="BloodGroup" HeaderText="Blood Group" SortExpression="BloodGroup"
                                            meta:resourcekey="BoundFieldResource4" />--%>
                                        <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address"
                                            meta:resourcekey="BoundFieldResource5" />
                                        <asp:BoundField DataField="ContactNo" HeaderText="Contact Number" SortExpression="ContactNumber"
                                            meta:resourcekey="BoundFieldResource6" />
                                        <asp:BoundField DataField="EmailID" HeaderText="Email" SortExpression="Email" meta:resourcekey="BoundFieldResource7" />
                                        <asp:BoundField DataField="Qualification" HeaderText="Qualification" SortExpression="Qaulification"
                                            meta:resourcekey="BoundFieldResource8" />
                                        <asp:BoundField DataField="Designation" HeaderText="Designation" SortExpression="Designation"
                                            meta:resourcekey="BoundFieldResource9" />
                                <%--        <asp:BoundField DataField="IsActive" HeaderText="IsActive" SortExpression="IsActive"
                                            meta:resourcekey="BoundFieldResource10" />--%>
                                    </Columns>
                                    <PagerTemplate>
                                        <asp:ImageButton Text="First" CommandName="Page" CommandArgument="First" runat="server"
                                            ImageUrl="~/App_Themes/Images/first.png" ID="ibtnFirst" ToolTip="Move First Page"
                                            meta:resourcekey="ibtnFirstResource1" />
                                        <asp:ImageButton Text="Previous" CommandName="Page" CommandArgument="Prev" runat="server"
                                            ImageUrl="~/App_Themes/Images/previous.png" ID="ibtnPrevious" ToolTip="Move Previous Page"
                                            meta:resourcekey="ibtnPreviousResource1" />
                                        <asp:Label ID="lblPage" runat="server" Text="Page" ForeColor="Black" meta:resourcekey="lblPageResource1"></asp:Label>
                                        <asp:DropDownList ID="ddlPageSelector" runat="server" AutoPostBack="True" SkinID="DdlWidth50"
                                            meta:resourcekey="ddlPageSelectorResource1">
                                        </asp:DropDownList>
                                        <asp:ImageButton Text="Next" CommandName="Page" CommandArgument="Next" runat="server"
                                            ImageUrl="~/App_Themes/Images/NEXT.png" ID="ibtnNext" ToolTip="Move Next Page"
                                            meta:resourcekey="ibtnNextResource1" />
                                        <asp:ImageButton Text="Last" CommandName="Page" CommandArgument="Last" runat="server"
                                            ImageUrl="~/App_Themes/Images/last.png" ID="ibtnLast" ToolTip="Move Last Page"
                                            meta:resourcekey="ibtnLastResource1" />
                                    </PagerTemplate>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
