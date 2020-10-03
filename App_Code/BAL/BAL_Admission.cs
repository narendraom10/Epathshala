using System.Collections;
using System.Data;
using System;

/// <summary>
/// Summary description for BAL_Admission
/// </summary>
public class BAL_Admission
{
    DataAccess oDataHelper;
    ArrayList arrParameter;

    public BAL_Admission()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public string Admission_Insert(AdmissionProperties AdmissionProperties, string OutParameter)
    {
        this.oDataHelper = new DataAccess();
        this.arrParameter = new ArrayList();

        this.arrParameter.Add(new parameter("AdmissionGrade", AdmissionProperties.AdmissionGrade));
        this.arrParameter.Add(new parameter("FormType", AdmissionProperties.FormType));
        this.arrParameter.Add(new parameter("ApplicantType", AdmissionProperties.ApplicantType));
        this.arrParameter.Add(new parameter("AccessCode", AdmissionProperties.AccessCode));
        this.arrParameter.Add(new parameter("ChoiceofBoard", AdmissionProperties.ChoiceofBoard));
        this.arrParameter.Add(new parameter("FirstName", AdmissionProperties.FirstName));
        this.arrParameter.Add(new parameter("MiddleName", AdmissionProperties.MiddleName));
        this.arrParameter.Add(new parameter("LastName", AdmissionProperties.LastName));
        this.arrParameter.Add(new parameter("Addressline1", AdmissionProperties.Addressline1));
        this.arrParameter.Add(new parameter("Addressline2", AdmissionProperties.Addressline2));
        this.arrParameter.Add(new parameter("Country", AdmissionProperties.Country));
        this.arrParameter.Add(new parameter("State", AdmissionProperties.State));
        this.arrParameter.Add(new parameter("City", AdmissionProperties.City));
        this.arrParameter.Add(new parameter("Pincode", AdmissionProperties.Pincode));
        this.arrParameter.Add(new parameter("TelephoneNo", AdmissionProperties.TelephoneNo));
        this.arrParameter.Add(new parameter("EmergencyMobileNo", AdmissionProperties.EmergencyMobileNo));
        this.arrParameter.Add(new parameter("Gender", AdmissionProperties.Gender));
        this.arrParameter.Add(new parameter("DateOfBirth", AdmissionProperties.DateOfBirth));
        this.arrParameter.Add(new parameter("PlaceOfBirth", AdmissionProperties.PlaceOfBirth));
        this.arrParameter.Add(new parameter("Nationality", AdmissionProperties.Nationality));
        this.arrParameter.Add(new parameter("OtherNationality", AdmissionProperties.OtherNationality));
        this.arrParameter.Add(new parameter("PassportNumber", AdmissionProperties.PassportNumber));
        this.arrParameter.Add(new parameter("Caste", AdmissionProperties.Caste));
        this.arrParameter.Add(new parameter("LastSchoolAttended", AdmissionProperties.LastSchoolAttended));
        this.arrParameter.Add(new parameter("OtherLastSchoolAttended", AdmissionProperties.OtherLastSchoolAttended));

        this.arrParameter.Add(new parameter("FatherName", AdmissionProperties.FatherName));
        this.arrParameter.Add(new parameter("Fathergraduationdegree", AdmissionProperties.Fathergraduationdegree));
        this.arrParameter.Add(new parameter("FatherPostGraduationDegree", AdmissionProperties.FatherPostGraduationDegree));
        this.arrParameter.Add(new parameter("FatherOccupation", AdmissionProperties.FatherOccupation));
        this.arrParameter.Add(new parameter("FatherOfficeAddress", AdmissionProperties.FatherOfficeAddress));
        this.arrParameter.Add(new parameter("FatherMobileNumber", AdmissionProperties.FatherMobileNumber));
        this.arrParameter.Add(new parameter("FatherEmailId", AdmissionProperties.FatherEmailId));
        this.arrParameter.Add(new parameter("FatherSchoolAttended", AdmissionProperties.FatherSchoolAttended));
        this.arrParameter.Add(new parameter("FatherCollegeAttended", AdmissionProperties.FatherCollegeAttended));

        this.arrParameter.Add(new parameter("MotherName", AdmissionProperties.MotherName));
        this.arrParameter.Add(new parameter("Mothergraduationdegree", AdmissionProperties.MotherGraduationDegree));
        this.arrParameter.Add(new parameter("MotherPostGraduationDegree", AdmissionProperties.MotherPostGraduationDegree));
        this.arrParameter.Add(new parameter("MotherOccupation", AdmissionProperties.MotherOccupation));
        this.arrParameter.Add(new parameter("MotherOfficeAddress", AdmissionProperties.MotherOfficeAddress));
        this.arrParameter.Add(new parameter("MotherMobileNumber", AdmissionProperties.MotherMobileNumber));
        this.arrParameter.Add(new parameter("ResidenceOrLandlineNumber", AdmissionProperties.ResidenceOrLandlineNumber));
        this.arrParameter.Add(new parameter("MotherEmailId", AdmissionProperties.MotherEmailId));
        this.arrParameter.Add(new parameter("MotherSchoolAttended", AdmissionProperties.MotherSchoolAttended));
        this.arrParameter.Add(new parameter("MotherCollegeAttended", AdmissionProperties.MotherCollegeAttended));

        this.arrParameter.Add(new parameter("MobileNumberForCommunication", AdmissionProperties.MobileNumberForCommunication));
        this.arrParameter.Add(new parameter("EmailIdForCommunication", AdmissionProperties.EmailIdForCommunication));

        this.arrParameter.Add(new parameter("Siblingname", AdmissionProperties.Siblingname));
        this.arrParameter.Add(new parameter("Siblingage", AdmissionProperties.Siblingage));
        this.arrParameter.Add(new parameter("Siblingschoolcollege", AdmissionProperties.Siblingschoolcollege));
        this.arrParameter.Add(new parameter("Siblingschoolcollegegrade", AdmissionProperties.Siblingschoolcollegegrade));
        this.arrParameter.Add(new parameter("Siblingschoolcollegedivision", AdmissionProperties.Siblingschoolcollegedivision));

        this.arrParameter.Add(new parameter("Siblingnamesecond", AdmissionProperties.Siblingnamesecond));
        this.arrParameter.Add(new parameter("Siblingagesecond", AdmissionProperties.Siblingagesecond));
        this.arrParameter.Add(new parameter("Siblingschoolcollegesecond", AdmissionProperties.Siblingschoolcollegesecond));
        this.arrParameter.Add(new parameter("Siblingschoolcollegegradesecond", AdmissionProperties.Siblingschoolcollegegradesecond));
        this.arrParameter.Add(new parameter("Siblingschoolcollegedivisionsecond", AdmissionProperties.Siblingschoolcollegedivisionsecond));

        this.arrParameter.Add(new parameter("MotherTongue", AdmissionProperties.MotherTongue));
        this.arrParameter.Add(new parameter("OtherLanguagesSpokenAtHome", AdmissionProperties.OtherLanguagesSpokenAtHome));
        this.arrParameter.Add(new parameter("IsNuclearOrJointFamily", AdmissionProperties.IsNuclearOrJointFamily));
        this.arrParameter.Add(new parameter("HowDoYouHearAboutAIS", AdmissionProperties.HowDoYouHearAboutAIS));
        this.arrParameter.Add(new parameter("OptionOfferedByAISafterGradeVII", AdmissionProperties.OptionOfferedByAISafterGradeVII));
        this.arrParameter.Add(new parameter("OptionOfferedByAISafterGradeX", AdmissionProperties.OptionOfferedByAISafterGradeX));
        this.arrParameter.Add(new parameter("ExamDay", AdmissionProperties.ExamDay));
        this.arrParameter.Add(new parameter("ExamTime", AdmissionProperties.ExamTime));
        this.arrParameter.Add(new parameter("MailBody", AdmissionProperties.MailBody));
        this.arrParameter.Add(new parameter("IsSendMailSuccess", AdmissionProperties.IsSendMailSuccess));
        this.arrParameter.Add(new parameter("FailiurReason", AdmissionProperties.FailiurReason));

        return this.oDataHelper.DAL_InsertWithOutParameter("Admission_Insert", this.arrParameter, OutParameter);
    }
    public DataSet Admission_ExamDays_SelectALL()
    {
        oDataHelper = new DataAccess();
        arrParameter = new ArrayList();

        return oDataHelper.DAL_Select("Admission_examdays_selectall", arrParameter);
    }
    public DataSet Admission_Select_interactionlist(AdmissionProperties oAdmission)
    {
        oDataHelper = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("AdmissionGrade", oAdmission.AdmissionGrade));

