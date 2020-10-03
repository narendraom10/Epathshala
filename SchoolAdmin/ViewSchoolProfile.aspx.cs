/// <summary> 
/// <DevelopedBy>"NARENDRASINH"</DevelopedBy>
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

public partial class SchoolAdmin_ViewSchoolProfile : System.Web.UI.Page
{
    #region "Declaration"
    School_BLogic obj_BAL_School;
    //SchoolRegistration obj_SchoolRegistration;
    SchoolBMS_BLogic obj_BAL_SchoolRegistrationBMS;
    SchoolBMS obj_SchoolRegistrationBMS;
    //SYS_BMS_BLogic SYS_BMSBLogic;
    SYS_Status_BLogic BAL_SYS_Status;
    SYS_Status Prop_SYS_Status;
    SYS_SchoolType_BLogic BSchoolType = new SYS_SchoolType_BLogic();

    SYS_Board_BLogic BLBoard = new SYS_Board_BLogic();
    SYS_Medium_BLogic BlMedium = new SYS_Medium_BLogic();
    SYS_Standard_BLogic BStandard = new SYS_Standard_BLogic();
    SYS_Board PBoard = new SYS_Board();
    SYS_Medium PMedium = new SYS_Medium();
    School school;
    #endregion

    #region "Page Events"
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            try
            {
                if ((Session["SchoolID"] != "" || Session["SchoolID"] != null))
                {
                    obj_BAL_School = new School_BLogic();
                    DataSet dsSelect = new DataSet();
                    string SearchCondition = string.Empty;
                    dsSelect = obj_BAL_School.BAL_School_SelectAllOrBySchRegID("BySchRegID", Convert.ToInt32(Session["SchoolID"].ToString()), SearchCondition);
                    if (dsSelect.Tables.Count > Convert.ToInt32(EnumFile.AssignValue.Zero))
                    {
                        ViewState["SchRegID"] = Session["SchoolID"].ToString();
                        txtSchName.Text = dsSelect.Tables[0].Rows[0]["Name"].ToString();
                        txtValSchAddress.Text = dsSelect.Tables[0].Rows[0]["Address"].ToString();
                        txtValPloatNo.Text = dsSelect.Tables[0].Rows[0]["PloteNo"].ToString();
                        txtValBlockNoSurvey.Text = dsSelect.Tables[0].Rows[0]["BlockNo"].ToString();
                        lblValCountry.Text = dsSelect.Tables[0].Rows[0]["Country"].ToString();
                        lblValState.Text = dsSelect.Tables[0].Rows[0]["State"].ToString();
                        lblValDistrict.Text = dsSelect.Tables[0].Rows[0]["District"].ToString();
                        txtValCity.Text = dsSelect.Tables[0].Rows[0]["City"].ToString();
                        txtValPincode.Text = dsSelect.Tables[0].Rows[0]["PinCode"].ToString();
                        txtValLandline.Text = dsSelect.Tables[0].Rows[0]["LandLineNo"].ToString();
                        txtValFaxNo.Text = dsSelect.Tables[0].Rows[0]["FaxNo"].ToString();
                        txtValMobileNo.Text = dsSelect.Tables[0].Rows[0]["MobileNo"].ToString();
                        txtValSchoolStartYear.Text = dsSelect.Tables[0].Rows[0]["SchoolStartYear"].ToString();
                        txtValSchlMailID.Text = dsSelect.Tables[0].Rows[0]["EmailID"].ToString();
                        txtValSchlWebsite.Text = dsSelect.Tables[0].Rows[0]["WebSiteURL"].ToString();



                        GetSChoolTypes();
                        GetBoards();
                        bindgrvSYS_Statusdetail();
                        bindgrvSchoolRegistrationBMSdetail(Convert.ToInt32(ViewState["SchRegID"].ToString()));
                    }
                }
            }
            catch (Exception ex)
            {
                WebMsg.Show(ex.Message);
            }
        }
    }
    #endregion

    #region "Control Events"

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        school = new School();
        obj_BAL_School = new School_BLogic();
        school.schoolid = Convert.ToInt32(ViewState["SchRegID"].ToString());
        school.name = txtSchName.Text;
        school.ploteno = txtValPloatNo.Text;
        school.blockno = txtValBlockNoSurvey.Text;
        school.address = txtValSchAddress.Text;
        //school.countryid = Convert.ToInt32(lblValCountry.Text);
        //school.stateid = Convert.ToInt32(lblValState.Text);
        //school.districtid =  Convert.ToInt32(lblValDistrict.Text);
        school.city = txtValCity.Text;
        school.pincode = Convert.ToInt64(txtValPincode.Text);
        school.landlineno = Convert.ToInt64(txtValLandline.Text);
        school.faxno = Convert.ToInt64(txtValFaxNo.Text);
        school.mobileno = Convert.ToInt64(txtValMobileNo.Text);
        school.emailid = txtValSchlMailID.Text;
        school.websiteurl = txtValSchlWebsite.Text;
        school.schoolstartyear = txtValSchoolStartYear.Text;
        school.modifiedby = Convert.ToInt32(Session["EmpolyeeID"].ToString());
        obj_BAL_School.BAL_School_UpdateDetails(school, "Update");
    }

    protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindgrvSchoolRegistrationBMSdetail(Convert.ToInt32(ViewState["SchRegID"].ToString()));
    }

    protected void ibtnSearch_Click(object sender, ImageClickEventArgs e)
    {

    }

    protected void ibtnRefresh_Click(object sender, ImageClickEventArgs e)
    {
        RefreshGridControls();
    }

    protected void btnGo_Click(object sender, EventArgs e)
    {
        bindgrvSchoolRegistrationBMSdetail(Convert.ToInt32(ViewState["SchRegID"].ToString()));
    }

    protected void ddlBoardI_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlBoardI.SelectedValue != ((int)EnumFile.AssignValue.Zero).ToString())
            {
                ddlMedium.Items.Clear();
                BlMedium.BindMediumByBoardID(ddlMedium, "GetMediumByBoardID", int.Parse(ddlBoardI.SelectedValue));
                ddlMedium.Items[0].Value = ((int)EnumFile.AssignValue.Zero).ToString();
                ddlMedium.Enabled = true;

                ddlStandard.Items.Clear();
                ddlStandard.Items.Insert(Convert.ToInt32(EnumFile.AssignValue.Zero), "-- Select --");
                ddlStandard.Items[0].Value = ((int)EnumFile.AssignValue.Zero).ToString();
                ddlStandard.Enabled = false;
            }
            else if (ddlBoardI.SelectedValue == ((int)EnumFile.AssignValue.Zero).ToString())
            {
                ddlMedium.Items.Clear();
                ddlMedium.Items.Insert(Convert.ToInt32(EnumFile.AssignValue.Zero), "-- Select --");
                ddlMedium.Items[0].Value = ((int)EnumFile.AssignValue.Zero).ToString();
                ddlMedium.Enabled = false;
                ddlStandard.Items.Clear();
                ddlStandard.Items.Insert(Convert.ToInt32(EnumFile.AssignValue.Zero), "-- Select --");
                ddlStandard.Items[0].Value = ((int)EnumFile.AssignValue.Zero).ToString();
                ddlStandard.Enabled = false;
            }
        }
        catch (Exception)
        {

        }
    }

    protected void ddlMedium_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlMedium.SelectedValue != ((int)EnumFile.AssignValue.Zero).ToString())
            {
                ddlStandard.Items.Clear();
                //BStandard.BindListByID(GvStandards, "GetStandardByBoardMediumID", int.Parse(DdlBoard.SelectedValue), int.Parse(DdlMedium.SelectedValue));
                BStandard.BindStandardListByID(ddlStandard, "GetStandardByBoardMediumID", int.Parse(ddlBoardI.SelectedValue), int.Parse(ddlMedium.SelectedValue));              
                ddlStandard.Enabled = true;
            }
            else if (ddlMedium.SelectedValue == ((int)EnumFile.AssignValue.Zero).ToString())
            {
                ddlStandard.Items.Clear();
                ddlStandard.Items.Insert(Convert.ToInt32(EnumFile.AssignValue.Zero), "-- Select --");
                ddlStandard.Items[0].Value = ((int)EnumFile.AssignValue.Zero).ToString();
                ddlStandard.Enabled = false;
            }
        }
        catch (Exception)
        {

        }
    }
    #endregion

    #region "GridViewEvents"
    protected void gvSchoolRegistrationBMSdetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            DropDownList DDLSelectPage = (DropDownList)gvSchoolRegistrationBMSdetail.BottomPagerRow.FindControl("ddlPageSelector");
            DDLSelectPage.SelectedIndex = e.NewPageIndex;
            gvSchoolRegistrationBMSdetail.PageIndex = e.NewPageIndex;
            bindgrvSchoolRegistrationBMSdetail(Convert.ToInt32(ViewState["SchRegID"].ToString()));
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }
    protected void ddlPageSelector_SelectedIndexChanged(object sender, EventArgs e)
    {
        gvSchoolRegistrationBMSdetail.PageIndex = ((DropDownList)sender).SelectedIndex;
        bindgrvSchoolRegistrationBMSdetail(Convert.ToInt32(ViewState["SchRegID"].ToString()));
    }
    protected void gvEmpStdSubAllocationDetails_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Pager)
        {
            GridViewOperations GrvOperation = new GridViewOperations();
            GrvOperation.SetPagerButtonStates(gvSchoolRegistrationBMSdetail, e.Row, this.Page);
        }
    }
    protected void gvEmpStdSubAllocationDetails_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (e.SortExpression.Trim() == this.SortField)
            this.SortDirection = (this.SortDirection == "descending" ? "ascending" : "descending");
        else
            this.SortDirection = "ascending";

        this.SortField = e.SortExpression;

        this.SortField = e.SortExpression;
        bindgrvSchoolRegistrationBMSdetail(Convert.ToInt32(ViewState["SchRegID"].ToString()));

        GridViewOperations GrvOperation = new GridViewOperations();
        GrvOperation.GrvSortingSetImage(e, gvSchoolRegistrationBMSdetail, this.SortDirection);
    }
    #endregion

    #region "GridviewUserFunction"

    private void bindgrvSchoolRegistrationBMSdetail(int SchRegID)
    {
        try
        {

            DataSet dsSelect = new DataSet();
            dsSelect = GetClassRecord(dsSelect, SchRegID);

            if (dsSelect.Tables.Count > Convert.ToInt32(EnumFile.AssignValue.Zero))
            {
                gvSchoolRegistrationBMSdetail.Columns[0].Visible = false;


                GridViewOperations GrvOperation = new GridViewOperations();
                GrvOperation.BindGridWithSorting(gvSchoolRegistrationBMSdetail, dsSelect, this.SortField, this.SortDirection);
            }
            else
            {
                //grvSchoolRegistrationBMSdetail.DataSource = dsSelect.Tables[0];

                gvSchoolRegistrationBMSdetail.DataBind();
            }
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }
    //GetClass Details by search condition
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
    #endregion

    #region "User Defined Functions"

    protected override void InitializeCulture()
    {
        string culture = Convert.ToString(Session[Global.SESSION_KEY_CULTURE]);
        // 'set culture to current thread 
        System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture);
        System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);
        //call base class 
        base.InitializeCulture();
    }

    private void RefreshGridControls()
    {
        ddlStatus.SelectedIndex = Convert.ToInt32(EnumFile.AssignValue.Zero);
        ddlBoardI.SelectedIndex = Convert.ToInt32(EnumFile.AssignValue.Zero);
        ddlStandard.SelectedIndex = Convert.ToInt32(EnumFile.AssignValue.Zero);
        ddlMedium.SelectedIndex = Convert.ToInt32(EnumFile.AssignValue.Zero);
        ddlSchoolType.SelectedIndex = Convert.ToInt32(EnumFile.AssignValue.Zero);
        ddlMedium.Enabled = false;
        ddlStandard.Enabled = false;
        bindgrvSchoolRegistrationBMSdetail(Convert.ToInt32(ViewState["SchRegID"].ToString()));
    }

    protected void GetSChoolTypes()
    {
        try
        {
            ddlSchoolType.Items.Clear();
            BSchoolType.BindList(ddlSchoolType, "Select");
        }
        catch (Exception)
        {

        }
    }

    protected void GetBoards()
    {
        try
        {
            DataSet dsBoards = new DataSet();
            PBoard.boardid = Convert.ToInt32(EnumFile.AssignValue.Zero);
            dsBoards = BLBoard.BAL_SYS_Board_Select(PBoard, "Select");
            ddlBoardI.DataSource = dsBoards;
            ddlBoardI.DataTextField = dsBoards.Tables[0].Columns["Board"].ToString();
            ddlBoardI.DataValueField = dsBoards.Tables[0].Columns["BoardID"].ToString();
            ddlBoardI.DataBind();
            ddlBoardI.Items.Insert(Convert.ToInt32(EnumFile.AssignValue.Zero), "-- Select --");
            ddlBoardI.Items[0].Value = ((int)EnumFile.AssignValue.Zero).ToString();
            ddlMedium.Items.Clear();
            ddlMedium.Items.Insert(Convert.ToInt32(EnumFile.AssignValue.Zero), "-- Select --");
            ddlMedium.Items[0].Value = ((int)EnumFile.AssignValue.Zero).ToString();
            ddlMedium.Enabled = false;
            ddlStandard.Items.Clear();
            ddlStandard.Items.Insert(Convert.ToInt32(EnumFile.AssignValue.Zero), "-- Select --");
            ddlStandard.Items[0].Value = ((int)EnumFile.AssignValue.Zero).ToString();
            ddlStandard.Enabled = false;
        }
        catch (Exception)
        {

        }
    }

    private void bindgrvSYS_Statusdetail()
    {
        Prop_SYS_Status = new SYS_Status();
        BAL_SYS_Status = new SYS_Status_BLogic();
        Prop_SYS_Status.statusid = Convert.ToInt32(EnumFile.AssignValue.Zero);
        Prop_SYS_Status.status = string.Empty;
        DataSet dsSelect = new DataSet();
        dsSelect = BAL_SYS_Status.BAL_SYS_Status_Select(Prop_SYS_Status, "SelectAll");
        if (dsSelect.Tables.Count > Convert.ToInt32(EnumFile.AssignValue.Zero))
        {
            ddlStatus.DataSource = dsSelect;
            ddlStatus.DataTextField = dsSelect.Tables[0].Columns["Status"].ToString();
            ddlStatus.DataValueField = dsSelect.Tables[0].Columns["StatusID"].ToString();
            ddlStatus.DataBind();
            ddlStatus.Items.Insert(Convert.ToInt32(EnumFile.AssignValue.Zero), "-- Select --");
            ddlStatus.Items[0].Value = ((int)EnumFile.AssignValue.Zero).ToString();
        }
    }

    private DataSet GetClassRecord(DataSet dsSelect, int SchRegID)
    {
        obj_SchoolRegistrationBMS = new SchoolBMS();
        obj_BAL_SchoolRegistrationBMS = new SchoolBMS_BLogic();
        obj_SchoolRegistrationBMS.schregbmsid = SchRegID;
        string SearchCondition = string.Empty;
        if (ddlStatus.SelectedValue != ((int)EnumFile.AssignValue.Zero).ToString())
        {
            SearchCondition = SearchCondition + " and SchoolBMS.StatusID=" + ddlStatus.SelectedValue;
        }
        if (ddlSchoolType.SelectedValue != ((int)EnumFile.AssignValue.Zero).ToString())
        {
            SearchCondition = SearchCondition + " and SchoolBMS.SchoolTypeID = " + ddlSchoolType.SelectedValue + " ";
        }
        if (ddlBoardI.SelectedValue != ((int)EnumFile.AssignValue.Zero).ToString())
        {
            SearchCondition = SearchCondition + " and SYS_Board.BoardID = " + ddlBoardI.SelectedValue + " ";
        }
        if (ddlMedium.SelectedValue != ((int)EnumFile.AssignValue.Zero).ToString())
        {
            SearchCondition = SearchCondition + " and SYS_Medium.MediumID = " + ddlMedium.SelectedValue + " ";
        }
        if (ddlStandard.SelectedValue != ((int)EnumFile.AssignValue.Zero).ToString())
        {
            SearchCondition = SearchCondition + " and SYS_Standard.StandardID = " + ddlStandard.SelectedValue + " ";
        }


        obj_SchoolRegistrationBMS.schregid = SchRegID;
        dsSelect = obj_BAL_SchoolRegistrationBMS.BAL_SchoolBMS_Select(obj_SchoolRegistrationBMS, "SelectAllBySchRegID", SearchCondition);
        return dsSelect;
    }
    #endregion
    
}