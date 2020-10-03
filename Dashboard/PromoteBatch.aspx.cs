using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Dashboard_PromoteBatch : System.Web.UI.Page
{
    School_BLogic SchoolBLogic = new School_BLogic();
    DropDownFill DdlFilling;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillSchoolDropdown(ddlschool);
            FillBMSDropdown(ddlBMS);
            FillCurrentAcademicYearDropdown();
            //dvstudentlist.Visible = false;

            //FillAcademicYearDropdown();

        }
    }

    #region "User Defined Functions"

    private void FillAcademicYearDropdown()
    {
        SchoolBLogic = new School_BLogic();
        DataSet ds = new DataSet();
        ds = SchoolBLogic.BAL_AllAcademicYear();
        if (ds != null)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlAcademicYear.DataSource = ds;
                ddlAcademicYear.DataTextField = "AcademicYear";
                ddlAcademicYear.DataBind();
                ddlAcademicYear.Items.Insert(Convert.ToInt32(EnumFile.AssignValue.Zero), "-- Select --");
                ddlAcademicYear.Items[0].Value = Convert.ToString((int)EnumFile.AssignValue.Zero);
            }
        }
    }

    private void FillSchoolDropdown(DropDownList ddlSchool)
    {
        SchoolBLogic = new School_BLogic();
        DataTable dt = new DataTable();
        dt = SchoolBLogic.BAL_SchoolAllNameWithID("Normal").Tables[0];
        if (dt != null)
        {
            if (dt.Rows.Count > 0)
            {
                DdlFilling = new DropDownFill();
                DdlFilling.BindDropDownByTable(ddlSchool, dt, "Name", "SchoolID");
                ddlSchool.Items.Insert(Convert.ToInt32(EnumFile.AssignValue.Zero), "-- Select --");
                ddlSchool.Items[0].Value = Convert.ToString((int)EnumFile.AssignValue.Zero);

                ddlschool.SelectedValue = AppSessions.SchoolID.ToString();
                ddlschool.Enabled = false;
            }
        }
    }



    private void FillBMSDropdown(DropDownList ddlBMS)
    {
        SchoolBLogic = new School_BLogic();
        DataTable dt = new DataTable();


        SYS_BMS_BLogic SYS_BMSBLogic = new SYS_BMS_BLogic();
        DataSet dsselectBMS = new DataSet();
        dsselectBMS = SYS_BMSBLogic.BAL_SYS_BMS_SelectAllBySchoolID(Convert.ToInt64(ddlschool.SelectedValue));
        dt = dsselectBMS.Tables[0];
        if (dt != null)
        {
            if (dt.Rows.Count > 0)
            {
                DdlFilling = new DropDownFill();
                DdlFilling.BindDropDownByTable(ddlBMS, dt, "BMS", "BMSID");
                //ddlBMS.Items.Insert(Convert.ToInt32(EnumFile.AssignValue.Zero), "-- Select --");
                //ddlBMS.Items[0].Value = Convert.ToString((int)EnumFile.AssignValue.Zero);
            }
        }
    }

    public void FillDivisionDropDown(DropDownList ddlDivision, int i)
    {
        SchoolBLogic = new School_BLogic();
        DataTable dt = new DataTable();


        SYS_BMS_BLogic SYS_BMSBLogic = new SYS_BMS_BLogic();
        DataSet dsselectBMS = new DataSet();
        if (i == 1)
        {
            dsselectBMS = SYS_BMSBLogic.BAL_SYS_Division_SelectAllBySchoolID(Convert.ToInt64(ddlschool.SelectedValue), Convert.ToInt64(ddlBMS.SelectedValue));
            if (dsselectBMS.Tables[0].Rows.Count > 0)
            {
                ddldiv.Enabled = true;
            }
            else
            {
                ddldiv.Enabled = false;
            }

        }
        else
        {

            dsselectBMS = SYS_BMSBLogic.BAL_SYS_Division_SelectAllBySchoolID(Convert.ToInt64(ddlschool.SelectedValue), Convert.ToInt64(ddlnextyearBMS.SelectedValue));
            if (dsselectBMS.Tables[0].Rows.Count > 0)
            {
                ddldivision.Enabled = true;
            }
            else
            {
                ddldivision.Enabled = false;
            }
        }

        dt = dsselectBMS.Tables[0];
        if (dt != null)
        {
            if (dt.Rows.Count > 0)
            {
                DdlFilling = new DropDownFill();
                DdlFilling.BindDropDownByTable(ddlDivision, dt, "Division", "DivisionID");
                ddlDivision.Items.Insert(Convert.ToInt32(EnumFile.AssignValue.Zero), "-- Select --");
                ddlDivision.Items[0].Value = Convert.ToString((int)EnumFile.AssignValue.Zero);


            }
        }

    }



    private void FillCurrentAcademicYearDropdown()
    {
        SchoolBLogic = new School_BLogic();
        DataSet ds = new DataSet();
        ds = SchoolBLogic.BAL_AllAcademicYear();
        if (ds != null)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlcurrentacedemicyear.DataSource = ds;

                ddlcurrentacedemicyear.DataTextField = "academicyear";
                ddlcurrentacedemicyear.DataBind();
                ddlcurrentacedemicyear.Items.Insert(Convert.ToInt32(EnumFile.AssignValue.Zero), "-- select --");
                ddlcurrentacedemicyear.Items[0].Value = Convert.ToString((int)EnumFile.AssignValue.Zero);
            }
        }
    }


    #endregion

    protected void ddlschool_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            FillBMSDropdown(ddlBMS);
        }
        catch (Exception ex)
        {
        }
    }
    protected void ddlBMS_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlBMS.SelectedIndex == 0)
        {
            ddldiv.Enabled = false;
        }
        else
        {

            FillDivisionDropDown(ddldiv, 1);
        }

    }

    DataSet dsStudentList = new DataSet();
    protected void btnok_Click(object sender, EventArgs e)
    {
        Student_BLogic OStudent_BLogic = new Student_BLogic();


        dsStudentList = OStudent_BLogic.BAL_Student_SelectBMSDIVWise(Convert.ToInt32(ddlschool.SelectedValue), Convert.ToInt32(ddlBMS.SelectedValue), Convert.ToInt32(ddldiv.SelectedValue), ddlcurrentacedemicyear.SelectedItem.ToString());
        try
        {
            if (dsStudentList != null)
            {
                if (dsStudentList.Tables[0].Rows.Count > 0)
                {


                    if (ddlschool.SelectedIndex > 0 && ddlBMS.SelectedIndex > 0 && ddldiv.SelectedIndex > 0)
                    {
                        gvstudentList.Visible = true;
                        gvstudentList.DataSource = dsStudentList.Tables[0];
                        gvstudentList.DataBind();
                        ViewState["StudentList"] = dsStudentList.Tables[0];
                        //divpromot.Visible = true;
                        btnpromote.Visible = true;
                        ddlBMS.Enabled = false;
                        ddldiv.Enabled = false;
                        ddlcurrentacedemicyear.Enabled = false;
                        FillBMSDropdown(ddlnextyearBMS);
                        FillAcademicYearDropdown();
                    }
                    else
                    {

                        WebMsg.Show("Please select BMS and Division and Current Acedemic Year......");
                    }
                }
                else
                {
                    divpromot.Visible = false;
                    DataTable dt = new DataTable();
                    gvstudentList.DataSource = dt;
                    gvstudentList.DataBind();
                }
            }
        }
        catch (Exception ex)
        {
        }
    }


    protected void btnreset_Click(object sender, EventArgs e)
    {
        divpromot.Visible = false;
        btnpromote.Visible = false;
        // dvstudentlist.Visible = false;
        ddlBMS.SelectedIndex = 0;
        if (ddldiv.Enabled == true)
            ddldiv.SelectedIndex = 0;
        ddlcurrentacedemicyear.SelectedIndex = 0;
        ddlBMS.Enabled = true;
        ddldiv.Enabled = false;
        ddlcurrentacedemicyear.Enabled = false;
        //ResetNextYearPanel();
        DataTable dt = new DataTable();
        gvstudentList.DataSource = dt;
        gvstudentList.DataBind();
        gvstudentList.Visible = false;
    }
    protected void ddlnextyearBMS_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblNoOfStudent.Text = "";
        if (ddlnextyearBMS.SelectedIndex == 0)
        {
            ddldivision.Enabled = false;
        }
        else
        {
            FillDivisionDropDown(ddldivision, 2);
        }

    }
    protected void btnpromot_Click(object sender, EventArgs e)
    {

        PromoteToNextYear();

        //Student_BLogic OStudent_BLogic = new Student_BLogic();
        //DataSet dsStudentList = new DataSet();
        //dsStudentList = OStudent_BLogic.BAL_Student_SelectBMSDIVWise(Convert.ToInt32(ddlschool.SelectedValue), Convert.ToInt32(ddlnextyearBMS.SelectedValue), Convert.ToInt32(ddldivision.SelectedValue), ddlAcademicYear.SelectedItem.ToString());
        //try
        //{
        //    if (dsStudentList != null)
        //    {
        //        if (dsStudentList.Tables[0].Rows.Count > 0)
        //        {
        //            if (ddlnextyearBMS.SelectedIndex > 0 && ddldivision.SelectedIndex > 0)
        //            {
        //                btnupdate.Visible = true;
        //                lblNoOfStudent.Text = "Total Student in " + ddlnextyearBMS.SelectedItem.ToString() + " is " + dsStudentList.Tables[0].Rows.Count.ToString();
        //                // dvstudentlist.Visible = true;
        //                GridView1.DataSource = dsStudentList.Tables[0];
        //                GridView1.DataBind();
        //                btnupdate.Visible = true;
        //                btnpromotetonext.Visible = true;

        //            }

        //        }
        //        else
        //        {
        //            GridView1.DataSource = null;
        //            GridView1.DataBind();
        //            btnupdate.Visible = false;
        //        }
        //    }
        //}
        //catch (Exception ex)
        //{
        //}

        //int studentcnt = 0;
        //try
        //{

        //    if (ddlnextyearBMS.SelectedIndex > 0 && ddldivision.SelectedIndex > 0 && ddlAcademicYear.SelectedIndex > 0)
        //    {


        //        Student_BLogic oStudent_Blogic = new Student_BLogic();

        //        DataSet ds = new DataSet();

        //        DataTable table = new DataTable();
        //        table = (DataTable)ViewState["StudentList"];

        //        foreach (GridViewRow gvrow in gvstudentList.Rows)
        //        {
        //            CheckBox chk = (CheckBox)gvrow.FindControl("chk");
        //            if (chk != null & chk.Checked)
        //            {
        //                studentcnt = studentcnt + 1;
        //                DataRow[] result = table.Select("Studentid=" + gvstudentList.DataKeys[gvrow.RowIndex].Value.ToString());

        //                long studentid = Convert.ToInt64(result[0].ItemArray[0].ToString());
        //                long schoolid = Convert.ToInt64(result[0].ItemArray[1].ToString());
        //                int Roleid = Convert.ToInt32(result[0].ItemArray[4].ToString());
        //                string GrNo = result[0].ItemArray[14].ToString();
        //                string previousacedemicyear = result[0].ItemArray[19].ToString();
        //                string currentacedemicyear = ddlAcademicYear.SelectedItem.ToString();

        //                int PreviousRollNo = 0;
        //                int CurrnetRollNo = 0;
        //                if (result[0].ItemArray[10].ToString() != string.Empty)
        //                {
        //                    PreviousRollNo = Convert.ToInt32(result[0].ItemArray[10].ToString());
        //                    // CurrnetRollNo = Convert.ToInt32(((TextBox)gvstudentList.Rows[gvrow.RowIndex].Cells[2].FindControl("txtrollno")).Text);
        //                    CurrnetRollNo = PreviousRollNo;
        //                }


        //                long PreviousBMSID = Convert.ToInt64(result[0].ItemArray[2].ToString());
        //                long CurrentBMSID = Convert.ToInt64(ddlnextyearBMS.SelectedValue.ToString());
        //                int PreviousDivID = Convert.ToInt32(result[0].ItemArray[3].ToString());
        //                int CurrentDivID = Convert.ToInt32(ddldivision.SelectedValue.ToString());
        //                long CreatedBy = Convert.ToInt64(AppSessions.EmpolyeeID);
        //                string status = "Promoted";


        //                oStudent_Blogic.BAL_Student_PromoteNextYear(studentid, schoolid, Roleid, GrNo, previousacedemicyear, currentacedemicyear, PreviousRollNo, CurrnetRollNo,
        //                    PreviousBMSID, CurrentBMSID, PreviousDivID, CurrentDivID, CreatedBy, status);

        //                btnupdate.Visible = true;
        //                //str += gvDetails.DataKeys[gvrow.RowIndex].Value.ToString() + ',';
        //                //strname += gvrow.Cells[2].Text + ',';


        //            }
        //        }

        //        FillGridDetails();
        //        FillPromotedStudentList();

        //        if (studentcnt <= 0)
        //        {
        //            WebMsg.Show("please select atleast one student");
        //        }
        //        else
        //        {
        //            WebMsg.Show("Student promted to " + ddlnextyearBMS.SelectedItem.ToString() + " Sucessfully");
        //            //ddlnextyearBMS.SelectedIndex = 0;
        //            //ddldivision.SelectedIndex = 0;
        //            //ddlAcademicYear.SelectedIndex = 0;
        //            //lblNoOfStudent.Text = "";
        //            //divpromot.Visible = false;
        //        }

        //    }



        //    else
        //    {
        //        WebMsg.Show("Please select Next Year BMS , Division and Acedemic year....");
        //    }








        //}
        //catch (Exception ex)
        //{
        //}

    }



    protected void PromoteToNextYear()
    {
        int studentcnt = 0;
        try
        {
            if (ddlnextyearBMS.SelectedIndex > 0 && ddldivision.SelectedIndex > 0)
            {
                Student_BLogic oStudent_Blogic = new Student_BLogic();
                DataSet ds = new DataSet();
                DataTable table = new DataTable();
                table = (DataTable)ViewState["StudentList"];
                foreach (GridViewRow gvrow in gvstudentList.Rows)
                {
                    CheckBox chk = (CheckBox)gvrow.FindControl("chk");
                    if (chk != null & chk.Checked)
                    {
                        studentcnt = studentcnt + 1;
                        DataRow[] result = table.Select("Studentid=" + gvstudentList.DataKeys[gvrow.RowIndex].Value.ToString());
                        long studentid = Convert.ToInt64(result[0].ItemArray[0].ToString());
                        long schoolid = Convert.ToInt64(result[0].ItemArray[1].ToString());
                        int Roleid = Convert.ToInt32(result[0].ItemArray[4].ToString());
                        string GrNo = result[0].ItemArray[14].ToString();
                        string previousacedemicyear = result[0].ItemArray[19].ToString();
                        //string currentacedemicyear = ddlAcademicYear.SelectedItem.ToString();
                        string currentacedemicyear = lblnextacedemicyear.Text.Trim();
                        int PreviousRollNo = 0;
                        int CurrnetRollNo = 0;
                        if (result[0].ItemArray[10].ToString() != string.Empty)
                        {
                            PreviousRollNo = Convert.ToInt32(result[0].ItemArray[10].ToString());
                            // CurrnetRollNo = Convert.ToInt32(((TextBox)gvstudentList.Rows[gvrow.RowIndex].Cells[2].FindControl("txtrollno")).Text);
                            CurrnetRollNo = PreviousRollNo;
                        }

                        long PreviousBMSID = Convert.ToInt64(result[0].ItemArray[2].ToString());
                        long CurrentBMSID = Convert.ToInt64(ddlnextyearBMS.SelectedValue.ToString());
                        int PreviousDivID = Convert.ToInt32(result[0].ItemArray[3].ToString());
                        int CurrentDivID = Convert.ToInt32(ddldivision.SelectedValue.ToString());
                        long CreatedBy = Convert.ToInt64(AppSessions.EmpolyeeID);
                        string status = "Promoted";

                        oStudent_Blogic.BAL_Student_PromoteNextYear(studentid, schoolid, Roleid, GrNo, previousacedemicyear, currentacedemicyear, PreviousRollNo, CurrnetRollNo,
                            PreviousBMSID, CurrentBMSID, PreviousDivID, CurrentDivID, CreatedBy, status);
                        btnupdate.Visible = true;
                    }
                }

                FillGridDetails();
                FillPromotedStudentList();
                if (studentcnt <= 0)
                {
                    WebMsg.Show("please select atleast one student");
                }
                else
                {
                    WebMsg.Show("Student promted to " + ddlnextyearBMS.SelectedItem.ToString() + " Sucessfully");
                    //ddlnextyearBMS.SelectedIndex = 0;
                    //ddldivision.SelectedIndex = 0;
                    //ddlAcademicYear.SelectedIndex = 0;
                    //lblNoOfStudent.Text = "";
                    //divpromot.Visible = false;
                }
            }
            else
            {
                WebMsg.Show("Please select Next Year BMS , Division and Acedemic year....");
            }
        }
        catch (Exception ex)
        {
        }
    }

    protected void FillGridDetails()
    {

        Student_BLogic OStudent_BLogic = new Student_BLogic();
        dsStudentList = OStudent_BLogic.BAL_Student_SelectBMSDIVWise(Convert.ToInt32(ddlschool.SelectedValue), Convert.ToInt32(ddlBMS.SelectedValue), Convert.ToInt32(ddldiv.SelectedValue), ddlcurrentacedemicyear.SelectedItem.ToString());
        try
        {
            if (dsStudentList != null)
            {
                gvstudentList.Visible = true;
                gvstudentList.DataSource = dsStudentList;
                gvstudentList.DataBind();

            }
        }
        catch (Exception ex)
        {
        }

    }
    protected void ddlAcademicYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        Student_BLogic OStudent_BLogic = new Student_BLogic();
        DataSet dsStudentList = new DataSet();
        dsStudentList = OStudent_BLogic.BAL_Student_SelectBMSDIVWise(Convert.ToInt32(ddlschool.SelectedValue), Convert.ToInt32(ddlnextyearBMS.SelectedValue), Convert.ToInt32(ddldivision.SelectedValue), ddlAcademicYear.SelectedItem.ToString());
        try
        {
            if (dsStudentList != null)
            {
                if (dsStudentList.Tables[0].Rows.Count > 0)
                {
                    if (ddlnextyearBMS.SelectedIndex > 0 && ddldivision.SelectedIndex > 0)
                    {
                        btnupdate.Visible = true;
                        lblNoOfStudent.Text = "Total Student in " + ddlnextyearBMS.SelectedItem.ToString() + " is " + dsStudentList.Tables[0].Rows.Count.ToString();
                        // dvstudentlist.Visible = true;
                        GridView1.DataSource = dsStudentList.Tables[0];
                        GridView1.DataBind();

                    }

                }
                else
                {
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                    btnupdate.Visible = false;
                }
            }
        }
        catch (Exception ex)
        {
        }
    }

    protected void FillStudentList()
    {

        Student_BLogic OStudent_BLogic = new Student_BLogic();
        DataSet dsStudentList = new DataSet();
        //dsStudentList = OStudent_BLogic.BAL_Student_SelectBMSDIVWise(Convert.ToInt32(ddlschool.SelectedValue), Convert.ToInt32(ddlnextyearBMS.SelectedValue), Convert.ToInt32(ddldivision.SelectedValue), ddlAcademicYear.SelectedItem.ToString());
        dsStudentList = OStudent_BLogic.BAL_Student_SelectBMSDIVWise(Convert.ToInt32(ddlschool.SelectedValue), Convert.ToInt32(ddlnextyearBMS.SelectedValue), Convert.ToInt32(ddldivision.SelectedValue), lblnextacedemicyear.Text.Trim());
        try
        {
            if (dsStudentList != null)
            {
                if (dsStudentList.Tables[0].Rows.Count > 0)
                {
                    if (ddlnextyearBMS.SelectedIndex > 0 && ddldivision.SelectedIndex > 0)
                    {
                        btnupdate.Visible = true;
                        lblNoOfStudent.Text = "Total Student in " + ddlnextyearBMS.SelectedItem.ToString() + " is " + dsStudentList.Tables[0].Rows.Count.ToString();
                        // dvstudentlist.Visible = true;
                        GridView1.DataSource = dsStudentList.Tables[0];
                        GridView1.DataBind();

                    }

                }
                else
                {
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                    btnupdate.Visible = false;
                }
            }
        }
        catch (Exception ex)
        {
        }

    }

    protected void FillPromotedStudentList()
    {
        Student_BLogic OStudent_BLogic = new Student_BLogic();
        DataSet dsStudentList = new DataSet();
        //dsStudentList = OStudent_BLogic.BAL_Student_SelectBMSDIVWise(Convert.ToInt32(ddlschool.SelectedValue), Convert.ToInt32(ddlnextyearBMS.SelectedValue), Convert.ToInt32(ddldivision.SelectedValue), ddlAcademicYear.SelectedItem.ToString());
        dsStudentList = OStudent_BLogic.BAL_Student_SelectBMSDIVWise(Convert.ToInt32(ddlschool.SelectedValue), Convert.ToInt32(ddlnextyearBMS.SelectedValue), Convert.ToInt32(ddldivision.SelectedValue), lblnextacedemicyear.Text.Trim());
        try
        {
            if (ddlschool.SelectedIndex > 0 && ddlnextyearBMS.SelectedIndex > 0 && ddldivision.SelectedIndex > 0)
            {
                lblNoOfStudent.Text = "Total Student in " + ddlnextyearBMS.SelectedItem.ToString() + " is " + dsStudentList.Tables[0].Rows.Count.ToString();
                // dvstudentlist.Visible = true;
                GridView1.DataSource = dsStudentList.Tables[0];
                GridView1.DataBind();


            }
            else
            {
            }
        }
        catch (Exception ex)
        {
        }

    }
    protected void ddldivision_SelectedIndexChanged(object sender, EventArgs e)
    {

        //Student_BLogic OStudent_BLogic = new Student_BLogic();
        //DataSet dsStudentList = new DataSet();

        //dsStudentList = OStudent_BLogic.BAL_Student_SelectBMSDIVWise(Convert.ToInt32(ddlschool.SelectedValue), Convert.ToInt32(ddlnextyearBMS.SelectedValue), Convert.ToInt32(ddldivision.SelectedValue),ddlAcademicYear.SelectedItem.ToString());
        //try
        //{
        //    if (ddlschool.SelectedIndex > 0 && ddlnextyearBMS.SelectedIndex > 0 && ddldivision.SelectedIndex > 0)
        //    {
        //        //gvstudent.DataSource = dsStudentList.Tables[0];
        //        //gvstudent.DataBind();
        //        lblNoOfStudent.Text = "Total Student in " + ddlnextyearBMS.SelectedItem.ToString() + " is " + dsStudentList.Tables[0].Rows.Count.ToString();




        //    }
        //    else
        //    {
        //        lblNoOfStudent.Text = "Total Student in " + ddlnextyearBMS.SelectedItem.ToString() + " is 0";

        //    }
        //}
        //catch (Exception ex)
        //{
        //}

        FillStudentList();

    }


    protected void ddldiv_SelectedIndexChanged1(object sender, EventArgs e)
    {
        ddlcurrentacedemicyear.Enabled = true;
    }
    protected void btnpromotreset_Click(object sender, EventArgs e)
    {
        ResetNextYearPanel();
    }

    protected void ResetNextYearPanel()
    {
        if (ddlnextyearBMS.Enabled == true)
            ddlnextyearBMS.SelectedIndex = 0;


        if (ddldivision.Enabled == true)
            ddldivision.SelectedIndex = 0;

        if (ddlAcademicYear.Enabled == true)
            ddlAcademicYear.SelectedIndex = 0;
        btnupdate.Visible = false;
        lblNoOfStudent.Text = "";
        GridView1.DataSource = null;
        GridView1.DataBind();

    }

    protected void btnupdate_Click(object sender, EventArgs e)
    {
        try
        {
            int CurrnetRollNo = 0;
            string GRNO = string.Empty;
            int studentid = 0;
            Student_BLogic oStudent_Blogic = new Student_BLogic();
            foreach (GridViewRow gvrow in GridView1.Rows)
            {
                CurrnetRollNo = Convert.ToInt32(((TextBox)GridView1.Rows[gvrow.RowIndex].Cells[2].FindControl("txtrollno")).Text);
                GRNO = ((TextBox)GridView1.Rows[gvrow.RowIndex].Cells[3].FindControl("txtgrno")).Text;
                studentid = Convert.ToInt32(GridView1.DataKeys[gvrow.RowIndex].Value);

                oStudent_Blogic.BAL_Student_Update_Student(studentid, CurrnetRollNo, GRNO);

            }

            WebMsg.Show("Student details updated sucessfully....");

            FillPromotedStudentList();

        }
        catch (Exception ex)
        {
        }

    }
    protected void btnpromote_Click(object sender, EventArgs e)
    {
        divpromot.Visible = true;
        int studentcnt = 0;


        foreach (GridViewRow gvrow in gvstudentList.Rows)
        {
            CheckBox chk = (CheckBox)gvrow.FindControl("chk");
            if (chk != null & chk.Checked)
            {
                studentcnt = studentcnt + 1;
                divpromot.Visible = true;

                DataSet dsSettings = new DataSet();
                Teacher_Dashboard_BLogic obj_BAL_Teacher_Dashboard = new Teacher_Dashboard_BLogic();
                dsSettings = obj_BAL_Teacher_Dashboard.BAL_Select_CoveredUncoverChapterTopic_Settings("CurrentAcademicYear");
                string CurrentAcademicYear = dsSettings.Tables[0].Rows[0]["value"].ToString().Trim();
                lblnextacedemicyear.Text = CurrentAcademicYear;
            }
        }

        if (studentcnt <= 0)
        {
            WebMsg.Show("please select atleast one student");
            divpromot.Visible = false;
        }
    }
    protected void btnpromotetonext_Click(object sender, EventArgs e)
    {
        PromoteToNextYear();
    }
}