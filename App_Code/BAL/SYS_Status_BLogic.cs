using System.Data;
using System.Collections;

/// <summary> 
/// <DevelopedBy>"NARENDRASINH"</DevelopedBy>
/// <DevelopedDate></DevelopedDate>
/// <UpdatedBy>"NARENDRASINH"</UpdatedBy>
/// <UpdatedDate></UpdatedDate>
/// </summary>


public class SYS_Status_BLogic
{
    DataAccess DAL_SYS_Status;
    ArrayList arrParameter;
    public SYS_Status_BLogic()
    {
        //
        // TODO: Add constructor logic here
        //
    }



    public void BAL_SYS_Status_Insert(SYS_Status SYS_Status, string mode)
    {
        DAL_SYS_Status = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("mode", mode));
        arrParameter.Add(new parameter("StatusID", SYS_Status.statusid));
        arrParameter.Add(new parameter("Status", SYS_Status.status));
        DAL_SYS_Status.DAL_InsertUpdate("Proc_SYS_StatusInsertUpdate", arrParameter);
    }

    public void BAL_SYS_Status_Update(SYS_Status SYS_Status, string mode)
    {
        DAL_SYS_Status = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("mode", mode));
        arrParameter.Add(new parameter("StatusID", SYS_Status.statusid));
        arrParameter.Add(new parameter("Status", SYS_Status.status));
        DAL_SYS_Status.DAL_InsertUpdate("Proc_SYS_StatusInsertUpdate", arrParameter);
    }

    public void BAL_SYS_Status_Delete(SYS_Status SYS_Status, string mode)
    {
        DAL_SYS_Status = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("mode", mode));
        arrParameter.Add(new parameter("StatusID", SYS_Status.statusid));
        arrParameter.Add(new parameter("Status", SYS_Status.status));
        DAL_SYS_Status.DAL_Delete("Proc_SYS_StatusSelectDelete", arrParameter);
    }

    public DataSet BAL_SYS_Status_Select(SYS_Status SYS_Status, string mode)
    {
        DAL_SYS_Status = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("mode", mode));
        arrParameter.Add(new parameter("StatusID", SYS_Status.statusid));
        arrParameter.Add(new parameter("Status", SYS_Status.status));
        return DAL_SYS_Status.DAL_Select("Proc_SYS_StatusSelectDelete", arrParameter);
    }

    public DataSet BAL_SYS_Status_SelectAll()
    {
        DAL_SYS_Status = new DataAccess();
        return DAL_SYS_Status.DAL_SelectALL("Proc_SYS_StatusSELECTAll");
    }
}