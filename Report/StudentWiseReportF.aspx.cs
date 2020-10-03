using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Udev.UserMasterPage.Classes;
using System.Globalization;
using System.Data.SqlClient;
using System.Collections;
using System.Web.UI.DataVisualization.Charting;

public partial class Report_StudentWiseReportF : System.Web.UI.Page
{
    string connectionstring;
    protected override void InitializeCulture()
    {
        string culture = Convert.ToString(Session[Global.SESSION_KEY_CULTURE]);
        //// 'set culture to current thread 
        System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture);
        System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);
        ////call base class 
        base.InitializeCulture();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            DateTime startOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            DateTime endOfMonth = startOfMonth.AddMonths(1).AddDays(-1);
            txtfromdate.Text = string.Format("{0:dd-MMM-yyyy}", startOfMonth);
            txttodate.Text = string.Format("{0:dd-MMM-yyyy}", endOfMonth);
            BindAllDDLSchool();
            BindDDlDivision();

            //--------------------------------------------
            switch (AppSessions.RoleID)
            {
                case (int)EnumFile.Role.S_Admin:
                    ddlSchool.SelectedIndex = ddlSchool.Items.IndexOf(ddlSchool.Items.FindByValue(AppSessions.SchoolID.ToString()));
                    ddlSchool.Enabled = false;
                    ddlSchool_SelectedIndexChanged(ddlSchool, e);
                    break;
                case (int)EnumFile.Role.Teacher:
                    ddlSchool.SelectedIndex = ddlSchool.Items.IndexOf(ddlSchool.Items.FindByValue(AppSessions.SchoolID.ToString()));
                    ddlSchool.Enabled = false;
                    ddlSchool_SelectedIndexChanged(ddlSchool, e);
                    break;
            }
            //---------------------------------------------------



        }
    }

    #region "User defined functions"
    private void BindDDlDivision()
    {
        SYS_Division_BLogic BAL_SYS_Division = new SYS_Division_BLogic();

        DataSet dsSelect = new DataSet();
        dsSelect = BAL_SYS_Division.BAL_SYS_Division_SelectAllActive("Active");
        if (dsSelect.Tables.Count > 0)
        {
            DropDownFill DdlFilling = new DropDownFill();
            DdlFilling.BindDropDownByTable(ddlDivision, dsSelect.Tables[0], "Division", "DivisionID");
            ddlDivision.Items.Insert(Convert.ToInt32(EnumFile.AssignValue.Zero), "-- Select --");
            ddlDivision.Items[0].Value = Convert.ToString((int)EnumFile.AssignValue.Zero);
        }
    }
    private void BindAllDDLSchool()
    {
        School_BLogic SchoolBLogic = new School_BLogic();
        DataTable dt = new DataTable();
        dt = SchoolBLogic.BAL_SchoolAllNameWithID("Normal").Tables[0];
        if (dt != null)
        {
            if (dt.Rows.Count > 0)
            {
                DropDownFill DdlFilling = new DropDownFill();
                DdlFilling.BindDropDownByTable(ddlSchool, dt, "Name", "SchoolID");
                ddlSchool.Items.Insert(Convert.ToInt32(EnumFile.AssignValue.Zero), "-- Select --");
                ddlSchool.Items[0].Value = Convert.ToString((int)EnumFile.AssignValue.Zero);
            }

        }
        DDLDisable(ddlBoard, false);

    }
    private void DDLDisable(DropDownList ddl, bool enbDsbl)
    {
        ddl.SelectedIndex = 0;
        ddl.Enabled = enbDsbl;
    }
    private void BindSubjectChapterTopic(int Step)
    {

        DataSet ds = new DataSet();

        SYS_Board_BLogic objSys_Board = new SYS_Board_BLogic();
        ds = objSys_Board.BAL_SYS_StdSubChapTopic_BySchoolIDBoardIDMediumid(Convert.ToInt32(ddlSchool.SelectedValue), Convert.ToInt32(ddlBoard.SelectedValue), Convert.ToInt32(ddlMedium.SelectedValue), Convert.ToInt32(ddlStandard.SelectedValue), Convert.ToInt32(ddlsubject.SelectedValue), 0);

        DropDownFill DdlFilling = new DropDownFill();
        if (Step <= 1)
        {
            if (ds.Tables.Count > 0)
            {
                DdlFilling.BindDropDownByTable(ddlStandard, ds.Tables[0], "Standard", "StandardID");
                DDLDisable(ddlStandard, true);
            }
        }
        if (Step <= 2)
        {
            if (ds.Tables.Count > 1)
            {
                DdlFilling.BindDropDownByTable(ddlsubject, ds.Tables[1], "Subject", "SubjectID");
                DDLDisable(ddlsubject, true);
            }
        }






    }
    #endregion

    protected void ddlSchool_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (ddlSchool.SelectedValue != "0")
        {
            DataSet ds = new DataSet();

            SYS_Board_BLogic objSys_Board = new SYS_Board_BLogic();
            ds = objSys_Board.BAL_SYS_Board_BySchoolID(Convert.ToInt32(ddlSchool.SelectedValue));

            DropDownFill DdlFilling = new DropDownFill();
            DdlFilling.BindDropDownByTable(ddlBoard, ds.Tables[0], "Board", "BoardID");

            DDLDisable(ddlBoard, true);
            DDLDisable(ddlMedium, false);
            DDLDisable(ddlStandard, false);
            DDLDisable(ddlsubject, false);

        }
        else
        {
            DDLDisable(ddlBoard, false);
            DDLDisable(ddlMedium, false);
            DDLDisable(ddlStandard, false);
            DDLDisable(ddlsubject, false);

        }
    }
    protected void ddlBoard_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlBoard.SelectedValue != "0")
        {
            DataSet ds = new DataSet();

            SYS_Board_BLogic objSys_Board = new SYS_Board_BLogic();
            ds = objSys_Board.BAL_SYS_Medium_BySchoolIDBoardID(Convert.ToInt32(ddlSchool.SelectedValue), Convert.ToInt32(ddlBoard.SelectedValue));

            DropDownFill DdlFilling = new DropDownFill();
            DdlFilling.BindDropDownByTable(ddlMedium, ds.Tables[0], "Medium", "MediumID");



            DDLDisable(ddlMedium, true);
            DDLDisable(ddlStandard, false);
            DDLDisable(ddlsubject, false);

        }
        else
        {

            DDLDisable(ddlMedium, false);
            DDLDisable(ddlStandard, false);
            DDLDisable(ddlsubject, false);

        }

    }
    protected void ddlMedium_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlMedium.SelectedValue != "0")
        {
            BindSubjectChapterTopic(1);
        }
        else
        {

            DDLDisable(ddlStandard, false);
            DDLDisable(ddlsubject, false);

        }
    }
    protected void ddlStandard_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindSubjectChapterTopic(2);
    }
    protected void ddlsubject_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindSubjectChapterTopic(3);
    }

    protected void btnview_Click(object sender, EventArgs e)
    {

        BindDataToGrid();
    }
    private void BindDataToGrid()
    {
        ddlSchool.Enabled = false;
        ddlBoard.Enabled = false;
        ddlMedium.Enabled = false;
        ddlStandard.Enabled = false;
        ddlsubject.Enabled = false;
        txtfromdate.Enabled = false;
        txttodate.Enabled = false;
        BindGrvResultDetails();
    }
    private void BindGrvResultDetails()
    {
        ViewState["Stage"] = 1;
        StageOneCalli();

    }



    protected void btnReset_Click(object sender, EventArgs e)
    {
        if (AppSessions.RoleID == (int)EnumFile.Role.E_Admin)
        {
            DDLDisable(ddlSchool, true);
            DDLDisable(ddlBoard, false);
            DDLDisable(ddlMedium, false);
            DDLDisable(ddlStandard, false);
            DDLDisable(ddlsubject, false);
            txtfromdate.Enabled = true;
            txttodate.Enabled = true;
            DateTime startOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            DateTime endOfMonth = startOfMonth.AddMonths(1).AddDays(-1);
            txtfromdate.Text = string.Format("{0:dd-MMM-yyyy}", startOfMonth);
            txttodate.Text = string.Format("{0:dd-MMM-yyyy}", endOfMonth);
            ViewState["Stage"] = 1;
            StageOneCalli();
        }
        else if (AppSessions.RoleID == (int)EnumFile.Role.S_Admin)
        {
            //DDLDisable(ddlSchool, true);
            DDLDisable(ddlBoard, true);
            DDLDisable(ddlMedium, false);
            DDLDisable(ddlStandard, false);
            DDLDisable(ddlsubject, false);
            txtfromdate.Enabled = true;
            txttodate.Enabled = true;
            DateTime startOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            DateTime endOfMonth = startOfMonth.AddMonths(1).AddDays(-1);
            txtfromdate.Text = string.Format("{0:dd-MMM-yyyy}", startOfMonth);
            txttodate.Text = string.Format("{0:dd-MMM-yyyy}", endOfMonth);
            ViewState["Stage"] = 1;
            StageOneCalli();
        }
        else if (AppSessions.RoleID == (int)EnumFile.Role.Teacher)
        {
            // TODO : Code here
        }
        else if (AppSessions.RoleID == (int)EnumFile.Role.Student)
        {
            //TODO: CODE Here..
        }


    }

    public void Displayselecteddata(Hashtable hashtable, object objsender)
    {

        if (Convert.ToInt32(ViewState["Stage"].ToString()) == 1)
        {
            FirstRpt.Visible = true;
            secondRpt.Visible = true;
            thirdRpt.Visible = false;
            fourthRpt.Visible = false;

            btnback.Visible = true;
            ViewState["Stage"] = 2;
            lblTitleSecond.Visible = true;
            lblTitleFirst.Visible = true;
            this.SchoolID = Convert.ToInt32(ddlSchool.SelectedValue.ToString());
            this.BMSID = Convert.ToInt32(hashtable["BMSID"].ToString());
            this.StudentID = Convert.ToInt32(hashtable["StudentID"].ToString());
            this.DivisionID = Convert.ToInt32(hashtable["DivisionID"].ToString());
            this.FromDate = Convert.ToDateTime(txtfromdate.Text);
            this.ToDate = Convert.ToDateTime(txttodate.Text);
            this.StudentName = hashtable["FirstName"].ToString();
            this.Standard = hashtable["Standard"].ToString();
            this.Perc = hashtable["Perc"].ToString();
            //this.StudentID= ;
            //this.SchoolID, this.StudentID, this.BMSID, this.SubjectID, this.DivisionID, this.FromDate, this.ToDate
            BindValuesToLabels();
            StageTwoCalling();
        }
        else if (Convert.ToInt32(ViewState["Stage"].ToString()) == 2)
        {
            FirstRpt.Visible = true;
            secondRpt.Visible = false;
            thirdRpt.Visible = true;
            fourthRpt.Visible = false;
            lblTitleThird.Visible = true;
            lblTitleSecond.Visible = false;

            btnback.Visible = true;
            ViewState["Stage"] = 3;

            this.SubjectID = Convert.ToInt32(hashtable["SubjectID"].ToString());
            this.EmployeeID = Convert.ToInt32(hashtable["EmployeeID"].ToString());


            tlblSchoolValue.Text = ddlSchool.SelectedItem.Text;
            tlblBoardValue.Text = ddlBoard.SelectedItem.Text;
            tlblMediumValue.Text = ddlMedium.SelectedItem.Text;
            tlblStandardValue.Text = this.Standard;
            tlblStudentValue.Text = this.StudentName;
            tlblFromDateValue.Text = string.Format("{0:dd-MMM-yyyy}", this.FromDate);
            tlblToDateValue.Text = string.Format("{0:dd-MMM-yyyy}", this.ToDate);
            tlblStudentValue.Text = this.StudentName;
            tlblPercValue.Text = hashtable["Perc"].ToString();
            tlblteacherValue.Text = hashtable["Teacher"].ToString();
            tlblsubjectValue.Text = hashtable["Subject"].ToString();

            StageThreeCalling();
        }
        else if (Convert.ToInt32(ViewState["Stage"].ToString()) == 3)
        {
            FirstRpt.Visible = true;
            secondRpt.Visible = false;
            thirdRpt.Visible = false;
            fourthRpt.Visible = true;
            //lblTitleFourth.Visible = true;
            //lblTitleThird.Visible = false;

            userControlDv.Visible = false;
            notusercontroldv.Visible = true;

            btnback.Visible = true;
            ViewState["Stage"] = 4;

            flblSchoolValue.Text = ddlSchool.SelectedItem.Text;
            flblBoardValue.Text = ddlBoard.SelectedItem.Text;
            flblMediumValue.Text = ddlMedium.SelectedItem.Text;


            // BMSSCTID StudentID,ExamDate,EmployeeID
            this.BMSSCTID = Convert.ToInt32(hashtable["BMSSCTID"].ToString());
            this.ExamDate = Convert.ToDateTime(hashtable["ExamDate"].ToString());
            DataSet ds = new DataSet();
            ReportsForResult objRsultReport = new ReportsForResult();

            ds = objRsultReport.BAL_SYS_ResultRPTByStudentDetails(this.StudentID, this.BMSSCTID, this.EmployeeID, this.ExamDate);

            int FirstTime = 1;
            if (ds.Tables.Count > 0)
            {
                if (FirstTime == 1)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        flblStandardValue.Text = ds.Tables[0].Rows[0]["Standard"].ToString();
                        flblsubjectValue.Text = ds.Tables[0].Rows[0]["Subject"].ToString();
                        flblChapterValue.Text = ds.Tables[0].Rows[0]["Chapter"].ToString();
                        flbltopicValue.Text = ds.Tables[0].Rows[0]["Topic"].ToString();
                        flblDateValue.Text = string.Format("{0:dd-MMM-yyyy}", Convert.ToDateTime(ViewState["ExamDate"].ToString()));
                        flblteacherValue.Text = ds.Tables[0].Rows[0]["Teacher"].ToString();
                        flblStudentValue.Text = ds.Tables[0].Rows[0]["FirstName"].ToString();
                        flblTrueAnsValue.Text = ds.Tables[0].Rows[0]["True"].ToString();
                        flblFalseAnsValue.Text = ds.Tables[0].Rows[0]["False"].ToString();
                        flblResultValue.Text = ds.Tables[0].Rows[0]["Perc"].ToString();

                        Label1.Text = ds.Tables[0].Rows[0]["True"].ToString();
                        Label2.Text = ds.Tables[0].Rows[0]["False"].ToString();
                        lblTotalQues.Text = (Convert.ToInt32(ds.Tables[0].Rows[0]["True"].ToString()) + Convert.ToInt32(ds.Tables[0].Rows[0]["False"].ToString())).ToString();
                        lbluserScoreValue.Text = Label1.Text + "/" + lblTotalQues.Text;
                    }
                    FirstTime = 0;
                }
                gvAnalysis.DataSource = ds.Tables[1];
                gvAnalysis.DataBind();
            }
            else
            {
                gvAnalysis.DataSource = null;
                gvAnalysis.DataBind();
            }

        }
    }

    private void StageThreeCalling()
    {
        DataSet ds = new DataSet();
        ReportsForResult objRsultReport = new ReportsForResult();
        ds = objRsultReport.BAL_SYS_ResultSubjectwiseFourth_Select(this.SchoolID, this.BMSID, this.SubjectID, this.EmployeeID, this.DivisionID, this.StudentID, this.FromDate, this.ToDate);


        CommanCallUserControl(ds, "../ReportXMLFiles/StudentWiseReportThird.xml");
    }

    private void CommanCallUserControl(DataSet ds, string reporttype)
    {
        GetConnectionStringSTRING obj = new GetConnectionStringSTRING();
        connectionstring = obj.BAL_EpathshalaString();



        try
        {
            WebUserControl1.ConnectionString = connectionstring;


            //reporttype = Server.MapPath("Files/MonthlySummary.xml");
            WebUserControl1.XMLReportFile = Server.MapPath(reporttype);

            WebUserControl1.Search(ds.Tables[0]);
            //WebUserControl1.Search(); 

        }
        catch (Exception ex)
        {
            WebMsg.Show("" + ex.Message.ToString());
        }
    }
    private void StageOneCalli()
    {
        DataSet ds = new DataSet();
        ReportsForResult objRsultReport = new ReportsForResult();

        ds = objRsultReport.BAL_SYS_ResultStudentwise_Select(Convert.ToInt32(ddlSchool.SelectedValue), Convert.ToInt32(ddlBoard.SelectedValue), Convert.ToInt32(ddlMedium.SelectedValue), Convert.ToInt32(ddlStandard.SelectedValue), Convert.ToInt32(ddlsubject.SelectedValue), Convert.ToInt32(ddlDivision.SelectedValue), Convert.ToDateTime(txtfromdate.Text), Convert.ToDateTime(txttodate.Text));

        GetConnectionStringSTRING obj = new GetConnectionStringSTRING();
        connectionstring = obj.BAL_EpathshalaString();
        WebUserControl1.Visible = true;
        CommanCallUserControl(ds, "../ReportXMLFiles/StudentWiseFirstReport.xml");
    }
    private void StageTwoCalling()
    {
        DataSet ds = new DataSet();
        ReportsForResult objRsultReport = new ReportsForResult();
        ds = objRsultReport.BAL_SYS_ResultStudentwiseSecond_Select(this.SchoolID, this.StudentID, this.BMSID, this.SubjectID, this.DivisionID, this.FromDate, this.ToDate);


        GetConnectionStringSTRING obj = new GetConnectionStringSTRING();
        connectionstring = obj.BAL_EpathshalaString();

        CommanCallUserControl(ds, "../ReportXMLFiles/StudentWiseReportSecond.xml");

        Chart1.Visible = true;
        BindChart(ds);
    }

    protected void BindChart(DataSet ds)
    {

        //DataSet ds = new DataSet();
        //ReportsForResult objRsultReport = new ReportsForResult();
        //ds = objRsultReport.BAL_SYS_ResultStudentwiseSecond_Select(this.SchoolID, this.StudentID, this.BMSID, this.SubjectID, this.DivisionID, this.FromDate, this.ToDate);

        DataTable dt = new DataTable();


        dt = ds.Tables[0];

        string[] x = new string[dt.Rows.Count];
        decimal[] y = new decimal[dt.Rows.Count];

        for (int i = 0; i < dt.Rows.Count; i++)
        {
            x[i] = dt.Rows[i][2].ToString();
            string perc = dt.Rows[i][3].ToString().Substring(0, dt.Rows[i][3].ToString().IndexOf("%"));
            y[i] = Convert.ToInt32(perc);
        }

        //BarChart1.Series.Add(new AjaxControlToolkit.BarChartSeries { Data = y });
        //BarChart1.CategoriesAxis = string.Join(",", x);
        Chart1.Series[0].Points.DataBindXY(x, y);
        Chart1.Series[0].ChartType = SeriesChartType.Column;
        Chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = false;
        //lblstudentname.Text = studentname;
        //Chart1.Legends[0].Enabled = true;
    }



    private void BindValuesToLabels()
    {
        slblSchoolValue.Text = ddlSchool.SelectedItem.Text;
        slblBoardValue.Text = ddlBoard.SelectedItem.Text;
        slblMediumValue.Text = ddlMedium.SelectedItem.Text;
        slblStandardValue.Text = this.Standard;
        slblstudentValue.Text = this.StudentName;
        slblPercValue.Text = this.Perc;
        //lblsubjectValue.Text = this.Subject;
        slblFromDateValue.Text = string.Format("{0:dd-MMM-yyyy}", this.FromDate);
        slblToDateValue.Text = string.Format("{0:dd-MMM-yyyy}", this.ToDate);
    }
    #region Property
    public string School
    {
        get
        {
            if (ViewState["School"] == null || ViewState["School"].ToString() == string.Empty)
            {
                return string.Empty;
            }
            else
            {
                return ViewState["School"].ToString();
            }
        }

        set
        {
            ViewState["School"] = value;
        }
    }
    public int SchoolID
    {
        get
        {
            if (ViewState["SchoolID"] == null || ViewState["SchoolID"].ToString() == string.Empty)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(ViewState["SchoolID"].ToString());
            }
        }

        set
        {
            ViewState["SchoolID"] = value;
        }
    }
    public string Perc
    {
        get
        {
            if (ViewState["Perc"] == null || ViewState["Perc"].ToString() == string.Empty)
            {
                return string.Empty;
            }
            else
            {
                return ViewState["Perc"].ToString();
            }
        }

        set
        {
            ViewState["Perc"] = value;
        }
    }
    public string Subject
    {
        get
        {
            if (ViewState["Subject"] == null || ViewState["Subject"].ToString() == string.Empty)
            {
                return string.Empty;
            }
            else
            {
                return ViewState["Subject"].ToString();
            }
        }

        set
        {
            ViewState["Subject"] = value;
        }
    }
    public int SubjectID
    {
        get
        {
            if (ViewState["SubjectID"] == null || ViewState["SubjectID"].ToString() == string.Empty)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(ViewState["SubjectID"].ToString());
            }
        }

        set
        {
            ViewState["SubjectID"] = value;
        }
    }
    public string Board
    {
        get
        {
            if (ViewState["Board"] == null || ViewState["Board"].ToString() == string.Empty)
            {
                return string.Empty;
            }
            else
            {
                return ViewState["Board"].ToString();
            }
        }

        set
        {
            ViewState["Board"] = value;
        }
    }
    public string Medium
    {
        get
        {
            if (ViewState["Medium"] == null || ViewState["Medium"].ToString() == string.Empty)
            {
                return string.Empty;
            }
            else
            {
                return ViewState["Medium"].ToString();
            }
        }

        set
        {
            ViewState["Medium"] = value;
        }
    }
    public string Standard
    {
        get
        {
            if (ViewState["Standard"] == null || ViewState["Standard"].ToString() == string.Empty)
            {
                return string.Empty;
            }
            else
            {
                return ViewState["Standard"].ToString();
            }
        }

        set
        {
            ViewState["Standard"] = value;
        }
    }
    public int BMSID
    {
        get
        {
            if (ViewState["BMSID"] == null || ViewState["BMSID"].ToString() == string.Empty)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(ViewState["BMSID"].ToString());
            }
        }

        set
        {
            ViewState["BMSID"] = value;
        }
    }
    public int StudentID
    {
        get
        {
            if (ViewState["StudentID"] == null || ViewState["StudentID"].ToString() == string.Empty)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(ViewState["StudentID"].ToString());
            }
        }

        set
        {
            ViewState["StudentID"] = value;
        }
    }
    public string StudentName
    {
        get
        {
            if (ViewState["StudentName"] == null || ViewState["StudentName"].ToString() == string.Empty)
            {
                return string.Empty;
            }
            else
            {
                return ViewState["StudentName"].ToString();
            }
        }

        set
        {
            ViewState["StudentName"] = value;
        }
    }
    public int DivisionID
    {
        get
        {
            if (ViewState["DivisionID"] == null || ViewState["DivisionID"].ToString() == string.Empty)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(ViewState["DivisionID"].ToString());
            }
        }

        set
        {
            ViewState["DivisionID"] = value;
        }
    }
    public DateTime FromDate
    {
        get
        {
            if (ViewState["FromDate"] == null || ViewState["FromDate"].ToString() == string.Empty)
            {
                return DateTime.Now.Date;
            }
            else
            {
                return Convert.ToDateTime(ViewState["FromDate"].ToString());
            }
        }

        set
        {
            ViewState["FromDate"] = value;
        }
    }
    public DateTime ToDate
    {
        get
        {
            if (ViewState["ToDate"] == null || ViewState["ToDate"].ToString() == string.Empty)
            {
                return DateTime.Now.Date;
            }
            else
            {
                return Convert.ToDateTime(ViewState["ToDate"].ToString());
            }
        }

        set
        {
            ViewState["ToDate"] = value;
        }
    }
    public int EmployeeID
    {
        get
        {
            if (ViewState["EmployeeID"] == null || ViewState["EmployeeID"].ToString() == string.Empty)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(ViewState["EmployeeID"].ToString());
            }
        }

        set
        {
            ViewState["EmployeeID"] = value;
        }
    }
    public string Employee
    {
        get
        {
            if (ViewState["Employee"] == null || ViewState["Employee"].ToString() == string.Empty)
            {
                return string.Empty;
            }
            else
            {
                return ViewState["Employee"].ToString();
            }
        }

        set
        {
            ViewState["Employee"] = value;
        }
    }
    public int BMSSCTID
    {
        get
        {
            if (ViewState["BMSSCTID"] == null || ViewState["BMSSCTID"].ToString() == string.Empty)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(ViewState["BMSSCTID"].ToString());
            }
        }

        set
        {
            ViewState["BMSSCTID"] = value;
        }
    }
    public DateTime ExamDate
    {
        get
        {
            if (ViewState["ExamDate"] == null || ViewState["ExamDate"].ToString() == string.Empty)
            {
                return DateTime.Now.Date;
            }
            else
            {
                return Convert.ToDateTime(ViewState["ExamDate"].ToString());
            }
        }

        set
        {
            ViewState["ExamDate"] = value;
        }
    }
    #endregion


    #region ControlEvents
    protected void gvAnalysis_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Literal ltQuestion = (Literal)e.Row.FindControl("ltQuestion");
                Literal lblSolution = (Literal)e.Row.FindControl("lblSolution");
                Literal Option1 = (Literal)e.Row.FindControl("Option1");
                Literal Option2 = (Literal)e.Row.FindControl("Option2");
                Literal Option3 = (Literal)e.Row.FindControl("Option3");
                Literal Option4 = (Literal)e.Row.FindControl("Option4");

                ltQuestion.Text = HttpUtility.HtmlDecode(DataBinder.Eval(e.Row.DataItem, "Question").ToString());
                lblSolution.Text = HttpUtility.HtmlDecode(DataBinder.Eval(e.Row.DataItem, "Solution").ToString());

                Option1.Text = "<div style=\"";
                if (DataBinder.Eval(e.Row.DataItem, "Option1ID").ToString() == DataBinder.Eval(e.Row.DataItem, "AnswerID").ToString())
                {
                    Option1.Text = Option1.Text + "color:Red;";
                }
                if (DataBinder.Eval(e.Row.DataItem, "Option1ID").ToString() == DataBinder.Eval(e.Row.DataItem, "GivenAnswerID").ToString())
                {
                    Option1.Text = Option1.Text + "background-color:#ABBCAB;";
                }
                Option1.Text = Option1.Text + "min-width:20px\">A. " + HttpUtility.HtmlDecode(DataBinder.Eval(e.Row.DataItem, "Option1").ToString()) + "</div>";

                Option2.Text = "<div style=\"";
                if (DataBinder.Eval(e.Row.DataItem, "Option2ID").ToString() == DataBinder.Eval(e.Row.DataItem, "AnswerID").ToString())
                {
                    Option2.Text = Option2.Text + "color:Red;";
                }
                if (DataBinder.Eval(e.Row.DataItem, "Option2ID").ToString() == DataBinder.Eval(e.Row.DataItem, "GivenAnswerID").ToString())
                {
                    Option2.Text = Option2.Text + "background-color:#ABBCAB;";
                }
                Option2.Text = Option2.Text + "min-width:20px\">B. " + HttpUtility.HtmlDecode(DataBinder.Eval(e.Row.DataItem, "Option2").ToString()) + "</div>";


                Option3.Text = "<div style=\"";
                if (DataBinder.Eval(e.Row.DataItem, "Option3ID").ToString() == DataBinder.Eval(e.Row.DataItem, "AnswerID").ToString())
                {
                    Option3.Text = Option3.Text + "color:Red;";
                }
                if (DataBinder.Eval(e.Row.DataItem, "Option3ID").ToString() == DataBinder.Eval(e.Row.DataItem, "GivenAnswerID").ToString())
                {
                    Option3.Text = Option3.Text + "background-color:#ABBCAB;";
                }
                Option3.Text = Option3.Text + "min-width:20px\">C. " + HttpUtility.HtmlDecode(DataBinder.Eval(e.Row.DataItem, "Option3").ToString()) + "</div>";

                Option4.Text = "<div style=\"";
                if (DataBinder.Eval(e.Row.DataItem, "Option4ID").ToString() == DataBinder.Eval(e.Row.DataItem, "AnswerID").ToString())
                {
                    Option4.Text = Option4.Text + "color:Red;";
                }
                if (DataBinder.Eval(e.Row.DataItem, "Option4ID").ToString() == DataBinder.Eval(e.Row.DataItem, "GivenAnswerID").ToString())
                {
                    Option4.Text = Option4.Text + "background-color:#ABBCAB;";
                }
                Option4.Text = Option4.Text + "min-width:20px\">D. " + HttpUtility.HtmlDecode(DataBinder.Eval(e.Row.DataItem, "Option4").ToString()) + "</div>";

            }
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message.ToString());
        }
        finally
        {
        }
    }
    //protected void ImgBtnBack_Click(object sender, ImageClickEventArgs e)
    //{

    //    if (Session["SubjectWiseReport5To4"] != null)
    //    {
    //        Response.Redirect(Session["SubjectWiseReport5To4"].ToString());
    //    }
    //}
    #endregion
    protected void btnback_Click(object sender, EventArgs e)
    {
        if (Convert.ToInt32(ViewState["Stage"].ToString()) == 2)
        {
            FirstRpt.Visible = true;
            secondRpt.Visible = false;
            thirdRpt.Visible = false;
            fourthRpt.Visible = false;
            lblTitleFirst.Visible = true;
            lblTitleSecond.Visible = false;

            btnback.Visible = false;
            //WebUserControl1.XMLReportFile = Server.MapPath("../ReportXMLFiles/StudentWiseFirstReport.xml");

            ViewState["Stage"] = 1;
            StageOneCalli();
        }
        else if (Convert.ToInt32(ViewState["Stage"].ToString()) == 3)
        {
            FirstRpt.Visible = true;
            secondRpt.Visible = true;
            thirdRpt.Visible = false;
            fourthRpt.Visible = false;
            btnback.Visible = true;

            lblTitleSecond.Visible = true;
            lblTitleThird.Visible = false;
            //WebUserControl1.XMLReportFile = Server.MapPath("../ReportXMLFiles/StudentWiseReportSecond.xml");

            ViewState["Stage"] = 2;
            StageTwoCalling();
        }
        else if (Convert.ToInt32(ViewState["Stage"].ToString()) == 4)
        {
            FirstRpt.Visible = true;
            secondRpt.Visible = false;
            thirdRpt.Visible = true;
            fourthRpt.Visible = false;
            btnback.Visible = true;
            lblTitleThird.Visible = true;
            lblTitleFourth.Visible = false;

            userControlDv.Visible = true;
            notusercontroldv.Visible = false;

            ViewState["Stage"] = 3;
            StageThreeCalling();
        }

    }
}