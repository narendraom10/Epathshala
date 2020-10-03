<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ReportControl.ascx.cs"
    Inherits="ReportControl" %>

    <div>
       

                <table width="100%">
                    <tr>
                        <td>
                            <h1>
                                <asp:Label ID="lblTitle" runat="server"></asp:Label>
                            </h1>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btnexporttoexcel" runat="server" Text="Export To Excel" OnClick="btnexporttoexcel_Click" />
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:GridView ID="gridreport" runat="server" BorderStyle="None" BorderWidth="1px" CssClass="GridViewCss"
                                CellPadding="3" OnRowDataBound="OnRowDataBound" SkinID="ReportGrid" OnSelectedIndexChanged="OnSelectedIndexChanged"
                                OnPageIndexChanging="gridreport_PageIndexChanging" PageSize="1"  EnableModelValidation="False"
                                AllowSorting="false" OnSorting="gridreport_Sorting" AutoGenerateColumns="true"
                                dataformatstring="{0:dd-MMMM-yyyy}" >
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <h4>
                                <asp:Label ID="lblFooter" runat="server" Visible="False"></asp:Label>
                            </h4>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <h4>
                                <asp:Label ID="lblaverage" runat="server" Visible="False"></asp:Label>
                            </h4>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lbltotal" runat="server" Visible="False"></asp:Label>
                        </td>
                    </tr>
                </table>
         
    </div>

