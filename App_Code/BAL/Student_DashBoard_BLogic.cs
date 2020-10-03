/// <summary> 
/// <DevelopedBy></DevelopedBy>
/// <DevelopedDate></DevelopedDate>
/// <UpdatedBy>"SHEEL"</UpdatedBy>
/// <UpdatedDate>"20-8-2014"</UpdatedDate>
/// </summary>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;


public class Student_DashBoard_BLogic
{


	DataAccess DAL_Student_Dashboard;
	ArrayList arrParameter;
	DataSet ds;

	public Student_DashBoard_BLogic()
	{
		//
		// TODO: Add constructor logic here
		//
	}


	public DataSet BAL_Student_Subject_Select(StudentDash StudenDash)
	{
		DAL_Student_Dashboard = new DataAccess();
		arrParameter = new ArrayList();

		arrParameter.Add(new parameter("BMSID", StudenDash.BMSID));
		arrParameter.Add(new parameter("PackageFDID", StudenDash.PackageFDID));
		arrParameter.Add(new parameter("mode", StudenDash.Mode));
		return DAL_Student_Dashboard.DAL_Select("Proc_Select_Subject_For_StudentDashBoard", arrParameter);
	}

	public DataSet BAL_Student_Package(string packagetype , int BMSID)
	{
		DAL_Student_Dashboard = new DataAccess();
		arrParameter = new ArrayList();

		arrParameter.Add(new parameter("BMSID", BMSID));
		arrParameter.Add(new parameter("PackageType", packagetype));

		return DAL_Student_Dashboard.DAL_Select("packagedetails_Selectpackage", arrParameter);
	}

	public DataSet BAL_Student_Not_Purchased_Package(string packagetype , int BMSID, int studentid)
	{
		DAL_Student_Dashboard = new DataAccess();
		arrParameter = new ArrayList();

		arrParameter.Add(new parameter("BMSID", BMSID));
		arrParameter.Add(new parameter("PackageType", packagetype));
		arrParameter.Add(new parameter("StudentID", studentid));

		return DAL_Student_Dashboard.DAL_Select("studentpackagedetails_selectnotpurchasedpackage", arrParameter);
	}

	public DataSet BAL_Student_ALL_Not_Purchased_Package(int BMSID, int studentid, string Currency)
	{
		DAL_Student_Dashboard = new DataAccess();
		arrParameter = new ArrayList();

		arrParameter.Add(new parameter("BMSID", BMSID));
		arrParameter.Add(new parameter("StudentID", studentid));
		arrParameter.Add(new parameter("Currency", Currency));
		

		return DAL_Student_Dashboard.DAL_Select("studentpackagedetails_selectAllNotPurchasedPackages", arrParameter);
	}

	public DataSet BAL_Student_Purchased_Package(string packagetype, int BMSID, int studentid)
	{
		DAL_Student_Dashboard = new DataAccess();
		arrParameter = new ArrayList();

		arrParameter.Add(new parameter("PackageType", packagetype));
		arrParameter.Add(new parameter("BMSID", BMSID));
		arrParameter.Add(new parameter("StudentID", studentid));

		return DAL_Student_Dashboard.DAL_Select("studentpackagedetails_SelectPurchasePackage", arrParameter);
	}
	
	public DataSet BAL_Student_PackageFor_Notification(StudentDash StudenDash)
	{
		DAL_Student_Dashboard = new DataAccess();
		arrParameter = new ArrayList();

		arrParameter.Add(new parameter("StudentID", StudenDash.StudentID));
		arrParameter.Add(new parameter("mode", StudenDash.Mode));
		return DAL_Student_Dashboard.DAL_Select("Proc_GetStudentPackage_For_Notification", arrParameter);
	}

	public DataSet BAL_Student_ExpiryNotification(StudentDash StudenDash)
	{
		DAL_Student_Dashboard = new DataAccess();
		arrParameter = new ArrayList();

		arrParameter.Add(new parameter("StudentID", StudenDash.StudentID));
		arrParameter.Add(new parameter("mode", StudenDash.Mode));
		return DAL_Student_Dashboard.DAL_Select("Proc_GetNotification_For_PackageExpiry", arrParameter);
	}

