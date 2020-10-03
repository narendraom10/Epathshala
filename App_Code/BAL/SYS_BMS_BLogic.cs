using System.Data;
using System.Collections;
using System;

/// <summary> 
/// <DevelopedBy>"NARENDRASINH"</DevelopedBy>
/// <DevelopedDate></DevelopedDate>
/// <UpdatedBy>"NARENDRASINH"</UpdatedBy>
/// <UpdatedDate></UpdatedDate>
/// </summary>


public class SYS_BMS_BLogic
{
    DataAccess DAL_SYS_BMS;
    ArrayList arrParameter;
    SYS_BMS PBMS = new SYS_BMS();

    public SYS_BMS_BLogic()
    {
        //
        // TODO: Add constructor logic here
        //
    }



    public int BAL_SYS_BMS_Insert(SYS_BMS SYS_BMS, string mode)
    {
        DAL_SYS_BMS = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("mode", mode));
        arrParameter.Add(new parameter("BMSID", SYS_BMS.bmsid));
        arrParameter.Add(new parameter("BoardID", SYS_BMS.boardid));
        arrParameter.Add(new parameter("MediumID", SYS_BMS.mediumid));
        arrParameter.Add(new parameter("StandardID", SYS_BMS.standardid));
        arrParameter.Add(new parameter("IsSemester", SYS_BMS.issemester));
        arrParameter.Add(new parameter("CreatedBy", SYS_BMS.createdby));
        return DAL_SYS_BMS.DAL_InsertUpdate_Return("Proc_SYS_BMSInsertUpdate", arrParameter);
    }

    public int BAL_SYS_BMS_Update(SYS_BMS SYS_BMS, string mode)
    {
        DAL_SYS_BMS = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("mode", mode));
        arrParameter.Add(new parameter("BMSID", SYS_BMS.bmsid));
        arrParameter.Add(new parameter("BoardID", SYS_BMS.boardid));
        arrParameter.Add(new parameter("MediumID", SYS_BMS.mediumid));
        arrParameter.Add(new parameter("StandardID", SYS_BMS.standardid));
        arrParameter.Add(new parameter("IsSemester", SYS_BMS.issemester));
        arrParameter.Add(new parameter("CreatedBy", SYS_BMS.createdby));
        return DAL_SYS_BMS.DAL_InsertUpdate_Return("Proc_SYS_BMSInsertUpdate", arrParameter);
    }

    public void BAL_SYS_BMS_Delete(SYS_BMS SYS_BMS, string mode)
    {
        DAL_SYS_BMS = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("mode", mode));
        arrParameter.Add(new parameter("BMSID", SYS_BMS.bmsid));
        arrParameter.Add(new parameter("BMSIDStr", SYS_BMS.bmsidStr));
        arrParameter.Add(new parameter("BoardID", SYS_BMS.boardid));
        arrParameter.Add(new parameter("MediumID", SYS_BMS.mediumid));
        arrParameter.Add(new parameter("StandardID", SYS_BMS.standardid));

        DAL_SYS_BMS.DAL_Delete("Proc_SYS_BMSSelectDelete", arrParameter);
    }

    public DataSet BAL_SYS_BMS_Select(SYS_BMS SYS_BMS, string mode)
    {
        DAL_SYS_BMS = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("mode", mode));
        arrParameter.Add(new parameter("BMSID", SYS_BMS.bmsid));
        arrParameter.Add(new parameter("BoardID", SYS_BMS.boardid));
        arrParameter.Add(new parameter("MediumID", SYS_BMS.mediumid));
        arrParameter.Add(new parameter("StandardID", SYS_BMS.standardid));

        return DAL_SYS_BMS.DAL_Select("Proc_SYS_BMSSelectDelete", arrParameter);
    }
    public DataSet BAL_SYS_BMSSCT_ByBMSSCTID(int bmssctid)
    {
        DAL_SYS_BMS = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("bmssctid", bmssctid));

        return DAL_SYS_BMS.DAL_Select("Proc_SYS_BMSSCTSelectByID", arrParameter);
    }
    public DataSet BAL_SYS_BMSSCT_ByGroupBMSSCTID(string grpbmssctid)
    {
        DAL_SYS_BMS = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("GroupBMSSCTID", grpbmssctid));

        return DAL_SYS_BMS.DAL_Select("Proc_SYS_BMSSCTSelectByGroupBMSSCTID", arrParameter);
    }
    public DataSet BAL_SYS_BMS_SelectAll()
    {
        //GetDataByBoardMediumStandard in one combo by Ready Method
        DAL_SYS_BMS = new DataAccess();
        return DAL_SYS_BMS.DAL_SelectALL("Proc_SYS_BMSSELECTAll");
    }
    public DataSet BAL_SYS_BMS_SelectAllBySchoolID(Int64 SchoolID)
    {
        //GetDataByBoardMediumStandard in one combo by school ID Ready Method and used 
        DAL_SYS_BMS = new DataAccess();
        arrParameter = new ArrayList();
        arrParameter.Add(new parameter("SchoolID", SchoolID));
        return DAL_SYS_BMS.DAL_Select("Proc_SYS_BMSSELECTAllBySchoolID", arrParameter);
    }
    public DataSet BAL_SYS_Division_SelectAllBySchoolID(Int64 SchoolID, Int64 BMSID)
    {
        //Get Division list school and BMS wise
        DAL_SYS_BMS = new DataAccess();
        arrParameter = new ArrayList();
        arrParameter.Add(new parameter("SchoolID", SchoolID));
        arrParameter.Add(new parameter("BMSID", BMSID));
        return DAL_SYS_BMS.DAL_Select("Proc_fillDivisionBySchoolID", arrParameter);
    }
    public DataSet GetDataByBoardMediumStandard(int BoardID, int MediumID, int StandardID, string Mode)
    {
        DataSet dsBMS = new DataSet();
        PBMS.boardid = BoardID;
        PBMS.mediumid = MediumID;
        PBMS.standardid = StandardID;
        dsBMS = BAL_SYS_BMS_Select(PBMS, Mode);
        return dsBMS;
    }


    public DataSet BAL_SYS_BMS_Select_For_Attendance(SYS_BMS SYS_BMS, string mode)
    {
        DAL_SYS_BMS = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("mode", mode));
        arrParameter.Add(new parameter("BMSID", SYS_BMS.bmsid));
        return DAL_SYS_BMS.DAL_Select("Proc_SYS_BMSSelectDelete", arrParameter);
    }
    public DataSet BAL_SYS_BMS_FillDivisionBySchoolBMSID(int SchoolID)
    {
        DAL_SYS_BMS = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("SchoolID", SchoolID));
        arrParameter.Add(new parameter("BMSID", 0));

        return DAL_SYS_BMS.DAL_Select("Proc_fillDivisionBySchoolID", arrParameter);
    }
    public DataSet Get_AllBoards()
    {
        DAL_SYS_BMS = new DataAccess();
        arrParameter = new ArrayList();

        return DAL_SYS_BMS.DAL_Select("sp_GetAllBoards_BMS", arrParameter);
    }
    public DataSet Get_AllBoards_PackageReport()
    {
        DAL_SYS_BMS = new DataAccess();
        arrParameter = new ArrayList();
        return DAL_SYS_BMS.DAL_Select("sp_GetAllBoards_BMS_TransationMaster", arrParameter);
    }
    public DataSet Get_AllMediumByBoardID(int BoardID)
    {
        DAL_SYS_BMS = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("BoardId", BoardID));
        return DAL_SYS_BMS.DAL_Select("sp_GetAllMedium_BMS", arrParameter);
    }

    public DataSet Get_AllMediumByBoardID_PackageReport(int BoardID)
    {
        DAL_SYS_BMS = new DataAccess();
        arrParameter = new ArrayList();
        arrParameter.Add(new parameter("BoardId", BoardID));
        return DAL_SYS_BMS.DAL_Select("sp_GetAllMedium_BMS_TransationMaster", arrParameter);
    }

    public DataSet Get_AllStandardByBoardMediumID(int BoardID, int MediumId)
    {
        DAL_SYS_BMS = new DataAccess();
        arrParameter = new ArrayList();
        arrParameter.Add(new parameter("BoardId", BoardID));
        arrParameter.Add(new parameter("MediumId", MediumId));
        //return DAL_SYS_BMS.DAL_Select("select_sucessfulTransactionByStandardID", arrParameter);
        return DAL_SYS_BMS.DAL_Select("sp_GetAllStandard_BMS", arrParameter);

    }

    public DataSet GetAllStandard_BMS_PackageReport(int BoardId, int MediumId)
    {
        DAL_SYS_BMS = new DataAccess();
        arrParameter = new ArrayList();
        arrParameter.Add(new parameter("BoardId", BoardId));
        arrParameter.Add(new parameter("MediumId", MediumId));
        return DAL_SYS_BMS.DAL_Select("sp_GetAllStandard_BMS_TransactionMaster", arrParameter);
    }

    public DataSet GetAllStudent_BMS_PackageReport(int BoardId, int MediumId,int standardId)
    {
        DAL_SYS_BMS = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("BoardID", BoardId));
        arrParameter.Add(new parameter("MediumID", MediumId));
        arrParameter.Add(new parameter("StandardID", standardId));
        return DAL_SYS_BMS.DAL_Select("sp_GetStudentList_TransactionMaster", arrParameter);
    }

    public DataSet SearchGetAllStudent_BMS_PackageReport(int BoardId, int MediumId, int standardId,string strStudentName, string datetype,DateTime fromdate,DateTime todate, string packagename)
    {
        DAL_SYS_BMS = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("BoardID", BoardId));
        arrParameter.Add(new parameter("MediumID", MediumId));
        arrParameter.Add(new parameter("StandardID", standardId));
        arrParameter.Add(new parameter("Studentname", strStudentName));
        arrParameter.Add(new parameter("datetype", datetype));

        arrParameter.Add(new parameter("FromDate", fromdate));
        arrParameter.Add(new parameter("EndDate", todate));
        arrParameter.Add(new parameter("PackageName", packagename));

        return DAL_SYS_BMS.DAL_Select("Select_Package_StudentList", arrParameter);
    }

    public DataSet GetPackageName(string packageid)
    {
        DAL_SYS_BMS = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("PackageID", packageid));
        return DAL_SYS_BMS.DAL_Select("sp_GetPackageDetails", arrParameter);
        
    }
}