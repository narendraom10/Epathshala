<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Epathshala.master" AutoEventWireup="true"
    CodeFile="SchoolwisePerformanceReport.aspx.cs" Inherits="Report_SchoolwisePerformanceReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="DropDownCheckBoxes" Namespace="Saplin.Controls" TagPrefix="asp1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .ddCheckBoxes
        {
            min-height: 21px;
        }
        .ddCheckBoxes *
        {
            white-space: nowrap;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel runat="server" ID="upTopics" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="tbldashboard" id="ClasswiseReport" runat="server" visible="true">
                <div class="activitydivside">
                    <div class="ActivityHeader">
                        <asp:Label ID="Label2" runat="server" Text="Schoolwise Performance Report"></asp:Label>
                    </div>
                    <div class="ActivityContent" id="FirstRpt" runat="server" visible="true">
                        <div>
                            <asp:Label ID="lblSchool" runat="server" Text="School:" CssClass="textlabel" meta:resourcekey="lblSchoolResource1"></asp:Label>
                            <asp1:DropDownCheckBoxes ID="ddlSchool" runat="server" AddJQueryReference="True"
                                UseButtons="True" UseSelectAllNode="True" CssClass="ddCheckBoxes">
                                <Texts SelectBoxCaption="Select School " />
                                <Style SelectBoxWidth="400" DropDownBoxBoxWidth="200" DropDownBoxBoxHeight="70" />
                            </asp1:DropDownCheckBoxes>
                        </div>
                        <br />
                        <div>
                            <asp:Label ID="lblyear" runat="server" Text="Year:" CssClass="textlabel"></asp:Label>
                            <asp1:DropDownCheckBoxes ID="ddlAcademicYear" runat="server" AddJQueryReference="True"
                                UseButtons="True" UseSelectAllNode="True" CssClass="ddCheckBoxes">
                                <Texts SelectBoxCaption="Select Acedemic Year " />
                                <Style SelectBoxWidth="400" DropDownBoxBoxWidth="200" DropDownBoxBoxHeight="70" />
                            </asp1:DropDownCheckBoxes>
                        </div>
                        <br />
                        <div class="gobotton">
                            <asp:Button ID="btnGo" runat="server" Text="Go" ValidationGroup="a" meta:resourcekey="btnGoResource1"
                                OnClick="btnGo_Click" />
                            <asp:Button ID="btnReset" runat="server" Text="Reset" meta:resourcekey="btnResetResource1"
                                OnClick="btnReset_Click" />
                        </div>
                        <div>
                            <asp:Label ID="lblCountryID" runat="server"></asp:Label>
                            <asp:Label ID="lblCountryName" runat="server"></asp:Label>
                        </div>
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="a"
                            ShowMessageBox="True" ShowSummary="False" meta:resourcekey="ValidationSummary1Resource1" />
                    </div>
                </div>
            </div>
            <div class="tbldashboard">
                <div class="activitydivside">
                    <div class="ActivityHeader">
                        <asp:Label ID="Label3" runat="server" Text="Chart Report"></asp:Label>
                    </div>
                    <div class="ActivityContent" id="userControlDv" runat="server" visible="true">
                        <asp:Chart ID="Chart1" runat="server" Visible="false" Height="400px" Width="1120px"
                            BackColor="#CCCCCC">
                            <Titles>
                                <asp:Title Text="Year wise school performace report" />
                            </Titles>
                            <Legends>
                                <asp:Legend Alignment="Center" Docking="Bottom" IsTextAutoFit="False" Name="Default"
                                    LegendStyle="Row" />
                            </Legends>
                            <ChartAreas>
                                <asp:ChartArea Name="ChartArea1">
                                </asp:ChartArea>
                            </ChartAreas>
                        </asp:Chart>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnGo" />
        </Triggers>
    </asp:UpdatePanel>
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
