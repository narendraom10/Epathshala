<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Epathshala.master" AutoEventWireup="true"
    CodeFile="Copy of PackageRegistration.aspx.cs" Inherits="Admin_PackageRegistration" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">

        function CallMethod() {
            debugger
            var txtname = $("#<%= txtPackageName.ClientID%>");
            //alert(txtname.val());
            PageMethods.CheckPackageExist(txtname.val(), CallSuccess, CallError);
        }
        function CallSuccess(res) {
            debugger

            if (res == "True") {
                $("#<%= txtPackageName.ClientID%>").val('');
                $("#<%= lblAvailibility.ClientID%>")[0].innerHTML = "package exist";
                // alert("Package alredy exist please enter other package")
            }
            else {
                $("#<%= lblAvailibility.ClientID%>")[0].innerHTML = "";
            }
        }

        function CallError(res) {
            debugger
            alert('Error');
        } 
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="0" cellspacing="0" class="RoundTop InnerTableStyle TableControl"
        width="90%">
        <tr>
            <td class="Header12 GridViewHeadercssTestAssessment RoundTop">
                <asp:Label ID="lblpackageregistration" runat="server" Text="Package Registration"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="padding: 5px;">
                <%--   <cc1:ModalPopupExtender ID="mp1" runat="server" PopupControlID="PanelAdd" TargetControlID="btnnewpackage"
                    BackgroundCssClass="modalBackground" Enabled="True">
                </cc1:ModalPopupExtender>--%>
                <asp:Panel ID="PanelAdd" runat="server" CssClass="modalPopup" Visible="false">
                    <div class="ActivityHeader">
                        <asp:Label ID="Label1" runat="server" Text="Package Registration" meta:resourcekey="lblBMSResource1"></asp:Label>
                    </div>
                    <div id="Display" runat="server" meta:resourcekey="SelectBMSResource1" style="width: 100%;
                        height: 75%;">
                        <div class="activitydivfull" style="width: 100%; height: 70%; margin: auto; border: none;">
                            <table>
                                <tr>
                                    <td colspan="2">
                                    </td>
                                </tr>
                                <%--<tr style="height: 50px">
                                    <td style="text-align: right;">
                                        <asp:Label ID="lblpackagename" runat="server" Text="Package Name:  "></asp:Label>
                                    </td>
                                    <td style="text-align: left;">
                                        <asp:TextBox ID="txtPackageName" runat="server" Width="300px" Height="25px" MaxLength="30"></asp:TextBox>
                                        <asp:Label ID="lblAvailibility" runat="server" ForeColor="#FF3300"></asp:Label>
                                        <asp:RequiredFieldValidator ID="rqdPackageName" runat="server" ControlToValidate="txtPackageName"
                                            ErrorMessage="Please enter package name" ValidationGroup="AddBx">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>--%>
                                <%--  <tr style="height: 50px">
                                    <td style="text-align: right;">
                                        <asp:Label ID="lblDescription" runat="server" Text="Package Description:  "></asp:Label>
                                    </td>
                                    <td style="text-align: left;">
                                        <asp:TextBox ID="txtdescription" runat="server" TextMode="MultiLine" Rows="3" CssClass="multiline2"
                                            Width="300px" Height="45px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: right; height: 50px">
                                        <asp:Label ID="lbldate" runat="server" Text="End Date:  "></asp:Label>
                                    </td>
                                    <td style="text-align: left;">
                                        <asp:TextBox ID="txtdate" runat="server" Width="300px" Height="25px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtdate"
                                            ErrorMessage="Please enter Date" ValidationGroup="AddBx">*</asp:RequiredFieldValidator>
                                        <asp:ImageButton ID="ibtnDate" runat="server" ImageUrl="~/App_Themes/Images/Calender.gif"
                                            Width="20px" meta:resourcekey="ibtnDateResource1" />
                                        <cc1:CalendarExtender ID="calExt" runat="server" TargetControlID="txtDate" PopupButtonID="ibtnDate"
                                            Enabled="True" Format="dd-MMM-yyyy">
                                        </cc1:CalendarExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: right; height: 50px">
                                        <asp:Label ID="lblmonth" runat="server" Text="No. Of Month:  "></asp:Label>
                                    </td>
                                    <td style="text-align: left;">
                                        <asp:TextBox ID="txtmonth" runat="server" Width="300px" Height="25px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rqmonth" runat="server" ControlToValidate="txtmonth"
                                            ErrorMessage="Please enter price" ValidationGroup="AddBx">*</asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtmonth"
                                            ErrorMessage="Enter number only" ValidationGroup="AddBx" ValidationExpression="[\d]{1,5}">*</asp:RegularExpressionValidator>
                                    </td>
                                </tr>--%>
                                <tr>
                                    <td colspan="2" align="center">
                                        <asp:Button ID="btnnext" runat="server" Text="Submit" OnClick="btnnext_Click" ValidationGroup="AddBx" />
                                        <asp:Button ID="btnClose" runat="server" Text="Close" CssClass="gobutton" CausesValidation="False"
                                            OnClick="btnClose_Click1" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:ValidationSummary ID="vs1" ShowMessageBox="true" ShowSummary="false" ValidationGroup="AddBx"
                                            runat="server" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </asp:Panel>
                <table>
                    <tr>
                        <td>
                            <asp:Panel ID="Panel1" runat="server">
                                <table id="tblpackagedetail" class="tblControl1">
                                    <tr>
                                        <td style="text-align: right;">
                                            <asp:Label ID="lblpackagename" runat="server" Text="Package Name:  "></asp:Label>
                                        </td>
                                        <td style="text-align: left;">
                                            <asp:TextBox ID="txtPackageName" runat="server" Width="300px" Height="25px" MaxLength="30"></asp:TextBox>
                                            <asp:Label ID="lblAvailibility" runat="server" ForeColor="#FF3300"></asp:Label>
                                            <asp:RequiredFieldValidator ID="rqdPackageName" runat="server" ControlToValidate="txtPackageName"
                                                ErrorMessage="Please enter package name" ValidationGroup="packageDetails">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: right;">
                                            <asp:Label ID="lblBoardMediumStandardAdd" runat="server" Text="BMS:" ToolTip="Board/Medium/Standard"></asp:Label>
                                        </td>
                                        <td style="text-align: left;">
                                            <asp:DropDownList ID="ddlBoardMediumStandard" runat="server" AutoPostBack="True"
                                                AppendDataBoundItems="True" OnSelectedIndexChanged="ddlBoardMediumStandard_SelectedIndexChanged"
                                                Width="385px" Enabled="True">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rqdBoardMediumStandard" runat="server" Text="." ControlToValidate="ddlBoardMediumStandard"
                                                ErrorMessage="Board>>Medium>>Standard required" InitialValue="0" ToolTip="Please select Board>>Medium>>Standard required"
                                                ValidationGroup="StdSubAllocationAdd" meta:resourceKey="rqdBoardMediumStandardResource1"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: right;">
                                            <asp:Label ID="lblSubject" runat="server" Text="Subject:" ToolTip="Select subject"></asp:Label>
                                        </td>
                                        <td class="SelectAllCheckBox" style="text-align: left; padding-left: 11px;">
                                            <asp:CheckBox ID="chkAllSubject" runat="server" onclick="javascript:SelectAllParent(this,'Subject');"
                                                Enabled="False" /><span>Check All</span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td style="text-align: left;">
                                            <asp:CheckBoxList ID="clstSubject" runat="server" RepeatColumns="3" CssClass="chkStyle1"
                                                RepeatDirection="Horizontal" onclick="javascript:SelectAllChild(this,'Subject');"
                                                Enabled="False">
                                            </asp:CheckBoxList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: right;">
                                            <asp:Label ID="lblpackagetype" runat="server" Text="Package Type:" ToolTip="Enter Package Type"></asp:Label>
                                        </td>
                                        <td style="text-align: left;">
                                            <asp:RadioButton ID="rbsignle" runat="server" Checked="true" Text="Single" GroupName="Packagetype" />
                                            <asp:RadioButton ID="rbcombo" runat="server" Text="Combo" GroupName="Packagetype" />
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtprice"
                                                ErrorMessage="Please Enter Number Only" ValidationGroup="packageDetails" ValidationExpression="[\d]{1,5}">Enter number only</asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: right;">
                                            <asp:Label ID="lblprice" runat="server" Text="Price:" ToolTip="Enter Price"></asp:Label>
                                        </td>
                                        <td style="text-align: left;">
                                            <asp:TextBox ID="txtprice" runat="server" Width="300px" Enabled="False" Height="25px"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="revprice" runat="server" ControlToValidate="txtprice"
                                                ErrorMessage="Please Enter Number Only" ValidationGroup="packageDetails" ValidationExpression="[\d]{1,5}">Enter number only</asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                    <tr style="height: 50px">
                                        <td style="text-align: right;">
                                            <asp:Label ID="lblDescription" runat="server" Text="Package Description:  "></asp:Label>
                                        </td>
                                        <td style="text-align: left;">
                                            <asp:TextBox ID="txtdescription" runat="server" TextMode="MultiLine" Rows="3" CssClass="multiline2"
                                                Width="300px" Height="45px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: right; height: 50px">
                                            <asp:Label ID="lbldate" runat="server" Text="End Date:  "></asp:Label>
                                        </td>
                                        <td style="text-align: left;">
                                            <asp:TextBox ID="txtdate" runat="server" Width="300px" Height="25px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtdate"
                                                ErrorMessage="Please enter Date" ValidationGroup="packageDetails">*</asp:RequiredFieldValidator>
                                            <asp:ImageButton ID="ibtnDate" runat="server" ImageUrl="~/App_Themes/Images/Calender.gif"
                                                Width="20px" meta:resourcekey="ibtnDateResource1" />
                                            <cc1:CalendarExtender ID="calExt" runat="server" TargetControlID="txtDate" PopupButtonID="ibtnDate"
                                                Enabled="True" Format="dd-MMM-yyyy">
                                            </cc1:CalendarExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: right; height: 50px">
                                            <asp:Label ID="lblmonth" runat="server" Text="No. Of Month:  "></asp:Label>
                                        </td>
                                        <td style="text-align: left;">
                                            <asp:TextBox ID="txtmonth" runat="server" Width="300px" Height="25px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rqmonth" runat="server" ControlToValidate="txtmonth"
                                                ErrorMessage="Please enter price" ValidationGroup="packageDetails">*</asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtmonth"
                                                ErrorMessage="Enter number only" ValidationGroup="packageDetails" ValidationExpression="[\d]{1,5}">*</asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:Button ID="btnsubmit" runat="server" Text="Submit" OnClick="submit_Click" ValidationGroup="packageDetails" />
                                            <asp:Button ID="btncancel" runat="server" Text="Cancel" CausesValidation="false"
                                                OnClick="btncancel_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:ValidationSummary ID="ValidationSummary1" ShowMessageBox="true" ShowSummary="false"
                                                ValidationGroup="packageDetails" runat="server" />
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
            </td>
            <td valign="top" style="padding-left: 50px; border: 10px;">
                <h2>
                    List Of Available Packages
                </h2>
                <div style="margin-top: 20px;">
                    <table>
                        <tr>
                            <td>
                                <asp:GridView ID="gvAll" runat="server" AutoGenerateColumns="false" OnPageIndexChanging="OnPaging"
                                    DataKeyNames="PackageID" PageSize="2">
                                    <Columns>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="chkAll" runat="server" onclick="checkAll(this);" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chk" runat="server" onclick="Check_Click(this)" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField ItemStyle-Width="150px" DataField="PackageName" HeaderText="Package Name" />
                                        <asp:BoundField ItemStyle-Width="150px" DataField="Subject" HeaderText="Subject" />
                                        <asp:BoundField ItemStyle-Width="150px" DataField="Price" HeaderText="Price" />
                                        <asp:BoundField ItemStyle-Width="150px" DataField="NoOfMonth" HeaderText="No Of Months" />
                                        <asp:BoundField ItemStyle-Width="150px" DataField="PackageType" HeaderText="Package Type" />
                                        <asp:BoundField ItemStyle-Width="150px" DataField="EndDate" HeaderText="End Date"
                                            DataFormatString="{0:dd/MMM/yyyy}" />
                                    </Columns>
                                    <AlternatingRowStyle BackColor="#C2D69B" />
                                </asp:GridView>
                                <asp:HiddenField ID="hfCount" runat="server" Value="0" />
                            </td>
                        </tr>
                        <tr>
                            <td align="center" style="margin-top: 10px;">
                                <asp:Button ID="btnDelete" runat="server" Text="Delete Records" OnClientClick="return ConfirmDelete();"
                                    OnClick="btnDelete_Click" />
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
    <script type="text/javascript">


        $(document).ready(function () {
        });

        function SelectAllParent(CheckBox, checkfrom) {


            var chkList = $("#<%= clstSubject.ClientID%>");

            var Inputs = chkList[0].getElementsByTagName("input");
            for (var n = 0; n < Inputs.length; ++n) {
                if (Inputs[n].type == 'checkbox')
                    Inputs[n].checked = CheckBox.checked;
            }
        }

        function SelectAllChild(CheckBoxList, checkfrom) {
            var Inputs = CheckBoxList.getElementsByTagName("input");
            var AllTick = true;
            for (var n = 0; n < Inputs.length; ++n) {
                if (Inputs[n].type == 'checkbox')
                    if (Inputs[n].checked == false) {
                        AllTick = false;
                    }
            }
            var chkAllChildClick;

            chkAllChildClick = document.getElementById("<%= chkAllSubject.ClientID%>");

            chkAllChildClick.checked = AllTick;
        }

        function CheckPackageAvailablity(CheckBox, checkfrom) {

            debugger


            var chkList = $("#<%= txtPackageName.ClientID%>");



            var packagename = $("#<%= txtPackageName.ClientID%>").val();





        }





        //           }
    </script>
    <script type="text/javascript">
        function ConfirmDelete() {
            var count = document.getElementById("<%=hfCount.ClientID %>").value;
            var gv = document.getElementById("<%=gvAll.ClientID%>");
            var chk = gv.getElementsByTagName("input");
            for (var i = 0; i < chk.length; i++) {
                if (chk[i].checked && chk[i].id.indexOf("chkAll") == -1) {
                    count++;
                }
            }
            if (count == 0) {
                alert("No records to delete.");
                return false;
            }
            else {
                return confirm("Do you want to delete " + count + " records.");
            }
        }
    </script>
    <script type="text/javascript">
