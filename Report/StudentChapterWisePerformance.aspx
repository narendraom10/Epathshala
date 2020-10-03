<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Epathshala.master" AutoEventWireup="true"
    CodeFile="StudentChapterWisePerformance.aspx.cs" Inherits="Report_StudentChapterWisePerformance" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="ClasswiseReport" runat="server" visible="true" style="margin:auto">
        <table cellpadding="0" cellspacing="0" style="margin-top: 4px" width="70%" class="RoundTop InnerTableStyle TableControl">
            <tr align="center">
                <td align="center" class="Header12 RoundTop GridViewHeadercssTestAssessment" colspan="2">
                    <asp:Label ID="Label2" runat="server" Text="Performancewise Student Report"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblsubject" runat="server" Text="Subject"></asp:Label>
                    <asp:DropDownList ID="ddlsubject" runat="server">
                    </asp:DropDownList>
                    <asp:Button ID="btnreport" Text="View Report" runat="server" OnClick="btnreport_Click"   />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="grchapterwiseperformance" runat="server" AutoGenerateColumns="false">
                    <EmptyDataTemplate>
                           <h2>  <span style="color:Black">No data was returned.</span>  </h2>
                        </EmptyDataTemplate>
                    
                        <Columns>
                            <asp:BoundField DataField="Chapter" HeaderText="Chapter" meta:resourcekey="BoundFieldResource1" />
                            <asp:BoundField DataField="Persentage" HeaderText="Percentage" meta:resourcekey="BoundFieldResource2" />
                            <%--<table>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblchapter" runat="server" Text='<%# Eval("Chapter") %>'>
                                                </asp:Label>
                                            </td>

                                            <td>
                                                <asp:Label ID="lblper" runat="server" Text='<%# Eval("Persentage") %>'>
                                                </asp:Label>
                                            </td>
                                        </tr>

                                       
                                    </table>--%>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
