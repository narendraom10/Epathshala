using System.Data;
using System.Collections;

///// <summary>
///// Summary description for Student_BLogic
///// </summary>


public class Student_BLogic
{
    DataAccess DAL_Student;
    ArrayList arrParameter;
    public Student_BLogic()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public void BAL_Student_Insert(Student Student, string mode)
    {
        this.DAL_Student = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("mode", mode));
        arrParameter.Add(new parameter("SchoolID", Student.schoolid));
        arrParameter.Add(new parameter("BMSID", Student.bmsid));
        arrParameter.Add(new parameter("DivisionID", Student.divisionid));
        arrParameter.Add(new parameter("StudentCode", Student.studentcode));
        arrParameter.Add(new parameter("LoginID", Student.loginid));
        arrParameter.Add(new parameter("Password", Student.password));
        arrParameter.Add(new parameter("FirstName", Student.firstname));
        arrParameter.Add(new parameter("MiddleName", Student.middlename));
        arrParameter.Add(new parameter("LastName", Student.lastname));
        arrParameter.Add(new parameter("RollNo", Student.rollno));
        arrParameter.Add(new parameter("ContactNo", Student.contactno));
        arrParameter.Add(new parameter("MobileNo", Student.mobileno));
        arrParameter.Add(new parameter("EmailID", Student.emailid));
        arrParameter.Add(new parameter("GRNo", Student.grno));
        //arrParameter.Add(new parameter("DateOfBirth", Student.dateofbirth));
        arrParameter.Add(new parameter("Gender", Student.gender));
        arrParameter.Add(new parameter("BloodGroup", Student.bloodgroup));
        arrParameter.Add(new parameter("CreatedBy", Student.createdby));
        arrParameter.Add(new parameter("Address", Student.Address));
        DAL_Student.DAL_InsertUpdate("Proc_StudentInsertUpdate", arrParameter);
    }

    public int BAL_Student_Insert_Online(Student Student, string mode)
    {
        int t1 = 0;
        this.DAL_Student = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("mode", mode));
        arrParameter.Add(new parameter("SchoolID", Student.schoolid));
        arrParameter.Add(new parameter("BMSID", Student.bmsid));
        arrParameter.Add(new parameter("DivisionID", Student.divisionid));
        arrParameter.Add(new parameter("StudentCode", Student.studentcode));
        arrParameter.Add(new parameter("LoginID", Student.loginid));
        arrParameter.Add(new parameter("Password", Student.password));
        arrParameter.Add(new parameter("FirstName", Student.firstname));
        arrParameter.Add(new parameter("MiddleName", Student.middlename));
        arrParameter.Add(new parameter("LastName", Student.lastname));
        arrParameter.Add(new parameter("RollNo", Student.rollno));
        //arrParameter.Add(new parameter("ContactNo", Student.contactno));
        arrParameter.Add(new parameter("ContactNo", Student.mobilenostring));
        arrParameter.Add(new parameter("MobileNo", Student.mobileno));
        arrParameter.Add(new parameter("EmailID", Student.emailid));
        arrParameter.Add(new parameter("GRNo", Student.grno));
        //arrParameter.Add(new parameter("DateOfBirth", Student.dateofbirth));
        arrParameter.Add(new parameter("School", Student.schoolname));
        arrParameter.Add(new parameter("Gender", Student.gender));
        arrParameter.Add(new parameter("BloodGroup", Student.bloodgroup));
        arrParameter.Add(new parameter("CreatedBy", Student.createdby));
        arrParameter.Add(new parameter("Address", Student.Address));
        arrParameter.Add(new parameter("PaymentType", Student.PaymentType));
        if (mode == "OnlineReg")
            t1 = DAL_Student.executescalre("Proc_StudentInsertUpdate", arrParameter);
        else
            t1 = DAL_Student.DAL_InsertUpdate_Return("Proc_StudentInsertUpdate", arrParameter);

        return t1;
    }

    public void BAL_Student_Update(Student Student, string mode)
    {
        DAL_Student = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("mode", mode));
        arrParameter.Add(new parameter("StudentID", Student.studentid));
        arrParameter.Add(new parameter("SchoolID", Student.schoolid));
        arrParameter.Add(new parameter("BMSID", Student.bmsid));
        arrParameter.Add(new parameter("DivisionID", Student.divisionid));
        arrParameter.Add(new parameter("StudentCode", Student.studentcode));
        arrParameter.Add(new parameter("LoginID", Student.loginid));
        arrParameter.Add(new parameter("Password", Student.password));
        arrParameter.Add(new parameter("FirstName", Student.firstname));
        arrParameter.Add(new parameter("MiddleName", Student.middlename));
        arrParameter.Add(new parameter("LastName", Student.lastname));
        arrParameter.Add(new parameter("RollNo", Student.rollno));
        arrParameter.Add(new parameter("ContactNo", Student.contactno));
        arrParameter.Add(new parameter("MobileNo", Student.mobileno));
        arrParameter.Add(new parameter("EmailID", Student.emailid));
        arrParameter.Add(new parameter("GRNo", Student.grno));
        arrParameter.Add(new parameter("DateOfBirth", Student.dateofbirth));
        arrParameter.Add(new parameter("Gender", Student.gender));
        arrParameter.Add(new parameter("BloodGroup", Student.bloodgroup));
        arrParameter.Add(new parameter("IsActive", Student.isactive));
        arrParameter.Add(new parameter("ModifiedBy", Student.modifiedby));
        arrParameter.Add(new parameter("Address", Student.Address));
        arrParameter.Add(new parameter("Picture", Student.Picture));

        DAL_Student.DAL_InsertUpdate("Proc_StudentInsertUpdate", arrParameter);
    }

    public void BAL_Student_Delete(Student Student, string mode)
    {
        DAL_Student = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("mode", mode));
        arrParameter.Add(new parameter("StudentID", Student.studentid));
        arrParameter.Add(new parameter("SchoolID", Student.schoolid));
        arrParameter.Add(new parameter("BMSID", Student.bmsid));
        arrParameter.Add(new parameter("DivisionID", Student.divisionid));
        arrParameter.Add(new parameter("RoleID", Student.roleid));
        arrParameter.Add(new parameter("StudentCode", Student.studentcode));
        arrParameter.Add(new parameter("LoginID", Student.loginid));
        arrParameter.Add(new parameter("Password", Student.password));
        arrParameter.Add(new parameter("FirstName", Student.firstname));
        arrParameter.Add(new parameter("MiddleName", Student.middlename));
        arrParameter.Add(new parameter("LastName", Student.lastname));
        arrParameter.Add(new parameter("RollNo", Student.rollno));
        arrParameter.Add(new parameter("ContactNo", Student.contactno));
        arrParameter.Add(new parameter("MobileNo", Student.mobileno));
        arrParameter.Add(new parameter("EmailID", Student.emailid));
        arrParameter.Add(new parameter("GRNo", Student.grno));
        arrParameter.Add(new parameter("DateOfBirth", Student.dateofbirth));
        arrParameter.Add(new parameter("Gender", Student.gender));
        arrParameter.Add(new parameter("BloodGroup", Student.bloodgroup));
        arrParameter.Add(new parameter("IsActive", Student.isactive));
        arrParameter.Add(new parameter("CreatedOn", Student.createdon));
        arrParameter.Add(new parameter("CreatedBy", Student.createdby));
        arrParameter.Add(new parameter("ModifiedOn", Student.modifiedon));
        arrParameter.Add(new parameter("ModifiedBy", Student.modifiedby));
        DAL_Student.DAL_Delete("Proc_StudentSelectDelete", arrParameter);
    }

    public DataSet BAL_Student_Select(Student Student, string mode)
    {
        DAL_Student = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("mode", mode));
        arrParameter.Add(new parameter("StudentID", Student.studentid));
        return DAL_Student.DAL_Select("Proc_StudentSelectDelete", arrParameter);
    }

    public DataSet BAL_Student_SelectAll()
    {
        DAL_Student = new DataAccess();
        return DAL_Student.DAL_SelectALL("Proc_StudentSELECTAll");
    }

    public DataSet BAL_Student_SelectPackageID(int BMSID)
    {
        DAL_Student = new DataAccess();

        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("BMSID", BMSID));

        return DAL_Student.DAL_Select("PackageDetials_SlectTrialPackage", arrParameter);
    }

    public DataSet BAL_Student_SelectBMSDIVWise(int SchoolID, int BMSID, int DivisionID, string AcedemicYear)
    {
        DAL_Student = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("schoolID", SchoolID));
        arrParameter.Add(new parameter("BMSID", BMSID));
        arrParameter.Add(new parameter("DivisionID", DivisionID));
        arrParameter.Add(new parameter("Acedemicyear", AcedemicYear));
        return DAL_Student.DAL_Select("Student_Select_Student_BYSchoolBMSDIV", arrParameter);
    }

    public DataSet BAL_Verify_Student(Student Student)
    {
        DAL_Student = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("LoginID", Student.loginid));
        return DAL_Student.DAL_Select("Proc_Verify_Student_LoginID", arrParameter);


    }


    public DataSet BAL_Student_Select_PaymentInfo(int ID)
    {
        DAL_Student = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("StudentID", ID));
        return DAL_Student.DAL_Select("GetStudentPaymentInfo", arrParameter);
    }

    public void BAL_Student_Update_Student(int studentid, int rollno, string GRNO)
    {

        DataAccess OUpdateStudent = new DataAccess();
        arrParameter = new ArrayList();
        arrParameter.Add(new parameter("StudentID", studentid));
        //arrParameter.Add(new parameter("SchoolID", schoolid));
        arrParameter.Add(new parameter("RollNo", rollno));
        arrParameter.Add(new parameter("GRNo", GRNO));
        OUpdateStudent.DAL_InsertUpdate("Update_StudentDetails", arrParameter);

    }

    public int BAL_Student_PromoteNextYear(long studentid, long schoolid, int roleid, string grno, string previousacedemicyear, string currentacedemicyear,
        int Previousrollno, int currentRollNo, long PreviousBMSID, long CurrentBMSID, int PreviousDivID, int CurrentDivID, long CreatedBy, string status)
    {
        int t1 = 0;
        this.DAL_Student = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("StudentID", studentid));
        arrParameter.Add(new parameter("SchoolID", schoolid));
        arrParameter.Add(new parameter("RoleID", roleid));
        arrParameter.Add(new parameter("GRNo", grno));
        arrParameter.Add(new parameter("PreviousAcedemicYear", previousacedemicyear));
        arrParameter.Add(new parameter("CurrentAcedemicYear", currentacedemicyear));
        arrParameter.Add(new parameter("PreviousRollNo", Previousrollno));
        arrParameter.Add(new parameter("CurrenetRollNo", currentRollNo));
        arrParameter.Add(new parameter("PreviousBMSID", PreviousBMSID));
        arrParameter.Add(new parameter("CurrentBMSID", CurrentBMSID));
        arrParameter.Add(new parameter("PreviousDivID", PreviousDivID));
        arrParameter.Add(new parameter("CurrentDivID", CurrentDivID));
        arrParameter.Add(new parameter("CreateBy", CreatedBy));
        arrParameter.Add(new parameter("Status", status));


        t1 = DAL_Student.DAL_InsertUpdate_Return("StudentPromoteBatch_UpdateStudentBMS", arrParameter);
        return t1;

    }

    public DataSet BAL_Student_Select_EmailID(int studentID)
    {
        DAL_Student = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("StudentID", studentID));
        return DAL_Student.DAL_Select("GetStudentEmailInfo", arrParameter);
    }
    public DataSet BAL_Student_SelectBMSDIV(int SchoolID, int BMSID, int DivisionID)
    {
        DAL_Student = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("schoolID", SchoolID));
        arrParameter.Add(new parameter("BMSID", BMSID));
        arrParameter.Add(new parameter("DivisionID", DivisionID));

        return DAL_Student.DAL_Select("Student_Select_ByBMSDiv", arrParameter);
    }

    #region Update Profile

    public DataSet BAL_Student_GetDetailByStudentID(int studentid)
    {
        this.DAL_Student = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("StudentID", studentid));

        return DAL_Student.DAL_Select("Proc_getStudentUpdateProfile", arrParameter);
    }
    public bool BAL_Student_UpdateProfile(Student Student)
    {
        this.DAL_Student = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("StudentID", Student.studentid));
        arrParameter.Add(new parameter("FirstName", Student.firstname));
        arrParameter.Add(new parameter("MiddleName", Student.middlename));
        arrParameter.Add(new parameter("LastName", Student.lastname));
        arrParameter.Add(new parameter("ContactNo", Student.contactno));
        arrParameter.Add(new parameter("MobileNo", Student.mobileno));
        arrParameter.Add(new parameter("EmailID", Student.emailid));
        arrParameter.Add(new parameter("DateOfBirth", Student.dateofbirth));
        arrParameter.Add(new parameter("Gender", Student.gender));
        arrParameter.Add(new parameter("BloodGroup", Student.bloodgroup));
        arrParameter.Add(new parameter("Address", Student.Address));

        return DAL_Student.DAL_InsertUpdateWithStatus("Proc_StudentUpdateProfile", arrParameter);
    }

    #endregion

    public DataSet Insert_Student_Bulk(string InsertStatement)
    {
        DAL_Student = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("InsertStatement", InsertStatement));

        return DAL_Student.DAL_Select("student_InsertStudentBulk", arrParameter);
    }


    public DataSet BAL_Registration_Select(string mode, string startdate, string enddate)
    {
        DAL_Student = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("mode", mode));
        arrParameter.Add(new parameter("startdate", startdate));
        arrParameter.Add(new parameter("enddate", enddate));
        return DAL_Student.DAL_Select("Proc_SelectRecentRegistration", arrParameter);
    }
    public DataSet BAL_Student_BySchoolid(int schoolID)
    {
        DAL_Student = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("schoolID", schoolID));
        return DAL_Student.DAL_Select("GetStudent_BySchoolid", arrParameter);
    }
    public void BAL_MessageLog(string StudentID, string SentOnMobileNo, string Message, string Response, bool IsSendSuccess)
    {
        this.DAL_Student = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("SchoolID", AppSessions.SchoolID));
        arrParameter.Add(new parameter("StudentID", StudentID));
        arrParameter.Add(new parameter("SentOnMobileNo", SentOnMobileNo));
        arrParameter.Add(new parameter("Message", Message));
        arrParameter.Add(new parameter("IsSendSuccess", IsSendSuccess));
        arrParameter.Add(new parameter("Response", Response));
        arrParameter.Add(new parameter("CreatedBy", AppSessions.EmpolyeeID));

        DAL_Student.DAL_InsertUpdate("MessageLog_Insert", arrParameter);
    }
    public DataSet BAL_Get_MessageLog()
    {
        this.DAL_Student = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("SchoolID", AppSessions.SchoolID));

        return DAL_Student.DAL_Select("MessageLog_Select_BySchoolId", arrParameter);
    }

    #region StudentProfileNew
    public void UpdateStudentProfile(Student std, string section_to_update)
    {
        //Possible values of section_to_update are : Personal , Parent or Educational
        DataAccess da = new DataAccess();
        ArrayList arr_student_params = new ArrayList();
        Student obj_student = new Student();

        switch (section_to_update)
        {
            case "personal":
                arr_student_params.Add(new parameter("StudentID", std.studentid));
                arr_student_params.Add(new parameter("FirstName", std.firstname));
                arr_student_params.Add(new parameter("MiddleName", std.middlename));
                arr_student_params.Add(new parameter("LastName", std.lastname));
                arr_student_params.Add(new parameter("Address", std.Address));
                arr_student_params.Add(new parameter("ContactNo", std.contactno));
                arr_student_params.Add(new parameter("MobileNo", std.mobileno));
                arr_student_params.Add(new parameter("EmailID", std.emailid));
                arr_student_params.Add(new parameter("DateOfBirth", std.dateofbirth));
                arr_student_params.Add(new parameter("Gender", std.gender));
                arr_student_params.Add(new parameter("Picture", std.Picture));
                arr_student_params.Add(new parameter("BloodGroup", std.bloodgroup));
                arr_student_params.Add(new parameter("City", std.City));
                arr_student_params.Add(new parameter("Zipcode", std.Zipcode));
                arr_student_params.Add(new parameter("State", std.State));
                arr_student_params.Add(new parameter("Country", std.Country));
                arr_student_params.Add(new parameter("sectiontoupdate", "personal"));

                da.DAL_InsertUpdate("sp_StudentProfileUpdate", arr_student_params);

                break;
            case "parent":
                arr_student_params.Add(new parameter("StudentID", std.studentid));
                arr_student_params.Add(new parameter("FatherName", std.FatherName));
                arr_student_params.Add(new parameter("FatherContact", std.FatherContact));
                arr_student_params.Add(new parameter("FatherEmail", std.FatherEmail));
                arr_student_params.Add(new parameter("MotherName", std.MotherName));
                arr_student_params.Add(new parameter("MotherContact", std.MotherContact));
                arr_student_params.Add(new parameter("MotherEmail", std.MotherEmail));
                arr_student_params.Add(new parameter("GuardianName", std.GuardianName));
                arr_student_params.Add(new parameter("GuardianContact", std.GuardianContact));
                arr_student_params.Add(new parameter("GuardianEmail", std.GuardianEmail));
                arr_student_params.Add(new parameter("sectiontoupdate", "parent"));

                da.DAL_InsertUpdate("sp_StudentProfileUpdate", arr_student_params);
                break;
            case "education":
                arr_student_params.Add(new parameter("School", std.schoolname));
                arr_student_params.Add(new parameter("SchoolContact", std.SchoolContact));
                arr_student_params.Add(new parameter("SchoolEmail", std.SchoolEmail));
                arr_student_params.Add(new parameter("StudentID", std.studentid));
                arr_student_params.Add(new parameter("sectiontoupdate", "education"));

                da.DAL_InsertUpdate("sp_StudentProfileUpdate", arr_student_params);
                break;
        }
    }
    #endregion
}
