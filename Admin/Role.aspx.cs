/// <summary>               
/// <Description>Role management</Description>
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

public partial class Admin_Role : System.Web.UI.Page
{
    #region "Variables"
    SYS_Role_BLogic BAL_SYS_Role;
    SYS_Role SYS_Role;
    int status = 0;
    #endregion

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
    #endregion

    #region "Page event"
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindgrvSYS_Roledetail();
        }
    }
    #endregion

    #region "Control events"
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            SYS_Role = new SYS_Role();
            BAL_SYS_Role = new SYS_Role_BLogic();
            SYS_Role.role = txtRole.Text;
            SYS_Role.description = txtDescription.Text;
            SYS_Role.createdby = Convert.ToInt32(Session["EmpolyeeID"]);
            SYS_Role.modifiedby = Convert.ToInt32(Session["EmpolyeeID"]);
            status = BAL_SYS_Role.BAL_SYS_Role_Insert(SYS_Role, "Insert");
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

    protected void BtnCancel_Click(object sender, EventArgs e)
    {
        ClearControls();
        AllPanelInvisible();
        pnlAdd.CssClass = "Visible";
    }

    protected void grvSYS_Roledetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvSYS_Roledetail.PageIndex = e.NewPageIndex;
        bindgrvSYS_Roledetail();
    }

    protected void grvSYS_Roledetail_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (e.SortExpression.Trim() == this.SortField)
            this.SortDirection = (this.SortDirection == "descending" ? "ascending" : "descending");
        else
            this.SortDirection = "ascending";
        this.SortField = e.SortExpression;
        bindgrvSYS_Roledetail();
        GridViewOperations GrvOperation = new GridViewOperations();
        GrvOperation.GrvSortingSetImage(e, grvSYS_Roledetail, this.SortDirection);
    }

    protected void grvSYS_Roledetail_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Pager)
        {
            GridViewOperations GrvOperation = new GridViewOperations();
            GrvOperation.SetPagerButtonStates(grvSYS_Roledetail, e.Row, this.Page);
        }
    }

    protected void ddlPageSelector_SelectedIndexChanged(object sender, EventArgs e)
    {
        grvSYS_Roledetail.PageIndex = ((DropDownList)sender).SelectedIndex;
        bindgrvSYS_Roledetail();
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
            foreach (GridViewRow gr in grvSYS_Roledetail.Rows)
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
                ViewState["roleid"] = Convert.ToInt32(grvSYS_Roledetail.DataKeys[index]["RoleID"]);
                txtRoleEdit.Text = Convert.ToString(grvSYS_Roledetail.DataKeys[index]["Role"]);
                txtDescriptionEdit.Text = Convert.ToString(grvSYS_Roledetail.DataKeys[index]["Description"]);
            }
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        bindgrvSYS_Roledetail();
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        SYS_Role = new SYS_Role();
        BAL_SYS_Role = new SYS_Role_BLogic();
        SYS_Role.roleid = Convert.ToInt32(ViewState["roleid"].ToString());
        SYS_Role.role = txtRoleEdit.Text;
        SYS_Role.description = txtDescriptionEdit.Text;
        SYS_Role.createdby = Convert.ToInt32(Session["EmpolyeeID"]);
        SYS_Role.modifiedby = Convert.ToInt32(Session["EmpolyeeID"]);
        status = BAL_SYS_Role.BAL_SYS_Role_Update(SYS_Role, "Update");
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

        string DivisionIDStr = string.Empty;
        foreach (GridViewRow gr in grvSYS_Roledetail.Rows)
        {
            CheckBox chk = new CheckBox();
            chk = (CheckBox)gr.FindControl("chkSelect");
            if (chk.Checked == true)
            {

                if (CountChecked == 0)
                {
                    DivisionIDStr = grvSYS_Roledetail.DataKeys[gr.RowIndex]["RoleID"].ToString();
                }
                else
                {
                    DivisionIDStr = DivisionIDStr + "," + grvSYS_Roledetail.DataKeys[gr.RowIndex]["RoleID"].ToString();
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
            SYS_Role = new SYS_Role();
            BAL_SYS_Role = new SYS_Role_BLogic();
            SYS_Role.roleid = 0;
            SYS_Role.roleidStr = DivisionIDStr;
            if (rbActive.Checked == true)
            {
                SYS_Role.isactive = true;
            }
            if (rbDeactive.Checked == true)
            {
                SYS_Role.isactive = false;
            }
            status = BAL_SYS_Role.BAL_SYS_Role_Delete(SYS_Role, "UpdateStatus");
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
    private void AllPanelInvisible()
    {
        pnlAdd.CssClass = "InVisible";
        pnlEdit.CssClass = "InVisible";
        pnlSearch.CssClass = "InVisible";
    }

    private void ClearControls()
    {
        txtRole.Text = string.Empty;
        txtDescription.Text = string.Empty;
    }

    private void ClearControlsEdit()
    {
        AllPanelInvisible();
        pnlSearch.CssClass = "Visible";
        txtRoleEdit.Text = string.Empty;
        txtDescriptionEdit.Text = string.Empty;
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

    private void bindgrvSYS_Roledetail()
    {
        SYS_Role = new SYS_Role();
        BAL_SYS_Role = new SYS_Role_BLogic();

        DataSet dsSelect = new DataSet();
        dsSelect = BAL_SYS_Role.BAL_SYS_Role_Select(SYS_Role, "SelectAll");

        if (dsSelect.Tables.Count > 0)
        {
            string searchCondition = string.Empty;
            if (txtRoleSearch.Text != String.Empty)
            {
                searchCondition = "Role like '%" + txtRoleSearch.Text + "%'";
            }

            if (txtDescriptionSearch.Text != String.Empty)
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
            GrvOperation.BindGridWithSorting(grvSYS_Roledetail, dsSelectSub, this.SortField, this.SortDirection);
        }
        else
        {
            grvSYS_Roledetail.DataSource = null;
            grvSYS_Roledetail.DataBind();
        }
    }

    private void RefreshPageControls()
    {
        txtRoleSearch.Text = string.Empty;
        txtDescriptionSearch.Text = string.Empty;
        rlstActive.ClearSelection();
        ClearControls();
        ClearControlsEdit();
        bindgrvSYS_Roledetail();
    }
    #endregion

    protected void btnSearchReset_Click(object sender, EventArgs e)
    {
        AllPanelInvisible();
        txtRoleSearch.Text = string.Empty;
        txtDescriptionSearch.Text = string.Empty;
        rlstActive.ClearSelection();
        pnlSearch.CssClass = "Visible";
    }
}