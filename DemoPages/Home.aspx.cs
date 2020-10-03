using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class DemoPages_Home : System.Web.UI.Page
{
    SYS_BMS_BLogic BSysBMS = new SYS_BMS_BLogic();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            GetBMS();
    }

    #region "User Defined Function"
    protected void GetBMS()
    {
        DropDownFill DdlFilling = new DropDownFill();
        DataSet dsBMS = new DataSet();
        dsBMS = BSysBMS.BAL_SYS_BMS_SelectAll();
        if (dsBMS.Tables[0].Rows.Count > 0)
        {
            DdlFilling.BindDropDownByTable(ddlBMS, dsBMS.Tables[0], "BMS", "BMSID");
            ddlBMS.Items.Insert(Convert.ToInt32(EnumFile.AssignValue.Zero), "-- Select --");
            ddlBMS.Items[0].Value = Convert.ToString((int)EnumFile.AssignValue.Zero);
            ddlBMS.Enabled = true;
        }
    }
    #endregion
    
    protected void btnSubmit1_Click(object sender, EventArgs e)
    {
        Session["DemoUserName"] = txtFirstName.Text;
        Session["DEMOBMSID"] = ddlBMS.SelectedValue.ToString();
        Session["DEMOBMSSDNameEduResource"] = ddlBMS.SelectedItem.ToString();
        Response.Redirect("../Dashboard/StudentDashboardDemo.aspx");
    }

  
}