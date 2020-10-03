///<Summary>
///</Summary>

using System;
using System.Data;
using System.Globalization;
using System.Web.UI.WebControls;
using Udev.UserMasterPage.Classes;

public partial class Student_ReschedulingChapterTopicStudent : System.Web.UI.Page
{
    #region Variables
    Student_DashBoard_BLogic obj_BAL_Student_Dashboard;
    StudentDash obj_Student_Dashboard;
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
            BindSubjectList();
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
                fill_ALL_Covered_Chaptes_Topics();
                PopulateMonthYear();
                Applied_Chapter_Topics();
            }
        }
    }
    #endregion

    #region Control Events

    #region Button Events
    protected void Demo1_ButtonClickDemo(object sender, EventArgs e)
    {
        fill_ALL_Covered_Chaptes_Topics();
        Applied_Chapter_Topics();
    }

    protected void BtnSubmit_Click(object sender, EventArgs e)
    {
        obj_BAL_Student_Dashboard = new Student_DashBoard_BLogic();
        obj_Student_Dashboard = new StudentDash();


        obj_Student_Dashboard.BMSID = Convert.ToInt64(Session["BMSID"]);
        obj_Student_Dashboard.SubjectID = Convert.ToInt16(Session["SubjectID"]);
        obj_Student_Dashboard.StudentID = Convert.ToInt64(Session["StudentID"]);
        obj_Student_Dashboard.ChapterID = Convert.ToInt64(ddlChapter.SelectedValue);
        obj_Student_Dashboard.TopicID = Convert.ToInt64(ddlTopic.SelectedValue);

        int result = obj_BAL_Student_Dashboard.BAL_Insert_Rescheduling_BMSSCT(obj_Student_Dashboard);

        if (result == ((int)EnumFile.AssignValue.One))
        {
            WebMsg.Show("Submit Query Successfully.");
            Applied_Chapter_Topics();
        }
        else if (result == ((int)EnumFile.AssignValue.Zero))
        {
            WebMsg.Show("This Chapter, Topic are allready requested for Rescheduling.");
        }

        DropDownList[] disddl3 = { ddlChapter, ddlTopic };
        DisableDropDwon(disddl3);

        DropDownList[] disddl = { ddlChapter };
        EnableDropDwon(disddl);

    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        DropDownList[] disddl3 = { ddlChapter, ddlTopic };
        DisableDropDwon(disddl3);

        DropDownList[] disddl = { ddlChapter };
        EnableDropDwon(disddl);
    }
    #endregion

    #region DropDown Events
  
    protected void rbSubjectList_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rbSubjectList.Items.Count > 0)
        {
            AppSessions.SubjectID = Convert.ToInt16(rbSubjectList.SelectedValue);
            fill_ALL_Covered_Chaptes_Topics();
            PopulateMonthYear();
            Applied_Chapter_Topics();
        }
    }

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

    protected void ddlMonthYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        Applied_Chapter_Topics();
    }
    #endregion

    #endregion

    #region User Define Function

    public void fill_ALL_Covered_Chaptes_Topics()
    {

        obj_BAL_Student_Dashboard = new Student_DashBoard_BLogic();
        obj_Student_Dashboard = new StudentDash();

        obj_Student_Dashboard.BMSID = Convert.ToInt64(Session["BMSID"]);
        obj_Student_Dashboard.SubjectID = Convert.ToInt16(Session["SubjectID"]);
        obj_Student_Dashboard.StudentID = Convert.ToInt64(Session["StudentID"]);

        DataSet dsSelect = new DataSet();

        dsSelect = obj_BAL_Student_Dashboard.BAL_Select_Covered_Syllabus(obj_Student_Dashboard);

        if (dsSelect.Tables.Count == ((int)EnumFile.AssignValue.One))
        {
            if (dsSelect.Tables[0].Rows[0]["NoRecord"].ToString().Equals("0"))
            {
                WebMsg.Show("No Chatper availbale.");

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

    public void PopulateMonthYear()
    {
        for (int m = 0; m <= 3; m++)
        {
            ddlMonthYear.Items.Insert(m, new ListItem(String.Format("{0}", System.DateTime.Now.AddMonths(-m).ToString("MMMM-yyyy")), System.DateTime.Now.AddMonths(-m).ToString("MM")));
        }
        ddlMonthYear.SelectedIndex = (int)EnumFile.AssignValue.Zero;
    }

    protected void BindSubjectList()
    {
        try
        {
            obj_BAL_Student_Dashboard = new Student_DashBoard_BLogic();
            obj_Student_Dashboard = new StudentDash();

            obj_Student_Dashboard.BMSID = Convert.ToInt64(Session["BMSID"]);
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
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }

    public void Applied_Chapter_Topics()
    {
        obj_BAL_Student_Dashboard = new Student_DashBoard_BLogic();
        obj_Student_Dashboard = new StudentDash();

        obj_Student_Dashboard.BMSID = Convert.ToInt64(Session["BMSID"]);
        obj_Student_Dashboard.SubjectID = Convert.ToInt16(Session["SubjectID"]);
        obj_Student_Dashboard.StudentID = Convert.ToInt64(Session["StudentID"]);

        obj_Student_Dashboard.Month = Convert.ToInt16(ddlMonthYear.SelectedValue);
        String[] Year = ddlMonthYear.SelectedItem.ToString().Split('-');
        obj_Student_Dashboard.Year = Convert.ToInt32(Year[1]);

        DataSet dsSelect = new DataSet();
        dsSelect = obj_BAL_Student_Dashboard.BAL_Select_Applied_Rescheduling_Data_Of_Student(obj_Student_Dashboard);

        if (dsSelect.Tables[0].Rows.Count > 0)
        {
            grvReschedulingData.DataSource = dsSelect.Tables[0];
            grvReschedulingData.DataBind();
        }
        else
        {
            grvReschedulingData.DataSource = null;
            grvReschedulingData.DataBind();
        }
    }

    #endregion
   
}