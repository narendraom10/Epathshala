/// <summary>
/// <Description>Schoolwise Student Gender Report</Description>
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
using Udev.UserMasterPage.Classes;
using System.Globalization;

public partial class Report_SchoolwiseStudentGenderReportNew : System.Web.UI.Page
{
    #region "Declaration"
    DropDownFill DdlFilling;
    School_BLogic SchoolBLogic = new School_BLogic();
    StudentGenderwiseReport_BLogic objGenderReport;
    DataSet dsResult = new DataSet();
    StudentGenderwiseReport_BLogic objStudentReport;
    string connectionstring;
    #endregion

    #region "PageLoad"
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
                    btnReset.Visible = false;
                    
                    break;
                case (int)EnumFile.Role.Teacher:
                    ddlSchool.SelectedIndex = ddlSchool.Items.IndexOf(ddlSchool.Items.FindByValue(AppSessions.SchoolID.ToString()));
                    ddlSchool.Enabled = false;
                    btnReset.Visible = false;
                    
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

    #region "User Defined Function"
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
    private void StageFirstCalling()
    {

        objGenderReport = new StudentGenderwiseReport_BLogic();
        SchoolwiseStudentGenderGrid.Visible = true;
        dsResult = new DataSet();
        dsResult = objGenderReport.GetSchoolwiseStudentGenderReport(this.SchoolID);
        GetConnectionStringSTRING obj = new GetConnectionStringSTRING();
        connectionstring = obj.BAL_EpathshalaString();

        SchoolwiseStudentGenderGrid.XMLReportFile = Server.MapPath("../ReportXMLFiles/SchoolwiseStudentGender.xml");
        SchoolwiseStudentGenderGrid.Search(dsResult.Tables[0]);
        CurrentReport = "Schoolwise Report";
    }
    private void StageTwoCalling()
    {
        dsResult = new DataSet();
        this.objGenderReport = new StudentGenderwiseReport_BLogic();

        dsResult = objGenderReport.GetBMSwiseStudentGenderReport(this.SchoolID, this.BoardID, this.MediumID, this.StandardID, this.AcademicYear);
        GetConnectionStringSTRING obj = new GetConnectionStringSTRING();
        connectionstring = obj.BAL_EpathshalaStudentString();

        BMSwiseStudentGender.XMLReportFile = Server.MapPath("../ReportXMLFiles/BMSwiseStudentGenderReport.xml");
        BMSwiseStudentGender.Search(dsResult.Tables[0]);
        CurrentReport = "BMSwise Student Gender";
    }
    private void StageThirdCalling()
    {
        objStudentReport = new StudentGenderwiseReport_BLogic();
        dsResult = new DataSet();

        dsResult = objStudentReport.GetStudentListBySchoolBMSGenderDivisionID(this.SchoolID, this.BMSID, this.DivisionID, this.AcademicYear);
        GetConnectionStringSTRING obj = new GetConnectionStringSTRING();
        connectionstring = obj.BAL_EpathshalaStudentString();

        BMSwiseStudentList.XMLReportFile = Server.MapPath("../ReportXMLFiles/BMSwiseStudentListReport.xml");
        BMSwiseStudentList.Search(dsResult.Tables[0]);
        CurrentReport = "BMSwise Student List";
    }
    private void CommanCallUserControl(DataSet dtResult, string reporttype)
    {
        GetConnectionStringSTRING obj = new GetConnectionStringSTRING();
        connectionstring = obj.BAL_EpathshalaString();
        try
        {
            SchoolwiseStudentGenderGrid.ConnectionString = connectionstring;
            SchoolwiseStudentGenderGrid.XMLReportFile = Server.MapPath(reporttype);
            SchoolwiseStudentGenderGrid.Search(dtResult.Tables[0]);
        }
        catch (Exception ex)
        {
            WebMsg.Show("" + ex.Message.ToString());
        }
    }
    public void Displayselecteddata(Hashtable hashtable, object objsender)
    {
        ReportControl rpt = (ReportControl)objsender;
        if (rpt.ID == "SchoolwiseStudentGenderGrid")
        {
            GenderwiseReport1.Visible = true;
            GenderwiseReport2.Visible = true;
            GenderwiseReport3.Visible = false;
            lblTitleFirst.Visible = true;
            lblTitleSecond.Visible = true;
            lblTitleThird.Visible = false;
            btnBack.Visible = true;
            SchoolwiseStudentGenderGrid.Visible = false;
            BMSwiseStudentGender.Visible = true;
            BMSwiseStudentList.Visible = false;
            this.AcademicYear = hashtable["AcademicYear"].ToString();
            lblYearValueSecond.Text = this.AcademicYear;
            lblSchoolValueSecond.Text = ddlSchool.SelectedItem.Text;
            BindBoardDropdown(ddlBoardSecond);
            CurrentReport = "BMSwise Student Gender";
            StageTwoCalling();
        }
        else if (rpt.ID == "BMSwiseStudentGender")
        {
            GenderwiseReport1.Visible = true;
            GenderwiseReport2.Visible = false;
            GenderwiseReport3.Visible = true;
            lblTitleFirst.Visible = true;
            lblTitleSecond.Visible = false;
            lblTitleThird.Visible = true;
            SchoolwiseStudentGenderGrid.Visible = false;
            BMSwiseStudentGender.Visible = false;
            BMSwiseStudentList.Visible = true;

            btnBack.Visible = true;
            lblYearValueThird.Text = this.AcademicYear;
            lblSchoolValueThird.Text = ddlSchool.SelectedItem.Text;
            lblBMSValueThird.Text = hashtable["BMS"].ToString();
            this.BMSID = Convert.ToInt32(hashtable["BMSID"].ToString());
            lblDivisionValueThird.Text = hashtable["Division"].ToString();
            this.DivisionID = Convert.ToInt32(hashtable["DivisionID"].ToString());
            StageThirdCalling();
            BMSwiseStudentList.Visible = true;
        }
        else if (rpt.ID == "BMSwiseStudentList")
        {
            std.Visible = true;
            this.StudentID = Convert.ToInt32(hashtable["StudentID"].ToString());
            Session["ReportYear"] = this.AcademicYear;
            std.BindStudentDetails(StudentID.ToString());

            mpStudent.Show();
        }
    }
    private void BindBoardDropdown(DropDownList ddlBoardSecond)
    {
        DataSet ds = new DataSet();

        SYS_Board_BLogic objSys_Board = new SYS_Board_BLogic();
        ds = objSys_Board.BAL_SYS_Board_BySchoolID(this.SchoolID);

        DropDownFill DdlFilling = new DropDownFill();
        DdlFilling.BindDropDownByTable(ddlBoardSecond, ds.Tables[0], "Board", "BoardID");
        ddlBoardSecond.Items.Insert(Convert.ToInt32(EnumFile.AssignValue.Zero), "-- Select --");
        ddlBoardSecond.Items[0].Value = Convert.ToString((int)EnumFile.AssignValue.Zero);
    }
    private void ddlDisable(DropDownList Dropdown, bool Status)
    {
        Dropdown.Enabled = Status;
        Dropdown.SelectedIndex = 0;
    }
    #endregion

