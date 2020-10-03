<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Epathshala.master" AutoEventWireup="true"
    CodeFile="PackageRegistration.aspx.cs" Inherits="Admin_PackageRegistration" %>

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
    <style type="text/css">
        .chkStyle11
        {
            width: 100%;
            margin: 5px 5px 5px 144px;
        }
        label
        {
            display: inline;
            width: 5em;
            padding-left: 5px;
        }
        .ajax__calendar_container
        {
            position: absolute;
            z-index: 100003 !important;
            background-color: White;
            border: 1px solid black;
        }
        
        .hidden
        {
            display: none;
            visibility: hidden;
        }
        
        
        
        /*   .textlabel1
        {
            width: 125px;
            float: left;
            height: auto;
            white-space: nowrap;
            clear: both; /*margin-top:9px;
            padding-top: 4px;
            white-space: nowrap;
            padding-left:2px;
        } */
        
        .textlabel1
        {
            width: 125px;
            height: auto;
            clear: both;
            padding-top: 4px;
            white-space: nowrap;
            float: left;
            text-align: right;
            padding-right: 20px;
        }
        
        .activitydivside1
        {
            background-color: #FFF;
            padding-bottom: 10px;
            font-size: 14px;
            color: #3E3E3E;
            border-left: 1px solid #959595;
            border-bottom: 1px solid #959595;
            border-right: 1px solid #959595;
            border-radius: 2px;
            display: inline-block;
            width: 95%;
            margin-left: auto !important;
        }
        
        .divnewpackage1
        {
            margin: auto 50px auto auto;
            padding: 5px 5px 5px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="tbldashboard" id="ClasswiseReport" runat="server" visible="true">
        <div class="sidepanelpackage">
            <div class="activitydivsidepackage">
                <div class="ActivityHeader">
                    <asp:Label ID="Label2" runat="server" Text="New Package Registration"></asp:Label>
                </div>
                <div class="ActivityContent" id="FirstRpt" runat="server" visible="true">
                    <div class="divnewpackage">
                        <asp:Label ID="lblpackagename" runat="server" Text="Package Name:  " CssClass="textlabel1"></asp:Label>
                        <asp:TextBox ID="txtPackageName" runat="server" Width="330px" Height="25px"></asp:TextBox>
                        <asp:Label ID="lblAvailibility" runat="server" ForeColor="#FF3300"></asp:Label>
                        <asp:RequiredFieldValidator ID="rqdPackageName" runat="server" ControlToValidate="txtPackageName"
                            ErrorMessage="Please enter package name" ValidationGroup="packageDetails">*</asp:RequiredFieldValidator>
                    </div>
                    <div class="divnewpackage">
                        <asp:Label ID="lblBoardMediumStandardAdd" runat="server" Text="BMS:" ToolTip="Board/Medium/Standard"
                            CssClass="textlabel1"></asp:Label>
                        <asp:DropDownList ID="ddlBoardMediumStandard" runat="server" AutoPostBack="True"
                            Width="330px" AppendDataBoundItems="True" OnSelectedIndexChanged="ddlBoardMediumStandard_SelectedIndexChanged"
                            Enabled="True">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rqdBoardMediumStandard" runat="server" Text="." ControlToValidate="ddlBoardMediumStandard"
                            ErrorMessage="Board>>Medium>>Standard required" InitialValue="0" ToolTip="Please select Board>>Medium>>Standard required"
                            ValidationGroup="StdSubAllocationAdd" meta:resourceKey="rqdBoardMediumStandardResource1"></asp:RequiredFieldValidator>
                    </div>
                    <div class="divnewpackage">
                        <asp:Label ID="lblSubject" runat="server" Text="Subject:" ToolTip="Select subject"
                            CssClass="textlabel1"></asp:Label>
                        <asp:CheckBox ID="chkAllSubject" runat="server" onclick="javascript:SelectAllParent(this,'Subject');"
                            Enabled="False" /><span>Check All</span>
                        <asp:CheckBoxList ID="clstSubject" runat="server" RepeatColumns="3" CssClass="chkStyle11"
                            RepeatDirection="Horizontal" onclick="javascript:SelectAllChild(this,'Subject');"
                            Enabled="False">
                        </asp:CheckBoxList>
                    </div>
                    <%-- <div class="divnewpackage">
                        <asp:Label ID="lblpackagetype" runat="server" Text="Package Type:" ToolTip="Enter Package Type"
                            CssClass="textlabel1"></asp:Label>
                        <asp:RadioButton ID="rbsignle" runat="server" Checked="true" Text="Single" GroupName="Packagetype" />
                        <asp:RadioButton ID="rbcombo" runat="server" Text="Combo" GroupName="Packagetype" />
                    </div>--%>
                    <div class="divnewpackage">
                        <asp:Label ID="lblprice" runat="server" Text="Price:" ToolTip="Enter Price" CssClass="textlabel1"></asp:Label>
                        <asp:TextBox ID="txtprice" runat="server" Width="330px" Enabled="False" Height="25px"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="revprice" runat="server" ControlToValidate="txtprice"
                            ErrorMessage="Number Only" ValidationGroup="packageDetails" ValidationExpression="[\d]{1,5}">Number only</asp:RegularExpressionValidator>
                    </div>
                    <div class="divnewpackage">
                        <asp:Label ID="lblDescription" runat="server" Text="Package Description:  " CssClass="textlabel1"></asp:Label>
                        <asp:TextBox ID="txtdescription" runat="server" TextMode="MultiLine" Rows="3" CssClass="multiline2"
                            Width="330px" Height="45px"></asp:TextBox>
                    </div>
                    <div class="divnewpackage">
                        <asp:Label ID="lbldate" runat="server" Text="End Date:  " CssClass="textlabel1"></asp:Label>
                        <asp:TextBox ID="txtdate" runat="server" Width="300px" Height="25px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtdate"
                            ErrorMessage="Please enter Date" ValidationGroup="packageDetails">*</asp:RequiredFieldValidator>
                        <asp:ImageButton ID="ibtnDate" runat="server" ImageUrl="~/App_Themes/Images/Calender.gif"
                            Width="20px" meta:resourcekey="ibtnDateResource1" />
                        <cc1:CalendarExtender ID="calExt" runat="server" TargetControlID="txtDate" PopupButtonID="ibtnDate"
                            Enabled="True" Format="dd-MMM-yyyy">
                        </cc1:CalendarExtender>
                    </div>
                    <div class="divnewpackage">
                        <asp:Label ID="lblmonth" runat="server" Text="No. Of Days:  " CssClass="textlabel1"></asp:Label>
                        <asp:TextBox ID="txtmonth" runat="server" Width="330px" Height="25px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rqmonth" runat="server" ControlToValidate="txtmonth"
                            ErrorMessage="Please enter price" ValidationGroup="packageDetails">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtmonth"
                            ErrorMessage="Number only" ValidationGroup="packageDetails" ValidationExpression="[\d]{1,5}">*</asp:RegularExpressionValidator>
                    </div>
                    <div class="divnewpackage">
                        <asp:Label ID="lblisactive" runat="server" Text="Is Active:  " CssClass="textlabel1"></asp:Label>
                        <asp:RadioButton ID="rbyes" runat="server" Text="Yes" GroupName="Insert" Checked="true"
                            Width="100px" />
                        <asp:RadioButton ID="rbno" runat="server" Text="No" GroupName="Insert" Width="100px" />
                    </div>
                    <div class="divnewpackage" style="padding-right: 250px;" align="center">
                        <asp:Button ID="btnsubmit" runat="server" Text="Submit" OnClick="submit_Click" ValidationGroup="packageDetails" />
                        <asp:Button ID="btncancel" runat="server" Text="Cancel" CausesValidation="false"
                            OnClick="btncancel_Click" />
                        <asp:HiddenField ID="hfselectedcnt" runat="server" />
                    </div>
                </div>
            </div>
        </div>
        <div class="sidepanelpackage1">
            <div>
                <div class="activitydivside1" id="SecondRpt" runat="server" visible="true">
                    <div class="ActivityHeader">
                        <asp:Label ID="Label3" runat="server" Text="Available packages"></asp:Label>
                    </div>
                    <div class="ActivityContent">
                        <asp:GridView ID="gvAll" runat="server" AutoGenerateColumns="false" DataKeyNames="PackageID"
                            AllowPaging="true" SkinID="NoPaging">
                            <Columns>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="chkAll" runat="server" onclick="checkAll(this);" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chk" runat="server" onclick="Check_Click(this)" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="PackageName" HeaderText="Package Name" />
                                <asp:BoundField DataField="Subject" HeaderText="Subject" />
                                <asp:BoundField DataField="Price" HeaderText="Price" />
                                <asp:BoundField DataField="NoOfMonth" HeaderText="No Of Days" />
                                <asp:BoundField DataField="PackageType" HeaderText="Package Type" />
                                <asp:BoundField DataField="EndDate" HeaderText="End Date" DataFormatString="{0:dd-MMM-yyyy}" />
                                <asp:TemplateField Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblisactive" runat="server" Text='<%# Eval("IsActive")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lbldicription" runat="server" Text='<%# Eval("PackageDescription")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblBMS" runat="server" Text='<%# Eval("BMS")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="30px" HeaderText="Edit">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkEdit" runat="server" Text="Edit" OnClick="Edit"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <asp:HiddenField ID="hfCount" runat="server" Value="0" />
                        <asp:Button ID="btnDelete" runat="server" Text="Delete Records" OnClientClick="return ConfirmDelete();"
                            OnClick="btnDelete_Click" />
                        <asp:Panel ID="pnlAddEdit" runat="server" CssClass="modalPopup" Style="display: inline">
                            <div class="ActivityHeader">
                                <asp:Label ID="Label4" runat="server" Text="Edit Package Details"></asp:Label>
                            </div>
                            <br />
                            <table align="center">
                                <tr>
                                    <td>
                                        <div class="divnewpackage1">
                                            <asp:Label ID="lpackagename" runat="server" Text="Package Name:  " CssClass="textlabel1"></asp:Label>
                                            <asp:TextBox ID="txtpackagenameedit" runat="server" Width="330px" Height="25px" ReadOnly="true"></asp:TextBox>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div class="divnewpackage1">
                                            <asp:Label ID="lblbmsedit" runat="server" Text="BMS:" ToolTip="Board/Medium/Standard"
                                                CssClass="textlabel1"></asp:Label>
                                            <asp:Label ID="lblDisplayBMSEdit" runat="server"></asp:Label>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div class="divnewpackage1">
                                            <asp:Label ID="lblsubjectedit" runat="server" Text="Subject:" ToolTip="Select subject"
                                                CssClass="textlabel1"></asp:Label>
                                            <asp:Label ID="lblsubjectlist" runat="server"></asp:Label>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div class="divnewpackage1">
                                            <asp:Label ID="lblpriceedit" runat="server" Text="Price:" ToolTip="Enter Price" CssClass="textlabel1"></asp:Label>
                                            <asp:TextBox ID="txtpriceedit" runat="server" Width="330px" Height="25px" MaxLength="5"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtpriceedit"
                                                ErrorMessage="Number Only" ValidationGroup="EditPackage" ValidationExpression="[\d]{1,5}">Number only</asp:RegularExpressionValidator>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div class="divnewpackage1">
                                            <asp:Label ID="lblpackagedecriptionedit" runat="server" Text="Package Description:  "
                                                CssClass="textlabel1"></asp:Label>
                                            <asp:TextBox ID="txtpackagedecriptionedit" runat="server" TextMode="MultiLine" Rows="3"
                                                CssClass="multiline2" Width="330px" Height="45px"></asp:TextBox>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div class="divnewpackage1">
                                            <asp:Label ID="ldateedit" runat="server" Text="End Date:  " CssClass="textlabel1"></asp:Label>
                                            <asp:TextBox ID="txtdateedit" runat="server" Width="300px" Height="25px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtdateedit"
                                                ErrorMessage="Please enter Date" ValidationGroup="EditPackage">*</asp:RequiredFieldValidator>
                                            <asp:ImageButton ID="imgenddate" runat="server" ImageUrl="~/App_Themes/Images/Calender.gif"
                                                Width="20px" meta:resourcekey="ibtnDateResource1" />
                                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtdateedit"
                                                CssClass="ajax__calendar_container" PopupButtonID="imgenddate" Enabled="True"
                                                Format="dd-MMM-yyyy">
                                            </cc1:CalendarExtender>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div class="divnewpackage1">
                                            <asp:Label ID="lblpackagenoofmonthedit" runat="server" Text="No. Of Days:  " CssClass="textlabel1"></asp:Label>
                                            <asp:TextBox ID="txtnoofmonthedit" runat="server" Width="330px" Height="25px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtmonth"
                                                ErrorMessage="Please enter price" ValidationGroup="packageDetails">*</asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtnoofmonthedit"
                                                ErrorMessage="Number only" ValidationGroup="EditPackage" ValidationExpression="[\d]{1,5}">*</asp:RegularExpressionValidator>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div class="divnewpackage1">
                                            <asp:Label ID="lblisactiveedit" runat="server" Text="Active:" CssClass="textlabel1"></asp:Label>
                                            <asp:RadioButton ID="rbtrue" runat="server" Text="Yes" Checked="true" GroupName="IsActive"
                                                Width="100px" />
                                            <asp:RadioButton ID="rbfalse" runat="server" Text="No" GroupName="IsActive" />
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <asp:Button ID="btnSave" runat="server" Text="Edit" OnClick="Save" ValidationGroup="EditPackage" />
                                        <asp:Button ID="Button1" runat="server" Text="Cancel" OnClientClick="return Hidepopup()" />
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                        <asp:LinkButton ID="lnkFake" runat="server"></asp:LinkButton>
                        <cc1:ModalPopupExtender ID="popup" runat="server" DropShadow="false" PopupControlID="pnlAddEdit"
                            TargetControlID="lnkFake" BackgroundCssClass="modalBackground">
                        </cc1:ModalPopupExtender>
                    </div>
                </div>
            </div>
        </div>
    </div>
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
