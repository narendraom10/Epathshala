using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Data;

/// <summary>
/// Summary description for ActivityFeedbackRaing
/// </summary>
public class ActivityFeedbackRaing
{
    DataAccess Dal_AverageRating;
    ArrayList arrParameter;
    public DataSet GetActivityFeedback(int SchoolID, int BMSSCTID, int divisionID, int mode)
    {
        try
        {
            this.Dal_AverageRating = new DataAccess();
            arrParameter = new ArrayList();


            arrParameter.Add(new parameter("SchoolID", SchoolID));
            arrParameter.Add(new parameter("BMSSCTID",BMSSCTID));
            arrParameter.Add(new parameter("divisionID", divisionID));
            arrParameter.Add(new parameter("mode", mode));


            return this.Dal_AverageRating.DAL_Select("PROC_Select_Activity_Feedback_Teacher", arrParameter);
            //return this.Dal_AverageRating.DAL_Select("Proc_CalculateAverage", arrParameter);
            
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }



    public DataSet GetQuestionRatingAverage(int SchoolID, int BMSSCTID, int divisionID)
    {
        try
        {
            this.Dal_AverageRating = new DataAccess();
            arrParameter = new ArrayList();


            arrParameter.Add(new parameter("SchoolID", SchoolID));
            arrParameter.Add(new parameter("BMSSCTID", BMSSCTID));
            arrParameter.Add(new parameter("divisionID", divisionID));
            


            return this.Dal_AverageRating.DAL_Select("Proc_Select_Average_Question_Rating", arrParameter);
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    //public DataSet GetAverageRatingStudent(int SchoolID, int BMSSCTID)
    //{
    //    try
    //    {
    //        this.Dal_AverageRating = new DataAccess();
    //        arrParameter = new ArrayList();


    //        arrParameter.Add(new parameter("SchoolID", SchoolID));
    //        arrParameter.Add(new parameter("BMSSCTID", BMSSCTID));

    //        return this.Dal_AverageRating.DAL_Select("PROC_Select_Activity_Feedback_Rating_Sum_Student", arrParameter);
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }

    //}

    //public DataSet GetActivityFeedbackTeacher(int SchoolID, int BMSSCTID, int divisionID)
    //{
    //    try
    //    {
    //        this.Dal_AverageRating = new DataAccess();
    //        arrParameter = new ArrayList();


    //        arrParameter.Add(new parameter("SchoolID", SchoolID));
    //        arrParameter.Add(new parameter("BMSSCTID", BMSSCTID));
    //        arrParameter.Add(new parameter("ID", divisionID));

    //        return this.Dal_AverageRating.DAL_Select("PROC_Select_Feedback", arrParameter);
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }

    //}

    //public DataSet GetActivityFeedbackStudent(int SchoolID, int BMSSCTID, int divisionID)
    //{
    //    try
    //    {
    //        this.Dal_AverageRating = new DataAccess();
    //        arrParameter = new ArrayList();


    //        arrParameter.Add(new parameter("SchoolID", SchoolID));
    //        arrParameter.Add(new parameter("BMSSCTID", BMSSCTID));
    //        arrParameter.Add(new parameter("ID", divisionID));

    //        return this.Dal_AverageRating.DAL_Select("PROC_Select_Feedback_Student", arrParameter);
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }

    //}
}