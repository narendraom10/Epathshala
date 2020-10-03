<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SchoolExamReportsStudentRpt.ascx.cs" Inherits="UserControl_SchoolExamReportsStudentRpt" %>
<table cellpadding="2" cellspacing="2" width="100%" style="margin: 5px 5px 5px 5px">
        <tr>
            <td align="right">
                <asp:Label ID="lblSchool" runat="server" Text="School :" ToolTip="School Name:"></asp:Label>
            </td>
            <td colspan="3">
                <asp:Label ID="lblSchoolValue" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="lblBoard" runat="server" Text="Board:" ToolTip="Board"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblBoardValue" runat="server" Text="" ToolTip="Board"></asp:Label>
            </td>
            <td align="right">
                <asp:Label ID="lblMedium" runat="server" Text="Medium:"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblMediumValue" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="lblStandard" runat="server" Text="Standard:"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblStandardValue" runat="server" Text=""></asp:Label>
            </td>
            <td align="right">
                <asp:Label ID="lblsubject" runat="server" Text="Subject:"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblsubjectValue" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="lblChapter" runat="server" Text="Chapter:"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblChapterValue" runat="server" Text=""></asp:Label>
            </td>
            <td align="right">
                <asp:Label ID="lbltopic" runat="server" Text="Topic:"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lbltopicValue" runat="server" Text=""></asp:Label>
            </td>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="lblDate" runat="server" Text="Date:"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblDateValue" runat="server" Text=""></asp:Label>
            </td>
            <td align="right">
                <asp:Label ID="lblteacher" runat="server" Text="Teacher:"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblteacherValue" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="lblStudent" runat="server" Text="Student:"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblStudentValue" runat="server" Text=""></asp:Label>
            </td>
            <td align="right">
                <asp:Label ID="lblTrueAns" runat="server" Text="True Ans:"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblTrueAnsValue" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="lblFalseAns" runat="server" Text="False Ans:"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblFalseAnsValue" runat="server" Text=""></asp:Label>
            </td>
            <td align="right">
                <asp:Label ID="lblResult" runat="server" Text="Result (%):"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblResultValue" runat="server" Text=""></asp:Label>
            </td>
        </tr>
    </table>
    <table id="ExamResult" runat="server" width="100%">
        <tr>
            <td align="left" style="width: 50%">
                <table border="0" style="border: solid 1px #4CBCBB;" width="100%">
                    <tr>
                        <td align="center" colspan="6">
                            <asp:Label ID="lblASum" runat="server" ForeColor="#4CBCBB" Font-Bold="true" Text="Assessment summary"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="padding-left: 13px;">
                            <asp:Label ID="Label8" runat="server" ForeColor="#4CBCBB" Text="Total Question:"></asp:Label>
                        </td>
                        <td align="left" style="padding-left: 10px;">
                            <asp:Label ID="lblTotalQues" runat="server" ForeColor="#4CBCBB" Text="0"></asp:Label>
                        </td>
                        <td align="right" style="padding-left: 13px;">
                            <asp:Label ID="Label11" runat="server" ForeColor="#4CBCBB" Text="Correct:"></asp:Label>
                        </td>
                        <td align="left" style="padding-left: 10px;">
                            <asp:Label ID="Label1" runat="server" ForeColor="#4CBCBB" Text="0"></asp:Label>
                        </td>
                        <td align="right" style="padding-left: 13px;">
                            <asp:Label ID="Label13" runat="server" ForeColor="#4CBCBB" Text="False:"></asp:Label>
                        </td>
                        <td align="left" style="padding-left: 10px;">
                            <asp:Label ID="Label2" runat="server" ForeColor="#4CBCBB" Text="0"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
            <td style="width: 50%">
                <table border="0" style="border: solid 1px #4CBCBB;" width="100%">
                    <tr>
                        <td align="center" valign="middle">
                            <asp:Label ID="lbluserScore" runat="server" ForeColor="#4CBCBB" Font-Bold="true"
                                Text="You have score :"></asp:Label><asp:Label ID="lbluserScoreValue" runat="server"
                                    ForeColor="#4CBCBB"  Font-Bold="true" Text="Label"></asp:Label><br />
                            <br />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                <asp:GridView ID="gvAnalysis" runat="server" OnRowDataBound="gvAnalysis_RowDataBound"
                    SkinID="TestAssessment">
                    <Columns>
                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center">
                            <HeaderTemplate>
                                <asp:Label ID="Label4" Text="Assessment" runat="server" Font-Bold="True"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <table width="100%" style="border: solid 1px #4CBCBB;">
                                    <tr class="DatalistHeader">
                                        <td align="right" valign="top" style="border-bottom: solid 1px #4CBCBB; border-top: none;
                                            border-right: none; border-left: none" width="15%">
                                            <asp:Label ID="lblQ" runat="server" Text="Ques" ForeColor="#4CBCBB" Font-Bold="True"></asp:Label>
                                            <span style="color: #4CBCBB; font-weight: bold">
                                                <asp:Label ID="lblNo" runat="server" ForeColor="#4CBCBB" Font-Bold="True" Text='<%# Container.DataItemIndex +1 %>'></asp:Label>:
                                            </span>
                                        </td>
                                        <td align="left" colspan="4" style="border-bottom: solid 1px #4CBCBB; border-top: none;
                                            border-right: none; border-left: none" width="85%">
                                            <asp:Literal ID="ltQuestion" runat="server" Text='<%# Eval("Question") %>'></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" valign="top" style="border: none;">
                                            <asp:Label ID="lblCorrectAns" runat="server" ForeColor="#4CBCBB" Text="Options:" Font-Bold="True"></asp:Label>
                                        </td>
                                        <td align="left" style="border: none;">
                                            <table cellspacing="10px" cellpadding="10px">
                                                <tr>
                                                    <td>
                                                        <asp:Literal ID="Option1" runat="server" Text='A'></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:Literal ID="Option2" runat="server" Text='B'></asp:Literal>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Literal ID="Option3" runat="server" Text='C'></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:Literal ID="Option4" runat="server" Text='D'></asp:Literal>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td align="right" style="border: none;">
                                        </td>
                                        <td align="left" style="border: none;">
                                            <asp:Label ID="lblSrNo" runat="server" Text=''></asp:Label>
                                        </td>
                                        <td rowspan="3" valign="middle" style="padding-right: 10px; border: none" align="right">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" valign="top" style="border: none;">
                                            <asp:Label ID="lblSolutionTitle" runat="server" ForeColor="#4CBCBB" Text="Solution:"
                                                Font-Bold="True"></asp:Label>
                                        </td>
                                        <td align="left" style="border: none;">
                                            <asp:Literal ID="lblSolution" runat="server" Text='<%# Eval("Solution") %>'></asp:Literal>
                                        </td>
                                        <td align="right" style="border: none;">
                                            <asp:Literal ID="ltAns" Text='' runat="server"></asp:Literal>
                                        </td>
                                        <td align="left" style="border: none;">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="border: none;">
                                            <asp:Label ID="lblResu" runat="server" ForeColor="#4CBCBB" Text="Result:" Font-Bold="True"></asp:Label>
                                        </td>
                                        <td align="left" style="border: none;">
                                            <asp:Label ID="lblResult" runat="server" Text='<%# Eval("Result") %>'></asp:Label>
                                        </td>
                                        <td align="right" style="border: none;">
                                        </td>
                                        <td align="left" style="border: none;">
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>