<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InteractionList.aspx.cs"
    Inherits="Admission_InteractionList" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <title>Interaction List</title>
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
                    Interaction List
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
                                    <div style="width: 155px;" class="grvHeaderrow">
                                        Name of the applicant
                                    </div>
                                    <div style="width: 110px;" class="grvHeaderrow">
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
                                    <div style="width: 100px;" class="grvHeaderrow">
                                        <asp:TextBox ID="lbldate" runat="server" Style="width: 95%; padding-left: 0px; font-size: 1em;
                                            height: 16px; color: #fff; background-color: #5bc0de; font-weight: bold; border: 1px solid #5bc0de;
                                            cursor: pointer;" Text="Date" ReadOnly="true" />
                                        <cc1:CalendarExtender ID="CalExtDateOfBirth" runat="server" TargetControlID="lbldate"
                                            PopupButtonID="lbldate" Enabled="True" Format="dd-MMM-yyyy" OnClientDateSelectionChanged="dateSelectionChanged"
                                            CssClass="cal_Theme1">
                                        </cc1:CalendarExtender>
                                    </div>
                                    <div style="width: 70px;" class="grvHeaderrow">
                                        <input type="text" id="txtstarttime" style="width: 95%; padding-left: 0px; font-size: 1em;
                                            height: 16px; color: #fff; background-color: #5bc0de; font-weight: bold; border: 1px solid #5bc0de;
                                            cursor: pointer;" placeholder="" value="09:00 AM" onblur="javascript:return validatetime();" />
                                    </div>
                                    <div style="width: 25px;" class="grvHeaderrowlastchk">
                                        <input id="chkALL" type="checkbox" name="chkALL" onclick="javascript:return CheckALL(this);" />
                                    </div>
                                </div>
                                <div class="rowlist">
                                    <asp:PlaceHolder runat="server" ID="itemPlaceHolder1"></asp:PlaceHolder>
                                </div>
                                <div class="pager">
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
                                <div style="width: 155px;" class="grvDatarow">
                                    <%# Eval("Name")%>
                                </div>
                                <div style="width: 110px;" class="grvDatarow">
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
                                <div style="width: 100px;" class="grvDatarow">
                                    <asp:TextBox ID="interactiondate" runat="server" Style="width: 83%; padding-left: 7px;
                                        font-size: 0.89em; height: 16px; color: Gray; font-weight: bold; border: 1px solid #7bcce4;"
                                        pattern="^(([0-9])|([0-2][0-9])|([3][0-1]))\-(Jan|jan|Feb|feb|Mar|mar|Apr|apr|May|may|Jun|jun|Jul|jul|Aug|aug|Sep|sep|Oct|oct|Nov|nov|Dec|dec)\-\d{4}$" />
                                </div>
                                <div style="width: 70px;" class="grvDatarow">
                                    <asp:TextBox ID="interactiontime" runat="server" Style="width: 80%; padding-left: 3px;
                                        font-size: 0.89em; height: 16px; color: Gray; font-weight: bold; border: 1px solid #7bcce4;"
                                        pattern="^\d{2}\:\d{2} (AM|PM)$" />
                                </div>
                                <div style="width: 25px;" class="grvDatarowlastchk">
                                    <input id="interactioncheck" runat="server" type="checkbox" name="name" value=""
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
                                    <div style="width: 110px;" class="grvHeaderrow">
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
                                    <div style="width: 90px;" class="grvHeaderrow">
                                        Date
                                    </div>
                                    <div style="width: 70px;" class="grvHeaderrow">
                                        Time
                                    </div>
                                    <div style="width: 25px;" class="grvHeaderrowlastchk">
                                        <input id="chkALLEmpty" type="checkbox" name="chkALLEmpty" />
                                    </div>
                                </div>
                                <div class="row" style="text-align: center; text-align: center; height: 20px; padding-top: 5px;
                                    padding-bottom: 5px;">
                                    No Record Available</div>
                            </div>
                        </EmptyDataTemplate>
                    </asp:ListView>
                    <div style="text-align: right; margin-top: -30px; display: inline-block; float: right;">
                        <asp:Button ID="btnSendInteraction" Text="Send Interaction" runat="server" OnClick="btnSendInteraction_click" />
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
                    <asp:AsyncPostBackTrigger ControlID="btnSendInteraction" />
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
        function ShowProcessBar() {
            if (document.getElementById("<%= btnLoader.ClientID%>") != null) {
                document.getElementById("<%= btnLoader.ClientID%>").click();
            }
            return true;
        }
        var monthNames = ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"];
        function dateSelectionChanged(sender, args) {
            var time = document.getElementById('txtstarttime').value;
            if (time != '') {
                var hours = Number(time.match(/^(\d+)/)[1]); var minutes = Number(time.match(/:(\d+)/)[1]); var AMPM = time.match(/\s(.*)$/)[1]; if (AMPM == "PM" && hours < 12) hours = hours + 12; if (AMPM == "AM" && hours == 12) hours = hours - 12; var sHours = hours.toString(); var sMinutes = minutes.toString(); if (hours < 10) sHours = "0" + sHours; if (minutes < 10) sMinutes = "0" + sMinutes;
                var date = new Date(sender.get_selectedDate().getFullYear(), sender.get_selectedDate().getMonth(), sender.get_selectedDate().getDate(), sHours, sMinutes - 10, 00, 0); var offset = 0;
                var rowlist = document.getElementsByTagName("INPUT");
                for (var index = 0; index < rowlist.length; index++) {
                    var control = rowlist[index];
                    if (control.id != undefined && control.id != null && control.id.length > 0) {
                        var minutes; var seconds; var HH; var MM; var ampm;
                        if (control.id.endsWith("interactiondate")) {
                            minutes = date.getMinutes(); seconds = date.getSeconds();
                            if (offset == 0) { date.setMinutes(minutes + 10, seconds, 0); offset++; } else if (offset == 1) { offset = 0; }
                            HH = date.getHours();
                            if (HH > 12) { date.setDate(date.getDate() + 1); date.setMinutes(minutes - 290, seconds, 0); }
                            control.value = pad(date.getDate(), 2) + '-' + monthNames[(date.getMonth())] + '-' + date.getFullYear();
                        }
                        if (control.id.endsWith("interactiontime")) { HH = date.getHours(); MM = date.getMinutes(); ampm = HH >= 12 ? 'PM' : 'AM'; HH = HH % 12; HH = HH ? HH : 12; HH < 10 ? HH = '0' + HH : null; MM < 10 ? MM = '0' + MM : null; control.value = HH + ':' + MM + " " + ampm; }
                    }
                }
            }
            else {
                alert('Please enter time first.');
            }
        }
        function pad(num, size) { var s = num + ""; if (s.length < size) { s = "0" + s; } return s; }
        function CheckALL(obj) { var rowlist = document.getElementsByTagName("INPUT"); for (var index = 0; index < rowlist.length; index++) { var control = rowlist[index]; if (control.id != undefined && control.id != null && control.id.length > 0) { if (control.id.endsWith("interactioncheck")) { control.checked = obj.checked; } } } }
        function CheckSingle(obj) { var AllChecked = true; var rowlist = document.getElementsByTagName("INPUT"); for (var index = 0; index < rowlist.length; index++) { var control = rowlist[index]; if (control.id != undefined && control.id != null && control.id.length > 0) { if (control.id.endsWith("interactioncheck")) { if (!control.checked) { AllChecked = false; break; } } } } document.getElementById('chkALL').checked = AllChecked; }
        function ChoiceAdmissionGrade() { __doPostBack('<%= hdnadmissiongradefilter.UniqueID %>', '') }
        function CloseMessage() { document.getElementById("<%= mainpopup.ClientID %>").className = "overlay"; return false; }
        function validatetime() { var time = document.getElementById('txtstarttime').value; if (time != '') { var hours = Number(time.match(/^(\d+)/)[1]); var minutes = Number(time.match(/:(\d+)/)[1]); var AMPM = time.match(/\s(.*)$/)[1]; if (AMPM == "PM" && hours < 12) hours = hours + 12; if (AMPM == "AM" && hours == 12) hours = hours - 12; var sHours = hours.toString(); var sMinutes = minutes.toString(); if (hours < 10) sHours = "0" + sHours; if (minutes < 10) sMinutes = "0" + sMinutes; if (sHours >= 13) { alert('Selected time should be less than 01:00 PM'); document.getElementById('txtstarttime').value = "09:00 AM"; } } else { alert('You cannot leave time empty.'); document.getElementById('txtstarttime').value = "09:00 AM"; } }
        function redirectpage(page) { var win = window.open(page, '_self'); }
    </script>
</body>
</html>
