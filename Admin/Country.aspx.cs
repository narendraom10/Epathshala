/// <summary>               
/// <Description>Country management</Description>
/// <DevelopedBy>"NARENDRASINH, YOGESH"</DevelopedBy>
/// <DevelopedDate></DevelopedDate>
/// <UpdatedBy>"NARENDRASINH,SHEEL"</UpdatedBy>
/// <UpdatedDate>6-6-2014</UpdatedDate>
/// </summary>
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Udev.UserMasterPage.Classes;
using System.Globalization;

public partial class Admin_Country : System.Web.UI.Page
{
    #region "Variables"
    SYS_Country_BLogic BAL_SYS_Country;
    SYS_Country SYS_Country;
    int status = 0;
    #endregion

    #region"Properties"
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

    #region "Page events"
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindgrvSYS_Countrydetail();
        }
    }
    #endregion

    #region "Control events"
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            SYS_Country = new SYS_Country();
            BAL_SYS_Country = new SYS_Country_BLogic();
            SYS_Country.countryid = Convert.ToInt32(EnumFile.AssignValue.Zero);
            SYS_Country.country = txtCountry.Text;
            SYS_Country.createdby = Convert.ToInt32(Session["EmpolyeeID"]);
            status = BAL_SYS_Country.BAL_SYS_Country_Insert(SYS_Country, "Insert");
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
        ////{ 
        ////}
    }

    protected void BtnCancel_Click(object sender, EventArgs e)
    {
        ClearControls();
        AllPanelInvisible();
        pnlAdd.CssClass = "Visible";
    }

    protected void ibtnRefresh_Click(object sender, ImageClickEventArgs e)
    {
        RefreshPageControls();
    }

    protected void IbtnEdit_Click(object sender, ImageClickEventArgs e)
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
            foreach (GridViewRow gr in grvSYS_Countrydetail.Rows)
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
                ViewState["countryid"] = Convert.ToInt32(grvSYS_Countrydetail.DataKeys[index]["CountryID"]);
                txtCountryEdit.Text = Convert.ToString(grvSYS_Countrydetail.DataKeys[index]["Country"]);
            }
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        bindgrvSYS_Countrydetail();
    }

    protected void BtnUpdate_Click(object sender, EventArgs e)
    {
        SYS_Country = new SYS_Country();
        BAL_SYS_Country = new SYS_Country_BLogic();
        SYS_Country.countryid = Convert.ToInt32(ViewState["countryid"].ToString());
        SYS_Country.country = txtCountryEdit.Text;
        SYS_Country.createdby = Convert.ToInt32(Session["EmpolyeeID"]);
        status = BAL_SYS_Country.BAL_SYS_Country_Update(SYS_Country, "Update");
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

    protected void BtnActDeactSub_Click(object sender, EventArgs e)
    {
        int CountChecked = 0;
        string CountryIDStr = string.Empty;
        foreach (GridViewRow gr in grvSYS_Countrydetail.Rows)
        {
            CheckBox chk = new CheckBox();
            chk = (CheckBox)gr.FindControl("chkSelect");
            if (chk.Checked == true)
            {
                if (CountChecked == 0)
                {
                    CountryIDStr = grvSYS_Countrydetail.DataKeys[gr.RowIndex]["CountryID"].ToString();
                }
                else
                {
                    CountryIDStr = CountryIDStr + "," + grvSYS_Countrydetail.DataKeys[gr.RowIndex]["CountryID"].ToString();
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
            SYS_Country = new SYS_Country();
            BAL_SYS_Country = new SYS_Country_BLogic();
            SYS_Country.countryidStr = CountryIDStr;
            if (rbActive.Checked == true)
            {
                SYS_Country.isactive = true;
            }

            if (rbDeactive.Checked == true)
            {
                SYS_Country.isactive = false;
            }

            status = BAL_SYS_Country.BAL_SYS_Country_Delete(SYS_Country, "UpdateStatus");
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

    protected void GrvSYS_Countrydetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvSYS_Countrydetail.PageIndex = e.NewPageIndex;
        bindgrvSYS_Countrydetail();
    }

    protected void ddlPageSelector_SelectedIndexChanged(object sender, EventArgs e)
    {
        grvSYS_Countrydetail.PageIndex = ((DropDownList)sender).SelectedIndex;
        bindgrvSYS_Countrydetail();
    }

    #endregion

    #region "User defined functions"

    protected override void InitializeCulture()
    {
        string culture = Convert.ToString(Session[Global.SESSION_KEY_CULTURE]);
        //// 'set culture to current thread 
        System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture);
        System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);
        ////call base class 
        base.InitializeCulture();
    }

    private void bindgrvSYS_Countrydetail()
    {
        SYS_Country = new SYS_Country();
        BAL_SYS_Country = new SYS_Country_BLogic();

        DataSet dsSelect = new DataSet();
        dsSelect = BAL_SYS_Country.BAL_SYS_Country_Select(SYS_Country, "SelectAll");
        if (dsSelect.Tables.Count > 0)
        {
            string searchCondition = string.Empty;
            if (txtCountrySearch.Text != string.Empty)
            {
                searchCondition = "Country like '%" + txtCountrySearch.Text + "%'";
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
            GrvOperation.BindGridWithSorting(grvSYS_Countrydetail, dsSelectSub, this.SortField, this.SortDirection);
        }
        else
        {
            grvSYS_Countrydetail.DataSource = null;
            grvSYS_Countrydetail.DataBind();
        }
    }

    protected void GrvSYS_Countrydetail_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (e.SortExpression.Trim() == this.SortField)
        {
            this.SortDirection = (this.SortDirection == "descending" ? "ascending" : "descending");
        }
        else
        {
            this.SortDirection = "ascending";
            this.SortField = e.SortExpression;
            bindgrvSYS_Countrydetail();
        }

        GridViewOperations GrvOperation = new GridViewOperations();
        GrvOperation.GrvSortingSetImage(e, grvSYS_Countrydetail, this.SortDirection);
    }

    protected void GrvSYS_Countrydetail_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Pager)
        {
            GridViewOperations GrvOperation = new GridViewOperations();
            GrvOperation.SetPagerButtonStates(grvSYS_Countrydetail, e.Row, this.Page);
        }
    }

    private void ClearControls()
    {
        txtCountrySearch.Text = string.Empty;
        txtCountry.Text = string.Empty;
    }

    private void ClearControlsEdit()
    {
        AllPanelInvisible();
        pnlSearch.CssClass = "Visible";
        txtCountryEdit.Text = string.Empty;
        txtCountrySearch.Text = string.Empty;
    }

    private void RefreshPageControls()
    {
        txtCountrySearch.Text = string.Empty;
        ClearControls();
        ClearControlsEdit();
        bindgrvSYS_Countrydetail();
    }

    private void AllPanelInvisible()
    {
        pnlAdd.CssClass = "InVisible";
        pnlEdit.CssClass = "InVisible";
        pnlSearch.CssClass = "InVisible";
    }
    #endregion

    protected void btnSearchReset_Click(object sender, EventArgs e)
    {
        AllPanelInvisible();
        rlstActive.ClearSelection();
        txtCountrySearch.Text = string.Empty;
        pnlSearch.CssClass = "Visible";
    }
}