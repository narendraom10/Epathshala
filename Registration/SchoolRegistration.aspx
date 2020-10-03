<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Epathshala.master" AutoEventWireup="true"
    CodeFile="SchoolRegistration.aspx.cs" Inherits="Registration_SchoolRegistration"
    Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">


    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        function validateTime(sender, args) {
            debugger;
            var startTimeAMPM = parseInt($("[id*=ddlStartTime]").val());
            var endTimeAMPM = parseInt($("[id*=ddlEndTime]").val());
            if (startTimeAMPM != endTimeAMPM) {
                args.IsValid = startTimeAMPM < endTimeAMPM;
                return;
            }
            var starthour = $("[id*=txtStartTimeHH]").val();
            var startminute = $("[id*=txtStartTimeMM]").val();
            var endhour = $("[id*=txtEndTimeHH]").val();
            var endminute = $("[id*=txtEndTimeMM]").val();

            var startHour = parseInt(starthour.substring(0, 2));
            var startMin = parseInt(startminute.substring(4));

            var endHour = parseInt(endhour.substring(0, 2));
            var endMin = parseInt(endminute.substring(4));

            if ((startHour == endHour && startMin == endMin)
                 || (startHour >= endHour)) {
                args.IsValid = false;
                return;
            }
            args.IsValid = true;
        }
    </script>
    <table cellpadding="0" cellspacing="0" class="RoundTop InnerTableStyle TableControl"
        width="90%">
        <tr>
            <td class="Header12 GridViewHeadercssTestAssessment RoundTop">
                <asp:Label ID="lblSchoolRegistation" runat="server" Text="School Registration" meta:resourcekey="lblSchoolRegistationResource1"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="padding: 5px;">
                <fieldset id="fsSchoolGeneralInfo" runat="server" visible="true">
                    <legend>
                        <asp:Label ID="lblGenInfoTitle" CssClass="SubTitle" runat="server" Text="General Information"
                            meta:resourcekey="lblGenInfoTitleResource1"></asp:Label>
                    </legend>
                    <table id="tblSchoolGeneralInfo" runat="server" class="tblControl1">
                        <%--<thead>
                            <tr>
                                <td colspan="6" class="Header">
                                    <asp:Label runat="server" Text="School Registration"></asp:Label>
                                </td>
                            </tr>
                        </thead>--%>
                        <tr>
                            <td class="Required">
                                <asp:Label ID="lblSchName" runat="server" Text="School Name:" meta:resourcekey="lblSchNameResource1"></asp:Label>
                            </td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtSchName" runat="server" meta:resourcekey="txtSchNameResource1"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rqdSchoolName" runat="server" Text="." ControlToValidate="txtSchName"
                                    ErrorMessage="School name is required" ToolTip="School name is required" ValidationGroup="SchoolGeneralInfo"
                                    meta:resourcekey="rqdSchoolNameResource1"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td class="Required">
                                <asp:Label ID="lblSchAddress" runat="server" Text="School Address:" meta:resourcekey="lblSchAddressResource1"></asp:Label>
                            </td>
                            <td style="text-align: left;" colspan="3">
                                <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine" Rows="3" CssClass="multiline2"
                                    meta:resourcekey="txtAddressResource1"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rqdSchoolAddress" runat="server" Text="." ControlToValidate="txtAddress"
                                    ErrorMessage="School address is required" ToolTip="School address is required"
                                    ValidationGroup="SchoolGeneralInfo" meta:resourcekey="rqdSchoolAddressResource1"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblPloatNo" runat="server" Text="Plot number:" meta:resourcekey="lblPloatNoResource1"></asp:Label>
                            </td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtPloatNo" runat="server" meta:resourcekey="txtPloatNoResource1"></asp:TextBox>
                                <cc1:TextBoxWatermarkExtender ID="txtBoxWatermarkExtenderTxtPloatNo" runat="server"
                                    Enabled="True" TargetControlID="txtPloatNo" WatermarkCssClass="watermark" WatermarkText="Ex: 43/44">
                                </cc1:TextBoxWatermarkExtender>
                                <br />
                            </td>
                            <td>
                                <asp:Label ID="lblBlockNoSurvey" runat="server" Text="Block No/Survey no:" meta:resourcekey="lblBlockNoSurveyResource1"></asp:Label>
                            </td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtBlockNoSurvey" runat="server" meta:resourcekey="txtBlockNoSurveyResource1"></asp:TextBox>
                                <cc1:TextBoxWatermarkExtender ID="txtBoxWatermarkExtenderTxtBlockNoSurvey" runat="server"
                                    Enabled="True" TargetControlID="txtBlockNoSurvey" WatermarkCssClass="watermark"
                                    WatermarkText="Ex: 43/44">
                                </cc1:TextBoxWatermarkExtender>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblCountry" runat="server" Text="Country:" meta:resourcekey="lblCountryResource1"></asp:Label>
                            </td>
                            <td style="text-align: left;">
                                <asp:DropDownList ID="ddlCountry" runat="server" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged"
                                    AutoPostBack="True" meta:resourcekey="ddlCountryResource1">
                                    <asp:ListItem Value="0" meta:resourcekey="ListItemResource1">Select Country</asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator InitialValue="0" ID="rqdCountry" runat="server" Text="."
                                    ControlToValidate="ddlCountry" ErrorMessage="Country is required" ToolTip="Country is required"
                                    ValidationGroup="SchoolGeneralInfo" meta:resourcekey="rqdCountryResource1"></asp:RequiredFieldValidator>
                            </td>
                            <td class="Required">
                                <asp:Label ID="lblState" runat="server" Text="State:" meta:resourcekey="lblStateResource1"></asp:Label>
                            </td>
                            <td style="text-align: left;">
                                <asp:DropDownList ID="ddlState" runat="server" OnSelectedIndexChanged="ddlState_SelectedIndexChanged"
                                    AutoPostBack="True" Enabled="False" meta:resourcekey="ddlStateResource1">
                                    <asp:ListItem meta:resourcekey="ListItemResource2">Select State</asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator InitialValue="0" ID="rqdState" runat="server" Text="."
                                    ControlToValidate="ddlState" ErrorMessage="State is required" ToolTip="State is required"
                                    ValidationGroup="SchoolGeneralInfo" meta:resourcekey="rqdStateResource1"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="Required">
                                <asp:Label ID="lblDistrict" runat="server" Text="District:" meta:resourcekey="lblDistrictResource1"></asp:Label>
                            </td>
                            <td style="text-align: left;">
                                <asp:DropDownList ID="ddlDistrict" runat="server" AutoPostBack="True" Enabled="False"
                                    meta:resourcekey="ddlDistrictResource1">
                                    <asp:ListItem meta:resourcekey="ListItemResource3">Select District</asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator InitialValue="0" ID="rqdDistrict" runat="server" Text="."
                                    ControlToValidate="ddlDistrict" ErrorMessage="District is required" ToolTip="District is required"
                                    ValidationGroup="SchoolGeneralInfo" meta:resourcekey="rqdDistrictResource1"></asp:RequiredFieldValidator>
                            </td>
                            <td class="Required">
                                <asp:Label ID="lblCity" runat="server" Text="City/Village:" meta:resourcekey="lblCityResource1"></asp:Label>
                            </td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtCity" runat="server" meta:resourcekey="txtCityResource1"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rqdCity" runat="server" Text="." ControlToValidate="txtCity"
                                    ErrorMessage="City is required" ToolTip="City is required" ValidationGroup="SchoolGeneralInfo"
                                    meta:resourcekey="rqdCityResource1"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="Required">
                                <asp:Label ID="lblPincode" runat="server" Text="Pincode:" meta:resourcekey="lblPincodeResource1"></asp:Label>
                            </td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtPincode" runat="server" MaxLength="6" meta:resourcekey="txtPincodeResource1"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rqdPincode" runat="server" Text="." ControlToValidate="txtPincode"
                                    ErrorMessage="Pincode is required" ToolTip="Pincode is required" ValidationGroup="SchoolGeneralInfo"
                                    meta:resourcekey="rqdPincodeResource1"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revPincode" runat="server" ErrorMessage="Enter 6 digits in in pincode"
                                    ToolTip="Enter 6 digits in in pincode" Text="." ValidationGroup="SchoolGeneralInfo"
                                    ControlToValidate="txtPincode" ValidationExpression="\d{6}" meta:resourcekey="revPincodeResource1"></asp:RegularExpressionValidator>
                                <asp:RegularExpressionValidator ID="revPin" ControlToValidate="txtPincode" ValidationExpression="^[0-9]+$"
                                    Text="." ValidationGroup="SchoolGeneralInfo" runat="server" ErrorMessage="Only number are allowed in pincode"
                                    ToolTip="Only numbers are allowed in pincode" meta:resourcekey="revPinResource1"></asp:RegularExpressionValidator>
                            </td>
                           <%-- <td class="Required">
                                <asp:Label ID="lblPincodeperm" runat="server" Text="Pincode:" meta:resourcekey="lblPincodeResource1"></asp:Label>
                            </td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtPincodeperm" runat="server" MaxLength="6" meta:resourcekey="txtPincodeResource1"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rqdPincodeperm" runat="server" Text="." ControlToValidate="txtPincodeperm"
                                    ErrorMessage="Pincode is required" ToolTip="Pincode is required" ValidationGroup="SchoolGeneralInfo"
                                    meta:resourcekey="rqdPincodeResource1"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revPincodeperm" runat="server" ErrorMessage="Enter 6 digits in in pincode"
                                    ToolTip="Enter 6 digits in in pincode" Text="." ValidationGroup="SchoolGeneralInfo"
                                    ControlToValidate="txtPincodeperm" ValidationExpression="\d{6}" meta:resourcekey="revPincodeResource1"></asp:RegularExpressionValidator>
                                <asp:RegularExpressionValidator ID="revPinperm" ControlToValidate="txtPincodeperm"
                                    ValidationExpression="^[0-9]+$" Text="." ValidationGroup="SchoolGeneralInfo"
                                    runat="server" ErrorMessage="Only number are allowed in pincode" ToolTip="Only numbers are allowed in pincode"
                                    meta:resourcekey="revPinResource1"></asp:RegularExpressionValidator>
                            </td>--%>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblLandline" CssClass="LblTitleField" runat="server" Text="Landline No:"
                                    meta:resourcekey="lblLandlineResource1"></asp:Label>
                            </td>
                            <td class="ValueCell" style="text-align: left;">
                                <asp:TextBox ID="txtLandline" runat="server" MaxLength="11" meta:resourcekey="txtLandlineResource1"></asp:TextBox>
                                <cc1:TextBoxWatermarkExtender ID="txtLandline_TextBoxWatermarkExtender" runat="server"
                                    Enabled="True" TargetControlID="txtLandline" WatermarkCssClass="watermark" WatermarkText="With STD Code">
                                </cc1:TextBoxWatermarkExtender>
                                <asp:RegularExpressionValidator ID="revLandLine" runat="server" ErrorMessage="Only numbers and characters are allowed in Landline No"
                                    ToolTip="Only numbers are allowed in Landline No" Text="." ValidationGroup="SchoolGeneralInfo"
                                    ValidationExpression="^[0-9]+$" ControlToValidate="txtLandline" meta:resourcekey="revLandLineResource1"></asp:RegularExpressionValidator>
                            </td>
                            <td>
                                <asp:Label ID="lblFaxNo" runat="server" Text="FAX No:" meta:resourcekey="lblFaxNoResource1"></asp:Label>
                            </td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtFaxNo" runat="server" MaxLength="11" meta:resourcekey="txtFaxNoResource1"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblMobileNo" runat="server" Text="Mobile No:" meta:resourcekey="lblMobileNoResource1"></asp:Label>
                            </td>
                            <td class="ValueCell" style="text-align: left;">
                                <asp:TextBox ID="txtMobileNo" runat="server" MaxLength="11" meta:resourcekey="txtMobileNoResource1"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="revMobileNo" runat="server" ErrorMessage="Only numbers and characters are allowed in Mobile No"
                                    ToolTip="Only numbers and characters are allowed in Mobile No" Text="." ValidationGroup="SchoolGeneralInfo"
                                    ValidationExpression="^[0-9]+$" ControlToValidate="txtMobileNo" meta:resourcekey="revMobileNoResource1"></asp:RegularExpressionValidator>
                            </td>
                            <td>
                                <asp:Label ID="lblSchoolStartYear" CssClass="LblTitleField" runat="server" Text="School start year:"
                                    meta:resourcekey="lblSchoolStartYearResource1"></asp:Label>
                            </td>
                            <td class="ValueCell" style="text-align: left;">
                                <asp:TextBox ID="txtSchoolStartyear" runat="server" MaxLength="4" meta:resourcekey="txtSchoolStartyearResource1"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="Required">
                                <asp:Label ID="lblSchlMailID" runat="server" Text="School E-mail ID:" meta:resourcekey="lblSchlMailIDResource1"></asp:Label>
                            </td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtSchlMailID" runat="server" meta:resourcekey="txtSchlMailIDResource1"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rqdSchoolEmailID" runat="server" Text="." ControlToValidate="txtSchlMailID"
                                    ErrorMessage="School E-mail ID is required" ToolTip="School E-mail ID is required"
                                    ValidationGroup="SchoolGeneralInfo" meta:resourcekey="rqdSchoolEmailIDResource1"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revSchoolEmailID" runat="server" ErrorMessage="Please enter valid school email id"
                                    ToolTip="Please enter valid school email id" Text="." ValidationGroup="SchoolGeneralInfo"
                                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtSchlMailID"
                                    meta:resourcekey="revSchoolEmailIDResource1"></asp:RegularExpressionValidator>
                            </td>
                            <td>
                                <asp:Label ID="lblSchlWebsite" CssClass="LblTitleField" runat="server" Text="School Website URL:"
                                    meta:resourcekey="lblSchlWebsiteResource1"></asp:Label>
                            </td>
                            <td class="ValueCell" style="text-align: left;">
                                <asp:TextBox ID="txtSchlWebsite" runat="server" meta:resourcekey="txtSchlWebsiteResource1"></asp:TextBox>
                                <cc1:TextBoxWatermarkExtender ID="txtBoxWatermarkExtenderTxtSchlWebsite" runat="server"
                                    Enabled="True" TargetControlID="txtSchlWebsite" WatermarkCssClass="watermark"
                                    WatermarkText="Ex: (http://yoururl.com)">
                                </cc1:TextBoxWatermarkExtender>
                                <asp:RegularExpressionValidator ID="revSchoolWebsite" runat="server" ErrorMessage="Please enter valid school website"
                                    Text="." ValidationGroup="SchoolGeneralInfo" ToolTip="Please enter valid school website"
                                    ValidationExpression="http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&amp;=]*)?" ControlToValidate="txtSchlWebsite"
                                    meta:resourcekey="revSchoolWebsiteResource1"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <asp:Button ID="btnNext" runat="server" Text="Next" OnClick="btnNext_Click" ValidationGroup="SchoolGeneralInfo"
                                    meta:resourcekey="btnNextResource1" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
                <fieldset id="fsSchoolInfo" runat="server" visible="false">
                    <legend>
                        <asp:Label ID="lblSchlLocInfo" runat="server" CssClass="SubTitle" Text="School Information"
                            meta:resourcekey="lblSchlLocInfoResource1"></asp:Label>
                    </legend>
                    <table class="tblControl1">
                        <tr>
                            <td>
                            </td>
                            <td class="Required">
                                <asp:Label ID="lblSchlType" runat="server" CssClass="LblTitleField" Text="School Type:"
                                    meta:resourcekey="lblSchlTypeResource1"></asp:Label>
                            </td>
                            <td class="ValueCell" style="text-align: left;">
                                <asp:DropDownList ID="ddlSchlType" runat="server" AutoPostBack="True" meta:resourcekey="ddlSchlTypeResource1">
                                    <asp:ListItem Value="0" Text="-- Select --" meta:resourcekey="ListItemResource4"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rqdSchoolType" InitialValue="0" runat="server" Text="."
                                    ControlToValidate="ddlSchlType" ErrorMessage="School type is required" ToolTip="School type is required"
                                    ValidationGroup="SchoolInfo" meta:resourcekey="rqdSchoolTypeResource1"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td class="Required">
                                <asp:Label ID="lblBoard" runat="server" CssClass="LblTitleField" Text="Board:" meta:resourcekey="lblBoardResource1"></asp:Label>
                            </td>
                            <td class="ValueCell" style="text-align: left;">
                                <asp:DropDownList ID="ddlBoard" runat="server" OnSelectedIndexChanged="ddlBoard_SelectedIndexChanged"
                                    AutoPostBack="True" meta:resourcekey="ddlBoardResource1">
                                    <asp:ListItem Text="-- Select --" Value="0" meta:resourcekey="ListItemResource5"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rqdBoard" InitialValue="0" runat="server" Text="."
                                    ControlToValidate="ddlBoard" ErrorMessage="Board is required" ToolTip="Board is required"
                                    ValidationGroup="SchoolInfo" meta:resourcekey="rqdBoardResource1"></asp:RequiredFieldValidator>
                            </td>
                            <td class="Required">
                                <asp:Label ID="lblMedium" runat="server" CssClass="LblTitleField" Text="Medium:"
                                    meta:resourcekey="lblMediumResource1"></asp:Label>
                            </td>
                            <td class="ValueCell" style="text-align: left;">
                                <asp:DropDownList ID="ddlMedium" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlMedium_SelectedIndexChanged"
                                    meta:resourcekey="ddlMediumResource1">
                                    <asp:ListItem Text="-- Select --" Value="0" meta:resourcekey="ListItemResource6"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rqdMedium" InitialValue="0" runat="server" Text="."
                                    ControlToValidate="ddlMedium" ErrorMessage="Medium is required" ToolTip="Medium is required"
                                    ValidationGroup="SchoolInfo" meta:resourcekey="rqdMediumResource1"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td class="Required">
                                <asp:Label ID="lblStandard" runat="server" CssClass="LblTitleField" Text="Standard:"
                                    meta:resourcekey="lblStandardResource1"></asp:Label>
                            </td>
                            <td class="ValueCell">
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td colspan="4">
                                <asp:CheckBoxList ID="clstStandardList" runat="server" RepeatDirection="Horizontal"
                                    CssClass="chkChoice" meta:resourcekey="clstStandardListResource1">
                                </asp:CheckBoxList>
                                <%--<asp:GridView ID="GvStandards" runat="server" AutoGenerateColumns="False" DataKeyNames="Standard"
                                    AllowPaging="True" OnPageIndexChanging="GvStandards_PageIndexChanging">
                                    <Columns>
                                        <asp:BoundField DataField="StandardID" HeaderText="StandardID" Visible="true" />
                                        <asp:TemplateField HeaderText="Select ">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="ChkStandard" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Standard" HeaderText="Standards" />
                                        <asp:TemplateField HeaderText="No Of students ">
                                            <ItemTemplate>
                                                <asp:TextBox ID="TxtStudents" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>--%>
                                <asp:DataList ID="dlStandard" runat="server" RepeatColumns="2" BackColor="White"
                                    BorderStyle="None" BorderWidth="0px" CellSpacing="3" RepeatDirection="Horizontal"
                                    Height="100%" Width="100%" HorizontalAlign="Center" CellPadding="3" meta:resourcekey="dlStandardResource1">
                                    <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                                    <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                                    <SelectedItemStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                                    <ItemTemplate>
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblStdId" runat="server" Text='<%# Eval("StandardID") %>' Visible="False"
                                                        meta:resourcekey="lblStdIdResource1"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:CheckBox ID="chkStandard" runat="server" meta:resourcekey="chkStandardResource1" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblStandard" runat="server" Width="180px" Text='<%# Eval("Standard") %>'
                                                        meta:resourcekey="lblResource1"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtSemister" runat="server" Width="40px" meta:resourcekey="txtSemisterResource1" Visible="false"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:DataList>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <%--  <tr>
                            <td  >
                                
                            </td>
                            <td   colspan="2">
                                <span class="Required">*</span>
                                <asp:Label ID="LblNoStudent" runat="server" CssClass="LblTitleField" Text="Total Number of student :"></asp:Label>
                                <br />
                                <asp:Label ID="lblComNoStudent" runat="server" CssClass="LblTitleField" Text="(Total student in Selected all standard)"></asp:Label>
                            </td>
                            <td class="ValueCell" colspan="2">
                                <asp:TextBox ID="TxtNoOfStudent"   runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RfvNoOfStudent" runat="server" Text="." ControlToValidate="TxtNoOfStudent"
                                    ErrorMessage="Total Number of student is required" ToolTip="Total Number of student is required"
                                    ValidationGroup="SchoolInfo"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RexNoOfStudent" runat="server" ErrorMessage="Only numbers are allowed in Total Number of student"
                                    ToolTip="Only numbers are allowed in Total Number of student" Text="." ValidationGroup="SchoolInfo"
                                    ValidationExpression="^[0-9]+$" ControlToValidate="TxtNoOfStudent"></asp:RegularExpressionValidator>
                            </td>
                            <td>
                            </td>
                        </tr>--%>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:Label ID="lblStartTime" runat="server" CssClass="LblTitleField" Text="Start Time:"
                                    meta:resourcekey="lblStartTimeResource1"></asp:Label>
                            </td>
                            <td class="ValueCell" style="text-align: left;">
                                <asp:TextBox ID="txtStartTimeHH" runat="server" Width="40px" MaxLength="2" meta:resourcekey="txtStartTimeHHResource1"></asp:TextBox>:<asp:TextBox
                                    ID="txtStartTimeMM" MaxLength="2" runat="server" Width="40px" meta:resourcekey="txtStartTimeMMResource1"></asp:TextBox>
                                <asp:DropDownList runat="server" ID="ddlStartTime" Width="50px">
                                    <asp:ListItem Text="AM" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="PM" Value="1"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rqdStartTimeHH" runat="server" ErrorMessage="Please enter hours in start time."
                                    ControlToValidate="txtStartTimeHH" Text="." ValidationGroup="SchoolInfo" meta:resourcekey="rqdStartTimeHHResource1"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revStartTimeHH" runat="server" ValidationExpression="^[0-9]+$"
                                    ErrorMessage="Only number are allowed in start time." ControlToValidate="txtStartTimeHH"
                                    Text="." ValidationGroup="SchoolInfo" meta:resourcekey="revStartTimeHHResource1"></asp:RegularExpressionValidator>
                                <asp:RequiredFieldValidator ID="rqdStartTimeMM" runat="server" ErrorMessage="Only number are allowed in start time."
                                    ControlToValidate="txtStartTimeMM" Text="." ValidationGroup="SchoolInfo" meta:resourcekey="rqdStartTimeMMResource1"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revStartTimeMM" runat="server" ErrorMessage="Please enter minutes in start time."
                                    ControlToValidate="txtStartTimeMM" Text="." ValidationGroup="SchoolInfo" ValidationExpression="^[0-9]+$"
                                    meta:resourcekey="revStartTimeMMResource1"></asp:RegularExpressionValidator>
                            </td>
                            <td>
                                <asp:Label ID="lblEndTime" runat="server" CssClass="LblTitleField" Text="End Time:"
                                    meta:resourcekey="lblEndTimeResource1"></asp:Label>
                            </td>
                            <td class="ValueCell" style="text-align: left;">
                                <asp:TextBox ID="txtEndTimeHH" runat="server" Width="40px" MaxLength="2" meta:resourcekey="txtEndTimeHHResource1"></asp:TextBox>:<asp:TextBox
                                    ID="txtEndTimeMM" MaxLength="2" runat="server" Width="40px" meta:resourcekey="txtEndTimeMMResource1"></asp:TextBox>
                                <asp:DropDownList runat="server" ID="ddlEndTime" Width="50px">
                                    <asp:ListItem Text="AM" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="PM" Value="1"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rqdEndTimeHH" runat="server" ErrorMessage="Please enter hours in end time."
                                    ControlToValidate="txtEndTimeHH" Text="." ValidationGroup="SchoolInfo" meta:resourcekey="rqdEndTimeHHResource1"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revEndTimeHH" runat="server" ValidationExpression="^[0-9]+$"
                                    ErrorMessage="Only number are allowed in end time." ControlToValidate="txtEndTimeHH"
                                    Text="." ValidationGroup="SchoolInfo" meta:resourcekey="revEndTimeHHResource1"></asp:RegularExpressionValidator>
                                <asp:RequiredFieldValidator ID="rqdEndTimeMM" runat="server" ErrorMessage="Only number are allowed in end time."
                                    ControlToValidate="txtEndTimeMM" Text="." ValidationGroup="SchoolInfo" meta:resourcekey="rqdEndTimeMMResource1"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revEndTimeMM" runat="server" ErrorMessage="Please enter minutes in end time."
                                    ControlToValidate="txtEndTimeMM" Text="." ValidationGroup="SchoolInfo" ValidationExpression="^[0-9]+$"
                                    meta:resourcekey="revEndTimeMMResource1"></asp:RegularExpressionValidator>
                                <asp:CustomValidator ID="CustomValidator1" runat="server" ClientValidationFunction="validateTime"
                                    Text="End Time Is Not Valid" ControlToValidate="ddlEndTime" ValidationGroup="SchoolInfo"></asp:CustomValidator>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td class="ValueCell">
                            </td>
                            <td>
                            </td>
                            <td class="ValueCell">
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:Label ID="lblStatus" runat="server" meta:resourcekey="lblStatusResource1"></asp:Label>
                            </td>
                            <td class="ValueCell" style="text-align: left;">
                                <asp:Button ID="btnAdd" runat="server" Text="Add" ValidationGroup="SchoolInfo" OnClick="btnAdd_Click"
                                    meta:resourcekey="btnAddResource1" />
                                <asp:Button ID="btnReset" runat="server" Text="Reset" OnClick="btnReset_Click" meta:resourcekey="btnResetResource1" />
                            </td>
                            <td>
                            </td>
                            <td class="ValueCell">
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td class="ValueCell">
                            </td>
                            <td>
                            </td>
                            <td class="ValueCell">
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td class="ValueCell">
                            </td>
                            <td>
                            </td>
                            <td class="ValueCell">
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td align="center" colspan="4">
                                <asp:GridView ID="gvSchoolInfo" runat="server" AutoGenerateColumns="False" OnRowCommand="GvSchoolInfo_RowCommand"
                                    DataKeyNames="ID" AllowPaging="True" OnPageIndexChanging="gvSchoolInfo_PageIndexChanging"
                                    PageSize="15" meta:resourcekey="gvSchoolInfoResource1">
                                    <Columns>
                                        <asp:BoundField DataField="ID" HeaderText="ID" Visible="false" meta:resourcekey="BoundFieldResource1" />
                                        <asp:BoundField DataField="SchoolType" HeaderText="SchoolType" meta:resourcekey="BoundFieldResource2" />
                                        <asp:BoundField DataField="Standard" HeaderText="Standard" meta:resourcekey="BoundFieldResource3" />
                                        <asp:BoundField DataField="Medium" HeaderText="Medium" meta:resourcekey="BoundFieldResource4" />
                                        <asp:BoundField DataField="Board" HeaderText="Board" meta:resourcekey="BoundFieldResource5" />
                                        <asp:BoundField DataField="Students" HeaderText="Students" meta:resourcekey="BoundFieldResource6" Visible="false" />
                                        <asp:TemplateField HeaderText="Delete" meta:resourcekey="TemplateFieldResource1">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ibtnDelete" CausesValidation="False" OnClientClick="return confirm('Are you sure you want to delete this ? ');"
                                                    CommandName="DeleteRow" Width="12px" CommandArgument='<%# Eval("ID") %>' Height="12px"
                                                    ToolTip="Delete" runat="server" ImageUrl="~/App_Themes/Images/delete.gif" meta:resourcekey="ibtnDeleteResource1" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="5" align="right">
                                <asp:Button ID="btnPrevious" runat="server" Text="Previous" ToolTip="Previous" OnClick="btnPrevious_Click"
                                    meta:resourcekey="btnPreviousResource1" />
                                <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click"
                                    meta:resourcekey="btnSubmitResource1" />
                            </td>
                            <td>
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </td>
        </tr>
        <tr>
            <td>
                <asp:ValidationSummary ID="vsumSchoolGeneralInfo" ShowMessageBox="True" ShowSummary="False"
                    runat="server" ValidationGroup="SchoolGeneralInfo" meta:resourcekey="vsumSchoolGeneralInfoResource1" />
                <asp:ValidationSummary ID="vsumSchoolInfo" ShowMessageBox="True" ShowSummary="False"
                    runat="server" ValidationGroup="SchoolInfo" meta:resourcekey="vsumSchoolInfoResource1" />
            </td>
        </tr>
        <tfoot>
            <tr>
                <td colspan="4" class="Footer">
                </td>
            </tr>
        </tfoot>
    </table>
</asp:Content>
