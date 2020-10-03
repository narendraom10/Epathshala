using System.Collections;
using System.Data;
using System.Web.UI.WebControls;

/// <summary> 
/// <DevelopedBy>"NARENDRASINH"</DevelopedBy>
/// <DevelopedDate></DevelopedDate>
/// <UpdatedBy>"NARENDRASINH"</UpdatedBy>
/// <UpdatedDate></UpdatedDate>
/// </summary>


public class SYS_Medium_BLogic
{
    DataAccess DAL_SYS_Medium;
    ArrayList arrParameter;
    SYS_Medium PMedium = new SYS_Medium();
    public SYS_Medium_BLogic()
    {
        //
        // TODO: Add constructor logic here
        //
    }



    public int BAL_SYS_Medium_Insert(SYS_Medium SYS_Medium, string mode)
    {
        DAL_SYS_Medium = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("mode", mode));
        arrParameter.Add(new parameter("MediumID", SYS_Medium.mediumid));
        arrParameter.Add(new parameter("Medium", SYS_Medium.medium));
        arrParameter.Add(new parameter("Code", SYS_Medium.code));
        arrParameter.Add(new parameter("Description", SYS_Medium.description));
        arrParameter.Add(new parameter("CreatedBy", SYS_Medium.createdby));
        arrParameter.Add(new parameter("ModifiedBy", SYS_Medium.modifiedby));
        return DAL_SYS_Medium.DAL_InsertUpdate_Return("Proc_SYS_MediumInsertUpdate", arrParameter);
    }

    public int BAL_SYS_Medium_Update(SYS_Medium SYS_Medium, string mode)
    {
        DAL_SYS_Medium = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("mode", mode));
        arrParameter.Add(new parameter("MediumID", SYS_Medium.mediumid));
        arrParameter.Add(new parameter("Medium", SYS_Medium.medium));
        arrParameter.Add(new parameter("Code", SYS_Medium.code));
        arrParameter.Add(new parameter("Description", SYS_Medium.description));
        arrParameter.Add(new parameter("CreatedBy", SYS_Medium.createdby));
        arrParameter.Add(new parameter("ModifiedBy", SYS_Medium.modifiedby));
        return DAL_SYS_Medium.DAL_InsertUpdate_Return("Proc_SYS_MediumInsertUpdate", arrParameter);
    }

    public int BAL_SYS_Medium_Delete(SYS_Medium SYS_Medium, string mode)
    {
        DAL_SYS_Medium = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("mode", mode));
        arrParameter.Add(new parameter("MediumID", SYS_Medium.mediumid));
        arrParameter.Add(new parameter("BoardID", 0));
        arrParameter.Add(new parameter("MediumIDStr", SYS_Medium.mediumidStr));
        arrParameter.Add(new parameter("IsActive", SYS_Medium.isactive));
        return DAL_SYS_Medium.DAL_Delete_Return("Proc_SYS_MediumSelectDelete", arrParameter);
    }

    public DataSet BAL_SYS_Medium_Select(SYS_Medium SYS_Medium, string mode)
    {
        DAL_SYS_Medium = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("mode", mode));
        arrParameter.Add(new parameter("MediumID", SYS_Medium.mediumid));
        arrParameter.Add(new parameter("BoardID", SYS_Medium.boardid));
        return DAL_SYS_Medium.DAL_Select("Proc_SYS_MediumSelectDelete", arrParameter);
    }

    public DataSet BAL_SYS_Medium_SelectAll()
    {
        DAL_SYS_Medium = new DataAccess();
        return DAL_SYS_Medium.DAL_SelectALL("SELECTAll_SYS_Medium");
    }

    public void BindMediumByBoardID(DropDownList Dlist, string Mode, int BoardID)
    {
        DataSet dsMedium = new DataSet();
        PMedium.boardid = BoardID;
        dsMedium = BAL_SYS_Medium_Select(PMedium, Mode);
        if (dsMedium.Tables[0].Rows.Count > 0 && dsMedium.Tables[0] != null)
        {
            Dlist.DataSource = dsMedium;
            Dlist.DataTextField = dsMedium.Tables[0].Columns["Medium"].ToString();
            Dlist.DataValueField = dsMedium.Tables[0].Columns["MediumID"].ToString();
            Dlist.DataBind();
        }

        Dlist.Items.Insert(0, "-- Select --");
        Dlist.Items[0].Value = "0";
    }

   
}