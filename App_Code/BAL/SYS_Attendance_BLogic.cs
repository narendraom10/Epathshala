using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Collections;

/// <summary>
/// Summary description for SYS_Attendance_BLogic
/// </summary>
public class SYS_Attendance_BLogic
{
    DataAccess DAL_SYS_Status;
    ArrayList arrParameter;
    SYS_Attendance Prop_SYS_Attendance;
    public SYS_Attendance_BLogic()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    // By Arpit

    public void BAL_StudentAttedance_Insert(SYS_Attendance Prop_SYS_Attendance, string mode)
    {
        DAL_SYS_Status = new DataAccess();
        arrParameter = new ArrayList();
        arrParameter.Add(new parameter("CreatedBy", Prop_SYS_Attendance.EmployeeID));
        arrParameter.Add(new parameter("BMSID", Prop_SYS_Attendance.BMSID));
        arrParameter.Add(new parameter("DivisionID", Prop_SYS_Attendance.DivisionId));
        arrParameter.Add(new parameter("AttedanceDetails", Prop_SYS_Attendance.AttedanceDetails));
        arrParameter.Add(new parameter("SchoolID", Prop_SYS_Attendance.SchoolID));
        DAL_SYS_Status.DAL_InsertUpdate("proc_FillAttendance", arrParameter);
    }

    public void BAL_StudentAttedance_Admin_Update(SYS_Attendance Prop_SYS_Attendance, string mode)
    {
        DAL_SYS_Status = new DataAccess();
        arrParameter = new ArrayList();
        arrParameter.Add(new parameter("CreatedBy", Prop_SYS_Attendance.EmployeeID));
        arrParameter.Add(new parameter("BMSID", Prop_SYS_Attendance.BMSID));
        arrParameter.Add(new parameter("DivisionID", Prop_SYS_Attendance.DivisionId));
        arrParameter.Add(new parameter("AttedanceDetails", Prop_SYS_Attendance.AttedanceDetails));
        arrParameter.Add(new parameter("SchoolID", Prop_SYS_Attendance.SchoolID));
        arrParameter.Add(new parameter("Date", Prop_SYS_Attendance.AttendanceDate));
        DAL_SYS_Status.DAL_InsertUpdate("proc_FillAttendance", arrParameter);
    }

    public DataSet BAL_SYS_Attendance_SelectAll(SYS_Attendance Prop_SYS_Attendance, String mode)
    {
        DAL_SYS_Status = new DataAccess();
        arrParameter = new ArrayList();
        arrParameter.Add(new parameter("mode", mode));
        arrParameter.Add(new parameter("EmployeeID", Prop_SYS_Attendance.EmployeeID));
        arrParameter.Add(new parameter("DivisionID", Prop_SYS_Attendance.DivisionId));
        arrParameter.Add(new parameter("BMSID", Prop_SYS_Attendance.BMSID));
        DataSet dsselect = new DataSet();
        dsselect = DAL_SYS_Status.DAL_Select("PROC_Select_Student", arrParameter);
        return dsselect;
    }

    public DataSet BAL_SYS_Attendance_TeacherWiseStudents(SYS_Attendance Prop_SYS_Attendance, String mode)
    {
        DAL_SYS_Status = new DataAccess();
        arrParameter = new ArrayList();
        arrParameter.Add(new parameter("DivisionID", Prop_SYS_Attendance.DivisionId));
        arrParameter.Add(new parameter("SchoolID", Prop_SYS_Attendance.SchoolID));
        arrParameter.Add(new parameter("BMSID", Prop_SYS_Attendance.BMSID));
        arrParameter.Add(new parameter("SortBy", Prop_SYS_Attendance.SortBy));
        DataSet dsselect = new DataSet();
        dsselect = DAL_SYS_Status.DAL_Select("Proc_GetStudentAttendance", arrParameter);
        return dsselect;
    }

