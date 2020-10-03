using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Data;

///// <summary>
///// Summary description for ClassRoomActivityLog_BLogic
///// </summary>


public class ClassRoomActivityLog_BLogic
{
    DataAccess DAL_ClassRoomActivityLog;
    ArrayList arrParameter;

    public ClassRoomActivityLog_BLogic()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public int BAL_ClassRoomActivityLog_Insert(ClassRoomActivityLog ClassRoomActivityLog)
    {
        DAL_ClassRoomActivityLog = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("BMSSCTID", ClassRoomActivityLog.bmssctid));
        arrParameter.Add(new parameter("SchoolID", ClassRoomActivityLog.schoolid));
        arrParameter.Add(new parameter("EmployeeID", ClassRoomActivityLog.employeeid));
        arrParameter.Add(new parameter("DivisionID", ClassRoomActivityLog.divisionid));

        return DAL_ClassRoomActivityLog.executescalre("Proc_Insert_ClassRoomActivityLog", arrParameter);
    }

    public int BAL_ClassRoomActivityLog_Insert_Student(ClassRoomActivityLog ClassRoomActivityLog)
    {
        DAL_ClassRoomActivityLog = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("BMSSCTID", ClassRoomActivityLog.bmssctid));
        arrParameter.Add(new parameter("StudentID", ClassRoomActivityLog.Studentid));
        arrParameter.Add(new parameter("ActivityFeedback", ClassRoomActivityLog.ActivityFeedback));

        return DAL_ClassRoomActivityLog.executescalre("Proc_Insert_ClassRoomActivityLog_Student", arrParameter);
    }

    public int BAL_ClassRoomActivityLog_InsertRating_Student(ClassRoomActivityLog ClassRoomActivityLog)
    {
        DAL_ClassRoomActivityLog = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("BMSSCTID", ClassRoomActivityLog.bmssctid));
        arrParameter.Add(new parameter("StudentID", ClassRoomActivityLog.Studentid));
        if (ClassRoomActivityLog.ActivityFeedback != null)
            arrParameter.Add(new parameter("Review", ClassRoomActivityLog.ActivityFeedback));
        else
            arrParameter.Add(new parameter("Rating", ClassRoomActivityLog.FeedbackRating));

        return DAL_ClassRoomActivityLog.executescalre("Proc_InsertRating_ClassRoomActivityLog_Student", arrParameter);
    }

    public int BAL_ClassRoomActivityLog_InsertReview_Student(ClassRoomActivityLog ClassRoomActivityLog)
    {
        DAL_ClassRoomActivityLog = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("BMSSCTID", ClassRoomActivityLog.bmssctid));
        arrParameter.Add(new parameter("StudentID", ClassRoomActivityLog.Studentid));
        arrParameter.Add(new parameter("Rating", ClassRoomActivityLog.FeedbackRating));

        return DAL_ClassRoomActivityLog.executescalre("Proc_InsertRating_ClassRoomActivityLog_Student", arrParameter);
    }

    public void BAL_ReScheduling_ActivityLog_Update(ClassRoomActivityLog ClassRoomActivityLog)
    {
        DAL_ClassRoomActivityLog = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("ReSchedulingID", ClassRoomActivityLog.ReSchedulingID));
        arrParameter.Add(new parameter("BMSSCTID", ClassRoomActivityLog.bmssctid));
        arrParameter.Add(new parameter("SchoolID", ClassRoomActivityLog.schoolid));
        arrParameter.Add(new parameter("EmployeeID", ClassRoomActivityLog.employeeid));
        arrParameter.Add(new parameter("DivisionID", ClassRoomActivityLog.divisionid));

        DAL_ClassRoomActivityLog.executescalre("Proc_Update_ReScheduling_ActivityLog", arrParameter);
    }

    public void BAL_ReScheduling_ActivityLog_Update_Student(ClassRoomActivityLog ClassRoomActivityLog)
    {
        DAL_ClassRoomActivityLog = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("SReSchedulingID", ClassRoomActivityLog.SReSchedulingID));
        arrParameter.Add(new parameter("BMSSCTID", ClassRoomActivityLog.bmssctid));
        arrParameter.Add(new parameter("StudentID", ClassRoomActivityLog.Studentid));

        DAL_ClassRoomActivityLog.executescalre("Proc_Update_ReScheduling_ActivityLog_Student", arrParameter);
    }

    public void BAL_ClassRoomActivityLog_Update(ClassRoomActivityLog ClassRoomActivityLog, string mode)
    {
        DAL_ClassRoomActivityLog = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("mode", mode));
        arrParameter.Add(new parameter("CRALID", ClassRoomActivityLog.cralid));
        arrParameter.Add(new parameter("BMSSCTID", ClassRoomActivityLog.bmssctid));
        arrParameter.Add(new parameter("SchoolID", ClassRoomActivityLog.schoolid));
        arrParameter.Add(new parameter("EmployeeID", ClassRoomActivityLog.employeeid));
        arrParameter.Add(new parameter("DivisionID", ClassRoomActivityLog.divisionid));

        DAL_ClassRoomActivityLog.DAL_InsertUpdate("Proc_ClassRoomActivityLogInsertUpdate", arrParameter);
    }

    public void BAL_ClassRoomActivityLog_Delete(ClassRoomActivityLog ClassRoomActivityLog, string mode)
    {
        DAL_ClassRoomActivityLog = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("mode", mode));
        arrParameter.Add(new parameter("CRALID", ClassRoomActivityLog.cralid));
        arrParameter.Add(new parameter("BMSSCTID", ClassRoomActivityLog.bmssctid));
        arrParameter.Add(new parameter("SchoolID", ClassRoomActivityLog.schoolid));
        arrParameter.Add(new parameter("EmployeeID", ClassRoomActivityLog.employeeid));
        arrParameter.Add(new parameter("DivisionID", ClassRoomActivityLog.divisionid));

        DAL_ClassRoomActivityLog.DAL_Delete("Proc_ClassRoomActivityLogSelectDelete", arrParameter);
    }

    public DataSet BAL_ClassRoomActivityLog_Select(ClassRoomActivityLog ClassRoomActivityLog, string mode)
    {
        DAL_ClassRoomActivityLog = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("mode", mode));
        arrParameter.Add(new parameter("CRALID", ClassRoomActivityLog.cralid));
        arrParameter.Add(new parameter("BMSSCTID", ClassRoomActivityLog.bmssctid));
        arrParameter.Add(new parameter("SchoolID", ClassRoomActivityLog.schoolid));
        arrParameter.Add(new parameter("EmployeeID", ClassRoomActivityLog.employeeid));
        arrParameter.Add(new parameter("DivisionID", ClassRoomActivityLog.divisionid));

        return DAL_ClassRoomActivityLog.DAL_Select("Proc_ClassRoomActivityLogSelectDelete", arrParameter);
    }

    public DataSet BAL_ClassRoomActivityLog_SelectAll()
    {
        DAL_ClassRoomActivityLog = new DataAccess();
        return DAL_ClassRoomActivityLog.DAL_SelectALL("Proc_ClassRoomActivityLogSELECTAll");
    }





}