<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Epathshala.master" AutoEventWireup="true"
    CodeFile="DateWiseInteractionReport.aspx.cs" Inherits="Report_DateWiseInteractionReport" %>

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
    <asp:UpdatePanel runat="server" ID="UpAdmission" UpdateMode="Always">
        <ContentTemplate>
            <div style="width: 80%; margin: auto; margin-top: 30px;">
                <div style="display: inline-block; float: right;">
                    <table class="inputform" style="text-align: center;">
                        <tr>
                            <td class="labelname">
                                <asp:Label ID="LblStartDate" runat="server" Text="Start Date:" Enabled="False"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TxtStartDate" runat="server" CssClass="controllabel"></asp:TextBox>
                                <div style="padding: 2px; background-color: #444; width: 20px; height: 20px; display: inline-block;
                                    margin-left: 4px; border-radius: 4px;">
                                    <asp:ImageButton ID="ibtnStartDate" runat="server" ImageUrl="~/App_Themes/Responsive/web/Calender.png"
                                        Width="20px" />
                                </div>
                                <cc1:CalendarExtender ID="CalExtStartDate" runat="server" TargetControlID="TxtStartDate"
                                    PopupButtonID="ibtnStartDate" Enabled="True" Format="dd-MMM-yyyy">
                                </cc1:CalendarExtender>
                            </td>
                            <td class="labelname">
                                <asp:Label ID="LblEndDate" runat="server" Text="End Date:" Enabled="False"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TxtEndDate" runat="server" CssClass="controllabel"></asp:TextBox>
                                <div style="padding: 2px; background-color: #444; width: 20px; height: 20px; display: inline-block;
                                    margin-left: 4px; border-radius: 4px;">
                                    <asp:ImageButton ID="ibtnEndDate" runat="server" ImageUrl="~/App_Themes/Responsive/web/Calender.png"
                                        Width="20px" />
                                </div>
                                <cc1:CalendarExtender ID="CalExtEndDate" runat="server" TargetControlID="TxtEndDate"
                                    PopupButtonID="ibtnEndDate" Enabled="True" Format="dd-MMM-yyyy">
                                </cc1:CalendarExtender>
                            </td>
                            <td>
                                <asp:Button ID="btnSubmit" runat="server" Text="Go" OnClick="btnSubmit_Click" ValidationGroup="VgAdmission" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <div style="width: 80%; margin: auto; margin-top: 30px;">
                <div class="activitydivside1" id="SecondRpt" runat="server" visible="true">
                    <div class="ActivityHeader">
                        <asp:Label ID="LblTitle" runat="server" Text="Date Wise Interaction Report"></asp:Label>
                    </div>
                    <div class="ActivityContent">
                        <asp:GridView ID="GvAdmission" runat="server" DataKeyNames="AdmissionId,AdmissionStatus"
                            AutoGenerateColumns="False">
                            <Columns>
                                <asp:TemplateField HeaderText="SNo.">
                                    <ItemTemplate>
                                        <asp:Label ID="LblSrNo" runat="server" Text='<%# Container.DataItemIndex+1 %>' /></ItemTemplate>
                                    <ItemStyle CssClass="GridViewRows" Width="5%" HorizontalAlign="Center" VerticalAlign="Top" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Form No" SortExpression="FormNo">
                                    <ItemTemplate>
                                        <asp:Label ID="LblFormNo" runat="server" Text='<%#Eval("FormNo") %>' /></ItemTemplate>
                                    <ItemStyle CssClass="GridViewRows" Width="15%" HorizontalAlign="Left" VerticalAlign="Top" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Admission Grade" SortExpression="AdmissionGrade">
                                    <ItemTemplate>
                                        <asp:Label ID="LblAdmissionGrade" runat="server" Text='<%#Eval("AdmissionGrade") %>' /></ItemTemplate>
                                    <ItemStyle CssClass="GridViewRows" Width="25%" HorizontalAlign="Left" VerticalAlign="Top" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Student Name">
                                    <ItemTemplate>
                                        <asp:Label ID="LblStudentName" runat="server" Text='<%#Eval("FirstName") %>' /></ItemTemplate>
                                    <ItemStyle CssClass="GridViewRows" Width="18%" HorizontalAlign="Left" VerticalAlign="Top" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Mobile">
                                    <ItemTemplate>
                                        <asp:Label ID="LblEmergencyMobileNumber" runat="server" Text='<%#Eval("EmergencyMobileNo") %>' /></ItemTemplate>
                                    <ItemStyle CssClass="GridViewRows" Width="10%" HorizontalAlign="Left" VerticalAlign="Top" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Communication Email">
                                    <ItemTemplate>
                                        <asp:Label ID="LblCommunicationEmail" runat="server" Text='<%#Eval("CommunicationEmail") %>' /></ItemTemplate>
                                    <ItemStyle CssClass="GridViewRows" Width="10%" HorizontalAlign="Left" VerticalAlign="Top" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Interaction Time">
                                    <ItemTemplate>
                                        <asp:Label ID="LblInteractionTime" runat="server" Text='<%#Eval("InteractionTime") %>' /></ItemTemplate>
                                    <ItemStyle CssClass="GridViewRows" Width="20%" HorizontalAlign="Left" VerticalAlign="Top" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </ContentTemplate>
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
    </script>
</asp:Content>
