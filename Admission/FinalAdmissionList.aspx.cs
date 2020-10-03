using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Admission_FinalAdmissionList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Convert.ToString(AppSessions.EmpolyeeID)) && Convert.ToString(AppSessions.EmpolyeeID) != "0" && AppSessions.RoleID == (int)EnumFile.Role.S_Admin)
        {
            if (!Page.IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["frm"]))
                {
                    switch (Convert.ToString(Request.QueryString["frm"]))
                    {
                        case "ta":
                            ViewState["Type"] = "TotalAdmission";
                            headerText.Text = "TOTAL ADMISSION REGISTRATION";
                            break;
                        case "ti":
                            ViewState["Type"] = "TotalInteraction";
                            headerText.Text = "TOTAL INTERACTION SEND";
                            break;
                        case "taa":
                            ViewState["Type"] = "TotalApproveAdmission";
                            headerText.Text = "TOTAL ADMISSION APPROVE";
                            break;
                        case "tnaa":
                            ViewState["Type"] = "TotalNotApproveAdmission";
                            headerText.Text = "TOTAL ADMISSION NOT APPROVE";
                            break;
                        case "fdc":
                            ViewState["Type"] = "TotalApproveAndFeesDocumentcomplatedAdmission";
                            headerText.Text = "CONFIRMED ADMISSION";
                            break;
                        case "fdnc":
                            ViewState["Type"] = "TotalApproveAndFeesDocumentNotcomplatedAdmission";
                            headerText.Text = "FEES OR DOCUMENT NOT-COMPLATE";
                            break;
                        default:
                            ViewState["Type"] = "TotalAdmission";
                            headerText.Text = "TOTAL ADMISSION REGISTRATION";
                            break;
                    }
                    BindGrid();
                }
            }
        }
        else
        {
            Response.Redirect("~/Login.aspx");
        }
    }
    private void BindGrid()
    {
        AdmissionProperties oAdmissionProperties = new AdmissionProperties();
        BAL_Admission oBAL_Admission = new BAL_Admission();

        DataSet ods = oBAL_Admission.Admission_Select_GetDashboardCountData(Convert.ToString(ViewState["Type"]), AdmissionGradeFilter.Value);

        lvstudent.DataSource = ods;
        lvstudent.DataBind();
    }
    protected void hdnadmissiongradefilter_Click(object sender, EventArgs e)
    {
        BindGrid();
    }
}