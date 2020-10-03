///<Summary>
///</Summary>

using System;
using System.Collections;
using System.Data;
using System.IO;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using Udev.UserMasterPage.Classes;
using System.Globalization;

public partial class Admin_ViewTeacherFeedback : System.Web.UI.Page
{

    #region "Variables"
    TeacherNotes_BLogic BAL_TeacherNotes;
    TeacherNotes TeacherNotes;
    SYS_TeacherActivityFeedback_BLogic BLogicActivityFeedBack;
    DropDownFill DdlFilling;
    EmailUtility EU = new EmailUtility();
    Employee_BLogic BLogicEmployee;
    SYS_BMS_BLogic BLogicSysBMS;
    #endregion

    # region "Properties"

    string SortDirection
    {
        get
        {
            object o = ViewState["SortDirection"];
            if (o == null)
                return String.Empty;
            else
                return (string)o;
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
                return String.Empty;
            else
                return (string)o;
        }
        set
        {
            ViewState["SortField"] = value;
        }
    }

    # endregion

    #region "Page events"

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
        try
        {
            if (!this.IsPostBack)
            {
                txtDate.Text = System.DateTime.Now.ToString("dd-MMM-yyyy");
                this.GetSchools();
                this.GetBMS();
                this.LoadSCT();
                this.GetEmployees();
                this.GetActivityFeedBackData();
            }
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }

    #endregion

    #region "Control Events"

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();

        try
        {
            GetActivityFeedBackData();
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }

