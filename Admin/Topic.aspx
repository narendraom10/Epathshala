<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Epathshala.master" AutoEventWireup="true"
    CodeFile="Topic.aspx.cs" Inherits="Admin_Topic" Culture="auto" meta:resourcekey="PageResource2"
    UICulture="auto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="../Scripts/Jquery1.9.1.js" type="text/javascript"></script>
    <script type="text/javascript">        $(document).ready(function () {
            $("#<%= ibtnSearch.ClientID%>").click(function () {
                if ($("#<%= pnlSearch.ClientID%>").is(':visible')) {
                    $("#<%= pnlSearch.ClientID%>").removeClass("Visible").addClass("InVisible");
                    $("#<%= pnlAdd.ClientID%>").removeClass("Visible").addClass("InVisible");
                    $("#<%= pnlEdit.ClientID%>").removeClass("Visible").addClass("InVisible");
                }
                else {
                    $("#<%= pnlSearch.ClientID%>").removeClass("InVisible").addClass("Visible");
                    $("#<%= pnlAdd.ClientID%>").removeClass("Visible").addClass("InVisible");
                    $("#<%= pnlEdit.ClientID%>").removeClass("Visible").addClass("InVisible");
                } return false;
            });

            $("#<%= ibtnAdd.ClientID%>").click(function () {
                if ($("#<%= pnlAdd.ClientID%>").is(':visible')) {
                    $("#<%= pnlAdd.ClientID%>").removeClass("Visible").addClass("InVisible");
                    $("#<%= pnlSearch.ClientID%>").removeClass("InVisible").addClass("Visible");
                    $("#<%= pnlEdit.ClientID%>").removeClass("Visible").addClass("InVisible");
                }
                else {
                    $("#<%= pnlAdd.ClientID%>").removeClass("InVisible").addClass("Visible");
                    $("#<%= pnlSearch.ClientID%>").removeClass("Visible").addClass("InVisible");
                    $("#<%= pnlEdit.ClientID%>").removeClass("Visible").addClass("InVisible");
                } return false;
            });
            $("#<%= ibtnAdd.ClientID%>").click(function () {
                if ($("#<%= pnlAdd.ClientID%>").is(':visible')) {
                    $("#<%= pnlAdd.ClientID%>").removeClass("Visible").addClass("InVisible");
                    $("#<%= pnlSearch.ClientID%>").removeClass("InVisible").addClass("Visible");
                    $("#<%= pnlEdit.ClientID%>").removeClass("Visible").addClass("InVisible");
                }
                else {
                    $("#<%= pnlAdd.ClientID%>").removeClass("InVisible").addClass("Visible");
                    $("#<%= pnlSearch.ClientID%>").removeClass("Visible").addClass("InVisible");
                    $("#<%= pnlEdit.ClientID%>").removeClass("Visible").addClass("InVisible");
                } return false;
            });

            $("#<%= ibtnActiveDeactive.ClientID%>").click(function () {
                if ($("#<%= pnlActDeact.ClientID%>").is(':visible')) {
                    $("#<%= pnlAdd.ClientID%>").removeClass("Visible").addClass("InVisible");
                    $("#<%= pnlSearch.ClientID%>").removeClass("InVisible").addClass("Visible");
                    $("#<%= pnlEdit.ClientID%>").removeClass("Visible").addClass("InVisible");
                    $("#<%= pnlActDeact.ClientID%>").removeClass("Visible").addClass("InVisible");
                }
                else {
                    $("#<%= pnlActDeact.ClientID%>").removeClass("InVisible").addClass("Visible");
                    $("#<%= pnlAdd.ClientID%>").removeClass("Visible").addClass("InVisible");
                    $("#<%= pnlSearch.ClientID%>").removeClass("Visible").addClass("InVisible");
                    $("#<%= pnlEdit.ClientID%>").removeClass("Visible").addClass("InVisible");
                }
                return false;
            });
        });    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="0" cellspacing="0" class="RoundTop InnerTableStyle TableControl"
        width="90%">
        <tr>
            <td class="Header12 GridViewHeadercssTestAssessment RoundTop">
                <asp:Label ID="lblTitle" runat="server" Text="Topic" meta:resourcekey="lblTitleResource1"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <table cellpadding="0" cellspacing="0" class="ActionBarTable">
                    <tr>
                        <td>
                            <table cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td>
                                        <asp:ImageButton ID="ibtnSearch" runat="server" ImageUrl="~/App_Themes/Images/ButtonBarView.png"
                                            ToolTip="Search" meta:resourcekey="ibtnSearchResource1" />
                                    </td>
                                    <td>
                                        <asp:ImageButton ID="ibtnRefresh" runat="server" ImageUrl="~/App_Themes/Images/ButtonBarRefresh.png"
                                            OnClick="ibtnRefresh_Click" ToolTip="Refresh" meta:resourcekey="ibtnRefreshResource1" />
                                    </td>
                                    <td style="display: none;">
                                        <asp:ImageButton ID="ibtnAdd" runat="server" ImageUrl="~/App_Themes/Images/ButtonBarAdd.png"
                                            ToolTip="Add Topic" meta:resourcekey="ibtnAddResource1" />
                                    </td>
                                    <td>
                                        <asp:ImageButton ID="ibtnEdit" runat="server" ImageUrl="~/App_Themes/Images/ButtonBarEdit.png"
                                            OnClick="ibtnEdit_Click" ToolTip="Edit" meta:resourcekey="ibtnEditResource1" />
                                    </td>
                                    <td>
                                        <asp:ImageButton ID="ibtnActiveDeactive" runat="server" ImageUrl="~/App_Themes/Images/ButtonBarActiveDeactive.png"
                                            OnClick="ibtnActiveDeactive_Click" ToolTip="Active DeActive Topic" meta:resourcekey="ibtnActiveDeactiveResource1" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <asp:UpdatePanel ID="upDetails" runat="server">
                    <ContentTemplate>
                        <table id="tblGrid" cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td class="panel">
                                    <asp:Panel ID="pnlSearch" runat="server" CssClass="Visible" meta:resourcekey="pnlSearchResource1">
                                        <fieldset id="fsSearchInfo" runat="server" style="margin: 5px">
                                            <legend>
                                                <asp:Label ID="lblSearchTitle" runat="server" Text="Search" CssClass="SubTitle" meta:resourcekey="lblSearchTitleResource1"></asp:Label>
                                            </legend>
                                            <table class="tblControl1">
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblBMSIDSearch" runat="server" Text="BMS:" meta:resourcekey="lblBMSIDSearchResource1"></asp:Label>
                                                    </td>
                                                    <td colspan="3" style="text-align: left;">
                                                        <asp:DropDownList ID="ddlBMSSearch" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlBMSSearch_SelectedIndexChanged"
                                                            meta:resourcekey="ddlBMSSearchResource1">
                                                            <asp:ListItem Text="-- Select --" Value="0" meta:resourcekey="ListItemResource1"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblSubjectIDSearch" runat="server" Text="Subject:" meta:resourcekey="lblSubjectIDSearchResource1"></asp:Label>
                                                    </td>
                                                    <td style="text-align: left;">
                                                        <asp:DropDownList ID="ddlSubjectSearch" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSubjectSearch_SelectedIndexChanged"
                                                            meta:resourcekey="ddlSubjectSearchResource1">
                                                            <asp:ListItem Text="-- Select --" Value="0" meta:resourcekey="ListItemResource2"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblChapterIDSearch" runat="server" Text="Chapter:" meta:resourcekey="lblChapterIDSearchResource1"></asp:Label>
                                                    </td>
                                                    <td style="text-align: left;">
                                                        <asp:DropDownList ID="ddlChapterSearch" runat="server" AutoPostBack="True" meta:resourcekey="ddlChapterSearchResource1">
                                                            <asp:ListItem Text="-- Select --" Value="0" meta:resourcekey="ListItemResource3"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblTopicIndexSearch" runat="server" Text="TopicIndex:" meta:resourcekey="lblTopicIndexSearchResource1"></asp:Label>
                                                    </td>
                                                    <td style="text-align: left;">
                                                        <asp:TextBox ID="txtTopicIndexSearch" runat="server" meta:resourcekey="txtTopicIndexSearchResource1"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblTopicSearch" runat="server" Text="Topic:" meta:resourcekey="lblTopicSearchResource1"></asp:Label>
                                                    </td>
                                                    <td style="text-align: left;">
                                                        <asp:TextBox ID="txtTopicSearch" runat="server" meta:resourcekey="txtTopicSearchResource1"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblActive" runat="server" Text="Active:" meta:resourceKey="lblActiveResource1"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:RadioButtonList ID="rlstActive" runat="server" RepeatDirection="Horizontal">
                                                            <asp:ListItem Value="1" Text="Yes" meta:resourceKey="lblActiveListItemResource1"></asp:ListItem>
                                                            <asp:ListItem Value="0" Text="No" meta:resourceKey="lblActiveListItemResource2"></asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </td>
                                                    <td colspan="2" style="text-align: left;">
                                                        <asp:Button ID="btnSearch" ValidationGroup="aSearch" runat="server" Text="Go" AlternateText="Search"
                                                            OnClick="btnSearch_Click" meta:resourcekey="btnSearchResource2" />
                                                        <asp:Button ID="btnResetSearch" runat="server" Text="Reset" OnClick="btnResetSearch_Click"
                                                            meta:resourcekey="btnResetSearchResource1" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </fieldset>
                                    </asp:Panel>
                                    <asp:Panel ID="pnlAdd" runat="server" CssClass="InVisible" meta:resourcekey="pnlAddResource1">
                                        <fieldset id="fsAdd" runat="server" style="margin: 5px">
                                            <legend>
                                                <asp:Label ID="lblAddTitle" runat="server" Text="Add" CssClass="SubTitle" meta:resourcekey="lblAddTitleResource1"></asp:Label>
                                            </legend>
                                            <table class="tblControl1">
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblChapterID" runat="server" Text="ChapterID:" meta:resourcekey="lblChapterIDResource1"></asp:Label>
                                                    </td>
                                                    <td style="text-align: left;">
                                                        <asp:DropDownList ID="ddlChapterID" runat="server" AutoPostBack="True" meta:resourcekey="ddlChapterIDResource1">
                                                            <asp:ListItem Text="-- Select --" Value="0" meta:resourcekey="ListItemResource4"></asp:ListItem>
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="ReqFieldChapterID" runat="server" ErrorMessage="Please Insert ChapterID"
                                                            ValidationGroup="a" InitialValue="0" ControlToValidate="ddlChapterID" meta:resourcekey="ReqFieldChapterIDResource1">*</asp:RequiredFieldValidator>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblTopicIndex" runat="server" Text="TopicIndex:" meta:resourcekey="lblTopicIndexResource1"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtTopicIndex" runat="server" meta:resourcekey="txtTopicIndexResource1"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="ReqFieldTopicIndex" runat="server" ErrorMessage="Please Insert TopicIndex"
                                                            ValidationGroup="a" ControlToValidate="txtTopicIndex" meta:resourcekey="ReqFieldTopicIndexResource1">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblTopic" runat="server" Text="Topic:" meta:resourcekey="lblTopicResource1"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtTopic" runat="server" meta:resourcekey="txtTopicResource1"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="ReqFieldTopic" runat="server" ErrorMessage="Please Insert Topic"
                                                            ValidationGroup="a" ControlToValidate="txtTopic" meta:resourcekey="ReqFieldTopicResource1">*</asp:RequiredFieldValidator>
                                                    </td>
                                                    <td colspan="2" style="text-align: left;">
                                                        <asp:Button ID="btnSave" ValidationGroup="a" runat="server" Text="Save" AlternateText="Save"
                                                            OnClick="btnSave_Click" meta:resourcekey="btnSaveResource1" />
                                                        <asp:Button ID="btnCancel" runat="server" Text="Reset" OnClick="btnCancel_Click"
                                                            meta:resourcekey="btnCancelResource1" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4" align="center">
                                                        <asp:ValidationSummary ID="ValSumSYS_Topic" runat="server" ValidationGroup="a" meta:resourcekey="ValSumSYS_TopicResource1" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </fieldset>
                                    </asp:Panel>
                                    <asp:Panel ID="pnlEdit" runat="server" CssClass="InVisible" meta:resourcekey="pnlEditResource1">
                                        <fieldset id="fsEmpStdSubEdit" runat="server" style="margin: 5px">
                                            <legend>
                                                <asp:Label ID="lblEditTitle" runat="server" Text="Edit" CssClass="SubTitle" meta:resourceKey="lblEditTitleResource1"></asp:Label>
                                            </legend>
                                            <table class="tblControl1">
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblBMSIDEdit" runat="server" Text="BMSID:" meta:resourcekey="lblBMSIDEditResource1"></asp:Label>
                                                    </td>
                                                    <td colspan="3" style="text-align: left;">
                                                        <asp:DropDownList ID="ddlBMSEdit" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlBMSEdit_SelectedIndexChanged"
                                                            Enabled="False" meta:resourcekey="ddlBMSEditResource1">
                                                            <asp:ListItem Text="-- Select --" Value="0" meta:resourcekey="ListItemResource5"></asp:ListItem>
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="ReqFieldBMSIDEdit" InitialValue="0" runat="server"
                                                            ErrorMessage="Please Insert BMS" ValidationGroup="aEdit" ControlToValidate="ddlBMSEdit"
                                                            meta:resourcekey="ReqFieldBMSIDEditResource1">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblSubjectIDEdit" runat="server" Text="SubjectID:" meta:resourcekey="lblSubjectIDEditResource1"></asp:Label>
                                                    </td>
                                                    <td style="text-align: left;">
                                                        <asp:DropDownList ID="ddlSubjectEdit" runat="server" AutoPostBack="True" Enabled="False"
                                                            OnSelectedIndexChanged="ddlSubjectEdit_SelectedIndexChanged" meta:resourcekey="ddlSubjectEditResource1">
                                                            <asp:ListItem Text="-- Select --" Value="0" meta:resourcekey="ListItemResource6"></asp:ListItem>
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="ReqFieldSubjectIDEdit" InitialValue="0" runat="server"
                                                            ErrorMessage="Please Insert Subject" ValidationGroup="aEdit" ControlToValidate="ddlSubjectEdit"
                                                            meta:resourcekey="ReqFieldSubjectIDEditResource1">*</asp:RequiredFieldValidator>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblChapterIDEdit" runat="server" Text="ChapterID:" meta:resourcekey="lblChapterIDEditResource1"></asp:Label>
                                                    </td>
                                                    <td style="text-align: left;">
                                                        <asp:DropDownList ID="ddlChapterEdit" runat="server" AutoPostBack="True" Enabled="False"
                                                            meta:resourcekey="ddlChapterEditResource1">
                                                            <asp:ListItem Text="-- Select --" Value="0" meta:resourcekey="ListItemResource7"></asp:ListItem>
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="ReqFieldChapterIDEdit" runat="server" ControlToValidate="ddlChapterEdit"
                                                            ErrorMessage="Please Insert ChapterID" InitialValue="0" ValidationGroup="aEdit"
                                                            meta:resourcekey="ReqFieldChapterIDEditResource1">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblTopicIndexEdit" runat="server" Text="TopicIndex:" meta:resourcekey="lblTopicIndexEditResource1"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtTopicIndexEdit" runat="server" meta:resourcekey="txtTopicIndexEditResource1"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="ReqFieldTopicIndexEdit" runat="server" ErrorMessage="Please Insert TopicIndex"
                                                            ValidationGroup="aEdit" ControlToValidate="txtTopicIndexEdit" meta:resourcekey="ReqFieldTopicIndexEditResource1">*</asp:RequiredFieldValidator>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblTopicEdit" runat="server" Text="Topic:" meta:resourcekey="lblTopicEditResource1"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtTopicEdit" runat="server" meta:resourcekey="txtTopicEditResource1"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="ReqFieldTopicEdit" runat="server" ErrorMessage="Please Insert Topic"
                                                            ValidationGroup="aEdit" ControlToValidate="txtTopicEdit" meta:resourcekey="ReqFieldTopicEditResource1">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblIsActiveEdit" runat="server" Text="IsActive:" meta:resourcekey="lblIsActiveEditResource1"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:RadioButtonList ID="rlstEditActive" runat="server" RepeatDirection="Horizontal">
                                                            <asp:ListItem meta:resourceKey="lblActiveListItemResource1" Text="Yes" Value="1"></asp:ListItem>
                                                            <asp:ListItem meta:resourceKey="lblActiveListItemResource2" Text="No" Value="0"></asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </td>
                                                    <td colspan="2" style="text-align: left;">
                                                        <asp:Button ID="btnUpdate" ValidationGroup="aEdit" runat="server" Text="Update" AlternateText="Save"
                                                            OnClick="btnUpdate_Click" meta:resourcekey="btnUpdateResource1" />
                                                        <asp:Button ID="btnCancelEdit" runat="server" Text="Cancel" OnClick="btnCancelEdit_Click"
                                                            meta:resourcekey="btnCancelEditResource1" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" align="center">
                                                        <asp:ValidationSummary ID="ValSumSYS_TopicEdit" runat="server" ValidationGroup="aEdit"
                                                            meta:resourcekey="ValSumSYS_TopicEditResource1" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </fieldset>
                                    </asp:Panel>
                                    <asp:Panel ID="pnlActDeact" runat="server" CssClass="InVisible" meta:resourcekey="pnlActDeactResource1">
                                        <fieldset id="fsActDeact" runat="server" style="margin: 5px">
                                            <legend>
                                                <asp:Label ID="lblActDeactTitle" runat="server" Text="Active/Deactive " meta:resourcekey="lblActDeactTitleResource1"></asp:Label>
                                            </legend>
                                            <table cellspacing="1" style="margin: 5px" class="tblControl1">
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblPnlActDeactTitle" runat="server" Text="Please Select Action:" meta:resourcekey="lblPnlActDeactTitleResource1"></asp:Label>
                                                        <asp:RadioButton ID="rbActive" runat="server" Text=" Active" GroupName="ActDeact"
                                                            Checked="True" meta:resourcekey="rbActiveResource1" />
                                                        <asp:RadioButton ID="rbDeactive" runat="server" Text=" Deactive" GroupName="ActDeact"
                                                            meta:resourcekey="rbDeactiveResource1" />
                                                    </td>
                                                    <td>
                                                        <asp:Button ID="btnActDeactSub" runat="server" Text="Submit" CssClass="gobutton"
                                                            OnClick="btnActDeactSub_Click" meta:resourcekey="btnActDeactSubResource1" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </fieldset>
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:GridView ID="grvSYS_Topicdetail" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                        CellPadding="4" DataKeyNames="BMSID,SubjectID,TopicID,ChapterID,TopicIndex,Topic,IsActive,CreatedOn,CreatedBy"
                                        OnPageIndexChanging="grvSYS_Topicdetail_PageIndexChanging" OnSorting="grvSYS_Topicdetail_Sorting"
                                        OnRowCreated="grvSYS_Topicdetail_RowCreated" meta:resourcekey="grvSYS_TopicdetailResource1">
                                        <Columns>
                                            <asp:TemplateField meta:resourcekey="TemplateFieldResource1">
                                                <HeaderTemplate>
                                                    <table>
                                                        <tr>
                                                            <td align="center">
                                                                <asp:CheckBox ID="chkHeaderchkSelect" runat="server" onclick="javascript:SelectAll(this);"
                                                                    meta:resourcekey="chkHeaderchkSelectResource1" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <table>
                                                        <tr>
                                                            <td align="center">
                                                                <asp:CheckBox ID="chkSelect" runat="server" onclick="javascript:ChildClick(this);"
                                                                    meta:resourcekey="chkSelectResource1" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" Width="5px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Sr. No" meta:resourcekey="TemplateFieldResource2">
                                                <ItemTemplate>
                                                    <%# ((GridViewRow)Container).RowIndex + 1%></ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10px" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="BMSID" SortExpression="BMSID" HeaderText="BMSID" Visible="False"
                                                meta:resourcekey="BoundFieldResource1" />
                                            <asp:BoundField DataField="BMS" SortExpression="BMS" HeaderText="Board >> Medium >> Standard"
                                                meta:resourcekey="BoundFieldResource2" />
                                            <asp:BoundField DataField="SubjectID" SortExpression="SubjectID" HeaderText="SubjectID"
                                                Visible="False" meta:resourcekey="BoundFieldResource3" />
                                            <asp:BoundField DataField="Subject" SortExpression="Subject" HeaderText="Subject"
                                                meta:resourcekey="BoundFieldResource4" />
                                            <asp:BoundField DataField="ChapterID" SortExpression="ChapterID" HeaderText="ChapterID"
                                                Visible="False" meta:resourcekey="BoundFieldResource5" />
                                            <asp:BoundField DataField="Chapter" SortExpression="Chapter" HeaderText="Chapter"
                                                meta:resourcekey="BoundFieldResource6" />
                                            <asp:BoundField DataField="TopicIndex" SortExpression="TopicIndex" HeaderText="TopicIndex"
                                                meta:resourcekey="BoundFieldResource7"></asp:BoundField>
                                            <asp:BoundField DataField="TopicID" SortExpression="TopicID" HeaderText="TopicID"
                                                Visible="False" meta:resourcekey="BoundFieldResource8" />
                                            <asp:BoundField DataField="Topic" SortExpression="Topic" HeaderText="Topic" meta:resourcekey="BoundFieldResource9">
                                            </asp:BoundField>
                                            <asp:BoundField DataField="CreatedOn" SortExpression="CreatedOn" HeaderText="CreatedOn"
                                                DataFormatString="{0: dd-MMM-yyyy hh:mm ss}" meta:resourcekey="BoundFieldResource11">
                                                <ItemStyle Width="25px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="CreatedBy" SortExpression="CreatedBy" HeaderText="CreatedBy"
                                                meta:resourcekey="BoundFieldResource12"></asp:BoundField>
                                            <asp:BoundField DataField="Active" SortExpression="Active" HeaderText="Active" meta:resourcekey="BoundFieldResource10" />
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
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
