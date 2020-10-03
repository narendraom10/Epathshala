using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class ResponsiveRegister : System.Web.UI.Page
{
    #region "Declarations"
    SYS_BMS_BLogic BSysBMS = new SYS_BMS_BLogic();
    SYS_BMS PSysBMS = new SYS_BMS();
    Student_BLogic BAL_Student;
    Student Student;
    SYS_Role_BLogic obj_BAL_SYS_Role;
    SYS_Role obj_SYS_Role;
    Student_DashBoard_BLogic BLogic_Student;
    StudentDash StudentDash;
    string msg = string.Empty;
    #endregion

    #region "Page Login"
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetBMS();
        }
    }
    #endregion

    #region Control Events"
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        int t1 = 0;
        try
        {
            if (verifyLoginID())
            {
                Student = new Student();
                BAL_Student = new Student_BLogic();
                Student.schoolid = 1;
                Student.divisionid = 1;
                Student.bmsid = int.Parse(ddlBMS.SelectedValue);
                Student.loginid = txtEmail.Text;
                Student.password = txtPassword.Text;
                Student.firstname = txtFirstName.Text;
                Student.lastname = txtLastName.Text;
                Student.contactno = Convert.ToInt64(txtContactNo.Text);
                Student.emailid = txtEmail.Text;
                Student.dateofbirth = Convert.ToDateTime(txtBirthdate.Text);
                if (ddlGender.SelectedValue == "1")
                {
                    Student.gender = 'M';
                }
                else if (ddlGender.SelectedValue == "2")
                {
                    Student.gender = 'F';
                }

                Student.PaymentType = 'I';



                t1 = BAL_Student.BAL_Student_Insert_Online(Student, "OnlineReg");
                if (t1 > 0)
                {
                    //ScriptManager.RegisterStartupScript(this.Page, GetType(), "Message", "You are successfully registered", false);
                    WebMsg.Show("Your registration has been done successfully.");
                    ClearRegisterControls();
                }
                ClearRegisterControls();
            }
            else
            {
                WebMsg.Show("LoginID already exist..");
            }
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
        finally
        { }
    }
    #endregion

    #region "User Defined Function"
    protected void GetBMS()
    {
        DropDownFill DdlFilling = new DropDownFill();
        DataSet dsBMS = new DataSet();
        dsBMS = BSysBMS.BAL_SYS_BMS_SelectAll();
        if (dsBMS.Tables[0].Rows.Count > 0)
        {
            DdlFilling.BindDropDownByTable(ddlBMS, dsBMS.Tables[0], "BMS", "BMSID");
            ddlBMS.Items.Insert(Convert.ToInt32(EnumFile.AssignValue.Zero), "-- Select --");
            ddlBMS.Items[0].Value = Convert.ToString((int)EnumFile.AssignValue.Zero);
            ddlBMS.Enabled = true;
        }
    }
    protected void ClearRegisterControls()
    {
        try
        {
            ddlBMS.SelectedValue = "0";
            ddlGender.SelectedValue = "0";
            txtEmail.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtContactNo.Text = string.Empty;
            txtBirthdate.Text = string.Empty;
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }
    protected bool verifyLoginID()
    {
        bool Flag = true;
        try
        {
            BAL_Student = new Student_BLogic();
            Student = new Student();
            DataSet ds = new DataSet();

            Student.loginid = txtEmail.Text;
            ds = BAL_Student.BAL_Verify_Student(Student);
            if (ds.Tables[0].Rows.Count > 0 && ds != null)
            {
                string LoginID = ds.Tables[0].Rows[0]["LoginID"].ToString();
                if (LoginID != string.Empty)
                {
                    Flag = false;
                    WebMsg.Show("LoginID already exist..");
                }
            }

        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
        return Flag;
    }
    #endregion
}