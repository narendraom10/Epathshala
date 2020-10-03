///<Summary>
///</Summary>

using System;
using System.Collections;
using System.Data;
using System.Globalization;
using System.Web;
using System.Web.UI.WebControls;
using Udev.UserMasterPage.Classes;


public partial class Teacher_ReschedulingChapterTopic : System.Web.UI.Page
{

    #region Variables
    Teacher_Dashboard_BLogic obj_BAL_Teacher_Dashboard;
    Teacher_Dashboard obj_Teacher_Dashboard;
    SYS_TeacherActivityFeedback_BLogic BLogicActivityFeedBack;
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
            TrackLog_Utils.Log(Convert.ToInt32(AppSessions.SchoolID), Convert.ToInt32(AppSessions.EmpolyeeID), Convert.ToInt16(AppSessions.DivisionID), "ReschedulingChapterTopicPage", "Page", "Load", Convert.ToDateTime(System.DateTime.Now), HttpContext.Current.Session.SessionID, StringEnum.stringValueOf(EnumFile.Activity.ReschedulePageLoad), "Reschedule Page Loaded.", 0);

            fill_ALL_Covered_Chaptes_Topics();
            PopulateMonthYear();
            Applied_Chapter_Topics();
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
        ArrayList alistContacts = new ArrayList();
        string Body = string.Empty;
        obj_BAL_Teacher_Dashboard = new Teacher_Dashboard_BLogic();
        obj_Teacher_Dashboard = new Teacher_Dashboard();

        obj_Teacher_Dashboard.BMSID = Convert.ToInt64(Session["BMSID"]);
        obj_Teacher_Dashboard.SubjectID = Convert.ToInt16(Session["SubjectID"]);
        obj_Teacher_Dashboard.DivisionID = Convert.ToInt16(Session["DivisionID"]);
        obj_Teacher_Dashboard.EmployeeID = Convert.ToInt64(Session["EmpolyeeID"]);
        obj_Teacher_Dashboard.SchoolID = Convert.ToInt64(Session["SchoolID"]);
        obj_Teacher_Dashboard.ChapterID = Convert.ToInt64(ddlChapter.SelectedValue);
        obj_Teacher_Dashboard.TopicID = Convert.ToInt64(ddlTopic.SelectedValue);

        int result = obj_BAL_Teacher_Dashboard.BAL_Insert_Rescheduling_BMSSCT(obj_Teacher_Dashboard);

        int bmssctid = obj_BAL_Teacher_Dashboard.BAL_Select_BMS_SCTID(obj_Teacher_Dashboard);

        TrackLog_Utils.Log(Convert.ToInt32(AppSessions.SchoolID), Convert.ToInt32(AppSessions.EmpolyeeID), Convert.ToInt16(AppSessions.DivisionID), "ReschedulingChapterTopicPage", "BtnSubmit", "Click", Convert.ToDateTime(System.DateTime.Now), HttpContext.Current.Session.SessionID, StringEnum.stringValueOf(EnumFile.Activity.ReschedulingRequestSubmited), "Request for Rescheduling BMSSCT ID : " + bmssctid, bmssctid);

        if (result == ((int)EnumFile.AssignValue.One))
        {
            alistContacts = GetEmailAddress();
            Body = GenerateEmailBody();
            EmailUtility.SendEmail(alistContacts, "Rescheduling request notification", Body);
            WebMsg.Show("Rescheduling request sent successfully.");
            Applied_Chapter_Topics();
        }
        else if (result == ((int)EnumFile.AssignValue.Zero))
        {
            WebMsg.Show("This Chapter, Topic are already requested for Rescheduling.");
        }

        DropDownList[] disddl3 = { ddlChapter, ddlTopic };
        DisableDropDwon(disddl3);

