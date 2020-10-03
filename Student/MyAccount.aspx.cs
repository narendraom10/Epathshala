using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Udev.UserMasterPage.Classes;
using System.Collections;


public partial class Student_MyAccount : System.Web.UI.Page
{
    #region Declarations

    #endregion

    #region Page Events
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            Student Student = new Student();
            Student_BLogic BAL_Student = new Student_BLogic();
            Student.studentid = AppSessions.StudentID;
            DataSet dsSelect = new DataSet();
            dsSelect = BAL_Student.BAL_Student_Select(Student, "SelectByID");

            Dvw_PersonalDetails.DataSource = dsSelect;
            Dvw_PersonalDetails.DataBind();

            Dvw_ParentGuardianDetails.DataSource = dsSelect;
            Dvw_ParentGuardianDetails.DataBind();

            Dvw_EducationalDetails.DataSource = dsSelect;
            Dvw_EducationalDetails.DataBind();


        }
    }
    #endregion

    #region DetailsView Events
    #region Personal
    protected void Dvw_PersonalDetails_ModeChanging(object sender, DetailsViewModeEventArgs e)
    {
        try
        {


            if (Dvw_PersonalDetails.CurrentMode == DetailsViewMode.Edit)
            {
                Dvw_PersonalDetails.ChangeMode(DetailsViewMode.ReadOnly);
            }
            else
            {
                Dvw_PersonalDetails.ChangeMode(DetailsViewMode.Edit);
            }
            Student Student = new Student();
            Student_BLogic BAL_Student = new Student_BLogic();
            Student.studentid = AppSessions.StudentID;
            DataSet dsSelect = new DataSet();
            dsSelect = BAL_Student.BAL_Student_Select(Student, "SelectByID");


            Dvw_PersonalDetails.DataSource = dsSelect;
            Dvw_PersonalDetails.DataBind();

            ViewState["byteimage"] = (byte[])dsSelect.Tables[0].Rows[0]["Picture"];
        }
        catch (Exception ex)
        {


        }
    }
    protected void Dvw_PersonalDetails_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
    {
        try
        {
            if (Dvw_PersonalDetails.CurrentMode == DetailsViewMode.Edit)
            {
                Label lbl_findStudentid = (Label)Dvw_PersonalDetails.Rows[0].FindControl("Lbl_EditStudentId");
                FileUpload pictup = (FileUpload)Dvw_PersonalDetails.Rows[1].FindControl("pictureupload");
                TextBox txt_findFirstName = (TextBox)Dvw_PersonalDetails.Rows[2].FindControl("Txt_EditFirstName");
                TextBox txt_findMiddleName = (TextBox)Dvw_PersonalDetails.Rows[3].FindControl("Txt_EditMiddleName");
                TextBox txt_findLastName = (TextBox)Dvw_PersonalDetails.Rows[4].FindControl("Txt_EditLastName");
                TextBox txt_findAddress = (TextBox)Dvw_PersonalDetails.Rows[5].FindControl("Txt_EditAddress");
                TextBox txt_findContact = (TextBox)Dvw_PersonalDetails.Rows[6].FindControl("Txt_EditContact");
                TextBox txt_findMobile = (TextBox)Dvw_PersonalDetails.Rows[7].FindControl("Txt_EditMobile");
                TextBox txt_findEmail = (TextBox)Dvw_PersonalDetails.Rows[8].FindControl("Txt_EditEmail");
                TextBox txt_findBithdate = (TextBox)Dvw_PersonalDetails.Rows[9].FindControl("Txt_EditBirthdate");
                RadioButtonList rbLst_findGender = (RadioButtonList)Dvw_PersonalDetails.Rows[10].FindControl("Rbtn_EditGender");
                TextBox txt_findBloodGroup = (TextBox)Dvw_PersonalDetails.Rows[11].FindControl("Txt_EditBloodGroup");
                TextBox txt_findCity = (TextBox)Dvw_PersonalDetails.Rows[12].FindControl("Txt_EditSchoolCity");
                TextBox txt_findzipcode = (TextBox)Dvw_PersonalDetails.Rows[13].FindControl("Txt_EditSchoolZipcode");
                TextBox txt_findstate = (TextBox)Dvw_PersonalDetails.Rows[14].FindControl("Txt_EditState");
                TextBox txt_findcountry = (TextBox)Dvw_PersonalDetails.Rows[15].FindControl("Txt_EditCountry");

                Student_BLogic obj_studblogic = new Student_BLogic();
                Student obj_student = new Student();

                obj_student.studentid = int.Parse(lbl_findStudentid.Text);
                obj_student.firstname = txt_findFirstName.Text;
                obj_student.middlename = txt_findMiddleName.Text;
                obj_student.lastname = txt_findLastName.Text;
                obj_student.Address = txt_findAddress.Text;
                obj_student.contactno = long.Parse(txt_findContact.Text);
                obj_student.mobileno = long.Parse(txt_findMobile.Text);
                obj_student.emailid = txt_findEmail.Text;
                obj_student.dateofbirth = DateTime.Parse(txt_findBithdate.Text);

                if (rbLst_findGender.SelectedIndex == 0) { obj_student.gender = 'M'; } else if (rbLst_findGender.SelectedIndex == 1) { obj_student.gender = 'F'; }

                Byte[] imgByte = null;
                if (pictup.HasFile && pictup.PostedFile != null)
                {
                    HttpPostedFile File = pictup.PostedFile;
                    imgByte = new Byte[File.ContentLength];

                    DataAccess da = new DataAccess();
                    ArrayList tmplst = new ArrayList();
                    tmplst.Add(new parameter("FieldName", "UploadImageSize"));
                    DataSet dsgetSetting = da.DAL_Select("PROC_GetConfig", tmplst);

                    int allowed_bytes = int.Parse(dsgetSetting.Tables[0].Rows[0]["value"].ToString());
                    if (File.ContentLength <= allowed_bytes)
                    {
                        File.InputStream.Read(imgByte, 0, File.ContentLength);
                    }
                    else
                    {
                        imgByte = (byte[])ViewState["byteimage"];
                    }
                }
                else
                {
                    try { imgByte = (byte[])ViewState["byteimage"]; }
                    catch { }
                }
                obj_student.Picture = imgByte;

                obj_student.bloodgroup = txt_findBloodGroup.Text;
                obj_student.City = txt_findCity.Text;
                obj_student.Zipcode = txt_findzipcode.Text;
                obj_student.State = txt_findstate.Text;
                obj_student.Country = txt_findcountry.Text;

                obj_studblogic.UpdateStudentProfile(obj_student, "personal");

                Dvw_PersonalDetails.ChangeMode(DetailsViewMode.ReadOnly);
                Student Student = new Student();
                Student_BLogic BAL_Student = new Student_BLogic();
                Student.studentid = AppSessions.StudentID;
                DataSet dsSelect = new DataSet();
                dsSelect = BAL_Student.BAL_Student_Select(Student, "SelectByID");

                Dvw_PersonalDetails.DataSource = dsSelect;
                Dvw_PersonalDetails.DataBind();

                TrackLog_Utils.Log(Convert.ToInt32(AppSessions.SchoolID), Convert.ToInt32(AppSessions.EmployeeOrStudentID), Convert.ToInt16(AppSessions.DivisionID), StringEnum.stringValueOf(EnumFile.AccessedPages.AccessMyAccount), "Save Button", "Click", Convert.ToDateTime(System.DateTime.Now), HttpContext.Current.Session.SessionID, StringEnum.stringValueOf(EnumFile.Activity.MyAccountProfileSectionUpdated), "Updated Personal Details.", 0);
            }
        }
        catch (Exception ex)
        {


        }


    }
    #endregion

    #region Parent
    protected void Dvw_ParentGuardianDetails_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
    {
        try
        {
            if (Dvw_ParentGuardianDetails.CurrentMode == DetailsViewMode.Edit)
            {
                Label lbl_findStudentid = (Label)Dvw_ParentGuardianDetails.Rows[0].FindControl("Lbl_EditParentStudentId");
                TextBox Txt_findFathername = (TextBox)Dvw_ParentGuardianDetails.Rows[1].FindControl("Txt_EditFatherName");
                TextBox Txt_findFatherContact = (TextBox)Dvw_ParentGuardianDetails.Rows[2].FindControl("Txt_EditFatherContact");
                TextBox Txt_findFatherEmail = (TextBox)Dvw_ParentGuardianDetails.Rows[3].FindControl("Txt_EditFatherEmail");

                TextBox Txt_findMothername = (TextBox)Dvw_ParentGuardianDetails.Rows[4].FindControl("Txt_EditMotherName");
                TextBox Txt_findMotherContact = (TextBox)Dvw_ParentGuardianDetails.Rows[5].FindControl("Txt_EditMotherContact");
                TextBox Txt_findMotherEmail = (TextBox)Dvw_ParentGuardianDetails.Rows[6].FindControl("Txt_EditMotherEmail");

                TextBox Txt_findGuardianname = (TextBox)Dvw_ParentGuardianDetails.Rows[7].FindControl("TxtEditGuardianName");
                TextBox Txt_findGuardianContact = (TextBox)Dvw_ParentGuardianDetails.Rows[8].FindControl("Txt_EditGuardianContact");
                TextBox Txt_findGuardianEmail = (TextBox)Dvw_ParentGuardianDetails.Rows[9].FindControl("Txt_EditGuardianEmail");

                Student_BLogic obj_studblogic = new Student_BLogic();
                Student obj_student = new Student();

                obj_student.studentid = int.Parse(lbl_findStudentid.Text);
                obj_student.FatherName = Txt_findFathername.Text;
                obj_student.FatherContact = Txt_findFatherContact.Text;
                obj_student.FatherEmail = Txt_findFatherEmail.Text;

                obj_student.MotherName = Txt_findMothername.Text;
                obj_student.MotherContact = Txt_findMotherContact.Text;
                obj_student.MotherEmail = Txt_findMotherEmail.Text;

                obj_student.GuardianName = Txt_findGuardianname.Text;
                obj_student.GuardianContact = Txt_findGuardianContact.Text;
                obj_student.GuardianEmail = Txt_findGuardianEmail.Text;

                obj_studblogic.UpdateStudentProfile(obj_student, "parent");

                Dvw_ParentGuardianDetails.ChangeMode(DetailsViewMode.ReadOnly);

                Student Student = new Student();
                Student_BLogic BAL_Student = new Student_BLogic();
                Student.studentid = AppSessions.StudentID;
                DataSet dsSelect = new DataSet();
                dsSelect = BAL_Student.BAL_Student_Select(Student, "SelectByID");

                Dvw_ParentGuardianDetails.DataSource = dsSelect;
                Dvw_ParentGuardianDetails.DataBind();

                TrackLog_Utils.Log(Convert.ToInt32(AppSessions.SchoolID), Convert.ToInt32(AppSessions.EmployeeOrStudentID), Convert.ToInt16(AppSessions.DivisionID), StringEnum.stringValueOf(EnumFile.AccessedPages.AccessMyAccount), "Save Button", "Click", Convert.ToDateTime(System.DateTime.Now), HttpContext.Current.Session.SessionID, StringEnum.stringValueOf(EnumFile.Activity.MyAccountProfileSectionUpdated), "Updated Parent Details.", 0);
            }
        }
        catch (Exception ex)
        {


        }

    }
    protected void Dvw_ParentGuardianDetails_ModeChanging(object sender, DetailsViewModeEventArgs e)
    {
        try
        {
            if (Dvw_ParentGuardianDetails.CurrentMode == DetailsViewMode.Edit)
            {
                Dvw_ParentGuardianDetails.ChangeMode(DetailsViewMode.ReadOnly);
            }
            else
            {
                Dvw_ParentGuardianDetails.ChangeMode(DetailsViewMode.Edit);
            }
            Student Student = new Student();
            Student_BLogic BAL_Student = new Student_BLogic();
            Student.studentid = AppSessions.StudentID;
            DataSet dsSelect = new DataSet();
            dsSelect = BAL_Student.BAL_Student_Select(Student, "SelectByID");
            Dvw_ParentGuardianDetails.DataSource = dsSelect;
            Dvw_ParentGuardianDetails.DataBind();
        }
        catch (Exception ex)
        {


        }

    }
    #endregion

    #region Educational
    protected void Dvw_EducationalDetails_ModeChanging(object sender, DetailsViewModeEventArgs e)
    {
        try
        {
            if (Dvw_EducationalDetails.CurrentMode == DetailsViewMode.Edit)
            {
                Dvw_EducationalDetails.ChangeMode(DetailsViewMode.ReadOnly);
            }
            else
            {
                Dvw_EducationalDetails.ChangeMode(DetailsViewMode.Edit);
            }
            Student Student = new Student();
            Student_BLogic BAL_Student = new Student_BLogic();
            Student.studentid = AppSessions.StudentID;
            DataSet dsSelect = new DataSet();
            dsSelect = BAL_Student.BAL_Student_Select(Student, "SelectByID");


            Dvw_EducationalDetails.DataSource = dsSelect;
            Dvw_EducationalDetails.DataBind();

        }
        catch (Exception ex)
        {


        }


    }

    protected void Dvw_EducationalDetails_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
    {
        try
        {

            if (Dvw_EducationalDetails.CurrentMode == DetailsViewMode.Edit)
            {
                Label lbl_findStudentid = (Label)Dvw_EducationalDetails.Rows[0].FindControl("Lbl_EditEduStudentId");
                TextBox Txt_findSchoolName = (TextBox)Dvw_EducationalDetails.Rows[2].FindControl("Txt_EditSchool");
                TextBox Txt_findSchoolContact = (TextBox)Dvw_EducationalDetails.Rows[3].FindControl("Txt_EditSchoolContact");
                TextBox Txt_findSchoolEmail = (TextBox)Dvw_EducationalDetails.Rows[4].FindControl("Txt_EditSchoolEmail");

                Student_BLogic obj_studblogic = new Student_BLogic();
                Student obj_student = new Student();

                obj_student.studentid = int.Parse(lbl_findStudentid.Text);
                obj_student.schoolname = Txt_findSchoolName.Text;
                obj_student.SchoolContact = Txt_findSchoolContact.Text;
                obj_student.SchoolEmail = Txt_findSchoolEmail.Text;

                obj_studblogic.UpdateStudentProfile(obj_student, "education");

                Dvw_EducationalDetails.ChangeMode(DetailsViewMode.ReadOnly);

                Student Student = new Student();
                Student_BLogic BAL_Student = new Student_BLogic();
                Student.studentid = AppSessions.StudentID;
                DataSet dsSelect = new DataSet();
                dsSelect = BAL_Student.BAL_Student_Select(Student, "SelectByID");

                Dvw_EducationalDetails.DataSource = dsSelect;
                Dvw_EducationalDetails.DataBind();

                TrackLog_Utils.Log(Convert.ToInt32(AppSessions.SchoolID), Convert.ToInt32(AppSessions.EmployeeOrStudentID), Convert.ToInt16(AppSessions.DivisionID), StringEnum.stringValueOf(EnumFile.AccessedPages.AccessMyAccount), "Save Button", "Click", Convert.ToDateTime(System.DateTime.Now), HttpContext.Current.Session.SessionID, StringEnum.stringValueOf(EnumFile.Activity.MyAccountProfileSectionUpdated), "Updated Educational Details.", 0);
            }
        }
        catch (Exception ex)
        {


        }
    }
    #endregion
    #endregion

    #region User Defined Methods

    #endregion

    protected void btnChangesubmit_Click(object sender, EventArgs e)
    {
        if (AppSessions.RoleID == 4)//student
        {
            //Employee_BLogic BEmployee = new Employee_BLogic();
            //Employee PEmployee = new Employee();
            //PEmployee.roleid = AppSessions.RoleID;
            //PEmployee.userid = "";
            //PEmployee.Studentlist = Convert.ToString(AppSessions.StudentID);
            //PEmployee.password = txtnp.Text;
            //PEmployee.modifiedby = AppSessions.EmpolyeeID;
            //BEmployee.BAL_Employee_Password_Update(PEmployee);
            //lblmsg.Visible = true;
            DataSet dtLogin = new DataSet();
            DataTable LoginInfo = new DataTable();
            DataTable UserInfo = new DataTable();

            SYS_Role obj_SYS_Role = new SYS_Role();
            SYS_Role_BLogic obj_BAL_SYS_Role = new SYS_Role_BLogic();
            obj_SYS_Role.Username = AppSessions.LoginID;
            obj_SYS_Role.Password = txtop.Text;

            dtLogin = obj_BAL_SYS_Role.BAL_SYS_Student_Login(obj_SYS_Role);
            LoginInfo = dtLogin.Tables[0];

            if (LoginInfo.Rows.Count > 0 && LoginInfo != null)
            {
                Employee_BLogic BEmployee = new Employee_BLogic();
                Employee PEmployee = new Employee();
                PEmployee.roleid = AppSessions.RoleID;
                PEmployee.userid = "";
                PEmployee.Studentlist = Convert.ToString(AppSessions.StudentID);
                PEmployee.password = txtnp.Text;
                PEmployee.modifiedby = AppSessions.EmpolyeeID;
                BEmployee.BAL_Employee_Password_Update(PEmployee);
                lblmsg.Text = "Password changed successfully";

                TrackLog_Utils.Log(Convert.ToInt32(AppSessions.SchoolID), Convert.ToInt32(AppSessions.EmployeeOrStudentID), Convert.ToInt16(AppSessions.DivisionID), StringEnum.stringValueOf(EnumFile.AccessedPages.AccessMyAccount), "Change Password Tab", "Click", Convert.ToDateTime(System.DateTime.Now), HttpContext.Current.Session.SessionID, StringEnum.stringValueOf(EnumFile.Activity.MyAccountChangedPassword), "Changed Password > From :  " + txtop.Text + " To : " + txtnp.Text, 0);
            }
            else
            {
                lblmsg.Visible = true;
                lblmsg.Text = "Please enter valid old password.";
                //WebMsg.Show("Please enter valid old password.");
            }


        }
        else if (AppSessions.RoleID == 3 || AppSessions.RoleID == 2 || AppSessions.RoleID == 1) //3-teacher,2-sadmin,1-epath-admin
        {
            Employee_BLogic BEmployee = new Employee_BLogic();
            Employee PEmployee = new Employee();
            PEmployee.roleid = AppSessions.RoleID;
            PEmployee.userid = Convert.ToString(AppSessions.EmpolyeeID);
            PEmployee.Studentlist = "";
            PEmployee.password = txtnp.Text;
            PEmployee.modifiedby = AppSessions.EmpolyeeID;
            BEmployee.BAL_Employee_Password_Update(PEmployee);
        }

    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        txtcp.Text = string.Empty;
        txtnp.Text = string.Empty;
    }
}