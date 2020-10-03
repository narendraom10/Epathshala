using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;

/// <summary>
/// Summary description for ProductLicense_Blogic
/// </summary>
public class ProductLicense_Blogic
{
    DataAccess DAL_License;
    ArrayList arrParameter;

    public int BAL_Product_Insert_Update(ProductLicense PL)
    {
        int t1 = 0;
        try
        {
            this.DAL_License = new DataAccess();
            this.arrParameter = new ArrayList();
            this.arrParameter.Add(new parameter("Code", PL.Code));
            this.arrParameter.Add(new parameter("ProductKey", PL.ProductKey));
            this.arrParameter.Add(new parameter("OldCode", PL.Oldcode));
            t1 = this.DAL_License.DAL_InsertUpdate_Return("Proc_Insert_Product_Registration", this.arrParameter);
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
        return t1;
    }
}