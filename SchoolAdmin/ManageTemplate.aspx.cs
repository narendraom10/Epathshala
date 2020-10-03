using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class SchoolAdmin_ManageTemplate : System.Web.UI.Page
{
    Template_BLogic BAL_Template;
    Template oTemplate;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindGrid();
        }
    }

    private void BindGrid()
    {
        BAL_Template = new Template_BLogic();
        oTemplate = new Template();

        oTemplate.Templatepath = Server.MapPath("~/Template");

        gvtemplate.DataSource = BAL_Template.BAL_Template_SelectALL(oTemplate);
        gvtemplate.DataBind();
    }
    protected void gvtemplate_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        BAL_Template = new Template_BLogic();
        oTemplate = new Template();
        oTemplate.Templatepath = Server.MapPath("~/Template");
        oTemplate.Title = Convert.ToString(e.CommandArgument);

        if (e.CommandName == "templateedit")
        {
            Response.Redirect("AddUpdateTemplate.aspx?title=" + Convert.ToString(e.CommandArgument) + "");
        }
        else if (e.CommandName == "templatedelete")
        {
            bool status = BAL_Template.BAL_Template_Delete(oTemplate);

            if (status)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Template has been deleted successfully.');", true);
                BindGrid();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Template has been deleted failed.');", true);
            }
        }
        else if (e.CommandName == "templateview")
        {
            Response.Redirect("ViewTemplate.aspx?title=" + Convert.ToString(e.CommandArgument) + "");
        }
    }
}