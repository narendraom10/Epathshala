using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Data;

public partial class Admission_admissiondashboard : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Convert.ToString(AppSessions.EmpolyeeID)) && Convert.ToString(AppSessions.EmpolyeeID) != "0" && AppSessions.RoleID == (int)EnumFile.Role.S_Admin) { }
        else
            Response.Redirect("~/Login.aspx");
    }
    private static string GetDashboardCount(string Type)
    {
        BAL_Admission oBAL_Admission = new BAL_Admission();
        DataSet ods = oBAL_Admission.Admission_Select_GetDashboardCount(Type);
        return Convert.ToString(ods.Tables[0].Rows[0][0]);
    }
    [WebMethod]
    public static string AddAdmissionRegistration()
    {
        return GetDashboardCount("TotalAdmission");
    }
    [WebMethod]
    public static string TotalInteraction()
    {
        return GetDashboardCount("TotalInteraction");
    }
    [WebMethod]
    public static string TotalApprove()
    {
        return GetDashboardCount("TotalApproveAdmission");
    }
    [WebMethod]
    public static string TotalNotApprove()
    {
        return GetDashboardCount("TotalNotApproveAdmission");
    }
    [WebMethod]
    public static string TotalFeesDocumentNotSubmitted()
    {
        return GetDashboardCount("TotalApproveAndFeesDocumentNotcomplatedAdmission");
    }
    [WebMethod]
    public static string TotalFinal()
    {
        return GetDashboardCount("TotalApproveAndFeesDocumentcomplatedAdmission");
    }
}