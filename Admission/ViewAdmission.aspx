<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Epathshala.master" AutoEventWireup="true"
    CodeFile="ViewAdmission.aspx.cs" Inherits="Admission_ViewAdmission" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        /*Calendar Related Start*/
        .ajax__calendar
        {
            z-index: 100001 !important;
        }
        /*Calendar Related End*/
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../App_Themes/Responsive/Calender/CSS.css" rel="stylesheet" type="text/css" />
    <script src="../App_Themes/Responsive/Calender/Extension.min.js" type="text/javascript"></script>
    <asp:UpdatePanel runat="server" ID="UpAdmission" UpdateMode="Always">
        <ContentTemplate>
            <div style="width: 80%; margin: auto; margin-top: 30px;">
                <div class="activitydivside1" id="SecondRpt" runat="server" visible="true">
                    <div class="ActivityHeader">
                        <asp:Label ID="LblTitle" runat="server" Text="Manage Admission"></asp:Label>
                    </div>
                    <div class="ActivityContent">
                        <asp:GridView ID="GvAdmission" runat="server" DataKeyNames="AdmissionId,AdmissionStatus"
                            OnSorting="GvAdmission_Sorting" OnPageIndexChanging="GvAdmission_PageIndexChanging"
                            OnRowCreated="GvAdmission_RowCreated" meta:resourcekey="GvUserListResource1"
                            AutoGenerateColumns="False" OnRowDataBound="GvAdmission_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="SNo.">
                                    <ItemTemplate>
                                        <asp:Label ID="LblSrNo" runat="server" Text='<%# Container.DataItemIndex+1 %>' /></ItemTemplate>
                                    <ItemStyle CssClass="GridViewRows" Width="5%" HorizontalAlign="Center" VerticalAlign="Top" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Form No" SortExpression="FormNo">
                                    <ItemTemplate>
                                        <asp:Label ID="LblFormNo" runat="server" Text='<%#Eval("FormNo") %>' /></ItemTemplate>
                                    <ItemStyle CssClass="GridViewRows" Width="10%" HorizontalAlign="Left" VerticalAlign="Top" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Admission Grade" SortExpression="AdmissionGrade">
                                    <ItemTemplate>
                                        <asp:Label ID="LblAdmissionGrade" runat="server" Text='<%#Eval("AdmissionGrade") %>' /></ItemTemplate>
                                    <ItemStyle CssClass="GridViewRows" Width="20%" HorizontalAlign="Left" VerticalAlign="Top" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Student Name">
                                    <ItemTemplate>
                                        <asp:Label ID="LblStudentName" runat="server" Text='<%#Eval("FirstName") %>' /></ItemTemplate>
                                    <ItemStyle CssClass="GridViewRows" Width="13%" HorizontalAlign="Left" VerticalAlign="Top" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Emergency Mobile Number">
                                    <ItemTemplate>
                                        <asp:Label ID="LblEmergencyMobileNumber" runat="server" Text='<%#Eval("EmergencyMobileNo") %>' /></ItemTemplate>
                                    <ItemStyle CssClass="GridViewRows" Width="15%" HorizontalAlign="Left" VerticalAlign="Top" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Communication Email">
                                    <ItemTemplate>
                                        <asp:Label ID="LblCommunicationEmail" runat="server" Text='<%#Eval("CommunicationEmail") %>' /></ItemTemplate>
                                    <ItemStyle CssClass="GridViewRows" Width="15%" HorizontalAlign="Left" VerticalAlign="Top" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Admission Status" SortExpression="AdmissionStatus">
                                    <ItemTemplate>
                                        <asp:Label ID="LblAdmissionStatus" runat="server" Text='<%#Eval("AdmissionStatus") %>' /></ItemTemplate>
                                    <ItemStyle CssClass="GridViewRows" Width="10%" HorizontalAlign="Left" VerticalAlign="Top" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Action">
                                    <ItemTemplate>
                                        <div id="dvSend" runat="server" style="display: inline-block; padding-top: 5px;">
                                            <a style="cursor: pointer; text-decoration: none;" title="Send Interaction Slip"
                                                onclick="javascript:return ShowInteractionPopup('<%#Eval("AdmissionId") %>','Interaction','<%#Eval("CommunicationEmail") %>');">
                                                <asp:Image ID="Image3" ImageUrl="~/App_Themes/Responsive/web/Interaction.png" runat="server"
                                                    Width="22px" />&nbsp; </a>
                                        </div>
                                        <div id="dvconfirm" runat="server" style="display: inline-block; vertical-align: top;
                                            padding-top: 5px;">
                                            <a style="cursor: pointer; text-decoration: none;" title="Admission Confirm" onclick="javascript:return ShowInteractionPopup('<%#Eval("AdmissionId") %>','confirm','<%#Eval("CommunicationEmail") %>');">
                                                <asp:Image ID="Image1" ImageUrl="~/App_Themes/Responsive/web/confirm.png" runat="server"
                                                    Width="20px" />
                                            </a><a style="cursor: pointer; text-decoration: none;" title="Admission Onhold" onclick="javascript:return ShowInteractionPopup('<%#Eval("AdmissionId") %>','onhold','<%#Eval("CommunicationEmail") %>');">
                                                <asp:Image ID="Image2" ImageUrl="~/App_Themes/Responsive/web/onhold.png" runat="server"
                                                    Width="20px" />
                                            </a><a style="cursor: pointer; text-decoration: none;" title="Admission Reject" onclick="javascript:return ShowInteractionPopup('<%#Eval("AdmissionId") %>','reject','<%#Eval("CommunicationEmail") %>');">
                                                <asp:Image ID="Image4" ImageUrl="~/App_Themes/Responsive/web/reject.png" runat="server"
                                                    Width="20px" />
                                            </a>
                                        </div>
                                    </ItemTemplate>
                                    <ItemStyle CssClass="GridViewRows" Width="12%" HorizontalAlign="Center" VerticalAlign="Top" />
                                </asp:TemplateField>
                            </Columns>
                            <PagerTemplate>
                                <asp:ImageButton Text="First" CommandName="Page" CommandArgument="First" runat="server"
                                    ImageUrl="~/App_Themes/Responsive/web/first.png" ID="ibtnFirst" ToolTip="Move First Page"
                                    meta:resourcekey="btnFirstResource1" CssClass="playbtn" />
                                <asp:ImageButton Text="Previous" CommandName="Page" CommandArgument="Prev" runat="server"
                                    ImageUrl="~/App_Themes/Responsive/web/previous.png" ID="ibtnPrevious" ToolTip="Move Previous Page"
                                    meta:resourcekey="btnPreviousResource1" CssClass="playbtn" />
                                <asp:Label ID="LblPage" runat="server" Text="Page" ForeColor="Black" meta:resourcekey="LblPageResource1"></asp:Label>
                                <asp:DropDownList ID="ddlPageSelector" OnSelectedIndexChanged="ddlPageSelector_SelectedIndexChanged"
                                    runat="server" AutoPostBack="True" SkinID="DdlWidth50" meta:resourcekey="ddlPageSelectorResource1">
                                </asp:DropDownList>
                                <asp:ImageButton Text="Next" CommandName="Page" CommandArgument="Next" runat="server"
                                    ImageUrl="~/App_Themes/Responsive/web/NEXT.png" ID="ibtnNext" ToolTip="Move Next Page"
                                    meta:resourcekey="btnNextResource1" CssClass="playbtn" />
                                <asp:ImageButton Text="Last" CommandName="Page" CommandArgument="Last" runat="server"
                                    ImageUrl="~/App_Themes/Responsive/web/last.png" ID="ibtnLast" ToolTip="Move Last Page"
                                    meta:resourcekey="btnLastResource1" CssClass="playbtn" />
                            </PagerTemplate>
                        </asp:GridView>
                    </div>
                </div>
                <asp:HiddenField ID="hdnAdmissionID" runat="server" />
                <asp:HiddenField ID="hdnAdmissionStatus" runat="server" />
                <asp:HiddenField ID="hdnEmailID" runat="server" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <!--Send Interaction Slip-->
    <asp:Button ID="BtnShowInteractionPopup" runat="server" Text="Show" Style="display: none" />
    <asp:Button ID="BtnCancelInteractionPopup" runat="server" Text="Close" Style="display: none" />
    <cc1:ModalPopupExtender ID="MdlInteractionSleep" runat="server" PopupControlID="PnlInteractionSleep"
        TargetControlID="BtnShowInteractionPopup" BackgroundCssClass="modalBackground"
        CancelControlID="BtnCancelInteractionPopup">
    </cc1:ModalPopupExtender>
    <asp:Panel ID="PnlInteractionSleep" runat="server" Style="display: none;">
        <div class="activitydivfull" style="width: 560px; box-shadow: 0 0 4px #000">
            <div class="ActivityHeader">
                <asp:Label ID="lblactionTitle" runat="server" Text=""></asp:Label>
            </div>
            <div class="ActivityContent">
                <div style="margin-top: 15px; max-height: 350px; overflow: auto;">
                    <table id="TblInteraction" runat="server" border="0" cellpadding="0" cellspacing="0"
                        style="width: 90%;">
                        <tr>
                            <td style="width: 30%; text-align: right; padding: 10px;">
                                <asp:Label ID="LblDate" runat="server" Text="Date:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TxtDate" runat="server" MaxLength="50" CssClass="disable_past_dates controllabel"
                                    Width="150px"></asp:TextBox>
                                <div style="padding: 2px; background-color: #444; width: 20px; height: 20px; display: inline-block;
                                    margin-left: 4px; border-radius: 4px;">
                                    <asp:ImageButton ID="ibtnCalender" runat="server" ImageUrl="~/App_Themes/Responsive/web/Calender.png"
                                        Width="20px" />
                                </div>
                                &nbsp;<asp:RequiredFieldValidator ID="RqdDate" runat="server" ControlToValidate="TxtDate"
                                    ErrorMessage="Please enter interaction date" ValidationGroup="VgInteraction">*</asp:RequiredFieldValidator>
                                &nbsp;<asp:RegularExpressionValidator ID="RevDate" runat="server" ControlToValidate="TxtDate"
                                    ErrorMessage="Please enter interaction date in dd-MMM-yyyy Format." ValidationGroup="VgInteraction"
                                    ValidationExpression="^(([0-9])|([0-2][0-9])|([3][0-1]))\-(Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec)\-\d{4}$">*</asp:RegularExpressionValidator>
                                <cc1:CalendarExtender ID="CalDate" runat="server" TargetControlID="TxtDate" PopupButtonID="ibtnCalender"
                                    Enabled="True" Format="dd-MMM-yyyy">
                                </cc1:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 30%; text-align: right; padding: 10px;">
                                <asp:Label ID="LblTime" runat="server" Text="Time:"></asp:Label>
                            </td>
                            <td style="padding-top: 10px;">
                                <asp:TextBox ID="TxtTime" runat="server" CssClass="controllabel" Width="100px"></asp:TextBox>
                                <cc1:MaskedEditExtender ID="MEXTime" runat="server" TargetControlID="TxtTime" Mask="99:99"
                                    MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError"
                                    MaskType="Time" AcceptAMPM="True" ErrorTooltipEnabled="True" />
                                <cc1:MaskedEditValidator ID="MEVTime" runat="server" ControlExtender="MEXTime" ControlToValidate="TxtTime"
                                    IsValidEmpty="False" EmptyValueMessage="*" InvalidValueMessage="*" Display="Dynamic"
                                    ValidationGroup="VgInteraction"></cc1:MaskedEditValidator>
                            </td>
                        </tr>
                    </table>
                    <table id="TblAdmission" runat="server" border="0" cellpadding="0" cellspacing="0"
                        style="width: 90%;">
                        <tr>
                            <td style="width: 30%; text-align: right; padding: 10px;">
                                <asp:Label ID="LblStatus" runat="server" Text="Status:"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="LblStatusText" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 30%; text-align: right; padding: 10px; vertical-align: top;">
                                <asp:Label ID="LblFeedBack" runat="server" Text="Feedback:"></asp:Label>
                            </td>
                            <td style="padding-top: 10px;">
                                <textarea id="TxtFeedBack" runat="server" rows="5" cols="60" style="min-width: 310px;
                                    max-width: 310px; padding: 5px;"></textarea>
                                &nbsp;<asp:RequiredFieldValidator ID="RqdFeedBack" runat="server" ControlToValidate="TxtFeedBack"
                                    ErrorMessage="Please enter Feedback" ValidationGroup="Vgconfirm">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 30%; text-align: right; padding: 10px; vertical-align: top;">
                                <asp:Label ID="LblRemarks" runat="server" Text="Remarks:"></asp:Label>
                            </td>
                            <td style="padding-top: 10px;">
                                <textarea id="TxtRemarks" runat="server" rows="5" cols="60" style="min-width: 310px;
                                    max-width: 310px; padding: 5px;"></textarea>
                            </td>
                        </tr>
                    </table>
                    <table border="0" cellpadding="0" cellspacing="0" style="width: 90%;">
                        <tr id="trtemplate" runat="server">
                            <td style="width: 30%; text-align: right; padding: 10px; vertical-align: top; padding-top: 20px;">
                                <asp:Label ID="LblTemplate" runat="server" Text="Mail Template:"></asp:Label>
                            </td>
                            <td style="padding-top: 20px;">
                                <asp:GridView ID="gvtemplate" runat="server" AutoGenerateColumns="False" SkinID="NoPaging"
                                    ShowHeader="false" Width="80%">
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:RadioButton ID="Rbtemplate" runat="server" onclick="javascript:checkOnlyOneRadio(this);" />
                                            </ItemTemplate>
                                            <ItemStyle CssClass="GridViewRows" Width="10%" HorizontalAlign="Center" VerticalAlign="Top" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:Label ID="GV_LblTemplateName" runat="server" Text='<%#Eval("title") %>' />
                                            </ItemTemplate>
                                            <ItemStyle CssClass="GridViewRows" Width="40%" HorizontalAlign="Left" VerticalAlign="Top" />
                                        </asp:TemplateField>
                                    </Columns>
                                    <EmptyDataTemplate>
                                        <div style="text-align: center; color: black">
                                            No Template Found</div>
                                    </EmptyDataTemplate>
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr id="trdocument" runat="server">
                            <td style="width: 30%; text-align: right; padding: 10px; vertical-align: top; padding-top: 20px;">
                                <asp:Label ID="LblDocument" runat="server" Text="Attach Document:"></asp:Label>
                            </td>
                            <td style="padding-top: 20px;">
                                <asp:GridView ID="GvDocument" runat="server" AutoGenerateColumns="False" SkinID="NoPaging"
                                    ShowHeader="false" Width="80%">
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkdocument" runat="server" />
                                            </ItemTemplate>
                                            <ItemStyle CssClass="GridViewRows" Width="10%" HorizontalAlign="Center" VerticalAlign="Top" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:Label ID="GV_LblDocumentName" runat="server" Text='<%#Eval("title") %>' />
                                            </ItemTemplate>
                                            <ItemStyle CssClass="GridViewRows" Width="40%" HorizontalAlign="Left" VerticalAlign="Top" />
                                        </asp:TemplateField>
                                    </Columns>
                                    <EmptyDataTemplate>
                                        <div style="text-align: center; color: black">
                                            No Document Found</div>
                                    </EmptyDataTemplate>
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </div>
                <div style="margin-top: 20px; margin-left: 26%;">
                    <%--<asp:Button ID="btnPreviewSend" runat="server" Text="Preview & Send" OnClick="btnPreviewSend_Click"
                        ValidationGroup="VgInteraction" />--%>
                    <asp:Button ID="btnSendI" runat="server" Text="Send" OnClick="btnSend_Click" ValidationGroup="VgInteraction" />
                    <asp:Button ID="btnSendA" runat="server" Text="Send" OnClick="btnSend_Click" ValidationGroup="Vgconfirm" />
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click"
                        ValidationGroup="Vgconfirm" />
                    <asp:Button ID="btnClose" runat="server" Text="Cancel" OnClientClick="javascript:return CloseInteractionPopup();" />
                </div>
                <div>
                    <asp:ValidationSummary ID="VsumSendInteractionSlip" runat="server" Font-Bold="False"
                        ShowMessageBox="False" ShowSummary="False" />
                </div>
            </div>
        </div>
    </asp:Panel>
    <!--Send Interaction Slip-->
    <!-- LoaderPart start-->
    <asp:Button ID="btnLoader" runat="server" Style="display: none" />
    <asp:Button ID="btnCancel" runat="server" Style="display: none" />
    <cc1:ModalPopupExtender ID="ModalPopup" runat="server" PopupControlID="dvPopup" CancelControlID="btnCancel"
        TargetControlID="btnLoader" BackgroundCssClass="modalBackground" Enabled="True">
    </cc1:ModalPopupExtender>
    <table id="dvPopup" runat="server" class="loadingtable" cellpadding="0" cellspacing="0"
        style="display: none;">
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
            ShowLoader();
        }
        function EndRequestHandler(sender, args) {
            HideLoader();
        }
        function ShowLoader() {
            if ($("#<%= btnLoader.ClientID%>") != null) {
                $("#<%= btnLoader.ClientID%>").click();
            }
        }
        function HideLoader() {
            if ($("#<%= btnCancel.ClientID%>") != null) {
                $("#<%= btnCancel.ClientID%>").click();
            }
        }
        function ShowInteractionPopup(Admissionid, from, email) {
            if ($("#<%= BtnShowInteractionPopup.ClientID%>") != null) {
                document.getElementById('<%= hdnAdmissionID.ClientID%>').value = Admissionid;
                document.getElementById('<%= hdnAdmissionStatus.ClientID%>').value = from;
                document.getElementById('<%= hdnEmailID.ClientID%>').value = email;

                switch (from) {
                    case "Interaction":

                        document.getElementById('<%= lblactionTitle.ClientID %>').innerHTML = "Send Interaction Slip";
                        document.getElementById('<%= TblAdmission.ClientID %>').style.display = "none";
                        document.getElementById('<%= TblInteraction.ClientID %>').style.display = "";
                        document.getElementById('<%= trtemplate.ClientID %>').style.display = "";
                        document.getElementById('<%= trdocument.ClientID %>').style.display = "";
                        document.getElementById('<%= btnSendI.ClientID %>').style.display = "";
                        document.getElementById('<%= btnSendA.ClientID %>').style.display = "none";
                        document.getElementById('<%= btnSubmit.ClientID %>').style.display = "none";

                        break;
                    case "confirm":

                        document.getElementById('<%= lblactionTitle.ClientID %>').innerHTML = "Admission " + from;
                        document.getElementById('<%= TblAdmission.ClientID %>').style.display = "";
                        document.getElementById('<%= TblInteraction.ClientID %>').style.display = "none";
                        document.getElementById('<%= trtemplate.ClientID %>').style.display = "";
                        document.getElementById('<%= trdocument.ClientID %>').style.display = "";
                        document.getElementById('<%= btnSendI.ClientID %>').style.display = "none";
                        document.getElementById('<%= btnSendA.ClientID %>').style.display = "";
                        document.getElementById('<%= btnSubmit.ClientID %>').style.display = "none";

                        break;
                    case "onhold":

                        document.getElementById('<%= lblactionTitle.ClientID %>').innerHTML = "Admission " + from;
                        document.getElementById('<%= TblAdmission.ClientID %>').style.display = "";
                        document.getElementById('<%= TblInteraction.ClientID %>').style.display = "none";
                        document.getElementById('<%= trtemplate.ClientID %>').style.display = "none";
                        document.getElementById('<%= trdocument.ClientID %>').style.display = "none";
                        document.getElementById('<%= btnSendI.ClientID %>').style.display = "none";
                        document.getElementById('<%= btnSendA.ClientID %>').style.display = "none";
                        document.getElementById('<%= btnSubmit.ClientID %>').style.display = "";

                        break;
                    case "reject":

                        document.getElementById('<%= lblactionTitle.ClientID %>').innerHTML = "Admission " + from;
                        document.getElementById('<%= TblAdmission.ClientID %>').style.display = "";
                        document.getElementById('<%= TblInteraction.ClientID %>').style.display = "none";
                        document.getElementById('<%= trtemplate.ClientID %>').style.display = "none";
                        document.getElementById('<%= trdocument.ClientID %>').style.display = "none";
                        document.getElementById('<%= btnSendI.ClientID %>').style.display = "none";
                        document.getElementById('<%= btnSendA.ClientID %>').style.display = "none";
                        document.getElementById('<%= btnSubmit.ClientID %>').style.display = "";

                        break;
                }

                if (from == 'Interaction') {

                }
                else {

                }
                document.getElementById('<%= LblStatusText.ClientID %>').innerHTML = from;
                $("#<%= BtnShowInteractionPopup.ClientID%>").click();
            }
            return false;
        }
        function CloseInteractionPopup() {
            if ($("#<%= BtnCancelInteractionPopup.ClientID%>") != null) {
                document.getElementById('<%= TxtDate.ClientID%>').value = "";
                document.getElementById('<%= TxtTime.ClientID%>').value = "";
                document.getElementById('<%= hdnAdmissionID.ClientID%>').value = "";
                $("#<%= BtnCancelInteractionPopup.ClientID%>").click();
            }
            return false;
        }
        function checkOnlyOneRadio(obj) {
            try {
                var TargetBaseControl = document.getElementById('<%= gvtemplate.ClientID %>');
                var Inputs = TargetBaseControl.getElementsByTagName("input");
                for (var n = 0; n < Inputs.length; ++n) {
                    if (Inputs[n].type == 'radio') {
                        Inputs[n].checked = false;
                    }
                }
                obj.checked = true;
            }
            catch (e) {
                alert("Error");
            }
        } 
    </script>
</asp:Content>
