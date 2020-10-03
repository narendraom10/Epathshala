<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Epathshala.master" AutoEventWireup="true"
    CodeFile="ExamEntry.aspx.cs" Inherits="Exam_ExamEntry" Culture="auto" meta:resourcekey="PageResource1"
    UICulture="auto" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/UserControl/NewTeacherPanel.ascx" TagName="TeacherPanel" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .gobutton
        {
            width: 50px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--<asp:UpdatePanel runat="server" ID="upMain" UpdateMode="Conditional">
        <ContentTemplate>--%>
            <div class="tblDashboard">
                <div class="firstpanel">
                    <div>
                        <uc1:TeacherPanel ID="TeacherPanel1" runat="server" />
                    </div>
                    <div class="activityright activitydiv">
                        <div class="ActivityHeader">
                            <asp:Label ID="LblExamEntry" runat="server" Text="Exam Entry " meta:resourcekey="LblExamEntryResource1"></asp:Label>
                        </div>
                        <div class="ActivityContent">
                            <asp:UpdatePanel runat="server" ID="UpdatePanel1" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <div>
                                        <div class="inputdiv">
                                            <asp:Label ID="LblChapter" runat="server" Text="Chapter:" CssClass="textlabel" meta:resourcekey="LblChapterResource1"></asp:Label>
                                            <asp:DropDownList ID="ddlChapter" runat="server" Width="215px" Enabled="False" AutoPostBack="True"
                                                OnSelectedIndexChanged="ddlChapter_SelectedIndexChanged" meta:resourcekey="ddlChapterResource1">
                                                <asp:ListItem Text="-- Select --" meta:resourcekey="ListItemResource1"></asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RFVDdlChapter" runat="server" ControlToValidate="DdlChapter"
                                                InitialValue="-- Select --" ErrorMessage="Please Select Chapter." ValidationGroup="PnlBMS1"
                                                meta:resourcekey="RFVDdlChapterResource1">*</asp:RequiredFieldValidator>
                                        </div>
                                        <div class="inputdiv">
                                            <asp:Label ID="LblTopic" runat="server" Text="Topic:" CssClass="textlabel" meta:resourcekey="LblTopicResource1"></asp:Label>
                                            <asp:DropDownList ID="ddlTopic" runat="server" Width="215px" Enabled="False" meta:resourcekey="ddlTopicResource1">
                                                <asp:ListItem Text="-- Select --" meta:resourcekey="ListItemResource2"></asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RFVDdlTopic" runat="server" ControlToValidate="DdlTopic"
                                                InitialValue="-- Select --" ErrorMessage="Please Select Topic." ValidationGroup="PnlBMS1"
                                                meta:resourcekey="RFVDdlTopicResource1">*</asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddlChapter" />
                                </Triggers>
                            </asp:UpdatePanel>
                            <div class="inputdiv">
                                <asp:Label ID="LblExamName" runat="server" Text="Exam Name:" CssClass="textlabel"
                                    meta:resourcekey="LblExamNameResource1"></asp:Label>
                                <asp:TextBox ID="TxtExamName" runat="server" CssClass="inntextbox" meta:resourcekey="TxtExamNameResource1"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvTxtExamName" runat="server" ControlToValidate="TxtExamName"
                                    ErrorMessage="Please Enter Exam Name." ValidationGroup="PnlBMS1" meta:resourcekey="rfvTxtExamNameResource1">*</asp:RequiredFieldValidator>
                            </div>
                            <div class="inputdiv">
                                <asp:Label ID="lblTotalQuestions" runat="server" Text="Total Questions:" CssClass="textlabel"
                                    meta:resourcekey="lblTotalQuestionsResource1"></asp:Label>
                                <asp:TextBox ID="TxtTotalQuestions" runat="server" CssClass="inntextbox" meta:resourcekey="TxtTotalQuestionsResource1"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="frvTotalQuestions" runat="server" ControlToValidate="TxtTotalQuestions"
                                    ErrorMessage="Please Enter Total Questions." ValidationGroup="PnlBMS1" meta:resourcekey="frvTotalQuestionsResource1">*</asp:RequiredFieldValidator>
                            </div>
                            <div class="inputdiv">
                                <asp:Label ID="lblTotalMarks" runat="server" Text="Total Marks:" CssClass="textlabel"
                                    meta:resourcekey="lblTotalMarksResource1"></asp:Label>
                                <asp:TextBox ID="TxtTotalMarks" runat="server" CssClass="inntextbox" meta:resourcekey="TxtTotalMarksResource1"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvTotalMarks" runat="server" ControlToValidate="TxtTotalMarks"
                                    ErrorMessage="Please Enter Total Marks." ValidationGroup="PnlBMS1" meta:resourcekey="rfvTotalMarksResource1">*</asp:RequiredFieldValidator>
                            </div>
                            <div>
                                <asp:Button ID="BtnSubmit" Text="Submit" runat="server" CssClass="gobutton" ValidationGroup="PnlBMS1"
                                    OnClick="BtnSubmit_Click" meta:resourcekey="BtnSubmitResource1" />
                                <asp:Button ID="btnReset" runat="server" CssClass="gobutton" Text="Reset" CausesValidation="False"
                                    OnClick="btnReset_Click" meta:resourcekey="btnResetResource1" />
                            </div>
                        </div>
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="PnlBMS1"
                            ShowMessageBox="True" ShowSummary="False" meta:resourcekey="VSPnlBMSResource1" />
                    </div>
                </div>
            </div>
     <%--   </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="TeacherPanel1" />
        </Triggers>
    </asp:UpdatePanel>--%>
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
    </script>
</asp:Content>
