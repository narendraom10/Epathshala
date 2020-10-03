<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Epathshala.master" AutoEventWireup="true"
    CodeFile="PromoteBatch.aspx.cs" Inherits="Dashboard_PromoteBatch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .checkboxtext1
        {
            text-align: center;
            vertical-align: middle;
        }
        .style1
        {
            width: 500px;
        }
        .style2
        {
            width: 81px;
        }
        .style3
        {
            width: 119px;
        }
        .style5
        {
            width: 91px;
        }
        .style6
        {
            width: 65px;
        }
        .style7
        {
            width: 108px;
        }
    </style>
    <script type="text/javascript">

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

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="height: 100%; width: 100%;">
        <tr>
            <%--<td style="width: 35%; vertical-align: top; height: 50%;">
                <div class="sidepanelPromotBanch" runat="server" id="divcurrentyeardetails">
                    <div class="activitydivside">
                        <div class="ActivityHeader">
                            <asp:Label ID="LblPageTitle" runat="server" Text="Current Details" CssClass="label1"></asp:Label>
                        </div>
                        <div>
                            <asp:UpdatePanel runat="server" ID="UpdatePanel_3" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <table>
                                    </table>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <div align="center">
                            <asp:Button ID="btnok" runat="server" Text="OK" OnClick="btnok_Click" />
                            <asp:Button ID="btnreset" runat="server" Text="Reset" OnClick="btnreset_Click" />
                        </div>
                    </div>
                </div>
            </td>--%>
            <td style="width: 100%; vertical-align: top;">
                <%--Right Side panel--%>
                <div class="sidepanel1PromotBanch">
                    <div class="activitydivside1">
                        <div class="ActivityHeader">
                            Student's Current Board Medium and Standard Details
                        </div>
                        <div class="ActivityContent">
                            <table width="100%">
                                <tr>
                                    <td class="style2">
                                        <asp:Label ID="lblschool" runat="server" Text="School"></asp:Label>
                                    </td>
                                    <td class="style1">
                                        <asp:DropDownList ID="ddlschool" runat="server" OnSelectedIndexChanged="ddlschool_SelectedIndexChanged"
                                            Width="350px">
                                        </asp:DropDownList>
                                    </td>
                                    <td class="style3">
                                        <asp:Label ID="lbldiv" runat="server" Text="Div"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddldiv" runat="server" Enabled="False" OnSelectedIndexChanged="ddldiv_SelectedIndexChanged1"
                                            AutoPostBack="true">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style2">
                                        <asp:Label ID="lblbms" runat="server" Text="BMS"></asp:Label>
                                    </td>
                                    <td class="style1">
                                        <asp:DropDownList ID="ddlBMS" runat="server" OnSelectedIndexChanged="ddlBMS_SelectedIndexChanged"
                                            AppendDataBoundItems="true" AutoPostBack="True" Width="350px">
                                            <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td class="style3">
                                        <asp:Label ID="lblacedemicyear" runat="server" Text="Acedemic Year"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlcurrentacedemicyear" runat="server" Enabled="False">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <%-- <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        <asp:UpdatePanel ID="up_ddlcurrentdiv" runat="server" UpdateMode="Conditional">
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="ddlBMS" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>--%>
                                <%--  <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        <asp:UpdatePanel ID="up_currentacedemicyear" runat="server" UpdateMode="Conditional">
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="ddldiv" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>--%>
                                <tr>
                                    <td colspan="4">
                                        <div align="center">
                                            <asp:Button ID="Button1" runat="server" Text="OK" OnClick="btnok_Click" />
                                            <asp:Button ID="Button2" runat="server" Text="Reset" OnClick="btnreset_Click" />
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <asp:GridView ID="gvstudentList" runat="server" AutoGenerateColumns="false" DataKeyNames="StudentID"
                                            AllowPaging="true" SkinID="NoPaging">
                                            <Columns>
                                                <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                                    <HeaderTemplate>
                                                        <asp:CheckBox ID="chkAll" runat="server" onclick="checkAll(this);" />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chk" runat="server" onclick="Check_Click(this)" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <%--<asp:BoundField DataField="StudentID" HeaderText="Student ID"/>--%>
                                                <asp:BoundField DataField="Name" HeaderText="Name" ItemStyle-Width="500px" />
                                                <%--<asp:TemplateField HeaderText="RollNo" ItemStyle-HorizontalAlign="Right">
                                        <ItemTemplate >
                                            <asp:TextBox ID="txtrollno" runat="server" style="text-align:right; padding-right:5px;" Text='<%# Eval("RollNo") %>'  />
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                                <asp:BoundField DataField="RollNo" HeaderText="Roll Number" ItemStyle-HorizontalAlign="Right"
                                                    Visible="true" />
                                                <asp:BoundField DataField="GRNo" HeaderText="Gr Number" ItemStyle-HorizontalAlign="Right" />
                                            </Columns>
                                            <EmptyDataTemplate>
                                                <p style="color: black; font-weight: bold; font-size: 20px;">
                                                    No Records Found
                                                </p>
                                            </EmptyDataTemplate>
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4" align="center">
                                        <asp:Button ID="btnpromote" runat="server" Text="Promote to Next Standard" Style="height: 26px"
                                            Visible="False" OnClick="btnpromote_Click" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
            </td>
        </tr>
        <tr>
            <td style="width: 100%; vertical-align: top;">
                <br />
                <div class="sidepanel1PromotBanch" runat="server" visible="false" id="divpromot">
                    <div class="activitydivside1">
                        <div class="ActivityHeader">
                            <asp:Label ID="Label1" runat="server" Text="Promote student to next standard"></asp:Label>
                            <asp:Label ID="lblNoOfStudent" runat="server" Text="-" Font-Bold="True" ForeColor="#FF3300"
                                Visible="False"></asp:Label>
                        </div>
                        <div class="ActivityContent">
                            <table width="100%">
                                <tr>
                                    <td class="style5">
                                        <asp:Label ID="lblnewBMS" runat="server" Text="BMS"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlnextyearBMS" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlnextyearBMS_SelectedIndexChanged"
                                            Width="350px">
                                        </asp:DropDownList>
                                    </td>
                                    <td class="style6">
                                        <asp:Label ID="lbldivision" runat="server" Text="Division"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddldivision" runat="server" Enabled="False" AutoPostBack="True"
                                            OnSelectedIndexChanged="ddldivision_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                    <td class="style7">
                                        <asp:Label ID="lblnewacedemicyear" runat="server" Text="Acedemic Year"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlAcademicYear" runat="server" OnSelectedIndexChanged="ddlAcademicYear_SelectedIndexChanged"
                                            AutoPostBack="true" Visible="False">
                                        </asp:DropDownList>
                                        <asp:Label ID="lblnextacedemicyear" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <%--   <asp:UpdatePanel runat="server" ID="UpdatePanel2" UpdateMode="Conditional">
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="ddlAcademicYear" />
                                            </Triggers>
                                        </asp:UpdatePanel>--%>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div align="center">
                            <asp:Button ID="btnpromot" runat="server" Text="Submit" OnClick="btnpromot_Click"
                                Style="height: 26px" />
                            <asp:Button ID="btnpromotreset" runat="server" Text="Reset" OnClick="btnpromotreset_Click" />
                        </div>
                        <div>
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" DataKeyNames="StudentID"
                                AllowPaging="true" SkinID="NoPaging">
                                <Columns>
                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" Visible="false">
                                        <HeaderTemplate>
                                            <asp:CheckBox ID="chkAll" runat="server" onclick="checkAll(this);" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chk" runat="server" onclick="Check_Click(this)" Visible="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Name" HeaderText="Name" ItemStyle-Width="1000px" />
                                    <asp:TemplateField HeaderText="RollNo" ItemStyle-HorizontalAlign="Right">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtrollno" runat="server" Text='<%# Eval("RollNo") %>' Style="text-align: right;
                                                padding-right: 10px;" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Gr No" ItemStyle-HorizontalAlign="Right">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtgrno" runat="server" Text='<%# Eval("GRNo") %>' Style="text-align: right;
                                                padding-right: 10px;" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                        <div align="center">
                            <asp:Button ID="btnpromotetonext" runat="server" Text="Promote" Visible="False" OnClick="btnpromotetonext_Click" />
                            <asp:Button ID="btnupdate" runat="server" Text="Update" OnClick="btnupdate_Click"
                                Visible="False" />
                        </div>
                    </div>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
