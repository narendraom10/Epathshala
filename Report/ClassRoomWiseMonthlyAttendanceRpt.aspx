<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Epathshala.master" AutoEventWireup="true"
    CodeFile="ClassRoomWiseMonthlyAttendanceRpt.aspx.cs" Inherits="Report_ClassRoomWiseMonthlyAttendanceRpt" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
  <%--  <asp:UpdatePanel runat="server" ID="upMain" UpdateMode="Conditional">
        <ContentTemplate>--%>
            <div class="tblDashboard">
                <div class="sidepanel">
                    <div class="activitydivside" id="ClasswiseMonthlyReport" runat="server" visible="true">
                        <div class="ActivityHeader">
                            <asp:Label ID="lblTitle" runat="server" Text="Classroom wise monthly attendance report"></asp:Label>
                        </div>
                        <div class="ActivityContent">
                            <div>
                                <asp:Label ID="lblSchool" runat="server" Text="School:" CssClass="textlabel"></asp:Label>
                                <asp:DropDownList ID="ddlSchool" runat="server" Width="140px" AutoPostBack="True"
                                    OnSelectedIndexChanged="ddlSchool_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RFVddlSchool" runat="server" ErrorMessage="Please Select School."
                                    ControlToValidate="ddlSchool" ValidationGroup="a" InitialValue="0">*</asp:RequiredFieldValidator>
                            </div>
                            <div>
                                <asp:Label ID="lblBoard" runat="server" Text="Board:" CssClass="textlabel"></asp:Label>
                                <asp:DropDownList ID="ddlBoard" runat="server" AutoPostBack="True" 
                                    OnSelectedIndexChanged="ddlBoard_SelectedIndexChanged" Width="140px">
                                    <asp:ListItem Value="0" Text="-- Select --"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div>
                                <asp:Label ID="lblMedium" runat="server" Text="Medium:" CssClass="textlabel"></asp:Label>
                                <asp:DropDownList ID="ddlMedium" runat="server" AutoPostBack="True" 
                                    OnSelectedIndexChanged="ddlMedium_SelectedIndexChanged" Width="140px">
                                    <asp:ListItem Value="0" Text="-- Select --"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div>
                                <asp:Label ID="lblStandard" runat="server" Text="Standard:" CssClass="textlabel"></asp:Label>
                                <asp:DropDownList ID="ddlStandard" runat="server" AutoPostBack="True" 
                                    OnSelectedIndexChanged="ddlStandard_SelectedIndexChanged" Width="140px">
                                    <asp:ListItem Value="0" Text="-- Select --"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div>
                                <asp:Label ID="lblDivision" runat="server" Text="Division:" CssClass="textlabel"></asp:Label>
                                <asp:DropDownList ID="ddlDivision" runat="server" AutoPostBack="True" 
                                    Width="140px">
                                    <asp:ListItem Value="0" Text="-- Select --"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div>
                                <asp:Label ID="lblDate" runat="server" Text="Month:" CssClass="textlabel"></asp:Label>
                                <asp:TextBox ID="txtDate" runat="server" onKeypress="return(false)" CssClass="textBoxCls"></asp:TextBox>
                                <asp:ImageButton ID="ibtnDate" runat="server" ImageUrl="~/App_Themes/Images/calendar12.png"
                                    Width="20px" />
                                <cc2:CalendarExtender ID="calExt" runat="server" TargetControlID="txtDate" PopupButtonID="ibtnDate"
                                    Enabled="True" Format="MMM-yyyy">
                                </cc2:CalendarExtender>
                            </div>
                            <div class="gobotton">
                                <asp:Button ID="btnGo" runat="server" Text="Go" OnClick="btnGo_Click" CssClass="Button"
                                    ValidationGroup="a" />
                                <asp:Button ID="btnReset" runat="server" Text="Reset" OnClick="btnReset_Click" CssClass="Button" />
                            </div>
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="a"
                                ShowMessageBox="True" ShowSummary="False" />
                        </div>
                    </div>
                </div>
                <div class="sidepanel1">
                    <div class="activitydivside1">
                        <div class="ActivityHeader">
                            <asp:Label ID="Label1" runat="server" Text="Attendance Sheet"></asp:Label>
                        </div>
                        <div style="margin-left:700px" >
                            <asp:Button ID="btnexporttoexcel" runat="server" Text="Export to Excel" 
                                onclick="btnexporttoexcel_Click" Visible="False" />  
                        </div>
                       
                        <div class="ActivityContent">
                            <div style="overflow: scroll; width: 100%; height: 450px">
                                <asp:GridView ID="grdAtt" runat="server" AllowPaging="false" SkinID="GridforReport" Visible="false"
                                    AllowSorting="false" EmptyDataText="No Data Found." Width="100%" AutoGenerateColumns="true">
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        <%--</ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnGo" />
            <asp:AsyncPostBackTrigger ControlID="btnexporttoexcel" />
            <asp:AsyncPostBackTrigger ControlID="ddlSchool" />
            <asp:AsyncPostBackTrigger ControlID="ddlBoard" />
            <asp:AsyncPostBackTrigger ControlID="ddlMedium" />
            <asp:AsyncPostBackTrigger ControlID="ddlStandard" />
            <asp:PostBackTrigger ControlID="ddlDivision" />
        </Triggers>
    </asp:UpdatePanel>--%>
    <!-- LoaderPart -->
    <asp:Button ID="btnLoader" runat="server" Style="display: none" />
    <asp:Button ID="btnCancel" runat="server" Style="display: none" />
    <cc2:ModalPopupExtender ID="ModalPopup" runat="server" PopupControlID="dvPopup" CancelControlID="btnCancel"
        TargetControlID="btnLoader" BackgroundCssClass="modalBackground" Enabled="True">
    </cc2:ModalPopupExtender>
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
