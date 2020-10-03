<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Epathshala.master" AutoEventWireup="true"
    CodeFile="AddUpdateTemplate.aspx.cs" Inherits="SchoolAdmin_AddUpdateTemplate" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit.HTMLEditor"
    TagPrefix="HTMLEditor" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .ajax__htmleditor_editor_editpanel
        {
            padding: 5px;
        }
        .ddl
        {
            border: 2px solid #e5e5e5;
            padding: 3px;
            -webkit-appearance: none;
            text-indent: 0.01px; /*In Firefox*/
            text-overflow: ''; /*In Firefox*/
            margin: 0px !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="width: 80%; margin: auto">
        <div class="activitydivside1" id="Div1" runat="server" style="margin-bottom: 5px;
            padding-bottom: 0px">
            <div class="ActivityHeader">
                <asp:Label ID="lblTitle" runat="server" Text="Add Template"></asp:Label>
            </div>
            <div class="ActivityContent" style="margin-top: 10px;">
                <div class="dvmaildetail">
                    <div class="dvsmallheader">
                        <span>Template</span>
                    </div>
                    <div>
                        <asp:TextBox runat="server" ID="txttitle" Style="width: 98.5%; height: 25px; border: 2px solid #e5e5e5;
                            padding: 4px" MaxLength="100" />
                        <asp:RequiredFieldValidator ID="reqtitle" runat="server" ControlToValidate="txttitle"
                            ErrorMessage="Please enter template" ValidationGroup="vgtemplate">*</asp:RequiredFieldValidator>
                    </div>
                    <div class="dvsmallheader" style="margin-top: 20px;">
                        <span>Mail Subject</span>
                    </div>
                    <div>
                        <asp:TextBox runat="server" ID="txtsubject" Style="width: 99%; height: 25px; border: 2px solid #e5e5e5;
                            padding: 4px" MaxLength="100" />
                        <asp:RequiredFieldValidator ID="reqsubject" runat="server" ControlToValidate="txtsubject"
                            ErrorMessage="Please enter mail subject" ValidationGroup="vgtemplate">*</asp:RequiredFieldValidator>
                    </div>
                    <div class="dvsmallheader" style="margin-top: 20px;">
                        <span>Mail Body</span>
                    </div>
                    <div style="display: inline-block; width: auto; float: right;">
                        <span>Select Field: </span>
                        <asp:DropDownList ID="DdlTag" runat="server" AppendDataBoundItems="true" runat="server"
                            Width="200px" Height="30px" CssClass="ddl" SkinID="none" onchange="InsertTag(this)">
                        </asp:DropDownList>
                        <span>Copy Tag: </span>
                        <asp:TextBox ID="TxtTagValue" Text="" runat="server" Style="min-width: 200px; height: 20px;
                            border: 2px solid #e5e5e5; padding: 4px;" />
                    </div>
                    <div>
                        <HTMLEditor:Editor ID="txtmail" runat="server" Height="460px" Width="100%" AutoFocus="false"
                            ClientIDMode="AutoID" />
                        <asp:RequiredFieldValidator ID="reqmailcontent" runat="server" ControlToValidate="txtmail"
                            ErrorMessage="Please enter mail body" ValidationGroup="vgtemplate">*</asp:RequiredFieldValidator>
                    </div>
                    <div style="width: 100%; display: none;">
                        <div style="display: inline-block; text-align: right; float: right; margin-right: -4px;
                            margin-bottom: 0px;">
                            <input type="file" id="fuimage" name="fuimage" runat="server" style="width: 250px;" />
                            <asp:RegularExpressionValidator ID="regval" ValidationExpression="([a-zA-Z0-9\s_\\.\-:])+(.png|.jpg)$"
                                ControlToValidate="fuimage" runat="server" ForeColor="Red" ErrorMessage="Please select a valid image."
                                Display="Dynamic" />
                            <asp:Button ID="btnupload" runat="server" OnClick="btnupload_Click" Text="Add Image"
                                Style="margin-bottom: 10px;" />
                        </div>
                    </div>
                    <div style="margin-left: -4px; padding-top: 13px; padding-bottom: 10px;">
                        <asp:Button ID="btnSubmit" Text="Create" runat="server" OnClick="btnSubmit_Click"
                            ValidationGroup="vgtemplate" />
                        <asp:Button ID="btnsubmitadd" Text="Create & Add" runat="server" OnClick="btnsubmitadd_Click"
                            ValidationGroup="vgtemplate" />
                        <asp:Button ID="btnclose" Text="Back" runat="server" OnClick="btnclose_Click" />
                    </div>
                    <div>
                        <asp:ValidationSummary ID="vstemplate" runat="server" ValidationGroup="vgtemplate"
                            Font-Bold="False" ShowSummary="False" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        function InsertTag(obj) {
            if (obj.value != '0') {
                document.getElementById("<%= TxtTagValue.ClientID %>").value = obj.value;
            }
            else {
                document.getElementById("<%= TxtTagValue.ClientID %>").value = "";
            }
        }
    </script>
</asp:Content>
