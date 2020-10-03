using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Collections;

/// <summary>
/// Summary description for QuestionMaster
/// </summary>
public class QuestionMaster
{
    DataAccess DAL_Question;
    ArrayList arrParameter;
	public QuestionMaster()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataSet SELECTAll_QuestionByBMSSCTID(int JumbleQuestion,int level,int noofquestion,int bmssctid,string TestType)
    {

        DAL_Question = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("JumbleQuestion", JumbleQuestion));
        arrParameter.Add(new parameter("level", level));
        arrParameter.Add(new parameter("noofquestion", noofquestion));
        arrParameter.Add(new parameter("bmssctid", bmssctid));
        arrParameter.Add(new parameter("TestType", TestType));
        //arrParameter.Add(new parameter("SearchCondition", SearchCondition));
        return DAL_Question.DAL_Select("SELECTAll_QuestionByBMSSCTID", arrParameter);
    }
    public DataSet SELECTAll_QuestionByBMSSCTIDAutoExam(string bmssctid, string TestType,string From,string NumberofQuestion)
    {

        DAL_Question = new DataAccess();
        arrParameter = new ArrayList();

        //arrParameter.Add(new parameter("JumbleQuestion", JumbleQuestion));
        //arrParameter.Add(new parameter("level", level));
        //arrParameter.Add(new parameter("noofquestion", noofquestion));
        arrParameter.Add(new parameter("bmssctid", bmssctid));
        arrParameter.Add(new parameter("TestType", TestType));
        arrParameter.Add(new parameter("From", From));
        arrParameter.Add(new parameter("NumberofQuestion", NumberofQuestion));
        //arrParameter.Add(new parameter("SearchCondition", SearchCondition));
        return DAL_Question.DAL_Select("SELECTAll_QuestionByBMSSCTIDAutoExam", arrParameter);
    }
    public DataSet SELECT_TotalNumStudents(int TrackLogID)
    {

        DAL_Question = new DataAccess();
        arrParameter = new ArrayList();

       
        arrParameter.Add(new parameter("TrackLogID", TrackLogID));
        return DAL_Question.DAL_Select("SELECT_TotalNumStudentsByTrackLog", arrParameter);
    }
    public void BAL_StudentExamResult(int epathparaid,int studentid,DataTable dt,string testType)
    {
        //DataAccessEpathshalaStudent DAL_Question = new DataAccessEpathshalaStudent();
        DataAccess DAL_Question = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("BMSSCTID", epathparaid));
        arrParameter.Add(new parameter("StudentID", studentid));
        arrParameter.Add(new parameter("TestType", testType));
        DAL_Question.DAL_InsertUpdateDataTable("PROC_Insert_StudentResultPortal", arrParameter,dt);
    }
}