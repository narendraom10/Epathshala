using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class UserControl_StudentRegistration : System.Web.UI.UserControl
{

    Student_BLogic OBAL_Student;
    Student OStudent;
    Student_DashBoard_BLogic OBLogic_Student;
    SYS_BMS_BLogic BSysBMS = new SYS_BMS_BLogic();


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            GetBMS();
    }
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
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        int t1 = 0;

        //if (TxtBxCap.Text.Trim() != "")
        //{
        //Captcha1.ValidateCaptcha(TxtBxCap.Text.Trim());
        try
        {
            if (verifyLoginID())
            {
                if (!CheckPasswordComplexcity())
                {
                    WebMsg.Show("Invalid password format, please enter minimum 6 alphanumeric character with @ # $ %. Sign.");
                    return;
                }
                OStudent = new Student();
                OBAL_Student = new Student_BLogic();
                OStudent.schoolid = 1;
                OStudent.divisionid = 1;
                OStudent.bmsid = int.Parse(ddlBMS.SelectedValue);
                OStudent.loginid = txtEmail.Text;
                OStudent.password = txtPassword.Text;
                OStudent.firstname = txtFirstName.Text;
                OStudent.lastname = txtLastName.Text;
                OStudent.contactno = Convert.ToInt64(txtContactNo.Text);
                OStudent.emailid = txtEmail.Text;

                DateTime fromdatetime;
                if (DateTime.TryParse(txtBirthdate.Text, out fromdatetime))
                {
                    OStudent.dateofbirth = fromdatetime;
                }

                if (ddlGender.SelectedValue == "1")
                {
                    OStudent.gender = 'M';
                }
                else if (ddlGender.SelectedValue == "2")
                {
                    OStudent.gender = 'F';
                }
                OStudent.PaymentType = 'I';
                //if (Captcha1.UserValidated)
                //{
                t1 = OBAL_Student.BAL_Student_Insert_Online(OStudent, "OnlineReg");
                //}
                //else
                //{
                //    WebMsg.Show("Please enter the correct Captcha code");

                //}
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
               // WebMsg.Show("LoginID already exist..");
            }
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
        finally
        { }


    }

    public bool CheckPasswordComplexcity()
    {
        bool flag = false;
        OBLogic_Student = new Student_DashBoard_BLogic();
        DataSet dsResult = new DataSet();
        dsResult = OBLogic_Student.BAL_Select_PaymentPagesInfo("Password");

        string Complexcity = dsResult.Tables[0].Rows[0]["value"].ToString();

        if (txtPassword.Text.Length > 0)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtPassword.Text, Complexcity))
            {

                //WebMsg.Show("Valid Password");
                flag = true;
            }
            else
            {
                //WebMsg.Show("Invalid Password");
                flag = false;
            }
        }
        return flag;
    }

    protected bool verifyLoginID()
    {
        bool Flag = true;
        try
        {
            OBAL_Student = new Student_BLogic();
            OStudent = new Student();
            DataSet ds = new DataSet();

            OStudent.loginid = txtEmail.Text;
            ds = OBAL_Student.BAL_Verify_Student(OStudent);
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
}