        return oDataHelper.DAL_Select("Admission_select_interactionlist", arrParameter);
    }
    public bool AdmissionInteraction_Insert(AdmissionInteraction AdmissionInteraction)
    {
        this.oDataHelper = new DataAccess();
        this.arrParameter = new ArrayList();

        this.arrParameter.Add(new parameter("AdmissionId", AdmissionInteraction.AdmissionId));
        this.arrParameter.Add(new parameter("InteractionDate", AdmissionInteraction.InteractionDate));
        this.arrParameter.Add(new parameter("InteractionTime", AdmissionInteraction.InteractionTime));
        this.arrParameter.Add(new parameter("MailFrom", AdmissionInteraction.MailFrom));
        this.arrParameter.Add(new parameter("MailTo", AdmissionInteraction.MailTo));
        this.arrParameter.Add(new parameter("MailSubject", AdmissionInteraction.MailSubject));
        this.arrParameter.Add(new parameter("MailBody", AdmissionInteraction.MailBody));
        this.arrParameter.Add(new parameter("IsSendSuccess", AdmissionInteraction.IsSendSuccess));
        this.arrParameter.Add(new parameter("FailureReasons", AdmissionInteraction.FailureReasons));
        this.arrParameter.Add(new parameter("CreatedBy", AdmissionInteraction.CreatedBy));

        return this.oDataHelper.DAL_InsertUpdateWithStatus("AdmissionInteraction_Insert", this.arrParameter);
    }
    public DataSet Admission_Select_admissionapprovallist(AdmissionProperties oAdmission)
    {
        oDataHelper = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("AdmissionGrade", oAdmission.AdmissionGrade));

        return oDataHelper.DAL_Select("Admission_Select_admissionapprovallist", arrParameter);
    }
    public bool AdmissionApproval_Insert(AdmissionApproval AdmissionApproval)
    {
        this.oDataHelper = new DataAccess();
        this.arrParameter = new ArrayList();

        this.arrParameter.Add(new parameter("AdmissionId", AdmissionApproval.AdmissionId));
        this.arrParameter.Add(new parameter("AdmissionStatus", AdmissionApproval.AdmissionStatus));
        this.arrParameter.Add(new parameter("Remarks", AdmissionApproval.Remarks));
        this.arrParameter.Add(new parameter("MailFrom", AdmissionApproval.MailFrom));
        this.arrParameter.Add(new parameter("MailTo", AdmissionApproval.MailTo));
        this.arrParameter.Add(new parameter("MailSubject", AdmissionApproval.MailSubject));
        this.arrParameter.Add(new parameter("MailBody", AdmissionApproval.MailBody));
        this.arrParameter.Add(new parameter("IsSendSuccess", AdmissionApproval.IsSendSuccess));
        this.arrParameter.Add(new parameter("FailureReasons", AdmissionApproval.FailureReasons));
        this.arrParameter.Add(new parameter("CreatedBy", AdmissionApproval.CreatedBy));

        return this.oDataHelper.DAL_InsertUpdateWithStatus("AdmissionApproval_Insert", this.arrParameter);
    }
    public DataSet Admission_ValidateAccesscode(string AccessCode)
    {
        oDataHelper = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("AccessCode", AccessCode));

        return oDataHelper.DAL_Select("Admission_validateaccesscode", arrParameter);
    }
    public DataSet Admission_getadmissiondetail_byreferenceno(string ReferenceNumber, string mobilenumber)
    {
        oDataHelper = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("ReferenceNumber", ReferenceNumber));
        arrParameter.Add(new parameter("MobileNumber", mobilenumber));

        return oDataHelper.DAL_Select("Admission_getadmissiondetail_byreferenceno", arrParameter);
    }
    public DataSet Admission_Select_AdmissionFeesAndDocument(string AdmissionGrade)
    {
        oDataHelper = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("AdmissionGrade", AdmissionGrade));

        return oDataHelper.DAL_Select("Admission_Select_admissionfeesanddocument", arrParameter);
    }
    public bool AdmissionFeesAndDocument_Insert(AdmissionFeesAndDocument AdmissionFeesAndDocument)
    {
        this.oDataHelper = new DataAccess();
        this.arrParameter = new ArrayList();

        this.arrParameter.Add(new parameter("AdmissionId", AdmissionFeesAndDocument.AdmissionId));
        this.arrParameter.Add(new parameter("Fees", AdmissionFeesAndDocument.Fees));
        this.arrParameter.Add(new parameter("BirthCertificate", AdmissionFeesAndDocument.BirthCertificate));
        this.arrParameter.Add(new parameter("AdmissionAcceptanceForm", AdmissionFeesAndDocument.AdmissionAcceptanceForm));
        this.arrParameter.Add(new parameter("ParentsTestimonials", AdmissionFeesAndDocument.ParentsTestimonials));
        this.arrParameter.Add(new parameter("SchoolLeavingCertificate", AdmissionFeesAndDocument.SchoolLeavingCertificate));
        this.arrParameter.Add(new parameter("BonafiedCertificate", AdmissionFeesAndDocument.BonafiedCertificate));
        this.arrParameter.Add(new parameter("CopyofPassport", AdmissionFeesAndDocument.CopyofPassport));
        this.arrParameter.Add(new parameter("ReferenceletterTC", AdmissionFeesAndDocument.ReferenceletterTC));
        this.arrParameter.Add(new parameter("AllComplate", AdmissionFeesAndDocument.AllComplate));
        this.arrParameter.Add(new parameter("CreatedBy", AdmissionFeesAndDocument.CreatedBy));

        return this.oDataHelper.DAL_InsertUpdateWithStatus("AdmissionFeesAndDocument_Insert", this.arrParameter);
    }
    public DataSet Admission_Select_GetDashboardCount(string Type)
    {
        oDataHelper = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("Type", Type));

        return oDataHelper.DAL_Select("Admission_Select_dashboardcount", arrParameter);
    }
    public DataSet Admission_Select_GetDashboardCountData(string Type, string AdmissionGrade)
    {
        oDataHelper = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("Type", Type));
        arrParameter.Add(new parameter("AdmissionGrade", AdmissionGrade));

        return oDataHelper.DAL_Select("Admission_Select_dashboardcountdata", arrParameter);
    }
    public DataSet Admission_Select_AdmissionFeesAndDocument_ByAdmissionId(string AdmissionId)
    {
        oDataHelper = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("AdmissionId", AdmissionId));

        return oDataHelper.DAL_Select("Admission_Select_admissionfeesanddocumentbyadmissionid", arrParameter);
    }
}


