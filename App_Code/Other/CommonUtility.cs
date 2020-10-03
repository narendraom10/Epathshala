using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VarnindraClient;
using System.Data;
using System.Collections;

/// <summary>
/// Summary description for CommonUtility
/// </summary>
public static class CommonUtility
{
    static Common_Blogic CBLogic;

    /// <summary>
    /// Method wil be used to verify product license information.
    /// </summary>
    /// <param name="ProID">Product ID</param>
    /// <param name="ProKey">Product Key</param>
    /// <param name="ProCode">Product Code</param>
    /// <returns>Retuen boolean</returns>
    public static bool GetLicenseInfo(string ProID = null, string ProKey = null, string ProCode = null)
    {
        bool Flag = false;
        string ProductID = string.Empty;
        string strCode = string.Empty;
        string key = string.Empty;
        string OldCode = string.Empty;
        Prepaid objPrepaid = new Prepaid();
        DataSet dsProductInfo = new DataSet();
        try
        {
            dsProductInfo = GetProductInfoFromXML();
            if (dsProductInfo.Tables.Count > 0 & dsProductInfo != null)
            {
                if (dsProductInfo.Tables[0].Rows.Count > 0)
                {
                    OldCode = dsProductInfo.Tables[0].Rows[0]["OldCode"].ToString();
                }
            }

            if (ProID == null & ProKey == null & ProCode == null)
            {
                ProductID = GetProductID();
                if (dsProductInfo.Tables.Count > 0 & dsProductInfo != null)
                {
                    if (dsProductInfo.Tables[0].Rows.Count > 0)
                    {
                        strCode = dsProductInfo.Tables[0].Rows[0]["Code"].ToString();
                        key = dsProductInfo.Tables[0].Rows[0]["ProductKey"].ToString();
                    }
                }
            }
            else
            {
                ProductID = ProID;
                key = ProKey;
                strCode = ProCode;
            }



            if (strCode == string.Empty & key == string.Empty)
            {
                Flag = false;
            }
            else
            {
                if (strCode == objPrepaid.GetSystemInfo(ProductID, OldCode))
                {
                    enmErrorCode ErrorCode = new VarnindraClient.enmErrorCode();
                    ErrorCode = objPrepaid.CheckRegistration(strCode, key.Replace(" - ", ""), ProductID, DateTime.Now, "0", "0");

                    switch (ErrorCode.ToString())
                    {
                        case "Invalid_Product_ID":
                            Flag = false;
                            break;

                        case "InvalidKey":
                            Flag = false;
                            break;

                        case "Invalid_Count1":
                            Flag = false;
                            break;

                        case "Invalid_Count2":
                            Flag = false;
                            break;

                        case "Invalid_Start_Date":
                            Flag = false;
                            break;

                        case "No_Error":
                            Flag = true;
                            break;
                    }
                }
                else
                {
                    Flag = false;
                }
            }
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }

        return Flag;
    }

    /// <summary>
    /// Method wil be used to get product id.
    /// </summary>
    /// <returns>Returns string value</returns>
    public static string GetProductID()
    {
        string ProductID = string.Empty;
        try
        {
            Student_DashBoard_BLogic SBlogic = new Student_DashBoard_BLogic();
            DataSet dsProduct = new DataSet();
            dsProduct = SBlogic.BAL_Select_PaymentPagesInfo("Product");
            if (dsProduct != null & dsProduct.Tables.Count > 0)
            {
                if (dsProduct.Tables[0].Rows.Count > 0)
                {
                    ProductID = dsProduct.Tables[0].Rows[0]["value"].ToString();
                }
            }
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
        return ProductID;
    }

    /// <summary>
    /// Method will be used to get product related information.
    /// </summary>
    /// <returns></returns>
    public static DataSet GetProductInfo()
    {
        DataAccess DA = new DataAccess();
        DataSet dsInfo = new DataSet();
        try
        {
            dsInfo = DA.DAL_SelectALL("Proc_Select_Product_Info");
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
        return dsInfo;
    }


    public static DataSet GetProductInfoFromXML()
    {
        DataSet dsProductInfoFromXML = new DataSet();
        try
        {
            //string str = HttpContext.Current.Server.MapPath("~/Dashboard/KeySchema.xml").ToString();
            dsProductInfoFromXML.ReadXmlSchema(HttpContext.Current.Server.MapPath("~/Dashboard/KeySchema.xml"));
            dsProductInfoFromXML.ReadXml(HttpContext.Current.Server.MapPath("~/Dashboard/Key.xml"));
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
        return dsProductInfoFromXML;
    }

    /// <summary>
    /// Method will be used to perform logout action.
    /// </summary>
    public static void LogoutMethod()
    {
        try
        {
            Hashtable sessions = (Hashtable)HttpContext.Current.Application["WEB_SESSIONS_OBJECT"];
            if (sessions == null)
            {
                sessions = new Hashtable();
            }

            if (HttpContext.Current.Session["EmpolyeeID"] != null)
            {
                sessions.Remove(HttpContext.Current.Session["EmpolyeeID"].ToString());
            }

            if (HttpContext.Current.Session["StudentID"] != null)
            {
                sessions.Remove(HttpContext.Current.Session["StudentID"].ToString());
            }

            HttpContext.Current.Application.Lock();
            HttpContext.Current.Application["WEB_SESSIONS_OBJECT"] = sessions;
            HttpContext.Current.Application.UnLock();
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }

    /// <summary>
    /// Method will be used to remove product key from databse.
    /// </summary>
    public static void RemoveKey()
    {
        try
        {
            ProductLicense_Blogic BLogic_Product = new ProductLicense_Blogic();
            ProductLicense Property_Product = new ProductLicense();
            DataSet ds = new DataSet();
            ds = GetProductInfo();
            string OldCode = string.Empty;
            if (ds != null & ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    OldCode = ds.Tables[0].Rows[0]["Code"].ToString();
                }
            }
            Property_Product.Code = string.Empty;
            Property_Product.ProductKey = string.Empty;
            Property_Product.Oldcode = OldCode;
            BLogic_Product.BAL_Product_Insert_Update(Property_Product);
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }

    }


    public static void RemoveKeyFromXML()
    {
        try
        {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            ds = GetProductInfoFromXML();
            string OldCode = string.Empty;
            if (ds != null & ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    OldCode = ds.Tables[0].Rows[0]["Code"].ToString();
                }
            }


            //dt.ReadXmlSchema(HttpContext.Current.Server.MapPath("~/Dashboard/KeySchema.xml"));
            //dt.ReadXml(HttpContext.Current.Server.MapPath("~/Dashboard/KeySchema.xml"));
            dt = ds.Tables[0];

            dt.Rows[0]["Code"] = string.Empty;
            dt.Rows[0]["ProductKey"] = string.Empty;
            dt.Rows[0]["OldCode"] = OldCode;
            dt.AcceptChanges();

            dt.WriteXml(HttpContext.Current.Server.MapPath("~/Dashboard/Key.xml"));
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }

    }


    /// <summary>
    /// Method will be used to get relevant email address.
    /// </summary>
    /// <returns>Array list</returns>
    public static ArrayList GetEmailAddress(string GroupName)
    {
        CBLogic = new Common_Blogic();
        DataSet ds = new DataSet();
        ArrayList alistContacts = new ArrayList();
        ds = CBLogic.BAL_Select_Report_Contact("Admin");
        if (ds != null & ds.Tables.Count > 0)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    alistContacts.Add(ds.Tables[0].Rows[i]["Email"].ToString());
                }
            }
        }
        return alistContacts;
    }
}


