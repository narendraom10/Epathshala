<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Epathshala.master" AutoEventWireup="true"
    CodeFile="ReschedulingChapterTopicStudent.aspx.cs" Inherits="Student_ReschedulingChapterTopicStudent" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .RBPadding
        {
            padding: 15px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td>
                <asp:RadioButtonList ID="rbSubjectList" runat="server" RepeatDirection="Horizontal"
                    CssClass="RBPadding" CellSpacing="5" CellPadding="5" RepeatColumns="7" AutoPostBack="True"
                    OnSelectedIndexChanged="rbSubjectList_SelectedIndexChanged" 
                    meta:resourcekey="rbSubjectListResource1">
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td style="padding: 5px 5px 5px 5px">
                <table cellpadding="0" cellspacing="0" width="80%" class="InnerTableStyle RoundTop tblControls">
                    <tr>
                        <td colspan="2" class="Header round">
                            <asp:Label ID="LblRescheduling" runat="server" Text="Rescheduling Chapter Topic"
                                meta:resourcekey="LblReschedulingResource1"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="Required" style="text-align: right;">
                            <asp:Label ID="LblChapter" runat="server" Text="Chapter:" meta:resourcekey="LblChapterResource1"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlChapter" runat="server" Width="215px" Enabled="False" AutoPostBack="True"
                                OnSelectedIndexChanged="ddlChapter_SelectedIndexChanged" meta:resourcekey="ddlChapterResource1">
                                <asp:ListItem Text="-- Select --" meta:resourcekey="ListItemResource1"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RFVDdlChapter" runat="server" ControlToValidate="DdlChapter"
                                InitialValue="-- Select --" ErrorMessage="Please Select Chapter." ValidationGroup="PnlBMS1"
                                meta:resourcekey="RFVDdlChapterResource1">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="Required" style="text-align: right;">
                            <asp:Label ID="LblTopic" runat="server" Text="Topic:" meta:resourcekey="LblTopicResource1"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlTopic" runat="server" Width="215px" Enabled="False" AutoPostBack="True"
                                meta:resourcekey="ddlTopicResource1">
                                <asp:ListItem Text="-- Select --" meta:resourcekey="ListItemResource2"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RFVDdlTopic" runat="server" ControlToValidate="DdlTopic"
                                InitialValue="-- Select --" ErrorMessage="Please Select Topic." ValidationGroup="PnlBMS1"
                                meta:resourcekey="RFVDdlTopicResource1">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            <table>
                                <tr>
                                    <td>
                                        <asp:Button ID="BtnSubmit" Text="Submit" runat="server" CssClass="gobutton" ValidationGroup="PnlBMS1"
                                            OnClick="BtnSubmit_Click" meta:resourcekey="BtnSubmitResource1" />
                                    </td>
                                    <td>
                                        <asp:Button ID="btnReset" runat="server" CssClass="gobutton" Text="Reset" CausesValidation="False"
                                            OnClick="btnReset_Click" meta:resourcekey="btnResetResource1" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">
                            <asp:ValidationSummary ID="VSPnlBMS" runat="server" ValidationGroup="PnlBMS1" ShowMessageBox="True"
                                ShowSummary="False" meta:resourcekey="VSPnlBMSResource1" />
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right;">
                            <asp:Label ID="lblMonthYear" runat="server" Text="MonthYear:" meta:resourcekey="lblMonthYearResource1"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlMonthYear" runat="server" Width="215px" AutoPostBack="True"
                                OnSelectedIndexChanged="ddlMonthYear_SelectedIndexChanged" meta:resourcekey="ddlMonthYearResource1">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">
                            <asp:GridView ID="grvReschedulingData" runat="server" AutoGenerateColumns="False"
                                DataKeyNames="SReSchedulingID,BMSSCTID,ChapterID,TopicID" EmptyDataText="Chapter Topic Not Available."
                                meta:resourcekey="grvReschedulingDataResource1">
                                <Columns>
                                    <asp:TemplateField HeaderText="Sr No." meta:resourcekey="TemplateFieldResource1">
                                        <ItemTemplate>
                                            <%# ((GridViewRow)Container).RowIndex + 1%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Chapter" HeaderText="Chapter" meta:resourcekey="BoundFieldResource1" />
                                    <asp:BoundField DataField="Topic" HeaderText="Topic" meta:resourcekey="BoundFieldResource2" />
                                    <asp:BoundField DataField="AppliedDate" HeaderText="Applied Date" meta:resourcekey="BoundFieldResource3" />
                                    <asp:BoundField DataField="Status" HeaderText="Status" meta:resourcekey="BoundFieldResource4" />
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
