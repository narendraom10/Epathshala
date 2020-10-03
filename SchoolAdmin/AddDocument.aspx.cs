using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

public partial class SchoolAdmin_AddDocument : System.Web.UI.Page
{
    #region Declaration

    Admission_BLogic oAdmission_BLogic;
    Admission oAdmission;

    Document_BLogic oDocument_BLogic;
    MailDocument oDocument;

    #endregion

    #region pageload

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
                    btnSubmit.Text = "Update";
                    lblTitle.Text = "Update Document";

                    DataTable oTable = oDocument_BLogic.BAL_Document_Select(oDocument);

                    txttitle.Text = Convert.ToString(oTable.Rows[0]["title"]);
                    txtmail.Content = Convert.ToString(oTable.Rows[0]["body"]);
                    ViewState["Mode"] = "Update";
                }
                else
                {
                    ViewState["Mode"] = "Add";
                }
            }
            else
            {
                ViewState["Mode"] = "Add";
            }
            BindTagDropDown();
        }
    }

    #endregion

    #region Control event

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        oDocument_BLogic = new Document_BLogic();
        oDocument = new MailDocument();

        oDocument.Documentpath = Server.MapPath("~/Documents/AdmissionDocument");
        oDocument.Title = txttitle.Text;
        oDocument.Body = txtmail.Content;

        if (Convert.ToString(ViewState["Mode"]) == "Add")
        {
            if (!oDocument_BLogic.BAL_Document_CheckExists(oDocument))
            {
                bool status = oDocument_BLogic.BAL_Document_Insert(oDocument);

                if (status)
                {
                    Response.Redirect("ManageDocument.aspx");
                }
                else
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Document has been added failed.');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Document already exists.');", true);
            }
        }
        else if (Convert.ToString(ViewState["Mode"]) == "Update")
        {
            if (!oDocument_BLogic.BAL_Document_CheckExists(oDocument) || oDocument.Title == Convert.ToString(ViewState["title"]))
            {
                DeleteOldTemplate();
                bool status = oDocument_BLogic.BAL_Document_Update(oDocument);

                if (status)
                {
                    Response.Redirect("ManageDocument.aspx");
                }
                else
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Document has been updated failed.');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Document already exists.');", true);
            }
        }
    }
    protected void btnclose_Click(object sender, EventArgs e)
    {
        Response.Redirect("ManageDocument.aspx");
    }

    #endregion

    #region User define method

    private void DeleteOldTemplate()
    {
        string Templatepath = Path.Combine(oDocument.Documentpath, Convert.ToString(AppSessions.SchoolID));
        if (File.Exists(Path.Combine(Templatepath, ViewState["title"] + ".xml")))
            File.Delete(Path.Combine(Templatepath, ViewState["title"] + ".xml"));
    }

    private void BindTagDropDown()
    {
        DropDownFill DdlFilling = new DropDownFill();
        oAdmission = new Admission();
        oAdmission_BLogic = new Admission_BLogic();

        DataSet odsTag = oAdmission_BLogic.AdmissionTagMaster_Select_All();        

        if (odsTag.Tables.Count > ((int)EnumFile.AssignValue.Zero))
        {
            DdlFilling.BindDropDownByTable(DdlTag, odsTag.Tables[0], "ValueField", "DisplayTag");
        }
        else
        {
            DdlFilling.ClearDropDownListRef(DdlTag);
        }       
    }


    #endregion
}