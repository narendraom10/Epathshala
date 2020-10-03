/// <summary> 
/// <DevelopedBy></DevelopedBy>
/// <DevelopedDate></DevelopedDate>
/// <UpdatedBy>"SHEEL"</UpdatedBy>
/// </summary>

using System.Collections;
using System.Data;
using System.Web.UI.WebControls;
using System;

///// <summary>
///// Summary description for SYS_Standard_BLogic
///// </summary>


public class SYS_Standard_BLogic
{
    DataAccess DAL_SYS_Standard;
    ArrayList arrParameter;
    SYS_Standard PStandard = new SYS_Standard();
    public SYS_Standard_BLogic()
    {
        //
        // TODO: Add constructor logic here
        //
    }



    public int BAL_SYS_Standard_Insert(SYS_Standard SYS_Standard, string mode)
    {
        DAL_SYS_Standard = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("mode", mode));
        arrParameter.Add(new parameter("StandardID", SYS_Standard.standardid));
        arrParameter.Add(new parameter("Standard", SYS_Standard.standard));
        arrParameter.Add(new parameter("Code", SYS_Standard.code));
        arrParameter.Add(new parameter("Description", SYS_Standard.description));
        arrParameter.Add(new parameter("CreatedBy", SYS_Standard.createdby));
        arrParameter.Add(new parameter("ModifiedBy", SYS_Standard.modifiedby));
        return DAL_SYS_Standard.DAL_InsertUpdate_Return("Proc_SYS_StandardInsertUpdate", arrParameter);
    }

    public int BAL_SYS_Standard_Update(SYS_Standard SYS_Standard, string mode)
    {
        DAL_SYS_Standard = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("mode", mode));
        arrParameter.Add(new parameter("StandardID", SYS_Standard.standardid));
        arrParameter.Add(new parameter("Standard", SYS_Standard.standard));
        arrParameter.Add(new parameter("Code", SYS_Standard.code));
        arrParameter.Add(new parameter("Description", SYS_Standard.description));       
        arrParameter.Add(new parameter("CreatedBy", SYS_Standard.createdby));      
        arrParameter.Add(new parameter("ModifiedBy", SYS_Standard.modifiedby));
        return DAL_SYS_Standard.DAL_InsertUpdate_Return("Proc_SYS_StandardInsertUpdate", arrParameter);
    }

    public int BAL_SYS_Standard_Delete(SYS_Standard SYS_Standard, string mode)
    {
        DAL_SYS_Standard = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("mode", mode));
        arrParameter.Add(new parameter("StandardID", SYS_Standard.standardid));
        arrParameter.Add(new parameter("StandardIDStr", SYS_Standard.standardidStr));
        arrParameter.Add(new parameter("BoardID", SYS_Standard.boardid));
        arrParameter.Add(new parameter("MediumID", SYS_Standard.mediumid));
        arrParameter.Add(new parameter("IsActive", SYS_Standard.isactive));
        return DAL_SYS_Standard.DAL_Delete_Return("SELECT_DELETE_SYS_Standard", arrParameter);
    }

    public DataSet BAL_SYS_Standard_Select(SYS_Standard SYS_Standard, string mode)
    {
        DAL_SYS_Standard = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("mode", mode));
        arrParameter.Add(new parameter("StandardID", SYS_Standard.standardid));
        arrParameter.Add(new parameter("StandardIDStr", SYS_Standard.standardidStr));
        arrParameter.Add(new parameter("BoardID", SYS_Standard.boardid));
        arrParameter.Add(new parameter("MediumID", SYS_Standard.mediumid));
        return DAL_SYS_Standard.DAL_Select("SELECT_DELETE_SYS_Standard", arrParameter);
    }

    public DataSet BAL_SYS_Standard_SelectAll()
    {
        DAL_SYS_Standard = new DataAccess();
        return DAL_SYS_Standard.DAL_SelectALL("SELECTAll_SYS_Standard");
    }

    public DataSet BAL_SYS_Standard_SelectForUserList(SYS_Standard SYS_Standard)
    {
        DAL_SYS_Standard = new DataAccess();
        arrParameter = new ArrayList();
        arrParameter.Add(new parameter("UserRoleID", SYS_Standard.userroleid));
        arrParameter.Add(new parameter("EmployeeID", SYS_Standard.employeeid));
        arrParameter.Add(new parameter("SchoolID", SYS_Standard.Schoolid));
        return DAL_SYS_Standard.DAL_Select("proc_Select_Standard_ForUserList", arrParameter);
    }

    public void BindListByID(DataList Gv, string Mode, int BoardID,int MediumID)
    {
        DataSet dsStandards = new DataSet();
        PStandard.boardid = BoardID;
        PStandard.mediumid = MediumID;
        dsStandards = BAL_SYS_Standard_Select(PStandard, Mode);
        if (dsStandards.Tables[0].Rows.Count > 0 && dsStandards.Tables[0] != null)
        {
            //Clist.DataSource = dsStandards;
            //Clist.DataTextField = dsStandards.Tables[0].Columns["Standard"].ToString();
            //Clist.DataValueField = dsStandards.Tables[0].Columns["StandardID"].ToString();
            //Clist.DataBind();

            Gv.DataSource = dsStandards.Tables[0];
            Gv.DataBind();
            
        }
    }
  
    public void BindStandardListByID(DropDownList Gv, string Mode, int BoardID, int MediumID)
    {
        DataSet dsStandards = new DataSet();
        PStandard.boardid = BoardID;
        PStandard.mediumid = MediumID;
        dsStandards = BAL_SYS_Standard_Select(PStandard, Mode);
        if (dsStandards.Tables[0].Rows.Count > 0 && dsStandards.Tables[0] != null)
        {
            //Clist.DataSource = dsStandards;
           
            //Clist.DataBind();

            Gv.DataSource = dsStandards.Tables[0];
            Gv.DataTextField = dsStandards.Tables[0].Columns["Standard"].ToString();
            Gv.DataValueField = dsStandards.Tables[0].Columns["StandardID"].ToString();
            Gv.DataBind();

        }
        Gv.Items.Insert(0, "-- Select --");
        Gv.Items[0].Value = "0";
    }

    public void BindStandardListForUserList(DropDownList DDL, SYS_Standard SysStandard)
    {
        try
        {
            DataSet dsStandardsForUser = new DataSet();
            dsStandardsForUser = this.BAL_SYS_Standard_SelectForUserList(SysStandard);
            if (dsStandardsForUser.Tables[0].Rows.Count > 0 && dsStandardsForUser.Tables[0] != null)
            {
                DDL.DataSource = dsStandardsForUser;
                DDL.DataTextField = "Standard";
                DDL.DataValueField = "StandardID";
                DDL.DataBind();
            }
            DDL.Items.Insert(0, "-- Select --");
            DDL.Items[0].Value = "0";
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }

    public DataSet get_GvStandard(string SchoolID,char flag)
    {
        DAL_SYS_Standard = new DataAccess();
        DataSet ds = new DataSet();
        arrParameter = new ArrayList();
        arrParameter.Add(new parameter("SchoolID", SchoolID));
        arrParameter.Add(new parameter("Filtertype", flag));
        ds = DAL_SYS_Standard.DAL_Select("Proc_SelectSchool_Allocated_Standard", arrParameter);
        return ds;
    }


    public DataSet getALL_GvStandard()
    {

        DAL_SYS_Standard = new DataAccess();
        DataSet ds = new DataSet();
        ds = DAL_SYS_Standard.DAL_SelectALL("Proc_SelectSchool_All_Standard");
        return ds;
    }
    
    public int BAL_SYS_New_Standard_Insert(int SchoolID, int BMSID, int StatusID)
    {
        DAL_SYS_Standard = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("SchoolID", SchoolID));
        arrParameter.Add(new parameter("BMSID", BMSID));
        arrParameter.Add(new parameter("StatusID", StatusID));
       
        return DAL_SYS_Standard.DAL_InsertUpdate_Return("Proc_SYS_NewStandardInsert", arrParameter);
    }
    
    public int BAL_SYS_New_Standard_Delete(int SchoolID, int BMSID)
    {
        DAL_SYS_Standard = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("SchoolID", SchoolID));
        arrParameter.Add(new parameter("BMSID", BMSID));
        return DAL_SYS_Standard.DAL_Delete_Return("Proc_SYS_NewStandardDelete", arrParameter);
    }

}