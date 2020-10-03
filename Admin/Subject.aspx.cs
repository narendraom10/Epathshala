/// <summary>               
/// <Description>Subject management</Description>
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

public partial class Admin_Subject : System.Web.UI.Page
{

    # region "Variables"
    SYS_Subject_BLogic BAL_SYS_Subject;
    SYS_Subject SYS_Subject;
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
            bindgrvSYS_Subjectdetail();
        }
    }
    # endregion

    # region "Control events"
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ClearControls();
        AllPanelInvisible();
        pnlAdd.CssClass = "Visible";
    }
    protected void grvSYS_Subjectdetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvSYS_Subjectdetail.PageIndex = e.NewPageIndex;
        bindgrvSYS_Subjectdetail();
    }
    protected void grvSYS_Subjectdetail_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (e.SortExpression.Trim() == this.SortField)
            this.SortDirection = (this.SortDirection == "descending" ? "ascending" : "descending");
        else
            this.SortDirection = "ascending";
        this.SortField = e.SortExpression;
        bindgrvSYS_Subjectdetail();
        GridViewOperations GrvOperation = new GridViewOperations();
        GrvOperation.GrvSortingSetImage(e, grvSYS_Subjectdetail, this.SortDirection);
    }
    protected void grvSYS_Subjectdetail_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Pager)
        {
            GridViewOperations GrvOperation = new GridViewOperations();
            GrvOperation.SetPagerButtonStates(grvSYS_Subjectdetail, e.Row, this.Page);
        }
    }
    protected void ddlPageSelector_SelectedIndexChanged(object sender, EventArgs e)
    {
        grvSYS_Subjectdetail.PageIndex = ((DropDownList)sender).SelectedIndex;
        bindgrvSYS_Subjectdetail();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            SYS_Subject = new SYS_Subject();
            BAL_SYS_Subject = new SYS_Subject_BLogic();
            SYS_Subject.subject = txtSubject.Text;
            SYS_Subject.code = txtCode.Text;
            SYS_Subject.description = txtDescription.Text;
            SYS_Subject.createdby = Convert.ToInt32(Session["EmpolyeeID"]);
            SYS_Subject.modifiedby = Convert.ToInt32(Session["EmpolyeeID"]);
            status = BAL_SYS_Subject.BAL_SYS_Subject_Insert(SYS_Subject, "Insert");
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
            foreach (GridViewRow gr in grvSYS_Subjectdetail.Rows)
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

                ViewState["subjectid"] = Convert.ToInt32(grvSYS_Subjectdetail.DataKeys[index]["SubjectID"]);
                txtSubjectEdit.Text = Convert.ToString(grvSYS_Subjectdetail.DataKeys[index]["Subject"]);
                txtCodeEdit.Text = Convert.ToString(grvSYS_Subjectdetail.DataKeys[index]["Code"]);
                txtDescriptionEdit.Text = Convert.ToString(grvSYS_Subjectdetail.DataKeys[index]["Description"]);

            }
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        bindgrvSYS_Subjectdetail();
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        SYS_Subject = new SYS_Subject();
        BAL_SYS_Subject = new SYS_Subject_BLogic();
        SYS_Subject.subjectid = Convert.ToInt32(ViewState["subjectid"].ToString());
        SYS_Subject.subject = txtSubjectEdit.Text;
        SYS_Subject.code = txtCodeEdit.Text;
        SYS_Subject.description = txtDescriptionEdit.Text;
        SYS_Subject.createdby = Convert.ToInt32(Session["EmpolyeeID"]);
        SYS_Subject.modifiedby = Convert.ToInt32(Session["EmpolyeeID"]);
        status = BAL_SYS_Subject.BAL_SYS_Subject_Update(SYS_Subject, "Update");
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
    protected void btnSearchReset_Click(object sender, EventArgs e)
    {
        RefreshPageControls();
    }
    protected void btnActDeactSub_Click(object sender, EventArgs e)
    {
        int CountChecked = 0;
        string SubjectIDStr = "";
        foreach (GridViewRow gr in grvSYS_Subjectdetail.Rows)
        {
            CheckBox chk = new CheckBox();
            chk = (CheckBox)gr.FindControl("chkSelect");
            if (chk.Checked == true)
            {
                if (CountChecked == 0)
                {
                    SubjectIDStr = grvSYS_Subjectdetail.DataKeys[gr.RowIndex]["SubjectID"].ToString();
                }
                else
                {
                    SubjectIDStr = SubjectIDStr + "," + grvSYS_Subjectdetail.DataKeys[gr.RowIndex]["SubjectID"].ToString();
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
            SYS_Subject = new SYS_Subject();
            BAL_SYS_Subject = new SYS_Subject_BLogic();
            SYS_Subject.subjectidStr = SubjectIDStr;
            if (rbActive.Checked == true)
            {
                SYS_Subject.isactive = true;
            }
            if (rbDeactive.Checked == true)
            {
                SYS_Subject.isactive = false;
            }
            status = BAL_SYS_Subject.BAL_SYS_Subject_Delete(SYS_Subject, "UpdateStatus");
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
    private void AllPanelInvisible()
    {
        pnlAdd.CssClass = "InVisible";
        pnlEdit.CssClass = "InVisible";
        pnlSearch.CssClass = "InVisible";
    }
    private void ClearControls()
    {
        txtSubject.Text = "";
        txtCode.Text = "";
        txtDescription.Text = "";
    }
    private void ClearControlsEdit()
    {
        AllPanelInvisible();
        pnlSearch.CssClass = "Visible";
        txtSubjectEdit.Text = "";
        txtCodeEdit.Text = "";
        txtDescriptionEdit.Text = "";
    }
    private void bindgrvSYS_Subjectdetail()
    {
        SYS_Subject = new SYS_Subject();
        BAL_SYS_Subject = new SYS_Subject_BLogic();

        DataSet dsSelect = new DataSet();
        dsSelect = BAL_SYS_Subject.BAL_SYS_Subject_Select(SYS_Subject, "SelectAll");
        if (dsSelect.Tables.Count > 0)
        {
            string searchCondition = "";
            if (txtSubjectSearch.Text != String.Empty)
            {
                searchCondition = "Subject like '%" + txtSubjectSearch.Text + "%'";
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
            GrvOperation.BindGridWithSorting(grvSYS_Subjectdetail, dsSelectSub, this.SortField, this.SortDirection);
        }
        else
        {
            grvSYS_Subjectdetail.DataSource = null;
            grvSYS_Subjectdetail.DataBind();
        }
    }
    private void RefreshPageControls()
    {
        txtSubjectSearch.Text = "";
        txtCodeSearch.Text = "";
        txtDescriptionSearch.Text = "";
        rlstActive.ClearSelection();
        ClearControls();
        ClearControlsEdit();
        bindgrvSYS_Subjectdetail();
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