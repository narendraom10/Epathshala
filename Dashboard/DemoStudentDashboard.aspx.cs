using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Udev.UserMasterPage.Classes;
using System.Globalization;
using System.Data;
using System.IO;
using System.Collections;
using System.Text;

public partial class Dashboard_DemoStudentDashboard : System.Web.UI.Page
{

    #region Variables
    Teacher_Dashboard_BLogic obj_BAL_Teacher_Dashboard;
    Teacher_Dashboard obj_Teacher_Dashboard;
    Announcement_BLogic BAL_Announcement = new Announcement_BLogic();

    Student_DashBoard_BLogic obj_BAL_Student_Dashboard;
    StudentDash obj_Student_Dashboard;
    public string path = string.Empty;
    double Total = 0;
    double RowCount = 0;
    double Percentage = 0;
    #endregion  

    #region Culture

    protected override void InitializeCulture()
    {
        string culture = Convert.ToString(Session[Global.SESSION_KEY_CULTURE]);
        // 'set culture to current thread 
        System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture);
        System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);
        //call base class 
        base.InitializeCulture();
    }
    #endregion  

    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string Name = Request.QueryString["Name"];
            string BMSID = Request.QueryString["BMSID"];
            Session["ShowPaymentPages"] = "No";
            //Session["DemoBMS"] = BMSID.ToString();
            Session["DemoBMS"] = BMSID.ToString();
            Session["StudentID"] = Name.ToString();
            BindSubjectList();

            //GetExpiryNotification();
            if (rbSubjectList.Items.Count > 0)
            {
                if (AppSessions.SubjectID != 0)
                {
                    rbSubjectList.SelectedValue = AppSessions.SubjectID.ToString();
                }
                else
                {
                    rbSubjectList.SelectedIndex = 0;
                    AppSessions.SubjectID = Convert.ToInt16(rbSubjectList.SelectedValue);
                }
                //FillChapters_Topic();
                //fill_Covered_Chapters_Topics();
                //fill_Covered_Syllabus();
                //Fill_Chart_Data();
            }
        }
    }
    #endregion


    #region Control Event

    #region DropDown Events
    protected void lnkViewAll_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Teacher/ViewAllTeacherAnnouncement.aspx");
    }
    protected void rbSubjectList_SelectedIndexChanged(object sender, EventArgs e)
    {
        // BindSubjectList();
        if (rbSubjectList.Items.Count > 0)
        {
            AppSessions.SubjectID = Convert.ToInt16(rbSubjectList.SelectedValue);
            FillChapters_Topic();
            fill_Covered_Chapters_Topics();
            fill_Covered_Syllabus();
            Fill_Chart_Data();
            //// Fill_Rescheduling_Chapter_Topic();
        }
    }
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

    protected void Demo1_ButtonClickDemo(object sender, EventArgs e)
    {
        //BindSubjectList();
        if (rbSubjectList.Items.Count > 0)
        {
            AppSessions.SubjectID = Convert.ToInt16(rbSubjectList.SelectedValue);
            FillChapters_Topic();
            fill_Covered_Chapters_Topics();
            fill_Covered_Syllabus();
            Fill_Chart_Data();
            ////Fill_Rescheduling_Chapter_Topic();
        }
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

        if (bmssctid > (int)EnumFile.AssignValue.Zero)
        {
            Session["ChapterTopic"] = ddlChapter.SelectedItem.ToString() + " >> " + ddlTopic.SelectedItem.ToString();
            Session["BMSSCTID"] = bmssctid;
            String Path1 = Server.MapPath("../EduResource/" + bmssctid);
            if (Directory.Exists(Path1))
            {
                Response.Redirect("EducationalResource.aspx?Type=Student");
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

    protected void btnReset_Click(object sender, EventArgs e)
    {
        ddlChapter.SelectedIndex = ((int)EnumFile.AssignValue.Zero);
        DropDownList[] disddl = { ddlTopic };
        DisableDropDwon(disddl);
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



    #endregion


    #region User Define Function

    protected void GetExpiryNotification()
    {
        try
        {
            if (Session["ShowPaymentPages"].ToString().ToLower() != "no")
            {


                obj_BAL_Student_Dashboard = new Student_DashBoard_BLogic();
                obj_Student_Dashboard = new StudentDash();

                //if (Session["UserPackage"] == "Single")
                //{
                obj_Student_Dashboard.StudentID = AppSessions.StudentID;
                // obj_Student_Dashboard.Mode = "Single";
                DataSet ds = new DataSet();
                ds = obj_BAL_Student_Dashboard.BAL_Student_ExpiryNotification1(obj_Student_Dashboard);
                if (ds.Tables[0].Rows.Count > 0 && ds != null)
                {
                    fsExpiryNotification.Visible = true;
                    gvSubjectExpiryNotification.Visible = true;
                    gvSubjectExpiryNotification.DataSource = ds.Tables[0];
                    gvSubjectExpiryNotification.DataBind();
                }
                else
                {
                    Response.Redirect("~/DashBoard/SelectPackage.aspx");

                }
                if (ds.Tables[1].Rows.Count > 0 && ds != null)
                {
                    gvExpiredPackageList.Visible = true;
                    gvExpiredPackageList.DataSource = ds.Tables[1];
                    gvExpiredPackageList.DataBind();
                }

            }
            //}

            //if (Session["UserPackage"] == "Combo")
            //{
            //    obj_Student_Dashboard.StudentID = AppSessions.StudentID;
            //    obj_Student_Dashboard.Mode = "Combo";
            //    DataSet ds = new DataSet();
            //    ds = obj_BAL_Student_Dashboard.BAL_Student_ExpiryNotification1(obj_Student_Dashboard);
            //    if (ds.Tables[0].Rows.Count > 0 && ds != null)
            //    {
            //        fsExpiryNotification.Visible = true;
            //        gvComboExpiryNotification.Visible = true;
            //        gvComboExpiryNotification.DataSource = ds.Tables[0];
            //        gvComboExpiryNotification.DataBind();
            //    }
            //}

        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }

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

    protected void GetStudentDetailBMS()
    {
        DataSet dsData = new DataSet();
        DataSet dsLogin = new DataSet();
        obj_BAL_Student_Dashboard = new Student_DashBoard_BLogic();
        obj_Student_Dashboard = new StudentDash();
        ArrayList Alist = new ArrayList();
        //int BMSID = 0;
        try
        {
            obj_Student_Dashboard.StudentID = AppSessions.StudentID;
            //dsData = obj_BAL_Student_Dashboard.BAL_Validate_Student(obj_Student_Dashboard);
            dsData = obj_BAL_Student_Dashboard.BAL_Student_PackageDetails(AppSessions.StudentID, AppSessions.BMSID);

            //dsData = obj_BAL_Student_Dashboard.BAL_Student_ExpiryNotification1(obj_Student_Dashboard);
            if (dsData != null && dsData.Tables.Count > 0)
            {
                if (dsData.Tables[0].Rows.Count > 0)
                {
                    string SubjectID = dsData.Tables[0].Rows[0]["SubjectID"].ToString();
                    if (SubjectID != string.Empty)
                    {


                        for (int i = 0; i < dsData.Tables[0].Rows.Count; i++)
                        {
                            Alist.Add(dsData.Tables[0].Rows[i]["PackageFD_ID"].ToString());
                        }
                        ViewState["ArrayList"] = Alist;
                        //Session["UserPackage"] = "Single";
                    }
                    //else
                    //{
                    //    BMSID = Convert.ToInt32(dsData.Tables[0].Rows[0]["BMSID"].ToString());
                    //    Session["DemoBMS"] = BMSID;
                    //    Session["UserPackage"] = "Combo";
                    //}
                }
                else if (dsData.Tables[0].Rows.Count > 1)
                {
                    Response.Redirect("~/DashBoard/SelectPackage.aspx");
                }
            }
            else
            {
                Response.Redirect("~/DashBoard/SelectPackage.aspx");
            }
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }

    protected void BindSubjectList()
    {
        try
        {
            if (Session["ShowPaymentPages"] != null)
            {
                //Session["DemoBMS"] = AppSessions.BMSID;
            }
            else
            {
                GetStudentDetailBMS();
            }
            obj_BAL_Student_Dashboard = new Student_DashBoard_BLogic();
            obj_Student_Dashboard = new StudentDash();
            ArrayList Alist = new ArrayList();

            if (ViewState["ArrayList"] != null)
            {
                Alist = (ArrayList)ViewState["ArrayList"];
                string PackageFDID = string.Empty;
                for (int i = 0; i < Alist.Count; i++)
                {
                    if (PackageFDID != string.Empty)
                    {
                        PackageFDID = PackageFDID + "," + Alist[i].ToString();
                    }
                    else
                    {
                        PackageFDID = PackageFDID + Alist[i].ToString();
                    }
                }

                obj_Student_Dashboard.BMSID = AppSessions.BMSID;
                obj_Student_Dashboard.PackageFDID = PackageFDID;
                obj_Student_Dashboard.Mode = "Selected";
                DataSet ds = new DataSet();
                //ds = obj_BAL_Student_Dashboard.BAL_Student_Subject_Select(obj_Student_Dashboard);
                ds = obj_BAL_Student_Dashboard.BAL_Student_Purchased_Package("", Convert.ToInt32(AppSessions.BMSID), Convert.ToInt32(AppSessions.StudentID));

                DataTable dt = new DataTable();
                dt.Columns.Add("SubjectID", typeof(Int32));
                dt.Columns.Add("Subject", typeof(string));



                if (ds.Tables[0].Rows.Count > 0 && ds != null)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {

                        if (ds.Tables[0].Rows[i]["PackageType"].ToString().ToLower() == "combo")
                        {
                            string[] subjects = ds.Tables[0].Rows[i]["subject"].ToString().Split(',');
                            string[] subjectsid = ds.Tables[0].Rows[i]["subjectid"].ToString().Split(',');
                            for (int subcnt = 0; subcnt < subjects.Length; subcnt++)
                            {
                                DataRow dr = dt.NewRow();
                                dr["SubjectID"] = subjectsid[subcnt].ToString().Trim();
                                dr["Subject"] = subjects[subcnt].ToString().Trim();
                                dt.Rows.Add(dr);
                            }
                        }
                        else
                        {
                            DataRow dr = dt.NewRow();
                            dr["SubjectID"] = ds.Tables[0].Rows[i]["Subjectid"].ToString().Trim();
                            dr["Subject"] = ds.Tables[0].Rows[i]["Subject"].ToString().Trim();
                            dt.Rows.Add(dr);
                        }

                    }
                    DataTable dt1 = dt.DefaultView.ToTable(true, "SubjectID", "Subject");
                    DataView dv = dt1.DefaultView;
                    dv.Sort = "Subject";
                    dt = dv.ToTable();
                    // dt = dt.DefaultView.ToTable(true);
                    rbSubjectList.DataSource = dt;
                    rbSubjectList.DataValueField = "SubjectID";
                    rbSubjectList.DataTextField = "Subject";
                    rbSubjectList.DataBind();
                    rbSubjectList.SelectedIndex = 0;
                }
            }

            //if (Session["DemoBMS"] != null)
            if (Session["DemoBMS"] != null)
            {
                obj_Student_Dashboard.BMSID = Convert.ToInt64(Session["DemoBMS"]);
                obj_Student_Dashboard.Mode = "All";
                DataSet ds = new DataSet();
                ds = obj_BAL_Student_Dashboard.BAL_Student_Subject_Select(obj_Student_Dashboard);
                if (ds.Tables[0].Rows.Count > 0 && ds != null)
                {
                    rbSubjectList.DataSource = ds.Tables[0];
                    rbSubjectList.DataValueField = "SubjectID";
                    rbSubjectList.DataTextField = "Subject";
                    rbSubjectList.DataBind();
                    rbSubjectList.SelectedIndex = 0;
                }
            }


        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }

    public void FillChapters_Topic()
    {
        obj_BAL_Student_Dashboard = new Student_DashBoard_BLogic();
        obj_Student_Dashboard = new StudentDash();

        obj_Student_Dashboard.BMSID = Convert.ToInt64(Session["BMSID"]);
        obj_Student_Dashboard.SubjectID = Convert.ToInt16(Session["SubjectID"]);
        obj_Student_Dashboard.StudentID = Convert.ToInt64(Session["StudentID"]);

        //
        DataSet dsSettings = new DataSet();
        dsSettings = obj_BAL_Student_Dashboard.BAL_Select_CoveredUncoverChapterTopic_Settings();
        IsAllow_Enable_Settings(dsSettings);

        DataSet dsSelect = new DataSet();
        dsSelect = obj_BAL_Student_Dashboard.BAL_Select_Chapters_Topics(obj_Student_Dashboard);
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
            ddlChapter.SelectedIndex = Convert.ToInt32(EnumFile.AssignValue.Zero);

            //DropDownList[] disddl = { ddlChapter, ddlTopic };
            //EnableDropDwon(disddl);

            if (dsSelect.Tables[2].Rows.Count > ((int)EnumFile.AssignValue.Zero))
            {
                if (dsSelect.Tables[2].Rows[0]["ChapterID"].ToString().Equals(""))
                {
                    ddlChapter.SelectedIndex = ((int)EnumFile.AssignValue.Zero);
                }
                else
                {
                    // ddlChapter.SelectedValue = dsSelect.Tables[2].Rows[0]["ChapterID"].ToString();
                }
            }
            DropDownList[] disddl1 = { ddlTopic };
            DisableDropDwon(disddl1);

            ViewState["TopicTable"] = (DataTable)dsSelect.Tables[1];

            ddlTopic.DataSource = dsSelect.Tables[1];
            ddlTopic.DataTextField = "Topic";
            ddlTopic.DataValueField = "TopicID";
            ddlTopic.DataBind();
            ddlTopic.Items.Insert(Convert.ToInt32(EnumFile.AssignValue.Zero), new ListItem("-- Select --"));
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
                    // ddlTopic.SelectedValue = dsSelect.Tables[3].Rows[0]["TopicID"].ToString();
                }
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
        obj_BAL_Student_Dashboard = new Student_DashBoard_BLogic();
        obj_Student_Dashboard = new StudentDash();

        obj_Student_Dashboard.BMSID = Convert.ToInt64(Session["BMSID"]);
        obj_Student_Dashboard.SubjectID = Convert.ToInt16(Session["SubjectID"]);
        obj_Student_Dashboard.StudentID = Convert.ToInt64(Session["StudentID"]);

        DataSet dsSelect = new DataSet();

        dsSelect = obj_BAL_Student_Dashboard.BAL_Select_Covered_Chapters_Topics(obj_Student_Dashboard);

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

        obj_BAL_Student_Dashboard = new Student_DashBoard_BLogic();
        obj_Student_Dashboard = new StudentDash();

        obj_Student_Dashboard.BMSID = Convert.ToInt64(Session["BMSID"]);
        obj_Student_Dashboard.SubjectID = Convert.ToInt16(Session["SubjectID"]);
        obj_Student_Dashboard.StudentID = Convert.ToInt64(Session["StudentID"]);

        DataSet dsSelect = new DataSet();

        dsSelect = obj_BAL_Student_Dashboard.BAL_Select_Covered_Syllabus(obj_Student_Dashboard);

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

        obj_BAL_Student_Dashboard = new Student_DashBoard_BLogic();
        obj_Student_Dashboard = new StudentDash();

        obj_Student_Dashboard.BMSID = Convert.ToInt64(Session["BMSID"]);
        obj_Student_Dashboard.SubjectID = Convert.ToInt16(Session["SubjectID"]);
        obj_Student_Dashboard.DivisionID = Convert.ToInt16(Session["DivisionID"]);
        obj_Student_Dashboard.StudentID = Convert.ToInt64(Session["StudentID"]);
        obj_Student_Dashboard.SchoolID = Convert.ToInt64(Session["SchoolID"]);

        DataSet dsSelect = new DataSet();

        dsSelect = obj_BAL_Student_Dashboard.BAL_Select_Covered_Syllabus(obj_Student_Dashboard);

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
            ddlChapter.SelectedIndex = Convert.ToInt32(EnumFile.AssignValue.Zero);

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

    //public void Fill_Chart_Data()
    //{

    //    obj_BAL_Student_Dashboard = new Student_DashBoard_BLogic();
    //    obj_Student_Dashboard = new StudentDash();

    //    obj_Student_Dashboard.BMSID = Convert.ToInt64(Session["BMSID"]);
    //    obj_Student_Dashboard.SubjectID = Convert.ToInt16(Session["SubjectID"]);
    //    obj_Student_Dashboard.StudentID = Convert.ToInt64(Session["StudentID"]);

    //    DataSet dsSelect = new DataSet();

    //    dsSelect = obj_BAL_Student_Dashboard.BAL_Select_Chart_Data(obj_Student_Dashboard);

    //    if (dsSelect.Tables[0].Rows.Count > ((int)EnumFile.AssignValue.Zero))
    //    {
    //        LblCoveredChapter.Visible = true;
    //        LblUncoveredChapter.Visible = true;

    //        Int32 CoveredChapters = Convert.ToInt32(dsSelect.Tables[0].Rows[0]["Covered"].ToString());
    //        Int32 UncoveredChapters = 100 - CoveredChapters;

    //        LblCoveredChapter.Text = Convert.ToString(CoveredChapters) + "%";
    //        LblUncoveredChapter.Text = Convert.ToString(UncoveredChapters) + "%";

    //        LblCoveredChapter.Width = CoveredChapters * 2;
    //        LblUncoveredChapter.Width = UncoveredChapters * 2;

    //        //LblCoveredChapter.Width = CoveredChapters;
    //        //LblUncoveredChapter.Width = UncoveredChapters;


    //    }
    //    else
    //    {
    //        LblCoveredChapter.Visible = false;
    //        LblUncoveredChapter.Visible = false;

    //        LblCoveredChapter.Text = "";
    //        LblUncoveredChapter.Text = "";

    //    }
    //}

    public void Fill_Chart_Data()
    {

        obj_BAL_Student_Dashboard = new Student_DashBoard_BLogic();
        obj_Student_Dashboard = new StudentDash();

        obj_Student_Dashboard.BMSID = Convert.ToInt64(Session["BMSID"]);
        obj_Student_Dashboard.SubjectID = Convert.ToInt16(Session["SubjectID"]);
        obj_Student_Dashboard.StudentID = Convert.ToInt64(Session["StudentID"]);

        DataSet dsSelect = new DataSet();

        dsSelect = obj_BAL_Student_Dashboard.BAL_Select_Chart_Data(obj_Student_Dashboard);

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

            lblCovered.Text = "";
            lblUncovered.Text = "";

            lblCovered1.Text = "";
            lblUncovered1.Text = "";

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

    public void IsAllow_Enable_Settings(DataSet dsSettings)
    {

        if (dsSettings != null)
        {
            if (dsSettings.Tables.Count > 0)
            {

                if (dsSettings.Tables[0].Rows.Count > 0)
                {

                    object datatype = dsSettings.Tables[0].Rows[0]["Type"].ToString();
                    object val = dsSettings.Tables[0].Rows[0]["value"].ToString();

                    if (Convert.ToBoolean(Convert.ToInt16(val)))
                    {
                        rblChapters.Visible = true;
                        ddlChapter.Enabled = true;
                        ddlTopic.Enabled = true;
                    }
                    else
                    {
                        rblChapters.Visible = false;
                        ddlChapter.Enabled = false;
                        ddlTopic.Enabled = false;
                    }
                }
            }
        }


    }
    #endregion

    #region "Properties"
    string SortDirection
    {
        get
        {
            object o = ViewState["SortDirection"];
            if (o == null)
            {
                return string.Empty;
            }
            else
            {
                return (string)o;
            }
        }

        set
        {
            ViewState["SortDirection"] = value;
        }
    }
    string SortField
    {
        get
        {
            object o = ViewState["SortField"];
            if (o == null)
            {
                return string.Empty;
            }
            else
            {
                return (string)o;
            }
        }

        set
        {
            ViewState["SortField"] = value;
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
                    Session["TopicID1"] = node.Value;
                    Session["ChapterID"] = node.Parent.Value;
                    //WebMsg.Show("ChapterID = " + ChapterID + " TopicID = " + TopicID);
                    Session["SubjectID"] = Convert.ToInt32(rbSubjectList.SelectedValue);
                    Session["Topic1"] = node.Text;
                    Session["Chapter"] = node.Parent.Text;
                    Session["Subject"] = rbSubjectList.SelectedItem.Text.ToString();
                    //mpTestResult.Show();
                }
                node.Selected = false;
            }
        }
        Response.Redirect("StudentPreTestPostTestResult.aspx?Type=Student");
    }
    protected void ddlChapter_SelectedIndexChanged1(object sender, EventArgs e)
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
    protected void btnsearcksubmit_Click(object sender, EventArgs e)
    {
        Response.Redirect("SearchResult.aspx?key=" + txtkeyword.Text + "");
    }

}