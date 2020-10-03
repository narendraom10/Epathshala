//// <summary>               
//// <Description>Announcement Management</Description>
//// <DevelopedBy>"Bhavesh Prajapati"</DevelopedBy>
//// <DevelopedDate>"20-Nov-2013"</DevelopedDate>
//// <UpdatedBy>""</UpdatedBy>
//// <UpdatedDate></UpdatedDate>
//// </summary>
using System;
using System.Data;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.WebControls;
using Udev.UserMasterPage.Classes;

public partial class SchoolAdmin_ViewAnnouncement_ : System.Web.UI.Page
{
    #region "Declaration"
    SYS_BMS_BLogic SYS_BMSBLogic = new SYS_BMS_BLogic();
    Announcement_BLogic BAL_Announcement = new Announcement_BLogic();
    Announcement PAnnouncement = new Announcement();
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

    #region "Page Event"
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            this.ibtnDelete.Attributes.Add("onclick", "if(confirm('Are you sure to delete?')){}else{return false}");
            this.BindDivisionCheckBoxList();
            this.GetDDLBMSDetails();
            this.BindGridAnnouncement();
        }
    }

    #endregion

    #region "User Defined Functions"
    /// <summary>
    /// <Description>Bind Announcement Grid with all Announcement Details</Description>
    /// </summary>
    protected void BindGridAnnouncement()
    {
        DataSet dsSelect = new DataSet();
        dsSelect = this.BAL_Announcement.BAL_SelectAnnouncementBySchoolID(Convert.ToInt32(this.Session["SchoolID"]), "SelectAll");
        gvAnnouncementDetails.DataSource = dsSelect;
        if (dsSelect.Tables.Count > ((int)EnumFile.AssignValue.Zero))
        {
            GridViewOperations GvOperation = new GridViewOperations();
            GvOperation.BindGridWithSorting(this.gvAnnouncementDetails, dsSelect, this.SortField, this.SortDirection);
        }
        else
        {
            gvAnnouncementDetails.DataSource = null;
            gvAnnouncementDetails.DataBind();
        }
    }

    //// <summary>
    //// Bind Division CheckBox based on BMSID
    //// </summary>
    protected void BindDivisionCheckBoxList()
    {
        CheckBoxFill clstFilling = new CheckBoxFill();
        ////DdlFilling.BindCheckBoxListByDynamic(clstDivision, "SYS_Division", "Division", "DivisionID", " IsActive = 1");
        Int32 BMSID = (int)EnumFile.AssignValue.Zero;
        if (this.IsPostBack)
        {
            BMSID = Convert.ToInt32(ddlBoardMediumStandard.SelectedValue);
        }

        clstFilling.FillCheckBoxForAnnouncementBySchoolBMSID(this.clstDivision, Convert.ToInt32(this.Session["SchoolID"]), BMSID);
    }

    /// <summary>
    /// This method used for bind BMS Dropdown based on SchoolID
    /// </summary>
    protected void GetDDLBMSDetails()
    {
        DropDownFill DdlFilling = new DropDownFill();
        this.SYS_BMSBLogic = new SYS_BMS_BLogic();
        DataSet dsselectBMS = new DataSet();
        dsselectBMS = this.SYS_BMSBLogic.BAL_SYS_BMS_SelectAllBySchoolID(Convert.ToInt64(this.Session["SchoolID"]));
        if (dsselectBMS.Tables.Count > ((int)EnumFile.AssignValue.Zero))
        {
            DdlFilling.BindDropDownByTable(this.ddlBoardMediumStandard, dsselectBMS.Tables[0], "BMS", "BMSID");
            ddlBoardMediumStandard.Items.Insert((int)EnumFile.AssignValue.Zero, "ALL");
            ddlBoardMediumStandard.Items[0].Value = ((int)EnumFile.AssignValue.Zero).ToString();
        }
        else
        {
            DdlFilling.ClearDropDownListRef(this.ddlBoardMediumStandard);
        }
    }

    /// <summary>
    /// Method will be used to refresh all page controls.
    /// </summary>
    protected void RefreshControls()
    {
        edtAnnouncement.Visible = false;
        txtSearchAnnouncement.Visible = true;
        txtSearchAnnouncement.Text = string.Empty;
        ddlBoardMediumStandard.SelectedIndex = Convert.ToInt32(EnumFile.AssignValue.Zero);
        clstDivision.ClearSelection();
        txtStartDate.Text = string.Empty;
        txtEndDate.Text = string.Empty;
        edtAnnouncement.Content = string.Empty;
        btnUpdate.Visible = false;
        btnAdd.Visible = false;
        btnSearch.Visible = true;
        this.BindGridAnnouncement();
        this.BindDivisionCheckBoxList();
    }

    protected override void InitializeCulture()
    {
        string culture = Convert.ToString(Session[Global.SESSION_KEY_CULTURE]);
        //// 'set culture to current thread 
        System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture);
        System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);
        ////call base class 
        base.InitializeCulture();
    }

    #endregion

    #region "Control Events"

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        int count = Convert.ToInt32(EnumFile.AssignValue.Zero);
        string divisionidstr = string.Empty;
        foreach (ListItem chk in clstDivision.Items)
        {
            if (chk.Selected == true)
            {
                if (count == Convert.ToInt32(EnumFile.AssignValue.Zero))
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
        ////divisionidstr = "' " + divisionidstr + " '";
        if (count == Convert.ToInt32(EnumFile.AssignValue.Zero))
        {
            WebMsg.Show("Please select atleast one Division");
        }
        else
        {
            try
            {
                DataSet dsselectErrors = new DataSet();
                this.PAnnouncement.bmsid = Convert.ToInt32(ddlBoardMediumStandard.SelectedValue.ToString());
                if (divisionidstr == string.Empty)
                {
                    divisionidstr = ((int)EnumFile.AssignValue.Zero).ToString();
                }

                this.PAnnouncement.divisionstr = divisionidstr;
                string IFormat = "dd-MMM-yyyy";

                DateTime StartDate = Convert.ToDateTime(DateTime.Parse(txtStartDate.Text).ToString(IFormat));
                DateTime EndDate = Convert.ToDateTime(DateTime.Parse(txtEndDate.Text).ToString(IFormat));

                if (StartDate > EndDate)
                {
                    WebMsg.Show("End Date Larger than StartDate");
                }
                else
                {
                    this.PAnnouncement.divisionid = Convert.ToInt32(clstDivision.SelectedValue);
                    this.PAnnouncement.startdate = StartDate;
                    this.PAnnouncement.enddate = EndDate;

                    //Label lbl = new Label();
                    //lbl.Text = Server.HtmlDecode(edtAnnouncement.Content.ToString());
                    //this.PAnnouncement.announcement = lbl.Text;

                    //Literal ltrl = new Literal();
                    //ltrl.Text = HttpUtility.HtmlDecode(edtAnnouncement.Content.ToString());

                    //Literal ltr1 = new Literal();
                    //ltr1.Text = HttpUtility.HtmlEncode(edtAnnouncement.Content.ToString());

                    //this.PAnnouncement.announcement = ltrl.Text;
                    ////PAnnouncement.announcement = edtAnnouncement.Content.ToString();
                    ////PAnnouncement.announcement = edtAnnouncement.Content.Substring(0, edtAnnouncement.Content.Length - 6);
                    this.PAnnouncement.announcement = txtSearchAnnouncement.Text;
                    this.PAnnouncement.createdby = Convert.ToInt32(this.Session["EmpolyeeID"]);
                    this.PAnnouncement.modifiedby = Convert.ToInt32(this.Session["EmpolyeeID"]);

                    dsselectErrors = this.BAL_Announcement.BAL_Announcement_Insert(this.PAnnouncement, "Insert");

                    if (dsselectErrors.Tables.Count > ((int)EnumFile.AssignValue.Zero))
                    {
                        if (dsselectErrors.Tables[0].Rows.Count > ((int)EnumFile.AssignValue.Zero))
                        {
                            if (Convert.ToInt32(dsselectErrors.Tables[0].Rows[0][0].ToString()) != ((int)EnumFile.AssignValue.Zero))
                            {
                                WebMsg.Show("Record already exist.");
                            }
                        }
                        else
                        {
                            ////BindGridAnnouncement();
                            this.RefreshControls();
                            WebMsg.Show("Record inserted.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                WebMsg.Show(ex.Message);
            }
        }
    }

    protected void ddlBoardMediumStandard_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.BindDivisionCheckBoxList();
    }

    protected void ibtnAddAnnouncement_Click(object sender, ImageClickEventArgs e)
    {
        this.RefreshControls();
        //edtAnnouncement.Visible = true;
        txtSearchAnnouncement.Visible = true;
        btnSearch.Visible = false;
        btnUpdate.Visible = false;
        btnAdd.Visible = true;
    }

    protected void ibtnRefresh_Click(object sender, ImageClickEventArgs e)
    {
        this.RefreshControls();
    }

    protected void ibtnEditAnnouncement_Click(object sender, ImageClickEventArgs e)
    {

        int CoundChecked = (int)EnumFile.AssignValue.Zero;
        int GRrowIndex = (int)EnumFile.AssignValue.Zero;
        foreach (GridViewRow gr in gvAnnouncementDetails.Rows)
        {
            CheckBox chk = new CheckBox();
            chk = (CheckBox)gr.FindControl("chkSelect");
            if (chk.Checked == true)
            {
                CoundChecked = CoundChecked + 1;
                GRrowIndex = gr.RowIndex;
            }
        }

        if (CoundChecked == ((int)EnumFile.AssignValue.Zero) || CoundChecked > ((int)EnumFile.AssignValue.One))
        {
            WebMsg.Show("Please select one record to Update.");
        }
        else
        {
            btnAdd.Visible = false;
            btnUpdate.Visible = true;
            btnSearch.Visible = false;
            edtAnnouncement.Visible = true;
            txtSearchAnnouncement.Visible = false;
            pnlSearch.Visible = true;
            string IFormat = "dd-MMM-yyyy";
            edtAnnouncement.Content = gvAnnouncementDetails.DataKeys[GRrowIndex]["Announcement"].ToString();
            txtStartDate.Text = Convert.ToDateTime(gvAnnouncementDetails.DataKeys[GRrowIndex]["StartDate"].ToString()).ToString(IFormat);
            txtEndDate.Text = Convert.ToDateTime(gvAnnouncementDetails.DataKeys[GRrowIndex]["EndDate"].ToString()).ToString(IFormat);
            ddlBoardMediumStandard.SelectedValue = gvAnnouncementDetails.DataKeys[GRrowIndex]["BMSID"].ToString();
            clstDivision.SelectedValue = gvAnnouncementDetails.DataKeys[GRrowIndex]["DivisionID"].ToString();
            this.ViewState["AnnouncementID"] = gvAnnouncementDetails.DataKeys[GRrowIndex]["AnnouncementID"].ToString();
        }
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        this.RefreshControls();
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        int count = (int)EnumFile.AssignValue.Zero;
        string divisionidstr = string.Empty;
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
            try
            {
                DataSet dsselectErrors = new DataSet();
                this.PAnnouncement.bmsid = Convert.ToInt32(ddlBoardMediumStandard.SelectedValue.ToString());
                if (divisionidstr == string.Empty)
                {
                    divisionidstr = ((int)EnumFile.AssignValue.Zero).ToString();
                }

                this.PAnnouncement.divisionstr = divisionidstr;
                string IFormat = "dd-MMM-yyyy";
                DateTime StartDate = Convert.ToDateTime(DateTime.Parse(txtStartDate.Text).ToString(IFormat));
                DateTime EndDate = Convert.ToDateTime(DateTime.Parse(txtEndDate.Text).ToString(IFormat));

                if (StartDate > EndDate)
                {
                    WebMsg.Show("End Date Larger than StartDate");
                }
                else
                {
                    this.PAnnouncement.divisionid = Convert.ToInt32(clstDivision.SelectedValue);
                    this.PAnnouncement.startdate = StartDate;
                    this.PAnnouncement.enddate = EndDate;
                    //this.PAnnouncement.announcement = edtAnnouncement.Content.ToString();
                    ////  PAnnouncement.announcement = edtAnnouncement.Content.Substring(0, edtAnnouncement.Content.Length - 6);
                    this.PAnnouncement.announcement = txtSearchAnnouncement.Text;
                    this.PAnnouncement.createdby = Convert.ToInt32(this.Session["EmpolyeeID"]);
                    this.PAnnouncement.modifiedby = Convert.ToInt32(this.Session["EmpolyeeID"]);
                    this.PAnnouncement.announcementid = Convert.ToInt32(this.ViewState["AnnouncementID"].ToString());
                    dsselectErrors = this.BAL_Announcement.BAL_Announcement_Update(this.PAnnouncement, "Update");

                    if (dsselectErrors.Tables.Count > ((int)EnumFile.AssignValue.Zero))
                    {
                        if (dsselectErrors.Tables[0].Rows.Count > ((int)EnumFile.AssignValue.Zero))
                        {
                            if (Convert.ToInt32(dsselectErrors.Tables[0].Rows[0][0].ToString()) == ((int)EnumFile.AssignValue.Zero))
                            {
                                WebMsg.Show("Following Combination already exist.");
                            }
                        }
                        else
                        {
                            this.RefreshControls();
                            WebMsg.Show("Record Updated.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                WebMsg.Show(ex.Message);
            }
        }
    }

    protected void ibtnDelete_Click(object sender, ImageClickEventArgs e)
    {
        DataSet dsselectErrors = new DataSet();
        int CoundChecked = (int)EnumFile.AssignValue.Zero;
        int GRrowIndex = (int)EnumFile.AssignValue.Zero;
        foreach (GridViewRow gr in gvAnnouncementDetails.Rows)
        {
            CheckBox chk = new CheckBox();
            chk = (CheckBox)gr.FindControl("chkSelect");
            if (chk.Checked == true)
            {
                CoundChecked = CoundChecked + 1;
                GRrowIndex = gr.RowIndex;
            }
        }

        if (CoundChecked == ((int)EnumFile.AssignValue.Zero) || CoundChecked > ((int)EnumFile.AssignValue.One))
        {
            WebMsg.Show("Please select Atleast one record to Delete.");
        }
        else
        {
            this.PAnnouncement.announcementid = Convert.ToInt32(gvAnnouncementDetails.DataKeys[GRrowIndex]["AnnouncementID"].ToString());
            this.BAL_Announcement.BAL_Announcement_Delete(this.PAnnouncement, Convert.ToInt32(this.Session["SchoolID"]), "Delete");
            this.BindGridAnnouncement();
            this.RefreshControls();
            WebMsg.Show("Record Deleted");
        }
    }

    protected void ddlPageSelector_SelectedIndexChanged(object sender, EventArgs e)
    {
        gvAnnouncementDetails.PageIndex = ((DropDownList)sender).SelectedIndex;
        this.BindGridAnnouncement();
    }

    protected void ibtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        btnSearch.Visible = true;
        txtSearchAnnouncement.Visible = true;
        edtAnnouncement.Visible = false;
        pnlSearch.Visible = true;
        btnAdd.Visible = false;
        btnUpdate.Visible = false;
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        this.BindGridAnnouncementDetails();
    }

    #endregion

    #region "Grid Events"
    protected void BindGridAnnouncementDetails()
    {
        DataSet dsSelect = new DataSet();
        string SearchCondition = string.Empty;

        ////if (Convert.ToInt32(ddlBoardMediumStandard.SelectedValue) > 0)
        ////{
        SearchCondition = "and Announcement.BMSID = " + ddlBoardMediumStandard.SelectedValue;
        ////}

        int count = (int)EnumFile.AssignValue.Zero;
        string divisionIDList = string.Empty;
        foreach (ListItem chk in clstDivision.Items)
        {
            if (chk.Selected == true)
            {
                if (count == (int)EnumFile.AssignValue.Zero)
                {
                    divisionIDList = chk.Value.ToString();
                }
                else
                {
                    divisionIDList = divisionIDList + " , " + chk.Value.ToString();
                }

                count = count + 1;
            }
        }

        if (count > ((int)EnumFile.AssignValue.Zero))
        {
            SearchCondition = SearchCondition + " and Announcement.DivisionID IN (" + divisionIDList + ") ";
        }

        if (txtSearchAnnouncement.Text != string.Empty)
        {
            SearchCondition = SearchCondition + " and Announcement like '%" + txtSearchAnnouncement.Text + "%'";
        }

        if (txtStartDate.Text != string.Empty || txtEndDate.Text != string.Empty)
        {
            if (txtStartDate.Text != string.Empty && txtEndDate.Text != string.Empty)
            {
                SearchCondition = SearchCondition + " and Announcement.StartDate between '" + txtStartDate.Text + "'and '" + txtEndDate.Text + "'";
            }
            else if (txtStartDate.Text != string.Empty)
            {
                SearchCondition = SearchCondition + " and Announcement.StartDate = '" + txtStartDate.Text + "'";
            }
            else if (txtEndDate.Text != string.Empty)
            {
                SearchCondition = SearchCondition + " and Announcement.EndDate = '" + txtEndDate.Text + "'";
            }
        }

        dsSelect = this.BAL_Announcement.BAL_SelectAnnouncementBySchoolID1(Convert.ToInt32(this.Session["SchoolID"]), SearchCondition);
        if (dsSelect.Tables.Count > ((int)EnumFile.AssignValue.Zero))
        {
            GridViewOperations GvOperation = new GridViewOperations();
            GvOperation.BindGridWithSorting(this.gvAnnouncementDetails, dsSelect, this.SortField, this.SortDirection);
        }
        else
        {
            gvAnnouncementDetails.DataSource = null;
            gvAnnouncementDetails.DataBind();
        }
    }

    protected void gvAnnouncementDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            DropDownList DDLSelectPage = (DropDownList)gvAnnouncementDetails.BottomPagerRow.FindControl("ddlPageSelector");
            DDLSelectPage.SelectedIndex = e.NewPageIndex;
            gvAnnouncementDetails.PageIndex = e.NewPageIndex;
            this.BindGridAnnouncement();
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message.ToString());
        }
    }

    protected void gvAnnouncementDetails_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Pager)
        {
            GridViewOperations GrvOperation = new GridViewOperations();
            GrvOperation.SetPagerButtonStates(this.gvAnnouncementDetails, e.Row, this.Page);
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
        this.BindGridAnnouncement();
        GridViewOperations GrvOperation = new GridViewOperations();
        GrvOperation.GrvSortingSetImage(e, this.gvAnnouncementDetails, this.SortDirection);
    }
    #endregion
}