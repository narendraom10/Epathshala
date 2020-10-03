<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Epathshala.master" AutoEventWireup="true"
    CodeFile="SubjectWiseTestStepOne.aspx.cs" Inherits="Teacher_SubjectWiseTestStepOne" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="upMainExam" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div style="width: 80%; margin: auto;">
                <div class="activitydivside1" id="Div1" runat="server" visible="true">
                    <div class="ActivityHeader">
                        <asp:Label ID="Label1" runat="server" Text="Test Parameters"></asp:Label>
                    </div>
                    <div class="ActivityContent">
                        <table>
                            <tr>
                                <td style="width: 20%; padding-left: 5px; padding-top: 5px; text-align: right; padding-right: 20px;">
                                    <asp:Label ID="lblBMSText" Text="BMS" runat="server" />:
                                </td>
                                <td style="width: 80%; padding-left: 5px; padding-top: 5px;">
                                    <asp:Label ID="lblBMS" Text="" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td style="padding-left: 5px; padding-top: 5px; text-align: right; padding-right: 20px;">
                                    <asp:Label ID="lblsubjecttext" Text="Subject" runat="server" />:
                                </td>
                                <td style="padding-left: 5px; padding-top: 5px;">
                                    <asp:Label ID="lblsubject" Text="text" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td style="padding-left: 5px; padding-top: 5px; text-align: right; padding-right: 20px;">
                                    <asp:Label ID="lbldivisiontext" Text="Division" runat="server" />:
                                </td>
                                <td style="padding-left: 5px; padding-top: 5px;">
                                    <asp:Label ID="lbldivision" Text="text" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td style="padding-left: 5px; padding-top: 5px; text-align: right; padding-right: 20px;">
                                    <asp:Label ID="Label2" Text="Chapter" runat="server" />:
                                </td>
                                <td style="padding-top: 5px;">
                                    <asp:DropDownList ID="ddlselectoption" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlselectoption_SelectedIndexChanged"
                                        Width="180px">
                                        <asp:ListItem Text="-- Select --" Value=""></asp:ListItem>
                                        <asp:ListItem Text="All Chpater" Value="All"></asp:ListItem>
                                        <asp:ListItem Text="Covered Chapters" Value="Covered"></asp:ListItem>
                                        <asp:ListItem Text="Uncovered Chapters" Value="Uncovered"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                        <asp:Label ID="lblBMSID" Text="text" runat="server" Style="display: none;" />
                        <asp:Label ID="lblsubjectID" Text="text" runat="server" Style="display: none;" />
                        <asp:Label ID="lbldivisionID" Text="text" runat="server" Style="display: none;" />
                        <div style="float: right;">
                        </div>
                    </div>
                </div>
            </div>
            <div style="width: 80%; margin: auto; margin-top: 30px;">
                <div class="activitydivside1" id="SecondRpt" runat="server" visible="true">
                    <div class="ActivityHeader">
                        <asp:Label ID="Label3" runat="server" Text="Select Chapters"></asp:Label>
                    </div>
                    <div class="ActivityContent">
                        <asp:GridView ID="GVChapter" runat="server" AutoGenerateColumns="False" SkinID="NoPaging"
                            OnRowDataBound="GVChapter_RowDataBound">
                            <Columns>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <input type="checkbox" id="chkAll" runat="server" onclick="javascript:checkAll(this);" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkSelect" runat="server" onclick="javascript:checkOne(this);" />
                                        <%--<asp:HiddenField ID="hdnchapterSingle" runat="server" Value='<%# Eval("ChapterID") %>' />--%>
                                        <asp:HiddenField ID="hdnBMSSCTID" runat="server" Value='<%# Eval("BMSSCTID") %>' />
                                    </ItemTemplate>
                                    <ItemStyle CssClass="GridViewRows" Width="10%" HorizontalAlign="Center" VerticalAlign="Top" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="SNo.">
                                    <ItemTemplate>
                                        <asp:Label ID="GV_LblSRNO" runat="server" Text='<%# Container.DataItemIndex+1 %>' /></ItemTemplate>
                                    <ItemStyle CssClass="GridViewRows" Width="10%" HorizontalAlign="Center" VerticalAlign="Top" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Chapter>>Topic">
                                    <ItemTemplate>
                                        <asp:Label ID="GV_LblChapterName" runat="server" Text='<%#Eval("Chapter") %>' /></ItemTemplate>
                                    <ItemStyle CssClass="GridViewRows" Width="25%" HorizontalAlign="Left" VerticalAlign="Top" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Total Question">
                                    <ItemTemplate>
                                        <asp:Label ID="GV_Lbltq" runat="server" Text='<%#Eval("TotalQuestion") %>' /></ItemTemplate>
                                    <ItemStyle CssClass="GridViewRows" Width="25%" HorizontalAlign="Left" VerticalAlign="Top" />
                                </asp:TemplateField>
                            </Columns>
                            <EmptyDataTemplate>
                                <div style="text-align: center; color: black">
                                    No Search Result Found</div>
                            </EmptyDataTemplate>
                        </asp:GridView>
                    </div>
                </div>
            </div>
            <div style="width: 80%; margin: auto; margin-top: 30px;">
                <div class="activitydivside1" id="Div2" runat="server" visible="true">
                    <div class="ActivityHeader">
                        <asp:Label ID="Label4" runat="server" Text="Number Of Question"></asp:Label>
                    </div>
                    <div class="ActivityContent">
                        <table>
                            <tr>
                                <td style="width: 20%; padding-left: 5px; padding-top: 5px; text-align: right; padding-right: 20px;
                                    white-space: nowrap;">
                                    <asp:Label ID="tblTotalQuestiionText" Text="Total Question" runat="server" />
                                </td>
                                <td style="width: 80%; padding-left: 5px; padding-top: 5px;">
                                    <asp:Label ID="tblTotalQuestiionValue" Text="" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td style="padding-left: 5px; padding-top: 5px; text-align: right; padding-right: 20px;
                                    white-space: nowrap;">
                                    <asp:Label ID="Label5" Text="Number of Question" runat="server" />
                                </td>
                                <td style="padding-left: 5px; padding-top: 5px;">
                                    <asp:TextBox runat="server" ID="txtNumQue" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
            <div style="width: 80%; margin: auto; text-align: center; margin-top: 25px;">
                <asp:Button ID="btnsearcksubmit" runat="server" Text="Take Test" OnClick="btnsearcksubmit_Click"
                    OnClientClick="javascript:return ValidateCount();" />
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="ddlselectoption" />
        </Triggers>
    </asp:UpdatePanel>
    <!-- LoaderPart start-->
    <asp:Button ID="btnLoader" runat="server" Style="display: none" />
    <asp:Button ID="btnCancel" runat="server" Style="display: none" />
    <cc1:ModalPopupExtender ID="ModalPopup" runat="server" PopupControlID="dvPopup" CancelControlID="btnCancel"
        TargetControlID="btnLoader" BackgroundCssClass="modalBackground" Enabled="True">
    </cc1:ModalPopupExtender>
    <table id="dvPopup" runat="server" class="loadingtable" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <img src="../App_Themes/Responsive/web/Loader.gif" alt="Loading Please wait.." />
            </td>
        </tr>
        <tr>
            <td class="loadingtabletd">
                <span>Loading Please Wait..</span>
            </td>
        </tr>
    </table>
    <!-- LoaderPart end-->
    <script type="text/javascript">
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_beginRequest(BeginRequestHandler);
        prm.add_endRequest(EndRequestHandler);
        function BeginRequestHandler(sender, args) {
            if ($("#<%= btnLoader.ClientID%>") != null) {
                $("#<%= btnLoader.ClientID%>").click();
            }
        }

        function EndRequestHandler(sender, args) {
            if ($("#<%= btnCancel.ClientID%>") != null) {
                $("#<%= btnCancel.ClientID%>").click();
            }
        }
        function checkAll(CheckBox) {
            try {
                if (CheckBox.checked == true) {
                    var TargetBaseControl = document.getElementById('<%= GVChapter.ClientID %>');
                    var Inputs = TargetBaseControl.getElementsByTagName("input");
                    for (var n = 0; n < Inputs.length; ++n) {
                        var headerCheckBox = Inputs[0];
                        if (Inputs[n].type == 'checkbox' && Inputs[n] != headerCheckBox && Inputs[n].disabled == false) {
                            Inputs[n].checked = true;
                        }
                    }
                }
                else {
                    var TargetBaseControl = document.getElementById('<%= GVChapter.ClientID %>');
                    var Inputs = TargetBaseControl.getElementsByTagName("input");
                    for (var n = 0; n < Inputs.length; ++n) {
                        var headerCheckBox = Inputs[0];
                        if (Inputs[n].type == 'checkbox' && Inputs[n] != headerCheckBox && Inputs[n].disabled == false) {
                            Inputs[n].checked = false;
                        }
                    }
                }
                SetTotalCount();
            }
            catch (e) {
                alert("Error");
            }
        }
        function checkOne(CheckBox) {
            var checked = true;
            var TargetBaseControl = document.getElementById('<%= GVChapter.ClientID %>');
            var Inputs = TargetBaseControl.getElementsByTagName("input");
            for (var n = 0; n < Inputs.length; ++n) {
                var headerCheckBox = Inputs[0];
                if (Inputs[n].type == 'checkbox' && Inputs[n] != headerCheckBox && Inputs[n].disabled == false) {
                    if (Inputs[n].checked == false) {
                        checked = false;
                        break;
                    }
                }
            }
            headerCheckBox.checked = checked;
            SetTotalCount();
        }
        function ValidateCount() {
            try {
                if ($("#<%= txtNumQue.ClientID%>").val() == '' || $("#<%= txtNumQue.ClientID%>").val() == null) {
                    alert('Please enter number of questions.');
                    return false;
                }
                var TotalQuestion = 0;
                var GridRow = document.getElementById("<%=GVChapter.ClientID %>");
                for (i = 1; i < GridRow.rows.length; i++) {
                    if ((GridRow.rows[i].cells[0].getElementsByTagName("INPUT")[0].checked)) {
                        TotalQuestion = parseInt(TotalQuestion, 10) + parseInt(GridRow.rows[i].cells[3].getElementsByTagName("span")[0].innerHTML, 10);
                    }
                }
                if (parseInt($("#<%= txtNumQue.ClientID%>").val(), 10) == 0) {
                    alert("Please enter valid number of questions.");
                }
                else if (parseInt($("#<%= txtNumQue.ClientID%>").val(), 10) <= TotalQuestion) {
                    return true;
                }
                else {
                    alert('Number of questions should be less than total question.');
                    return false;
                }
            } catch (e) {
                alert('Please reload the page and try again.');
                return false;
            }
        }
        function SetTotalCount() {
            var TotalQuestion = 0;
            var GridRow = document.getElementById("<%=GVChapter.ClientID %>");
            for (i = 1; i < GridRow.rows.length; i++) {
                if ((GridRow.rows[i].cells[0].getElementsByTagName("INPUT")[0].checked)) {
                    TotalQuestion = parseInt(TotalQuestion, 10) + parseInt(GridRow.rows[i].cells[3].getElementsByTagName("span")[0].innerHTML, 10);
                }
            }
            document.getElementById('<%= tblTotalQuestiionValue.ClientID %>').innerHTML = TotalQuestion;
        }
    </script>
</asp:Content>
