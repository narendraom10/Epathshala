<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Registration.aspx.cs" Inherits="Registration"
    MasterPageFile="~/MasterPage/CommonHeaderFooter.master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <%--    <script src="../App_Themes/Green/CircularChart/js/jquery.circliful.min.js" type="text/javascript"></script>
    <link href="../App_Themes/GreenDashboard.css" rel="stylesheet" type="text/css" />--%>
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
            width: 100% !important;
        }
        .input-sm2
        {
            border-radius: 0 !important;
            font-size: 12px !important;
            height: 30px !important;
            line-height: 1.5 !important;
            padding: 5px 10px !important;
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
        select
        {
            color: #6D9B93 !important;
            font-weight: normal !important;
            font-style: normal;
            background: none !important;
            background-color: #314B3C !important;
            border: 1px solid #273D2F !important;
            font-size: 12px !important;
            text-shadow:none !important;
        }
        select:hover
        {
            font-weight: normal !important;
            color: #6D9B93 !important;
            background: none !important;
            background-color: #314B3C !important;
            border: 1px solid #273D2F !important;
        }
        .mypara
        {
            color: #bbc3c8 !important;
            font-family: 'Verdana' , sans-serif;
            font-size: 12px;
            line-height: 20px;
            text-indent: 30px;
            text-align: justify;
            margin: 0;
            text-indent: 0;
        }
    </style>
    <!-- jQuery if needed -->
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.2/jquery.min.js"></script>
    <%--<style type="text/css">
        .select1
        {
            /* Size and position */
            position: relative !important;
            width: 100% !important;
            margin: 0 auto !important;
            padding: 10px !important; /* Styles */
            background: #314B3C !important;
            border-radius: 0px !important;
            border: 1px solid rgba(0,0,0,0.15) !important;
            box-shadow: 0 1px 1px rgba(50,50,50,0.1) !important;
            cursor: pointer !important;
            font-weight:normal !important;
            color: #fff !important;
        }
        
        .select1 > option:after
        {
            font-weight:normal !important;
            content: "" !important;
            width: 0 !important;
            height: 0 !important;
            position: absolute !important;
            bottom: 100% !important;
            right: 15px !important;
            border-width: 0 6px 6px 6px !important;
            border-style: solid !important;
            border-color: #314B3C transparent !important;
        }
        .select1 > option:before
        {
            content: "" !important;
            width: 0 !important;
            height: 0 !important;
            position: absolute !important;
            bottom: 100% !important;
            right: 13px !important;
            border-width: 0 8px 8px 8px !important;
            border-style: solid !important;
            border-color: rgba(0,0,0,0.1) transparent !important;
        }
    </style>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>--%>
    <div class="row">
        <div class="col-sm-12">
            <div class="WoodenBorder">
                <div class="row">
                    <div class="col-sm-4">
                        <div class="GreenBoardHeading">
                            Student Registration
                        </div>
                        <div class="GreenBoard">
                            <div>
                                <asp:TextBox ID="txtFirstName" runat="server" placeholder="First Name" CssClass="form-control2 input-sm2"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ReqFieldFirstName" runat="server" ErrorMessage="Please enter First Name."
                                    ValidationGroup="a" ControlToValidate="txtFirstName">*</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revFirstName" runat="server" ErrorMessage="Only characters are allowed in First Name."
                                    ToolTip="Only characters are allowed in First Name." Text="." ValidationGroup="a"
                                    ValidationExpression="^[a-zA-Z ]+$" ControlToValidate="txtFirstName"></asp:RegularExpressionValidator>
                            </div>
                            <div>
                                <asp:TextBox ID="txtLastName" runat="server" placeholder="Last Name" CssClass="form-control2 input-sm2"></asp:TextBox>
                                <%--<asp:RequiredFieldValidator ID="ReqFieldLastName" runat="server" ErrorMessage="Please enter Last Name."
                                    ValidationGroup="a" ControlToValidate="txtLastName">*</asp:RequiredFieldValidator>--%>
                                <asp:RegularExpressionValidator ID="revLastName" runat="server" ErrorMessage="Only characters are allowed in Last Name."
                                    ToolTip="Only characters are allowed in Last Name." Text="." ValidationGroup="a"
                                    ValidationExpression="^[a-zA-Z ]+$" ControlToValidate="txtLastName"></asp:RegularExpressionValidator>
                            </div>
                            <div>
                                <asp:TextBox ID="txtContactNo" runat="server" placeholder="Contact Number" MaxLength="20" CssClass="form-control2 input-sm2"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ReqFieldContactNo" runat="server" ErrorMessage="Please enter Contact Number."
                                    ControlToValidate="txtContactNo" ValidationGroup="a">*</asp:RequiredFieldValidator>
                                <%--<asp:RegularExpressionValidator ID="revContactNo" runat="server" ErrorMessage="Please enter valid Contact Number."
                                    ToolTip="Please enter valid Contact Number." Text="." ValidationGroup="a" ValidationExpression="^[0-9]{6,10}"
                                    ControlToValidate="txtContactNo"></asp:RegularExpressionValidator>--%>
                            </div>
                            <div>
                                <asp:TextBox ID="txtEmail" runat="server" placeholder="Email For Communication \ LoginID"
                                    CssClass="form-control2 input-sm2"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ReqFieldEmailID" runat="server" ErrorMessage="Please enter EmailID."
                                    ValidationGroup="a" ControlToValidate="txtEmail">*</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revEmailID" runat="server" ErrorMessage="Please enter valid EmailID."
                                    ToolTip="Please enter valid EmailID." Text="." ValidationGroup="a" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                    ControlToValidate="txtEmail"></asp:RegularExpressionValidator>
                            </div>
                            <div>
                                <asp:TextBox ID="txtSchoolname" runat="server" placeholder="School Name" CssClass="form-control2 input-sm2"></asp:TextBox>
                                <%--<asp:RequiredFieldValidator ID="ReqFieldSchooname" runat="server" ErrorMessage="Please School Name."
                                    ValidationGroup="a" ControlToValidate="txtSchoolname">*</asp:RequiredFieldValidator>--%>
                                &nbsp;
                            </div>
                            <div>
                                <asp:DropDownList ID="ddlBoard" runat="server" Style="text-align: left; border-radius: 0px !important;
                                    width: 100%" AutoPostBack="True" OnSelectedIndexChanged="ddlBoard_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="ReqFieldBoard" runat="server" InitialValue="--Select Board--"
                                    ErrorMessage="Please Select Board." ValidationGroup="a" ControlToValidate="ddlBoard">*</asp:RequiredFieldValidator>
                            </div>
                            <div class="Control">
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlMedium" runat="server" class="dropdown btn btn-default dropdown-toggle"
                                            Style="text-align: left; width: 100%" AutoPostBack="True" Enabled="False" OnSelectedIndexChanged="ddlMedium_SelectedIndexChanged">
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
                            <div class="Control">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlStandard" runat="server" class="dropdown btn btn-default dropdown-toggle"
                                            Style="text-align: left; width: 100%; top: 0px; left: -1px;" AutoPostBack="True"
                                            Enabled="False" OnSelectedIndexChanged="ddlStandard_SelectedIndexChanged">
                                            <asp:ListItem Value="0" Text="Select Standard"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="ReqFieldStandard" runat="server" InitialValue="--Select Standard--"
                                            ErrorMessage="Please Select Standard." ValidationGroup="a" ControlToValidate="ddlStandard">*</asp:RequiredFieldValidator>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="ddlMedium" EventName="SelectedIndexChanged" />
                                    </Triggers>
                                </asp:UpdatePanel>
                                <%--<asp:DropDownList ID="ddlStandard" runat="server" Style="text-align: left; border-radius: 0px !important;
                                    width: 100%; top: 0px; left: -1px;" AutoPostBack="True" Enabled="False" OnSelectedIndexChanged="ddlStandard_SelectedIndexChanged">
                                    <asp:ListItem Value="0" Text="Select Standard"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="ReqFieldStandard" runat="server" InitialValue="--Select Standard--"
                                    ErrorMessage="Please Select Standard." ValidationGroup="a" ControlToValidate="ddlStandard">*</asp:RequiredFieldValidator>--%>
                            </div>
                            <%--<div>
                                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" placeholder="Password"
                                    Style="border: 1px solid #777777;"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ReqFieldPassword" runat="server" ErrorMessage="Please enter Password."
                                    ValidationGroup="a" ControlToValidate="txtPassword">*</asp:RequiredFieldValidator>
                            </div>
                            <div>
                                <asp:TextBox ID="txtconfirmpassword" runat="server" TextMode="Password" placeholder="Confirm Password"
                                    Style="border: 1px solid #777777;"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ReqFieldconfPassword" runat="server" ErrorMessage="Please enter Confirm Password."
                                    ValidationGroup="a" ControlToValidate="txtconfirmpassword">*</asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="cmpvldPassword" runat="server" ControlToCompare="txtPassword"
                                    ControlToValidate="txtconfirmpassword" Type="String" Operator="Equal" ValidationGroup="a"
                                    ErrorMessage="Password and Confirm password should be same.">*</asp:CompareValidator>
                            </div>
                            <div style="padding-bottom: 10px;">
                                <asp:RadioButtonList ID="RlstGender" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="1" Text="Male" Selected="True"></asp:ListItem>
                                    <asp:ListItem Value="2" Text="Female"></asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                            <div>
                                <asp:TextBox ID="txtBirthdate" runat="server" placeholder="Birthdate (DD-MM-YYYY)"
                                    CssClass="disable_future_dates" Style="border: 1px solid #777777;"></asp:TextBox>
                                <asp:ImageButton ID="ibtnDate" runat="server" ImageUrl="~/App_Themes/Responsive/web/Calender.png"
                                    Width="30px" Style="padding-left: 5px; padding-top: 10px;" />
                                <asp:RequiredFieldValidator ID="ReqFieldBirthDate" runat="server" ErrorMessage="Please select Birthdate."
                                    ValidationGroup="a" ControlToValidate="txtBirthdate">*</asp:RequiredFieldValidator>
                                <cc1:CalendarExtender ID="calExeBirthDate" runat="server" TargetControlID="txtBirthdate"
                                    PopupButtonID="ibtnDate" Format="dd-MM-yyyy">
                                </cc1:CalendarExtender>
                            </div>--%>
                            <div class="Control" style="visibility: hidden;">
                                <asp:DropDownList ID="ddlBMS" runat="server" class="dropdown btn btn-default dropdown-toggle"
                                    Style="text-align: left; width: 100%">
                                    <asp:ListItem Value="0" Text="<SELECT>"></asp:ListItem>
                                </asp:DropDownList>
                                <%--<asp:RequiredFieldValidator ID="ReqFieldBMSID" runat="server" InitialValue="0" ErrorMessage="Please Select BMS."
                                    ValidationGroup="a" ControlToValidate="ddlBMS">*</asp:RequiredFieldValidator>--%>
                            </div>
                            <div style="padding-top: 30px; text-align: center; padding-left: 0px;">
                                <asp:Button ID="btnSubmit" runat="server" CssClass="go" Text="Register" ValidationGroup="a"
                                    OnClick="btnSubmit_Click" EnableTheming="false" />
                                <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" EnableTheming="false" Visible=false />
                                <asp:ValidationSummary ID="ValSumStudent" runat="server" ValidationGroup="a" ShowMessageBox="True"
                                    ShowSummary="False" meta:resourcekey="ValSumStudentResource1" />
                            </div>
                            <br />
                        </div>
                    </div>
                    <div class="col-sm-8">
                        <div class="GreenBoardHeading">
                            Why one should register for ePathshala?
                        </div>
                        <div class="GreenBoard">
                            <p class="mypara">
                                <span lang="EN-US"><b style="color: #FFFFFF;">ePathshala</b> is the innovative solution
                                    of ePath Arraycom, to make learning simple, easy, interesting and user friendly
                                    with the ultimate goal to empower the children in the process of positive development.
                                    It opens up new horizon of experiential learning for the children. The heart & soul
                                    of any digital school is curriculum based digital content and ePathshala is the
                                    result of experience of the experts of the subjects who have developed content by
                                    using modern technology like Internet for making topic informative, by taking help
                                    of animated pictures(2D/3D animations) graphics etc. ePathshala is child centric
                                    offering an opportunity to revisit previous concepts effortlessly. Every interactive
                                    lesson is articulated in a simple language breaking the complex theory into an uncomplicated
                                    learning process. Each concept is designed with a blend of local requirements and
                                    global standards.
                                    <br />
                                    <br />
                                    <b style="color: #FFFFFF;">ePathshala</b> is Diagnostic, Remedial and Developmental
                                    online school. It Provides Preventive, Curative and Progressive learning measures.
                                    <br />
                                    <br />
                                    In order to use online services, you must obtain access to the World Wide Web, either
                                    directly or through devices that access web-based content, and pay service fees
                                    associated with such access. In addition, you will need to have access to all equipment
                                    necessary to make such a connection to the World Wide Web, including a computer
                                    and modem or other access devices.
                                    <br />
                                    <br />
                                    <b style="color: #FFFFFF;">ePathshala</b> offers K-12 solution and the content is
                                    developed on the basis of syllabus which can take care of various state education
                                    boards like CBSE (English, Hindi), UP, Gujarat etc.
                                    <br />
                                    <br />
                                    <b style="color: #FFFFFF;">ePathshala</b> consists of data bank of questions for
                                    assessment of children and it offers facilities like Pre Test, Multiple Choice Questions,
                                    worksheets (Practice Sheets), Post Test for each subject and chapter.
                                    <br />
                                    <br />
                                    <b style="color: #FFFFFF;">For more information or for any query please contact
                                    </b><a href="mailto:info@epath.net.in"><span>info@epath.net.in</span></a> </span>
                            </p>
                            <br />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        //This function is to simply make current page menu item active.
        $(document).ready(function () {
            $('.puerto-menu li .active').removeClass('active');
            $('.puerto-menu li:nth-child(5) a').addClass('active');
        });
    </script>

</asp:Content>
