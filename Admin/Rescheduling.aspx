<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Epathshala.master" AutoEventWireup="true"
    CodeFile="Rescheduling.aspx.cs" Inherits="Admin_Rescheduling" Culture="auto"
    meta:resourcekey="PageResource1" UICulture="auto" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function checkInDateChanged(sender, args) {
            var checkInDate = sender.get_selectedDate();

            var checkOutDateExtender = $find(sender.get_id().toString() + '1');
            var checkOutdate = checkOutDateExtender.get_selectedDate();

            if (sender.get_selectedDate() < new Date()) {
                sender.set_selectedDate(new Date());
                var checkInDate1 = sender.get_selectedDate();
                checkOutdate = new Date(checkInDate1.setDate(checkInDate1.getDate() + 2));
                checkOutDateExtender.set_selectedDate(checkOutdate);
                alert("Select date greater than equal to todays date");
            }
            else {
                checkOutdate = new Date(checkInDate.setDate(checkInDate.getDate() + 2));
                checkOutDateExtender.set_selectedDate(checkOutdate);
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="0" cellspacing="0" class="RoundTop InnerTableStyle TableControl"
        width="90%">
        <tr>
            <td class="Header12 GridViewHeadercssTestAssessment RoundTop">
                <asp:Label ID="lblTitle" runat="server" Text="Teacher Rescheduling Approval" meta:resourcekey="lblTitleResource1"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="grdRescheduling" runat="server" DataKeyNames="ReSchedulingID,BMSSCTID,ChapterID,Subject,Standard,Division,Chapter,Topic,TopicID,EmployeeID"
                    AutoGenerateColumns="False" OnRowCommand="grdRescheduling_RowCommand" OnRowDataBound="grdRescheduling_RowDataBound"
                    meta:resourcekey="grdReschedulingResource1">
                    <Columns>
                        <asp:TemplateField HeaderText="Sr. No" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Center"
                            meta:resourcekey="TemplateFieldResource1">
                            <ItemTemplate>
                                <%# ((GridViewRow)Container).RowIndex + 1%>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="50px"></ItemStyle>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Name" HeaderText="School" SortExpression="Name" ItemStyle-Width="100px"
                            meta:resourcekey="BoundFieldResource1">
                            <ItemStyle Width="100px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="EmployeeName" HeaderText="Teacher" SortExpression="EmployeeName"
                            ItemStyle-Width="120px" meta:resourcekey="BoundFieldResource2">
                            <ItemStyle Width="120px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="Subject" HeaderText="Subject" SortExpression="Subject"
                            ItemStyle-Width="100px" meta:resourcekey="BoundFieldResource3">
                            <ItemStyle Width="100px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="Standard" HeaderText="Standard" SortExpression="Standard"
                            ItemStyle-Width="120px" meta:resourcekey="BoundFieldResource4">
                            <ItemStyle Width="120px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="Division" HeaderText="Division" SortExpression="Division"
                            ItemStyle-Width="80px" meta:resourcekey="BoundFieldResource5">
                            <ItemStyle Width="80px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="Chapter" HeaderText="Chapter" SortExpression="Chapter"
                            ItemStyle-Width="120px" meta:resourcekey="BoundFieldResource6">
                            <ItemStyle Width="120px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="Topic" HeaderText="Topic" SortExpression="Topic" ItemStyle-Width="120px"
                            meta:resourcekey="BoundFieldResource7">
                            <ItemStyle Width="120px"></ItemStyle>
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="ReSchedulingID" Visible="false" meta:resourcekey="TemplateFieldResource2">
                            <ItemTemplate>
                                <asp:Label ID="lblReschedulingID" runat="server" Text='<%# Eval("ReSchedulingID") %>'
                                    meta:resourcekey="lblReschedulingIDResource1"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Start Date" SortExpression="StartDate" ItemStyle-Width="100px"
                            meta:resourcekey="TemplateFieldResource3">
                            <ItemTemplate>
                                <asp:TextBox ID="txtStartDate" runat="server" Width="90px" Enabled="False" meta:resourcekey="txtStartDateResource1"></asp:TextBox>
                                <asp:ImageButton ID="ibtnStartDate" runat="server" ImageUrl="~/App_Themes/Images/Calender.gif"
                                    Width="15px" meta:resourcekey="ibtnStartDateResource1" />
                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtStartDate"
                                    PopupButtonID="ibtnStartDate" Enabled="True" Format="dd-MM-yyyy" OnClientDateSelectionChanged="checkInDateChanged">
                                </cc1:CalendarExtender>
                                <asp:RequiredFieldValidator ID="RFVtxtStartDate" runat="server" ControlToValidate="txtStartDate"
                                    ErrorMessage="Please Select Start Date." Text="*" ValidationGroup="Grid" meta:resourcekey="RFVtxtStartDateResource1"></asp:RequiredFieldValidator>
                            </ItemTemplate>
                            <ItemStyle Width="100px"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="End Date" SortExpression="EndeDate" ItemStyle-Width="100px"
                            meta:resourcekey="TemplateFieldResource4">
                            <ItemTemplate>
                                <asp:TextBox ID="txtEndDate" runat="server" Width="90px" Enabled="False" meta:resourcekey="txtEndDateResource1"></asp:TextBox>
                                <asp:ImageButton ID="ibtnEndDate" runat="server" ImageUrl="~/App_Themes/Images/Calender.gif"
                                    Width="15px" meta:resourcekey="ibtnEndDateResource1" />
                                <cc1:CalendarExtender ID="CalendarExtender11" runat="server" TargetControlID="txtEndDate"
                                    PopupButtonID="ibtnEndDate" Enabled="True" Format="dd-MM-yyyy">
                                </cc1:CalendarExtender>
                                <asp:RequiredFieldValidator ID="RFVtxtEndDate" runat="server" ControlToValidate="txtEndDate"
                                    ErrorMessage="Please Select End Date." Text="*" ValidationGroup="Grid" meta:resourcekey="RFVtxtEndDateResource1"></asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="CMPVDATE" runat="server" ErrorMessage="EndDate Must be Greater Then Start Date."
                                    Text="*" ValidationGroup="Grid" Type="string" Operator="GreaterThan" ControlToValidate="txtEndDate"
                                    ControlToCompare="txtStartDate" CultureInvariantValues="True" meta:resourcekey="CMPVDATEResource1"></asp:CompareValidator>
                            </ItemTemplate>
                            <ItemStyle Width="100px"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Approve" meta:resourcekey="TemplateFieldResource5">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkbtnApprove" runat="server" CommandArgument="ReSchedulingID,BMSSCTID"
                                    CommandName="Approve" ValidationGroup="Grid" meta:resourcekey="lnkbtnApproveResource1">Approve</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>
                <asp:ValidationSummary ID="VSGrid" ShowMessageBox="True" ShowSummary="False" runat="server"
                    ValidationGroup="Grid" meta:resourcekey="VSGridResource1" />
            </td>
        </tr>
    </table>
</asp:Content>
