/// <summary>               
/// <Description>Attendance Control</Description>
/// <DevelopedBy>"Shailendrasinh"</DevelopedBy>
/// <DevelopedDate></DevelopedDate>
/// <UpdatedBy></UpdatedBy>
/// <UpdatedDate></UpdatedDate>
/// </summary>

using System;
using System.Data;
using System.Web.UI.WebControls;

public partial class Attendens : System.Web.UI.UserControl
{
    #region "Declaration"
    SYS_Attendance_BLogic BAttendance = new SYS_Attendance_BLogic();
    SYS_Attendance PSysAttendance = new SYS_Attendance();
    SYS_BMS_BLogic SYS_BMSBLogic;
    #endregion

    # region Properties
    # endregion

    #region "Page Event"
    protected void Page_Load(object sender, EventArgs e)
    {
        DataSet ds_BMS = new DataSet();

        if (!IsPostBack)
        {
            GetDDLBMSDetails();
            BindDivisionCheckBoxList();
            txtStartDate.Text = DateTime.Today.ToString("dd-MMM-yyyy");
            txtEndDate.Text = DateTime.Today.ToString("dd-MMM-yyyy");
            BindGridAttandance();
        }
    }
    #endregion

    #region "Control Events"
    protected void btnOk_Click(object sender, EventArgs e)
    {
        BindGridAttandance();
    }
    protected void ddlPageSelector_SelectedIndexChanged(object sender, EventArgs e)
    {
        grdAttandance.PageIndex = ((DropDownList)sender).SelectedIndex;
        BindGridAttandance();
    }
    protected void gvAnnouncementDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            DropDownList DDLSelectPage = (DropDownList)grdAttandance.BottomPagerRow.FindControl("ddlPageSelector");
            DDLSelectPage.SelectedIndex = e.NewPageIndex;
            grdAttandance.PageIndex = e.NewPageIndex;
            BindGridAttandance();
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message.ToString());
        }
    }
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
    protected void gvAnnouncementDetails_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Pager)
        {
            GridViewOperations GrvOperation = new GridViewOperations();
            GrvOperation.SetPagerButtonStates(grdAttandance, e.Row, this.Page);
        }
    }
    protected void gvAnnouncementDetails_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (e.SortExpression.Trim() == this.SortField)
        {
            this.SortDirection = (this.SortDirection == "descending" ? "ascending" : "descending");
        }
        else
        {
            this.SortDirection = "ascending";
        }
        this.SortField = e.SortExpression;
        BindGridAttandance();
        GridViewOperations GrvOperation = new GridViewOperations();
        GrvOperation.GrvSortingSetImage(e, grdAttandance, this.SortDirection);
    }
    protected void ddlBoardMediumStandard_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindDivisionCheckBoxList();
    }
    #endregion

    #region "User Defined Functions"
    private void GetDDLBMSDetails()
    {
        DropDownFill DdlFilling = new DropDownFill();
        SYS_BMSBLogic = new SYS_BMS_BLogic();
        DataSet dsselectBMS = new DataSet();
        dsselectBMS = SYS_BMSBLogic.BAL_SYS_BMS_SelectAllBySchoolID(Convert.ToInt64(Session["SchoolID"]));
        if (dsselectBMS.Tables.Count > Convert.ToInt32(EnumFile.AssignValue.Zero))
        {
            DdlFilling.BindDropDownByTable(ddlBoardMediumStandard, dsselectBMS.Tables[0], "BMS", "BMSID");
            ddlBoardMediumStandard.Items.Insert(Convert.ToInt32(EnumFile.AssignValue.Zero), "ALL");
            ddlBoardMediumStandard.Items[0].Value = ((int)EnumFile.AssignValue.Zero).ToString();
        }
        else
        {
            DdlFilling.ClearDropDownListRef(ddlBoardMediumStandard);
        }
    }
    private void BindDivisionCheckBoxList()
    {
        CheckBoxFill clstFilling = new CheckBoxFill();

        Int32 BMSID = ((int)EnumFile.AssignValue.Zero);
        if (IsPostBack)
        {
            BMSID = Convert.ToInt32(ddlBoardMediumStandard.SelectedValue);
        }
        clstFilling.FillCheckBoxForAnnouncementBySchoolBMSID(clstDivision, Convert.ToInt32(Session["SchoolID"]), BMSID);

        foreach (ListItem chk in clstDivision.Items)
        {
            if (chk.Selected == false)
            {
                chk.Selected = true;
            }
        }
    }
    private void BindGridAttandance()
    {
        int count = ((int)EnumFile.AssignValue.Zero);
        string divisionidstr = string.Empty;

        DataSet ds1 = new DataSet();
        PSysAttendance.BMSID = int.Parse(ddlBoardMediumStandard.SelectedValue);

        foreach (ListItem chk in clstDivision.Items)
        {
            if (chk.Selected == true)
            {
                if (count == ((int)EnumFile.AssignValue.Zero))
                {
                    divisionidstr = chk.Value;
                }
                else
                {
                    divisionidstr = divisionidstr + " , " + chk.Value;
                }
                count = count + 1;
            }
        }
        if (count == ((int)EnumFile.AssignValue.Zero))
        {
            WebMsg.Show("Please select atleast one Division");
        }
        else
        {
            PSysAttendance.DivisionId = int.Parse(clstDivision.SelectedValue);
            PSysAttendance.DivisionIdstr = divisionidstr;
            PSysAttendance.StartDate = Convert.ToDateTime(txtStartDate.Text);
            PSysAttendance.EndDate = Convert.ToDateTime(txtEndDate.Text);
            ds1 = BAttendance.BAL_SYS_Attendance_Details(PSysAttendance, "");
            grdAttandance.DataSource = ds1;
            grdAttandance.DataBind();
        }
    }
    #endregion

}