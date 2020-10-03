using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Udev.UserMasterPage.Classes;
using System.Globalization;

public partial class Student_Report_ClassroomAttendance : System.Web.UI.Page
{
    #region "Declaration"
    ClassroomWiseAttendance Obj_Dal_ClassroomWiseAttendance;
    int count = 0;
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
            Int32 BMSID = Convert.ToInt32(Request.QueryString["BMSID"]);
            Session["BMSID"] = Convert.ToInt32(Request.QueryString["BMSID"]);

            this.Obj_Dal_ClassroomWiseAttendance = new ClassroomWiseAttendance();
            DataSet dsResult = Obj_Dal_ClassroomWiseAttendance.SelectBMS(BMSID);

            lblSchoolValue.Text = Session["SchoolName"].ToString();
            lblAttendanceValue.Text = Request.QueryString["Attendance"].ToString();

            lblBMSValue.Text = dsResult.Tables[0].Rows[0]["BMS"].ToString();
            Session["BMS"] = dsResult.Tables[0].Rows[0]["BMS"].ToString();
            lblDivValue.Text = Request.QueryString["Division"];
            Session["DivisionName"] = Request.QueryString["Division"];
            lblDateValue.Text = Session["Date"].ToString();
            BindClassroomattendaceGrid();
        }
    }
    #endregion

    #region "Control Events"
    protected void ddlPageSelector_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            grdAttendance.PageIndex = ((DropDownList)sender).SelectedIndex;
            BindClassroomattendaceGrid();
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }


    protected void grdClassroomWiseAttendance_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            grdAttendance.PageIndex = e.NewPageIndex;
            BindClassroomattendaceGrid();
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
                GrvOperation.SetPagerButtonStates(grdAttendance, e.Row, this.Page);
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
            BindClassroomattendaceGrid();
            GridViewOperations GrvOperation = new GridViewOperations();
            GrvOperation.GrvSortingSetImage(e, grdAttendance, this.SortDirection);
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }
    protected void grdAttendance_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            for (int i = 1; i < e.Row.Cells.Count; i++)
            {
                if (e.Row.Cells[i].Text == "P")
                {
                    count = count + 1;
                    e.Row.Cells[i].Style.Add("color", "green");
                }
                else if (e.Row.Cells[i].Text == "A")
                {
                    e.Row.Cells[i].Style.Add("color", "red");
                }
            }
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[1].Text = "Total Attendance";
            e.Row.Cells[2].Text = Convert.ToString(count);
        }


        //if (e.Row.Cells[i].Text == "P")
        //{
        //    e.Row.Cells[i].Style.Add("color", "green");
        //}
        //else if (e.Row.Cells[i].Text == "A")
        //{
        //    e.Row.Cells[i].Style.Add("color", "red");
        //}
    }
    #endregion
    #region "User Defined Functions"

    private void BindClassroomattendaceGrid()
    {
        try
        {
            int SchoolID = Convert.ToInt32(Session["SchoolID"]);
            DateTime Date = Convert.ToDateTime(Session["Date"]);
            int BMSID = Convert.ToInt32(Request.QueryString["BMSID"].ToString());
            DataSet dtResult = new DataSet();
            this.Obj_Dal_ClassroomWiseAttendance = new ClassroomWiseAttendance();
            dtResult = this.Obj_Dal_ClassroomWiseAttendance.GetAttendance(SchoolID, Date, BMSID);
            grdAttendance.DataSource = dtResult;
            grdAttendance.DataBind();
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }
    #endregion
    protected void btnback_Click(object sender, EventArgs e)
    {
        Response.Redirect("ClassroomWiseAttendance.aspx?&SchoolID=" + Session["SchoolID"].ToString() + "&BoardID=" + Session["BoardID"].ToString());
    }
}