<%@ Page Title="" Language="C#" MasterPageFile="~/Epathshala.master" AutoEventWireup="true" CodeFile="AddNewPackage.aspx.cs" Inherits="Admin_AddNewPackage" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

 <asp:Button ID="btnAddPopup" runat="server" Text="Add" meta:resourcekey="btnShowResource1" />
 <asp:Button ID="btnShow" runat="server" Text="Show Modal Popup" />
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
                                        Height="20px" Width="20px"  OnClientClick=" return confirm('Do you want to close current activity ?');" />
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
                            <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="button" 
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

</asp:Content>

