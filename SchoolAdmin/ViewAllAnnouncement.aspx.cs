/// <summary>               
/// <Description>View All Announcement</Description>
/// <DevelopedBy>"Bhavesh Prajapati"</DevelopedBy>
/// <DevelopedDate>"16-Nov-2013"</DevelopedDate>
/// <UpdatedBy>""</UpdatedBy>
/// <UpdatedDate></UpdatedDate>
/// </summary>
using System;
using System.Data;
using System.Globalization;
using System.Web.UI.WebControls;
using Udev.UserMasterPage.Classes;

public partial class SchoolAdmin_ViewAllAnnouncement : System.Web.UI.Page
{
    #region "Declarartion"
    Announcement_BLogic BAL_Announcement = new Announcement_BLogic();

    #endregion

    #region "Properties
    string SortDirection
    {
        get
        {
            object o = this.ViewState["SortDirection"];
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
            this.ViewState["SortDirection"] = value;
        }
    }

    string SortField
    {
        get
        {
            object o = this.ViewState["SortField"];
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
            this.ViewState["SortField"] = value;
        }
    }

    #endregion

    #region "Page_Event"

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
        if (!this.IsPostBack)
        {
            this.BindMoreAnnouncement();
        }
    }

    #endregion

    #region "Controls_Event"

    protected void btnBackHomePage_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Dashboard/SchoolAdminDashboard.aspx");
    }

    protected void gvAnnouncementDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            DropDownList DDLSelectPage = (DropDownList)gvAnnouncementDetails.BottomPagerRow.FindControl("ddlPageSelector");
            DDLSelectPage.SelectedIndex = e.NewPageIndex;
            gvAnnouncementDetails.PageIndex = e.NewPageIndex;
            this.BindMoreAnnouncement();
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message.ToString());
        }
    }

    protected void gvAnnouncementDetails_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Pager)
        {
            GridViewOperations GrvOperation = new GridViewOperations();
            GrvOperation.SetPagerButtonStates(this.gvAnnouncementDetails, e.Row, this.Page);
        }
    }

    protected void gvAnnouncementDetails_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (e.SortExpression.Trim() == this.SortField)
        {
            this.SortDirection = (this.SortDirection == "descending" ? "ascending" : "descending");
        }
        else
        {
            this.SortDirection = "ascending";
        }

        this.SortField = e.SortExpression;
        this.BindMoreAnnouncement();
        GridViewOperations GrvOperation = new GridViewOperations();
        GrvOperation.GrvSortingSetImage(e, this.gvAnnouncementDetails, this.SortDirection);
    }

    protected void ddlPageSelector_SelectedIndexChanged(object sender, EventArgs e)
    {
        gvAnnouncementDetails.PageIndex = ((DropDownList)sender).SelectedIndex;
        this.BindMoreAnnouncement();
    }

    #endregion

    #region "User_Defined_Function"

    private void BindMoreAnnouncement()
    {
        DataSet dsSelect = new DataSet();
        dsSelect = this.BAL_Announcement.BAL_SelectAnnouncementBySchoolID(Convert.ToInt32(this.Session["SchoolID"]), "SelectAll");
        gvAnnouncementDetails.DataSource = dsSelect;
        if (dsSelect.Tables.Count > (int)EnumFile.AssignValue.Zero)
        {
            GridViewOperations GrvOperation = new GridViewOperations();
            GrvOperation.BindGridWithSorting(this.gvAnnouncementDetails, dsSelect, this.SortField, this.SortDirection);
            RepDetails.DataSource = dsSelect;
            RepDetails.DataBind();
        }
        else
        {
            gvAnnouncementDetails.DataSource = null;
            gvAnnouncementDetails.DataBind();
        }
    }

    #endregion
}