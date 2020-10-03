using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;

public partial class UserManagement_UpdateProfile : System.Web.UI.Page
{
    #region "Declaration"
    Employee_BLogic BAL_Employee = new Employee_BLogic();
    Employee Employee = new Employee();
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Page.Title = "Update Pofile";

            string IFormat = "dd-MMM-yyyy";

            if (Session["RoleID"].ToString() == Convert.ToString((int)EnumFile.Role.E_Admin))
                lblRole.Text = "E-Admin";
            else if (Session["RoleID"].ToString() == Convert.ToString((int)EnumFile.Role.S_Admin))
                lblRole.Text = "S-Admin";
            else if (Session["RoleID"].ToString() == Convert.ToString((int)EnumFile.Role.Teacher))
                lblRole.Text = "Teacher";

            if (Request.QueryString["Employeeid"] != "0" & Request.QueryString["Employeeid"] != null)
            {
                this.ViewState["Employeeid"] = AppSessions.EmpolyeeID;

                ArrayList AlistEmailID = new ArrayList();
                DataSet dsEmail = new DataSet();
                BAL_Employee = new Employee_BLogic();
                try
                {
                    dsEmail = BAL_Employee.SelectEmployeeDetailByEmployeeID(Convert.ToInt64(this.ViewState["Employeeid"]));
                    if (dsEmail != null & dsEmail.Tables.Count > 0)
                    {
                        if (dsEmail.Tables[0].Rows.Count > 0)
                        {
                            //EmployeeID, Code, RoleID, SchoolID, FirstName, MiddleName, LastName, Gender, DateOfBirth, BloodGroup, Address, EmailID, ContactNo, Qualification, 
                            // Designation, SecurityQuestion, SecurityAnswer, LoginID, Password, Image, LastLoginDate, AttemptCount, IsActive, CreatedOn, CreatedBy, ModifiedOn, 
                            // ModifiedBy, AllowMultipleSession
                            txtAddFirstName.Text = Convert.ToString(dsEmail.Tables[0].Rows[0]["FirstName"]);
                            txtAddMiddleName.Text = Convert.ToString(dsEmail.Tables[0].Rows[0]["MiddleName"]);
                            txtAddLastName.Text = Convert.ToString(dsEmail.Tables[0].Rows[0]["LastName"]);
                            rlstAddGender.SelectedValue = Convert.ToString(dsEmail.Tables[0].Rows[0]["Gender"]);
                            DateTime dt;
                            if (DateTime.TryParse(Convert.ToString(dsEmail.Tables[0].Rows[0]["DateOfBirth"]), out  dt))
                                txtAddDOB.Text = dt.ToString(IFormat);
                            txtAddBloodGroup.Text = Convert.ToString(dsEmail.Tables[0].Rows[0]["BloodGroup"]);
                            txtAddPermanentAddress.Text = Convert.ToString(dsEmail.Tables[0].Rows[0]["Address"]);
                            txtAddEmail.Text = Convert.ToString(dsEmail.Tables[0].Rows[0]["EmailID"]);
                            txtAddContactNumber.Text = Convert.ToString(dsEmail.Tables[0].Rows[0]["ContactNo"]);
                            txtAddQualification.Text = Convert.ToString(dsEmail.Tables[0].Rows[0]["Qualification"]);
                            txtAddDesignation.Text = Convert.ToString(dsEmail.Tables[0].Rows[0]["Designation"]);
                            tLoginId.Text = Convert.ToString(dsEmail.Tables[0].Rows[0]["LoginID"]);
                            hdnLoginid.Value = Convert.ToString(dsEmail.Tables[0].Rows[0]["LoginID"]);
                            lblAddTitle.Text = "Update Profile: " + txtAddFirstName.Text;
                        }
                    }

                }
                catch (Exception ex)
                {
                    WebMsg.Show(ex.Message);
                }
            }
        }

    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            string IFormat = "dd-MMM-yyyy";
            this.Employee.employeeid = Convert.ToInt32(this.ViewState["Employeeid"]);
            this.Employee.roleid = Convert.ToInt32(Session["RoleID"]);
            this.Employee.firstname = txtAddFirstName.Text;
            this.Employee.middlename = txtAddMiddleName.Text;
            this.Employee.lastname = txtAddLastName.Text;
            if (rlstAddGender.SelectedIndex == (int)EnumFile.AssignValue.Zero)
            {
                this.Employee.gender = 'M';
            }
            else if (rlstAddGender.SelectedIndex == (int)EnumFile.AssignValue.One)
            {
                this.Employee.gender = 'F';
            }

            this.Employee.dateofbirth = Convert.ToDateTime(DateTime.Parse(txtAddDOB.Text).ToString(IFormat));
            this.Employee.bloodgroup = txtAddBloodGroup.Text;
            this.Employee.address = txtAddPermanentAddress.Text;
            this.Employee.emailid = txtAddEmail.Text;
            this.Employee.MobileNumber = txtAddContactNumber.Text;
            this.Employee.qualification = txtAddQualification.Text;
            this.Employee.designation = txtAddDesignation.Text;
            this.Employee.loginid = tLoginId.Text;

            byte[] mybytes = (byte[])ViewState["url"];
            this.Employee.image1 = mybytes;

            this.Employee.createdby = AppSessions.EmpolyeeID;
            this.Employee.modifiedby = AppSessions.EmpolyeeID;

            this.Employee.modifiedon = Convert.ToDateTime(DateTime.Parse(DateTime.Now.ToString()).ToString(IFormat));

            bool Status = this.BAL_Employee.BAL_Employee_Update_FromEpathAdmin(this.Employee);

            if (Status)
            {
                ResetControl();
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Update profile sucessfully');", true);
            }
            else
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Update profile Failed');", true);

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
        }
    }

    private void ResetControl()
    {
        txtAddFirstName.Text = string.Empty;
        txtAddMiddleName.Text = string.Empty;
        txtAddLastName.Text = string.Empty;
        txtAddDOB.Text = string.Empty;
        txtAddBloodGroup.Text = string.Empty;
        txtAddPermanentAddress.Text = string.Empty;
        txtAddEmail.Text = string.Empty;
        txtAddContactNumber.Text = string.Empty;
        txtAddQualification.Text = string.Empty;
        txtAddDesignation.Text = string.Empty;
        tLoginId.Text = string.Empty;
    }
}