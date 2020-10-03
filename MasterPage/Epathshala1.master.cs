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
using System.Web.Configuration;

public partial class Epathshala : System.Web.UI.MasterPage
{
    #region Variables

    Student_DashBoard_BLogic SBlogic;

    #endregion

    #region Page Load

    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        if (!IsPostBack)
        {
            DataSet dsSettings = new DataSet();
            Teacher_Dashboard_BLogic obj_BAL_Teacher_Dashboard = new Teacher_Dashboard_BLogic();
            dsSettings = obj_BAL_Teacher_Dashboard.BAL_Select_CoveredUncoverChapterTopic_Settings("ShowICICILogo");
            bool IsVisible = Convert.ToBoolean(dsSettings.Tables[0].Rows[0]["value"].ToString());
            if (IsVisible)
            {
                dvICICI.Visible = true;
                dvICICIEpath.Style.Add("margin-top", "0px");
            }
            else
            {
                dvICICI.Visible = false;
                dvICICIEpath.Style.Add("margin-top", "35px");
            }

            if (AppSessions.IsAISProject)
            {
                dvAIS.Visible = true;
                header.Style.Add("background-color", "#dddddd");
                header.Style.Add("height", "160px");
                header.Style.Add("margin-bottom", "-5px");
            }
            else
            {
                dvAIS.Visible = false;

            }

            try
            {
                checkforsession();
                DataAccess da = new DataAccess();
                ArrayList tmplst = new ArrayList();
                tmplst.Add(new parameter("FieldName", "IsOnline"));
                DataSet dsgetSetting = da.DAL_Select("PROC_GetConfig", tmplst);
                if (dsgetSetting != null && dsgetSetting.Tables.Count > 0)
                {
                    DataTable dt = dsgetSetting.Tables[0];


                    //Start Timer for Automatic exam Start
                    if (AppSessions.StudentID != null && AppSessions.StudentID != 0)
                    {
                        if (dt.Rows[0]["value"].Equals("false"))
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
                    }
                    else
                    {
                        Timer1.Enabled = false;
                    }
                    //End Start Timer for Automatic exam Start


                }



                if (AllowMultiLangual())
                {
                    ddlLanguage12.Visible = true;
                }
                else
                {
                    ddlLanguage12.Visible = false;
                }
                ddlLanguage12.SelectedValue = Session["LANG"].ToString();

                //checkforsession();
                if (Session["UserName"] != null || Session["UserName"] != "")
                {
                    //    //lblWelcome.Text = 
                    lblWelcome.Text = Session["UserName"].ToString();

                    if (AppSessions.AppUserType != "Student")
                    {
                        //        //lblschool.Visible = true;
                        //        //lblSchoolName.Text = lblSchoolName.Text + " " + Session["SchoolName"].ToString();
                        //        //lblUserType.Visible = true;
                        //        //lblUserType.Text = lblUserType.Text + " " + AppSessions.Role;
                    }
                }
                //if (Request.QueryString["MenuVisible"] == "False")
                //{
                //    Menu1.Visible = false;
                //    ddlLanguage12.Visible = false;
                //    lbtnSignOut.Visible = false;
                //    lblWelcome.Visible = false;
                //}
                //else
                //{
                //    Menu1.Visible = true;
                //    ddlLanguage12.Visible = true;
                //    lbtnSignOut.Visible = true;
                //    lblWelcome.Visible = true;
                //}
                if (AppSessions.RoleID != null)
                {
                    switch (AppSessions.RoleID)
                    {
                        case (int)EnumFile.Role.E_Admin:
                            Mv_RolewiseMenus.ActiveViewIndex = 0;
                            break;
                        case (int)EnumFile.Role.S_Admin:
                            Mv_RolewiseMenus.ActiveViewIndex = 1;
                            break;
                        case (int)EnumFile.Role.Teacher:
                            Mv_RolewiseMenus.ActiveViewIndex = 2;
                            break;
                        case (int)EnumFile.Role.Student:
                            Mv_RolewiseMenus.ActiveViewIndex = 3;
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                //Response.Redirect("../OtherPages/Login.aspx");
                //Response.Redirect("../OtherPages/Landing.aspx");
                //Response.Redirect("../NewPublic/epathhome.aspx");
                Response.Redirect("../NewPublic/userLogin.aspx");

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

    #endregion

    #region Control Event

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

        Session["StudentID"] = null;
        Session["EmpolyeeID"] = null;
        //Response.Redirect("../OtherPages/Login.aspx");
        //Response.Redirect("../OtherPages/Landing.aspx");
        //Response.Redirect("../NewPublic/epathhome.aspx");
        Response.Redirect("../NewPublic/userLogin.aspx");
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

                if (Session["TrackLogID"] == null)
                {
                    Session["TrackLogID"] = "";
                }

                if (Session["TrackLogID"].ToString() != dsCheckLog.Tables[0].Rows[0]["TrackLogID"].ToString())
                {
                    allowToRedirect = true;
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
                        Response.Redirect("../Student/StudentAssessmentAutomaticMas.aspx?Level=0&TestType=Posttest&BMSSCTID=" + dsCheckLog.Tables[0].Rows[0]["BMSSCTID"].ToString() + "&GroupBMSSCT=" + TrackLog_Utils.GetLogedGroupBMSSCTID(Convert.ToString(Session["TrackLogID"])));
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
                        Response.Redirect("../Student/StudentAssessmentAutomaticMas.aspx?Level=0&TestType=Pretest&BMSSCTID=" + dsCheckLog.Tables[0].Rows[0]["BMSSCTID"].ToString() + "&GroupBMSSCT=" + TrackLog_Utils.GetLogedGroupBMSSCTID(Convert.ToString(Session["TrackLogID"])));
                    }

                }
            }
        }
        //End For Redirect to Automatic Exam by Teacher
    }
    protected void btncpsubmit_Click(object sender, EventArgs e)
    {
        if (AppSessions.RoleID == 4)//student
        {
            DataSet dtLogin = new DataSet();
            DataTable LoginInfo = new DataTable();
            DataTable UserInfo = new DataTable();

            SYS_Role obj_SYS_Role = new SYS_Role();
            SYS_Role_BLogic obj_BAL_SYS_Role = new SYS_Role_BLogic();
            obj_SYS_Role.Username = AppSessions.LoginID;
            obj_SYS_Role.Password = txtop.Text;

            dtLogin = obj_BAL_SYS_Role.BAL_SYS_Student_Login(obj_SYS_Role);
            LoginInfo = dtLogin.Tables[0];

            if (LoginInfo.Rows.Count > 0 && LoginInfo != null)
            {
                Employee_BLogic BEmployee = new Employee_BLogic();
                Employee PEmployee = new Employee();
                PEmployee.roleid = AppSessions.RoleID;
                PEmployee.userid = "";
                PEmployee.Studentlist = Convert.ToString(AppSessions.StudentID);
                PEmployee.password = txtnp.Text;
                PEmployee.modifiedby = AppSessions.EmpolyeeID;
                BEmployee.BAL_Employee_Password_Update(PEmployee);
                //Response.Redirect("~/otherpages/Landing.aspx?frm=cp");
                Response.Redirect("../NewPublic/login.aspx?frm=cp");

            }
            else
            {
                WebMsg.Show("Please enter valid old password.");
            }
        }
        else if (AppSessions.RoleID == 3 || AppSessions.RoleID == 2 || AppSessions.RoleID == 1) //3-teacher,2-sadmin,1-epath-admin
        {
            Employee_BLogic BEmployee = new Employee_BLogic();
            Employee PEmployee = new Employee();
            PEmployee.roleid = AppSessions.RoleID;
            PEmployee.userid = Convert.ToString(AppSessions.EmpolyeeID);
            PEmployee.Studentlist = "";
            PEmployee.password = txtnp.Text;
            PEmployee.modifiedby = AppSessions.EmpolyeeID;
            BEmployee.BAL_Employee_Password_Update(PEmployee);
        }

    }

