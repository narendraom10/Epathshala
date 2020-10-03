using System.Collections;
using System.Data;
using System.Web.UI.WebControls;

/// <summary> 
/// <DevelopedBy>"NARENDRASINH"</DevelopedBy>
/// <DevelopedDate></DevelopedDate>
/// <UpdatedBy>"NARENDRASINH"</UpdatedBy>
/// <UpdatedDate></UpdatedDate>
/// </summary>


public class SYS_State_BLogic
{
    DataAccess DAL_SYS_State;
    ArrayList arrParameter;
    SYS_State PState = new SYS_State();

    public SYS_State_BLogic()
    {
        //
        // TODO: Add constructor logic here
        //
    }



    public int BAL_SYS_State_Insert(SYS_State SYS_State, string mode)
    {
        DAL_SYS_State = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("mode", mode));
        arrParameter.Add(new parameter("StateID", SYS_State.stateid));
        arrParameter.Add(new parameter("CountryID", SYS_State.countryid));
        arrParameter.Add(new parameter("State", SYS_State.state));
        arrParameter.Add(new parameter("CreatedBy", SYS_State.createdby));
        return DAL_SYS_State.DAL_InsertUpdate_Return("Proc_SYS_StateInsertUpdate", arrParameter);
    }

    public int BAL_SYS_State_Update(SYS_State SYS_State, string mode)
    {
        DAL_SYS_State = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("mode", mode));
        arrParameter.Add(new parameter("StateID", SYS_State.stateid));
        arrParameter.Add(new parameter("CountryID", SYS_State.countryid));
        arrParameter.Add(new parameter("State", SYS_State.state));
        arrParameter.Add(new parameter("CreatedBy", SYS_State.createdby));
        return DAL_SYS_State.DAL_InsertUpdate_Return("Proc_SYS_StateInsertUpdate", arrParameter);
    }

    public int BAL_SYS_State_Delete(SYS_State SYS_State, string mode)
    {
        DAL_SYS_State = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("mode", mode));
        arrParameter.Add(new parameter("StateID", SYS_State.stateid));
        arrParameter.Add(new parameter("StateIDStr", SYS_State.stateidStr));
        arrParameter.Add(new parameter("CountryID", SYS_State.countryid));
        arrParameter.Add(new parameter("IsActive", SYS_State.isactive));
        return DAL_SYS_State.DAL_Delete_Return("SELECT_DELETE_SYS_State", arrParameter);
    }

    public DataSet BAL_SYS_State_Select(SYS_State SYS_State, string mode)
    {
        DAL_SYS_State = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("mode", mode));
        arrParameter.Add(new parameter("StateID", SYS_State.stateid));
        arrParameter.Add(new parameter("StateIDStr", SYS_State.stateidStr));
        arrParameter.Add(new parameter("CountryID", SYS_State.countryid));
        return DAL_SYS_State.DAL_Select("SELECT_DELETE_SYS_State", arrParameter);
    }

    public DataSet BAL_SYS_State_SelectAll()
    {
        DAL_SYS_State = new DataAccess();
        return DAL_SYS_State.DAL_SelectALL("Proc_SYS_StateSelectAll");
    }

    public void BindListByID(DropDownList Dlist, string Mode, int CountryID)
    {
        DataSet dsStates = new DataSet();
        PState.countryid = CountryID;
        dsStates = BAL_SYS_State_Select(PState, Mode);
        if (dsStates.Tables[0].Rows.Count > 0 && dsStates.Tables[0] != null)
        {
          
           
            Dlist.DataSource = dsStates;
            Dlist.DataTextField = dsStates.Tables[0].Columns["State"].ToString();
            Dlist.DataValueField = dsStates.Tables[0].Columns["StateID"].ToString();
            Dlist.DataBind();
        }
        Dlist.Items.Insert(0, "-- Select --");
        Dlist.Items[0].Value = "0";
    }
}