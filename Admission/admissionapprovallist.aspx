<%@ Page Language="C#" AutoEventWireup="true" CodeFile="admissionapprovallist.aspx.cs"
    Inherits="Admission_admissionapprovallist" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admission Fees And Document</title>
    <meta charset="UTF-8" />
    <title>Admission Approval List</title>
    <link rel="stylesheet" type="text/css" href="//fonts.googleapis.com/css?family=Open+Sans" />
    <link rel="stylesheet" href="form.css" type="text/css" />
    <script type="text/javascript" src="form.js"></script>
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
    <asp:ScriptManager runat="server" AsyncPostBackTimeout="360000" />
    <div class="panel panel-default">
        <div class="panel-heading">
            <div style="float: left;">
                <h3 class="panel-title">
                    Admission Approval List
                </h3>
            </div>
            <div class="rfindicator">
                <span>&nbsp;</span>
            </div>
        </div>
        <div class="panel-body" style="padding-bottom: 20px;">
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
            <asp:UpdatePanel runat="server">
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
                                    <div style="width: 100px;" class="grvHeaderrow">
                                        current school
                                    </div>
                                    <div style="width: 55px;" class="grvHeaderrow">
                                        Gender
                                    </div>
                                    <div style="width: 85px;" class="grvHeaderrow">
                                        Date of birth
                                    </div>
                                    <div style="width: 120px;" class="grvHeaderrow">
                                        Applied to (Grade)
                                    </div>
                                    <div style="width: 145px; display: none;" class="grvHeaderrow">
                                        Communication Email
                                    </div>
                                    <div style="width: 130px; display: none;" class="grvHeaderrow">
                                        Communication No
                                    </div>
                                    <div style="width: 60px;" class="grvHeaderrow">
                                        Yes | No
                                    </div>
                                    <div style="width: 140px;" class="grvHeaderrow">
                                        Remarks
                                    </div>
                                    <div style="width: 25px;" class="grvHeaderrowlastchk">
                                        <input id="chkALL" type="checkbox" name="chkALL" onclick="javascript:return CheckALL(this);" />
                                    </div>
                                </div>
                                <div class="rowlist" runat="server">
                                    <asp:PlaceHolder runat="server" ID="itemPlaceHolder1"></asp:PlaceHolder>
                                </div>
                                <div class="pager">
                                    <div class="pgbutton">
                                        <asp:DataPager ID="pglvstudent" runat="server" PageSize="20">
                                            <Fields>
                                                <asp:NumericPagerField ButtonCount="2" NumericButtonCssClass="numeric_button" CurrentPageLabelCssClass="current_page"
                                                    NextPreviousButtonCssClass="next_button" />
                                            </Fields>
                                        </asp:DataPager>
                                    </div>
                                    <div class="pglabel">
                                        <asp:DataPager ID="pglvstudentlabel" runat="server" PageSize="20">
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
                                    <asp:HiddenField ID="hdnFirstname" runat="server" Value='<%# Eval("FirstName") %>' />
                                    <asp:HiddenField ID="hdnLastName" runat="server" Value='<%# Eval("LastName") %>' />
                                    <asp:HiddenField ID="hdnAddressline1" runat="server" Value='<%# Eval("Addressline1") %>' />
                                    <asp:HiddenField ID="hdnCity" runat="server" Value='<%# Eval("City") %>' />
                                    <asp:HiddenField ID="hdnState" runat="server" Value='<%# Eval("State") %>' />
                                    <asp:HiddenField ID="hdnAdmissionGrade" runat="server" Value='<%# Eval("AdmissionGrade") %>' />
                                </div>
                                <div style="width: 125px;" class="grvDatarow">
                                    <%# Eval("ReferenceNumber")%>
                                </div>
                                <div style="width: 145px;" class="grvDatarow">
                                    <%# Eval("Name")%>
                                </div>
                                <div style="width: 100px;" class="grvDatarow">
                                    <%# Eval("LastSchoolAttended")%>
                                </div>
                                <div style="width: 55px;" class="grvDatarow">
                                    <%# Eval("Gender")%>
                                </div>
                                <div style="width: 85px;" class="grvDatarow">
                                    <%# Eval("DateOfBirth")%>
                                </div>
                                <div style="width: 120px" class="grvDatarow">
                                    <%# Eval("AdmissionGrade")%>
                                </div>
                                <div style="width: 145px; display: none;" class="grvDatarow">
                                    <asp:Label ID="communicationemail" Text='<%# Eval("EmailIdForCommunication")%>' runat="server" />
                                </div>
                                <div style="width: 130px; display: none;" class="grvDatarow">
                                    <%# Eval("MobileNumberForCommunication")%>
                                </div>
                                <div style="width: 60px;" class="grvDatarowcenter">
                                    <input type="radio" id="radioadmissionyes" name="radioadmission" runat="server" onclick="javascript:return Setapprovalremarks(this);" />&nbsp;&nbsp;&nbsp;&nbsp;
                                    <input type="radio" id="radioadmissionno" name="radioadmission" runat="server" onclick="javascript:return Setapprovalremarks(this);" />
                                </div>
                                <div style="width: 140px; padding-top: 6px; padding-bottom: 5px; min-height: 21px;"
                                    class="grvDatarow">
                                    <select id="approvalremarksyes" style="display: none;" class="approvalremarks" runat="server">
                                        <option selected="selected" value="">-- select --</option>
                                        <option>Sibling</option>
                                        <option>Todden</option>
                                        <option>Parents Profile is good</option>
                                        <option>Personal Recommendation /Government</option>
                                        <option>Smart child</option>
                                    </select>
                                    <select id="approvalremarksno" style="display: none;" class="approvalremarks" runat="server">
                                        <option selected="selected" value="">-- select --</option>
                                        <option>Parents background</option>
                                        <option>Parents fluency in English</option>
                                        <option>Abnormality in the child</option>
                                        <option>Fees not paid when admission granted</option>
                                        <option>Todden feedback</option>
                                        <option>Undisciplined parents</option>
                                        <option>Three children</option>
                                        <option>AIS not first preference</option>
                                        <option>Sibling in another</option>
                                        <option>Youngest for the batch</option>
                                        <option>Entrance exam not cleared</option>
                                    </select>
                                </div>
                                <div style="width: 25px;" class="grvDatarowlastchk">
                                    <input id="admissionapprovalcheck" runat="server" type="checkbox" name="name" value=""
                                        onclick="javascript:return CheckSingle(this);" />
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
                                    <div style="width: 100px;" class="grvHeaderrow">
                                        current school
                                    </div>
                                    <div style="width: 55px;" class="grvHeaderrow">
                                        Gender
                                    </div>
                                    <div style="width: 85px;" class="grvHeaderrow">
                                        Date of birth
                                    </div>
                                    <div style="width: 120px;" class="grvHeaderrow">
                                        Applied to (Grade)
                                    </div>
                                    <div style="width: 145px; display: none;" class="grvHeaderrow">
                                        Communication Email
                                    </div>
                                    <div style="width: 130px; display: none;" class="grvHeaderrow">
                                        Communication No
                                    </div>
                                    <div style="width: 60px;" class="grvHeaderrow">
                                        Yes | No
                                    </div>
                                    <div style="width: 140px;" class="grvHeaderrow">
                                        Remarks
                                    </div>
                                    <div style="width: 25px;" class="grvHeaderrowlastchk">
                                        <input id="chkALL" type="checkbox" name="chkALL" onclick="javascript:return CheckALL(this);" />
                                    </div>
                                </div>
                                <div class="row" style="text-align: center; text-align: center; height: 20px; padding-top: 5px;
                                    padding-bottom: 5px;">
                                    No Record Available</div>
                            </div>
                        </EmptyDataTemplate>
                    </asp:ListView>
                    <div style="text-align: right; margin-top: -30px; display: inline-block; float: right;">
                        <asp:Button ID="btnapproveadmission" Text="Proceed Admission" runat="server" OnClick="btnapproveadmission_click" />
                    </div>
                    <asp:Button ID="hdnadmissiongradefilter" Text="text" runat="server" OnClick="hdnadmissiongradefilter_Click"
                        Style="display: none;" />
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
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnapproveadmission" />
                </Triggers>
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
        function CloseMessage() { document.getElementById("<%= mainpopup.ClientID %>").className = "overlay"; return false; }
        function CheckALL(obj) { var rowlist = document.getElementsByTagName("INPUT"); for (var index = 0; index < rowlist.length; index++) { var control = rowlist[index]; if (control.id != undefined && control.id != null && control.id.length > 0) { if (control.id.endsWith("admissionapprovalcheck")) { control.checked = obj.checked; } } } }
        function CheckSingle(obj) { var AllChecked = true; var rowlist = document.getElementsByTagName("INPUT"); for (var index = 0; index < rowlist.length; index++) { var control = rowlist[index]; if (control.id != undefined && control.id != null && control.id.length > 0) { if (control.id.endsWith("admissionapprovalcheck")) { if (!control.checked) { AllChecked = false; break; } } } } document.getElementById('chkALL').checked = AllChecked; }
        function Setapprovalremarks(obj) {

            if (obj.id.indexOf('radioadmissionyes') >= 0) {
                var selectyesid = obj.id.replace('radioadmissionyes', 'approvalremarksyes');
                var selectnoid = obj.id.replace('radioadmissionyes', 'approvalremarksno');

                document.getElementById(selectyesid).required = true;
                document.getElementById(selectyesid).style.display = '';
                document.getElementById(selectnoid).required = false;
                document.getElementById(selectnoid).style.display = 'none';

            } else if (obj.id.indexOf('radioadmissionno') >= 0) {
                var selectyesid = obj.id.replace('radioadmissionno', 'approvalremarksyes');
                var selectnoid = obj.id.replace('radioadmissionno', 'approvalremarksno');

                document.getElementById(selectyesid).required = false;
                document.getElementById(selectyesid).style.display = 'none';
                document.getElementById(selectnoid).required = true;
                document.getElementById(selectnoid).style.display = '';
            }
        }
        function redirectpage(page) { var win = window.open(page, '_self'); }
    </script>
</body>
</html>