    #region Control Events"
    protected void btnViewReport_Click(object sender, EventArgs e)
    {
        if (ddlSchool.SelectedIndex != 0)
        {

            lblSchoolFirst.Visible = true;
            userControlDiv.Visible = true;
            lblSchoolValueFirst.Text = ddlSchool.SelectedItem.ToString();
            this.SchoolID = Convert.ToInt32(ddlSchool.SelectedValue);
            StageFirstCalling();
        }
        else
        {
            WebMsg.Show("Please select school.");
        }
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        if (AppSessions.RoleID == (int)EnumFile.Role.E_Admin)
        {
            ddlSchool.SelectedIndex = 0;
            lblSchoolFirst.Visible = false;
            lblSchoolValueFirst.Visible = false;
            userControlDiv.Visible = false;
        }
        else if (AppSessions.RoleID == (int)EnumFile.Role.S_Admin)
        {
            
        }
        else if (AppSessions.RoleID == (int)EnumFile.Role.Teacher)
        {

        }

    }
    protected void btnViewReportSecond_Click(object sender, EventArgs e)
    {
        userControlDiv.Visible = true;
        this.BoardID = Convert.ToInt32(ddlBoardSecond.SelectedValue);
        this.MediumID = Convert.ToInt32(ddlMediumSecond.SelectedValue);
        this.StandardID = Convert.ToInt32(ddlStandardSecond.SelectedValue);
        BMSwiseStudentGender.Visible = true;
        StageTwoCalling();
    }
    protected void ddlBoardSecond_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlBoardSecond.SelectedIndex != 0)
        {
            DataSet ds = new DataSet();

            SYS_Board_BLogic objSys_Board = new SYS_Board_BLogic();
            ds = objSys_Board.BAL_SYS_Medium_BySchoolIDBoardID(this.SchoolID, Convert.ToInt32(ddlBoardSecond.SelectedValue));

            DropDownFill DdlFilling = new DropDownFill();
            DdlFilling.BindDropDownByTable(ddlMediumSecond, ds.Tables[0], "Medium", "MediumID");
            ddlMediumSecond.Items.Insert(Convert.ToInt32(EnumFile.AssignValue.Zero), "-- Select --");
            ddlMediumSecond.Items[0].Value = Convert.ToString((int)EnumFile.AssignValue.Zero);
            ddlDisable(ddlMediumSecond, true);
            
        }
        else
        {
            ddlDisable(ddlMediumSecond, false);
            ddlDisable(ddlStandardSecond, false);
        }
    }
    protected void ddlMediumSecond_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlMediumSecond.SelectedIndex != 0)
        {
            DataSet ds = new DataSet();

            SYS_Board_BLogic objSys_Board = new SYS_Board_BLogic();
            ds = objSys_Board.BAL_SYS_StdSubChapTopic_BySchoolIDBoardIDMediumid(this.SchoolID, Convert.ToInt32(ddlBoardSecond.SelectedValue), Convert.ToInt32(ddlMediumSecond.SelectedValue), Convert.ToInt32(null), Convert.ToInt32(null), Convert.ToInt32(null));

            DropDownFill DdlFilling = new DropDownFill();

            if (ds.Tables.Count > 0)
            {
                DdlFilling.BindDropDownByTable(ddlStandardSecond, ds.Tables[0], "Standard", "StandardID");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ddlStandardSecond.Items.Insert(Convert.ToInt32(EnumFile.AssignValue.Zero), "-- Select --");
                    ddlStandardSecond.Items[0].Value = Convert.ToString((int)EnumFile.AssignValue.Zero);
                    ddlDisable(ddlStandardSecond, true);
                }
            }
        }
        else
        {
            ddlDisable(ddlStandardSecond, false);
        }
    }
    protected void btnResetSecond_Click(object sender, EventArgs e)
    {
        ddlDisable(ddlBoardSecond, true);
        ddlDisable(ddlMediumSecond, false);
        ddlDisable(ddlStandardSecond, false);
        userControlDiv.Visible = false;
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        if (CurrentReport == "Schoolwise Report")
        { }
        else if (CurrentReport == "BMSwise Student Gender")
        {
            GenderwiseReport1.Visible = true;
            GenderwiseReport2.Visible = false;
            GenderwiseReport3.Visible = false;
            lblTitleFirst.Visible = true;
            lblTitleSecond.Visible = false;
            lblTitleThird.Visible = false;
            btnBack.Visible = false;
            BMSwiseStudentGender.Visible = false;
            BMSwiseStudentList.Visible = false;
            SchoolwiseStudentGenderGrid.Visible = true;
            StageFirstCalling();
        }
        else if (CurrentReport == "BMSwise Student List")
        {
            GenderwiseReport1.Visible = true;
            GenderwiseReport2.Visible = true;
            GenderwiseReport3.Visible = false;
            lblTitleFirst.Visible = true;
            lblTitleSecond.Visible = true;
            lblTitleThird.Visible = false;
            btnBack.Visible = true;
            BMSwiseStudentGender.Visible = true;
            BMSwiseStudentList.Visible = false;
            SchoolwiseStudentGenderGrid.Visible = false;
            StageTwoCalling();
        }

    }
    #endregion

    protected void ibtnClose_Click(object sender, EventArgs e)
    {
        StageThirdCalling();
    }

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
    public string AcademicYear
    {
        get
        {
            if (ViewState["AcademicYear"] == null || ViewState["AcademicYear"] == string.Empty)
            {
                return string.Empty;
            }
            else
            {
                return ViewState["AcademicYear"].ToString();
            }
        }
        set
        {
            ViewState["AcademicYear"] = value;
        }
    }
    public int StudentID
    {
        get
        {
            if (ViewState["StudentID"] == null || ViewState["StudentID"] == string.Empty)
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