        DropDownList[] disddl = { ddlChapter };
        EnableDropDwon(disddl);

    }




    protected string GenerateEmailBody()
    {
        string Body = string.Empty;
        obj_BAL_Teacher_Dashboard = new Teacher_Dashboard_BLogic();
        DataSet ds = new DataSet();
        int ReschedulingID = 0;
        try
        {
            ds = obj_BAL_Teacher_Dashboard.SelectLastReschedulingID(AppSessions.EmpolyeeID);
            if (ds != null & ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ReschedulingID = Convert.ToInt32(ds.Tables[0].Rows[0]["ReschedulingID"].ToString());
                }
            }

            Body = "<b>Hello Admin,<b/><br/><br/>";

            Body += "<table border='1' width='100%'>";
            Body += "<tr><td colspan='4' align='center'><b>Rescheduling Request<b/></td></tr>";
            Body += "<tr><td><b>School:<b/></td><td>" + AppSessions.SchoolName + "</td><td><b>Date:<b/></td><td>" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "</td></tr>";
            Body += "<tr><td><b>BMS:<b/></td><td colspan='3'>" + AppSessions.BMS + "</td></tr>";
            Body += "<tr><td><b>SCT:<b/></td><td colspan='3'>" + AppSessions.Subject + ">>" + Session["ChapterTopic"] + "</td></tr>";
            Body += "<tr><td><b>Div:<b/></td><td colspan='3'>" + AppSessions.Division + "</td></tr>";
            Body += "<tr><td><b>Teacher:<b/></td><td colspan='3'>" + AppSessions.UserName + "</td></tr>";
            Body += "</table><br/>";


            Body += "<a href='" + Session["LoginURL"].ToString() + "?ID=" + ReschedulingID + "'>Please click here to approve reschedule request.<a/><br/><br/>";
            //Body += "<a href='http://localhost:6991/Epathshala/Default.aspx?ID=" + ReschedulingID + "'>Please click here to approve reschedule request.<a/><br/><br/>";
            Body += "<b>Regards,<b/><br/>";
            Body += "<b>" + EmailUtility.USERNAME + "<b/>";


        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
        return Body;
    }

    /// <summary>
    /// Method will beused to get relevant email address.
    /// </summary>
    /// <returns>Array list</returns>
    protected ArrayList GetEmailAddress()
    {
        DataSet ds = new DataSet();
        ArrayList alistContacts = new ArrayList();
        BLogicActivityFeedBack = new SYS_TeacherActivityFeedback_BLogic();
        ds = BLogicActivityFeedBack.BAL_Select_Report_Contact("Admin");
        if (ds != null & ds.Tables.Count > 0)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    alistContacts.Add(ds.Tables[0].Rows[i]["Email"].ToString());
                }
            }
        }
        return alistContacts;
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        TrackLog_Utils.Log(Convert.ToInt32(AppSessions.SchoolID), Convert.ToInt32(AppSessions.EmpolyeeID), Convert.ToInt16(AppSessions.DivisionID), "ReschedulingChapterTopicPage", "btnReset", "Click", Convert.ToDateTime(System.DateTime.Now), HttpContext.Current.Session.SessionID, StringEnum.stringValueOf(EnumFile.Activity.ResetReschedulingRequest), "Reset Rescheduling Request.", 0);
        DropDownList[] disddl3 = { ddlChapter, ddlTopic };
        DisableDropDwon(disddl3);

        DropDownList[] disddl = { ddlChapter };
        EnableDropDwon(disddl);
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

    protected void ddlMonthYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        Applied_Chapter_Topics();
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

    public void Applied_Chapter_Topics()
    {
        obj_BAL_Teacher_Dashboard = new Teacher_Dashboard_BLogic();
        obj_Teacher_Dashboard = new Teacher_Dashboard();

        obj_Teacher_Dashboard.BMSID = Convert.ToInt64(Session["BMSID"]);
        obj_Teacher_Dashboard.SubjectID = Convert.ToInt16(Session["SubjectID"]);
        obj_Teacher_Dashboard.DivisionID = Convert.ToInt16(Session["DivisionID"]);
        obj_Teacher_Dashboard.EmployeeID = Convert.ToInt64(Session["EmpolyeeID"]);
        obj_Teacher_Dashboard.SchoolID = Convert.ToInt64(Session["SchoolID"]);

        obj_Teacher_Dashboard.Month = Convert.ToInt16(ddlMonthYear.SelectedValue);
        String[] Year = ddlMonthYear.SelectedItem.ToString().Split('-');
        obj_Teacher_Dashboard.Year = Convert.ToInt32(Year[1]);

        DataSet dsSelect = new DataSet();
        dsSelect = obj_BAL_Teacher_Dashboard.BAL_Select_Applied_Rescheduling_Data_Of_Teacher(obj_Teacher_Dashboard);

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

    protected void grvReschedulingData_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (e.SortExpression.Trim() == this.SortField)
        {
            this.SortDirection = (this.SortDirection == "descending" ? "ascending" : "descending");
        }
        else
        {
            this.SortDirection = "ascending";
            this.SortField = e.SortExpression;
            Applied_Chapter_Topics();
        }

        GridViewOperations GrvOperation = new GridViewOperations();
        GrvOperation.GrvSortingSetImage(e, grvReschedulingData, this.SortDirection);
    }
    #region "Properties"
    string SortDirection
    {
        get
        {
            object o = ViewState["SortDirection"];
            if (o == null)
            {
                return string.Empty;
            }
            else
            {
                return (string)o;
            }
        }

        set
        {
            ViewState["SortDirection"] = value;
        }
    }

    string SortField
    {
        get
        {
            object o = ViewState["SortField"];
            if (o == null)
            {
                return string.Empty;
            }
            else
            {
                return (string)o;
            }
        }

        set
        {
            ViewState["SortField"] = value;
        }
    }
    #endregion
   
}