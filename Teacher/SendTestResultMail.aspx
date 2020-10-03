<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Epathshala.master" AutoEventWireup="true"
    CodeFile="SendTestResultMail.aspx.cs" Inherits="Teacher_SendTestResultMail" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit.HTMLEditor"
    TagPrefix="HTMLEditor" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="width: 80%; margin: auto;">
        <div class="activitydivside1">
            <div class="ActivityHeader">
                <span>Result Detail</span>
            </div>
            <div class="ActivityContent">
                <asp:GridView ID="gvstudentresult" runat="server" SkinID="WithoutPageSizeWithSort"
                    AutoGenerateColumns="False" OnRowDataBound="gvstudentresult_RowDataBound">
                    <Columns>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <input type="checkbox" id="chkAll" runat="server" onclick="javascript:checkAll(this);" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkSelect" runat="server" onclick="javascript:checkOne(this);"
                                    ToolTip='<%# Eval("EmailID") %>' />
                                <asp:HiddenField ID="hdnstudentID" runat="server" Value='<%# Eval("StudentID") %>' />
                                <asp:HiddenField ID="hdnEmailID" runat="server" Value='<%# Eval("EmailID") %>' />
                            </ItemTemplate>
                            <ItemStyle CssClass="GridViewRows" Width="5%" HorizontalAlign="Center" VerticalAlign="Top" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Name" SortExpression="FirstName">
                            <ItemTemplate>
                                <asp:Label ID="GV_LblStudentName" runat="server" Text='<%#Eval("StudentName") %>'
                                    ToolTip='<%# Eval("EmailID") %>' /></ItemTemplate>
                            <ItemStyle CssClass="GridViewRows" Width="15%" HorizontalAlign="Left" VerticalAlign="Top" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Email Address">
                            <ItemTemplate>
                                <asp:Label ID="GV_LblEmail" runat="server" Text='<%#Eval("EmailID") %>'></asp:Label></ItemTemplate>
                            <ItemStyle CssClass="GridViewRows" Width="20%" HorizontalAlign="Left" VerticalAlign="Top" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Right Answer">
                            <ItemTemplate>
                                <asp:Label ID="GV_LblRA" runat="server" Text='<%#Eval("RightAnswer") %>'></asp:Label></ItemTemplate>
                            <ItemStyle CssClass="GridViewRows" Width="15%" HorizontalAlign="Left" VerticalAlign="Top" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Wrong Answer">
                            <ItemTemplate>
                                <asp:Label ID="GV_LblWA" runat="server" Text='<%#Eval("WrongAnswer") %>'></asp:Label></ItemTemplate>
                            <ItemStyle CssClass="GridViewRows" Width="15%" HorizontalAlign="Left" VerticalAlign="Top" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Comment">
                            <ItemTemplate>
                                <asp:TextBox ID="GV_LblComment" runat="server" Width="90%"></asp:TextBox></ItemTemplate>
                            <ItemStyle CssClass="GridViewRows" Width="30%" HorizontalAlign="Center" VerticalAlign="Top" />
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                        <div style="text-align: center; color: black">
                            No Search Result Found</div>
                    </EmptyDataTemplate>
                </asp:GridView>
            </div>
        </div>
    </div>
    <div style="width: 80%; margin: auto; margin-top: 30px;">
        <div class="activitydivside1">
            <div class="ActivityHeader">
                <span>Mail Detail</span>
            </div>
            <div class="ActivityContent">
                <div class="dvmaildetail">
                    <div>
                        <span>Subject</span>
                    </div>
                    <div style="margin-top: 3px;">
                        <asp:TextBox runat="server" ID="txtsubject" Style="width: 100%; height: 25px;" />
                    </div>
                    <div style="margin-top: 8px;">
                        <span>Mail Body</span>
                    </div>
                    <div style="margin-top: 3px;">
                        <HTMLEditor:Editor ID="txtmail" runat="server" Height="460px" Width="100%" AutoFocus="false"
                            ClientIDMode="AutoID" />
                    </div>
                    <asp:UpdatePanel ID="upresult" runat="server" UpdateMode="Always">
                        <ContentTemplate>
                            <div style="margin-left: -5px; padding-top: 10px; text-align: center;">
                                <asp:Button ID="btnsendmail" Text="Send Mail" runat="server" OnClick="btnsendmail_Click"
                                    OnClientClick="javascript:return CheckAtleastOneTick();" />
                                <asp:Button ID="btnclose" Text="Cancel" runat="server" OnClick="btnclose_Click" />
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>
    <!--mail result start-->
    <asp:Button ID="btnresultopen" runat="server" Style="display: none" />
    <asp:Button ID="btnresultclose" runat="server" Style="display: none" />
    <cc1:ModalPopupExtender ID="mdlresult" runat="server" PopupControlID="tblresult"
        CancelControlID="btnresultclose" TargetControlID="btnresultopen" BackgroundCssClass="modalBackground"
        Enabled="True">
    </cc1:ModalPopupExtender>
    <div class="activitydivside1" id="tblresult" runat="server" style="margin-bottom: 5px;
        padding-bottom: 0px; width: 550px; margin: auto;">
        <div class="ActivityHeader">
            <span>Send mail report</span>
        </div>
        <div class="ActivityContent" style="margin-top: -10px; margin-bottom: 0px;">
            <div class="dvresult" style="max-height: 300px; overflow: auto;">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
                    <ContentTemplate>
                        <asp:GridView ID="gvresult" runat="server" SkinID="GridforReport" Style="margin-top: 15px;
                            margin-bottom: 15px;">
                            <EmptyDataTemplate>
                            </EmptyDataTemplate>
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div style="text-align: center; margin-bottom: 10px;">
                <asp:Button ID="Button1" runat="server" Text="Close" OnClientClick="javascript:return closeresultpopup();" />
            </div>
        </div>
    </div>
    <!--mail result end-->
    <!-- LoaderPart start-->
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
    <!-- LoaderPart end-->
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
        function checkAll(CheckBox) {
            try {
                if (CheckBox.checked == true) {
                    var TargetBaseControl = document.getElementById('<%= gvstudentresult.ClientID %>');
                    var Inputs = TargetBaseControl.getElementsByTagName("input");
                    for (var n = 0; n < Inputs.length; ++n) {
                        var headerCheckBox = Inputs[0];
                        if (Inputs[n].type == 'checkbox' && Inputs[n] != headerCheckBox && Inputs[n].disabled == false) {
                            Inputs[n].checked = true;
                        }
                    }
                }
                else {
                    var TargetBaseControl = document.getElementById('<%= gvstudentresult.ClientID %>');
                    var Inputs = TargetBaseControl.getElementsByTagName("input");
                    for (var n = 0; n < Inputs.length; ++n) {
                        var headerCheckBox = Inputs[0];
                        if (Inputs[n].type == 'checkbox' && Inputs[n] != headerCheckBox && Inputs[n].disabled == false) {
                            Inputs[n].checked = false;
                        }
                    }
                }
            }
            catch (e) {
                alert("Error");
            }
        }
        function checkOne(CheckBox) {
            var checked = true;
            var TargetBaseControl = document.getElementById('<%= gvstudentresult.ClientID %>');
            var Inputs = TargetBaseControl.getElementsByTagName("input");
            for (var n = 0; n < Inputs.length; ++n) {
                var headerCheckBox = Inputs[0];
                if (Inputs[n].type == 'checkbox' && Inputs[n] != headerCheckBox && Inputs[n].disabled == false) {
                    if (Inputs[n].checked == false) {
                        checked = false;
                        break;
                    }
                }
            }
            headerCheckBox.checked = checked;
        }
        function CheckAtleastOneTick() {
            var TargetBaseControl = document.getElementById('<%= gvstudentresult.ClientID %>');
            var AllTick = false;
            var Inputs = TargetBaseControl.getElementsByTagName("input");
            for (var n = 0; n < Inputs.length; ++n) {
                var headerCheckBox = Inputs[0];
                if (Inputs[n].type == 'checkbox' && Inputs[n] != headerCheckBox)
                    if (Inputs[n].checked == true) {
                        AllTick = true;
                        break;
                    }
            }
            if (AllTick == false) {
                alert("Please select atleast one record for process.");
                return false;
            }
            else {
                return true;
            }
        }
        function closeresultpopup() {
            if ($("#<%= btnresultclose.ClientID%>") != null) {
                $("#<%= btnresultclose.ClientID%>").click();
            }
            return false;
        }
    </script>
</asp:Content>