<!--
        function Check_Click(objRef) {
            //Get the Row based on checkbox
            var row = objRef.parentNode.parentNode;

            //Get the reference of GridView
            var GridView = row.parentNode;

            //Get all input elements in Gridview
            var inputList = GridView.getElementsByTagName("input");

            for (var i = 0; i < inputList.length; i++) {
                //The First element is the Header Checkbox
                var headerCheckBox = inputList[0];

                //Based on all or none checkboxes
                //are checked check/uncheck Header Checkbox
                var checked = true;
                if (inputList[i].type == "checkbox" && inputList[i] != headerCheckBox) {
                    if (!inputList[i].checked) {
                        checked = false;
                        break;
                    }
                }
            }
            headerCheckBox.checked = checked;

        }
        function checkAll(objRef) {
            var GridView = objRef.parentNode.parentNode.parentNode;
            var inputList = GridView.getElementsByTagName("input");
            for (var i = 0; i < inputList.length; i++) {
                var row = inputList[i].parentNode.parentNode;
                if (inputList[i].type == "checkbox" && objRef != inputList[i]) {
                    if (objRef.checked) {
                        inputList[i].checked = true;
                    }
                    else {
                        if (row.rowIndex % 2 == 0) {
                            row.style.backgroundColor = "#C2D69B";
                        }
                        else {
                            row.style.backgroundColor = "white";
                        }
                        inputList[i].checked = false;
                    }
                }
            }
        }
//-->
    </script>
    <%--<table>
        <tr>
            <td>
                <asp:Label ID="lblpackagename" runat="server"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtpackagename" runat="server"></asp:TextBox>
            </td>
        </tr>
      
    </table>--%>
    </table>
</asp:Content>
