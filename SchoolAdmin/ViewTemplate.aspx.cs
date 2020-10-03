using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class SchoolAdmin_ViewTemplate : System.Web.UI.Page
{
    Template_BLogic BAL_Template;
    Template oTemplate;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["title"]))
            {
                BAL_Template = new Template_BLogic();
                oTemplate = new Template();
                oTemplate.Templatepath = Server.MapPath("~/Template");
                oTemplate.Title = Request.QueryString["title"];
                ViewState["title"] = Request.QueryString["title"];

                if (BAL_Template.BAL_Template_CheckExists(oTemplate))
                {
                    DataTable oTable = BAL_Template.BAL_Template_Select(oTemplate);

                    txttitle.Text = Convert.ToString(oTable.Rows[0]["title"]);
                    txttitle.Enabled = false;

                    txtsubject.Text = Convert.ToString(oTable.Rows[0]["subject"]);
                    txtsubject.Enabled = false;
                        
                    txtmail.Content = Convert.ToString(oTable.Rows[0]["body"]);
                    txtmail.ActiveMode = AjaxControlToolkit.HTMLEditor.ActiveModeType.Preview;
                    txtmail.Enabled = false;

                }
            }
        }
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/SchoolAdmin/ManageTemplate.aspx");
    }
  
}