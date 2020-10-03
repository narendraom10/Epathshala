using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;
using Udev.UserMasterPage.Classes;
using System.Collections;

public partial class Epathshala : System.Web.UI.MasterPage
{
    Student_DashBoard_BLogic SBlogic;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                //Start Timer for Automatic exam Start
                if (AppSessions.StudentID != null && AppSessions.StudentID != 0)
                {
                    string PathCurrn = Request.Path.ToString();
                    if (!PathCurrn.Contains("/Student/StudentAssessmentAutomaticMas.aspx"))
                    {
                        Session["ExamStarted"] = "";
                    }
                    if (Session["ExamStarted"] != null)
                    {
                        if (Session["ExamStarted"] != "Started")
                        {
                            Timer1.Enabled = true;
                            Timer1.Interval = 6000;
                        }
                        else
                        {
                            Timer1.Enabled = false;
                            Timer1.Interval = int.MaxValue;
                        }
                    }
                    else
                    {
                        Timer1.Enabled = true;
                        Timer1.Interval = 6000;
                    }
                }
                else
                {
                    Timer1.Enabled = false;
                }
                //End Start Timer for Automatic exam Start


                if (AllowMultiLangual())
                {
                    ddlLanguage12.Visible = true;
                }
                else
                {
                    ddlLanguage12.Visible = false;
                }
                ddlLanguage12.SelectedValue = Session["LANG"].ToString();
                if (Session["UserName"] != null || Session["UserName"] != "")
                {
                    //lblWelcome.Text =
                    lblWelcome.Text = "Welcome " + Session["UserName"].ToString();

                    if (AppSessions.AppUserType != "Student")
                    {
                        //lblschool.Visible = true;
                        //lblSchoolName.Text = lblSchoolName.Text + " " + Session["SchoolName"].ToString();
                        //lblUserType.Visible = true;
                        //lblUserType.Text = lblUserType.Text + " " + AppSessions.Role;
                    }
                }
                if (Request.QueryString["MenuVisible"] == "False")
                {
                    Menu1.Visible = false;
                    ddlLanguage12.Visible = false;
                    lbtnSignOut.Visible = false;
                    lblWelcome.Visible = false;
                }
                else
                {
                    Menu1.Visible = true;
                    ddlLanguage12.Visible = true;
                    lbtnSignOut.Visible = true;
                    lblWelcome.Visible = true;
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("~/Index.aspx");
                throw ex;
            }
        }
        else
        {
            if (AppSessions.RoleID == null && AppSessions.RoleID == 0)
            { }

            //ddlLanguage12.SelectedValue = Session["LANG"].ToString();
        }

    }

    protected bool AllowMultiLangual()
    {
        bool Flag = false;
        try
        {
            SBlogic = new Student_DashBoard_BLogic();
            DataSet dsMultiLangual = new DataSet();
            dsMultiLangual = SBlogic.BAL_Select_PaymentPagesInfo("MultiLangual");
            if (dsMultiLangual != null & dsMultiLangual.Tables.Count > 0)
            {
                if (dsMultiLangual.Tables[0].Rows.Count > 0)
                {
                    if (dsMultiLangual.Tables[0].Rows[0]["value"].ToString() == "0")
                    {
                        Flag = false;
                    }
                    else
                    {
                        Flag = true;
                    }
                }
            }

        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
        return Flag;
    }

    protected void lbtnSignOut_Click(object sender, EventArgs e)
    {
        Hashtable sessions = (Hashtable)Application["WEB_SESSIONS_OBJECT"];
        if (sessions == null)
        {
            sessions = new Hashtable();
        }

        if (Session["EmpolyeeID"] != null)
        {
            sessions.Remove(Session["EmpolyeeID"].ToString());
        }

        if (Session["StudentID"] != null)
        {
            sessions.Remove(Session["StudentID"].ToString());
        }

        Application.Lock();
        Application["WEB_SESSIONS_OBJECT"] = sessions;
        Application.UnLock();

        TrackLog_Utils.Log(Convert.ToInt32(AppSessions.SchoolID), Convert.ToInt32(AppSessions.EmpolyeeID), Convert.ToInt16(AppSessions.DivisionID), "LogoutPage", "btnLogout", "Click", Convert.ToDateTime(System.DateTime.Now), HttpContext.Current.Session.SessionID, StringEnum.stringValueOf(EnumFile.Activity.LogoutSuccess), "LoginId : " + Session["UserName"].ToString(), 0);

        HttpContext.Current.Session.Clear();
        HttpContext.Current.Session.Abandon();

        Response.Redirect("~/Index.aspx");
    }
    protected void ddlLanguage12_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlLanguage12.SelectedValue.ToString().Equals("en-US"))
            {
                Session["LANG"] = ddlLanguage12.SelectedValue;
                Session["langid"] = ((int)EnumFile.Language.English).ToString();
            }
            else if (ddlLanguage12.SelectedValue.ToString().Equals("gu-IN"))
            {
                Session["LANG"] = ddlLanguage12.SelectedValue;
                Session["langid"] = ((int)EnumFile.Language.Gujarati).ToString();
            }
            else if (ddlLanguage12.SelectedValue.ToString().Equals("hi-IN"))
            {
                Session["LANG"] = ddlLanguage12.SelectedValue;
                Session["langid"] = ((int)EnumFile.Language.Hindi).ToString();
            }
            Session[Global.SESSION_KEY_CULTURE] = ddlLanguage12.SelectedValue;
            Session["LANG"] = ddlLanguage12.SelectedValue;
            Session["Varnindra"] = ddlLanguage12.SelectedValue;

            System.Threading.Thread.CurrentThread.CurrentCulture =
               CultureInfo.CreateSpecificCulture(Session["LANG"].ToString());
            System.Threading.Thread.CurrentThread.CurrentUICulture = new
            CultureInfo(ddlLanguage12.SelectedValue);

            //Response.Redirect(Request.ServerVariables["SCRIPT_NAME"].ToString());
            Response.Redirect(Request.Url.AbsoluteUri);
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }
    protected void Timer1_Tick(object sender, EventArgs e)
    {
        //For Redirect to Automatic Exam by Teacher
        TrackLog_Utils obj = new TrackLog_Utils();
        DataSet dsCheckLog = new DataSet();
        dsCheckLog = obj.SELECTExamTrackLogOtherEmployee(AppSessions.BMSID, AppSessions.SchoolID, AppSessions.DivisionID, AppSessions.EmpolyeeID);
        if (dsCheckLog.Tables.Count > 0)
        {
            if (dsCheckLog.Tables[0].Rows.Count > 0)
            {
                bool allowToRedirect = false;
                if (Session["TrackLogID"] != null)
                {
                    if (Session["TrackLogID"].ToString() != dsCheckLog.Tables[0].Rows[0]["TrackLogID"].ToString())
                    {
                        allowToRedirect = true;
                    }
                }
                else
                {
                    Session["TrackLogID"] = "";
                    if (Session["TrackLogID"].ToString() != dsCheckLog.Tables[0].Rows[0]["TrackLogID"].ToString())
                    {
                        allowToRedirect = true;
                    }
                }
                if (allowToRedirect)
                {
                    bool ExamStar = false;
                    if (dsCheckLog.Tables[0].Rows[0]["Activity"].ToString() == "Posttest")
                    {
                        Timer1.Interval = int.MaxValue;
                        ExamStar = true;
                        Session["TrackLogID"] = dsCheckLog.Tables[0].Rows[0]["TrackLogID"].ToString();

                        if (ExamStar)
                        {
                            Session["ExamStarted"] = "Started";
                        }
                        Response.Redirect("../Student/StudentAssessmentAutomaticMas.aspx?Level=0&TestType=Posttest&BMSSCTID=" + dsCheckLog.Tables[0].Rows[0]["BMSSCTID"].ToString());
                    }
                    if (dsCheckLog.Tables[0].Rows[0]["Activity"].ToString() == "Pretest")
                    {
                        Timer1.Interval = int.MaxValue;
                        ExamStar = true;
                        Session["TrackLogID"] = dsCheckLog.Tables[0].Rows[0]["TrackLogID"].ToString();

                        if (ExamStar)
                        {
                            Session["ExamStarted"] = "Started";
                        }
                        Response.Redirect("../Student/StudentAssessmentAutomaticMas.aspx?Level=0&TestType=Pretest&BMSSCTID=" + dsCheckLog.Tables[0].Rows[0]["BMSSCTID"].ToString());
                    }

                }
            }
        }
        //End For Redirect to Automatic Exam by Teacher
    }
}
