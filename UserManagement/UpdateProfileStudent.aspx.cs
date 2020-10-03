using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data;

public partial class UserManagement_UpdateProfileStudent : System.Web.UI.Page
{
    #region "Declaration"
    Student_BLogic BAL_Student;
    Student oStudent;
    #endregion


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Page.Title = "Update Pofile";

            string IFormat = "dd-MMM-yyyy";

            //lblRole.Text = "Student";

            DataSet dsStudent = new DataSet();
            BAL_Student = new Student_BLogic();
            try
            {
                dsStudent = BAL_Student.BAL_Student_GetDetailByStudentID(AppSessions.StudentID);
                if (dsStudent != null & dsStudent.Tables.Count > 0)
                {
                    if (dsStudent.Tables[0].Rows.Count > 0)
                    {
                        //FirstName, MiddleName, LastName, Gender, DateOfBirth, BloodGroup, Address, EmailID, ContactNo, MobileNumber
                        txtAddFirstName.Text = Convert.ToString(dsStudent.Tables[0].Rows[0]["FirstName"]);
                     //   txtAddMiddleName.Text = Convert.ToString(dsStudent.Tables[0].Rows[0]["MiddleName"]);
                        txtAddLastName.Text = Convert.ToString(dsStudent.Tables[0].Rows[0]["LastName"]);
                        rlstAddGender.SelectedValue = Convert.ToString(dsStudent.Tables[0].Rows[0]["Gender"]);
                        DateTime dt;
                        if (DateTime.TryParse(Convert.ToString(dsStudent.Tables[0].Rows[0]["DateOfBirth"]), out  dt))
                            txtAddDOB.Text = dt.ToString(IFormat);
                        //txtAddBloodGroup.Text = Convert.ToString(dsStudent.Tables[0].Rows[0]["BloodGroup"]);
                        txtAddPermanentAddress.Text = Convert.ToString(dsStudent.Tables[0].Rows[0]["Address"]);
                        txtAddEmail.Text = Convert.ToString(dsStudent.Tables[0].Rows[0]["EmailID"]);
                        string contactno = Convert.ToString(dsStudent.Tables[0].Rows[0]["ContactNo"]);
                        string mobileno = Convert.ToString(dsStudent.Tables[0].Rows[0]["MobileNo"]);
                        if (contactno!="0")
                        {
                            
                            txtAddContactNumber.Text = Convert.ToString(dsStudent.Tables[0].Rows[0]["ContactNo"]);
                        }
                        if (mobileno!="0")
                         
                        {
                        txtAddMobileNumber.Text = Convert.ToString(dsStudent.Tables[0].Rows[0]["MobileNo"]);
                        }
                       // lblAddTitle.Text = "Update Profile: " + txtAddFirstName.Text;
                        TxtOldPassword.Text = null;
                    }
                }

            }
            catch (Exception ex)
            {
                WebMsg.Show(ex.Message);
            }

        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            if (AppSessions.RoleID == 4)//student
            {
                DataSet dtLogin = new DataSet();
                DataTable LoginInfo = new DataTable();
                DataTable UserInfo = new DataTable();

                SYS_Role obj_SYS_Role = new SYS_Role();
                SYS_Role_BLogic obj_BAL_SYS_Role = new SYS_Role_BLogic();
                obj_SYS_Role.Username = AppSessions.LoginID;
               // obj_SYS_Role.Password = TxtOldPassword.Text;
                if (!string.IsNullOrEmpty(TxtOldPassword.Text))
                {

                    dtLogin = obj_BAL_SYS_Role.BAL_SYS_Student_Login(obj_SYS_Role);
                    LoginInfo = dtLogin.Tables[0];

                    if (LoginInfo.Rows.Count > 0 && LoginInfo != null)
                    {
                        oStudent.password = TxtNewPassword.Text;

                    }
                    else
                    {
                        WebMsg.Show("Please enter valid old password.");
                    }
                }
            }
            else if (AppSessions.RoleID == 3 || AppSessions.RoleID == 2 || AppSessions.RoleID == 1) //3-teacher,2-sadmin,1-epath-admin
            {
                Employee_BLogic BEmployee = new Employee_BLogic();
                Employee PEmployee = new Employee();
                PEmployee.roleid = AppSessions.RoleID;
                PEmployee.userid = Convert.ToString(AppSessions.EmpolyeeID);
                PEmployee.Studentlist = "";
                PEmployee.password = TxtNewPassword.Text;
                PEmployee.modifiedby = AppSessions.EmpolyeeID;
                BEmployee.BAL_Employee_Password_Update(PEmployee);
            }
            oStudent = new Student();
            BAL_Student = new Student_BLogic();            

            string IFormat = "dd-MMM-yyyy";
            oStudent.studentid = AppSessions.StudentID;
            oStudent.firstname = txtAddFirstName.Text;
          //  oStudent.middlename = txtAddMiddleName.Text;
            oStudent.lastname = txtAddLastName.Text;
            if (rlstAddGender.SelectedIndex == (int)EnumFile.AssignValue.Zero)
            {
                oStudent.gender = 'M';
            }
            else if (rlstAddGender.SelectedIndex == (int)EnumFile.AssignValue.One)
            {
                oStudent.gender = 'F';
            }
            if (!string.IsNullOrEmpty(txtAddDOB.Text))
                      
            {
                 oStudent.dateofbirth = Convert.ToDateTime(DateTime.Parse(txtAddDOB.Text).ToString(IFormat));
           
            }
            //else
            //{

            //    oStudent.dateofbirth = null;


            //}
            //oStudent.bloodgroup = ""; //txtAddBloodGroup.Text;
            if (!string.IsNullOrEmpty(txtAddPermanentAddress.Text))
            oStudent.Address = txtAddPermanentAddress.Text;
            if (!string.IsNullOrEmpty(txtAddEmail.Text))
            oStudent.emailid = txtAddEmail.Text;
            if (!string.IsNullOrEmpty(txtAddContactNumber.Text))
                oStudent.contactno = Convert.ToInt64(txtAddContactNumber.Text);
            if (!string.IsNullOrEmpty(txtAddMobileNumber.Text))
                oStudent.mobileno = Convert.ToInt64(txtAddMobileNumber.Text);

            bool Status = this.BAL_Student.BAL_Student_UpdateProfile(oStudent);

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
       //txtAddMiddleName.Text = string.Empty;
        txtAddLastName.Text = string.Empty;
        txtAddDOB.Text = string.Empty;
        //txtAddBloodGroup.Text = string.Empty;
        txtAddPermanentAddress.Text = string.Empty;
        txtAddEmail.Text = string.Empty;
        txtAddContactNumber.Text = string.Empty;
        txtAddMobileNumber.Text = string.Empty;     
    }
}