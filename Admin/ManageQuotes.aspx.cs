using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_ManageQuotes : System.Web.UI.Page
{
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

    #region FormEvents
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindQuoteGrid();
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Quotes oQuotes = new Quotes();
        QuoteBLogic oQuoteBL = new QuoteBLogic();
        oQuotes.Quote = txtQuoteText.Text;
        oQuotes.ByWhom = txtbyWhom.Text;
        oQuoteBL.InsertQuote(oQuotes);
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Message", "<script> alert('Record inserted Successfully!')</script>", false);
        ClearFields();

        //Rebind the latest data
        BindQuoteGrid();
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        ClearFields();
    }
    #endregion

    #region PrivateMethods
    private void BindQuoteGrid()
    {
        QuoteBLogic oOfferBL = new QuoteBLogic();
        gvQuotes.DataSource = oOfferBL.GetAllQuotes();
        gvQuotes.DataBind();
    }
    private void ClearFields()
    {
        txtQuoteText.Text = "";
        txtbyWhom.Text = "";
    }
    #endregion

    #region GridEvents
    protected void gvQuotes_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvQuotes.EditIndex = e.NewEditIndex;
        BindQuoteGrid();

        pnlAdd.Visible = false;
    }
    protected void gvQuotes_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        Quotes oQuotes = new Quotes();
        QuoteBLogic oQuotesBL = new QuoteBLogic();

        Label tmpquoteId = (Label)gvQuotes.Rows[e.RowIndex].FindControl("lblEditQuoteID");
        TextBox tmpEQuoteText = (TextBox)gvQuotes.Rows[e.RowIndex].FindControl("txtEditQuoteText");
        TextBox tmpEBywhome = (TextBox)gvQuotes.Rows[e.RowIndex].FindControl("txtEditbyWhom");

        if (tmpquoteId != null)
        {
            oQuotes.QuoteID = tmpquoteId.Text;
            oQuotes.Quote = tmpEQuoteText.Text;
            oQuotes.ByWhom = tmpEBywhome.Text;
            
            oQuotesBL.UpdateQuote(oQuotes);

            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Message", "<script> alert('Record Updated Successfully.')</script>", false);
            pnlAdd.Visible = true;

            //Rebind the latest data
            gvQuotes.EditIndex = -1;
            BindQuoteGrid();
        }
    }
    protected void gvQuotes_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvQuotes.PageIndex = e.NewPageIndex;
        BindQuoteGrid();
    }
    protected void gvQuotes_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        Quotes oQuotes = new Quotes();
        QuoteBLogic oQuotesBL = new QuoteBLogic();
        Label tmpquoteId = (Label)gvQuotes.Rows[e.RowIndex].FindControl("lblQuoteID");
        if (tmpquoteId != null)
        {
            oQuotes.QuoteID = tmpquoteId.Text;
        }
        oQuotesBL.DeleteQuote(oQuotes);
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Message", "<script> alert('Record deleted successfully!')</script>", false);

        //Rebind the latest data
        BindQuoteGrid();
    }
    protected void gvQuotes_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Pager)
        {
            GridViewOperations GrvOperation = new GridViewOperations();
            GrvOperation.SetPagerButtonStates(gvQuotes, e.Row, this.Page);
        }
    }
    protected void gvQuotes_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvQuotes.EditIndex = -1;
        BindQuoteGrid();

        pnlAdd.Visible = true;
    }
    protected void ddlPageSelector_SelectedIndexChanged(object sender, EventArgs e)
    {
        gvQuotes.PageIndex = ((DropDownList)sender).SelectedIndex;
        BindQuoteGrid();
    }
    #endregion

    
}