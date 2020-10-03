using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;

/// <summary> 
/// <DevelopedBy>"NARENDRASINH"</DevelopedBy>
/// <DevelopedDate></DevelopedDate>
/// <UpdatedBy>"NARENDRASINH"</UpdatedBy>
/// <UpdatedDate></UpdatedDate>
/// </summary>
public class DropDownFill
{
    DataAccess DAL_Employee;
    ArrayList arrParameter;
	public DropDownFill()
	{
		
	}

    //Call Like
    // DropDownFill DdlFilling = new DropDownFill();
    //DdlFilling.BindDropDownByDynamic(DdlEmployee, "Employee", "FirstName", "EmployeeID", " SchoolID = " + Convert.ToInt32(Session["SchoolID"]));
    public void BindDropDownByDynamic(DropDownList Dlist, string TableName, string TextField, string ValueField,string WhereParamStr)
    {
        DataTable DTSelect=new DataTable();
        string SearchCondition = "SELECT "+TextField +" , "+ValueField+" FROM "+TableName;
        if (WhereParamStr != "")
        {
            SearchCondition = SearchCondition + " where " + WhereParamStr;
        }
        DTSelect = BAL_Employee_SelectBySchoolID(SearchCondition);
        BindDropDownByTable(Dlist, DTSelect, TextField, ValueField);
    }
    public void BindCheckBoxListByDynamic(CheckBoxList Dlist, string TableName, string TextField, string ValueField, string WhereParamStr)
    {
        DataTable DTSelect = new DataTable();
        string SearchCondition = "SELECT " + TextField + " , " + ValueField + " FROM " + TableName;
        SearchCondition = SearchCondition + " where " + WhereParamStr;
        DTSelect = BAL_Employee_SelectBySchoolID(SearchCondition);
       
        if (DTSelect.Rows.Count > 0)
        {
            Dlist.Items.Clear();
            Dlist.DataSource = DTSelect;
            Dlist.DataTextField = TextField;
            Dlist.DataValueField = ValueField;
            Dlist.DataBind();         
        }
        else
        {
            Dlist.Items.Clear();
            Dlist.DataBind();           
        }
    }
    public DataTable BAL_Employee_SelectBySchoolID(string SearchCondition)
    {
        DAL_Employee = new DataAccess();
        arrParameter = new ArrayList();        
        arrParameter.Add(new parameter("SearchCondition", SearchCondition));
        return DAL_Employee.DAL_Select("Proc_DropDownFill", arrParameter).Tables[0];
    }
    public void BindDropDownByTable(DropDownList Dlist, DataTable DTSelect, string TextField,string ValueField)
    {
        if (DTSelect.Rows.Count > 0)
        {
            Dlist.Items.Clear();
            Dlist.Items.Insert(0, "-- Select --");
            Dlist.Items[0].Value = "0";
            Dlist.DataSource = DTSelect;
            Dlist.DataTextField = TextField;
            Dlist.DataValueField = ValueField;          
            Dlist.DataBind();
        }
        else
        {
            Dlist.Items.Clear();
            Dlist.Items.Insert(0, "-- Select --");
            Dlist.Items[0].Value = "0";
            Dlist.DataBind();
           
        }
    }
    public void BindCheckBoxListByTable(CheckBoxList Dlist, DataTable DTSelect, string TextField, string ValueField)
    {
        if (DTSelect.Rows.Count > 0)
        {
            Dlist.Items.Clear();
            Dlist.DataSource = DTSelect;
            Dlist.DataTextField = TextField;
            Dlist.DataValueField = ValueField;
            Dlist.DataBind();          
        }
        else
        {
            Dlist.Items.Clear();
            Dlist.DataBind();         
        }
    }
    public void ClearDropDownListRef(DropDownList Dlist)
    {
        
            Dlist.Items.Clear();
            Dlist.DataBind();
            Dlist.Items.Insert(Convert.ToInt32(EnumFile.AssignValue.Zero), "-- Select --");
            Dlist.Items[0].Value = Convert.ToString((int)EnumFile.AssignValue.Zero);
        
    }



    public void BindDropDownByGroupName(DropDownList ddlGroupName, DataTable dataTable, string p)
    {
        if (dataTable.Rows.Count > 0)
        {
            ddlGroupName.Items.Clear();
            ddlGroupName.Items.Insert(0, "-- Select --");
            ddlGroupName.Items[0].Value = "0";
            ddlGroupName.DataSource = dataTable;
            ddlGroupName.DataTextField = p;
            //ddlGroupName.DataValueField = ValueField;
            ddlGroupName.DataBind();
        }
        else
        {
            ddlGroupName.Items.Clear();
            ddlGroupName.Items.Insert(0, "-- Select --");
            ddlGroupName.Items[0].Value = "0";
            ddlGroupName.DataBind();

        }
    }
}