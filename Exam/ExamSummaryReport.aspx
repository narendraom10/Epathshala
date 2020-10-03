<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Epathshala.master" AutoEventWireup="true"
    CodeFile="ExamSummaryReport.aspx.cs" Inherits="Exam_ExamSummaryReort" Culture="auto"
    meta:resourcekey="PageResource1" UICulture="auto" %>

<%@ Register Src="~/UserControl/NewTeacherPanel.ascx" TagName="TeacherPanel" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .gobutton
        {
            height: 26px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="tblDashboard">
        <div class="firstpanel">
            <div>
                <uc1:TeacherPanel ID="TeacherPanel1" runat="server" />
            </div>
            <div class="activitydiv activityright">
                <div class="ActivityHeader">
                    <asp:Label ID="LblExamEntry" runat="server" Text="Summary Report" meta:resourcekey="LblExamEntryResource1"></asp:Label>
                </div>
                <div class="ActivityContent">
                    <div>
                        <asp:Label ID="LblChapter" runat="server" Text="Chapter:" CssClass="textlabel" meta:resourcekey="LblChapterResource1"></asp:Label>
                        <asp:DropDownList ID="ddlChapter" runat="server" Width="215px" Enabled="False" AutoPostBack="True"
                            OnSelectedIndexChanged="ddlChapter_SelectedIndexChanged" meta:resourcekey="ddlChapterResource1">
                            <asp:ListItem Text="-- Select --" meta:resourcekey="ListItemResource1"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RFVDdlChapter" runat="server" ControlToValidate="DdlChapter"
                            InitialValue="-- Select --" ErrorMessage="Please Select Chapter." ValidationGroup="PnlBMS1"
                            meta:resourcekey="RFVDdlChapterResource1">*</asp:RequiredFieldValidator>
                    </div>
                    <div>
                        <asp:Label ID="LblTopic" runat="server" Text="Topic:" CssClass="textlabel" meta:resourcekey="LblTopicResource1"></asp:Label>
                        <asp:DropDownList ID="ddlTopic" runat="server" Width="215px" Enabled="False" meta:resourcekey="ddlTopicResource1">
                            <asp:ListItem Text="-- Select --" meta:resourcekey="ListItemResource2"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RFVDdlTopic" runat="server" ControlToValidate="DdlTopic"
                            InitialValue="-- Select --" ErrorMessage="Please Select Topic." ValidationGroup="PnlBMS1"
                            meta:resourcekey="RFVDdlTopicResource1">*</asp:RequiredFieldValidator>
                    </div>
                    <div class="gobotton">
                        <asp:Button ID="BtnResult" Text="Show Result" runat="server" CssClass="gobutton"
                            ValidationGroup="PnlBMS1" OnClick="BtnSubmit_Click" meta:resourcekey="BtnResultResource1" />
                        <asp:Button ID="btnReset" runat="server" CssClass="gobutton" Text="Reset" CausesValidation="False"
                            OnClick="btnReset_Click" meta:resourcekey="btnResetResource1" />
                    </div>
                    <asp:ValidationSummary ID="VSPnlBMS" runat="server" ValidationGroup="PnlBMS1" ShowMessageBox="True"
                        ShowSummary="False" meta:resourcekey="VSPnlBMSResource1" />
                </div>
            </div>
        </div>
        <div class="firstpanel">
            <div class="activitydivside1">
                <div class="ActivityHeader">
                    <asp:Label ID="Label1" runat="server" Text="Report List"></asp:Label>
                </div>
                <div class="ActivityContent">
                    <asp:GridView ID="GridStudentList" runat="server" SkinID="GridforReport" meta:resourcekey="GridStudentListResource1">
                    </asp:GridView>
                </div>
                <div style="width: 100px; margin: auto;">
                    <asp:Button ID="BtnPDF" Text="PDF View" runat="server" CssClass="gobutton" ValidationGroup="GridValidation"
                        Visible="False" OnClick="BtnPDF_Click" meta:resourcekey="BtnPDFResource1" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
