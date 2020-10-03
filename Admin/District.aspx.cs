/// <summary>               
/// <Description>District management</Description>
/// <DevelopedBy>"NARENDRASINH, YOGESH"</DevelopedBy>
/// <DevelopedDate></DevelopedDate>
/// <UpdatedBy>"NARENDRASINH,SHEEL"</UpdatedBy>
/// <UpdatedDate>7-6-2014</UpdatedDate>
/// </summary>
using System;
using System.Data;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.WebControls;
using Udev.UserMasterPage.Classes;

public partial class Admin_District : System.Web.UI.Page
{
    #region "Variables"
    SYS_District_BLogic BAL_SYS_District;
    SYS_District SYS_District;
    SYS_State_BLogic BLState = new SYS_State_BLogic();
    SYS_Country PCountry = new SYS_Country();
    SYS_Country_BLogic BLCountry = new SYS_Country_BLogic();
    SYS_State PState = new SYS_State();
    int status = 0;
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

    #region "Page Events"

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetCoutries();
            bindgrvSYS_Districtdetail();
        }
    }

    #endregion

    #region "Control Events"

    protected void BtnActDeactSub_Click(object sender, EventArgs e)
    {
        int CountChecked = 0;
        string DistrictIDStr = string.Empty;
        foreach (GridViewRow gr in grvSYS_Districtdetail.Rows)
        {
            CheckBox chk = new CheckBox();
            chk = (CheckBox)gr.FindControl("chkSelect");
            if (chk.Checked == true)
            {
                if (CountChecked == 0)
                {
                    DistrictIDStr = grvSYS_Districtdetail.DataKeys[gr.RowIndex]["DistrictID"].ToString();
                }
                else
                {
                    DistrictIDStr = DistrictIDStr + "," + grvSYS_Districtdetail.DataKeys[gr.RowIndex]["DistrictID"].ToString();
                }

                CountChecked = CountChecked + 1;
            }
        }

        if (CountChecked == 0)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Message", "<script> alert(' Please select one record to Active/Deactive.')</script>", false);
        }
        else
        {
            SYS_District = new SYS_District();
            BAL_SYS_District = new SYS_District_BLogic();
            ////SYS_District.districtid = DistrictIDStr;
            SYS_District.districtidStr = DistrictIDStr;
            if (rbActive.Checked == true)
            {
                SYS_District.isactive = true;
            }

            if (rbDeactive.Checked == true)
            {
                SYS_District.isactive = false;
            }

            status = BAL_SYS_District.BAL_SYS_District_Delete(SYS_District, "UpdateStatus");
            string status1 = string.Empty;
            if (status == 1)
            {
                if (rbActive.Checked == true)
                {
                    status1 = "Active.";
                }
                else if (rbDeactive.Checked == true)
                {
                    status1 = "Deactive.";
                }
                string message = string.Format("Selected records successfully {0}", status1);
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Message", "<script> alert('" + message + "')</script>", false);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Message", "<script> alert('Selected record not Active/Deactive.')</script>", false);
            }
            RefreshPageControls();
        }
    }
    protected void btnSearchReset_Click(object sender, EventArgs e)
    {
        RefreshPageControls();
    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        try
        {
            SYS_District = new SYS_District();
            BAL_SYS_District = new SYS_District_BLogic();
            SYS_District.stateid = Convert.ToInt32(ddlStateID.SelectedValue);
            SYS_District.countryid = Convert.ToInt32(ddlCountryID.SelectedValue);
            SYS_District.district = txtDistrict.Text;
            SYS_District.createdby = Convert.ToInt32(Session["EmpolyeeID"]);
            status = BAL_SYS_District.BAL_SYS_District_Insert(SYS_District, "Insert");
            if (status == 1)
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
        ////{ }
    }

    protected void BtnCancel_Click(object sender, EventArgs e)
    {
        ClearControls();
        AllPanelInvisible();
        pnlAdd.CssClass = "Visible";
    }

    protected void GrvSYS_Districtdetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvSYS_Districtdetail.PageIndex = e.NewPageIndex;
        bindgrvSYS_Districtdetail();
    }

    protected void ibtnRefresh_Click(object sender, ImageClickEventArgs e)
    {
        RefreshPageControls();
    }

    protected void BtnUpdate_Click(object sender, EventArgs e)
    {
        SYS_District = new SYS_District();
        BAL_SYS_District = new SYS_District_BLogic();
        SYS_District.districtid = Convert.ToInt32(ViewState["districtid"].ToString());
        SYS_District.countryid = Convert.ToInt32(ddlCountryIDEdit.SelectedValue);
        SYS_District.stateid = Convert.ToInt32(ddlStateIDEdit.SelectedValue);
        SYS_District.district = txtDistrictEdit.Text;
        SYS_District.createdby = Convert.ToInt32(Session["EmpolyeeID"]);
        status = BAL_SYS_District.BAL_SYS_District_Update(SYS_District, "Update");
        if (status == 1)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Message", "<script> alert('Record successfully updated.')</script>", false);
        }
        else
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Message", "<script> alert('Record not updated.')</script>", false);
        }
        RefreshPageControls();
    }

    protected void btnCancelEdit_Click(object sender, EventArgs e)
    {
        ClearControlsEdit();
    }

    protected void ibtnEdit_Click(object sender, ImageClickEventArgs e)
    {
        if (pnlEdit.CssClass == "Visible")
        {
            AllPanelInvisible();
            pnlSearch.CssClass = "Visible";
            ClearControlsEdit();
        }
        else
        {
            int CountChecked = 0;
            int GRrowIndex = 0;
            foreach (GridViewRow gr in grvSYS_Districtdetail.Rows)
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
                AllPanelInvisible();
                pnlEdit.CssClass = "Visible";
                GetState();
                int DistrictID;
                int index = GRrowIndex;
                DistrictID = Convert.ToInt32(grvSYS_Districtdetail.DataKeys[index]["DistrictID"]);
                ViewState["districtid"] = Convert.ToInt32(grvSYS_Districtdetail.DataKeys[index]["DistrictID"]);
                ddlCountryIDEdit.SelectedValue = Convert.ToString(grvSYS_Districtdetail.DataKeys[index]["CountryID"]);
                ddlStateIDEdit.SelectedValue = Convert.ToString(grvSYS_Districtdetail.DataKeys[index]["StateID"]);
                txtDistrictEdit.Text = Convert.ToString(grvSYS_Districtdetail.DataKeys[index]["District"]);
            }
        }
    }

    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        bindgrvSYS_Districtdetail();
    }

    protected void DdlCountryIDSearch_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlCountryIDSearch.SelectedValue != ((int)EnumFile.AssignValue.Zero).ToString())
            {
                ddlStateIDSearch.Items.Clear();
                BLState.BindListByID(ddlStateIDSearch, "ByCountryID", int.Parse(ddlCountryIDSearch.SelectedValue));
                ddlStateIDSearch.Enabled = true;
            }
            else if (ddlCountryIDSearch.SelectedValue == ((int)EnumFile.AssignValue.Zero).ToString())
            {
                ddlStateIDSearch.Items.Clear();
                ddlStateIDSearch.Items.Insert(Convert.ToInt32(EnumFile.AssignValue.Zero), "-- Select --");
                ddlStateIDSearch.Items[0].Value = ((int)EnumFile.AssignValue.Zero).ToString();
                ddlStateIDSearch.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }

        pnlAdd.CssClass = "InVisible";
        pnlSearch.CssClass = "Visible";
    }

    protected void DdlCountryID_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlCountryID.SelectedValue != ((int)EnumFile.AssignValue.Zero).ToString())
            {
                ddlStateID.Items.Clear();
                BLState.BindListByID(ddlStateID, "ByCountryID", int.Parse(ddlCountryID.SelectedValue));
                ddlStateID.Enabled = true;
            }
            else if (ddlCountryID.SelectedValue == ((int)EnumFile.AssignValue.Zero).ToString())
            {
                ddlStateID.Items.Clear();
                ddlStateID.Items.Insert(Convert.ToInt32(EnumFile.AssignValue.Zero), "-- Select --");
                ddlStateID.Items[0].Value = ((int)EnumFile.AssignValue.Zero).ToString();
                ddlStateID.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }

        pnlAdd.CssClass = "Visible";
        pnlSearch.CssClass = "InVisible";
    }

    protected void DdlPageSelector_SelectedIndexChanged(object sender, EventArgs e)
    {
        grvSYS_Districtdetail.PageIndex = ((DropDownList)sender).SelectedIndex;
        bindgrvSYS_Districtdetail();
    }

    protected void GrvSYS_Districtdetail_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (e.SortExpression.Trim() == this.SortField)
        {
            this.SortDirection = (this.SortDirection == "descending" ? "ascending" : "descending");
        }
        else
        {
            this.SortDirection = "ascending";
            this.SortField = e.SortExpression;
            bindgrvSYS_Districtdetail();
        }

        GridViewOperations GrvOperation = new GridViewOperations();
        GrvOperation.GrvSortingSetImage(e, grvSYS_Districtdetail, this.SortDirection);
    }

    protected void GrvSYS_Districtdetail_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Pager)
        {
            GridViewOperations GrvOperation = new GridViewOperations();
            GrvOperation.SetPagerButtonStates(grvSYS_Districtdetail, e.Row, this.Page);
        }
    }

    #endregion

    #region "User Defined Functions"

    protected void GetCoutries()
    {
        try
        {
            DataSet dsCountries = new DataSet();
            PCountry.countryid = Convert.ToInt32(EnumFile.AssignValue.Zero);
            dsCountries = BLCountry.BAL_SYS_Country_Select(PCountry, "Select");
            BindDropDown(dsCountries, ddlCountryID);
            BindDropDown(dsCountries, ddlCountryIDEdit);
            BindDropDown(dsCountries, ddlCountryIDSearch);
        }
        catch (Exception)
        {
        }
    }

    protected void GetState()
    {
        try
        {
            DataSet dsState = new DataSet();
            PState.stateid = Convert.ToInt32(EnumFile.AssignValue.Zero);
            dsState = BLState.BAL_SYS_State_Select(PState, "Select");
            ddlStateIDEdit.DataSource = dsState;
            ddlStateIDEdit.DataTextField = dsState.Tables[0].Columns["State"].ToString();
            ddlStateIDEdit.DataValueField = dsState.Tables[0].Columns["StateID"].ToString();
            ddlStateIDEdit.DataBind();
            ddlStateIDEdit.Items.Insert(Convert.ToInt32(EnumFile.AssignValue.Zero), "-- Select --");
            ddlStateIDEdit.Items[0].Value = ((int)EnumFile.AssignValue.Zero).ToString();
        }
        catch (Exception)
        {
        }
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

    private void AllPanelInvisible()
    {
        pnlAdd.CssClass = "InVisible";
        pnlEdit.CssClass = "InVisible";
        pnlSearch.CssClass = "InVisible";
    }

    private void ClearControls()
    {
        ddlCountryID.SelectedValue = Convert.ToString((int)EnumFile.AssignValue.Zero);
        ddlStateID.Items.Clear();
        ddlStateID.Items.Insert(Convert.ToInt32(EnumFile.AssignValue.Zero), "-- Select --");
        ddlStateID.Items[0].Value = Convert.ToString((int)EnumFile.AssignValue.Zero);
        ddlStateID.SelectedValue = Convert.ToString((int)EnumFile.AssignValue.Zero);
        txtDistrict.Text = string.Empty;
    }

    private void ClearControlsEdit()
    {
        AllPanelInvisible();
        pnlSearch.CssClass = "Visible";
        ddlCountryIDEdit.SelectedValue = Convert.ToString((int)EnumFile.AssignValue.Zero);
        ddlStateIDEdit.Items.Clear();
        ddlStateIDEdit.Items.Insert(Convert.ToInt32(EnumFile.AssignValue.Zero), "-- Select --");
        ddlStateIDEdit.Items[0].Value = Convert.ToString((int)EnumFile.AssignValue.Zero);
        ddlStateIDEdit.SelectedValue = Convert.ToString((int)EnumFile.AssignValue.Zero);
        txtDistrictEdit.Text = string.Empty;
    }

    private void bindgrvSYS_Districtdetail()
    {
        SYS_District = new SYS_District();
        BAL_SYS_District = new SYS_District_BLogic();
        DataSet dsSelect = new DataSet();
        dsSelect = BAL_SYS_District.BAL_SYS_District_Select(SYS_District, "SelectAll");
        if (dsSelect.Tables.Count > 0)
        {
            string searchCondition = string.Empty;
            if (ddlCountryIDSearch.SelectedIndex > 0)
            {
                searchCondition = " CountryID = " + ddlCountryIDSearch.SelectedValue.ToString();
            }

            if (ddlStateIDSearch.SelectedIndex > 0)
            {
                if (searchCondition != string.Empty)
                {
                    searchCondition = searchCondition + " and ";
                }

                searchCondition = "StateID = " + ddlStateIDSearch.SelectedValue.ToString();
            }

            if (txtDistrictSearch.Text != string.Empty)
            {
                if (searchCondition != string.Empty)
                {
                    searchCondition = searchCondition + " and ";
                }

                searchCondition = searchCondition + " District like '%" + txtDistrictSearch.Text + "%'";
            }

            if (rlstActive.SelectedValue == "0")
            {
                if (searchCondition != string.Empty)
                {
                    searchCondition = searchCondition + " and ";
                }

                searchCondition = searchCondition + " IsActive = 0";
            }
            else if (rlstActive.SelectedValue == "1")
            {
                if (searchCondition != string.Empty)
                {
                    searchCondition = searchCondition + " and ";
                }

                searchCondition = searchCondition + " IsActive = 1";
            }

            DataView dv = new DataView(dsSelect.Tables[0]);
            dv.RowFilter = searchCondition;

            DataSet dsSelectSub = new DataSet();
            dsSelectSub.Tables.Add(dv.ToTable());

            GridViewOperations GrvOperation = new GridViewOperations();
            GrvOperation.BindGridWithSorting(grvSYS_Districtdetail, dsSelectSub, this.SortField, this.SortDirection);
        }
        else
        {
            grvSYS_Districtdetail.DataSource = null;
            grvSYS_Districtdetail.DataBind();
        }
    }

    private void RefreshPageControls()
    {
        ddlCountryIDSearch.SelectedValue = Convert.ToString((int)EnumFile.AssignValue.Zero);
        ddlStateIDSearch.Items.Clear();
        ddlStateIDSearch.Items.Insert(Convert.ToInt32(EnumFile.AssignValue.Zero), "-- Select --");
        ddlStateIDSearch.Items[0].Value = Convert.ToString((int)EnumFile.AssignValue.Zero);
        ddlStateIDSearch.SelectedValue = Convert.ToString((int)EnumFile.AssignValue.Zero);
        ClearControls();
        ClearControlsEdit();
        bindgrvSYS_Districtdetail();
    }

    private void BindDropDown(DataSet dsCountries, DropDownList ddl)
    {
        ddl.DataSource = dsCountries;
        ddl.DataTextField = dsCountries.Tables[0].Columns["Country"].ToString();
        ddl.DataValueField = dsCountries.Tables[0].Columns["CountryID"].ToString();
        ddl.DataBind();
        ddl.Items.Insert(Convert.ToInt32(EnumFile.AssignValue.Zero), "-- Select --");
        ddl.Items[0].Value = ((int)EnumFile.AssignValue.Zero).ToString();
    }

    #endregion

}