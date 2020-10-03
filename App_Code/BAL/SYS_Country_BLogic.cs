using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Data;
using System.Web.UI.WebControls;
/// <summary> 
/// <DevelopedBy>"NARENDRASINH"</DevelopedBy>
/// <DevelopedDate></DevelopedDate>
/// <UpdatedBy>"NARENDRASINH"</UpdatedBy>
/// <UpdatedDate></UpdatedDate>
/// </summary>
public class SYS_Country_BLogic
{
    DataAccess DAL_SYS_Country;
    ArrayList arrParameter;
    SYS_Country PCountry = new SYS_Country();

    public SYS_Country_BLogic()
    {
        //
        // TODO: Add constructor logic here
        //
    }



    public int BAL_SYS_Country_Insert(SYS_Country SYS_Country, string mode)
    {
        DAL_SYS_Country = new DataAccess();
        arrParameter = new ArrayList();
        arrParameter.Add(new parameter("mode", mode));
        arrParameter.Add(new parameter("CountryID", SYS_Country.countryid));
        arrParameter.Add(new parameter("Country", SYS_Country.country));
        arrParameter.Add(new parameter("CreatedBy", SYS_Country.createdby));
        return DAL_SYS_Country.DAL_InsertUpdate_Return("Proc_SYS_CountryInsertUpdate", arrParameter);
    }

    public int BAL_SYS_Country_Update(SYS_Country SYS_Country, string mode)
    {
        DAL_SYS_Country = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("mode", mode));
        arrParameter.Add(new parameter("CountryID", SYS_Country.countryid));
        arrParameter.Add(new parameter("Country", SYS_Country.country));
        arrParameter.Add(new parameter("CreatedBy", SYS_Country.createdby));
        return DAL_SYS_Country.DAL_InsertUpdate_Return("Proc_SYS_CountryInsertUpdate", arrParameter);
    }

    public int BAL_SYS_Country_Delete(SYS_Country SYS_Country, string mode)
    {
        DAL_SYS_Country = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("mode", mode));
        arrParameter.Add(new parameter("CountryID", SYS_Country.countryid));
        arrParameter.Add(new parameter("CountryIDStr", SYS_Country.countryidStr));
        arrParameter.Add(new parameter("IsActive", SYS_Country.isactive));
        return DAL_SYS_Country.DAL_Delete_Return("SELECT_DELETE_SYS_Country", arrParameter);
    }

    public DataSet BAL_SYS_Country_Select(SYS_Country SYS_Country, string mode)
    {
        DAL_SYS_Country = new DataAccess();
        arrParameter = new ArrayList();
        arrParameter.Add(new parameter("mode", mode));
        arrParameter.Add(new parameter("CountryID", SYS_Country.countryid));
        arrParameter.Add(new parameter("CountryIDStr", SYS_Country.countryidStr));
        return DAL_SYS_Country.DAL_Select("SELECT_DELETE_SYS_Country", arrParameter);
    }

    public DataSet BAL_SYS_Country_SelectAll()
    {
        DAL_SYS_Country = new DataAccess();
        return DAL_SYS_Country.DAL_SelectALL("SELECTAll_SYS_Country");
    }

    public void BindListByID(DropDownList Dlist, string Mode, int CountryID)
    {
        DataSet dsCountries = new DataSet();
        PCountry.countryid = CountryID;
        dsCountries = BAL_SYS_Country_Select(PCountry, Mode);
        Dlist.DataSource = dsCountries;
        Dlist.DataTextField = dsCountries.Tables[0].Columns["Country"].ToString();
        Dlist.DataValueField = dsCountries.Tables[0].Columns["CountryID"].ToString();
        Dlist.DataBind();
        Dlist.Items.Insert(0, "-- Select --");
        Dlist.Items[0].Value = "0";
    }
}