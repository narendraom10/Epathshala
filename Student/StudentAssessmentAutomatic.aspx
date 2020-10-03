<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Epathshala.master" AutoEventWireup="true" CodeFile="StudentAssessmentAutomatic.aspx.cs" Inherits="Student_StudentAssessmentAutomatic" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
 <script type="text/javascript" src="../JavaScript/ASCIIMathML.js"></script>
    <script type="text/javascript" src="../JavaScript/jquery-1.4.2.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <Triggers>
            <%--<asp:PostBackTrigger ControlID="BtnButton" />--%>
            <asp:PostBackTrigger ControlID="BtnButton" />
            </Triggers>
            <ContentTemplate>
             <script type="text/javascript" src="../JavaScript/ASCIIMathML.js"></script>
           
                <table width="100%" id="Examtbl" runat="server">
                    <tr id="Tr1" runat="server">
                        <td id="Td1" runat="server">
                            <table width="100%" cellspacing="0">
                                <tr>
                                    <td width="100%">
                                        <div class="QuestionHead">
                                            <asp:Literal ID="ltQuestionCount" Text="Question No" runat="server" 
                                                meta:resourcekey="ltQuestionCountResource1"></asp:Literal>
                                            <asp:Literal ID="ltQuestionCount1" runat="server" 
                                                meta:resourcekey="ltQuestionCount1Resource1"></asp:Literal>
                                            <asp:Literal ID="ltQuestionCount2" Text="out of" runat="server" 
                                                meta:resourcekey="ltQuestionCount2Resource1"></asp:Literal>
                                            <asp:Literal ID="ltQuestionCount3" Text="Question No 1 out of 20" 
                                                runat="server" meta:resourcekey="ltQuestionCount3Resource1"></asp:Literal>
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
                                        &nbsp;
                                    </td>
                                    <td align="left" valign="bottom" class="QuestionText">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top" class="QuestionText" style="width: 12%">
                                        <asp:Label ID="lblQues" runat="server" Text="Question" 
                                            meta:resourcekey="lblQuesResource1"></asp:Label>
                                    </td>
                                    <td align="left" valign="bottom" class="QuestionText">
                                        <asp:Literal ID="ltQuestion" runat="server" 
                                            meta:resourcekey="ltQuestionResource1"></asp:Literal>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 12%">
                                    </td>
                                    <td align="left" valign="bottom" class="QuestionText">
                                        <asp:RadioButtonList ID="rdb" runat="server" RepeatColumns="2" RepeatDirection="Horizontal"
                                            ValidationGroup="Exm" CellSpacing="10" meta:resourcekey="rdbResource1">
                                        </asp:RadioButtonList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="rdb"
                                            ValidationGroup="Exm" ErrorMessage="Please select any one answer" 
                                            meta:resourcekey="RequiredFieldValidator1Resource1"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 12%">
                                    </td>
                                    <td align="left" valign="bottom" class="QuestionText">
                                        <asp:Button ID="BtnButton" runat="server" Text="Next" OnClick="BtnButton_Click" 
                                            ValidationGroup="Exm" meta:resourcekey="BtnButtonResource1" />
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
                <table id="ExamResult" runat="server" visible="False" width="100%">
                    <tr id="Tr5" runat="server">
                        <td id="Td5" align="left" style="width: 50%" runat="server">
                            <table border="0" style="border: solid 1px #666666;" width="100%">
                                <tr>
                                    <td align="center" colspan="6">
                                        <asp:Label ID="lblASum" runat="server" ForeColor="#666666" Font-Bold="True" 
                                            Text="Assessment summary" meta:resourcekey="lblASumResource1"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="padding-left: 13px;">
                                        <asp:Label ID="Label8" runat="server" ForeColor="#666666" 
                                            Text="Total Question:" meta:resourcekey="Label8Resource1"></asp:Label>
                                    </td>
                                    <td align="left" style="padding-left: 10px;">
                                        <asp:Label ID="lblTotalQues" runat="server" ForeColor="#666666" Text="0" 
                                            meta:resourcekey="lblTotalQuesResource1"></asp:Label>
                                    </td>
                                    <td align="right" style="padding-left: 13px;">
                                        <asp:Label ID="Label11" runat="server" ForeColor="#666666" Text="Correct:" 
                                            meta:resourcekey="Label11Resource1"></asp:Label>
                                    </td>
                                    <td align="left" style="padding-left: 10px;">
                                        <asp:Label ID="lblTrueAns" runat="server" ForeColor="#666666" Text="0" 
                                            meta:resourcekey="lblTrueAnsResource1"></asp:Label>
                                    </td>
                                    <td align="right" style="padding-left: 13px;">
                                        <asp:Label ID="Label13" runat="server" ForeColor="#666666" Text="False:" 
                                            meta:resourcekey="Label13Resource1"></asp:Label>
                                    </td>
                                    <td align="left" style="padding-left: 10px;">
                                        <asp:Label ID="lblFalseAns" runat="server" ForeColor="#666666" Text="0" 
                                            meta:resourcekey="lblFalseAnsResource1"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td id="Td6" style="width: 50%" runat="server">
                            <table border="0" style="border: solid 1px #666666;" width="100%">
                                <tr>
                                    <td align="center" valign="middle">
                                        <asp:Label ID="lbluserScore" runat="server" ForeColor="#666666" 
                                            Font-Bold="True"  Text="You have score :" 
                                            meta:resourcekey="lbluserScoreResource1"></asp:Label>
                                        <asp:Label ID="lbluserScoreValue" runat="server" ForeColor="#666666" 
                                            Font-Bold="True" Text="Label" 
                                            meta:resourcekey="lbluserScoreValueResource1"></asp:Label><br /><br />
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
                                            <asp:Label ID="Label4" Text="Assessment" runat="server" Font-Bold="True" 
                                                meta:resourcekey="Label4Resource1"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <table width="100%" style="border: solid 1px #666666;">
                                                <tr class="DatalistHeader">
                                                    <td align="right" valign="top" style="border-bottom: solid 1px #666666; border-top: none;
                                                        border-right: none; border-left: none" width="15%">
                                                        <asp:Label ID="lblQ" runat="server" Text="Ques" ForeColor="#666666" 
                                                            Font-Bold="True" meta:resourcekey="lblQResource1"></asp:Label>
                                                        <span style="color: #666666; font-weight: bold">
                                                            <asp:Label ID="lblNo" runat="server" ForeColor="#666666" Font-Bold="True" 
                                                            Text='<%# Container.DataItemIndex +1 %>' meta:resourcekey="lblNoResource1"></asp:Label>:
                                                        </span>
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
                                                            <asp:Button ID="btnSolution" Text="View Solution" runat="server" meta:resourcekey="btnSolutionResource1" />
                                                        </asp:Panel>
                                                        <asp:Panel ID="MainPanel" runat="server" Style="display: none;" Width="100%" 
                                                            meta:resourcekey="MainPanelResource1">
                                                            <asp:Panel ID="pnldrag" runat="server" Style="cursor: move; text-align: center; font-weight: bold;
                                                                font-size: 20px; width: 710px; color: white" meta:resourcekey="pnldragResource1">
                                                            </asp:Panel>
                                                            <asp:Panel ID="innerPanel" runat="server" Style="width: 100%;" 
                                                                meta:resourcekey="innerPanelResource1">
                                                                <table class="InnerModalPopup" style="position: fixed; border: solid 1px #666666;
                                                                    vertical-align: middle; text-align: center; width: 98%;" border="0">
                                                                    <tr>
                                                                        <th style="border-left: 1px solid #ffffff; border-top: 1px solid #ffffff; background-color: #42A3A1;
                                                                            height: 25; font-size: 14px; font-weight: bold; text-align: center;" width="100%">
                                                                            <asp:Label ID="lblPkg" runat="server" ForeColor="White" Font-Bold="True" 
                                                                                Text="Solution" meta:resourcekey="lblPkgResource1"></asp:Label>
                                                                        </th>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left">
                                                                            <asp:Label ID="lblQues" runat="server" Font-Bold="True" ForeColor="#666666" 
                                                                                Text="Question :" meta:resourcekey="lblQuesResource2"></asp:Label>
                                                                            <asp:Literal ID="ltQues" Text='<%# Eval("Question") %>' runat="server"></asp:Literal>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left">
                                                                            <asp:Label ID="lblAns" runat="server" Font-Bold="True" ForeColor="#666666" 
                                                                                Text="Solution" meta:resourcekey="lblAnsResource1"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left">
                                                                            <asp:Literal ID="ltAns" runat="server" meta:resourcekey="ltAnsResource1"></asp:Literal>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="center">
                                                                            <asp:Button ID="CancelButton" runat="server" Text="OK" Width="12%" 
                                                                                meta:resourcekey="CancelButtonResource1" />
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
                                                        <asp:Literal ID="lblGiven" runat="server" Text="ads" 
                                                            meta:resourcekey="lblGivenResource1"></asp:Literal>
                                                    </td>
                                                    <td align="right" style="border: none;">
                                                    </td>
                                                    <td align="left" style="border: none;">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" style="border: none;">
                                                        <asp:Label ID="lblResu" runat="server" ForeColor="#666666" Text="Result:" 
                                                            Font-Bold="True" meta:resourcekey="lblResuResource1"></asp:Label>
                                                    </td>
                                                    <td align="left" style="border: none;">
                                                        <asp:Label ID="lblResult" runat="server" Text='0' 
                                                            meta:resourcekey="lblResultResource1"></asp:Label>
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
            </ContentTemplate>
        </asp:UpdatePanel>
</asp:Content>