public class AdmissionProperties
{
    public AdmissionProperties()
    {
    }

    string admissionId;
    public string AdmissionId
    {
        get { return admissionId; }
        set { admissionId = value; }
    }

    string referenceNumber;
    public string ReferenceNumber
    {
        get { return referenceNumber; }
        set { referenceNumber = value; }
    }

    string admissionGrade;
    public string AdmissionGrade
    {
        get { return admissionGrade; }
        set { admissionGrade = value; }
    }

    string applicantType;
    public string ApplicantType
    {
        get { return applicantType; }
        set { applicantType = value; }
    }

    string accessCode;
    public string AccessCode
    {
        get { return accessCode; }
        set { accessCode = value; }
    }

    string formType;
    public string FormType
    {
        get { return formType; }
        set { formType = value; }
    }

    string choiceofBoard;
    public string ChoiceofBoard
    {
        get { return choiceofBoard; }
        set { choiceofBoard = value; }
    }

    string firstName;
    public string FirstName
    {
        get { return firstName; }
        set { firstName = value; }
    }

    string middleName;
    public string MiddleName
    {
        get { return middleName; }
        set { middleName = value; }
    }

    string lastName;
    public string LastName
    {
        get { return lastName; }
        set { lastName = value; }
    }

    string addressline1;
    public string Addressline1
    {
        get { return addressline1; }
        set { addressline1 = value; }
    }

