using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Data;

/// <summary>
/// Summary description for Common_Blogic
/// </summary>
public class Common_Blogic
{
    DataAccess DA;
    ArrayList arrParameter;
	
    /// <summary>
    /// Method will be used to select email contact from database.
    /// </summary>
    /// <param name="GroupName">Indicate group name.</param>
    /// <returns>Dataset</returns>
    public DataSet BAL_Select_Report_Contact(string GroupName)
    {
        DA = new DataAccess();
        arrParameter = new ArrayList();
        arrParameter.Add(new parameter("GroupName", GroupName));
        return DA.DAL_Select("Peoc_Get_Report_Contact_GroupWise", arrParameter);
    }
    public DataSet BAL_Select_offer()
    {
        DA = new DataAccess();
        arrParameter = new ArrayList();
        return DA.DAL_Select("tbloffer_Get_offer", arrParameter);
    }
}