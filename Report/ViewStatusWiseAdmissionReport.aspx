<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Epathshala.master" AutoEventWireup="true"
    CodeFile="ViewStatusWiseAdmissionReport.aspx.cs" Inherits="Report_ViewStatusWiseAdmissionReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../App_Themes/Responsive/Calender/CSS.css" rel="stylesheet" type="text/css" />
    <script src="../App_Themes/Responsive/Calender/Extension.min.js" type="text/javascript"></script>
    <asp:UpdatePanel runat="server" ID="UpAdmission" UpdateMode="Always">
        <ContentTemplate>
            <div style="width: 80%; margin: auto; margin-top: 30px;">
                <div class="activitydivside1" id="SecondRpt" runat="server" visible="true">
                    <div class="ActivityHeader">
                        <asp:Label ID="LblTitle" runat="server" Text="Status Wise Admission Report"></asp:Label>
                        <div style="display: inline-block; float: right; padding-right: 10px;">
                            <asp:ImageButton ImageUrl="~/App_Themes/Responsive/web/All.png" runat="server" Style="cursor: pointer;
                                width: 22px;" ToolTip="All Admission" OnClick="All_Click" />
                            <asp:ImageButton ImageUrl="~/App_Themes/Responsive/web/Interaction.png" runat="server"
                                Style="cursor: pointer; width: 22px;" ToolTip="Interaction" OnClick="Interaction_Click" />
                            <asp:ImageButton ImageUrl="~/App_Themes/Responsive/web/confirm.png" runat="server"
                                Style="cursor: pointer; width: 22px;" ToolTip="Confirm" OnClick="Confirm_Click" />
                            <asp:ImageButton ImageUrl="~/App_Themes/Responsive/web/onhold.png" runat="server"
                                Style="cursor: pointer; width: 22px;" ToolTip="Onhold" OnClick="Onhold_Click" />
                            <asp:ImageButton ImageUrl="~/App_Themes/Responsive/web/reject.png" runat="server"
                                Style="cursor: pointer; width: 22px;" ToolTip="Rejected" OnClick="Rejected_Click" />
                        </div>
                    </div>
                    <div class="ActivityContent">
                        <div id="dvExcel" runat="server" style="text-align: right;">
                            <asp:ImageButton ID="imgExcel" ImageUrl="~/App_Themes/Responsive/web/excel.png" runat="server"
                                Style="cursor: pointer; width: 22px; margin-bottom: 2px;" ToolTip="Export As Excel"
                                OnClick="ExportAsExcel_Click" />
                        </div>
                        <asp:GridView ID="GvAdmission" runat="server" DataKeyNames="AdmissionId" OnSorting="GvAdmission_Sorting"
                            OnPageIndexChanging="GvAdmission_PageIndexChanging" OnRowCreated="GvAdmission_RowCreated"
                            meta:resourcekey="GvUserListResource1" AutoGenerateColumns="False" OnRowDataBound="GvAdmission_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="SNo.">
                                    <ItemTemplate>
                                        <asp:Label ID="LblSrNo" runat="server" Text='<%# Container.DataItemIndex+1 %>' /></ItemTemplate>
                                    <ItemStyle CssClass="GridViewRows" Width="5%" HorizontalAlign="Center" VerticalAlign="Top" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Form No" SortExpression="FormNo">
                                    <ItemTemplate>
                                        <asp:Label ID="LblFormNo" runat="server" Text='<%#Eval("FormNo") %>' /></ItemTemplate>
                                    <ItemStyle CssClass="GridViewRows" Width="13%" HorizontalAlign="Left" VerticalAlign="Top" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Admission Grade" SortExpression="AdmissionGrade">
                                    <ItemTemplate>
                                        <asp:Label ID="LblAdmissionGrade" runat="server" Text='<%#Eval("AdmissionGrade") %>' /></ItemTemplate>
                                    <ItemStyle CssClass="GridViewRows" Width="25%" HorizontalAlign="Left" VerticalAlign="Top" />
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
                                <asp:TemplateField HeaderText="View History">
                                    <ItemTemplate>
                                        <a style="cursor: pointer; text-decoration: none;" title="View History" onclick="javascript:return ShowHistoryPopup('<%#Eval("AdmissionId") %>');">
                                            <asp:Image ID="Image1" ImageUrl="~/App_Themes/Responsive/web/ProcessHistory.png"
                                                runat="server" Width="20px" />
                                        </a>
                                    </ItemTemplate>
                                    <ItemStyle CssClass="GridViewRows" Width="10%" HorizontalAlign="Center" VerticalAlign="Top" />
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
            </div>
            <!--History Popup-->
            <asp:LinkButton ID="LinkButton1" runat="server"></asp:LinkButton>
            <cc1:ModalPopupExtender ID="MdlHistory" runat="server" PopupControlID="PnlHistory"
                BehaviorID="MdlBHistory" TargetControlID="LinkButton1" BackgroundCssClass="modalBackground"
                Y="50">
            </cc1:ModalPopupExtender>
            <asp:Panel ID="PnlHistory" runat="server" Style="display: none;">
                <div class="activitydivfull" style="width: 650px; box-shadow: 0 0 4px #000">
                    <div class="ActivityHeader">
                        <asp:Label ID="lblactionTitle" runat="server" Text="History"></asp:Label>
                        <div style="float: right; padding: 0px 5px 0px 0px;">
                            <img onclick="javascript:return CloseHistoryPopup();" alt="Close" src="../App_Themes/Images/close.png"
                                height="20px" width="20px" style="cursor: pointer;" />
                        </div>
                    </div>
                    <div class="ActivityContent">
                        <div style="margin-top: 5px; max-height: 400px; overflow: auto;">
                            <div class="dvsmallheader">
                                <span>Admission History</span>
                            </div>
                            <asp:GridView ID="GvStatusHistory" runat="server" SkinID="GridforReport" Style="margin-top: 2px;
                                margin-bottom: 15px;" EmptyDataText="No Status Record Found">
                            </asp:GridView>
                            <div class="dvsmallheader">
                                <span>Mail History</span>
                            </div>
                            <asp:GridView ID="GvMailHistory" runat="server" Style="margin-top: 2px; margin-bottom: 15px;"
                                EmptyDataText="No Mail Record Found" AutoGenerateColumns="false">
                                <Columns>
                                    <asp:TemplateField HeaderText="AdmissionStatus">
                                        <ItemTemplate>
                                            <asp:Label ID="LblAdmissionStatus" runat="server" Text='<%#Eval("AdmissionStatus") %>' /></ItemTemplate>
                                        <ItemStyle CssClass="GridViewRows" Width="13%" HorizontalAlign="Left" VerticalAlign="Top" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="MailSubject">
                                        <ItemTemplate>
                                            <asp:Label ID="LblMailSubject" runat="server" Text='<%#Eval("MailSubject") %>' /></ItemTemplate>
                                        <ItemStyle CssClass="GridViewRows" Width="25%" HorizontalAlign="Left" VerticalAlign="Top" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="SendOn">
                                        <ItemTemplate>
                                            <asp:Label ID="LblSendOn" runat="server" Text='<%#Eval("SendOn") %>' /></ItemTemplate>
                                        <ItemStyle CssClass="GridViewRows" Width="13%" HorizontalAlign="Left" VerticalAlign="Top" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="View Mail">
                                        <ItemTemplate>
                                            <a style="cursor: pointer; text-decoration: none;" title="View Mail" onclick="javascript:return LoadMail('<%#Eval("AdmissionEmailID") %>');">
                                                <asp:Image ID="Image1" ImageUrl="~/App_Themes/Responsive/web/ViewEmail.png" runat="server"
                                                    Width="20px" />
                                            </a>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="GridViewRows" Width="13%" HorizontalAlign="Center" VerticalAlign="Top" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <div class="Mail">
                            </div>
                        </div>
                    </div>
                </div>
            </asp:Panel>
            <!--History Popup-->
            <asp:Button Text="text" ID="btnGetHistory" runat="server" Style="display: none;"
                OnClick="btnGetHistory_Click" />
            <asp:HiddenField ID="hdnAdmissionID" runat="server" />
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnGetHistory" />
            <asp:PostBackTrigger ControlID="imgExcel" />
        </Triggers>
    </asp:UpdatePanel>
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
        function ShowHistoryPopup(AdmissionId) {
            document.getElementById('<%= hdnAdmissionID.ClientID %>').value = AdmissionId;
            if ($find("MdlBHistory") != null) {
                __doPostBack('<%= btnGetHistory.UniqueID %>', '')
            }
        }
        function CloseHistoryPopup() {
            if ($find("MdlBHistory") != null) {
                $find("MdlBHistory").hide();
                return false;
            }
        }
        function LoadMail(AdmissionEmailID) {
            $('.Mail').html('');
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                url: "../Report/ViewStatusWiseAdmissionReport.aspx/LoadMail",
                data: "{'AdmissionEmailID':'" + AdmissionEmailID + "'}",
                success: function (data) {
                    try {
                        $('.Mail').html(data.d.toString());
                    } catch (e) {
                        return;
                    }
                },
                error: function (result) {
                    alert("Error");
                }
            });
        }
    </script>
</asp:Content>
