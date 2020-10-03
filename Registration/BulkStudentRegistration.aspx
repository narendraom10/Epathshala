<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Epathshala.master" AutoEventWireup="true"
    CodeFile="BulkStudentRegistration.aspx.cs" Inherits="Registration_BulkStudentRegistration" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="upMain" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div style="overflow: auto; margin: auto; width: 80%;">
                <div style="float: left;">
                    <asp:Button ID="btndownload" Text="DownLoad Template" runat="server" OnClick="btndownload_Click" />
                </div>
                <div style="float: right;">
                    <input type="file" id="fufile" name="fufile" runat="server" style="width: 250px;" />
                    <asp:RegularExpressionValidator ID="regval" ValidationExpression="([a-zA-Z0-9\s_\\.\-:])+(.xls|.xlsx)$"
                        ControlToValidate="fufile" runat="server" ForeColor="Red" ErrorMessage="Please select a valid file."
                        Display="Dynamic" />
                    <asp:Button ID="btnUpload" Text="Upload File" runat="server" OnClick="btnUpload_Click" />
                </div>
            </div>
            <div style="overflow: auto; margin: auto; width: 80%; margin-top: 25px; margin-bottom: 25px;">
                <asp:GridView ID="grvData" runat="server" AutoGenerateColumns="False" SkinID="NoPaging"
                    OnRowDataBound="grvData_RowDataBound">
                    <Columns>
                        <asp:TemplateField HeaderText="SNo.">
                            <ItemTemplate>
                                <asp:Label ID="GV_LblSRNO" runat="server" Text='<%# Container.DataItemIndex+1 %>' /></ItemTemplate>
                            <ItemStyle CssClass="GridViewRows" HorizontalAlign="Center" VerticalAlign="Top" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="BMS">
                            <ItemTemplate>
                                <asp:Label ID="GV_LblBMS" runat="server" Text='<%#Eval("BMS") %>' /></ItemTemplate>
                            <ItemStyle CssClass="GridViewRows" HorizontalAlign="Left" VerticalAlign="Top" Width="35%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Division">
                            <ItemTemplate>
                                <asp:Label ID="GV_LblDivision" runat="server" Text='<%#Eval("Division") %>' /></ItemTemplate>
                            <ItemStyle CssClass="GridViewRows" HorizontalAlign="Left" VerticalAlign="Top" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="First Name">
                            <ItemTemplate>
                                <asp:Label ID="GV_Lblfn" runat="server" Text='<%#Eval("FirstName") %>' /></ItemTemplate>
                            <ItemStyle CssClass="GridViewRows" HorizontalAlign="Left" VerticalAlign="Top" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Middle Name">
                            <ItemTemplate>
                                <asp:Label ID="GV_Lblmn" runat="server" Text='<%#Eval("MiddleName") %>' /></ItemTemplate>
                            <ItemStyle CssClass="GridViewRows" HorizontalAlign="Left" VerticalAlign="Top" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Last Name">
                            <ItemTemplate>
                                <asp:Label ID="GV_Lblln" runat="server" Text='<%#Eval("LastName") %>' /></ItemTemplate>
                            <ItemStyle CssClass="GridViewRows" HorizontalAlign="Left" VerticalAlign="Top" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Address">
                            <ItemTemplate>
                                <asp:Label ID="GV_LblAdd" runat="server" Text='<%#Eval("Address") %>' /></ItemTemplate>
                            <ItemStyle CssClass="GridViewRows" HorizontalAlign="Left" VerticalAlign="Top" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="RollNo">
                            <ItemTemplate>
                                <asp:Label ID="GV_Lblrn" runat="server" Text='<%#Eval("RollNo") %>' /></ItemTemplate>
                            <ItemStyle CssClass="GridViewRows" HorizontalAlign="Left" VerticalAlign="Top" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ContactNo">
                            <ItemTemplate>
                                <asp:Label ID="GV_LblContactNo" runat="server" Text='<%#Eval("ContactNo") %>' /></ItemTemplate>
                            <ItemStyle CssClass="GridViewRows" HorizontalAlign="Left" VerticalAlign="Top" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="MobileNo">
                            <ItemTemplate>
                                <asp:Label ID="GV_LbllMobileNo" runat="server" Text='<%#Eval("MobileNo") %>' /></ItemTemplate>
                            <ItemStyle CssClass="GridViewRows" HorizontalAlign="Left" VerticalAlign="Top" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="EmailID">
                            <ItemTemplate>
                                <asp:Label ID="GV_LblEmailID" runat="server" Text='<%#Eval("EmailID") %>' /></ItemTemplate>
                            <ItemStyle CssClass="GridViewRows" HorizontalAlign="Left" VerticalAlign="Top" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="GRNo">
                            <ItemTemplate>
                                <asp:Label ID="GV_LblGRNo" runat="server" Text='<%#Eval("GRNo") %>' /></ItemTemplate>
                            <ItemStyle CssClass="GridViewRows" HorizontalAlign="Left" VerticalAlign="Top" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="DateOfBirth">
                            <ItemTemplate>
                                <asp:Label ID="GV_LblGRDateOfBirth" runat="server" Text='<%#Eval("DateOfBirth") %>' /></ItemTemplate>
                            <ItemStyle CssClass="GridViewRows" HorizontalAlign="Left" VerticalAlign="Top" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Gender">
                            <ItemTemplate>
                                <asp:Label ID="GV_LblGRGender" runat="server" Text='<%#Eval("Gender") %>' /></ItemTemplate>
                            <ItemStyle CssClass="GridViewRows" HorizontalAlign="Left" VerticalAlign="Top" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="BloodGroup">
                            <ItemTemplate>
                                <asp:Label ID="GV_LblBloodGroup" runat="server" Text='<%#Eval("BloodGroup") %>' /></ItemTemplate>
                            <ItemStyle CssClass="GridViewRows" HorizontalAlign="Left" VerticalAlign="Top" />
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                        <div style="text-align: center; color: black">
                            No Search Result Found</div>
                    </EmptyDataTemplate>
                </asp:GridView>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnDownload" />
            <asp:PostBackTrigger ControlID="btnUpload" />
            <asp:PostBackTrigger ControlID="btnImport" />
        </Triggers>
    </asp:UpdatePanel>
    <div style="overflow: auto; margin: auto; width: 80%;">
        <div style="float: right;">
            <asp:Button ID="btnImport" Text="Upload Data" runat="server" OnClick="btnImport_Click"
                Visible="false" />
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
            <span>Student Import Result</span>
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
                <asp:Button ID="btnDownloadExcel" runat="server" Text="Download Excel" 
                    onclick="btnDownloadExcel_Click"  />
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
