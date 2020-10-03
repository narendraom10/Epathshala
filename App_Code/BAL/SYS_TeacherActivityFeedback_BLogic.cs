using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Data;

/// <summary>
/// Summary description for SYS_TeacherActivityFeedback_BLogic
/// </summary>
public class SYS_TeacherActivityFeedback_BLogic
{
    DataAccess DAccess;
    ArrayList arrParameter;

    public SYS_TeacherActivityFeedback_BLogic()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataSet BAL_Select_Activity_Feedback_Report()
    {
        DAccess = new DataAccess();
        arrParameter = new ArrayList();
        return DAccess.DAL_SelectALL("Proc_GetActivityFeedBackReport");
    }

    public DataSet BAL_Select_IsActivityFeedback_Settings(string Field)
    {
        DAccess = new DataAccess();
        arrParameter = new ArrayList();
        arrParameter.Add(new parameter("FieldName", Field));
        return DAccess.DAL_Select("PROC_GetConfigValue", arrParameter);
        //return DAccess.DAL_SelectALL("PROC_Select_IsActivityFeedback");
    }

    public int FachTopicwiseResult(SYS_TeacherActivityFeedback TA)
    {
        DAccess = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("SchoolID", TA.SchoolID));
        arrParameter.Add(new parameter("BMSSCTID", TA.BMSSCTID));
        arrParameter.Add(new parameter("EmployeeID", TA.EmployeeID));
        arrParameter.Add(new parameter("DivisionID", TA.DivisionID));
        arrParameter.Add(new parameter("Feedback", TA.Feedback));
        arrParameter.Add(new parameter("CreatedBy", TA.CreatedBy));
        arrParameter.Add(new parameter("FeedbackTable", TA.FeedbackQuestion));
        return DAccess.executescalre("PROC_INSERT_TeacherActivityFeedback", arrParameter);

    }

    public int SaveStudentFeeback(SYS_TeacherActivityFeedback TA)
    {
        //DataAccessEpathshalaStudent objDAL = new DataAccessEpathshalaStudent();
        DataAccess objDAL = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("SchoolID", TA.SchoolID));
        arrParameter.Add(new parameter("BMSSCTID", TA.BMSSCTID));
        arrParameter.Add(new parameter("StudentID", TA.StudentID));
        arrParameter.Add(new parameter("DivisionID", TA.DivisionID));
        arrParameter.Add(new parameter("Feedback", TA.Feedback));
        arrParameter.Add(new parameter("CreatedBy", TA.CreatedBy));
        arrParameter.Add(new parameter("FeedbackTable", TA.FeedbackQuestion));
        return objDAL.executescalre("PROC_INSERT_TeacherActivityFeedbackForStudent", arrParameter);
    }


    public DataSet BAL_Select_Report_Contact(string GroupName)
    {
        DAccess = new DataAccess();
        arrParameter = new ArrayList();
        arrParameter.Add(new parameter("GroupName", GroupName));
        return DAccess.DAL_Select("Peoc_Get_Report_Contact_GroupWise", arrParameter);
    }
    //public string Covered(SYS_TeacherActivityFeedback TA)
    //{
    //    DAccess = new DataAccess();
    //    arrParameter = new ArrayList();
    //    arrParameter.Add(new parameter("BMSSCTID", TA.BMSSCTID));
    //    arrParameter.Add(new parameter("DivisionID", TA.DivisionID));
    //    // return DAccess.executescalre("Proc_Activity", arrParameter);
    //    return DAccess.executescalre("Proc_Activity", arrParameter);
    //} 
    public string Covered(SYS_TeacherActivityFeedback TA)
    {
        DAccess = new DataAccess();
        arrParameter = new ArrayList();
        arrParameter.Add(new parameter("BMSSCTID", TA.BMSSCTID));
        arrParameter.Add(new parameter("DivisionID", TA.DivisionID));
        // return DAccess.executescalre("Proc_Activity", arrParameter);
        DataSet ds = new DataSet();
        ds = DAccess.DAL_Select("Proc_Activity", arrParameter);
        string rtnStr = "";
        if (ds.Tables.Count > 0)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                rtnStr = ds.Tables[0].Rows[0][0].ToString();
            }
        }
        return rtnStr;
    }


}