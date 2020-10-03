<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Epathshala.master" AutoEventWireup="true"
    CodeFile="RegistrationReport.aspx.cs" Inherits="Report_RegistrationReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel runat="server" ID="UpRegistration" UpdateMode="Always">
        <ContentTemplate>
            <div style="width: 90%; margin: auto; margin-top: 30px;">
                <div style="display: inline-block; float: right;">
                    <table class="inputform" style="text-align: center; margin-right: -8px;">
                        <tr>
                            <td class="labelname">
                                <asp:Label ID="LblStartDate" runat="server" Text="Registration Start Date:" Enabled="False"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TxtStartDate" runat="server" CssClass="controllabel"></asp:TextBox>
                                <div style="padding: 2px; background-color: #444; width: 20px; height: 20px; display: inline-block;
                                    margin-left: 4px; border-radius: 4px;">
                                    <asp:ImageButton ID="ibtnStartDate" runat="server" ImageUrl="~/App_Themes/Responsive/web/Calender.png"
                                        Width="20px" />
                                </div>
                                <cc1:CalendarExtender ID="CalExtStartDate" runat="server" TargetControlID="TxtStartDate"
                                    PopupButtonID="ibtnStartDate" Enabled="True" Format="dd MMM, yyyy">
                                </cc1:CalendarExtender>
                            </td>
                            <td class="labelname">
                                <asp:Label ID="LblEndDate" runat="server" Text="Registration End Date:" Enabled="False"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TxtEndDate" runat="server" CssClass="controllabel"></asp:TextBox>
                                <div style="padding: 2px; background-color: #444; width: 20px; height: 20px; display: inline-block;
                                    margin-left: 4px; border-radius: 4px;">
                                    <asp:ImageButton ID="ibtnEndDate" runat="server" ImageUrl="~/App_Themes/Responsive/web/Calender.png"
                                        Width="20px" />
                                </div>
                                <cc1:CalendarExtender ID="CalExtEndDate" runat="server" TargetControlID="TxtEndDate"
                                    PopupButtonID="ibtnEndDate" Enabled="True" Format="dd MMM, yyyy">
                                </cc1:CalendarExtender>
                            </td>
                            <td style="padding-left: 10px;">
                                <asp:Button ID="btnSubmit" runat="server" Text="Go" OnClick="btnSubmit_Click" ValidationGroup="VgAdmission" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <div style="width: 90%; margin: auto; margin-top: 30px;">
                <div class="activitydivside1" style="margin-top: 15px; margin-bottom: 15px;">
                    <div class="ActivityHeader">
                        <asp:Label ID="LblTitle" runat="server" Text="Date Wise Registration Report"></asp:Label>
                    </div>
                    <div class="ActivityContent">
                        <asp:GridView ID="gvRegistration" runat="server" AutoGenerateColumns="False" OnRowCommand="gvRegistration_RowCommand"
                            OnSorting="gvRegistration_Sorting" OnPageIndexChanging="gvRegistration_PageIndexChanging"
                            OnRowCreated="gvRegistration_RowCreated" OnRowDataBound="gvRegistration_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="Student Name" SortExpression="StudentName">
                                    <ItemTemplate>
                                        <asp:Label runat="server" Text='<%# Eval("StudentName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Contact Number" SortExpression="ContactNo">
                                    <ItemTemplate>
                                        <asp:Label runat="server" Text='<%# Eval("ContactNo") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="EmailID" SortExpression="EmailID">
                                    <ItemTemplate>
                                        <asp:Label runat="server" Text='<%# Eval("EmailID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Registration Date" SortExpression="CreatedOn">
                                    <ItemTemplate>
                                        <asp:Label runat="server" Text='<%# string.Format("{0:dd MMM, yyyy}", Eval("CreatedOn")) %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Package Name" SortExpression="PackageName">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="ShowPackage" runat="server" CommandName="ShowPackage" CommandArgument='<%#Eval("PackageID") %>'><%# Eval("PackageName") %></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Activate On" SortExpression="ActivateOn">
                                    <ItemTemplate>
                                        <asp:Label runat="server" Text='<%# string.Format("{0:dd MMM, yyyy}", Eval("ActivateOn")) %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="From Date" SortExpression="FromDate">
                                    <ItemTemplate>
                                        <asp:Label runat="server" Text='<%# string.Format("{0:dd MMM, yyyy}", Eval("FromDate")) %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Valid Till" SortExpression="ValidTill">
                                    <ItemTemplate>
                                        <asp:Label runat="server" Text='<%# string.Format("{0:dd MMM, yyyy}", Eval("ValidTill")) %>'></asp:Label>
                                    </ItemTemplate>
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
                            <EmptyDataTemplate>
                                No Registration Found
                            </EmptyDataTemplate>
                        </asp:GridView>
                    </div>
                </div>
            </div>
            <!--Show Package-->
            <asp:Button ID="BtnShowPackagePopup" runat="server" Text="Show" Style="display: none" />
            <asp:Button ID="BtnCancelPackagePopup" runat="server" Text="Close" Style="display: none" />
            <cc1:ModalPopupExtender ID="MdlPackageSleep" runat="server" PopupControlID="PnlPackageSleep"
                TargetControlID="BtnShowPackagePopup" BackgroundCssClass="modalBackground" CancelControlID="BtnCancelPackagePopup">
            </cc1:ModalPopupExtender>
            <asp:Panel ID="PnlPackageSleep" runat="server" Style="display: none;">
                <div class="activitydivfull">
                    <div class="ActivityHeader">
                        <asp:Label ID="lblactionTitle" runat="server" Text="Package Detail"></asp:Label>
                        <div style="float: right; padding: 0px 5px 0px 0px;">
                            <img onclick="javascript:return ClosePackagePopup();" alt="Close" src="../App_Themes/Images/close.png"
                                height="20px" width="20px" style="cursor: pointer;" />
                        </div>
                    </div>
                    <div class="ActivityContent">
                        <div style="margin-top: 15px; overflow: auto;">
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="padding-top: 10px;">
                                        <asp:GridView ID="gvpackage" runat="server" Style="margin-top: 2px; margin-bottom: 15px;"
                                            EmptyDataText="No Mail Record Found" AutoGenerateColumns="false" Width="200%">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Package Name">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" Text='<%#Eval("PackageName") %>' /></ItemTemplate>
                                                    <ItemStyle CssClass="GridViewRows" HorizontalAlign="Left" VerticalAlign="Top" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Package Type">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" Text='<%#Eval("PackageType") %>' /></ItemTemplate>
                                                    <ItemStyle CssClass="GridViewRows" HorizontalAlign="Left" VerticalAlign="Top" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="BMS">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" Text='<%#Eval("BMS") %>' /></ItemTemplate>
                                                    <ItemStyle CssClass="GridViewRows" HorizontalAlign="Left" VerticalAlign="Top" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Subject">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" Text='<%#Eval("Subject") %>' /></ItemTemplate>
                                                    <ItemStyle CssClass="GridViewRows" HorizontalAlign="Left" VerticalAlign="Top" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Price">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" Text='<%#Eval("Price") %>' /></ItemTemplate>
                                                    <ItemStyle CssClass="GridViewRows" HorizontalAlign="Left" VerticalAlign="Top" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Number Of Days">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" Text='<%#Eval("NoOfMonth") %>' /></ItemTemplate>
                                                    <ItemStyle CssClass="GridViewRows" HorizontalAlign="Left" VerticalAlign="Top" />
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
            </asp:Panel>
            <!--Send Package-->
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="gvRegistration" />
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
        function ClosePackagePopup() {
            if ($("#<%= BtnCancelPackagePopup.ClientID%>") != null) {
                $("#<%= BtnCancelPackagePopup.ClientID%>").click();
            }
            return false;
        }     
    </script>
</asp:Content>