    protected void ddlBMS_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlBMS.SelectedValue != Convert.ToString((int)EnumFile.AssignValue.Zero))
            {
                LoadSCT(Convert.ToInt32(ddlBMS.SelectedValue));
                GetEmployees(Convert.ToInt32(ddlSchool.SelectedValue), Convert.ToInt32(ddlBMS.SelectedValue));
            }
            else
            {
                LoadSCT(Convert.ToInt32(ddlBMS.SelectedValue));
                GetEmployees(Convert.ToInt32(ddlSchool.SelectedValue), Convert.ToInt32(ddlBMS.SelectedValue));
                ddlSCT.SelectedValue = Convert.ToString((int)EnumFile.AssignValue.Zero);
                ddlTeacher.SelectedValue = Convert.ToString((int)EnumFile.AssignValue.Zero);
            }
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }

    protected void btnSendEmail_Click(object sender, EventArgs e)
    {
        ArrayList alistContacts = new ArrayList();
        try
        {
            if (gvFeedBack.Rows.Count > 0)
            {
                alistContacts = GetEmailAddress();
                gvFeedBack.AllowPaging = false;
                GetActivityFeedBackData();
                gvFeedBack.Columns[7].Visible = false;
                gvFeedBack.Columns[6].Visible = true;
                gvFeedBack.Columns[5].Visible = false;
                StringBuilder strBuilder = new StringBuilder();
                StringWriter strWriter = new StringWriter(strBuilder);
                HtmlTextWriter htw = new HtmlTextWriter(strWriter);
                gvFeedBack.RenderControl(htw);
                string body = strBuilder.ToString();


                if (EmailUtility.SendEmail(alistContacts, "Feedback", body))
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Message", "<script> alert('Email has been sent successfully')</script>", false);
                }
                else
                {
                    //ClientScript.RegisterStartupScript(this.GetType(), "Mess", "<script> alert( 'Email failed..please contact administrator')</script>", false);
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Message", "<script> alert('Email failed..please contact administrator')</script>", false);
                }

                gvFeedBack.AllowPaging = true;
                GetActivityFeedBackData();
                gvFeedBack.Columns[7].Visible = true;
                gvFeedBack.Columns[6].Visible = false;
                gvFeedBack.Columns[5].Visible = true;
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Message", "<script> alert('No data found.')</script>", false);
            }
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }

    protected void gvFeedBack_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Pager)
        {
            GridViewOperations GrvOperation = new GridViewOperations();
            GrvOperation.SetPagerButtonStates(gvFeedBack, e.Row, this.Page);
        }
    }

    protected void gvFeedBack_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (e.SortExpression.Trim() == this.SortField)
            this.SortDirection = (this.SortDirection == "descending" ? "ascending" : "descending");
        else
            this.SortDirection = "ascending";
        this.SortField = e.SortExpression;
        GetActivityFeedBackData();
        GridViewOperations GrvOperation = new GridViewOperations();
        GrvOperation.GrvSortingSetImage(e, gvFeedBack, this.SortDirection);
    }

    protected void ddlPageSelector_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            gvFeedBack.PageIndex = ((DropDownList)sender).SelectedIndex;
            GetActivityFeedBackData();
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }

    protected void gvFeedBack_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvFeedBack.PageIndex = e.NewPageIndex;
            GetActivityFeedBackData();
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }

    protected void gvFeedBack_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "ViewFeedBack")
            {
                ImageButton IB = (ImageButton)e.CommandSource;
                GridViewRow gvr = (GridViewRow)IB.NamingContainer;
                int index = gvr.RowIndex;
                lblPopUpSchoolValue.Text = gvFeedBack.DataKeys[index]["Name"].ToString();
                lblPopUpDateValue.Text = Convert.ToDateTime(gvFeedBack.DataKeys[index]["CreatedOn"]).ToString("dd-MMM-yyyy");
                lblPopUPBMSSCTValue.Text = gvFeedBack.DataKeys[index]["BMS_SCT"].ToString();
                lblPopUpEmployeeValue.Text = gvFeedBack.DataKeys[index]["FirstName"].ToString();
                lblPopUpFeedBackValue.Text = gvFeedBack.DataKeys[index]["Feedback"].ToString();
                this.ModalPopUpFeedback.Show();
                this.upPopUp.Update();
            }
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        try
        {
            txtDate.Text = System.DateTime.Now.ToString("dd-MMM-yyyy");
            this.GetBMS();
            this.LoadSCT();
            this.GetEmployees();
            this.GetActivityFeedBackData();
            ClearControls();
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Message", "<script> alert('" + ex.Message + "')</script>", false);
        }
    }

    protected void ddlSchool_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlSchool.SelectedValue != Convert.ToString((int)EnumFile.AssignValue.Zero))
            {
                GetBMS(Convert.ToInt64(ddlSchool.SelectedValue));
            }
            else
            {
                GetBMS(Convert.ToInt64(ddlSchool.SelectedValue));
                ddlBMS.SelectedValue = Convert.ToString((int)EnumFile.AssignValue.Zero);
                ddlSCT.SelectedValue = Convert.ToString((int)EnumFile.AssignValue.Zero);
            }
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }

    #endregion

    #region "User defined functions"

    /// <summary>
    /// Limit method will be used to limit ffedback content in gridview.
    /// </summary>
    /// <param name="Desc">Feedback description</param>
    /// <param name="length">Maximum content Length</param>
    /// <returns></returns>
    protected string Limit(object Desc, int length)
    {
        StringBuilder strDesc = new StringBuilder();
        strDesc.Insert(0, Desc.ToString());

        if (strDesc.Length > length)
        {
            return strDesc.ToString().Substring(0, length) + "...";
        }
        else
        {
            return strDesc.ToString();
        }
    }

    /// <summary>
    /// Method will be used to load sct.
    /// </summary>
    /// <param name="BMSID">BMS ID</param>
    protected void LoadSCT(int BMSID = 0)
    {
        try
        {
            DataSet ds = new DataSet();
            DdlFilling = new DropDownFill();
            BAL_TeacherNotes = new TeacherNotes_BLogic();
            TeacherNotes = new TeacherNotes();
            TeacherNotes.BmsId = BMSID;
            string Mode = string.Empty;
            Mode = BMSID == 0 ? "AllSCT" : "FeedbackReport";
            ds = BAL_TeacherNotes.BAL_Load_SCT_BY_BMS(TeacherNotes, Mode);
            if (ds != null & ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > ((int)EnumFile.AssignValue.Zero))
                {
                    DdlFilling.BindDropDownByTable(ddlSCT, ds.Tables[0], "SCT", "SCTID");
                    ddlSCT.Items.Insert(Convert.ToInt32(EnumFile.AssignValue.Zero), "-- Select --");
                    ddlSCT.Items[0].Value = Convert.ToString((int)EnumFile.AssignValue.Zero);
                    ddlSCT.SelectedValue = Convert.ToString((int)EnumFile.AssignValue.Zero);

                }
                else
                {
                    ddlSCT.Items.Clear();
                    ddlSCT.Items.Insert(Convert.ToInt32(EnumFile.AssignValue.Zero), "-- Select --");
                    ddlSCT.Items[0].Value = Convert.ToString((int)EnumFile.AssignValue.Zero);
                    ddlSCT.SelectedValue = Convert.ToString((int)EnumFile.AssignValue.Zero);
                }
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Message", "<script> alert('" + ex.Message + "')</script>", false);
        }
    }

    /// <summary>
    /// Method will be used to get bms based on school id.
    /// </summary>
    /// <param name="SchoolID"></param>
    protected void GetBMS(Int64 SchoolID = 0)
    {
        try
        {
            DdlFilling = new DropDownFill();
            BLogicSysBMS = new SYS_BMS_BLogic();
            DataSet dsBMS = new DataSet();
            dsBMS = SchoolID == 0 ? BLogicSysBMS.BAL_SYS_BMS_SelectAll() : BLogicSysBMS.BAL_SYS_BMS_SelectAllBySchoolID(SchoolID);
            if (dsBMS != null & dsBMS.Tables.Count > 0)
            {
                if (dsBMS.Tables[0].Rows.Count > 0)
                {
                    DdlFilling.BindDropDownByTable(ddlBMS, dsBMS.Tables[0], "BMS", "BMSID");
                    ddlBMS.Items.Insert(Convert.ToInt32(EnumFile.AssignValue.Zero), "-- Select --");
                    ddlBMS.Items[0].Value = Convert.ToString((int)EnumFile.AssignValue.Zero);
                    ddlBMS.SelectedValue = Convert.ToString((int)EnumFile.AssignValue.Zero);
                }
                else
                {
                    ddlBMS.Items.Clear();
                    ddlBMS.Items.Insert(Convert.ToInt32(EnumFile.AssignValue.Zero), "-- Select --");
                    ddlBMS.Items[0].Value = Convert.ToString((int)EnumFile.AssignValue.Zero);
                    ddlBMS.SelectedValue = Convert.ToString((int)EnumFile.AssignValue.Zero);
                }
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Message", "<script> alert('" + ex.Message + "')</script>", false);
        }
    }


    /// <summary>
    /// Method will be used to get activity feedback data.
    /// </summary>
    protected void GetActivityFeedBackData()
    {
        DataSet ds = new DataSet();
        BLogicActivityFeedBack = new SYS_TeacherActivityFeedback_BLogic();
        string Condition = string.Empty;

        try
        {
            ds = BLogicActivityFeedBack.BAL_Select_Activity_Feedback_Report();
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ddlSchool.SelectedValue != Convert.ToString((int)EnumFile.AssignValue.Zero))
                    {
                        Condition = "SchoolID =" + ddlSchool.SelectedValue;
                    }

                    if (ddlBMS.SelectedValue != Convert.ToString((int)EnumFile.AssignValue.Zero))
                    {
                        if (Condition != string.Empty)
                        {
                            Condition = Condition + " and ";
                            Condition = Condition + "BMSID=" + ddlBMS.SelectedValue;
                        }
                        else
                        {
                            Condition = "BMSID=" + ddlBMS.SelectedValue;
                        }
                    }

                    if (txtDate.Text != string.Empty)
                    {
                        if (Condition != string.Empty)
                        {
                            Condition = Condition + " and ";
                            Condition = Condition + "CreatedOn='" + txtDate.Text + "'";
                        }
                        else
                        {
                            Condition = "CreatedOn='" + txtDate.Text + "'";
                        }
                    }

                    if (ddlSCT.SelectedValue != Convert.ToString((int)EnumFile.AssignValue.Zero))
                    {
                        if (Condition != string.Empty)
                        {
                            Condition = Condition + " and ";
                            Condition = Condition + "SCTID=" + ddlSCT.SelectedValue;
                        }
                        else
                        {
                            Condition = "SCTID=" + ddlSCT.SelectedValue;
                        }
                    }

                    if (ddlTeacher.SelectedValue != Convert.ToString((int)EnumFile.AssignValue.Zero))
                    {
                        if (Condition != string.Empty)
                        {
                            Condition = Condition + " and ";
                            Condition = Condition + "EmployeeID=" + ddlTeacher.SelectedValue;
                        }
                        else
                        {
                            Condition = "EmployeeID=" + ddlTeacher.SelectedValue;
                        }
                    }

                    DataView dv = new DataView(ds.Tables[0]);
                    dv.RowFilter = Condition;

                    DataSet dsSelectSub = new DataSet();
                    dsSelectSub.Tables.Add(dv.ToTable());

                    GridViewOperations GrvOperation = new GridViewOperations();
                    GrvOperation.BindGridWithSorting(gvFeedBack, dsSelectSub, this.SortField, this.SortDirection);
                }
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Message", "<script> alert('" + ex.Message + "')</script>", false);
        }
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

    /// <summary>
    /// Method will be used to clear all the controls.
    /// </summary>
    protected void ClearControls()
    {
        try
        {
            ddlSchool.SelectedValue = Convert.ToString((int)EnumFile.AssignValue.Zero);
            ddlBMS.SelectedValue = Convert.ToString((int)EnumFile.AssignValue.Zero);
            ddlSCT.SelectedValue = Convert.ToString((int)EnumFile.AssignValue.Zero);
            ddlTeacher.SelectedValue = Convert.ToString((int)EnumFile.AssignValue.Zero);
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Message", "<script> alert('" + ex.Message + "')</script>", false);
        }
    }

    /// <summary>
    /// Method will be used to get school list.
    /// </summary>
    protected void GetSchools()
    {
        try
        {
            School_BLogic SchoolBLogic = new School_BLogic();
            DataTable dt = new DataTable();
            dt = SchoolBLogic.BAL_SchoolAllNameWithID("Normal").Tables[0];
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    DdlFilling = new DropDownFill();
                    DdlFilling.BindDropDownByTable(ddlSchool, dt, "Name", "SchoolID");
                    ddlSchool.Items.Insert(0, "-- Select --");
                    ddlSchool.Items[0].Value = "0";
                    ddlSchool.SelectedValue = Convert.ToString((int)EnumFile.AssignValue.Zero);
                }
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Message", "<script> alert('" + ex.Message + "')</script>", false);
        }
    }

    protected void GetEmployees(int SchoolID = 0, int BMSID = 0)
    {
        try
        {
            DdlFilling = new DropDownFill();
            BLogicEmployee = new Employee_BLogic();
            DataSet dsEmployee = new DataSet();
            string Mode = string.Empty;
            Mode = (SchoolID == 0 & BMSID == 0) ? "AllTeacher" : "SchoolBoardWiseTeacher";
            dsEmployee = BLogicEmployee.BAL_Employee_SelectBySchoolStandard(SchoolID, BMSID, Mode);
            if (dsEmployee != null & dsEmployee.Tables.Count > 0)
            {
                if (dsEmployee.Tables[0].Rows.Count > 0)
                {
                    DdlFilling.BindDropDownByTable(ddlTeacher, dsEmployee.Tables[0], "Employee", "EmployeeID");
                    ddlTeacher.Items.Insert(Convert.ToInt32(EnumFile.AssignValue.Zero), "-- Select --");
                    ddlTeacher.Items[0].Value = Convert.ToString((int)EnumFile.AssignValue.Zero);
                    ddlTeacher.SelectedValue = Convert.ToString((int)EnumFile.AssignValue.Zero);
                }
                else
                {
                    ddlTeacher.Items.Clear();
                    ddlTeacher.Items.Insert(Convert.ToInt32(EnumFile.AssignValue.Zero), "-- Select --");
                    ddlTeacher.Items[0].Value = Convert.ToString((int)EnumFile.AssignValue.Zero);
                    ddlTeacher.SelectedValue = Convert.ToString((int)EnumFile.AssignValue.Zero);
                }
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Message", "<script> alert('" + ex.Message + "')</script>", false);
        }
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
           server control at run time. */
    }
    #endregion

}
