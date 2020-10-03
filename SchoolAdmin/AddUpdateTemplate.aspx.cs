using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

public partial class SchoolAdmin_AddUpdateTemplate : System.Web.UI.Page
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
                    btnSubmit.Text = "Update";
                    btnsubmitadd.Visible = false;
                    lblTitle.Text = "Update Template";

                    DataTable oTable = BAL_Template.BAL_Template_Select(oTemplate);

                    txttitle.Text = Convert.ToString(oTable.Rows[0]["title"]);
                    txtsubject.Text = Convert.ToString(oTable.Rows[0]["subject"]);
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
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        BAL_Template = new Template_BLogic();
        oTemplate = new Template();

        oTemplate.Templatepath = Server.MapPath("~/Template");
        oTemplate.Title = txttitle.Text;
        oTemplate.Subject = txtsubject.Text;
        oTemplate.Body = txtmail.Content;

        if (Convert.ToString(ViewState["Mode"]) == "Add")
        {
            oTemplate.CreatedBy = AppSessions.EmpolyeeID;

            if (!BAL_Template.BAL_Template_CheckExists(oTemplate))
            {
                bool status = BAL_Template.BAL_Template_Insert(oTemplate);

                if (status)
                {
                    Response.Redirect("ManageTemplate.aspx");
                }
                else
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Template has been added failed.');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Template already exists.');", true);
            }
        }
        else if (Convert.ToString(ViewState["Mode"]) == "Update")
        {
            oTemplate.Modifiedby = AppSessions.EmpolyeeID;

            if (!BAL_Template.BAL_Template_CheckExists(oTemplate) || oTemplate.Title == Convert.ToString(ViewState["title"]))
            {
                DeleteOldTemplate();
                bool status = BAL_Template.BAL_Template_Update(oTemplate);

                if (status)
                {
                    Response.Redirect("ManageTemplate.aspx");
                }
                else
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Template has been updated failed.');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Template already exists.');", true);
            }
        }
    }

    protected void btnsubmitadd_Click(object sender, EventArgs e)
    {
        BAL_Template = new Template_BLogic();
        oTemplate = new Template();

        oTemplate.Templatepath = Server.MapPath("~/Template");
        oTemplate.Title = txttitle.Text;
        oTemplate.Subject = txtsubject.Text;
        oTemplate.Body = txtmail.Content;

        if (Convert.ToString(ViewState["Mode"]) == "Add")
        {
            oTemplate.CreatedBy = AppSessions.EmpolyeeID;

            if (!BAL_Template.BAL_Template_CheckExists(oTemplate))
            {
                bool status = BAL_Template.BAL_Template_Insert(oTemplate);

                if (status)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Template has been added successfully.');", true);
                    ResetControl();
                }
                else
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Template has been added failed.');", true);
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Template already exists.');", true);
        }
    }
    protected void btnclose_Click(object sender, EventArgs e)
    {
        Response.Redirect("ManageTemplate.aspx");
    }
    private void ResetControl()
    {
        txttitle.Text = string.Empty;
        txtsubject.Text = string.Empty;
        txtmail.Content = string.Empty;
    }
    private void DeleteOldTemplate()
    {
        string Templatepath = Path.Combine(oTemplate.Templatepath, Convert.ToString(AppSessions.SchoolID));
        if (File.Exists(Path.Combine(Templatepath, ViewState["title"] + ".xml")))
            File.Delete(Path.Combine(Templatepath, ViewState["title"] + ".xml"));
    }
    protected void btnupload_Click(object sender, EventArgs e)
    {
        try
        {
            if ((fuimage.PostedFile != null) && (fuimage.PostedFile.ContentLength > 0))
            {
                string fileExtension = System.IO.Path.GetExtension(fuimage.PostedFile.FileName).ToLower();
                string saveimagepath = Server.MapPath("~/Documents/MailImage");
                string saveimagename = DateTime.Now.ToString("yyyyMMddhhmmsstt") + fileExtension;
                string saveimagefullpath = Path.Combine(saveimagepath, saveimagename);
                fuimage.PostedFile.SaveAs(saveimagefullpath);

                string originalPath = new Uri(HttpContext.Current.Request.Url.AbsoluteUri).OriginalString;
                string parentDirectory = originalPath.Substring(0, originalPath.LastIndexOf("/"));
                string parentparentDirectory = parentDirectory.Substring(0, parentDirectory.LastIndexOf("/"));
                string ImageURL = parentparentDirectory + "/Documents/MailImage/" + saveimagename;

                txtmail.Content = txtmail.Content + "<img src=" + ImageURL + ">";
            }
            else
            {
                WebMsg.Show("Please select file....");
            }
        }
        catch (Exception ex)
        {
        }
    }
    private void BindTagDropDown()
    {
        DropDownFill DdlFilling = new DropDownFill();
        Admission oAdmission = new Admission();
        Admission_BLogic oAdmission_BLogic = new Admission_BLogic();

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
}