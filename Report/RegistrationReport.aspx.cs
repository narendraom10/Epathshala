using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Report_RegistrationReport : System.Web.UI.Page
{
    # region Variables
    Student_BLogic BAL_Student_BLogic;
    
    Package_BLogic BAL_Package_BLogic;
    # endregion

    #region Properties

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

    #region PageLoad

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            TxtStartDate.Attributes.Add("readonly", "readonly");
            TxtEndDate.Attributes.Add("readonly", "readonly");
            TxtStartDate.Text = DateTime.Now.AddDays(-6).ToString("dd MMM, yyyy");
            TxtEndDate.Text = DateTime.Now.ToString("dd MMM, yyyy");
            BindRegistrationGrid("ALL", TxtStartDate.Text, TxtEndDate.Text);
        }
    }

    #endregion

    #region Control Event

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        BindRegistrationGrid("ALL", TxtStartDate.Text, TxtEndDate.Text);
    }
    /// <summary>
    /// Fire event when chage dropdown selection from pagination
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    /// 
    protected void ddlPageSelector_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            this.gvRegistration.PageIndex = ((DropDownList)sender).SelectedIndex;
            BindRegistrationGrid("ALL", TxtStartDate.Text, TxtEndDate.Text);
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }

    }

    /// <summary>
    /// Fire when page index changing
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvRegistration_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            DropDownList DDLSelectPage = (DropDownList)this.gvRegistration.BottomPagerRow.FindControl("ddlPageSelector");
            DDLSelectPage.SelectedIndex = e.NewPageIndex;
            this.gvRegistration.PageIndex = e.NewPageIndex;
            BindRegistrationGrid("ALL", TxtStartDate.Text, TxtEndDate.Text); 
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }

    /// <summary>
    /// GridView sorting event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvRegistration_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            if (e.SortExpression.Trim() == this.SortField)
            {
                this.SortDirection = this.SortDirection == "descending" ? "ascending" : "descending";
            }
            else
            {
                this.SortDirection = "ascending";
            }

            this.SortField = e.SortExpression;
            BindRegistrationGrid("ALL", TxtStartDate.Text, TxtEndDate.Text);
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }

    /// <summary>
    /// Event fire on pagination row created
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvRegistration_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Pager)
        {
            GridViewOperations GrvOperation = new GridViewOperations();
            GrvOperation.SetPagerButtonStates(gvRegistration, e.Row, this.Page);
        }
    }

    protected void gvRegistration_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "ShowPackage")
        {
            BAL_Package_BLogic = new Package_BLogic();
            DataSet dsPackageDetail = new DataSet();
            dsPackageDetail = BAL_Package_BLogic.GetPackageDetailByPackageId(Convert.ToString(e.CommandArgument));

            gvpackage.DataSource = dsPackageDetail.Tables[0];
            gvpackage.DataBind();

            MdlPackageSleep.Show();
        }
    }

    protected void gvRegistration_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            
        }
    }

    #endregion

    #region User Define Method

    private void BindRegistrationGrid(string p, string startdate, string enddate)
    {
        try
        {
            BAL_Student_BLogic = new Student_BLogic();
            DataSet dsTeacherNotes = new DataSet();
            dsTeacherNotes = BAL_Student_BLogic.BAL_Registration_Select(p, startdate, enddate);

            GridViewOperations GrvOperation = new GridViewOperations();
            GrvOperation.BindGridWithSorting(this.gvRegistration, dsTeacherNotes, this.SortField, this.SortDirection);
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }

    #endregion    
}