    string addressline2;
    public string Addressline2
    {
        get { return addressline2; }
        set { addressline2 = value; }
    }

    string country;
    public string Country
    {
        get { return country; }
        set { country = value; }
    }

    string state;
    public string State
    {
        get { return state; }
        set { state = value; }
    }

    string city;
    public string City
    {
        get { return city; }
        set { city = value; }
    }

    string pincode;
    public string Pincode
    {
        get { return pincode; }
        set { pincode = value; }
    }

    Byte[] photo = null;
    public Byte[] Photo
    {
        get { return photo; }
        set { photo = value; }
    }

    string telephoneNo;
    public string TelephoneNo
    {
        get { return telephoneNo; }
        set { telephoneNo = value; }
    }

    string emergencyMobileNo;
    public string EmergencyMobileNo
    {
        get { return emergencyMobileNo; }
        set { emergencyMobileNo = value; }
    }

    string gender;
    public string Gender
    {
        get { return gender; }
        set { gender = value; }
    }

    string dateOfBirth;
    public string DateOfBirth
    {
        get { return dateOfBirth; }
        set { dateOfBirth = value; }
    }

    string placeOfBirth;
    public string PlaceOfBirth
    {
        get { return placeOfBirth; }
        set { placeOfBirth = value; }
    }

    string nationality;
    public string Nationality
    {
        get { return nationality; }
        set { nationality = value; }
    }

