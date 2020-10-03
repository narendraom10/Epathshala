///<summary>
/// <DevelopedBy>"NARENDRASINH, YOGESH, Arpit Patel"</DevelopedBy>
/// <UpdatedBy>"Arpit Patel,SHEEL"</UpdatedBy>
/// <Date>26-November-2013,6-6-2014</Date>
/// </summary>
using System;
using System.Data;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.WebControls;
using Udev.UserMasterPage.Classes;

public partial class Admin_Chapter : System.Web.UI.Page
{
    #region "Variables"
    SYS_Chapter_BLogic BAL_SYS_Chapter;
    SYS_Chapter SYS_Chapter;
    SYS_BMS_BLogic BAL_SYS_BMS = new SYS_BMS_BLogic();
    SYS_BMS SYS_BMS = new SYS_BMS();
    DropDownFill DDF = new DropDownFill();
    SYS_Subject_BLogic BAl_SYS_Subject = new SYS_Subject_BLogic();
    SYS_Subject SYS_Subject = new SYS_Subject();
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
                return String.Empty;
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
                return String.Empty;
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

    protected override void InitializeCulture()
    {
        string culture = Convert.ToString(Session[Global.SESSION_KEY_CULTURE]);
        //// 'set culture to current thread 
        System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture);
        System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);
        ////call base class 
        base.InitializeCulture();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                bindgrvSYS_Chapterdetail();
                getBMS();
                getSubjectsOnLoad();
            }
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }
    #endregion

    #region "Control Events"

    protected void BtnSave_Click(object sender, EventArgs e)
    {
        try
        {
            SYS_Chapter = new SYS_Chapter();
            BAL_SYS_Chapter = new SYS_Chapter_BLogic();
            SYS_Chapter.bmsid = int.Parse(ddlBMS.SelectedValue);
            SYS_Chapter.subjectid = Convert.ToInt16(ddlSubject.SelectedValue);
            SYS_Chapter.chapterindex = Convert.ToInt16(txtChapterIndex.Text);
            SYS_Chapter.chapter = txtChapter.Text;
            SYS_Chapter.code = txtCode.Text;
            SYS_Chapter.description = txtDescription.Text;
            SYS_Chapter.createdby = AppSessions.EmpolyeeID;
            status = BAL_SYS_Chapter.BAL_SYS_Chapter_Insert_Admin(SYS_Chapter, "Insert");
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

    protected void BtnActDeactSub_Click(object sender, EventArgs e)
    {
        try
        {
            int CountChecked = 0;
            ////int GRrowIndex = 0;
            string ActiveDeactive = string.Empty;
            foreach (GridViewRow gr in grvSYS_Chapterdetail.Rows)
            {
                CheckBox chk = new CheckBox();
                chk = (CheckBox)gr.FindControl("chkSelect");
                if (chk.Checked == true)
                {
                    if (CountChecked == 0)
                    {
                        ActiveDeactive = grvSYS_Chapterdetail.DataKeys[gr.RowIndex]["ChapterID"].ToString();
                    }
                    else
                    {
                        ActiveDeactive = ActiveDeactive + ", " + grvSYS_Chapterdetail.DataKeys[gr.RowIndex]["ChapterID"].ToString();
                    }

                    CountChecked = CountChecked + 1;
                }
            }

            if (CountChecked > 0)
            {
                SYS_Chapter = new SYS_Chapter();
                BAL_SYS_Chapter = new SYS_Chapter_BLogic();
                SYS_Chapter.Chpateridlist = ActiveDeactive;
                if (rbActive.Checked == true)
                {
                    SYS_Chapter.isactive = true;
                }

                if (rbDeactive.Checked == true)
                {
                    SYS_Chapter.isactive = false;
                }

                status = BAL_SYS_Chapter.BAL_SYS_Chapter_ActivateDeActivate_Admin_Chapter(SYS_Chapter, "ActivateDeactivate");
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
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Message", "<script> alert(' Please select one record to Active/Deactive.')</script>", false);
            }
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }

    protected void BtnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            ClearControls();
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }

    protected void grvSYS_Chapterdetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            grvSYS_Chapterdetail.PageIndex = e.NewPageIndex;
            bindgrvSYS_Chapterdetail();
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }

    protected void grvSYS_Chapterdetail_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            if (e.SortExpression.Trim() == this.SortField)
            {
                this.SortDirection = (this.SortDirection == "descending" ? "ascending" : "descending");
            }
            else
            {
                this.SortDirection = "ascending";
                this.SortField = e.SortExpression;
                bindgrvSYS_Chapterdetail();
            }

            GridViewOperations GrvOperation = new GridViewOperations();
            GrvOperation.GrvSortingSetImage(e, grvSYS_Chapterdetail, this.SortDirection);
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }

    protected void grvSYS_Chapterdetail_RowCreated(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.Pager)
            {
                GridViewOperations GrvOperation = new GridViewOperations();
                GrvOperation.SetPagerButtonStates(grvSYS_Chapterdetail, e.Row, this.Page);
            }
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }

    protected void ddlPageSelector_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            grvSYS_Chapterdetail.PageIndex = ((DropDownList)sender).SelectedIndex;
            bindgrvSYS_Chapterdetail();
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }

    protected void ibtnRefresh_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            getSubjectsOnLoad();
            RefreshPageControls();
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }

    protected void ibtnEdit_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            int CountChecked = 0;
            int GRrowIndex = 0;

            foreach (GridViewRow gr in grvSYS_Chapterdetail.Rows)
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
                int index = 0;
                AllPanelInvisible();
                pnlEdit.CssClass = "Visible";
                index = GRrowIndex;
                ViewState["chapterid"] = Convert.ToInt32(grvSYS_Chapterdetail.DataKeys[index]["ChapterID"]);
                ddlBMSEdit.SelectedValue = grvSYS_Chapterdetail.DataKeys[index]["BMSID"].ToString();
                ddlBMSEdit_SelectedIndexChanged(null, null);
                ddlSubjectEdit.SelectedValue = grvSYS_Chapterdetail.DataKeys[index]["SubjectID"].ToString();
                txtChapterIndexEdit.Text = Convert.ToString(grvSYS_Chapterdetail.DataKeys[index]["ChapterIndex"]);
                txtChapterEdit.Text = Convert.ToString(grvSYS_Chapterdetail.DataKeys[index]["Chapter"]);
                txtCodeEdit.Text = Convert.ToString(grvSYS_Chapterdetail.DataKeys[index]["Code"]);
                txtDescriptionEdit.Text = Convert.ToString(grvSYS_Chapterdetail.DataKeys[index]["Description"]);
                bool Active = Convert.ToBoolean(grvSYS_Chapterdetail.DataKeys[index]["IsActive"]);
                if (Active == true)
                {
                    rlstEditActive.SelectedValue = "1";
                }
                else
                {
                    rlstEditActive.SelectedValue = "0";
                }
            }
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }

    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            bindgrvSYS_Chapterdetail();
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            SYS_Chapter = new SYS_Chapter();
            BAL_SYS_Chapter = new SYS_Chapter_BLogic();
            SYS_Chapter.chapterid = Convert.ToInt32(ViewState["chapterid"].ToString());
            SYS_Chapter.bmsid = int.Parse(ddlBMSEdit.SelectedValue);
            SYS_Chapter.subjectid = Convert.ToInt16(ddlSubjectEdit.SelectedValue);
            SYS_Chapter.chapterindex = Convert.ToInt16(txtChapterIndexEdit.Text);
            SYS_Chapter.chapter = txtChapterEdit.Text;
            SYS_Chapter.code = txtCodeEdit.Text;
            SYS_Chapter.description = txtDescriptionEdit.Text;
            SYS_Chapter.modifiedby = AppSessions.EmpolyeeID;
            if (rlstEditActive.SelectedValue == "1")
            {
                SYS_Chapter.isactive = true;
            }
            else
            {
                SYS_Chapter.isactive = false;
            }

            status = BAL_SYS_Chapter.BAL_SYS_Chapter_Update(SYS_Chapter, "Update");
            if (status == 1)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Message", "<script> alert('Record successfully updated.')</script>", false);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Message", "<script> alert('Record not updated.')</script>", false);
            }
            RefreshPageControls();
            bindgrvSYS_Chapterdetail();
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }

    protected void BtnCancelEdit_Click(object sender, EventArgs e)
    {
        try
        {
            ClearControlsEdit();
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }

    protected void BtnResetSearch_Click(object sender, EventArgs e)
    {
        try
        {
            getSubjectsOnLoad();
            ClearControlsSearch();
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }

    protected void ddlBMS_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlBMS.SelectedValue != "0")
            {
                ddlSubject.Items.Clear();
                getSubjects(ddlSubject, int.Parse(ddlBMS.SelectedValue));
                ddlSubject.Items.Insert(Convert.ToInt32(EnumFile.AssignValue.Zero), "-- Select --");
                ddlSubject.Items[0].Value = Convert.ToString((int)EnumFile.AssignValue.Zero);
                ddlSubject.Enabled = true;
            }
            else
            {
                ddlSubject.Items.Clear();
                ddlSubject.Items.Insert(Convert.ToInt32(EnumFile.AssignValue.Zero), "-- Select --");
                ddlSubject.Items[0].Value = Convert.ToString((int)EnumFile.AssignValue.Zero);
                ddlSubject.Enabled = false;
            }

            pnlAdd.CssClass = "Visible";
            pnlSearch.CssClass = "InVisible";
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }

    protected void ddlBMSSearch_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlBMSSearch.SelectedValue != "0")
            {
                ddlSubjectSearch.Items.Clear();
                getSubjects(ddlSubjectSearch, int.Parse(ddlBMSSearch.SelectedValue));
                ddlSubjectSearch.Items.Insert(Convert.ToInt32(EnumFile.AssignValue.Zero), "-- Select --");
                ddlSubjectSearch.Items[0].Value = Convert.ToString((int)EnumFile.AssignValue.Zero);
            }
            else
            {
                ddlSubjectSearch.Items.Clear();
                ddlSubjectSearch.Items.Insert(Convert.ToInt32(EnumFile.AssignValue.Zero), "-- Select --");
                ddlSubjectSearch.Items[0].Value = Convert.ToString((int)EnumFile.AssignValue.Zero);
            }
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }

    protected void ddlBMSEdit_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlBMSEdit.SelectedValue != "0")
            {
                ddlSubjectEdit.Items.Clear();
                getSubjects(ddlSubjectEdit, int.Parse(ddlBMSEdit.SelectedValue));
                ddlSubjectEdit.Items.Insert(Convert.ToInt32(EnumFile.AssignValue.Zero), "-- Select --");
                ddlSubjectEdit.Items[0].Value = Convert.ToString((int)EnumFile.AssignValue.Zero);
                ddlSubjectEdit.Enabled = true;
            }
            else
            {
                ddlSubjectEdit.Items.Clear();
                ddlSubjectEdit.Items.Insert(Convert.ToInt32(EnumFile.AssignValue.Zero), "-- Select --");
                ddlSubjectEdit.Items[0].Value = Convert.ToString((int)EnumFile.AssignValue.Zero);
                ddlSubjectEdit.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }

    #endregion

    #region "User Defined Functions"

    /// <summary>
    /// Method will be used to bind bms to drop down.
    /// </summary>
    protected void getBMS()
    {
        try
        {
            DataSet dsBMS = new DataSet();
            dsBMS = BAL_SYS_BMS.BAL_SYS_BMS_SelectAll();
            if (dsBMS.Tables[0].Rows.Count > 0 && dsBMS.Tables[0] != null)
            {
                DDF.BindDropDownByTable(ddlBMS, dsBMS.Tables[0], "BMS", "BMSID");
                ddlBMS.Items.Insert(Convert.ToInt32(EnumFile.AssignValue.Zero), "-- Select --");
                ddlBMS.Items[0].Value = Convert.ToString((int)EnumFile.AssignValue.Zero);
                ddlBMS.Enabled = true;

                DDF.BindDropDownByTable(ddlBMSEdit, dsBMS.Tables[0], "BMS", "BMSID");
                ddlBMSEdit.Items.Insert(Convert.ToInt32(EnumFile.AssignValue.Zero), "-- Select --");
                ddlBMSEdit.Items[0].Value = Convert.ToString((int)EnumFile.AssignValue.Zero);
                ddlBMSEdit.Enabled = true;

                DDF.BindDropDownByTable(ddlBMSSearch, dsBMS.Tables[0], "BMS", "BMSID");
                ddlBMSSearch.Items.Insert(Convert.ToInt32(EnumFile.AssignValue.Zero), "-- Select --");
                ddlBMSSearch.Items[0].Value = Convert.ToString((int)EnumFile.AssignValue.Zero);
                ddlBMSSearch.Enabled = true;
            }
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }

    /// <summary>
    /// Method will be used to bind subjects to the drop down.
    /// </summary>
    /// <param name="ddl"></param>
    /// <param name="BMSID"></param>
    protected void getSubjects(DropDownList ddl, int BMSID)
    {
        try
        {
            DataSet dsSubjects = new DataSet();
            dsSubjects = BAl_SYS_Subject.BAL_SYS_Subject_SelectByBMSID(BMSID);
            if (dsSubjects.Tables[0].Rows.Count > 0 && dsSubjects.Tables[0] != null)
            {
                DDF.BindDropDownByTable(ddl, dsSubjects.Tables[0], "Subject", "SubjectID");
            }
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }

    /// <summary>
    /// Method will be used to bind subjects on load time. 
    /// </summary>
    protected void getSubjectsOnLoad()
    {
        try
        {
            DataSet dsSubjects = new DataSet();
            dsSubjects = BAl_SYS_Subject.BAL_SYS_Subject_Select_Admin("AdminSelect");
            if (dsSubjects.Tables[0].Rows.Count > 0 && dsSubjects.Tables[0] != null)
            {
                DDF.BindDropDownByTable(ddlSubjectEdit, dsSubjects.Tables[0], "Subject", "SubjectID");
                ddlSubjectEdit.Items.Insert(Convert.ToInt32(EnumFile.AssignValue.Zero), "-- Select --");
                ddlSubjectEdit.Items[0].Value = Convert.ToString((int)EnumFile.AssignValue.Zero);
                ddlSubjectEdit.Enabled = true;

                DDF.BindDropDownByTable(ddlSubjectSearch, dsSubjects.Tables[0], "Subject", "SubjectID");
                ddlSubjectSearch.Items.Insert(Convert.ToInt32(EnumFile.AssignValue.Zero), "-- Select --");
                ddlSubjectSearch.Items[0].Value = Convert.ToString((int)EnumFile.AssignValue.Zero);
                ddlSubjectSearch.Enabled = true;
            }
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }

    /// <summary>
    /// Method will be used to refresh page controls.
    /// </summary>
    private void RefreshPageControls()
    {
        try
        {
            ClearControls();
            ClearControlsEdit();
            ClearControlsSearch();
            bindgrvSYS_Chapterdetail();
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }

    /// <summary>
    /// Method will be used to clear controls of the add panel.
    /// </summary>
    private void ClearControls()
    {
        try
        {
            pnlAdd.CssClass = "Visible";
            pnlSearch.CssClass = "InVisible";
            ddlBMS.SelectedValue = "0";
            ddlSubject.SelectedValue = "0";
            ddlSubject.Enabled = false;
            txtChapterIndex.Text = string.Empty;
            txtChapter.Text = string.Empty;
            txtCode.Text = string.Empty;
            txtDescription.Text = string.Empty;
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }

    /// <summary>
    /// Method will be used to clear controls of the edit panel.
    /// </summary>
    private void ClearControlsEdit()
    {
        try
        {
            pnlEdit.CssClass = "Visible";
            pnlSearch.CssClass = "InVisible";
            ddlBMSEdit.SelectedValue = "0";
            ddlSubjectEdit.SelectedValue = "0";
            ddlSubjectEdit.Enabled = false;
            txtChapterIndexEdit.Text = string.Empty;
            txtChapterEdit.Text = string.Empty;
            txtCodeEdit.Text = string.Empty;
            txtDescriptionEdit.Text = string.Empty;
            rlstEditActive.ClearSelection();
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }

    /// <summary>
    /// Method will be used to clear controls of the search panel.
    /// </summary>
    protected void ClearControlsSearch()
    {
        try
        {
            pnlSearch.CssClass = "Visible";
            pnlAdd.CssClass = "InVisible";
            pnlEdit.CssClass = "InVisible";
            ddlBMSSearch.SelectedValue = "0";
            ddlSubjectSearch.SelectedValue = "0";
            txtChapterIndexSearch.Text = string.Empty;
            txtChapterSearch.Text = string.Empty;
            txtCodeSearch.Text = string.Empty;
            txtDescriptionSearch.Text = string.Empty;
            rlstActive.ClearSelection();
            bindgrvSYS_Chapterdetail();
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }

    /// <summary>
    /// Method will be used to bind grid view.
    /// </summary>
    private void bindgrvSYS_Chapterdetail()
    {
        try
        {
            SYS_Chapter = new SYS_Chapter();
            BAL_SYS_Chapter = new SYS_Chapter_BLogic();
            DataSet dsSelect = new DataSet();
            dsSelect = BAL_SYS_Chapter.BAL_SYS_Chapter_Select(SYS_Chapter, "AdminSelect");
            if (dsSelect.Tables.Count > 0)
            {
                string searchCondition = string.Empty;
                if (ddlBMSSearch.SelectedValue != "0")
                {
                    searchCondition = "BMSID=" + ddlBMSSearch.SelectedValue;
                }

                if (ddlSubjectSearch.SelectedValue != "0")
                {
                    if (searchCondition != string.Empty)
                    {
                        searchCondition = searchCondition + " and ";
                        searchCondition = searchCondition + "SubjectID=" + ddlSubjectSearch.SelectedValue;
                    }
                    else
                    {
                        searchCondition = "SubjectID=" + ddlSubjectSearch.SelectedValue;
                    }
                }

                if (txtChapterIndexSearch.Text != string.Empty)
                {
                    if (searchCondition != string.Empty)
                    {
                        searchCondition = searchCondition + " and ";
                        searchCondition = searchCondition + "ChapterIndex=" + txtChapterIndexSearch.Text;
                    }
                    else
                    {
                        searchCondition = "ChapterIndex=" + txtChapterIndexSearch.Text;
                    }
                }

                if (txtChapterSearch.Text != string.Empty)
                {
                    if (searchCondition != string.Empty)
                    {
                        searchCondition = searchCondition + " and ";
                        searchCondition = searchCondition + "Chapter like '%" + txtChapterSearch.Text + "%'";
                    }
                    else
                    {
                        searchCondition = "Chapter like '%" + txtChapterSearch.Text + "%'";
                    }
                }

                if (txtCodeSearch.Text != string.Empty)
                {
                    if (searchCondition != string.Empty)
                    {
                        searchCondition = searchCondition + " and ";
                        searchCondition = searchCondition + "Code like '%" + txtCodeSearch.Text + "%'";
                    }
                    else
                    {
                        searchCondition = "Code like '%" + txtCodeSearch.Text + "%'";
                    }
                }

                if (txtDescriptionSearch.Text != string.Empty)
                {
                    if (searchCondition != string.Empty)
                    {
                        searchCondition = searchCondition + " and ";
                        searchCondition = searchCondition + "Description like '%" + txtDescriptionSearch.Text + "%'";
                    }
                    else
                    {
                        searchCondition = "Description like '%" + txtDescriptionSearch.Text + "%'";
                    }
                }

                if (rlstActive.SelectedValue == "1")
                {
                    if (searchCondition != string.Empty)
                    {
                        searchCondition = searchCondition + " and ";
                        searchCondition = searchCondition + "IsActive=" + true;
                    }
                    else
                    {
                        searchCondition = "IsActive=" + true;
                    }
                }
                else if (rlstActive.SelectedValue == "0")
                {
                    if (searchCondition != string.Empty)
                    {
                        searchCondition = searchCondition + " and ";
                        searchCondition = searchCondition + "IsActive=" + false;
                    }
                    else
                    {
                        searchCondition = "IsActive=" + false;
                    }
                }

                DataView dv = new DataView(dsSelect.Tables[0]);
                dv.RowFilter = searchCondition;

                DataSet dsChapter = new DataSet();
                dsChapter.Tables.Add(dv.ToTable());

                GridViewOperations GrvOperation = new GridViewOperations();
                GrvOperation.BindGridWithSorting(grvSYS_Chapterdetail, dsChapter, this.SortField, this.SortDirection);
            }
            else
            {
                grvSYS_Chapterdetail.DataSource = null;
                grvSYS_Chapterdetail.DataBind();
            }
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }

    /// <summary>
    /// Method will be used to set the invisiblity of the panel.
    /// </summary>
    private void AllPanelInvisible()
    {
        try
        {
            pnlAdd.CssClass = "InVisible";
            pnlEdit.CssClass = "InVisible";
            pnlSearch.CssClass = "InVisible";
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }

    #endregion
}