using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Data;

/// <summary>
/// Summary description for TrackLog_Utils
/// </summary>
public class TrackLog_Utils
{
    public TrackLog_Utils()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static void Log(Int32 SchoolID, Int32 EmployeeID, Int16 DivisionID, String PageName, String ControlName, String EventName, DateTime ActivityDate, String SessionID, String Activity, String Remark, Int32 BMSSCTID)
    {
        Teacher_Dashboard_BLogic obj_BAL_Teacher_Dashboard = new Teacher_Dashboard_BLogic();
        DataSet dsSettings = new DataSet();
        dsSettings = obj_BAL_Teacher_Dashboard.BAL_Select_Maintain_activity_log_Settings();

        object datatype = dsSettings.Tables[0].Rows[0]["Type"].ToString();
        object val = dsSettings.Tables[0].Rows[0]["value"].ToString();

        if (Convert.ToBoolean(Convert.ToInt16(val)))
        {
            DataAccess DAL_Teacher_Dashboard = new DataAccess();
            ArrayList arrParameter = new ArrayList();

            arrParameter.Add(new parameter("SchoolID", SchoolID));
            arrParameter.Add(new parameter("EmployeeID", EmployeeID));
            arrParameter.Add(new parameter("DivisionID", DivisionID));
            arrParameter.Add(new parameter("PageName", PageName));
            arrParameter.Add(new parameter("ControlName", ControlName));
            arrParameter.Add(new parameter("EventName", EventName));
            arrParameter.Add(new parameter("ActivityDate", ActivityDate));
            arrParameter.Add(new parameter("SessionID", SessionID));
            arrParameter.Add(new parameter("Activity", Activity));
            arrParameter.Add(new parameter("Remark", Remark));
            arrParameter.Add(new parameter("BMSSCTID", BMSSCTID));
            arrParameter.Add(new parameter("RoleID", AppSessions.RoleID));

            DAL_Teacher_Dashboard.DAL_InsertUpdate("PORC_INSERT_TrackLog", arrParameter);
        }
    }

    public static void Log_StudentActivity(Int32 SchoolID, Int32 StudentID, Int16 DivisionID, String PageName, String ControlName, String EventName, DateTime ActivityDate, String SessionID, String Activity, String Remark, Int32 BMSSCTID)
    {
        Teacher_Dashboard_BLogic obj_BAL_Teacher_Dashboard = new Teacher_Dashboard_BLogic();
        DataSet dsSettings = new DataSet();

        dsSettings = obj_BAL_Teacher_Dashboard.BAL_Select_Maintain_activity_log_Settings();

        object datatype = dsSettings.Tables[0].Rows[0]["Type"].ToString();
        object val = dsSettings.Tables[0].Rows[0]["value"].ToString();

        if (Convert.ToBoolean(Convert.ToInt16(val)))
        {
            DataAccess DAL_Teacher_Dashboard = new DataAccess();
            ArrayList arrParameter = new ArrayList();

            arrParameter.Add(new parameter("SchoolID", SchoolID));
            arrParameter.Add(new parameter("EmployeeID", StudentID));
            arrParameter.Add(new parameter("DivisionID", DivisionID));
            arrParameter.Add(new parameter("PageName", PageName));
            arrParameter.Add(new parameter("ControlName", ControlName));
            arrParameter.Add(new parameter("EventName", EventName));
            arrParameter.Add(new parameter("ActivityDate", ActivityDate));
            arrParameter.Add(new parameter("SessionID", SessionID));
            arrParameter.Add(new parameter("Activity", Activity));
            arrParameter.Add(new parameter("Remark", Remark));
            arrParameter.Add(new parameter("BMSSCTID", BMSSCTID));
            arrParameter.Add(new parameter("RoleID", AppSessions.RoleID));

            DAL_Teacher_Dashboard.DAL_InsertUpdate("sp_Log_StudentActivity", arrParameter);
        }
    }
    public DataSet SELECTExamTrackLogOtherEmployee(int BMSID, int SchoolID, int Division, int EmpolyeeID)
    {

        DataAccess DAL_Access = new DataAccess();
        ArrayList arrParameter = new ArrayList();

        arrParameter.Add(new parameter("BMSID", BMSID));
        arrParameter.Add(new parameter("SchoolID", SchoolID));
        arrParameter.Add(new parameter("Division", Division));
        arrParameter.Add(new parameter("EmpolyeeID", EmpolyeeID));

        return DAL_Access.DAL_Select("PORC_SELECTExamTrackLogOtherEmployee", arrParameter);
    }

    public static void LogGroupBMSSCTID(string TrackLogID, int EmployeeID, string GroupBMSSCT)
    {
        DataAccess DAL_Teacher_Dashboard = new DataAccess();
        ArrayList arrParameter = new ArrayList();

        arrParameter.Add(new parameter("TrackLogID", TrackLogID));
        arrParameter.Add(new parameter("BMSSCTIDGroup", GroupBMSSCT));
        arrParameter.Add(new parameter("CreatedBy", EmployeeID));

        DAL_Teacher_Dashboard.DAL_InsertUpdate("TrackLogBMSSCTMapping_insert", arrParameter);
    }
    public static string GetLogedGroupBMSSCTID(string TrackLogID)
    {
        DataAccess DAL_Teacher_Dashboard = new DataAccess();
        ArrayList arrParameter = new ArrayList();
        DataSet oDs = new DataSet();

        arrParameter.Add(new parameter("TrackLogID", TrackLogID));

        oDs = DAL_Teacher_Dashboard.DAL_Select("TrackLogBMSSCTMapping_GetGroupBMSSCTID", arrParameter);

        if (oDs.Tables[0].Rows.Count > 0)
            return oDs.Tables[0].Rows[0][0].ToString();
        else
            return "";
    }
}