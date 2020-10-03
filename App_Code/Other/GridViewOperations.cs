using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Data;

/// <summary> 
/// <DevelopedBy>"NARENDRASINH"</DevelopedBy>
/// <DevelopedDate></DevelopedDate>
/// <UpdatedBy>"NARENDRASINH"</UpdatedBy>
/// <UpdatedDate></UpdatedDate>
/// </summary>
public class GridViewOperations
{
	public GridViewOperations()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public void GrvSortingSetImage(GridViewSortEventArgs e, GridView Grv, string SortDirec)
    {
        Image sortImage = new Image();
        int columnIndex = 0;
        if (SortDirec == "ascending")
        {
            sortImage.ImageUrl = "~/App_Themes/images/sort_down_green.png";
        }
        else
        {
            sortImage.ImageUrl = "~/App_Themes/images/sort_up_green.png";
        }
        foreach (DataControlFieldHeaderCell headerCell in Grv.HeaderRow.Cells)
        {
            if (headerCell.ContainingField.SortExpression == e.SortExpression)
            {
                columnIndex = Grv.HeaderRow.Cells.GetCellIndex(headerCell);
            }
        }

        Grv.HeaderRow.Cells[columnIndex].Controls.Add(sortImage);

    }
    public void SetPagerButtonStates(GridView gridView, GridViewRow gvPagerRow, Page page)
    {



        int pageIndex = gridView.PageIndex;

        int pageCount = gridView.PageCount;



        ImageButton ibtnFirst = (ImageButton)gvPagerRow.FindControl("ibtnFirst");

        ImageButton ibtnPrevious = (ImageButton)gvPagerRow.FindControl("ibtnPrevious");

        ImageButton ibtnNext = (ImageButton)gvPagerRow.FindControl("ibtnNext");

        ImageButton ibtnLast = (ImageButton)gvPagerRow.FindControl("ibtnLast");



        ibtnFirst.Enabled = ibtnPrevious.Enabled = (pageIndex != 0);

        ibtnNext.Enabled = ibtnLast.Enabled = (pageIndex < (pageCount - 1));



        DropDownList ddlPageSelector = (DropDownList)gvPagerRow.FindControl("ddlPageSelector");

        ddlPageSelector.Items.Clear();

        for (int i = 1; i <= gridView.PageCount; i++)
        {

            ddlPageSelector.Items.Add(i.ToString());

        }



        ddlPageSelector.SelectedIndex = pageIndex;



        //Anonymous method (see another way to do this at the bottom)

        ddlPageSelector.SelectedIndexChanged += delegate
        {

            gridView.PageIndex = ddlPageSelector.SelectedIndex;
            gridView.DataBind();

        };



    }

    public void BindGridWithSorting(GridView grv, DataSet dsSelect, string sortFildSend, string sortDirectionSend)
    {
        if (dsSelect.Tables.Count > 0)
        {
            DataView dv = new DataView(dsSelect.Tables[0]);
            if (dv.Count != 0)
            {

                if (!sortFildSend.Equals(String.Empty))
                {
                    string strDirect = String.Empty;
                    if (sortDirectionSend.Equals("descending"))
                        strDirect = " DESC";

                    dv.Sort = sortFildSend + strDirect;
                }


                grv.DataSource = dv;
                grv.DataBind();
            }
            else
            {
                grv.DataSource = dv;
                grv.DataBind();
            }
        }
        else
        {
            grv.DataSource = null;
            grv.DataBind();
        }
    }
}