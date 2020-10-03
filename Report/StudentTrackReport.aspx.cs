using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using Udev.UserMasterPage.Classes;
using System.Globalization;
using System.Data;
using System.Collections;
using System.Text.RegularExpressions;
using System.Text;
using System.Xml;

public partial class Report_StudentTrackReport : System.Web.UI.Page
{
    #region "Declaration"
    SYS_BMS_BLogic BSysBMS = new SYS_BMS_BLogic();
    SYS_BMS PSysBMS = new SYS_BMS();
    DropDownFill DdlFilling;
    School_BLogic SchoolBLogic = new School_BLogic();
    SYS_Division_BLogic DivisionBLogic = new SYS_Division_BLogic();
    TrackLogRPT_BLogic obj_TracklogRPT;
    string connectionstring;
    #endregion

    #region "Page Events"

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
            txtFdate.Text = DateTime.Today.ToString("dd MMM yyyy");
            txtTodate.Text = DateTime.Today.ToString("dd MMM yyyy");
            Get_Boards();
        }
    }
    #endregion

    #region User Defined Methods
    public void Get_Boards()
    {
        DropDownFill DdlFilling = new DropDownFill();
        DataSet dsBoard = new DataSet();
        dsBoard = BSysBMS.Get_AllBoards();
        if (dsBoard.Tables[0].Rows.Count > 0)
        {
            ddlBoard.DataSource = dsBoard;
            ddlBoard.DataTextField = "Board";
            ddlBoard.DataValueField = "BoardID";
            ddlBoard.DataBind();
            ddlBoard.Items.Insert(0, "Select Board");
        }
    }
    public void Displayselecteddata(Hashtable hashtable, object objsender)
    {
        if (RptCtrlSessionSummury.Visible == true)
        {

            RptCtrlSessionSummury.Visible = false;
            RptCtrlSessionDetails.Visible = true;
            btnback.Visible = true;



            DataAccess da = new DataAccess();
            ArrayList arrlst = new ArrayList();
            arrlst.Add(new parameter("ReportType", "details"));
            arrlst.Add(new parameter("SessionID", hashtable["SessionID"].ToString()));
            arrlst.Add(new parameter("StudentId", ddlStudents.SelectedValue));

            LblSessionname.Text = hashtable["SessionID"].ToString();

            DataSet dsResult = da.DAL_Select("sp_StudentActivityTrackReport", arrlst);

            if (dsResult.Tables.Count > 0)
            {
                CommanCallUserControl(dsResult.Tables[0], "../ReportXMLFiles/StudentActivityTrackSessionDetails.xml", 2);
            }
            else
            {
                WebMsg.Show("No data found.");
            }
        }
        else if (RptCtrlSessionDetails.Visible == true)
        {
            //RptCtrlSessionDetails.Visible = false;
        }

    }
    private void CommanCallUserControl(DataTable dt, string reporttype, int control)
    {
        GetConnectionStringSTRING obj = new GetConnectionStringSTRING();
        connectionstring = obj.BAL_EpathshalaString();
        try
        {
            if (control == 1)
            {
                RptCtrlSessionSummury.ConnectionString = connectionstring;
                RptCtrlSessionSummury.XMLReportFile = Server.MapPath(reporttype);
                RptCtrlSessionSummury.Search(dt);
                RptCtrlSessionSummury.Visible = true;
            }
            else if (control == 2)
            {
                RptCtrlSessionDetails.ConnectionString = connectionstring;
                RptCtrlSessionDetails.XMLReportFile = Server.MapPath(reporttype);
                RptCtrlSessionDetails.Search(dt);
                RptCtrlSessionDetails.Visible = true;
                
                lblfooterdiv.Visible = false;
            }
        }
        catch (Exception ex)
        {
            WebMsg.Show("" + ex.Message.ToString());
        }
    }
    #endregion

    #region DropDowns
    protected void ddlBoard_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlBoard != null && ddlBoard.SelectedIndex > 0)
        {
            DataSet dsmedium = new DataSet();
            dsmedium = BSysBMS.Get_AllMediumByBoardID(int.Parse(ddlBoard.SelectedValue));
            if (dsmedium.Tables[0].Rows.Count > 0)
            {
                ddlMedium.DataSource = dsmedium;
                ddlMedium.DataTextField = "Medium";
                ddlMedium.DataValueField = "MediumID";
                ddlMedium.DataBind();
                ddlMedium.Items.Insert(0, "Select Medium");
                ddlMedium.Enabled = true;
            }
        }
    }
    protected void ddlMedium_SelectedIndexChanged(object sender, EventArgs e)
    {
        if ((ddlBoard != null && ddlBoard.SelectedIndex > 0) && (ddlMedium != null && ddlMedium.SelectedIndex > 0))
        {
            DataSet dsstandard = new DataSet();
            dsstandard = BSysBMS.Get_AllStandardByBoardMediumID(int.Parse(ddlBoard.SelectedValue), int.Parse(ddlMedium.SelectedValue));
            if (dsstandard.Tables[0].Rows.Count > 0)
            {
                ddlStandard.DataSource = dsstandard;
                ddlStandard.DataTextField = "Standard";
                ddlStandard.DataValueField = "StandardId";
                ddlStandard.DataBind();
                ddlStandard.Items.Insert(0, "Select Standard");
                ddlStandard.Enabled = true;
            }
        }
    }
    protected void ddlStandard_SelectedIndexChanged(object sender, EventArgs e)
    {
        if ((ddlBoard != null && ddlBoard.SelectedIndex > 0) && (ddlMedium != null && ddlMedium.SelectedIndex > 0) && (ddlStandard != null && ddlStandard.SelectedIndex > 0))
        {
            SYS_Division_BLogic obj_DivBlogic = new SYS_Division_BLogic();

            int param_boardsid = int.Parse(ddlBoard.SelectedValue);
            int param_mediumid = int.Parse(ddlMedium.SelectedValue);
            int param_standardid = int.Parse(ddlStandard.SelectedValue);

            ViewState["BMSID"] = obj_DivBlogic.BAL_SYS_SelectBMSID(param_boardsid, param_mediumid, param_standardid);
            if (ViewState["BMSID"] != null)
            {
                DataAccess da = new DataAccess();
                DataTable dt_StudentList = da.GetDataTable("select StudentID,FirstName+ ' ' + LastName+ ' > '+ LoginId as StudentName from Student where BMSID=" + ViewState["BMSID"] + " AND IsActive='true'");
                if (dt_StudentList != null && dt_StudentList.Rows.Count > 0)
                {
                    ddlStudents.DataSource = dt_StudentList;
                    ddlStudents.DataTextField = "StudentName";
                    ddlStudents.DataValueField = "StudentID";
                    ddlStudents.DataBind();
                    ddlStudents.Items.Insert(0, "Select Student");

                    ddlStudents.Enabled = true;
                }
                else
                {
                    ddlStudents.Enabled = false;
                }
            }
        }
    }
    protected void ddlStudent_SelectedIndexChanged(object sender, EventArgs e)
    {
    }
    #endregion

    #region Controls
    protected void btnViewReport_Click(object sender, EventArgs e)
    {


        DataAccess da = new DataAccess();
        ArrayList arrlst = new ArrayList();
        arrlst.Add(new parameter("ReportType", "summury"));
        arrlst.Add(new parameter("StudentID", ddlStudents.SelectedValue));
        arrlst.Add(new parameter("Datefrom", txtFdate.Text));
        arrlst.Add(new parameter("dateto", txtTodate.Text));

        DataSet dsResult = da.DAL_Select("sp_StudentActivityTrackReport", arrlst);

        

        if (dsResult.Tables.Count > 0)
        {
            lblfooterdiv.Visible = true;
            lblFooterTotal.Text = "TOTAL DURATION: " + dsResult.Tables[2].Rows[0][1].ToString();

            slblStudentValue.Text = dsResult.Tables[0].Rows[0]["FirstName"].ToString() + " " + dsResult.Tables[0].Rows[0]["LastName"].ToString();
            LblBMSValues.Text = dsResult.Tables[0].Rows[0]["BMS"].ToString().Replace(">>", "-");
            LblPeriodValues.Text = "From " + txtFdate.Text + " - " + "To : " + txtTodate.Text;

            div_general.Visible = true;
            div_no_general_data.Visible = false;
            div_reportdetails.Visible = true;
            div_no_reportdetails.Visible = false;

            RptCtrlSessionSummury.Visible = true;
            RptCtrlSessionDetails.Visible = false;
            CommanCallUserControl(dsResult.Tables[1], "../ReportXMLFiles/StudentActivityTrackRPT.xml", 1);
        }
        else
        {
            WebMsg.Show("No data found.");
        }

    }

    protected void btnback_Click(object sender, EventArgs e)
    {

    }
    #endregion

    protected void btnReset_Click(object sender, EventArgs e)
    {
        Get_Boards();
        ddlMedium.Items.Clear(); ddlMedium.Enabled = false;
        ddlStandard.Items.Clear(); ddlStandard.Enabled = false;
        ddlStudents.Items.Clear(); ddlStudents.Enabled = false;
        txtFdate.Text = DateTime.Today.ToString("dd-MMM-yyyy");
        txtTodate.Text = DateTime.Today.ToString("dd-MMM-yyyy");

        btnback.Visible = false;

        div_no_reportdetails.Visible = true;
        div_no_general_data.Visible = true;
        div_reportdetails.Visible = false;
        div_general.Visible = false;

        slblStudentValue.Text = string.Empty;
        LblBMSValues.Text = string.Empty;
        LblPeriodValues.Text = string.Empty;
        LblSessionname.Text = string.Empty;

    }
    protected void btnback_Click1(object sender, EventArgs e)
    {
        if (RptCtrlSessionSummury.Visible)
        {
            btnback.Visible = false;
        }
        else if (RptCtrlSessionDetails.Visible)
        {
            RptCtrlSessionDetails.Visible = false;
            RptCtrlSessionSummury.Visible = true;
            btnback.Visible = false;
            LblSessionname.Text = string.Empty;
            lblfooterdiv.Visible = true;
        }
    }
}