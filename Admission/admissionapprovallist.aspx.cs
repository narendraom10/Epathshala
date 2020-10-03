using System;
using System.Collections;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Text;
using System.IO;
using System.Xml;

public partial class Admission_admissionapprovallist : System.Web.UI.Page
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

        oAdmissionProperties.AdmissionGrade = AdmissionGradeFilter.Value;

        DataSet ods = oBAL_Admission.Admission_Select_admissionapprovallist(oAdmissionProperties);

        lvstudent.DataSource = ods;
        lvstudent.DataBind();

        if (ods.Tables[0].Rows.Count > 0)
            btnapproveadmission.Visible = true;
        else
            btnapproveadmission.Visible = false;
    }
    protected void btnapproveadmission_click(object sender, EventArgs e)
    {
        foreach (ListViewDataItem item in lvstudent.Items)
        {
            string AdmissionID = string.Empty;
            string Remarks = string.Empty;
            string MailFrom = string.Empty;
            string MailTo = string.Empty;
            string MailSubject = string.Empty;
            string MailBody = string.Empty;
            string FailiurReason = string.Empty;
            ArrayList ArrMailTo = new ArrayList();
            ArrayList ArrAttachmentList = new ArrayList();

            HtmlInputCheckBox admissionapprovalcheck = (HtmlInputCheckBox)item.FindControl("admissionapprovalcheck");
            if (admissionapprovalcheck.Checked)
            {
                HtmlInputRadioButton radioadmissionyes = (HtmlInputRadioButton)item.FindControl("radioadmissionyes");
                HtmlInputRadioButton radioadmissionno = (HtmlInputRadioButton)item.FindControl("radioadmissionno");

                if (radioadmissionyes.Checked)
                {
                    HtmlSelect approvalremarksyes = (HtmlSelect)item.FindControl("approvalremarksyes");
                    Label communicationemail = (Label)item.FindControl("communicationemail");
                    HiddenField hdnAdmissionID = (HiddenField)item.FindControl("hdnAdmissionID");
                    HiddenField hdnFirstname = (HiddenField)item.FindControl("hdnFirstname");
                    HiddenField hdnLastName = (HiddenField)item.FindControl("hdnLastName");
                    HiddenField hdnAddressline1 = (HiddenField)item.FindControl("hdnAddressline1");
                    HiddenField hdnCity = (HiddenField)item.FindControl("hdnCity");
                    HiddenField hdnState = (HiddenField)item.FindControl("hdnState");
                    HiddenField hdnAdmissionGrade = (HiddenField)item.FindControl("hdnAdmissionGrade");

                    AdmissionID = hdnAdmissionID.Value;
                    Remarks = approvalremarksyes.Value;
                    MailFrom = EmailUtility.SMTPEmailAddress;
                    MailTo = communicationemail.Text;
                    MailSubject = GetMailSubject();
                    MailBody = GetMailBody(hdnFirstname.Value, hdnLastName.Value, hdnAddressline1.Value, hdnCity.Value, hdnState.Value, hdnAdmissionGrade.Value);

                    ArrMailTo.Add(MailTo);

                    string DocumentPath = Server.MapPath("~/Documents/AISAdmissionDocument");
                    ArrAttachmentList.Add(Path.Combine(DocumentPath, "Grade " + hdnAdmissionGrade.Value + " Fee Schedule 2015-16.pdf"));
                    ArrAttachmentList.Add(Path.Combine(DocumentPath, "Grade " + hdnAdmissionGrade.Value + " Admission Acceptance Form 2015-16.pdf"));

                    bool IsSendSuccess = EmailUtility.SendEmail(ArrMailTo, MailSubject, MailBody, out FailiurReason, ArrAttachmentList);

                    BAL_Admission oBAL_Admission = new BAL_Admission();
                    AdmissionApproval oAdmissionApproval = new AdmissionApproval();

                    oAdmissionApproval.AdmissionId = AdmissionID;
                    oAdmissionApproval.AdmissionStatus = "Approve";
                    oAdmissionApproval.Remarks = GetValue(Remarks);
                    oAdmissionApproval.MailFrom = MailFrom;
                    oAdmissionApproval.MailTo = MailTo;
                    oAdmissionApproval.MailSubject = MailSubject;
                    oAdmissionApproval.MailBody = MailBody;
                    oAdmissionApproval.IsSendSuccess = IsSendSuccess;
                    oAdmissionApproval.FailureReasons = GetValue(FailiurReason);
                    oAdmissionApproval.CreatedBy = Convert.ToString(AppSessions.EmpolyeeID);

                    oBAL_Admission.AdmissionApproval_Insert(oAdmissionApproval);

                }
                else if (radioadmissionno.Checked)
                {
                    HiddenField hdnAdmissionID = (HiddenField)item.FindControl("hdnAdmissionID");
                    HtmlSelect approvalremarksno = (HtmlSelect)item.FindControl("approvalremarksno");

                    AdmissionID = hdnAdmissionID.Value;
                    Remarks = approvalremarksno.Value;
                    MailFrom = null;
                    MailTo = null;
                    MailSubject = null;
                    MailBody = null;

                    BAL_Admission oBAL_Admission = new BAL_Admission();
                    AdmissionApproval oAdmissionApproval = new AdmissionApproval();

                    oAdmissionApproval.AdmissionId = AdmissionID;
                    oAdmissionApproval.AdmissionStatus = "NotApprove";
                    oAdmissionApproval.Remarks = GetValue(Remarks);
                    oAdmissionApproval.MailFrom = MailFrom;
                    oAdmissionApproval.MailTo = MailTo;
                    oAdmissionApproval.MailSubject = MailSubject;
                    oAdmissionApproval.MailBody = MailBody;
                    oAdmissionApproval.IsSendSuccess = true;
                    oAdmissionApproval.FailureReasons = GetValue("Mail Not Send Because Admission NotApprove");
                    oAdmissionApproval.CreatedBy = Convert.ToString(AppSessions.EmpolyeeID);

                    oBAL_Admission.AdmissionApproval_Insert(oAdmissionApproval);
                }
            }
        }
        BindGrid();

        mainpopup.Attributes["class"] = "overlayone";
        msg.InnerHtml = "Your operation has been successfully completed.";
    }
    protected void hdnadmissiongradefilter_Click(object sender, EventArgs e)
    {
        BindGrid();
    }
    private string GetValue(string inputstring)
    {
        return (!string.IsNullOrEmpty(inputstring) ? inputstring.Trim() : null);
    }
    private string GetMailBody(string firstName, string lastName, string addressLine1, string city, string state, string admissionGrade)
    {
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(Path.Combine(Server.MapPath("~/Admission"), "AdmissionApprovalMail.xml"));
        XmlNode oNode = xmlDoc.DocumentElement;

        StringBuilder oBuilder = new StringBuilder(oNode.SelectSingleNode("Mailbody").InnerText);

        oBuilder.Replace("@@lastName@@", lastName);
        oBuilder.Replace("@@firstName@@", firstName);
        oBuilder.Replace("@@admissionGrade@@", admissionGrade);

        //oBuilder.Append("<p style='font-size: 13px; font-family: arial,sans-serif;'><span style='font-size: 12pt; font-family: 'Times New Roman',serif;'>Dear Mr &amp; Mrs." + lastName + "</span></p>");
        //oBuilder.Append("<p style='font-size: 13px; font-family: arial,sans-serif;'><span style='font-size: 12pt; font-family: 'Times New Roman',serif;'>We are pleased to inform you that after discussions we had during the interaction session," + firstName + " has been selected for admission in TODDEN-AIS -&nbsp;<strong>for " + admissionGrade + " 2016-17</strong></span></p>");
        //oBuilder.Append("<div>");
        //oBuilder.Append("<p style='font-family: arial,sans-serif; font-size: 13px;'><span style='font-size: 12pt; font-family: 'Times New Roman',serif;'>We take this opportunity to congratulate your child warmly, on securing a place in TODDEN-AIS .We are confident that we will be able to provide&nbsp; a stimulating and challenging learning environment at the school.</span></p>");
        //oBuilder.Append("<p style='font-family: arial,sans-serif; font-size: 13px;'><span style='font-size: 12pt; font-family: 'Times New Roman',serif;'>We&nbsp;&nbsp;now seek your cooperation in ensuring that our admission process is completed as quickly as possible. To complete the admission process, we request you to kindly submit the following:</span></p>");
        //oBuilder.Append("<p style='font-family: arial,sans-serif; font-size: 13px; margin-left: 0.5in;'><span style='font-size: 12pt; font-family: 'Times New Roman',serif;'>1.</span><span style='font-size: 7pt; font-family: 'Times New Roman',serif;'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span style='font-size: 12pt; font-family: 'Times New Roman',serif;'>The Admission acceptance form( attached herein )duly signed&nbsp;&nbsp;by both parents and</span></p>");
        //oBuilder.Append("<p style='font-family: arial,sans-serif; font-size: 13px; margin-left: 0.5in;'><span style='font-size: 12pt; font-family: 'Times New Roman',serif;'>2.</span><span style='font-size: 7pt; font-family: 'Times New Roman',serif;'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span style='font-size: 12pt; font-family: 'Times New Roman',serif;'>The payment of fees as per the schedule .(attached herein)</span></p>");
        //oBuilder.Append("<p style='font-family: arial,sans-serif; font-size: 13px;'><span style='font-size: 12pt; font-family: 'Times New Roman',serif;'>Please note that the&nbsp;<strong>last date to pay the fees will be &nbsp;Thursday 17th&nbsp; October 2015&nbsp;</strong> after which it will be presumed that you are not interested in getting your child admitted to TODDEN-AIS</span></p>");
        //oBuilder.Append("<p style='font-family: arial,sans-serif; font-size: 13px;'><span style='font-size: 12pt; font-family: 'Times New Roman',serif;'>We regret that request for extension will not be entertained.</span></p>");
        //oBuilder.Append("<p style='font-family: arial,sans-serif; font-size: 13px;'><span style='font-size: 12pt; font-family: 'Times New Roman',serif;'>The fees are to be paid in the&nbsp;<strong>school office</strong>&nbsp;between 8:30 am&nbsp;&nbsp;and 1:00 p.m.</span></p>");
        //oBuilder.Append("<p style='font-family: arial,sans-serif; font-size: 13px;'>&nbsp;</p>");
        //oBuilder.Append("<p style='font-family: arial,sans-serif; font-size: 13px;'><span style='font-size: 12pt; font-family: 'Times New Roman',serif;'>&nbsp;Thanking you<br /><br /></span></p>");
        //oBuilder.Append("<p style='font-family: arial,sans-serif; font-size: 13px; margin-bottom: 0.0001pt;'><em><span style='font-size: 12pt; font-family: 'Times New Roman',serif;'>Mrs Shivangi Panchal</span></em><br /><span style='font-size: 12pt; font-family: 'Times New Roman',serif;'>Executive Director<br />Administration</span></p>");
        //oBuilder.Append("</div>");

        return Convert.ToString(oBuilder);
    }
    private string GetMailSubject()
    {
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(Path.Combine(Server.MapPath("~/Admission"), "AdmissionApprovalMail.xml"));
        XmlNode oNode = xmlDoc.DocumentElement;
        return oNode.SelectSingleNode("subject").InnerText;
    }
}