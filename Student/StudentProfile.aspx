<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Epathshala.master" AutoEventWireup="true"
    CodeFile="StudentProfile.aspx.cs" Inherits="Student_StudentProfile" Culture="auto"
    UICulture="auto" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .kw ul, .kw ul li
        {
            list-style: outside none none;
            margin-bottom: 5px;
            text-align: right;
        }
        .kw ul, .kw ul li
        {
            list-style: outside none none;
            margin-bottom: 5px;
            text-align: right;
        }
        .navsa a
        {
            color: #f77408;
            font-size: 12px;
            text-decoration: underline;
            text-transform: capitalize;
        }
        .noborder
        {
            border: none;
        }
        input[type="file"]
        {
            display: block;
            height: auto;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row DBHeader">
        <div class="col-sm-6 NoPadding">
            <div class="DashboardHeading">
                You are here: <span style="color: White;">Profile</span>
            </div>
        </div>
        <div class="col-sm-6 NoPadding">
            <div class="DashboardHeading">
                <img src="../App_Themes/Green/Images/icon-calendar.png" />
                &nbsp;&nbsp;<i>Today:
                    <%=DateTime.Now.ToString("dd MMM yyyy / hh:mm tt")%>
                </i>
            </div>
        </div>
    </div>
    <ul class="tabs--primary nav nav-tabs navsa noborder">
        <li id="vw" runat="server"><a href="javascript:changepageview('View');">View</a></li>
        <li id="ed" runat="server"><a class="active" href="javascript:changepageview('Edit');">
            Edit</a></li>
    </ul>
    <div class="row" style="border-top: 1px solid #ddd; margin-top: -1px;">
        <div class="col-sm-12 NoPadding">
        </div>
    </div>
    <%-- <asp:UpdatePanel runat="server" UpdateMode="Always">
        <ContentTemplate>--%>
    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="1">
        <asp:View ID="View" runat="server">
            <div class="profile" style="padding: 15px;">
                <div style="margin-bottom: 10px; display: table;">
                    <asp:Image ID="picone" ImageUrl="ImgHandler.ashx?imgid=1" runat="server" Width="200px"
                        Height="150px" />
                </div>
                <div style="margin-bottom: 10px; display: table;">
                    <div class="field-label" style="color: #fff; float: left; font-weight: bold;">
                        BMS:&nbsp;</div>
                    <div class="field-items" style="float: left;">
                        <div class="field-item even" style="color: #fff;">
                            <asp:Label ID="vwbms" runat="server"></asp:Label></div>
                    </div>
                </div>
                <div style="margin-bottom: 10px; display: table;">
                    <div class="field-label" style="color: #fff; float: left; font-weight: bold;">
                        FirstName:&nbsp;</div>
                    <div class="field-items" style="float: left;">
                        <div class="field-item even" style="color: #fff;">
                            <asp:Label ID="vwfirstname" runat="server"></asp:Label></div>
                    </div>
                </div>
                <div style="margin-bottom: 10px; display: table;">
                    <div class="field-label" style="color: #fff; float: left; font-weight: bold;">
                        MiddleName:&nbsp;</div>
                    <div class="field-items" style="float: left;">
                        <div class="field-item even" style="color: #fff;">
                            <asp:Label ID="vwmiddlename" runat="server"></asp:Label></div>
                    </div>
                </div>
                <div style="margin-bottom: 10px; display: table;">
                    <div class="field-label" style="color: #fff; float: left; font-weight: bold;">
                        LastName:&nbsp;</div>
                    <div class="field-items" style="float: left;">
                        <div class="field-item even" style="color: #fff;">
                            <asp:Label ID="vwlastname" runat="server"></asp:Label></div>
                    </div>
                </div>
                <div style="margin-bottom: 10px; display: table;">
                    <div class="field-label" style="color: #fff; float: left; font-weight: bold;">
                        Gender:&nbsp;</div>
                    <div class="field-items" style="float: left;">
                        <div class="field-item even" style="color: #fff;">
                            <asp:Label ID="vwgender" runat="server"></asp:Label></div>
                    </div>
                </div>
                <div style="margin-bottom: 10px; display: table;">
                    <div class="field-label" style="color: #fff; float: left; font-weight: bold;">
                        Address:&nbsp;</div>
                    <div class="field-items" style="float: left;">
                        <div class="field-item even" style="color: #fff;">
                            <asp:Label ID="vwaddress" runat="server"></asp:Label></div>
                    </div>
                </div>
                <div style="margin-bottom: 10px; display: table;">
                    <div class="field-label" style="color: #fff; float: left; font-weight: bold;">
                        MobileNo:&nbsp;</div>
                    <div class="field-items" style="float: left;">
                        <div class="field-item even" style="color: #fff;">
                            <asp:Label ID="vwmobilenumber" runat="server"></asp:Label></div>
                    </div>
                </div>
                <div style="margin-bottom: 10px; display: table;">
                    <div class="field-label" style="color: #fff; float: left; font-weight: bold;">
                        ContactNo:&nbsp;</div>
                    <div class="field-items" style="float: left;">
                        <div class="field-item even" style="color: #fff;">
                            <asp:Label ID="vwcontactnumner" runat="server"></asp:Label></div>
                    </div>
                </div>
                <div style="margin-bottom: 10px; display: table;">
                    <div class="field-label" style="color: #fff; float: left; font-weight: bold;">
                        EmailID:&nbsp;</div>
                    <div class="field-items" style="float: left;">
                        <div class="field-item even" style="color: #fff;">
                            <asp:Label ID="vwemail" runat="server"></asp:Label></div>
                    </div>
                </div>
                <div style="margin-bottom: 10px; display: table;">
                    <div class="field-label" style="color: #fff; float: left; font-weight: bold;">
                        Date of Birth:&nbsp;</div>
                    <div class="field-items" style="float: left;">
                        <div class="field-item even" style="color: #fff;">
                            <asp:Label ID="vwdateofbirth" runat="server"></asp:Label></div>
                    </div>
                </div>
            </div>
        </asp:View>
        <asp:View ID="Edit" runat="server">
            <div class="row" style="margin-top: 15px;">
                <div class="hidden-xs col-md-3 col-lg-3">
                </div>
                <div class="col-xs-12 col-md-6 col-lg-6">
                    <div id="Div1" class="Activity" runat="server">
                        <div class="ActivityHeading">
                            <asp:Label ID="lblAddTitle" runat="server" Text="User Profile"></asp:Label>
                        </div>
                        <div class="Content">
                            <div style="text-align: right;">
                                <asp:Label ID="Label1" runat="server" CssClass="Label" Text="* Indicates required field."
                                    ForeColor="Red" Font-Size="8pt"></asp:Label>
                            </div>
                            <asp:Label ID="lblBMS" runat="server" Text="BMS" CssClass="Label"></asp:Label>
                            <div class="ddlControl">
                                <asp:DropDownList ID="ddlBMSAdd" runat="server" Enabled="False" class="ddlControl"
                                    SkinID="none">
                                    <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="ReqFieldBMSID" runat="server" InitialValue="0" ErrorMessage="Please Insert BMSID"
                                    ValidationGroup="a" ControlToValidate="ddlBMSAdd">*</asp:RequiredFieldValidator>
                            </div>
                            <asp:Label ID="lblFirstName" runat="server" Text="FirstName" CssClass="Label"></asp:Label>
                            <div>
                                <asp:TextBox ID="txtFirstName" runat="server" CssClass="controllabel"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ReqFieldFirstName" runat="server" ErrorMessage="Please Insert FirstName"
                                    ValidationGroup="a" ControlToValidate="txtFirstName">*</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revFirstName" runat="server" ErrorMessage="Only numbers and characters are allowed in FirstName"
                                    ToolTip="Only numbers and characters are allowed in FirstName" Text="." ValidationGroup="a"
                                    ValidationExpression="^[a-zA-Z0-9]+$" ControlToValidate="txtFirstName"></asp:RegularExpressionValidator>
                            </div>
                            <div>
                                <asp:Label ID="lblMiddleName" runat="server" Text="MiddleName" CssClass="Label"></asp:Label>
                                <asp:TextBox ID="txtMiddleName" runat="server" CssClass="controllabel"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ReqFieldMiddleName" runat="server" ErrorMessage="Please Insert MiddleName"
                                    ValidationGroup="a" ControlToValidate="txtMiddleName">*</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revMiddleName" runat="server" ErrorMessage="Only numbers and characters are allowed in MiddleName"
                                    ToolTip="Only numbers and characters are allowed in MiddleName" Text="." ValidationGroup="a"
                                    ValidationExpression="^[a-zA-Z0-9]+$" ControlToValidate="txtMiddleName"></asp:RegularExpressionValidator>
                            </div>
                            <div>
                                <asp:Label ID="lblLastName" runat="server" Text="LastName" CssClass="Label"></asp:Label>
                                <asp:TextBox ID="txtLastName" runat="server" CssClass="controllabel"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ReqFieldLastName" runat="server" ErrorMessage="Please Insert LastName"
                                    ValidationGroup="a" ControlToValidate="txtLastName">*</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revLastName" runat="server" ErrorMessage="Only numbers and characters are allowed in LastName"
                                    ToolTip="Only numbers and characters are allowed in LastName" Text="." ValidationGroup="a"
                                    ValidationExpression="^[a-zA-Z0-9]+$" ControlToValidate="txtLastName"></asp:RegularExpressionValidator>
                            </div>
                            <div>
                                <asp:Label ID="lblAddress" runat="server" CssClass="Label" Text="Address"></asp:Label>
                                <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine" CssClass="txtareaControl"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ReqAddress" runat="server" ErrorMessage="Address is required."
                                    ControlToValidate="txtAddress" ValidationGroup="a">*</asp:RequiredFieldValidator>
                            </div>
                            <div>
                                <asp:Label ID="lblpicture" runat="server" CssClass="Label" Text="Picture"></asp:Label>
                                <asp:FileUpload ID="pictureupload" runat="server" class="form-control form-file" />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="pictureupload"
                                    ErrorMessage="Only .jpg,.png,.jpeg Files are allowed" ValidationExpression="(.*?)\.(jpg|jpeg|png|JPG|JPEG|PNG)$"></asp:RegularExpressionValidator>
                            </div>
                            <div>
                                <asp:Label ID="lblMobileNo" runat="server" CssClass="Label" Text="MobileNo"></asp:Label>
                                <asp:TextBox ID="txtMobileNo" runat="server" CssClass="controllabel"></asp:TextBox>
                                <cc2:TextBoxWatermarkExtender ID="txtMobileNo_TextBoxWatermarkExtender" runat="server"
                                    Enabled="True" TargetControlID="txtMobileNo" WatermarkCssClass="watermark" WatermarkText="Ex: 9845689243">
                                </cc2:TextBoxWatermarkExtender>
                                <asp:RegularExpressionValidator ID="revMobileNo" runat="server" ErrorMessage="Only numbers and characters are allowed in MobileNo"
                                    ToolTip="Only numbers and characters are allowed in Mobile No" Text="." ValidationGroup="a"
                                    ValidationExpression="^[0-9]+$" ControlToValidate="txtMobileNo"></asp:RegularExpressionValidator>
                            </div>
                            <div>
                                <asp:Label ID="lblContactNo" CssClass="Label" runat="server" Text="ContactNo"></asp:Label>
                                <asp:TextBox ID="txtContactNo" runat="server" CssClass="controllabel"></asp:TextBox>
                                <cc2:TextBoxWatermarkExtender ID="txtContactNo_TextBoxWatermarkExtender" runat="server"
                                    Enabled="True" TargetControlID="txtContactNo" WatermarkCssClass="watermark" WatermarkText="Ex: 23254834">
                                </cc2:TextBoxWatermarkExtender>
                                <asp:RequiredFieldValidator ID="ReqFieldContactNo" runat="server" ErrorMessage="Contact no is required."
                                    ControlToValidate="txtContactNo" ValidationGroup="a">*</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revContactNo" runat="server" ErrorMessage="Only numbers are allowed in ContactNo"
                                    ToolTip="Only numbers are allowed in ContactNo" Text="." ValidationGroup="a"
                                    ValidationExpression="^[0-9]+$" ControlToValidate="txtContactNo"></asp:RegularExpressionValidator>
                            </div>
                            <div>
                                <asp:Label ID="lblEmailID" CssClass="Label" runat="server" Text="EmailID"></asp:Label>
                                <asp:TextBox ID="txtEmailID" runat="server" CssClass="controllabel"></asp:TextBox>
                                <cc2:TextBoxWatermarkExtender ID="txtEmailID_TextBoxWatermarkExtender" runat="server"
                                    Enabled="True" TargetControlID="txtEmailID" WatermarkCssClass="watermark" WatermarkText="Ex: abc@gmail.com">
                                </cc2:TextBoxWatermarkExtender>
                                <asp:RequiredFieldValidator ID="ReqFieldEmailID" runat="server" ErrorMessage="Please Insert EmailID"
                                    ValidationGroup="a" ControlToValidate="txtEmailID">*</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revEmailID" runat="server" ErrorMessage="Please enter valid EmailID"
                                    ToolTip="Please enter valid EmailID" Text="." ValidationGroup="a" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                    ControlToValidate="txtEmailID"></asp:RegularExpressionValidator>
                            </div>
                            <div>
                                <asp:Label ID="lblAddDob" runat="server" Text="Date of Birth" CssClass="Label"></asp:Label>
                                <div style="padding: 2px; background-color: #444; width: 20px; height: 20px; display: inline-block;
                                    margin-left: 4px; border-radius: 4px;">
                                    <asp:ImageButton ID="ibtnAddCalender" runat="server" ImageUrl="~/App_Themes/Responsive/web/Calender.png"
                                        Width="20px" />
                                </div>
                            </div>
                            <div>
                                <asp:TextBox ID="txtDateOfBirth" runat="server" CssClass="controllabel"></asp:TextBox>
                                <cc2:CalendarExtender ID="calExt" runat="server" TargetControlID="txtDateOfBirth"
                                    PopupButtonID="ibtnAddCalender" Enabled="True" Format="dd-MMM-yyyy">
                                </cc2:CalendarExtender>
                                <asp:RequiredFieldValidator ID="ReqFieldDateOfBirth" runat="server" ErrorMessage="Please Insert DateOfBirth"
                                    ValidationGroup="a" ControlToValidate="txtDateOfBirth">*</asp:RequiredFieldValidator>
                                &nbsp;<asp:RegularExpressionValidator ID="revDOB" runat="server" ControlToValidate="txtDateOfBirth"
                                    ErrorMessage="Enter Date in dd-MMM-yyyy Format." ValidationGroup="a" ValidationExpression="^(([0-9])|([0-2][0-9])|([3][0-1]))\-(Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec)\-\d{4}$">*</asp:RegularExpressionValidator>
                            </div>
                            <div>
                                <asp:Label ID="lblGender" CssClass="Label" runat="server" Text="Gender"></asp:Label>
                                <asp:RadioButtonList ID="rdbGenderList" runat="server" ValidationGroup="a" CssClass="inline-rb"
                                    RepeatDirection="Horizontal">
                                    <asp:ListItem Value="0" Text="Male"></asp:ListItem>
                                    <asp:ListItem Value="1" Text="Female"></asp:ListItem>
                                </asp:RadioButtonList>
                                <asp:RequiredFieldValidator ID="ReqFieldGender" runat="server" ErrorMessage="Please Insert Gender"
                                    ValidationGroup="a" ControlToValidate="rdbGenderList">*</asp:RequiredFieldValidator>
                            </div>
                            <div>
                                <asp:Button ID="btnSave" ValidationGroup="a" runat="server" Text="Update" AlternateText="Save"
                                    OnClick="btnSave_Click" />
                            </div>
                            <div>
                                <asp:ValidationSummary ID="ValSumStudent" runat="server" ValidationGroup="a" ShowMessageBox="True"
                                    ShowSummary="False" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="hidden-xs col-md-3 col-lg-3">
                </div>
            </div>
        </asp:View>
    </asp:MultiView>
    <asp:HiddenField ID="hdnstate" runat="server" Value="" />
    <asp:Button ID="btnchangeview" OnClick="btnchangeview_Click" Text="Change View" runat="server"
        Style="display: none;" />
    <%--  </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnSave" />
        </Triggers>
    </asp:UpdatePanel>--%>
    <table cellpadding="0" cellspacing="0" width="50%" class="RoundTop InnerTableStyle TableControl"
        style="display: none;">
        <tr>
            <td colspan="4" class="Header12 GridViewHeadercssTestAssessment RoundTop">
                <asp:Label ID="lblStReg" runat="server" Text="Student Profile"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center">
            </td>
        </tr>
    </table>
    <script type="text/javascript">
        function changepageview(mode) {
            switch (mode) {
                case "View":
                    document.getElementById('<%= hdnstate.ClientID %>').value = "View";
                    __doPostBack('<%= btnchangeview.UniqueID %>', '')
                    break;
                case "Edit":
                    document.getElementById('<%= hdnstate.ClientID %>').value = "Edit";
                    __doPostBack('<%= btnchangeview.UniqueID %>', '')
                    break;
                default: break;
            }
        }
    </script>
</asp:Content>
