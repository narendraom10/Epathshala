

using System.Data;
using System.Collections;

/// <summary> 
/// <DevelopedBy>"NARENDRASINH"</DevelopedBy>
/// <DevelopedDate></DevelopedDate>
/// <UpdatedBy>"NARENDRASINH"</UpdatedBy>
/// <UpdatedDate></UpdatedDate>
/// </summary>


public class SYS_Division_BLogic
{
    DataAccess DAL_SYS_Division;
    ArrayList arrParameter;
    public SYS_Division_BLogic()
    {
        //
        // TODO: Add constructor logic here
        //
    }



    public int BAL_SYS_Division_Insert(SYS_Division SYS_Division, string mode)
    {
        DAL_SYS_Division = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("mode", mode));
        arrParameter.Add(new parameter("DivisionID", SYS_Division.divisionid));
        arrParameter.Add(new parameter("Division", SYS_Division.division));
        arrParameter.Add(new parameter("Description", SYS_Division.description));
        arrParameter.Add(new parameter("CreatedBy", SYS_Division.createdby));
        arrParameter.Add(new parameter("ModifiedBy", SYS_Division.modifiedby));
        return DAL_SYS_Division.DAL_InsertUpdate_Return("Proc_SYS_DivisionInsertUpdate", arrParameter);
    }

    public int BAL_SYS_Division_Update(SYS_Division SYS_Division, string mode)
    {
        DAL_SYS_Division = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("mode", mode));
        arrParameter.Add(new parameter("DivisionID", SYS_Division.divisionid));
        arrParameter.Add(new parameter("Division", SYS_Division.division));
        arrParameter.Add(new parameter("Description", SYS_Division.description));
        arrParameter.Add(new parameter("CreatedBy", SYS_Division.createdby));
        arrParameter.Add(new parameter("ModifiedBy", SYS_Division.modifiedby));
        return DAL_SYS_Division.DAL_InsertUpdate_Return("Proc_SYS_DivisionInsertUpdate", arrParameter);
    }

    public int BAL_SYS_Division_Delete(SYS_Division SYS_Division, string mode)
    {
        DAL_SYS_Division = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("mode", mode));
        arrParameter.Add(new parameter("DivisionID", SYS_Division.divisionid));
        arrParameter.Add(new parameter("DivisionIDStr", SYS_Division.divisionidStr));
        arrParameter.Add(new parameter("IsActive", SYS_Division.isactive));
        return DAL_SYS_Division.DAL_Delete_Return("Proc_SYS_DivisionSelectDelete", arrParameter);
    }

    public DataSet BAL_SYS_Division_Select(SYS_Division SYS_Division, string mode)
    {
        DAL_SYS_Division = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("mode", mode));
        arrParameter.Add(new parameter("DivisionID", SYS_Division.divisionid));
        arrParameter.Add(new parameter("DivisionIDStr", SYS_Division.divisionidStr));
        return DAL_SYS_Division.DAL_Select("Proc_SYS_DivisionSelectDelete", arrParameter);
    }

    public DataSet BAL_SYS_Division_SelectAll()
    {
        DAL_SYS_Division = new DataAccess();
        return DAL_SYS_Division.DAL_SelectALL("Proc_SYS_DivisionSELECTAll");
    }

    public DataSet BAL_SYS_Division_Select_ByID(SYS_Division SYS_Division, string mode)
    {
        DAL_SYS_Division = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("mode", mode));
        arrParameter.Add(new parameter("DivisionID", SYS_Division.divisionid));
        arrParameter.Add(new parameter("DivisionIDStr", 0));
        return DAL_SYS_Division.DAL_Select("Proc_SYS_DivisionSelectDelete", arrParameter);
    }
    public DataSet BAL_SYS_Division_SelectAllActive(string mode)
    {
        DAL_SYS_Division = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("mode", mode));
        return DAL_SYS_Division.DAL_Select("Proc_SYS_DivisionActive", arrParameter);
    }
    public DataSet BAL_SYS_Division_SelectByBMSID(int BoardID, int MediumID, int StandardID, int SchoolID)
    {
        DAL_SYS_Division = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("BoardID", BoardID));
        arrParameter.Add(new parameter("MediumID", MediumID));
        arrParameter.Add(new parameter("StandardID", StandardID));
        arrParameter.Add(new parameter("SchoolID", SchoolID));
        return DAL_SYS_Division.DAL_Select("Proc_SelectDivision_ByBoardMediumStandard", arrParameter);
    }
    public DataSet BAL_SYS_GroupName_SelectByBMSID()
    {
       // DAL_SYS_Division = new DataAccess();
        //DataAccessEpathshalaStudent DAL_SysGroupName = new DataAccessEpathshalaStudent();
        DataAccess DAL_SysGroupName = new DataAccess();
        arrParameter = new ArrayList();

        return DAL_SysGroupName.DAL_SelectALL("Proc_SelectGroupName_ByBoardMediumStandard");
    }
    public DataSet BAL_SYS_Year_Select()
    {
        // DAL_SYS_Division = new DataAccess();
        //DataAccessEpathshalaStudent DAL_SysGroupName = new DataAccessEpathshalaStudent();
        DataAccess DAL_SysGroupName = new DataAccess();
        arrParameter = new ArrayList();

        return DAL_SysGroupName.DAL_SelectALL("Proc_SelectYearName");
    }

    public int BAL_SYS_SelectBMSID(int BoardID, int MediumID, int StandardID)
    {
        DAL_SYS_Division = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("BoardID", BoardID));
        arrParameter.Add(new parameter("MediumID", MediumID));
        arrParameter.Add(new parameter("StandardID", StandardID));

        return DAL_SYS_Division.executescalre("PROC_Select_BMS", arrParameter);
    }
}