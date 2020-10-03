using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Report_DateWiseInteractionReport : System.Web.UI.Page
{
    #region Declaration

    Admission_BLogic oAdmission_BLogic;
    Admission oAdmission;

    #endregion

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

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindAdmissionGrid("");
            TxtStartDate.Text = DateTime.Now.AddDays(-1).ToString("dd MMM yyyy");
            TxtEndDate.Text = DateTime.Now.AddDays(1).ToString("dd MMM yyyy");
        }
    }

    private void BindAdmissionGrid(string status)
    {
        oAdmission = new Admission();
        oAdmission_BLogic = new Admission_BLogic();

        DataSet ods = oAdmission_BLogic.Admission_Select_ByInteraction(DateTime.Now, DateTime.Now);

        GridViewOperations GrvOperation = new GridViewOperations();
        GrvOperation.BindGridWithSorting(this.GvAdmission, ods, this.SortField, this.SortDirection);
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {

    }
}