using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Web.Services;
using System.Text;

public partial class Admission_AdmissionFeesAndDocument : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Convert.ToString(AppSessions.EmpolyeeID)) && Convert.ToString(AppSessions.EmpolyeeID) != "0" && AppSessions.RoleID == (int)EnumFile.Role.S_Admin)
        {
            if (!Page.IsPostBack)
            {
                BindGrid();
            }
            mainpopup.Attributes["class"] = "overlay";
            msg.InnerHtml = "";
        }
        else
        {
            Response.Redirect("~/Login.aspx");
        }
    }
    protected void OnPagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
    {
        (lvstudent.FindControl("pglvstudent") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
        (lvstudent.FindControl("pglvstudentlabel") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
        this.BindGrid();
    }
    private void BindGrid()
    {
        AdmissionProperties oAdmissionProperties = new AdmissionProperties();
        BAL_Admission oBAL_Admission = new BAL_Admission();

        DataSet ods = oBAL_Admission.Admission_Select_AdmissionFeesAndDocument(AdmissionGradeFilter.Value);

        lvstudent.DataSource = ods;
        lvstudent.DataBind();
    }
    protected void hdnadmissiongradefilter_Click(object sender, EventArgs e)
    {
        BindGrid();
    }
    protected void btnsubmitadmission_click(object sender, EventArgs e)
    {
        string admissionid = hdnCurrentAdmissionid.Value;
        string admissiongrade = hdnCurrentAdmissionGrade.Value;
        string Nationality = hdnCurrentNationality.Value;
        bool AllComplate = true;

        BAL_Admission oBAL_Admission = new BAL_Admission();
        AdmissionFeesAndDocument oAdmissionFeesAndDocument = new AdmissionFeesAndDocument();

        oAdmissionFeesAndDocument.AdmissionId = admissionid;

        oAdmissionFeesAndDocument.Fees = chkdocumentlist.Items.FindByText("Fees").Selected;
        if (!oAdmissionFeesAndDocument.Fees)
            AllComplate = false;

        oAdmissionFeesAndDocument.BirthCertificate = chkdocumentlist.Items.FindByText("Birth Certificate").Selected;
        if (!oAdmissionFeesAndDocument.BirthCertificate)
            AllComplate = false;

        oAdmissionFeesAndDocument.AdmissionAcceptanceForm = chkdocumentlist.Items.FindByText("Admission Acceptance Form").Selected;
        if (!oAdmissionFeesAndDocument.AdmissionAcceptanceForm)
            AllComplate = false;

        oAdmissionFeesAndDocument.ParentsTestimonials = chkdocumentlist.Items.FindByText("Parents Testimonials").Selected;
        if (!oAdmissionFeesAndDocument.ParentsTestimonials)
            AllComplate = false;

        switch (admissiongrade)
        {
            case "Nursery":
            case "Jr KG":
            case "Sr KG":
                oAdmissionFeesAndDocument.BonafiedCertificate = chkdocumentlist.Items.FindByText("Bonafide Certificate").Selected;
                if (!oAdmissionFeesAndDocument.BonafiedCertificate)
                    AllComplate = false;
                break;
            case "1":
            case "2":
            case "3":
            case "4":
            case "5":
            case "6":
            case "7":
            case "8":
            case "9":
            case "10":
            case "11":
                oAdmissionFeesAndDocument.SchoolLeavingCertificate = chkdocumentlist.Items.FindByText("SchoolLeaving Certificate").Selected;
                if (!oAdmissionFeesAndDocument.SchoolLeavingCertificate)
                    AllComplate = false;
                break;
            default:
                break;
        }
        if (Nationality == "Other")
        {
            oAdmissionFeesAndDocument.ReferenceletterTC = chkdocumentlist.Items.FindByText("Reference letter/TC").Selected;
            if (!oAdmissionFeesAndDocument.ReferenceletterTC)
                AllComplate = false;
            oAdmissionFeesAndDocument.CopyofPassport = chkdocumentlist.Items.FindByText("Copy of Passport").Selected;
            if (!oAdmissionFeesAndDocument.CopyofPassport)
                AllComplate = false;
        }

        oAdmissionFeesAndDocument.CreatedBy = Convert.ToString(AppSessions.EmpolyeeID);
        oAdmissionFeesAndDocument.AllComplate = AllComplate;

        bool IsSuccess = oBAL_Admission.AdmissionFeesAndDocument_Insert(oAdmissionFeesAndDocument);

        BindGrid();
        fdpopup.Attributes["class"] = "overlay";
        mainpopup.Attributes["class"] = "overlayone";

        if (IsSuccess)
            msg.InnerHtml = "Fees And Document has been submitted successfully.";
        else
            msg.InnerHtml = "Fees And Document has been submitted failed.";
    }
    private string GetValue(string inputstring)
    {
        return (!string.IsNullOrEmpty(inputstring) ? inputstring.Trim() : null);
    }
    protected void btnGetHistory_Click(object sender, EventArgs e)
    {
        string admissionid = hdnCurrentAdmissionid.Value;
        string admissiongrade = hdnCurrentAdmissionGrade.Value;
        string referencenumber = hdnCurrentReferenceNumber.Value;
        string Nationality = hdnCurrentNationality.Value;

        AdmissionProperties oAdmissionProperties = new AdmissionProperties();
        BAL_Admission oBAL_Admission = new BAL_Admission();

        chkdocumentlist.Items.Clear();

        DataSet ods = oBAL_Admission.Admission_Select_AdmissionFeesAndDocument_ByAdmissionId(admissionid);

        if (ods.Tables[0].Rows.Count > 0)
        {
            ListItem li = new ListItem("Fees");
            li.Selected = Convert.ToBoolean(ods.Tables[0].Rows[0]["Fees"]);
            chkdocumentlist.Items.Add(li);

            li = new ListItem("Birth Certificate");
            li.Selected = Convert.ToBoolean(ods.Tables[0].Rows[0]["BirthCertificate"]);
            chkdocumentlist.Items.Add(li);

            li = new ListItem("Admission Acceptance Form");
            li.Selected = Convert.ToBoolean(ods.Tables[0].Rows[0]["AdmissionAcceptanceForm"]);
            chkdocumentlist.Items.Add(li);

            li = new ListItem("Parents Testimonials");
            li.Selected = Convert.ToBoolean(ods.Tables[0].Rows[0]["ParentsTestimonials"]);
            chkdocumentlist.Items.Add(li);

            switch (admissiongrade)
            {
                case "Nursery":
                case "Jr KG":
                case "Sr KG":
                    li = new ListItem("Bonafide Certificate");
                    li.Selected = Convert.ToBoolean(ods.Tables[0].Rows[0]["BonafiedCertificate"]);
                    chkdocumentlist.Items.Add(li);
                    break;
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                case "10":
                case "11":
                    li = new ListItem("School Leaving Certificate");
                    li.Selected = Convert.ToBoolean(ods.Tables[0].Rows[0]["SchoolLeavingCertificate"]);
                    chkdocumentlist.Items.Add(li);
                    break;
                default:
                    break;
            }
            if (Nationality == "Other")
            {
                li = new ListItem("Reference letter/TC");
                li.Selected = Convert.ToBoolean(ods.Tables[0].Rows[0]["ReferenceletterTC"]);
                chkdocumentlist.Items.Add(li);

                li = new ListItem("Copy of Passport");
                li.Selected = Convert.ToBoolean(ods.Tables[0].Rows[0]["CopyofPassport"]);
                chkdocumentlist.Items.Add(li);
            }
        }
        fdpopup.Attributes["class"] = "overlayone";
    }
}

