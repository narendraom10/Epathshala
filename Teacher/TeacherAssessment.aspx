<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TeacherAssessment.aspx.cs"
    Inherits="Teacher_TeacherAssessment" MaintainScrollPositionOnPostback="true" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ePathshala</title>
    <script type="text/javascript" src="../JavaScript/ASCIIMathML.js"></script>
    <script type="text/javascript" src="../JavaScript/jquery-1.4.2.js"></script>
    <script>
        var start = new Date();
        function startTime() {
            var today = new Date();
            var h = today.getHours();
            var m = today.getMinutes();
            var s = today.getSeconds();
            m = checkTime(m);
            s = checkTime(s);

            var elapsed_ms = today - start;
            var seconds = Math.round(elapsed_ms / 1000);
            var minutes = Math.round(seconds / 60);
            var hours = Math.round(minutes / 60);

            var sec = TrimSecondsMinutes(seconds);
            var min = TrimSecondsMinutes(minutes);
            var hr = TrimSecondsMinutes(hours);

            sec = checkTime(sec);
            min = checkTime(min);
            hr = checkTime(hr);

            document.getElementById('txt').innerHTML = h + ":" + m + ":" + s;
            document.getElementById('txt2TimeLap').innerHTML = hr + ":" + min + ":" + sec;

            var t = setTimeout(function () { startTime() }, 500);
        }
        function TrimSecondsMinutes(elapsed) {
            if (elapsed >= 60)
                return TrimSecondsMinutes(elapsed - 60);
            return elapsed;
        }
        function checkTime(i) {
            if (i < 10) { i = "0" + i };  // add zero in front of numbers < 10
            return i;
        }
    </script>
    <script type="text/javascript" language="javascript">
        window.history.forward(-1);
    </script>
    <style type="text/css">
        .studentidvisibility
        {
            display: none;
            visibility: hidden;
        }
    </style>
    
<script>
    (function (i, s, o, g, r, a, m) {
        i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {
            (i[r].q = i[r].q || []).push(arguments)
        }, i[r].l = 1 * new Date(); a = s.createElement(o),
  m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
    })(window, document, 'script', '//www.google-analytics.com/analytics.js', 'ga');

    ga('create', 'UA-69363607-1', 'auto');
    ga('send', 'pageview');

</script>

