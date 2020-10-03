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

public partial class Report_AgewiseStudentReportF : System.Web.UI.Page
{
    #region "Declaration"

    SYS_Division_BLogic DivisionBLogic = new SYS_Division_BLogic();
    DropDownFill DdlFilling;
    School_BLogic SchoolBLogic = new School_BLogic();
    AgewiseStudentReport Obj_Dal_AgewiseStudentReport;
    string connectionstring;

    #endregion

    #region "Page Event"
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


    #endregion

    #region "Control Events"

    protected void ddlSchool_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSchool.SelectedIndex != 0)
        {
            DataSet ds = new DataSet();

            SYS_Board_BLogic objSys_Board = new SYS_Board_BLogic();
            ds = objSys_Board.BAL_SYS_Board_BySchoolID(Convert.ToInt32(ddlSchool.SelectedValue));

            DropDownFill DdlFilling = new DropDownFill();
            DdlFilling.BindDropDownByTable(ddlBoard, ds.Tables[0], "Board", "BoardID");
            ddlBoard.Items.Insert(Convert.ToInt32(EnumFile.AssignValue.Zero), "-- Select --");
            ddlBoard.Items[0].Value = Convert.ToString((int)EnumFile.AssignValue.Zero);


            Session["SchoolID"] = Convert.ToInt32(ddlSchool.SelectedValue);
            Session["SchoolName"] = ddlSchool.SelectedItem.ToString();
            ddlDisable(ddlBoard, true);
            ddlDisable(ddlMedium, false);
            ddlDisable(ddlGroupName, false);
            ddlDisable(ddlYear, true);

            //    grdAgewiseStudentReport.DataSource = null;
            //    grdAgewiseStudentReport.DataBind();
            //    grdAgewiseStudentReport.Visible = false;
        }
        else
        {
            ddlDisable(ddlBoard, false);
            ddlDisable(ddlMedium, false);
            ddlDisable(ddlGroupName, false);
            ddlDisable(ddlYear, true);

            //    grdAgewiseStudentReport.DataSource = null;
            //    grdAgewiseStudentReport.DataBind();
            //    grdAgewiseStudentReport.Visible = false;
        }
    }
    private void ddlDisable(DropDownList ddlDropDown, bool status)
    {
        ddlDropDown.Enabled = status;
        ddlDropDown.SelectedIndex = 0;
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
            ddlDisable(ddlMedium, true);
            ddlMedium.Items[0].Value = Convert.ToString((int)EnumFile.AssignValue.Zero);
            Session["ReportBoardID"] = Convert.ToInt32(ddlBoard.SelectedValue);
            Session["BoardName"] = ddlBoard.SelectedItem.ToString();
        }
        else
        {
            ddlDisable(ddlMedium, false);
            ddlDisable(ddlGroupName, false);
            ddlDisable(ddlYear, false);
        }
    }
    protected void ddlMedium_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlMedium.SelectedIndex != 0)
        {
            BindGroupName(ddlGroupName);
            ddlDisable(ddlGroupName, true);
            Session["ReportMediumID"] = Convert.ToInt32(ddlMedium.SelectedValue);
            Session["MediumName"] = ddlMedium.SelectedItem.ToString();
        }
        else
        {
            ddlDisable(ddlGroupName, false);
        }
    }
    protected void btnGo_Click(object sender, EventArgs e)
    {
        ddlSchool.Enabled = false;
        ddlBoard.Enabled = false;
        ddlMedium.Enabled = false;
        ddlGroupName.Enabled = false;


        StageFirstCalling();

    }

    private void StageFirstCalling()
    {
        DataSet ds = new DataSet();
        this.Obj_Dal_AgewiseStudentReport = new AgewiseStudentReport();
        string Groupname;
        string Year;
        if (ddlGroupName.SelectedIndex == 0)
        {
            Groupname = null;
        }
        else
        {
            Groupname = ddlGroupName.SelectedItem.ToString();
        }
        if (ddlYear.SelectedIndex == 0)
        {
            Year = null;
        }
        else
        {
            Year = ddlYear.SelectedItem.ToString();
        }
        ds = this.Obj_Dal_AgewiseStudentReport.GetAgewiseStudentReport(Convert.ToInt32(ddlSchool.SelectedValue), Convert.ToInt32(ddlBoard.SelectedValue), Convert.ToInt32(ddlMedium.SelectedValue), Convert.ToString(Groupname), Convert.ToString(Year));

        GetConnectionStringSTRING obj = new GetConnectionStringSTRING();
        connectionstring = obj.BAL_EpathshalaString();
        rptSchool.Visible = true;
        CommanCallUserControl(ds, "../ReportXMLFiles/AgewiseStudentReportFirst.xml");
        rptSchool.Search(ds.Tables[0]);
        CurrentReport = "School";
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        if (AppSessions.RoleID == (int)EnumFile.Role.E_Admin)
        {
            ddlDisable(ddlSchool, true);
            ddlDisable(ddlBoard, false);
            ddlDisable(ddlMedium, false);
            ddlDisable(ddlGroupName, false);
            ddlDisable(ddlYear, false);
            rptSchool.Visible = false;
        }
        else if (AppSessions.RoleID == (int)EnumFile.Role.S_Admin)
        {
            //ddlDisable(ddlSchool, false);
            ddlDisable(ddlBoard, true);
            ddlDisable(ddlMedium, false);
            ddlDisable(ddlGroupName, false);
            ddlDisable(ddlYear, true);
            rptSchool.Visible = false;
        }
        else if (AppSessions.RoleID == (int)EnumFile.Role.Teacher)
        {
            
        }
        
       
    }
    protected void btnback_Click(object sender, EventArgs e)
    {
        if (CurrentReport == "School")
        {
        }
        else if (CurrentReport == "AgeGroup")
        {
            rptSchool.Visible = true;
            rptAgeGroup.Visible = false;
            rptStudent.Visible = false;
            FirstRpt.Visible = true;
            SecondRpt.Visible = false;
            ThirdReport.Visible = false;
            btnback.Visible = false;
            StageFirstCalling();
           
        }
        else if (CurrentReport == "Student")
        {
            rptSchool.Visible = false;
            rptAgeGroup.Visible = true;
            rptStudent.Visible = false;
            FirstRpt.Visible = true;
            SecondRpt.Visible = true;
            ThirdReport.Visible = false;
            btnback.Visible = true;
            CurrentReport = "AgeGroup";
            StageSecondCalling();
            //StageThirdCalling();
        }
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

    private void BindGroupName(DropDownList ddlGroupName)
    {
        if (ddlMedium.SelectedIndex != 0)
        {
            DivisionBLogic = new SYS_Division_BLogic();

            DataSet dsResult = new DataSet();
            dsResult = DivisionBLogic.BAL_SYS_GroupName_SelectByBMSID();

            DdlFilling = new DropDownFill();
            // DdlFilling.BindDropDownByTable(ddlGroupName, dsResult.Tables[0], "GroupName", "StudentAgeGroupID");
            DdlFilling.BindDropDownByGroupName(ddlGroupName, dsResult.Tables[0], "GroupName");
            ddlGroupName.Items.Insert(Convert.ToInt32(EnumFile.AssignValue.Zero), "-- Select --");
            ddlGroupName.Items[0].Value = Convert.ToString((int)EnumFile.AssignValue.Zero);
            Session["ReportGroupName"] = Convert.ToInt32(ddlGroupName.SelectedValue);
            Session["GroupName"] = ddlGroupName.SelectedItem.ToString();
        }
    }
    private void CommanCallUserControl(DataSet ds, string reporttype)
    {
        GetConnectionStringSTRING obj = new GetConnectionStringSTRING();
        connectionstring = obj.BAL_EpathshalaString();
        try
        {
            rptSchool.ConnectionString = connectionstring;
            //reporttype = Server.MapPath("Files/MonthlySummary.xml");
            rptSchool.XMLReportFile = Server.MapPath(reporttype);

            rptSchool.Search(ds.Tables[0]);
            // WebUserControl1.status = "1";
        }
        catch (Exception ex)
        {
            WebMsg.Show("" + ex.Message.ToString());
        }
    }
    public void Displayselecteddata(Hashtable hashtable, object objsender)
    {
        ReportControl rpt = (ReportControl)objsender;

        if (rpt.ID == "rptSchool")
        {
            rptSchool.Visible = false;
            rptAgeGroup.Visible = true;
            rptStudent.Visible = false;
            FirstRpt.Visible = true;
            SecondRpt.Visible = true;
            ThirdReport.Visible = false;
            btnback.Visible = true;

            this.SchoolID = Convert.ToInt32(ddlSchool.SelectedValue.ToString());
            this.BoardID = Convert.ToInt32(ddlBoard.SelectedValue.ToString());
            this.MediumID = Convert.ToInt32(ddlMedium.SelectedValue.ToString());
            this.GroupName = (hashtable["GroupName"].ToString());
            this.AgeGroup = (hashtable["AgeGroup"].ToString());
            this.Year = ddlYear.SelectedItem.ToString();
            Session["YearExam"] = Year;

            this.StudentAgeGropID = Convert.ToInt32(hashtable["StudentAgeGropID"].ToString());
            Session["Example"] = StudentAgeGropID;
            this.StudentAgeGropIDPara = Convert.ToInt32(Session["Example"]);
            BindValuesToLabels();

            StageSecondCalling();
        }
        else if (rpt.ID == "rptAgeGroup")
        {
            rptSchool.Visible = false;
            rptAgeGroup.Visible = false;
            rptStudent.Visible = true;
            FirstRpt.Visible = true;
            SecondRpt.Visible = false;
            ThirdReport.Visible = true;
            btnback.Visible = true;

            this.SchoolID = Convert.ToInt32(ddlSchool.SelectedValue.ToString());
            this.BoardID = Convert.ToInt32(ddlBoard.SelectedValue.ToString());
            this.MediumID = Convert.ToInt32(ddlMedium.SelectedValue.ToString());
            this.GroupName = (hashtable["GroupName"].ToString());
            this.Year = ddlYear.SelectedItem.ToString();
            this.BMSID = Convert.ToInt32(hashtable["BMSID"].ToString());
            this.BMS = (hashtable["BMS"].ToString());
            this.DivisionID = Convert.ToInt32(hashtable["DivisionID"].ToString());
            this.Division = (hashtable["Division"].ToString());
            this.Description = (hashtable["Description"].ToString());
            lblTeacherValue.Text = AppSessions.UserName;
            BindValuesToLabels2();

            StageThirdCalling();
        }
        else if (rpt.ID == "rptStudent")
        {
            std.Visible = true;

            this.StudentID = Convert.ToInt32(hashtable["StudentID"].ToString());
            Session["NewStudentID"] = StudentID;
            Session["ReportYear"] = Session["YearExam"].ToString();
            std.BindStudentDetails(Session["NewStudentID"].ToString());

            mpStudent.Show();
        }
    }

    protected void ibtnClose_Click(object sender, EventArgs e)
    {
        StageThirdCalling();
    }
    private void StageThirdCalling()
    {
       

        DataSet dtResult = new DataSet();
        this.Obj_Dal_AgewiseStudentReport = new AgewiseStudentReport();
        dtResult = this.Obj_Dal_AgewiseStudentReport.GetAgewiseStudent(this.SchoolID, this.BoardID, this.MediumID, this.GroupName, this.Year, this.BMSID, this.DivisionID, this.Description);

        GetConnectionStringSTRING obj = new GetConnectionStringSTRING();
        connectionstring = obj.BAL_EpathshalaString();

        rptStudent.XMLReportFile = Server.MapPath("../ReportXMLFiles/AgewiseStudentReportThird.xml");
        rptStudent.Search(dtResult.Tables[0]);
        CurrentReport = "Student";
    }

    private void StageSecondCalling()
    {
        
        DataSet dtResult = new DataSet();
        this.Obj_Dal_AgewiseStudentReport = new AgewiseStudentReport();
        dtResult = this.Obj_Dal_AgewiseStudentReport.GetAgewise(this.SchoolID, this.BoardID, this.MediumID, this.GroupName, this.Year, this.StudentAgeGropIDPara);

        GetConnectionStringSTRING obj = new GetConnectionStringSTRING();
        connectionstring = obj.BAL_EpathshalaString();

        rptAgeGroup.XMLReportFile = Server.MapPath("../ReportXMLFiles/AgewiseStudentReportSecond.xml");
        rptAgeGroup.Search(dtResult.Tables[0]);
        CurrentReport = "AgeGroup";
    }

    private void BindValuesToLabels()
    {
        lblSchoolValue.Text = ddlSchool.SelectedItem.Text;
        lblAgeValue.Text = this.AgeGroup;
        lblYearValue.Text = this.Year;
    }
    private void BindValuesToLabels2()
    {
        lblSchoolValTh.Text = ddlSchool.SelectedItem.Text;
        lblBMSValue.Text = this.BMS;
        lblDivValue.Text = this.Division;
        lblAgeGroupValue.Text = this.AgeGroup;
    }

    #endregion

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
    public int BoardID
    {
        get
        {
            if (ViewState["BoardID"] == null || ViewState["BoardID"].ToString() == string.Empty)
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
    public int MediumID
    {
        get
        {
            if (ViewState["MediumID"] == null || ViewState["MediumID"].ToString() == string.Empty)
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
    public string BMS
    {
        get
        {
            if (ViewState["BMS"] == null || ViewState["BMS"].ToString() == string.Empty)
            {
                return string.Empty;
            }
            else
            {
                return ViewState["BMS"].ToString();
            }
        }

        set
        {
            ViewState["BMS"] = value;
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
    public string Division
    {
        get
        {
            if (ViewState["Division"] == null || ViewState["Division"].ToString() == string.Empty)
            {
                return string.Empty;
            }
            else
            {
                return ViewState["Division"].ToString();
            }
        }

        set
        {
            ViewState["Division"] = value;
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
    public string Year
    {
        get
        {
            if (ViewState["Year"] == null || ViewState["Year"].ToString() == string.Empty)
            {
                return string.Empty;
            }
            else
            {
                return ViewState["Year"].ToString();
            }
        }

        set
        {
            ViewState["Year"] = value;
        }
    }
    public string AgeGroup
    {
        get
        {
            if (ViewState["AgeGroup"] == null || ViewState["AgeGroup"].ToString() == string.Empty)
            {
                return string.Empty;
            }
            else
            {
                return ViewState["AgeGroup"].ToString();
            }
        }

        set
        {
            ViewState["AgeGroup"] = value;
        }
    }
    public string GroupName
    {
        get
        {
            if (ViewState["GroupName"] == null || ViewState["GroupName"].ToString() == string.Empty)
            {
                return string.Empty;
            }
            else
            {
                return ViewState["GroupName"].ToString();
            }
        }

        set
        {
            ViewState["GroupName"] = value;
        }
    }
    public int StudentAgeGropIDPara
    {
        get
        {
            if (ViewState["StudentAgeGropIDPara"] == null || ViewState["StudentAgeGropIDPara"].ToString() == string.Empty)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(ViewState["StudentAgeGropIDPara"].ToString());
            }
        }

        set
        {
            ViewState["StudentAgeGropIDPara"] = value;
        }
    }
    public int StudentAgeGropID
    {
        get
        {
            if (ViewState["StudentAgeGropID"] == null || ViewState["StudentAgeGropID"].ToString() == string.Empty)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(ViewState["StudentAgeGropID"].ToString());
            }
        }

        set
        {
            ViewState["StudentAgeGropID"] = value;
        }
    }
    public string Description
    {
        get
        {
            if (ViewState["Description"] == null || ViewState["Description"].ToString() == string.Empty)
            {
                return string.Empty;
            }
            else
            {
                return ViewState["Description"].ToString();
            }
        }

        set
        {
            ViewState["Description"] = value;
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
    public Hashtable hashtable { get; set; }
    #endregion

    
}