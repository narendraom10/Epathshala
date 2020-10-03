using System.Collections;
using System.Data;
using System.Web.UI.WebControls;
using System;

/// <summary> 
/// <DevelopedBy>"NARENDRASINH"</DevelopedBy>
/// <DevelopedDate></DevelopedDate>
/// <UpdatedBy>"NARENDRASINH"</UpdatedBy>
/// <UpdatedDate></UpdatedDate>
/// </summary>

public class SYS_SchoolType_BLogic
{
    DataAccess DAL_SYS_SchoolType;
    ArrayList arrParameter;
    SYS_SchoolType PSchoolType = new SYS_SchoolType();
    public SYS_SchoolType_BLogic()
    {
        //
        // TODO: Add constructor logic here
        //
    }



    public int BAL_SYS_SchoolType_Insert(SYS_SchoolType SYS_SchoolType, string mode)
    {
        DAL_SYS_SchoolType = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("mode", mode));
        arrParameter.Add(new parameter("SchoolTypeID", SYS_SchoolType.schooltypeid));
        arrParameter.Add(new parameter("Type", SYS_SchoolType.type));
        arrParameter.Add(new parameter("CreatedBy", SYS_SchoolType.createdby));
        return DAL_SYS_SchoolType.DAL_InsertUpdate_Return("Proc_SYS_SchoolTypeInsertUpdate", arrParameter);
    }

    public int BAL_SYS_SchoolType_Update(SYS_SchoolType SYS_SchoolType, string mode)
    {
        DAL_SYS_SchoolType = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("mode", mode));
        arrParameter.Add(new parameter("SchoolTypeID", SYS_SchoolType.schooltypeid));
        arrParameter.Add(new parameter("Type", SYS_SchoolType.type));             
        arrParameter.Add(new parameter("CreatedBy", SYS_SchoolType.createdby));
        return DAL_SYS_SchoolType.DAL_InsertUpdate_Return("Proc_SYS_SchoolTypeInsertUpdate", arrParameter);
    }

    public int BAL_SYS_SchoolType_Delete(SYS_SchoolType SYS_SchoolType, string mode)
    {
        DAL_SYS_SchoolType = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("mode", mode));
        arrParameter.Add(new parameter("SchoolTypeID", SYS_SchoolType.schooltypeid));
        arrParameter.Add(new parameter("SchoolTypeIDStr", SYS_SchoolType.schooltypeidStr));
        arrParameter.Add(new parameter("IsActive", SYS_SchoolType.isactive));
        return DAL_SYS_SchoolType.DAL_Delete_Return("SELECT_DELETE_SYS_SchoolType", arrParameter);
    }

    public DataSet BAL_SYS_SchoolType_Select(SYS_SchoolType SYS_SchoolType, string mode)
    {
        DAL_SYS_SchoolType = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("mode", mode));
        arrParameter.Add(new parameter("SchoolTypeID", SYS_SchoolType.schooltypeid));
        arrParameter.Add(new parameter("SchoolTypeIDStr", SYS_SchoolType.schooltypeidStr));
        return DAL_SYS_SchoolType.DAL_Select("SELECT_DELETE_SYS_SchoolType", arrParameter);
    }

    public DataSet BAL_SYS_SchoolType_SelectAll()
    {
        DAL_SYS_SchoolType = new DataAccess();
        return DAL_SYS_SchoolType.DAL_SelectALL("SELECTAll_SYS_SchoolType");
    }

    public void BindList(DropDownList Dlist, string Mode)
    {
        DataSet dsSchoolType = new DataSet();
        dsSchoolType = BAL_SYS_SchoolType_Select(PSchoolType, Mode);
        if (dsSchoolType.Tables.Count > 0)
        {
            Dlist.Items.Clear();
            Dlist.DataSource = dsSchoolType;
            Dlist.DataTextField = dsSchoolType.Tables[0].Columns["Type"].ToString();
            Dlist.DataValueField = dsSchoolType.Tables[0].Columns["SchoolTypeID"].ToString();
            Dlist.DataBind();
            Dlist.Items.Insert(Convert.ToInt32(EnumFile.AssignValue.Zero), "-- Select --");
            Dlist.Items[0].Value = ((int)EnumFile.AssignValue.Zero).ToString();
        }
        else
        {
            Dlist.Items.Clear();          
            Dlist.Items.Insert(Convert.ToInt32(EnumFile.AssignValue.Zero), "-- Select --");
            Dlist.Items[0].Value = ((int)EnumFile.AssignValue.Zero).ToString();
        }
    }
}