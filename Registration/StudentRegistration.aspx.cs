using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Udev.UserMasterPage.Classes;
using System.Globalization;

public partial class SchoolAdmin_StudentRegistration : System.Web.UI.Page
{

    Student_BLogic BAL_Student;
    Student Student;
    CheckBoxFill Cfill;
    SYS_BMS_BLogic BSysBMS = new SYS_BMS_BLogic();
    SYS_BMS PSysBMS = new SYS_BMS();

    protected override void InitializeCulture()
    {
        string culture = Convert.ToString(Session[Global.SESSION_KEY_CULTURE]);
        // 'set culture to current thread 
        System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture);
        System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);
        //call base class 
        base.InitializeCulture();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ViewState["SchoolID"] = AppSessions.SchoolID;
            SchoolAndSchoolID();
            GetBMS();
            GetDivisions();
            bindgrvStudentdetail();
        }
    }

    protected void SchoolAndSchoolID()
    {
        ltrlSchoolIDSearch.Text = AppSessions.SchoolID.ToString();
        ltrlSchoolID.Text = AppSessions.SchoolID.ToString();
        txtSchool.Text = AppSessions.SchoolName;
        txtSchoolSearch.Text = AppSessions.SchoolName;
    }

    protected void GetBMS()
    {
        DropDownFill DdlFilling = new DropDownFill();
        DataSet dsBMS = new DataSet();
        dsBMS = BSysBMS.BAL_SYS_BMS_SelectAllBySchoolID(Convert.ToInt64(ViewState["SchoolID"]));
        if (dsBMS.Tables[0].Rows.Count > 0)
        {
            DdlFilling.BindDropDownByTable(ddlBMSAdd, dsBMS.Tables[0], "BMS", "BMSID");
            ddlBMSAdd.Items.Insert(Convert.ToInt32(EnumFile.AssignValue.Zero), "-- Select --");
            ddlBMSAdd.Items[0].Value = Convert.ToString((int)EnumFile.AssignValue.Zero);
            ddlBMSAdd.Enabled = true;

            DdlFilling.BindDropDownByTable(ddlBMSEdit, dsBMS.Tables[0], "BMS", "BMSID");
            ddlBMSEdit.Items.Insert(Convert.ToInt32(EnumFile.AssignValue.Zero), "-- Select --");
            ddlBMSEdit.Items[0].Value = Convert.ToString((int)EnumFile.AssignValue.Zero);
            ddlBMSEdit.Enabled = true;

            DdlFilling.BindDropDownByTable(ddlBMSSearch, dsBMS.Tables[0], "BMS", "BMSID");
            ddlBMSSearch.Items.Insert(Convert.ToInt32(EnumFile.AssignValue.Zero), "-- Select --");
            ddlBMSSearch.Items[0].Value = Convert.ToString((int)EnumFile.AssignValue.Zero);
            ddlBMSSearch.Enabled = true;
        }
    }

    protected void GetDivisions()
    {
        Cfill = new CheckBoxFill();
        this.Cfill.FillDivisionBySchoolBMSID(this.ddlDivisionAdd, int.Parse(ViewState["SchoolID"].ToString()));
        ddlDivisionAdd.Items.Insert(Convert.ToInt32(EnumFile.AssignValue.Zero), "-- Select --");
        ddlDivisionAdd.Items[0].Value = Convert.ToString((int)EnumFile.AssignValue.Zero);

        this.Cfill.FillDivisionBySchoolBMSID(this.ddlDivisionEdit, int.Parse(ViewState["SchoolID"].ToString()));
        ddlDivisionEdit.Items.Insert(Convert.ToInt32(EnumFile.AssignValue.Zero), "-- Select --");
        ddlDivisionEdit.Items[0].Value = Convert.ToString((int)EnumFile.AssignValue.Zero);

        this.Cfill.FillDivisionBySchoolBMSID(this.ddlDivisionSearch, int.Parse(ViewState["SchoolID"].ToString()));
        ddlDivisionSearch.Items.Insert(Convert.ToInt32(EnumFile.AssignValue.Zero), "-- Select --");
        ddlDivisionSearch.Items[0].Value = Convert.ToString((int)EnumFile.AssignValue.Zero);
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            Student = new Student();
            BAL_Student = new Student_BLogic();
            Student.schoolid = int.Parse(ltrlSchoolID.Text);
            Student.bmsid = int.Parse(ddlBMSAdd.SelectedValue);
            Student.divisionid = int.Parse(ddlDivisionAdd.SelectedValue);
            //Student.studentcode = txtStudentCode.Text;
            //Student.loginid = txtLoginID.Text;
            //Student.password = txtPassword.Text;
            Student.firstname = txtFirstName.Text;
            Student.middlename = txtMiddleName.Text;
            Student.lastname = txtLastName.Text;
            Student.rollno = Convert.ToInt16(txtRollNo.Text);
            //Student.contactno = Convert.ToInt64(txtContactNo.Text);
            //Student.mobileno = Convert.ToInt64(txtMobileNo.Text);
            //Student.emailid = txtEmailID.Text;
            //Student.grno = txtGRNo.Text;
            //Student.dateofbirth = Convert.ToDateTime(txtDateOfBirth.Text);
            if (rdbGenderList.SelectedValue == "0")
            {
                Student.gender = 'M';
            }
            else if (rdbGenderList.SelectedValue == "1")
            {
                Student.gender = 'F';
            }

            //Student.bloodgroup = txtBloodGroup.Text;
            Student.createdby = AppSessions.EmpolyeeID;
            BAL_Student.BAL_Student_Insert(Student, "Insert");
            RefreshPageControls();
            pnlSearch.CssClass = "Visible";
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        { }
    }
    private void AllPanelInvisible()
    {
        pnlAdd.CssClass = "InVisible";
        pnlEdit.CssClass = "InVisible";
        pnlSearch.CssClass = "InVisible";
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ClearControls();
        AllPanelInvisible();
        pnlAdd.CssClass = "Visible";
    }
    private void ClearControls()
    {
        //txtStudentCode.Text = "";
        ddlBMSAdd.SelectedValue = "0";
        ddlDivisionAdd.SelectedValue = "0";
        //txtLoginID.Text = "";
        //txtPassword.Text = "";
        txtFirstName.Text = "";
        txtMiddleName.Text = "";
        txtLastName.Text = "";
        txtRollNo.Text = "";
        //txtContactNo.Text = "";
        //txtMobileNo.Text = "";
        //txtEmailID.Text = "";
        //txtGRNo.Text = "";
        //txtDateOfBirth.Text = "";
        //txtBloodGroup.Text = "";
        rdbGenderList.ClearSelection();
    }
    private void ClearControlsEdit()
    {
        AllPanelInvisible();
        pnlSearch.CssClass = "Visible";
        ddlBMSEdit.SelectedValue = "0";
        ddlDivisionEdit.SelectedValue = "0";
        //txtStudentCodeEdit.Text = "";
        txtLoginIDEdit.Text = "";
        txtPasswordEdit.Text = "";
        txtFirstNameEdit.Text = "";
        txtMiddleNameEdit.Text = "";
        txtLastNameEdit.Text = "";
        txtRollNoEdit.Text = "";
        //txtContactNoEdit.Text = "";
        //txtMobileNoEdit.Text = "";
        //txtEmailIDEdit.Text = "";
        //txtGRNoEdit.Text = "";
        //txtDateOfBirthEdit.Text = "";
        //txtBloodGroupEdit.Text = "";
        //chkIsActiveEdit.Checked = false;
        rdbGenderEditList.ClearSelection();
    }
    protected void grvStudentdetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvStudentdetail.PageIndex = e.NewPageIndex;
        bindgrvStudentdetail();
    }

    private void bindgrvStudentdetail()
    {
        Student = new Student();
        BAL_Student = new Student_BLogic();
        DataSet dsSelect = new DataSet();
        dsSelect = BAL_Student.BAL_Student_Select(Student, "SelectAll");
        if (dsSelect.Tables.Count > 0)
        {
            string Condition = string.Empty;
            if (ltrlSchoolIDSearch.Text != string.Empty)
            {
                Condition = "SchoolID=" + ltrlSchoolIDSearch.Text;
            }

            if (ddlBMSSearch.SelectedValue != "0")
            {
                if (Condition != string.Empty)
                {
                    Condition = Condition + " And ";
                    Condition = Condition + "BMSID=" + ddlBMSSearch.SelectedValue;
                }
                else
                {
                    Condition = "BMSID=" + ddlBMSSearch.SelectedValue;
                }
            }

            if (ddlDivisionSearch.SelectedValue != "0")
            {
                if (Condition != string.Empty)
                {
                    Condition = Condition + " And ";
                    Condition = Condition + "DivisionID=" + ddlDivisionSearch.SelectedValue;
                }
                else
                {
                    Condition = "DivisionID=" + ddlDivisionSearch.SelectedValue;
                }
            }


            if (txtFirstNameSearch.Text != string.Empty)
            {
                if (Condition != string.Empty)
                {
                    Condition = Condition + " And ";
                    Condition = Condition + "FirstName=" + txtFirstNameSearch.Text;
                }
                else
                {
                    Condition = "FirstName=" + txtFirstNameSearch.Text;
                }
            }

            if (txtRollNoSearch.Text != string.Empty)
            {
                if (Condition != string.Empty)
                {
                    Condition = Condition + " And ";
                    Condition = Condition + "RollNo=" + txtRollNoSearch.Text;
                }
                else
                {
                    Condition = "RollNo=" + txtRollNoSearch.Text;
                }
            }

            //if (txtDateOfBirthSearch.Text != string.Empty)
            //{
            //    if (Condition != string.Empty)
            //    {
            //        Condition = Condition + " And ";
            //        Condition = Condition + "DateOfBirth=" + txtDateOfBirthSearch.Text;
            //    }
            //    else
            //    {
            //        Condition = "DateOfBirth=" + txtDateOfBirthSearch.Text;
            //    }
            //}

            if (rdbListGenderSearch.SelectedValue == "0")
            {
                if (Condition != string.Empty)
                {
                    Condition = Condition + " And ";
                    Condition = Condition + "Gender='" + "M'";
                }
                else
                {
                    Condition = "Gender='" + "M'";
                }
            }
            else if (rdbListGenderSearch.SelectedValue == "1")
            {
                if (Condition != string.Empty)
                {
                    Condition = Condition + " And ";
                    Condition = Condition + "Gender='" + "F'";
                }
                else
                {
                    Condition = "Gender='" + "F'";
                }
            }


            //if (rlstAddActive.SelectedValue == "1")
            //{
            //    if (Condition != string.Empty)
            //    {
            //        Condition = Condition + " And ";
            //        Condition = Condition + "IsActive=" + true;
            //    }
            //    else
            //    {
            //        Condition = "IsActive=" + true;
            //    }
            //}
            //else if (rlstAddActive.SelectedValue == "0")
            //{
            //    if (Condition != string.Empty)
            //    {
            //        Condition = Condition + " And ";
            //        Condition = Condition + "IsActive=" + false;
            //    }
            //    else
            //    {
            //        Condition = "IsActive=" + false;
            //    }
            //}

            DataView dv = new DataView(dsSelect.Tables[0]);
            dv.RowFilter = Condition;

            DataSet FilteredData = new DataSet();
            FilteredData.Tables.Add(dv.ToTable());

            GridViewOperations GrvOperation = new GridViewOperations();
            GrvOperation.BindGridWithSorting(grvStudentdetail, FilteredData, this.SortField, this.SortDirection);
        }
        else
        {
            grvStudentdetail.DataSource = null;
            grvStudentdetail.DataBind();
        }
    }
    protected void grvStudentdetail_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (e.SortExpression.Trim() == this.SortField)
            this.SortDirection = (this.SortDirection == "descending" ? "ascending" : "descending");
        else
            this.SortDirection = "ascending";
        this.SortField = e.SortExpression;
        GridViewOperations GrvOperation = new GridViewOperations();
        GrvOperation.GrvSortingSetImage(e, grvStudentdetail, this.SortDirection);
    }
    protected void grvStudentdetail_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Pager)
        {
            GridViewOperations GrvOperation = new GridViewOperations();
            GrvOperation.SetPagerButtonStates(grvStudentdetail, e.Row, this.Page);
        }
    }
    protected void ddlPageSelector_SelectedIndexChanged(object sender, EventArgs e)
    {
        grvStudentdetail.PageIndex = ((DropDownList)sender).SelectedIndex;
        bindgrvStudentdetail();
    }
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
    protected void ibtnRefresh_Click(object sender, ImageClickEventArgs e)
    {
        RefreshPageControls();
    }
    private void RefreshPageControls()
    {

        txtFirstNameSearch.Text = "";
        txtRollNoSearch.Text = "";
        //txtDateOfBirthSearch.Text = "";
        ddlBMSSearch.SelectedValue = "0";
        ddlDivisionSearch.SelectedValue = "0";
        //rlstAddActive.ClearSelection();
        rdbGenderList.ClearSelection();
        ClearControls();
        ClearControlsEdit();
        pnlSearch.CssClass = "Visible";
        pnlAdd.CssClass = "InVisible";
        pnlEdit.CssClass = "InVisible";
        bindgrvStudentdetail();
    }
    protected void ibtnEdit_Click(object sender, ImageClickEventArgs e)
    {
        if (pnlEdit.CssClass == "Visible")
        {
            AllPanelInvisible();
            pnlSearch.CssClass = "Visible";
            ClearControlsEdit();
        }
        else
        {
            int CountChecked = 0;
            int GRrowIndex = 0;
            foreach (GridViewRow gr in grvStudentdetail.Rows)
            {
                CheckBox chk = new CheckBox();
                chk = (CheckBox)gr.FindControl("chkSelect");
                if (chk.Checked == true)
                {
                    CountChecked = CountChecked + 1;
                    GRrowIndex = gr.RowIndex;
                }
            }
            if (CountChecked == 0 || CountChecked > 1)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Message", "<script> alert('Please select one record to update.')</script>", false);
            }
            else
            {
                AllPanelInvisible();
                pnlEdit.CssClass = "Visible";
                int index = GRrowIndex;

                ddlBMSEdit.SelectedValue = grvStudentdetail.DataKeys[index]["BMSID"].ToString();
                ddlDivisionEdit.SelectedValue = grvStudentdetail.DataKeys[index]["DivisionID"].ToString();
                txtSchoolEdit.Text = AppSessions.SchoolName;
                ltrlSchoolIDEdit.Text = AppSessions.SchoolID.ToString();
                ViewState["studentid"] = Convert.ToInt32(grvStudentdetail.DataKeys[index]["StudentID"]);
                //txtStudentCodeEdit.Text = Convert.ToString(grvStudentdetail.DataKeys[index]["StudentCode"]);
                txtLoginIDEdit.Text = Convert.ToString(grvStudentdetail.DataKeys[index]["LoginID"]);
                txtPasswordEdit.Text = Convert.ToString(grvStudentdetail.DataKeys[index]["Password"]);
                txtFirstNameEdit.Text = Convert.ToString(grvStudentdetail.DataKeys[index]["FirstName"]);
                txtMiddleNameEdit.Text = Convert.ToString(grvStudentdetail.DataKeys[index]["MiddleName"]);
                txtLastNameEdit.Text = Convert.ToString(grvStudentdetail.DataKeys[index]["LastName"]);
                txtRollNoEdit.Text = Convert.ToString(grvStudentdetail.DataKeys[index]["RollNo"]);
                //txtContactNoEdit.Text = Convert.ToString(grvStudentdetail.DataKeys[index]["ContactNo"]);
                //txtMobileNoEdit.Text = Convert.ToString(grvStudentdetail.DataKeys[index]["MobileNo"]);
                //txtEmailIDEdit.Text = Convert.ToString(grvStudentdetail.DataKeys[index]["EmailID"]);
                //txtGRNoEdit.Text = Convert.ToString(grvStudentdetail.DataKeys[index]["GRNo"]);
                string Gender = grvStudentdetail.DataKeys[index]["Gender"].ToString();

                if (Gender == "M")
                {
                    rdbGenderEditList.SelectedValue = "0";
                }
                else
                {
                    rdbGenderEditList.SelectedValue = "1";
                }

                //txtDateOfBirthEdit.Text = Convert.ToDateTime(grvStudentdetail.DataKeys[index]["DateOfBirth"]).ToString("dd-MMM-yyyy");
                //txtBloodGroupEdit.Text = Convert.ToString(grvStudentdetail.DataKeys[index]["BloodGroup"]);
                //chkIsActiveEdit.Checked = Convert.ToBoolean(grvStudentdetail.DataKeys[index]["IsActive"]);
            }
        }
    }
    protected void ibtnDelete_Click(object sender, ImageClickEventArgs e)
    {
        int CountChecked = 0;
        string StudentIDStr = "";
        foreach (GridViewRow gr in grvStudentdetail.Rows)
        {
            CheckBox chk = new CheckBox();
            chk = (CheckBox)gr.FindControl("chkSelect");
            if (chk.Checked == true)
            {
                if (CountChecked == 0)
                {
                    StudentIDStr = grvStudentdetail.DataKeys[gr.RowIndex]["StudentID"].ToString();
                }
                else
                {
                    StudentIDStr = StudentIDStr + "," + grvStudentdetail.DataKeys[gr.RowIndex]["StudentID"].ToString();
                }
                CountChecked = CountChecked + 1;
            }
        }
        if (CountChecked == 0)
        {
            WebMsg.Show("Please select one record to delete.");
        }
        else
        {
            Student = new Student();
            BAL_Student = new Student_BLogic();
            Student.studentidStr = StudentIDStr;
            BAL_Student.BAL_Student_Delete(Student, "Delete");
            ClearControls();
            bindgrvStudentdetail();
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        bindgrvStudentdetail();
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Student = new Student();
        BAL_Student = new Student_BLogic();
        Student.studentid = Convert.ToInt32(ViewState["studentid"].ToString());
        Student.schoolid = int.Parse(ltrlSchoolIDEdit.Text);
        Student.bmsid = int.Parse(ddlBMSEdit.SelectedValue);
        Student.divisionid = int.Parse(ddlDivisionEdit.SelectedValue);
        //Student.studentcode = txtStudentCodeEdit.Text;
        Student.loginid = txtLoginIDEdit.Text;
        Student.password = txtPasswordEdit.Text;
        Student.firstname = txtFirstNameEdit.Text;
        Student.middlename = txtMiddleNameEdit.Text;
        Student.lastname = txtLastNameEdit.Text;
        Student.rollno = Convert.ToInt16(txtRollNoEdit.Text);
        //Student.contactno = Convert.ToInt64(txtContactNoEdit.Text);
        //Student.mobileno = Convert.ToInt64(txtMobileNoEdit.Text);
        //Student.emailid = txtEmailIDEdit.Text;
        //Student.grno = txtGRNoEdit.Text;
        //Student.dateofbirth = Convert.ToDateTime(txtDateOfBirthEdit.Text);
        if (rdbGenderEditList.SelectedValue == "0")
        {
            Student.gender = 'M';
        }
        else
        {
            Student.gender = 'F';
        }
        //Student.bloodgroup = txtBloodGroupEdit.Text;
        //if (chkIsActiveEdit.Checked == true)
        //{
        //    Student.isactive = true;
        //}
        //else
        //{
        //    Student.isactive = false;
        //}


        Student.modifiedby = AppSessions.EmpolyeeID;
        BAL_Student.BAL_Student_Update(Student, "Update");
        RefreshPageControls();
    }
    protected void btnCancelEdit_Click(object sender, EventArgs e)
    {
        ClearControlsEdit();
    }
    protected void btnCancel0_Click(object sender, EventArgs e)
    {
        RefreshPageControls();
    }
    protected void ibtnAdd_Click(object sender, ImageClickEventArgs e)
    {
        AllPanelInvisible();
        ClearControls();
        pnlAdd.CssClass = "Visible";
    }
}
