<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Epathshala.master" AutoEventWireup="true"
    CodeFile="MyAccount.aspx.cs" Inherits="Student_MyAccount" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .nav-pills > li, a
        {
            padding: 5px !important;
            color: #FFF;
            background-color: #273434;
            padding: 5px;
        }
        
        .nav-pills > li.active > a, .nav-pills > li.active > a:hover, .nav-pills > li.active > a:focus
        {
            padding: 5px !important;
            padding: 5px !important;
            color: #FFF;
            background-color: #273434;
        }
        .nav-pills > li > a:hover
        {
            padding: 5px !important;
            background-color: transparent !important;
            border-radius: 0px !important;
            color: White !important;
            border-right: 5px SOLID #71AF32 !important;
        }
        .nav-pills > li.active > a, .nav-pills > li.active > a:hover, .nav-pills > li.active > a:focus
        {
            background-color: transparent;
            color: #F78B08 !important;
            padding: 5px !important;
            border-radius: 0px;
            border-right: 5px solid #255C49 !important;
        }
        .nav-pills > li.active > a, .nav-pills > li.active > a:hover, .nav-pills > li.active > a:focus
        {
            color: White !important;
            padding: 5px !important;
            background-color: transparent !important;
        }
        .nav-tabs > li:hover > a:hover
        {
            color: White !important;
            border-radius: 0px !important;
            padding: 5px !important;
            background-color: transparent !important;
            border: 1px solid #2E8E6E !important;
            -moz-border-top-colors: none !important;
            -moz-border-right-colors: none !important;
            -moz-border-bottom-colors: none !important;
            -moz-border-left-colors: none !important;
            border-image: none !important;
            cursor: pointer !important;
            width: 150px !important;
        }
        .nav-tabs > li > a
        {
            color: White !important;
            border-radius: 0px !important;
            padding: 5px !important;
            border-radius: 0px !important;
            background-color: transparent !important;
            border: 1px solid #2E8E6E !important;
            border-image: none !important;
            cursor: pointer !important;
            width: 150px !important;
        }
        .nav-tabs > li.active > a, .nav-tabs > li.active > a:hover, .nav-tabs > li.active > a:focus
        {
            color: White !important;
            border-radius: 0px !important;
            border-radius: 0px !important;
            padding: 5px !important;
            background-color: #273434 !important;
            border: 1px solid #2E8E6E;
            border-image: none !important;
            cursor: pointer !important;
            width: 150px !important;
        }
    </style>
    <style type="text/css">
        .form-control2
        {
            background-color: #314B3C !important;
            border: 1px solid #273D2F !important;
            border-radius: 0px !important;
            box-shadow: 0 1px 1px rgba(0, 0, 0, 0.075) inset !important;
            color: #f9f9f9 !important;
            display: block !important;
            font-size: 14px !important;
            height: 34px !important;
            line-height: 1.42857 !important;
            padding: 6px 12px !important;
            transition: border-color 0.15s ease-in-out 0s, box-shadow 0.15s ease-in-out 0s !important;
            vertical-align: middle !important;
            width: 80% !important;
        }
        .input-sm2
        {
            border-radius: 0 !important;
            font-size: 12px !important;
            height: 30px !important;
            line-height: 1.5 !important;
            padding: 5px 10px !important;
            width: 80% !important;
        }
        .form-control2:focus
        {
            border-color: #48a02b !important;
            outline: 0 !important;
            -webkit-box-shadow: inset 0 1px 1px rgba(0,0,0,.075), 0 0 8px rgba(40, 225, 189, 0.6) !important;
            box-shadow: inset 0 1px 1px rgba(0,0,0,.075), 0 0 8px rgba(40, 225, 189, 0.6) !important;
        }
        .form-inline .form-control2
        {
            display: inline-block !important;
        }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            document.getElementById('profile').className = 'tab-pane fade active in';
        });


        //        function SetEducationTabActive() {
        //            $('a[href^="#tb_eduinfo"]').attr("Class", "active");
        //            
        //        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row DBHeader">
        <div class="col-sm-6 NoPadding">
            <div class="DashboardHeading">
                You are here: <span style="color: White;">My Account</span>
            </div>
        </div>
        <div class="col-sm-6 NoPadding">
            <div class="DashboardHeading">
                <img src="../App_Themes/Green/Images/icon-calendar.png" />
                &nbsp;&nbsp;<i>Today:
                    <%=DateTime.Now.ToString("dd MMMM yyyy / hh:mm tt")%>
                </i>
            </div>
        </div>
    </div>
    <%-- <div class="row">
        <div class="col-md-12">
            <div class="alert alert-success">
                <span class="glyphicon glyphicon-ok" ></span>
            <strong>Success ! </strong> Profile Details saved!.
            </div>
            <div class="alert alert-danger">
                <span class="glyphicon glyphicon-remove" ></span>
            <strong>Failed ! </strong> Profile Details could not be saved!.
            </div>
        </div>
    </div>--%>
    <div class="row">
        <div class="col-md-3">
            <ul class="nav nav-pills nav-stacked">
                <li class="active"><a href="#profile" data-toggle="tab"><span class="glyphicon glyphicon-user">
                </span>&nbsp;Profile</a></li>
                <li><a href="#ChangePassword" data-toggle="tab"><span class="glyphicon glyphicon-lock">
                </span>&nbsp;Change Password</a></li>
                <%--<li><a href="#Packages" data-toggle="tab">My Packages</a></li>--%>
            </ul>
        </div>
        <div class="col-md-9">
            <div class="tab-content">
                <div id="profile" class="tab-pane fade in">
                    <ul class="nav nav-tabs">
                        <li class="active"><a style="text-align: center;" data-toggle="tab" href="#tb_personalinfo">
                            Personal Info</a></li>
                        <li><a style="text-align: center;" data-toggle="tab" href="#tb_parentinfo">Parent/Guardian
                            Info</a></li>
                        <li><a style="text-align: center;" data-toggle="tab" href="#tb_eduinfo">Educational
                            Info</a></li>
                    </ul>
                    <div class="tab-content">
                        <div id="tb_personalinfo" class="tab-pane fade in active">
                            <%--Student's Personal Information --%>
                            <div>
                                <asp:DetailsView ID="Dvw_PersonalDetails" runat="server" AutoGenerateRows="False"
                                    SkinID="ProfileDetails" OnModeChanging="Dvw_PersonalDetails_ModeChanging" OnItemUpdating="Dvw_PersonalDetails_ItemUpdating">
                                    <Fields>
                                        <%--<asp:CommandField ShowCancelButton="true" ShowEditButton="true" HeaderText="Personal Info" />--%>
                                        <asp:TemplateField HeaderText="Personal Details" ItemStyle-HorizontalAlign="Right">
                                            <ItemTemplate>
                                                <span class="glyphicon glyphicon-edit"></span>
                                                <asp:LinkButton ID="Lbtn_EditPersonalDetails" CommandName="Edit" Text="Edit" runat="server" />
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <span class="glyphicon glyphicon-floppy-disk"></span>
                                                <asp:LinkButton ID="Lbtn_SavePersonalDetails" CommandName="Update" ValidationGroup="a"
                                                    Text="Save" runat="server" />
                                                | <span class="glyphicon glyphicon-floppy-remove"></span>
                                                <asp:LinkButton ID="Lbtn_CancelPersonalDetails" CommandName="Cancel" Text="Cancel"
                                                    runat="server" />
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="StudentId" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="Lbl_StudentID" Text='<%# Eval("StudentID") %>' runat="server" />
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:Label ID="Lbl_EditStudentId" Text='<%# Eval("StudentID") %>' runat="server" />
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:Image ID="picone" ImageUrl="ImgHandler.ashx?imgid=1" CssClass="img-circle" runat="server"
                                                    Style="border: 3px solid WHITE; box-shadow: 3px 3px 5px gray;" Height="100px"
                                                    Width="100px" />
                                                <%--<asp:Image ID="picone" ImageUrl='<%# Eval("Picture") %>' runat="server" Width="200px"
                                                    Height="150px" />--%>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:FileUpload ID="pictureupload" runat="server" Style="background-color: #314B3C;
                                                    height: 30px;" />
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="pictureupload"
                                                    ErrorMessage="Only .jpg,.png,.jpeg Files are allowed" ValidationExpression="(.*?)\.(jpg|jpeg|png|JPG|JPEG|PNG)$"></asp:RegularExpressionValidator>
                                                <br />
                                                <span style="color: White; font-size: smaller;"><i>NOTE : Max Upload Image size allowed
                                                    is 300 Kb.</i></span>
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="*First Name">
                                            <ItemTemplate>
                                                <asp:Label ID="Lbl_FirstName" Text='<%# Eval("FirstName") %>' runat="server" />
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="Txt_EditFirstName" Text='<%# Eval("FirstName") %>' CssClass="form-control2 input-sm2"
                                                    runat="server" />
                                                <asp:RequiredFieldValidator ID="ReqEditFirstname" runat="server" ErrorMessage="Please Insert FirstName"
                                                    ValidationGroup="a" ControlToValidate="Txt_EditFirstName">*</asp:RequiredFieldValidator>
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Middle Name">
                                            <ItemTemplate>
                                                <asp:Label ID="Lbtl_Middlename" Text='<%# Eval("MiddleName") %>' runat="server" />
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="Txt_EditMiddleName" Text='<%# Eval("MiddleName") %>' CssClass="form-control2 input-sm2"
                                                    runat="server" />
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Last Name">
                                            <ItemTemplate>
                                                <asp:Label ID="Lbl_LastName" Text='<%# Eval("LastName") %>' runat="server" />
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="Txt_EditLastName" Text='<%# Eval("LastName") %>' CssClass="form-control2 input-sm2"
                                                    runat="server" />
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Address">
                                            <ItemTemplate>
                                                <asp:Label ID="Lbl_Address" Text='<%# Eval("Address") %>' runat="server" />
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="Txt_EditAddress" Text='<%# Eval("Address") %>' CssClass="form-control2 input-sm2"
                                                    TextMode="MultiLine" runat="server" Style="color: Black;" />
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Contact No">
                                            <ItemTemplate>
                                                <asp:Label ID="Lbl_ContactNo" Text='<%# Eval("ContactNo") %>' runat="server" />
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="Txt_EditContact" Text='<%# Eval("ContactNo") %>' CssClass="form-control2 input-sm2"
                                                    runat="server" />
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Mobile No">
                                            <ItemTemplate>
                                                <asp:Label ID="Lbl_MobileNo" Text='<%# Eval("MobileNo") %>' runat="server" />
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="Txt_EditMobile" Text='<%# Eval("MobileNo") %>' CssClass="form-control2 input-sm2"
                                                    runat="server" />
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="*Email ID">
                                            <ItemTemplate>
                                                <asp:Label ID="Lbl_EmailID" Text='<%# Eval("EmailID") %>' runat="server" />
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="Txt_EditEmail" Text='<%# Eval("EmailID") %>' CssClass="form-control2 input-sm2"
                                                    runat="server" />
                                                <asp:RequiredFieldValidator ID="ReqFieldEmailID" runat="server" ErrorMessage="Please Insert EmailID"
                                                    ValidationGroup="a" ControlToValidate="Txt_EditEmail">*</asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="revEmailID" runat="server" ErrorMessage="Please enter valid EmailID"
                                                    ToolTip="Please enter valid EmailID" Text="Invalid Email Address." ValidationGroup="a"
                                                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="Txt_EditEmail"></asp:RegularExpressionValidator>
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="*BirthDate">
                                            <ItemTemplate>
                                                <asp:Label ID="Lbl_Birthdate" Text='<%# Eval("DateOfBirth","{0:dd-MMM-yyyy}") %>'
                                                    runat="server" />
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="Txt_EditBirthdate" Width="150px" CssClass="form-control2 input-sm2"
                                                    Text='<%# Eval("DateOfBirth","{0:dd-MMM-yyyy}") %>' runat="server" />
                                                <asp:ImageButton ID="ibtnAddCalender" runat="server" ImageUrl="~/App_Themes/Responsive/web/Calender.png"
                                                    Width="20px" />
                                                <cc2:CalendarExtender ID="calExt" runat="server" TargetControlID="Txt_EditBirthdate"
                                                    PopupButtonID="ibtnAddCalender" Enabled="True" Format="dd-MMM-yyyy">
                                                </cc2:CalendarExtender>
                                                <asp:RequiredFieldValidator ID="ReqFieldBirthdate" runat="server" ErrorMessage="Please Birthdate"
                                                    ValidationGroup="a" ControlToValidate="Txt_EditBirthdate">*</asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="revDOB" runat="server" ControlToValidate="Txt_EditBirthdate"
                                                    ErrorMessage="Enter Date in dd-MMM-yyyy Format." ValidationGroup="a" ValidationExpression="^(([0-9])|([0-2][0-9])|([3][0-1]))\-(Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec)\-\d{4}$">*</asp:RegularExpressionValidator>
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Gender">
                                            <ItemTemplate>
                                                <asp:Label ID="Lbl_Gender" Text='<%# Eval("Gender") %>' runat="server" />
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:RadioButtonList ID="Rbtn_EditGender" runat="server">
                                                    <asp:ListItem Text="Male" />
                                                    <asp:ListItem Text="Female" />
                                                </asp:RadioButtonList>
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Blood Group">
                                            <ItemTemplate>
                                                <asp:Label ID="Lbl_BloodGroup" Text='<%# Eval("BloodGroup") %>' runat="server" />
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="Txt_EditBloodGroup" Text='<%# Eval("BloodGroup") %>' CssClass="form-control2 input-sm2"
                                                    runat="server" />
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="City">
                                            <ItemTemplate>
                                                <asp:Label ID="Lbl_City" Text='<%# Eval("City") %>' runat="server" />
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="Txt_EditSchoolCity" Text='<%# Eval("City") %>' CssClass="form-control2 input-sm2"
                                                    runat="server" />
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Zipcode">
                                            <ItemTemplate>
                                                <asp:Label ID="Lbl_Zipcode" Text='<%# Eval("Zipcode") %>' runat="server" />
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="Txt_EditSchoolZipcode" Text='<%# Eval("Zipcode") %>' CssClass="form-control2 input-sm2"
                                                    runat="server" />
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="State">
                                            <ItemTemplate>
                                                <asp:Label ID="Lbl_State" Text='<%# Eval("State") %>' runat="server" />
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="Txt_EditState" Text='<%# Eval("State") %>' CssClass="form-control2 input-sm2"
                                                    runat="server" />
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Country">
                                            <ItemTemplate>
                                                <asp:Label ID="Lbl_Country" Text='<%# Eval("Country") %>' runat="server" />
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="Txt_EditCountry" Text='<%# Eval("Country") %>' CssClass="form-control2 input-sm2"
                                                    runat="server" />
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                    </Fields>
                                </asp:DetailsView>
                            </div>
                            <hr />
                            <div class="text-center">
                                <a data-toggle="tab" class="btn btn-sm btn-success" style="background: #235E4A !important;"
                                    href="#tb_parentinfo">Next</a>
                            </div>
                        </div>
                        <div id="tb_parentinfo" class="tab-pane fade in">
                            <%-- Student's Parent/Guardian Information --%>
                            <div>
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <asp:DetailsView ID="Dvw_ParentGuardianDetails" runat="server" AutoGenerateRows="False"
                                            SkinID="ProfileDetails" OnItemUpdating="Dvw_ParentGuardianDetails_ItemUpdating"
                                            OnModeChanging="Dvw_ParentGuardianDetails_ModeChanging">
                                            <Fields>
                                                <asp:TemplateField HeaderText="Parent/Guardian Details" ItemStyle-HorizontalAlign="Right">
                                                    <ItemTemplate>
                                                        <span class="glyphicon glyphicon-edit"></span>
                                                        <asp:LinkButton ID="Lbtn_EditParentDetailsDetails" CommandName="Edit" Text="Edit"
                                                            runat="server" />
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <span class="glyphicon glyphicon-floppy-disk"></span>
                                                        <asp:LinkButton ID="Lbtn_SaveParentDetails" Text="Save" CommandName="Update" ValidationGroup="b"
                                                            runat="server" />
                                                        <span class="glyphicon glyphicon-floppy-remove"></span>
                                                        <asp:LinkButton ID="Lbtn_CancelParentDetails" Text="Cancel" CommandName="Cancel"
                                                            runat="server" />
                                                    </EditItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="StudentId" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Lbl_ParentStudentId" Text='<%# Eval("StudentID") %>' runat="server" />
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:Label ID="Lbl_EditParentStudentId" Text='<%# Eval("StudentID") %>' runat="server" />
                                                    </EditItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Father Name">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Lbl_FatherName" Text='<%# Eval("FatherName") %>' runat="server" />
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="Txt_EditFatherName" Text='<%# Eval("FatherName") %>' CssClass="form-control2 input-sm2"
                                                            runat="server" />
                                                    </EditItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Father Contact">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Lbl_FatherContact" Text='<%# Eval("FatherContact") %>' runat="server" />
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="Txt_EditFatherContact" Text='<%# Eval("FatherContact") %>' CssClass="form-control2 input-sm2"
                                                            runat="server" />
                                                    </EditItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Father Email">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Lbl_FatherEmail" Text='<%# Eval("FatherEmail") %>' runat="server" />
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="Txt_EditFatherEmail" Text='<%# Eval("FatherEmail") %>' CssClass="form-control2 input-sm2"
                                                            runat="server" />
                                                        <asp:RegularExpressionValidator ID="reqFatherEmailID" runat="server" ErrorMessage="Please enter valid EmailID"
                                                            ToolTip="Please enter valid EmailID" Text="Invalid Email Address" ValidationGroup="b"
                                                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="Txt_EditFatherEmail"></asp:RegularExpressionValidator>
                                                    </EditItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Mother Name">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Lbl_MotherName" Text='<%# Eval("MotherName") %>' runat="server" />
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="Txt_EditMotherName" Text='<%# Eval("MotherName") %>' CssClass="form-control2 input-sm2"
                                                            runat="server" />
                                                    </EditItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Mother Contact">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Lbl_MotherContact" Text='<%# Eval("MotherContact") %>' runat="server" />
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="Txt_EditMotherContact" Text='<%# Eval("MotherContact") %>' CssClass="form-control2 input-sm2"
                                                            runat="server" />
                                                    </EditItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Mother Email">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Lbl_MotherEmail" Text='<%# Eval("MotherEmail") %>' runat="server" />
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="Txt_EditMotherEmail" Text='<%# Eval("MotherEmail") %>' CssClass="form-control2 input-sm2"
                                                            runat="server" />
                                                        <asp:RegularExpressionValidator ID="reqMotherEmailID" runat="server" ErrorMessage="Please enter valid EmailID"
                                                            ToolTip="Please enter valid EmailID" Text="Invalid Email Address." ValidationGroup="b"
                                                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="Txt_EditMotherEmail"></asp:RegularExpressionValidator>
                                                    </EditItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Guardian Name">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Lbl_GuardianName" Text='<%# Eval("GuardianName") %>' runat="server" />
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="TxtEditGuardianName" Text='<%# Eval("GuardianName") %>' CssClass="form-control2 input-sm2"
                                                            runat="server" />
                                                    </EditItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Guardian Contact">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Lbl_GuardianContact" Text='<%# Eval("GuardianContact") %>' runat="server" />
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="Txt_EditGuardianContact" Text='<%# Eval("GuardianContact") %>' CssClass="form-control2 input-sm2"
                                                            runat="server" />
                                                    </EditItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Guardian Email">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Lbl_GuardianEmail" Text='<%# Eval("GuardianEmail") %>' runat="server" />
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="Txt_EditGuardianEmail" Text='<%# Eval("GuardianEmail") %>' CssClass="form-control2 input-sm2"
                                                            runat="server" />
                                                        <asp:RegularExpressionValidator ID="reqGuardianEmailID" runat="server" ErrorMessage="Please enter valid EmailID"
                                                            ToolTip="Please enter valid EmailID" Text="Invalid Email Address." ValidationGroup="b"
                                                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="Txt_EditGuardianEmail"></asp:RegularExpressionValidator>
                                                    </EditItemTemplate>
                                                </asp:TemplateField>
                                            </Fields>
                                        </asp:DetailsView>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <hr />
                            <div class="text-center">
                                <a data-toggle="tab" class="btn btn-sm btn-success" style="background: #235E4A !important;"
                                    href="#tb_eduinfo">Next</a> <a class="btn btn-sm btn-success" style="background: #235E4A !important;"
                                        data-toggle="tab" href="#tb_personalinfo">Back</a>
                            </div>
                        </div>
                        <div id="tb_eduinfo" class="tab-pane fade in">
                            <%-- Student's Educational Information --%>
                            <asp:Label ID="lblbms" Text="" runat="server" />
                            <div>
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                        <asp:DetailsView ID="Dvw_EducationalDetails" runat="server" AutoGenerateRows="False"
                                            SkinID="ProfileDetails" OnItemUpdating="Dvw_EducationalDetails_ItemUpdating"
                                            OnModeChanging="Dvw_EducationalDetails_ModeChanging">
                                            <Fields>
                                                <asp:TemplateField HeaderText="Educational Details" ItemStyle-HorizontalAlign="Right">
                                                    <ItemTemplate>
                                                        <span class="glyphicon glyphicon-edit"></span>
                                                        <asp:LinkButton ID="Lbtn_EditEducationalDetails" Text="Edit" CommandName="Edit" runat="server" />
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <span class="glyphicon glyphicon-floppy-disk"></span>
                                                        <asp:LinkButton ID="Lbtn_SaveEducationalDetails" Text="Save" ValidationGroup="c"
                                                            CommandName="Update" runat="server" />
                                                        <span class="glyphicon glyphicon-floppy-remove"></span>
                                                        <asp:LinkButton ID="Lbtn_CancelEducationalDetails" Text="Cancel" CommandName="Cancel"
                                                            runat="server" />
                                                    </EditItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="StudentId" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Lbl_EduStudentId" Text='<%# Eval("StudentID") %>' runat="server" />
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:Label ID="Lbl_EditEduStudentId" Text='<%# Eval("StudentID") %>' runat="server" />
                                                    </EditItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Board-Medium-Standard">
                                                    <ItemTemplate>
                                                        <%=AppSessions.BMS %>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <%=AppSessions.BMS %>
                                                    </EditItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="School Name">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Lbl_School" Text='<%# Eval("School") %>' runat="server" />
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="Txt_EditSchool" Text='<%# Eval("School") %>' CssClass="form-control2 input-sm2"
                                                            runat="server" />
                                                    </EditItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="School Contact">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Lbl_SchoolContact" Text='<%# Eval("SchoolContact") %>' runat="server" />
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="Txt_EditSchoolContact" Text='<%# Eval("SchoolContact") %>' CssClass="form-control2 input-sm2"
                                                            runat="server" />
                                                    </EditItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="School Email">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Lbl_SchoolEmail" Text='<%# Eval("SchoolEmail") %>' runat="server" />
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="Txt_EditSchoolEmail" Text='<%# Eval("SchoolEmail") %>' CssClass="form-control2 input-sm2"
                                                            runat="server" />
                                                        <asp:RegularExpressionValidator ID="reqSchoolEmailID" runat="server" ErrorMessage="Please enter valid EmailID"
                                                            ToolTip="Please enter valid EmailID" Text="Invalid Email Address." ValidationGroup="c"
                                                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="Txt_EditSchoolEmail"></asp:RegularExpressionValidator>
                                                    </EditItemTemplate>
                                                </asp:TemplateField>
                                            </Fields>
                                        </asp:DetailsView>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <hr />
                            <div class="text-center">
                                <a data-toggle="tab" class="btn btn-sm btn-success" style="background: #235E4A !important;"
                                    href="#tb_parentinfo">Back</a>
                            </div>
                        </div>
                    </div>
                </div>
                <div id="ChangePassword" class="tab-pane fade in">
                    <div>
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>
                                <h4>
                                    Change Password</h4>
                                <hr />
                                <div>
                                    <asp:TextBox ID="txtop" CssClass="form-control2 input-sm2" runat="server" TextMode="Password"
                                        placeholder="Old Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvop" ValidationGroup="cp" ControlToValidate="txtop"
                                        ForeColor="White" runat="server" ErrorMessage="*" Text="*"></asp:RequiredFieldValidator>

                                    <asp:TextBox ID="txtnp" CssClass="form-control2 input-sm2" runat="server" TextMode="Password"
                                        placeholder="New Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvnp" ValidationGroup="cp" ControlToValidate="txtnp"
                                        ForeColor="White" runat="server" ErrorMessage="*" Text="*"></asp:RequiredFieldValidator>
                                    <asp:TextBox ID="txtcp" CssClass="form-control2 input-sm2" runat="server" TextMode="Password"
                                        placeholder="Confirm Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvcp" ValidationGroup="cp" ControlToValidate="txtcp"
                                        ForeColor="White" runat="server" ErrorMessage="*" Text="*"></asp:RequiredFieldValidator>
                                    <asp:CompareValidator ID="cmpcp" runat="server" ControlToCompare="txtnp" ControlToValidate="txtcp"
                                        ForeColor="White" ErrorMessage="Password Mismatch" ValidationGroup="cp"></asp:CompareValidator>
                                    <asp:ValidationSummary ID="vscp" ShowMessageBox="false" ShowSummary="false" ValidationGroup="cp"
                                        runat="server" ForeColor="White" />
                                </div>
                                <div class="text">
                                    <asp:Button ID="btnChangesubmit" runat="server" Text="Change" ValidationGroup="cp"
                                        OnClick="btnChangesubmit_Click" CausesValidation="false" />
                                    &nbsp;&nbsp;
                                    <asp:Button ID="btnReset" runat="server" Text="Reset" OnClick="btnReset_Click" CausesValidation="false" />
                                </div>
                                <div>
                                    <asp:Label ID="lblmsg" runat="server" Visible="false"></asp:Label>
                                </div>
                                <%--  <h4>
                                    This Part is Under Construction.</h4>--%>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <%--<div id="Packages" class="tab-pane fade in">
                    This is Package details
                </div>--%>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        //This function is to simply make current page menu item active.
        $(document).ready(function () {
            $('.puerto-menu li .active').removeClass('active');
        });
    </script>
</asp:Content>
