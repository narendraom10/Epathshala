/// <summary>               
/// <Description>Medium management</Description>
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

public partial class Admin_Medium : System.Web.UI.Page
{
    #region "Variables"

    SYS_Medium_BLogic BAL_SYS_Medium;
    SYS_Medium SYS_Medium;
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
            bindgrvSYS_Mediumdetail();
        }
    }
    #endregion

    #region "Control events"
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        try
        {
            SYS_Medium = new SYS_Medium();
            BAL_SYS_Medium = new SYS_Medium_BLogic();
            SYS_Medium.mediumid = 0;
            SYS_Medium.medium = txtMedium.Text;
            SYS_Medium.code = txtCode.Text;
            SYS_Medium.description = txtDescription.Text;
            SYS_Medium.createdby = Convert.ToInt32(Session["EmpolyeeID"]);
            SYS_Medium.modifiedby = Convert.ToInt32(Session["EmpolyeeID"]);
            status = BAL_SYS_Medium.BAL_SYS_Medium_Insert(SYS_Medium, "Insert");
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

    protected void grvSYS_Mediumdetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvSYS_Mediumdetail.PageIndex = e.NewPageIndex;
        bindgrvSYS_Mediumdetail();
    }

    protected void BtnCancel_Click(object sender, EventArgs e)
    {
        ClearControls();
        AllPanelInvisible();
        pnlAdd.CssClass = "Visible";
    }

    protected void grvSYS_Mediumdetail_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (e.SortExpression.Trim() == this.SortField)
        {
            this.SortDirection = (this.SortDirection == "descending" ? "ascending" : "descending");
        }
        else
        {
            this.SortDirection = "ascending";
            this.SortField = e.SortExpression;
            bindgrvSYS_Mediumdetail();
        }

        GridViewOperations GrvOperation = new GridViewOperations();
        GrvOperation.GrvSortingSetImage(e, grvSYS_Mediumdetail, this.SortDirection);
    }

    protected void grvSYS_Mediumdetail_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Pager)
        {
            GridViewOperations GrvOperation = new GridViewOperations();
            GrvOperation.SetPagerButtonStates(grvSYS_Mediumdetail, e.Row, this.Page);
        }
    }

    protected void ddlPageSelector_SelectedIndexChanged(object sender, EventArgs e)
    {
        grvSYS_Mediumdetail.PageIndex = ((DropDownList)sender).SelectedIndex;
        bindgrvSYS_Mediumdetail();
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
            foreach (GridViewRow gr in grvSYS_Mediumdetail.Rows)
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
                ViewState["mediumid"] = Convert.ToInt32(grvSYS_Mediumdetail.DataKeys[index]["MediumID"]);
                txtMediumEdit.Text = Convert.ToString(grvSYS_Mediumdetail.DataKeys[index]["Medium"]);
                txtCodeEdit.Text = Convert.ToString(grvSYS_Mediumdetail.DataKeys[index]["Code"]);
                txtDescriptionEdit.Text = Convert.ToString(grvSYS_Mediumdetail.DataKeys[index]["Description"]);
            }
        }
    }

    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        bindgrvSYS_Mediumdetail();
    }

    protected void BtnUpdate_Click(object sender, EventArgs e)
    {
        SYS_Medium = new SYS_Medium();
        BAL_SYS_Medium = new SYS_Medium_BLogic();
        SYS_Medium.mediumid = Convert.ToInt32(ViewState["mediumid"].ToString());
        SYS_Medium.medium = txtMediumEdit.Text;
        SYS_Medium.code = txtCodeEdit.Text;
        SYS_Medium.description = txtDescriptionEdit.Text;
        SYS_Medium.createdby = Convert.ToInt32(Session["EmpolyeeID"]);
        SYS_Medium.modifiedby = Convert.ToInt32(Session["EmpolyeeID"]);
        status = BAL_SYS_Medium.BAL_SYS_Medium_Update(SYS_Medium, "Update");
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

    protected void BtnActDeactSub_Click(object sender, EventArgs e)
    {
        int CountChecked = 0;
        string MediumIDStr = string.Empty;
        foreach (GridViewRow gr in grvSYS_Mediumdetail.Rows)
        {
            CheckBox chk = new CheckBox();
            chk = (CheckBox)gr.FindControl("chkSelect");
            if (chk.Checked == true)
            {
                if (CountChecked == 0)
                {
                    MediumIDStr = grvSYS_Mediumdetail.DataKeys[gr.RowIndex]["MediumID"].ToString();
                }
                else
                {
                    MediumIDStr = MediumIDStr + "," + grvSYS_Mediumdetail.DataKeys[gr.RowIndex]["MediumID"].ToString();
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
            SYS_Medium = new SYS_Medium();
            BAL_SYS_Medium = new SYS_Medium_BLogic();
            SYS_Medium.mediumid = 0;
            SYS_Medium.mediumidStr = MediumIDStr;
            if (rbActive.Checked == true)
            {
                SYS_Medium.isactive = true;
            }

            if (rbDeactive.Checked == true)
            {
                SYS_Medium.isactive = false;
            }

            status = BAL_SYS_Medium.BAL_SYS_Medium_Delete(SYS_Medium, "UpdateStatus");
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

    private void ClearControls()
    {
        txtMedium.Text = string.Empty;
        txtCode.Text = string.Empty;
        txtDescription.Text = string.Empty;
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
        txtMediumEdit.Text = string.Empty;
        txtCodeEdit.Text = string.Empty;
        txtDescriptionEdit.Text = string.Empty;
    }

    private void bindgrvSYS_Mediumdetail()
    {
        SYS_Medium = new SYS_Medium();
        BAL_SYS_Medium = new SYS_Medium_BLogic();
        DataSet dsSelect = new DataSet();
        dsSelect = BAL_SYS_Medium.BAL_SYS_Medium_Select(SYS_Medium, "SelectAll");
        if (dsSelect.Tables.Count > 0)
        {
            string searchCondition = string.Empty;
            if (txtMediumSearch.Text != string.Empty)
            {
                searchCondition = "Medium like '%" + txtMediumSearch.Text + "%'";
            }

            if (txtCodeSearch.Text != string.Empty)
            {
                if (searchCondition != string.Empty)
                {
                    searchCondition = searchCondition + " and ";
                }

                searchCondition = "Code like '%" + txtCodeSearch.Text + "%'";
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
            GrvOperation.BindGridWithSorting(grvSYS_Mediumdetail, dsSelectSub, this.SortField, this.SortDirection);
        }
        else
        {
            grvSYS_Mediumdetail.DataSource = null;
            grvSYS_Mediumdetail.DataBind();
        }
    }

    private void RefreshPageControls()
    {
        txtMediumSearch.Text = string.Empty;
        txtCodeSearch.Text = string.Empty;
        txtDescriptionSearch.Text = string.Empty;
        ClearControls();
        ClearControlsEdit();
        rlstActive.ClearSelection();
        bindgrvSYS_Mediumdetail();

    }
    #endregion
    protected void btnSearchReset_Click(object sender, EventArgs e)
    {
        RefreshPageControls();
    }
}