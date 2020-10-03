/// <summary>               
/// <Description>Division management</Description>
/// <DevelopedBy>"NARENDRASINH, YOGESH"</DevelopedBy>
/// <DevelopedDate></DevelopedDate>
/// <UpdatedBy>"NARENDRASINH,SHEEL"</UpdatedBy>
/// <UpdatedDate>6-6-2014</UpdatedDate>
/// </summary>
using System;
using System.Data;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.WebControls;
using Udev.UserMasterPage.Classes;

public partial class Admin_Division : System.Web.UI.Page
{
    #region "Variables"
    SYS_Division_BLogic BAL_SYS_Division;
    SYS_Division SYS_Division;
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

    #region "Page events"
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindgrvSYS_Divisiondetail();
        }
    }
    #endregion

    #region "Control events"
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        try
        {
            SYS_Division = new SYS_Division();
            BAL_SYS_Division = new SYS_Division_BLogic();
            SYS_Division.division = txtDivision.Text;
            SYS_Division.description = txtDescription.Text;
            SYS_Division.createdby = Convert.ToInt32(Session["EmpolyeeID"]);
            SYS_Division.modifiedby = Convert.ToInt32(Session["EmpolyeeID"]);
            status = BAL_SYS_Division.BAL_SYS_Division_Insert(SYS_Division, "Insert");
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

    protected void grvSYS_Divisiondetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvSYS_Divisiondetail.PageIndex = e.NewPageIndex;
        bindgrvSYS_Divisiondetail();
    }

    protected void grvSYS_Divisiondetail_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (e.SortExpression.Trim() == this.SortField)
        {
            this.SortDirection = (this.SortDirection == "descending" ? "ascending" : "descending");
        }
        else
        {
            this.SortDirection = "ascending";
            this.SortField = e.SortExpression;
            bindgrvSYS_Divisiondetail();
        }

        GridViewOperations GrvOperation = new GridViewOperations();
        GrvOperation.GrvSortingSetImage(e, grvSYS_Divisiondetail, this.SortDirection);
    }

    protected void grvSYS_Divisiondetail_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Pager)
        {
            GridViewOperations GrvOperation = new GridViewOperations();
            GrvOperation.SetPagerButtonStates(grvSYS_Divisiondetail, e.Row, this.Page);
        }
    }

    protected void ddlPageSelector_SelectedIndexChanged(object sender, EventArgs e)
    {
        grvSYS_Divisiondetail.PageIndex = ((DropDownList)sender).SelectedIndex;
        bindgrvSYS_Divisiondetail();
    }

    protected void ibtnRefresh_Click(object sender, ImageClickEventArgs e)
    {
        RefreshPageControls();
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
            foreach (GridViewRow gr in grvSYS_Divisiondetail.Rows)
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

                ViewState["divisionid"] = Convert.ToInt32(grvSYS_Divisiondetail.DataKeys[index]["DivisionID"]);
                txtDivisionEdit.Text = Convert.ToString(grvSYS_Divisiondetail.DataKeys[index]["Division"]);
                txtDescriptionEdit.Text = Convert.ToString(grvSYS_Divisiondetail.DataKeys[index]["Description"]);
            }
        }
    }

    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        bindgrvSYS_Divisiondetail();
    }

    protected void BtnUpdate_Click(object sender, EventArgs e)
    {
        SYS_Division = new SYS_Division();
        BAL_SYS_Division = new SYS_Division_BLogic();
        SYS_Division.divisionid = Convert.ToInt32(ViewState["divisionid"].ToString());
        SYS_Division.division = txtDivisionEdit.Text;
        SYS_Division.description = txtDescriptionEdit.Text;
        SYS_Division.createdby = Convert.ToInt32(Session["EmpolyeeID"]);
        SYS_Division.modifiedby = Convert.ToInt32(Session["EmpolyeeID"]);
        status=BAL_SYS_Division.BAL_SYS_Division_Update(SYS_Division, "Update");
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

    protected void BtnCancelEdit_Click(object sender, EventArgs e)
    {
        ClearControlsEdit();
    }
    protected void btnSearchReset_Click(object sender, EventArgs e)
    {
        RefreshPageControls();
    }
    protected void BtnActDeactSub_Click(object sender, EventArgs e)
    {
        int CountChecked = 0;

        string DivisionIDStr = string.Empty;
        foreach (GridViewRow gr in grvSYS_Divisiondetail.Rows)
        {
            CheckBox chk = new CheckBox();
            chk = (CheckBox)gr.FindControl("chkSelect");
            if (chk.Checked == true)
            {
                if (CountChecked == 0)
                {
                    DivisionIDStr = grvSYS_Divisiondetail.DataKeys[gr.RowIndex]["DivisionID"].ToString();
                }
                else
                {
                    DivisionIDStr = DivisionIDStr + "," + grvSYS_Divisiondetail.DataKeys[gr.RowIndex]["DivisionID"].ToString();
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
            SYS_Division = new SYS_Division();
            BAL_SYS_Division = new SYS_Division_BLogic();
            SYS_Division.divisionidStr = DivisionIDStr;
            if (rbActive.Checked == true)
            {
                SYS_Division.isactive = true;
            }

            if (rbDeactive.Checked == true)
            {
                SYS_Division.isactive = false;
            }

            status = BAL_SYS_Division.BAL_SYS_Division_Delete(SYS_Division, "UpdateStatus");
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

    private void RefreshPageControls()
    {
        txtDivisionSearch.Text = string.Empty;
        txtDescriptionSearch.Text = string.Empty;
        rlstActive.ClearSelection();
        ClearControls();
        ClearControlsEdit();
        bindgrvSYS_Divisiondetail();
    }

    private void AllPanelInvisible()
    {
        pnlAdd.CssClass = "InVisible";
        pnlEdit.CssClass = "InVisible";
        pnlSearch.CssClass = "InVisible";
    }

    private void ClearControls()
    {
        txtDivision.Text = string.Empty;
        txtDescription.Text = string.Empty;
    }

    private void ClearControlsEdit()
    {
        AllPanelInvisible();
        pnlSearch.CssClass = "Visible";
        txtDivisionEdit.Text = string.Empty;
        txtDescriptionEdit.Text = string.Empty;
    }

    private void bindgrvSYS_Divisiondetail()
    {
        SYS_Division = new SYS_Division();
        BAL_SYS_Division = new SYS_Division_BLogic();

        DataSet dsSelect = new DataSet();
        dsSelect = BAL_SYS_Division.BAL_SYS_Division_Select(SYS_Division, "SelectAll");
        if (dsSelect.Tables.Count > 0)
        {
            string searchCondition = string.Empty;
            if (txtDivisionSearch.Text != string.Empty)
            {
                searchCondition = "Division like '%" + txtDivisionSearch.Text + "%'";
            }

            if (txtDescriptionSearch.Text != string.Empty)
            {
                if (searchCondition != string.Empty)
                {
                    searchCondition = searchCondition + " and ";
                }

                searchCondition = searchCondition + " Description like '%" + txtDescriptionSearch.Text + "%'";
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
            GrvOperation.BindGridWithSorting(grvSYS_Divisiondetail, dsSelectSub, this.SortField, this.SortDirection);
        }
        else
        {
            grvSYS_Divisiondetail.DataSource = null;
            grvSYS_Divisiondetail.DataBind();
        }
    }
    #endregion
}