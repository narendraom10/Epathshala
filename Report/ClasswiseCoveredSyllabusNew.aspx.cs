/// <summary>
/// <Description>Covered Syllabus Report</Description>
/// <DevelopedBy>"Bhavesh Prajapati</DevelopedBy>
/// <DevelopedDate>"24 May 2014"</DevelopedDate>
/// <UpdatedBy></UpdatedBy>
/// <UpdatedDate></UpdatedDate>
/// </summary>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
using System.Globalization;
using Udev.UserMasterPage.Classes;

public partial class Report_ClasswiseCoveredSyllabusNew : System.Web.UI.Page
{
    #region "Declaration"

    ClasswiseCoveredSyllabus obj_Dal_ClasswiseCoveredSyllabus;
    DropDownFill DdlFilling;
    School_BLogic SchoolBLogic = new School_BLogic();
    SYS_Division_BLogic DivisionBLogic = new SYS_Division_BLogic();
    string connectionstring;
    #endregion

    #region "Page Load"
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillSchoolDropdown(ddlSchool);
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

    #region "User Defined Functions"
    private void FillSchoolDropdown(DropDownList ddlSchool)
    {
        SchoolBLogic = new School_BLogic();
        DataTable dt = new DataTable();
        dt = SchoolBLogic.BAL_SchoolAllNameWithID("Normal").Tables[0];
        if (dt != null)
        {
            if (dt.Rows.Count > 0)
            {
                DdlFilling = new DropDownFill();
                DdlFilling.BindDropDownByTable(ddlSchool, dt, "Name", "SchoolID");
                ddlSchool.Items.Insert(Convert.ToInt32(EnumFile.AssignValue.Zero), "-- Select --");
                ddlSchool.Items[0].Value = Convert.ToString((int)EnumFile.AssignValue.Zero);
            }
        }
    }
    private void ddlDisable(DropDownList dropdown, bool status)
    {
        dropdown.Enabled = status;
        dropdown.SelectedIndex = 0;
    }
    private void BindSubjectChapterTopic(int Step)
    {

        DataSet ds = new DataSet();

        SYS_Board_BLogic objSys_Board = new SYS_Board_BLogic();
        ds = objSys_Board.BAL_SYS_StdSubChapTopic_BySchoolIDBoardIDMediumid(Convert.ToInt32(ddlSchool.SelectedValue), Convert.ToInt32(ddlBoard.SelectedValue), Convert.ToInt32(ddlMedium.SelectedValue), Convert.ToInt32(ddlStandard.SelectedValue), Convert.ToInt32(ddlSubject.SelectedValue), Convert.ToInt32(ddlChapter.SelectedValue));

        DdlFilling = new DropDownFill();
        if (Step <= 1)
        {
            if (ds.Tables.Count > 0)
            {
                DdlFilling.BindDropDownByTable(ddlStandard, ds.Tables[0], "Standard", "StandardID");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ddlStandard.Items.Insert(Convert.ToInt32(EnumFile.AssignValue.Zero), "-- Select --");
                    ddlStandard.Items[0].Value = Convert.ToString((int)EnumFile.AssignValue.Zero);
                }
            }
        }
        if (Step <= 2)
        {
            if (ds.Tables.Count > 1)
            {
                DdlFilling.BindDropDownByTable(ddlSubject, ds.Tables[1], "Subject", "SubjectID");
                if (ds.Tables[1].Rows.Count > 0)
                {
                    ddlSubject.Items.Insert(Convert.ToInt32(EnumFile.AssignValue.Zero), "-- Select --");
                    ddlSubject.Items[0].Value = Convert.ToString((int)EnumFile.AssignValue.Zero);
                }
            }
        }
        if (Step <= 3)
        {
            if (ds.Tables.Count > 2)
            {
                DdlFilling.BindDropDownByTable(ddlChapter, ds.Tables[2], "Chapter", "ChapterID");
                if (ds.Tables[2].Rows.Count > 0)
                {
                    ddlChapter.Items.Insert(Convert.ToInt32(EnumFile.AssignValue.Zero), "-- Select --");
                    ddlChapter.Items[0].Value = Convert.ToString((int)EnumFile.AssignValue.Zero);
                }
            }
        }
        if (Step <= 4)
        {
            if (ds.Tables.Count > 3)
            {
                DdlFilling.BindDropDownByTable(ddlTopic, ds.Tables[3], "Topic", "TopicID");
                if (ds.Tables[3].Rows.Count > 0)
                {
                    ddlTopic.Items.Insert(Convert.ToInt32(EnumFile.AssignValue.Zero), "-- Select --");
                    ddlTopic.Items[0].Value = Convert.ToString((int)EnumFile.AssignValue.Zero);
                }
            }
        }
    }
    private void BindDivision(DropDownList ddlDivision)
    {
        int StandardID;
        if (ddlStandard.SelectedIndex != 0)
        {
            StandardID = Convert.ToInt32(null);
        }
        else
        {
            StandardID = Convert.ToInt32(ddlStandard.SelectedValue);
        }
        DivisionBLogic = new SYS_Division_BLogic();
        DataSet dsResult = new DataSet();
        dsResult = DivisionBLogic.BAL_SYS_Division_SelectByBMSID(Convert.ToInt32(ddlBoard.SelectedValue), Convert.ToInt32(ddlMedium.SelectedValue), StandardID, Convert.ToInt32(Session["SchoolID"]));

        DdlFilling = new DropDownFill();
        DdlFilling.BindDropDownByTable(ddlDivision, dsResult.Tables[0], "Division", "DivisionID");
        ddlDivision.Items.Insert(Convert.ToInt32(EnumFile.AssignValue.Zero), "-- Select --");
        ddlDivision.Items[0].Value = Convert.ToString((int)EnumFile.AssignValue.Zero);

    }
    private void BindDataToGrid()
    {
        ViewState["Stage"] = 1;
        StageOneCalling();
    }
    private void StageOneCalling()
    {
        DataSet dtResult = new DataSet();
        this.obj_Dal_ClasswiseCoveredSyllabus = new ClasswiseCoveredSyllabus();
        dtResult = this.obj_Dal_ClasswiseCoveredSyllabus.GetClasswiseCoveredDetails(Convert.ToInt32(ddlSchool.SelectedValue), Convert.ToInt32(ddlBoard.SelectedValue), Convert.ToInt32(ddlMedium.SelectedValue), Convert.ToInt32(ddlDivision.SelectedValue), Convert.ToInt32(ddlStandard.SelectedValue), Convert.ToInt32(ddlSubject.SelectedValue), Convert.ToInt32(ddlChapter.SelectedValue), Convert.ToInt32(ddlTopic.SelectedValue));

        GetConnectionStringSTRING obj = new GetConnectionStringSTRING();
        connectionstring = obj.BAL_EpathshalaString();

        ClasswiseSyllabusGrid.XMLReportFile = Server.MapPath("../ReportXMLFiles/ClasswiseCoveredSyllabus.xml");
        ClasswiseSyllabusGrid.Search(dtResult.Tables[0]);
        CurrentReport = "Classwise Report";
        ClasswiseSyllabusGrid.Visible = true;
        //CommanCallUserControl(dtResult, "../ReportXMLFiles/ClasswiseCoveredSyllabus.xml");
    }
    private void StageTwoCalling()
    {
        DataSet dsResult = new DataSet();
        this.obj_Dal_ClasswiseCoveredSyllabus = new ClasswiseCoveredSyllabus();
        dsResult = obj_Dal_ClasswiseCoveredSyllabus.SelectBMS(this.BMSID);
        this.BoardID = Convert.ToInt32(dsResult.Tables[0].Rows[0]["BoardID"]);
        this.MediumID = Convert.ToInt32(dsResult.Tables[0].Rows[0]["MediumID"]);
        this.StandardID = Convert.ToInt32(dsResult.Tables[0].Rows[0]["StandardID"]);

        dsResult = new DataSet();
        this.obj_Dal_ClasswiseCoveredSyllabus = new ClasswiseCoveredSyllabus();
        dsResult = this.obj_Dal_ClasswiseCoveredSyllabus.GetSubjectwiseCoveredDetails(this.BMSID, this.SchoolID, this.DivisionID);

        GetConnectionStringSTRING obj = new GetConnectionStringSTRING();
        connectionstring = obj.BAL_EpathshalaString();

        SubjectwiseSyllabusGrid.XMLReportFile = Server.MapPath("../ReportXMLFiles/SubjectwiseCoveredSyllabus.xml");
        SubjectwiseSyllabusGrid.Search(dsResult.Tables[0]);
        CurrentReport = "Subjectwise Report";
        //CommanCallUserControl(dsResult, "../ReportXMLFiles/SubjectwiseCoveredSyllabus.xml");
    }
    private void StageThreeCalling()
    {
        obj_Dal_ClasswiseCoveredSyllabus = new ClasswiseCoveredSyllabus();
        DataSet dsResult = new DataSet();

        dsResult = obj_Dal_ClasswiseCoveredSyllabus.GetChapterwiseCoveredSyllabusDetails(this.BMSID, this.SubjectID, this.DivisionID, this.SchoolID);

        GetConnectionStringSTRING obj = new GetConnectionStringSTRING();
        connectionstring = obj.BAL_EpathshalaString();

        ChapterwiseSyllabusGrid.XMLReportFile = Server.MapPath("../ReportXMLFiles/ChapterwiseCoveredSyllabus.xml");
        ChapterwiseSyllabusGrid.Search(dsResult.Tables[0]);
        CurrentReport = "Chapterwise Report";
        //CommanCallUserControl(dsResult, "../ReportXMLFiles/ChapterwiseCoveredSyllabus.xml");
    }
    private void StageForthCalling()
    {
        obj_Dal_ClasswiseCoveredSyllabus = new ClasswiseCoveredSyllabus();
        DataSet dsResult = new DataSet();

        dsResult = obj_Dal_ClasswiseCoveredSyllabus.GetTopicwiseCoveredSyllavbus(this.BMSID, this.SubjectID, this.DivisionID, this.SchoolID, this.ChapterID);

        GetConnectionStringSTRING obj = new GetConnectionStringSTRING();
        connectionstring = obj.BAL_EpathshalaString();

        TopicwiseSyllabusGrid.XMLReportFile = Server.MapPath("../ReportXMLFiles/TopicwiseCoveredSyllabus.xml");
        TopicwiseSyllabusGrid.Search(dsResult.Tables[0]);
        CurrentReport = "Topicwise Report";
        //CommanCallUserControl(dsResult, "../ReportXMLFiles/TopicwiseCoveredSyllabus.xml");
    }
    private void CommanCallUserControl(DataSet dtResult, string reporttype)
    {
        GetConnectionStringSTRING obj = new GetConnectionStringSTRING();
        connectionstring = obj.BAL_EpathshalaString();
        try
        {
            ClasswiseSyllabusGrid.ConnectionString = connectionstring;
            ClasswiseSyllabusGrid.XMLReportFile = Server.MapPath(reporttype);
            ClasswiseSyllabusGrid.Search(dtResult.Tables[0]);
        }
        catch (Exception ex)
        {
            WebMsg.Show("" + ex.Message.ToString());
        }
    }
    public void Displayselecteddata(Hashtable hashtable, object objsender)
    {
        ReportControl rpt = (ReportControl)objsender;

        if (rpt.ID == "ClasswiseSyllabusGrid")
        {
            ClasswiseReport.Visible = true;
            SubjectwiseReport.Visible = true;
            ChapterwiseReport.Visible = false;
            TopicwiseReport.Visible = false;

            btnBack.Visible = true;
            lblFirstTitle.Visible = true;
            lblSecondTitle.Visible = true;
            lblThirdTitle.Visible = false;
            lblForthTitle.Visible = false;
            ClasswiseSyllabusGrid.Visible = false;
            SubjectwiseSyllabusGrid.Visible = true;
            ChapterwiseSyllabusGrid.Visible = false;
            TopicwiseSyllabusGrid.Visible = false;
            BindFieldIDFromDropDown();
            BindDivLableValues(hashtable);
            this.SchoolID = Convert.ToInt32(hashtable["SchoolID"]);
            this.BMSID = Convert.ToInt32(hashtable["BMSID"]);
            this.DivisionID = Convert.ToInt32(hashtable["DivisionID"]);
            StageTwoCalling();
        }
        else if (rpt.ID == "SubjectwiseSyllabusGrid")
        {
            ClasswiseReport.Visible = true;
            SubjectwiseReport.Visible = false;
            ChapterwiseReport.Visible = true;
            TopicwiseReport.Visible = false;
            lblFirstTitle.Visible = true;
            lblSecondTitle.Visible = false;
            lblThirdTitle.Visible = true;
            lblForthTitle.Visible = false;
            ClasswiseSyllabusGrid.Visible = false;
            SubjectwiseSyllabusGrid.Visible = false;
            ChapterwiseSyllabusGrid.Visible = true;
            TopicwiseSyllabusGrid.Visible = false;
            btnBack.Visible = true;

            lblSubjectValueThird.Text = hashtable["Subject"].ToString();
            lblCoveredSyllabusValueThird.Text = hashtable["SyllabusCovered"].ToString() + " %";
            lblSubjectValueForth.Text = hashtable["Subject"].ToString();
            this.SubjectID = Convert.ToInt32(hashtable["SubjectID"]);

            StageThreeCalling();
        }
        else if (rpt.ID == "ChapterwiseSyllabusGrid")
        {

            ClasswiseReport.Visible = true;
            SubjectwiseReport.Visible = false;
            ChapterwiseReport.Visible = false;
            TopicwiseReport.Visible = true;
            lblFirstTitle.Visible = true;
            lblSecondTitle.Visible = false;
            lblThirdTitle.Visible = false;
            lblForthTitle.Visible = true;
            ClasswiseSyllabusGrid.Visible = false;
            SubjectwiseSyllabusGrid.Visible = false;
            ChapterwiseSyllabusGrid.Visible = false;
            TopicwiseSyllabusGrid.Visible = true;

            this.ChapterID = Convert.ToInt32(hashtable["ChapterID"]);
            lblChapterValueForth.Text = hashtable["Chapter"].ToString();
            lblCoveredSyllabusValueForth.Text = hashtable["Percentage"].ToString() + " %";
            StageForthCalling();
        }
        else if (rpt.ID == "TopicwiseSyllabusGrid")
        {
            StageForthCalling();
        }
    }
    private void BindFieldIDFromDropDown()
    {
        this.SchoolID = Convert.ToInt32(ddlSchool.SelectedValue.ToString());
        this.BoardID = Convert.ToInt32(ddlBoard.SelectedValue.ToString());
        this.MediumID = Convert.ToInt32(ddlMedium.SelectedValue.ToString());
        this.StandardID = Convert.ToInt32(ddlStandard.SelectedValue.ToString());
        this.SubjectID = Convert.ToInt32(ddlSubject.SelectedValue.ToString());
        this.ChapterID = Convert.ToInt32(ddlChapter.SelectedValue.ToString());
        this.TopicID = Convert.ToInt32(ddlTopic.SelectedValue.ToString());
        this.DivisionID = Convert.ToInt32(ddlDivision.SelectedValue.ToString());
    }
    private void BindDivLableValues(Hashtable HashTable)
    {
        lblSchoolValueSecond.Text = ddlSchool.SelectedItem.Text;
        lblBMSValueSecond.Text = HashTable["BMS"].ToString();
        lblDivValueSecond.Text = HashTable["Division"].ToString();
        lblCoveredSyllabusValueSecond.Text = HashTable["SyllabusCovered"].ToString() + " %";
        lblSchoolValueThird.Text = ddlSchool.SelectedItem.Text;
        lblBMSValueThird.Text = HashTable["BMS"].ToString();
        lblDivValueThird.Text = HashTable["Division"].ToString();
        lblSchoolValueForth.Text = ddlSchool.SelectedItem.Text;
        lblBMSValueForth.Text = HashTable["BMS"].ToString();
        lblDivValueForth.Text = HashTable["Division"].ToString();
    }
    #endregion

    #region "Controls Events"
    protected void ddlSchool_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSchool.SelectedIndex != 0)
        {
            DataSet ds = new DataSet();

            SYS_Board_BLogic objSys_Board = new SYS_Board_BLogic();
            ds = objSys_Board.BAL_SYS_Board_BySchoolID(Convert.ToInt32(ddlSchool.SelectedValue));

            DropDownFill DdlFilling = new DropDownFill();
            ddlDisable(ddlBoard, true);
            DdlFilling.BindDropDownByTable(ddlBoard, ds.Tables[0], "Board", "BoardID");
            ddlBoard.Items.Insert(Convert.ToInt32(EnumFile.AssignValue.Zero), "-- Select --");
            ddlBoard.Items[0].Value = Convert.ToString((int)EnumFile.AssignValue.Zero);
            Session["ReportSchoolID"] = Convert.ToInt32(ddlSchool.SelectedValue);
            Session["ReportSchoolName"] = ddlSchool.SelectedItem.ToString();
            ddlDisable(ddlBoard, true);
            ddlDisable(ddlMedium, false);
            ddlDisable(ddlStandard, true);
            ddlDisable(ddlSubject, true);
            ddlDisable(ddlSubject, true);
            ddlDisable(ddlDivision, true);
        }
        else
        {
            ddlDisable(ddlBoard, false);
            ddlDisable(ddlMedium, false);
            ddlDisable(ddlStandard, false);
            ddlDisable(ddlSubject, false);
            ddlDisable(ddlSubject, false);
            ddlDisable(ddlChapter, false);
            ddlDisable(ddlTopic, false);
            ddlDisable(ddlDivision, false);
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
            ddlMedium.Items.Insert(Convert.ToInt32(EnumFile.AssignValue.Zero), "-- Select --");
            ddlMedium.Items[0].Value = Convert.ToString((int)EnumFile.AssignValue.Zero);
            ddlDisable(ddlMedium, true);
            //ddlMedium.Items[0].Value = Convert.ToString((int)EnumFile.AssignValue.Zero);
        }
        else
        {
            ddlDisable(ddlMedium, false);
            ddlDisable(ddlStandard, false);
            ddlDisable(ddlSubject, false);
            ddlDisable(ddlChapter, false);
            ddlDisable(ddlTopic, false);
            ddlDisable(ddlDivision, false);
        }
    }
    protected void ddlMedium_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlMedium.SelectedIndex != 0)
        {
            BindSubjectChapterTopic(1);
            ddlDisable(ddlStandard, true);
            ddlDisable(ddlSubject, true);
            ddlDisable(ddlChapter, true);
            BindDivision(ddlDivision);
            ddlDisable(ddlDivision, true);
        }
        else
        {
            ddlDisable(ddlStandard, false);
            ddlDisable(ddlSubject, false);
            ddlDisable(ddlChapter, false);
            ddlDisable(ddlTopic, false);
            ddlDisable(ddlDivision, false);
        }
    }
    protected void ddlStandard_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlStandard.SelectedIndex != 0)
        {
            BindSubjectChapterTopic(2);
            BindDivision(ddlDivision);
            ddlDisable(ddlTopic, false);
            ddlDisable(ddlDivision, true);
        }
        else
        {
            ddlSubject.SelectedIndex = 0;
            ddlChapter.SelectedIndex = 0;
            ddlDivision.SelectedIndex = 0;
            ddlDisable(ddlTopic, false);
        }
    }
    protected void ddlSubject_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSubject.SelectedIndex != 0)
        {
            BindSubjectChapterTopic(3);
            ddlDisable(ddlTopic, false);
            ddlDivision.SelectedIndex = 0;
        }
        else
        {
            ddlChapter.SelectedIndex = 0;
            ddlDisable(ddlTopic, false);
            ddlDivision.SelectedIndex = 0;
        }
    }
    protected void ddlChapter_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlChapter.SelectedIndex != 0)
        {
            BindSubjectChapterTopic(4);
            ddlDisable(ddlTopic, true);
            ddlDivision.SelectedIndex = 0;
        }
        else
        {
            ddlDisable(ddlTopic, false);
            ddlDivision.SelectedIndex = 0;
        }
    }
    protected void ddlTopic_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlTopic.SelectedIndex == 0)
        {
            ddlDivision.SelectedIndex = 0;
        }
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        if (AppSessions.RoleID == (int)EnumFile.Role.E_Admin)
        {
            ddlDisable(ddlSchool, true);
            ddlDisable(ddlBoard, false);
            ddlDisable(ddlMedium, false);
            ddlDisable(ddlStandard, false);
            ddlDisable(ddlSubject, false);
            ddlDisable(ddlChapter, false);
            ddlDisable(ddlTopic, false);
            ddlDisable(ddlDivision, false);
            ViewState["Stage"] = 1;

            userControlDiv.Visible = false;    
        }
        else if (AppSessions.RoleID == (int)EnumFile.Role.S_Admin)
        {
            //ddlDisable(ddlSchool, true);
            ddlDisable(ddlBoard, true);
            ddlDisable(ddlMedium, false);
            ddlDisable(ddlStandard, false);
            ddlDisable(ddlSubject, false);
            ddlDisable(ddlChapter, false);
            ddlDisable(ddlTopic, false);
            ddlDisable(ddlDivision, false);
            ViewState["Stage"] = 1;
            userControlDiv.Visible = false;
        }
        else if (AppSessions.RoleID == (int)EnumFile.Role.Teacher)
        {
            //ddlDisable(ddlSchool, true);
            ddlDisable(ddlBoard, true);
            ddlDisable(ddlMedium, false);
            ddlDisable(ddlStandard, false);
            ddlDisable(ddlSubject, false);
            ddlDisable(ddlChapter, false);
            ddlDisable(ddlTopic, false);
            ddlDisable(ddlDivision, false);
            ViewState["Stage"] = 1;
            userControlDiv.Visible = false;
        }
        //var nvc = HttpUtility.ParseQueryString(Request.Url.Query);
        //nvc.Remove("SchoolID");
        //string url = Request.Url.AbsolutePath + nvc.ToString();
        //Response.Redirect(url);
    }
    protected void btnViewReport_Click(object sender, EventArgs e)
    {
        if (ddlSchool.SelectedIndex != 0)
        {
            ddlBoard.Enabled = true;
            ddlMedium.Enabled = true;
            ddlStandard.Enabled = true;
            ddlSubject.Enabled = true;
            ddlChapter.Enabled = true;
            ddlTopic.Enabled = true;
            ddlDivision.Enabled = true;
            userControlDiv.Visible = true;
            BindDataToGrid();
        }

    }

  
    protected void btnBack_Click(object sender, EventArgs e)
    {
        if (CurrentReport == "Classwise Report")
        {
        }
        else if (CurrentReport == "Subjectwise Report")
        {
            ClasswiseReport.Visible = true;
            SubjectwiseReport.Visible = false;
            ChapterwiseReport.Visible = false;
            TopicwiseReport.Visible = false;

            btnBack.Visible = false;
            lblFirstTitle.Visible = true;
            lblSecondTitle.Visible = false;
            lblThirdTitle.Visible = false;
            lblForthTitle.Visible = false;
            ClasswiseSyllabusGrid.Visible = true;
            SubjectwiseSyllabusGrid.Visible = false;
            ChapterwiseSyllabusGrid.Visible = false;
            TopicwiseSyllabusGrid.Visible = false;
            StageOneCalling();
        }
        else if (CurrentReport == "Chapterwise Report")
        {
            ClasswiseReport.Visible = true;
            SubjectwiseReport.Visible = true;
            ChapterwiseReport.Visible = false;
            TopicwiseReport.Visible = false;

            btnBack.Visible = true;
            lblFirstTitle.Visible = true;
            lblSecondTitle.Visible = true;
            lblThirdTitle.Visible = false;
            lblForthTitle.Visible = false;
            ClasswiseSyllabusGrid.Visible = false;
            SubjectwiseSyllabusGrid.Visible = true;
            ChapterwiseSyllabusGrid.Visible = false;
            TopicwiseSyllabusGrid.Visible = false;
            StageTwoCalling();
        }
        else if (CurrentReport == "Topicwise Report")
        {
            ClasswiseReport.Visible = true;
            SubjectwiseReport.Visible = false;
            ChapterwiseReport.Visible = true;
            TopicwiseReport.Visible = false;

            btnBack.Visible = true;
            lblFirstTitle.Visible = true;
            lblSecondTitle.Visible = false;
            lblThirdTitle.Visible = true;
            lblForthTitle.Visible = false;
            ClasswiseSyllabusGrid.Visible = false;
            SubjectwiseSyllabusGrid.Visible = false; 
            ChapterwiseSyllabusGrid.Visible = true;
            TopicwiseSyllabusGrid.Visible = false;
            StageThreeCalling();
        }
    }
    #endregion

    #region Properties
    public int SchoolID
    {
        get
        {
            if (ViewState["SchoolID"] == null || ViewState["SchoolID"] == string.Empty)
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
    public int BoardID
    {
        get
        {
            if (ViewState["BoardID"] == null || ViewState["BoardID"] == string.Empty)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(ViewState["BoardID"].ToString());
            }
        }
        set
        {
            ViewState["BoardID"] = value;
        }
    }
    public int MediumID
    {
        get
        {
            if (ViewState["MediumID"] == null || ViewState["MediumID"] == string.Empty)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(ViewState["MediumID"].ToString());
            }
        }
        set
        {
            ViewState["MediumID"] = value;
        }
    }
    public int StandardID
    {
        get
        {
            if (ViewState["StandardID"] == null || ViewState["StandardID"] == string.Empty)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(ViewState["StandardID"].ToString());
            }
        }
        set
        {
            ViewState["StandardID"] = value;
        }
    }
    public int SubjectID
    {
        get
        {
            if (ViewState["SubjectID"] == null || ViewState["SubjectID"] == string.Empty)
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
    public int ChapterID
    {
        get
        {
            if (ViewState["ChapterID"] == null || ViewState["ChapterID"] == string.Empty)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(ViewState["ChapterID"].ToString());
            }
        }
        set
        {
            ViewState["ChapterID"] = value;
        }
    }
    public int TopicID
    {
        get
        {
            if (ViewState["TopicID"] == null || ViewState["TopicID"] == string.Empty)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(ViewState["TopicID"].ToString());
            }
        }
        set
        {
            ViewState["TopicID"] = value;
        }
    }
    public int DivisionID
    {
        get
        {
            if (ViewState["DivisionID"] == null || ViewState["DivisionID"] == string.Empty)
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
    public int BMSID
    {
        get
        {
            if (ViewState["BMSID"] == null || ViewState["BMSID"] == string.Empty)
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
    public string CurrentReport
    {
        get
        {
            return ViewState["CurrentReport"].ToString();
        }
        set
        {
            ViewState["CurrentReport"] = value.ToString();
        }
    }
    #endregion
}