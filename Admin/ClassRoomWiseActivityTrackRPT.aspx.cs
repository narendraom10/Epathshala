using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Udev.UserMasterPage.Classes;
using System.Globalization;
using System.Data;
using System.Xml;

public partial class Admin_ClassRoomWiseActivityTrackRPT : System.Web.UI.Page
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

    #region "Culture"
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

    #region "Page Event"
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtFromDate.Text = DateTime.Today.ToString("dd-MM-yyyy");
            txtToDate.Text = DateTime.Today.ToString("dd-MM-yyyy");
            FillSchoolDropdown(ddlSchool);
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
        BindClassWiseAttendanceGrid();
    }

    public static DateTime Get_DDMMYYYY(String dat)
    {
        IFormatProvider culture = new CultureInfo("en-US", true);
        DateTime dt = DateTime.Parse(dat, culture, DateTimeStyles.AssumeLocal);
        return dt;
    }

    protected void btnreset_Click(object sender, EventArgs e)
    {
        Server.Transfer(Request.Path);
    }

    //protected void grdClassroomWiseAttendance_PageIndexChanging(object sender, GridViewPageEventArgs e)
    //{
    //    try
    //    {
    //        grdClassroomWiseAttendance.PageIndex = e.NewPageIndex;
    //        BindClassWiseAttendanceGrid();
    //    }
    //    catch (Exception ex)
    //    {
    //        WebMsg.Show(ex.Message);
    //    }
    //}

    //protected void ddlPageSelector_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        grdClassroomWiseAttendance.PageIndex = ((DropDownList)sender).SelectedIndex;
    //        BindClassWiseAttendanceGrid();
    //    }
    //    catch (Exception ex)
    //    {
    //        WebMsg.Show(ex.Message);
    //    }
    //}

    //protected void grdClassroomWiseAttendance_RowCreated(object sender, GridViewRowEventArgs e)
    //{
    //    try
    //    {
    //        if (e.Row.RowType == DataControlRowType.Pager)
    //        {
    //            GridViewOperations GrvOperation = new GridViewOperations();
    //            GrvOperation.SetPagerButtonStates(grdClassroomWiseAttendance, e.Row, this.Page);
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        WebMsg.Show(ex.Message);
    //    }
    //}

    //protected void grdClassroomWiseAttendance_Sorting(object sender, GridViewSortEventArgs e)
    //{
    //    try
    //    {
    //        if (e.SortExpression.Trim() == this.SortField)
    //            this.SortDirection = (this.SortDirection == "descending" ? "ascending" : "descending");
    //        else
    //            this.SortDirection = "ascending";
    //        this.SortField = e.SortExpression;
    //        BindClassWiseAttendanceGrid();
    //        GridViewOperations GrvOperation = new GridViewOperations();
    //        GrvOperation.GrvSortingSetImage(e, grdClassroomWiseAttendance, this.SortDirection);
    //    }
    //    catch (Exception ex)
    //    {
    //        WebMsg.Show(ex.Message);
    //    }
    //}

    //protected void grdClassroomWiseAttendance_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    try
    //    {
    //        if (e.Row.RowType == DataControlRowType.DataRow)
    //        {
    //            for (int i = 1; i < e.Row.Cells.Count; i++)
    //            {
    //                e.Row.Cells[i].Text = "<a href='ClassroomAttendance.aspx?BMSID=" + DataBinder.Eval(e.Row.DataItem, "BMSID").ToString() + "&Division=" + DataBinder.Eval(e.Row.DataItem, "Division").ToString() + "&DivisionID=" + DataBinder.Eval(e.Row.DataItem, "DivisionID").ToString() + "&Attendance=" + DataBinder.Eval(e.Row.DataItem, "Attendance").ToString() + "'>" + e.Row.Cells[i].Text + "</a>";
    //            }
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        WebMsg.Show(ex.Message.ToString());
    //    }
    //    finally
    //    {
    //    }
    //}

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
        //DataSet dtResult = new DataSet();
        //this.Obj_Dal_ClassroomWiseAttendance = new ClassroomWiseAttendance();
        //dtResult = this.Obj_Dal_ClassroomWiseAttendance.GetClasswiseAttendance(Convert.ToInt32(ddlSchool.SelectedValue), Convert.ToInt32(ddlBoard.SelectedValue), Convert.ToInt32(ddlMedium.SelectedValue), Convert.ToInt32(ddlStandard.SelectedValue), Convert.ToInt32(ddlDivision.SelectedValue), Get_DDMMYYYY(txtDate.Text));

        //Session["Date"] = txtDate.Text;

        //grdClassroomWiseAttendance.DataSource = dtResult;
        //grdClassroomWiseAttendance.DataBind();
    }
    #endregion
   
}