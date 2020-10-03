using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Student_Report_StudentDetail : System.Web.UI.UserControl
{


    //public void Student_Report_StudentDetail(int studentID) {
    //    if (studentID > 0)
    //    {
    //        BindStudentDetails(studentID.ToString());
    //    }
    //}

    //public int StudentID
    //{
    //    get
    //    {
    //        return int.Parse(ViewState["StudentID"].ToString());
    //    }
    //    set
    //    {
    //        ViewState["StudentID"] = value;
    //    }
    //}

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["StudentID"] != null)
            {
                BindStudentDetails(Session["StudentID"].ToString());
            }
        }
    }

    public void BindStudentDetails(string StudentID)
    {
        try
        {
            StudentGenderwiseReport_BLogic objStudentReport = new StudentGenderwiseReport_BLogic();
            DataTable dtResult = new DataTable();

            dtResult = objStudentReport.GetStudentDetailsByStudentIDAcademicYear(Convert.ToInt32(StudentID), Session["ReportYear"].ToString());

            if (dtResult.Rows.Count > 0)
            {
                lblFirstNameValue.Text = dtResult.Rows[0]["FirstName"].ToString();
                lblMiddleNameValue.Text = dtResult.Rows[0]["MiddleName"].ToString();
                lblLastNameValue.Text = dtResult.Rows[0]["LastName"].ToString();
                lblGenderValue.Text = dtResult.Rows[0]["Gender"].ToString();
                lblDoBValue.Text = Convert.ToDateTime(dtResult.Rows[0]["DateOfBirth"]).ToString("dd-MMM-yyyy");
                lblAddressValue.Text = dtResult.Rows[0]["Address"].ToString();
                lblContactNoValue.Text = dtResult.Rows[0]["ContactNo"].ToString();
                lblEmailIDValue.Text = dtResult.Rows[0]["EmailID"].ToString();
                lblBloodGroupValue.Text = dtResult.Rows[0]["BloodGroup"].ToString();
                lblBMSValue1.Text = dtResult.Rows[0]["BMS"].ToString();
                lblSchoolValue1.Text = dtResult.Rows[0]["School"].ToString();
                lblGrNoValue.Text = dtResult.Rows[0]["GRNo"].ToString();
                lblRollNoValue.Text = dtResult.Rows[0]["RollNo"].ToString();
                lblCurrentYearValue.Text = dtResult.Rows[0]["CurrentAcademicYear"].ToString();
                lblDivValue.Text = dtResult.Rows[0]["Division"].ToString();
            }
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

  

    //public void BindStudentDetails(DataRow dr)
    //{
    //    try
    //    {
    //        if (dr != null)
    //        {
    //            lblFirstNameValue.Text = dr["FirstName"].ToString();
    //            lblMiddleNameValue.Text = dr["MiddleName"].ToString();
    //            lblLastNameValue.Text = dr["LastName"].ToString();
    //            lblGenderValue.Text = dr["Gender"].ToString();
    //            lblDoBValue.Text = Convert.ToDateTime(dr["DateOfBirth"]).ToString("dd-MMM-yyyy");
    //            lblAddressValue.Text = dr["Address"].ToString();
    //            lblContactNoValue.Text = dr["ContactNo"].ToString();
    //            lblEmailIDValue.Text = dr["EmailID"].ToString();
    //            lblBloodGroupValue.Text = dr["BloodGroup"].ToString();
    //            lblBMSValue1.Text = dr["BMS"].ToString();
    //            lblSchoolValue1.Text = dr["School"].ToString();
    //            lblGrNoValue.Text = dr["GRNo"].ToString();
    //            lblRollNoValue.Text = dr["RollNo"].ToString();
    //            lblCurrentYearValue.Text = dr["CurrentAcademicYear"].ToString();
    //            lblDivValue.Text = dr["Division"].ToString();
    //        }
    //    }
    //    catch (Exception ex)
    //    {

    //        throw ex;
    //    }
    //}

}