    string otherNationality;
    public string OtherNationality
    {
        get { return otherNationality; }
        set { otherNationality = value; }
    }

    string passportNumber;
    public string PassportNumber
    {
        get { return passportNumber; }
        set { passportNumber = value; }
    }

    string caste;
    public string Caste
    {
        get { return caste; }
        set { caste = value; }
    }

    string lastSchoolAttended;
    public string LastSchoolAttended
    {
        get { return lastSchoolAttended; }
        set { lastSchoolAttended = value; }
    }

    string otherLastSchoolAttended;
    public string OtherLastSchoolAttended
    {
        get { return otherLastSchoolAttended; }
        set { otherLastSchoolAttended = value; }
    }

    string fatherName;
    public string FatherName
    {
        get { return fatherName; }
        set { fatherName = value; }
    }

    string fatherGraduationDegree;
    public string Fathergraduationdegree
    {
        get { return fatherGraduationDegree; }
        set { fatherGraduationDegree = value; }
    }

    string fatherPostGraduationDegree;
    public string FatherPostGraduationDegree
    {
        get { return fatherPostGraduationDegree; }
        set { fatherPostGraduationDegree = value; }
    }

    string fatherOccupation;
    public string FatherOccupation
    {
        get { return fatherOccupation; }
        set { fatherOccupation = value; }
    }

    string fatherOfficeAddress;
    public string FatherOfficeAddress
    {
        get { return fatherOfficeAddress; }
        set { fatherOfficeAddress = value; }
    }

    string fatherMobileNumber;
    public string FatherMobileNumber
    {
        get { return fatherMobileNumber; }
        set { fatherMobileNumber = value; }
    }

    string fatherEmailId;
    public string FatherEmailId
    {
        get { return fatherEmailId; }
        set { fatherEmailId = value; }
    }

    string fatherSchoolAttended;
    public string FatherSchoolAttended
    {
        get { return fatherSchoolAttended; }
        set { fatherSchoolAttended = value; }
    }

    string fatherCollegeAttended;
    public string FatherCollegeAttended
    {
        get { return fatherCollegeAttended; }
        set { fatherCollegeAttended = value; }
    }

    string motherName;
    public string MotherName
    {
        get { return motherName; }
        set { motherName = value; }
    }

    string motherGraduationDegree;
    public string MotherGraduationDegree
    {
        get { return motherGraduationDegree; }
        set { motherGraduationDegree = value; }
    }

    string motherPostGraduationDegree;
    public string MotherPostGraduationDegree
    {
        get { return motherPostGraduationDegree; }
        set { motherPostGraduationDegree = value; }
    }

    string motherOccupation;
    public string MotherOccupation
    {
        get { return motherOccupation; }
        set { motherOccupation = value; }
    }

    string motherOfficeAddress;
    public string MotherOfficeAddress
    {
        get { return motherOfficeAddress; }
        set { motherOfficeAddress = value; }
    }

    string motherMobileNumber;
    public string MotherMobileNumber
    {
        get { return motherMobileNumber; }
        set { motherMobileNumber = value; }
    }

    string residenceOrLandlineNumber;
    public string ResidenceOrLandlineNumber
    {
        get { return residenceOrLandlineNumber; }
        set { residenceOrLandlineNumber = value; }
    }

    string motherEmailId;
    public string MotherEmailId
    {
        get { return motherEmailId; }
        set { motherEmailId = value; }
    }

