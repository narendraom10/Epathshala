<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Epathshala.master" AutoEventWireup="true"
    CodeFile="SendMessage.aspx.cs" Inherits="SchoolAdmin_SendMessage" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="width: 80%; margin: auto;">
        <div id="Div1" class="activitydivside1" runat="server" style="margin-bottom: 30px;">
            <div class="ActivityHeader">
                <asp:Label ID="lbltitle" runat="server" Text="Send Message"></asp:Label>
            </div>
            <div class="ActivityContent">
                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td colspan="2" style="padding-bottom: 25px;">
                            Note: This message will be sent to all students.&nbsp;&nbsp;Total Student: <span
                                id="totalstudenttop" runat="server"></span>
                        </td>
                    </tr>
                    <tr style="padding-top: 25px;">
                        <td style="width: 20%; text-align: right; height: 30px; padding-right: 10px;">
                            Message
                        </td>
                        <td style="padding-left: 5px;">
                            <asp:TextBox ID="txtMessage" TextMode="Multiline" Columns="30" Rows="4" runat="server"
                                Style="padding: 10px; height: 100px;" onkeyup="getCountDown();"></asp:TextBox>
                            &nbsp;&nbsp;Total Character: <span id="CharacterCount">0</span>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td style="padding-top: 15px;">
                            <asp:Button ID="btnsend" Text="Send Mesage" runat="server" OnClientClick="javascript:return SendMessageWorker();" />
                            &nbsp;&nbsp;Total Student: <span id="totalstudent" runat="server"></span>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <!-- LoaderPart start-->
        <asp:Button ID="btnLoader" runat="server" Style="display: none" />
        <asp:Button ID="btnCancel" runat="server" Style="display: none" />
        <ajaxToolkit:ModalPopupExtender ID="ModalPopup" runat="server" PopupControlID="dvPopup"
            CancelControlID="btnCancel" TargetControlID="btnLoader" BackgroundCssClass="modalBackground"
            Enabled="True">
        </ajaxToolkit:ModalPopupExtender>
        <table id="dvPopup" runat="server" cellpadding="0" cellspacing="0" style="min-width: 350px;
            min-height: 200px; background-color: White;">
            <tr>
                <td colspan="2" style="padding-top: 15px; padding-left: 40px;">
                    <img id="ldimg" runat="server" src="../App_Themes/Responsive/web/Loader.gif" alt="Loading Please wait.." />
                </td>
            </tr>
            <tr style="text-align: center; font-weight: bold; font-size: 14px;">
                <td style="width: 50%; padding: 5px;">
                    Success: <span id="totalsuccess"></span>
                </td>
                <td>
                    Failed: <span id="totalfail"></span>
                </td>
            </tr>
            <tr id="clsbtn" runat="server" style="display: none;">
                <td colspan="2" style="text-align: center; height: 50px; padding-bottom: 10px;">
                    <div style="display: inline-block; background-color: #3a3d91; cursor: pointer; border: medium none;
                        border-radius: 1.5px; box-shadow: 0 1px 0.05em #000; color: #fff; font-size: 15px;
                        font-weight: 400; margin: 5px; padding: 5px 10px; position: relative;" onclick="javascript:return CloseProgressMessage();">
                        Close
                    </div>
                </td>
            </tr>
        </table>
        <!-- LoaderPart end-->
    </div>
    <script type="text/javascript">
        var successcount = 0;
        var failcount = 0;
        var totalstudent = 0;
        function getCountDown() {
            document.getElementById('CharacterCount').innerHTML = document.getElementById("<%= txtMessage.ClientID %>").value.length;
            return false;
        }
        function SendMessageWorker() {
            var message = document.getElementById('<%= txtMessage.ClientID %>').value;
            if (message != null && message != '') {
                showloader();
                document.getElementById('totalsuccess').innerHTML = successcount;
                document.getElementById('totalfail').innerHTML = failcount;
                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    url: "../SchoolAdmin/SendMessage.aspx/GETSTUDENTDATA",
                    data: "",
                    success: function (Result) {
                        try {
                            Result = Result.d;
                            totalstudent = Result.length;
                            if (totalstudent == 0) {
                                hideimage()
                                return;
                            }
                            for (var i = 0; i < Result.length; i++) {
                                SendSingleMessage(Result[i].Key, Result[i].Value, message);
                            }
                        } catch (e) {
                            return;
                        }
                    },
                    error: function (result) {
                        alert("Error");
                    }
                });
            }
            else {
                alert('You can not send blank message.');
            }
            return false;
        }
        function SendSingleMessage(studentid, number, message) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                url: "../SchoolAdmin/SendMessage.aspx/SENDMESSAGE",
                data: "{'studentid':'" + studentid + "','number':'" + number + "','message':'" + message + "'}",
                success: function (Result) {
                    try {
                        if (Result.d == true) {
                            successcount = successcount + 1;
                            document.getElementById('totalsuccess').innerHTML = successcount;
                            hideimage();
                        }
                        else if (Result.d == false) {
                            failcount = failcount + 1;
                            document.getElementById('totalfail').innerHTML = failcount;
                            hideimage();
                        }
                    } catch (e) {
                        return;
                    }
                },
                error: function (result) {
                    failcount = failcount + 1;
                }
            });
        }
        function showloader() {
            if ($("#<%= btnLoader.ClientID%>") != null) {
                $("#<%= btnLoader.ClientID%>").click();
            }
        }
        function hideloader() {
            if ($("#<%= btnCancel.ClientID%>") != null) {
                $("#<%= btnCancel.ClientID%>").click();
            }
        }
        function hideimage() {
            if (totalstudent <= (successcount + failcount)) {
                document.getElementById('<%=ldimg.ClientID %>').style.display = 'none';
                document.getElementById('<%=clsbtn.ClientID %>').style.display = '';
            }
        }
        function CloseProgressMessage() {
            successcount = 0;
            failcount = 0;
            totalstudent = 0;
            document.getElementById('totalsuccess').innerHTML = successcount;
            document.getElementById('totalfail').innerHTML = failcount;
            document.getElementById('<%=ldimg.ClientID %>').style.display = '';
            document.getElementById('<%=clsbtn.ClientID %>').style.display = 'none';
            hideloader();
        }
    </script>
</asp:Content>
