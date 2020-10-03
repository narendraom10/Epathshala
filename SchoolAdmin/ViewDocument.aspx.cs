using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class SchoolAdmin_ViewDocument : System.Web.UI.Page
{
    Document_BLogic oDocument_BLogic;
    MailDocument oDocument;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["title"]))
            {
                oDocument_BLogic = new Document_BLogic();
                oDocument = new MailDocument();

                oDocument.Documentpath = Server.MapPath("~/Documents/AdmissionDocument");
                oDocument.Title = Request.QueryString["title"];
                ViewState["title"] = Request.QueryString["title"];

                if (oDocument_BLogic.BAL_Document_CheckExists(oDocument))
                {
                    DataTable oTable = oDocument_BLogic.BAL_Document_Select(oDocument);

                    txttitle.Text = Convert.ToString(oTable.Rows[0]["title"]);
                    txttitle.Enabled = false;

                    txtmail.Content = Convert.ToString(oTable.Rows[0]["body"]);
                    txtmail.ActiveMode = AjaxControlToolkit.HTMLEditor.ActiveModeType.Preview;
                    txtmail.Enabled = false;

                }
            }
        }
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/SchoolAdmin/ManageDocument.aspx");
    }
}