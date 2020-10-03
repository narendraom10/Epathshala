<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Epathshala.master" AutoEventWireup="true"
    CodeFile="StudentRegistration.aspx.cs" Inherits="SchoolAdmin_StudentRegistration"
    Culture="auto" meta:resourcekey="PageResource2" UICulture="auto" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="../Scripts/Jquery1.9.1.js" type="text/javascript"></script>
    <script type="text/javascript">        $(document).ready(function () {
            $("#<%= ibtnSearch.ClientID%>").click(function () {
                if ($("#<%= pnlSearch.ClientID%>").is(':visible')) {
                    $("#<%= pnlSearch.ClientID%>").removeClass("Visible").addClass("InVisible");
                    $("#<%= pnlAdd.ClientID%>").removeClass("Visible").addClass("InVisible");
                    $("#<%= pnlEdit.ClientID%>").removeClass("Visible").addClass("InVisible");
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
    <style type="text/css">
        .HideElement
        {
            display: none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="up1" runat="server">
        <ContentTemplate>
            <table cellpadding="0" cellspacing="0" width="90%" class="RoundTop InnerTableStyle TableControl">
                <tr>
                    <td class="Header12 GridViewHeadercssTestAssessment RoundTop">
                        <asp:Label ID="lblTitle" runat="server" Text="Student" meta:resourcekey="lblTitleResource1"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <table class="ActionBarTable" cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <table cellpadding="0" cellspacing="0" border="0">
                                        <tr>
                                            <td>
                                                <asp:ImageButton ID="ibtnSearch" runat="server" ImageUrl="~/App_Themes/Images/ButtonBarView.png"
                                                    ToolTip="Search" meta:resourcekey="ibtnSearchResource1" />
                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ibtnRefresh" runat="server" ImageUrl="~/App_Themes/Images/ButtonBarRefresh.png"
                                                    OnClick="ibtnRefresh_Click" ToolTip="Refresh" meta:resourcekey="ibtnRefreshResource1" />
                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ibtnAdd" runat="server" ImageUrl="~/App_Themes/Images/ButtonBarAdd.png"
                                                    ToolTip="Add Student" meta:resourcekey="ibtnAddResource1"  OnClick="ibtnAdd_Click"/>
                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ibtnEdit" runat="server" ImageUrl="~/App_Themes/Images/ButtonBarEdit.png"
                                                    OnClick="ibtnEdit_Click" ToolTip="Edit" meta:resourcekey="ibtnEditResource1" />
                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ibtnDelete" runat="server" ImageUrl="~/App_Themes/Images/ButtonBarDelete.png"
                                                    OnClick="ibtnDelete_Click" ToolTip="Delete Student" 
                                                    meta:resourcekey="ibtnDeleteResource1" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <asp:UpdatePanel ID="upDetails" runat="server">
                            <ContentTemplate>
                                <table id="tblGrid" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td class="panel">
                                            <asp:Panel ID="pnlSearch" runat="server" CssClass="Visible" meta:resourcekey="pnlSearchResource1">
                                                <fieldset id="fsSearchInfo" runat="server" style="margin: 5px">
                                                    <legend>
                                                        <asp:Label ID="lblSearchTitle" runat="server" Text="Search" CssClass="SubTitle" meta:resourcekey="lblSearchTitleResource1"></asp:Label>
                                                    </legend>
                                                    <table class="tblControl1">
                                                        <tr class="HideElement">
                                                            <td colspan="4">
                                                                <asp:Literal ID="ltrlSchoolIDSearch" runat="server" meta:resourcekey="ltrlSchoolIDSearchResource1"></asp:Literal>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblSchoolIDSearch" runat="server" Text="School:" meta:resourcekey="lblSchoolIDSearchResource1"></asp:Label>
                                                            </td>
                                                            <td style="text-align: left">
                                                                <asp:TextBox ID="txtSchoolSearch" runat="server" Enabled="False" meta:resourcekey="txtSchoolSearchResource1"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblBMSIDSearch" runat="server" Text="BMS:" meta:resourcekey="lblBMSIDSearchResource1"></asp:Label>
                                                            </td>
                                                            <td style="text-align: left">
                                                                <asp:DropDownList ID="ddlBMSSearch" runat="server" meta:resourcekey="ddlBMSSearchResource1">
                                                                    <asp:ListItem Value="0" Text="--Select--" meta:resourcekey="ListItemResource1"></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblDivisionIDSearch" runat="server" Text="Division:" meta:resourcekey="lblDivisionIDSearchResource1"></asp:Label>
                                                            </td>
                                                            <td style="text-align: left">
                                                                <asp:DropDownList ID="ddlDivisionSearch" runat="server" meta:resourcekey="ddlDivisionSearchResource1">
                                                                    <asp:ListItem Value="0" Text="--Select--" meta:resourcekey="ListItemResource2"></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblFirstNameSearch" runat="server" Text="FirstName:" meta:resourcekey="lblFirstNameSearchResource1"></asp:Label>
                                                            </td>
                                                            <td style="text-align: left">
                                                                <asp:TextBox ID="txtFirstNameSearch" runat="server" meta:resourcekey="txtFirstNameSearchResource1"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblRollNoSearch" runat="server" Text="RollNo:" meta:resourcekey="lblRollNoSearchResource1"></asp:Label>
                                                            </td>
                                                            <td style="text-align: left">
                                                                <asp:TextBox ID="txtRollNoSearch" runat="server" meta:resourcekey="txtRollNoSearchResource1"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblGenderSearch" runat="server" Text="Gender:" meta:resourcekey="lblGenderSearchResource1"></asp:Label>
                                                                <%--<asp:Label ID="lblDateOfBirthSearch" runat="server" Text="DateOfBirth:" meta:resourcekey="lblDateOfBirthSearchResource1"></asp:Label>--%>
                                                            </td>
                                                            <td style="text-align: left">
                                                                <asp:RadioButtonList ID="rdbListGenderSearch" runat="server" ValidationGroup="a"
                                                                    RepeatDirection="Horizontal" meta:resourcekey="rdbListGenderSearchResource1">
                                                                    <asp:ListItem Value="0" Text="Male" meta:resourcekey="ListItemResource3"></asp:ListItem>
                                                                    <asp:ListItem Value="1" Text="Female" meta:resourcekey="ListItemResource4"></asp:ListItem>
                                                                </asp:RadioButtonList>
                                                                <%--   <asp:TextBox ID="txtDateOfBirthSearch" runat="server" meta:resourcekey="txtDateOfBirthSearchResource1"></asp:TextBox>
                                                                <asp:ImageButton ID="imgBtnCalSearch" runat="server" ImageUrl="~/App_Themes/Images/Calender.gif"
                                                                    Width="20px" meta:resourcekey="imgBtnCalSearchResource1" />
                                                                <cc2:CalendarExtender ID="calExeSearch" runat="server" TargetControlID="txtDateOfBirthSearch"
                                                                    PopupButtonID="imgBtnCalSearch" Enabled="True" Format="dd-MMM-yyyy">
                                                                </cc2:CalendarExtender>--%>
                                                            </td>
                                                        </tr>
                                                        <%-- <tr>
                                                            <td>
                                                            </td>
                                                            <td style="text-align: left">
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblAddActive" runat="server" Text="Active:" meta:resourceKey="lblActiveResource1"></asp:Label>
                                                            </td>
                                                            <td style="text-align: left">
                                                                <asp:RadioButtonList ID="rlstAddActive" runat="server" RepeatDirection="Horizontal">
                                                                    <asp:ListItem Value="1" Text="Yes" meta:resourceKey="lblActiveListItemResource1"></asp:ListItem>
                                                                    <asp:ListItem Value="0" Text="No" meta:resourceKey="lblActiveListItemResource2"></asp:ListItem>
                                                                </asp:RadioButtonList>
                                                            </td>
                                                        </tr>--%>
                                                        <tr>
                                                            <td colspan="4" align="center">
                                                                <asp:Button ID="btnSearch" ValidationGroup="aSearch" runat="server" Text="Go" AlternateText="Search"
                                                                    OnClick="btnSearch_Click" meta:resourcekey="btnSearchResource2" />
                                                                <asp:Button ID="btnCancel0" runat="server" meta:resourcekey="btnCancelResource1"
                                                                    Text="Reset" OnClick="btnCancel0_Click" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="4" align="center">
                                                                <asp:ValidationSummary ID="ValSumStudentSearch" runat="server" ValidationGroup="aSearch"
                                                                    meta:resourcekey="ValSumStudentSearchResource1" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </fieldset>
                                            </asp:Panel>
                                            <asp:Panel ID="pnlAdd" runat="server" CssClass="InVisible" meta:resourcekey="pnlAddResource1">
                                                <fieldset id="fsAdd" runat="server" style="margin: 5px">
                                                    <legend>
                                                        <asp:Label ID="lblAddTitle" runat="server" Text="Add" CssClass="SubTitle" meta:resourcekey="lblAddTitleResource1"></asp:Label>
                                                    </legend>
                                                    <table class="tblControl1">
                                                        <tr class="HideElement">
                                                            <td>
                                                                <asp:Literal ID="ltrlSchoolID" runat="server" meta:resourcekey="ltrlSchoolIDResource1"></asp:Literal>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblSchool" runat="server" Text="School:" meta:resourcekey="lblSchoolResource1"></asp:Label>
                                                            </td>
                                                            <td style="text-align: left">
                                                                <asp:TextBox ID="txtSchool" runat="server" Enabled="False" meta:resourcekey="txtSchoolResource1"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="ReqFieldSchoolID" runat="server" ErrorMessage="Please Insert School Name"
                                                                    ValidationGroup="a" ControlToValidate="txtSchool" meta:resourcekey="ReqFieldSchoolIDResource1">*</asp:RequiredFieldValidator>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblBMSID" runat="server" Text="BMSID:" meta:resourcekey="lblBMSIDResource1"></asp:Label>
                                                            </td>
                                                            <td style="text-align: left">
                                                                <asp:DropDownList ID="ddlBMSAdd" runat="server" meta:resourcekey="ddlBMSAddResource1">
                                                                    <asp:ListItem Value="0" Text="--Select--" meta:resourcekey="ListItemResource5"></asp:ListItem>
                                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="ReqFieldBMSID" runat="server" InitialValue="0" ErrorMessage="Please Insert BMSID"
                                                                    ValidationGroup="a" ControlToValidate="ddlBMSAdd" meta:resourcekey="ReqFieldBMSIDResource1">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <asp:Label ID="lblFirstName" runat="server" Text="Name:"></asp:Label>
                                                            </td>
                                                            <td colspan="3" style="text-align: left;">
                                                                <asp:TextBox ID="txtFirstName" runat="server" meta:resourcekey="txtFirstNameResource1"
                                                                    Height="22px" Width="225px"></asp:TextBox>

                                                                     <asp:RequiredFieldValidator ID="ReqFieldtxtname" runat="server" InitialValue="0"
                                                                    ErrorMessage="Please Insert Name" ValidationGroup="a" ControlToValidate="txtFirstName">*</asp:RequiredFieldValidator>


                                                                <cc2:TextBoxWatermarkExtender ID="txtBoxWatermarkExtenderTxtfirstname" runat="server"
                                                                    Enabled="True" TargetControlID="txtFirstName" WatermarkCssClass="watermark" WatermarkText="First Name">
                                                                </cc2:TextBoxWatermarkExtender>
                                                               
                                                                <asp:TextBox ID="txtMiddleName" runat="server" meta:resourcekey="txtMiddleNameResource1"
                                                                    Height="22px" Width="225px"></asp:TextBox>
                                                                <cc2:TextBoxWatermarkExtender ID="TextBoxWatermarkExtenderMiddleName" runat="server"
                                                                    Enabled="True" TargetControlID="txtMiddleName" WatermarkCssClass="watermark"
                                                                    WatermarkText="Middle Name">
                                                                </cc2:TextBoxWatermarkExtender>
                                                                <asp:TextBox ID="txtLastName" runat="server" meta:resourcekey="txtLastNameResource1"
                                                                    Height="22px" Width="225px"></asp:TextBox>
                                                                <cc2:TextBoxWatermarkExtender ID="TextBoxWatermarkExtenderLastName" runat="server"
                                                                    Enabled="True" TargetControlID="txtLastName" WatermarkCssClass="watermark" WatermarkText="Last Name">
                                                                </cc2:TextBoxWatermarkExtender>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblMobileNo" runat="server" Text="MobileNo:" meta:resourcekey="lblMobileNoResource1"></asp:Label>
                                                            </td>
                                                            <td style="text-align: left">
                                                                <asp:TextBox ID="txtMobileNo" runat="server" meta:resourcekey="txtMobileNoResource1"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblEmailID" runat="server" Text="EmailID:" meta:resourcekey="lblEmailIDResource1"></asp:Label>
                                                            </td>
                                                            <td style="text-align: left">
                                                                <asp:TextBox ID="txtEmailID" runat="server" meta:resourcekey="txtEmailIDResource1"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblDivisionID" runat="server" Text="Division:" meta:resourcekey="lblDivisionIDResource1"></asp:Label>
                                                            </td>
                                                            <td style="text-align: left">
                                                                <asp:DropDownList ID="ddlDivisionAdd" runat="server" meta:resourcekey="ddlDivisionAddResource1">
                                                                    <asp:ListItem Value="0" Text="--Select--" meta:resourcekey="ListItemResource6"></asp:ListItem>
                                                                </asp:DropDownList>
                                                                <%--   <asp:RequiredFieldValidator ID="ReqFieldDivisionID" runat="server" InitialValue="0"
                                                                    ErrorMessage="Please Insert Division" ValidationGroup="a" ControlToValidate="ddlDivisionAdd"
                                                                    meta:resourcekey="ReqFieldDivisionIDResource1">*</asp:RequiredFieldValidator>--%>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblRollNo" runat="server" Text="RollNo:" meta:resourcekey="lblRollNoResource1"></asp:Label>
                                                            </td>
                                                            <td style="text-align: left">
                                                                <asp:TextBox ID="txtRollNo" runat="server" meta:resourcekey="txtRollNoResource1"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="ReqFieldRollNo" runat="server" ErrorMessage="Please Insert RollNo"
                                                                    ValidationGroup="a" ControlToValidate="txtRollNo" meta:resourcekey="ReqFieldRollNoResource1">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <%-- <tr>
                                                            <td>
                                                                <asp:Label ID="lblStudentCode" runat="server" Text="StudentCode:" meta:resourcekey="lblStudentCodeResource1"></asp:Label>
                                                            </td>
                                                            <td style="text-align: left">
                                                                <asp:TextBox ID="txtStudentCode" runat="server" meta:resourcekey="txtStudentCodeResource1"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblLoginID" runat="server" Text="LoginID:" meta:resourcekey="lblLoginIDResource1"></asp:Label>
                                                            </td>
                                                            <td style="text-align: left">
                                                                <asp:TextBox ID="txtLoginID" runat="server" meta:resourcekey="txtLoginIDResource1"></asp:TextBox>
                                                            </td>
                                                        </tr>--%>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblGender" runat="server" Text="Gender:" meta:resourcekey="lblGenderResource1"></asp:Label>
                                                            </td>
                                                            <td style="text-align: left">
                                                                <asp:RadioButtonList ID="rdbGenderList" runat="server" ValidationGroup="a" RepeatDirection="Horizontal"
                                                                    meta:resourcekey="rdbGenderListResource1">
                                                                    <asp:ListItem Value="0" Text="Male" meta:resourcekey="ListItemResource7"></asp:ListItem>
                                                                    <asp:ListItem Value="1" Text="Female" meta:resourcekey="ListItemResource8"></asp:ListItem>
                                                                </asp:RadioButtonList>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblDateOfBirth" runat="server" Text="DateOfBirth:" meta:resourcekey="lblDateOfBirthResource1"></asp:Label>
                                                            </td>
                                                            <td style="text-align: left">
                                                                <asp:TextBox ID="txtDateOfBirth" runat="server" meta:resourcekey="txtDateOfBirthResource1"></asp:TextBox>
                                                                <asp:ImageButton ID="ibtnDate" runat="server" ImageUrl="~/App_Themes/Images/Calender.gif"
                                                                    Width="20px" meta:resourcekey="ibtnDateResource1" />
                                                                <cc2:CalendarExtender ID="calExt" runat="server" TargetControlID="txtDateOfBirth"
                                                                    PopupButtonID="ibtnDate" Enabled="True" Format="dd-MMM-yyyy">
                                                                </cc2:CalendarExtender>
                                                                <asp:RequiredFieldValidator ID="ReqFieldDateOfBirth" runat="server" ErrorMessage="Please Insert DateOfBirth"
                                                                    ValidationGroup="a" ControlToValidate="txtDateOfBirth" meta:resourcekey="ReqFieldDateOfBirthResource1">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblGRNo" runat="server" Text="GRNo:" meta:resourcekey="lblGRNoResource1"></asp:Label>
                                                            </td>
                                                            <td style="text-align: left">
                                                                <asp:TextBox ID="txtGRNo" runat="server" meta:resourcekey="txtGRNoResource1"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblBloodGroup" runat="server" Text="BloodGroup:" meta:resourcekey="lblBloodGroupResource1"></asp:Label>
                                                            </td>
                                                            <td style="text-align: left">
                                                                <asp:TextBox ID="txtBloodGroup" runat="server" meta:resourcekey="txtBloodGroupResource1"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <caption>
                                                            <tr>
                                                                <td colspan="4" style="text-align: center;">
                                                                    <asp:Button ID="btnSave" runat="server" AlternateText="Save" meta:resourcekey="btnSaveResource1"
                                                                        OnClick="btnSave_Click" Text="Save" ValidationGroup="a" />
                                                                    <asp:Button ID="btnCancel" runat="server" meta:resourcekey="btnCancelResource1" OnClick="btnCancel_Click"
                                                                        Text="Reset" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" colspan="4">
                                                                    <asp:ValidationSummary ID="ValSumStudent" runat="server" meta:resourcekey="ValSumStudentResource1"
                                                                        ValidationGroup="a" />
                                                                </td>
                                                            </tr>
                                                        </caption>
                                                    </table>
                                                </fieldset>
                                            </asp:Panel>
                                            <asp:Panel ID="pnlEdit" runat="server" CssClass="InVisible" meta:resourcekey="pnlEditResource1">
                                                <fieldset id="fsEmpStdSubEdit" runat="server" style="margin: 5px">
                                                    <legend>
                                                        <asp:Label ID="lblEditTitle" runat="server" Text="Edit" CssClass="SubTitle" meta:resourceKey="lblEditTitleResource1"></asp:Label>
                                                    </legend>
                                                    <table class="tblControl1">
                                                        <tr class="HideElement">
                                                            <td colspan="4">
                                                                <asp:Literal ID="ltrlSchoolIDEdit" runat="server" meta:resourcekey="ltrlSchoolIDEditResource1"></asp:Literal>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblSchoolIDEdit" runat="server" Text="SchoolID:" meta:resourcekey="lblSchoolIDEditResource1"></asp:Label>
                                                            </td>
                                                            <td style="text-align: left">
                                                                <asp:TextBox ID="txtSchoolEdit" runat="server" Enabled="False" meta:resourcekey="txtSchoolEditResource1"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="ReqFieldSchoolIDEdit" runat="server" ErrorMessage="Please Insert SchoolID"
                                                                    ValidationGroup="aEdit" ControlToValidate="txtSchoolEdit" meta:resourcekey="ReqFieldSchoolIDEditResource1">*</asp:RequiredFieldValidator>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblBMSIDEdit" runat="server" Text="BMSID:" meta:resourcekey="lblBMSIDEditResource1"></asp:Label>
                                                            </td>
                                                            <td style="text-align: left">
                                                                <asp:DropDownList ID="ddlBMSEdit" runat="server" meta:resourcekey="ddlBMSEditResource1">
                                                                    <asp:ListItem Value="0" Text="--Select--" meta:resourcekey="ListItemResource9"></asp:ListItem>
                                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="ReqFieldBMSIDEdit" runat="server" InitialValue="0"
                                                                    ErrorMessage="Please Insert BMSID" ValidationGroup="aEdit" ControlToValidate="ddlBMSEdit"
                                                                    meta:resourcekey="ReqFieldBMSIDEditResource1">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblDivisionIDEdit" runat="server" Text="DivisionID:" meta:resourcekey="lblDivisionIDEditResource1"></asp:Label>
                                                            </td>
                                                            <td style="text-align: left">
                                                                <asp:DropDownList ID="ddlDivisionEdit" runat="server" meta:resourcekey="ddlDivisionEditResource1">
                                                                    <asp:ListItem Value="0" Text="--Select--" meta:resourcekey="ListItemResource10"></asp:ListItem>
                                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="ReqFieldDivisionIDEdit" InitialValue="0" runat="server"
                                                                    ErrorMessage="Please Insert DivisionID" ValidationGroup="aEdit" ControlToValidate="ddlDivisionEdit"
                                                                    meta:resourcekey="ReqFieldDivisionIDEditResource1">*</asp:RequiredFieldValidator>
                                                            </td>
                                                            <td style="text-align: right">
                                                            </td>
                                                            <td style="text-align: left">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblLoginIDEdit" runat="server" Text="LoginID:" meta:resourcekey="lblLoginIDEditResource1"></asp:Label>
                                                                <%--<asp:Label ID="lblStudentCodeEdit" runat="server" Text="StudentCode:" meta:resourcekey="lblStudentCodeEditResource1"></asp:Label>--%>
                                                            </td>
                                                            <td style="text-align: left">
                                                                <asp:TextBox ID="txtLoginIDEdit" runat="server" meta:resourcekey="txtLoginIDEditResource1"
                                                                    Enabled="false"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="ReqFieldLoginIDEdit" runat="server" ErrorMessage="Please Insert LoginID"
                                                                    ValidationGroup="aEdit" ControlToValidate="txtLoginIDEdit" meta:resourcekey="ReqFieldLoginIDEditResource1">*</asp:RequiredFieldValidator>
                                                                <%--<asp:TextBox ID="txtStudentCodeEdit" runat="server" meta:resourcekey="txtStudentCodeEditResource1"></asp:TextBox>--%>
                                                                <%--<asp:RequiredFieldValidator ID="ReqFieldStudentCodeEdit" runat="server" ErrorMessage="Please Insert StudentCode"
                                                                    ValidationGroup="aEdit" ControlToValidate="txtStudentCodeEdit" meta:resourcekey="ReqFieldStudentCodeEditResource1">*</asp:RequiredFieldValidator>--%>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblPasswordEdit" runat="server" Text="Password:" meta:resourcekey="lblPasswordEditResource1"></asp:Label>
                                                            </td>
                                                            <td style="text-align: left">
                                                                <asp:TextBox ID="txtPasswordEdit" runat="server" meta:resourcekey="txtPasswordEditResource1"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="ReqFieldPasswordEdit" runat="server" ErrorMessage="Please Insert Password"
                                                                    ValidationGroup="aEdit" ControlToValidate="txtPasswordEdit" meta:resourcekey="ReqFieldPasswordEditResource1">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblRollNoEdit" runat="server" Text="RollNo:" meta:resourcekey="lblRollNoEditResource1"></asp:Label>
                                                            </td>
                                                            <td style="text-align: left">
                                                                <asp:TextBox ID="txtRollNoEdit" runat="server" meta:resourcekey="txtRollNoEditResource1"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="ReqFieldRollNoEdit" runat="server" ErrorMessage="Please Insert RollNo"
                                                                    ValidationGroup="aEdit" ControlToValidate="txtRollNoEdit" meta:resourcekey="ReqFieldRollNoEditResource1">*</asp:RequiredFieldValidator>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblFirstNameEdit" runat="server" Text="FirstName:" meta:resourcekey="lblFirstNameEditResource1"></asp:Label>
                                                            </td>
                                                            <td style="text-align: left">
                                                                <asp:TextBox ID="txtFirstNameEdit" runat="server" meta:resourcekey="txtFirstNameEditResource1"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="ReqFieldFirstNameEdit" runat="server" ErrorMessage="Please Insert FirstName"
                                                                    ValidationGroup="aEdit" ControlToValidate="txtFirstNameEdit" meta:resourcekey="ReqFieldFirstNameEditResource1">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblMiddleNameEdit" runat="server" Text="MiddleName:" meta:resourcekey="lblMiddleNameEditResource1"></asp:Label>
                                                            </td>
                                                            <td style="text-align: left">
                                                                <asp:TextBox ID="txtMiddleNameEdit" runat="server" meta:resourcekey="txtMiddleNameEditResource1"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="ReqFieldMiddleNameEdit" runat="server" ErrorMessage="Please Insert MiddleName"
                                                                    ValidationGroup="aEdit" ControlToValidate="txtMiddleNameEdit" meta:resourcekey="ReqFieldMiddleNameEditResource1">*</asp:RequiredFieldValidator>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblLastNameEdit" runat="server" Text="LastName:" meta:resourcekey="lblLastNameEditResource1"></asp:Label>
                                                            </td>
                                                            <td style="text-align: left">
                                                                <asp:TextBox ID="txtLastNameEdit" runat="server" meta:resourcekey="txtLastNameEditResource1"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="ReqFieldLastNameEdit" runat="server" ErrorMessage="Please Insert LastName"
                                                                    ValidationGroup="aEdit" ControlToValidate="txtLastNameEdit" meta:resourcekey="ReqFieldLastNameEditResource1">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblGenderEdit" runat="server" Text="Gender:" meta:resourcekey="lblGenderEditResource1"></asp:Label>
                                                            </td>
                                                            <td style="text-align: left">
                                                                <asp:RadioButtonList ID="rdbGenderEditList" runat="server" ValidationGroup="aEdit"
                                                                    RepeatDirection="Horizontal" meta:resourcekey="rdbGenderEditListResource1">
                                                                    <asp:ListItem Value="0" Text="Male" meta:resourcekey="ListItemResource11"></asp:ListItem>
                                                                    <asp:ListItem Value="1" Text="Female" meta:resourcekey="ListItemResource12"></asp:ListItem>
                                                                </asp:RadioButtonList>
                                                                <asp:RequiredFieldValidator ID="ReqFieldGenderEdit" runat="server" ErrorMessage="Please Insert Gender"
                                                                    ValidationGroup="aEdit" ControlToValidate="rdbGenderEditList" meta:resourcekey="ReqFieldGenderEditResource1">*</asp:RequiredFieldValidator>
                                                            </td>
                                                            <td>
                                                                <%--<asp:Label ID="lblContactNoEdit" runat="server" Text="ContactNo:" meta:resourcekey="lblContactNoEditResource1"></asp:Label>--%>
                                                            </td>
                                                            <td style="text-align: left">
                                                                <%--<asp:TextBox ID="txtContactNoEdit" runat="server" meta:resourcekey="txtContactNoEditResource1"></asp:TextBox>--%>
                                                                <%--<asp:RequiredFieldValidator ID="ReqFieldContactNoEdit" runat="server" ErrorMessage="Please Insert ContactNo"
                                                                    ValidationGroup="aEdit" ControlToValidate="txtContactNoEdit" meta:resourcekey="ReqFieldContactNoEditResource1">*</asp:RequiredFieldValidator>--%>
                                                            </td>
                                                        </tr>
                                                        <%-- <tr>
                                                            <td>
                                                                <asp:Label ID="lblMobileNoEdit" runat="server" Text="MobileNo:" meta:resourcekey="lblMobileNoEditResource1"></asp:Label>
                                                            </td>
                                                            <td style="text-align: left">
                                                                <asp:TextBox ID="txtMobileNoEdit" runat="server" meta:resourcekey="txtMobileNoEditResource1"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="ReqFieldMobileNoEdit" runat="server" ErrorMessage="Please Insert MobileNo"
                                                                    ValidationGroup="aEdit" ControlToValidate="txtMobileNoEdit" meta:resourcekey="ReqFieldMobileNoEditResource1">*</asp:RequiredFieldValidator>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblEmailIDEdit" runat="server" Text="EmailID:" meta:resourcekey="lblEmailIDEditResource1"></asp:Label>
                                                            </td>
                                                            <td style="text-align: left">
                                                                <asp:TextBox ID="txtEmailIDEdit" runat="server" meta:resourcekey="txtEmailIDEditResource1"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="ReqFieldEmailIDEdit" runat="server" ErrorMessage="Please Insert EmailID"
                                                                    ValidationGroup="aEdit" ControlToValidate="txtEmailIDEdit" meta:resourcekey="ReqFieldEmailIDEditResource1">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblGRNoEdit" runat="server" Text="GRNo:" meta:resourcekey="lblGRNoEditResource1"></asp:Label>
                                                            </td>
                                                            <td style="text-align: left">
                                                                <asp:TextBox ID="txtGRNoEdit" runat="server" meta:resourcekey="txtGRNoEditResource1"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="ReqFieldGRNoEdit" runat="server" ErrorMessage="Please Insert GRNo"
                                                                    ValidationGroup="aEdit" ControlToValidate="txtGRNoEdit" meta:resourcekey="ReqFieldGRNoEditResource1">*</asp:RequiredFieldValidator>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblDateOfBirthEdit" runat="server" Text="DateOfBirth:" meta:resourcekey="lblDateOfBirthEditResource1"></asp:Label>
                                                            </td>
                                                            <td style="text-align: left">
                                                                <asp:TextBox ID="txtDateOfBirthEdit" runat="server" meta:resourcekey="txtDateOfBirthEditResource1"></asp:TextBox>
                                                                <asp:ImageButton ID="imgBtnCal" runat="server" ImageUrl="~/App_Themes/Images/Calender.gif"
                                                                    Width="20px" meta:resourcekey="imgBtnCalResource1" />
                                                                <cc2:CalendarExtender ID="calExeEdit" runat="server" TargetControlID="txtDateOfBirthEdit"
                                                                    PopupButtonID="imgBtnCal" Enabled="True" Format="dd-MMM-yyyy">
                                                                </cc2:CalendarExtender>
                                                                <asp:RequiredFieldValidator ID="ReqFieldDateOfBirthEdit" runat="server" ErrorMessage="Please Insert DateOfBirth"
                                                                    ValidationGroup="aEdit" ControlToValidate="txtDateOfBirthEdit" meta:resourcekey="ReqFieldDateOfBirthEditResource1">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>--%>
                                                        <%--    <tr>
                                                            <td>
                                                                
                                                            </td>
                                                            <td style="text-align: left">
                                                              
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblBloodGroupEdit" runat="server" Text="BloodGroup:" meta:resourcekey="lblBloodGroupEditResource1"></asp:Label>
                                                            </td>
                                                            <td style="text-align: left">
                                                                <asp:TextBox ID="txtBloodGroupEdit" runat="server" meta:resourcekey="txtBloodGroupEditResource1"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="ReqFieldBloodGroupEdit" runat="server" ErrorMessage="Please Insert BloodGroup"
                                                                    ValidationGroup="aEdit" ControlToValidate="txtBloodGroupEdit" meta:resourcekey="ReqFieldBloodGroupEditResource1">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>--%>
                                                        <%--   <tr>
                                                            <td>
                                                                <asp:Label ID="lblIsActiveEdit" runat="server" Text="IsActive:" meta:resourcekey="lblIsActiveEditResource1"></asp:Label>
                                                            </td>
                                                            <td style="text-align: left" colspan="3">
                                                                <asp:CheckBox ID="chkIsActiveEdit" runat="server" meta:resourcekey="chkIsActiveEditResource1" />
                                                                <asp:RequiredFieldValidator ID="ReqFieldIsActiveEdit" runat="server" ErrorMessage="Please Insert IsActive"
                                                                    ValidationGroup="aEdit" ControlToValidate="rdbGenderEditList" meta:resourcekey="ReqFieldIsActiveEditResource1">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>--%>
                                                        <tr>
                                                            <td colspan="4" style="text-align: center;">
                                                                <asp:Button ID="btnUpdate" ValidationGroup="aEdit" runat="server" Text="Update" AlternateText="Save"
                                                                    OnClick="btnUpdate_Click" meta:resourcekey="btnUpdateResource1" />
                                                                <asp:Button ID="btnCancelEdit" runat="server" Text="Cancel" OnClick="btnCancelEdit_Click"
                                                                    meta:resourcekey="btnCancelEditResource1" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="4" align="center">
                                                                <asp:ValidationSummary ID="ValSumStudentEdit" runat="server" ValidationGroup="aEdit"
                                                                    meta:resourcekey="ValSumStudentEditResource1" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </fieldset>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:GridView ID="grvStudentdetail" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                                CellPadding="4" DataKeyNames="StudentID,SchoolID,BMSID,DivisionID,RoleID,StudentCode,LoginID,Password,FirstName,MiddleName,LastName,RollNo,ContactNo,MobileNo,EmailID,GRNo,DateOfBirth,Gender,BloodGroup,IsActive,CreatedOn,CreatedBy,ModifiedOn,ModifiedBy"
                                                OnPageIndexChanging="grvStudentdetail_PageIndexChanging" OnSorting="grvStudentdetail_Sorting"
                                                OnRowCreated="grvStudentdetail_RowCreated" meta:resourcekey="grvStudentdetailResource1">
                                                <Columns>
                                                    <asp:TemplateField meta:resourcekey="TemplateFieldResource1">
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
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Sr. No" meta:resourcekey="TemplateFieldResource2">
                                                        <ItemTemplate>
                                                            <%# ((GridViewRow)Container).RowIndex + 1%></ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="StudentID" SortExpression="StudentID" HeaderText="StudentID"
                                                        Visible="False" meta:resourcekey="BoundFieldResource1" />
                                                    <asp:BoundField DataField="Name" SortExpression="Name" HeaderText="School" meta:resourcekey="BoundFieldResource2" />
                                                    <asp:BoundField DataField="SchoolID" SortExpression="SchoolID" HeaderText="SchoolID"
                                                        Visible="False" meta:resourcekey="BoundFieldResource3" />
                                                    <asp:BoundField DataField="BMSID" SortExpression="BMSID" HeaderText="BMSID" Visible="False"
                                                        meta:resourcekey="BoundFieldResource4" />
                                                    <asp:BoundField DataField="BMS" SortExpression="BMS" HeaderText="Board >> Medium >> Standard"
                                                        meta:resourcekey="BoundFieldResource5" />
                                                    <asp:BoundField DataField="Division" SortExpression="Division" HeaderText="Division"
                                                        meta:resourcekey="BoundFieldResource6" />
                                                    <asp:BoundField DataField="DivisionID" SortExpression="DivisionID" HeaderText="DivisionID"
                                                        Visible="False" meta:resourcekey="BoundFieldResource7" />
                                                    <asp:BoundField DataField="RoleID" SortExpression="RoleID" HeaderText="RoleID" Visible="False"
                                                        meta:resourcekey="BoundFieldResource8" />
                                                    <asp:BoundField DataField="StudentCode" SortExpression="StudentCode" HeaderText="StudentCode"
                                                        Visible="False" meta:resourcekey="BoundFieldResource9" />
                                                    <asp:BoundField DataField="RollNo" SortExpression="RollNo" HeaderText="RollNo" meta:resourcekey="BoundFieldResource15" />
                                                    <asp:BoundField DataField="FirstName" SortExpression="FirstName" HeaderText="FirstName"
                                                        meta:resourcekey="BoundFieldResource12" />
                                                    <asp:BoundField DataField="Gender" SortExpression="Gender" HeaderText="Gender" meta:resourcekey="BoundFieldResource21" />
                                                    <asp:BoundField DataField="LoginID" SortExpression="LoginID" HeaderText="LoginID"
                                                        meta:resourcekey="BoundFieldResource10" />
                                                    <asp:BoundField DataField="Password" SortExpression="Password" HeaderText="Password"
                                                        meta:resourcekey="BoundFieldResource11" />
                                                    <asp:BoundField DataField="MiddleName" SortExpression="MiddleName" HeaderText="MiddleName"
                                                        Visible="False" meta:resourcekey="BoundFieldResource13" />
                                                    <asp:BoundField DataField="LastName" SortExpression="LastName" HeaderText="LastName"
                                                        Visible="False" meta:resourcekey="BoundFieldResource14" />
                                                    <asp:BoundField DataField="ContactNo" SortExpression="ContactNo" HeaderText="ContactNo"
                                                        Visible="False" meta:resourcekey="BoundFieldResource16" />
                                                    <asp:BoundField DataField="MobileNo" SortExpression="MobileNo" HeaderText="MobileNo"
                                                        Visible="False" meta:resourcekey="BoundFieldResource17" />
                                                    <asp:BoundField DataField="EmailID" SortExpression="EmailID" HeaderText="EmailID"
                                                        Visible="False" meta:resourcekey="BoundFieldResource18" />
                                                    <asp:BoundField DataField="GRNo" SortExpression="GRNo" HeaderText="GRNo" Visible="False"
                                                        meta:resourcekey="BoundFieldResource19" />
                                                    <asp:BoundField DataField="DateOfBirth" SortExpression="DateOfBirth" HeaderText="DateOfBirth"
                                                        Visible="False" meta:resourcekey="BoundFieldResource20" />
                                                    <asp:BoundField DataField="BloodGroup" SortExpression="BloodGroup" HeaderText="BloodGroup"
                                                        Visible="False" meta:resourcekey="BoundFieldResource22" />
                                                    <asp:BoundField DataField="IsActive1" SortExpression="IsActive" HeaderText="Active"
                                                        Visible="False" meta:resourcekey="BoundFieldResource23" />
                                                    <asp:BoundField DataField="CreatedOn" SortExpression="CreatedOn" HeaderText="CreatedOn"
                                                        Visible="False" meta:resourcekey="BoundFieldResource24" />
                                                    <asp:BoundField DataField="CreatedBy" SortExpression="CreatedBy" HeaderText="CreatedBy"
                                                        Visible="False" meta:resourcekey="BoundFieldResource25" />
                                                    <asp:BoundField DataField="ModifiedOn" SortExpression="ModifiedOn" HeaderText="ModifiedOn"
                                                        Visible="False" meta:resourcekey="BoundFieldResource26" />
                                                    <asp:BoundField DataField="ModifiedBy" SortExpression="ModifiedBy" HeaderText="ModifiedBy"
                                                        Visible="False" meta:resourcekey="BoundFieldResource27" />
                                                </Columns>
                                                <PagerTemplate>
                                                    <asp:ImageButton Text="First" CommandName="Page" CommandArgument="First" runat="server"
                                                        ImageUrl="~/App_Themes/Images/first.png" ID="ibtnFirst" ToolTip="Move First Page"
                                                        meta:resourcekey="ibtnFirstResource1" />
                                                    <asp:ImageButton Text="Previous" CommandName="Page" CommandArgument="Prev" runat="server"
                                                        ImageUrl="~/App_Themes/Images/previous.png" ID="ibtnPrevious" ToolTip="Move Previous Page"
                                                        meta:resourcekey="ibtnPreviousResource1" />
                                                    <asp:Label ID="lblPage" runat="server" Text="Page" ForeColor="Black" meta:resourcekey="lblPageResource1"></asp:Label>
                                                    <asp:DropDownList ID="ddlPageSelector" OnSelectedIndexChanged="ddlPageSelector_SelectedIndexChanged"
                                                        runat="server" AutoPostBack="True" SkinID="DdlWidth50" meta:resourcekey="ddlPageSelectorResource1">
                                                    </asp:DropDownList>
                                                    <asp:ImageButton Text="Next" CommandName="Page" CommandArgument="Next" runat="server"
                                                        ImageUrl="~/App_Themes/Images/NEXT.png" ID="ibtnNext" ToolTip="Move Next Page"
                                                        meta:resourcekey="ibtnNextResource1" />
                                                    <asp:ImageButton Text="Last" CommandName="Page" CommandArgument="Last" runat="server"
                                                        ImageUrl="~/App_Themes/Images/last.png" ID="ibtnLast" ToolTip="Move Last Page"
                                                        meta:resourcekey="ibtnLastResource1" />
                                                </PagerTemplate>
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
