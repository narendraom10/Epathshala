<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Epathshala.master" AutoEventWireup="true"
    CodeFile="ClassroomTrack.aspx.cs" Inherits="Report_ClassroomTrack" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="../UserControl/ReportControl.ascx" TagName="ReportControl" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<div class="tblDashboard">
    <div class="sidepanel" visible="False" meta:resourcekey="lblSecondTitleResource1">
        <div class="activitydivside">
            <div class="ActivityHeader">
                Class room track
            </div>
            <div class="ActivityContent">
                <div class="Label">
                    School</div>
                <div class="Control">
                    <asp:DropDownList runat="server" ID="ddlSchool" ClientIDMode="Static" OnSelectedIndexChanged="ddlSchool_SelectedIndexChanged"
                        AutoPostBack="True" Width="140px">
                    </asp:DropDownList>
                </div>
                <asp:UpdatePanel runat="server" ID="pnlBMS" ClientIDMode="Static">
                    <ContentTemplate>
                        <div class="Label">
                            BMS</div>
                        <div class="Control">
                            <asp:DropDownList runat="server" ID="ddlBMS" ClientIDMode="Static" AutoPostBack="True"
                                OnSelectedIndexChanged="ddlBMS_SelectedIndexChanged" Width="140px">
                            </asp:DropDownList>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlSchool" EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
                <asp:UpdatePanel runat="server" ID="pnlDivision" ClientIDMode="Static">
                    <ContentTemplate>
                        <div class="Label">
                            Division</div>
                        <div class="Control">
                            <asp:DropDownList runat="server" ID="ddlDivision" ClientIDMode="Static" Width="140px">
                            </asp:DropDownList>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlBMS" EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
                <div class="Label">
                    Date
                </div>
                <div class="Control">
                    <asp:TextBox ID="txtDate" runat="server" CssClass="textBoxCls"></asp:TextBox>
                    <asp:ImageButton ID="ibtnStartDate" runat="server" ImageUrl="~/App_Themes/Images/calendar12.png"
                        Width="20px" meta:resourcekey="ibtnStartDateResource1" />
                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDate"
                        PopupButtonID="ibtnStartDate" Enabled="True" Format="dd-MMM-yyyy">
                    </cc1:CalendarExtender>
                </div>
                <div class="Control">
                    <asp:Button runat="server" ClientIDMode="Static" ID="btnSubmit" Text="Submit" OnClick="btnSubmit_Click" />
                    <asp:Button ID="btnexporttoexcel" runat="server" Text="Export to excel" OnClick="btnexporttoexcel_Click" />
                    
                </div>
            </div>
        </div>
    </div>
    
        <div class="sidepanel1" >
            <div class="activitydivside1" id="Classroomtrack" runat="server" >
                <div class="ActivityHeader">
                    Classrrom Track 
                </div>
                <div class="activitycontent">
                    <div>
                        <asp:UpdatePanel runat="server" ID="pnlReport" ClientIDMode="Static">
                            <ContentTemplate>
                                <div class="Control">
                                    <asp:GridView runat="server" ClientIDMode="Static" ID="gvwReport" AutoGenerateColumns="False"
                                        SkinID="NoPaging">
                                        <Columns>
                                            <asp:BoundField DataField="Activity_Date" HeaderText="Time" DataFormatString="{0:hh:mm_tt}"
                                                HtmlEncode="false" />
                                            <asp:BoundField DataField="Employee" HeaderText="Employee" />
                                            <asp:BoundField DataField="Activity" HeaderText="Activity" />
                                            <asp:BoundField DataField="Time_Difference" HeaderText="Duration" />
                                            <asp:BoundField DataField="Remark" HeaderText="Remark" />
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="btnSubmit" EventName="Click" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
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
