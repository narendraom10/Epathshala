<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Attendens.ascx.cs" Inherits="Attendens" %>
<table style="margin: 0px 0px 0px 0px;" class="tblControls">
    <tr>
        <td>
            <asp:Label ID="lblBoard" runat="server" Text="Board:" 
                meta:resourcekey="lblBoardResource1"></asp:Label>
        </td>
        <td>
            <asp:DropDownList ID="ddlBoard" runat="server" 
                meta:resourcekey="ddlBoardResource1">
                <asp:ListItem Text="-- Select --" meta:resourcekey="ListItemResource1"> </asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="rqdddlBoard" runat="server" ControlToValidate="ddlBoard"
                InitialValue="-- Select --" ErrorMessage="Must Select Board." 
                meta:resourcekey="rqdddlBoardResource1">*</asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td>
        </td>
        <td>
            <asp:Button ID="btnOk" runat="server" Text="Ok" OnClick="btnOk_Click" 
                meta:resourcekey="btnOkResource1" />
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <asp:GridView ID="gvAttandance" runat="server" AutoGenerateColumns="False" 
                meta:resourcekey="gvAttandanceResource1">
                <Columns>
                   <%-- <asp:BoundField DataField="StandardID" HeaderText="StandardID" SortExpression="StandardID" />--%>
                    <asp:BoundField DataField="Standard" HeaderText="Standard" 
                        SortExpression="Standard" meta:resourcekey="BoundFieldResource1" />
                   <%--  <asp:BoundField DataField="DivisionID" HeaderText="DivisionID" SortExpression="DivisionID" />--%>
                      <asp:BoundField DataField="Division" HeaderText="Division" 
                        SortExpression="Division" meta:resourcekey="BoundFieldResource2" />
                       <%-- <asp:BoundField DataField="Attendance" HeaderText="Attendance" SortExpression="Attendance" />--%>
                </Columns>
            </asp:GridView>
        </td>
    </tr>
</table>
