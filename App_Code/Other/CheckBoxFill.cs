using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;


/// <summary>
/// Summary description for CheckBoxFill
/// </summary>
public class CheckBoxFill
{
    ArrayList arrParameter;
    DataAccess DAL_Employee;
    public CheckBoxFill()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public void FillCheckBoxForAnnouncementBySchoolBMSID(CheckBoxList clstDivision, int SchoolID, int BMSID)
    {
        DataTable DtSelect = new DataTable();
        Announcement_BLogic BAL_Announcement = new Announcement_BLogic();
        //DtSelect = BAL_Announcement.FillCheckBox(SchoolID, BMSID);
        DataAccess DAL_Announcement = new DataAccess();

        arrParameter = new ArrayList();
        arrParameter.Add(new parameter("SchoolID", SchoolID));
        arrParameter.Add(new parameter("BMSID", BMSID));
        DtSelect = DAL_Announcement.DAL_Select("Proc_fillDivisionBySchoolID", arrParameter).Tables[0];
        if (DtSelect.Rows.Count > 0)
        {
            clstDivision.Items.Clear();
            clstDivision.DataSource = DtSelect;
            clstDivision.DataTextField = "Division";
            clstDivision.DataValueField = "DivisionID";
            clstDivision.DataBind();
        }
        else
        {
            clstDivision.Items.Clear();
            clstDivision.DataBind();
        }
    }

    public void FillDivisionBySchoolBMSID(DropDownList ddl, int SchoolID)
    {
        DataTable DtSelect = new DataTable();
        Announcement_BLogic BAL_Announcement = new Announcement_BLogic();
        //DtSelect = BAL_Announcement.FillCheckBox(SchoolID, BMSID);
        DataAccess DAL_Announcement = new DataAccess();

        arrParameter = new ArrayList();
        arrParameter.Add(new parameter("SchoolID", SchoolID));
        arrParameter.Add(new parameter("BMSID",0));
        DtSelect = DAL_Announcement.DAL_Select("Proc_fillDivisionBySchoolID", arrParameter).Tables[0];
        if (DtSelect.Rows.Count > 0)
        {
            ddl.Items.Clear();
            ddl.DataSource = DtSelect;
            ddl.DataTextField = "Division";
            ddl.DataValueField = "DivisionID";
            ddl.DataBind();
        }
    }
}