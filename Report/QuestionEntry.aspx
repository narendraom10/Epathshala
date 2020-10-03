<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Epathshala.master" AutoEventWireup="true"
    CodeFile="QuestionEntry.aspx.cs" Inherits="QuestionEntry" EnableEventValidation="false"
    ValidateRequest="false" MaintainScrollPositionOnPostback="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../tiny_mce/tiny_mce.js"></script>
    <script type="text/javascript" language="javascript">

        tinyMCE.init({

            // General options

            mode: "textareas",

            theme: "advanced",

            plugins: "safari,pagebreak,style,layer,table,save,advhr,advimage,advlink,emotions,iespell,inlinepopups,insertdatetime,preview,media,searchreplace,print,contextmenu,paste,directionality,fullscreen,noneditable,visualchars,nonbreaking,xhtmlxtras,template,wordcount",

            // Theme options

            theme_advanced_buttons1: "save,newdocument,|,bold,italic,underline,strikethrough,|,justifyleft,justifycenter,justifyright,justifyfull,styleselect,formatselect,fontselect,fontsizeselect",
            theme_advanced_buttons2: "cut,copy,paste,pastetext,pasteword,|,search,replace,|,bullist,numlist,|,outdent,indent,blockquote,|,undo,redo,|,link,unlink,anchor,image,cleanup,help,code,|,insertdate,inserttime,preview,|,forecolor,backcolor",
            theme_advanced_buttons3: "tablecontrols,|,hr,removeformat,visualaid,|,sub,sup,|,charmap,emotions,iespell,media,advhr,|,print,|,ltr,rtl,|,fullscreen",
            theme_advanced_buttons4: "insertlayer,moveforward,movebackward,absolute,|,styleprops,|,cite,abbr,acronym,del,ins,attribs,|,visualchars,nonbreaking,template,pagebreak",
            theme_advanced_toolbar_location: "top",
            theme_advanced_toolbar_align: "left",
            theme_advanced_statusbar_location: "bottom",
            theme_advanced_resizing: true,

            // Example content CSS (should be your site CSS)

            content_css: "css/content.css",

            // Drop lists for link/image/media/template dialogs

            template_external_list_url: "lists/template_list.js",

            external_link_list_url: "lists/link_list.js",

            external_image_list_url: "lists/image_list.js",

            media_external_list_url: "lists/media_list.js",

            // Replace values for the template plugin

            template_replace_values: {

                username: "Some User",

                staffid: "991234"

            }

        });

    </script>
    <asp:UpdatePanel runat="server" ID="upMain" UpdateMode="Conditional">
        <ContentTemplate>
            <table class="TabControlBody" border="1" width="100%">
                <tr>
                    <td colspan="4" align="left" valign="middle" class="LableProperty" style="height: 25px;
                        color: White; background-color: #0097DF">
                        <asp:Label ID="LblQueEntrySelection" runat="server" Text="Question Entry" Style="margin-left: 10px"></asp:Label>
                    </td>
                </tr>
                <tr style="height: 5px">
                    <td colspan="4">
                        &nbsp;&nbsp;
                    </td>
                </tr>
                <tr>
                    <td width="25%" align="right" valign="top" class="LableProperty">
                        <asp:Label ID="CT2_LblBMS" runat="server" Text="BMS:" ToolTip="Board > Medium > Standard > Subject"></asp:Label>&nbsp;&nbsp;
                    </td>
                    <td width="25%" align="left" valign="top" class="LableProperty">
                        <asp:DropDownList ID="ddlBMSList" runat="server" CssClass="DroupDownListProperty"
                            AppendDataBoundItems="True" Width="80%" AutoPostBack="True" OnSelectedIndexChanged="ddlBMSList_SelectedIndexChanged">
                            <asp:ListItem Value="0" Text="-- SELECT --"></asp:ListItem>
                        </asp:DropDownList>
                        <span style="color: Red">
                            <asp:RequiredFieldValidator ID="RFVddlBMSList" runat="server" ErrorMessage="Select the BMS."
                                Text="*" ValidationGroup="QuesEntry" ControlToValidate="ddlBMSList" InitialValue="0"></asp:RequiredFieldValidator></span>
                    </td>
                    <td width="25%" align="right" valign="top" class="LableProperty">
                        <asp:Label ID="LblQuesLevel" runat="server" Text="Question Level:"></asp:Label>&nbsp;&nbsp;
                    </td>
                    <td width="25%" align="left" valign="top" class="LableProperty">
                        <asp:DropDownList ID="ddlQuesLevel" Width="80%" runat="server" CssClass="DroupDownListProperty">
                            <asp:ListItem Selected="True" Value="1" Text="1"></asp:ListItem>
                            <asp:ListItem Value="2" Text="2"></asp:ListItem>
                            <asp:ListItem Value="3" Text="3"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td width="25%" align="right" valign="top" class="LableProperty">
                        <asp:Label ID="CT2_LblSCT" runat="server" Text="SCT:" ToolTip="Subject > Chapter > Topic > "></asp:Label>&nbsp;&nbsp;
                    </td>
                    <td width="25%" align="left" valign="top" class="LableProperty">
                        <asp:DropDownList ID="ddlSCTList" runat="server" CssClass="DroupDownListProperty"
                            AppendDataBoundItems="True" Width="80%" AutoPostBack="True" Enabled="false">
                            <asp:ListItem Value="0" Text="-- SELECT --"></asp:ListItem>
                        </asp:DropDownList>
                        <span style="color: Red">
                            <asp:RequiredFieldValidator ID="RFVddlSCTList" runat="server" ErrorMessage="Select the SCT."
                                Text="*" ValidationGroup="QuesEntry" ControlToValidate="ddlSCTList" InitialValue="0"></asp:RequiredFieldValidator></span>
                    </td>
                    <td width="25%" align="right" valign="top" class="LableProperty">
                        <asp:Label ID="LblQuesType" runat="server" Text="Question Type:"></asp:Label>&nbsp;&nbsp;
                    </td>
                    <td width="25%" align="left" valign="top" class="LableProperty">
                        <asp:DropDownList ID="ddlQuesTypeList" runat="server" CssClass="DroupDownListProperty"
                            Width="80%">
                            <asp:ListItem Selected="True" Value="Pretest" Text="Pretest"></asp:ListItem>
                            <asp:ListItem Value="Posttest" Text="Posttest"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" align="center" valign="top" class="LableProperty">
                        <asp:Button ID="btnQuestionSave" runat="server" CssClass="ButtonStyle" Text="Add"
                            ValidationGroup="QuesEntry" OnClick="btnQuestionSave_Click" />&nbsp;&nbsp;
                        <asp:Button ID="btnQuestionReset" runat="server" CssClass="ButtonStyle" Text="Reset"
                            CausesValidation="False" OnClick="btnQuestionReset_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="4" align="center" valign="top" class="LableProperty">
                        <span style="color: Red">
                            <asp:ValidationSummary ID="VSQUES" runat="server" ValidationGroup="QuesEntry" DisplayMode="List"
                                ForeColor="Red" />
                        </span>
                    </td>
                </tr>
                <div id="QuestionEntryDiv" runat="server" visible="False">
                    <tr>
                        <td width="80%" colspan="3" align="left" valign="top" class="LableProperty">
                            <asp:Label ID="LblQues" runat="server" Text="Question:"></asp:Label>
                        </td>
                        <td width="20%" align="right" valign="top" class="LableProperty">
                            <a href="Math_Help.htm" target="_blank">Math Help </a>
                        </td>
                    </tr>
                    <tr>
                        <td width="100%" colspan="4" align="center" valign="top" class="LableProperty">
                            <textarea id="Ques" rows="15" cols="80" style="width: 80%" runat="server"></textarea>
                            <span>
                                <asp:RequiredFieldValidator ID="RFVTxtArQues" runat="server" ErrorMessage="Enter a Question."
                                    Text="*" ControlToValidate="Ques" ValidationGroup="QuesField"></asp:RequiredFieldValidator></span>
                        </td>
                    </tr>
                    <tr>
                        <td width="100%" colspan="4" align="center" valign="top" class="LableProperty">
                            <div>
                                <table width="350px">
                                    <tr>
                                        <td width="5px" align="center" valign="top" class="LableProperty">
                                            <asp:Label ID="LblOptions" runat="server" Text="Options"></asp:Label>
                                        </td>
                                        <td width="5px" align="center" valign="top" class="LableProperty">
                                        </td>
                                        <td width="300px" align="center" valign="top" class="LableProperty">
                                            <asp:Label ID="LblAnswer" runat="server" Text="Answer"></asp:Label>
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
                                            <span>
                                                <asp:RequiredFieldValidator ID="RFVTxtAnswer1" runat="server" ErrorMessage="Enter the Option A."
                                                    Text="*" ControlToValidate="TxtAnswer1" ValidationGroup="QuesField"></asp:RequiredFieldValidator></span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="5px" align="right" valign="top" class="LableProperty">
                                            <asp:Label ID="LblB" runat="server" Text="B"></asp:Label>
                                        </td>
                                        <td width="5px" align="right" valign="top" class="LableProperty">
                                            <asp:RadioButton ID="RbOption2" runat="server" GroupName="MCQ" />
                                        </td>
                                        <td width="300px" align="center" valign="top" class="LableProperty">
                                            <asp:TextBox runat="server" ID="TxtAnswer2" Height="30px" Width="250px"></asp:TextBox>
                                            <span>
                                                <asp:RequiredFieldValidator ID="RFVTxtAnswer2" runat="server" ErrorMessage="Enter the Option B."
                                                    Text="*" ControlToValidate="TxtAnswer1" ValidationGroup="QuesField"></asp:RequiredFieldValidator></span>
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
                                            <span>
                                                <asp:RequiredFieldValidator ID="RFVTxtAnswer3" runat="server" ErrorMessage="Enter the Option C."
                                                    Text="*" ControlToValidate="TxtAnswer3" ValidationGroup="QuesField"></asp:RequiredFieldValidator></span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="5px" align="right" valign="top" class="LableProperty">
                                            <asp:Label ID="LblD" runat="server" Text="D"></asp:Label>
                                        </td>
                                        <td width="5px" align="right" valign="top" class="LableProperty">
                                            <asp:RadioButton ID="RbOption4" runat="server" GroupName="MCQ" />
                                        </td>
                                        <td width="300px" align="center" valign="top" class="LableProperty">
                                            <asp:TextBox runat="server" ID="TxtAnswer4" Height="30px" Width="250px"></asp:TextBox>
                                            <span>
                                                <asp:RequiredFieldValidator ID="RFVTxtAnswer4" runat="server" ErrorMessage="Enter the Option D."
                                                    Text="*" ControlToValidate="TxtAnswer4" ValidationGroup="QuesField"></asp:RequiredFieldValidator></span>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td width="100%" colspan="4" align="left" valign="top" class="LableProperty">
                            <asp:Label ID="LblSolution" runat="server" Text="Solution:"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td width="100%" colspan="4" align="center" valign="top" class="LableProperty">
                            <textarea id="TxtSolution" rows="15" cols="80" style="width: 80%" runat="server"></textarea>
                            <span>
                                <asp:RequiredFieldValidator ID="RFVTxtSolution" runat="server" ErrorMessage="Enter the Solution."
                                    Text="*" ControlToValidate="TxtSolution" ValidationGroup="QuesField"></asp:RequiredFieldValidator></span>
                        </td>
                    </tr>
                    <tr>
                        <td width="100%" colspan="4" align="center" valign="top" class="LableProperty">
                            <asp:ImageButton ID="BtnQuesSave" runat="server" ImageUrl="~/Images/Save.png" Width="35px"
                                Height="35px" ToolTip="Save Question" ValidationGroup="QuesField" OnClick="BtnQuesSave_Click" />&nbsp;&nbsp;&nbsp;
                            <asp:ImageButton ID="BtnCancelQues" runat="server" ImageUrl="~/Images/close.png"
                                Width="35px" Height="35px" ToolTip="Cancel Question" CausesValidation="False"
                                OnClick="BtnCancelQues_Click" />&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" align="center" valign="top" class="LableProperty">
                            <span style="color: Red">
                                <asp:ValidationSummary ID="VSQuesField" runat="server" DisplayMode="List" ForeColor="Red"
                                    ValidationGroup="QuesField" />
                            </span>
                        </td>
                    </tr>
                    <tr>
                        <td width="100%" colspan="4" align="center" valign="top" class="LableProperty">
                            <asp:Button ID="BttnCheck" runat="server" Text="Check" OnClick="BttnCheck_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td width="25%" align="right" valign="top" class="LableProperty">
                            <asp:Label ID="LblQuestion" runat="server" Text="Question"></asp:Label>&nbsp;&nbsp;
                        </td>
                        <td width="100%" colspan="3" align="left" valign="top" class="LableProperty">
                            <asp:Literal ID="LblQusPrint" runat="server"></asp:Literal>
                            <span style="color: Red"></span>
                        </td>
                    </tr>
                    <tr>
                        <td width="25%" align="right" valign="top" class="LableProperty">
                            <asp:Label ID="LblOptionA" runat="server" Text="Option A"></asp:Label>&nbsp;&nbsp;
                        </td>
                        <td width="100%" colspan="3" align="left" valign="top" class="LableProperty">
                            <asp:Literal ID="LtrlOptionAPrint" runat="server"></asp:Literal>
                            <span style="color: Red"></span>
                        </td>
                    </tr>
                    <tr>
                        <td width="25%" align="right" valign="top" class="LableProperty">
                            <asp:Label ID="LblOptionB" runat="server" Text="Option B"></asp:Label>&nbsp;&nbsp;
                        </td>
                        <td width="100%" colspan="3" align="left" valign="top" class="LableProperty">
                            <asp:Literal ID="LtrlOptionBPrint" runat="server"></asp:Literal>
                            <span style="color: Red"></span>
                        </td>
                    </tr>
                    <tr>
                        <td width="25%" align="right" valign="top" class="LableProperty">
                            <asp:Label ID="LblOptionC" runat="server" Text="Option C"></asp:Label>&nbsp;&nbsp;
                        </td>
                        <td width="100%" colspan="3" align="left" valign="top" class="LableProperty">
                            <asp:Literal ID="LtrlOptionCPrint" runat="server"></asp:Literal>
                            <span style="color: Red"></span>
                        </td>
                    </tr>
                    <tr>
                        <td width="25%" align="right" valign="top" class="LableProperty">
                            <asp:Label ID="LblOptionD" runat="server" Text="Option D"></asp:Label>&nbsp;&nbsp;
                        </td>
                        <td width="100%" colspan="3" align="left" valign="top" class="LableProperty">
                            <asp:Literal ID="LtrlOptionDPrint" runat="server"></asp:Literal>
                            <span style="color: Red"></span>
                        </td>
                    </tr>
                    <tr>
                        <td width="25%" align="right" valign="top" class="LableProperty">
                            <asp:Label ID="LblSoltion" runat="server" Text="Solution"></asp:Label>&nbsp;&nbsp;
                        </td>
                        <td width="100%" colspan="3" align="left" valign="top" class="LableProperty">
                            <asp:Literal ID="LtrlSolPrint" runat="server"></asp:Literal>
                            <span style="color: Red"></span>
                        </td>
                    </tr>
                </div>
            </table>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="ddlBMSList" />
            <asp:AsyncPostBackTrigger ControlID="BttnCheck" />
        </Triggers>
    </asp:UpdatePanel>
    <!-- LoaderPart -->
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
    <!-- LoaderPart -->
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
    </script>
</asp:Content>
