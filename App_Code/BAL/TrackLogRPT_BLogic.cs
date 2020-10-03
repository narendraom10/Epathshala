using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Data;

/// <summary>
/// Summary description for TrackLogRPT_BLogic
/// </summary>
public class TrackLogRPT_BLogic
{
    DataAccess DAL_TLRPT;
    ArrayList arrParameter;

    public TrackLogRPT_BLogic()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataSet BAL_Select_Active_Schools_BMS()
    {
        DAL_TLRPT = new DataAccess();
        return DAL_TLRPT.DAL_SelectALL("PROC_Select_Active_Schools");
    }

    public DataSet BAL_Select_TeacherTrackLog(Int64 SchoolID, Int64 BMSID, Int16 DivisionID, DateTime StartDate, DateTime EndDate)
    {
        DAL_TLRPT = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("SchoolID", SchoolID));
        arrParameter.Add(new parameter("BMSID", BMSID));
        arrParameter.Add(new parameter("DivisionID", DivisionID));
        arrParameter.Add(new parameter("StartDate", StartDate));
        arrParameter.Add(new parameter("EndDate", EndDate));

        return DAL_TLRPT.DAL_Select("PROC_Select_Teacher_TrackLog", arrParameter);
    }

    public DataSet BAL_Select_TeacherWiseTrackLog(Int64 SchoolID, Int64 BoardID, Int64 MediumID, Int64 StandardID, Int16 DivisionID, DateTime StartDate, DateTime EndDate)
    {
        DAL_TLRPT = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("SchoolID", SchoolID));
        arrParameter.Add(new parameter("BoardID", BoardID));
        arrParameter.Add(new parameter("MediumID", MediumID));
        arrParameter.Add(new parameter("StandardID", StandardID));
        arrParameter.Add(new parameter("DivisionID", DivisionID));
        arrParameter.Add(new parameter("StartDate", StartDate));
        arrParameter.Add(new parameter("EndDate", EndDate));

        return DAL_TLRPT.DAL_Select("PROC_Select_TeacherWise_TrackLog", arrParameter);
    }
    public DataSet BAL_Select_TeacherWiseBMSSCTWiseTrackLog(Int64 SchoolID, Int64 BoardID, Int64 MediumID, Int64 StandardID, Int16 DivisionID, DateTime StartDate, DateTime EndDate)
    {
        DAL_TLRPT = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("SchoolID", SchoolID));
        arrParameter.Add(new parameter("BoardID", BoardID));
        arrParameter.Add(new parameter("MediumID", MediumID));
        arrParameter.Add(new parameter("StandardID", StandardID));
        arrParameter.Add(new parameter("DivisionID", DivisionID));
        arrParameter.Add(new parameter("StartDate", StartDate));
        arrParameter.Add(new parameter("EndDate", EndDate));

        return DAL_TLRPT.DAL_Select("PROC_Select_TeacherWiseBMSSCTWise_TrackLog", arrParameter);
    }
    public DataSet BAL_Select_TeacherWiseBMSSCTWiseBYEmpIDTrackLog(Int64 EmpID, DateTime ActivityDate)
    {
        DAL_TLRPT = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("ActivityDate", ActivityDate));
        arrParameter.Add(new parameter("EmpID", EmpID));

        return DAL_TLRPT.DAL_Select("PROC_Select_TeacherWiseBMSSCTWiseBYEmpID_TrackLog", arrParameter);
    }
    public DataSet BAL_Select_TeacherWiseBMSSCTWiseBYEmpIDBMSSCTIDTrackLog(Int64 BMSSCTID, Int64 DivisionID, Int64 EmpID, DateTime ActivityDate)
    {
        DAL_TLRPT = new DataAccess();
        arrParameter = new ArrayList();


        arrParameter.Add(new parameter("BMSSCTID", BMSSCTID));
        arrParameter.Add(new parameter("DivisionID", DivisionID));
        arrParameter.Add(new parameter("EmpID", EmpID));
        arrParameter.Add(new parameter("ActivityDate", ActivityDate));


        return DAL_TLRPT.DAL_Select("PROC_Select_TeacherWiseBMSSCTWiseBYEmpIDBMSSCTID_TrackLog", arrParameter);
    }

    public DataSet BAL_Select_ClassRoom_TrackLog(Int64 SchoolID, Int64 BMSID, Int16 DivisionID, DateTime StartDate)
    {
        DAL_TLRPT = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("SchoolID", SchoolID));
        arrParameter.Add(new parameter("BMSID", BMSID));
        arrParameter.Add(new parameter("DivisionID", DivisionID));
        arrParameter.Add(new parameter("ActivityDate", StartDate));

        return DAL_TLRPT.DAL_Select("PROC_Select_ClassRoom_TrackLog", arrParameter);
    }
}