using System;
using System.Data;
using System.Web.UI.WebControls;
using System.Collections;
using System.Web.Services;
using System.Text.RegularExpressions;

public partial class Admission_AdmissionForm : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindExamDates();
        }
    }
    protected void submit_click(object sender, EventArgs e)
    {
        BAL_Admission oBAL_Admission = new BAL_Admission();
        AdmissionProperties oAdmissionProperties = new AdmissionProperties();

        //Admission criteria
        oAdmissionProperties.AdmissionGrade = AdmissionGrade.Value;

        #region Admission board value

        switch (oAdmissionProperties.AdmissionGrade)
        {
            case "Nursery":
                if (radioboardNursery_1.Checked)
                {
                    oAdmissionProperties.ApplicantType = radioboardNursery_1.Value;
                    oAdmissionProperties.AccessCode = accesscode.Value;
                    string response = ValidateAccessCode(accesscode.Value);
                    if (response == "invalidtoddenaccesscode")
                    {
                        btnPrint.Visible = false;
                        AdmissionGrade.Value = "";
                        mainpopup.Attributes["class"] = "overlayone";
                        msg.InnerText = "Sorry, Requested Access Code is already used by other user.";
                        return;
                    }
                }
                else if (radioboardNursery_2.Checked)
                {
                    oAdmissionProperties.ApplicantType = radioboardNursery_2.Value;
                }
                break;
            case "8":
                if (radioboard8_1.Checked)
                    oAdmissionProperties.ChoiceofBoard = radioboard8_1.Value;
                else if (radioboard8_2.Checked)
                    oAdmissionProperties.ChoiceofBoard = radioboard8_2.Value;
                break;
            case "9":
                if (radioboard9_1.Checked)
                    oAdmissionProperties.ChoiceofBoard = radioboard9_1.Value;
                break;
            case "11":
                if (radioboard11_1.Checked)
                    oAdmissionProperties.ChoiceofBoard = radioboard11_1.Value;
                else if (radioboard11_2.Checked)
                    oAdmissionProperties.ChoiceofBoard = radioboard11_2.Value;
                break;
            default:
                break;
        }

        #endregion

        oAdmissionProperties.FormType = GetValue(hdnwaitlistform.Value);

        //Personal information
        oAdmissionProperties.FirstName = GetValue(FirstName.Value);
        oAdmissionProperties.MiddleName = GetValue(MiddleName.Value);
        oAdmissionProperties.LastName = GetValue(LastName.Value);
        oAdmissionProperties.Addressline1 = GetValue(Addressline1.Value);
        oAdmissionProperties.Addressline2 = GetValue(Addressline2.Value);
        oAdmissionProperties.Country = GetValue(Country.Value);
        oAdmissionProperties.State = GetValue(State.Value);
        oAdmissionProperties.City = GetValue(City.Value);
        oAdmissionProperties.Pincode = GetValue(Pincode.Value);
        oAdmissionProperties.TelephoneNo = GetValue(stdcode.Value + '-' + TelephoneNo.Value);
        oAdmissionProperties.EmergencyMobileNo = GetValue(EmergencyMobileNo.Value);

        if (Gender_1.Checked)
            oAdmissionProperties.Gender = "Male";
        else if (Gender_2.Checked)
            oAdmissionProperties.Gender = "Female";

        oAdmissionProperties.DateOfBirth = GetValue(DateOfBirth.Text);
        oAdmissionProperties.PlaceOfBirth = GetValue(PlaceOfBirth.Value);
        oAdmissionProperties.Nationality = GetValue(Nationality.Value);
        oAdmissionProperties.OtherNationality = GetValue(OtherNationality.Value);
        oAdmissionProperties.PassportNumber = GetValue(PassportNumber.Value);
        oAdmissionProperties.Caste = GetValue(Caste.Value);
        oAdmissionProperties.LastSchoolAttended = GetValue(LastSchoolAttended.Value);
        oAdmissionProperties.OtherLastSchoolAttended = GetValue(OtherLastSchoolAttended.Value);

        //Father information
        oAdmissionProperties.FatherName = GetValue(FatherName.Value);
        oAdmissionProperties.Fathergraduationdegree = GetValue(Fathergraduationdegree.Value);
        oAdmissionProperties.FatherPostGraduationDegree = GetValue(FatherPostGraduationDegree.Value);
        oAdmissionProperties.FatherOccupation = GetValue(FatherOccupation.Value);
        oAdmissionProperties.FatherOfficeAddress = GetValue(FatherOfficeAddress.Value);
        oAdmissionProperties.FatherMobileNumber = GetValue(FatherMobileNumber.Value);
        oAdmissionProperties.FatherEmailId = GetValue(FatherEmailId.Value);
        oAdmissionProperties.FatherSchoolAttended = GetValue(FatherSchoolAttended.Value);
        oAdmissionProperties.FatherCollegeAttended = GetValue(FatherCollegeAttended.Value);

        //Mother information
        oAdmissionProperties.MotherName = GetValue(MotherName.Value);
        oAdmissionProperties.MotherGraduationDegree = GetValue(MotherGraduationDegree.Value);
        oAdmissionProperties.MotherPostGraduationDegree = GetValue(MotherPostGraduationDegree.Value);
        oAdmissionProperties.MotherOccupation = GetValue(MotherOccupation.Value);
        oAdmissionProperties.MotherOfficeAddress = GetValue(MotherOfficeAddress.Value);
        oAdmissionProperties.MotherMobileNumber = GetValue(MotherMobileNumber.Value);
        oAdmissionProperties.ResidenceOrLandlineNumber = GetValue(rorlstdcode.Value + '-' + ResidenceOrLandlineNumber.Value);
        oAdmissionProperties.MotherEmailId = GetValue(MotherEmailId.Value);
        oAdmissionProperties.MotherSchoolAttended = GetValue(MotherSchoolAttended.Value);
        oAdmissionProperties.MotherCollegeAttended = GetValue(MotherCollegeAttended.Value);

        //For communication
        oAdmissionProperties.MobileNumberForCommunication = GetValue(MobileNumberForCommunication.Value);
        oAdmissionProperties.EmailIdForCommunication = GetValue(EmailIdForCommunication.Value);

        if (radiosibling_Applicable.Checked)
        {
            //Siblings-1
            oAdmissionProperties.Siblingname = GetValue(siblingname.Value);
            oAdmissionProperties.Siblingage = GetValue(siblingage.Text);
            oAdmissionProperties.Siblingschoolcollege = GetValue(siblingschoolcollege.Value);

            if (siblingschoolcollege.Value == "AIS")
            {
                oAdmissionProperties.Siblingschoolcollegegrade = GetValue(siblingschoolcollegegrade.Value);
                oAdmissionProperties.Siblingschoolcollegedivision = GetValue(siblingschoolcollegedivision.Value);
            }
            else if (siblingschoolcollege.Value == "Other")
                oAdmissionProperties.Siblingschoolcollegegrade = GetValue(Othersiblingschoolcollegegrade.Value);

            //Siblings-2
            if (!string.IsNullOrEmpty(siblingnamesecond.Value))
            {
                oAdmissionProperties.Siblingnamesecond = GetValue(siblingnamesecond.Value);
                oAdmissionProperties.Siblingagesecond = GetValue(siblingagesecond.Text);
                oAdmissionProperties.Siblingschoolcollegesecond = GetValue(siblingschoolcollegesecond.Value);

                if (siblingschoolcollegesecond.Value == "AIS")
                {
                    oAdmissionProperties.Siblingschoolcollegegradesecond = GetValue(siblingschoolcollegegradesecond.Value);
                    oAdmissionProperties.Siblingschoolcollegedivisionsecond = GetValue(siblingschoolcollegedivisionsecond.Value);
                }
                else if (siblingschoolcollegesecond.Value == "Other")
                    oAdmissionProperties.Siblingschoolcollegegradesecond = GetValue(Othersiblingschoolcollegegradesecond.Value);
            }
        }

        //Other Information
        oAdmissionProperties.MotherTongue = GetValue(MotherTongue.Value);
        oAdmissionProperties.OtherLanguagesSpokenAtHome = GetValue(OtherLanguagesSpokenAtHome.Value);

        if (IsNuclearOrJointFamily_1.Checked)
            oAdmissionProperties.IsNuclearOrJointFamily = IsNuclearOrJointFamily_1.Value;
        else if (IsNuclearOrJointFamily_2.Checked)
            oAdmissionProperties.IsNuclearOrJointFamily = IsNuclearOrJointFamily_2.Value;

        oAdmissionProperties.HowDoYouHearAboutAIS = GetValue(HowDoYouHearAboutAIS.Value);

        #region Future Option value

        switch (oAdmissionProperties.AdmissionGrade)
        {
            case "8":
                if (OptionOfferedByAISafterGradeX_1.Checked)
                    oAdmissionProperties.OptionOfferedByAISafterGradeX = OptionOfferedByAISafterGradeX_1.Value;
                else if (OptionOfferedByAISafterGradeX_2.Checked)
                    oAdmissionProperties.OptionOfferedByAISafterGradeX = OptionOfferedByAISafterGradeX_2.Value;
                break;
            case "9":
                if (OptionOfferedByAISafterGradeX_1.Checked)
                    oAdmissionProperties.OptionOfferedByAISafterGradeX = OptionOfferedByAISafterGradeX_1.Value;
                else if (OptionOfferedByAISafterGradeX_2.Checked)
                    oAdmissionProperties.OptionOfferedByAISafterGradeX = OptionOfferedByAISafterGradeX_2.Value;

                break;
            case "10": break;
            case "11": break;
            default:
                if (OptionOfferedByAISafterGradeVII_1.Checked)
                    oAdmissionProperties.OptionOfferedByAISafterGradeVII = OptionOfferedByAISafterGradeVII_1.Value;
                else if (OptionOfferedByAISafterGradeVII_2.Checked)
                    oAdmissionProperties.OptionOfferedByAISafterGradeVII = OptionOfferedByAISafterGradeVII_2.Value;

                if (OptionOfferedByAISafterGradeX_1.Checked)
                    oAdmissionProperties.OptionOfferedByAISafterGradeX = OptionOfferedByAISafterGradeX_1.Value;
                else if (OptionOfferedByAISafterGradeX_2.Checked)
                    oAdmissionProperties.OptionOfferedByAISafterGradeX = OptionOfferedByAISafterGradeX_2.Value;
                else if (OptionOfferedByAISafterGradeX_3.Checked)
                    oAdmissionProperties.OptionOfferedByAISafterGradeX = OptionOfferedByAISafterGradeX_3.Value;

                break;
        }

        #endregion

        #region ExamDay Option

        switch (oAdmissionProperties.AdmissionGrade)
        {
            case "5":
            case "6":
            case "7":
            case "8":
            case "9":
            case "10":
            case "11":
                oAdmissionProperties.ExamDay = ExamDay.Value;
                oAdmissionProperties.ExamTime = "9.00 am - 11.00 am";
                break;
            default:
                break;
        }

        #endregion

        #region Send Nautification Mail for exam

        ArrayList ArrMailTo = new ArrayList();
        ArrMailTo.Add(EmailIdForCommunication.Value);
        string MailSubject = "AIS Entrance Exam Notification";
        string MailBody = "Dear Student,<br /><br /><br />Your entrance exam is scheduled on " + oAdmissionProperties.ExamDay + " at " + oAdmissionProperties.ExamTime + ".<br /><br /><br />Thanks,<br />AIS Team.";
        string FailiurReason = string.Empty;

        switch (AdmissionGrade.Value)
        {
            case "5":
            case "6":
            case "7":
            case "8":
            case "9":
            case "10":
            case "11":
                oAdmissionProperties.MailBody = MailBody;
                oAdmissionProperties.IsSendMailSuccess = EmailUtility.SendEmail(ArrMailTo, MailSubject, MailBody, out FailiurReason);
                oAdmissionProperties.FailiurReason = GetValue(FailiurReason);
                break;
            default:
                break;
        }

        #endregion

        string ReferenceNumber = oBAL_Admission.Admission_Insert(oAdmissionProperties, "ReferenceNumber");

        if (!string.IsNullOrEmpty(ReferenceNumber))
        {
            hdnmb.Value = MobileNumberForCommunication.Value;
            hdnrn.Value = ReferenceNumber;
            btnPrint.Visible = true;
            mainpopup.Attributes["class"] = "overlayone";
            msg.InnerHtml = "Your application has been successfully submitted. Thank you for your interest in Ahmedabad International School.<br /><br /> Your application reference number is <span style='color:#3db5d8;'>" + ReferenceNumber + "</span>, Please use this reference number for all further correspondence.";
            ResetControl();
        }
        else
        {
            btnPrint.Visible = false;
            mainpopup.Attributes["class"] = "overlayone";
            msg.InnerText = "Sorry, There is some problem in admission application submission, please try again.";
        }
    }
    private void ResetControl()
    {
        AdmissionGrade.Value = string.Empty;
        radioboardNursery_1.Checked = false;
        radioboardNursery_2.Checked = false;
        radioboard8_1.Checked = false;
        radioboard8_2.Checked = false;
        radioboard9_1.Checked = false;
        radioboard11_1.Checked = false;
        radioboard11_2.Checked = false;

        waitlistform.Text = string.Empty;

        FirstName.Value = string.Empty;
        MiddleName.Value = string.Empty;
        LastName.Value = string.Empty;
        Addressline1.Value = string.Empty;
        Addressline2.Value = string.Empty;
        Country.Value = string.Empty;
        State.Value = string.Empty;
        City.Value = string.Empty;
        Pincode.Value = string.Empty;
        stdcode.Value = string.Empty;
        TelephoneNo.Value = string.Empty;
        EmergencyMobileNo.Value = string.Empty;

        Gender_1.Checked = false;
        Gender_2.Checked = false;

        DateOfBirth.Text = string.Empty;
        PlaceOfBirth.Value = string.Empty;
        Nationality.Value = string.Empty;
        OtherNationality.Value = "Indian";
        Caste.Value = string.Empty;
        LastSchoolAttended.Value = string.Empty;
        OtherLastSchoolAttended.Value = "AIS";

        FatherName.Value = string.Empty;
        Fathergraduationdegree.Value = string.Empty;
        FatherPostGraduationDegree.Value = string.Empty;
        FatherOccupation.Value = string.Empty;
        FatherOfficeAddress.Value = string.Empty;
        FatherMobileNumber.Value = string.Empty;
        FatherEmailId.Value = string.Empty;
        FatherSchoolAttended.Value = string.Empty;
        FatherCollegeAttended.Value = string.Empty;

        MotherName.Value = string.Empty;
        MotherGraduationDegree.Value = string.Empty;
        MotherPostGraduationDegree.Value = string.Empty;
        MotherOccupation.Value = string.Empty;
        MotherOfficeAddress.Value = string.Empty;
        MotherMobileNumber.Value = string.Empty;
        rorlstdcode.Value = string.Empty;
        ResidenceOrLandlineNumber.Value = string.Empty;
        MotherEmailId.Value = string.Empty;
        MotherSchoolAttended.Value = string.Empty;
        MotherCollegeAttended.Value = string.Empty;

        MobileNumberForCommunication.Value = string.Empty;
        EmailIdForCommunication.Value = string.Empty;

        siblingname.Value = string.Empty;
        siblingage.Text = string.Empty;
        siblingschoolcollege.Value = string.Empty;
        siblingschoolcollegegrade.Value = string.Empty;
        siblingschoolcollegedivision.Value = string.Empty;

        siblingnamesecond.Value = string.Empty;
        siblingagesecond.Text = string.Empty;
        siblingschoolcollegesecond.Value = string.Empty;
        siblingschoolcollegegradesecond.Value = string.Empty;
        siblingschoolcollegedivisionsecond.Value = string.Empty;

        MotherTongue.Value = string.Empty;

        OtherLanguagesSpokenAtHome.Value = string.Empty;

        IsNuclearOrJointFamily_1.Checked = false;
        IsNuclearOrJointFamily_2.Checked = false;

        HowDoYouHearAboutAIS.Value = string.Empty;

        OptionOfferedByAISafterGradeVII_1.Checked = false;
        OptionOfferedByAISafterGradeVII_2.Checked = false;

        OptionOfferedByAISafterGradeX_1.Checked = false;
        OptionOfferedByAISafterGradeX_2.Checked = false;
        OptionOfferedByAISafterGradeX_3.Checked = false;

        iagree.Checked = false;
    }
    private string GetValue(string inputstring)
    {
        return (!string.IsNullOrEmpty(inputstring) ? inputstring.Trim() : null);
    }
    private void BindExamDates()
    {
        BAL_Admission oBAL_Admission = new BAL_Admission();

        DataSet ods = oBAL_Admission.Admission_ExamDays_SelectALL();

        DataSet ds = new DataSet();
        ExamDay.DataSource = ods.Tables[0];
        ExamDay.DataTextField = "ExamDays";
        ExamDay.DataValueField = "ExamDays";
        ExamDay.DataBind();

        ExamDay.Items.Insert(0, new ListItem("-- Select --", ""));
    }
    [WebMethod]
    public static string ValidateAccessCode(string accesscode)
    {
        string returnvalue = "invalidtoddenaccesscode";
        if (!string.IsNullOrEmpty(accesscode))
        {
            Match match = Regex.Match(accesscode, @"^16TN(100|\d{2})$", RegexOptions.IgnoreCase);
            if (match.Success)
            {
                BAL_Admission oBAL_Admission = new BAL_Admission();

                DataSet ods = oBAL_Admission.Admission_ValidateAccesscode(accesscode);
                if (ods.Tables.Count > 0)
                {
                    if (ods.Tables[0].Rows.Count > 0)
                        returnvalue = "invalidtoddenaccesscode";
                    else
                        returnvalue = "validtoddenaccesscode";
                }
                else
                    returnvalue = "invalidtoddenaccesscode";
            }
            else
            {
                returnvalue = "invalidtoddenaccesscode";
            }
        }
        else
        {
            returnvalue = "invalidtoddenaccesscode";
        }
        return returnvalue;
    }
}

