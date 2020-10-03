using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Collections;
using System.IO;
using System.Data;

public partial class Dashboard_SendAssesmentMail : System.Web.UI.Page
{
    Template_BLogic BAL_Template;
    Template oTemplate;
    DataTable oTable;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            stdlist.BMSID = AppSessions.BMSID;
            stdlist.DivisionID = AppSessions.DivisionID;
            stdlist.SchoolID = AppSessions.SchoolID;
            stdlist.PageTitle = "Send Assesment E-Mail";

            if (PreviousPage != null)
            {
                if (PreviousPage.AttchmentList.Count > 0)
                {
                    ArrayList array = new ArrayList();
                    foreach (string filepath in PreviousPage.AttchmentList)
                    {
                        if (Path.GetExtension(filepath).ToLower() == ".pdf")
                            array.Add(filepath);
                    }
                    stdlist.Attachment = array;
                }
                if (!string.IsNullOrEmpty(PreviousPage.Templatetitle))
                {
                    BAL_Template = new Template_BLogic();
                    oTemplate = new Template();

                    oTemplate.Templatepath = Server.MapPath("~/Template");
                    oTemplate.Title = PreviousPage.Templatetitle;

                    if (BAL_Template.BAL_Template_CheckExists(oTemplate))
                    {
                        oTable = new DataTable();
                        oTable = BAL_Template.BAL_Template_Select(oTemplate);

                        stdlist.Subject = Convert.ToString(oTable.Rows[0]["subject"]);
                        stdlist.MailBody = Convert.ToString(oTable.Rows[0]["body"]);
                    }
                }
            }
        }
    }
}