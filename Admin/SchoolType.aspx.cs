/// <summary>               
/// <Description>SchoolType management</Description>
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

public partial class Admin_SchoolType : System.Web.UI.Page
{
    # region "Variables"
    SYS_SchoolType_BLogic BAL_SYS_SchoolType;
    SYS_SchoolType SYS_SchoolType;
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
            bindgrvSYS_SchoolTypedetail();
        }
    }
    # endregion

    # region "control events"
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            SYS_SchoolType = new SYS_SchoolType();
            BAL_SYS_SchoolType = new SYS_SchoolType_BLogic();
            SYS_SchoolType.schooltypeid = 0;
            SYS_SchoolType.type = txtType.Text;
            SYS_SchoolType.createdby = Convert.ToInt32(Session["EmpolyeeID"]);
            status = BAL_SYS_SchoolType.BAL_SYS_SchoolType_Insert(SYS_SchoolType, "Insert");
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
    protected void grvSYS_SchoolTypedetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvSYS_SchoolTypedetail.PageIndex = e.NewPageIndex;
        bindgrvSYS_SchoolTypedetail();
    }
    protected void grvSYS_SchoolTypedetail_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (e.SortExpression.Trim() == this.SortField)
            this.SortDirection = (this.SortDirection == "descending" ? "ascending" : "descending");
        else
            this.SortDirection = "ascending";
        this.SortField = e.SortExpression;
        bindgrvSYS_SchoolTypedetail();
        GridViewOperations GrvOperation = new GridViewOperations();
        GrvOperation.GrvSortingSetImage(e, grvSYS_SchoolTypedetail, this.SortDirection);
    }
    protected void grvSYS_SchoolTypedetail_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Pager)
        {
            GridViewOperations GrvOperation = new GridViewOperations();
            GrvOperation.SetPagerButtonStates(grvSYS_SchoolTypedetail, e.Row, this.Page);
        }
    }
    protected void ddlPageSelector_SelectedIndexChanged(object sender, EventArgs e)
    {
        grvSYS_SchoolTypedetail.PageIndex = ((DropDownList)sender).SelectedIndex;
        bindgrvSYS_SchoolTypedetail();
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
            foreach (GridViewRow gr in grvSYS_SchoolTypedetail.Rows)
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

                ViewState["schooltypeid"] = Convert.ToInt32(grvSYS_SchoolTypedetail.DataKeys[index]["SchoolTypeID"]);
                txtTypeEdit.Text = Convert.ToString(grvSYS_SchoolTypedetail.DataKeys[index]["Type"]);

            }
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        bindgrvSYS_SchoolTypedetail();
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        SYS_SchoolType = new SYS_SchoolType();
        BAL_SYS_SchoolType = new SYS_SchoolType_BLogic();
        SYS_SchoolType.schooltypeid = Convert.ToInt32(ViewState["schooltypeid"].ToString());
        SYS_SchoolType.type = txtTypeEdit.Text;
        SYS_SchoolType.createdby = Convert.ToInt32(Session["EmpolyeeID"]);
        status = BAL_SYS_SchoolType.BAL_SYS_SchoolType_Update(SYS_SchoolType, "Update");
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
        string SchoolTypeIDStr = "";
        foreach (GridViewRow gr in grvSYS_SchoolTypedetail.Rows)
        {
            CheckBox chk = new CheckBox();
            chk = (CheckBox)gr.FindControl("chkSelect");
            if (chk.Checked == true)
            {
                if (CountChecked == 0)
                {
                    SchoolTypeIDStr = grvSYS_SchoolTypedetail.DataKeys[gr.RowIndex]["SchoolTypeID"].ToString();
                }
                else
                {
                    SchoolTypeIDStr = SchoolTypeIDStr + "," + grvSYS_SchoolTypedetail.DataKeys[gr.RowIndex]["SchoolTypeID"].ToString();
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
            SYS_SchoolType = new SYS_SchoolType();
            BAL_SYS_SchoolType = new SYS_SchoolType_BLogic();
            SYS_SchoolType.schooltypeidStr = SchoolTypeIDStr;
            if (rbActive.Checked == true)
            {
                SYS_SchoolType.isactive = true;
            }
            if (rbDeactive.Checked == true)
            {
                SYS_SchoolType.isactive = false;
            }
            status = BAL_SYS_SchoolType.BAL_SYS_SchoolType_Delete(SYS_SchoolType, "UpdateStatus");
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

    # region "User defined functions "

    private void AllPanelInvisible()
    {
        pnlAdd.CssClass = "InVisible";
        pnlEdit.CssClass = "InVisible";
        pnlSearch.CssClass = "InVisible";
    }
    private void ClearControls()
    {
        txtType.Text = "";

    }
    protected override void InitializeCulture()
    {
        string culture = Convert.ToString(Session[Global.SESSION_KEY_CULTURE]);
        // 'set culture to current thread 
        System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture);
        System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);
        //call base class 
        base.InitializeCulture();
    }
    private void ClearControlsEdit()
    {
        AllPanelInvisible();
        pnlSearch.CssClass = "Visible";
        txtTypeEdit.Text = "";

    }
    private void bindgrvSYS_SchoolTypedetail()
    {
        SYS_SchoolType = new SYS_SchoolType();
        BAL_SYS_SchoolType = new SYS_SchoolType_BLogic();
        SYS_SchoolType.schooltypeid = 0;
        SYS_SchoolType.schooltypeidStr = "";
        DataSet dsSelect = new DataSet();
        dsSelect = BAL_SYS_SchoolType.BAL_SYS_SchoolType_Select(SYS_SchoolType, "SelectAll");

        if (dsSelect.Tables.Count > 0)
        {
            string searchCondition = "";
            if (txtTypeSearch.Text != String.Empty)
            {
                searchCondition = "Type like '%" + txtTypeSearch.Text + "%'";
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
            GrvOperation.BindGridWithSorting(grvSYS_SchoolTypedetail, dsSelectSub, this.SortField, this.SortDirection);
        }
        else
        {
            grvSYS_SchoolTypedetail.DataSource = null;
            grvSYS_SchoolTypedetail.DataBind();
        }
    }
    private void RefreshPageControls()
    {
        txtTypeSearch.Text = "";
        rlstActive.ClearSelection();
        ClearControls();
        ClearControlsEdit();
        bindgrvSYS_SchoolTypedetail();
    }

    # endregion
    protected void btnSearchReset_Click(object sender, EventArgs e)
    {
        txtTypeSearch.Text = string.Empty;
        rlstActive.ClearSelection();
        AllPanelInvisible();
        pnlSearch.CssClass = "Visible";
    }
}