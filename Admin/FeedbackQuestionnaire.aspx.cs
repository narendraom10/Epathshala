/// <summary>
/// <Description>Add Feedback Questionnaire</Description>
/// <DevelopedBy>"Bhavesh Prajapati</DevelopedBy>
/// <DevelopedDate>"17 May 2014"</DevelopedDate>
/// <UpdatedBy></UpdatedBy>
/// <UpdatedDate></UpdatedDate>
/// </summary>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Udev.UserMasterPage.Classes;
using System.Globalization;

public partial class Admin_ManageFeedback : System.Web.UI.Page
{
    #region "Declaration"
    Feedback_BLogic BAL_Feedback;
    DataSet dsResult;
    #endregion

    #region "Page Load"
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindFeedbackDetails();
        }
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
    #endregion

    #region "User Definded Functions"
    private void BindFeedbackDetails()
    {
        try
        {
            BAL_Feedback = new Feedback_BLogic();
            dsResult = new DataSet();
            dsResult = BAL_Feedback.GetFeedbackQuestionDetail();

            if (dsResult.Tables.Count > 0)
            {
                string SearchCondition = string.Empty;
                if (txtFeedbackSearch.Text != string.Empty)
                {
                    SearchCondition = "FeedbackQuestion like '%" + txtFeedbackSearch.Text + "%'";
                }
                else
                {
                    if (txtFeedbackSearch.Text == string.Empty)
                    {
                        if (rlstActive.SelectedValue == "1")
                        {
                            SearchCondition = SearchCondition + "IsActive ='Yes'";
                        }
                        else if (rlstActive.SelectedValue == "0")
                        {
                            SearchCondition = SearchCondition + "IsActive ='No'";
                        }
                    }
                    else
                    {
                        if (rlstActive.SelectedValue == "1")
                        {
                            SearchCondition = SearchCondition + " AND IsActive ='Yes'";
                        }
                        else if (rlstActive.SelectedValue == "0")
                        {
                            SearchCondition = SearchCondition + " AND IsActive ='No'";
                        }
                    }
                }
                DataView dv = new DataView(dsResult.Tables[0]);
                dv.RowFilter = SearchCondition;
                DataSet dsFeedback = new DataSet();
                dsFeedback.Tables.Add(dv.ToTable());

                grvSYS_Feedbackdetail.DataSource = dsFeedback;
                grvSYS_Feedbackdetail.DataBind();
            }


        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
    private void ClearAllControls()
    {
        AllPanelVisible();
        ClearControls(txtFeedbackSearch);
        ClearControls(txtFeedback);
        foreach (GridViewRow gr in grvSYS_Feedbackdetail.Rows)
        {
            CheckBox chk = new CheckBox();
            chk = (CheckBox)gr.FindControl("chkSelect");
            chk.Checked = false;
        }
    }
    private void AllPanelVisible()
    {
        pnlAdd.CssClass = "InVisible";
        pnlEdit.CssClass = "InVisible";
        pnlSearch.CssClass = "Visible";
        pnlActDeact.CssClass = "InVisible";
    }
    private void ClearControls(TextBox txtFeedback)
    {
        txtFeedback.Text = string.Empty;
    }
    #endregion

    #region "Control Events"
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        BindFeedbackDetails();
    }
    protected void btnSearchReset_Click(object sender, EventArgs e)
    {
        txtFeedbackSearch.Text = string.Empty;
        rlstActive.ClearSelection();
        AllPanelVisible();
        pnlSearch.CssClass = "Visible";
    }
    protected void ibtnRefresh_Click(object sender, ImageClickEventArgs e)
    {
        ClearAllControls();
        pnlSearch.CssClass = "Visible";
        rlstActive.ClearSelection();
        BindFeedbackDetails();
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ClearControls(txtFeedback);
    }
    protected void btnCancelEdit_Click(object sender, EventArgs e)
    {
        ClearControls(txtFeedbackEdit);
        AllPanelVisible();
        pnlSearch.CssClass = "Visible";
    }
    protected void ibtnEdit_Click(object sender, ImageClickEventArgs e)
    {
        if (pnlEdit.CssClass == "InVisible")
        {
            AllPanelVisible();
            ClearControls(txtFeedbackEdit);
            pnlEdit.CssClass = "Visible";
            pnlSearch.CssClass = "InVisible";
        }
        //if (pnlEdit.CssClass != "InVisible")
        //{
        int CountChecked = 0;
        int GRIndex = 0;

        foreach (GridViewRow gr in grvSYS_Feedbackdetail.Rows)
        {
            CheckBox chk = new CheckBox();
            chk = (CheckBox)gr.FindControl("chkSelect");
            if (chk.Checked == true)
            {
                CountChecked++;
                GRIndex = gr.RowIndex;
            }
        }
        if (CountChecked == 0 || CountChecked > 1)
        {
            WebMsg.Show("Please select one row to update.");
        }
        else
        {
            AllPanelVisible();
            pnlEdit.CssClass = "Visible";
            pnlSearch.CssClass = "InVisible";
            ViewState["FeedbackQuestionID"] = Convert.ToInt32(grvSYS_Feedbackdetail.DataKeys[GRIndex]["FeedbackQuestionID"]);
            txtFeedbackEdit.Text = Convert.ToString(grvSYS_Feedbackdetail.DataKeys[GRIndex]["FeedbackQuestion"]);
            string IsActive = Convert.ToString(grvSYS_Feedbackdetail.DataKeys[GRIndex]["IsActive"]);
        }
        //}
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            BAL_Feedback = new Feedback_BLogic();
            int Feedback = BAL_Feedback.InsertUpdateFeedbackQuestion("Insert", txtFeedback.Text, Convert.ToInt32(null), Convert.ToInt32(AppSessions.EmpolyeeID));
            if (Feedback == 1)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Message", "<script> alert('Feedback question added successfully.')</script>", false);
                BindFeedbackDetails();
                ClearAllControls();
                pnlSearch.CssClass = "Visible";
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Message", "<script> alert('Feedback question not added.')</script>", false);
            }
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            BAL_Feedback = new Feedback_BLogic();
            int Feedback = BAL_Feedback.InsertUpdateFeedbackQuestion("Update", txtFeedbackEdit.Text, Convert.ToInt32(ViewState["FeedbackQuestionID"]), Convert.ToInt32(AppSessions.EmpolyeeID));
            if (Feedback == 1)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Message", "<script> alert('Feedback question updated successfully.')</script>", false);
                BindFeedbackDetails();
                ClearAllControls();
                pnlSearch.CssClass = "Visible";
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Message", "<script> alert('Feedback question not update.')</script>", false);
            }
        }
        catch (Exception ex)
        {

            throw ex;
        }

    }
    protected void ibtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        AllPanelVisible();
        pnlSearch.CssClass = "Visible";
    }
    #endregion

    protected void btnActDeactSub_Click(object sender, EventArgs e)
    {
        int CountChecked = 0;
        int FeedbackQuestionIDStr = 0;
        foreach (GridViewRow gr in grvSYS_Feedbackdetail.Rows)
        {
            CheckBox chk = new CheckBox();
            chk = (CheckBox)gr.FindControl("chkSelect");
            if (chk.Checked == true)
            {
                if (CountChecked == 0)
                {
                    FeedbackQuestionIDStr = Convert.ToInt32(grvSYS_Feedbackdetail.DataKeys[gr.RowIndex]["FeedbackQuestionID"].ToString());
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
            BAL_Feedback = new Feedback_BLogic();
            bool Active = false;

            if (rbActive.Checked == true)
            {
                Active = true;
            }
            if (rbDeactive.Checked == true)
            {
                Active = false;
            }
            int Status = BAL_Feedback.BAL_SYS_FeedbackStatus(FeedbackQuestionIDStr, Active);
            if (Status == 1)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Message", "<script> alert(' Record updated successfully.')</script>", false);
                BindFeedbackDetails();
                ClearAllControls();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Message", "<script> alert(' Record not updated successfully.')</script>", false);
            }
        }
    }
}