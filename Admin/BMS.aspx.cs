/// <summary>               
/// <Description>Board medium standard mapping management</Description>
/// <DevelopedBy>"NARENDRASINH, YOGESH"</DevelopedBy>
/// <DevelopedDate></DevelopedDate>
/// <UpdatedBy>"NARENDRASINH"</UpdatedBy>
/// <UpdatedDate></UpdatedDate>
/// </summary>
using System;
using System.Data;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.WebControls;
using Udev.UserMasterPage.Classes;

public partial class BMS : System.Web.UI.Page
{
    #region "Variables"

    SYS_BMS_BLogic BAL_SYS_BMS;
    SYS_BMS SYS_BMS;
    SYS_Board PBoard = new SYS_Board();
    SYS_Medium PMedium = new SYS_Medium();
    SYS_Standard PStandard = new SYS_Standard();
    SYS_Board_BLogic BLBoard = new SYS_Board_BLogic();
    SYS_Medium_BLogic BlMedium = new SYS_Medium_BLogic();
    SYS_Standard_BLogic BStandard = new SYS_Standard_BLogic();
    int Status = 0;
    #endregion

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
            this.ViewState["SortDirection"] = value;
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
            this.ViewState["SortField"] = value;
        }
    }
    #endregion

    #region "Page Events"
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.GetBoardsBothDDL();
            this.bindgrvSYS_BMSdetail();
        }
    }
    #endregion

    #region "Control Events"

    protected void BtnSave_Click(object sender, EventArgs e)
    {
        try
        {
            this.SYS_BMS = new SYS_BMS();
            this.BAL_SYS_BMS = new SYS_BMS_BLogic();
            SYS_BMS.boardid = Convert.ToInt32(ddlBoard.SelectedValue);
            SYS_BMS.mediumid = Convert.ToInt32(ddlMedium.SelectedValue);
            SYS_BMS.standardid = Convert.ToInt32(ddlStandard.SelectedValue);

            if (rlstAddSemester.SelectedValue == "0")
            {
                SYS_BMS.issemester = false;
            }
            else if (rlstAddSemester.SelectedValue == "1")
            {
                SYS_BMS.issemester = true;
            }
            SYS_BMS.createdby = Convert.ToInt32(Session["EmpolyeeID"]);
            Status = BAL_SYS_BMS.BAL_SYS_BMS_Insert(SYS_BMS, "Insert");
            if (Status == 1)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Message", "<script> alert('Record successfully inserted.')</script>", false);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Message", "<script> alert('Record not inserted.')</script>", false);
            }
            RefreshPageControls();
            pnlSearch.CssClass = "Visible";
        }
        catch (Exception ex)
        {
            throw ex;
        }
        ////finally
        ////{
        ////}
    }

    protected void BtnCancel_Click(object sender, EventArgs e)
    {
        this.ClearControls();
        this.AllPanelInvisible();
        pnlAdd.CssClass = "Visible";
    }

    protected void grvSYS_BMSdetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvSYS_BMSdetail.PageIndex = e.NewPageIndex;
        this.bindgrvSYS_BMSdetail();
    }

    protected void grvSYS_BMSdetail_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (e.SortExpression.Trim() == this.SortField)
        {
            this.SortDirection = (this.SortDirection == "descending" ? "ascending" : "descending");
        }
        else
        {
            this.SortDirection = "ascending";
            this.SortField = e.SortExpression;
        }

        GridViewOperations GrvOperation = new GridViewOperations();
        GrvOperation.GrvSortingSetImage(e, grvSYS_BMSdetail, this.SortDirection);
    }

    protected void grvSYS_BMSdetail_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Pager)
        {
            GridViewOperations GrvOperation = new GridViewOperations();
            GrvOperation.SetPagerButtonStates(grvSYS_BMSdetail, e.Row, this.Page);
        }
    }

    protected void ddlPageSelector_SelectedIndexChanged(object sender, EventArgs e)
    {
        grvSYS_BMSdetail.PageIndex = ((DropDownList)sender).SelectedIndex;
        this.bindgrvSYS_BMSdetail();
    }

    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        this.bindgrvSYS_BMSdetail();
    }

    protected void BtnUpdate_Click(object sender, EventArgs e)
    {
        SYS_BMS = new SYS_BMS();
        this.BAL_SYS_BMS = new SYS_BMS_BLogic();
        SYS_BMS.bmsid = Convert.ToInt32(ViewState["bmsid"].ToString());
        SYS_BMS.boardid = Convert.ToInt32(ddlBoardEdit.SelectedValue);
        SYS_BMS.mediumid = Convert.ToInt32(ddlMediumEdit.SelectedValue);
        SYS_BMS.standardid = Convert.ToInt32(ddlStandardEdit.SelectedValue);
        ////SYS_BMS.bms = txtBMSEdit.Text;
        if (rlstUpdateActive.SelectedValue == "0")
        {
            SYS_BMS.issemester = false;
        }
        else if (rlstUpdateActive.SelectedValue == "1")
        {
            SYS_BMS.issemester = true;
        }
        ////SYS_BMS.createdon = txtCreatedOnEdit.Text;
        SYS_BMS.createdby = Convert.ToInt32(Session["EmpolyeeID"]);
        Status = BAL_SYS_BMS.BAL_SYS_BMS_Update(SYS_BMS, "Update");
        if (Status == 1)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Message", "<script> alert('Record successfully updated.')</script>", false);
        }
        else
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Message", "<script> alert('Record not updated.')</script>", false);
        }

        RefreshPageControls();
    }

    protected void BtnCancelEdit_Click(object sender, EventArgs e)
    {
        this.ClearControlsEdit();
    }

    protected void IbtnDelete_Click(object sender, ImageClickEventArgs e)
    {
        int CountChecked = 0;
        string BMSIDStr = string.Empty;
        foreach (GridViewRow gr in grvSYS_BMSdetail.Rows)
        {
            CheckBox chk = new CheckBox();
            chk = (CheckBox)gr.FindControl("chkSelect");
            if (chk.Checked == true)
            {
                if (CountChecked == 0)
                {
                    BMSIDStr = grvSYS_BMSdetail.DataKeys[gr.RowIndex]["BMSID"].ToString();
                }
                else
                {
                    BMSIDStr = BMSIDStr + "," + grvSYS_BMSdetail.DataKeys[gr.RowIndex]["BMSID"].ToString();
                }

                CountChecked = CountChecked + 1;
            }
        }

        if (CountChecked == 0)
        {
            WebMsg.Show("Please select one record to delete.");
        }
        else
        {
            SYS_BMS = new SYS_BMS();
            this.BAL_SYS_BMS = new SYS_BMS_BLogic();
            SYS_BMS.bmsidStr = BMSIDStr;
            this.BAL_SYS_BMS.BAL_SYS_BMS_Delete(SYS_BMS, "Delete");
            //if (Status == 1)
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Message", "<script> alert('Record successfully updated.')</script>", false);
            //}
            //else
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Message", "<script> alert('Record not updated.')</script>", false);
            //}
            RefreshPageControls();
        }
    }

    protected void DdlBoard_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlBoard.SelectedValue != ((int)EnumFile.AssignValue.Zero).ToString())
            {
                ddlMedium.Items.Clear();
                this.BlMedium.BindMediumByBoardID(ddlMedium, "Select", int.Parse(ddlBoard.SelectedValue));
                ddlMedium.Items[0].Value = ((int)EnumFile.AssignValue.Zero).ToString();
                ddlMedium.Enabled = true;
                ddlStandard.Items.Clear();
                ddlStandard.Items.Insert(((int)EnumFile.AssignValue.Zero), "-- Select --");
                ddlStandard.Items[0].Value = ((int)EnumFile.AssignValue.Zero).ToString();
                ddlStandard.Enabled = false;
            }
            else if (ddlBoard.SelectedValue == ((int)EnumFile.AssignValue.Zero).ToString())
            {
                ddlMedium.Items.Clear();
                ddlMedium.Items.Insert(((int)EnumFile.AssignValue.Zero), "-- Select --");
                ddlMedium.Items[0].Value = ((int)EnumFile.AssignValue.Zero).ToString();
                ddlMedium.Enabled = false;
                ddlStandard.Items.Clear();
                ddlStandard.Items.Insert(((int)EnumFile.AssignValue.Zero), "-- Select --");
                ddlStandard.Items[0].Value = ((int)EnumFile.AssignValue.Zero).ToString();
                ddlStandard.Enabled = false;
            }
        }
        catch (Exception)
        {
        }

        pnlAdd.CssClass = "Visible";
        pnlSearch.CssClass = "InVisible";
    }

    protected void DdlMedium_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlMedium.SelectedValue != ((int)EnumFile.AssignValue.Zero).ToString())
            {
                ddlStandard.Items.Clear();
                ////BStandard.BindListByID(GvStandards, "GetStandardByBoardMediumID", int.Parse(DdlBoard.SelectedValue), int.Parse(DdlMedium.SelectedValue));
                this.BStandard.BindStandardListByID(ddlStandard, "Select", int.Parse(ddlBoard.SelectedValue), int.Parse(ddlMedium.SelectedValue));
                ddlStandard.Enabled = true;
            }
            else if (ddlMedium.SelectedValue == ((int)EnumFile.AssignValue.Zero).ToString())
            {
                ddlStandard.Items.Clear();
                ddlStandard.Items.Insert(((int)EnumFile.AssignValue.Zero), "-- Select --");
                ddlStandard.Items[0].Value = ((int)EnumFile.AssignValue.Zero).ToString();
                ddlStandard.Enabled = false;
            }
        }
        catch (Exception)
        {
        }

        pnlAdd.CssClass = "Visible";
        pnlSearch.CssClass = "InVisible";
    }

    protected void ibtnRefresh_Click(object sender, ImageClickEventArgs e)
    {
        RefreshPageControls();
    }

    protected void IbtnEdit_Click(object sender, ImageClickEventArgs e)
    {
        if (pnlEdit.CssClass == "Visible")
        {
            this.AllPanelInvisible();
            pnlSearch.CssClass = "Visible";
            this.ClearControlsEdit();
        }
        else
        {
            int CountChecked = 0;
            int GRrowIndex = 0;
            foreach (GridViewRow gr in grvSYS_BMSdetail.Rows)
            {
                CheckBox chk = new CheckBox();
                chk = (CheckBox)gr.FindControl("chkSelect");
                if (chk.Checked == true)
                {
                    CountChecked = CountChecked + 1;
                    GRrowIndex = gr.RowIndex;
                }
            }

            if (CountChecked == 0 || CountChecked > 1)
            {
                WebMsg.Show("Please select one record to update.");
            }
            else
            {
                this.AllPanelInvisible();
                pnlEdit.CssClass = "Visible";
                int index = GRrowIndex;
                ViewState["bmsid"] = Convert.ToInt32(grvSYS_BMSdetail.DataKeys[index]["BMSID"]);
                ddlBoardEdit.SelectedValue = Convert.ToString(grvSYS_BMSdetail.DataKeys[index]["BoardID"]);
                this.BindMediumForEdit();
                ddlMediumEdit.SelectedValue = Convert.ToString(grvSYS_BMSdetail.DataKeys[index]["MediumID"]);
                this.BindStandardForEdit();
                ddlStandardEdit.SelectedValue = Convert.ToString(grvSYS_BMSdetail.DataKeys[index]["StandardID"]);
                string Semester = Convert.ToString(grvSYS_BMSdetail.DataKeys[index]["IsSemester"]);
                if (Semester == "Yes")
                {
                    rlstUpdateActive.SelectedValue = "1";
                }
                else
                {
                    rlstUpdateActive.SelectedValue = "0";
                }
            }
        }
    }
    protected void btnSearchReset_Click(object sender, EventArgs e)
    {
        RefreshPageControls();
    }
    #endregion

    #region "User Defined Functions"

    protected override void InitializeCulture()
    {
        string culture = Convert.ToString(Session[Global.SESSION_KEY_CULTURE]);
        //// 'set culture to current thread 
        System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture);
        System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);
        ////call base class 
        base.InitializeCulture();
    }

    protected void GetBoardsBothDDL()
    {
        try
        {
            DataSet dsBoards = new DataSet();
            PBoard.boardid = ((int)EnumFile.AssignValue.Zero);
            dsBoards = this.BLBoard.BAL_SYS_Board_Select(PBoard, "Select");
            DropDownFill objddlfill = new DropDownFill();
            objddlfill.BindDropDownByTable(ddlBoard, dsBoards.Tables[0], "Board", "BoardID");
            objddlfill.BindDropDownByTable(ddlBoardEdit, dsBoards.Tables[0], "Board", "BoardID");
            ddlMedium.Enabled = false;
            ddlStandard.Enabled = false;
        }
        catch (Exception)
        {
        }
    }

    private void AllPanelInvisible()
    {
        pnlAdd.CssClass = "InVisible";
        pnlEdit.CssClass = "InVisible";
        pnlSearch.CssClass = "InVisible";
    }

    private void ClearControls()
    {
        DropDownFill objddl = new DropDownFill();
        objddl.ClearDropDownListRef(ddlBoard);
        this.GetBoardsBothDDL();
        objddl.ClearDropDownListRef(ddlMedium);
        objddl.ClearDropDownListRef(ddlStandard);
        rlstAddSemester.ClearSelection();
    }

    private void ClearControlsEdit()
    {
        this.AllPanelInvisible();
        pnlSearch.CssClass = "Visible";
        DropDownFill objddl = new DropDownFill();
        objddl.ClearDropDownListRef(ddlBoardEdit);
        this.GetBoardsBothDDL();
        objddl.ClearDropDownListRef(ddlMediumEdit);
        objddl.ClearDropDownListRef(ddlStandardEdit);
        rlstUpdateActive.ClearSelection();
    }

    private void bindgrvSYS_BMSdetail()
    {
        SYS_BMS = new SYS_BMS();
        this.BAL_SYS_BMS = new SYS_BMS_BLogic();

        DataSet dsSelect = new DataSet();
        dsSelect = this.BAL_SYS_BMS.BAL_SYS_BMS_Select(SYS_BMS, "SelectAll");
        if (dsSelect.Tables.Count > 0)
        {
            string searchCondition = string.Empty;

            if (txtBoardSearch.Text != string.Empty)
            {
                searchCondition = "Board like '%" + txtBoardSearch.Text + "%'";
            }

            if (txtMediumSearch.Text != string.Empty)
            {
                if (searchCondition != string.Empty)
                {
                    searchCondition = searchCondition + " and ";
                }

                searchCondition = "Medium like '%" + txtMediumSearch.Text + "%'";
            }

            if (txtStandardSearch.Text != string.Empty)
            {
                if (searchCondition != string.Empty)
                {
                    searchCondition = searchCondition + " and ";
                }

                searchCondition = "Standard like '%" + txtStandardSearch.Text + "%'";
            }

            if (rlstActive.SelectedValue == "0")
            {
                if (searchCondition != string.Empty)
                {
                    searchCondition = searchCondition + " and ";
                }

                searchCondition = searchCondition + "IsSemester ='No'";
            }
            else if (rlstActive.SelectedValue == "1")
            {
                if (searchCondition != string.Empty)
                {
                    searchCondition = searchCondition + " and ";
                }

                searchCondition = searchCondition + "IsSemester ='Yes'";
            }

            DataView dv = new DataView(dsSelect.Tables[0]);
            dv.RowFilter = searchCondition;

            DataSet dsSelectSub = new DataSet();
            dsSelectSub.Tables.Add(dv.ToTable());

            GridViewOperations GrvOperation = new GridViewOperations();
            GrvOperation.BindGridWithSorting(grvSYS_BMSdetail, dsSelectSub, this.SortField, this.SortDirection);
        }
        else
        {
            grvSYS_BMSdetail.DataSource = null;
            grvSYS_BMSdetail.DataBind();
        }
    }

    private void RefreshPageControls()
    {
        txtBoardSearch.Text = string.Empty;
        txtMediumSearch.Text = string.Empty;
        txtStandardSearch.Text = string.Empty;
        rlstActive.ClearSelection();

        this.ClearControls();
        this.ClearControlsEdit();
        this.bindgrvSYS_BMSdetail();
    }

    private void BindMediumForEdit()
    {
        try
        {
            if (ddlBoardEdit.SelectedValue != ((int)EnumFile.AssignValue.Zero).ToString())
            {
                ddlMediumEdit.Items.Clear();
                this.BlMedium.BindMediumByBoardID(ddlMediumEdit, "Select", int.Parse(ddlBoardEdit.SelectedValue));

                ddlStandardEdit.Items.Clear();
                ddlStandardEdit.Items.Insert(((int)EnumFile.AssignValue.Zero), "-- Select --");
                ddlStandardEdit.Items[0].Value = ((int)EnumFile.AssignValue.Zero).ToString();
            }
            else if (ddlBoardEdit.SelectedValue == ((int)EnumFile.AssignValue.Zero).ToString())
            {
                ddlMediumEdit.Items.Clear();
                ddlMediumEdit.Items.Insert(((int)EnumFile.AssignValue.Zero), "-- Select --");
                ddlMediumEdit.Items[0].Value = ((int)EnumFile.AssignValue.Zero).ToString();
                ddlStandardEdit.Items.Clear();
                ddlStandardEdit.Items.Insert(((int)EnumFile.AssignValue.Zero), "-- Select --");
                ddlStandardEdit.Items[0].Value = ((int)EnumFile.AssignValue.Zero).ToString();
            }
        }
        catch (Exception)
        {
        }
    }

    private void BindStandardForEdit()
    {
        try
        {
            if (ddlMediumEdit.SelectedValue != ((int)EnumFile.AssignValue.Zero).ToString())
            {
                ddlStandardEdit.Items.Clear();
                ////BStandard.BindListByID(GvStandards, "GetStandardByBoardMediumID", int.Parse(DdlBoard.SelectedValue), int.Parse(DdlMedium.SelectedValue));
                this.BStandard.BindStandardListByID(ddlStandardEdit, "Select", int.Parse(ddlBoardEdit.SelectedValue), int.Parse(ddlMediumEdit.SelectedValue));
            }
            else if (ddlMediumEdit.SelectedValue == ((int)EnumFile.AssignValue.Zero).ToString())
            {
                ddlStandardEdit.Items.Clear();
                ddlStandardEdit.Items.Insert(((int)EnumFile.AssignValue.Zero), "-- Select --");
                ddlStandardEdit.Items[0].Value = ((int)EnumFile.AssignValue.Zero).ToString();
            }
        }
        catch (Exception)
        {
        }
    }
    #endregion
}