    string motherSchoolAttended;
    public string MotherSchoolAttended
    {
        get { return motherSchoolAttended; }
        set { motherSchoolAttended = value; }
    }

    string motherCollegeAttended;
    public string MotherCollegeAttended
    {
        get { return motherCollegeAttended; }
        set { motherCollegeAttended = value; }
    }

    string mobileNumberForCommunication;
    public string MobileNumberForCommunication
    {
        get { return mobileNumberForCommunication; }
        set { mobileNumberForCommunication = value; }
    }

    string emailIdForCommunication;
    public string EmailIdForCommunication
    {
        get { return emailIdForCommunication; }
        set { emailIdForCommunication = value; }
    }

    string siblingname;
    public string Siblingname
    {
        get { return siblingname; }
        set { siblingname = value; }
    }

    string siblingage;
    public string Siblingage
    {
        get { return siblingage; }
        set { siblingage = value; }
    }

    string siblingschoolcollege;
    public string Siblingschoolcollege
    {
        get { return siblingschoolcollege; }
        set { siblingschoolcollege = value; }
    }

    string siblingschoolcollegegrade;
    public string Siblingschoolcollegegrade
    {
        get { return siblingschoolcollegegrade; }
        set { siblingschoolcollegegrade = value; }
    }

    string siblingschoolcollegedivision;
    public string Siblingschoolcollegedivision
    {
        get { return siblingschoolcollegedivision; }
        set { siblingschoolcollegedivision = value; }
    }

    string siblingnamesecond;
    public string Siblingnamesecond
    {
        get { return siblingnamesecond; }
        set { siblingnamesecond = value; }
    }

    string siblingagesecond;
    public string Siblingagesecond
    {
        get { return siblingagesecond; }
        set { siblingagesecond = value; }
    }

    string siblingschoolcollegesecond;
    public string Siblingschoolcollegesecond
    {
        get { return siblingschoolcollegesecond; }
        set { siblingschoolcollegesecond = value; }
    }

    string siblingschoolcollegegradesecond;
    public string Siblingschoolcollegegradesecond
    {
        get { return siblingschoolcollegegradesecond; }
        set { siblingschoolcollegegradesecond = value; }
    }

    string siblingschoolcollegedivisionsecond;
    public string Siblingschoolcollegedivisionsecond
    {
        get { return siblingschoolcollegedivisionsecond; }
        set { siblingschoolcollegedivisionsecond = value; }
    }

    string motherTongue;
    public string MotherTongue
    {
        get { return motherTongue; }
        set { motherTongue = value; }
    }

    string otherLanguagesSpokenAtHome;
    public string OtherLanguagesSpokenAtHome
    {
        get { return otherLanguagesSpokenAtHome; }
        set { otherLanguagesSpokenAtHome = value; }
    }

    string isNuclearOrJointFamily;
    public string IsNuclearOrJointFamily
    {
        get { return isNuclearOrJointFamily; }
        set { isNuclearOrJointFamily = value; }
    }

    string howDoYouHearAboutAIS;
    public string HowDoYouHearAboutAIS
    {
        get { return howDoYouHearAboutAIS; }
        set { howDoYouHearAboutAIS = value; }
    }

    string optionOfferedByAISafterGradeVII;
    public string OptionOfferedByAISafterGradeVII
    {
        get { return optionOfferedByAISafterGradeVII; }
        set { optionOfferedByAISafterGradeVII = value; }
    }

    string optionOfferedByAISafterGradeX;
    public string OptionOfferedByAISafterGradeX
    {
        get { return optionOfferedByAISafterGradeX; }
        set { optionOfferedByAISafterGradeX = value; }
    }

    string examDay;
    public string ExamDay
    {
        get { return examDay; }
        set { examDay = value; }
    }

    string examTime;
    public string ExamTime
    {
        get { return examTime; }
        set { examTime = value; }
    }

    string mailBody;
    public string MailBody
    {
        get { return mailBody; }
        set { mailBody = value; }
    }

    public bool isSendMailSuccess = false;
    public bool IsSendMailSuccess
    {
        get { return isSendMailSuccess; }
        set { isSendMailSuccess = value; }
    }

    string failiurReason;
    public string FailiurReason
    {
        get { return failiurReason; }
        set { failiurReason = value; }
    }
}
public class AdmissionInteraction
{
    string admissionId;
    public string AdmissionId
    {
        get { return admissionId; }
        set { admissionId = value; }
    }

