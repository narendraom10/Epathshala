<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StudentAssessment.aspx.cs"
    Inherits="Student_StudentAssessment" Culture="auto" meta:resourcekey="PageResource1"
    UICulture="auto" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>

    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/mathjax/2.7.4/latest.js?config=AM_CHTML"></script>
    <script src="../JavaScript/ASCIIMathML.js"></script>
    <script src="../JavaScript/jquery-1.4.2.js"></script>

    <!--     Fonts and icons     -->
    <link rel="stylesheet" type="text/css" href="https://fonts.googleapis.com/css?family=Roboto:300,400,500,700|Roboto+Slab:400,700|Material+Icons" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/latest/css/font-awesome.min.css" />
    <!-- CSS Files -->
    <link href="../assets/css/material-dashboard.css?v=2.1.0" rel="stylesheet" />
    <!-- CSS Just for demo purpose, don't include it in your project -->
    <link href="../assets/demo/demo.css" rel="stylesheet" />

    <script type="text/javascript" src="../JavaScript/ASCIIMathML.js"></script>
    <script type="text/javascript" src="../JavaScript/jquery-1.4.2.js"></script>
    <script src="../App_Themes/Green/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <link href="../App_Themes/Green/bootstrap/css/bootstrap.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../App_Themes/Green/bootstrap/css/bootstrap-theme.min.css" rel="stylesheet"
        type="text/css" />
    <script src="../App_Themes/Green/CircularChart/js/jquery.circliful.min.js" type="text/javascript"></script>
    <%--<link href="../App_Themes/GreenDashboard.css" rel="stylesheet" type="text/css" />--%>
    <style type="text/css">
        * {
            padding: 0px;
            margin: 0px;
            /*white-space: nowrap;*/
            font-size: 14pt;
        }

        html {
            background-image: url('Images/green-bg.jpg') !important;
            background-repeat: repeat !important;
        }

        .ResultPnl * {
            color: Black;
        }

        .GridViewCssTestAssessment {
            border: none;
            margin: 1px 1px 1px 1px;
            padding: 1px 1px 1px 1px;
            text-align: center;
            color: #777777;
            font-family: Roboto-Light;
            font-size: 14px;
        }

            .GridViewCssTestAssessment td {
                border: none;
                padding: 4px 3px 4px 3px;
            }

        .GridViewHeadercssTestAssessment th {
            border: 0px solid #CCCCCC;
            padding: 8px 2px 2px 2px;
            text-align: center;
            color: White;
        }

            .GridViewHeadercssTestAssessment th a {
                color: White;
                text-decoration: none;
            }

        .GridViewHeadercssTestAssessment {
            background-color: #263434;
            color: #71af32;
            overflow: hidden;
        }

        .GridViewItemTestAssessment {
            margin: 2px 2px 2px 2px;
            text-align: left;
            color: #777777;
        }
    </style>
