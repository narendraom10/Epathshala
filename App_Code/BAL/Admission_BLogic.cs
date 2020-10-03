using System.Collections;
using System.Data;
using System;

/// <summary>
/// Admission related method.
/// </summary>
public class Admission_BLogic
{
    DataAccess oDataHelper;
    ArrayList arrParameter;
    public Admission_BLogic()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    /// <summary>
    /// Insert new record in Admission table.
    /// </summary>
    /// <param name="Admission">Admission properties class</param>
    /// <returns>Insert ststus(true or false)</returns>
    public bool Admission_Insert(Admission Admission)
    {
        this.oDataHelper = new DataAccess();
        this.arrParameter = new ArrayList();

        this.arrParameter.Add(new parameter("FormNo", Admission.FormNo));
        this.arrParameter.Add(new parameter("AdmissionGrade", Admission.AdmissionGrade));
        this.arrParameter.Add(new parameter("FirstName", Admission.FirstName));
        this.arrParameter.Add(new parameter("MiddleName", Admission.MiddleName));
        this.arrParameter.Add(new parameter("LastName", Admission.LastName));
        this.arrParameter.Add(new parameter("MailingAddress", Admission.MailingAddress));
        this.arrParameter.Add(new parameter("Photo", Admission.Photo));
        this.arrParameter.Add(new parameter("TelephoneNo", Admission.TelephoneNo));
        this.arrParameter.Add(new parameter("EmergencyMobileNo", Admission.EmergencyMobileNo));
        this.arrParameter.Add(new parameter("CommunicationMail", Admission.CommunicationEmailId));//
        this.arrParameter.Add(new parameter("Gender", Admission.Gender));
        this.arrParameter.Add(new parameter("DateOfBirth", Admission.DateOfBirth));
        this.arrParameter.Add(new parameter("PlaceOfBirth", Admission.PlaceOfBirth));
        this.arrParameter.Add(new parameter("Nationality", Admission.Nationality));
        this.arrParameter.Add(new parameter("Religion", Admission.Religion));
        this.arrParameter.Add(new parameter("Caste", Admission.Caste));
        this.arrParameter.Add(new parameter("SubCaste", Admission.SubCaste));
        this.arrParameter.Add(new parameter("LastSchoolAttended", Admission.LastSchoolAttended));
        this.arrParameter.Add(new parameter("FatherName", Admission.FatherName));
        this.arrParameter.Add(new parameter("FatherEducation", Admission.FatherEducation));
        this.arrParameter.Add(new parameter("FatherOccupation", Admission.FatherOccupation));
        this.arrParameter.Add(new parameter("FatherOfficeAddress", Admission.FatherOfficeAddress));
        this.arrParameter.Add(new parameter("FatherTelephoneNo", Admission.FatherTelephoneNo));
        this.arrParameter.Add(new parameter("FatherMobileNo", Admission.FatherMobileNo));
        this.arrParameter.Add(new parameter("FatherEmailId", Admission.FatherEmailId));
        this.arrParameter.Add(new parameter("MotherName", Admission.MotherName));
        this.arrParameter.Add(new parameter("MotherEducation", Admission.MotherEducation));
        this.arrParameter.Add(new parameter("MotherOccupation", Admission.MotherOccupation));
        this.arrParameter.Add(new parameter("MotherOfficeAddress", Admission.MotherOfficeAddress));
        this.arrParameter.Add(new parameter("MotherTelephoneNo", Admission.MotherTelephoneNo));
        this.arrParameter.Add(new parameter("MotherMobileNo", Admission.MotherMobileNo));
        this.arrParameter.Add(new parameter("MotherEmailId", Admission.MotherEmailId));
        this.arrParameter.Add(new parameter("MotherTongue", Admission.MotherTongue));
        this.arrParameter.Add(new parameter("OtherLanguages", Admission.OtherLanguages));
        this.arrParameter.Add(new parameter("IsNuclearorJointFamily", Admission.IsNuclearorJointFamily));
        this.arrParameter.Add(new parameter("HowdoyouhearAboutAIS", Admission.HowDoYouHearAboutAIS));
        this.arrParameter.Add(new parameter("CreatedBy", Admission.CreatedBy));
        this.arrParameter.Add(new parameter("SchoolId", Admission.SchoolId));

        return this.oDataHelper.DAL_InsertUpdateWithStatus("Admission_Insert", this.arrParameter);
    }

