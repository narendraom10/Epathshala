using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Collections;

/// <summary>
/// Summary description for Feedback_BLogic
/// </summary>
public class Feedback_BLogic
{
    DataAccess objDAL;
    ArrayList arrParameter;
    public Feedback_BLogic()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    public DataTable GetFeedbackDetail(SYS_TeacherActivityFeedback TA)
    {
        try
        {
            objDAL = new DataAccess();
            arrParameter = new ArrayList();

            arrParameter.Add(new parameter("SchoolID", TA.SchoolID));
            arrParameter.Add(new parameter("BMSSCTID", TA.BMSSCTID));
            arrParameter.Add(new parameter("EmployeeID", TA.EmployeeID));
            arrParameter.Add(new parameter("DivisionID", TA.DivisionID));
            arrParameter.Add(new parameter("CreatedBy", TA.CreatedBy));

            //return objDAL.DAL_SelectAll("Proc_SelectFeedbackQuestionList").Tables[0];
            return objDAL.DAL_Select("Proc_SelectFeedbackQuestionListNew", arrParameter).Tables[0];
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    public DataTable GetFeedbackDetail1(SYS_TeacherActivityFeedback TA)
    {
        try
        {
            objDAL = new DataAccess();
            arrParameter = new ArrayList();

            arrParameter.Add(new parameter("SchoolID", TA.SchoolID));
            arrParameter.Add(new parameter("BMSSCTID", TA.BMSSCTID));
            arrParameter.Add(new parameter("DivisionID", TA.DivisionID));
            

            //return objDAL.DAL_SelectAll("Proc_SelectFeedbackQuestionList").Tables[0];
            return objDAL.DAL_Select("Proc_SelectFeedbackQuestionListNew1", arrParameter).Tables[0];
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    public DataTable GetFeedbackDetailStudent(SYS_TeacherActivityFeedback TA)
    {
        try
        {
            //DataAccessEpathshalaStudent objDAL = new DataAccessEpathshalaStudent();
            DataAccess objDAL = new DataAccess();
            arrParameter = new ArrayList();

            arrParameter.Add(new parameter("SchoolID", TA.SchoolID));
            arrParameter.Add(new parameter("BMSSCTID", TA.BMSSCTID));
            arrParameter.Add(new parameter("StudentID", TA.StudentID));
            arrParameter.Add(new parameter("DivisionID", TA.DivisionID));
            arrParameter.Add(new parameter("CreatedBy", TA.CreatedBy));

            return objDAL.DAL_Select("Proc_SelectFeedbackQuestionListForStudent", arrParameter).Tables[0];
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    public DataTable GetFeedbackDetailStudent1(SYS_TeacherActivityFeedback TA)
    {
        try
        {
            //DataAccessEpathshalaStudent objDAL = new DataAccessEpathshalaStudent();
            DataAccess objDAL = new DataAccess();
            arrParameter = new ArrayList();

            arrParameter.Add(new parameter("SchoolID", TA.SchoolID));
            arrParameter.Add(new parameter("BMSSCTID", TA.BMSSCTID));
            
            arrParameter.Add(new parameter("StudentID", TA.StudentID));
            

            return objDAL.DAL_Select("Proc_SelectFeedbackQuestionListForStudent1", arrParameter).Tables[0];
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }


    

    public DataSet GetFeedbackQuestionDetail()
    {
        try
        {
            objDAL = new DataAccess();
            return objDAL.DAL_SelectALL("Proc_SelectFeedbackQuestion");
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    public int InsertUpdateFeedbackQuestion(string mode, string Feedback, int FeedbackID, int EmployeeID)
    {
        try
        {
            objDAL = new DataAccess();
            arrParameter = new ArrayList();
            arrParameter.Add(new parameter("mode", mode));
            arrParameter.Add(new parameter("FeedbackID", FeedbackID));
            arrParameter.Add(new parameter("Feedback", Feedback));
            //arrParameter.Add(new parameter("IsActive", IsActive));
            arrParameter.Add(new parameter("EmployeeID", EmployeeID));

            return objDAL.DAL_InsertUpdate_Return("Proc_InsertUpdateFeedbackQuestion", arrParameter);
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }



    public int BAL_SYS_FeedbackStatus(int FeedbackQuestionIDStr, bool IsActive)
    {
        try
        {
            objDAL = new DataAccess();
            arrParameter = new ArrayList();
            arrParameter.Add(new parameter("FeedbackQuestionID", FeedbackQuestionIDStr));
            arrParameter.Add(new parameter("IsActive", IsActive));

            return objDAL.DAL_InsertUpdate_Return("Proc_UpdateFeedbackQuestionStatus", arrParameter);
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
}