using System;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SchoolAdmin_ManageDocument : System.Web.UI.Page
{
    #region declaration

    Document_BLogic BAL_Document;
    MailDocument oDocument;

    #endregion

    #region PageLoad
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindGrid();
        }
    }

    #endregion

    #region Control Event

    protected void gvdocument_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        BAL_Document = new Document_BLogic();
        oDocument = new MailDocument();
        oDocument.Documentpath = Server.MapPath("~/Documents/AdmissionDocument");
        oDocument.Title = Convert.ToString(e.CommandArgument);

        if (e.CommandName == "documentedit")
        {
            Response.Redirect("AddDocument.aspx?title=" + Convert.ToString(e.CommandArgument) + "");
        }
        else if (e.CommandName == "documentdelete")
        {
            bool status = BAL_Document.BAL_Document_Delete(oDocument);

            if (status)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Document has been deleted successfully.');", true);
                BindGrid();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Document has been deleted failed.');", true);
            }
        }
        else if (e.CommandName == "documentview")
        {
            Response.Redirect("ViewDocument.aspx?title=" + Convert.ToString(e.CommandArgument) + "");
        }
    }

    #endregion

    #region User define method

    private void BindGrid()
    {
        BAL_Document = new Document_BLogic();
        oDocument = new MailDocument();

        oDocument.Documentpath = Server.MapPath("~/Documents/AdmissionDocument");

        gvdocument.DataSource = BAL_Document.BAL_Document_SelectALL(oDocument);
        gvdocument.DataBind();
    }

    #endregion
}