</head>
<%--style="background-image: url('Images/green-bg.jpg') !important; background-repeat: repeat !important;"--%>
<body>

    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <Triggers>
                <%--<asp:PostBackTrigger ControlID="BtnButton" />--%>
                <asp:PostBackTrigger ControlID="BtnButton" />
            </Triggers>
            <ContentTemplate>
                <script type="text/javascript" src="../JavaScript/ASCIIMathML.js"></script>
                <script type="text/javascript" src="../JavaScript/jquery-1.4.2.js"></script>
                <%--<link href="../App_Themes/GreenDashboard.css" rel="stylesheet" type="text/css" />--%>

                <div class="container">
                    <div class="row">
                        <div class="col-12">
                            <%--MCQ/ Pretest/ PostTest--%>
                            <div id="Examtbl" runat="server">


                                <div class="col-12">
                                    <div class="card" style="margin-top: 75px !important;">
                                        <div class="card-title" style="border-bottom: 1px solid silver;">

                                            <div style="padding: 10px 20px;">
                                                <asp:Literal ID="ltQuestionCount" Text="Ques. " runat="server" meta:resourcekey="ltQuestionCountResource1"></asp:Literal>
                                                <asp:Literal ID="ltQuestionCount1" runat="server" meta:resourcekey="ltQuestionCount1Resource1"></asp:Literal>
                                                <asp:Literal ID="ltQuestionCount2" Text="out of" runat="server" meta:resourcekey="ltQuestionCount2Resource1"></asp:Literal>
                                                <asp:Literal ID="ltQuestionCount3" Text="Question No 1 out of 20" runat="server"
                                                    meta:resourcekey="ltQuestionCount3Resource1"></asp:Literal>
                                            </div>
                                        </div>
                                        <div class="card-body">

                                            <%--Question--%>
                                            <div class="Content">
                                                <asp:Label ID="lblQues" runat="server" Text="Question" meta:resourcekey="lblQuesResource1"
                                                    Style="display: none; white-space: normal; 8"></asp:Label>
                                                <asp:Literal ID="ltQuestion" runat="server" meta:resourcekey="ltQuestionResource1"></asp:Literal>
                                            </div>

                                            <%--Options--%>
                                            <style>
                                                .radiobuttonlist input {
                                                    display: inline-block;
                                                    margin: 0px !important;
                                                    padding: 10px !important;
                                                    line-height: 75px !important;
                                                }

                                                .radiobuttonlist label {
                                                    display: inline-block;
                                                    margin: 0px !important;
                                                    padding: 10px !important;
                                                    font-size: 14pt !important;
                                                    margin-left: 15px !important;
                                                    margin-top: -25px !important;
                                                    min-width: 300px !important;
                                                    line-height: 45px !important;
                                                }
                                            </style>

                                            <div class="radio radiobuttonlist col-sm-9">
                                                <asp:RadioButtonList ID="rdb" runat="server" CellSpacing="10" meta:resourcekey="rdbResource1"
                                                    ValidationGroup="Exm" Width="100%" RepeatDirection="Vertical" RepeatLayout="Flow">
                                                </asp:RadioButtonList>
                                            </div>
                                        </div>

                                        <div class="card-footer">
                                            <asp:Button CssClass="btn btn-outline-success" ID="BtnButton" runat="server" Text="Next" OnClick="BtnButton_Click" ValidationGroup="Exm"
                                                meta:resourcekey="BtnButtonResource1" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="rdb"
                                                ErrorMessage="Please select any one answer" meta:resourcekey="RequiredFieldValidator1Resource1"
                                                ValidationGroup="Exm" Style="float: left"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <%-------------------------------------------------------------------------------------------------%>


                <style>
                    #gvAnalysis {
                        width:100%;
                    }
                </style>

                <%--Exam Result Report--%>
                <div class="container">
                    <div class="row">
                        <div class="col-12">
                            <%--Exam Result Report--%>
                            <div id="ExamResult" runat="server" visible="False" width="100%">
                                <div class="row">
                                    <div style="padding: 15px;" class="col-sm-12 col-xs-12 col-md-12 col-lg-12">

                                        <table class="table table-striped table-bordered">
                                            <thead>
                                                <tr>
                                                    <th colspan="2" class="text-center">
                                                        <asp:Label ID="lblASum" runat="server" Font-Bold="True" Text="Assessment summary"
                                                            meta:resourcekey="lblASumResource1"></asp:Label>
                                                    </th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <tr>
                                                    <td class="text-right" style="width: 50%">
                                                        <asp:Label ID="Label8" runat="server"
                                                            CssClass="Label" Text="Total Question:" meta:resourcekey="Label8Resource1"></asp:Label>
                                                    </td>
                                                    <td class="text-left" style="width: 50%">
                                                        <asp:Label ID="lblTotalQues" runat="server" Text="0" meta:resourcekey="lblTotalQuesResource1"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="text-right">
                                                        <asp:Label ID="Label11" runat="server"
                                                            CssClass="Label" Text="Correct:" meta:resourcekey="Label11Resource1"></asp:Label>
                                                    </td>
                                                    <td class="text-left">
                                                        <asp:Label ID="lblTrueAns" runat="server" Text="0" meta:resourcekey="lblTrueAnsResource1"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="text-right">
                                                        <asp:Label ID="Label13" runat="server"
                                                            CssClass="Label" Text="False:" meta:resourcekey="Label13Resource1"></asp:Label>
                                                    </td>
                                                    <td class="text-left">
                                                        <asp:Label ID="lblFalseAns" runat="server" Text="0" meta:resourcekey="lblFalseAnsResource1"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="text-right">
                                                        <asp:Label ID="lbluserScore" runat="server"
                                                            CssClass="Label" Text="You have score :" meta:resourcekey="lbluserScoreResource1"></asp:Label>
                                                    </td>
                                                    <td class="text-left">
                                                        <asp:Label ID="lbluserScoreValue" runat="server" Text="Label"
                                                            meta:resourcekey="lbluserScoreValueResource1"></asp:Label>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-12 col-xs-12 col-md-12 col-lg-12" style="padding: 15px;">
                                        <asp:GridView ID="gvAnalysis" runat="server" OnRowDataBound="gvAnalysis_RowDataBound"
                                            SkinID="TestAssessment" meta:resourcekey="gvAnalysisResource1" AutoGenerateColumns="False">
                                            <Columns>
                                                <asp:TemplateField meta:resourcekey="TemplateFieldResource1">
                                                    <HeaderTemplate>
                                                        <div class="text-center">
                                                            <asp:Label ID="Label4" Text="Assessment" runat="server" Font-Bold="True" meta:resourcekey="Label4Resource1"></asp:Label>
                                                        </div>

                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <table class="table table-responsive">
                                                            <tr>
                                                                <td class="text-right">
                                                                    <asp:Label ID="lblQ" runat="server" Text="Ques" ForeColor="#000000" Font-Bold="True"
                                                                        meta:resourcekey="lblQResource1"></asp:Label>
                                                                    <span style="color: #000000; font-weight: bold">
                                                                        <asp:Label ID="lblNo" runat="server" ForeColor="#000000" Font-Bold="True" Text='<%# Container.DataItemIndex +1 %>'
                                                                            meta:resourcekey="lblNoResource1"></asp:Label>: </span>
                                                                </td>
                                                                <td colspan="4">
                                                                    <asp:Literal ID="ltQuestion" runat="server" Text='<%# Eval("Question") %>'></asp:Literal>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right" style="border: none; white-space: nowrap;">
                                                                    <asp:Label ID="lblCorrectAns" runat="server" ForeColor="#000000" Text="Correct Answer:"
                                                                        Font-Bold="True" meta:resourcekey="lblCorrectAnsResource1"></asp:Label>
                                                                </td>
                                                                <td align="left" style="border: none;">
                                                                    <asp:Literal ID="lblCorrect" runat="server" Text='<%# Eval("Answer") %>'></asp:Literal>
                                                                </td>
                                                                <td align="right" style="border: none;"></td>
                                                                <td align="left" style="border: none;">
                                                                    <asp:Label ID="lblSrNo" runat="server" meta:resourcekey="lblSrNoResource1"></asp:Label>
                                                                </td>
                                                                <td rowspan="3" valign="middle" style="padding-right: 10px; border: none; display: none;"
                                                                    align="right">
                                                                    <asp:Panel ID="pnlview" runat="server" meta:resourcekey="pnlviewResource1">
                                                                        <asp:Button ID="btnSolution" Text="View Solution" runat="server" meta:resourcekey="btnSolutionResource1" />
                                                                    </asp:Panel>
                                                                    <asp:Panel ID="MainPanel" runat="server" Style="display: none;" Width="100%" meta:resourcekey="MainPanelResource1">
                                                                        <asp:Panel ID="pnldrag" runat="server" Style="cursor: move; text-align: center; font-weight: bold; font-size: 20px; width: 710px; color: white"
                                                                            meta:resourcekey="pnldragResource1">
                                                                        </asp:Panel>
                                                                        <asp:Panel runat="server" Style="width: 100%; color: Black;" meta:resourcekey="innerPanelResource1">
                                                                            <table style="position: fixed; border: solid 1px #000000; vertical-align: middle; text-align: center; width: 98%; background-color: White;"
                                                                                border="0" class="ResultPnl">
                                                                                <tr>
                                                                                    <th style="border-left: 1px solid #ffffff; border-top: 1px solid #ffffff; background-color: #000000; height: 25; font-size: 14px; font-weight: bold; text-align: center;"
                                                                                        width="100%">
                                                                                        <asp:Label ID="lblPkg" runat="server" ForeColor="White" Font-Bold="True" Text="Solution"
                                                                                            meta:resourcekey="lblPkgResource1"></asp:Label>
                                                                                    </th>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align="left">
                                                                                        <asp:Label ID="lblQues" runat="server" Font-Bold="True" Text="Question :" meta:resourcekey="lblQuesResource2"></asp:Label>
                                                                                        <asp:Literal ID="ltQues" Text='<%# Eval("Question") %>' runat="server"></asp:Literal>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align="left">
                                                                                        <asp:Label ID="lblAns" runat="server" Font-Bold="True" Text="Solution" meta:resourcekey="lblAnsResource1"></asp:Label>
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
                                                                    <asp:Label ID="lblYourAns" runat="server" ForeColor="#000000" Text="Your Answer:"
                                                                        Font-Bold="True" meta:resourcekey="lblYourAnsResource1"></asp:Label>
                                                                </td>
                                                                <td align="left" style="border: none;" colspan="4">
                                                                    <asp:Literal ID="lblGiven" runat="server" Text="ads" meta:resourcekey="lblGivenResource1"></asp:Literal>
                                                                </td>

                                                            </tr>
                                                            <tr>
                                                                <td align="right" style="border: none;">
                                                                    <asp:Label ID="lblResu" runat="server" ForeColor="#000000" Text="Result:" Font-Bold="True"
                                                                        meta:resourcekey="lblResuResource1"></asp:Label>
                                                                </td>
                                                                <td align="left" style="border: none;" colspan="4">
                                                                    <asp:Label ID="lblResult" runat="server" Text='0' meta:resourcekey="lblResultResource1"></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
    <script type="text/javascript">
        $(document).ready(function () {
            parent.autoResize();
        });
    </script>

    <!--   Core JS Files   -->
    <script src="../assets/js/core/jquery.min.js" type="text/javascript"></script>
    <script src="../assets/js/core/popper.min.js" type="text/javascript"></script>
    <script src="../assets/js/core/bootstrap-material-design.min.js" type="text/javascript"></script>
    <script src="../assets/js/plugins/perfect-scrollbar.jquery.min.js"></script>
    <!--  Google Maps Plugin    -->
    <script src="https://maps.googleapis.com/maps/api/js?key=YOUR_KEY_HERE"></script>
    <!-- Chartist JS -->
    <script src="../assets/js/plugins/chartist.min.js"></script>
    <!--  Notifications Plugin    -->
    <script src="../assets/js/plugins/bootstrap-notify.js"></script>
    <!-- Control Center for Material Dashboard: parallax effects, scripts for the example pages etc -->
    <script src="../assets/js/material-dashboard.min.js?v=2.1.0" type="text/javascript"></script>
    <!-- Material Dashboard DEMO methods, don't include it in your project! -->
    <script src="../assets/demo/demo.js"></script>
    <script>
        $(document).ready(function () {
            // Javascript method's body can be found in assets/js/demos.js
            md.initDashboardPageCharts();

        });
    </script>
    <%--<p>`3^n`</p>--%>
</body>
</html>
