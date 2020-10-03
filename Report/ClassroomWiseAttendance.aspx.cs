using System;
using System.Data;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using Udev.UserMasterPage.Classes;
using System.Web;

public partial class Student_Report_ClassroomWiseAttendance : System.Web.UI.Page
{
    #region "Declaration"

    ClassroomWiseAttendance Obj_Dal_ClassroomWiseAttendance;
    DropDownFill DdlFilling;
    School_BLogic SchoolBLogic = new School_BLogic();
    SYS_Division_BLogic DivisionBLogic = new SYS_Division_BLogic();

    #endregion

    #region "Properties"

    string SortDirection
    {
        get
        {
            object o = this.ViewState["SortDirection"];
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
            this.ViewState["SortDirection"] = value;
        }
    }
    string SortField
    {
        get
        {
            object o = this.ViewState["SortField"];
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
            this.ViewState["SortField"] = value;
        }
    }

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
            if (Request.QueryString.Count > 0)
            {
                ddlSchool.SelectedValue = Request.QueryString["SchoolID"].ToString();
                ddlSchool_SelectedIndexChanged(sender, e);
                ddlBoard.SelectedValue = Convert.ToString(Request.QueryString["BoardID"]);
                ddlBoard_SelectedIndexChanged(sender, e);
                ddlMedium.SelectedValue = Session["MediumID"].ToString();
                ddlMedium_SelectedIndexChanged(sender, e);
                ddlStandard.SelectedValue = Session["StandardID"].ToString();
                ddlStandard_SelectedIndexChanged(sender, e);
                ddlDivision.SelectedValue = Session["DivisionID"].ToString();
                BindClassWiseAttendanceGrid();
            }
            else
            {
                txtDate.Text = DateTime.Today.ToString("dd-MMM-yyyy");
                FillSchoolDropdown(ddlSchool);
            }
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
    private void ddlDisable(DropDownList ddlDropDown, bool status)
    {
        ddlDropDown.Enabled = status;
        ddlDropDown.SelectedIndex = 0;
    }

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

