using System;

/// <summary>
/// Admission related properties
/// </summary>
public class Admission
{
    /// <summary>
    /// Add constructor logic here
    /// </summary>
    public Admission()
    {
    }

    /// <summary>
    /// AdmissionId Auto increment number.
    /// </summary>
    string admissionId;
    public string AdmissionId
    {
        get { return admissionId; }
        set { admissionId = value; }
    }

    /// <summary>
    /// School identification number.
    /// </summary>
    string schoolId;
    public string SchoolId
    {
        get { return schoolId; }
        set { schoolId = value; }
    }

    /// <summary>
    /// Unique identification number of Each Form.
    /// </summary>
    string formNo;
    public string FormNo
    {
        get { return formNo; }
        set { formNo = value; }
    }

    /// <summary>
    /// Admission Grade contain value of BMSID.
    /// </summary>
    string admissionGrade;
    public string AdmissionGrade
    {
        get { return admissionGrade; }
        set { admissionGrade = value; }
    }

    /// <summary>
    /// First Name of Student.
    /// </summary>
    string firstName;
    public string FirstName
    {
        get { return firstName; }
        set { firstName = value; }
    }

    /// <summary>
    /// Middle Name of Student.
    /// </summary>
    string middleName;
    public string MiddleName
    {
        get { return middleName; }
        set { middleName = value; }
    }

    /// <summary>
    /// Last Name of Student.
    /// </summary>
    string lastName;
    public string LastName
    {
        get { return lastName; }
        set { lastName = value; }
    }

    /// <summary>
    /// The address at which a person or business receives letters or packages.
    /// </summary>
    string mailingAddress;
    public string MailingAddress
    {
        get { return mailingAddress; }
        set { mailingAddress = value; }
    }

    /// <summary>
    /// Student photo.
    /// </summary>
    Byte[] photo = null;
    public Byte[] Photo
    {
        get { return photo; }
        set { photo = value; }
    }

    /// <summary>
    /// Telephone number with maximum 13 number.
    /// </summary>
    string telephoneNo;
    public string TelephoneNo
    {
        get { return telephoneNo; }
        set { telephoneNo = value; }
    }

    /// <summary>
    /// Mobile number with maximum 11 number.
    /// </summary>
    string emergencyMobileNo;
    public string EmergencyMobileNo
    {
        get { return emergencyMobileNo; }
        set { emergencyMobileNo = value; }
    }

    /// <summary>
    /// Student's Communication-Email ID.
    /// </summary>
    string communicationemail;
    public string CommunicationEmailId
    {
        get { return communicationemail; }
        set { communicationemail = value; }
    }


    /// <summary>
    /// Student Gender.
    /// </summary>
    string gender;
    public string Gender
    {
        get { return gender; }
        set { gender = value; }
    }

    /// <summary>
    /// Student DateOfBirth.
    /// </summary>
    string dateOfBirth;
    public string DateOfBirth
    {
        get { return dateOfBirth; }
        set { dateOfBirth = value; }
    }

    /// <summary>
    /// Student Place of birth.
    /// </summary>
    string placeOfBirth;
    public string PlaceOfBirth
    {
        get { return placeOfBirth; }
        set { placeOfBirth = value; }
    }

    /// <summary>
    /// Student Nationality.
    /// </summary>
    string nationality;
    public string Nationality
    {
        get { return nationality; }
        set { nationality = value; }
    }

    /// <summary>
    /// Student Religion.
    /// </summary>
    string religion;
    public string Religion
    {
        get { return religion; }
        set { religion = value; }
    }

    /// <summary>
    /// Stduent Caste.
    /// </summary>
    string caste;
    public string Caste
    {
        get { return caste; }
        set { caste = value; }
    }

    /// <summary>
    /// Student Subcaste.
    /// </summary>
    string subCaste;
    public string SubCaste
    {
        get { return subCaste; }
        set { subCaste = value; }
    }

    /// <summary>
    /// Name of student's previous school.
    /// </summary>
    string lastSchoolAttended;
    public string LastSchoolAttended
    {
        get { return lastSchoolAttended; }
        set { lastSchoolAttended = value; }
    }

