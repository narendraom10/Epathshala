/// <summary>               
/// <Description>Announcement Menu Control</Description>
/// <DevelopedBy>"Bhavesh Prajapati"</DevelopedBy>
/// <DevelopedDate>"16-Nov-2013"</DevelopedDate>
/// <UpdatedBy>""</UpdatedBy>
/// <UpdatedDate></UpdatedDate>
/// </summary>

using System;
using System.Data;
using System.Text;
using System.Web.UI.WebControls;

public partial class UserControl_Announcement : System.Web.UI.UserControl
{
    #region "Declarartion"
    Announcement_BLogic BAL_Announcement = new Announcement_BLogic();

    #endregion

    # region Properties

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

    # region Page events
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindDataListAnnoucement();
        }
    }
    # endregion

    # region Control events

    protected void lbtnViewAll_Click(object sender, EventArgs e)
    {
        BindMoreAnnouncement();
        Response.Redirect("~/SchoolAdmin/ViewAllAnnouncement.aspx");
    }

    protected void gvAnnouncementDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            DropDownList DDLSelectPage = (DropDownList)gvAnnouncementDetails.BottomPagerRow.FindControl("ddlPageSelector");
            DDLSelectPage.SelectedIndex = e.NewPageIndex;
            gvAnnouncementDetails.PageIndex = e.NewPageIndex;
            BindMoreAnnouncement();
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message.ToString());
        }
    }

    protected void lbtnTitleAnnouncement_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/SchoolAdmin/ViewAnnouncement.aspx");
    }

    protected void ddlPageSelector_SelectedIndexChanged(object sender, EventArgs e)
    {
        gvAnnouncementDetails.PageIndex = ((DropDownList)sender).SelectedIndex;
        BindMoreAnnouncement();
    }

    protected void gvAnnouncementDetails_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Pager)
        {
            GridViewOperations GrvOperation = new GridViewOperations();
            GrvOperation.SetPagerButtonStates(gvAnnouncementDetails, e.Row, this.Page);
        }
    }

    protected void gvAnnouncementDetails_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (e.SortExpression.Trim() == this.SortField)
            this.SortDirection = (this.SortDirection == "descending" ? "ascending" : "descending");
        else
            this.SortDirection = "ascending";

        this.SortField = e.SortExpression;
        BindMoreAnnouncement();
        GridViewOperations GrvOperation = new GridViewOperations();
        GrvOperation.GrvSortingSetImage(e, gvAnnouncementDetails, this.SortDirection);
    }

    # endregion

    # region User defined functions
    protected string Limit(object Desc, int length)
    {
        StringBuilder strDesc = new StringBuilder();
        strDesc.Insert(0, Desc.ToString());

        if (strDesc.Length > length)
        {
            return strDesc.ToString().Substring(0, length) + "...";
        }
        else
        {
            return strDesc.ToString();
        }
    }

    private void BindDataListAnnoucement()
    {

        DataSet dsSelect = new DataSet();
        dsSelect = BAL_Announcement.BAL_SelectAnnouncementBySchoolID(Convert.ToInt32(Session["SchoolID"]), "Select");

        if (dsSelect != null)
        {
            int countAnnouncement = Convert.ToInt32(dsSelect.Tables[0].Rows.Count);

            dlAnnouncement.DataSource = dsSelect.Tables[0];
            dlAnnouncement.DataBind();
            if (countAnnouncement >= 5)
            {
                lbtnViewAll.Visible = true;
            }
        }

        //DataTable dtTmpAnnouncement = new DataTable();

        ////dtTmpAnnouncement.Columns.Add("Announcement", typeof(string));
        //dtTmpAnnouncement.Columns.Add("AnnouncementToolTip", typeof(string));
        //dtTmpAnnouncement.Columns.Add("AnnouncementTool", typeof(string));
        //dtTmpAnnouncement.Columns.Add("StartDate", typeof(DateTime));
        //int i = ((int)EnumFile.AssignValue.Zero);
        //int j = ((int)EnumFile.AssignValue.Zero);

        //foreach (DataRow dr in dsSelect.Tables[0].Rows)
        //{
        //    string str = HttpUtility.HtmlDecode(dsSelect.Tables[0].Rows[i]["Announcement"].ToString());
        //    int count = str.Length;
        //    if (count >= 10)
        //    {
        //        // str = str.Substring(0, 20) + "...";
        //        // dlAnnouncement.FindControl("lbtnViewMore").Visible=true;
        //    }

        //    dtTmpAnnouncement.Rows.Add();
        //    //dtTmpAnnouncement.Rows[j]["Announcement"] = str.ToString();
        //    dtTmpAnnouncement.Rows[j]["AnnouncementTool"] = HttpUtility.HtmlDecode(dsSelect.Tables[0].Rows[i]["Announcement"].ToString());
        //    dtTmpAnnouncement.Rows[j]["AnnouncementToolTip"] = dsSelect.Tables[0].Rows[i]["Announcement"].ToString();
        //    dtTmpAnnouncement.Rows[j]["StartDate"] = dsSelect.Tables[0].Rows[i]["StartDate"].ToString();

        //    i++;
        //    j++;
        //}



        //fillToopTip(dtTmpAnnouncement);
    }

    //private void fillToopTip(DataTable dtTmpAnnouncement)
    //{
    //    int k = 0;
    //    foreach (DataRow dr in dtTmpAnnouncement.Rows)
    //    {
    //        Label lblHidden = new Label();

    //        lblHidden = (Label)dlAnnouncement.Items[k].FindControl("lblHidden");
    //        lblHidden.Text = dtTmpAnnouncement.Rows[k]["Announcement"].ToString();
    //        lblHidden.CssClass = "";
    //        lblHidden.ToolTip = lblHidden.Text;
    //        k++;
    //    }

    //    foreach (DataListItem item in dlAnnouncement.Items)
    //    {
    //        string text = ((Label)(item.FindControl("lblAnnouncementSubject"))).Text;
    //    }
    //}

    private void BindMoreAnnouncement()
    {
        DataSet dsSelect = new DataSet();
        dsSelect = BAL_Announcement.BAL_SelectAnnouncementBySchoolID(Convert.ToInt32(Session["SchoolID"]), "SelectAll");
        gvAnnouncementDetails.DataSource = dsSelect;
        if (dsSelect.Tables.Count > ((int)EnumFile.AssignValue.Zero))
        {
            GridViewOperations GrvOperation = new GridViewOperations();
            GrvOperation.BindGridWithSorting(gvAnnouncementDetails, dsSelect, this.SortField, this.SortDirection);
        }
        else
        {
            gvAnnouncementDetails.DataSource = null;
            gvAnnouncementDetails.DataBind();
        }
        //upViewMore.Update();
        //this.mdlextViewMore.Show();
    }
    # endregion
}