using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Web;
using System.Web.UI.WebControls;
using Udev.UserMasterPage.Classes;

public partial class Exam_ResultEntry : System.Web.UI.Page
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
        this.TeacherPanel1.TeacherPanelEvent += new EventHandler(Demo1_ButtonClickDemo);
        if (!IsPostBack)
        {
            TrackLog_Utils.Log(Convert.ToInt32(AppSessions.SchoolID), Convert.ToInt32(AppSessions.EmpolyeeID), Convert.ToInt16(AppSessions.DivisionID), "ResultEntryPage", "Page", "Load", Convert.ToDateTime(System.DateTime.Now), HttpContext.Current.Session.SessionID, StringEnum.stringValueOf(EnumFile.Activity.ResultEntryPage), "Result Entry page Loaded.", 0);
            fill_ALL_Covered_Chaptes_Topics();
        }
    }
    #endregion

    #region Control Events

    #region Button Events

    protected void Demo1_ButtonClickDemo(object sender, EventArgs e)
    {
        fill_ALL_Covered_Chaptes_Topics();
        ClearControls();
    }

    protected void BtnSubmit_Click(object sender, EventArgs e)
    {
        obj_BAL_Teacher_Dashboard = new Teacher_Dashboard_BLogic();
        obj_Teacher_Dashboard = new Teacher_Dashboard();

        obj_Teacher_Dashboard.SchoolID = Convert.ToInt64(Session["SchoolID"]);
        obj_Teacher_Dashboard.BMSID = Convert.ToInt64(Session["BMSID"]);
        obj_Teacher_Dashboard.DivisionID = Convert.ToInt16(Session["DivisionID"]);
        obj_Teacher_Dashboard.SubjectID = Convert.ToInt16(Session["SubjectID"]);
        obj_Teacher_Dashboard.ChapterID = Convert.ToInt64(ddlChapter.SelectedValue);
        obj_Teacher_Dashboard.TopicID = Convert.ToInt64(ddlTopic.SelectedValue);
        obj_Teacher_Dashboard.ExamID = Convert.ToInt64(ddlExam.SelectedValue);

        int bmssctid = obj_BAL_Teacher_Dashboard.BAL_Select_BMS_SCTID(obj_Teacher_Dashboard);
        ViewState["BMSSCT"] = bmssctid;

        DataSet dsStudentList = new DataSet();
        dsStudentList = obj_BAL_Teacher_Dashboard.Get_StudentList(obj_Teacher_Dashboard);

        //TrackLog_Utils.Log(Convert.ToInt32(AppSessions.SchoolID), Convert.ToInt32(AppSessions.EmpolyeeID), Convert.ToInt16(AppSessions.DivisionID), "ResultEntryPage", "BtnSubmit", "click", Convert.ToDateTime(System.DateTime.Now), HttpContext.Current.Session.SessionID, StringEnum.stringValueOf(EnumFile.Activity.ResultEntryPage),"", Convert.ToInt32(Session["BMSSCTID"]));
        TrackLog_Utils.Log(Convert.ToInt32(AppSessions.SchoolID), Convert.ToInt32(AppSessions.EmpolyeeID), Convert.ToInt16(AppSessions.DivisionID), "ResultEntryPage", "BtnSubmit", "Click", Convert.ToDateTime(System.DateTime.Now), HttpContext.Current.Session.SessionID, StringEnum.stringValueOf(EnumFile.Activity.StudentListPopulatedForExam), "BMSSCT ID = " + bmssctid + " Exam Name : " + ddlExam.SelectedItem.ToString() + " Exam Marks : " + TxtTotalMarks.Text, bmssctid);

        if (dsStudentList.Tables[0].Rows.Count > 0)
        {
            GridStudentList.Visible = true;
            btnSave.Visible = true;
            BtnPDF.Visible = true;
            Session["ChapName"] = ddlChapter.SelectedItem.ToString();
            Session["TopicName"] = ddlTopic.SelectedItem.ToString();
            Session["ExamName"] = ddlExam.SelectedItem.ToString();
            Session["ToatlQues"] = TxtTotalQuestions.Text;
            Session["ToatlMarks"] = TxtTotalMarks.Text;
            Session["StudentResult"] = dsStudentList.Tables[0];
            GridStudentList.DataSource = dsStudentList.Tables[0];
            GridStudentList.DataBind();
        }
        else
        {
            GridStudentList.DataSource = null;
            GridStudentList.DataBind();
            GridStudentList.Visible = false;
            btnSave.Visible = false;
            BtnPDF.Visible = false;
            WebMsg.Show("No student available.");
        }
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        TrackLog_Utils.Log(Convert.ToInt32(AppSessions.SchoolID), Convert.ToInt32(AppSessions.EmpolyeeID), Convert.ToInt16(AppSessions.DivisionID), "ResultEntryPage", "btnReset", "click", Convert.ToDateTime(System.DateTime.Now), HttpContext.Current.Session.SessionID, StringEnum.stringValueOf(EnumFile.Activity.ResetExamResult), "Clear entered result in grid for " + ddlExam.SelectedItem.ToString() + " exam.", Convert.ToInt32(ViewState["BMSSCT"]));
        ClearControls();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        obj_BAL_Teacher_Dashboard = new Teacher_Dashboard_BLogic();
        obj_Teacher_Dashboard = new Teacher_Dashboard();
        obj_Teacher_Dashboard.ExamID = Convert.ToInt64(ViewState["ExamID"]);
        obj_BAL_Teacher_Dashboard.BAL_SYS_Delete_Student_Result(obj_Teacher_Dashboard);

        DataTable TbStudent = new DataTable("StudentExam");

        TbStudent.Columns.Add("ExamID", typeof(Int64));
        TbStudent.Columns.Add("StudentID", typeof(Int64));
        TbStudent.Columns.Add("RightAnswers", typeof(System.String));
        TbStudent.Columns.Add("WorngAnswers", typeof(Int32));
        TbStudent.Columns.Add("Total", typeof(Int32));
        TbStudent.Columns.Add("CreatedBy", typeof(Int64));

        for (int i = 0; i < GridStudentList.Rows.Count; i++)
        {
            DataRow dr = TbStudent.NewRow();
            dr["ExamID"] = Convert.ToInt64(ViewState["ExamID"]);
            dr["StudentID"] = Convert.ToInt64(GridStudentList.DataKeys[i].Values["StudentID"].ToString());
            TextBox tb1 = (TextBox)GridStudentList.Rows[i].Cells[2].FindControl("TxtRightMarks");
            if (tb1.Text.ToString().Equals("A"))
            {
                dr["RightAnswers"] = "A";
                dr["WorngAnswers"] = Convert.ToInt32("0");
            }
            else if (tb1.Text.ToString().Equals("Z"))
            {
                dr["RightAnswers"] = "Z";
                dr["WorngAnswers"] = Convert.ToInt32("0");
            }
            else
            {
                dr["RightAnswers"] = Convert.ToInt32(tb1.Text);
                dr["WorngAnswers"] = Convert.ToInt32(Convert.ToInt32(ViewState["TotalMarks"]) - Convert.ToInt32(tb1.Text));
            }

            dr["Total"] = Convert.ToInt32(ViewState["TotalMarks"]);
            dr["CreatedBy"] = Convert.ToInt64(Session["EmpolyeeID"]);

            TbStudent.Rows.Add(dr);
        }

        if (TbStudent.Rows.Count > ((int)EnumFile.AssignValue.Zero))
        {
            try
            {
                TrackLog_Utils.Log(Convert.ToInt32(AppSessions.SchoolID), Convert.ToInt32(AppSessions.EmpolyeeID), Convert.ToInt16(AppSessions.DivisionID), "ResultEntryPage", "btnSave", "click", Convert.ToDateTime(System.DateTime.Now), HttpContext.Current.Session.SessionID, StringEnum.stringValueOf(EnumFile.Activity.ExamResultSaved), "BMSSCT ID : " + Convert.ToInt32(ViewState["BMSSCTID"]) + " Exam Name : " + ddlExam.SelectedItem.ToString() , Convert.ToInt32(ViewState["BMSSCTID"]));

                string con = ConfigurationManager.AppSettings["EpathshalaStudentCon"];
                using (SqlBulkCopy copy = new SqlBulkCopy(con))
                {
                    //copy.ColumnMappings.Add(0, 0);
                    copy.ColumnMappings.Add(0, 1);//ExamID
                    copy.ColumnMappings.Add(1, 2);//StudentID
                    copy.ColumnMappings.Add(2, 3);//RightAnswers
                    copy.ColumnMappings.Add(3, 4);//WorngAnswers
                    copy.ColumnMappings.Add(4, 5);//Total
                    copy.ColumnMappings.Add(5, 8);//CreatedBy
                    copy.DestinationTableName = "Student_Exam_Result";
                    copy.WriteToServer(TbStudent);
                }
                WebMsg.Show("Result inserted successfully.");
            }
            catch (Exception ex)
            {
                WebMsg.Show("Error in inserting the result.");
            }
        }
        else
        {
            WebMsg.Show("There is no data to be set.");
        }
        ClearControls();
    }

    protected void BtnPDF_Click(object sender, EventArgs e)
    {
        TrackLog_Utils.Log(Convert.ToInt32(AppSessions.SchoolID), Convert.ToInt32(AppSessions.EmpolyeeID), Convert.ToInt16(AppSessions.DivisionID), "ResultEntryPage", "BtnPDF", "click", Convert.ToDateTime(System.DateTime.Now), HttpContext.Current.Session.SessionID, StringEnum.stringValueOf(EnumFile.Activity.ExportToPDF), "BMSSCT ID : " + Convert.ToInt32(ViewState["BMSSCTID"]) + " Exam Name : " + ddlExam.SelectedItem.ToString(), Convert.ToInt32(ViewState["BMSSCTID"]));
        
        Page.RegisterStartupScript("Page Title", "<script language='javascript'>window.open('Print_PDF.aspx?page=ResultEntry','My Window','width=700,height=600,scroll=1');</script>");
    }
    #endregion

    #region DropDown Events

    protected void ddlChapter_SelectedIndexChanged(object sender, EventArgs e)
    {

        DropDownList[] disddl = { ddlTopic, ddlExam };
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
            ddlTopic.Items.Insert(0, new System.Web.UI.WebControls.ListItem("-- Select --"));

            DropDownList[] disddl1 = { ddlTopic };
            EnableDropDwon(disddl1);
        }
        else
        {
            ClearControls();
            DropDownList[] disddl3 = { ddlTopic, ddlExam };
            DisableDropDwon(disddl3);
        }
    }

    protected void ddlTopic_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlTopic.SelectedIndex > 0)
        {
            DropDownList[] disddl = { ddlExam };
            DisableDropDwon(disddl);

            obj_BAL_Teacher_Dashboard = new Teacher_Dashboard_BLogic();
            obj_Teacher_Dashboard = new Teacher_Dashboard();

            obj_Teacher_Dashboard.BMSID = Convert.ToInt64(Session["BMSID"]);
            obj_Teacher_Dashboard.SubjectID = Convert.ToInt16(Session["SubjectID"]);
            obj_Teacher_Dashboard.DivisionID = Convert.ToInt16(Session["DivisionID"]);
            obj_Teacher_Dashboard.EmployeeID = Convert.ToInt64(Session["EmpolyeeID"]);
            obj_Teacher_Dashboard.SchoolID = Convert.ToInt64(Session["SchoolID"]);
            obj_Teacher_Dashboard.ChapterID = Convert.ToInt64(ddlChapter.SelectedValue);
            obj_Teacher_Dashboard.TopicID = Convert.ToInt64(ddlTopic.SelectedValue);

            Int64 bmssctid = Convert.ToInt64(obj_BAL_Teacher_Dashboard.Get_BMSSCTID(obj_Teacher_Dashboard));
            if (bmssctid == ((int)EnumFile.AssignValue.Zero))
            {
                WebMsg.Show("BMSSCT does not exists.");
            }
            else
            {
                obj_Teacher_Dashboard.BMSSCTID = Convert.ToInt64(bmssctid);
                DataSet ds = new DataSet();
                ds = obj_BAL_Teacher_Dashboard.Get_Exams(obj_Teacher_Dashboard);
                DataTable dt = ds.Tables[0];
                ViewState["ExamTable"] = dt;

                ddlExam.Items.Clear();

                if (dt.Rows.Count > 0)
                {
                    ddlExam.DataSource = dt;
                    ddlExam.DataTextField = "ExamName";
                    ddlExam.DataValueField = "ExamID";
                    ddlExam.DataBind();

                }
                ddlExam.Items.Insert(0, new System.Web.UI.WebControls.ListItem("-- Select --"));

                DropDownList[] disddl1 = { ddlExam };
                EnableDropDwon(disddl1);

            }
        }
        else
        {
            DropDownList[] disddl1 = { ddlExam };
            DisableDropDwon(disddl1);

            TxtTotalQuestions.Text = "0";
            TxtTotalMarks.Text = "0";

            GridStudentList.DataSource = null;
            GridStudentList.DataBind();

            GridStudentList.Visible = false;
            btnSave.Visible = false;
        }

    }

    protected void ddlExam_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlExam.SelectedIndex > 0)
        {
            if (ddlTopic.SelectedIndex > 0)
            {
                DataTable dt = (DataTable)ViewState["ExamTable"];

                if (dt.Rows.Count > 0)
                {
                    DataTable dtResult = dt.Clone();
                    DataRow[] dr = dt.Select("ExamID = " + Convert.ToInt32(ddlExam.SelectedValue));
                    ViewState["ExamID"] = Convert.ToInt32(ddlExam.SelectedValue);
                    foreach (DataRow drLoop in dr)
                    {
                        dtResult.ImportRow(drLoop);
                    }

                    if (dtResult.Rows.Count > 0)
                    {
                        ViewState["TotalMarks"] = dtResult.Rows[0]["TotalMarks"].ToString();
                        TxtTotalQuestions.Text = dtResult.Rows[0]["TotalQues"].ToString();
                        TxtTotalMarks.Text = dtResult.Rows[0]["TotalMarks"].ToString();
                    }
                }
                else
                {
                    DropDownList[] disddl = { ddlExam };
                    DisableDropDwon(disddl);

                    TxtTotalQuestions.Text = "0";
                    TxtTotalMarks.Text = "0";
                }
            }
            else
            {
                DropDownList[] disddl = { ddlExam };
                DisableDropDwon(disddl);

                TxtTotalQuestions.Text = "0";
                TxtTotalMarks.Text = "0";

            }
        }
        else
        {
            TxtTotalQuestions.Text = "0";
            TxtTotalMarks.Text = "0";

            GridStudentList.DataSource = null;
            GridStudentList.DataBind();

            GridStudentList.Visible = false;
            btnSave.Visible = false;
        }
    }

    #endregion

    #region Gridview Events

    protected void GridStudentList_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }

    //protected void OnTextChanged(object sender, EventArgs e)
    //{
    //    //ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('" + (sender as TextBox).Text + "');", true);
    //    TextBox tb = sender as TextBox;
    //    if (Convert.ToInt32(tb.Text) > Convert.ToInt32(ViewState["TotalMarks"]))
    //    {
    //        WebMsg.Show("Right marks must be lessthen Total marks.");
    //        tb.Text = "";
    //        tb.Focus();
    //    }
    //}

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
                WebMsg.Show("No Chapter available.");

                DropDownList[] disddl = { ddlChapter, ddlTopic, ddlExam };
                DisableDropDwon(disddl);
            }
        }

        else if (dsSelect.Tables.Count > ((int)EnumFile.AssignValue.Zero) && dsSelect.Tables[0].Rows.Count > ((int)EnumFile.AssignValue.Zero))
        {

            ddlChapter.DataSource = dsSelect.Tables[0];
            ddlChapter.DataTextField = "Chapter";
            ddlChapter.DataValueField = "ChapterID";
            ddlChapter.DataBind();
            ddlChapter.Items.Insert(Convert.ToInt32(EnumFile.AssignValue.Zero), new System.Web.UI.WebControls.ListItem("-- Select --"));

            DropDownList[] disddl = { ddlChapter, ddlTopic, ddlExam };
            EnableDropDwon(disddl);


            ViewState["TopicTable"] = (DataTable)dsSelect.Tables[1];

            ddlTopic.DataSource = dsSelect.Tables[1];
            ddlTopic.DataTextField = "Topic";
            ddlTopic.DataValueField = "TopicID";
            ddlTopic.DataBind();
            ddlTopic.Items.Insert(Convert.ToInt32(EnumFile.AssignValue.Zero), new System.Web.UI.WebControls.ListItem("-- Select --"));
            ddlTopic.SelectedIndex = Convert.ToInt32(EnumFile.AssignValue.Zero);

        }
        else if (dsSelect.Tables[0].Rows.Count == 0)
        {
            ddlChapter.DataSource = dsSelect.Tables[0];
            ddlChapter.DataTextField = "Chapter";
            ddlChapter.DataValueField = "ChapterID";
            ddlChapter.DataBind();

            ddlChapter.Items.Insert(0, new System.Web.UI.WebControls.ListItem("-- Select --"));
        
        }
        else
        {
            DropDownList[] disddl = { ddlChapter, ddlTopic, ddlExam };
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
        DropDownList[] disddl3 = { ddlChapter, ddlTopic, ddlExam };
        DisableDropDwon(disddl3);

        DropDownList[] disddl = { ddlChapter };
        EnableDropDwon(disddl);

        TxtTotalQuestions.Text = "";
        TxtTotalMarks.Text = "";

        GridStudentList.DataSource = null;
        GridStudentList.DataBind();

        GridStudentList.Visible = false;
        btnSave.Visible = false;
    }

    #endregion

}