	public DataSet BAL_Student_ExpiryNotification1(StudentDash StudenDash)
	{
		DAL_Student_Dashboard = new DataAccess();
		arrParameter = new ArrayList();

		arrParameter.Add(new parameter("StudentID", StudenDash.StudentID));

		return DAL_Student_Dashboard.DAL_Select("Studentpackagedetails_selectstudentpackage", arrParameter);
	}

	public DataSet BAL_Student_SelectNotAvailablePackage(int BMSID, int packageID)
	{
		DAL_Student_Dashboard = new DataAccess();
		arrParameter = new ArrayList();

		arrParameter.Add(new parameter("BMSID1", Convert.ToInt32(BMSID)));
		arrParameter.Add(new parameter("packageID", packageID));

		return DAL_Student_Dashboard.DAL_Select("StudentPackageDetails_SelectNotAvailablePAckage", arrParameter);
	}

	public DataSet BAL_Student_CheckForPackageAvailablity(string packageID)
	{
		DAL_Student_Dashboard = new DataAccess();
		arrParameter = new ArrayList();
		arrParameter.Add(new parameter("PackageID", packageID));
		return DAL_Student_Dashboard.DAL_Select("CheckForPackageAvailablity", arrParameter);
	}

	public DataSet BAL_Student_PackageHistory(StudentDash StudenDash, string SearchBy, string PackageType, DateTime? Fromdate = null, DateTime? ToDate = null)
	{
		DAL_Student_Dashboard = new DataAccess();
		arrParameter = new ArrayList();

		arrParameter.Add(new parameter("StudentID", StudenDash.StudentID));
		arrParameter.Add(new parameter("Fromdate", Fromdate));
		arrParameter.Add(new parameter("Todate", ToDate));

		arrParameter.Add(new parameter("SearchBy", SearchBy));
		arrParameter.Add(new parameter("PackageType", PackageType));
		
	
		
		//return DAL_Student_Dashboard.DAL_Select("StudentPackageDetails_StudentPackageReport", arrParameter);
		return DAL_Student_Dashboard.DAL_Select("StudentPackageDetails_StudentPackageReport_Test", arrParameter);
	}

	public DataSet BAL_Student_ExpiredPackageHistory(StudentDash StudenDash)
	{
		DAL_Student_Dashboard = new DataAccess();
		arrParameter = new ArrayList();

		arrParameter.Add(new parameter("StudentID", StudenDash.StudentID));
		arrParameter.Add(new parameter("PackageID", StudenDash.PackageFDID));

		return DAL_Student_Dashboard.DAL_Select("Studentpackagedetails_selectstudentExpiredpackage", arrParameter);
	}

	public DataSet BAL_Student_PackageDetails(int studentid,int BMSID)
	{
		DAL_Student_Dashboard = new DataAccess();
		arrParameter = new ArrayList();

		arrParameter.Add(new parameter("StudentID", studentid));
		arrParameter.Add(new parameter("BMSID", BMSID));

		return DAL_Student_Dashboard.DAL_Select("studentpackagedetails_selctdetails", arrParameter);
	}

	

	public DataSet BAL_Select_CoveredUncoverChapterTopic_Settings()
	{
		DAL_Student_Dashboard = new DataAccess();

		return DAL_Student_Dashboard.DAL_SelectALL("PROC_Select_CoveredUncoverChapterTopic_Student");
	}

	public DataSet BAL_Select_Chapters_Topics(StudentDash SD)
	{
		DAL_Student_Dashboard = new DataAccess();
		arrParameter = new ArrayList();

		arrParameter.Add(new parameter("BMSID", SD.BMSID));
		arrParameter.Add(new parameter("SubjectID", SD.SubjectID));
		arrParameter.Add(new parameter("StudentID", SD.StudentID));

		return DAL_Student_Dashboard.DAL_Select("PROC_Select_Chapter_Topic_BasedOn_SeqNo_Student", arrParameter);
	}

	public DataSet BAL_Select_All_Chapters_Topics(StudentDash SD)
	{
		DAL_Student_Dashboard = new DataAccess();
		arrParameter = new ArrayList();

		arrParameter.Add(new parameter("BMSID", SD.BMSID));
		arrParameter.Add(new parameter("SubjectID", SD.SubjectID));
		arrParameter.Add(new parameter("StudentID", SD.StudentID));

		return DAL_Student_Dashboard.DAL_Select("proc_GetChapterTopicStatusByStudent", arrParameter);
	}

