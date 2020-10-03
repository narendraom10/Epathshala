<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Epathshala.master" AutoEventWireup="true"
    CodeFile="TeacherClassAllocation.aspx.cs" Inherits="Admin_TeacherClassAllocation"
    Culture="auto" meta:resourcekey="PageResource2" UICulture="auto" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="../Scripts/Jquery1.9.1.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            //            $("#<%= ibtnSearch.ClientID%>").click(function () {
            //                debugger;
            //                if ($("#<%= pnlSearch.ClientID%>").is(':visible')) {
            //                    $("#<%= pnlSearch.ClientID%>").removeClass("Visible").addClass("InVisible");
            //                    $("#<%= pnlAdd.ClientID%>").removeClass("Visible").addClass("InVisible");
            //                    $("#<%= pnlEdit.ClientID%>").removeClass("Visible").addClass("InVisible");
            //                    $("#<%= pnlISClassTeach.ClientID%>").removeClass("Visible").addClass("InVisible");
            //                } else {
            //                    $("#<%= pnlSearch.ClientID%>").removeClass("InVisible").addClass("Visible");
            //                    $("#<%= pnlAdd.ClientID%>").removeClass("Visible").addClass("InVisible");
            //                    $("#<%= pnlEdit.ClientID%>").removeClass("Visible").addClass("InVisible");
            //                    $("#<%= pnlISClassTeach.ClientID%>").removeClass("Visible").addClass("InVisible");
            //                }
            //                if ($("#<%= btnReset.ClientID%>") != null) {
            //                    $("#<%= btnReset.ClientID%>").click();
            //                }
            //                return false;
            //            });
            $("#<%= ibtnIsClassTeacher.ClientID%>").click(function () {
                if ($("#<%= pnlISClassTeach.ClientID%>").is(':visible')) {
                    $("#<%= pnlISClassTeach.ClientID%>").removeClass("Visible").addClass("InVisible");
                    $("#<%= pnlSearch.ClientID%>").removeClass("InVisible").addClass("Visible");
                    $("#<%= pnlAdd.ClientID%>").removeClass("Visible").addClass("InVisible");
                    $("#<%= pnlEdit.ClientID%>").removeClass("Visible").addClass("InVisible");
                } else {
                    $("#<%= pnlISClassTeach.ClientID%>").removeClass("InVisible").addClass("Visible");
                    $("#<%= pnlSearch.ClientID%>").removeClass("Visible").addClass("InVisible");
                    $("#<%= pnlAdd.ClientID%>").removeClass("Visible").addClass("InVisible");
                    $("#<%= pnlEdit.ClientID%>").removeClass("Visible").addClass("InVisible");
                }
                return false;
            });
            $("#<%= ibtnAdd.ClientID%>").click(function () {
                if ($("#<%= pnlAdd.ClientID%>").is(':visible')) {
                    $("#<%= pnlAdd.ClientID%>").removeClass("Visible").addClass("InVisible");
                    $("#<%= pnlSearch.ClientID%>").removeClass("InVisible").addClass("Visible");
                    $("#<%= pnlISClassTeach.ClientID%>").removeClass("Visible").addClass("InVisible");
                    $("#<%= pnlEdit.ClientID%>").removeClass("Visible").addClass("InVisible");
                } else {
                    $("#<%= pnlAdd.ClientID%>").removeClass("InVisible").addClass("Visible");
                    $("#<%= pnlISClassTeach.ClientID%>").removeClass("Visible").addClass("InVisible");
                    $("#<%= pnlSearch.ClientID%>").removeClass("Visible").addClass("InVisible");
                    $("#<%= pnlEdit.ClientID%>").removeClass("Visible").addClass("InVisible");
                }
                return false;
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="tblDashboard1">
        <div class="firstpanel">
            <div class="activitydivfull">
                <div class="ActivityHeader">
                    <asp:Label ID="lblTitle" runat="server" Text="Standard Management" meta:resourcekey="lblTitleResource1"></asp:Label>
                </div>
                <div class="ActivityContent">
                    <div class="standarbtn">
                        <ul>
                            <li class="standarbar">
                                <asp:ImageButton ID="ibtnSearch" runat="server" ImageUrl="~/App_Themes/Responsive/web/searchuser.png"
                                    ToolTip="Search Teacher" meta:resourcekey="ibtnSearchResource1" OnClientClick="javascript:return SearchButtonClick();" />
                            </li>
                            <li class="standarbar">
                                <asp:ImageButton ID="ibtnRefresh" runat="server" ImageUrl="~/App_Themes/Responsive/web/rectreload.png"
                                    OnClick="ibtnRefresh_Click" ToolTip="Refresh" meta:resourcekey="ibtnRefreshResource1" />
                            </li>
                            <li class="standarbar">
                                <asp:ImageButton ID="ibtnAdd" runat="server" ImageUrl="~/App_Themes/Responsive/web/plus.png"
                                    ToolTip="Add Teacher" meta:resourcekey="ibtnAddResource1" />
                            </li>
                            <li class="standarbar">
                                <asp:ImageButton ID="ibtnEdit" runat="server" ImageUrl="~/App_Themes/Responsive/web/edit.png"
                                    OnClick="ibtnEdit_Click" ToolTip="Edit Teacher" meta:resourcekey="ibtnEditResource1" />
                            </li>
                            <li class="standarbar">
                                <asp:ImageButton ID="ibtnIsClassTeacher" runat="server" OnClick="ibtnIsClassTeacher_Click"
                                    ImageUrl="~/App_Themes/Responsive/web/activeuser.png" ToolTip="Is Class Teacher or Not"
                                    meta:resourcekey="ibtnIsClassTeacherResource1" />
                            </li>
                            <li class="standarbar">
                                <asp:ImageButton ID="ibtnDelete" runat="server" ImageUrl="~/App_Themes/Responsive/web/close.png"
                                    OnClick="ibtnDelete_Click" ToolTip="Delete Teacher" meta:resourcekey="ibtnDeleteResource1" />
                            </li>
                        </ul>
                    </div>
                    <div class="subheaduserdetail">
                        <asp:UpdatePanel ID="UpSearch" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:Panel ID="pnlSearch" runat="server" CssClass="Visible" meta:resourcekey="pnlSearchResource1">
                                    <fieldset id="fsSchoolGeneralInfo" runat="server" style="margin: 5px">
                                        <legend>
                                            <asp:Label ID="lblSearchTitle" runat="server" Text="Search" CssClass="SubTitle" meta:resourceKey="lblSearchTitleResource1"></asp:Label>
                                        </legend>
                                        <table class="tblControl1">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="LblSchoolName" runat="server" Text="School Name:" meta:resourceKey="LblSchoolNameResource1"></asp:Label></div>
                                                </td>
                                                <td style="text-align: left;">
                                                    <asp:DropDownList ID="ddlSchool" runat="server" Width="100%" AutoPostBack="True"
                                                        OnSelectedIndexChanged="ddlSchool_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblEmployee" runat="server" Text="Employee:" meta:resourceKey="lblEmployeeResource1"></asp:Label>
                                                </td>
                                                <td style="text-align: left;">
                                                    <asp:DropDownList ID="ddlEmployee" runat="server" AutoPostBack="True" AppendDataBoundItems="True"
                                                        meta:resourceKey="ddlEmployeeResource1">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="rqdEmployee" runat="server" Text="." ControlToValidate="ddlEmployee"
                                                        ErrorMessage="Teacher is required" InitialValue="0" ToolTip="Please select teacher."
                                                        ValidationGroup="StdSubAllocation" meta:resourceKey="rqdEmployeeResource1"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblBoardMediumStandard" runat="server" Text="BMS:" meta:resourceKey="lblBoardMediumStandardResource1"
                                                        ToolTip="Board/Medium/Standard"></asp:Label>
                                                </td>
                                                <td style="text-align: left;">
                                                    <asp:DropDownList ID="ddlBoardMediumStandard" runat="server" AutoPostBack="True"
                                                        OnSelectedIndexChanged="ddlBoardMediumStandard_SelectedIndexChanged" AppendDataBoundItems="True"
                                                        meta:resourceKey="ddlBoardMediumStandardResource1">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="rqdBoardMediumStandard" runat="server" Text="." ControlToValidate="ddlBoardMediumStandard"
                                                        ErrorMessage="Board>>Medium>>Standard required" InitialValue="0" ToolTip="Please select Board>>Medium>>Standard required"
                                                        ValidationGroup="StdSubAllocation" meta:resourceKey="rqdBoardMediumStandardResource1"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="vertical-align: top;">
                                                    <asp:Label ID="lblDivision" runat="server" Text="Division:" meta:resourceKey="lblDivisionResource1"></asp:Label>
                                                </td>
                                                <td style="text-align: left;">
                                                    <asp:CheckBoxList ID="clstDivision" runat="server" RepeatColumns="3" CssClass="chkStyle"
                                                        RepeatDirection="Horizontal" meta:resourceKey="clstDivisionResource1">
                                                    </asp:CheckBoxList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="vertical-align: top;">
                                                    <asp:Label ID="lblSubject" runat="server" Text="Subject:" meta:resourceKey="lblSubjectResource1"></asp:Label>
                                                </td>
                                                <td style="text-align: left;">
                                                    <asp:CheckBoxList ID="clstSubject" runat="server" RepeatColumns="3" CssClass="chkStyle"
                                                        RepeatDirection="Horizontal">
                                                    </asp:CheckBoxList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblIsClassTeacher" runat="server" Text="Is class teacher:" meta:resourceKey="lblIsClassTeacherResource1"></asp:Label>
                                                </td>
                                                <td style="text-align: left;">
                                                    <asp:RadioButtonList ID="rbtnIsClassTecorNo" runat="server" RepeatDirection="Horizontal">
                                                        <asp:ListItem Value="1">Yes</asp:ListItem>
                                                        <asp:ListItem Value="0">No</asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                </td>
                                                <td style="text-align: left;">
                                                    <asp:Button ID="btnGo" runat="server" meta:resourceKey="btnGoResource1" OnClick="btnGo_Click"
                                                        Text="Go" />
                                                    <asp:Button ID="btnReset" runat="server" meta:resourceKey="btnResetResource1" OnClick="btnReset_Click"
                                                        Text="Reset" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                </td>
                                                <td>
                                                    <asp:ValidationSummary ID="vsumTeacherAllocation" runat="server" DisplayMode="List"
                                                        meta:resourceKey="vsumTeacherAllocationResource1" ValidationGroup="StdSubAllocation" />
                                                </td>
                                            </tr>
                                        </table>
                                    </fieldset>
                                </asp:Panel>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="ddlSchool" />
                                <asp:AsyncPostBackTrigger ControlID="ddlEmployee" />
                                <asp:AsyncPostBackTrigger ControlID="ddlBoardMediumStandard" />
                                <asp:AsyncPostBackTrigger ControlID="btnReset" />
                                <asp:PostBackTrigger ControlID="btnGo" />
                            </Triggers>
                        </asp:UpdatePanel>
                        <asp:UpdatePanel ID="upAdd" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:Panel ID="pnlAdd" runat="server" CssClass="InVisible">
                                    <fieldset id="fsEmpStdSubAdd" runat="server" style="margin: 5px">
                                        <legend>
                                            <asp:Label ID="lblAddTitle" runat="server" Text="Add" CssClass="SubTitle" meta:resourceKey="lblAddTitleResource1"></asp:Label>
                                        </legend>
                                        <table class="tblControl1">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="LblSchoolNameAdd" runat="server" Text="School Name:" meta:resourceKey="LblSchoolNameResource1"></asp:Label></div>
                                                </td>
                                                <td style="text-align: left;">
                                                    <asp:DropDownList ID="ddlSchoolAdd" runat="server" Width="100%" AutoPostBack="True"
                                                        OnSelectedIndexChanged="ddlSchoolAdd_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 113px;">
                                                    <asp:Label ID="lblEmployeeAdd" runat="server" Text="Employee:" meta:resourceKey="lblEmployeeResource1"></asp:Label>
                                                </td>
                                                <td style="text-align: left;">
                                                    <asp:DropDownList ID="ddlEmployeeAdd" runat="server" AutoPostBack="True" AppendDataBoundItems="True"
                                                        meta:resourceKey="ddlEmployeeResource1" OnSelectedIndexChanged="ddlEmployeeAdd_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                    <%-- <asp:DropDownList ID="ddlEmployeeAdd" runat="server" meta:resourceKey="ddlEmployeeResource1">
                                                    </asp:DropDownList>--%>
                                                    <asp:RequiredFieldValidator ID="rqdEmployeeAdd" runat="server" Text="." ControlToValidate="ddlEmployeeAdd"
                                                        ErrorMessage="Teacher is required" InitialValue="0" ToolTip="Please select teacher."
                                                        ValidationGroup="StdSubAllocationAdd" meta:resourceKey="rqdEmployeeResource1">
                                                    </asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblBoardMediumStandardAdd" runat="server" Text="BMS:" meta:resourceKey="lblBoardMediumStandardResource1"
                                                        ToolTip="Board/Medium/Standard"></asp:Label>
                                                </td>
                                                <td style="text-align: left;">
                                                    <asp:DropDownList ID="ddlBoardMediumStandardAdd" runat="server" AutoPostBack="True"
                                                        AppendDataBoundItems="True" meta:resourceKey="ddlBoardMediumStandardResource1"
                                                        OnSelectedIndexChanged="ddlBoardMediumStandardAdd_SelectedIndexChanged" onchange="javascript:ResetCheckBox();">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="rqdBoardMediumStandardAdd" runat="server" Text="."
                                                        ControlToValidate="ddlBoardMediumStandardAdd" ErrorMessage="Board>>Medium>>Standard required"
                                                        InitialValue="0" ToolTip="Please select Board>>Medium>>Standard required" ValidationGroup="StdSubAllocationAdd"
                                                        meta:resourceKey="rqdBoardMediumStandardResource1"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblDivisionAdd" runat="server" Text="Division:" meta:resourceKey="lblDivisionResource1"
                                                        Style="vertical-align: top;"></asp:Label>
                                                </td>
                                                <td class="SelectAllCheckBox" style="text-align: left; padding-left: 11px;">
                                                    <asp:CheckBox ID="chkAllDivison" runat="server" onclick="javascript:SelectAllParent(this,'Division');" /><span>Check
                                                        All</span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                </td>
                                                <td style="text-align: left;">
                                                    <asp:CheckBoxList ID="clstDivisionAdd" runat="server" RepeatColumns="3" RepeatDirection="Horizontal"
                                                        onclick="javascript:SelectAllChild(this,'Division');" CssClass="chkStyle">
                                                    </asp:CheckBoxList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblSubjectAdd" runat="server" Text="Subject:" meta:resourceKey="lblSubjectResource1"></asp:Label>
                                                </td>
                                                <td class="SelectAllCheckBox" style="text-align: left; padding-left: 11px;">
                                                    <asp:CheckBox ID="chkAllSubject" runat="server" onclick="javascript:SelectAllParent(this,'Subject');" /><span>Check
                                                        All</span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                </td>
                                                <td style="text-align: left;">
                                                    <asp:CheckBoxList ID="clstSubjectAdd" runat="server" RepeatColumns="3" CssClass="chkStyle"
                                                        RepeatDirection="Horizontal" onclick="javascript:SelectAllChild(this,'Subject');">
                                                    </asp:CheckBoxList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                </td>
                                                <td style="text-align: left;">
                                                    <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit"
                                                        ValidationGroup="StdSubAllocationAdd" meta:resourceKey="btnSubmitResource1" />
                                                    <asp:Button ID="btnResetAdd" runat="server" Text="Cancel" meta:resourceKey="btnResetCancelResource1"
                                                        OnClick="btnResetAdd_Click" OnClientClick="javascript:UnCheckAllChkech();" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                </td>
                                                <td>
                                                    <asp:ValidationSummary ID="vsumTeacherAllocationAdd" runat="server" DisplayMode="List"
                                                        meta:resourceKey="vsumTeacherAllocationResource1" ValidationGroup="StdSubAllocationAdd" />
                                                </td>
                                            </tr>
                                        </table>
                                    </fieldset>
                                </asp:Panel>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="ddlSchoolAdd" />
                                <asp:AsyncPostBackTrigger ControlID="ddlEmployeeAdd" />
                                <asp:AsyncPostBackTrigger ControlID="ddlBoardMediumStandardAdd" />
                                <asp:AsyncPostBackTrigger ControlID="btnResetAdd" />
                                <asp:PostBackTrigger ControlID="btnSubmit" />
                            </Triggers>
                        </asp:UpdatePanel>
                        <asp:Panel ID="pnlEdit" runat="server" CssClass="InVisible">
                            <fieldset id="fsEmpStdSubEdit" runat="server" style="margin: 5px">
                                <legend>
                                    <asp:Label ID="lblEditTitle" runat="server" Text="Edit" CssClass="SubTitle" meta:resourceKey="lblEditTitleResource1"></asp:Label>
                                </legend>
                                <table class="tblControl1">
                                    <tr>
                                        <td style="width: 113px;">
                                            <asp:Label ID="lblEmployeeEdit" runat="server" Text="Employee:" meta:resourceKey="lblEmployeeResource1"></asp:Label>
                                        </td>
                                        <td style="text-align: left;">
                                            <asp:DropDownList ID="ddlEmployeeEdit" runat="server" AutoPostBack="True" AppendDataBoundItems="True"
                                                meta:resourceKey="ddlEmployeeResource1">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rqdEmployeeEdit" runat="server" Text="." ControlToValidate="ddlEmployeeEdit"
                                                ErrorMessage="Teacher is required" InitialValue="0" ToolTip="Please select teacher."
                                                ValidationGroup="StdSubAllocationEdit" meta:resourceKey="rqdEmployeeResource1"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblBoardMediumStandardEdit" runat="server" Text="BMS:" ToolTip="Board/Medium/Standard"
                                                meta:resourceKey="lblBoardMediumStandardResource1"></asp:Label>
                                        </td>
                                        <td style="text-align: left;">
                                            <asp:DropDownList ID="ddlBoardMediumStandardEdit" runat="server" AutoPostBack="True"
                                                AppendDataBoundItems="True" meta:resourceKey="ddlBoardMediumStandardResource1">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rqdBoardMediumStandardEdit" runat="server" Text="."
                                                ControlToValidate="ddlBoardMediumStandardEdit" ErrorMessage="Board>>Medium>>Standard required"
                                                InitialValue="0" ToolTip="Please select Board>>Medium>>Standard required" ValidationGroup="StdSubAllocationEdit"
                                                meta:resourceKey="rqdBoardMediumStandardResource1"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="vertical-align: top;">
                                            <asp:Label ID="lblDivisionEdit" runat="server" Text="Division:" meta:resourceKey="lblDivisionResource1"></asp:Label>
                                        </td>
                                        <td style="text-align: left;">
                                            <asp:CheckBoxList ID="clstDivisionEdit" runat="server" RepeatColumns="3" RepeatDirection="Horizontal"
                                                CssClass="chkStyle" meta:resourceKey="clstDivisionResource1">
                                            </asp:CheckBoxList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="vertical-align: top;">
                                            <asp:Label ID="lblSubjectEdit" runat="server" Text="Subject:" meta:resourceKey="lblSubjectResource1"></asp:Label>
                                        </td>
                                        <td style="text-align: left;">
                                            <asp:CheckBoxList ID="clstSubjectEdit" runat="server" CssClass="chkStyle" RepeatColumns="3"
                                                RepeatDirection="Horizontal">
                                            </asp:CheckBoxList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td style="text-align: left;">
                                            <asp:Button ID="btnUpdate" runat="server" Text="Update" ValidationGroup="StdSubAllocationEdit"
                                                OnClick="btnUpdate_Click" meta:resourceKey="btnUpdateResource1" />
                                            <asp:Button ID="btnResetEdit" runat="server" Text="Cancel" meta:resourceKey="btnResetCancelResource1"
                                                OnClick="btnResetEdit_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td>
                                            <asp:ValidationSummary ID="vsumTeacherAllocationEdit" runat="server" DisplayMode="List"
                                                meta:resourceKey="vsumTeacherAllocationResource1" ValidationGroup="StdSubAllocationEdit" />
                                        </td>
                                    </tr>
                                </table>
                            </fieldset>
                        </asp:Panel>
                        <asp:Panel ID="pnlISClassTeach" runat="server" CssClass="InVisible" meta:resourcekey="pnlISClassTeachResource1">
                            <fieldset id="fsISClassTeach" runat="server" style="margin: 5px">
                                <legend>
                                    <asp:Label ID="lblISClassTeachTitle" runat="server" Text="Is Class teacher" CssClass="SubTitle"
                                        meta:resourceKey="lblISClassTeachTitleResource1"></asp:Label>
                                </legend>
                                <table cellspacing="1" style="margin: 5px" class="tblControl1">
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblSectAction" runat="server" Text="Please Select Action:" meta:resourceKey="lblSectActionResource1"></asp:Label>
                                            <asp:RadioButton ID="rbYes" runat="server" Text="YES" GroupName="YesNo" Checked="True"
                                                meta:resourceKey="rdYesResource1" />
                                            <asp:RadioButton ID="rbNo" runat="server" Text="NO" GroupName="YesNo" meta:resourceKey="rdNoResource1" />
                                        </td>
                                        <td>
                                            <asp:Button ID="btnYesNoSub" runat="server" Text="Submit" OnClick="btnYesNoSub_Click"
                                                meta:resourceKey="btnYesNoSubResource1" />
                                        </td>
                                    </tr>
                                </table>
                            </fieldset>
                        </asp:Panel>
                    </div>
                    <div>
                        <asp:GridView ID="gvEmpStdSubAllocationDetails" runat="server" DataKeyNames="EmpStdID,EmployeeID,BMSID,DivisionID,SubjectID"
                            OnPageIndexChanging="gvEmpStdSubAllocationDetails_PageIndexChanging" AllowSorting="True"
                            OnSorting="gvEmpStdSubAllocationDetails_Sorting" OnRowCreated="gvEmpStdSubAllocationDetails_RowCreated"
                            meta:resourcekey="gvEmpStdSubAllocationDetailsResource1">
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
                                <asp:BoundField DataField="EmpName" HeaderText="Teacher" SortExpression="EmpName"
                                    meta:resourcekey="BoundFieldResource1" />
                                <asp:BoundField DataField="BMS" HeaderText="Board>>Medium>>Standard" SortExpression="BMS"
                                    meta:resourcekey="BoundFieldResource2" />
                                <asp:BoundField DataField="DivisionName" HeaderText="Division" SortExpression="DivisionName"
                                    meta:resourcekey="BoundFieldResource3" />
                                <asp:BoundField DataField="SubjectName" HeaderText="Subject" SortExpression="SubjectName"
                                    meta:resourcekey="BoundFieldResource4" />
                                <asp:BoundField DataField="IsClassTeacher" HeaderText="Class Teacher" SortExpression="IsClassTeacher"
                                    meta:resourcekey="BoundFieldResource5" />
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
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- LoaderPart -->
    <asp:Button ID="btnLoader" runat="server" Style="display: none" />
    <asp:Button ID="btnCancel" runat="server" Style="display: none" />
    <cc1:ModalPopupExtender ID="ModalPopup" runat="server" PopupControlID="dvPopup" CancelControlID="btnCancel"
        TargetControlID="btnLoader" BackgroundCssClass="modalBackground" Enabled="True">
    </cc1:ModalPopupExtender>
    <table id="dvPopup" runat="server" class="loadingtable" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <img src="../App_Themes/Responsive/web/Loader.gif" alt="Loading Please wait.." />
            </td>
        </tr>
        <tr>
            <td class="loadingtabletd">
                <span>Loading Please Wait..</span>
            </td>
        </tr>
    </table>
    <!-- LoaderPart -->
    <script type="text/javascript">
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_beginRequest(BeginRequestHandler);
        prm.add_endRequest(EndRequestHandler);
        function BeginRequestHandler(sender, args) {
            if ($("#<%= btnLoader.ClientID%>") != null) {
                $("#<%= btnLoader.ClientID%>").click();
            }
        }

        function EndRequestHandler(sender, args) {
            if ($("#<%= btnCancel.ClientID%>") != null) {
                $("#<%= btnCancel.ClientID%>").click();
            }
        }
        var TotalChkBx;
        var Counter;
        Counter = 0;
        function SelectAll(CheckBox) {

            var TargetBaseControl = document.getElementById('<%= this.gvEmpStdSubAllocationDetails.ClientID %>');

            var TargetChildControl = "chkselect";
            var Inputs = TargetBaseControl.getElementsByTagName("input");
            for (var n = 0; n < Inputs.length; ++n)
                if (Inputs[n].type == 'checkbox')
                    Inputs[n].checked = CheckBox.checked;
            Counter = CheckBox.checked ? TotalChkBx : 0;
        }

        function ChildClick(CheckBox) {

            TotalChkBx = parseInt('<%= this.gvEmpStdSubAllocationDetails.Rows.Count %>');

            var HeaderCheckBox = document.getElementById('ctl00_ContentPlaceHolder1_gvEmpStdSubAllocationDetails_ctl01_chkHeaderchkSelect');
            if (CheckBox.checked && Counter < TotalChkBx)
                Counter++;
            else if (Counter > 0)
                Counter--;
            if (Counter < TotalChkBx)
                HeaderCheckBox.checked = false;
            else if (Counter == TotalChkBx)
                HeaderCheckBox.checked = true;
        }

        function SelectAllParent(CheckBox, checkfrom) {
            if (checkfrom == 'Division') {
                var chkList = $("#<%= clstDivisionAdd.ClientID%>");
            }
            else if (checkfrom == 'Subject') {
                var chkList = $("#<%= clstSubjectAdd.ClientID%>");
            }
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
            if (checkfrom == 'Division') {
                chkAllChildClick = document.getElementById("<%= chkAllDivison.ClientID%>");
            }
            else if (checkfrom == 'Subject') {
                chkAllChildClick = document.getElementById("<%= chkAllSubject.ClientID%>");
            }
            chkAllChildClick.checked = AllTick;
        }
        function ResetCheckBox() {
            var chkList = $("#<%= clstDivisionAdd.ClientID%>");
            var Inputs = chkList[0].getElementsByTagName("input");
            for (var n = 0; n < Inputs.length; ++n) {
                if (Inputs[n].type == 'checkbox')
                    Inputs[n].checked = false;
            }
            var chkList = $("#<%= clstSubjectAdd.ClientID%>");
            var Inputs = chkList[0].getElementsByTagName("input");
            for (var n = 0; n < Inputs.length; ++n) {
                if (Inputs[n].type == 'checkbox')
                    Inputs[n].checked = false;
            }
            var chkAllDivi = document.getElementById("<%= chkAllDivison.ClientID%>");
            chkAllDivi.checked = false;

            var chkAllSub = document.getElementById("<%= chkAllSubject.ClientID%>");
            chkAllSub.checked = false;
        }
        function UnCheckAllChkech() {
            var chkAllDivi = document.getElementById("<%= chkAllDivison.ClientID%>");
            chkAllDivi.checked = false;

            var chkAllSub = document.getElementById("<%= chkAllSubject.ClientID%>");
            chkAllSub.checked = false;
        }
        function SearchButtonClick() {
            if ($("#<%= pnlSearch.ClientID%>").is(':visible')) {
                //                $("#<%= pnlSearch.ClientID%>").removeClass("Visible").addClass("InVisible");
                //                $("#<%= pnlAdd.ClientID%>").removeClass("Visible").addClass("InVisible");
                //                $("#<%= pnlEdit.ClientID%>").removeClass("Visible").addClass("InVisible");
                //                $("#<%= pnlISClassTeach.ClientID%>").removeClass("Visible").addClass("InVisible");
            } else {

                $("#<%= pnlSearch.ClientID%>").removeClass("InVisible").addClass("Visible");
                $("#<%= pnlAdd.ClientID%>").removeClass("Visible").addClass("InVisible");
                $("#<%= pnlEdit.ClientID%>").removeClass("Visible").addClass("InVisible");
                $("#<%= pnlISClassTeach.ClientID%>").removeClass("Visible").addClass("InVisible");
            }
            if ($("#<%= btnReset.ClientID%>") != null) {
                $("#<%= btnReset.ClientID%>").click();
            }
            return false;
        }
    </script>
</asp:Content>
