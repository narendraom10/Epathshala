<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdmissionFeesAndDocument.aspx.cs"
    Inherits="Admission_AdmissionFeesAndDocument" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <title>Admission Form</title>
    <link rel="stylesheet" type="text/css" href="//fonts.googleapis.com/css?family=Open+Sans" />
    <link rel="stylesheet" href="form.css" type="text/css" />
    <script type="text/javascript">
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
<body style="width: 1040px;">
    <form id="interactionform" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" AsyncPostBackTimeout="360000" />
    <div class="panel panel-default">
        <div class="panel-heading">
            <div style="float: left;">
                <h3 class="panel-title">
                    Admission Fees And Document Submission List
                </h3>
            </div>
            <div class="rfindicator">
                <span>&nbsp;</span>
            </div>
        </div>
        <div class="panel-body" style="padding-bottom: 25px;">
            <div style="display: inline-block; float: left; background: rgb(91, 192, 222) none repeat scroll 0px 0px;
                color: white; cursor: pointer; padding: 7px;" onclick="javascript:redirectpage('admissiondashboard.aspx');">
                Dashboard
            </div>
            <div style="padding-bottom: 25px; text-align: right; margin-right: -5px;">
                <select name="AdmissionGradeFilter" id="AdmissionGradeFilter" onchange="javascript:return ChoiceAdmissionGrade();"
                    runat="server">
                    <option value="">-- select --</option>
                    <option selected="selected" value="Nursery">Nursery</option>
                    <option value="Jr KG">Jr KG</option>
                    <option value="Sr KG">Sr KG</option>
                    <option value="1">1</option>
                    <option value="2">2</option>
                    <option value="3">3</option>
                    <option value="4">4</option>
                </select>
            </div>
            <asp:UpdatePanel ID="upadmissionGrade" runat="server">
                <ContentTemplate>
                    <asp:ListView ID="lvstudent" runat="server" ItemPlaceholderID="itemPlaceHolder1"
                        OnPagePropertiesChanging="OnPagePropertiesChanging">
                        <LayoutTemplate>
                            <div class="parentlist" runat="server">
                                <div class="header_row">
                                    <div style="width: 45px;" class="grvHeaderrowcenter">
                                        Sr No
                                    </div>
                                    <div style="width: 125px;" class="grvHeaderrow">
                                        Form No
                                    </div>
                                    <div style="width: 145px;" class="grvHeaderrow">
                                        Name of the applicant
                                    </div>
                                    <div style="width: 55px;" class="grvHeaderrow">
                                        Gender
                                    </div>
                                    <div style="width: 90px;" class="grvHeaderrow">
                                        Date of birth
                                    </div>
                                    <div style="width: 120px;" class="grvHeaderrow">
                                        Applied to (Grade)
                                    </div>
                                    <div style="width: 80px;" class="grvHeaderrow">
                                        Nationality
                                    </div>
                                    <div style="width: 180px;" class="grvHeaderrow">
                                        Remarks
                                    </div>
                                    <div style="width: 65px;" class="grvHeaderrowlast">
                                        Action
                                    </div>
                                </div>
                                <div class="rowlist">
                                    <asp:PlaceHolder runat="server" ID="itemPlaceHolder1"></asp:PlaceHolder>
                                </div>
                                <div class="pager mrg">
                                    <div class="pgbutton">
                                        <asp:DataPager ID="pglvstudent" runat="server" PageSize="50">
                                            <Fields>
                                                <asp:NumericPagerField ButtonCount="2" NumericButtonCssClass="numeric_button" CurrentPageLabelCssClass="current_page"
                                                    NextPreviousButtonCssClass="next_button" />
                                            </Fields>
                                        </asp:DataPager>
                                    </div>
                                    <div class="pglabel">
                                        <asp:DataPager ID="pglvstudentlabel" runat="server" PageSize="50">
                                            <Fields>
                                                <asp:TemplatePagerField>
                                                    <PagerTemplate>
                                                        <span>Records:
                                                            <%# Container.StartRowIndex >= 0 ? (Container.StartRowIndex + 1) : 0 %>
                                                            -
                                                            <%# (Container.StartRowIndex + Container.PageSize) > Container.TotalRowCount ? Container.TotalRowCount : (Container.StartRowIndex + Container.PageSize)%>
                                                            of
                                                            <%# Container.TotalRowCount %>
                                                        </span>
                                                    </PagerTemplate>
                                                </asp:TemplatePagerField>
                                            </Fields>
                                        </asp:DataPager>
                                    </div>
                                </div>
                            </div>
                        </LayoutTemplate>
                        <ItemTemplate>
                            <div class="<%# (Container.DataItemIndex%2==0) ? "alternate_row" : "row"%>" title='<%# Eval("MobileNumberForCommunication") + " / " +  Eval("EmailIdForCommunication") %>'>
                                <div style="width: 45px;" class="grvDatarowcenter">
                                    <%# Container.DataItemIndex + 1 %>
                                    <asp:HiddenField ID="hdnAdmissionID" runat="server" Value='<%# Eval("AdmissionId") %>' />
                                </div>
                                <div style="width: 125px;" class="grvDatarow">
                                    <%# Eval("ReferenceNumber")%>
                                </div>
                                <div style="width: 145px;" class="grvDatarow">
                                    <%# Eval("Name")%>
                                </div>
                                <div style="width: 55px;" class="grvDatarow">
                                    <%# Eval("Gender")%>
                                </div>
                                <div style="width: 90px;" class="grvDatarow">
                                    <%# Eval("DateOfBirth")%>
                                </div>
                                <div style="width: 120px" class="grvDatarow">
                                    <%# Eval("AdmissionGrade")%>
                                </div>
                                <div style="width: 80px;" class="grvDatarow" title='<%# Eval("OtherNationality")%>'>
                                    <%# Eval("Nationality")%>
                                </div>
                                <div style="width: 180px;" class="grvDatarow" title='<%# Eval("Remarks") %>'>
                                    <%# Convert.ToString(Eval("Remarks")).Length <= 25 ? Eval("Remarks") : Convert.ToString(Eval("Remarks")).Substring(0, 20) + "..."%>
                                </div>
                                <div style="width: 65px; text-align: center;" class="grvDatarowlast">
                                    <a style="cursor: pointer; text-decoration: none;" onclick="javascript:return showfdpopup('<%# Eval("AdmissionId") %>','<%# Eval("AdmissionGrade") %>','<%# Eval("ReferenceNumber")%>','<%# Eval("Nationality")%>');">
                                        <img src="../App_Themes/Responsive/web/interaction.png" alt="Assign" width="16px"
                                            title="Add Student to this Vehicle" /></a>
                                </div>
                            </div>
                        </ItemTemplate>
                        <EmptyDataTemplate>
                            <div class="parentlist" runat="server">
                                <div class="header_row">
                                    <div style="width: 45px;" class="grvHeaderrowcenter">
                                        Sr No
                                    </div>
                                    <div style="width: 125px;" class="grvHeaderrow">
                                        Form No
                                    </div>
                                    <div style="width: 145px;" class="grvHeaderrow">
                                        Name of the applicant
                                    </div>
                                    <div style="width: 55px;" class="grvHeaderrow">
                                        Gender
                                    </div>
                                    <div style="width: 90px;" class="grvHeaderrow">
                                        Date of birth
                                    </div>
                                    <div style="width: 120px;" class="grvHeaderrow">
                                        Applied to (Grade)
                                    </div>
                                    <div style="width: 80px;" class="grvHeaderrow">
                                        Mobile
                                    </div>
                                    <div style="width: 180px;" class="grvHeaderrow">
                                        Remarks
                                    </div>
                                    <div style="width: 65px;" class="grvHeaderrowlast">
                                        Action
                                    </div>
                                </div>
                                <div class="row" style="text-align: center; text-align: center; height: 20px; padding-top: 5px;
                                    padding-bottom: 5px;">
                                    No Record Available</div>
                            </div>
                        </EmptyDataTemplate>
                    </asp:ListView>
                    <asp:Button ID="hdnadmissiongradefilter" Text="text" runat="server" OnClick="hdnadmissiongradefilter_Click"
                        Style="display: none;" />
                    <asp:Button Text="text" ID="btnGetHistory" runat="server" Style="display: none;"
                        OnClick="btnGetHistory_Click" />
                    <asp:Button Text="text" ID="btnsubmitadmission" runat="server" Style="display: none;"
                        OnClick="btnsubmitadmission_click" />
                    <asp:HiddenField ID="hdnCurrentAdmissionid" runat="server" Value="" />
                    <asp:HiddenField ID="hdnCurrentAdmissionGrade" runat="server" Value="" />
                    <asp:HiddenField ID="hdnCurrentNationality" runat="server" Value="" />
                    <asp:HiddenField ID="hdnCurrentReferenceNumber" runat="server" Value="" />
                    <%--Response MessageBox--%>
                    <div id="fdpopup" runat="server" class="overlay">
                        <div class="popup" style="width: 30%;">
                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    <div style="float: left;">
                                        <h3 class="panel-title" style="font-size: 0.9em !important;">
                                            Submit Fees And Document: <span id="referencenumber" runat="server"></span>
                                        </h3>
                                    </div>
                                    <div class="rfindicator">
                                        <span>&nbsp;</span>
                                    </div>
                                </div>
                                <div class="panel-body">
                                    <fieldset>
                                        <legend></legend>
                                        <ol>
                                            <li>
                                                <table width="100%">
                                                    <tr>
                                                        <td>
                                                            <asp:CheckBoxList ID="chkdocumentlist" runat="server" CssClass="chkChoice">
                                                            </asp:CheckBoxList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <div class="dvmultioption" style="float: right; font-size: 0.9em; margin-top: 10px;
                                                                border: none; margin-bottom: 10px; margin-right: -10px;">
                                                                <div style="display: inline-block; float: left; background: rgb(91, 192, 222) none repeat scroll 0px 0px;
                                                                    color: white; cursor: pointer; padding: 7px 15px 7px 15px; margin-right: 8px;
                                                                    font-size: 1.15em;" onclick="javascript:return submitfdpopup();">
                                                                    Submit
                                                                </div>
                                                                <div style="display: inline-block; float: left; background: rgb(91, 192, 222) none repeat scroll 0px 0px;
                                                                    color: white; cursor: pointer; padding: 7px 15px 7px 15px; font-size: 1.15em;"
                                                                    onclick="javascript:return Closefdpopup();">
                                                                    Close
                                                                </div>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </li>
                                        </ol>
                                    </fieldset>
                                </div>
                            </div>
                        </div>
                    </div>
                    <%--Response MessageBox--%>
                    <div id="mainpopup" runat="server" class="overlay">
                        <div class="popup" style="width: 30%;">
                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    <div style="float: left;">
                                        <h3 class="panel-title">
                                            Message
                                        </h3>
                                    </div>
                                    <div class="rfindicator">
                                        <span>&nbsp;</span>
                                    </div>
                                </div>
                                <div class="panel-body">
                                    <fieldset>
                                        <legend></legend>
                                        <ol>
                                            <li>
                                                <table width="100%">
                                                    <tr>
                                                        <td>
                                                            <span id="msg" runat="server"></span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <div class="dvmultioption" style="float: right; margin-top: 10px; border: none; margin-bottom: 10px;">
                                                                <asp:Button ID="btnclose" Text="Close" runat="server" OnClientClick="javascript:return CloseMessage();" />
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </li>
                                        </ol>
                                    </fieldset>
                                </div>
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <!-- LoaderPart start-->
            <asp:Button ID="btnLoader" runat="server" Style="display: none" />
            <asp:Button ID="btnCancel" runat="server" Style="display: none" />
            <cc1:ModalPopupExtender ID="ModalPopup" runat="server" PopupControlID="dvPopup" CancelControlID="btnCancel"
                TargetControlID="btnLoader" BackgroundCssClass="modalBackground" Enabled="True">
            </cc1:ModalPopupExtender>
            <table id="dvPopup" runat="server" style="border: 1px solid #5bc0de; display: none;"
                class="loadingtable" cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <img src="../App_Themes/Responsive/web/Loader.gif" alt="Loading Please wait.." />
                    </td>
                </tr>
                <tr>
                    <td class="loadingtabletd">
                        <span>Processing Please Wait..</span>
                    </td>
                </tr>
            </table>
            <!-- LoaderPart end-->
        </div>
    </div>
    </form>
    <script type="text/javascript">
        var prm = Sys.WebForms.PageRequestManager.getInstance(); prm.add_beginRequest(BeginRequestHandler); prm.add_endRequest(EndRequestHandler);
        function BeginRequestHandler(sender, args) { ShowLoader(); } function EndRequestHandler(sender, args) { HideLoader(); }
        function ShowLoader() { if (document.getElementById("<%= btnLoader.ClientID%>") != null) { document.getElementById("<%= btnLoader.ClientID%>").click(); } }
        function HideLoader() { if (document.getElementById("<%= btnCancel.ClientID%>") != null) { document.getElementById("<%= btnCancel.ClientID%>").click(); } }
        function ChoiceAdmissionGrade() { __doPostBack('<%= hdnadmissiongradefilter.UniqueID %>', '') }
        function CheckALL(obj) { var rowlist = document.getElementsByTagName("INPUT"); for (var index = 0; index < rowlist.length; index++) { var control = rowlist[index]; if (control.id != undefined && control.id != null && control.id.length > 0) { if (control.id.endsWith("finaladmissioncheck")) { control.checked = obj.checked; } } } }
        function CheckSingle(obj) { var AllChecked = true; var rowlist = document.getElementsByTagName("INPUT"); for (var index = 0; index < rowlist.length; index++) { var control = rowlist[index]; if (control.id != undefined && control.id != null && control.id.length > 0) { if (control.id.endsWith("finaladmissioncheck")) { if (!control.checked) { AllChecked = false; break; } } } } document.getElementById('chkALL').checked = AllChecked; }
        function CloseMessage() { document.getElementById("<%= mainpopup.ClientID %>").className = "overlay"; return false; }
        function redirectpage(page) { var win = window.open(page, '_self'); }
        function showfdpopup(id, ag, rn, nat) {
            document.getElementById('<%=hdnCurrentAdmissionid.ClientID %>').value = id;
            document.getElementById('<%=hdnCurrentAdmissionGrade.ClientID %>').value = ag;
            document.getElementById('<%=hdnCurrentReferenceNumber.ClientID %>').value = rn;
            document.getElementById('<%=hdnCurrentNationality.ClientID %>').value = nat;
            __doPostBack('<%= btnGetHistory.UniqueID %>', '')
            return false;
        }
        function Closefdpopup() { document.getElementById("<%= fdpopup.ClientID %>").className = "overlay"; return false; }
        function submitfdpopup() {
            __doPostBack('<%= btnsubmitadmission.UniqueID %>', '')
            return false;
        }
    </script>
</body>
</html>