	public DataSet BAL_Student_GetComplateProfile(StudentDash SD)
	{
		DAL_Student_Dashboard = new DataAccess();
		arrParameter = new ArrayList();

		arrParameter.Add(new parameter("StudentID", SD.StudentID));

		return DAL_Student_Dashboard.DAL_Select("proc_Student_GetComplateProfile", arrParameter);
	}

	public DataSet BAL_Select_Chapters_Topics_Demo(StudentDash SD)
	{
		DAL_Student_Dashboard = new DataAccess();
		arrParameter = new ArrayList();

		arrParameter.Add(new parameter("BMSID", SD.BMSID));
		arrParameter.Add(new parameter("SubjectID", SD.SubjectID));
		

		return DAL_Student_Dashboard.DAL_Select("PROC_Select_Chapter_Topic_BasedOn_SeqNo_Student_Demo1", arrParameter);
	}

	//public DataSet BAL_Select_Covered_Chapters_Topics(StudentDash SD)
	//{
	//    DAL_Student_Dashboard = new DataAccess();
	//    arrParameter = new ArrayList();

	//    arrParameter.Add(new parameter("BMSID", SD.BMSID));
	//    arrParameter.Add(new parameter("SubjectID", SD.SubjectID));
	//    arrParameter.Add(new parameter("DivisionID", SD.DivisionID));
	//    arrParameter.Add(new parameter("StudentID", SD.StudentID));
	//    arrParameter.Add(new parameter("SchoolID", SD.SchoolID));

	//    return DAL_Student_Dashboard.DAL_Select("PROC_Select_Chapter_Topic_BasedOn_SeqNo_Student", arrParameter);
	//}

	public DataSet BAL_Select_Covered_Syllabus(StudentDash SD)
	{
		DAL_Student_Dashboard = new DataAccess();
		arrParameter = new ArrayList();

		arrParameter.Add(new parameter("BMSID", SD.BMSID));
		arrParameter.Add(new parameter("SubjectID", SD.SubjectID));
		arrParameter.Add(new parameter("StudentID", SD.StudentID));

		return DAL_Student_Dashboard.DAL_Select("PROC_Select_Covered_Syllabus_Student", arrParameter);
	}

	public DataSet BAL_Select_Chart_Data(StudentDash SD)
	{
		DAL_Student_Dashboard = new DataAccess();
		arrParameter = new ArrayList();

		arrParameter.Add(new parameter("BMSID", SD.BMSID));
		arrParameter.Add(new parameter("SubjectID", SD.SubjectID));
		arrParameter.Add(new parameter("StudentID", SD.StudentID));

		return DAL_Student_Dashboard.DAL_Select("PROC_Select_Chapter_Topic_ChartData_Student", arrParameter);
	}

	public DataSet BAL_Select_Covered_Chapters_Topics(StudentDash SD)
	{
		DAL_Student_Dashboard = new DataAccess();
		arrParameter = new ArrayList();

		arrParameter.Add(new parameter("BMSID", SD.BMSID));
		arrParameter.Add(new parameter("SubjectID", SD.SubjectID));
		arrParameter.Add(new parameter("StudentID", SD.StudentID));

		return DAL_Student_Dashboard.DAL_Select("PROC_Select_Covered_Chapter_Topic_BasedOn_SeqNo_Student", arrParameter);
	}

	public int BAL_Insert_Rescheduling_BMSSCT(StudentDash SD)
	{
		DAL_Student_Dashboard = new DataAccess();
		arrParameter = new ArrayList();

		arrParameter.Add(new parameter("BMSID", SD.BMSID));
		arrParameter.Add(new parameter("SubjectID", SD.SubjectID));
		arrParameter.Add(new parameter("ChapterID", SD.ChapterID));
		arrParameter.Add(new parameter("TopicID", SD.TopicID));
		arrParameter.Add(new parameter("StudentID", SD.StudentID));

		return DAL_Student_Dashboard.executescalre("Proc_Insert_Rescheduling_BMSSCT_Student", arrParameter);
	}

	public DataSet BAL_Select_Applied_Rescheduling_Data_Of_Student(StudentDash SD)
	{
		DAL_Student_Dashboard = new DataAccess();
		arrParameter = new ArrayList();

		arrParameter.Add(new parameter("BMSID", SD.BMSID));
		arrParameter.Add(new parameter("SubjectID", SD.SubjectID));
		arrParameter.Add(new parameter("StudentID", SD.StudentID));
		arrParameter.Add(new parameter("Month", SD.Month));
		arrParameter.Add(new parameter("Year", SD.Year));

		return DAL_Student_Dashboard.DAL_Select("Proc_Select_Rescheduling_Data_Of_Student", arrParameter);
	}

