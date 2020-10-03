using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Udev.UserMasterPage.Classes;
using System.Globalization;

public partial class Registration_StudentOnlineReg : System.Web.UI.Page
{
    SYS_BMS_BLogic BSysBMS = new SYS_BMS_BLogic();
    SYS_BMS PSysBMS = new SYS_BMS();
    Student_BLogic BAL_Student;
    Student Student;

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
            GetBMS();
        }
    }

    protected void GetBMS()
    {
        DropDownFill DdlFilling = new DropDownFill();
        DataSet dsBMS = new DataSet();
        dsBMS = BSysBMS.BAL_SYS_BMS_SelectAll();
        if (dsBMS.Tables[0].Rows.Count > 0)
        {
            DdlFilling.BindDropDownByTable(ddlBMSAdd, dsBMS.Tables[0], "BMS", "BMSID");
            ddlBMSAdd.Items.Insert(Convert.ToInt32(EnumFile.AssignValue.Zero), "-- Select --");
            ddlBMSAdd.Items[0].Value = Convert.ToString((int)EnumFile.AssignValue.Zero);
            ddlBMSAdd.Enabled = true;

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

            Student.loginid = txtLoginID.Text;
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

    protected void txtLoginID_TextChanged(object sender, EventArgs e)
    {
        try
        {
            verifyLoginID();
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ClearControls();
    }

    protected void ClearControls()
    {
        try
        {
            ddlBMSAdd.SelectedValue = "0";
            txtLoginID.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtFirstName.Text = string.Empty;
            txtMiddleName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtContactNo.Text = string.Empty;
            txtMobileNo.Text = string.Empty;
            txtEmailID.Text = string.Empty;
            //txtDateOfBirth.Text = string.Empty;
            txtAddress.Text = string.Empty;
            rdbGenderList.ClearSelection();
            rdbCountry.ClearSelection();
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        int t1 = 0;
        try
        {
            if (verifyLoginID())
            {

                Student = new Student();
                BAL_Student = new Student_BLogic();
                Student.bmsid = int.Parse(ddlBMSAdd.SelectedValue);
                Student.loginid = txtLoginID.Text;
                Student.password = txtPassword.Text;
                Student.firstname = txtFirstName.Text;
                Student.middlename = txtMiddleName.Text;
                Student.lastname = txtLastName.Text;
                Student.contactno = Convert.ToInt64(txtContactNo.Text);
                Student.mobileno = Convert.ToInt64(txtMobileNo.Text);
                Student.emailid = txtEmailID.Text;
                //Student.dateofbirth = Convert.ToDateTime(txtDateOfBirth.Text);
                Student.Address = txtAddress.Text;
                if (rdbGenderList.SelectedValue == "0")
                {
                    Student.gender = 'M';
                }
                else if (rdbGenderList.SelectedValue == "1")
                {
                    Student.gender = 'F';
                }

                if (rdbCountry.SelectedValue == "0")
                {
                    Student.PaymentType = 'I';
                }
                else if (rdbCountry.SelectedValue == "1")
                {
                    Student.PaymentType = 'O';
                }


                t1 = BAL_Student.BAL_Student_Insert_Online(Student, "OnlineReg");
                if (t1 > 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, GetType(), "Message", "You are successfully registered", false);
                    //WebMsg.Show("You are successfully registered");
                    ClearControls();
                    Response.Redirect("../Default.aspx");
                }
                ClearControls();
            }
            else
            {
                WebMsg.Show("LoginID already exist..");
            }
            //WebMsg.Show("Registration succeed");
            //Response.Redirect("~/Default.aspx");
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
        finally
        { }
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Default.aspx");
    }


}