<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Epathshala.master" AutoEventWireup="true"
    CodeFile="StandardAllocation.aspx.cs" Inherits="Admin_StandardAllocation" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="up1" runat="server" class="tblDashboard">
        <ContentTemplate>
            <div class="sidepanel">
                <div class="activitydivside">
                    <div class="ActivityHeader">
                        <asp:Label ID="LblPageTitle" runat="server" Text="School Details" meta:resourcekey="LblPageTitleResource1"></asp:Label>
                    </div>
                    <div>
                        <p>
                            </li>
                        </p>
                        <ul class="standarbtn">
                            <li class="standarbar">
                                <asp:ImageButton ID="ImgBtnActivate" runat="server" ImageUrl="~/App_Themes/Responsive/web/activeuser.png"
                                    OnClick="ImgBtnActivate_Click" OnClientClick="javascript:return selectmessage();" />
                            </li>
                        </ul>
                    </div>
                    <div id="PnlSearch" runat="server" meta:resourcekey="PnlSearchResource1" visible="false">
                        <div class="subheaduserdetail" id="LblFLSearch" runat="server" meta:resourcekey="LblFLSearchResource1">
                            Search</div>
                        <div class="ActivityContent">
                            <div>
                                <asp:Label ID="LblSchoolName" runat="server" Text="School Name:" CssClass="textlabel"
                                    meta:resourceKey="LblSchoolNameResource1"></asp:Label></div>
                            <div>
                                <asp:Literal ID="LtSchoolID" runat="server" Visible="False" meta:resourceKey="LtSchoolIDResource1"></asp:Literal>
                                <asp:DropDownList ID="ddlSchool" runat="server" Width="100%" AutoPostBack="True"
                                    OnSelectedIndexChanged="ddlSchool_SelectedIndexChanged">
                                    <asp:ListItem Text="-- Select --"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div>
                                <asp:Label ID="lblAllocated" runat="server" Text="Allocated:" CssClass="textlabel"
                                    meta:resourceKey="lblActiveResource1"></asp:Label>
                                <asp:RadioButtonList ID="rlstAllocated" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="1" Text="Yes"></asp:ListItem>
                                    <asp:ListItem Value="0" Text="No"></asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                            <div class="gobotton">
                                <asp:Button ID="BtnGo" runat="server" Text="Go" CssClass="gobutton" ValidationGroup="VGSearch"
                                    meta:resourceKey="BtnGoResource1" OnClick="BtnGo_Click" />
                                <asp:Button ID="BtnReset" runat="server" Text="Reset" CssClass="gobutton" OnClick="BtnReset_Click" />
                                <asp:ValidationSummary ID="VsSearch" ValidationGroup="VGSearch" ShowMessageBox="True"
                                    ShowSummary="False" runat="server" meta:resourceKey="VsSearchResource1" />
                            </div>
                        </div>
                    </div>
                    <div id="PnlActivateDeactivate" runat="server" visible="false" meta:resourcekey="PnlActivateDeactivateResource1">
                        <div class="subheaduserdetail" id="LblFlActDect" runat="server" cssclass="SubTitle"
                            meta:resourcekey="LblFlActDectResource1">
                            Allocate/Deallocate User
                        </div>
                        <div class="ActivityContent" style="margin-right: 5px;">
                            <div>
                                <asp:Label ID="LblActiveAction" runat="server" Text="Action:" CssClass="textlabel"
                                    meta:resourceKey="LblActiveActionResource1"></asp:Label>
                                <asp:RadioButton ID="RdbAllocated" runat="server" Text="Allocate" GroupName="ActDeact"
                                    Checked="True" meta:resourceKey="RdbActiveResource1" />
                                <asp:RadioButton ID="RdbDeallocated" runat="server" Text="Deallocate" GroupName="ActDeact"
                                    meta:resourceKey="RdbDeactiveResource1" />
                            </div>
                            <div class="gobotton">
                                <asp:Button ID="BtnActDeactSub" runat="server" Text="Submit" CssClass="gobutton"
                                    OnClick="BtnActDeactSub_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="sidepanel1">
                <div class="activitydivside1">
                    <div class="ActivityHeader">
                        Standard List
                    </div>
                    <div class="ActivityContent">
                        <asp:CheckBoxList ID="ChkUserList" runat="server" CssClass="chkChoice">
                        </asp:CheckBoxList>
                        <asp:GridView ID="GvStandard" runat="server" DataKeyNames="Standard,Allocated,BMSID"
                            OnPageIndexChanging="GvUserList_PageIndexChanging" OnRowCreated="grvEmpStdSubAllocationDetails_RowCreated"
                            AutoGenerateColumns="False" Style="margin-top: 0px">
                            <Columns>
                                <asp:BoundField DataField="UserID" HeaderText="UserID" Visible="False" meta:resourcekey="BoundFieldResource1" />
                                <asp:TemplateField HeaderText="Select" meta:resourcekey="TemplateFieldResource1"
                                    ItemStyle-HorizontalAlign="Center">
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="chkSelectHeader" runat="server" onclick="javascript:SelectAllCheckboxes(this);" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="ChkUserID" runat="server" meta:resourcekey="ChkUserIDResource1" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Standard" HeaderText="Standard" />
                                <asp:BoundField DataField="Allocated" HeaderText="Allocated" />
                                <asp:BoundField DataField="BMSID" HeaderText="BMSID" Visible="false" />
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
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <script type="text/javascript">
        function selectmessage() {
            var TargetBaseControl = document.getElementById('<%= GvStandard.ClientID %>');
            var AllTick = false;
            var Inputs = TargetBaseControl.getElementsByTagName("input");
            for (var n = 0; n < Inputs.length; ++n)
                if (Inputs[n].type == 'checkbox')
                    if (Inputs[n].checked == true) {
                        AllTick = true;
                        break;
                    }
            if (AllTick == false) {
                alert("Please select atleast one record.");
                return false;
            }
            else {
                return true;
            }
        }
    </script>
</asp:Content>