    /// <summary>
    /// Update existing Admission Details
    /// </summary>
    /// <param name="Admission">Admission properties class</param>
    /// <returns>Update status(true or false)</returns>
    public bool Admission_Update(Admission Admission)
    {
        this.oDataHelper = new DataAccess();
        this.arrParameter = new ArrayList();
        this.arrParameter.Add(new parameter("AdmissionId", Admission.AdmissionId));
        this.arrParameter.Add(new parameter("FormNo", Admission.FormNo));
        this.arrParameter.Add(new parameter("AdmissionGrade", Admission.AdmissionGrade));
        this.arrParameter.Add(new parameter("FirstName", Admission.FirstName));
        this.arrParameter.Add(new parameter("MiddleName", Admission.MiddleName));
        this.arrParameter.Add(new parameter("LastName", Admission.LastName));
        this.arrParameter.Add(new parameter("MailingAddress", Admission.MailingAddress));
        this.arrParameter.Add(new parameter("Photo", Admission.Photo));
        this.arrParameter.Add(new parameter("TelephoneNo", Admission.TelephoneNo));
        this.arrParameter.Add(new parameter("EmergencyMobileNo", Admission.EmergencyMobileNo));
        this.arrParameter.Add(new parameter("CommunicationMail", Admission.CommunicationEmailId));//
        this.arrParameter.Add(new parameter("Gender", Admission.Gender));
        this.arrParameter.Add(new parameter("DateOfBirth", Admission.DateOfBirth));
        this.arrParameter.Add(new parameter("PlaceOfBirth", Admission.PlaceOfBirth));
        this.arrParameter.Add(new parameter("Nationality", Admission.Nationality));
        this.arrParameter.Add(new parameter("Religion", Admission.Religion));
        this.arrParameter.Add(new parameter("Caste", Admission.Caste));
        this.arrParameter.Add(new parameter("SubCaste", Admission.SubCaste));
        this.arrParameter.Add(new parameter("LastSchoolAttended", Admission.LastSchoolAttended));
        this.arrParameter.Add(new parameter("FatherName", Admission.FatherName));
        this.arrParameter.Add(new parameter("FatherEducation", Admission.FatherEducation));
        this.arrParameter.Add(new parameter("FatherOccupation", Admission.FatherOccupation));
        this.arrParameter.Add(new parameter("FatherOfficeAddress", Admission.FatherOfficeAddress));
        this.arrParameter.Add(new parameter("FatherTelephoneNo", Admission.FatherTelephoneNo));
        this.arrParameter.Add(new parameter("FatherMobileNo", Admission.FatherMobileNo));
        this.arrParameter.Add(new parameter("FatherEmailId", Admission.FatherEmailId));
        this.arrParameter.Add(new parameter("MotherName", Admission.MotherName));
        this.arrParameter.Add(new parameter("MotherEducation", Admission.MotherEducation));
        this.arrParameter.Add(new parameter("MotherOccupation", Admission.MotherOccupation));
        this.arrParameter.Add(new parameter("MotherOfficeAddress", Admission.MotherOfficeAddress));
        this.arrParameter.Add(new parameter("MotherTelephoneNo", Admission.MotherTelephoneNo));
        this.arrParameter.Add(new parameter("MotherMobileNo", Admission.MotherMobileNo));
        this.arrParameter.Add(new parameter("MotherEmailId", Admission.MotherEmailId));
        this.arrParameter.Add(new parameter("MotherTongue", Admission.MotherTongue));
        this.arrParameter.Add(new parameter("OtherLanguages", Admission.OtherLanguages));
        this.arrParameter.Add(new parameter("IsNuclearorJointFamily", Admission.IsNuclearorJointFamily));
        this.arrParameter.Add(new parameter("HowdoyouhearAboutAIS", Admission.HowDoYouHearAboutAIS));
        this.arrParameter.Add(new parameter("CreatedBy", Admission.CreatedBy));

        return this.oDataHelper.DAL_InsertUpdateWithStatus("Admission_Update", this.arrParameter);
    }

    /// <summary>
    /// To insert Sibling details for the Admission
    /// </summary>
    /// <returns></returns>
    public bool Admission_Sibling_Insert(string InsString)
    {
        this.oDataHelper = new DataAccess();
        this.arrParameter = new ArrayList();

        this.arrParameter.Add(new parameter("InsertString", InsString));
        return this.oDataHelper.DAL_InsertUpdateWithStatus("Admission_Sibling_Insert", this.arrParameter);
    }

    /// <summary>
    /// To insert Details of Attached Admission Documents.
    /// </summary>
    /// <returns></returns>
    public bool Admission_Documents_Insert(string InsString)
    {
        this.oDataHelper = new DataAccess();
        this.arrParameter = new ArrayList();

        this.arrParameter.Add(new parameter("InsertString", InsString));
        return this.oDataHelper.DAL_InsertUpdateWithStatus("Admission_AttachedDocuments_Insert", this.arrParameter);
    }

    /// <summary>
    /// Select all row from admission table
    /// </summary>
    /// <param name="Admission"></param>
    /// <returns></returns>
    public DataSet Admission_Select_All(Admission Admission)
    {
        oDataHelper = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("LastAdmissionStatus", Admission.LastAdmissionStatus));
        arrParameter.Add(new parameter("schoolid", AppSessions.SchoolID));

