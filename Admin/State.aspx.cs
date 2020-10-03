/// <summary>               
/// <Description>State management</Description>
/// <DevelopedBy>"NARENDRASINH, YOGESH"</DevelopedBy>
/// <DevelopedDate></DevelopedDate>
/// <UpdatedBy>"NARENDRASINH,SHEEL"</UpdatedBy>
/// <UpdatedDate>7-6-2014</UpdatedDate>
/// </summary>
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Udev.UserMasterPage.Classes;
using System.Globalization;

public partial class Admin_State : System.Web.UI.Page
{

    # region "Variables"
    SYS_State_BLogic BAL_SYS_State;
    SYS_State SYS_State;
    SYS_Country PCountry = new SYS_Country();
    SYS_Country_BLogic BLCountry = new SYS_Country_BLogic();
    int status = 0;
    # endregion

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

    # region "Page Event"
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetCoutries();
            bindgrvSYS_Statedetail();
        }
    }
    # endregion

    # region "Control events"
    protected void grvSYS_Statedetail_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (e.SortExpression.Trim() == this.SortField)
            this.SortDirection = (this.SortDirection == "descending" ? "ascending" : "descending");
        else
            this.SortDirection = "ascending";
        this.SortField = e.SortExpression;
        bindgrvSYS_Statedetail();
        GridViewOperations GrvOperation = new GridViewOperations();
        GrvOperation.GrvSortingSetImage(e, grvSYS_Statedetail, this.SortDirection);
    }
    protected void btnSearchReset_Click(object sender, EventArgs e)
    {
        RefreshPageControls();
    }
    protected void grvSYS_Statedetail_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Pager)
        {
            GridViewOperations GrvOperation = new GridViewOperations();
            GrvOperation.SetPagerButtonStates(grvSYS_Statedetail, e.Row, this.Page);
        }
    }
    protected void ddlPageSelector_SelectedIndexChanged(object sender, EventArgs e)
    {
        grvSYS_Statedetail.PageIndex = ((DropDownList)sender).SelectedIndex;
        bindgrvSYS_Statedetail();
    }
    protected void ibtnRefresh_Click(object sender, ImageClickEventArgs e)
    {
        RefreshPageControls();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            SYS_State = new SYS_State();
            BAL_SYS_State = new SYS_State_BLogic();
            SYS_State.countryid = Convert.ToInt32(ddlCountryID.SelectedValue.ToString());
            SYS_State.stateid = 0;
            SYS_State.state = txtState.Text;
            SYS_State.createdby = Convert.ToInt32(Session["EmpolyeeID"]);
            status = BAL_SYS_State.BAL_SYS_State_Insert(SYS_State, "Insert");
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
        finally
        { }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ClearControls();
        AllPanelInvisible();
        pnlAdd.CssClass = "Visible";
    }
    protected void grvSYS_Statedetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvSYS_Statedetail.PageIndex = e.NewPageIndex;
        bindgrvSYS_Statedetail();
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
            foreach (GridViewRow gr in grvSYS_Statedetail.Rows)
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
                int index = GRrowIndex;

                ViewState["stateid"] = Convert.ToInt32(grvSYS_Statedetail.DataKeys[index]["StateID"]);
                ddlCountryIDEdit.SelectedValue = Convert.ToString(grvSYS_Statedetail.DataKeys[index]["CountryID"]);
                txtStateEdit.Text = Convert.ToString(grvSYS_Statedetail.DataKeys[index]["State"]);

            }
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        bindgrvSYS_Statedetail();
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        SYS_State = new SYS_State();
        BAL_SYS_State = new SYS_State_BLogic();
        SYS_State.stateid = Convert.ToInt32(ViewState["stateid"].ToString());
        SYS_State.countryid = Convert.ToInt32(ddlCountryIDEdit.SelectedValue.ToString());
        SYS_State.state = txtStateEdit.Text;
        SYS_State.createdby = Convert.ToInt32(Session["EmpolyeeID"]);
        status = BAL_SYS_State.BAL_SYS_State_Update(SYS_State, "Update");
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
    protected void btnActDeactSub_Click(object sender, EventArgs e)
    {
        int CountChecked = 0;
        string StateIDStr = "";
        foreach (GridViewRow gr in grvSYS_Statedetail.Rows)
        {
            CheckBox chk = new CheckBox();
            chk = (CheckBox)gr.FindControl("chkSelect");
            if (chk.Checked == true)
            {
                if (CountChecked == 0)
                {
                    StateIDStr = grvSYS_Statedetail.DataKeys[gr.RowIndex]["StateID"].ToString();
                }
                else
                {
                    StateIDStr = StateIDStr + "," + grvSYS_Statedetail.DataKeys[gr.RowIndex]["StateID"].ToString();
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
            SYS_State = new SYS_State();
            BAL_SYS_State = new SYS_State_BLogic();
            SYS_State.stateidStr = StateIDStr;
            if (rbActive.Checked == true)
            {
                SYS_State.isactive = true;
            }
            if (rbDeactive.Checked == true)
            {
                SYS_State.isactive = false;
            }
            status = BAL_SYS_State.BAL_SYS_State_Delete(SYS_State, "UpdateStatus");
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
    # endregion

    # region "User defined functions"
    private void ClearControls()
    {
        ddlCountryID.SelectedValue = Convert.ToString((int)EnumFile.AssignValue.Zero);
        txtState.Text = "";

    }
    private void AllPanelInvisible()
    {
        pnlAdd.CssClass = "InVisible";
        pnlEdit.CssClass = "InVisible";
        pnlSearch.CssClass = "InVisible";
    }
    private void ClearControlsEdit()
    {
        AllPanelInvisible();
        pnlSearch.CssClass = "Visible";
        ddlCountryIDEdit.SelectedValue = Convert.ToString((int)EnumFile.AssignValue.Zero);
        txtStateEdit.Text = "";

    }
    private void bindgrvSYS_Statedetail()
    {
        SYS_State = new SYS_State();
        BAL_SYS_State = new SYS_State_BLogic();

        DataSet dsSelect = new DataSet();
        dsSelect = BAL_SYS_State.BAL_SYS_State_Select(SYS_State, "SelectAll");
        if (dsSelect.Tables.Count > 0)
        {
            string searchCondition = "";
            if (ddlCountryIDSearch.SelectedIndex > 0)
            {
                searchCondition = "CountryID = " + ddlCountryIDSearch.SelectedValue.ToString();
            }

            if (txtStateSearch.Text != String.Empty)
            {
                if (searchCondition != "")
                {
                    searchCondition = searchCondition + " and ";
                }
                searchCondition = searchCondition + " State like '%" + txtStateSearch.Text + "%'";
            }
            if (rlstActive.SelectedValue == "0")
            {
                if (searchCondition != "")
                {
                    searchCondition = searchCondition + " and ";
                }
                searchCondition = searchCondition + " IsActive = 0";
            }
            else if (rlstActive.SelectedValue == "1")
            {
                if (searchCondition != "")
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
            GrvOperation.BindGridWithSorting(grvSYS_Statedetail, dsSelectSub, this.SortField, this.SortDirection);
        }
        else
        {
            grvSYS_Statedetail.DataSource = null;
            grvSYS_Statedetail.DataBind();
        }
    }
    private void RefreshPageControls()
    {
        ddlCountryIDSearch.SelectedValue = Convert.ToString((int)EnumFile.AssignValue.Zero);
        txtStateSearch.Text = "";

        ClearControls();
        ClearControlsEdit();
        bindgrvSYS_Statedetail();
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
    protected override void InitializeCulture()
    {
        string culture = Convert.ToString(Session[Global.SESSION_KEY_CULTURE]);
        //// 'set culture to current thread 
        System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture);
        System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);
        ////call base class 
        base.InitializeCulture();
    }
    # endregion

  
}