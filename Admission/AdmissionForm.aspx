<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdmissionForm.aspx.cs" Inherits="Admission_AdmissionForm"
    EnableViewStateMac="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <meta charset="UTF-8">
    <title>AIS Admission Form</title>
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
<body>
    <form id="aisadmission" runat="server" autocomplete="off">
    <asp:ScriptManager runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
    <img src="AIS_Banner.png" alt="AIS Logo" style="height: 140px; width: 1024px; margin-bottom: -5px;" />
    <%--Document submission message start--%>
    <div class="panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title" style="text-align: center;">
                Admission Application Form 2016-2017
            </h3>
        </div>
        <div class="panel-body">
            <fieldset>
                <legend></legend>
                <ol>
                    <li>
                        <table width="100%">
                            <tr>
                                <td>
                                    <ul style="padding-left: 20px;">
                                        <li style="list-style-type: none; color: Black; font-size: 14px; margin-left: -10px;">
                                            <b>Documents to be submitted to the office along with the copy of printed admission
                                                form</b></li>
                                        <li style="list-style-type: circle; padding-top: 15px;">An attested copy of the child's
                                            birth certificate to be attached with the original form at the time of submission.
                                            A copy of student's passport information page to be attached for non- resident Indian.</li>
                                        <li style="list-style-type: circle; padding-top: 15px;">A recent passport sized photograph
                                            to be attached in the box provided on the admission form.</li>
                                        <li style="list-style-type: circle; padding-top: 15px;">An official copy of the student's
                                            scholastic record to be attached for admissions to Grade 1 and above.</li>
                                        <li style="list-style-type: circle; padding-top: 15px;">Parents’ testimonials to be
                                            attached with the original form.</li>
                                        <li style="list-style-type: circle; padding-top: 15px; padding-bottom: 15px;">Recommendation
                                            letter from the previous school for overseas students and a bonafide certificate
                                            for students applying locally.</li>
                                    </ul>
                                </td>
                            </tr>
                        </table>
                    </li>
                </ol>
            </fieldset>
        </div>
    </div>
    <%--Admission criteria start--%>
    <div class="panel panel-default">
        <div class="panel-heading">
            <div style="float: left;">
                <h3 class="panel-title">
                    Admission Criteria
                </h3>
            </div>
            <div class="rfindicator">
                <span>* Indicates required field </span>
            </div>
        </div>
        <div class="panel-body">
            <fieldset>
                <legend></legend>
                <ol>
                    <li>
                        <table width="100%">
                            <tr>
                                <td class="trlable">
                                    <span>Admission Grade * </span>
                                </td>
                                <td class="trcontrol">
                                    <select name="AdmissionGrade" id="AdmissionGrade" runat="server" onchange="javascript:return ChoiceAdmissionGrade(this);"
                                        required>
                                        <option selected="selected" value="">-- select --</option>
                                        <option>Nursery</option>
                                        <option>Jr KG</option>
                                        <option>Sr KG</option>
                                        <option>1</option>
                                        <option>2</option>
                                        <option>3</option>
                                        <option>4</option>
                                        <option>5</option>
                                        <option>6</option>
                                        <option>7</option>
                                        <option>8</option>
                                        <option>9</option>
                                        <option>10</option>
                                        <option>11</option>
                                    </select>
                                    <img id="admissiongradeloading" src="../Images/smallloader.gif" alt="Loading..."
                                        width="20px" style="display: none;" />
                                    <asp:Label ID="waitlistform" runat="server" Text="" />
                                    <asp:HiddenField ID="hdnwaitlistform" runat="server" Value="" />
                                </td>
                            </tr>
                            <tr id="trNursery" style="display: none;">
                                <td class='trlable'>
                                    <span></span>
                                </td>
                                <td class='trcontrol'>
                                    <div class='dvmultioption'>
                                        <div class='selectcontrol'>
                                            <input id='radioboardNursery_1' name='radioboardNursery' runat='server' value="TODDEN Applicant"
                                                onclick="javascript:return changeNurseryApplicant(this.value);" type='radio'
                                                required /></div>
                                        <div class='selectlable'>
                                            <span>TODDEN Applicant</span>
                                        </div>
                                    </div>
                                    <div class='dvmultioption'>
                                        <div class='selectcontrol'>
                                            <input id='radioboardNursery_2' name='radioboardNursery' runat='server' value="Sibling Applicant"
                                                onclick="javascript:return changeNurseryApplicant(this.value);" type='radio'
                                                required /></div>
                                        <div class='selectlable'>
                                            <span>Sibling Applicant</span>
                                        </div>
                                    </div>
                                </td>
                            </tr>
                            <tr id="trNurserytodden" style="display: none;">
                                <td class='trlable'>
                                    <span>Access Code * </span>
                                </td>
                                <td class='trcontrol'>
                                    <input type="text" id="accesscode" name="accesscode" runat="server" placeholder=""
                                        onblur="javascript:return validateacesscode(this.value);" required />
                                    <img id="imgaccesscode" src="../Images/smallloader.gif" alt="Loading..." width="20px"
                                        style="display: none;" />
                                </td>
                            </tr>
                            <tr id="tr8" style="display: none;">
                                <td class='trlable'>
                                    <span>Choice of Board * </span>
                                </td>
                                <td class='trcontrol'>
                                    <div class='dvmultioption'>
                                        <div class='selectcontrol'>
                                            <input id='radioboard8_1' name='radioboard8' runat='server' value="S.S.C - Gujarat State Education Board (GSEB)"
                                                type='radio' required /></div>
                                        <div class='selectlable'>
                                            <span>S.S.C - Gujarat State Education Board (GSEB) </span>
                                        </div>
                                    </div>
                                    <div class='dvmultioption'>
                                        <div class='selectcontrol'>
                                            <input id='radioboard8_2' name='radioboard8' runat='server' value="IGCSE - Cambridge International Examination (CIE) UK"
                                                type='radio' required /></div>
                                        <div class='selectlable'>
                                            <span>IGCSE - Cambridge International Examination (CIE) UK </span>
                                        </div>
                                    </div>
                                </td>
                            </tr>
                            <tr id="tr9" style="display: none;">
                                <td class='trlable'>
                                    <span>Choice of Board *</span>
                                </td>
                                <td class='trcontrol'>
                                    <div class='dvmultioption'>
                                        <div class='selectcontrol'>
                                            <input id='radioboard9_1' name='radioboard9' runat='server' type='radio' value="Gujarat State Education Board (GSEB)"
                                                checked='true' required /></div>
                                        <div class='selectlable'>
                                            <span>Gujarat State Education Board (GSEB) </span>
                                        </div>
                                    </div>
                                </td>
                            </tr>
                            <tr id="tr11" style="display: none;">
                                <td class='trlable'>
                                    <span>Choice of Board *</span>
                                </td>
                                <td class='trcontrol'>
                                    <div class='dvmultioption'>
                                        <div class='selectcontrol'>
                                            <input id='radioboard11_1' name='radioboard11' runat='server' value="CIE" type='radio'
                                                required /></div>
                                        <div class='selectlable'>
                                            <span>CIE </span>
                                        </div>
                                    </div>
                                    <div class='dvmultioption'>
                                        <div class='selectcontrol'>
                                            <input id='radioboard11_2' name='radioboard11' runat='server' value="IBDB" type='radio'
                                                required /></div>
                                        <div class='selectlable'>
                                            <span>IBDB</span></div>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </li>
                </ol>
            </fieldset>
        </div>
    </div>
    <%--Sibling Details start--%>
    <div class="panel panel-default">
        <div class="panel-heading">
            <div style="float: left;">
                <h3 class="panel-title">
                    Sibling Details
                </h3>
            </div>
            <div class="rfindicator">
                <span>* Indicates required field </span>
            </div>
        </div>
        <div class="panel-body">
            <fieldset>
                <legend></legend>
                <ol>
                    <li>
                        <table width="100%">
                            <tr>
                                <td class="trlable">
                                    Applicable / Not applicable *
                                </td>
                                <td class="trcontrol">
                                    <div class="dvmultioption">
                                        <div class="selectcontrol">
                                            <input id='radiosibling_Applicable' name='radiosibling' runat='server' type='radio'
                                                checked="true" onclick="javascript:return changeSibling(this.value);" required /></div>
                                        <div class="selectlable">
                                            <span>Applicable </span>
                                        </div>
                                    </div>
                                    <div class="dvmultioption">
                                        <div class="selectcontrol">
                                            <input id='radiosibling_NotApplicable' name='radiosibling' runat='server' type='radio'
                                                onclick="javascript:return changeSibling(this.value);" required /></div>
                                        <div class="selectlable">
                                            <span>Not Applicable</span></div>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <table width="100%" id="tablesiblings">
                                    <tr>
                                        <td class="trlable">
                                            Sibling-1 *
                                        </td>
                                        <td class="trcontrol">
                                            <input type="text" id="siblingname" name="siblingname" runat="server" placeholder="Name"
                                                required />
                                            <asp:TextBox ID="siblingage" runat="server" placeholder="Date of Birth" pattern="^(([0-9])|([0-2][0-9])|([3][0-1]))\-(Jan|jan|Feb|feb|Mar|mar|Apr|apr|May|may|Jun|jun|Jul|jul|Aug|aug|Sep|sep|Oct|oct|Nov|nov|Dec|dec)\-\d{4}$"></asp:TextBox>
                                            <cc1:CalendarExtender ID="calsiblingage" runat="server" TargetControlID="siblingage"
                                                PopupButtonID="siblingage" Enabled="True" Format="dd-MMM-yyyy" CssClass="cal_Theme1">
                                            </cc1:CalendarExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="trlable">
                                        </td>
                                        <td class="trcontrol">
                                            <select name="siblingschoolcollege" id="siblingschoolcollege" runat="server" onchange="javascript:return Changesiblingschoolcollege(this.value);"
                                                required>
                                                <option selected="selected" value="">-- school --</option>
                                                <option>AIS</option>
                                                <option>Other</option>
                                            </select>
                                            <select name="siblingschoolcollegegrade" id="siblingschoolcollegegrade" runat="server"
                                                placeholder="Grade" style="display: none;" required>
                                                <option selected="selected" value="">-- grade --</option>
                                                <option>Nursery</option>
                                                <option>Jr KG</option>
                                                <option>Sr KG</option>
                                                <option>1</option>
                                                <option>2</option>
                                                <option>3</option>
                                                <option>4</option>
                                                <option>5</option>
                                                <option>6</option>
                                                <option>7</option>
                                                <option>8</option>
                                                <option>9</option>
                                                <option>10</option>
                                                <option>11</option>
                                            </select>
                                            <select name="siblingschoolcollegedivision" id="siblingschoolcollegedivision" runat="server"
                                                placeholder="Grade" style="display: none;" required>
                                                <option selected="selected" value="">-- division --</option>
                                                <option>A</option>
                                                <option>B</option>
                                                <option>C</option>
                                                <option>D</option>
                                            </select>
                                            <input type="text" id="Othersiblingschoolcollegegrade" name="Othersiblingschoolcollegegrade"
                                                runat="server" placeholder="Grade" value="" style="display: none;" required />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="trlable">
                                            Sibling-2
                                        </td>
                                        <td class="trcontrol">
                                            <input type="text" id="siblingnamesecond" name="siblingnamesecond" runat="server"
                                                placeholder="Name" />
                                            <asp:TextBox ID="siblingagesecond" runat="server" placeholder="Date of Birth" pattern="^(([0-9])|([0-2][0-9])|([3][0-1]))\-(Jan|jan|Feb|feb|Mar|mar|Apr|apr|May|may|Jun|jun|Jul|jul|Aug|aug|Sep|sep|Oct|oct|Nov|nov|Dec|dec)\-\d{4}$"></asp:TextBox>
                                            <cc1:CalendarExtender ID="Calsiblingagesecond" runat="server" TargetControlID="siblingagesecond"
                                                PopupButtonID="siblingagesecond" Enabled="True" Format="dd-MMM-yyyy" CssClass="cal_Theme1">
                                            </cc1:CalendarExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="trlable">
                                        </td>
                                        <td class="trcontrol">
                                            <select name="siblingschoolcollegesecond" id="siblingschoolcollegesecond" runat="server"
                                                onchange="javascript:return Changesiblingschoolcollegesecond(this.value);">
                                                <option selected="selected" value="">-- school --</option>
                                                <option>AIS</option>
                                                <option>Other</option>
                                            </select>
                                            <select name="siblingschoolcollegegradesecond" id="siblingschoolcollegegradesecond"
                                                runat="server" style="display: none;">
                                                <option selected="selected" value="">-- grade --</option>
                                                <option>Nursery</option>
                                                <option>Jr KG</option>
                                                <option>Sr KG</option>
                                                <option>1</option>
                                                <option>2</option>
                                                <option>3</option>
                                                <option>4</option>
                                                <option>5</option>
                                                <option>6</option>
                                                <option>7</option>
                                                <option>8</option>
                                                <option>9</option>
                                                <option>10</option>
                                                <option>11</option>
                                            </select>
                                            <select name="siblingschoolcollegedivisionsecond" id="siblingschoolcollegedivisionsecond"
                                                runat="server" placeholder="Grade" style="display: none;">
                                                <option selected="selected" value="">-- division --</option>
                                                <option>A</option>
                                                <option>B</option>
                                                <option>C</option>
                                                <option>D</option>
                                            </select>
                                            <input type="text" id="Othersiblingschoolcollegegradesecond" name="Othersiblingschoolcollegegradesecond"
                                                runat="server" placeholder="Grade" value="" style="display: none;" />
                                        </td>
                                    </tr>
                                </table>
                            </tr>
                        </table>
                    </li>
                </ol>
            </fieldset>
        </div>
    </div>
    <%--Personal Information start--%>
    <div class="panel panel-default">
        <div class="panel-heading">
            <div style="float: left;">
                <h3 class="panel-title">
                    Personal Information
                </h3>
            </div>
            <div class="rfindicator">
                <span>* Indicates required field </span>
            </div>
        </div>
        <div class="panel-body">
            <fieldset>
                <legend></legend>
                <ol>
                    <li>
                        <table width="100%">
                            <tr>
                                <td class="trlable">
                                    <span>Name of the Applicant * </span>
                                </td>
                                <td class="trcontrol">
                                    <input type="text" id="FirstName" name="FirstName" runat="server" placeholder="First"
                                        style="width: 120px;" required />
                                    <input type="text" id="MiddleName" name="MiddleName" runat="server" placeholder="Middle"
                                        style="width: 120px;" required />
                                    <input type="text" id="LastName" name="LastName" runat="server" placeholder="Last"
                                        style="width: 120px;" required />
                                </td>
                            </tr>
                            <tr>
                                <td class="trlable">
                                    Gender *
                                </td>
                                <td class="trcontrol">
                                    <div class="dvmultioption">
                                        <div class="selectcontrol">
                                            <input id='Gender_1' name='Gender' runat='server' type='radio' required /></div>
                                        <div class="selectlable">
                                            <span>Male </span>
                                        </div>
                                    </div>
                                    <div class="dvmultioption">
                                        <div class="selectcontrol">
                                            <input id='Gender_2' name='Gender' runat='server' type='radio' required />
                                        </div>
                                        <div class="selectlable">
                                            <span>Female</span></div>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td class="trlable">
                                    <span>Date of Birth * </span>
                                </td>
                                <td class="trcontrol">
                                    <asp:TextBox ID="DateOfBirth" runat="server" placeholder="dd-MMM-yyyy" pattern="^(([0-9])|([0-2][0-9])|([3][0-1]))\-(Jan|jan|Feb|feb|Mar|mar|Apr|apr|May|may|Jun|jun|Jul|jul|Aug|aug|Sep|sep|Oct|oct|Nov|nov|Dec|dec)\-\d{4}$"
                                        onkeypress="return NotAllow(this,event);" required></asp:TextBox>
                                    <cc1:CalendarExtender ID="CalExtDateOfBirth" runat="server" TargetControlID="DateOfBirth"
                                        PopupButtonID="DateOfBirth" Enabled="True" Format="dd-MMM-yyyy" OnClientDateSelectionChanged="dateSelectionChanged"
                                        CssClass="cal_Theme1">
                                    </cc1:CalendarExtender>
                                    <input type="text" name="PlaceOfBirth" id="PlaceOfBirth" runat="server" placeholder="Place of birth*"
                                        value="" required />
                                </td>
                            </tr>
                            <tr>
                                <td class="trlable">
                                    <span>Address * </span>
                                </td>
                                <td class="trcontrol">
                                    <input type="text" id="Addressline1" name="Addressline1" placeholder="Address Line 1*"
                                        runat="server" required />
                                </td>
                            </tr>
                            <tr>
                                <td class="trlable">
                                    <span></span>
                                </td>
                                <td class="trcontrol">
                                    <input type="text" id="Addressline2" name="Addressline2" runat="server" placeholder="Address Line 2" />
                                </td>
                            </tr>
                            <tr>
                                <td class="trlable">
                                    <span></span>
                                </td>
                                <td class="trcontrol">
                                    <input type="text" name="City" id="City" runat="server" style="width: 120px;" placeholder="City*"
                                        value="" required />
                                    <input type="text" name="State" id="State" runat="server" style="width: 120px;" placeholder="State*"
                                        value="" required />
                                    <input type="text" name="Country" id="Country" runat="server" style="width: 120px;"
                                        placeholder="Country*" value="" required />
                                </td>
                            </tr>
                            <tr>
                                <td class="trlable">
                                    <span></span>
                                </td>
                                <td class="trcontrol">
                                    <input type="text" id="Pincode" name="Pincode" runat="server" maxlength="6" placeholder="Pin code*"
                                        required />
                                </td>
                            </tr>
                            <tr>
                                <td class="trlable">
                                    <span>Telephone Number * </span>
                                </td>
                                <td class="trcontrol">
                                    <input id="stdcode" name="stdcode" runat="server" maxlength="3" pattern="\d{2,3}"
                                        onkeypress="return isNumber(this,event);" placeholder="stdcode" style="width: 50px;" />
                                    <input id="TelephoneNo" name="TelephoneNo" runat="server" maxlength="10" pattern="\d{6,10}"
                                        onkeypress="return isNumber(this,event);" style="width: 110px;" />
                                    <%--<p class="validation01">
                                        <span class="invalid">stdcode-number e.g. 079-99999999</span> <span class="valid">Your
                                            mobile number is valid</span>
                                    </p>--%>
                                </td>
                            </tr>
                            <tr>
                                <td class="trlable">
                                    <span>Emergency Mobile Number * </span>
                                </td>
                                <td class="trcontrol">
                                    <input id="EmergencyMobileNo" name="EmergencyMobileNo" runat="server" onkeypress="return isNumber(this,event);"
                                        maxlength="10" pattern="\d{10}" placeholder="" required />
                                    <p class="validation01">
                                        <span class="invalid">No spaces or brackets e.g. 9999999999</span> <span class="valid">
                                            Your mobile number is valid</span>
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td class="trlable">
                                    <span>Nationality * </span>
                                </td>
                                <td class="trcontrol">
                                    <select name="Nationality" id="Nationality" runat="server" onchange="javascript:return ChoiceNationality(this);">
                                        <option selected="selected">Indian</option>
                                        <option>Other</option>
                                    </select>
                                    <div id="dvnationality" style="display: none;">
                                        <input type="text" id="OtherNationality" runat="server" value="Indian" name="OtherNationality"
                                            placeholder="Nationality" style="width: 100px;" />
                                        <input type="text" id="PassportNumber" name="PassportNumber" runat="server" value=""
                                            placeholder="Passport Number" style="width: 100px;" />
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td class="trlable">
                                    <span>Caste * </span>
                                </td>
                                <td class="trcontrol">
                                    <input type="text" id="Caste" name="Caste" runat="server" placeholder="" required />
                                </td>
                            </tr>
                            <tr>
                                <td class="trlable">
                                    <span>Last School Attended * </span>
                                </td>
                                <td class="trcontrol">
                                    <select name="LastSchoolAttended" id="LastSchoolAttended" runat="server" onchange="javascript:return ChoiceLastSchoolAttended(this);">
                                        <option selected="selected">TODDEN</option>
                                        <option>Other</option>
                                    </select>
                                    <div id="dvlastschoolattended" style="display: none;">
                                        <input type="text" id="OtherLastSchoolAttended" name="OtherLastSchoolAttended" runat="server"
                                            value="TODDEN" placeholder="Last School Attended" required />
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </li>
                </ol>
            </fieldset>
        </div>
    </div>
    <%--Family Information: Father's Details start--%>
    <div class="panel panel-default">
        <div class="panel-heading">
            <div style="float: left;">
                <h3 class="panel-title">
                    Family Information: Father's Details
                </h3>
            </div>
            <div class="rfindicator">
                <span>* Indicates required field </span>
            </div>
        </div>
        <div class="panel-body">
            <fieldset>
                <legend></legend>
                <ol>
                    <li>
                        <table width="100%">
                            <tr>
                                <td class="trlable">
                                    <span>Father's Name * </span>
                                </td>
                                <td class="trcontrol">
                                    <input type="text" id="FatherName" runat="server" value="" name="FatherName" placeholder=""
                                        required />
                                </td>
                            </tr>
                            <tr>
                                <td class="trlable">
                                    <span>Education Qualification </span>
                                </td>
                                <td class="trcontrol">
                                    <input type="text" id="Fathergraduationdegree" runat="server" name="Fathergraduationdegree"
                                        placeholder="Graduation Degree" />
                                    <input type="text" id="FatherPostGraduationDegree" runat="server" name="FatherPostGraduationDegree"
                                        placeholder="Post-Graduation Degree" />
                                </td>
                            </tr>
                            <tr>
                                <td class="trlable">
                                    <span>Occupation * </span>
                                </td>
                                <td class="trcontrol">
                                    <select name="FatherOccupation" id="FatherOccupation" runat="server" required>
                                        <option selected="selected" value="">-- select --</option>
                                        <option>Business</option>
                                        <option>Doctor</option>
                                        <option>Engineer</option>
                                        <option>Hospitality</option>
                                        <option>Service</option>
                                        <option>Other</option>
                                    </select>
                                </td>
                            </tr>
                            <tr>
                                <td class="trlable">
                                    <span>Office Address * </span>
                                </td>
                                <td class="trcontrol">
                                    <input type="text" id="FatherOfficeAddress" name="FatherOfficeAddress" runat="server"
                                        placeholder="" required />
                                </td>
                            </tr>
                            <tr>
                                <td class="trlable">
                                    <span>Mobile Number * </span>
                                </td>
                                <td class="trcontrol">
                                    <input id="FatherMobileNumber" name="FatherMobileNumber" runat="server" pattern="\d{10}"
                                        onkeypress="return isNumber(this,event);" maxlength="10" placeholder="" required />
                                    <p class="validation01">
                                        <span class="invalid">No spaces or brackets e.g. 9999999999</span> <span class="valid">
                                            Your mobile number is valid</span>
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td class="trlable">
                                    <span>Email id *</span>
                                </td>
                                <td class="trcontrol">
                                    <input type="text" id="FatherEmailId" name="FatherEmailId" runat="server" placeholder=""
                                        pattern="[a-z0-9_.-]+\@[0-9a-z-]+\.[a-z.]{2,6}" required />
                                    <p class="validation01">
                                        <span class="invalid">Please enter a valid email address e.g. yourid@example.com</span>
                                        <span class="valid">Your email address is now valid</span>
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td class="trlable">
                                    <span>Name of the School attended </span>
                                </td>
                                <td class="trcontrol">
                                    <input type="text" id="FatherSchoolAttended" runat="server" name="FatherSchoolAttended"
                                        placeholder="" />
                                </td>
                            </tr>
                            <tr>
                                <td class="trlable">
                                    <span>Name of the college attended</span>
                                </td>
                                <td class="trcontrol">
                                    <input type="text" id="FatherCollegeAttended" runat="server" name="FatherCollegeAttended"
                                        placeholder="" />
                                </td>
                            </tr>
                        </table>
                    </li>
                </ol>
            </fieldset>
        </div>
    </div>
    <%--Family Information: Mother's Details start--%>
    <div class="panel panel-default">
        <div class="panel-heading">
            <div style="float: left;">
                <h3 class="panel-title">
                    Family Information: Mother's Details
                </h3>
            </div>
            <div class="rfindicator">
                <span>* Indicates required field </span>
            </div>
        </div>
        <div class="panel-body">
            <fieldset>
                <legend></legend>
                <ol>
                    <li>
                        <table width="100%">
                            <tr>
                                <td class="trlable">
                                    <span>Mother's Name * </span>
                                </td>
                                <td class="trcontrol">
                                    <input type="text" id="MotherName" runat="server" name="MotherName" placeholder=""
                                        required />
                                </td>
                            </tr>
                            <tr>
                                <td class="trlable">
                                    <span>Education Qualification </span>
                                </td>
                                <td class="trcontrol">
                                    <input type="text" id="MotherGraduationDegree" runat="server" name="MotherGraduationDegree"
                                        placeholder="Graduation Degree" />
                                    <input type="text" id="MotherPostGraduationDegree" runat="server" name="MotherPostGraduationDegree"
                                        placeholder="Post-Graduation Degree" />
                                </td>
                            </tr>
                            <tr>
                                <td class="trlable">
                                    <span>Occupation * </span>
                                </td>
                                <td class="trcontrol">
                                    <select name="MotherOccupation" id="MotherOccupation" runat="server" onchange="javascript:return ChoiceMotherOccupation(this);"
                                        required>
                                        <option selected="selected" value="">-- select --</option>
                                        <option>Homemaker</option>
                                        <option>Business</option>
                                        <option>Doctor</option>
                                        <option>Engineer</option>
                                        <option>Hospitality</option>
                                        <option>Service</option>
                                        <option>Other</option>
                                    </select>
                                </td>
                            </tr>
                            <tr id="trMotherOfficeAddress">
                                <td class="trlable">
                                    <span>Office Address</span>
                                </td>
                                <td class="trcontrol">
                                    <input type="text" id="MotherOfficeAddress" name="MotherOfficeAddress" runat="server"
                                        placeholder="" />
                                </td>
                            </tr>
                            <tr>
                                <td class="trlable">
                                    <span>Mobile Number * </span>
                                </td>
                                <td class="trcontrol">
                                    <input id="MotherMobileNumber" name="MotherMobileNumber" runat="server" pattern="\d{10}"
                                        onkeypress="return isNumber(this,event);" maxlength="10" placeholder="" required />
                                    <p class="validation01">
                                        <span class="invalid">No spaces or brackets e.g. 9999999999</span> <span class="valid">
                                            Your mobile number is valid</span>
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td class="trlable">
                                    <span>Residence/Landline Number * </span>
                                </td>
                                <td class="trcontrol">
                                    <input id="rorlstdcode" name="rorlstdcode" runat="server" maxlength="3" pattern="\d{2,3}"
                                        onkeypress="return isNumber(this,event);" placeholder="stdcode" style="width: 50px;"
                                        required />
                                    <input id="ResidenceOrLandlineNumber" name="ResidenceOrLandlineNumber" runat="server"
                                        maxlength="10" pattern="\d{6,10}" onkeypress="return isNumber(this,event);" style="width: 110px;"
                                        required />
                                    <p class="validation01">
                                        <span class="invalid">stdcode-number e.g. 079-99999999</span> <span class="valid">Your
                                            mobile number is valid</span>
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td class="trlable">
                                    <span>Email id *</span>
                                </td>
                                <td class="trcontrol">
                                    <input type="text" id="MotherEmailId" name="MotherEmailId" runat="server" placeholder=""
                                        pattern="[a-z0-9_.-]+\@[0-9a-z-]+\.[a-z.]{2,6}" required />
                                    <p class="validation01">
                                        <span class="invalid">Please enter a valid email address e.g. yourid@example.com</span>
                                        <span class="valid">Your email address is now valid</span>
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td class="trlable">
                                    <span>Name of the School attended </span>
                                </td>
                                <td class="trcontrol">
                                    <input type="text" id="MotherSchoolAttended" runat="server" name="MotherSchoolAttended"
                                        placeholder="" />
                                </td>
                            </tr>
                            <tr>
                                <td class="trlable">
                                    <span>Name of the college attended</span>
                                </td>
                                <td class="trcontrol">
                                    <input type="text" id="MotherCollegeAttended" runat="server" name="MotherCollegeAttended"
                                        placeholder="" />
                                </td>
                            </tr>
                        </table>
                    </li>
                </ol>
            </fieldset>
        </div>
    </div>
    <%--For communication start--%>
    <div class="panel panel-default">
        <div class="panel-heading">
            <div style="float: left;">
                <h3 class="panel-title">
                    For communication
                </h3>
            </div>
            <div class="rfindicator">
                <span>* Indicates required field </span>
            </div>
        </div>
        <div class="panel-body">
            <fieldset>
                <legend></legend>
                <ol>
                    <li>
                        <table width="100%">
                            <tr>
                                <td class="trlable">
                                    <span>Mobile number for communication * </span>
                                </td>
                                <td class="trcontrol">
                                    <input id="MobileNumberForCommunication" name="MobileNumberForCommunication" runat="server"
                                        pattern="\d{10}" onkeypress="return isNumber(this,event);" maxlength="10" required />
                                    <p class="validation01">
                                        <span class="invalid">No spaces or brackets e.g. 9999999999</span> <span class="valid">
                                            Your mobile number is valid</span>
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td class="trlable">
                                    <span>Email id for communication * </span>
                                </td>
                                <td class="trcontrol">
                                    <input type="text" id="EmailIdForCommunication" name="EmailIdForCommunication" runat="server"
                                        placeholder="" pattern="[a-z0-9_.-]+\@[0-9a-z-]+\.[a-z.]{2,6}" required />
                                    <p class="validation01">
                                        <span class="invalid">Please enter a valid email address e.g. yourid@example.com</span>
                                        <span class="valid">Your email address is now valid</span>
                                    </p>
                                </td>
                            </tr>
                        </table>
                    </li>
                </ol>
            </fieldset>
        </div>
    </div>
    <%--Other Information start--%>
    <div class="panel panel-default">
        <div class="panel-heading">
            <div style="float: left;">
                <h3 class="panel-title">
                    Other Information
                </h3>
            </div>
            <div class="rfindicator">
                <span>* Indicates required field </span>
            </div>
        </div>
        <div class="panel-body">
            <fieldset>
                <legend></legend>
                <ol>
                    <li>
                        <table width="100%">
                            <tr>
                                <td class="trlable">
                                    Mother Tongue *
                                </td>
                                <td class="trcontrol">
                                    <input type="text" id="MotherTongue" name="MotherTongue" runat="server" placeholder=""
                                        required />
                                </td>
                            </tr>
                            <tr>
                                <td class="trlable">
                                    Other Languages spoken at home *
                                </td>
                                <td class="trcontrol">
                                    <input type="text" id="OtherLanguagesSpokenAtHome" name="OtherLanguagesSpokenAtHome"
                                        runat="server" placeholder="" required />
                                </td>
                            </tr>
                            <tr>
                                <td class="trlable">
                                    Family Type *
                                </td>
                                <td class="trcontrol">
                                    <div class="dvmultioption">
                                        <div class="selectcontrol">
                                            <input id='IsNuclearOrJointFamily_1' name='IsNuclearOrJointFamily' runat='server'
                                                type='radio' value="Joint Family" required /></div>
                                        <div class="selectlable">
                                            <span>Joint Family </span>
                                        </div>
                                    </div>
                                    <div class="dvmultioption">
                                        <div class="selectcontrol">
                                            <input id='IsNuclearOrJointFamily_2' name='IsNuclearOrJointFamily' runat='server'
                                                type='radio' value="Nuclear Family" required /></div>
                                        <div class="selectlable">
                                            <span style='height: 29px;'>Nuclear Family</span></div>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td class="trlable">
                                    How did you hear about AIS *
                                </td>
                                <td class="trcontrol">
                                    <input type="text" id="HowDoYouHearAboutAIS" name="HowDoYouHearAboutAIS" runat="server"
                                        placeholder="" required />
                                </td>
                            </tr>
                            <tr>
                                <table width="100%" id="futureoption">
                                    <tr id="futureoptionrow1">
                                        <td class="trlable">
                                            What options offered by AIS are you looking at for your child? *
                                        </td>
                                        <td class="trcontrol">
                                            Select below option:
                                        </td>
                                    </tr>
                                    <tr id="futureoptionrow2">
                                        <td class="trlable">
                                            At the end of Grade VII
                                        </td>
                                        <td class="trcontrol">
                                            <div class="dvmultioption" style="display: block; width: 300px;">
                                                <div class="selectcontrol">
                                                    <input id='OptionOfferedByAISafterGradeVII_1' name='OptionOfferedByAISafterGradeVII'
                                                        runat='server' type='radio' value="Gujarat State Education Board" /></div>
                                                <div class="selectlable">
                                                    <span>Gujarat State Education Board </span>
                                                </div>
                                            </div>
                                            <div class="dvmultioption" style="display: block; width: 300px;">
                                                <div class="selectcontrol">
                                                    <input id='OptionOfferedByAISafterGradeVII_2' name='OptionOfferedByAISafterGradeVII'
                                                        runat='server' type='radio' value="Cambridge International Examinations" /></div>
                                                <div class="selectlable">
                                                    <span>Cambridge International Examinations</span></div>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr id="futureoptionrow3">
                                        <td class="trlable">
                                            At the end of Grade X
                                        </td>
                                        <td class="trcontrol">
                                            <div class="dvmultioption" style="display: block; width: 300px;">
                                                <div class="selectcontrol">
                                                    <input id='OptionOfferedByAISafterGradeX_1' name='OptionOfferedByAISafterGradeX'
                                                        runat='server' type='radio' value="Gujarat State Education Board" /></div>
                                                <div class="selectlable">
                                                    <span>Gujarat State Education Board </span>
                                                </div>
                                            </div>
                                            <div class="dvmultioption" style="display: block; width: 300px;">
                                                <div class="selectcontrol">
                                                    <input id='OptionOfferedByAISafterGradeX_2' name='OptionOfferedByAISafterGradeX'
                                                        runat='server' type='radio' value="Cambridge International Examinations" />
                                                </div>
                                                <div class="selectlable">
                                                    <span>Cambridge International Examinations</span></div>
                                            </div>
                                            <div class="dvmultioption" style="display: block; width: 300px;">
                                                <div class="selectcontrol">
                                                    <input id='OptionOfferedByAISafterGradeX_3' name='OptionOfferedByAISafterGradeX'
                                                        runat='server' type='radio' value="International Baccalaureate Organization" />
                                                </div>
                                                <div class="selectlable">
                                                    <span>International Baccalaureate Organization</span></div>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </tr>
                        </table>
                    </li>
                </ol>
            </fieldset>
        </div>
    </div>
    <%--Entrance Exam Day start--%>
    <div class="panel panel-default" id="entranceexam" style="display: none;">
        <div class="panel-heading">
            <div style="float: left;">
                <h3 class="panel-title">
                    Entrance Exam Day
                </h3>
            </div>
            <div class="rfindicator">
                <span>* Indicates required field </span>
            </div>
        </div>
        <div class="panel-body">
            <fieldset>
                <legend></legend>
                <ol>
                    <li>
                        <table width="100%">
                            <tr>
                                <td class="trlable">
                                    <span>Exam Day* </span>
                                </td>
                                <td class="trcontrol">
                                    <select name="ExamDay" id="ExamDay" runat="server" required>
                                    </select>
                                </td>
                            </tr>
                            <tr>
                                <td class="trlable">
                                    <span>Timing </span>
                                </td>
                                <td class="trcontrol">
                                    <span>9.00 am - 11.00 am</span>
                                </td>
                            </tr>
                        </table>
                    </li>
                </ol>
            </fieldset>
        </div>
    </div>
    <%--Declaration start--%>
    <div class="panel panel-default">
        <div class="panel-heading">
            <div style="float: left;">
                <h3 class="panel-title">
                    Declaration
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
                                    <ul style="padding-left: 20px;">
                                        <li style="list-style-type: circle;">Applicants furnishing false, incomplete, or misleading
                                            information will be subjected to rejection or dismissal without refund.</li>
                                        <li style="list-style-type: circle; padding-top: 15px;">Any pressure or recommendation
                                            brought on the school authorities will automatically disqualify the applicant.</li>
                                        <li style="list-style-type: circle; padding-top: 15px;">I declare that all information
                                            provided is correct and understand that false, inaccurate or misleading information
                                            could result in the student's withdrawal from school.</li>
                                        <li style="list-style-type: circle; padding-top: 15px;">Please refer the top block of
                                            this page for submission of document. Please note the documents are mandatory failing
                                            which the admission stands cancelled.</li>
                                    </ul>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div class="dvmultioption" style="float: right; margin-top: 25px; border: none; margin-bottom: 10px;">
                                        <div class="selectcontrol">
                                            <input type="checkbox" id="iagree" name="iagree" value="iagree" runat="server" placeholder=""
                                                required />
                                        </div>
                                        <div class="selectlable" style="padding-right: 15px;">
                                            <span>I Agree </span>
                                        </div>
                                        <asp:Button ID="btnsubmit" Text="Submit" runat="server" OnClick="submit_click" />
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </li>
                </ol>
            </fieldset>
        </div>
    </div>
    <%--Declaration end--%>
    <%--Response MessageBox--%>
    <div id="mainpopup" runat="server" class="overlay">
        <div class="popup">
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
                                                <asp:Button ID="btnPrint" Text="Print Application Form" runat="server" OnClientClick="javascript:return openprint();" />
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
    <asp:HiddenField ID="hdnmb" runat="server" Value="" />
    <asp:HiddenField ID="hdnrn" runat="server" Value="" />
    </form>
    <script type="text/javascript">
        H5F.listen(window, "load", function () { H5F.setup(document.getElementById("aisadmission")); }, false);

        function ChoiceAdmissionGrade(obj) {
            document.getElementById('admissiongradeloading').style.display = '';
            SetAdmissionBoard(obj.value); SetExamOption(obj.value); SetFutureOption(obj.value); SetWaitListText(obj.value);
            document.getElementById('admissiongradeloading').style.display = 'none';
            document.getElementById('<%= DateOfBirth.ClientID %>').value = '';
        }
        function ChoiceNationality(obj) {
            switch (obj.value) {
                case "Indian":
                    document.getElementById('<%= OtherNationality.ClientID %>').value = 'Indian';
                    document.getElementById('<%= PassportNumber.ClientID %>').value = '';
                    document.getElementById('<%= OtherNationality.ClientID %>').required = false;
                    document.getElementById('<%= PassportNumber.ClientID %>').required = false;
                    document.getElementById('dvnationality').style.display = 'none';
                    break;
                case "Other":
                    document.getElementById('<%= OtherNationality.ClientID %>').value = '';
                    document.getElementById('<%= PassportNumber.ClientID %>').value = '';
                    document.getElementById('<%= OtherNationality.ClientID %>').required = true;
                    document.getElementById('<%= PassportNumber.ClientID %>').required = true;
                    document.getElementById('dvnationality').style.display = 'inline-block';
                    break;
                default:
                    break;
            }
        }
        function ChoiceLastSchoolAttended(obj) {
            switch (obj.value) {
                case "TODDEN": document.getElementById('<%= OtherLastSchoolAttended.ClientID %>').value = 'TODDEN'; document.getElementById('dvlastschoolattended').style.display = 'none'; break;
                case "Other": document.getElementById('<%= OtherLastSchoolAttended.ClientID %>').value = ''; document.getElementById('dvlastschoolattended').style.display = 'inline-block'; break;
                default: break;
            }
        }
        function changeSibling(objvalue) {
            switch (objvalue) {
                case "radiosibling_Applicable":
                    document.getElementById('tablesiblings').style.display = '';

                    document.getElementById('<%= siblingname.ClientID %>').required = true;
                    //document.getElementById('<%= siblingage.ClientID %>').required = true;
                    document.getElementById('<%= siblingschoolcollege.ClientID %>').required = true;
                    document.getElementById('<%= siblingschoolcollege.ClientID %>').value = '';

                    document.getElementById('<%= siblingschoolcollegegrade.ClientID %>').style.display = 'none';
                    document.getElementById('<%= siblingschoolcollegedivision.ClientID %>').style.display = 'none';
                    document.getElementById('<%= Othersiblingschoolcollegegrade.ClientID %>').style.display = 'none';

                    document.getElementById('<%= siblingschoolcollegesecond.ClientID %>').value = '';

                    document.getElementById('<%= siblingschoolcollegegradesecond.ClientID %>').style.display = 'none';
                    document.getElementById('<%= siblingschoolcollegedivisionsecond.ClientID %>').style.display = 'none';
                    document.getElementById('<%= Othersiblingschoolcollegegradesecond.ClientID %>').style.display = 'none';

                    break;
                case "radiosibling_NotApplicable":
                    document.getElementById('tablesiblings').style.display = 'none';

                    document.getElementById('<%= siblingname.ClientID %>').required = false;
                    //document.getElementById('<%= siblingage.ClientID %>').required = false;
                    document.getElementById('<%= siblingschoolcollege.ClientID %>').required = false;
                    document.getElementById('<%= siblingschoolcollegegrade.ClientID %>').required = false;
                    document.getElementById('<%= siblingschoolcollegedivision.ClientID %>').required = false;
                    document.getElementById('<%= Othersiblingschoolcollegegrade.ClientID %>').required = false;

                    document.getElementById('<%= siblingschoolcollegegradesecond.ClientID %>').required = false;
                    document.getElementById('<%= siblingschoolcollegedivisionsecond.ClientID %>').required = false;
                    document.getElementById('<%= Othersiblingschoolcollegegradesecond.ClientID %>').required = false;
                    break;
                default:
                    break;
            }
        }
        function Changesiblingschoolcollege(objvalue) {
            switch (objvalue) {
                case "AIS":
                    document.getElementById('<%= siblingschoolcollegegrade.ClientID %>').style.display = ''; document.getElementById('<%= siblingschoolcollegegrade.ClientID %>').required = true;
                    document.getElementById('<%= siblingschoolcollegedivision.ClientID %>').style.display = ''; document.getElementById('<%= siblingschoolcollegedivision.ClientID %>').required = true;
                    document.getElementById('<%= Othersiblingschoolcollegegrade.ClientID %>').style.display = 'none'; document.getElementById('<%= Othersiblingschoolcollegegrade.ClientID %>').required = false;
                    break;
                case "Other":
                    document.getElementById('<%= siblingschoolcollegegrade.ClientID %>').style.display = 'none'; document.getElementById('<%= siblingschoolcollegegrade.ClientID %>').required = false;
                    document.getElementById('<%= siblingschoolcollegedivision.ClientID %>').style.display = 'none'; document.getElementById('<%= siblingschoolcollegedivision.ClientID %>').required = false;
                    document.getElementById('<%= Othersiblingschoolcollegegrade.ClientID %>').style.display = ''; document.getElementById('<%= Othersiblingschoolcollegegrade.ClientID %>').required = true;
                    break;
                default:
                    document.getElementById('<%= siblingschoolcollegegrade.ClientID %>').style.display = 'none'; document.getElementById('<%= siblingschoolcollegegrade.ClientID %>').required = false;
                    document.getElementById('<%= siblingschoolcollegedivision.ClientID %>').style.display = 'none'; document.getElementById('<%= siblingschoolcollegedivision.ClientID %>').required = false;
                    document.getElementById('<%= Othersiblingschoolcollegegrade.ClientID %>').style.display = 'none'; document.getElementById('<%= Othersiblingschoolcollegegrade.ClientID %>').required = false;
                    break;
            }
        }
        function Changesiblingschoolcollegesecond(objvalue) {
            switch (objvalue) {
                case "AIS":
                    document.getElementById('<%= siblingschoolcollegegradesecond.ClientID %>').style.display = ''; document.getElementById('<%= siblingschoolcollegegradesecond.ClientID %>').required = true;
                    document.getElementById('<%= siblingschoolcollegedivisionsecond.ClientID %>').style.display = ''; document.getElementById('<%= siblingschoolcollegedivisionsecond.ClientID %>').required = true;
                    document.getElementById('<%= Othersiblingschoolcollegegradesecond.ClientID %>').style.display = 'none'; document.getElementById('<%= Othersiblingschoolcollegegradesecond.ClientID %>').required = false;
                    break;
                case "Other":
                    document.getElementById('<%= siblingschoolcollegegradesecond.ClientID %>').style.display = 'none'; document.getElementById('<%= siblingschoolcollegegradesecond.ClientID %>').required = false;
                    document.getElementById('<%= siblingschoolcollegedivisionsecond.ClientID %>').style.display = 'none'; document.getElementById('<%= siblingschoolcollegedivisionsecond.ClientID %>').required = false;
                    document.getElementById('<%= Othersiblingschoolcollegegradesecond.ClientID %>').style.display = ''; document.getElementById('<%= Othersiblingschoolcollegegradesecond.ClientID %>').required = true;
                    break;
                default:
                    document.getElementById('<%= siblingschoolcollegegradesecond.ClientID %>').style.display = 'none'; document.getElementById('<%= siblingschoolcollegegradesecond.ClientID %>').required = false;
                    document.getElementById('<%= siblingschoolcollegedivisionsecond.ClientID %>').style.display = 'none'; document.getElementById('<%= siblingschoolcollegedivisionsecond.ClientID %>').required = false;
                    document.getElementById('<%= Othersiblingschoolcollegegradesecond.ClientID %>').style.display = 'none'; document.getElementById('<%= Othersiblingschoolcollegegradesecond.ClientID %>').required = false;
                    break;
            }
        }
        function SetFutureOption(AdmissionGrade) {
            switch (AdmissionGrade) {
                case "8": ShowTenOption(); break;
                case "9": ShowTenOption(); break;
                case "10": HideFutureOption(); break;
                case "11": HideFutureOption(); break;
                default: ShowSenenAndTenOption(); break; // For Nursery to 7
            }
        }
        function ShowTenOption() {
            document.getElementById('futureoptionrow1').style.display = '';
            document.getElementById('futureoptionrow2').style.display = 'none';
            document.getElementById('futureoptionrow3').style.display = '';

            //document.getElementById('<%= OptionOfferedByAISafterGradeVII_1.ClientID %>').required = false;
            //document.getElementById('<%= OptionOfferedByAISafterGradeVII_2.ClientID %>').required = false;
            //document.getElementById('<%= OptionOfferedByAISafterGradeX_1.ClientID %>').required = true;
            //document.getElementById('<%= OptionOfferedByAISafterGradeX_2.ClientID %>').required = true;
            //document.getElementById('<%= OptionOfferedByAISafterGradeX_3.ClientID %>').required = true;
        }
        function ShowSenenAndTenOption() {
            document.getElementById('futureoptionrow1').style.display = '';
            document.getElementById('futureoptionrow2').style.display = '';
            document.getElementById('futureoptionrow3').style.display = '';

            //document.getElementById('<%= OptionOfferedByAISafterGradeVII_1.ClientID %>').required = true;
            //document.getElementById('<%= OptionOfferedByAISafterGradeVII_2.ClientID %>').required = true;
            //document.getElementById('<%= OptionOfferedByAISafterGradeX_1.ClientID %>').required = true;
            //document.getElementById('<%= OptionOfferedByAISafterGradeX_2.ClientID %>').required = true;
            //document.getElementById('<%= OptionOfferedByAISafterGradeX_3.ClientID %>').required = true;
        }
        function HideFutureOption() {
            document.getElementById('futureoptionrow1').style.display = 'none';
            document.getElementById('futureoptionrow2').style.display = 'none';
            document.getElementById('futureoptionrow3').style.display = 'none';

            //document.getElementById('<%= OptionOfferedByAISafterGradeVII_1.ClientID %>').required = false;
            //document.getElementById('<%= OptionOfferedByAISafterGradeVII_2.ClientID %>').required = false;
            //document.getElementById('<%= OptionOfferedByAISafterGradeX_1.ClientID %>').required = false;
            //document.getElementById('<%= OptionOfferedByAISafterGradeX_2.ClientID %>').required = false;
            //document.getElementById('<%= OptionOfferedByAISafterGradeX_3.ClientID %>').required = false;
        }
        function SetExamOption(AdmissionGrade) {
            switch (AdmissionGrade) {
                case "5": ShowExamOption(); break;
                case "6": ShowExamOption(); break;
                case "7": ShowExamOption(); break;
                case "8": ShowExamOption(); break;
                case "9": ShowExamOption(); break;
                case "10": ShowExamOption(); break;
                case "11": ShowExamOption(); break;
                default: HideExamOption(); break;
            }
        }
        function ShowExamOption() { document.getElementById('entranceexam').style.display = ''; document.getElementById('<%= ExamDay.ClientID %>').required = true; }
        function HideExamOption() { document.getElementById('entranceexam').style.display = 'none'; document.getElementById('<%= ExamDay.ClientID %>').required = false; }
        function SetAdmissionBoard(AdmissionGrade) {
            switch (AdmissionGrade) {
                case "Nursery": VisibleFalseAllBorardOption(); VisibleBorardOptionNursery(true); break;
                case "8": VisibleFalseAllBorardOption(); VisibleBorardOption8(true); break;
                case "9": VisibleFalseAllBorardOption(); VisibleBorardOption9(true); break;
                case "11": VisibleFalseAllBorardOption(); VisibleBorardOption11(true); break;
                default: VisibleFalseAllBorardOption(); break;
            }
        }
        function SetWaitListText(AdmissionGrade) {
            switch (AdmissionGrade) {
                case "": case "Nursery": case "8": case "10": case "11":
                    document.getElementById('<%= waitlistform.ClientID %>').innerHTML = '';
                    document.getElementById('<%= hdnwaitlistform.ClientID %>').value = '';
                    break;
                default:
                    document.getElementById('<%= waitlistform.ClientID %>').innerHTML = 'Waitlist Application Form';
                    document.getElementById('<%= hdnwaitlistform.ClientID %>').value = 'Waitlist Application Form';
                    break;
            }
        }
        function VisibleBorardOptionNursery(par) {
            if (par) {
                document.getElementById('trNursery').style.display = '';
                document.getElementById('<%= radioboardNursery_1.ClientID %>').required = true;
                document.getElementById('<%= radioboardNursery_2.ClientID %>').required = true;

                document.getElementById('<%= radioboardNursery_1.ClientID %>').checked = false;
                document.getElementById('<%= radioboardNursery_2.ClientID %>').checked = false;
            }
            else {
                document.getElementById('trNursery').style.display = 'none';
                document.getElementById('<%= radioboardNursery_1.ClientID %>').required = false;
                document.getElementById('<%= radioboardNursery_2.ClientID %>').required = false;

                document.getElementById('trNurserytodden').style.display = 'none';
                document.getElementById('<%= accesscode.ClientID %>').required = false;
            }
        }
        function VisibleBorardOption8(par) {
            if (par) {
                document.getElementById('tr8').style.display = '';
                document.getElementById('<%= radioboard8_1.ClientID %>').required = true;
                document.getElementById('<%= radioboard8_2.ClientID %>').required = true;
            }
            else {
                document.getElementById('tr8').style.display = 'none';
                document.getElementById('<%= radioboard8_1.ClientID %>').required = false;
                document.getElementById('<%= radioboard8_2.ClientID %>').required = false;
            }
        }
        function VisibleBorardOption9(par) {
            if (par) {
                document.getElementById('tr9').style.display = '';
                document.getElementById('<%= radioboard9_1.ClientID %>').required = true;
            }
            else {
                document.getElementById('tr9').style.display = 'none';
                document.getElementById('<%= radioboard9_1.ClientID %>').required = false;
            }
        }
        function VisibleBorardOption11(par) {
            if (par) {
                document.getElementById('tr11').style.display = '';
                document.getElementById('<%= radioboard11_1.ClientID %>').required = true;
                document.getElementById('<%= radioboard11_2.ClientID %>').required = true;
            }
            else {
                document.getElementById('tr11').style.display = 'none';
                document.getElementById('<%= radioboard11_1.ClientID %>').required = false;
                document.getElementById('<%= radioboard11_2.ClientID %>').required = false;
            }
        }
        function VisibleFalseAllBorardOption() { VisibleBorardOptionNursery(false); VisibleBorardOption8(false); VisibleBorardOption9(false); VisibleBorardOption11(false); document.getElementById("<%= radiosibling_NotApplicable.ClientID %>").disabled = false; }
        function CloseMessage() { document.getElementById("<%= mainpopup.ClientID %>").className = "overlay"; return false; }
        function changeNurseryApplicant(optionvalue) {
            switch (optionvalue) {
                case "TODDEN Applicant":
                    document.getElementById('trNurserytodden').style.display = '';
                    document.getElementById('<%= accesscode.ClientID %>').required = true;

                    document.getElementById('<%= radiosibling_NotApplicable.ClientID %>').checked = true;
                    changeSibling('radiosibling_NotApplicable');
                    document.getElementById("<%= radiosibling_NotApplicable.ClientID %>").disabled = false;
                    break;
                case "Sibling Applicant":
                    document.getElementById('trNurserytodden').style.display = 'none';
                    document.getElementById('<%= accesscode.ClientID %>').required = false;

                    document.getElementById('<%= radiosibling_Applicable.ClientID %>').checked = true;
                    changeSibling('radiosibling_Applicable');
                    document.getElementById("<%= radiosibling_NotApplicable.ClientID %>").disabled = true;

                    Changesiblingschoolcollege('AIS');
                    document.getElementById('<%= siblingschoolcollege.ClientID %>').value = 'AIS';

                    break;
                default: break;
            }
        }
        function ChoiceMotherOccupation(obj) { switch (obj.value) { case "Homemaker": document.getElementById('trMotherOfficeAddress').style.display = 'none'; break; default: document.getElementById('trMotherOfficeAddress').style.display = ''; break; } }
        function dateSelectionChanged(sender, args) {
            var admissiongrade = document.getElementById('<%= AdmissionGrade.ClientID %>').value;
            if (admissiongrade != '' && admissiongrade != null) {
                if (admissiongrade == 'Nursery') {
                    //01-Jan-2012 To 31-May-2013
                    var sdate = new Date(2012, 00, 01); var edate = new Date(2013, 04, 31); var selecteddate = new Date(sender.get_selectedDate().getFullYear(), sender.get_selectedDate().getMonth(), sender.get_selectedDate().getDate());
                    if (selecteddate >= sdate && selecteddate <= edate) { }
                    else {
                        alert('Sorry your child is not eligible for Nursery for the academic year 2015 2016.');
                        document.getElementById('<%= DateOfBirth.ClientID %>').value = '';
                    }
                }
            } else { document.getElementById('<%= DateOfBirth.ClientID %>').value = ''; }
        }
        function validateacesscode(obj) {
            document.getElementById('imgaccesscode').style.display = '';
            PageMethods.ValidateAccessCode(obj, OnSucceeded, OnFailed);
            function OnSucceeded(response) { if (response == 'validtoddenaccesscode') { } else if (response == 'invalidtoddenaccesscode') { document.getElementById('<%= accesscode.ClientID %>').value = ''; } document.getElementById('imgaccesscode').style.display = 'none'; }
            function OnFailed(error) { document.getElementById('<%= accesscode.ClientID %>').value = ''; document.getElementById('imgaccesscode').style.display = 'none'; }
        }
        function isNumber(key, event) { var keyCode; var isIE; if (navigator.appName == "Microsoft Internet Explorer" || navigator.appName == "Netscape") { keyCode = event.keyCode; isIE = 1; if (navigator.appName == "Netscape") { keyCode = event.charCode; isIE = 0; } } else { keyCode = event.charCode; isIE = 0; } if (isIE == 1) { if (!((keyCode >= 48 && keyCode <= 57))) { return false; } } else { if (!((keyCode >= 48 && keyCode <= 57) || keyCode == 0)) { event.preventDefault(); } } }
        function NotAllow(key, event) { return false; }
        function openprint() { var mb = document.getElementById('<%= hdnmb.ClientID %>').value; var rn = document.getElementById('<%= hdnrn.ClientID %>').value; var URL = "printadmissionform.aspx?mb=" + mb + "&rn=" + rn + ""; window.open(URL, "_blank", "location=yes,scrollbars=yes,status=yes"); return false; }   
    </script>
</body>
</html>
