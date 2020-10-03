<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Epathshala.master" AutoEventWireup="true"
    CodeFile="ResultEntry.aspx.cs" Inherits="Exam_ResultEntry" Culture="auto" meta:resourcekey="PageResource1"
    UICulture="auto" %>

<%@ Register Src="~/UserControl/NewTeacherPanel.ascx" TagName="TeacherPanel" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="tblDashboard">
        <div class="firstpanel">
            <div>
                <uc1:TeacherPanel ID="TeacherPanel1" runat="server" />
            </div>
            <div class="activityright activitydiv">
                <div class="ActivityHeader">
                    <asp:Label ID="LblExamResultEntry" runat="server" Text="Exam result entry " meta:resourcekey="LblExamResultEntryResource1"></asp:Label>
                </div>
                <div class="ActivityContent">
                    <asp:UpdatePanel runat="server" ID="upTopics" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div>
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
                                    <asp:DropDownList ID="ddlTopic" runat="server" Width="215px" Enabled="False" AutoPostBack="True"
                                        OnSelectedIndexChanged="ddlTopic_SelectedIndexChanged" meta:resourcekey="ddlTopicResource1">
                                        <asp:ListItem Text="-- Select --" meta:resourcekey="ListItemResource2"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RFVDdlTopic" runat="server" ControlToValidate="DdlTopic"
                                        InitialValue="-- Select --" ErrorMessage="Please Select Topic." ValidationGroup="PnlBMS1"
                                        meta:resourcekey="RFVDdlTopicResource1">*</asp:RequiredFieldValidator>
                                </div>
                                <div>
                                    <asp:Label ID="lblExam" runat="server" Text="Exam Name:" CssClass="textlabel" meta:resourcekey="lblExamResource1"></asp:Label>
                                    <asp:DropDownList ID="ddlExam" runat="server" Width="215px" Enabled="False" AutoPostBack="True"
                                        OnSelectedIndexChanged="ddlExam_SelectedIndexChanged" meta:resourcekey="ddlExamResource1">
                                        <asp:ListItem Text="-- Select --" meta:resourcekey="ListItemResource3"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvddlExam" runat="server" ControlToValidate="ddlExam"
                                        InitialValue="-- Select --" ErrorMessage="Please Select Exam name." ValidationGroup="PnlBMS1"
                                        meta:resourcekey="rfvddlExamResource1">*</asp:RequiredFieldValidator>
                                </div>
                                <div>
                                    <asp:Label ID="lblTotalQuestions" runat="server" Text="Total Questions:" CssClass="textlabel"
                                        meta:resourcekey="lblTotalQuestionsResource1"></asp:Label>
                                    <asp:TextBox ID="TxtTotalQuestions" runat="server" CssClass="inntextbox" Enabled="False"
                                        meta:resourcekey="TxtTotalQuestionsResource1"></asp:TextBox>
                                </div>
                                <div>
                                    <asp:Label ID="lblTotalMarks" runat="server" Text="Total Marks:" CssClass="textlabel"
                                        meta:resourcekey="lblTotalMarksResource1"></asp:Label>
                                    <asp:TextBox ID="TxtTotalMarks" runat="server" CssClass="inntextbox" Enabled="False"
                                        meta:resourcekey="TxtTotalMarksResource1"></asp:TextBox>
                                </div>
                            </div>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="ddlChapter" />
                        </Triggers>
                    </asp:UpdatePanel>
                    <div class="gobotton">
                        <asp:Button ID="BtnSubmit" Text="Enter Result" runat="server" CssClass="gobutton"
                            ValidationGroup="PnlBMS1" OnClick="BtnSubmit_Click" meta:resourcekey="BtnSubmitResource1" />
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
                    Result List
                </div>
                <div class="ActivityContent">
                    <asp:GridView ID="GridStudentList" DataKeyNames="StudentID,RollNo" runat="server"
                        Visible="False" SkinID="WithoutPageSize" AutoGenerateColumns="False" meta:resourcekey="GridStudentListResource1">
                        <Columns>
                            <asp:BoundField DataField="RollNo" HeaderText="Roll No" meta:resourcekey="BoundFieldResource1" />
                            <asp:BoundField DataField="StudentName" HeaderText=" Student Name" meta:resourcekey="BoundFieldResource2" />
                            <%--<asp:TemplateField HeaderText="TotalMarks" SortExpression="TotalMarks" Visible="false">
                                        <ItemTemplate>
                                            <asp:TextBox ID="TxtTotalMarks" runat="server" Text='<%# Bind("TotalMarks") %>' Width="100px"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                            <asp:TemplateField HeaderText="Right Answers" SortExpression="Right" meta:resourcekey="TemplateFieldResource1">
                                <ItemTemplate>
                                    <asp:TextBox ID="TxtRightMarks" runat="server" Text='<%# Bind("Right") %>' Width="100px"
                                        meta:resourcekey="TxtRightMarksResource1"></asp:TextBox>
                                  <%--  <asp:RequiredFieldValidator ID="RFVTxtRightMarks" runat="server" ControlToValidate="TxtRightMarks"
                                        InitialValue="0" Display="None" ErrorMessage="Please Enter Right Marks." ValidationGroup="GridValidation"
                                        meta:resourcekey="RFVTxtRightMarksResource1" />--%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Wrong Answers" SortExpression="Worng" meta:resourcekey="TemplateFieldResource2">
                                <ItemTemplate>
                                    <asp:TextBox ID="TxtWorngMarks" runat="server" Text='<%# Bind("Worng") %>' Width="100px"
                                        Enabled="False" meta:resourcekey="TxtWorngMarksResource1"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RFVTxtWorngMarks" runat="server" ControlToValidate="TxtWorngMarks"
                                        Display="None" ErrorMessage="Please Enter Worng Marks." ValidationGroup="GridValidation"
                                        meta:resourcekey="RFVTxtWorngMarksResource1" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
                <div style="width: 220px; margin: auto;">
                    <asp:Button ID="btnSave" Text="Save Result" runat="server" CssClass="gobutton" ValidationGroup="GridValidation"
                        Visible="False" OnClick="btnSave_Click" meta:resourcekey="btnSaveResource1" />
                    <asp:Button ID="BtnPDF" Text="PDF View" runat="server" CssClass="gobutton" ValidationGroup="GridValidation"
                        Visible="False" OnClick="BtnPDF_Click" meta:resourcekey="BtnPDFResource1" />
                </div>
                <asp:ValidationSummary ID="VSGridValidation" runat="server" ValidationGroup="GridValidation"
                    ShowMessageBox="True" ShowSummary="False" meta:resourcekey="VSGridValidationResource1" />
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
    </script>
</asp:Content>
