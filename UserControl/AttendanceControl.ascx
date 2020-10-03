<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AttendanceControl.ascx.cs"
    Inherits="Attendens" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<style type="text/css">
    .style1
    {
        width: 422px;
    }
</style>
<div>
    <div  style="clear:both; display:inline-block; width:100%;">
        <asp:Label ID="lblBoardMediumStandard" runat="server" Text="BMS:" CssClass="textlabel" meta:resourcekey="lblBoardMediumStandardResource1"></asp:Label>
        <asp:DropDownList ID="ddlBoardMediumStandard" runat="server" CssClass="controllabel" meta:resourcekey="ddlBoardMediumStandardResource1"
            AutoPostBack="True" OnSelectedIndexChanged="ddlBoardMediumStandard_SelectedIndexChanged">
        </asp:DropDownList>
    </div>
    <div  style="clear:both; display:inline-block; width:100%;">
        <asp:Label ID="lblDivision" Text="Division:" CssClass="textlabel" runat="server" meta:resourcekey="lblDivisionResource1"></asp:Label>
        <asp:CheckBoxList ID="clstDivision" runat="server" RepeatDirection="Horizontal" RepeatColumns="4"
            CssClass="chkChoice" meta:resourcekey="clstDivisionResource1">
        </asp:CheckBoxList>
    </div>
    <div  style="clear:both; display:inline-block; width:100%;margin-top:3px;">
        <asp:Label ID="lblDateFrom" runat="server" Text="Date From:" CssClass="textlabel" meta:resourcekey="lblDateFromResource1"></asp:Label>
        <asp:TextBox ID="txtStartDate" runat="server" Width="100px" CssClass="controllabel" meta:resourcekey="txtStartDateResource1"></asp:TextBox>
        <div style="padding:2px; background-color:#444; width:20px; height:20px; display:inline-block; margin-left:4px; border-radius:4px;">
        <asp:ImageButton ID="ibtnStartDate" runat="server" ImageUrl="~/App_Themes/Responsive/web/calender.png"
            Width="20px" meta:resourcekey="ibtnStartDateResource1" />
        </div>
        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtStartDate"
            PopupButtonID="ibtnStartDate" Enabled="True" Format="dd-MMM-yyyy">
        </cc1:CalendarExtender>
    </div>
    <div  style="clear:both; display:inline-block; width:100%;margin-top:3px;">
        <asp:Label ID="lblTo" runat="server" Text="To:" CssClass="textlabel" meta:resourcekey="lblToResource1"></asp:Label>
        <asp:TextBox ID="txtEndDate" runat="server" Width="100px" CssClass="controllabel" meta:resourcekey="txtEndDateResource1"></asp:TextBox>
        <div style="padding:2px; background-color:#444; width:20px; height:20px; display:inline-block; margin-left:4px; border-radius:4px;">
        <asp:ImageButton ID="ibtnEndDate" runat="server" ImageUrl="~/App_Themes/Responsive/web/calender.png"
            Width="20px" meta:resourcekey="ibtnEndDateResource1" />
        </div>
        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtEndDate"
            PopupButtonID="ibtnEndDate" Enabled="True" Format="dd-MMM-yyyy">
        </cc1:CalendarExtender>
    </div>
    <div class="gobotton" style="clear:both; display:inline-block; width:90%;">
        <asp:Button ID="btnOk" runat="server" Text="Ok" OnClick="btnOk_Click" meta:resourcekey="btnOkResource1" />
    </div>
    <div style="float: right">
        <asp:Label ID="Label1" runat="server" BackColor="Green" Width="10px" Height="7px"
            meta:resourcekey="Label1Resource1"></asp:Label>
        <asp:Label ID="Label2" runat="server" Text="Present" Font-Size="10px" meta:resourcekey="Label2Resource1"></asp:Label>
        <asp:Label ID="Label3" runat="server" BackColor="Red" Width="10px" Height="7px" meta:resourcekey="Label3Resource1"></asp:Label>
        <asp:Label ID="Label4" runat="server" Text="Absent" Font-Size="10px" meta:resourcekey="Label4Resource1"></asp:Label>
    </div>
    <div style="clear:both; display:inline-block; width:100%;">
        
         <asp:GridView ID="grdAttandance" runat="server" OnPageIndexChanging="gvAnnouncementDetails_PageIndexChanging"
                OnRowCreated="gvAnnouncementDetails_RowCreated" OnSorting="gvAnnouncementDetails_Sorting"
                meta:resourcekey="grdAttandanceResource1" AutoGenerateColumns="false" >
                <Columns>
                    <asp:BoundField DataField="ADate" HeaderText="Date" SortExpression="ADate" ItemStyle-Width="65px"
                        meta:resourcekey="BoundFieldResource1">
                        <ItemStyle Width="65px"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="BMS" HeaderText="Board >> Medium >> Standard" SortExpression="BMS"
                        ItemStyle-Width="190px" meta:resourcekey="BoundFieldResource2">
                        <ItemStyle Width="190px"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="Division" HeaderText="Division" SortExpression="Division"
                        ItemStyle-Width="20px" meta:resourcekey="BoundFieldResource3">
                        <ItemStyle Width="20px"></ItemStyle>
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Attendance" SortExpression="Attendance" ItemStyle-Width="130px"
                        meta:resourcekey="TemplateFieldResource1">
                        <ItemTemplate>
                            <asp:Label ID="lblPrVal" runat="server" Font-Size="10px" ForeColor="Green" Font-Bold="true"
                                Text='<%# Math.Round(float.Parse(Eval("Attendance").ToString())) + "%" %>'></asp:Label>
                            <asp:Label ID="lblPr" CssClass="ApChartGreen" Height="22px" runat="server" Width='<%# ((float.Parse(Eval("Attendance").ToString()))  ) %>'
                                ForeColor="White" meta:resourcekey="lblPrResource1" /><asp:Label ID="lblAp" CssClass="ApChartRed"
                                    runat="server" Height="22px" Width='<%# ((100-float.Parse(Eval("Attendance").ToString())) ) %>'
                                    ForeColor="White" meta:resourcekey="lblApResource1" />
                            <asp:Label ID="lblApVal" runat="server" Font-Size="10px" ForeColor="Red" Font-Bold="true"
                                Text='<%# Math.Round(100 - (float.Parse(Eval("Attendance").ToString()))) + "%" %>'></asp:Label>
                            <%--   <asp:Label ID="lblPr" CssClass="ApChartGreen" Height="20px" runat="server" Width='<%# ((float.Parse(Eval("Attendance").ToString()))  ) %>'
                                meta:resourcekey="lblPrResource1" />
                            <asp:Label ID="lblPrVal" runat="server" Font-Size="10px" ForeColor="Green" Font-Bold="true"
                                Text='<%# Math.Round(float.Parse(Eval("Attendance").ToString())) + "%" %>'></asp:Label>
                            <br />
                            <asp:Label ID="lblAp" CssClass="ApChartRed" Height="20px" runat="server" Width='<%# ((100-float.Parse(Eval("Attendance").ToString())) ) %>'
                                meta:resourcekey="lblApResource1" />
                            <asp:Label ID="lblApVal" runat="server" Font-Size="10px" ForeColor="Red" Font-Bold="true"
                                Text='<%# Math.Round(100 - (float.Parse(Eval("Attendance").ToString()))) + "%" %>'></asp:Label>--%>
                        </ItemTemplate>
                        <ItemStyle Width="130px"></ItemStyle>
                    </asp:TemplateField>
                </Columns>
                <PagerTemplate>
                    <asp:ImageButton Text="First" CommandName="Page" CommandArgument="First" runat="server"
                        ImageUrl="~/App_Themes/Images/first.png" ID="ibtnFirst" ToolTip="Move First Page"
                        meta:resourcekey="ibtnFirstResource1" />
                    <asp:ImageButton Text="Previous" CommandName="Page" CommandArgument="Prev" runat="server"
                        ImageUrl="~/App_Themes/Images/previous.png" ID="ibtnPrevious" ToolTip="Move Previous Page"
                        meta:resourcekey="ibtnPreviousResource1" />
                    <asp:Label ID="lblPage" runat="server" Text="Page" ForeColor="Black" meta:resourcekey="lblPageResource1"></asp:Label>
                    <asp:DropDownList ID="ddlPageSelector" OnSelectedIndexChanged="ddlPageSelector_SelectedIndexChanged"
                        runat="server" AutoPostBack="True" SkinID="DdlWidth50" meta:resourcekey="ddlPageSelectorResource1">
                    </asp:DropDownList>
                    <asp:ImageButton Text="Next" CommandName="Page" CommandArgument="Next" runat="server"
                        ImageUrl="~/App_Themes/Images/NEXT.png" ID="ibtnNext" ToolTip="Move Next Page"
                        meta:resourcekey="ibtnNextResource1" />
                    <asp:ImageButton Text="Last" CommandName="Page" CommandArgument="Last" runat="server"
                        ImageUrl="~/App_Themes/Images/last.png" ID="ibtnLast" ToolTip="Move Last Page"
                        meta:resourcekey="ibtnLastResource1" />
                </PagerTemplate>
            </asp:GridView>
            
    </div>
</div>

