<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Epathshala.master" AutoEventWireup="true"
    CodeFile="SysConfigPage.aspx.cs" Inherits="Admin_SysConfigPage" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script language="javascript" type="text/javascript">
        function CleartextBoxes(sType) {
            a = document.getElementsByTagName("input");
            for (i = 0; i < a.length; i++) {
                if (a[i].type == sType) {
                    a[i].value = "";
                }
            }
            document.getElementById('<%=TxtBxDescription.ClientID %>').value = "";
            document.getElementById('<%=TxtBxDescriptionEdt.ClientID %>').value = "";
            return false;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="LblFieldGroup" runat="server" Text="Field Group"></asp:Label>
        <asp:DropDownList ID="ddlFieldGroup" runat="server" AppendDataBoundItems="True" Width="15%"
            AutoPostBack="True">
            <asp:ListItem Value="0" Text="-- SELECT --"></asp:ListItem>
        </asp:DropDownList>
        &nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="BttnOK" runat="server" Text="OK" OnClick="BttnOK_Click" />
        <asp:Button ID="btnAddPopup" runat="server" Text="Add" meta:resourcekey="btnShowResource1" />
        <asp:Button ID="btnedit" runat="server" Text="Edit" Style="display: none" />
    </div>
    <div>
        <br />
        <asp:GridView ID="GvlstSysConfig" runat="server" DataKeyNames="ConfigID,Field,Type,value,FieldGroup,Description"
            AutoGenerateColumns="false" OnSelectedIndexChanged="OnSelectedIndexChanged" OnRowDataBound="OnRowDataBound">
            <Columns>
                <asp:BoundField DataField="Field" HeaderText="Field" ReadOnly="true" />
                <asp:BoundField DataField="Type" HeaderText="Type" />
                <asp:BoundField DataField="value" HeaderText="value" />
                <asp:BoundField DataField="FieldGroup" HeaderText="FieldGroup" />
                <asp:BoundField DataField="Description" HeaderText="Description" />
            </Columns>
        </asp:GridView>
    </div>
    <!-- ModalPopupExtender Add-->
    <cc1:ModalPopupExtender ID="mp1" runat="server" PopupControlID="PanelAdd" TargetControlID="btnAddPopup"
        BackgroundCssClass="modalBackground" DynamicServicePath="" Enabled="True">
    </cc1:ModalPopupExtender>
    <!-- ModalPopupExtender -->
    <asp:Panel ID="PanelAdd" runat="server" Style="display: none" CssClass="modalPopup"
        DefaultButton="btnAddPopup">
        <div id="Display" runat="server" meta:resourcekey="SelectBMSResource1" style="width: 50%;
            height: 75%;">
            <div class="activitydivfull" style="width: 80%; height: 70%; margin: auto; border: none;">
                <table align="center" cellpadding="0" cellspacing="0" width="425px">
                    <tr>
                        <td colspan="2">
                            <div class="ActivityHeader1">
                                <asp:Label ID="LblDisplay" runat="server" Text="Configuration Settings" ForeColor="White"
                                    Font-Bold="true" meta:resourceKey="LblDisplay"></asp:Label>
                                <div style="float: right">
                                    <asp:ImageButton ID="ibtnClose" runat="server" Text="Close" CausesValidation="False"
                                        meta:resourceKey="btnCloseResource1" ImageUrl="~/App_Themes/Images/close.png"
                                        Height="20px" Width="20px" OnClick="ibtnClose_Click" OnClientClick=" return confirm('Do you want to close current activity ?');" />
                                </div>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <br />
                            <asp:Label ID="LblField" runat="server" Text="Field"></asp:Label>
                        </td>
                        <td>
                            <br />
                            <asp:TextBox ID="TxtBxField" runat="server" Width="250px"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ID="ReqdFldvldtrTxtBxField" ControlToValidate="TxtBxField"
                                ErrorMessage="Please Enter the Field." ValidationGroup="AddBx" Text="*"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <br />
                            <asp:Label ID="LblType" runat="server" Text="Type"></asp:Label>
                        </td>
                        <td>
                            <br />
                            <asp:TextBox ID="TxtBxType" runat="server" Width="250px"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ID="ReqdFldvldtrTxtBxType" ControlToValidate="TxtBxType"
                                ErrorMessage="Please Enter the Type." ValidationGroup="AddBx" Text="*"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <br />
                            <asp:Label ID="LblValue" runat="server" Text="Value"></asp:Label>
                        </td>
                        <td>
                            <br />
                            <asp:TextBox ID="TxtBxValue" runat="server" Width="250px"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ID="ReqdFldvldtrTxtBxValue" ControlToValidate="TxtBxValue"
                                ErrorMessage="Please Enter the Value." ValidationGroup="AddBx" Text="*"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <br />
                            <asp:Label ID="LblFieldGroupPopup" runat="server" Text="Field Group"></asp:Label>
                        </td>
                        <td>
                            <br />
                            <asp:TextBox ID="TxtBxFieldGroupPopup" runat="server" Width="250px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <br />
                            <asp:Label ID="LblDescription" runat="server" Text="Description"></asp:Label>
                        </td>
                        <td>
                            <br />
                            <asp:TextBox ID="TxtBxDescription" runat="server" TextMode="MultiLine" Width="250px"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ID="ReqdFldvldtrTxtBxDescription" ControlToValidate="TxtBxDescription"
                                ErrorMessage="Please Enter the Description." ValidationGroup="AddBx" Text="*"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                            <br />
                            <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="button" OnClick="btnAdd_Click"
                                ValidationGroup="AddBx" />
                            <input type="button" id="btnResets" value="Reset" onclick="CleartextBoxes('text');"
                                class="button" />
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
    <!-- ModalPopupExtender Edit -->
    <cc1:ModalPopupExtender ID="mpEdit" runat="server" PopupControlID="PanelEdit" TargetControlID="btnedit"
        BackgroundCssClass="modalBackground" DynamicServicePath="" Enabled="True">
    </cc1:ModalPopupExtender>
    <!-- ModalPopupExtender -->
    <asp:Panel ID="PanelEdit" runat="server" Style="display: none" CssClass="modalPopup"
        DefaultButton="btnAddPopup">
        <div id="Edit" runat="server" meta:resourcekey="SelectBMSResource1" style="width: 50%;
            height: 75%;">
            <div class="activitydivfull" style="width: 80%; height: 70%; margin: auto; border: none;">
                <table align="center" id="t1" cellpadding="0" cellspacing="0" width="425px">
                    <tr>
                        <td colspan="2">
                            <div class="ActivityHeader1">
                                <asp:Label ID="LblDisplay1" runat="server" Text="Configuration Settings" ForeColor="White"
                                    Font-Bold="true" meta:resourceKey="LblDisplay"></asp:Label>
                                <div style="float: right">
                                    <asp:ImageButton ID="ImageButton2" runat="server" Text="Close" OnClientClick=" return confirm('Do you want to close current activity ?');"
                                        CausesValidation="False" meta:resourceKey="btnCloseResource1" ImageUrl="~/App_Themes/Images/close.png"
                                        Height="20px" Width="20px" />
                                </div>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <br />
                            <asp:Label ID="LblFieldEdt" runat="server" Text="Field"></asp:Label>
                        </td>
                        <td>
                            <br />
                            <asp:TextBox ID="TxtBxFieldEdt" runat="server" Width="250px" ReadOnly="True"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <br />
                            <asp:Label ID="LblTypeEdt" runat="server" Text="Type"></asp:Label>
                        </td>
                        <td>
                            <br />
                            <asp:TextBox ID="TxtBxTypeEdt" runat="server" Width="250px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <br />
                            <asp:Label ID="LblValueEdt" runat="server" Text="Value"></asp:Label>
                        </td>
                        <td>
                            <br />
                            <asp:TextBox ID="TxtBxValueEdt" runat="server" Width="250px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <br />
                            <asp:Label ID="LblFieldGroupEdt" runat="server" Text="Field Group"></asp:Label>
                        </td>
                        <td>
                            <br />
                            <asp:TextBox ID="TxtBxFieldGroupEdt" runat="server" Width="250px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <br />
                            <asp:Label ID="LblDescriptionEdt" runat="server" Text="Description"></asp:Label>
                        </td>
                        <td>
                            <br />
                            <asp:TextBox ID="TxtBxDescriptionEdt" runat="server" Width="250px" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                            <br />
                            <asp:Button ID="BtnEditcntrl" runat="server" Text="Edit" CssClass="button" OnClick="BtnEditcntrl_Click" />
                            <input type="button" id="BtnReset1" value="Reset" onclick="CleartextBoxes('text');"
                                class="button" />
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </asp:Panel>
</asp:Content>