	public DataSet BAL_Select_Rescheduling_Data_Student(StudentDash SD)
	{
		DAL_Student_Dashboard = new DataAccess();
		arrParameter = new ArrayList();

		arrParameter.Add(new parameter("BMSID", SD.BMSID));
		arrParameter.Add(new parameter("SubjectID", SD.SubjectID));
		arrParameter.Add(new parameter("StudentID", SD.StudentID));

		return DAL_Student_Dashboard.DAL_Select("Proc_Select_Rescheduling_Data_Student", arrParameter);
	}

	public DataSet BAL_Validate_Student(StudentDash StudenDash)
	{
		DAL_Student_Dashboard = new DataAccess();
		arrParameter = new ArrayList();

		arrParameter.Add(new parameter("StudentID", StudenDash.StudentID));
		return DAL_Student_Dashboard.DAL_Select("PROC_Fetch_Student_PackageSubjects", arrParameter);
		// PROC_Fetch_Student_PackageSubjects
	}

	public DataSet BAL_Validate_Student_Package(StudentDash StudenDash)
	{
		DAL_Student_Dashboard = new DataAccess();
		arrParameter = new ArrayList();

		arrParameter.Add(new parameter("StudentID", StudenDash.StudentID));
		return DAL_Student_Dashboard.DAL_Select("studentpackagedetails_select", arrParameter);
		// PROC_Fetch_Student_PackageSubjects
	}
	

	public DataSet BAL_Select_PaymentPagesInfo(string FieldGroup)
	{
		DAL_Student_Dashboard = new DataAccess();
		arrParameter = new ArrayList();
		arrParameter.Add(new parameter("FieldGroup", FieldGroup));
		return DAL_Student_Dashboard.DAL_Select("PROC_GetConfigValueByFieldGroup", arrParameter);
	}

	public DataSet BAL_SelectStudentTestResultwithDetails(int SubjectID, int ChapterID, int TopicID, int BMSID, int StudentID, string TestType)
	{
		//DataAccessEpathshalaStudent DAL_Student = new DataAccessEpathshalaStudent();
		DataAccess DAL_Student = new DataAccess();
		arrParameter = new ArrayList();
		//arrParameter.Add(new parameter("SchoolID", SchoolID));
		arrParameter.Add(new parameter("SubjectID", SubjectID));
		arrParameter.Add(new parameter("BMSID", BMSID));
		arrParameter.Add(new parameter("ChapterID", ChapterID));
		arrParameter.Add(new parameter("TopicID", TopicID));
		arrParameter.Add(new parameter("StudentID", StudentID));
		arrParameter.Add(new parameter("TestType", TestType));
		return DAL_Student.DAL_Select("Proc_SelectStudentTestResultwithDetails", arrParameter);
	}


	public void get_DDLBMS(DropDownList ddlBBMS)
	{
		DAL_Student_Dashboard = new DataAccess();
		arrParameter = new ArrayList();
		try
		{
			ds = DAL_Student_Dashboard.DAL_SelectALL("Proc_SelectDistinctBMS");
			ddlBBMS.DataSource = ds.Tables[0];
			ddlBBMS.Items.Insert(0, new ListItem("-- SELECT --", "0"));
			ddlBBMS.DataTextField = ds.Tables[0].Columns["BMS"].ToString();
			ddlBBMS.DataValueField = ds.Tables[0].Columns["BMSID"].ToString();
			ddlBBMS.DataBind();
		}
		catch
		{
		}
		finally
		{
			ds.Clear();
		}
	}

	public void get_DDLSCT(DropDownList ddlSCT,int BMSID)
	{
		DAL_Student_Dashboard = new DataAccess();
		arrParameter = new ArrayList();
		try
		{
			arrParameter = new ArrayList();
			arrParameter.Add(new parameter("BMSID", BMSID));
			ds = DAL_Student_Dashboard.DAL_Select("Proc_SelectDistinctSCT", arrParameter);
			ddlSCT.DataSource = ds.Tables[0];
			ddlSCT.Items.Insert(0, new ListItem("-- SELECT --", "0"));
			ddlSCT.DataTextField = ds.Tables[0].Columns["SCT"].ToString();
			ddlSCT.DataValueField = ds.Tables[0].Columns["SCTID"].ToString();
			ddlSCT.DataBind();
		}
		catch
		{
		}
		finally
		{
			ds.Clear();
		}
	}

