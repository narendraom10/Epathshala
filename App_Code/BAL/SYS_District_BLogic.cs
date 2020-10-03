using System.Collections;
using System.Data;
using System.Web.UI.WebControls;

/// <summary> 
/// <DevelopedBy>"NARENDRASINH"</DevelopedBy>
/// <DevelopedDate></DevelopedDate>
/// <UpdatedBy>"NARENDRASINH"</UpdatedBy>
/// <UpdatedDate></UpdatedDate>
/// </summary>


public class SYS_District_BLogic
{
    DataAccess obj_DAL_SYS_District;
    ArrayList obj_arrParameter;
    SYS_District PDistrict = new SYS_District();
    public SYS_District_BLogic()
    {
        //
        // TODO: Add constructor logic here
        //
    }



    public int BAL_SYS_District_Insert(SYS_District SYS_District, string mode)
    {
        obj_DAL_SYS_District = new DataAccess();
        obj_arrParameter = new ArrayList();

        obj_arrParameter.Add(new parameter("mode", mode));
        obj_arrParameter.Add(new parameter("DistrictID", SYS_District.districtid));
        obj_arrParameter.Add(new parameter("StateID", SYS_District.stateid));
        obj_arrParameter.Add(new parameter("CountryID", SYS_District.countryid));
        obj_arrParameter.Add(new parameter("District", SYS_District.district));
        obj_arrParameter.Add(new parameter("CreatedBy", SYS_District.createdby));
        return obj_DAL_SYS_District.DAL_InsertUpdate_Return("Proc_SYS_DistrictInsertUpdate", obj_arrParameter);
    }

    public int BAL_SYS_District_Update(SYS_District SYS_District, string mode)
    {
        obj_DAL_SYS_District = new DataAccess();
        obj_arrParameter  = new ArrayList();

        obj_arrParameter.Add(new parameter("mode", mode));
        obj_arrParameter.Add(new parameter("DistrictID", SYS_District.districtid));
        obj_arrParameter.Add(new parameter("StateID", SYS_District.stateid));
        obj_arrParameter.Add(new parameter("CountryID", SYS_District.countryid));
        obj_arrParameter.Add(new parameter("District", SYS_District.district));
        obj_arrParameter.Add(new parameter("CreatedBy", SYS_District.createdby));
        return obj_DAL_SYS_District.DAL_InsertUpdate_Return("Proc_SYS_DistrictInsertUpdate", obj_arrParameter);
    }

    public int BAL_SYS_District_Delete(SYS_District SYS_District, string mode)
    {
        obj_DAL_SYS_District = new DataAccess();
        obj_arrParameter  = new ArrayList();
        obj_arrParameter.Add(new parameter("mode", mode));
        obj_arrParameter.Add(new parameter("DistrictID", SYS_District.districtid));
        obj_arrParameter.Add(new parameter("DistrictIDStr", SYS_District.districtidStr));
        obj_arrParameter.Add(new parameter("IsActive", SYS_District.isactive));
        return obj_DAL_SYS_District.DAL_Delete_Return("Proc_SYS_DistrictSelectDelete", obj_arrParameter);
    }

    public DataSet BAL_SYS_District_Select(SYS_District obj_SYS_District, string mode)
    {
        obj_DAL_SYS_District = new DataAccess();
        obj_arrParameter = new ArrayList();

        obj_arrParameter.Add(new parameter("mode", mode));
        obj_arrParameter.Add(new parameter("Tmp_DistrictID", obj_SYS_District.districtid));
        obj_arrParameter.Add(new parameter("Tmp_StateID", obj_SYS_District.stateid));
        return obj_DAL_SYS_District.DAL_Select("SELECT_DELETE_SYS_District", obj_arrParameter);
    }

    public DataSet BAL_SYS_District_SelectAll()
    {
        obj_DAL_SYS_District = new DataAccess();
        return obj_DAL_SYS_District.DAL_SelectALL("Proc_SYS_DistrictSelectAll");
    }

    public void BindListByID(DropDownList Dlist, string Mode, int StateID)
    {
        DataSet dsDistricts = new DataSet();
        PDistrict.stateid = StateID;
        dsDistricts = BAL_SYS_District_Select(PDistrict, Mode);
        if (dsDistricts.Tables[0].Rows.Count > 0 && dsDistricts.Tables[0] != null)
        {
            Dlist.DataSource = dsDistricts;
            Dlist.DataTextField = dsDistricts.Tables[0].Columns["District"].ToString();
            Dlist.DataValueField = dsDistricts.Tables[0].Columns["DistrictID"].ToString();
            Dlist.DataBind();
        }
        Dlist.Items.Insert(0, "-- Select --");
        Dlist.Items[0].Value = "0";
    }
}