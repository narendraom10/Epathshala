using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Dashboard_PackageConfirmation : System.Web.UI.Page
{

    #region Declaration
    string Pageindex = string.Empty;
    DataTable dt;
    #endregion

    #region Page Events
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Pageindex = Request.QueryString["PageIndex"].ToString();
            dt = (DataTable)(Session["SelectedPackage"]);
            gvSubjects.DataSource = dt;
            gvSubjects.DataBind();
            
            //int packageprice = 0;
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    packageprice += Convert.ToInt32(dt.Rows[i]["Price"].ToString());
            //}

            //lblprice.Visible = true;
            //lblprice.Text = "Total Package Price: " + packageprice.ToString();
            //Session["PackagePrice"] = packageprice.ToString();
        }
        catch (Exception ex)
        {

        }
    }
    #endregion

    #region Control Events
    protected void btngoback_Click(object sender, EventArgs e)
    {
        if (Pageindex == "0")

            Response.Redirect("SelectPackage.aspx", false);
        else
            Response.Redirect("BuyPackage.aspx", false);
    }
    protected void btnconfirm_Click(object sender, EventArgs e)
    {
        try
        {
            //Response.Redirect("Packagepayment.aspx", false);

            Response.Redirect("PackagePaymentNew.aspx", false);
        }
        catch (Exception ex)
        {
            //Response.Redirect("Packagepayment.aspx", false);
        }

    }
    #endregion
    protected void gvSubjects_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            //Label lbltotalpackageprice = (Label)e.Row.FindControl("lbltotalpackageprice");


            int packageprice = 0;
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    packageprice += Convert.ToInt32(dt.Rows[i]["Price"].ToString());
            //}

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                packageprice += Convert.ToInt32(Convert.ToDouble(dt.Rows[i]["Price"].ToString()));
            }

            Session["PackagePrice"] = packageprice.ToString();


            // First cell is used for specifying the Total text
            int intNoOfMergeCol = e.Row.Cells.Count - 1; /*except last column */
            for (int intCellCol = 1; intCellCol < intNoOfMergeCol; intCellCol++)
            {
                e.Row.Cells.RemoveAt(1);

            }
            e.Row.Cells[0].ColumnSpan = intNoOfMergeCol + 1;
            e.Row.Cells[0].BorderWidth = 0;
            e.Row.Cells[1].BorderWidth = 0;
            //e.Row.Cells[0].Text = " <hr style='color:yellow; height: 5px' />";

            e.Row.Cells[0].Text = "<div style='color:Black; Padding:3px 28px 3px 3px; '>" + "Total Price(INR): " + packageprice.ToString("F") + "</div>";
            e.Row.Cells[0].HorizontalAlign = HorizontalAlign.Right;

            Session["PackagePrice"] = packageprice.ToString();
        }
    }
    protected void gvSubjects_RowCreated(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.Footer)
            {

                //int packageprice = 0;
                //for (int i = 0; i < dt.Rows.Count; i++)
                //{
                //    packageprice += Convert.ToInt32(dt.Rows[i]["Price"].ToString());
                //}

                //Session["PackagePrice"] = packageprice.ToString();


                //// First cell is used for specifying the Total text
                //int intNoOfMergeCol = e.Row.Cells.Count - 1; /*except last column */
                //for (int intCellCol = 1; intCellCol < intNoOfMergeCol; intCellCol++)
                //{
                //    e.Row.Cells.RemoveAt(1);

                //}
                //e.Row.Cells[0].ColumnSpan = intNoOfMergeCol;
                //e.Row.Cells[0].BorderWidth = 0;
                //e.Row.Cells[1].BorderWidth = 0;
                ////e.Row.Cells[0].Text = " <hr style='color:yellow; height: 5px' />";

                //e.Row.Cells[0].Text = "<div style='color:Black; Padding:3px; '>" + "Total Price: " + packageprice.ToString() + "</div>";
                //e.Row.Cells[0].HorizontalAlign = HorizontalAlign.Right;

            }

        }
        catch (Exception)
        {


        }
    }
}