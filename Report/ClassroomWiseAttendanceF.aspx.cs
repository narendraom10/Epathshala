using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;
using System.Collections;
using Udev.UserMasterPage.Classes;

public partial class Report_ClassroomWiseAttendanceF : System.Web.UI.Page
{

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

    #region "Declaration"

    DropDownFill DdlFilling;
    SYS_Division_BLogic DivisionBLogic = new SYS_Division_BLogic();
    ClassroomWiseAttendance Obj_Dal_ClassroomWiseAttendance;
    School_BLogic SchoolBLogic = new School_BLogic();
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
            txtDate.Text = DateTime.Today.ToString("dd-MMM-yyyy");
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
    //public override void VerifyRenderingInServerForm(Control control)
    //{
    //    /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
    //       server control at run time. */
    //}
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
        }
        else
        {
            ddlDisable(ddlBoard, false);
            ddlDisable(ddlMedium, false);
            ddlDisable(ddlStandard, false);
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
            ddlDisable(ddlMedium, true);
            ddlMedium.Items[0].Value = Convert.ToString((int)EnumFile.AssignValue.Zero);
        }
        else
        {
            ddlDisable(ddlMedium, false);
            ddlDisable(ddlStandard, false);
            ddlDisable(ddlDivision, false);
        }
    }
    protected void ddlMedium_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlMedium.SelectedIndex != 0)
        {
            BindStandard(1);
            ddlDisable(ddlStandard, true);
            ddlDisable(ddlDivision, true);
        }
        else
        {
            ddlDisable(ddlStandard, false);
            ddlDisable(ddlDivision, false);
        }
    }

    protected void ddlStandard_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlStandard.SelectedIndex != 0)
        {
            BindDivision(ddlDivision);
            ddlDisable(ddlDivision, true);
        }
        else
        {
            ddlDisable(ddlDivision, false);
        }
    }

    protected void btnGo_Click(object sender, EventArgs e)
    {
        ddlSchool.Enabled = false;
        ddlBoard.Enabled = false;
        ddlMedium.Enabled = false;
        ddlStandard.Enabled = false;
        ddlDivision.Enabled = false;

        DataSet ds = new DataSet();
        this.Obj_Dal_ClassroomWiseAttendance = new ClassroomWiseAttendance();
        ReportsForResult objRsultReport = new ReportsForResult();
        ds = this.Obj_Dal_ClassroomWiseAttendance.GetClasswiseAttendance(Convert.ToInt32(ddlSchool.SelectedValue), Convert.ToInt32(ddlBoard.SelectedValue), Convert.ToInt32(ddlMedium.SelectedValue), Convert.ToInt32(ddlStandard.SelectedValue), Convert.ToInt32(ddlDivision.SelectedValue), Get_DDMMYYYY(txtDate.Text));
        GetConnectionStringSTRING obj = new GetConnectionStringSTRING();
        connectionstring = obj.BAL_EpathshalaString();

        try
        {
            rptSchoolAttendance.Visible = true;
            rptSchoolAttendance.XMLReportFile = Server.MapPath("../ReportXMLFiles/ClassroomWiseAttendanceFirst.xml");
            rptSchoolAttendance.Search(ds.Tables[0]);
            CurrentReport = "SchoolAttendance";
        }
        catch (Exception ex)
        {
            WebMsg.Show("" + ex.Message.ToString());
        }
    }



    public void Displayselecteddata(Hashtable hashtable, object objsender)
    {
        ReportControl rpt = (ReportControl)objsender;

        if (rpt.ID == "rptSchoolAttendance")
        {
            rptSchoolAttendance.Visible = false;
            rptClassAttendance.Visible = true;
            //FirstReport.Visible = false;
            Div1.Visible = true;
            secondRpt.Visible = true;
            btnback.Visible = true;

            this.SchoolID = Convert.ToInt32(ddlSchool.SelectedValue.ToString());
            this.BMSID = Convert.ToInt32(hashtable["BMSID"].ToString());
            ViewState["BMSID"] = Convert.ToInt32(hashtable["BMSID"].ToString());
            this.BMS = (hashtable["BMS"].ToString());
            this.Attendance = (hashtable["Attendance"].ToString());
            this.Division = (hashtable["Division"].ToString());
            this.Date = Convert.ToDateTime(txtDate.Text);
            BindValuesToLabels();

            DataSet ds = new DataSet();
            ReportsForResult objRsultReport = new ReportsForResult();
            this.Obj_Dal_ClassroomWiseAttendance = new ClassroomWiseAttendance();
            ds = this.Obj_Dal_ClassroomWiseAttendance.GetAttendance(SchoolID, Date, BMSID);

            GetConnectionStringSTRING obj = new GetConnectionStringSTRING();
            connectionstring = obj.BAL_EpathshalaString();

            try
            {
                rptClassAttendance.XMLReportFile = Server.MapPath("../ReportXMLFiles/ClassroomWiseAttendanceSecond.xml");
                rptClassAttendance.Search(ds.Tables[0]);
                CurrentReport = "ClassAttendance";
            }
            catch (Exception ex)
            {
                WebMsg.Show("" + ex.Message.ToString());
            }
        }
        if (rpt.ID == "rptClassAttendance")
        {
            this.SchoolID = Convert.ToInt32(ddlSchool.SelectedValue.ToString());
            this.BMSID = Convert.ToInt32(ViewState["BMSID"].ToString());
            this.Date = Convert.ToDateTime(txtDate.Text);
            BindValuesToLabels();

            DataSet ds = new DataSet();
            ReportsForResult objRsultReport = new ReportsForResult();
            this.Obj_Dal_ClassroomWiseAttendance = new ClassroomWiseAttendance();

            ds = this.Obj_Dal_ClassroomWiseAttendance.GetAttendance(SchoolID, Date, BMSID);

            GetConnectionStringSTRING obj = new GetConnectionStringSTRING();
            connectionstring = obj.BAL_EpathshalaString();

            try
            {
                rptClassAttendance.XMLReportFile = Server.MapPath("../ReportXMLFiles/ClassroomWiseAttendanceSecond.xml");
                rptClassAttendance.Search(ds.Tables[0]);
                CurrentReport = "ClassAttendance";
            }
            catch (Exception ex)
            {
                WebMsg.Show("" + ex.Message.ToString());
            }
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
            ddlDisable(ddlDivision, false);
            rptSchoolAttendance.Visible = false;
        }
        else if (AppSessions.RoleID == (int)EnumFile.Role.S_Admin)
        {
            //ddlDisable(ddlSchool, true);
            ddlDisable(ddlBoard, true);
            ddlDisable(ddlMedium, false);
            ddlDisable(ddlStandard, false);
            ddlDisable(ddlDivision, false);
            rptSchoolAttendance.Visible = false;
        }
        else if (AppSessions.RoleID == (int)EnumFile.Role.Teacher)
        {
            //ddlDisable(ddlSchool, true);
            ddlDisable(ddlBoard, true);
            ddlDisable(ddlMedium, false);
            ddlDisable(ddlStandard, false);
            ddlDisable(ddlDivision, false);
            rptSchoolAttendance.Visible = false;
        }
    }



    protected void btnback_Click(object sender, EventArgs e)
    {
        if (CurrentReport == "SchoolAttendance")
        {

        }
        else if (CurrentReport == "ClassAttendance")
        {
            rptSchoolAttendance.Visible = true;
            rptClassAttendance.Visible = false;
            //FirstReport.Visible = true;
            Div1.Visible = true;
            secondRpt.Visible = false;
            btnback.Visible = false;

            DataSet ds = new DataSet();
            this.Obj_Dal_ClassroomWiseAttendance = new ClassroomWiseAttendance();
            ReportsForResult objRsultReport = new ReportsForResult();
            ds = this.Obj_Dal_ClassroomWiseAttendance.GetClasswiseAttendance(Convert.ToInt32(ddlSchool.SelectedValue), Convert.ToInt32(ddlBoard.SelectedValue), Convert.ToInt32(ddlMedium.SelectedValue), Convert.ToInt32(ddlStandard.SelectedValue), Convert.ToInt32(ddlDivision.SelectedValue), Get_DDMMYYYY(txtDate.Text));
            GetConnectionStringSTRING obj = new GetConnectionStringSTRING();
            connectionstring = obj.BAL_EpathshalaString();

            try
            {
                rptSchoolAttendance.XMLReportFile = Server.MapPath("../ReportXMLFiles/ClassroomWiseAttendanceFirst.xml");
                rptSchoolAttendance.Search(ds.Tables[0]);
                CurrentReport = "SchoolAttendance";
            }
            catch (Exception ex)
            {
                WebMsg.Show("" + ex.Message.ToString());
            }
        }
    }



    #endregion

    #region "User Defined Functions"

    private void ddlDisable(DropDownList ddlDropDown, bool status)
    {
        ddlDropDown.Enabled = status;
        ddlDropDown.SelectedIndex = 0;
    }

    private void BindStandard(int Step)
    {
        DataSet ds = new DataSet();

        SYS_Board_BLogic objSys_Board = new SYS_Board_BLogic();
        ds = objSys_Board.BAL_SYS_Std_BySchoolIDBoardIDMediumid(Convert.ToInt32(ddlSchool.SelectedValue), Convert.ToInt32(ddlBoard.SelectedValue), Convert.ToInt32(ddlMedium.SelectedValue), Convert.ToInt32(ddlStandard.SelectedValue));

        DdlFilling = new DropDownFill();
        if (Step <= 1)
        {
            if (ds.Tables.Count > 0)
            {
                DdlFilling.BindDropDownByTable(ddlStandard, ds.Tables[0], "Standard", "StandardID");
                ddlStandard.Items.Insert(Convert.ToInt32(EnumFile.AssignValue.Zero), "-- Select --");
                ddlStandard.Items[0].Value = Convert.ToString((int)EnumFile.AssignValue.Zero);
                ddlDisable(ddlStandard, true);
            }
        }
    }
    private void BindDivision(DropDownList ddlDivision)
    {
        if (ddlStandard.SelectedIndex != 0)
        {
            DivisionBLogic = new SYS_Division_BLogic();

            DataSet dsResult = new DataSet();
            dsResult = DivisionBLogic.BAL_SYS_Division_SelectByBMSID(Convert.ToInt32(ddlBoard.SelectedValue), Convert.ToInt32(ddlMedium.SelectedValue), Convert.ToInt32(ddlStandard.SelectedValue), Convert.ToInt32(Session["SchoolID"]));

            DdlFilling = new DropDownFill();
            DdlFilling.BindDropDownByTable(ddlDivision, dsResult.Tables[0], "Division", "DivisionID");
            ddlDivision.Items.Insert(Convert.ToInt32(EnumFile.AssignValue.Zero), "-- Select --");
            ddlDivision.Items[0].Value = Convert.ToString((int)EnumFile.AssignValue.Zero);
        }
    }



    public static DateTime Get_DDMMYYYY(String dat)
    {
        IFormatProvider culture = new CultureInfo("en-US", true);
        DateTime dt = DateTime.Parse(dat, culture, DateTimeStyles.AssumeLocal);
        return dt;
    }

    private void BindValuesToLabels()
    {
        lblSchoolValue.Text = ddlSchool.SelectedItem.Text;
        lblBMSValue.Text = this.BMS;
        lblDivValue.Text = this.Division;
        lblDateValue.Text = string.Format("{0:dd-MMM-yyyy}", this.Date);
        lblAttendanceValue.Text = this.Attendance;
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
    public string Attendance
    {
        get
        {
            if (ViewState["Attendance"] == null || ViewState["Attendance"].ToString() == string.Empty)
            {
                return string.Empty;
            }
            else
            {
                return ViewState["Attendance"].ToString();
            }
        }

        set
        {
            ViewState["Attendance"] = value;
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
            if (ViewState["StandardID"] == null || ViewState["StandardID"].ToString() == string.Empty)
            {
                return string.Empty;
            }
            else
            {
                return ViewState["StandardID"].ToString();
            }
        }
        set
        {
            ViewState["StandardID"] = value;
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
    public DateTime Date
    {
        get
        {
            if (ViewState["Date"] == null || ViewState["Date"].ToString() == string.Empty)
            {
                return DateTime.Now.Date;
            }
            else
            {
                return Convert.ToDateTime(ViewState["Date"].ToString());
            }
        }
        set
        {
            ViewState["Date"] = value;
        }
    }
    #endregion
}