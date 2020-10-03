using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
using System.IO;
using System.Text;

public partial class Teacher_SendTestResultMail : System.Web.UI.Page
{
    #region variable
    #endregion

    #region Properties
    #endregion

    #region Page events

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            txtsubject.Text = "Test Result Alert";
            txtmail.Content = DefaultEmailBody(); ;
            DataSet dsExamAuto = null;

            Hashtable Question = (Hashtable)Application["Exam_TeacherSheResult"];
            if (Question == null)
            {
                Question = new Hashtable();
            }
            else
            {
                dsExamAuto = (DataSet)Question[Session["TrackLogID"].ToString()];
            }

            if (dsExamAuto != null)
            {
                if (dsExamAuto.Tables.Count > 0)
                {
                    if (dsExamAuto.Tables.Count > 2)
                    {
                        gvstudentresult.DataSource = dsExamAuto.Tables[1];
                        gvstudentresult.DataBind();
                    }
                }
            }
        }
    }

    #endregion

    #region Control Event

    protected void gvstudentresult_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label oLable = (Label)e.Row.FindControl("GV_LblEmail");
            if (string.IsNullOrEmpty(oLable.Text))
                e.Row.Enabled = false;
        }
    }
    protected void btnsendmail_Click(object sender, EventArgs e)
    {
        gvresult.Visible = true;

        DataTable dt = new DataTable();
        dt.Columns.Add("Name", typeof(string));
        dt.Columns.Add("EmailID", typeof(string));
        dt.Columns.Add("Status", typeof(string));

        foreach (GridViewRow row in gvstudentresult.Rows)
        {
            CheckBox chk = (CheckBox)row.FindControl("chkSelect");
            if (chk.Checked)
            {
                HiddenField hdn = (HiddenField)row.FindControl("hdnEmailID");
                Label lblstudentName = (Label)row.FindControl("GV_LblStudentName");
                Label lblRA = (Label)row.FindControl("GV_LblRA");
                Label lblWA = (Label)row.FindControl("GV_LblWA");
                TextBox lblComment = (TextBox)row.FindControl("GV_LblComment");

                string MailBody = bindEmailBody(txtmail.Content, lblstudentName.Text, Convert.ToString(Convert.ToInt32(lblWA.Text) + Convert.ToInt32(lblRA.Text)), lblRA.Text, lblComment.Text);

                string Response = SendMail(hdn.Value, txtsubject.Text, MailBody);

                dt.Rows.Add(lblstudentName.Text, hdn.Value, Response);
            }
        }
        gvresult.DataSource = dt;
        gvresult.DataBind();

        System.Threading.Thread.Sleep(1000);
        mdlresult.Show();
    }
    protected void btnclose_Click(object sender, EventArgs e)
    {
        if (AppSessions.Role == "Teacher")
            Response.Redirect("../Dashboard/TeacherDashboard.aspx");
    }

    #endregion

    #region User defined functions

    private string SendMail(string emailid, string mailsubject, string mailcontent)
    {
        string Response = string.Empty;
        if (!string.IsNullOrEmpty(emailid))
        {
            ArrayList alistEmailAddress = new ArrayList();
            alistEmailAddress.Add(emailid);
            if (alistEmailAddress.Count > 0)
            {
                bool IsSendSuccess = EmailUtility.SendEmail(alistEmailAddress, mailsubject, mailcontent);
                if (IsSendSuccess)
                    Response = "Send email successfully.";
                else
                    Response = "Send email failed.";
            }
        }
        else
        {
            Response = "Send email failed.[Email address is empty]";
        }
        return Response;
    }
    protected string bindEmailBody(string MailBody, string StudentName, string TotalMarks, string ObtainMarks, string Comment)
    {
        StringBuilder oBuilder = new StringBuilder();
        try
        {
            oBuilder.Append(MailBody);
            oBuilder.Replace("#StudentName#", StudentName);
            oBuilder.Replace("#ObtainMarks#", ObtainMarks);
            oBuilder.Replace("#TotalMarks#", TotalMarks);
            oBuilder.Replace("#Comment#", Comment);
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
        return oBuilder.ToString();
    }
    protected string DefaultEmailBody()
    {
        StringBuilder oBuilder = new StringBuilder();
        try
        {
            oBuilder.Append("<!DOCTYPE html><html><head><title>Finish Activity</title></head><body>");
            oBuilder.Append("<div style='border: 0px Solid #F0F0F0; background-color: #f9f9f9;margin: 10px; font-family: Cambria,Calibri,Times New Roman; font-size: medium;  box-shadow: 0px 0px 4px #909090;border-top: 8px Solid #522675;border-bottom: 4px Solid #522675;'>");
            oBuilder.Append("<div style='background-color:#F0F0F0  ;height:70px;'><div class='logo' style='text-align: center;color:#80262e;padding:20px;'>");
            oBuilder.Append("<h3 style='margin:0;'>#SCHOOLNAME#</h3>");
            oBuilder.Append("</div></div>");
            oBuilder.Append("<div style='border-bottom: 3px Solid #E8E8E8; padding: 20px; border-top: 2px Solid #522675;color: #909090;'>");
            oBuilder.Append("<p>Dear Parent,<br /><br />Today your ward #StudentName# has attended test of subject \"#SUBJECT#\" in class \"#STANDARD#\" at #TIME#.<br /><br />");
            oBuilder.Append("Result: #ObtainMarks# out of #TotalMarks#<br /><br />");
            oBuilder.Append("Comment: #Comment#<br /><br /><br /><br />");
            oBuilder.Append("Best Regards,<br />#USERNAME#.</p>");
            oBuilder.Append("</div></div>");
            oBuilder.Append("</body></html>");

            oBuilder.Replace("#SCHOOLNAME#", AppSessions.SchoolName);
            //oBuilder.Replace("#CHAPTER#", Convert.ToString(Session["Chapter"]));
            oBuilder.Replace("#SUBJECT#", AppSessions.Subject);

            string[] standard = AppSessions.Board.Split(new string[] { ">>" }, StringSplitOptions.RemoveEmptyEntries);

            oBuilder.Replace("#STANDARD#", standard[2].Trim() + " - " + AppSessions.Division);
            oBuilder.Replace("#TIME#", DateTime.Now.ToString("hh:mm tt"));
            oBuilder.Replace("#USERNAME#", AppSessions.UserName);
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
        return oBuilder.ToString();
    }

    #endregion
}