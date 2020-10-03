using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SysConfigPage : System.Web.UI.Page
{
    #region Variables

    Student_DashBoard_BLogic obj_BAL_Student_Dashboard = new Student_DashBoard_BLogic();
   
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        FillDDLFieldGroup(ddlFieldGroup);
    }
    protected void DrpDwnLstFieldGroup_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    #region "User defined functions"

    private void FillDDLFieldGroup(DropDownList ddl)
    {
        ddl.Items.Clear();
        obj_BAL_Student_Dashboard.get_DDLFieldGroup(ddl);
    }

    #endregion
}