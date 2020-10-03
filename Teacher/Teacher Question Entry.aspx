<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Epathshala.master" AutoEventWireup="true"
    CodeFile="Teacher Question Entry.aspx.cs" Inherits="Teacher_Teacher_Question_Entry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <script type="text/javascript" src="../MathJax/MathJax.js?config=AM_HTMLorMML-full"></script>
    <script type="text/javascript">
        function SetAnswer() {

            document.getElementById("<%= LtrlOptionAPrint.ClientID %>").innerHTML = htmlDecode(document.getElementById("<%= TxtAnswer1.ClientID %>").value);
            document.getElementById("<%= LtrlOptionBPrint.ClientID %>").innerHTML = htmlDecode(document.getElementById("<%= TxtAnswer2.ClientID %>").value);
            document.getElementById("<%= LtrlOptionCPrint.ClientID %>").innerHTML = htmlDecode(document.getElementById("<%= TxtAnswer3.ClientID %>").value);
            document.getElementById("<%= LtrlOptionDPrint.ClientID %>").innerHTML = htmlDecode(document.getElementById("<%= TxtAnswer4.ClientID %>").value);

            document.getElementById("2").className = "visibleDiv";

            // alert("in set answer");

            return false;
        }
    </script>
    <style type="text/css">
        .GridViewItem:Hover
        {
            cursor: pointer;
        }
        
    </style>
    <style type="text/css">
        .gvPagerCss span
        {
            background-color: #DEE1E7;
            font-size: 14px;
        }
        .gvPagerCss td
        {
            padding-left: 5px;
            padding-right: 5px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="tblDashboard">
        <div class="sidepanel" style="width: 42%;">
            <div class="activitydivside">
                <div class="ActivityHeader">
                    <asp:Label ID="lblFirstTitle" runat="server" Text="Question Entry" meta:resourcekey="lblFirstTitleResource1"></asp:Label>
                </div>
                <div class="ActivityContent">
                    <div>
                        <asp:Label ID="lblBMS" runat="server" Text="BMS:" CssClass="textlabel" ToolTip="Board, Medium, Standard"></asp:Label>
                        <asp:DropDownList ID="ddlbms" runat="server" AutoPostBack="True" Width="340px" AppendDataBoundItems="True"
                            OnSelectedIndexChanged="ddlbms_SelectedIndexChanged">
                            <asp:ListItem Value="0" Text="-- Select --" Selected="True"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div>
                        <asp:Label ID="lblsct" runat="server" Text="SCT:" CssClass="textlabel" ToolTip="Subject, Chapter, Topic"></asp:Label>
                        <asp:DropDownList ID="ddlsct" runat="server" AutoPostBack="True" Width="340px" AppendDataBoundItems="True">
                            <asp:ListItem Value="0" Text="-- Select --" Selected="True"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div>
                        <asp:Label ID="lblLevel" runat="server" Text="Level:" CssClass="textlabel" ToolTip="Question Level"></asp:Label>
                        <asp:DropDownList ID="ddllevel" runat="server" AutoPostBack="false" Width="140px">
                            <asp:ListItem Value="0" Text="-- Select --" Selected="True"></asp:ListItem>
                            <asp:ListItem Value="1" Text="1"></asp:ListItem>
                            <asp:ListItem Value="2" Text="2"></asp:ListItem>
                            <asp:ListItem Value="3" Text="3"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div>
                        <asp:Label ID="lblquestype" runat="server" Text="Question Type:" CssClass="textlabel"
                            ToolTip="Test Type"></asp:Label>
                        <asp:DropDownList ID="ddlquestype" runat="server" AutoPostBack="false" Width="140px">
                            <asp:ListItem Value="0" Text="-- Select --" Selected="True"></asp:ListItem>
                            <asp:ListItem Value="Pretest" Text="Pretest"></asp:ListItem>
                            <asp:ListItem Value="Posttest" Text="Posttest"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div align="center">
                        <asp:Button ID="btnview" runat="server" CssClass="ButtonStyle" Text="View" ValidationGroup="QuesEntry"
                            OnClick="btnview_Click" />&nbsp;&nbsp;
                        <asp:Button ID="btnQuestionSave" runat="server" CssClass="ButtonStyle" Text="Add"
                            ValidationGroup="QuesEntry" OnClick="btnQuestionSave_Click" />&nbsp;&nbsp;
                        <asp:Button ID="btnQuestionReset" runat="server" CssClass="ButtonStyle" Text="Reset"
                            CausesValidation="False" OnClick="btnQuestionReset_Click" />
                    </div>
                </div>
            </div>
        </div>
        <div class="sidepanel1" style="width: 54%;">
            <div class="activitydivside1" id="dvviewquestions" runat="server" visible="false"
                style="padding-left: 0px;">
                <div>
                    <asp:GridView ID="gvQuestionList" runat="server" AutoGenerateColumns="false" AllowPaging="True"
                        OnPageIndexChanging="gvQuestionList_PageIndexChanging">
                        <Columns>
                            <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblquesID" runat="server" Text='<%# Eval("QuestionBankID") %>'>' ></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Question" HeaderText="Question" />
                            <asp:BoundField DataField="Option1" HeaderText="Option1" />
                            <asp:BoundField DataField="Option2" HeaderText="Option2" />
                            <asp:BoundField DataField="Option3" HeaderText="Option3" />
                            <asp:BoundField DataField="Option4" HeaderText="Option4" />
                            <asp:BoundField DataField="Answer" HeaderText="Answer" />
                            <asp:BoundField DataField="Solution" HeaderText="Solution" />
                        </Columns>
                        <PagerStyle CssClass="gvPagerCss" HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:GridView>
                </div>
            </div>
            <div class="activitydivside1" id="dvquesdetails" runat="server" visible="false" style="padding-left: 0px;">
                <div class="ActivityHeader">
                    <asp:Label ID="lblSecondTitle" runat="server" Text="Question Details"></asp:Label>
                </div>
                <div class="activitycontent" style="margin: 5px 20px;">
                    <div>
                        <table width="100%">
                            <tr>
                                <td style="width: 95%;">
                                    Question:
                                    <br />
                                    <textarea id="Ques" rows="5" cols="80" style="width: 99%" runat="server"></textarea>
                                </td>
                                <td style="width: 5%;">
                                    <span>
                                        <asp:RequiredFieldValidator ID="RFVTxtArQues" runat="server" ErrorMessage="Enter a Question."
                                            Text="*" ControlToValidate="Ques" ValidationGroup="QuesField"></asp:RequiredFieldValidator></span>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div>
                        <table width="350px">
                            <tr>
                                <td colspan="7">
                                    Options:
                                </td>
                            </tr>
                            <tr>
                                <td width="5px" align="center" valign="top" class="LableProperty">
                                    <asp:Label ID="LblOptions" runat="server" Text=""></asp:Label>
                                </td>
                                <td width="5px" align="center" valign="top" class="LableProperty">
                                </td>
                                <td width="300px" align="center" valign="top" class="LableProperty">
                                    <asp:Label ID="LblAnswer" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td width="5px" align="right" valign="top" class="LableProperty">
                                    <asp:Label ID="LblA" runat="server" Text="A"></asp:Label>
                                </td>
                                <td width="5px" align="right" valign="top" class="LableProperty">
                                    <asp:RadioButton ID="RbOption1" runat="server" GroupName="MCQ" />
                                </td>
                                <td width="300px" align="center" valign="top" class="LableProperty">
                                    <asp:TextBox runat="server" ID="TxtAnswer1" Height="30px" Width="250px"></asp:TextBox>
                                </td>
                                <td>
                                    <span>
                                        <asp:RequiredFieldValidator ID="RFVTxtAnswer1" runat="server" ErrorMessage="Enter Option A."
                                            Text="*" ControlToValidate="TxtAnswer1" ValidationGroup="QuesField"></asp:RequiredFieldValidator></span>
                                </td>
                                <td>
                                </td>
                                <td width="5px" align="right" valign="top" class="LableProperty">
                                    <asp:Label ID="LblB" runat="server" Text="B"></asp:Label>
                                </td>
                                <td width="5px" align="right" valign="top" class="LableProperty">
                                    <asp:RadioButton ID="RbOption2" runat="server" GroupName="MCQ" />
                                </td>
                                <td width="300px" align="center" valign="top" class="LableProperty">
                                    <asp:TextBox runat="server" ID="TxtAnswer2" Height="30px" Width="250px"></asp:TextBox>
                                </td>
                                <td>
                                    <span>
                                        <asp:RequiredFieldValidator ID="RFVTxtAnswer2" runat="server" ErrorMessage="Enter Option B."
                                            Text="*" ControlToValidate="TxtAnswer2" ValidationGroup="QuesField"></asp:RequiredFieldValidator></span>
                                </td>
                            </tr>
                            <tr>
                                <td width="5px" align="right" valign="top" class="LableProperty">
                                    <asp:Label ID="LblC" runat="server" Text="C"></asp:Label>
                                </td>
                                <td width="5px" align="center" valign="top" class="LableProperty">
                                    <asp:RadioButton ID="RbOption3" runat="server" GroupName="MCQ" />
                                </td>
                                <td width="300px" align="center" valign="top" class="LableProperty">
                                    <asp:TextBox runat="server" ID="TxtAnswer3" Height="30px" Width="250px"></asp:TextBox>
                                </td>
                                <td>
                                    <span>
                                        <asp:RequiredFieldValidator ID="RFVTxtAnswer3" runat="server" ErrorMessage="Enter Option C."
                                            Text="*" ControlToValidate="TxtAnswer3" ValidationGroup="QuesField"></asp:RequiredFieldValidator></span>
                                </td>
                                <td>
                                </td>
                                <td width="5px" align="right" valign="top" class="LableProperty">
                                    <asp:Label ID="LblD" runat="server" Text="D"></asp:Label>
                                </td>
                                <td width="5px" align="right" valign="top" class="LableProperty">
                                    <asp:RadioButton ID="RbOption4" runat="server" GroupName="MCQ" />
                                </td>
                                <td width="300px" align="center" valign="top" class="LableProperty">
                                    <asp:TextBox runat="server" ID="TxtAnswer4" Height="30px" Width="250px"></asp:TextBox>
                                </td>
                                <td>
                                    <span>
                                        <asp:RequiredFieldValidator ID="RFVTxtAnswer4" runat="server" ErrorMessage="Enter Option D."
                                            Text="*" ControlToValidate="TxtAnswer4" ValidationGroup="QuesField"></asp:RequiredFieldValidator></span>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div>
                        Solution:
                        <br />
                        <textarea id="TxtSolution" rows="5" cols="80" style="width: 99%" runat="server"></textarea>
                        <span>
                            <asp:RequiredFieldValidator ID="RFVTxtSolution" runat="server" ErrorMessage="Enter the Solution."
                                Text="*" ControlToValidate="TxtSolution" ValidationGroup="QuesField"></asp:RequiredFieldValidator></span>
                    </div>
                    <div>
                        <asp:Button ID="BttnCheck" runat="server" Text="Check" OnClick="BttnCheck_Click" />
                        <asp:Button ID="BtnQuesSave" runat="server" Text="Save Question" ToolTip="Save Question"
                            ValidationGroup="QuesField" OnClick="BtnQuesSave_Click1" />&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="BtnCancelQues" runat="server" Text="Cancel Question" ToolTip="Cancel Question"
                            CausesValidation="False" OnClick="BtnCancelQues_Click1" />&nbsp;&nbsp;&nbsp;
                        &nbsp;&nbsp;&nbsp;
                    </div>
                    <div style="margin-top: 10px;">
                        <div>
                            <asp:Label ID="LblQuestion" runat="server" Text="Question"></asp:Label>&nbsp;&nbsp;
                            <asp:Literal ID="LblQusPrint" runat="server"></asp:Literal>
                            <span style="color: Red"></span>
                        </div>
                        <div>
                            <asp:Label ID="LblOptionA" runat="server" Text="Option A"></asp:Label>&nbsp;&nbsp;
                            <asp:Literal ID="LtrlOptionAPrint" runat="server"></asp:Literal>
                            <span style="color: Red"></span>
                        </div>
                        <div>
                            <asp:Label ID="LblOptionB" runat="server" Text="Option B"></asp:Label>&nbsp;&nbsp;
                            <asp:Literal ID="LtrlOptionBPrint" runat="server"></asp:Literal>
                            <span style="color: Red"></span>
                        </div>
                        <div>
                            <asp:Label ID="LblOptionC" runat="server" Text="Option C"></asp:Label>&nbsp;&nbsp;
                            <asp:Literal ID="LtrlOptionCPrint" runat="server"></asp:Literal>
                            <span style="color: Red"></span>
                        </div>
                        <div>
                            <asp:Label ID="LblOptionD" runat="server" Text="Option D"></asp:Label>&nbsp;&nbsp;
                            <asp:Literal ID="LtrlOptionDPrint" runat="server"></asp:Literal>
                            <span style="color: Red"></span>
                        </div>
                        <div>
                            <asp:Label ID="LblSoltion" runat="server" Text="Solution"></asp:Label>&nbsp;&nbsp;
                            <asp:Literal ID="LtrlSolPrint" runat="server"></asp:Literal>
                            <span style="color: Red"></span>
                        </div>
                        <div>
                            <span style="color: Red">
                                <asp:ValidationSummary ID="VSQuesField" runat="server" DisplayMode="List" ForeColor="Red"
                                    ValidationGroup="QuesField" />
                            </span>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
