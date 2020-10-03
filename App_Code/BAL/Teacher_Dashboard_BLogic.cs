/// <summary>
/// <Description></Description>
/// <DevelopedBy></DevelopedBy>
/// <Created Date> </Date>
/// <UpdatedBy>"Sheel"</UpdatedBy>
/// <Updated Date>"25-7-2014"</Date>
/// </summary>
using System.Data;
using System.Collections;
using System;

/// <summary>
/// Summary description for Teacher_Dashboard_BLogic
/// </summary>
public class Teacher_Dashboard_BLogic
{
    DataAccess DAL_Teacher_Dashboard;
    ArrayList arrParameter;
    SYS_TeacherActivityFeedback TA = new SYS_TeacherActivityFeedback();

    public Teacher_Dashboard_BLogic()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public int BAL_IsCLassTeacher_Select(Teacher_Dashboard TD)
    {
        DAL_Teacher_Dashboard = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("BMSID", TD.BMSID));
        arrParameter.Add(new parameter("EmployeeID", TD.EmployeeID));
        arrParameter.Add(new parameter("DivisionID", TD.DivisionID));
        arrParameter.Add(new parameter("SchoolID", TD.SchoolID));

        return DAL_Teacher_Dashboard.executescalre("PROC_IsClassTeacher", arrParameter);
    }

    public int BAL_Insert_Rescheduling_BMSSCT(Teacher_Dashboard TD)
    {
        DAL_Teacher_Dashboard = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("BMSID", TD.BMSID));
        arrParameter.Add(new parameter("SubjectID", TD.SubjectID));
        arrParameter.Add(new parameter("DivisionID", TD.DivisionID));
        arrParameter.Add(new parameter("ChapterID", TD.ChapterID));
        arrParameter.Add(new parameter("TopicID", TD.TopicID));
        arrParameter.Add(new parameter("SchoolID", TD.SchoolID));
        arrParameter.Add(new parameter("EmployeeID", TD.EmployeeID));

        return DAL_Teacher_Dashboard.executescalre("Proc_Insert_Rescheduling_BMSSCT", arrParameter);
    }

    public DataSet BAL_Select_Chapters_Topics(Teacher_Dashboard TD)
    {
        DAL_Teacher_Dashboard = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("BMSID", TD.BMSID));
        arrParameter.Add(new parameter("SubjectID", TD.SubjectID));
        arrParameter.Add(new parameter("DivisionID", TD.DivisionID));
        arrParameter.Add(new parameter("EmplyeeID", TD.EmployeeID));
        arrParameter.Add(new parameter("SchoolID", TD.SchoolID));

        return DAL_Teacher_Dashboard.DAL_Select("PROC_Select_Chapter_Topic_BasedOn_SeqNo", arrParameter);
    }

    public DataSet BAL_Select_Covered_Chapters_Topics(Teacher_Dashboard TD)
    {
        DAL_Teacher_Dashboard = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("BMSID", TD.BMSID));
        arrParameter.Add(new parameter("SubjectID", TD.SubjectID));
        arrParameter.Add(new parameter("DivisionID", TD.DivisionID));
        arrParameter.Add(new parameter("EmplyeeID", TD.EmployeeID));
        arrParameter.Add(new parameter("SchoolID", TD.SchoolID));

        return DAL_Teacher_Dashboard.DAL_Select("PROC_Select_Covered_Chapter_Topic_BasedOn_SeqNo", arrParameter);
    }

    public DataSet BAL_Select_Covered_Syllabus(Teacher_Dashboard TD)
    {
        DAL_Teacher_Dashboard = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("BMSID", TD.BMSID));
        arrParameter.Add(new parameter("SubjectID", TD.SubjectID));
        arrParameter.Add(new parameter("DivisionID", TD.DivisionID));
        arrParameter.Add(new parameter("EmplyeeID", TD.EmployeeID));
        arrParameter.Add(new parameter("SchoolID", TD.SchoolID));

        return DAL_Teacher_Dashboard.DAL_Select("PROC_Select_Covered_Syllabus", arrParameter);
    }

    public DataSet BAL_Select_Applied_Rescheduling_Data_Of_Teacher(Teacher_Dashboard TD)
    {
        DAL_Teacher_Dashboard = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("BMSID", TD.BMSID));
        arrParameter.Add(new parameter("SubjectID", TD.SubjectID));
        arrParameter.Add(new parameter("DivisionID", TD.DivisionID));
        arrParameter.Add(new parameter("EmployeeID", TD.EmployeeID));
        arrParameter.Add(new parameter("SchoolID", TD.SchoolID));
        arrParameter.Add(new parameter("Month", TD.Month));
        arrParameter.Add(new parameter("Year", TD.Year));

        return DAL_Teacher_Dashboard.DAL_Select("Proc_Select_Rescheduling_Data_Of_Teacher", arrParameter);
    }

    public DataSet BAL_Select_Chart_Data(Teacher_Dashboard TD)
    {
        DAL_Teacher_Dashboard = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("BMSID", TD.BMSID));
        arrParameter.Add(new parameter("SubjectID", TD.SubjectID));
        arrParameter.Add(new parameter("DivisionID", TD.DivisionID));
        arrParameter.Add(new parameter("EmpolyeeID", TD.EmployeeID));
        arrParameter.Add(new parameter("SchoolID", TD.SchoolID));

        return DAL_Teacher_Dashboard.DAL_Select("PROC_Select_Chapter_Topic_ChartData", arrParameter);
    }

    public DataSet BAL_Select_Rescheduling_Data(Teacher_Dashboard TD)
    {
        DAL_Teacher_Dashboard = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("BMSID", TD.BMSID));
        arrParameter.Add(new parameter("SubjectID", TD.SubjectID));
        arrParameter.Add(new parameter("DivisionID", TD.DivisionID));
        arrParameter.Add(new parameter("EmployeeID", TD.EmployeeID));
        arrParameter.Add(new parameter("SchoolID", TD.SchoolID));

        return DAL_Teacher_Dashboard.DAL_Select("Proc_Select_Rescheduling_Data", arrParameter);
    }

    public int BAL_Select_BMS_SCTID(Teacher_Dashboard TD)
    {
        DAL_Teacher_Dashboard = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("BMSID", TD.BMSID));
        arrParameter.Add(new parameter("SubjectID", TD.SubjectID));
        arrParameter.Add(new parameter("ChapterID", TD.ChapterID));
        arrParameter.Add(new parameter("TopicID", TD.TopicID));

        return DAL_Teacher_Dashboard.executescalre("PROC_Select_BMS_SCTID", arrParameter);
    }

    public DataSet BAL_Select_BMS_SCTID_Demo(Teacher_Dashboard TD)
    {
        DAL_Teacher_Dashboard = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("BMSID", TD.BMSID));
        arrParameter.Add(new parameter("SubjectID", TD.SubjectID));
        arrParameter.Add(new parameter("ChapterID", TD.ChapterID));
        arrParameter.Add(new parameter("TopicID", TD.TopicID));

        return DAL_Teacher_Dashboard.DAL_Select("PROC_Select_BMS_SCTID_Demo", arrParameter);
    }

    public DataSet BAL_Select_CoveredUncoverChapterTopic_Settings(string Field)
    {
        //DAL_Teacher_Dashboard = new DataAccess();
        //return DAL_Teacher_Dashboard.DAL_SelectALL("PROC_Select_CoveredUncoverChapterTopic");

        DAL_Teacher_Dashboard = new DataAccess();
        arrParameter = new ArrayList();
        arrParameter.Add(new parameter("FieldName", Field));
        return DAL_Teacher_Dashboard.DAL_Select("PROC_GetConfigValue", arrParameter);
    }
    public DataSet BAL_Select_IsActivityFeedback_Settings(string Field)
    {
        //DAL_Teacher_Dashboard = new DataAccess();    
        //return DAL_Teacher_Dashboard.DAL_SelectALL("PROC_Select_IsActivityFeedback");
        DAL_Teacher_Dashboard = new DataAccess();
        arrParameter = new ArrayList();
        arrParameter.Add(new parameter("FieldName", Field));
        return DAL_Teacher_Dashboard.DAL_Select("PROC_GetConfigValue", arrParameter); //[PROC_GetConfigValue] : Parameter @FieldName
    }

    public DataSet BAL_Select_Maintain_activity_log_Settings()
    {
        DAL_Teacher_Dashboard = new DataAccess();

        return DAL_Teacher_Dashboard.DAL_SelectALL("PROC_Select_Maintain_activity_log");
    }

    public int BAL_Insert_Exam(Teacher_Dashboard TD)
    {
        DAL_Teacher_Dashboard = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("ExamName", TD.ExamName));
        arrParameter.Add(new parameter("BMSSCTID", TD.BMSSCTID));
        arrParameter.Add(new parameter("SchoolID", TD.SchoolID));
        arrParameter.Add(new parameter("EmployeeID", TD.EmployeeID));
        arrParameter.Add(new parameter("DivisionID", TD.DivisionID));
        arrParameter.Add(new parameter("TotalQues", TD.TotalQues));
        arrParameter.Add(new parameter("TotalMarks", TD.TotalMarks));

        return DAL_Teacher_Dashboard.executescalre("Proc_Insert_Exam_Entry", arrParameter);
    }

    public int Get_BMSSCTID(Teacher_Dashboard TD)
    {
        DAL_Teacher_Dashboard = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("BMSID", TD.BMSID));
        arrParameter.Add(new parameter("SubjectID", TD.SubjectID));
        arrParameter.Add(new parameter("ChapterID", TD.ChapterID));
        arrParameter.Add(new parameter("TopicID", TD.TopicID));

        return DAL_Teacher_Dashboard.executescalre("PROC_Select_BMS_SCTID", arrParameter);
    }

    public DataSet Get_Exams(Teacher_Dashboard TD)
    {
        DAL_Teacher_Dashboard = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("BMSSCTID", TD.BMSSCTID));
        arrParameter.Add(new parameter("SchoolID", TD.SchoolID));
        arrParameter.Add(new parameter("EmployeeID", TD.EmployeeID));
        arrParameter.Add(new parameter("DivisionID", TD.DivisionID));

        return DAL_Teacher_Dashboard.DAL_Select("Proc_Select_Exams", arrParameter);
    }

    public DataSet Get_StudentList(Teacher_Dashboard TD)
    {
        DAL_Teacher_Dashboard = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("SchoolID", TD.SchoolID));
        arrParameter.Add(new parameter("BMSID", TD.BMSID));
        arrParameter.Add(new parameter("DivisionID", TD.DivisionID));
        arrParameter.Add(new parameter("ExamID", TD.ExamID));

        return DAL_Teacher_Dashboard.DAL_Select("Proc_Select_StudetsFor_Result", arrParameter);
    }

    public void BAL_SYS_Delete_Student_Result(Teacher_Dashboard TD)
    {
        DAL_Teacher_Dashboard = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("ExamID", TD.ExamID));
        DAL_Teacher_Dashboard.DAL_InsertUpdate("PROC_Delete_StudentResultData", arrParameter);
    }

    public DataSet Get_Student_ExamSummary_Report(Teacher_Dashboard TD)
    {
        DAL_Teacher_Dashboard = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("SchoolID", TD.SchoolID));
        arrParameter.Add(new parameter("BMSID", TD.BMSID));
        arrParameter.Add(new parameter("BMSSCTID", TD.BMSSCTID));
        arrParameter.Add(new parameter("DivisionID", TD.DivisionID));

        return DAL_Teacher_Dashboard.DAL_Select("Proc_Select_Studets_ExamSummary_Report", arrParameter);
    }

    public int FachTopicwiseResult(SYS_TeacherActivityFeedback TA)
    {
        DAL_Teacher_Dashboard = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("SchoolID", TA.SchoolID));
        arrParameter.Add(new parameter("BMSSCTID", TA.BMSSCTID));
        arrParameter.Add(new parameter("EmployeeID", TA.EmployeeID));
        arrParameter.Add(new parameter("DivisionID", TA.DivisionID));
        arrParameter.Add(new parameter("Feedback", TA.Feedback));

        arrParameter.Add(new parameter("CreatedBy", TA.CreatedBy));

        return DAL_Teacher_Dashboard.executescalre("PROC_INSERT_TeacherActivityFeedback", arrParameter);

    }

    public DataSet SelectLastReschedulingID(int EmployeeID)
    {
        DAL_Teacher_Dashboard = new DataAccess();
        arrParameter = new ArrayList();
        arrParameter.Add(new parameter("EmployeeID", EmployeeID));
        return DAL_Teacher_Dashboard.DAL_Select("Proc_Select_Last_ReschedulingID", arrParameter);
    }

    public DataSet BAL_Emailid_Select(Employee Employee)
    {
        DataSet ds = new DataSet();
        DAL_Teacher_Dashboard = new DataAccess();
        arrParameter = new ArrayList();
        arrParameter.Add(new parameter("UserName", Employee.emailid));
        ds = DAL_Teacher_Dashboard.DAL_Select("PROC_Select_Valid_login_test", arrParameter);
        return ds;
    }

    public DataSet SelectTeacherTestResult(int SchoolID, int BMSID, int EmployeeID, int DivisionID, int ChapterID, int TopicID, int SubjectID, string TestType)
    {
        DAL_Teacher_Dashboard = new DataAccess();
        arrParameter = new ArrayList();
        arrParameter.Add(new parameter("SchoolID", SchoolID));
        arrParameter.Add(new parameter("BMSID", BMSID));
        arrParameter.Add(new parameter("EmployeeID", EmployeeID));
        arrParameter.Add(new parameter("DivisionID", DivisionID));
        arrParameter.Add(new parameter("ChapterID", ChapterID));
        arrParameter.Add(new parameter("TopicID", TopicID));
        arrParameter.Add(new parameter("SubjectID", SubjectID));
        arrParameter.Add(new parameter("TestType", TestType));
        return DAL_Teacher_Dashboard.DAL_Select("Proc_SelectTeacherTestResultNew", arrParameter);
    }
    public DataSet BAL_BSMSearchResult(string Keyword)
    {
        DAL_Teacher_Dashboard = new DataAccess();
        arrParameter = new ArrayList();
        arrParameter.Add(new parameter("EmployeeID", AppSessions.EmpolyeeID));
        arrParameter.Add(new parameter("SchoolID", AppSessions.SchoolID));
        arrParameter.Add(new parameter("RoleID", AppSessions.RoleID));
        arrParameter.Add(new parameter("StudentID", AppSessions.StudentID));
        arrParameter.Add(new parameter("Keyword", Keyword));
        return DAL_Teacher_Dashboard.DAL_Select("Proc_BMSSCTListByChapterDescription", arrParameter);
    }
    public DataSet BAL_Select_Chapters_Topics_By_CoveredStatus(Teacher_Dashboard TD, string status)
    {
        DAL_Teacher_Dashboard = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("BMSID", TD.BMSID));
        arrParameter.Add(new parameter("SubjectID", TD.SubjectID));
        arrParameter.Add(new parameter("EmployeeID", TD.EmployeeID));
        arrParameter.Add(new parameter("Status", status));

        return DAL_Teacher_Dashboard.DAL_Select("sys_chapter_getchapterlistbycoveredstatus", arrParameter);
    }

    public int BAL_Select_QuestionBankIDCount(Int64 BMSSCTID, bool IsPostTest)
    {
        DAL_Teacher_Dashboard = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("BMSSCTID", BMSSCTID));
        arrParameter.Add(new parameter("IsPostTest", IsPostTest));
        return DAL_Teacher_Dashboard.executescalre("Proc_GetQuestionCount", arrParameter);
    }
}