        return oDataHelper.DAL_Select("Admission_Select_All", arrParameter);
    }

    public DataSet Admission_Select_ByAdmissionId(Admission Admission)
    {
        oDataHelper = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("AdmissionId", Admission.AdmissionId));

        return oDataHelper.DAL_Select("Admission_Select_ByAdmissionId", arrParameter);
    }

    public DataSet Admission_Select_ByInteraction(DateTime StartDate, DateTime EndDate)
    {
        oDataHelper = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("StartDate", StartDate));
        arrParameter.Add(new parameter("EndDate", EndDate));

        return oDataHelper.DAL_Select("Admission_Select_ByInteraction", arrParameter);
    }

    public DataSet AdmissionTagMaster_Select_All()
    {
        oDataHelper = new DataAccess();
        arrParameter = new ArrayList();

        return oDataHelper.DAL_Select("AdmissionTagMaster_Select_All", arrParameter);
    }

    /// <summary>
    /// To Get Last Inserted Admission ID (Useful in Sibling Details and Document Attached Details reference)
    /// </summary>
    /// <returns></returns>
    public DataSet GetLastAdmissionId()
    {

        oDataHelper = new DataAccess();
        arrParameter = new ArrayList();

        return oDataHelper.DAL_Select("Admission_SelectMaxAdmissionId", arrParameter);

    }

    /// <summary>
    /// Insert new record in AdmissionPipeline table.
    /// </summary>
    /// <param name="Admission">AdmissionPipeline properties class</param>
    /// <returns>Insert ststus(true or false)</returns>
    public bool AdmissionPipeline_Insert(AdmissionPipeline AdmissionPipeline)
    {
        this.oDataHelper = new DataAccess();
        this.arrParameter = new ArrayList();

        this.arrParameter.Add(new parameter("AdmissionId", AdmissionPipeline.AdmissionId));
        this.arrParameter.Add(new parameter("AdmissionStatus", AdmissionPipeline.AdmissionStatus));
        this.arrParameter.Add(new parameter("InteractionTime", AdmissionPipeline.InteractionTime));
        this.arrParameter.Add(new parameter("FeedBack", AdmissionPipeline.FeedBack));
        this.arrParameter.Add(new parameter("Remarks", AdmissionPipeline.Remarks));
        this.arrParameter.Add(new parameter("GeneratedDocumentCount", AdmissionPipeline.GeneratedDocumentCount));
        this.arrParameter.Add(new parameter("MailFrom", AdmissionPipeline.MailFrom));
        this.arrParameter.Add(new parameter("MailTo", AdmissionPipeline.MailTo));
        this.arrParameter.Add(new parameter("MailSubject", AdmissionPipeline.MailSubject));
        this.arrParameter.Add(new parameter("MailBody", AdmissionPipeline.MailBody));
        this.arrParameter.Add(new parameter("MailDocument", AdmissionPipeline.MailDocument));
        this.arrParameter.Add(new parameter("IsSendSuccess", AdmissionPipeline.IsSendSuccess));
        this.arrParameter.Add(new parameter("FailureReasons", AdmissionPipeline.FailureReasons));
        this.arrParameter.Add(new parameter("CreatedBy", AdmissionPipeline.CreatedBy));

        return this.oDataHelper.DAL_InsertUpdateWithStatus("AdmissionPipeline_Insert", this.arrParameter);
    }

    public bool AdmissionPipeline_UpdateMailStatus(AdmissionPipeline AdmissionPipeline)
    {
        this.oDataHelper = new DataAccess();
        this.arrParameter = new ArrayList();

        this.arrParameter.Add(new parameter("AdmissionId", AdmissionPipeline.AdmissionId));
        this.arrParameter.Add(new parameter("AdmissionStatus", AdmissionPipeline.AdmissionStatus));
        this.arrParameter.Add(new parameter("IsSendMail", AdmissionPipeline.IsSendSuccess));
        this.arrParameter.Add(new parameter("FailiurReason", AdmissionPipeline.FailureReasons));

        return this.oDataHelper.DAL_InsertUpdateWithStatus("AdmissionPipeline_UpdateMailStatus", this.arrParameter);
    }

    public DataSet AdmissionPipeline_Select_StatusAndEmail(AdmissionPipeline oAdmissionPipeline)
    {
        oDataHelper = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("AdmissionId", oAdmissionPipeline.AdmissionId));

        return oDataHelper.DAL_Select("AdmissionPipeline_Select_StatusAndEmail", arrParameter);
    }

    public DataSet AdmissionPipeline_Select_StatusAndEmail_By_AdmissionEmailID(string AdmissionEmailID)
    {
        oDataHelper = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("AdmissionEmailID", AdmissionEmailID));

        return oDataHelper.DAL_Select("AdmissionPipeline_Select_Email_ByAdmissionEmailID", arrParameter);
    }

    public DataSet Admission_ExamDays_SelectALL()
    {
        oDataHelper = new DataAccess();
        arrParameter = new ArrayList();

        return oDataHelper.DAL_Select("Admission_ExamDays_SelectAll", arrParameter);
    }
    public DataSet Admission_Online_SelectAll(AdmissionProperties oAdmission)
    {
        oDataHelper = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("AdmissionGrade", oAdmission.AdmissionGrade));

        return oDataHelper.DAL_Select("Admission_online_select", arrParameter);
    }
}
