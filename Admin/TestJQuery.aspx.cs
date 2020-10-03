using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;

public partial class Admin_TestJQuery : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    [WebMethod()]public static string CheckUserID(string UserID)
    {
        Employee_BLogic BAL_Employee = new Employee_BLogic();
        bool IsExists = BAL_Employee.BAL_Employee_CheckLogin(UserID);
        if (IsExists)
            return "True";
        else
            return "False";
    }
}