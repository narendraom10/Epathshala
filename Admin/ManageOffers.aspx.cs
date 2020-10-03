using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_ManageOffers : System.Web.UI.Page
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

    #region FormMethods
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindOfferGrid();
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Offers oOffers = new Offers();
        oOffers.OfferID = null;
        oOffers.OfferText = txtOfferText.Text;
        oOffers.OfferLink = txtOfferLink.Text;
        oOffers.Validity = int.Parse(txtValidity.Text);
        OffersBLogic oOffersBL = new OffersBLogic();
        oOffersBL.InsertOffer(oOffers);

        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Message", "<script> alert('Record successfully inserted.')</script>", false);
        ClearFields();

        //Rebind the latest data
        BindOfferGrid();
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        ClearFields();
    }

    private void ClearFields()
    {
        txtOfferLink.Text = string.Empty;
        txtOfferText.Text = string.Empty;
        txtValidity.Text = string.Empty;
    }
    #endregion

    #region PrivateMethods
    public void BindOfferGrid()
    {
        OffersBLogic oOfferBL = new OffersBLogic();
        gvOfferDetails.DataSource = oOfferBL.GetOffer();
        gvOfferDetails.DataBind();
    }
    #endregion

    #region "GridEvents"
    protected void gvOfferDetails_RowEditing(object sender, GridViewEditEventArgs e)
    {

        gvOfferDetails.EditIndex = e.NewEditIndex;
        BindOfferGrid();

        pnlAdd.Visible = false;
    }
    protected void gvOfferDetails_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvOfferDetails.EditIndex = -1;
        BindOfferGrid();

        pnlAdd.Visible = true;
    }
    protected void gvOfferDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        Offers oOffers = new Offers();
        OffersBLogic oOfferBL = new OffersBLogic();
        Label tmpofferId = (Label)gvOfferDetails.Rows[e.RowIndex].FindControl("lbloffferID");
        if (tmpofferId != null)
        {
            oOffers.OfferID = tmpofferId.Text;
        }
        oOfferBL.DeleteOffer(oOffers);
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Message", "<script> alert('Record successfully deleted.')</script>", false);

        //Rebind the latest data
        BindOfferGrid();

    }

    protected void gvOfferDetails_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        Offers oOffers = new Offers();
        OffersBLogic oOffersBL = new OffersBLogic();

        Label tmpofferId = (Label)gvOfferDetails.Rows[e.RowIndex].FindControl("lblEditoffferID");
        TextBox tmpEOfferText = (TextBox)gvOfferDetails.Rows[e.RowIndex].FindControl("txtEditOfferText");
        TextBox tmpEOfferlink = (TextBox)gvOfferDetails.Rows[e.RowIndex].FindControl("txtEditOfferLink");
        TextBox tmpEValidity = (TextBox)gvOfferDetails.Rows[e.RowIndex].FindControl("txtEditValidity");
        if (tmpofferId != null)
        {
            oOffers.OfferID = tmpofferId.Text;
            oOffers.OfferText = tmpEOfferText.Text;
            oOffers.OfferLink = tmpEOfferlink.Text;
            oOffers.Validity = int.Parse(tmpEValidity.Text);
            oOffersBL.UpdateOffer(oOffers);

            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Message", "<script> alert('Record Updated Successfully.')</script>", false);
            pnlAdd.Visible = true;

            //Rebind the latest data
            gvOfferDetails.EditIndex = -1;
            BindOfferGrid();
        }

    }
    protected void ddlPageSelector_SelectedIndexChanged(object sender, EventArgs e)
    {
        gvOfferDetails.PageIndex = ((DropDownList)sender).SelectedIndex;
        BindOfferGrid();
    }
    protected void gvOfferDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvOfferDetails.PageIndex = e.NewPageIndex;
        BindOfferGrid();
    }
    protected void gvOfferDetails_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Pager)
        {
            GridViewOperations GrvOperation = new GridViewOperations();
            GrvOperation.SetPagerButtonStates(gvOfferDetails, e.Row, this.Page);
        }
    }
    protected void gvOfferDetails_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (e.SortExpression.Trim() == this.SortField)
        {
            this.SortDirection = (this.SortDirection == "descending" ? "ascending" : "descending");
        }
        else
        {
            this.SortDirection = "ascending";
            this.SortField = e.SortExpression;
            BindOfferGrid();
        }

        GridViewOperations GrvOperation = new GridViewOperations();
        GrvOperation.GrvSortingSetImage(e, gvOfferDetails, this.SortDirection);
    }
    #endregion

}