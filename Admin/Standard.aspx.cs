/// <summary>               
/// <Description>Standard management</Description>
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

public partial class Admin_Standerd : System.Web.UI.Page
{

    # region "Variables"
    SYS_Standard_BLogic BAL_SYS_Standard;
    SYS_Standard SYS_Standard;
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

    # region "Page events"
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindgrvSYS_Standarddetail();
        }
    }
    # endregion

    # region "Control events"
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            SYS_Standard = new SYS_Standard();
            BAL_SYS_Standard = new SYS_Standard_BLogic();
            SYS_Standard.standardid = 0;
            SYS_Standard.standard = txtStandard.Text;
            SYS_Standard.code = txtCode.Text;
            SYS_Standard.description = txtDescription.Text;
            SYS_Standard.createdby = Convert.ToInt32(Session["EmpolyeeID"]);
            SYS_Standard.modifiedby = Convert.ToInt32(Session["EmpolyeeID"]);
            status =BAL_SYS_Standard.BAL_SYS_Standard_Insert(SYS_Standard, "Insert");
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
            foreach (GridViewRow gr in grvSYS_Standarddetail.Rows)
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

                ViewState["standardid"] = Convert.ToInt32(grvSYS_Standarddetail.DataKeys[index]["StandardID"]);
                txtStandardEdit.Text = Convert.ToString(grvSYS_Standarddetail.DataKeys[index]["Standard"]);
                txtCodeEdit.Text = Convert.ToString(grvSYS_Standarddetail.DataKeys[index]["Code"]);
                txtDescriptionEdit.Text = Convert.ToString(grvSYS_Standarddetail.DataKeys[index]["Description"]);

            }
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        bindgrvSYS_Standarddetail();
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        SYS_Standard = new SYS_Standard();
        BAL_SYS_Standard = new SYS_Standard_BLogic();
        SYS_Standard.standardid = Convert.ToInt32(ViewState["standardid"].ToString());
        SYS_Standard.standard = txtStandardEdit.Text;
        SYS_Standard.code = txtCodeEdit.Text;
        SYS_Standard.description = txtDescriptionEdit.Text;
        SYS_Standard.createdby = Convert.ToInt32(Session["EmpolyeeID"]);
        SYS_Standard.modifiedby = Convert.ToInt32(Session["EmpolyeeID"]);
        status = BAL_SYS_Standard.BAL_SYS_Standard_Update(SYS_Standard, "Update");
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
    protected void btnActDeactSub_Click(object sender, EventArgs e)
    {
        int CountChecked = 0;
        string StandardIDStr = "";
        foreach (GridViewRow gr in grvSYS_Standarddetail.Rows)
        {
            CheckBox chk = new CheckBox();
            chk = (CheckBox)gr.FindControl("chkSelect");
            if (chk.Checked == true)
            {
                if (CountChecked == 0)
                {
                    StandardIDStr = grvSYS_Standarddetail.DataKeys[gr.RowIndex]["StandardID"].ToString();
                }
                else
                {
                    StandardIDStr = StandardIDStr + "," + grvSYS_Standarddetail.DataKeys[gr.RowIndex]["StandardID"].ToString();
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
            SYS_Standard = new SYS_Standard();
            BAL_SYS_Standard = new SYS_Standard_BLogic();
            SYS_Standard.standardid = 0;
            SYS_Standard.standardidStr = StandardIDStr;
            if (rbActive.Checked == true)
            {
                SYS_Standard.isactive = true;
            }
            if (rbDeactive.Checked == true)
            {
                SYS_Standard.isactive = false;
            }
            status=BAL_SYS_Standard.BAL_SYS_Standard_Delete(SYS_Standard, "UpdateStatus");
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
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ClearControls();
        AllPanelInvisible();
        pnlAdd.CssClass = "Visible";
    }
    protected void grvSYS_Standarddetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvSYS_Standarddetail.PageIndex = e.NewPageIndex;
        bindgrvSYS_Standarddetail();
    }
    protected void grvSYS_Standarddetail_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (e.SortExpression.Trim() == this.SortField)
            this.SortDirection = (this.SortDirection == "descending" ? "ascending" : "descending");
        else
            this.SortDirection = "ascending";
        this.SortField = e.SortExpression;
        bindgrvSYS_Standarddetail();
        GridViewOperations GrvOperation = new GridViewOperations();
        GrvOperation.GrvSortingSetImage(e, grvSYS_Standarddetail, this.SortDirection);
    }
    protected void grvSYS_Standarddetail_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Pager)
        {
            GridViewOperations GrvOperation = new GridViewOperations();
            GrvOperation.SetPagerButtonStates(grvSYS_Standarddetail, e.Row, this.Page);
        }
    }
    protected void ddlPageSelector_SelectedIndexChanged(object sender, EventArgs e)
    {
        grvSYS_Standarddetail.PageIndex = ((DropDownList)sender).SelectedIndex;
        bindgrvSYS_Standarddetail();
    }
    protected void ibtnRefresh_Click(object sender, ImageClickEventArgs e)
    {
        RefreshPageControls();
    }
    # endregion

    # region "User defined functions"
    protected override void InitializeCulture()
    {
        string culture = Convert.ToString(Session[Global.SESSION_KEY_CULTURE]);
        // 'set culture to current thread 
        System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture);
        System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);
        //call base class 
        base.InitializeCulture();
    }
    private void ClearControls()
    {
        txtStandard.Text = "";
        txtCode.Text = "";
        txtDescription.Text = "";

    }
    private void ClearControlsEdit()
    {
        AllPanelInvisible();
        pnlSearch.CssClass = "Visible";
        txtStandardEdit.Text = "";
        txtCodeEdit.Text = "";
        txtDescriptionEdit.Text = "";

    }
    private void bindgrvSYS_Standarddetail()
    {
        SYS_Standard = new SYS_Standard();
        BAL_SYS_Standard = new SYS_Standard_BLogic();

        DataSet dsSelect = new DataSet();
        dsSelect = BAL_SYS_Standard.BAL_SYS_Standard_Select(SYS_Standard, "SelectAll");
        if (dsSelect.Tables.Count > 0)
        {
            string searchCondition = "";
            if (txtStandardSearch.Text != String.Empty)
            {
                searchCondition = "Standard like '%" + txtStandardSearch.Text + "%'";
            }

            if (txtCodeSearch.Text != String.Empty)
            {
                if (searchCondition != "")
                {
                    searchCondition = searchCondition + " and ";
                }
                searchCondition = searchCondition + " Code like '%" + txtCodeSearch.Text + "%'";
            }

            if (txtDescriptionSearch.Text != String.Empty)
            {
                if (searchCondition != "")
                {
                    searchCondition = searchCondition + " and ";
                }
                searchCondition = searchCondition + " Description like '%" + txtDescriptionSearch.Text + "%'";
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
            GrvOperation.BindGridWithSorting(grvSYS_Standarddetail, dsSelectSub, this.SortField, this.SortDirection);
        }
        else
        {
            grvSYS_Standarddetail.DataSource = null;
            grvSYS_Standarddetail.DataBind();
        }
    }
    private void RefreshPageControls()
    {
        txtStandardSearch.Text = "";
        txtCodeSearch.Text = "";
        txtDescriptionSearch.Text = "";
        rlstActive.ClearSelection();
        ClearControls();
        ClearControlsEdit();
        bindgrvSYS_Standarddetail();
    }
    private void AllPanelInvisible()
    {
        pnlAdd.CssClass = "InVisible";
        pnlEdit.CssClass = "InVisible";
        pnlSearch.CssClass = "InVisible";
    }
    # endregion

    protected void ibtnSearchReset_Click(object sender, EventArgs e)
    {
        RefreshPageControls();
    }
}

