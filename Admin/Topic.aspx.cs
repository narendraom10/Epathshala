///<Summary
/// <DevelopedBy>"NARENDRASINH, YOGESH, Arpit Patel"</DevelopedBy>
/// <UpdatedBy>"Arpit Patel,SHEEL"</UpdatedBy>
/// <Date>26-November-2013,6-6-2014</Date>
/// </summary>
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Udev.UserMasterPage.Classes;
using System.Globalization;

public partial class Admin_Topic : System.Web.UI.Page
{
    # region "Variables"
    SYS_Topic_BLogic BAL_SYS_Topic;
    SYS_Topic SYS_Topic;
    SYS_BMS_BLogic BAL_SYS_BMS = new SYS_BMS_BLogic();

    SYS_BMS SYS_BMS = new SYS_BMS();
    DropDownFill DDF = new DropDownFill();
    SYS_Subject_BLogic BAl_SYS_Subject = new SYS_Subject_BLogic();
    SYS_Subject SYS_Subject = new SYS_Subject();
    SYS_Chapter_BLogic BAl_SYS_Chapter = new SYS_Chapter_BLogic();
    SYS_Chapter SYS_Chapter = new SYS_Chapter();
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
            bindgrvSYS_Topicdetail();
            GetBMS();
            GetSubjectsOnLoad();
            GeChaptersOnLoad();
        }
    }
    # endregion

    # region "Control events"
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            SYS_Topic = new SYS_Topic();
            BAL_SYS_Topic = new SYS_Topic_BLogic();
            SYS_Topic.chapterid = Convert.ToInt32(ddlChapterID.Text);
            SYS_Topic.topicindex = Convert.ToInt32(txtTopicIndex.Text);
            SYS_Topic.topic = txtTopic.Text;
            SYS_Topic.createdby = Convert.ToInt32(Session["EmpolyeeID"]);
            status = BAL_SYS_Topic.BAL_SYS_Topic_Insert(SYS_Topic, "Insert");
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
    }

    protected void grvSYS_Topicdetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvSYS_Topicdetail.PageIndex = e.NewPageIndex;
        bindgrvSYS_Topicdetail();
    }

    protected void grvSYS_Topicdetail_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (e.SortExpression.Trim() == this.SortField)
            this.SortDirection = (this.SortDirection == "descending" ? "ascending" : "descending");
        else
            this.SortDirection = "ascending";
        this.SortField = e.SortExpression;
        bindgrvSYS_Topicdetail();
        GridViewOperations GrvOperation = new GridViewOperations();
        GrvOperation.GrvSortingSetImage(e, grvSYS_Topicdetail, this.SortDirection);
    }

    protected void grvSYS_Topicdetail_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Pager)
        {
            GridViewOperations GrvOperation = new GridViewOperations();
            GrvOperation.SetPagerButtonStates(grvSYS_Topicdetail, e.Row, this.Page);
        }
    }

    protected void ddlPageSelector_SelectedIndexChanged(object sender, EventArgs e)
    {
        grvSYS_Topicdetail.PageIndex = ((DropDownList)sender).SelectedIndex;
        bindgrvSYS_Topicdetail();
    }

    protected void ibtnRefresh_Click(object sender, ImageClickEventArgs e)
    {
        GetSubjectsOnLoad();
        GeChaptersOnLoad();
        RefreshPageControls();
    }

    protected void ibtnEdit_Click(object sender, ImageClickEventArgs e)
    {
        ClearControlsEdit();
        int CountChecked = 0;
        int GRrowIndex = 0;

        foreach (GridViewRow gr in grvSYS_Topicdetail.Rows)
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
            ViewState["topicid"] = Convert.ToInt32(grvSYS_Topicdetail.DataKeys[index]["TopicID"]);
            ddlBMSEdit.SelectedValue = grvSYS_Topicdetail.DataKeys[index]["BMSID"].ToString();
            ddlSubjectEdit.SelectedValue = grvSYS_Topicdetail.DataKeys[index]["SubjectID"].ToString();
            ddlChapterEdit.SelectedValue = Convert.ToString(grvSYS_Topicdetail.DataKeys[index]["ChapterID"]);
            txtTopicIndexEdit.Text = Convert.ToString(grvSYS_Topicdetail.DataKeys[index]["TopicIndex"]);
            txtTopicEdit.Text = Convert.ToString(grvSYS_Topicdetail.DataKeys[index]["Topic"]);
            bool Active = Convert.ToBoolean(grvSYS_Topicdetail.DataKeys[index]["IsActive"]);
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

    protected void ibtnActiveDeactive_Click(object sender, ImageClickEventArgs e)
    {
        //string ActiveDeactive = string.Empty;
        //int Count = 0;
        //foreach (GridViewRow gr in grvSYS_Topicdetail.Rows)
        //{
        //    CheckBox chk = new CheckBox();
        //    chk = (CheckBox)gr.FindControl("chkSelect");
        //    if (chk.Checked == true)
        //    {
        //        if (Count == ((int)EnumFile.AssignValue.Zero))
        //        {
        //            ActiveDeactive = grvSYS_Topicdetail.DataKeys[gr.RowIndex]["TopicID"].ToString();
        //        }
        //        else
        //        {
        //            ActiveDeactive = ActiveDeactive + "," + grvSYS_Topicdetail.DataKeys[gr.RowIndex]["TopicID"].ToString();
        //        }
        //        Count = Count + 1;
        //    }
        //}


        //if (Count > ((int)EnumFile.AssignValue.Zero))
        //{
        //    ViewState["ActiveDeactive"] = ActiveDeactive;
        //}
        //else
        //{
        //    WebMsg.Show("Please select atleast one record");
        //}
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        bindgrvSYS_Topicdetail();
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        SYS_Topic = new SYS_Topic();
        BAL_SYS_Topic = new SYS_Topic_BLogic();
        SYS_Topic.topicid = int.Parse(ViewState["topicid"].ToString());
        SYS_Topic.topic = txtTopicEdit.Text;
        SYS_Topic.topicindex = int.Parse(txtTopicIndexEdit.Text);
        SYS_Topic.chapterid = int.Parse(ddlChapterEdit.SelectedValue);
        if (rlstEditActive.SelectedValue == "1")
        {
            SYS_Topic.isactive = true;
        }
        else
        {
            SYS_Topic.isactive = false;
        }

        status = BAL_SYS_Topic.BAL_SYS_Topic_Update_Admin_Topic(SYS_Topic, "AdminUpdate");
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
        bindgrvSYS_Topicdetail();
    }

    protected void ddlBMSSearch_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlBMSSearch.SelectedValue != "0")
        {
            ddlSubjectSearch.Items.Clear();
            GetSubjects(ddlSubjectSearch, int.Parse(ddlBMSSearch.SelectedValue));
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

    protected void ddlBMSEdit_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlBMSEdit.SelectedValue != "0")
        {
            ddlSubjectEdit.Items.Clear();
            GetSubjects(ddlSubjectEdit, int.Parse(ddlBMSEdit.SelectedValue));
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

    protected void ddlSubjectSearch_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlSubjectSearch.SelectedValue != "0")
            {
                ddlChapterSearch.Items.Clear();
                GetChapters(ddlChapterSearch, Convert.ToInt16(ddlBMSSearch.SelectedValue), Convert.ToInt16(ddlSubjectSearch.SelectedValue));
                ddlChapterSearch.Items.Insert(Convert.ToInt32(EnumFile.AssignValue.Zero), "-- Select --");
                ddlChapterSearch.Items[0].Value = Convert.ToString((int)EnumFile.AssignValue.Zero);
                ddlChapterSearch.Enabled = true;
            }
            else
            {
                ddlChapterSearch.Items.Clear();
                ddlChapterSearch.Items.Insert(Convert.ToInt32(EnumFile.AssignValue.Zero), "-- Select --");
                ddlChapterSearch.Items[0].Value = Convert.ToString((int)EnumFile.AssignValue.Zero);
                ddlChapterSearch.Enabled = true;
            }
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }

    protected void ddlSubjectEdit_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSubjectEdit.SelectedValue != "0")
        {
            ddlChapterSearch.Items.Clear();
            GetChapters(ddlChapterEdit, Convert.ToInt16(ddlBMSEdit.SelectedValue), Convert.ToInt16(ddlSubjectEdit.SelectedValue));
            ddlChapterEdit.Items.Insert(Convert.ToInt32(EnumFile.AssignValue.Zero), "-- Select --");
            ddlChapterEdit.Items[0].Value = Convert.ToString((int)EnumFile.AssignValue.Zero);
            ddlChapterEdit.Enabled = true;
        }
        else
        {
            ddlChapterEdit.Items.Clear();
            ddlChapterEdit.Items.Insert(Convert.ToInt32(EnumFile.AssignValue.Zero), "-- Select --");
            ddlChapterEdit.Items[0].Value = Convert.ToString((int)EnumFile.AssignValue.Zero);
            ddlChapterEdit.Enabled = true;
        }
    }

    protected void btnResetSearch_Click(object sender, EventArgs e)
    {
        ClearControlsSearch();
    }

    protected void btnActDeactSub_Click(object sender, EventArgs e)
    {
        try
        {
            string ActiveDeactive = string.Empty;
            int Count = 0;
            foreach (GridViewRow gr in grvSYS_Topicdetail.Rows)
            {
                CheckBox chk = new CheckBox();
                chk = (CheckBox)gr.FindControl("chkSelect");
                if (chk.Checked == true)
                {
                    if (Count == ((int)EnumFile.AssignValue.Zero))
                    {
                        ActiveDeactive = grvSYS_Topicdetail.DataKeys[gr.RowIndex]["TopicID"].ToString();
                    }
                    else
                    {
                        ActiveDeactive = ActiveDeactive + ", " + grvSYS_Topicdetail.DataKeys[gr.RowIndex]["TopicID"].ToString();
                    }
                    Count = Count + 1;
                }
            }


            if (Count > ((int)EnumFile.AssignValue.Zero))
            {
                bool TempStatus = false;
                if (rbActive.Checked == true)
                {
                    TempStatus = true;
                }

                if (rbDeactive.Checked == true)
                {
                    TempStatus = false;
                }
                SYS_Topic = new SYS_Topic();
                BAL_SYS_Topic = new SYS_Topic_BLogic();
                SYS_Topic.isactive = TempStatus;
                SYS_Topic.topicidStr = ActiveDeactive;

                status = BAL_SYS_Topic.BAL_SYS_Topic_ActivateDeActivate_Admin_Topic(SYS_Topic, "ActivateDeactivate");
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
                //WebMsg.Show("Given command completed successfully");
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
    # endregion

    # region "User defined functions"
    protected void GetBMS()
    {
        try
        {
            DataSet dsBMS = new DataSet();
            dsBMS = BAL_SYS_BMS.BAL_SYS_BMS_SelectAll();
            if (dsBMS.Tables[0].Rows.Count > 0 && dsBMS.Tables[0] != null)
            {

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

    protected void GetSubjects(DropDownList ddl, int BMSID)
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

    protected void GetSubjectsOnLoad()
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

    protected void GeChaptersOnLoad()
    {
        DataSet dsChapters = new DataSet();
        dsChapters = BAl_SYS_Chapter.BAL_SYS_Chapter_Select(SYS_Chapter, "AdminSelect");
        if (dsChapters.Tables[0].Rows.Count > 0 && dsChapters.Tables[0] != null)
        {
            DDF.BindDropDownByTable(ddlChapterEdit, dsChapters.Tables[0], "Chapter", "ChapterID");
            ddlChapterEdit.Items.Insert(Convert.ToInt32(EnumFile.AssignValue.Zero), "-- Select --");
            ddlChapterEdit.Items[0].Value = Convert.ToString((int)EnumFile.AssignValue.Zero);
            ddlChapterEdit.Enabled = true;

            DDF.BindDropDownByTable(ddlChapterSearch, dsChapters.Tables[0], "Chapter", "ChapterID");
            ddlChapterSearch.Items.Insert(Convert.ToInt32(EnumFile.AssignValue.Zero), "-- Select --");
            ddlChapterSearch.Items[0].Value = Convert.ToString((int)EnumFile.AssignValue.Zero);
            ddlChapterSearch.Enabled = true;
        }
    }

    protected void GetChapters(DropDownList ddl, int BMSID, Int16 SubjectID)
    {
        try
        {
            DataSet dsChapters = new DataSet();
            SYS_Chapter.bmsid = BMSID;
            SYS_Chapter.subjectid = SubjectID;
            dsChapters = BAl_SYS_Chapter.BAL_SYS_Chapter_Select_Admin_Topic(SYS_Chapter, "SelectByBMSAndSubjectID");
            if (dsChapters.Tables[0].Rows.Count > 0 && dsChapters.Tables[0] != null)
            {
                DDF.BindDropDownByTable(ddl, dsChapters.Tables[0], "Chapter", "ChapterID");
            }
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }

    private void ClearControls()
    {

        ddlChapterID.SelectedValue = Convert.ToString((int)EnumFile.AssignValue.Zero);
        txtTopicIndex.Text = "";
        txtTopic.Text = "";
    }

    private void AllPanelInvisible()
    {
        pnlAdd.CssClass = "InVisible";
        pnlEdit.CssClass = "InVisible";
        pnlSearch.CssClass = "InVisible";
    }

    private void ClearControlsEdit()
    {
        ddlBMSEdit.SelectedValue = Convert.ToString((int)EnumFile.AssignValue.Zero);
        ddlSubjectEdit.SelectedValue = Convert.ToString((int)EnumFile.AssignValue.Zero);
        ddlChapterEdit.SelectedValue = Convert.ToString((int)EnumFile.AssignValue.Zero);
        txtTopicIndexEdit.Text = "";
        txtTopicEdit.Text = "";
        rlstEditActive.ClearSelection();
    }

    protected void ClearControlsSearch()
    {
        pnlSearch.CssClass = "Visible";
        pnlAdd.CssClass = "InVisible";
        pnlEdit.CssClass = "InVisible";
        pnlActDeact.CssClass = "InVisible";
        ddlBMSSearch.SelectedValue = Convert.ToString((int)EnumFile.AssignValue.Zero);
        ddlSubjectSearch.SelectedValue = Convert.ToString((int)EnumFile.AssignValue.Zero);
        ddlChapterSearch.SelectedValue = Convert.ToString((int)EnumFile.AssignValue.Zero);
        txtTopic.Text = string.Empty;
        txtTopicIndex.Text = string.Empty;
        rlstActive.ClearSelection();
        bindgrvSYS_Topicdetail();
    }

    private void bindgrvSYS_Topicdetail()
    {
        SYS_Topic = new SYS_Topic();
        BAL_SYS_Topic = new SYS_Topic_BLogic();

        DataSet dsSelect = new DataSet();
        dsSelect = BAL_SYS_Topic.BAL_SYS_Topic_Select(SYS_Topic, "SelectForManageTopic");
        if (dsSelect.Tables.Count > 0)
        {
            string searchCondition = string.Empty;

            if (ddlBMSSearch.SelectedValue != Convert.ToString((int)EnumFile.AssignValue.Zero) && ddlBMSSearch.SelectedValue != string.Empty)
            {
                searchCondition = "BMSID=" + ddlBMSSearch.SelectedValue;
            }

            if (ddlSubjectSearch.SelectedValue != Convert.ToString((int)EnumFile.AssignValue.Zero) && ddlSubjectSearch.SelectedValue != string.Empty)
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

            if (ddlChapterSearch.SelectedValue != Convert.ToString((int)EnumFile.AssignValue.Zero) && ddlChapterSearch.SelectedValue != String.Empty)
            {
                if (searchCondition != string.Empty)
                {
                    searchCondition = searchCondition + " and ";
                    searchCondition = searchCondition + "ChapterID = " + ddlChapterSearch.SelectedValue;
                }
                else
                {
                    searchCondition = "ChapterID = " + ddlChapterSearch.SelectedValue;
                }
            }

            if (txtTopicIndexSearch.Text != String.Empty)
            {
                if (searchCondition != string.Empty)
                {
                    searchCondition = searchCondition + " and ";
                    searchCondition = searchCondition + " TopicIndex like '%" + txtTopicIndexSearch.Text + "%'";
                }
                else
                {
                    searchCondition = "TopicIndex like '%" + txtTopicIndexSearch.Text + "%'";
                }
            }

            if (txtTopicSearch.Text != String.Empty)
            {
                if (searchCondition != string.Empty)
                {
                    searchCondition = searchCondition + " and ";
                    searchCondition = searchCondition + "Topic like '%" + txtTopicSearch.Text + "%'";
                }
                else
                {
                    searchCondition = "Topic like '%" + txtTopicSearch.Text + "%'";
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

            DataSet dsSelectSub = new DataSet();
            dsSelectSub.Tables.Add(dv.ToTable());

            GridViewOperations GrvOperation = new GridViewOperations();
            GrvOperation.BindGridWithSorting(grvSYS_Topicdetail, dsSelectSub, this.SortField, this.SortDirection);
        }
        else
        {
            grvSYS_Topicdetail.DataSource = null;
            grvSYS_Topicdetail.DataBind();
        }
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

    private void RefreshPageControls()
    {
        ClearControls();
        ClearControlsEdit();
        ClearControlsSearch();
        bindgrvSYS_Topicdetail();
    }
    # endregion
}