	public void get_DDLFieldGroup(DropDownList ddlFieldGroup)
	{
		DAL_Student_Dashboard = new DataAccess();
		arrParameter = new ArrayList();
		try
		{
			ds = DAL_Student_Dashboard.DAL_SelectALL("Proc_SelectDistinctFieldGroup");
			ddlFieldGroup.DataSource = ds.Tables[0];
			ddlFieldGroup.Items.Insert(0, new ListItem("-- SELECT --", "0"));
			ddlFieldGroup.DataTextField = ds.Tables[0].Columns["FieldGroup"].ToString();
			ddlFieldGroup.DataBind();
		}
		catch
		{
		}
		finally
		{
			ds.Clear();
		}
	}

	public DataSet get_GvlstSysConfig(string FieldGroup)
	{
		DAL_Student_Dashboard = new DataAccess();
		arrParameter = new ArrayList();

		arrParameter.Add(new parameter("FieldGroup", FieldGroup));
		ds = DAL_Student_Dashboard.DAL_Select("Proc_SelectSysConfigFields", arrParameter);

		return ds;
	}

	public int BAL_Insert_SysConfigFields1(string Field, string Type, string value, string FieldGroup, string Description)
	{
		DAL_Student_Dashboard = new DataAccess();
		arrParameter = new ArrayList();

		arrParameter.Add(new parameter("Field", Field));
		arrParameter.Add(new parameter("Type", Type));
		arrParameter.Add(new parameter("value",value));
		arrParameter.Add(new parameter("FieldGroup",FieldGroup));
		arrParameter.Add(new parameter("Description",Description));

		return DAL_Student_Dashboard.DAL_InsertUpdate_Return("Proc_Insert_SysConfigFields", arrParameter);
	}
	public DataSet BAL_Insert_SysConfigFields(string Field, string Type, string value, string FieldGroup, string Description)
	{
		DAL_Student_Dashboard = new DataAccess();
		arrParameter = new ArrayList();

		arrParameter.Add(new parameter("Field", Field));
		arrParameter.Add(new parameter("Type", Type));
		arrParameter.Add(new parameter("value", value));
		arrParameter.Add(new parameter("FieldGroup", FieldGroup));
		arrParameter.Add(new parameter("Description", Description));

		return DAL_Student_Dashboard.DAL_Select("Proc_Insert_SysConfigFields", arrParameter);
	}

	public int BAL_Edit_SysConfigFields(string Field, string Type, string value, string FieldGroup, string Description)
	{
		DAL_Student_Dashboard = new DataAccess();
		arrParameter = new ArrayList();

		arrParameter.Add(new parameter("Field", Field));
		arrParameter.Add(new parameter("Type", Type));
		arrParameter.Add(new parameter("value", value));
		arrParameter.Add(new parameter("FieldGroup", FieldGroup));
		arrParameter.Add(new parameter("Description", Description));

		return DAL_Student_Dashboard.DAL_InsertUpdate_Return("Proc_Edit_SysConfigFields", arrParameter);
	}

	public DataSet BAL_Select_ActivityFeedbackReviewRatingStudent(int BMSSCTID, int StudentID)
	{
		DataSet OFeedbackRating = new DataSet();
		DAL_Student_Dashboard = new DataAccess();
		arrParameter = new ArrayList();

		arrParameter.Add(new parameter("BMSSCTID", BMSSCTID));
		arrParameter.Add(new parameter("StudentID", StudentID));
		OFeedbackRating = DAL_Student_Dashboard.DAL_Select("Select_ActivityFeedbackReviewRatingStudent", arrParameter);

		return OFeedbackRating;

	}
	public DataSet BAL_Select_Student_Subjects(int StudentID)
	{
		DataSet SubjectList = new DataSet();
		DAL_Student_Dashboard = new DataAccess();
		arrParameter = new ArrayList();

		
		arrParameter.Add(new parameter("StudentID", StudentID));
		SubjectList = DAL_Student_Dashboard.DAL_Select("proc_Get_Student_Subjects", arrParameter);

		return SubjectList;
	}
}