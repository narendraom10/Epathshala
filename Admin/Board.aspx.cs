/// <summary>               
/// <Description>Board management</Description>
/// <DevelopedBy>"NARENDRASINH, YOGESH"</DevelopedBy>
/// <DevelopedDate></DevelopedDate>
/// <UpdatedBy>"NARENDRASINH,SHEEL"</UpdatedBy>
/// <UpdatedDate>6 June 2014</UpdatedDate>
/// </summary>
using System;
using System.Data;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.WebControls;
using Udev.UserMasterPage.Classes;

public partial class Admin_Board : System.Web.UI.Page
{
    #region "Variables"
    SYS_Board_BLogic BAL_SYS_Board;
    SYS_Board SYS_Board;
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
            bindgrvSYS_Boarddetail();
        }
    }

    #endregion

    #region "Control events"

    protected void ibtnRefresh_Click(object sender, ImageClickEventArgs e)
    {
        RefereshPageControls();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            SYS_Board = new SYS_Board();
            BAL_SYS_Board = new SYS_Board_BLogic();
            SYS_Board.board = txtBoard.Text;
            SYS_Board.code = txtCode.Text;
            SYS_Board.description = txtDescription.Text;
            SYS_Board.createdby = Convert.ToInt32(Session["EmpolyeeID"]);
            SYS_Board.modifiedby = Convert.ToInt32(Session["EmpolyeeID"]);
            int status = BAL_SYS_Board.BAL_SYS_Board_Insert(SYS_Board, "Insert");
            if (status == 1)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Message", "<script> alert('Record successfully inserted.')</script>", false);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Message", "<script> alert('Record not inserted.')</script>", false);
            }
            bindgrvSYS_Boarddetail();
            RefereshPageControls();
            ClearControls();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        ////finally
        ////{ }
    }

    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        bindgrvSYS_Boarddetail();
    }

    protected void BtnUpdate_Click(object sender, EventArgs e)
    {
        SYS_Board = new SYS_Board();
        BAL_SYS_Board = new SYS_Board_BLogic();
        SYS_Board.boardid = Convert.ToInt32(ViewState["boardid"].ToString());
        SYS_Board.board = txtBoardEdit.Text;
        SYS_Board.code = txtCodeEdit.Text;
        SYS_Board.description = txtDescriptionEdit.Text;
        SYS_Board.createdby = Convert.ToInt32(Session["EmpolyeeID"]);
        SYS_Board.modifiedby = Convert.ToInt32(Session["EmpolyeeID"]);
        int status = BAL_SYS_Board.BAL_SYS_Board_Update(SYS_Board, "Update");
        if (status == 1)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Message", "<script> alert('Record successfully updated.')</script>", false);
        }
        else
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Message", "<script> alert('Record not updated.')</script>", false);
        }
        RefereshPageControls();
    }

    protected void BtnCancelEdit_Click(object sender, EventArgs e)
    {
        ClearControlsEdit();
    }

    protected void BtnActDeactSub_Click(object sender, EventArgs e)
    {
        int CountChecked = 0;

        string BoardIDStr = string.Empty;
        foreach (GridViewRow gr in grvSYS_Boarddetail.Rows)
        {
            CheckBox chk = new CheckBox();
            chk = (CheckBox)gr.FindControl("chkSelect");
            if (chk.Checked == true)
            {
                if (CountChecked == 0)
                {
                    BoardIDStr = grvSYS_Boarddetail.DataKeys[gr.RowIndex]["BoardID"].ToString();
                }
                else
                {
                    BoardIDStr = BoardIDStr + "," + grvSYS_Boarddetail.DataKeys[gr.RowIndex]["BoardID"].ToString();
                }

                CountChecked = CountChecked + 1;
            }
        }

        if (CountChecked == 0)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Message", "<script> alert('Please select one record to Active/Deactive.')</script>", false);
        }
        else
        {
            SYS_Board = new SYS_Board();
            BAL_SYS_Board = new SYS_Board_BLogic();
            SYS_Board.boardidStr = BoardIDStr;
            //////////////////////////////////////////
            if (rbActive.Checked == true)
            {
                SYS_Board.isactive = true;
            }

            if (rbDeactive.Checked == true)
            {
                SYS_Board.isactive = false;
            }

            status = BAL_SYS_Board.BAL_SYS_Board_Delete(SYS_Board, "UpdateStatus");
            if (status == 1)
            {
                string status1 = string.Empty;
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
                //////////////////////////////////////////////////
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Message", "<script> alert('Selected record not Active/Deactive.')</script>", false);
            }
            RefereshPageControls();
        }
    }

    protected void BtnCancel_Click(object sender, EventArgs e)
    {
        ClearControls();
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
            foreach (GridViewRow gr in grvSYS_Boarddetail.Rows)
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
                int BoardID;
                int index = GRrowIndex;
                ////Convert.ToInt32(e.CommandArgument);
                BoardID = Convert.ToInt32(grvSYS_Boarddetail.DataKeys[index]["BoardID"]);
                ViewState["boardid"] = Convert.ToInt32(grvSYS_Boarddetail.DataKeys[index]["BoardID"]);
                txtBoardEdit.Text = Convert.ToString(grvSYS_Boarddetail.DataKeys[index]["Board"]);
                txtCodeEdit.Text = Convert.ToString(grvSYS_Boarddetail.DataKeys[index]["Code"]);
                txtDescriptionEdit.Text = Convert.ToString(grvSYS_Boarddetail.DataKeys[index]["Description"]);
            }
        }
    }
    #endregion

    #region Userdefined function

    protected override void InitializeCulture()
    {
        string culture = Convert.ToString(Session[Global.SESSION_KEY_CULTURE]);
        //// 'set culture to current thread 
        System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture);
        System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);
        ////call base class 
        base.InitializeCulture();
    }

    protected void GrvSYS_Boarddetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvSYS_Boarddetail.PageIndex = e.NewPageIndex;
        bindgrvSYS_Boarddetail();
    }

    protected void GrvSYS_Boarddetail_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (e.SortExpression.Trim() == this.SortField)
        {
            this.SortDirection = (this.SortDirection == "descending" ? "ascending" : "descending");
        }
        else
        {
            this.SortDirection = "ascending";
            this.SortField = e.SortExpression;
            bindgrvSYS_Boarddetail();
        }

        GridViewOperations GrvOperation = new GridViewOperations();
        GrvOperation.GrvSortingSetImage(e, grvSYS_Boarddetail, this.SortDirection);
    }

    protected void GrvSYS_Boarddetail_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Pager)
        {
            GridViewOperations GrvOperation = new GridViewOperations();
            GrvOperation.SetPagerButtonStates(grvSYS_Boarddetail, e.Row, this.Page);
        }
    }

    protected void DdlPageSelector_SelectedIndexChanged(object sender, EventArgs e)
    {
        grvSYS_Boarddetail.PageIndex = ((DropDownList)sender).SelectedIndex;
        bindgrvSYS_Boarddetail();
    }

    private void ClearControls()
    {
        pnlAdd.CssClass = "Visible";
        pnlSearch.CssClass = "InVisible";
        txtBoard.Text = string.Empty;
        txtCode.Text = string.Empty;
        txtDescription.Text = string.Empty;
    }

    private void ClearControlsEdit()
    {
        pnlEdit.CssClass = "InVisible";
        pnlSearch.CssClass = "Visible";
        txtBoardEdit.Text = string.Empty;
        txtCodeEdit.Text = string.Empty;
        txtDescriptionEdit.Text = string.Empty;
    }

    private void bindgrvSYS_Boarddetail()
    {
        SYS_Board = new SYS_Board();
        BAL_SYS_Board = new SYS_Board_BLogic();

        DataSet dsSelect = new DataSet();
        dsSelect = BAL_SYS_Board.BAL_SYS_Board_Select(SYS_Board, "SelectAll");
        if (dsSelect.Tables.Count > 0)
        {
            string searchCondition = string.Empty;
            if (txtBoardSearch.Text != string.Empty)
            {
                searchCondition = "Board like '%" + txtBoardSearch.Text + "%'";
            }

            if (txtCodeSearch.Text != string.Empty)
            {
                if (searchCondition != string.Empty)
                {
                    searchCondition = searchCondition + " and ";
                }

                searchCondition = searchCondition + " Code like '%" + txtCodeSearch.Text + "%'";
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
            GrvOperation.BindGridWithSorting(grvSYS_Boarddetail, dsSelectSub, this.SortField, this.SortDirection);
        }
        else
        {
            grvSYS_Boarddetail.DataSource = null;
            grvSYS_Boarddetail.DataBind();
        }
    }

    private void RefereshPageControls()
    {
        ClearControls();
        ClearControlsEdit();
        pnlSearch.CssClass = "Visible";
        pnlAdd.CssClass = "InVisible";
        pnlEdit.CssClass = "InVisible";
        txtBoardSearch.Text = string.Empty;
        txtCodeSearch.Text = string.Empty;
        rlstActive.ClearSelection();
        bindgrvSYS_Boarddetail();
    }

    private void AllPanelInvisible()
    {
        pnlEdit.CssClass = "InVisible";
        pnlSearch.CssClass = "InVisible";
        pnlAdd.CssClass = "InVisible";
    }

    #endregion
}