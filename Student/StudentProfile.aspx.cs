///<Summary>
///</Summary>

using System;
using System.Data;
using System.Globalization;
using Udev.UserMasterPage.Classes;
using System.Web;

public partial class Student_StudentProfile : System.Web.UI.Page
{
    # region "Variables"
    SYS_BMS_BLogic BSysBMS = new SYS_BMS_BLogic();
    SYS_BMS PSysBMS = new SYS_BMS();
    Student_BLogic BAL_Student;
    Student Student;
    # endregion

    # region "Properties"
    # endregion

    # region "Page events"
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetBMS();
            ViewMode();
        }
    }
    # endregion

    # region "User defined functions"
    protected void SetEditStudentInfo()
    {
        try
        {
            Student = new Student();
            BAL_Student = new Student_BLogic();
            Student.studentid = AppSessions.StudentID;
            DataSet dsSelect = new DataSet();
            dsSelect = BAL_Student.BAL_Student_Select(Student, "SelectByID");
            if (dsSelect.Tables[0].Rows.Count > 0)
            {
                ddlBMSAdd.SelectedValue = AppSessions.BMSID.ToString();
                txtFirstName.Text = dsSelect.Tables[0].Rows[0]["FirstName"].ToString();
                txtMiddleName.Text = dsSelect.Tables[0].Rows[0]["MiddleName"].ToString();
                txtLastName.Text = dsSelect.Tables[0].Rows[0]["LastName"].ToString();
                txtAddress.Text = dsSelect.Tables[0].Rows[0]["Address"].ToString();
                txtMobileNo.Text = dsSelect.Tables[0].Rows[0]["MobileNo"].ToString();
                txtContactNo.Text = dsSelect.Tables[0].Rows[0]["ContactNo"].ToString();
                txtEmailID.Text = dsSelect.Tables[0].Rows[0]["EmailID"].ToString();
                if (dsSelect.Tables[0].Rows[0]["DateOfBirth"].ToString() != string.Empty)
                {
                    txtDateOfBirth.Text = Convert.ToDateTime(dsSelect.Tables[0].Rows[0]["DateOfBirth"]).ToString("dd-MMM-yyyy");
                }

                if (dsSelect.Tables[0].Rows[0]["Gender"].ToString() == "M")
                {
                    rdbGenderList.SelectedValue = "0";
                }
                else
                {
                    rdbGenderList.SelectedValue = "1";
                }
                ViewState["byteimage"] = dsSelect.Tables[0].Rows[0]["Picture"];
                //txtLoginID.Text = dsSelect.Tables[0].Rows[0]["LoginID"].ToString();
                //txtPassword.Text = dsSelect.Tables[0].Rows[0]["Password"].ToString();
            }
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }
    protected void SetViewStudentInfo()
    {
        try
        {
            Student = new Student();
            BAL_Student = new Student_BLogic();
            Student.studentid = AppSessions.StudentID;
            DataSet dsSelect = new DataSet();
            dsSelect = BAL_Student.BAL_Student_Select(Student, "SelectByID");
            if (dsSelect.Tables[0].Rows.Count > 0)
            {
                vwbms.Text = AppSessions.BMS;
                vwfirstname.Text = dsSelect.Tables[0].Rows[0]["FirstName"].ToString();
                vwmiddlename.Text = dsSelect.Tables[0].Rows[0]["MiddleName"].ToString();
                vwlastname.Text = dsSelect.Tables[0].Rows[0]["LastName"].ToString();
                vwaddress.Text = dsSelect.Tables[0].Rows[0]["Address"].ToString();
                vwmobilenumber.Text = dsSelect.Tables[0].Rows[0]["MobileNo"].ToString();
                vwcontactnumner.Text = dsSelect.Tables[0].Rows[0]["ContactNo"].ToString();
                vwemail.Text = dsSelect.Tables[0].Rows[0]["EmailID"].ToString();
                if (dsSelect.Tables[0].Rows[0]["DateOfBirth"].ToString() != string.Empty)
                {
                    vwdateofbirth.Text = Convert.ToDateTime(dsSelect.Tables[0].Rows[0]["DateOfBirth"]).ToString("dd-MMM-yyyy");
                }

                if (dsSelect.Tables[0].Rows[0]["Gender"].ToString() == "M")
                {
                    vwgender.Text = "Male";
                }
                else
                {
                    vwgender.Text = "Female";
                }
            }
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
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
            // ddlBMSAdd.Enabled = true;

        }
    }

    protected override void InitializeCulture()
    {
        string culture = Convert.ToString(Session[Global.SESSION_KEY_CULTURE]);
        // 'set culture to current thread 
        System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture);
        System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);
        //call base class 
        base.InitializeCulture();
    }

    # endregion

    # region "Control events"
    protected void txtLoginID_TextChanged(object sender, EventArgs e)
    {
        try
        {
            BAL_Student = new Student_BLogic();
            Student = new Student();
            DataSet ds = new DataSet();

            //Student.loginid = txtLoginID.Text;
            ds = BAL_Student.BAL_Verify_Student(Student);
            if (ds.Tables[0].Rows.Count > 0 && ds != null)
            {
                string LoginID = ds.Tables[0].Rows[0]["LoginID"].ToString();
                if (LoginID != string.Empty)
                {
                    WebMsg.Show("LoginID already exist..");
                }
            }

        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            Byte[] imgByte = null;
            Student = new Student();
            BAL_Student = new Student_BLogic();
            Student.studentid = AppSessions.StudentID;
            Student.bmsid = int.Parse(ddlBMSAdd.SelectedValue);
            ////Student.loginid = txtLoginID.Text;
            ////Student.password = txtPassword.Text;
            Student.firstname = txtFirstName.Text;
            Student.middlename = txtMiddleName.Text;
            Student.lastname = txtLastName.Text;
            Student.contactno = Convert.ToInt64(txtContactNo.Text);
            Student.mobileno = Convert.ToInt64(txtMobileNo.Text);
            Student.emailid = txtEmailID.Text;
            Student.dateofbirth = Convert.ToDateTime(txtDateOfBirth.Text);
            Student.Address = txtAddress.Text;
            if (rdbGenderList.SelectedValue == "0")
            {
                Student.gender = 'M';
            }
            else if (rdbGenderList.SelectedValue == "1")
            {
                Student.gender = 'F';
            }
            if (pictureupload.HasFile && pictureupload.PostedFile != null)
            {
                HttpPostedFile File = pictureupload.PostedFile;
                imgByte = new Byte[File.ContentLength];
                File.InputStream.Read(imgByte, 0, File.ContentLength);
            }
            else
            {
                try { imgByte = (byte[])ViewState["byteimage"]; }
                catch { }
            }
            Student.Picture = imgByte;

            BAL_Student.BAL_Student_Update(Student, "UpdateOnlineReg");
            WebMsg.Show("Information updated.");
            ViewMode();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        { }
    }
    protected void btnchangeview_Click(object sender, EventArgs e)
    {
        switch (hdnstate.Value)
        {
            case "View":
                ViewMode();
                break;
            case "Edit":
                EditMode();
                break;
            default:
                break;
        }
    }
    private void ViewMode()
    {
        MultiView1.ActiveViewIndex = 0;
        vw.Attributes.Add("class", "active");
        ed.Attributes.Remove("class");
        SetViewStudentInfo();
    }
    private void EditMode()
    {
        MultiView1.ActiveViewIndex = 1;
        ed.Attributes.Add("class", "active");
        vw.Attributes.Remove("class");
        SetEditStudentInfo();
    }

    # endregion
}