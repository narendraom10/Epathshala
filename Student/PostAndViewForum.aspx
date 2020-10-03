<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Epathshala.master" AutoEventWireup="true"
    CodeFile="PostAndViewForum.aspx.cs" Inherits="Student_PostAndViewForum" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .pblock
        {
            width: 800px;
            list-style-type: none;
            margin: 0 auto;
            padding: 5px;
            margin-bottom: 10px;
            border: 1px solid #cccccc;
            border-radius: 5px;
        }
        .pblock .pdetail
        {
            padding: 5px 5px 15px 5px;
        }
        .pblock .rdetail
        {
            -moz-border-radius: 5px;
            border-radius: 5px;
            webkit-border-radius: 5px;
            border: 1px solid #c3ccdf;
            padding-left: 20px;
            background-color: #FFF;
            margin-left: 20px;
            width: 760px;
            padding: 10px 0px 15px 10px;
            margin-bottom: 10px;
            display: block;
        }
        .bydetail
        {
            border: 1px solid #cccccc;
            border-radius: 5px;
            background-color: #dddddd;
            display: inline-block;
            padding: 4px;
            margin-left: 10px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="width: 80%; margin: auto;">
        <div class="activitydivside1">
            <div class="ActivityHeader">
                <asp:Label runat="server" Text="Post Forum"></asp:Label>
                <div>
                    <asp:ValidationSummary ID="Vlsgpost" ValidationGroup="Vgpost" runat="server" Font-Bold="False"
                        ShowMessageBox="True" ShowSummary="False" />
                </div>
            </div>
            <div class="ActivityContent" style="text-align: center;">
                <textarea id="TxtForum" runat="server" rows="5" cols="100" style="min-width: 400px;
                    max-width: 400px; padding: 5px;"></textarea>
                <asp:RequiredFieldValidator ID="RqdForum" runat="server" ControlToValidate="TxtForum"
                    ErrorMessage="Please enter post text." ValidationGroup="Vgpost">*</asp:RequiredFieldValidator>
                <div style="display: inline-block; vertical-align: bottom;">
                    <asp:Button ID="btnpost" Text="Post" runat="server" OnClick="btnpost_Click" ValidationGroup="Vgpost" />
                </div>
            </div>
        </div>
        <div class="activitydivside1" style="margin-top: 15px;">
            <div class="ActivityHeader">
                <asp:Label runat="server" Text="View Forum"></asp:Label>
            </div>
            <div class="ActivityContent" style="background-color: #e7ebf2 !important;">
                <asp:GridView ID="GvPost" AutoGenerateColumns="true" runat="server" ShowHeader="false"
                    BackColor="#e7ebf2">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <div class="pblock">
                                    <div class="pdetail">
                                        <p>
                                            <asp:Label ID="Label3" Text='<%# Eval("Forum") %>' runat="server" />
                                            <span class="bydetail">Post On
                                                <asp:Label ID="Label1" Text='<%# Eval("PostedOn") %>' runat="server" />
                                                By
                                                <asp:Label ID="Label2" Text='<%# Eval("PostedBy") %>' runat="server" />
                                            </span>
                                        </p>
                                        <div style="display: inline-block; float: right;">
                                        </div>
                                    </div>
                                    <div class="rdetail">
                                        <asp:Label ID="Label4" Text='<%# Eval("Forum") %>' runat="server" />
                                        <span class="bydetail">Reply On
                                            <asp:Label ID="Label5" Text='<%# Eval("PostedOn") %>' runat="server" />
                                            By
                                            <asp:Label ID="Label6" Text='<%# Eval("PostedBy") %>' runat="server" />
                                        </span>
                                        <div style="display: block; float: right;">
                                            <asp:Button Text="My Reply" runat="server" />
                                        </div>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
