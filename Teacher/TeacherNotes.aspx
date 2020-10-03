<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Epathshala.master" AutoEventWireup="true"
    CodeFile="TeacherNotes.aspx.cs" Inherits="Teacher_TeacherNotes" Culture="auto"
    meta:resourcekey="PageResource1" UICulture="auto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function SelectAllCheckboxes(chk) {
            $("#ctl00_ContentPlaceHolder1_GvUserList input:checkbox").attr("checked", function () {
                if (this != chk) {
                    this.checked = chk.checked;
                }
            });
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="upNotes" runat="server" class="tblDashboard">
        <ContentTemplate>
            <div class="sidepanel">
                <div class="activitydivside">
                    <div class="ActivityHeader">
                        <asp:Label ID="lblTitleTeacherNote" runat="server" Text="Teacher Notes" meta:resourcekey="lblTitleTeacherNoteResource1"></asp:Label>
                    </div>
                    <div class="ActivityContent">
                        <div>
                            <asp:Label ID="lblBMSSCT" runat="server" Text="SCT:" CssClass="textlabel" meta:resourcekey="lblBMSSCTResource1"></asp:Label>
                            <asp:DropDownList ID="ddlBMSSCT" runat="server" Width="100%" AutoPostBack="True" meta:resourcekey="ddlBMSSCTResource1">
                                <asp:ListItem Value="0" Text="-- Select --" meta:resourcekey="ListItemResource1"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rqdBMSSCT" runat="server" ErrorMessage="SCT is required"
                                ValidationGroup="TeacherNoteGroup" ControlToValidate="ddlBMSSCT" InitialValue="0"
                                Text="." meta:resourcekey="rqdBMSSCTResource1"></asp:RequiredFieldValidator>
                        </div>
                        <div>
                            <asp:Label ID="lblNote" runat="server" Text="Note:" meta:resourcekey="lblNoteResource1"></asp:Label>
                            <asp:GridView ID="gvTeacherNote" runat="server" AutoGenerateColumns="False" DataKeyNames="Note"
                                OnRowCommand="gvTeacherNote_RowCommand" meta:resourcekey="gvTeacherNoteResource1">
                                <Columns>
                                    <%-- <asp:TemplateField HeaderText="No">
                                        <HeaderTemplate>
                                            <asp:CheckBox ID="chkSelectHead" runat="server" onclick="javascript:SelectAllCheckboxes(this);" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkSelect" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                    <asp:TemplateField HeaderText="No" meta:resourcekey="TemplateFieldResource1" SortExpression="No">
                                        <ItemTemplate>
                                            <asp:Label ID="lblNo" runat="server" Text='<%# Convert.ToInt32(Container.DataItemIndex)+1 %>'
                                                meta:resourcekey="lblNoResource1"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Note" meta:resourcekey="TemplateFieldResource2" SortExpression="Note">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtNote" runat="server" Text='<%# Eval("Note") %>' TextMode="MultiLine"
                                                Width="215px" Height="50px" meta:resourcekey="txtNoteResource1"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rqdGvNote" runat="server" ControlToValidate="txtNote"
                                                ValidationGroup="TeacherNoteGroup" ErrorMessage="Enter note in empty row." Text="."
                                                meta:resourcekey="rqdGvNoteResource1"></asp:RequiredFieldValidator>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--<asp:TemplateField>
                                        <ItemTemplate>
                                                <asp:ImageButton ID="ibtnDelete" CausesValidation="False" OnClientClick="return confirm('Are you sure you want to delete this ? ');"
                                                    CommandName="DeleteRow" Width="12px" CommandArgument='<%# Convert.ToInt32(Container.DataItemIndex)+1 %>' Height="12px"
                                                    ToolTip="Delete" runat="server" ImageUrl="~/App_Themes/Images/delete.gif" meta:resourcekey="ibtnDeleteResource1" />
                                            </ItemTemplate>
                                        
                                        </asp:TemplateField>--%>
                                </Columns>
                            </asp:GridView>
                            <asp:LinkButton ID="lnlAddRow" runat="server" ValidationGroup="TeacherNoteGroup"
                                Font-Strikeout="False" Font-Underline="False" OnClick="lnlAddRow_Click" Text="Add New Row"
                                meta:resourcekey="lnlAddRowResource1"></asp:LinkButton>
                        </div>
                        <div>
                            <asp:Button ID="btnSubmit" runat="server" Text="Submit" ValidationGroup="TeacherNoteGroup"
                                CssClass="gobutton" OnClick="btnSubmit_Click" meta:resourcekey="btnSubmitResource1" />
                            <asp:Button ID="btnReset" runat="server" CssClass="gobutton" OnClick="btnReset_Click"
                                Text="Reset" meta:resourcekey="btnResetResource1" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="sidepanel1">
                <div class="activitydivside1">
                    <div class="ActivityHeader">
                        Note List
                    </div>
                    <div class="ActivityContent">
                        <asp:GridView ID="gvNotes" runat="server" AutoGenerateColumns="False">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Label ID="lblSequence" runat="server" Text='<%#Convert.ToInt32(Container.DataItemIndex)+1 %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="NoteID" HeaderText="NoteID" Visible="false" />
                                <asp:BoundField DataField="SCT" HeaderText="SCT" SortExpression="SCT" />
                                <asp:TemplateField HeaderText="Note" SortExpression="Note">
                                    <ItemTemplate>
                                        <asp:Label ID="lblGvNote" runat="server" Text='<%#Eval("Note") %>' ToolTip='<%#Eval("Note") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <asp:ValidationSummary ID="vsTeacherNote" ValidationGroup="TeacherNoteGroup" ShowMessageBox="True"
                                        ShowSummary="False" runat="server" meta:resourcekey="vsTeacherNoteResource1" />
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