    /// <summary>
    /// Student's Father Name.
    /// </summary>
    string fatherName;
    public string FatherName
    {
        get { return fatherName; }
        set { fatherName = value; }
    }

    /// <summary>
    /// Student's Father highest qualification.
    /// </summary>
    string fatherEducation;
    public string FatherEducation
    {
        get { return fatherEducation; }
        set { fatherEducation = value; }
    }

    /// <summary>
    /// Student's Father Occupation.
    /// </summary>
    string fatherOccupation;
    public string FatherOccupation
    {
        get { return fatherOccupation; }
        set { fatherOccupation = value; }
    }

    /// <summary>
    /// Student's Father office address.
    /// </summary>
    string fatherOfficeAddress;
    public string FatherOfficeAddress
    {
        get { return fatherOfficeAddress; }
        set { fatherOfficeAddress = value; }
    }

    /// <summary>
    /// Student's Father Telephone number with maximum 13 number.
    /// </summary>
    string fatherTelephoneNo;
    public string FatherTelephoneNo
    {
        get { return fatherTelephoneNo; }
        set { fatherTelephoneNo = value; }
    }

    /// <summary>
    /// Student's Father Mobile number with maximum 11 number.
    /// </summary>
    string fatherMobileNo;
    public string FatherMobileNo
    {
        get { return fatherMobileNo; }
        set { fatherMobileNo = value; }
    }

    /// <summary>
    /// Student's Father-Email ID.
    /// </summary>
    string fatherEmailId;
    public string FatherEmailId
    {
        get { return fatherEmailId; }
        set { fatherEmailId = value; }
    }

    /// <summary>
    /// Student's Mother Name.
    /// </summary>
    string motherName;
    public string MotherName
    {
        get { return motherName; }
        set { motherName = value; }
    }

    /// <summary>
    /// Student's Mother highest qualification.
    /// </summary>
    string motherEducation;
    public string MotherEducation
    {
        get { return motherEducation; }
        set { motherEducation = value; }
    }

    /// <summary>
    /// Student's mother occupation.
    /// </summary>
    string motherOccupation;
    public string MotherOccupation
    {
        get { return motherOccupation; }
        set { motherOccupation = value; }
    }

    /// <summary>
    /// Student's mother office address.
    /// </summary>
    string motherOfficeAddress;
    public string MotherOfficeAddress
    {
        get { return motherOfficeAddress; }
        set { motherOfficeAddress = value; }
    }

    /// <summary>
    /// Student's mother telephone number with maximum 13 number.
    /// </summary>
    string motherTelephoneNo;
    public string MotherTelephoneNo
    {
        get { return motherTelephoneNo; }
        set { motherTelephoneNo = value; }
    }

    /// <summary>
    /// Student's mother mobile number with maximum 11 number.
    /// </summary>
    string motherMobileNo;
    public string MotherMobileNo
    {
        get { return motherMobileNo; }
        set { motherMobileNo = value; }
    }

    /// <summary>
    /// Student's mother email id.
    /// </summary>
    string motherEmailId;
    public string MotherEmailId
    {
        get { return motherEmailId; }
        set { motherEmailId = value; }
    }

    /// <summary>
    /// Mother tongue.
    /// </summary>
    string motherTongue;
    public string MotherTongue
    {
        get { return motherTongue; }
        set { motherTongue = value; }
    }

    /// <summary>
    /// Other languages spoken at home.
    /// </summary>
    string otherLanguages;
    public string OtherLanguages
    {
        get { return otherLanguages; }
        set { otherLanguages = value; }
    }

    /// <summary>
    /// Are you a nuclear family or a joint family.
    /// </summary>
    string isNuclearorJointFamily;
    public string IsNuclearorJointFamily
    {
        get { return isNuclearorJointFamily; }
        set { isNuclearorJointFamily = value; }
    }

    /// <summary>
    /// How did you hear about AIS.
    /// </summary>
    string howDoYouHearAboutAIS;
    public string HowDoYouHearAboutAIS
    {
        get { return howDoYouHearAboutAIS; }
        set { howDoYouHearAboutAIS = value; }
    }

    /// <summary>
    /// Current status of admission.
    /// </summary>
    string lastAdmissionStatus;
    public string LastAdmissionStatus
    {
        get { return lastAdmissionStatus; }
        set { lastAdmissionStatus = value; }
    }

