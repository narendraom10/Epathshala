using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Report_StudentPackageReport : System.Web.UI.Page
{

    #region Declaration
    
    Student_DashBoard_BLogic obj_BAL_Student_Dashboard;
    StudentDash obj_Student_Dashboard;

    #endregion

    #region Page Events
    protected void Page_Load(object sender, EventArgs e)
    {
        //lblBMS.Text = "Board Medium Standard is:       " + AppSessions.BMS;
        //gvstudentpackagedetails1.HeaderRow.TableSection = TableRowSection.TableHeader;
        if (!IsPostBack)
            BindGridPackage(); 
    }

    #endregion

    #region Control Events

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        BindGridPackage();
    }

    private void BindGridPackage()
    {
        try
        {
            obj_BAL_Student_Dashboard = new Student_DashBoard_BLogic();
            obj_Student_Dashboard = new StudentDash();
            obj_Student_Dashboard.StudentID = AppSessions.StudentID;
            DataSet ds = new DataSet();
            ds = obj_BAL_Student_Dashboard.BAL_Student_PackageHistory(obj_Student_Dashboard, null, null);
            //ds = obj_BAL_Student_Dashboard.BAL_Student_ExpiredPackageHistory(obj_Student_Dashboard);
            if (ds.Tables[0].Rows.Count > 0 && ds != null)
            {
                gvstudentpackagedetails1.DataSource = ds.Tables[0];
                gvstudentpackagedetails1.DataBind();
            }
        }
        catch (Exception ex)
        {
        }
    }


    protected void btnsubmit_Click1(object sender, EventArgs e)
    {
        try
        {
            //GetStudentPackageDetails();
        }
        catch (Exception ex)
        {
        }

    }
    protected void btnreset_Click(object sender, EventArgs e)
    {
        obj_BAL_Student_Dashboard = new Student_DashBoard_BLogic();
        obj_Student_Dashboard = new StudentDash();
        obj_Student_Dashboard.StudentID = AppSessions.StudentID;
        DataSet ds = new DataSet();
        //ddlpackagetype.SelectedIndex = 0;
        //ddlsearchby.SelectedIndex = 0;
        //ddlsearchby.SelectedIndex = 0;
        //txtfromdate.Text = string.Empty;
        //txttodate.Text = string.Empty;
        ds = obj_BAL_Student_Dashboard.BAL_Student_PackageHistory(obj_Student_Dashboard, null, null);
        //ds = obj_BAL_Student_Dashboard.BAL_Student_PackageHistory(obj_Student_Dashboard, ddlsearchby.SelectedItem.ToString().Trim(), ddlpackagetype.SelectedItem.ToString().Trim());
        gvstudentpackagedetails1.DataSource = ds.Tables[0];
        gvstudentpackagedetails1.DataBind();
    }

    #endregion

    #region Methods

    //protected void GetStudentPackageDetails()
    //{
    //    try
    //    {
    //        obj_BAL_Student_Dashboard = new Student_DashBoard_BLogic();
    //        obj_Student_Dashboard = new StudentDash();
    //        obj_Student_Dashboard.StudentID = AppSessions.StudentID;
    //        DateTime FromDt = DateTime.Now;
    //        DateTime ToDt = DateTime.Now;
    //        DataSet ds = new DataSet();
    //        if (ddlpackagetype.SelectedIndex == 0 && txtfromdate.Text == string.Empty)
    //        {
    //            ds = obj_BAL_Student_Dashboard.BAL_Student_PackageHistory(obj_Student_Dashboard, null, null);
    //        }

    //        if (txtfromdate.Text != string.Empty && ddlpackagetype.SelectedIndex != 0)
    //        {
    //            string Fromdate = txtfromdate.Text;
    //            DateTime dateTime_frm;
    //            if (DateTime.TryParse(Fromdate, out dateTime_frm))
    //            {
    //                FromDt = dateTime_frm;
    //            }
    //            string Todate = txttodate.Text;
    //            DateTime dateTime_to;
    //            if (DateTime.TryParse(Todate, out dateTime_to))
    //            {
    //                ToDt = dateTime_to;
    //            }
    //            //ds = obj_BAL_Student_Dashboard.BAL_Student_PackageHistory(obj_Student_Dashboard, ddlsearchby.SelectedItem.ToString().Trim(), ddlpackagetype.SelectedItem.ToString().Trim(), Convert.ToDateTime(txtfromdate.Text), Convert.ToDateTime(txttodate.Text));
    //            ds = obj_BAL_Student_Dashboard.BAL_Student_PackageHistory(obj_Student_Dashboard, ddlsearchby.SelectedValue.ToString().Trim(), ddlpackagetype.SelectedItem.ToString().Trim(), Convert.ToDateTime(txtfromdate.Text), Convert.ToDateTime(txttodate.Text));
    //        }

    //        if (txtfromdate.Text != string.Empty && ddlpackagetype.SelectedIndex == 0)
    //        {
    //            string Fromdate = txtfromdate.Text;
    //            DateTime dateTime_frm;
    //            if (DateTime.TryParse(Fromdate, out dateTime_frm))
    //            {
    //                FromDt = dateTime_frm;
    //            }
    //            string Todate = txttodate.Text;
    //            DateTime dateTime_to;
    //            if (DateTime.TryParse(Todate, out dateTime_to))
    //            {
    //                ToDt = dateTime_to;
    //            }
    //            //ds = obj_BAL_Student_Dashboard.BAL_Student_PackageHistory(obj_Student_Dashboard, ddlsearchby.SelectedItem.ToString().Trim(), null, Convert.ToDateTime(txtfromdate.Text), Convert.ToDateTime(txttodate.Text));
    //            ds = obj_BAL_Student_Dashboard.BAL_Student_PackageHistory(obj_Student_Dashboard, ddlsearchby.SelectedValue.ToString().Trim(), null, Convert.ToDateTime(txtfromdate.Text), Convert.ToDateTime(txttodate.Text));
    //        }

    //        if (ddlpackagetype.SelectedIndex != 0 && txtfromdate.Text == string.Empty)
    //        {
    //            ds = obj_BAL_Student_Dashboard.BAL_Student_PackageHistory(obj_Student_Dashboard, null, ddlpackagetype.SelectedItem.ToString().Trim());
    //        }


    //        if (ddlstatus.SelectedIndex == 0)
    //        {
    //            gvstudentpackagedetails1.DataSource = ds.Tables[0];
    //            gvstudentpackagedetails1.DataBind();
    //        }
    //        else
    //        {
    //            DataView dv = new DataView(ds.Tables[0]);
    //            dv.RowFilter = "Status='" + ddlstatus.SelectedItem.ToString() + "'  ";
    //            gvstudentpackagedetails1.DataSource = dv;
    //            gvstudentpackagedetails1.DataBind();
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //    }
    //}

    #endregion


}