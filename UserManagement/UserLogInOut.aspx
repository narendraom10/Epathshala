<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Epathshala.master" AutoEventWireup="true"
    CodeFile="UserLogInOut.aspx.cs" Inherits="UserManagement_UserLogInOut" Culture="auto"
    meta:resourcekey="PageResource1" UICulture="auto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="../Scripts/Jquery1.9.1.js" type="text/javascript"></script>
    <%-- <script type="text/javascript">
        $(document).ready(function () {

            $("#<%= ibtnSearch.ClientID%>").click(function () {
                if ($("#<%= pnlSearch.ClientID%>").is(':visible')) {
                    $("#<%= pnlSearch.ClientID%>").removeClass("Visible").addClass("InVisible");
                } else {
                    $("#<%= pnlSearch.ClientID%>").removeClass("InVisible").addClass("Visible");
                }
                return false;
            });

        });
    </script>--%>
    <script type="text/javascript">
        var TotalChkBx;
        var Counter;

        Counter = 0;


        function SelectAll(CheckBox) {

            var TargetBaseControl = document.getElementById('<%= this.gvLogInOutDetails.ClientID %>');

            var TargetChildControl = "chkselect";
            var Inputs = TargetBaseControl.getElementsByTagName("input");
            for (var n = 0; n < Inputs.length; ++n)
                if (Inputs[n].type == 'checkbox')
                    Inputs[n].checked = CheckBox.checked;
            Counter = CheckBox.checked ? TotalChkBx : 0;
        }

        function ChildClick(CheckBox) {

            TotalChkBx = parseInt('<%= this.gvLogInOutDetails.Rows.Count %>');

            var HeaderCheckBox = document.getElementById('ctl00_ContentPlaceHolder1_gvLogInOutDetails_ctl01_chkHeaderchkSelect');
            if (CheckBox.checked && Counter < TotalChkBx)
                Counter++;
            else if (Counter > 0)
                Counter--;
            if (Counter < TotalChkBx)
                HeaderCheckBox.checked = false;
            else if (Counter == TotalChkBx)
                HeaderCheckBox.checked = true;
        }         
    
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="sidepanel">
        <div class="activitydivside">
            <div class="ActivityHeader">
                <asp:Label ID="LblPageTitle" runat="server" Text="User Details" meta:resourcekey="LblPageTitleResource1"></asp:Label>
            </div>
            <div>
                <ul class="standarbtn">
                    <li class="standarbar">
                        <asp:ImageButton ID="ibtnSearch" runat="server" ImageUrl="~/App_Themes/Responsive/web/searchuser.png"
                            ToolTip="Search" meta:resourcekey="ImgBtnSearchResource1" />
                    </li>
                    <li class="standarbar">
                        <asp:ImageButton ID="ibtnRefresh" runat="server" ImageUrl="~/App_Themes/Responsive/web/rectreload.png"
                            ToolTip="Refresh" meta:resourcekey="ImgBtnRefreshResource1" OnClick="ibtnRefresh_Click" />
                    </li>
                    <li class="standarbar">
                        <asp:ImageButton ID="ibtnLogout" runat="server" ImageUrl="~/App_Themes/Responsive/web/activeuser.png"
                            ToolTip="Log Out Users" meta:resourcekey="ImgBtnActivateResource1" OnClick="ibtnLogout_Click" />
                    </li>
                </ul>
            </div>
            <div id="Div1" runat="server" meta:resourcekey="PnlSearchResource1">
                <div class="subheaduserdetail" id="LblFLSearch" runat="server" meta:resourcekey="LblFLSearchResource1">
                    Search</div>
                <div class="ActivityContent">
                    <div >
                        <asp:Label ID="lblUserID" runat="server" Text="User ID:" meta:resourcekey="lblUserIDResource1" style="margin-right:10px;"></asp:Label>
                         <asp:TextBox ID="txtUserID" runat="server" 
                            meta:resourcekey="txtUserIDResource1" Height="24px" Width="164px"></asp:TextBox>
                    </div>
                    <br />
                  
                    <div >
                        <asp:Label ID="lblEmployeeName" runat="server" Text="Name:" meta:resourcekey="lblEmployeeNameResource1" style="margin-right:20px;" ></asp:Label>
                        <asp:TextBox ID="txtEmployeeName" runat="server" meta:resourcekey="txtEmployeeNameResource1" Height="24px" Width="164px"></asp:TextBox>
                    </div>
                    <div class="gobotton">
                        <asp:Button ID="btnGo" runat="server" CssClass="gobutton" Text="Go" OnClick="btnGo_Click"
                            meta:resourcekey="btnGoResource1" />
                        <asp:Button ID="btnSearchReset" runat="server" Text="Reset" OnClick="btnSearchReset_Click"
                            meta:resourcekey="btnSearchResetResource1" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="sidepanel1">
        <div class="activitydivside1">
            <div class="ActivityHeader">
                List
            </div>
            <div class="ActivityContent">
                <asp:GridView ID="gvLogInOutDetails" runat="server" DataKeyNames="EmployeeID" meta:resourcekey="gvLogInOutDetailsResource1">
                    <Columns>
                        <asp:TemplateField meta:resourcekey="TemplateFieldResource1">
                            <HeaderTemplate>
                                <table>
                                    <tr>
                                        <td align="center">
                                            <asp:CheckBox ID="chkHeaderchkSelect" runat="server" onclick="javascript:SelectAll(this);"
                                                meta:resourcekey="chkheaderResource1" />
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
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Sr. No" meta:resourcekey="TemplateFieldResource2">
                            <ItemTemplate>
                                <%# Container.DataItemIndex +1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="employeeName" HeaderText="Name" meta:resourcekey="BoundFieldResource1" />
                        <asp:BoundField DataField="LoginID" HeaderText="User ID" meta:resourcekey="BoundFieldResource2" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