    #endregion

    #region User Define Function

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
    private void checkforsession()
    {
        Hashtable sessions = (Hashtable)Application["WEB_SESSIONS_OBJECT"];
        Boolean adminstatus = false;
        Boolean studentstatus = false;

        if (Session["StudentID"] != null)
        {
            studentstatus = true;
            if (!sessions.Contains(Session["StudentID"].ToString()))
                //Response.Redirect("../OtherPages/Login.aspx");
                //Response.Redirect("../OtherPages/Landing.aspx");
                //Response.Redirect("../NewPublic/epathhome.aspx");
                Response.Redirect("../NewPublic/userLogin.aspx");
        }
        else if (Session["EmpolyeeID"] != null)
        {
            if (!sessions.Contains(Session["EmpolyeeID"].ToString()))
                Response.Redirect("~/Index.aspx");
        }
        else
            studentstatus = false;

        if (Session["EmpolyeeID"] != null)
            adminstatus = true;
        else
            adminstatus = false;

        if (adminstatus == true || studentstatus == true) { }
        else
            Response.Redirect("~/Index.aspx");
    }

    #endregion
    protected void lnkup_Click(object sender, EventArgs e)
    {
        string EmployeeID = Convert.ToString(AppSessions.EmpolyeeID);
        string StudentID = Convert.ToString(AppSessions.StudentID);
        string SchoolID = Convert.ToString(AppSessions.SchoolID);
        if (AppSessions.RoleID == 4) //student
        {
            if (!string.IsNullOrEmpty(StudentID))
                Response.Redirect("~/UserManagement/UpdateProfileStudent.aspx");
        }
        else if (AppSessions.RoleID == 3 || AppSessions.RoleID == 2 || AppSessions.RoleID == 1) //3-teacher,2-sadmin,1-epath-admin
        {
            if (!string.IsNullOrEmpty(EmployeeID))
                Response.Redirect("~/UserManagement/UpdateProfile.aspx?Employeeid=" + EmployeeID + "&schoolid=" + SchoolID + "");
        }
    }
}
