using System;
using System.Data;
using System.Globalization;
using System.Web;
using System.Web.UI.WebControls;
using Udev.UserMasterPage.Classes;

public partial class Exam_ExamEntry : System.Web.UI.Page
{

    #region Variables
    Teacher_Dashboard_BLogic obj_BAL_Teacher_Dashboard;
    Teacher_Dashboard obj_Teacher_Dashboard;

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
        TrackLog_Utils.Log(Convert.ToInt32(AppSessions.SchoolID), Convert.ToInt32(AppSessions.EmpolyeeID), Convert.ToInt16(AppSessions.DivisionID), "ExamEntryPage", "Page", "Load", Convert.ToDateTime(System.DateTime.Now), HttpContext.Current.Session.SessionID, StringEnum.stringValueOf(EnumFile.Activity.ExamEntryPage), "Exam Entry Page Loaded.", 0);

        this.TeacherPanel1.TeacherPanelEvent += new EventHandler(Demo1_ButtonClickDemo);
        if (!IsPostBack)
        {
            fill_ALL_Covered_Chaptes_Topics();
        }
    }
    #endregion

    #region Control Events

    #region Button Events

    protected void Demo1_ButtonClickDemo(object sender, EventArgs e)
    {
        fill_ALL_Covered_Chaptes_Topics();
    }

    protected void BtnSubmit_Click(object sender, EventArgs e)
    {
        obj_BAL_Teacher_Dashboard = new Teacher_Dashboard_BLogic();
        obj_Teacher_Dashboard = new Teacher_Dashboard();

        obj_Teacher_Dashboard.BMSID = Convert.ToInt64(Session["BMSID"]);
        obj_Teacher_Dashboard.SubjectID = Convert.ToInt16(Session["SubjectID"]);
        obj_Teacher_Dashboard.DivisionID = Convert.ToInt16(Session["DivisionID"]);
        obj_Teacher_Dashboard.EmployeeID = Convert.ToInt64(Session["EmpolyeeID"]);
        obj_Teacher_Dashboard.SchoolID = Convert.ToInt64(Session["SchoolID"]);
        obj_Teacher_Dashboard.ChapterID = Convert.ToInt64(ddlChapter.SelectedValue);
        obj_Teacher_Dashboard.TopicID = Convert.ToInt64(ddlTopic.SelectedValue);
        obj_Teacher_Dashboard.ExamName = TxtExamName.Text;
        obj_Teacher_Dashboard.TotalQues = Convert.ToInt32(TxtTotalQuestions.Text);
        obj_Teacher_Dashboard.TotalMarks = Convert.ToInt32(TxtTotalMarks.Text);

        int bmssctid = obj_BAL_Teacher_Dashboard.Get_BMSSCTID(obj_Teacher_Dashboard);
        if (bmssctid == ((int)EnumFile.AssignValue.Zero))
        {
            WebMsg.Show("BMSSCT does not exists.");
        }
        else
        {
            TrackLog_Utils.Log(Convert.ToInt32(AppSessions.SchoolID), Convert.ToInt32(AppSessions.EmpolyeeID), Convert.ToInt16(AppSessions.DivisionID), "ExamEntryPage", "BtnSubmit", "Click", Convert.ToDateTime(System.DateTime.Now), HttpContext.Current.Session.SessionID, StringEnum.stringValueOf(EnumFile.Activity.ExamCreatedSuccessfully), "BMSSCT ID = " + bmssctid + " Exam Name : " + TxtExamName.Text + " Exam Marks : " + TxtTotalMarks.Text, bmssctid);

            obj_Teacher_Dashboard.BMSSCTID = Convert.ToInt64(bmssctid);
            int result = obj_BAL_Teacher_Dashboard.BAL_Insert_Exam(obj_Teacher_Dashboard);
            if (result == ((int)EnumFile.AssignValue.One))
            {
                WebMsg.Show("Exam entry has been entered successfully.");
            }
            else if (result == ((int)EnumFile.AssignValue.Zero))
            {
                WebMsg.Show("This exam entry already exists.");
            }
        }
        ClearControls();
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        TrackLog_Utils.Log(Convert.ToInt32(AppSessions.SchoolID), Convert.ToInt32(AppSessions.EmpolyeeID), Convert.ToInt16(AppSessions.DivisionID), "ExamEntryPage", "bntReset", "Click", Convert.ToDateTime(System.DateTime.Now), HttpContext.Current.Session.SessionID, StringEnum.stringValueOf(EnumFile.Activity.ResetExamName), "Reset Exam Name.", Convert.ToInt32(Session["BMSSCTID"]));

        ClearControls();
    }

    #endregion

    #region DropDown Events
    protected void ddlChapter_SelectedIndexChanged(object sender, EventArgs e)
    {

        DropDownList[] disddl = { ddlTopic };
        DisableDropDwon(disddl);

        if (ddlChapter.SelectedIndex > 0)
        {
            DataTable dt = (DataTable)ViewState["TopicTable"];
            ddlTopic.Items.Clear();

            if (dt.Rows.Count > 0)
            {
                DataTable dtResult = dt.Clone();
                DataRow[] dr = dt.Select("ChapterID = " + Convert.ToInt32(ddlChapter.SelectedValue));
                foreach (DataRow drLoop in dr)
                {
                    dtResult.ImportRow(drLoop);
                }

                if (dtResult.Rows.Count > 0)
                {
                    ddlTopic.DataSource = dtResult;
                    ddlTopic.DataTextField = "Topic";
                    ddlTopic.DataValueField = "TopicID";
                    ddlTopic.DataBind();
                }
            }
            ddlTopic.Items.Insert(0, new ListItem("-- Select --"));

            DropDownList[] disddl1 = { ddlTopic };
            EnableDropDwon(disddl1);
        }
        else
        {
            DropDownList[] disddl3 = { ddlTopic };
            DisableDropDwon(disddl3);
        }
    }
    #endregion

    #endregion

    #region User Define Function

    public void fill_ALL_Covered_Chaptes_Topics()
    {

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
                WebMsg.Show("No Chatper available.");

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

    public void ClearControls()
    {
        DropDownList[] disddl3 = { ddlChapter, ddlTopic };
        DisableDropDwon(disddl3);

        DropDownList[] disddl = { ddlChapter };
        EnableDropDwon(disddl);

        TxtExamName.Text = "";
        TxtTotalQuestions.Text = "";
        TxtTotalMarks.Text = "";
    }

    #endregion


}