    /// <summary>
    /// Date on which record created.
    /// </summary>
    DateTime? createdOn;
    public DateTime? CreatedOn
    {
        get { return createdOn; }
        set { createdOn = value; }
    }

    /// <summary>
    /// Unique identification number of user who modify record.
    /// </summary>
    string createdBy;
    public string CreatedBy
    {
        get { return createdBy; }
        set { createdBy = value; }
    }

    /// <summary>
    /// Date on which record modify.
    /// </summary>
    DateTime? modifiedOn;
    public DateTime? ModifiedOn
    {
        get { return modifiedOn; }
        set { modifiedOn = value; }
    }

    /// <summary>
    /// Unique identification number of user who modify record.
    /// </summary>
    string modifiedBy;
    public string ModifiedBy
    {
        get { return modifiedBy; }
        set { modifiedBy = value; }
    }
}

/// <summary>
/// Admission Interaction Slip related properties
/// </summary>
public class AdmissionPipeline
{
    /// <summary>
    /// AdmissionId of student for whom interaction slip generated.
    /// </summary>
    string admissionId;
    public string AdmissionId
    {
        get { return admissionId; }
        set { admissionId = value; }
    }

    /// <summary>
    /// School identification number.
    /// </summary>
    string schoolId;
    public string SchoolId
    {
        get { return schoolId; }
        set { schoolId = value; }
    }

    /// <summary>
    /// Admission Status of student like interaction,confirm,onhold,rejected.
    /// </summary>
    string admissionStatus;
    public string AdmissionStatus
    {
        get { return admissionStatus; }
        set { admissionStatus = value; }
    }

    /// <summary>
    /// interactionTime Ex: 18-Aug-2015 10:30 AM. 
    /// </summary>
    string interactionTime;
    public string InteractionTime
    {
        get { return interactionTime; }
        set { interactionTime = value; }
    }

    /// <summary>
    /// feedBack at the time of admission status change.
    /// </summary>
    string feedBack;
    public string FeedBack
    {
        get { return feedBack; }
        set { feedBack = value; }
    }

    /// <summary>
    /// Remarks at the time of admission status change.
    /// </summary>
    string remarks;
    public string Remarks
    {
        get { return remarks; }
        set { remarks = value; }
    }

    /// <summary>
    /// number of document generated.
    /// </summary>
    string generatedDocumentCount;
    public string GeneratedDocumentCount
    {
        get { return generatedDocumentCount; }
        set { generatedDocumentCount = value; }
    }

    /// <summary>
    /// Mail From Address.
    /// </summary>
    string mailFrom;
    public string MailFrom
    {
        get { return mailFrom; }
        set { mailFrom = value; }
    }

    /// <summary>
    /// On which Address mail send.
    /// </summary>
    string mailTo;
    public string MailTo
    {
        get { return mailTo; }
        set { mailTo = value; }
    }

    /// <summary>
    /// Mail Subject.
    /// </summary>
    string mailSubject;
    public string MailSubject
    {
        get { return mailSubject; }
        set { mailSubject = value; }
    }

    /// <summary>
    /// Mail Body.
    /// </summary>
    string mailBody;
    public string MailBody
    {
        get { return mailBody; }
        set { mailBody = value; }
    }

    /// <summary>
    /// list of attachment with ; seprate.
    /// </summary>
    string mailDocument;
    public string MailDocument
    {
        get { return mailDocument; }
        set { mailDocument = value; }
    }

    /// <summary>
    /// Mail Send Status.
    /// </summary>
    bool isSendSuccess = false;
    public bool IsSendSuccess
    {
        get { return isSendSuccess; }
        set { isSendSuccess = value; }
    }

    /// <summary>
    /// Reason if mail send fail.
    /// </summary>
    string failureReasons;
    public string FailureReasons
    {
        get { return failureReasons; }
        set { failureReasons = value; }
    }

    /// <summary>
    /// Unique identification number of user who create record.
    /// </summary>
    string createdBy;
    public string CreatedBy
    {
        get { return createdBy; }
        set { createdBy = value; }
    }
}
