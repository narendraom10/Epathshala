using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Report_AllSentMessageReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindGridData();
        }
    }
    protected void GvUserList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            DropDownList DDLSelectPage = (DropDownList)this.GvUserList.BottomPagerRow.FindControl("ddlPageSelector");
            DDLSelectPage.SelectedIndex = e.NewPageIndex;
            this.GvUserList.PageIndex = e.NewPageIndex;
            this.BindGridData();
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }

    private void BindGridData()
    {
        Student_BLogic oStudent_BLogic = new Student_BLogic();
        DataSet ods = oStudent_BLogic.BAL_Get_MessageLog();
        this.GvUserList.DataSource = ods;
        this.GvUserList.DataBind();
        
    }
    protected void ddlPageSelector_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            this.GvUserList.PageIndex = ((DropDownList)sender).SelectedIndex;
            this.BindGridData();
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }
    protected void GvUserList_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Pager)
        {
            GridViewOperations GrvOperation = new GridViewOperations();
            GrvOperation.SetPagerButtonStates(this.GvUserList, e.Row, this.Page);
        }
    }
}