    public DataSet BAL_SYS_Attendance_Students(SYS_Attendance Prop_SYS_Attendance, String mode)
    {
        DAL_SYS_Status = new DataAccess();
        arrParameter = new ArrayList();
        arrParameter.Add(new parameter("DivisionID", Prop_SYS_Attendance.DivisionId));
        arrParameter.Add(new parameter("SchoolID", Prop_SYS_Attendance.SchoolID));
        arrParameter.Add(new parameter("BMSID", Prop_SYS_Attendance.BMSID));
        arrParameter.Add(new parameter("Date", Prop_SYS_Attendance.AttendanceDate));
        arrParameter.Add(new parameter("SortBy", Prop_SYS_Attendance.SortBy));
        DataSet dsselect = new DataSet();
        dsselect = DAL_SYS_Status.DAL_Select("Proc_GetStudentAttendance", arrParameter);
        return dsselect;
    }

    public DataSet BAL_SYS_Attendance_SchoolAdmin(SYS_Attendance Prop_SYS_Attendance, String mode)
    {
        DataSet ds = new DataSet();
        DAL_SYS_Status = new DataAccess();
        arrParameter = new ArrayList();
        arrParameter.Add(new parameter("BoardID", Prop_SYS_Attendance.BoardID));
        return DAL_SYS_Status.DAL_Select("PROC_Select_StaDiv", arrParameter);
    }

    public DataSet BAL_SYS_Attendance_Total(SYS_Attendance Prop_SYS_Attendance, String mode)
    {
        DataSet ds = new DataSet();
        DAL_SYS_Status = new DataAccess();
        arrParameter = new ArrayList();
        arrParameter.Add(new parameter("SchoolID", Prop_SYS_Attendance.SchoolID));
        arrParameter.Add(new parameter("BoardID", Prop_SYS_Attendance.BoardID));
        return DAL_SYS_Status.DAL_Select("PROC_Select_Attendance", arrParameter);
    }
    public DataSet BAL_SYS_Attendance_Details(SYS_Attendance Prop_SYS_Attendance, String mode)
    {
        DataSet ds = new DataSet();
        DAL_SYS_Status = new DataAccess();
        arrParameter = new ArrayList();
        arrParameter.Add(new parameter("BMSID", Prop_SYS_Attendance.BMSID));
        arrParameter.Add(new parameter("DivisionID", Prop_SYS_Attendance.DivisionId));
        arrParameter.Add(new parameter("DivisionIDstr", Prop_SYS_Attendance.DivisionIdstr));
        arrParameter.Add(new parameter("StartDate", Prop_SYS_Attendance.StartDate));
        arrParameter.Add(new parameter("EndDate", Prop_SYS_Attendance.EndDate));
        return DAL_SYS_Status.DAL_Select("PROC_Select_Attendance", arrParameter);
    }

    public DataSet BAL_SYS_GetAttendaceStudent(SYS_Attendance Prop_SYS_Attendance, String mode)
    {
        DataSet dsselect = new DataSet();
        try
        {

            DAL_SYS_Status = new DataAccess();
            arrParameter = new ArrayList();
            arrParameter.Add(new parameter("CreatedBy", Prop_SYS_Attendance.EmployeeID));
            arrParameter.Add(new parameter("BMSID", Prop_SYS_Attendance.BMSID));
            arrParameter.Add(new parameter("DivisionID", Prop_SYS_Attendance.DivisionId));
            arrParameter.Add(new parameter("AttedanceDetails", Prop_SYS_Attendance.AttedanceDetails));
            arrParameter.Add(new parameter("SchoolID", Prop_SYS_Attendance.SchoolID));

            dsselect = DAL_SYS_Status.DAL_Select("proc_LogAttendanceRecord", arrParameter);
        }
        catch (Exception ex)
        {

        }
        return dsselect;
    }

    public DataSet BAL_SYS_UpdateMessageStatus(string xmldt)
    {
        DataSet dsselect = new DataSet();
        try
        {

            DAL_SYS_Status = new DataAccess();
            arrParameter = new ArrayList();
            arrParameter.Add(new parameter("updatexml", xmldt));

            dsselect = DAL_SYS_Status.DAL_Select("proc_UpdateMessageStatus", arrParameter);
        }
        catch (Exception ex)
        {

        }
        return dsselect;
    }

}