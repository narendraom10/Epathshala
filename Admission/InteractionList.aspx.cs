using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Collections;
using System.Xml;
using System.Text;
using System.IO;

public partial class Admission_InteractionList : System.Web.UI.Page
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
    private void BindGrid()
    {
        AdmissionProperties oAdmissionProperties = new AdmissionProperties();
        BAL_Admission oBAL_Admission = new BAL_Admission();

        oAdmissionProperties.AdmissionGrade = AdmissionGradeFilter.Value;

        DataSet ods = oBAL_Admission.Admission_Select_interactionlist(oAdmissionProperties);

        lvstudent.DataSource = ods;
        lvstudent.DataBind();

        if (ods.Tables[0].Rows.Count > 0)
            btnSendInteraction.Visible = true;
        else
            btnSendInteraction.Visible = false;
    }
    protected void btnSendInteraction_click(object sender, EventArgs e)
    {
        foreach (ListViewItem item in lvstudent.Items)
        {
            string InteractionDate = string.Empty;
            string InteractionTime = string.Empty;
            string AdmissionID = string.Empty;
            string MailFrom = string.Empty;
            string MailTo = string.Empty;
            string MailSubject = string.Empty;
            string MailBody = string.Empty;
            string FailiurReason = string.Empty;
            ArrayList ArrMailTo = new ArrayList();

            HtmlInputCheckBox interactioncheck = (HtmlInputCheckBox)item.FindControl("interactioncheck");
            if (interactioncheck.Checked)
            {
                TextBox interactiondate = (TextBox)item.FindControl("interactiondate");
                InteractionDate = interactiondate.Text;
                TextBox interactiontime = (TextBox)item.FindControl("interactiontime");
                InteractionTime = interactiontime.Text;
                Label communicationemail = (Label)item.FindControl("communicationemail");
                HiddenField hdnAdmissionID = (HiddenField)item.FindControl("hdnAdmissionID");

                AdmissionID = hdnAdmissionID.Value;
                MailFrom = EmailUtility.SMTPEmailAddress;
                MailTo = communicationemail.Text;
                MailSubject = GetMailSubject();
                MailBody = GetMailBody(InteractionDate, InteractionTime);

                if (!string.IsNullOrEmpty(InteractionDate) && !string.IsNullOrEmpty(InteractionTime) && !string.IsNullOrEmpty(MailTo) && !string.IsNullOrEmpty(AdmissionID))
                {
                    ArrMailTo.Add(MailTo);
                    bool IsSendSuccess = EmailUtility.SendEmail(ArrMailTo, MailSubject, MailBody, out FailiurReason);

                    BAL_Admission oBAL_Admission = new BAL_Admission();
                    AdmissionInteraction oAdmissionInteraction = new AdmissionInteraction();

                    oAdmissionInteraction.AdmissionId = AdmissionID;
                    oAdmissionInteraction.InteractionDate = InteractionDate;
                    oAdmissionInteraction.InteractionTime = InteractionTime;
                    oAdmissionInteraction.MailFrom = MailFrom;
                    oAdmissionInteraction.MailTo = MailTo;
                    oAdmissionInteraction.MailSubject = MailSubject;
                    oAdmissionInteraction.MailBody = MailBody;
                    oAdmissionInteraction.IsSendSuccess = IsSendSuccess;
                    oAdmissionInteraction.FailureReasons = GetValue(FailiurReason);
                    oAdmissionInteraction.CreatedBy = Convert.ToString(AppSessions.EmpolyeeID);

                    oBAL_Admission.AdmissionInteraction_Insert(oAdmissionInteraction);
                }
            }
        }
        BindGrid();

        mainpopup.Attributes["class"] = "overlayone";
        msg.InnerHtml = "Your operation has been successfully completed.";
    }
    protected void OnPagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
    {
        (lvstudent.FindControl("pglvstudent") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
        (lvstudent.FindControl("pglvstudentlabel") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
        this.BindGrid();
    }
    private string GetMailBody(string interactiondate, string interactiontime)
    {
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(Path.Combine(Server.MapPath("~/Admission"), "InteractionMail.xml"));
        XmlNode oNode = xmlDoc.DocumentElement;

        StringBuilder oBuilder = new StringBuilder(oNode.SelectSingleNode("Mailbody").InnerText);

        oBuilder.Replace("@@interactiondate@@", interactiondate);
        oBuilder.Replace("@@interactiontime@@", interactiontime);

        return Convert.ToString(oBuilder);
        //return "<p align='center' style='text-align: center;'><b><span style='font-size: 14pt; line-height: 115%;'>TODDEN – AIS</span></b></p> <p align='center' style='text-align: center;'><b><span style='font-size: 14pt; line-height: 115%;'>Interaction slip<br /> </span></b></p> <p align='center' style='text-align: center;'><b><span style='font-size: 14pt; line-height: 115%;'><br /> </span></b></p> <p>We are pleased to receive your application for admission.</p> <p>You are requested to come for an interaction session on " + interactiondate + " at " + interactiontime + " with your child.</p> <p><b>Reporting time: 30 mins before the scheduled time.</b><br /> </p> <p '='' style='text-indent: -0.25in;'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Please carry the following documents with you for verification</p> <p style='text-indent: -0.25in;'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;1.<span style='font: 7pt 'times new roman';'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span>Parents&nbsp; degree mark sheets</p> <p style='text-indent: -0.25in;'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 2.<span style='font: 7pt 'times new roman';'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span>Birth certificate of the child.</p>";
    }
    private string GetMailSubject()
    {
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(Path.Combine(Server.MapPath("~/Admission"), "InteractionMail.xml"));
        XmlNode oNode = xmlDoc.DocumentElement;
        return oNode.SelectSingleNode("subject").InnerText;
    }
    protected void hdnadmissiongradefilter_Click(object sender, EventArgs e)
    {
        BindGrid();
    }
    private string GetValue(string inputstring)
    {
        return (!string.IsNullOrEmpty(inputstring) ? inputstring.Trim() : null);
    }
}