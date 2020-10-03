using System;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Globalization;
using Udev.UserMasterPage.Classes;
using System.Text;
using System.Web;
using System.Collections.Generic;
using System.Net;

public partial class Teacher_TeacherDashboard : System.Web.UI.Page
{
    #region Variables
    Teacher_Dashboard_BLogic obj_BAL_Teacher_Dashboard;
    Teacher_Dashboard obj_Teacher_Dashboard;
    Announcement_BLogic BAL_Announcement = new Announcement_BLogic();
    public string path = string.Empty;
    double Total = 0;
    double RowCount = 0;
    double Percentage = 0;
    #endregion

    #region Culture

    protected override void FrameworkInitialize()
    {
        if (Session["Language"] != null)
        {
            String selectedLanguage = Session["Language"].ToString();
            System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(selectedLanguage);
            System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo(selectedLanguage);

            base.FrameworkInitialize();
        }
    }

    protected override void InitializeCulture()
    {
        if (Session["Language"] != null)
        {
            String selectedLanguage = Session["Language"].ToString();
            this.UICulture = selectedLanguage;
            this.Culture = selectedLanguage;

            Session[Global.SESSION_KEY_CULTURE] = selectedLanguage;
            Session["LANG"] = selectedLanguage;
            System.Threading.Thread.CurrentThread.CurrentCulture =
            CultureInfo.CreateSpecificCulture(selectedLanguage);
            System.Threading.Thread.CurrentThread.CurrentUICulture = new
            CultureInfo(selectedLanguage);
        }
        else
        {
            string culture = Convert.ToString(Session[Global.SESSION_KEY_CULTURE]);
            // 'set culture to current thread 
            System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture);
            System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);
            //call base class 
            base.InitializeCulture();
        }
    }
    #endregion

    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        //this.TeacherPanel1.TeacherPanelDDLEvent += new EventHandler(ddlBoardUserControl_SelectedIndexChanged);
        this.TeacherPanel1.TeacherPanelEvent += new EventHandler(Demo1_ButtonClickDemo);

        if (!IsPostBack)
        {
            IsClassTeacher();
            FillChapters_Topic();
            fill_Covered_Chapters_Topics();
            fill_Covered_Syllabus();
            Fill_Chart_Data();
            Fill_Rescheduling_Chapter_Topic();
            FillTeacherAnnouncement();

            if (AppSessions.IsAISProject)
            {
                //libtnAttendance.Visible = false;
                lilbtnEveningPrayer.Visible = false;
                lilbtnMorningPrayer.Visible = false;
                liLastActivityBookMark.Visible = false;
                liAnnouncementBookMark.Visible = false;
                dvRescheduing.Visible = false;
                dvreschedulemain.Visible = false;
                dvteachercontent.Visible = true;
                dvteachercontentmain.Visible = true;
                GetUploadedFiles();
                try
                {
                    string path = string.Empty;
                    string[] standard = AppSessions.Board.Split(new string[] { ">>" }, StringSplitOptions.RemoveEmptyEntries);
                    path = Server.MapPath("../EduResource/oxford/" + standard[2].Trim() + "/" + AppSessions.Subject);

                    if (Directory.Exists(path))
                        btnOxford.Visible = true;
                    else
                        btnOxford.Visible = false;
                }
                catch
                {
                    btnOxford.Visible = false;
                }
            }

            else
            {
                //libtnAttendance.Visible = true;
                lilbtnEveningPrayer.Visible = true;
                lilbtnMorningPrayer.Visible = true;
                liLastActivityBookMark.Visible = true;
                liAnnouncementBookMark.Visible = true;
                dvRescheduing.Visible = true;
                dvreschedulemain.Visible = true;
                dvteachercontentmain.Visible = false;
                dvteachercontent.Visible = false;
                btnOxford.Visible = false;
            }

        }
    }


    #endregion

    #region Control Event

    #region DropDown Events
    protected void ddlChapter_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlChapter.SelectedIndex > 0)
        {
            DataTable dt = (DataTable)ViewState["TopicTable"];
            if (dt.Rows.Count > Convert.ToInt32(EnumFile.AssignValue.Zero))
            {

                DataTable dtResult = dt.Clone();

                DataRow[] dr = dt.Select("ChapterID = " + Convert.ToInt32(ddlChapter.SelectedValue));

                //dt.AcceptChanges();
                foreach (DataRow drLoop in dr)
                {
                    //DataRow drRow = dtResult.NewRow();
                    //drRow =  dr1;
                    //dtResult.Rows.Add(drRow);
                    dtResult.ImportRow(drLoop);
                }

                ddlTopic.DataSource = dtResult;
                ddlTopic.DataTextField = "Topic";
                ddlTopic.DataValueField = "TopicID";
                ddlTopic.DataBind();
                ddlTopic.Items.Insert(Convert.ToInt32(EnumFile.AssignValue.Zero), new ListItem("-- Select --"));
                ddlTopic.SelectedIndex = Convert.ToInt32(EnumFile.AssignValue.Zero);

                DropDownList[] disddl = { ddlTopic };
                EnableDropDwon(disddl);
            }
        }
        else
        {
            DropDownList[] disddl = { ddlTopic };
            DisableDropDwon(disddl);
        }
    }
    #endregion

    #region Button Events

    protected void lnkViewAll_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Teacher/ViewAllTeacherAnnouncement.aspx");
    }

    protected void Demo1_ButtonClickDemo(object sender, EventArgs e)
    {
        IsClassTeacher();
        FillChapters_Topic();
        fill_Covered_Chapters_Topics();
        fill_Covered_Syllabus();
        Fill_Chart_Data();
        Fill_Rescheduling_Chapter_Topic();
        FillTeacherAnnouncement();

        if (AppSessions.IsAISProject)
        {
            string path = string.Empty;
            string[] standard = AppSessions.Board.Split(new string[] { ">>" }, StringSplitOptions.RemoveEmptyEntries);
            path = Server.MapPath("../EduResource/oxford/" + standard[2].Trim() + "/" + AppSessions.Subject);

            if (Directory.Exists(path))
                btnOxford.Visible = true;
            else
                btnOxford.Visible = false;
        }
    }

    protected void ddlBoardUserControl_SelectedIndexChanged(object sender, EventArgs e)
    {
        //base.FrameworkInitialize();
        //Server.Transfer(Request.Url.PathAndQuery, false);
    }


    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        obj_BAL_Teacher_Dashboard = new Teacher_Dashboard_BLogic();
        obj_Teacher_Dashboard = new Teacher_Dashboard();

        obj_Teacher_Dashboard.BMSID = Convert.ToInt64(Session["BMSID"]);
        obj_Teacher_Dashboard.SubjectID = Convert.ToInt16(Session["SubjectID"]);

        obj_Teacher_Dashboard.ChapterID = Convert.ToInt64(ddlChapter.SelectedValue);
        obj_Teacher_Dashboard.TopicID = Convert.ToInt64(ddlTopic.SelectedValue);

        int bmssctid = obj_BAL_Teacher_Dashboard.BAL_Select_BMS_SCTID(obj_Teacher_Dashboard);

        //TrackLog_Utils.Log(Convert.ToInt32(AppSessions.SchoolID), Convert.ToInt32(AppSessions.EmpolyeeID), Convert.ToInt16(AppSessions.DivisionID), "TeacherDashboard", "btnSubmit", "Click", Convert.ToDateTime(System.DateTime.Now), Session.SessionID, "click on submit button", "Submit Successfully.", bmssctid);
        TrackLog_Utils.Log(Convert.ToInt32(AppSessions.SchoolID), Convert.ToInt32(AppSessions.EmpolyeeID), Convert.ToInt16(AppSessions.DivisionID), "TeacherDeshboard", "btnSubmit", "Click", Convert.ToDateTime(System.DateTime.Now), HttpContext.Current.Session.SessionID, StringEnum.stringValueOf(EnumFile.Activity.ActivityStarted), "BMSSCT ID : " + bmssctid, bmssctid);

        if (bmssctid > (int)EnumFile.AssignValue.Zero)
        {
            Session["ChapterTopic"] = ddlChapter.SelectedItem.ToString() + " >> " + ddlTopic.SelectedItem.ToString();
            Session["Chapter"] = ddlChapter.SelectedItem.ToString();
            Session["BMSSCTID"] = bmssctid;
            String Path1 = Server.MapPath("../EduResource/" + bmssctid);

            this.Title = "Epathshala - " + bmssctid;
            if (Directory.Exists(Path1) == false)
            {
                Path1 = Server.MapPath("../EduResource/NoContent");
            }

            if (Directory.Exists(Path1))
            {

                Response.Redirect("EducationalResource.aspx?Type=Teacher", false);

            }

            else
            {
                WebMsg.Show(bmssctid.ToString() + ": No Educational resource available.");
            }
        }
        else
        {
            WebMsg.Show(bmssctid.ToString() + ": No Educational resource available.");
        }

    }

    protected void btnReset_Click(object sender, EventArgs e)
    {

        TrackLog_Utils.Log(Convert.ToInt32(AppSessions.SchoolID), Convert.ToInt32(AppSessions.EmpolyeeID), Convert.ToInt16(AppSessions.DivisionID), "TeacherDashboard", "btnReset", "Click", Convert.ToDateTime(System.DateTime.Now), HttpContext.Current.Session.SessionID, StringEnum.stringValueOf(EnumFile.Activity.ResetActivity), "Reset Activity Successfully.", 0);

        ddlChapter.SelectedIndex = ((int)EnumFile.AssignValue.Zero);
        DropDownList[] disddl = { ddlTopic };
        DisableDropDwon(disddl);
    }

    protected void btnAttendance_Click(object sender, EventArgs e)
    {
        if (btnAttendance.Text == "Take Attendance")
        {
            Response.Redirect("~/Teacher/StudentAttendance.aspx");
            TrackLog_Utils.Log(Convert.ToInt32(AppSessions.SchoolID), Convert.ToInt32(AppSessions.EmpolyeeID), Convert.ToInt16(AppSessions.DivisionID), "TeacherDashboard", "btnAttendance", "Click", Convert.ToDateTime(System.DateTime.Now), HttpContext.Current.Session.SessionID, StringEnum.stringValueOf(EnumFile.Activity.TakeAttendance), "Take Attendance.", 0);

        }
        else if (btnAttendance.Text == "View Attendance")
        {
            Response.Redirect("~/Teacher/StudentAttendance.aspx");
            TrackLog_Utils.Log(Convert.ToInt32(AppSessions.SchoolID), Convert.ToInt32(AppSessions.EmpolyeeID), Convert.ToInt16(AppSessions.DivisionID), "TeacherDashboard", "btnAttendance", "Click", Convert.ToDateTime(System.DateTime.Now), HttpContext.Current.Session.SessionID, StringEnum.stringValueOf(EnumFile.Activity.ViewAttendance), "View Attendance.", 0);

        }
    }

    protected void lbtnMorningPrayer_Click(object sender, EventArgs e)
    {
        TrackLog_Utils.Log(Convert.ToInt32(AppSessions.SchoolID), Convert.ToInt32(AppSessions.EmpolyeeID), Convert.ToInt16(AppSessions.DivisionID), "TeacherDashboard", "lbtnMorningPrayer", "Click", Convert.ToDateTime(System.DateTime.Now), HttpContext.Current.Session.SessionID, StringEnum.stringValueOf(EnumFile.Activity.Morningprayer), "Start Morning Prayer.", 0);

        // audply.InnerHtml = "<embed src=\"../prayer/tumhi ho mata pita tumhi ho.mp3\" ></embed>";
        //Media_Player_Control1.Visible = true;
        //Media_Player_Control1.MovieURL = "../prayer/tumhi ho mata pita tumhi ho.mp3";    
        string testDay = DateTime.Now.DayOfWeek.ToString();
        path = "../prayer/morningprayer" + testDay.ToLower() + ".mp3";
        mp1.Show();

    }

    protected void lbtnEveningPrayer_Click(object sender, EventArgs e)
    {

        TrackLog_Utils.Log(Convert.ToInt32(AppSessions.SchoolID), Convert.ToInt32(AppSessions.EmpolyeeID), Convert.ToInt16(AppSessions.DivisionID), "TeacherDashboard", "lbtnEveningPrayer", "Click", Convert.ToDateTime(System.DateTime.Now), HttpContext.Current.Session.SessionID, StringEnum.stringValueOf(EnumFile.Activity.Eveningprayer), "Start Evening Prayer.", 0);

        //audply.InnerHtml = "<embed src=\"../prayer/ye kunde.mp3\" ></embed>";
        //Media_Player_Control1.Visible = true;
        //Media_Player_Control1.MovieURL = "../prayer/ye kunde.mp3";
        string testDay = DateTime.Now.DayOfWeek.ToString();
        path = "../prayer/eveningprayer" + testDay.ToLower() + ".mp3";
        mp1.Show();

    }

    protected void btnClose_Click(object sender, EventArgs e)
    {
        TrackLog_Utils.Log(Convert.ToInt32(AppSessions.SchoolID), Convert.ToInt32(AppSessions.EmpolyeeID), Convert.ToInt16(AppSessions.DivisionID), "TeacherDashboard", "btnClose", "Click", Convert.ToDateTime(System.DateTime.Now), HttpContext.Current.Session.SessionID, StringEnum.stringValueOf(EnumFile.Activity.Quitprayer), "Quit Morning/Evening Prayer.", 0);

        mp1.Hide();
    }

    #endregion

    #region Redio Button List Events
    protected void rblChapters_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rblChapters.SelectedValue == ((int)EnumFile.Chapter.UnCoveredChapters).ToString())
        {
            FillChapters_Topic();
        }
        else if (rblChapters.SelectedValue == ((int)EnumFile.Chapter.CoveredChapters).ToString())
        {
            fill_ALL_Covered_Chaptes_Topics();
        }
    }
    #endregion

    #region Gridview Events
    protected void gvRescheduing_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        LinkButton lb = (LinkButton)e.CommandSource;
        GridViewRow gvr = (GridViewRow)lb.NamingContainer;

        Int64 bmssctid = Convert.ToInt64(gvRescheduing.DataKeys[gvr.RowIndex].Values["BMSSCTID"].ToString());

        if (bmssctid > (int)EnumFile.AssignValue.Zero)
        {
            Session["ChapterTopic"] = gvRescheduing.DataKeys[gvr.RowIndex].Values["Chapter"].ToString() + " >> " + gvRescheduing.DataKeys[gvr.RowIndex].Values["Topic"].ToString();
            Session["BMSSCTID"] = bmssctid;
            Session["ReSchedulingID"] = Convert.ToInt64(gvRescheduing.DataKeys[gvr.RowIndex].Values["ReSchedulingID"].ToString());
            Session["FromRescheduling"] = true;
            String Path1 = Server.MapPath("../EduResource/" + bmssctid);
            if (Directory.Exists(Path1))
            {
                Response.Redirect("EducationalResource.aspx?Type=Teacher");
            }
            else
            {
                WebMsg.Show("No Educational resource available.");
            }
        }
        else
        {
            WebMsg.Show("No Educational resource available.");
        }
    }
    #endregion

    #endregion

    #region User Define Function

    protected string Limit(object Desc, int length)
    {
        StringBuilder strDesc = new StringBuilder();
        strDesc.Insert(0, Desc.ToString());

        if (strDesc.Length > length)
        {
            return strDesc.ToString().Substring(0, length) + "...";
        }
        else
        {
            return strDesc.ToString();
        }
    }

    protected void FillTeacherAnnouncement()
    {
        DataSet dsSelect = new DataSet();
        dsSelect = BAL_Announcement.BAL_SelectAnnouncementForTeacher(AppSessions.BMSID, AppSessions.EmpolyeeID, "SelectForTeacher");

        if (dsSelect.Tables[0].Rows.Count > 0)
        {
            tblDashBoardAnnouncement.Visible = true;
            dlAnnouncement.DataSource = dsSelect.Tables[0];
            dlAnnouncement.DataBind();
        }
        else
        {
            tblDashBoardAnnouncement.Visible = false;
        }

    }
    public void IsClassTeacher()
    {
        int IsclassTeacher = Convert.ToInt32(EnumFile.ClassTeacher.IsNotClassTeacher);
        obj_BAL_Teacher_Dashboard = new Teacher_Dashboard_BLogic();
        obj_Teacher_Dashboard = new Teacher_Dashboard();

        obj_Teacher_Dashboard.BMSID = Convert.ToInt64(Session["BMSID"]);
        obj_Teacher_Dashboard.EmployeeID = Convert.ToInt64(Session["EmpolyeeID"]);
        obj_Teacher_Dashboard.DivisionID = Convert.ToInt16(Session["DivisionID"]);
        obj_Teacher_Dashboard.SchoolID = Convert.ToInt64(Session["SchoolID"]);

        IsclassTeacher = obj_BAL_Teacher_Dashboard.BAL_IsCLassTeacher_Select(obj_Teacher_Dashboard);

        if (IsclassTeacher == Convert.ToInt32(EnumFile.ClassTeacher.IsClassTeacher))
        {
            btnAttendance.Text = "Take Attendance";
        }
        else
        {
            btnAttendance.Text = "View Attendance";
        }
    }

    public void FillChapters_Topic()
    {
        rblChapters.SelectedValue = "1";

        obj_BAL_Teacher_Dashboard = new Teacher_Dashboard_BLogic();
        obj_Teacher_Dashboard = new Teacher_Dashboard();

        obj_Teacher_Dashboard.BMSID = Convert.ToInt64(Session["BMSID"]);
        obj_Teacher_Dashboard.SubjectID = Convert.ToInt16(Session["SubjectID"]);
        obj_Teacher_Dashboard.DivisionID = Convert.ToInt16(Session["DivisionID"]);
        obj_Teacher_Dashboard.EmployeeID = Convert.ToInt64(Session["EmpolyeeID"]);
        obj_Teacher_Dashboard.SchoolID = Convert.ToInt64(Session["SchoolID"]);

        DataSet dsSelect = new DataSet();
        dsSelect = obj_BAL_Teacher_Dashboard.BAL_Select_Chapters_Topics(obj_Teacher_Dashboard);

        DataSet dsSettings = new DataSet();
        dsSettings = obj_BAL_Teacher_Dashboard.BAL_Select_CoveredUncoverChapterTopic_Settings("CoveredUncoverChapterTopicSetting");
        //IsAllow_Enable_Settings(dsSettings, ref dsSelect);

        object datatype = dsSettings.Tables[0].Rows[0]["Type"].ToString();
        object val = dsSettings.Tables[0].Rows[0]["value"].ToString();

        if (Convert.ToBoolean(Convert.ToInt16(val)))
        {
            rblChapters.Visible = true;
            ddlChapter.Enabled = true;
            ddlTopic.Enabled = true;

            //TO DO: Remove Row From Tale Which have not available content

            DataSet dsSettingsRemove = new DataSet();
            dsSettingsRemove = obj_BAL_Teacher_Dashboard.BAL_Select_CoveredUncoverChapterTopic_Settings("ShowChapterOnlyWithContent");

            List<DataRow> oDataRowList = new List<DataRow>();
            if (Convert.ToBoolean(dsSettingsRemove.Tables[0].Rows[0]["value"].ToString()))
            {
                foreach (DataRow dr in dsSelect.Tables[0].Rows)
                {
                    bool dirExists = false;
                    string[] arry = Convert.ToString(dr["BMS_SCTID"]).Split(new string[] { "#" }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < arry.Length; i++)
                    {
                        string Path1 = Server.MapPath("../EduResource/" + arry[i]);
                        if (Directory.Exists(Path1))
                        {
                            dirExists = true;
                            break;
                        }
                    }
                    if (!dirExists)
                        oDataRowList.Add(dr);
                }
                foreach (DataRow dr in oDataRowList)
                {
                    dsSelect.Tables[0].Rows.Remove(dr);
                }
            }
            //End
        }
        else
        {
            rblChapters.Visible = false;
            ddlChapter.Enabled = false;
            ddlTopic.Enabled = false;
        }
        if (dsSelect.Tables.Count == ((int)EnumFile.AssignValue.One))
        {
            if (dsSelect.Tables[0].Rows[0]["NoRecord"].ToString().Equals("0"))
            {
                WebMsg.Show("No Chapter available.");
                DropDownList[] disddl = { ddlChapter, ddlTopic };
                DisableDropDwon(disddl);
            }
        }
        else if (dsSelect.Tables.Count > ((int)EnumFile.AssignValue.Zero) && dsSelect.Tables[0].Rows.Count > ((int)EnumFile.AssignValue.Zero))
        {
            ddlChapter.DataSource = dsSelect.Tables[0];
            ddlChapter.DataTextField = "Chapter";
            ddlChapter.DataValueField = "ChapterID";
            ddlChapter.DataBind();
            ddlChapter.Items.Insert(Convert.ToInt32(EnumFile.AssignValue.Zero), new ListItem("-- Select --"));

            if (dsSelect.Tables[2].Rows.Count > ((int)EnumFile.AssignValue.Zero))
            {
                if (dsSelect.Tables[2].Rows[0]["ChapterID"].ToString().Equals(""))
                {
                    ddlChapter.SelectedIndex = ((int)EnumFile.AssignValue.Zero);
                }
                else
                {
                    try
                    {
                        ddlChapter.SelectedValue = dsSelect.Tables[2].Rows[0]["ChapterID"].ToString();
                    }
                    catch { }
                }
            }

            ViewState["TopicTable"] = (DataTable)dsSelect.Tables[1];

            if (ddlChapter.SelectedIndex > 0)
            {
                DataTable dt = (DataTable)ViewState["TopicTable"];
                if (dt.Rows.Count > Convert.ToInt32(EnumFile.AssignValue.Zero))
                {
                    DataTable dtResult = dt.Clone();
                    DataRow[] dr = dt.Select("ChapterID = " + Convert.ToInt32(ddlChapter.SelectedValue));

                    foreach (DataRow drLoop in dr)
                    {
                        dtResult.ImportRow(drLoop);
                    }

                    ddlTopic.DataSource = dtResult;
                    ddlTopic.DataTextField = "Topic";
                    ddlTopic.DataValueField = "TopicID";
                    ddlTopic.DataBind();
                    ddlTopic.Items.Insert(Convert.ToInt32(EnumFile.AssignValue.Zero), new ListItem("-- Select --"));
                    if (Convert.ToBoolean(Convert.ToInt16(val)))
                    {
                        DropDownList[] disddl = { ddlTopic };
                        EnableDropDwon(disddl);
                    }

                    ddlTopic.SelectedIndex = Convert.ToInt32(EnumFile.AssignValue.Zero);

                    if (dsSelect.Tables[3].Rows.Count > ((int)EnumFile.AssignValue.Zero))
                    {
                        if (dsSelect.Tables[3].Rows[0]["TopicID"].ToString().Equals(""))
                        {
                            ddlTopic.SelectedIndex = ((int)EnumFile.AssignValue.Zero);
                        }
                        else
                        {
                            ViewState["TopicID"] = dsSelect.Tables[3].Rows[0]["TopicID"].ToString();
                            ddlTopic.SelectedValue = dsSelect.Tables[3].Rows[0]["TopicID"].ToString();
                        }
                    }
                }
            }
            else
            {
                DropDownList[] disddl = { ddlTopic };
                DisableDropDwon(disddl);
            }
        }
        else
        {
            DropDownList[] disddl = { ddlChapter, ddlTopic };
            DisableDropDwon(disddl);
        }

    }

    public void fill_Covered_Chapters_Topics()
    {
        obj_BAL_Teacher_Dashboard = new Teacher_Dashboard_BLogic();
        obj_Teacher_Dashboard = new Teacher_Dashboard();

        obj_Teacher_Dashboard.BMSID = Convert.ToInt64(Session["BMSID"]);
        obj_Teacher_Dashboard.SubjectID = Convert.ToInt16(Session["SubjectID"]);
        obj_Teacher_Dashboard.DivisionID = Convert.ToInt16(Session["DivisionID"]);
        obj_Teacher_Dashboard.EmployeeID = Convert.ToInt64(Session["EmpolyeeID"]);
        obj_Teacher_Dashboard.SchoolID = Convert.ToInt64(Session["SchoolID"]);

        DataSet dsSelect = new DataSet();

        dsSelect = obj_BAL_Teacher_Dashboard.BAL_Select_Covered_Chapters_Topics(obj_Teacher_Dashboard);

        if (dsSelect.Tables.Count == ((int)EnumFile.AssignValue.One))
        {
            if (dsSelect.Tables[0].Rows[0]["NoRecord"].ToString().Equals("0"))
            {
                lblLastChapterName.Text = "-";
                lblLastTopicName.Text = "-";
            }
        }
        else if (dsSelect.Tables.Count > ((int)EnumFile.AssignValue.Zero))
        {
            if (dsSelect.Tables[0].Rows.Count > ((int)EnumFile.AssignValue.Zero))
            {
                lblLastChapterName.Text = dsSelect.Tables[0].Rows[0]["Chapter"].ToString();
            }
            else
            {
                lblLastChapterName.Text = "-";
            }
            if (dsSelect.Tables[1].Rows.Count > ((int)EnumFile.AssignValue.Zero))
            {
                lblLastTopicName.Text = dsSelect.Tables[1].Rows[0]["Topic"].ToString();
            }
            else
            {
                lblLastTopicName.Text = "-";
            }
        }
        else
        {
            lblLastChapterName.Text = "-";
            lblLastTopicName.Text = "-";
        }
    }

    public void fill_Covered_Syllabus()
    {
        tvSyllabus.Nodes.Clear();

        obj_BAL_Teacher_Dashboard = new Teacher_Dashboard_BLogic();
        obj_Teacher_Dashboard = new Teacher_Dashboard();

        obj_Teacher_Dashboard.BMSID = Convert.ToInt64(Session["BMSID"]);
        obj_Teacher_Dashboard.SubjectID = Convert.ToInt16(Session["SubjectID"]);
        obj_Teacher_Dashboard.DivisionID = Convert.ToInt16(Session["DivisionID"]);
        obj_Teacher_Dashboard.EmployeeID = Convert.ToInt64(Session["EmpolyeeID"]);
        obj_Teacher_Dashboard.SchoolID = Convert.ToInt64(Session["SchoolID"]);

        DataSet dsSelect = new DataSet();

        dsSelect = obj_BAL_Teacher_Dashboard.BAL_Select_Covered_Syllabus(obj_Teacher_Dashboard);

        if (dsSelect.Tables.Count > ((int)EnumFile.AssignValue.Zero))
        {

            DataTable dtChapter = new DataTable();
            DataTable dtTopic = new DataTable();

            dtChapter = dsSelect.Tables[0];
            dtTopic = dsSelect.Tables[1];

            if (dtChapter.Rows.Count > ((int)EnumFile.AssignValue.Zero) && dtTopic.Rows.Count > ((int)EnumFile.AssignValue.Zero))
            {
                foreach (DataRow c in dtChapter.Rows)
                {
                    TreeNode ParentNode = new TreeNode();
                    ParentNode.Text = c["Chapter"].ToString();
                    ParentNode.Value = c["ChapterID"].ToString();
                    tvSyllabus.Nodes.Add(ParentNode);
                    foreach (DataRow d in dtTopic.Select("ChapterID  = " + Convert.ToInt32(c["ChapterID"].ToString())))
                    {
                        TreeNode ChildNode = new TreeNode();
                        ChildNode.Text = d["Topic"].ToString();
                        ChildNode.Value = d["TopicID"].ToString();
                        ParentNode.ChildNodes.Add(ChildNode);
                    }
                }
            }
            else
            {
                tvSyllabus.Nodes.Clear();
            }

        }
        else
        {
            tvSyllabus.Nodes.Clear();
        }

    }

    public void fill_ALL_Covered_Chaptes_Topics()
    {
        rblChapters.SelectedValue = "2";

        obj_BAL_Teacher_Dashboard = new Teacher_Dashboard_BLogic();
        obj_Teacher_Dashboard = new Teacher_Dashboard();

        obj_Teacher_Dashboard.BMSID = Convert.ToInt64(Session["BMSID"]);
        obj_Teacher_Dashboard.SubjectID = Convert.ToInt16(Session["SubjectID"]);
        obj_Teacher_Dashboard.DivisionID = Convert.ToInt16(Session["DivisionID"]);
        obj_Teacher_Dashboard.EmployeeID = Convert.ToInt64(Session["EmpolyeeID"]);
        obj_Teacher_Dashboard.SchoolID = Convert.ToInt64(Session["SchoolID"]);

        DataSet dsSelect = new DataSet();

        dsSelect = obj_BAL_Teacher_Dashboard.BAL_Select_Covered_Syllabus(obj_Teacher_Dashboard);

        if (dsSelect.Tables.Count == ((int)EnumFile.AssignValue.One))
        {
            if (dsSelect.Tables[0].Rows[0]["NoRecord"].ToString().Equals("0"))
            {
                WebMsg.Show("No Chapter available.");

                DropDownList[] disddl = { ddlChapter, ddlTopic };
                DisableDropDwon(disddl);
            }
        }

        else if (dsSelect.Tables.Count > ((int)EnumFile.AssignValue.Zero) && dsSelect.Tables[0].Rows.Count > ((int)EnumFile.AssignValue.Zero))
        {

            ddlChapter.DataSource = dsSelect.Tables[0];
            ddlChapter.DataTextField = "Chapter";
            ddlChapter.DataValueField = "ChapterID";
            ddlChapter.DataBind();
            ddlChapter.Items.Insert(Convert.ToInt32(EnumFile.AssignValue.Zero), new ListItem("-- Select --"));

            DropDownList[] disddl = { ddlChapter, ddlTopic };
            EnableDropDwon(disddl);


            ViewState["TopicTable"] = (DataTable)dsSelect.Tables[1];

            ddlTopic.DataSource = dsSelect.Tables[1];
            ddlTopic.DataTextField = "Topic";
            ddlTopic.DataValueField = "TopicID";
            ddlTopic.DataBind();
            ddlTopic.Items.Insert(Convert.ToInt32(EnumFile.AssignValue.Zero), new ListItem("-- Select --"));
            ddlTopic.SelectedIndex = Convert.ToInt32(EnumFile.AssignValue.Zero);

        }
        else
        {
            DropDownList[] disddl = { ddlChapter, ddlTopic };
            DisableDropDwon(disddl);
        }

    }

    public void Fill_Chart_Data()
    {
        obj_BAL_Teacher_Dashboard = new Teacher_Dashboard_BLogic();
        obj_Teacher_Dashboard = new Teacher_Dashboard();

        obj_Teacher_Dashboard.BMSID = Convert.ToInt64(Session["BMSID"]);
        obj_Teacher_Dashboard.SubjectID = Convert.ToInt16(Session["SubjectID"]);
        obj_Teacher_Dashboard.DivisionID = Convert.ToInt16(Session["DivisionID"]);
        obj_Teacher_Dashboard.EmployeeID = Convert.ToInt64(Session["EmpolyeeID"]);
        obj_Teacher_Dashboard.SchoolID = Convert.ToInt64(Session["SchoolID"]);

        DataSet dsSelect = new DataSet();

        dsSelect = obj_BAL_Teacher_Dashboard.BAL_Select_Chart_Data(obj_Teacher_Dashboard);

        if (dsSelect.Tables[0].Rows.Count > ((int)EnumFile.AssignValue.Zero))
        {
            LblCoveredChapter.Visible = true;
            LblUncoveredChapter.Visible = true;

            Int32 CoveredChapters = Convert.ToInt32(dsSelect.Tables[0].Rows[0]["Covered"].ToString());
            Int32 UncoveredChapters = 100 - CoveredChapters;

            LblCoveredChapter.Width = CoveredChapters * 2;
            LblUncoveredChapter.Width = UncoveredChapters * 2;


            lblCovered.Text = Convert.ToString(CoveredChapters) + "%";
            lblUncovered.Text = Convert.ToString(UncoveredChapters) + "%";

            lblCovered1.Text = Convert.ToString(CoveredChapters) + "%";
            lblUncovered1.Text = Convert.ToString(UncoveredChapters) + "%";


        }
        else
        {
            LblCoveredChapter.Visible = false;
            LblUncoveredChapter.Visible = false;

            LblCoveredChapter.Text = "";
            LblUncoveredChapter.Text = "";

        }
    }

    public void Fill_Rescheduling_Chapter_Topic()
    {
        obj_BAL_Teacher_Dashboard = new Teacher_Dashboard_BLogic();
        obj_Teacher_Dashboard = new Teacher_Dashboard();

        obj_Teacher_Dashboard.BMSID = Convert.ToInt64(Session["BMSID"]);
        obj_Teacher_Dashboard.SubjectID = Convert.ToInt16(Session["SubjectID"]);
        obj_Teacher_Dashboard.DivisionID = Convert.ToInt16(Session["DivisionID"]);
        obj_Teacher_Dashboard.EmployeeID = Convert.ToInt64(Session["EmpolyeeID"]);
        obj_Teacher_Dashboard.SchoolID = Convert.ToInt64(Session["SchoolID"]);

        DataSet dsSelect = new DataSet();

        dsSelect = obj_BAL_Teacher_Dashboard.BAL_Select_Rescheduling_Data(obj_Teacher_Dashboard);

        if (dsSelect.Tables[0].Rows.Count > ((int)EnumFile.AssignValue.Zero))
        {
            gvRescheduing.DataSource = dsSelect;
            gvRescheduing.DataBind();
        }
        else
        {
            gvRescheduing.DataSource = null;
            gvRescheduing.DataBind();
        }
    }

    public void DisableDropDwon(DropDownList[] disddl)
    {
        foreach (DropDownList dl in disddl)
        {
            dl.Enabled = false;
            dl.SelectedIndex = ((int)EnumFile.AssignValue.Zero);
        }
    }

    public void EnableDropDwon(DropDownList[] disddl)
    {
        foreach (DropDownList dl in disddl)
        {
            dl.Enabled = true;
            dl.SelectedIndex = ((int)EnumFile.AssignValue.Zero);
        }
    }

    public void IsAllow_Enable_Settings(DataSet dsSettings, ref DataSet dsSelect)
    {
        object datatype = dsSettings.Tables[0].Rows[0]["Type"].ToString();
        object val = dsSettings.Tables[0].Rows[0]["value"].ToString();

        if (Convert.ToBoolean(Convert.ToInt16(val)))
        {
            rblChapters.Visible = true;
            ddlChapter.Enabled = true;
            ddlTopic.Enabled = true;

            //TO DO: Remove Row From Tale Which have not available content

            DataSet dsSettingsRemove = new DataSet();
            dsSettingsRemove = obj_BAL_Teacher_Dashboard.BAL_Select_CoveredUncoverChapterTopic_Settings("ShowChapterOnlyWithContent");

            List<DataRow> oDataRowList = new List<DataRow>();
            if (Convert.ToBoolean(dsSettingsRemove.Tables[0].Rows[0]["value"].ToString()))
            {
                foreach (DataRow dr in dsSelect.Tables[0].Rows)
                {
                    string Path1 = Server.MapPath("../EduResource/" + Convert.ToString(dr["ChapterID"]));
                    if (!Directory.Exists(Path1))
                        oDataRowList.Add(dr);
                    foreach (DataRow drtopic in dsSelect.Tables[0].Rows)
                    {
                    }

                }
                foreach (DataRow dr in oDataRowList)
                {
                    dsSelect.Tables[0].Rows.Remove(dr);
                }
            }
            //End
        }
        else
        {
            rblChapters.Visible = false;
            ddlChapter.Enabled = false;
            ddlTopic.Enabled = false;
        }

    }
    #endregion

    protected void tvSyllabus_SelectedNodeChanged(object sender, EventArgs e)
    {
        for (int i = 0; i < tvSyllabus.Nodes.Count; i++)
        {
            foreach (TreeNode node in tvSyllabus.Nodes[i].ChildNodes)
            {
                if (node.Selected)
                {
                    ViewState["TopicID1"] = node.Value;
                    ViewState["ChapterID"] = node.Parent.Value;
                    Session["TopicID1"] = node.Value;
                    Session["ChapterID"] = node.Parent.Value;
                    Session["Chapter"] = node.Parent.Text;
                    Session["Topic1"] = node.Text;
                    Response.Redirect("TeacherPreTestPostTestResult.aspx");

                }
                node.Selected = false;
            }
        }
    }

    protected void btnsearcksubmit_Click(object sender, EventArgs e)
    {
        Response.Redirect("SearchResult.aspx?key=" + txtkeyword.Text + "");
    }
    protected void btnOxford_Click(object sender, EventArgs e)
    {
        string path = string.Empty;
        string[] standard = AppSessions.Board.Split(new string[] { ">>" }, StringSplitOptions.RemoveEmptyEntries);
        path = Server.MapPath("../EduResource/oxford/" + standard[2].Trim() + "/" + AppSessions.Subject);

        if (Directory.Exists(path))
            Response.Redirect("EducationalResource.aspx?Type=Teacher&frm=oxford", false);
        else
            WebMsg.Show("No Educational resource available.");
    }

    protected void GetUploadedFiles()
    {
        try
        {
            string DestinationLocation = Convert.ToString(AppSessions.EmpolyeeID);
            string dirpath;
            dirpath = Path.Combine(Server.MapPath("..\\EduResource\\Teacher Content\\" + DestinationLocation));

            string[] filePaths = Directory.GetFiles(dirpath);
            List<ListItem> files = new List<ListItem>();
            foreach (string filePath in filePaths)
            {
                files.Add(new ListItem(Path.GetFileName(filePath), filePath));
            }
            GridView1.DataSource = files;
            GridView1.DataBind();
        }
        catch (Exception ex)
        {

        }
    }

    protected void ViewFile(object sender, EventArgs e)
    {
        string filePath = (sender as LinkButton).CommandArgument;
        //Response.ContentType = ContentType;
        //Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath) + ".pdf");
        //Response.WriteFile(filePath);
        //Response.End();


        //int id = int.Parse((sender as LinkButton).CommandArgument);
        //string embed = "<object data=\"{0}{1}\" type=\"application/pdf\" width=\"500px\" height=\"300px\">";
        //embed += "If you are unable to view file, you can download from <a href = \"{0}{1}&download=1\">here</a>";
        //embed += " or download <a target = \"_blank\" href = \"http://get.adobe.com/reader/\">Adobe PDF Reader</a> to view the file.";
        //embed += "</object>";
        //ltEmbed.Text = string.Format(embed, ResolveUrl("~/FileCS.ashx?Id="), id);


        myframe.Attributes["style"] = "";
        myframe.Attributes["src"] = filePath;

        string src1 = "../PDFViewer/web/viewer.html?lank=" + "../EduResource/Teacher Content/" + AppSessions.EmpolyeeID.ToString() + "/" + filePath.Substring(filePath.LastIndexOf("\\") + 1).ToString();
        myframe.Attributes["src"] = src1;
        //string filepath1 = "../DemoPages/OpenFLVDemo.aspx?FullPath=../EduResource/55/04 Video Presentation/small1.mp4&ext=.mp4";
        //string src = "../PDFViewer/web/viewer.html?lank=" + filePath;
        //string src = "../DemoPages/OpenFLVDemo.aspx?FullPath=../EduResource/Teacher Content/" + AppSessions.EmpolyeeID.ToString() + "/" +  filePath.Substring( filePath.LastIndexOf("\\")+1).ToString() + "&ext=.pdf";
        myframe.Attributes["src"] = src1;
        Session["myframesrc"] = src1;
        mppdfviewwer.Show();







    }


    protected void DeleteFile(object sender, EventArgs e)
    {
        string filePath = (sender as LinkButton).CommandArgument;
        File.Delete(filePath);
        Response.Redirect(Request.Url.AbsoluteUri);
    }



    protected void btnupload_click(object sender, EventArgs e)
    {
        try
        {
            if ((FileUpload1.PostedFile != null) && (FileUpload1.PostedFile.ContentLength > 0))
            {
                string fileExtension = System.IO.Path.GetExtension(FileUpload1.PostedFile.FileName).ToLower();
                string validfile = "false";
                string fn = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
                if (fileExtension == ".pdf")
                {

                    string DestinationLocation = Convert.ToString(AppSessions.EmpolyeeID);
                    string dirpath;
                    dirpath = Path.Combine(Server.MapPath("..\\EduResource\\Teacher Content\\" + DestinationLocation));
                    if (!Directory.Exists(dirpath))
                    {
                        Directory.CreateDirectory(dirpath);
                    }
                    string fileName = Path.Combine(dirpath, System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName));
                    FileUpload1.PostedFile.SaveAs(fileName);
                    validfile = "true";
                    GetUploadedFiles();
                    WebMsg.Show("File uploaded sucessfully");

                }
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
}