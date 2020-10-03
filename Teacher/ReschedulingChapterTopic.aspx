<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Epathshala.master" AutoEventWireup="true"
    CodeFile="ReschedulingChapterTopic.aspx.cs" Inherits="Teacher_ReschedulingChapterTopic"
    Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/UserControl/NewTeacherPanel.ascx" TagName="TeacherPanel" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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
                    <asp:Label ID="LblRescheduling" runat="server" Text="Rescheduling Chapter Topic"
                        meta:resourcekey="LblReschedulingResource1"></asp:Label>
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
                                        meta:resourcekey="ddlTopicResource1">
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
                    <div class="gobotton" style="width: 80%;">
                        <asp:Button ID="BtnSubmit" Text="Submit" runat="server" ValidationGroup="PnlBMS1"
                            OnClick="BtnSubmit_Click" meta:resourcekey="BtnSubmitResource1" />
                        <asp:Button ID="btnReset" runat="server" Text="Reset" CausesValidation="False" OnClick="btnReset_Click"
                            meta:resourcekey="btnResetResource1" />
                        <asp:ValidationSummary ID="VSPnlBMS" runat="server" ValidationGroup="PnlBMS1" ShowMessageBox="True"
                            ShowSummary="False" meta:resourcekey="VSPnlBMSResource1" />
                    </div>
                    <div>
                        <asp:Label ID="lblMonthYear" runat="server" Text="MonthYear:" CssClass="textlabel"
                            meta:resourcekey="lblMonthYearResource1"></asp:Label>
                        <asp:DropDownList ID="ddlMonthYear" runat="server" Width="215px" AutoPostBack="True"
                            OnSelectedIndexChanged="ddlMonthYear_SelectedIndexChanged" meta:resourcekey="ddlMonthYearResource1">
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
        </div>
        <div class="firstpanel">
            <div class="activitydivside1">
                <div class="ActivityHeader">
                    <asp:Label ID="Label1" runat="server" Text="Rescheduling Requested List"></asp:Label>
                </div>
                <div class="ActivityContent">
                    <asp:GridView ID="grvReschedulingData" runat="server" AutoGenerateColumns="False"
                        DataKeyNames="ReSchedulingID,BMSSCTID,ChapterID,TopicID" EmptyDataText="Chapter Topic Not Available."
                        meta:resourcekey="grvReschedulingDataResource1" OnSorting="grvReschedulingData_Sorting">
                        <%--  <HeaderStyle CssClass="GridViewHeadercss" />
                                <RowStyle CssClass="GridViewItem" />--%>
                        <Columns>
                            <asp:TemplateField HeaderText="Sr No." meta:resourcekey="TemplateFieldResource1"
                                SortExpression="Sr No.">
                                <ItemTemplate>
                                    <%# ((GridViewRow)Container).RowIndex + 1%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Chapter" HeaderText="Chapter" meta:resourcekey="BoundFieldResource1"
                                SortExpression="Chapter" />
                            <asp:BoundField DataField="Topic" HeaderText="Topic" meta:resourcekey="BoundFieldResource2"
                                SortExpression="Topic" />
                            <asp:BoundField DataField="AppliedDate" HeaderText="Applied Date" meta:resourcekey="BoundFieldResource3"
                                SortExpression="AppliedDate" />
                            <asp:BoundField DataField="Status" HeaderText="Status" meta:resourcekey="BoundFieldResource4"
                                SortExpression="Status" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
    <%--</ContentTemplate>
    <triggers>
            <asp:AsyncPostBackTrigger ControlID="TeacherPanel1" />
        </triggers>
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
