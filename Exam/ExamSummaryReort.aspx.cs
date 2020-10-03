using System;
using System.Data;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.WebControls;
using Udev.UserMasterPage.Classes;

public partial class Exam_ExamSummaryReort : System.Web.UI.Page
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

    #region page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        this.TeacherPanel1.TeacherPanelEvent += new EventHandler(Demo1_ButtonClickDemo);
        if (!IsPostBack)
        {
            fill_ALL_Covered_Chaptes_Topics();
        }
    }
    #endregion

    #region Control Events

    #region Button Events

    protected void BtnPDF_Click(object sender, EventArgs e)
    {
        Page.RegisterStartupScript("Page Title", "<script language='javascript'>window.open('Print_PDF.aspx?page=SummaryReport','My Window','width=700,height=600,scroll=1');</script>");
    }

    protected void Demo1_ButtonClickDemo(object sender, EventArgs e)
    {
        fill_ALL_Covered_Chaptes_Topics();
    }

    protected void BtnSubmit_Click(object sender, EventArgs e)
    {
        BtnPDF.Visible = false;

        obj_BAL_Teacher_Dashboard = new Teacher_Dashboard_BLogic();
        obj_Teacher_Dashboard = new Teacher_Dashboard();

        obj_Teacher_Dashboard.SchoolID = Convert.ToInt64(Session["SchoolID"]);
        obj_Teacher_Dashboard.BMSID = Convert.ToInt64(Session["BMSID"]);
        obj_Teacher_Dashboard.SubjectID = Convert.ToInt16(Session["SubjectID"]);
        obj_Teacher_Dashboard.DivisionID = Convert.ToInt16(Session["DivisionID"]);
        obj_Teacher_Dashboard.EmployeeID = Convert.ToInt64(Session["EmpolyeeID"]);
       
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

            DataSet dsStudentList = new DataSet();
            dsStudentList = obj_BAL_Teacher_Dashboard.Get_Student_ExamSummary_Report(obj_Teacher_Dashboard);

            if (dsStudentList.Tables[0].Rows.Count > 0)
            {
                GridStudentList.DataSource = dsStudentList.Tables[0];
                GridStudentList.DataBind();
                Session["StudentResult"] = dsStudentList.Tables[0];
                Session["ChapName"] = ddlChapter.SelectedItem.ToString();
                Session["TopicName"] = ddlTopic.SelectedItem.ToString();
                Session["ExamName"] = "";
                Session["ToatlQues"] = "";
                Session["ToatlMarks"] = "";
                BtnPDF.Visible = true;
            }
            else
            {
                GridStudentList.DataSource = null;
                GridStudentList.DataBind();
                WebMsg.Show("No Data Fount.");
                BtnPDF.Visible = false;
            }
        }
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {

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

    public void ClearControls()
    {
        DropDownList[] disddl3 = { ddlChapter, ddlTopic };
        DisableDropDwon(disddl3);

        DropDownList[] disddl = { ddlChapter };
        EnableDropDwon(disddl);
       
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
           server control at run time. */
    }

    #endregion

 }