            grdClassroomWiseAttendance.DataSource = null;
            grdClassroomWiseAttendance.DataBind();
            grdClassroomWiseAttendance.Visible = false;
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
        if (ddlSchool.SelectedIndex != 0)
        {
            grdClassroomWiseAttendance.Visible = true;
            BindClassWiseAttendanceGrid();
            StoreSession();
        }
    }

    private void StoreSession()
    {
        Session["SchooID"] = ddlSchool.SelectedValue;
        Session["BoardID"] = ddlBoard.SelectedValue;
        Session["MediumID"] = ddlMedium.SelectedValue;
        Session["StandardID"] = ddlStandard.SelectedValue;
        Session["DivisionID"] = ddlDivision.SelectedValue;
    }

    public static DateTime Get_DDMMYYYY(String dat,string lan)
    {
       
        IFormatProvider culture = new CultureInfo(lan, true);
        DateTime dt = DateTime.Parse(dat, culture, DateTimeStyles.AssumeLocal);
        return dt;
    }
    protected void grdClassroomWiseAttendance_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            grdClassroomWiseAttendance.PageIndex = e.NewPageIndex;
            BindClassWiseAttendanceGrid();
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }
    protected void ddlPageSelector_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            grdClassroomWiseAttendance.PageIndex = ((DropDownList)sender).SelectedIndex;
            BindClassWiseAttendanceGrid();
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }
    protected void grdClassroomWiseAttendance_RowCreated(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.Pager)
            {
                GridViewOperations GrvOperation = new GridViewOperations();
                GrvOperation.SetPagerButtonStates(grdClassroomWiseAttendance, e.Row, this.Page);
            }
            if (e.Row.RowType == System.Web.UI.WebControls.DataControlRowType.DataRow)
            {
                // when mouse is over the row, save original color to new attribute, and change it to highlight color
                e.Row.Attributes.Add("onmouseover", "this.originalstyle=this.style.backgroundColor;this.style.backgroundColor='#95DDDD';this.style.cursor='pointer'");

                // when mouse leaves the row, change the bg color to its original value  
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalstyle;");
            }

        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }
    protected void grdClassroomWiseAttendance_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            if (e.SortExpression.Trim() == this.SortField)
                this.SortDirection = (this.SortDirection == "descending" ? "ascending" : "descending");
            else
                this.SortDirection = "ascending";
            this.SortField = e.SortExpression;
            BindClassWiseAttendanceGrid();
            GridViewOperations GrvOperation = new GridViewOperations();
            GrvOperation.GrvSortingSetImage(e, grdClassroomWiseAttendance, this.SortDirection);
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }
    protected void grdClassroomWiseAttendance_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                for (int i = 1; i < e.Row.Cells.Count; i++)
                {
                    //add css to GridViewrow based on rowState
                    e.Row.CssClass = e.Row.RowState.ToString();
                    //Add onclick attribute to select row.
                    e.Row.Attributes.Add("onclick", String.Format("javascript:__doPostBack('ctl00$ContentPlaceHolder1$grdClassroomWiseAttendance','Select${0}')", e.Row.RowIndex));

                }
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
    #endregion

    #region "User Defined Functions"

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
            dsResult = DivisionBLogic.BAL_SYS_Division_SelectByBMSID(Convert.ToInt32(ddlBoard.SelectedValue), Convert.ToInt32(ddlMedium.SelectedValue), Convert.ToInt32(ddlSchool.SelectedValue), Convert.ToInt32(Session["SchoolID"]));

            DdlFilling = new DropDownFill();
            DdlFilling.BindDropDownByTable(ddlDivision, dsResult.Tables[0], "Division", "DivisionID");
            ddlDivision.Items.Insert(Convert.ToInt32(EnumFile.AssignValue.Zero), "-- Select --");
            ddlDivision.Items[0].Value = Convert.ToString((int)EnumFile.AssignValue.Zero);
        }
    }
    private void BindClassWiseAttendanceGrid()
    {
        DataSet dtResult = new DataSet();
        this.Obj_Dal_ClassroomWiseAttendance = new ClassroomWiseAttendance();
        dtResult = this.Obj_Dal_ClassroomWiseAttendance.GetClasswiseAttendance(Convert.ToInt32(ddlSchool.SelectedValue), Convert.ToInt32(ddlBoard.SelectedValue), Convert.ToInt32(ddlMedium.SelectedValue), Convert.ToInt32(ddlStandard.SelectedValue), Convert.ToInt32(ddlDivision.SelectedValue), Get_DDMMYYYY(txtDate.Text, Session["LANG"].ToString()));

        Session["Date"] = txtDate.Text;

        grdClassroomWiseAttendance.DataSource = dtResult;
        grdClassroomWiseAttendance.DataBind();
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        ddlDisable(ddlSchool, true);
        ddlDisable(ddlBoard, false);
        ddlDisable(ddlMedium, false);
        ddlDisable(ddlStandard, false);
        ddlDisable(ddlDivision, false);

        grdClassroomWiseAttendance.DataSource = null;
        grdClassroomWiseAttendance.DataBind();
        grdClassroomWiseAttendance.Visible = false;


    }
    #endregion

    protected void grdClassroomWiseAttendance_SelectedIndexChanged(object sender, EventArgs e)
    {

        string BMSID = grdClassroomWiseAttendance.SelectedDataKey.Values["BMSID"].ToString();
        string DivisionID = grdClassroomWiseAttendance.SelectedDataKey.Values["DivisionID"].ToString();
        string Division = grdClassroomWiseAttendance.SelectedDataKey.Values["Division"].ToString();
        string Attendance = grdClassroomWiseAttendance.SelectedDataKey.Values["Attendance"].ToString();
        string Path = "ClassroomAttendance.aspx?BMSID=" + BMSID + "&DivisionID=" + DivisionID + "&Division=" + Division + "&Attendance=" + Attendance;
        Response.Redirect(Path);
    }
}


