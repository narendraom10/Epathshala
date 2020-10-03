using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Landing : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SYS_Role_BLogic obj_BAL_SYS_Role;
        if (!IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["frm"]))
            {
                if (Convert.ToString(Request.QueryString["frm"]) == "cp")
                {
                    WebMsg.Show("Change password successfully, please login with new password");
                    return;
                }
            }
            //string strcurrentsession = HttpContext.Current.Session.SessionID;
            //obj_BAL_SYS_Role = new SYS_Role_BLogic();

            //DataSet dsLoginDetails = obj_BAL_SYS_Role.BAL_SYS_Select_IsLoggedIn(strcurrentsession);
                
            if ((Session["StudentID"] != null) || (Session["EmployeeID"] != null))
            {
                //if (Convert.ToInt32(dsLoginDetails.Tables[0].Rows[0]["SessionCount"]) > 0)
                //{
                    Response.Redirect("../Dashboard/StudentDashboard.aspx");
                //}
            }
           
        }

    }
}