    string interactionDate;
    public string InteractionDate
    {
        get { return interactionDate; }
        set { interactionDate = value; }
    }

    string interactionTime;
    public string InteractionTime
    {
        get { return interactionTime; }
        set { interactionTime = value; }
    }

    string mailFrom;
    public string MailFrom
    {
        get { return mailFrom; }
        set { mailFrom = value; }
    }

    string mailTo;
    public string MailTo
    {
        get { return mailTo; }
        set { mailTo = value; }
    }

    string mailSubject;
    public string MailSubject
    {
        get { return mailSubject; }
        set { mailSubject = value; }
    }

    string mailBody;
    public string MailBody
    {
        get { return mailBody; }
        set { mailBody = value; }
    }

    bool isSendSuccess = false;
    public bool IsSendSuccess
    {
        get { return isSendSuccess; }
        set { isSendSuccess = value; }
    }

    string failureReasons;
    public string FailureReasons
    {
        get { return failureReasons; }
        set { failureReasons = value; }
    }

    string createdBy;
    public string CreatedBy
    {
        get { return createdBy; }
        set { createdBy = value; }
    }
}
public class AdmissionApproval
{
    string admissionId;
    public string AdmissionId
    {
        get { return admissionId; }
        set { admissionId = value; }
    }

    string admissionStatus;
    public string AdmissionStatus
    {
        get { return admissionStatus; }
        set { admissionStatus = value; }
    }

    string remarks;
    public string Remarks
    {
        get { return remarks; }
        set { remarks = value; }
    }

    string mailFrom;
    public string MailFrom
    {
        get { return mailFrom; }
        set { mailFrom = value; }
    }

    string mailTo;
    public string MailTo
    {
        get { return mailTo; }
        set { mailTo = value; }
    }

    string mailSubject;
    public string MailSubject
    {
        get { return mailSubject; }
        set { mailSubject = value; }
    }

    string mailBody;
    public string MailBody
    {
        get { return mailBody; }
        set { mailBody = value; }
    }

    bool isSendSuccess = false;
    public bool IsSendSuccess
    {
        get { return isSendSuccess; }
        set { isSendSuccess = value; }
    }

    string failureReasons;
    public string FailureReasons
    {
        get { return failureReasons; }
        set { failureReasons = value; }
    }

    string createdBy;
    public string CreatedBy
    {
        get { return createdBy; }
        set { createdBy = value; }
    }
}
public class AdmissionFeesAndDocument
{
    string admissionId;
    public string AdmissionId
    {
        get { return admissionId; }
        set { admissionId = value; }
    }

    bool fees = false;
    public bool Fees
    {
        get { return fees; }
        set { fees = value; }
    }

    bool birthCertificate = false;
    public bool BirthCertificate
    {
        get { return birthCertificate; }
        set { birthCertificate = value; }
    }

    bool admissionAcceptanceForm = false;
    public bool AdmissionAcceptanceForm
    {
        get { return admissionAcceptanceForm; }
        set { admissionAcceptanceForm = value; }
    }

    bool parentsTestimonials = false;
    public bool ParentsTestimonials
    {
        get { return parentsTestimonials; }
        set { parentsTestimonials = value; }
    }

    bool bonafiedCertificate = false;
    public bool BonafiedCertificate
    {
        get { return bonafiedCertificate; }
        set { bonafiedCertificate = value; }
    }

    bool schoolLeavingCertificate = false;
    public bool SchoolLeavingCertificate
    {
        get { return schoolLeavingCertificate; }
        set { schoolLeavingCertificate = value; }
    }

    bool referenceletterTC = false;
    public bool ReferenceletterTC
    {
        get { return referenceletterTC; }
        set { referenceletterTC = value; }
    }

    bool copyofPassport = false;
    public bool CopyofPassport
    {
        get { return copyofPassport; }
        set { copyofPassport = value; }
    }

    bool allComplate = false;
    public bool AllComplate
    {
        get { return allComplate; }
        set { allComplate = value; }
    }

    string createdBy;
    public string CreatedBy
    {
        get { return createdBy; }
        set { createdBy = value; }
    }

    string updatedBy;
    public string UpdatedBy
    {
        get { return updatedBy; }
        set { updatedBy = value; }
    }
}