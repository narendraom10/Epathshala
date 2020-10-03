using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
using Udev.UserMasterPage.Classes;
using System.Globalization;

public partial class Report_SchoolExamReports : System.Web.UI.Page
{
    #region Variables
    School_BLogic SchoolBLogic;
    string connectionstring;
    #endregion
    protected override void InitializeCulture()
    {
        string culture = Convert.ToString(Session[Global.SESSION_KEY_CULTURE]);
        // 'set culture to current thread 
        System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture);
        System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);
        //call base class 
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
    private void BindAllDDLSchool()
    {
        SchoolBLogic = new School_BLogic();
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
        ds = objSys_Board.BAL_SYS_StdSubChapTopic_BySchoolIDBoardIDMediumid(Convert.ToInt32(ddlSchool.SelectedValue), Convert.ToInt32(ddlBoard.SelectedValue), Convert.ToInt32(ddlMedium.SelectedValue), Convert.ToInt32(ddlStandard.SelectedValue), Convert.ToInt32(ddlsubject.SelectedValue), Convert.ToInt32(ddlchapter.SelectedValue));

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
                DDLDisable(ddlchapter, true);
                DDLDisable(ddltopic, true);
            }
        }
        if (Step <= 3)
        {
            if (ds.Tables.Count > 2)
            {
                DdlFilling.BindDropDownByTable(ddlchapter, ds.Tables[2], "Chapter", "ChapterID");
                DDLDisable(ddlchapter, true);
                DDLDisable(ddltopic, true);
            }
        }
        if (Step <= 4)
        {
            if (ds.Tables.Count > 3)
            {
                DdlFilling.BindDropDownByTable(ddltopic, ds.Tables[3], "Topic", "TopicID");
                DDLDisable(ddltopic, true);
            }
        }





    }
    #endregion
    #region "Control Events"
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
            DDLDisable(ddltopic, false);
            DDLDisable(ddlchapter, false);
        }
        else
        {
            DDLDisable(ddlBoard, false);
            DDLDisable(ddlMedium, false);
            DDLDisable(ddlStandard, false);
            DDLDisable(ddlsubject, false);
            DDLDisable(ddltopic, false);
            DDLDisable(ddlchapter, false);
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
            DDLDisable(ddltopic, false);
            DDLDisable(ddlchapter, false);
        }
        else
        {

            DDLDisable(ddlMedium, false);
            DDLDisable(ddlStandard, false);
            DDLDisable(ddlsubject, false);
            DDLDisable(ddltopic, false);
            DDLDisable(ddlchapter, false);
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
            DDLDisable(ddltopic, false);
            DDLDisable(ddlchapter, false);
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
    protected void ddlchapter_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindSubjectChapterTopic(4);
    }
    protected void ddltopic_SelectedIndexChanged(object sender, EventArgs e)
    {
        //BindSubjectChapterTopic(5);
    }
    #endregion
    protected void btnview_Click(object sender, EventArgs e)
    {
        StageOneCalli();
    }

    private void StageOneCalli()
    {
        ViewState["Stage"] = 1;
        ReportControl1.Visible = true;
        DataSet ds = new DataSet();
        ReportsForResult objRsultReport = new ReportsForResult();

        ds = objRsultReport.BAL_SYS_ResultClassroomwise_Select(Convert.ToInt32(ddlSchool.SelectedValue), Convert.ToInt32(ddlBoard.SelectedValue), Convert.ToInt32(ddlMedium.SelectedValue), Convert.ToInt32(ddlStandard.SelectedValue), Convert.ToInt32(ddlsubject.SelectedValue), Convert.ToInt32(ddlchapter.SelectedValue), Convert.ToInt32(ddltopic.SelectedValue), Convert.ToDateTime(txtfromdate.Text), Convert.ToDateTime(txttodate.Text));
        CommanCallUserControl(ds, "../ReportXMLFiles/SchoolExamReports.xml");
    }
    private void CommanCallUserControl(DataSet ds, string reporttype)
    {
        GetConnectionStringSTRING obj = new GetConnectionStringSTRING();
        connectionstring = obj.BAL_EpathshalaString();



        try
        {
            ReportControl1.ConnectionString = connectionstring;


            //reporttype = Server.MapPath("Files/MonthlySummary.xml");
            ReportControl1.XMLReportFile = Server.MapPath(reporttype);

            ReportControl1.Search(ds.Tables[0]);

        }
        catch (Exception ex)
        {
            WebMsg.Show("" + ex.Message.ToString());
        }
    }
    protected void btnback_Click(object sender, EventArgs e)
    {
        if (Convert.ToInt32(ViewState["Stage"].ToString()) == 2)
        {
            FirstRpt.Visible = true;
            secondRpt.Visible = false;
            thirdRpt.Visible = false;

            lblTitleFirst.Visible = true;
            lblTitleSecond.Visible = false;

            btnback.Visible = false;
            ViewState["Stage"] = 1;
            StageOneCalli();
        }
        else if (Convert.ToInt32(ViewState["Stage"].ToString()) == 3)
        {
            FirstRpt.Visible = true;
            secondRpt.Visible = true;
            thirdRpt.Visible = false;

            btnback.Visible = true;
            notusercontroldv.Visible = false;
            userControlDv.Visible = true;

            lblTitleSecond.Visible = true;
            lblTitleThird.Visible = false;

            ViewState["Stage"] = 2;
            StageTwoCalling();
        }

    }
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
    private void StageTwoCalling()
    {
        DataSet ds = new DataSet();
        ReportsForResult objRsultReport = new ReportsForResult();

        ds = objRsultReport.BAL_SYS_ResultClassroomwiseByFirRPT_Select(this.SchoolID, this.BMSSCTID, this.EmployeeID, this.DivisionID, this.ExamDate);

        GetConnectionStringSTRING obj = new GetConnectionStringSTRING();
        connectionstring = obj.BAL_EpathshalaString();

        CommanCallUserControl(ds, "../ReportXMLFiles/SchoolExamReportsSec.xml");
    }
    public void Displayselecteddata(Hashtable hashtable, object objsender)
    {

        if (Convert.ToInt32(ViewState["Stage"].ToString()) == 1)
        {
            FirstRpt.Visible = true;
            secondRpt.Visible = true;
            thirdRpt.Visible = false;


            btnback.Visible = true;
            ViewState["Stage"] = 2;
            lblTitleSecond.Visible = true;
            lblTitleFirst.Visible = true;

            slblSchoolValue.Text = ddlSchool.SelectedItem.Text;
            slblBoardValue.Text = ddlBoard.SelectedItem.Text;
            slblMediumValue.Text = ddlMedium.SelectedItem.Text;

            slblStandardValue.Text = hashtable["Standard"].ToString();
            slblsubjectValue.Text = hashtable["Subject"].ToString();
            slblChapterValue.Text = hashtable["Chapter"].ToString();
            slbltopicValue.Text = hashtable["Topic"].ToString();
            slblteacherValue.Text = hashtable["Teacher"].ToString();
            slblDateValue.Text = hashtable["ExamDate"].ToString();
            this.SchoolID = Convert.ToInt32(ddlSchool.SelectedValue);
            this.BMSSCTID = Convert.ToInt32(hashtable["BMSSCTID"].ToString());
            this.EmployeeID = Convert.ToInt32(hashtable["EmployeeID"].ToString());
            this.DivisionID = Convert.ToInt32(hashtable["DivisionID"].ToString());
            this.ExamDate = Convert.ToDateTime(hashtable["ExamDate"].ToString());
            //ds = objRsultReport.BAL_SYS_ResultClassroomwiseByFirRPT_Select(this.SchoolID, this.BMSSCTID, this.EmployeeID, this.DivisionID, this.ExamDate);
            StageTwoCalling();
        }
        else if (Convert.ToInt32(ViewState["Stage"].ToString()) == 2)
        {
            FirstRpt.Visible = true;
            secondRpt.Visible = false;
            thirdRpt.Visible = true;

            lblTitleThird.Visible = true;
            lblTitleSecond.Visible = false;

            btnback.Visible = true;
            ViewState["Stage"] = 3;


            tlblSchoolValue.Text = ddlSchool.SelectedItem.Text;
            tlblBoardValue.Text = ddlBoard.SelectedItem.Text;
            tlblMediumValue.Text = ddlMedium.SelectedItem.Text;
            notusercontroldv.Visible = true;
            userControlDv.Visible = false;

            // BMSSCTID StudentID,ExamDate,EmployeeID
            this.BMSSCTID = Convert.ToInt32(hashtable["BMSSCTID"].ToString());
            this.StudentID = Convert.ToInt32(hashtable["StudentID"].ToString());
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
                        tlblStandardValue.Text = ds.Tables[0].Rows[0]["Standard"].ToString();
                        tlblsubjectValue.Text = ds.Tables[0].Rows[0]["Subject"].ToString();
                        tlblChapterValue.Text = ds.Tables[0].Rows[0]["Chapter"].ToString();
                        tlbltopicValue.Text = ds.Tables[0].Rows[0]["Topic"].ToString();
                        tlblDateValue.Text = string.Format("{0:dd-MMM-yyyy}", Convert.ToDateTime(ViewState["ExamDate"].ToString()));
                        tlblteacherValue.Text = ds.Tables[0].Rows[0]["Teacher"].ToString();
                        tlblStudentValue.Text = ds.Tables[0].Rows[0]["FirstName"].ToString();
                        tlblTrueAnsValue.Text = ds.Tables[0].Rows[0]["True"].ToString();
                        tlblFalseAnsValue.Text = ds.Tables[0].Rows[0]["False"].ToString();
                        tlblResultValue.Text = ds.Tables[0].Rows[0]["Perc"].ToString();

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
    #region Property
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
    #endregion

}