</head>
<body onload="startTime()">
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <Triggers>
                <%--<asp:PostBackTrigger ControlID="BtnButton" />--%>
                <asp:PostBackTrigger ControlID="BtnButton" />
                <asp:PostBackTrigger ControlID="Menu1" />
            </Triggers>
            <ContentTemplate>
                <script>
                    var start = new Date();
                    function startTime() {
                        var today = new Date();
                        var h = today.getHours();
                        var m = today.getMinutes();
                        var s = today.getSeconds();
                        m = checkTime(m);
                        s = checkTime(s);

                        var elapsed_ms = today - start;
                        var seconds = Math.round(elapsed_ms / 1000);
                        var minutes = Math.round(seconds / 60);
                        var hours = Math.round(minutes / 60);

                        var sec = TrimSecondsMinutes(seconds);
                        var min = TrimSecondsMinutes(minutes);
                        var hr = TrimSecondsMinutes(hours);

                        sec = checkTime(sec);
                        min = checkTime(min);
                        hr = checkTime(hr);

                        document.getElementById('txt').innerHTML = h + ":" + m + ":" + s;
                        document.getElementById('txt2TimeLap').innerHTML = hr + ":" + min + ":" + sec;

                        var t = setTimeout(function () { startTime() }, 500);
                    }
                    function TrimSecondsMinutes(elapsed) {
                        if (elapsed >= 60)
                            return TrimSecondsMinutes(elapsed - 60);
                        return elapsed;
                    }
                    function checkTime(i) {
                        if (i < 10) { i = "0" + i };  // add zero in front of numbers < 10
                        return i;
                    }
                </script>
                <table width="100%" id="timertbl" runat="server">
                    <tr>
                        <td align="center">
                            <asp:Label ID="lblcurrentTime" runat="server" Text="Current Time"></asp:Label>
                        </td>
                        <td align="center">
                            <asp:Label ID="lbltimelaps" runat="server" Text="Time Lap"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <div id="txt" style="min-height: 20px">
                            </div>
                        </td>
                        <td align="center">
                            <div id="txt2TimeLap" style="min-height: 20px">
                            </div>
                        </td>
                    </tr>
                </table>
                <asp:Menu ID="Menu1" Orientation="Horizontal" runat="server" meta:resourcekey="Menu1Resource1"
                    OnMenuItemClick="Menu1_MenuItemClick">
                    <StaticMenuItemStyle CssClass="tab" />
                    <StaticSelectedStyle CssClass="tabSelected" />
                    <StaticHoverStyle CssClass="tabhover" />
                </asp:Menu>
                <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="1">
                    <asp:View ID="vwExam" runat="server">
                        <script type="text/javascript" src="../JavaScript/ASCIIMathML.js"></script>
                        <table width="100%" id="Examtbl" runat="server">
                            <tr id="Tr1" runat="server">
                                <td id="Td1" runat="server">
                                    <table width="100%" cellspacing="0">
                                        <tr>
                                            <td width="100%">
                                                <div class="QuestionHead">
                                                    <asp:Literal ID="ltQuestionCount" Text="Question No" runat="server" meta:resourcekey="ltQuestionCountResource1"></asp:Literal>
                                                    <asp:Literal ID="ltQuestionCount1" runat="server" meta:resourcekey="ltQuestionCount1Resource1"></asp:Literal>
                                                    <asp:Literal ID="ltQuestionCount2" Text="out of" runat="server" meta:resourcekey="ltQuestionCount2Resource1"></asp:Literal>
                                                    <asp:Literal ID="ltQuestionCount3" Text="Question No 1 out of 20" runat="server"
                                                        meta:resourcekey="ltQuestionCount3Resource1"></asp:Literal>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr id="Tr2" runat="server">
                                <td id="Td2" runat="server">
                                    <table width="100%" cellspacing="0">
                                        <tr>
                                            <td align="left" valign="top" class="QuestionText" style="width: 12%">
                                                <div style="height: 20px; overflow: hidden; padding-top: 5px; color: #c5222a;">
                                                    <asp:Label ID="Label1" runat="server" CssClass="TextHoverUnhover" Font-Bold="true"
                                                        meta:resourcekey="lblQuesResource1" Text="Question"></asp:Label>
                                                </div>
                                            </td>
                                            <td align="left" valign="bottom" class="QuestionText">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" valign="top" class="QuestionText" valign="top" colspan="2" style="color: #666666;
                                                font-weight: bold; padding: 5px;">
                                                <div>
                                                    <asp:Label ID="lblQues" runat="server" Text="Question" meta:resourcekey="lblQuesResource1"></asp:Label>
                                                    <asp:Literal ID="ltQuestion" runat="server" meta:resourcekey="ltQuestionResource1"></asp:Literal>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <asp:RadioButtonList ID="rdb" runat="server" CellSpacing="10" Width="100%" CssClass="RadioClass"
                                                    meta:resourcekey="rdbResource1" ValidationGroup="Exm">
                                                </asp:RadioButtonList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 12%">
                                            </td>
                                            <td align="left" valign="bottom" class="QuestionText">
                                                <asp:Button ID="BtnButton" runat="server" SkinID="NextBtn" Text="Next" OnClick="BtnButton_Click"
                                                    ValidationGroup="Exm" meta:resourcekey="BtnButtonResource1" /><br />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="rdb"
                                                    ValidationGroup="Exm" ErrorMessage="Kindly select an option as answer." meta:resourcekey="RequiredFieldValidator1Resource1"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr id="Tr3" runat="server">
                                <td id="Td3" runat="server">
                                </td>
                            </tr>
                            <tr id="Tr4" runat="server">
                                <td id="Td4" runat="server">
                                </td>
                            </tr>
                        </table>
                        <table id="ExamResult" runat="server" visible="true" width="100%">
                            <tr id="Tr5" runat="server">
                                <td id="Td5" align="left" style="width: 50%" runat="server">
                                    <table border="0" style="border: solid 1px #666666;" width="100%">
                                        <tr>
                                            <td align="center" colspan="6">
                                                <asp:Label ID="lblASum" runat="server" ForeColor="#666666" Font-Bold="True" Text="Assessment summary"
                                                    meta:resourcekey="lblASumResource1"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" style="padding-left: 13px;">
                                                <asp:Label ID="Label8" runat="server" ForeColor="#666666" Text="Total Question:"
                                                    meta:resourcekey="Label8Resource1"></asp:Label>
                                            </td>
                                            <td align="left" style="padding-left: 10px;">
                                                <asp:Label ID="lblTotalQues" runat="server" ForeColor="#666666" Text="0" meta:resourcekey="lblTotalQuesResource1"></asp:Label>
                                            </td>
                                            <td align="right" style="padding-left: 13px;">
                                                <asp:Label ID="Label11" runat="server" ForeColor="#666666" Text="Correct:" meta:resourcekey="Label11Resource1"></asp:Label>
                                            </td>
                                            <td align="left" style="padding-left: 10px;">
                                                <asp:Label ID="lblTrueAns" runat="server" ForeColor="#666666" Text="0" meta:resourcekey="lblTrueAnsResource1"></asp:Label>
                                            </td>
                                            <td align="right" style="padding-left: 13px;">
                                                <asp:Label ID="Label13" runat="server" ForeColor="#666666" Text="False:" meta:resourcekey="Label13Resource1"></asp:Label>
                                            </td>
                                            <td align="left" style="padding-left: 10px;">
                                                <asp:Label ID="lblFalseAns" runat="server" ForeColor="#666666" Text="0" meta:resourcekey="lblFalseAnsResource1"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td id="Td6" style="width: 50%" runat="server">
                                    <table border="0" style="border: solid 1px #666666;" width="100%">
                                        <tr>
                                            <td align="center" valign="middle">
                                                <asp:Label ID="lbluserScore" runat="server" ForeColor="#666666" Font-Bold="True"
                                                    Text="You have score :" meta:resourcekey="lbluserScoreResource1"></asp:Label>
                                                <asp:Label ID="lbluserScoreValue" runat="server" ForeColor="#666666" Font-Bold="True"
                                                    Text="Label" meta:resourcekey="lbluserScoreValueResource1"></asp:Label><br />
                                                <br />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr id="Tr6" runat="server">
                                <td id="Td7" align="center" colspan="2" runat="server">
                                    <asp:GridView ID="gvAnalysis" runat="server" OnRowDataBound="gvAnalysis_RowDataBound"
                                        SkinID="TestAssessment" meta:resourcekey="gvAnalysisResource1">
                                        <Columns>
                                            <asp:TemplateField meta:resourcekey="TemplateFieldResource1">
                                                <HeaderTemplate>
                                                    <asp:Label ID="Label4" Text="Assessment" runat="server" Font-Bold="True" meta:resourcekey="Label4Resource1"></asp:Label></HeaderTemplate>
                                                <ItemTemplate>
                                                    <table width="100%" style="border: solid 1px #666666;">
                                                        <tr class="DatalistHeader">
                                                            <td align="right" valign="top" style="border-bottom: solid 1px #666666; border-top: none;
                                                                border-right: none; border-left: none" width="15%">
                                                                <asp:Label ID="lblQ" runat="server" Text="Ques" ForeColor="#666666" Font-Bold="True"
                                                                    meta:resourcekey="lblQResource1"></asp:Label><span style="color: #666666; font-weight: bold"><asp:Label
                                                                        ID="lblNo" runat="server" ForeColor="#666666" Font-Bold="True" Text='<%# Container.DataItemIndex +1 %>'
                                                                        meta:resourcekey="lblNoResource1"></asp:Label>: </span>
                                                            </td>
                                                            <td align="left" colspan="4" style="border-bottom: solid 1px #666666; border-top: none;
                                                                border-right: none; border-left: none" width="85%">
                                                                <asp:Literal ID="ltQuestion" runat="server" Text='<%# Eval("Question") %>'></asp:Literal>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right" style="border: none;">
                                                                <asp:Label ID="lblCorrectAns" runat="server" ForeColor="#666666" Text="Correct Answer:"
                                                                    Font-Bold="True" meta:resourcekey="lblCorrectAnsResource1"></asp:Label>
                                                            </td>
                                                            <td align="left" style="border: none;">
                                                                <asp:Literal ID="lblCorrect" runat="server" Text='<%# Eval("Answer") %>'></asp:Literal>
                                                            </td>
                                                            <td align="right" style="border: none;">
                                                            </td>
                                                            <td align="left" style="border: none;">
                                                                <asp:Label ID="lblSrNo" runat="server" meta:resourcekey="lblSrNoResource1"></asp:Label>
                                                            </td>
                                                            <td rowspan="3" valign="middle" style="padding-right: 10px; border: none" align="right">
                                                                <asp:Panel ID="pnlview" runat="server" meta:resourcekey="pnlviewResource1">
                                                                    <asp:Button ID="btnSolution" Text="View Solution" runat="server" meta:resourcekey="btnSolutionResource1" /></asp:Panel>
                                                                <asp:Panel ID="MainPanel" runat="server" Style="display: none;" Width="100%" meta:resourcekey="MainPanelResource1">
                                                                    <asp:Panel ID="pnldrag" runat="server" Style="cursor: move; text-align: center; font-weight: bold;
                                                                        font-size: 20px; width: 710px; color: white" meta:resourcekey="pnldragResource1">
                                                                    </asp:Panel>
                                                                    <asp:Panel ID="innerPanel" runat="server" Style="width: 100%;" meta:resourcekey="innerPanelResource1">
                                                                        <table class="InnerModalPopup" style="position: fixed; border: solid 1px #666666;
                                                                            vertical-align: middle; text-align: center; width: 98%; background-color: White;"
                                                                            border="0">
                                                                            <tr>
                                                                                <th style="border-left: 1px solid #ffffff; border-top: 1px solid #ffffff; background-color: #666666;
                                                                                    height: 25; font-size: 14px; font-weight: bold; text-align: center;" width="100%">
                                                                                    <asp:Label ID="lblPkg" runat="server" ForeColor="White" Font-Bold="True" Text="Solution"
                                                                                        meta:resourcekey="lblPkgResource1"></asp:Label>
                                                                                </th>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left">
                                                                                    <asp:Label ID="lblQues" runat="server" Font-Bold="True" ForeColor="#666666" Text="Question :"
                                                                                        meta:resourcekey="lblQuesResource2"></asp:Label><asp:Literal ID="ltQues" Text='<%# Eval("Question") %>'
                                                                                            runat="server"></asp:Literal>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left">
                                                                                    <asp:Label ID="lblAns" runat="server" Font-Bold="True" ForeColor="#666666" Text="Solution"
                                                                                        meta:resourcekey="lblAnsResource1"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left">
                                                                                    <asp:Literal ID="ltAns" runat="server" meta:resourcekey="ltAnsResource1"></asp:Literal>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="center">
                                                                                    <asp:Button ID="CancelButton" runat="server" Text="OK" Width="12%" meta:resourcekey="CancelButtonResource1" />
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </asp:Panel>
                                                                </asp:Panel>
                                                                <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender" runat="server" BackgroundCssClass="modalBackground"
                                                                    CancelControlID="CancelButton" DropShadow="True" X="10" Y="10" PopupControlID="MainPanel"
                                                                    PopupDragHandleControlID="pnldrag" TargetControlID="pnlview" DynamicServicePath=""
                                                                    Enabled="True" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right" style="border: none;">
                                                                <asp:Label ID="lblYourAns" runat="server" ForeColor="#666666" Text="Your Answer:"
                                                                    Font-Bold="True" meta:resourcekey="lblYourAnsResource1"></asp:Label>
                                                            </td>
                                                            <td align="left" style="border: none;">
                                                                <asp:Literal ID="lblGiven" runat="server" Text="ads" meta:resourcekey="lblGivenResource1"></asp:Literal>
                                                            </td>
                                                            <td align="right" style="border: none;">
                                                            </td>
                                                            <td align="left" style="border: none;">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right" style="border: none;">
                                                                <asp:Label ID="lblResu" runat="server" ForeColor="#666666" Text="Result:" Font-Bold="True"
                                                                    meta:resourcekey="lblResuResource1"></asp:Label>
                                                            </td>
                                                            <td align="left" style="border: none;">
                                                                <asp:Label ID="lblResult" runat="server" Text='0' meta:resourcekey="lblResultResource1"></asp:Label>
                                                            </td>
                                                            <td align="right" style="border: none;">
                                                            </td>
                                                            <td align="left" style="border: none;">
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                    <asp:View ID="vwRestult" runat="server">
                        <asp:UpdatePanel ID="UpdatePanelForTimer" runat="server">
                            <ContentTemplate>
                                <asp:Timer ID="Timer1" runat="server" OnTick="Timer1_Tick" Interval="6000">
                                </asp:Timer>
                                <table width="100%" cellspacing="0" cellpadding="0" id="TblQuestionResult" runat="server"
                                    visible="true">
                                    <tr>
                                        <td align="center">
                                            <asp:GridView ID="grvStudentResultAuto" runat="server" SkinID="WidthCanModify" Width="98%"
                                                OnRowDataBound="grvStudentResultAuto_RowDataBound">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Sr. No">
                                                        <ItemTemplate>
                                                            <%# Container.DataItemIndex +1 %></ItemTemplate>
                                                        <ItemStyle Width="10%" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="RightAnswer" SortExpression="RightAnswer" HeaderText="RightAnswer"
                                                        ItemStyle-Width="15%" />
                                                    <asp:BoundField DataField="WrongAnswer" SortExpression="WrongAnswer" HeaderText="WrongAnswer"
                                                        ItemStyle-Width="15%" />
                                                    <asp:BoundField DataField="Attendent" SortExpression="Attendent" HeaderText="Attendent"
                                                        ItemStyle-Width="15%" />
                                                    <asp:TemplateField HeaderText="Chart">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="LblRightAnswerChart" CssClass="turquoise" Text=''></asp:Label><asp:Label
                                                                runat="server" ID="LblWrongAnswerChart" CssClass="pink" Text=''></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <table width="100%">
                                                <tr>
                                                    <td colspan="5" align="center">
                                                        <asp:Label ID="lblCurrentStatus" runat="server" ForeColor="#666666" Font-Bold="True"
                                                            Text="Current status"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" style="width: 20%">
                                                        <asp:Label ID="lblAvergRightAnswer" runat="server" ForeColor="#666666" Text="Average right/wrong answer (%)"></asp:Label>
                                                    </td>
                                                    <td align="center" style="width: 2%; color: #666666">
                                                        :
                                                    </td>
                                                    <td align="left" colspan="3">
                                                        <asp:Label ID="lblAvergRightAnswerValue" runat="server" CssClass="turquoise" Text=""></asp:Label><asp:Label
                                                            ID="lblAvergWrongAnswerValue" runat="server" CssClass="pink" Text=""></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" style="width: 20%">
                                                        <asp:Label ID="lblTotalStudentAttendingTest" runat="server" ForeColor="#666666" Text="Total students attending test"></asp:Label>
                                                    </td>
                                                    <td align="center" style="width: 2%; color: #666666">
                                                        :
                                                    </td>
                                                    <td align="left" style="width: 20%">
                                                        <asp:Label ID="lblTotalStudentAttendingTestValue" runat="server" Text=""></asp:Label>
                                                    </td>
                                                    <td align="left" style="width: 20%">
                                                        &nbsp;
                                                    </td>
                                                    <td align="left" style="width: 20%">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" style="width: 20%">
                                                        <asp:Label ID="lblTotalStudents" runat="server" ForeColor="#666666" Text="Total Students"></asp:Label>
                                                    </td>
                                                    <td align="center" style="width: 2%; color: #666666">
                                                        :
                                                    </td>
                                                    <td align="left" style="width: 20%">
                                                        <asp:Label ID="lblTotalStudentsValue" runat="server" Text=""></asp:Label>
                                                    </td>
                                                    <td align="left" style="width: 20%">
                                                        &nbsp;
                                                    </td>
                                                    <td align="left" style="width: 20%">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" style="width: 20%">
                                                        <asp:Label ID="lblStopExam" runat="server" ForeColor="#666666" Text="Live exam stop"></asp:Label>
                                                    </td>
                                                    <td align="center" style="width: 2%; color: #666666">
                                                        :
                                                    </td>
                                                    <td align="left" style="width: 20%">
                                                        <asp:Button ID="BtnStopExam" runat="server" Text="Stop Exam" Enabled="False" ForeColor="Green"
                                                            OnClick="BtnStopExam_Click" />
                                                        <a href="SendTestResultMail.aspx" target="_parent" class="Button">Send result mail</a>
                                                    </td>
                                                    <td align="left" style="width: 20%">
                                                        &nbsp;
                                                    </td>
                                                    <td align="left" style="width: 20%">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            <asp:GridView ID="grvStudentWiseResultAuto" runat="server" SkinID="WidthCanModify"
                                                Width="98%" DataKeyNames="StudentID" OnRowDataBound="grvStudentWiseResultAuto_RowDataBound">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Sr. No">
                                                        <ItemTemplate>
                                                            <%# Container.DataItemIndex +1 %></ItemTemplate>
                                                        <ItemStyle Width="10%" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="StudentName" SortExpression="StudentName" HeaderText="StudentName"
                                                        ItemStyle-Width="15%" />
                                                    <asp:BoundField DataField="RightAnswer" SortExpression="RightAnswer" HeaderText="RightAnswer"
                                                        ItemStyle-HorizontalAlign="Right" ItemStyle-Width="15%" />
                                                    <asp:BoundField DataField="WrongAnswer" SortExpression="WrongAnswer" HeaderText="WrongAnswer"
                                                        ItemStyle-HorizontalAlign="Right" ItemStyle-Width="15%" />
                                                    <asp:TemplateField HeaderText="StudentID" ItemStyle-Width="8%" ItemStyle-HorizontalAlign="Right"
                                                        Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" Visible="true" ID="lblstudentID" Text='<%#Eval("StudentID") %>'>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Result" ItemStyle-Width="8%" ItemStyle-HorizontalAlign="Right">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblresultperc"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-Width="15%" HeaderText="View Result" ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkViewResult" runat="server" Text="View" OnClick="ViewResult"></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <br />
                                            <br />
                                            <hr style="border: none; height: 2px; color: #333; background-color: #333; " />
                                            <br />
                                            <div id="dvMainstudentresult" runat="server" visible="false">
                                                <div align="center" style="font-size: 30px;">
                                                    <asp:Label ID="lblstudentname" runat="server" Text="" Style="font-weight: 700"></asp:Label>
                                                </div>
                                                <div runat="server" id="dvstudentresult" visible="true">
                                                    <table id="tblstudentresult" runat="server" visible="true" width="100%">
                                                        <tr id="Tr7" runat="server">
                                                            <td id="Td8" align="left" style="width: 50%" runat="server">
                                                                <table border="0" style="border: solid 1px #666666;" width="100%">
                                                                    <tr>
                                                                        <td align="center" colspan="6">
                                                                            <asp:Label ID="Label2" runat="server" ForeColor="#666666" Font-Bold="True" Text="Assessment summary"
                                                                                meta:resourcekey="lblASumResource1"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="right" style="padding-left: 13px;">
                                                                            <asp:Label ID="Label3" runat="server" ForeColor="#666666" Text="Total Question:"
                                                                                meta:resourcekey="Label8Resource1"></asp:Label>
                                                                        </td>
                                                                        <td align="left" style="padding-left: 10px;">
                                                                            <asp:Label ID="lbltotalquesstudent" runat="server" ForeColor="#666666" Text=""></asp:Label>
                                                                        </td>
                                                                        <td align="right" style="padding-left: 13px;">
                                                                            <asp:Label ID="lblcorrectansLabel" runat="server" ForeColor="#666666" Text="Correct:"></asp:Label>
                                                                        </td>
                                                                        <td align="left" style="padding-left: 10px;">
                                                                            <asp:Label ID="lblcorrectans" runat="server" ForeColor="#666666" Text=""></asp:Label>
                                                                        </td>
                                                                        <td align="right" style="padding-left: 13px;">
                                                                            <asp:Label ID="lblwrongansLabel" runat="server" ForeColor="#666666" Text="False:"></asp:Label>
                                                                        </td>
                                                                        <td align="left" style="padding-left: 10px;">
                                                                            <asp:Label ID="lblwrongans" runat="server" ForeColor="#666666" Text=""></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                            <td id="Td9" style="width: 50%" runat="server">
                                                                <table border="0" style="border: solid 1px #666666;" width="100%">
                                                                    <tr>
                                                                        <td align="center" valign="middle">
                                                                            <asp:Label ID="Label12" runat="server" ForeColor="#666666" Font-Bold="True" Text="You have score :"
                                                                                meta:resourcekey="lbluserScoreResource1"></asp:Label>
                                                                            <asp:Label ID="lblperc" runat="server" ForeColor="#666666" Font-Bold="True" Text="Label"
                                                                                meta:resourcekey="lbluserScoreValueResource1"></asp:Label><br />
                                                                            <br />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr id="Tr8" runat="server">
                                                            <td id="Td10" align="center" colspan="2" runat="server">
                                                                <div>
                                                                    <asp:GridView ID="GridView1" runat="server" SkinID="TestAssessment" OnRowDataBound="GridView1_RowDataBound">
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" meta:resourcekey="TemplateFieldResource1">
                                                                                <HeaderTemplate>
                                                                                    <asp:Label ID="Label4" Text="Assessment" runat="server" Font-Bold="True" meta:resourcekey="Label4Resource1"></asp:Label>
                                                                                </HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <table width="100%" style="border: solid 1px #484CE2;">
                                                                                        <tr class="DatalistHeader">
                                                                                            <td align="right" valign="top" style="border-bottom: solid 1px #484CE2; border-top: none;
                                                                                                border-right: none; border-left: none" width="15%">
                                                                                                <asp:Label ID="lblQ" runat="server" Text="Ques" ForeColor="#484CE2" Font-Bold="True"
                                                                                                    meta:resourcekey="lblQResource1"></asp:Label>
                                                                                                <span style="color: #484CE2; font-weight: bold">
                                                                                                    <asp:Label ID="lblNo" runat="server" ForeColor="#484CE2" Font-Bold="True" Text='<%# Container.DataItemIndex +1 %>'
                                                                                                        meta:resourcekey="lblNoResource1"></asp:Label>: </span>
                                                                                            </td>
                                                                                            <td align="left" colspan="4" style="border-bottom: solid 1px #484CE2; border-top: none;
                                                                                                border-right: none; border-left: none" width="85%">
                                                                                                <asp:Literal ID="ltQuestion" runat="server" Text='<%# Eval("Question") %>'></asp:Literal>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td align="right" valign="top" style="border: none;">
                                                                                                <asp:Label ID="lblCorrectAns" runat="server" ForeColor="#484CE2" Text="Options:"
                                                                                                    Font-Bold="True" meta:resourcekey="lblCorrectAnsResource1"></asp:Label>
                                                                                            </td>
                                                                                            <td align="left" style="border: none;">
                                                                                                <table cellspacing="10px" cellpadding="10px">
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                            <asp:Literal ID="Option1" runat="server" Text='A' meta:resourcekey="Option1Resource1"></asp:Literal>
                                                                                                        </td>
                                                                                                        <td>
                                                                                                            <asp:Literal ID="Option2" runat="server" Text='B' meta:resourcekey="Option2Resource1"></asp:Literal>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                            <asp:Literal ID="Option3" runat="server" Text='C' meta:resourcekey="Option3Resource1"></asp:Literal>
                                                                                                        </td>
                                                                                                        <td>
                                                                                                            <asp:Literal ID="Option4" runat="server" Text='D' meta:resourcekey="Option4Resource1"></asp:Literal>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </td>
                                                                                            <td align="right" style="border: none;">
                                                                                            </td>
                                                                                            <td align="left" style="border: none;">
                                                                                                <asp:Label ID="lblSrNo" runat="server" meta:resourcekey="lblSrNoResource1"></asp:Label>
                                                                                            </td>
                                                                                            <td rowspan="3" valign="middle" style="padding-right: 10px; border: none" align="right">
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td align="right" valign="top" style="border: none;">
                                                                                                <asp:Label ID="lblSolutionTitle" runat="server" ForeColor="#484CE2" Text="Solution:"
                                                                                                    Font-Bold="True" meta:resourcekey="lblSolutionTitleResource1"></asp:Label>
                                                                                            </td>
                                                                                            <td align="left" style="border: none;">
                                                                                                <asp:Literal ID="lblSolution" runat="server" Text='<%# Eval("Solution") %>'></asp:Literal>
                                                                                            </td>
                                                                                            <td align="right" style="border: none;">
                                                                                                <asp:Literal ID="ltAns" runat="server" meta:resourcekey="ltAnsResource1"></asp:Literal>
                                                                                            </td>
                                                                                            <td align="left" style="border: none;">
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td align="right" style="border: none;">
                                                                                                <asp:Label ID="lblResu" runat="server" ForeColor="#484CE2" Text="Result:" Font-Bold="True"
                                                                                                    meta:resourcekey="lblResuResource1"></asp:Label>
                                                                                            </td>
                                                                                            <td align="left" style="border: none;">
                                                                                                <asp:Label ID="lblResult" runat="server" Text='<%# Eval("Result") %>' meta:resourcekey="lblResultResource2"></asp:Label>
                                                                                            </td>
                                                                                            <td align="right" style="border: none;">
                                                                                            </td>
                                                                                            <td align="left" style="border: none;">
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </ItemTemplate>
                                                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                    </asp:GridView>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                            <Triggers>
                            </Triggers>
                        </asp:UpdatePanel>
                    </asp:View>
                </asp:MultiView>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
