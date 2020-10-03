<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Epathshala.master" AutoEventWireup="true"
    CodeFile="SearchResult.aspx.cs" Inherits="Dashboard_SearchResult" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        #ctl00_ContentPlaceHolder1_GvContentList td + td + td + td + td
        {
            text-align: center !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row">
        <div class="Activity" runat="server">
            <div class="ActivityHeading">
                <asp:Label ID="lblAddTitle" runat="server" Text="Search result for keyword: "></asp:Label><asp:Label
                    Text="No keyword set" runat="server" ID="lblsearckkey" />
            </div>
            <div class="Content">
                <div style="text-align: right;">
                    <asp:Label ID="Label1" runat="server" CssClass="Label" Text="Search result based on Board, Medium, Standard, Subject, Chapter, Chapter Description
                and Topic Name"></asp:Label>
                </div>
                <div>
                    <asp:GridView ID="GvContentList" runat="server" DataKeyNames="BMSSCTID,BMS,Chapter,Topic"
                        AutoGenerateColumns="False" SkinID="NoPaging" OnRowCommand="GvContentList_RowCommand"
                        OnRowDataBound="GvContentList_RowDataBound">
                        <Columns>
                            <asp:BoundField DataField="BMSSCTID" HeaderText="BMSSCTID" Visible="False" meta:resourcekey="BoundFieldResource1" />
                            <asp:TemplateField HeaderText="BMS">
                                <ItemTemplate>
                                    <asp:Label ID="lblBMS" runat="server" Text='<%# Bind("BMS") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Subject">
                                <ItemTemplate>
                                    <asp:Label ID="lblSubject" runat="server" Text='<%# Bind("Subject") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Chapter">
                                <ItemTemplate>
                                    <asp:Label ID="lblChapter" runat="server" Text='<%# Bind("Chapter") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Topic">
                                <ItemTemplate>
                                    <asp:Label ID="lblTopic" runat="server" Text='<%# Bind("Topic") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkDisplay" CssClass="LinkButton" Font-Underline="false" Text='View' ForeColor="Blue" 
                                        runat="server" CommandName="View" CommandArgument="ViewResource" ToolTip='<%# Eval("BMSSCTID") %>'
                                        Style="text-align: center;"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            <div style="text-align: center; color: black">
                                No Search Result Found</div>
                        </EmptyDataTemplate>
                    </asp:GridView>
                </div>
                <div>
                 <asp:Button ID="btnBack" runat="server" Text="Back" PostBackUrl="~/Dashboard/StudentDashboard.aspx" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
