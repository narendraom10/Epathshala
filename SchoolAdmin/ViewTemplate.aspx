<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Epathshala.master" AutoEventWireup="true"
    CodeFile="ViewTemplate.aspx.cs" Inherits="SchoolAdmin_ViewTemplate" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit.HTMLEditor"
    TagPrefix="HTMLEditor" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .ajax__htmleditor_editor_editpanel
        {
            padding: 5px;
        }
        .ajax__htmleditor_editor_bottomtoolbar
        {
            display: none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="width: 80%; margin: auto">
        <div class="activitydivside1" id="Div1" runat="server" style="margin-bottom: 5px;
            padding-bottom: 0px">
            <div class="ActivityHeader">
                <asp:Label ID="lblTitle" runat="server" Text="View Template"></asp:Label>
            </div>
            <div class="ActivityContent" style="margin-top: 10px;">
                <div class="dvmaildetail">
                    <div class="dvsmallheader">
                        <span>Template</span>
                    </div>
                    <div>
                        <asp:TextBox runat="server" ID="txttitle" Style="width: 98.5%; height: 25px; border: 2px solid #e5e5e5;
                            padding: 4px" MaxLength="100" />
                    </div>
                    <div class="dvsmallheader" style="margin-top: 15px;">
                        <span>Mail Subject</span>
                    </div>
                    <div>
                        <asp:TextBox runat="server" ID="txtsubject" Style="width: 99%; height: 25px; border: 2px solid #e5e5e5;
                            padding: 4px" MaxLength="100" />
                    </div>
                    <div class="dvsmallheader" style="margin-top: 15px;">
                        <span>Mail Body</span>
                    </div>
                    <div>
                        <HTMLEditor:Editor ID="txtmail" runat="server" Height="460px" Width="100%" AutoFocus="false"
                            ClientIDMode="AutoID" />
                    </div>
                    <div style="margin-left: -4px; padding-top: 13px; padding-bottom: 10px;">
                        <asp:Button ID="btnBack" Text="Back" runat="server" OnClick="btnBack_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
