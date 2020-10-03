/// <summary>
/// <Description></Description>
/// <DevelopedBy></DevelopedBy>
/// <Created Date> </Date>
/// <UpdatedBy>"Sheel"</UpdatedBy>
/// <Updated Date>"25-7-2014"</Date>
/// </summary>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Udev.UserMasterPage.Classes;
using System.Globalization;
using System.Collections;
using System.Web.SessionState;
using System.Text.RegularExpressions;
using System.Web.Configuration;

public partial class LoginMasterPage : System.Web.UI.MasterPage
{

    public string testbind(string TypeOfPainting)
    { 
    
        return "http://www.google.com"; 
    
    }

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
    Employee Employee;
    Teacher_Dashboard_BLogic BAL_Forgetpassword;
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        SetOfferText();
        SetQuoteText();
        if (!IsPostBack)
        {
            if (ddlLanguage.SelectedValue.ToString().Equals("en-US"))
            {
                Session["LANG"] = ddlLanguage.SelectedValue;
                Session["langid"] = ((int)EnumFile.Language.English).ToString();
            }
            else if (ddlLanguage.SelectedValue.ToString().Equals("gu-IN"))
            {
                Session["LANG"] = ddlLanguage.SelectedValue;
                Session["langid"] = ((int)EnumFile.Language.Gujarati).ToString();
            }
            else if (ddlLanguage.SelectedValue.ToString().Equals("hi-IN"))
            {
                Session["LANG"] = ddlLanguage.SelectedValue;
                Session["langid"] = ((int)EnumFile.Language.Hindi).ToString();
            }
        }
    }
    protected void StoreCookie()
    {
        try
        {
            if (chkRememberMe.Checked == true)
            {
                HttpCookie loginCookie = new HttpCookie("loginCookie");
                loginCookie["UserName"] = txtUserName.Text;
                loginCookie["Password"] = txtUserPassword.Text;
                loginCookie.Expires.AddDays(7);
                Response.Cookies.Add(loginCookie);
            }
            else
            {
                if (Request.Cookies["loginCookie"] != null)
                {
                    HttpCookie Cookie = Request.Cookies["loginCookie"];
                    Cookie.Expires = DateTime.Now.AddDays(-1d);
                    Response.Cookies.Add(Cookie);
                }
            }
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }

    public int CheckLogin()
    {
        obj_SYS_Role = new SYS_Role();
        obj_BAL_SYS_Role = new SYS_Role_BLogic();
        obj_SYS_Role.Username = txtUserName.Text;
        obj_SYS_Role.Password = txtUserPassword.Text;

        DataSet dtLogin = new DataSet();
        DataTable LoginInfo = new DataTable();

        dtLogin = obj_BAL_SYS_Role.BAL_SYS_Check_Login(obj_SYS_Role);
        LoginInfo = dtLogin.Tables[0];

        int status = Convert.ToInt16(LoginInfo.Rows[0]["Status"].ToString());

        return status;

    }

    //protected void btnGo_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        StoreCookie();

    //        int status = CheckLogin();
    //        //if (ddlUserType.SelectedValue == "0")
    //        if (status == 2)
    //        {
    //            WebMsg.Show("invalid username or password");
    //            return;
    //        }
    //        else if (status == 0)
    //        {
    //            // 0 Indicates Student

    //            StudentDash = new StudentDash();
    //            BLogic_Student = new Student_DashBoard_BLogic();

    //            DataSet dtLogin = new DataSet();
    //            DataTable LoginInfo = new DataTable();
    //            DataTable UserInfo = new DataTable();

    //            obj_SYS_Role = new SYS_Role();
    //            obj_BAL_SYS_Role = new SYS_Role_BLogic();
    //            obj_SYS_Role.Username = txtUserName.Text;
    //            obj_SYS_Role.Password = txtUserPassword.Text;
    //            //obj_SYS_Role.roleid = Convert.ToInt16(DdlRole.SelectedValue);

    //            dtLogin = obj_BAL_SYS_Role.BAL_SYS_Student_Login(obj_SYS_Role);
    //            LoginInfo = dtLogin.Tables[0];
    //            if (LoginInfo.Rows.Count > 0 && LoginInfo != null)
    //            {
    //                AppSessions.AppUserType = "Student";

    //                AppSessions.StudentID = Convert.ToInt32(LoginInfo.Rows[0]["StudentID"].ToString());
    //                AppSessions.UserName = LoginInfo.Rows[0]["FirstName"].ToString();

    //                AppSessions.BMSID = Convert.ToInt32(LoginInfo.Rows[0]["BMSID"].ToString());
    //                AppSessions.BMS = LoginInfo.Rows[0]["BMS"].ToString();

    //                AppSessions.BoardID = Convert.ToInt32(LoginInfo.Rows[0]["BoardID"].ToString());
    //                AppSessions.Board = LoginInfo.Rows[0]["Board"].ToString();

    //                AppSessions.MediumID = Convert.ToInt32(LoginInfo.Rows[0]["MediumID"].ToString());
    //                AppSessions.Medium = LoginInfo.Rows[0]["Medium"].ToString();

    //                AppSessions.StandardID = Convert.ToInt32(LoginInfo.Rows[0]["StandardID"].ToString());
    //                AppSessions.Standard = LoginInfo.Rows[0]["Standard"].ToString();

    //                AppSessions.DivisionID = Convert.ToInt32(LoginInfo.Rows[0]["DivisionID"].ToString());
    //                //AppSessions.Division = LoginInfo.Rows[0]["Division"].ToString();

    //                AppSessions.SchoolID = Convert.ToInt32(LoginInfo.Rows[0]["SchoolID"].ToString());
    //                //AppSessions.SchoolName = LoginInfo.Rows[0]["SchoolName"].ToString();

    //                AppSessions.Role = LoginInfo.Rows[0]["Role"].ToString();
    //                AppSessions.RoleID = Convert.ToInt32(LoginInfo.Rows[0]["RoleID"].ToString());

    //                //AppSessions.EmailID = Convert.ToString(LoginInfo.Rows[0]["EmailID"]);

    //                //yourLoginMethodStudent(LoginInfo);
    //                bool AllowMultipleSession = false;
    //                AllowMultipleSession = Convert.ToBoolean(LoginInfo.Rows[0]["AllowMultipleSession"].ToString());


    //                if (AllowMultipleSession == false)
    //                {
    //                    Hashtable sessions = (Hashtable)Application["WEB_SESSIONS_OBJECT"];
    //                    if (sessions == null)
    //                    {
    //                        sessions = new Hashtable();
    //                    }

    //                    HttpSessionState existingUserSession = (HttpSessionState)sessions[Session["StudentID"].ToString()];
    //                    if (existingUserSession != null)
    //                    {
    //                        ////existingUserSession[Session["EmpolyeeID"].ToString()] = null;
    //                        //logout current logged in user
    //                        WebMsg.Show("you are already logged in.");
    //                        lblError1.Visible = true;
    //                        return;
    //                    }
    //                }

    //                ////////getting the pointer to the Session of the current logged in user
    //                yourLoginMethodStudent(LoginInfo);
    //                ProceedToRedirectPage(LoginInfo);

    //                bool AllowPayment = false;
    //                DataSet dsPaymentInfo = new DataSet();
    //                dsPaymentInfo = BLogic_Student.BAL_Select_PaymentPagesInfo("Payment");
    //                if (dsPaymentInfo != null & dsPaymentInfo.Tables.Count > 0)
    //                {
    //                    if (dsPaymentInfo.Tables[0].Rows.Count > 0)
    //                    {
    //                        string a = dsPaymentInfo.Tables[0].Rows[0]["value"].ToString();
    //                        if (a == "0")
    //                        {
    //                            AllowPayment = false;
    //                        }
    //                        else
    //                        {
    //                            AllowPayment = true;
    //                        }
    //                    }
    //                }

    //                DataSet ds = new DataSet();
    //                StudentDash.StudentID = AppSessions.StudentID;
    //                //ds = BLogic_Student.BAL_Validate_Student(StudentDash);
    //                ds = BLogic_Student.BAL_Validate_Student_Package(StudentDash);


    //                if (AllowPayment == true)
    //                {
    //                    //Session["ShowPaymentPages"] = "yes";
    //                    if (ds != null && dtLogin.Tables.Count > 0)
    //                    {
    //                        if (ds.Tables[0].Rows.Count > 0)
    //                        {
    //                            Session["CheckValidity"] = "Yes";
    //                            ProceedToRedirect();
    //                        }
    //                        else
    //                        {
    //                            Response.Redirect("~/DashBoard/SelectPackage.aspx", false);
    //                        }
    //                    }
    //                    else
    //                    {
    //                        Response.Redirect("~/DashBoard/SelectPackage.aspx", false);
    //                    }
    //                }
    //                else
    //                {
    //                    Session["CheckValidity"] = "Yes";
    //                    Session["ShowPaymentPages"] = "No";
    //                    ProceedToRedirect();
    //                }
    //            }
    //        }

    //        //else if (ddlUserType.SelectedValue == "1")
    //        else if (status == 1)
    //        {
    //            // 1 Indicates Teacher
    //            DataSet dtLogin = new DataSet();
    //            DataTable LoginInfo = new DataTable();
    //            DataTable UserInfo = new DataTable();

    //            obj_SYS_Role = new SYS_Role();
    //            obj_BAL_SYS_Role = new SYS_Role_BLogic();
    //            obj_SYS_Role.Username = txtUserName.Text;
    //            obj_SYS_Role.Password = txtUserPassword.Text;
    //            //obj_SYS_Role.roleid = Convert.ToInt16(DdlRole.SelectedValue);

    //            dtLogin = obj_BAL_SYS_Role.BAL_SYS_Active_Login(obj_SYS_Role);
    //            LoginInfo = dtLogin.Tables[0];

    //            if (LoginInfo.Rows.Count > 0 && LoginInfo != null && LoginInfo.Rows[0]["Status"].ToString().Equals("1"))
    //            {
    //                if (dtLogin.Tables[1].Rows[0]["RoleID"].ToString() != "3")
    //                {
    //                    bool AllowMultipleSession = false;
    //                    UserInfo = dtLogin.Tables[1];
    //                    if (UserInfo.Rows.Count > 0 && UserInfo != null)
    //                    {

    //                        AppSessions.AppUserType = "School";
    //                        AppSessions.EmpolyeeID = int.Parse(UserInfo.Rows[0]["EmployeeID"].ToString());
    //                        AppSessions.RoleID = int.Parse(UserInfo.Rows[0]["RoleID"].ToString());
    //                        AppSessions.SchoolID = int.Parse(UserInfo.Rows[0]["SchoolID"].ToString());
    //                        AppSessions.UserName = UserInfo.Rows[0]["FirstName"].ToString();
    //                        AppSessions.SchoolName = UserInfo.Rows[0]["Name"].ToString();
    //                        AppSessions.Role = UserInfo.Rows[0]["Role"].ToString();

    //                        AllowMultipleSession = Convert.ToBoolean(UserInfo.Rows[0]["AllowMultipleSession"].ToString());
    //                        TrackLog_Utils.Log(Convert.ToInt32(AppSessions.SchoolID), Convert.ToInt32(AppSessions.EmpolyeeID), Convert.ToInt16(AppSessions.DivisionID), "LoginPage", "btnLogin", "Click", Convert.ToDateTime(System.DateTime.Now), HttpContext.Current.Session.SessionID, StringEnum.stringValueOf(EnumFile.Activity.LoginSuccess), "LoginId: " + txtUserName.Text, 0);
    //                    }

    //                    if (AllowMultipleSession == false)
    //                    {
    //                        Hashtable sessions = (Hashtable)Application["WEB_SESSIONS_OBJECT"];
    //                        if (sessions == null)
    //                        {
    //                            sessions = new Hashtable();
    //                        }

    //                        ////////getting the pointer to the Session of the current logged in user
    //                        HttpSessionState existingUserSession = (HttpSessionState)sessions[Session["EmpolyeeID"].ToString()];
    //                        if (existingUserSession != null)
    //                        {
    //                            ////existingUserSession[Session["EmpolyeeID"].ToString()] = null;
    //                            //logout current logged in user
    //                            lblError1.Visible = true;
    //                        }
    //                        else
    //                        {
    //                            yourLoginMethod(UserInfo);
    //                            ProceedToRedirectPage(UserInfo);
    //                        }
    //                    }
    //                    else
    //                    {
    //                        yourLoginMethod(UserInfo);
    //                        ProceedToRedirectPage(UserInfo);
    //                    }
    //                }
    //                else
    //                {
    //                    // For Teacher Redirection

    //                    bool AllowMultipleSession = false;
    //                    UserInfo = dtLogin.Tables[1];
    //                    if (UserInfo.Rows.Count > 0 && UserInfo != null)
    //                    {
    //                        Session["UserInfoTable"] = UserInfo;

    //                        ViewState["AppUserType"] = "School";
    //                        ViewState["EmpolyeeID"] = int.Parse(UserInfo.Rows[0]["EmployeeID"].ToString());
    //                        ViewState["RoleID"] = int.Parse(UserInfo.Rows[0]["RoleID"].ToString());
    //                        ViewState["SchoolID"] = int.Parse(UserInfo.Rows[0]["SchoolID"].ToString());
    //                        ViewState["UserName"] = UserInfo.Rows[0]["FirstName"].ToString();
    //                        ViewState["SchoolName"] = UserInfo.Rows[0]["Name"].ToString();
    //                        ViewState["Role"] = UserInfo.Rows[0]["Role"].ToString();

    //                        AllowMultipleSession = Convert.ToBoolean(UserInfo.Rows[0]["AllowMultipleSession"].ToString());
    //                        TrackLog_Utils.Log(Convert.ToInt32(ViewState["SchoolID"]), Convert.ToInt32(ViewState["EmpolyeeID"]), Convert.ToInt16(AppSessions.DivisionID), "LoginMasterPage.master", "btnGo", "Click", Convert.ToDateTime(System.DateTime.Now), HttpContext.Current.Session.SessionID, StringEnum.stringValueOf(EnumFile.Activity.LoginSuccess), ViewState["UserName"] + " (" + txtUserName.Text + ") From " + ViewState["SchoolName"] + " school Logged in.", 0);
    //                    }

    //                    if (AllowMultipleSession == false)
    //                    {
    //                        Hashtable sessions = (Hashtable)Application["WEB_SESSIONS_OBJECT"];
    //                        if (sessions == null)
    //                        {
    //                            sessions = new Hashtable();
    //                        }
    //                        ////////getting the pointer to the Session of the current logged in user
    //                        // HttpSessionState existingUserSession = (HttpSessionState)sessions[Session["EmpolyeeID"].ToString()];
    //                        HttpSessionState existingUserSession = (HttpSessionState)sessions[ViewState["EmpolyeeID"].ToString()];
    //                        if (existingUserSession != null)
    //                        {
    //                            ////existingUserSession[Session["EmpolyeeID"].ToString()] = null;
    //                            //logout current logged in user
    //                            //lblError1.Visible = true;
    //                            WebMsg.Show("This user is already logged in");
    //                        }
    //                        else
    //                        {
    //                            yourLoginMethod(UserInfo);
    //                            ProceedToRedirectPage(UserInfo);
    //                        }
    //                    }
    //                    else
    //                    {
    //                        yourLoginMethod(UserInfo);
    //                        ProceedToRedirectPage(UserInfo);
    //                    }
    //                }
    //            }
    //            else
    //            {
    //                TrackLog_Utils.Log(Convert.ToInt32(AppSessions.SchoolID), Convert.ToInt32(AppSessions.EmpolyeeID), Convert.ToInt16(AppSessions.DivisionID), "LoginPage", "btnLogin", "Click", Convert.ToDateTime(System.DateTime.Now), HttpContext.Current.Session.SessionID, StringEnum.stringValueOf(EnumFile.Activity.LoginFailed), "LoginId: " + txtUserName.Text + " , Password: " + txtUserPassword.Text, 0);
    //                WebMsg.Show("Authentication Failed,unable to login");
    //            }

    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        WebMsg.Show(ex.Message);
    //    }
    //}

    void yourLoginMethodStudent(DataTable UserInfo)
    {
        //put your login logic here and put the logged in user object in the session.
        //getting the sessions objects from the Application
        Hashtable sessions = (Hashtable)Application["WEB_SESSIONS_OBJECT"];
        if (sessions == null)
        {
            sessions = new Hashtable();
        }

        ////////getting the pointer to the Session of the current logged in user
        ////////////HttpSessionState existingUserSession =
        ////////////     (HttpSessionState)sessions[Session["EmpolyeeID"].ToString()]; if (existingUserSession != null)
        ////////////{
        ////////////    existingUserSession["EmpolyeeID"] = null;
        ////////////    //logout current logged in user
        ////////////}

        //putting the user in the session
        Session["StudentID"] = UserInfo.Rows[0]["StudentID"].ToString();

        //sessions[Session["EmpolyeeID"].ToString()] = Session;
        sessions[Session["StudentID"].ToString()] = Session;
        Application.Lock(); //lock to prevent duplicate objects
        Application["WEB_SESSIONS_OBJECT"] = sessions;
        Application.UnLock();
    }

    protected void btnSubFrgtpswd_Click(object sender, EventArgs e)
    {
        //Response.Redirect("~/ForgetPassword.aspx");
        mpForget.Show();
    }
    protected void BttnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet ds = new DataSet();
            Employee = new Employee();
            BAL_Forgetpassword = new Teacher_Dashboard_BLogic();
            Employee.emailid = txtEmail.Text;
            ArrayList arrParameter = new ArrayList();
            string subjectEmail = "Login Information";
            arrParameter.Add(txtEmail.Text);
            ds = BAL_Forgetpassword.BAL_Emailid_Select(Employee);
            ViewState["PasswordData"] = ds;
            if (ds.Tables.Count > 0 & ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (EmailUtility.SendEmail(arrParameter, subjectEmail, GenerateEmailBody()))
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Password has been sent to your email successfully.');window.location ='Login.aspx';", true);
                        ClearControls();
                    }
                    else
                    {
                        WebMsg.Show("Email Failed");
                        ClearControls();
                    }
                }
                else if (ds.Tables[1].Rows.Count > 0)
                {
                    if (EmailUtility.SendEmail(arrParameter, subjectEmail, GenerateEmailBody()))
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Password has been sent to your email successfully.');window.location ='Login.aspx';", true);
                        ClearControls();
                    }
                    else
                    {
                        WebMsg.Show("Email Failed");
                        ClearControls();
                    }
                }
                else
                {
                    WebMsg.Show("Invalid Email");
                    ClearControls();
                }
            }
            else
            {
                WebMsg.Show("Invalid Email");
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }
    protected string GenerateEmailBody()
    {
        DataSet ds = new DataSet();
        string Body = string.Empty;
        ds = (DataSet)ViewState["PasswordData"];
        try
        {
            string Pwd = ds.Tables[0].Rows[0]["Password"].ToString();
            char[] separator = new char[] { '@' };
            string[] strSplitArr = txtEmail.Text.Split(separator);
            string username = strSplitArr[0];

            Body = "<b>Hello &nbsp;" + username + ",<b/><br/><br/>";

            Body += "<b>Date:<b/>" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "<br/";
            Body += "<b>Email:<b/>" + txtEmail.Text + "<br/>";
            Body += "<b>Password:<b/>" + Pwd + "<br/><br/><br/>";

            Body += "<b>Thank You,<b/><br/>";
            Body += "<b>" + EmailUtility.USERNAME + "<b/>";
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
        return Body;
    }
    protected void ClearControls()
    {
        try
        {
            txtEmail.Text = string.Empty;
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }
    private void ProceedToRedirect()
    {        
        Response.Redirect("~/Dashboard/StudentDashboard.aspx", false);
        //Response.Redirect("Default3.aspx");
    }
    private void ProceedToRedirectParent()
    {
        Response.Redirect("~/Dashboard/ParentDashboard.aspx", false);
        //Response.Redirect("Default3.aspx");
    }
    void yourLoginMethod(DataTable UserInfo)
    {
        //put your login logic here and put the logged in user object in the session.

        //getting the sessions objects from the Application
        Hashtable sessions = (Hashtable)Application["WEB_SESSIONS_OBJECT"];
        if (sessions == null)
        {
            sessions = new Hashtable();
        }

        ////////getting the pointer to the Session of the current logged in user
        ////////////HttpSessionState existingUserSession =
        ////////////     (HttpSessionState)sessions[Session["EmpolyeeID"].ToString()]; if (existingUserSession != null)
        ////////////{
        ////////////    existingUserSession["EmpolyeeID"] = null;
        ////////////    //logout current logged in user
        ////////////}

        //putting the user in the session
        Session["EmpolyeeID"] = UserInfo.Rows[0]["EmployeeID"].ToString();

        //sessions[Session["EmpolyeeID"].ToString()] = Session;
        sessions[Session["EmpolyeeID"].ToString()] = Session;
        Application.Lock(); //lock to prevent duplicate objects
        Application["WEB_SESSIONS_OBJECT"] = sessions;
        Application.UnLock();
    }
    protected void btnClose_Click(object sender, EventArgs e)
    {
        mp1.Hide();
    }
    protected void btnOk_Click(object sender, EventArgs e)
    {
    }

    //protected override void InitializeCulture()
    //{
    //    if (ViewState["A"] != null)
    //    {
    //        String selectedLanguage = ViewState["A"].ToString();
    //        this.UICulture = selectedLanguage;
    //        this.Culture = selectedLanguage;

    //        Session[Global.SESSION_KEY_CULTURE] = selectedLanguage;
    //        Session["LANG"] = selectedLanguage;
    //        System.Threading.Thread.CurrentThread.CurrentCulture =
    //        CultureInfo.CreateSpecificCulture(selectedLanguage);
    //        System.Threading.Thread.CurrentThread.CurrentUICulture = new
    //        CultureInfo(selectedLanguage);
    //    }
    //    else
    //    {
    //        if (Request.Form["ddlLanguage"] != null)
    //        {
    //            String selectedLanguage = Request.Form["ddlLanguage"];
    //            this.UICulture = selectedLanguage;
    //            this.Culture = selectedLanguage;
    //            Session[Global.SESSION_KEY_CULTURE] = selectedLanguage;
    //            Session["LANG"] = selectedLanguage;
    //            System.Threading.Thread.CurrentThread.CurrentCulture =
    //            CultureInfo.CreateSpecificCulture(selectedLanguage);
    //            System.Threading.Thread.CurrentThread.CurrentUICulture = new
    //            CultureInfo(selectedLanguage);
    //        }
    //    }
    //    base.InitializeCulture();

    //}

    #region DropDown Events
    protected void ddlBoard_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlBoard.SelectedIndex > ((int)EnumFile.AssignValue.Zero))
        {
            string BMS = ddlBoard.SelectedItem.Text;
            string[] Split = Regex.Split(BMS, ">>");
            string Medium = Split[1];
            if (Medium == " Gujarati Medium ")
            {
                ViewState["A"] = "gu-IN";
            }
            else if (Medium == " English Medium ")
            {
                ViewState["A"] = "en-US";
            }
            else if (Medium == " Hindi Medium ")
            {
                ViewState["A"] = "hi-IN";
            }
            //this.InitializeCulture();

            DropDownList[] disddl = { ddlSubject, ddlDivision };
            DisableDropDwon(disddl);

            obj_BAL_SYS_Role = new SYS_Role_BLogic();
            Int64 BMSID = Convert.ToInt64(ddlBoard.SelectedValue);
            DataSet dsSelect = new DataSet();
            dsSelect = obj_BAL_SYS_Role.BAL_Allocated_Subject_Div_BasedonBMS(BMSID, Convert.ToInt64(ViewState["EmpolyeeID"]));
            Session["BMSID"] = BMSID;
            Session["subjectList"] = dsSelect;
            if (dsSelect.Tables.Count > ((int)EnumFile.AssignValue.Zero))
            {
                ddlSubject.DataSource = dsSelect.Tables[0];
                ddlSubject.DataTextField = "Subject";
                ddlSubject.DataValueField = "SubjectID";
                ddlSubject.DataBind();
                ddlSubject.Items.Insert(((int)EnumFile.AssignValue.Zero), new ListItem("-- Select --"));

                ddlDivision.DataSource = dsSelect.Tables[1];
                ddlDivision.DataTextField = "Division";
                ddlDivision.DataValueField = "DivisionID";
                ddlDivision.DataBind();
                ddlDivision.Items.Insert(((int)EnumFile.AssignValue.Zero), new ListItem("-- Select --"));

                DropDownList[] disddl1 = { ddlSubject, ddlDivision };
                EnableDropDwon(disddl1);
            }
        }
        else
        {
            DropDownList[] disddl = { ddlSubject, ddlDivision };
            DisableDropDwon(disddl);
        }
    }
    #endregion
    public void DisableDropDwon(DropDownList[] disddl)
    {
        foreach (DropDownList dl in disddl)
        {
            dl.Enabled = false;
            dl.SelectedIndex = ((int)EnumFile.AssignValue.Zero);
        }
    }

    public void EnableDropDwon(DropDownList[] disddl)
    {
        foreach (DropDownList dl in disddl)
        {
            dl.Enabled = true;
            dl.SelectedIndex = ((int)EnumFile.AssignValue.Zero);
        }
    }
    public void FillDdls()
    {
        obj_SYS_Role = new SYS_Role();
        obj_BAL_SYS_Role = new SYS_Role_BLogic();

        DataSet dsSelect = new DataSet();

        // dsSelect = obj_BAL_SYS_Role.BAL_Select_Employee_BMS_SelectAll(Convert.ToInt64(Session["EmpolyeeID"]));

        dsSelect = obj_BAL_SYS_Role.BAL_Select_Employee_BMS_SelectAll(Convert.ToInt64(ViewState["EmpolyeeID"]));

        if (dsSelect.Tables.Count > ((int)EnumFile.AssignValue.Zero))
        {
            Session["ds_BMS"] = dsSelect;
            ddlBoard.DataSource = dsSelect.Tables[0];
            ddlBoard.DataTextField = "BMS";
            ddlBoard.DataValueField = "BMSID";
            ddlBoard.DataBind();
            ddlBoard.Items.Insert(((int)EnumFile.AssignValue.Zero), new ListItem("-- Select --"));
        }
        //mp1.Show();
        //upSelectBMS.Update();
        ddlSubject.SelectedIndex = ((int)EnumFile.AssignValue.Zero);
        ddlSubject.Enabled = false;
        ddlDivision.SelectedIndex = ((int)EnumFile.AssignValue.Zero);
        ddlDivision.Enabled = false;
    }
    private void ProceedToRedirectPage(DataTable UserInfo)
    {
        try
        {
            if (UserInfo.Rows[0]["RoleID"].ToString().Equals(Convert.ToString((int)EnumFile.Role.E_Admin))) // Epath Admin
            {
                string ID = string.Empty;
                if (Request["ID"] != null)
                {
                    ID = Request["ID"].ToString();
                }
                if (ID != string.Empty)
                {
                    Response.Redirect("~/Admin/Rescheduling.aspx?ID=" + ID);
                }
                else
                {
                    Response.Redirect("~/Dashboard/EpathAdminDashboard.aspx");
                }
            }
            else if (UserInfo.Rows[0]["RoleID"].ToString().Equals(Convert.ToString((int)EnumFile.Role.S_Admin))) // School Admin
            {

                Response.Redirect("~/Dashboard/SchoolAdminDashboard.aspx");
            }
            else if (UserInfo.Rows[0]["RoleID"].ToString().Equals(Convert.ToString((int)EnumFile.Role.Teacher))) // Teacher
            {
                FillDdls();

                string EmployeeID = ViewState["EmpolyeeID"].ToString();

                if (Request.Cookies[EmployeeID + "TeacherDropDown"] != null)
                {
                    string MyVal;
                    if (Request.Cookies[EmployeeID + "TeacherDropDown"]["BoardVal"] != null)
                    {
                        MyVal = Request.Cookies[EmployeeID + "TeacherDropDown"]["BoardVal"];
                        ddlBoard.SelectedValue = MyVal;

                        if (Request.Cookies[EmployeeID + "TeacherDropDown"]["SubjectVal"] != null)
                        {
                            Int64 BMSID = Convert.ToInt64(ddlBoard.SelectedValue);
                            Int64 EmpID = Convert.ToInt64(ViewState["EmpolyeeID"]);

                            DataSet dsSelect = new DataSet();

                            dsSelect = obj_BAL_SYS_Role.BAL_Allocated_Subject_Div_BasedonBMS(BMSID, EmpID);
                            Session["subjectList"] = dsSelect;
                            if (dsSelect.Tables.Count > ((int)EnumFile.AssignValue.Zero))
                            {
                                ddlSubject.DataSource = dsSelect.Tables[0];
                                ddlSubject.DataTextField = "Subject";
                                ddlSubject.DataValueField = "SubjectID";
                                ddlSubject.DataBind();
                                ddlSubject.Items.Insert(((int)EnumFile.AssignValue.Zero), new ListItem("-- Select --"));

                                ddlDivision.DataSource = dsSelect.Tables[1];
                                ddlDivision.DataTextField = "Division";
                                ddlDivision.DataValueField = "DivisionID";
                                ddlDivision.DataBind();
                                ddlDivision.Items.Insert(((int)EnumFile.AssignValue.Zero), new ListItem("-- Select --"));

                                Session["BMSID"] = BMSID;

                                ddlBoard.Enabled = true;
                                ddlSubject.Enabled = true;
                                ddlDivision.Enabled = true;

                                MyVal = Request.Cookies[EmployeeID + "TeacherDropDown"]["SubjectVal"];
                                ddlSubject.SelectedValue = MyVal;

                                if (Request.Cookies[EmployeeID + "TeacherDropDown"]["DivisionVal"] != null)
                                {
                                    MyVal = Request.Cookies[EmployeeID + "TeacherDropDown"]["DivisionVal"];
                                    ddlDivision.SelectedValue = MyVal;
                                    RedirectToTeacherDashboard("CookiesSet");
                                }
                                else
                                {
                                    RedirectToTeacherDashboard("CookiesNotSet");
                                }
                            }
                            else
                            {
                                RedirectToTeacherDashboard("CookiesNotSet");
                            }
                        }
                        else
                        {
                            RedirectToTeacherDashboard("CookiesNotSet");
                        }
                    }
                    else
                    {
                        RedirectToTeacherDashboard("CookiesNotSet");
                    }
                }
                else
                {
                    RedirectToTeacherDashboard("CookiesNotSet");
                }
            }
            else if (UserInfo.Rows[0]["RoleID"].ToString().Equals(Convert.ToString((int)EnumFile.Role.Student))) // Student
            {
                Response.Redirect("~/Dashboard/StudentDashboard.aspx", false);
            }
            else if (UserInfo.Rows[0]["RoleID"].ToString().Equals(Convert.ToString((int)EnumFile.Role.Parent))) // Parent
            {
                Response.Redirect("~/Dashboard/ParentDashboard.aspx", false);
            }
        }
        catch (Exception ex)
        {
        }
    }

    private void RedirectToTeacherDashboard(string cookiesstatus)
    {
        try
        {
            if (Session["UserInfoTable"] != null)
            {
                DataTable dtUsetInfo = new DataTable();
                dtUsetInfo = (DataTable)Session["UserInfoTable"];
                AppSessions.AppUserType = "School";
                AppSessions.EmpolyeeID = int.Parse(dtUsetInfo.Rows[0]["EmployeeID"].ToString());
                AppSessions.RoleID = int.Parse(dtUsetInfo.Rows[0]["RoleID"].ToString());
                AppSessions.SchoolID = int.Parse(dtUsetInfo.Rows[0]["SchoolID"].ToString());
                AppSessions.UserName = dtUsetInfo.Rows[0]["FirstName"].ToString();
                AppSessions.SchoolName = dtUsetInfo.Rows[0]["Name"].ToString();
                AppSessions.Role = dtUsetInfo.Rows[0]["Role"].ToString();
                AppSessions.IsAllowSendEmail = (!dtUsetInfo.Columns.Contains("AllowSendEmail") ? false : Convert.ToBoolean(Convert.ToString(dtUsetInfo.Rows[0]["AllowSendEmail"])));
            }
            if (cookiesstatus == "CookiesSet")
            {
                AppSessions.BoardID = int.Parse(ddlBoard.SelectedValue);
                AppSessions.Board = ddlBoard.SelectedItem.Text;
                AppSessions.SubjectID = int.Parse(ddlSubject.SelectedValue);
                AppSessions.Subject = ddlSubject.SelectedItem.Text;
                AppSessions.DivisionID = int.Parse(ddlDivision.SelectedValue);
                AppSessions.Division = ddlDivision.SelectedItem.Text;

                HttpCookie myCookie = new HttpCookie(Convert.ToString(AppSessions.EmpolyeeID) + "TeacherDropDown");
                myCookie["BoardVal"] = ddlBoard.SelectedValue;
                myCookie["SubjectVal"] = ddlSubject.SelectedValue;
                myCookie["DivisionVal"] = ddlDivision.SelectedValue;
                myCookie.Expires = DateTime.Now.AddDays(7);
                Response.Cookies.Add(myCookie);

                TrackLog_Utils.Log(Convert.ToInt32(AppSessions.SchoolID), Convert.ToInt32(AppSessions.EmpolyeeID), Convert.ToInt16(AppSessions.DivisionID), "LoginMasterPage.master", "btnOk", "Click", Convert.ToDateTime(System.DateTime.Now), HttpContext.Current.Session.SessionID, StringEnum.stringValueOf(EnumFile.Activity.ActivitySelected), "BMS ID: " + AppSessions.BoardID.ToString() + ", BMS: " + AppSessions.Board + " , DivisionID: " + AppSessions.DivisionID + ", Division : " + AppSessions.Division + " , SubjectID: " + AppSessions.SubjectID + ", Subject : " + AppSessions.Subject + " , Teacher : " + AppSessions.UserName, 0);

                Response.Redirect("~/Dashboard/TeacherDashboard.aspx");
            }
            else if (cookiesstatus == "CookiesNotSet")
            {
                Response.Redirect("~/Dashboard/TeacherDashboard.aspx");
            }
        }
        catch (Exception)
        {
        }
    }

    protected void lblDashboard_Click(object sender, EventArgs e)
    {
        if (AppSessions.RoleID == 0)
        {
            msg = lblerrMsg.Text;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Message", "<script> alert('" + msg + "')</script>", false);
            txtUserName.Focus();
        }
    }
    protected void lblRescheduling_Click(object sender, EventArgs e)
    {
        if (AppSessions.RoleID == 0)
        {
            msg = lblerrMsg.Text;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Message", "<script> alert('" + msg + "')</script>", false);
            txtUserName.Focus();
        }
    }
    protected void lblFeedback_Click(object sender, EventArgs e)
    {
        if (AppSessions.RoleID == 0)
        {
            msg = lblerrMsg.Text;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Message", "<script> alert('" + msg + "')</script>", false);
            txtUserName.Focus();
        }
    }
    protected void lblReport_Click(object sender, EventArgs e)
    {
        if (AppSessions.RoleID == 0)
        {
            msg = lblerrMsg.Text;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Message", "<script> alert('" + msg + "')</script>", false);
            txtUserName.Focus();
        }
    }
    protected void lblHome_Click(object sender, EventArgs e)
    {
        Response.Redirect("Index.aspx");
    }
    protected void lblContactUs_Click(object sender, EventArgs e)
    {
        Response.Redirect("ContactUs.aspx");
    }
    private void SetOfferText()
    {
        Common_Blogic obj_Common_Blogic = new Common_Blogic();
        DataSet ods = obj_Common_Blogic.BAL_Select_offer();

        if (ods != null && ods.Tables.Count > 0)
        {
            string s1 = string.Empty;
            foreach (DataRow oDr in ods.Tables[0].Rows)
            {
                if (!string.IsNullOrEmpty(Convert.ToString(oDr["OfferLink"])))
                    s1 += "<a href='" + Convert.ToString(oDr["OfferLink"]) + "' target='_blank' style='font-size: large;color:white;font-family:cambria;font-weight:bold; font-style: normal; padding-right:100px;'>" + Convert.ToString(oDr["OfferDisplayText"]) + "</a>";
                else
                    s1 += "<span style='font-size: large;font-weight:bold; font-style: normal; padding-right:100px;color:white;font-family:cambria;'>" + Convert.ToString(oDr["OfferDisplayText"]) + "</span>";
            }
            ltmarquee.Text = s1;
        }
    }
    private void SetQuoteText()
    {
        //TODO : Add Quotes Coding Here..... PENDING...

        DataAccess oDA = new DataAccess();
        ArrayList arrparam = new ArrayList();
        arrparam.Add(new parameter("flag", "SS"));

        DataSet dsQOD = oDA.DAL_Select("tblQuote_GetQuote", arrparam);
        if ((dsQOD != null && dsQOD.Tables.Count > 0) && (dsQOD.Tables[0] != null && dsQOD.Tables[0].Rows.Count > 0))
        {
            if (dsQOD.Tables[0].Rows[0][0].Equals("FALSE"))
            {
                divQuote.Style.Add("display", "none");
                //divQuote.Visible = false;
            }
            else
            {
                DataTable dtQOD = dsQOD.Tables[0];
                if (dtQOD.Rows.Count > 0)
                {
                    divQuote.Style.Remove("display");
                    divQuote.Visible = true;
                    string s1 = string.Empty;
                    s1 += "<span style='font-size: large;font-weight:Normal; font-style: normal; padding-right:100px;color:white;font-family:cambria;'>" + Convert.ToString(dtQOD.Rows[0]["QuoteText"]) + " - " + Convert.ToString(dtQOD.Rows[0]["ByWhom"]) + "</span>";
                    ltQuotes.Text = s1;
                }
            }
        }
        //Common_Blogic obj_Common_Blogic = new Common_Blogic();
        //DataSet ods = obj_Common_Blogic.BAL_Select_offer();

        //if (ods != null && ods.Tables.Count > 0)
        //{
        //    string s1 = string.Empty;
        //    foreach (DataRow oDr in ods.Tables[0].Rows)
        //    {
        //        s1 += "<span style='font-size: large;font-weight:bold; font-style: normal; padding-right:100px;color:white;font-family:cambria;'>" + Convert.ToString(oDr["OfferDisplayText"]) + "</span>";
        //    }
        //ltQuotes.Text = s1;
        //}
    }
   
    protected void btnGo_Click(object sender, EventArgs e)
    {
        try
        {
            StoreCookie();

            int status = CheckLogin();
            //if (ddlUserType.SelectedValue == "0")
            if (status == 2)
            {
                WebMsg.Show("invalid username or password");
                return;
            }
            else if (status == 0)
            {
                // 0 Indicates Student

                StudentDash = new StudentDash();
                BLogic_Student = new Student_DashBoard_BLogic();

                DataSet dtLogin = new DataSet();
                DataTable LoginInfo = new DataTable();
                DataTable UserInfo = new DataTable();

                obj_SYS_Role = new SYS_Role();
                obj_BAL_SYS_Role = new SYS_Role_BLogic();
                obj_SYS_Role.Username = txtUserName.Text;
                obj_SYS_Role.Password = txtUserPassword.Text;
                //obj_SYS_Role.roleid = Convert.ToInt16(DdlRole.SelectedValue);

                dtLogin = obj_BAL_SYS_Role.BAL_SYS_Student_Login(obj_SYS_Role);
                LoginInfo = dtLogin.Tables[0];
                if (LoginInfo.Rows.Count > 0 && LoginInfo != null)
                {
                    AppSessions.AppUserType = "Student";

                    AppSessions.StudentID = Convert.ToInt32(LoginInfo.Rows[0]["StudentID"].ToString());
                    AppSessions.UserName = LoginInfo.Rows[0]["FirstName"].ToString();

                    AppSessions.BMSID = Convert.ToInt32(LoginInfo.Rows[0]["BMSID"].ToString());
                    AppSessions.BMS = LoginInfo.Rows[0]["BMS"].ToString();

                    AppSessions.BoardID = Convert.ToInt32(LoginInfo.Rows[0]["BoardID"].ToString());
                    AppSessions.Board = LoginInfo.Rows[0]["Board"].ToString();

                    AppSessions.MediumID = Convert.ToInt32(LoginInfo.Rows[0]["MediumID"].ToString());
                    AppSessions.Medium = LoginInfo.Rows[0]["Medium"].ToString();

                    AppSessions.StandardID = Convert.ToInt32(LoginInfo.Rows[0]["StandardID"].ToString());
                    AppSessions.Standard = LoginInfo.Rows[0]["Standard"].ToString();

                    AppSessions.DivisionID = Convert.ToInt32(LoginInfo.Rows[0]["DivisionID"].ToString());
                    //AppSessions.Division = LoginInfo.Rows[0]["Division"].ToString();

                    AppSessions.SchoolID = Convert.ToInt32(LoginInfo.Rows[0]["SchoolID"].ToString());
                    //AppSessions.SchoolName = LoginInfo.Rows[0]["SchoolName"].ToString();

                    AppSessions.Role = LoginInfo.Rows[0]["Role"].ToString();
                    AppSessions.RoleID = Convert.ToInt32(LoginInfo.Rows[0]["RoleID"].ToString());

                    //AppSessions.EmailID = Convert.ToString(LoginInfo.Rows[0]["EmailID"]);

                    //yourLoginMethodStudent(LoginInfo);
                    bool AllowMultipleSession = false;
                    AllowMultipleSession = Convert.ToBoolean(LoginInfo.Rows[0]["AllowMultipleSession"].ToString());


                    if (AllowMultipleSession == false)
                    {
                        Hashtable sessions = (Hashtable)Application["WEB_SESSIONS_OBJECT"];
                        if (sessions == null)
                        {
                            sessions = new Hashtable();
                        }

                        HttpSessionState existingUserSession = (HttpSessionState)sessions[Session["StudentID"].ToString()];
                        if (existingUserSession != null)
                        {
                            TrackLog_Utils.Log(Convert.ToInt32(AppSessions.SchoolID), Convert.ToInt32(AppSessions.EmployeeOrStudentID), Convert.ToInt16(AppSessions.DivisionID), "Login", "btnLogin", "Click", Convert.ToDateTime(System.DateTime.Now), HttpContext.Current.Session.SessionID, StringEnum.stringValueOf(EnumFile.Activity.UserAlreadyLoggedIn), "LoginId: " + txtUserName.Text, 0);
                            ////existingUserSession[Session["EmpolyeeID"].ToString()] = null;
                            //logout current logged in user
                            WebMsg.Show("you are already logged in.");
                            lblError1.Visible = true;
                            return;
                        }
                    }

                    ////////getting the pointer to the Session of the current logged in user
                    yourLoginMethodStudent(LoginInfo);
                    ProceedToRedirectPage(LoginInfo);

                    bool AllowPayment = false;
                    DataSet dsPaymentInfo = new DataSet();
                    dsPaymentInfo = BLogic_Student.BAL_Select_PaymentPagesInfo("Payment");
                    if (dsPaymentInfo != null & dsPaymentInfo.Tables.Count > 0)
                    {
                        if (dsPaymentInfo.Tables[0].Rows.Count > 0)
                        {
                            string a = dsPaymentInfo.Tables[0].Rows[0]["value"].ToString();
                            if (a == "0")
                            {
                                AllowPayment = false;
                            }
                            else
                            {
                                AllowPayment = true;
                            }
                        }
                    }

                    DataSet ds = new DataSet();
                    StudentDash.StudentID = AppSessions.StudentID;
                    //ds = BLogic_Student.BAL_Validate_Student(StudentDash);
                    ds = BLogic_Student.BAL_Validate_Student_Package(StudentDash);
                    TrackLog_Utils.Log(Convert.ToInt32(AppSessions.SchoolID), Convert.ToInt32(AppSessions.EmployeeOrStudentID), Convert.ToInt16(AppSessions.DivisionID), "Login", "btnLogin", "Click", Convert.ToDateTime(System.DateTime.Now), HttpContext.Current.Session.SessionID, StringEnum.stringValueOf(EnumFile.Activity.LoginSuccess), "LoginId: " + txtUserName.Text, 0);

                    if (AllowPayment == true)
                    {
                        //Session["ShowPaymentPages"] = "yes";
                        if (ds != null && dtLogin.Tables.Count > 0)
                        {
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                Session["CheckValidity"] = "Yes";
                                ProceedToRedirect();
                            }
                            else
                            {
                                Response.Redirect("~/DashBoard/SelectPackage.aspx", false);
                                TrackLog_Utils.Log(Convert.ToInt32(AppSessions.SchoolID), Convert.ToInt32(AppSessions.EmployeeOrStudentID), Convert.ToInt16(AppSessions.DivisionID), "Login", "btnLogin", "Click", Convert.ToDateTime(System.DateTime.Now), HttpContext.Current.Session.SessionID, StringEnum.stringValueOf(EnumFile.Activity.PackageSelection), "LoginId: " + txtUserName.Text, 0);
                                
                            }
                        }
                        else
                        {
                            Response.Redirect("~/DashBoard/SelectPackage.aspx", false);
                            TrackLog_Utils.Log(Convert.ToInt32(AppSessions.SchoolID), Convert.ToInt32(AppSessions.EmployeeOrStudentID), Convert.ToInt16(AppSessions.DivisionID), "Login", "btnLogin", "Click", Convert.ToDateTime(System.DateTime.Now), HttpContext.Current.Session.SessionID, StringEnum.stringValueOf(EnumFile.Activity.PackageSelection), "LoginId: " + txtUserName.Text, 0);
                        }
                    }
                    else
                    {
                        Session["CheckValidity"] = "Yes";
                        Session["ShowPaymentPages"] = "No";
                        ProceedToRedirect();
                    }
                }
            }
            else if (status == 16)
            {
                // 0 Indicates Student

                StudentDash = new StudentDash();
                BLogic_Student = new Student_DashBoard_BLogic();

                DataSet dtLogin = new DataSet();
                DataTable LoginInfo = new DataTable();
                DataTable UserInfo = new DataTable();

                obj_SYS_Role = new SYS_Role();
                obj_BAL_SYS_Role = new SYS_Role_BLogic();
                obj_SYS_Role.Username = txtUserName.Text;
                obj_SYS_Role.Password = txtUserPassword.Text;
                //obj_SYS_Role.roleid = Convert.ToInt16(DdlRole.SelectedValue);

                dtLogin = obj_BAL_SYS_Role.BAL_SYS_Parent_Login(obj_SYS_Role);
                LoginInfo = dtLogin.Tables[0];
                if (LoginInfo.Rows.Count > 0 && LoginInfo != null)
                {
                    AppSessions.AppUserType = "PStudent";

                    AppSessions.StudentID = Convert.ToInt32(LoginInfo.Rows[0]["StudentID"].ToString());
                    AppSessions.UserName = LoginInfo.Rows[0]["FirstName"].ToString();

                    AppSessions.BMSID = Convert.ToInt32(LoginInfo.Rows[0]["BMSID"].ToString());
                    AppSessions.BMS = LoginInfo.Rows[0]["BMS"].ToString();

                    AppSessions.BoardID = Convert.ToInt32(LoginInfo.Rows[0]["BoardID"].ToString());
                    AppSessions.Board = LoginInfo.Rows[0]["Board"].ToString();

                    AppSessions.MediumID = Convert.ToInt32(LoginInfo.Rows[0]["MediumID"].ToString());
                    AppSessions.Medium = LoginInfo.Rows[0]["Medium"].ToString();

                    AppSessions.StandardID = Convert.ToInt32(LoginInfo.Rows[0]["StandardID"].ToString());
                    AppSessions.Standard = LoginInfo.Rows[0]["Standard"].ToString();

                    AppSessions.DivisionID = Convert.ToInt32(LoginInfo.Rows[0]["DivisionID"].ToString());
                    //AppSessions.Division = LoginInfo.Rows[0]["Division"].ToString();

                    AppSessions.SchoolID = Convert.ToInt32(LoginInfo.Rows[0]["SchoolID"].ToString());
                    //AppSessions.SchoolName = LoginInfo.Rows[0]["SchoolName"].ToString();

                    AppSessions.Role = LoginInfo.Rows[0]["Role"].ToString();
                    AppSessions.RoleID = Convert.ToInt32(LoginInfo.Rows[0]["RoleID"].ToString());

                    //AppSessions.EmailID = Convert.ToString(LoginInfo.Rows[0]["EmailID"]);

                    //yourLoginMethodStudent(LoginInfo);
                    bool AllowMultipleSession = false;
                    AllowMultipleSession = Convert.ToBoolean(LoginInfo.Rows[0]["AllowMultipleSession"].ToString());


                    if (AllowMultipleSession == false)
                    {
                        Hashtable sessions = (Hashtable)Application["WEB_SESSIONS_OBJECT"];
                        if (sessions == null)
                        {
                            sessions = new Hashtable();
                        }

                        HttpSessionState existingUserSession = (HttpSessionState)sessions[Session["StudentID"].ToString()];
                        if (existingUserSession != null)
                        {
                            TrackLog_Utils.Log(Convert.ToInt32(AppSessions.SchoolID), Convert.ToInt32(AppSessions.EmployeeOrStudentID), Convert.ToInt16(AppSessions.DivisionID), "Login", "btnLogin", "Click", Convert.ToDateTime(System.DateTime.Now), HttpContext.Current.Session.SessionID, StringEnum.stringValueOf(EnumFile.Activity.UserAlreadyLoggedIn), "LoginId: " + txtUserName.Text, 0);
                            ////existingUserSession[Session["EmpolyeeID"].ToString()] = null;
                            //logout current logged in user
                            WebMsg.Show("you are already logged in.");
                            lblError1.Visible = true;
                            return;
                        }
                    }

                    ////////getting the pointer to the Session of the current logged in user
                    yourLoginMethodStudent(LoginInfo);
                    ProceedToRedirectPage(LoginInfo);

                    bool AllowPayment = false;
                    DataSet dsPaymentInfo = new DataSet();
                    dsPaymentInfo = BLogic_Student.BAL_Select_PaymentPagesInfo("Payment");
                    if (dsPaymentInfo != null & dsPaymentInfo.Tables.Count > 0)
                    {
                        if (dsPaymentInfo.Tables[0].Rows.Count > 0)
                        {
                            string a = dsPaymentInfo.Tables[0].Rows[0]["value"].ToString();
                            if (a == "0")
                            {
                                AllowPayment = false;
                            }
                            else
                            {
                                AllowPayment = true;
                            }
                        }
                    }

                    DataSet ds = new DataSet();
                    StudentDash.StudentID = AppSessions.StudentID;
                    //ds = BLogic_Student.BAL_Validate_Student(StudentDash);
                    ds = BLogic_Student.BAL_Validate_Student_Package(StudentDash);
                    TrackLog_Utils.Log(Convert.ToInt32(AppSessions.SchoolID), Convert.ToInt32(AppSessions.EmployeeOrStudentID), Convert.ToInt16(AppSessions.DivisionID), "Login", "btnLogin", "Click", Convert.ToDateTime(System.DateTime.Now), HttpContext.Current.Session.SessionID, StringEnum.stringValueOf(EnumFile.Activity.LoginSuccess), "LoginId: " + txtUserName.Text, 0);

                    if (AllowPayment == true)
                    {
                        //Session["ShowPaymentPages"] = "yes";
                        if (ds != null && dtLogin.Tables.Count > 0)
                        {
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                Session["CheckValidity"] = "Yes";
                                ProceedToRedirectParent();
                            }
                            else
                            {
                                Response.Redirect("~/DashBoard/SelectPackage.aspx", false);
                                TrackLog_Utils.Log(Convert.ToInt32(AppSessions.SchoolID), Convert.ToInt32(AppSessions.EmployeeOrStudentID), Convert.ToInt16(AppSessions.DivisionID), "Login", "btnLogin", "Click", Convert.ToDateTime(System.DateTime.Now), HttpContext.Current.Session.SessionID, StringEnum.stringValueOf(EnumFile.Activity.PackageSelection), "LoginId: " + txtUserName.Text, 0);

                            }
                        }
                        else
                        {
                            Response.Redirect("~/DashBoard/SelectPackage.aspx", false);
                            TrackLog_Utils.Log(Convert.ToInt32(AppSessions.SchoolID), Convert.ToInt32(AppSessions.EmployeeOrStudentID), Convert.ToInt16(AppSessions.DivisionID), "Login", "btnLogin", "Click", Convert.ToDateTime(System.DateTime.Now), HttpContext.Current.Session.SessionID, StringEnum.stringValueOf(EnumFile.Activity.PackageSelection), "LoginId: " + txtUserName.Text, 0);
                        }
                    }
                    else
                    {
                        Session["CheckValidity"] = "Yes";
                        Session["ShowPaymentPages"] = "No";
                        ProceedToRedirectParent();
                    }
                }
            }

            //else if (ddlUserType.SelectedValue == "1")
            else if (status == 1)
            {
                // 1 Indicates Teacher
                DataSet dtLogin = new DataSet();
                DataTable LoginInfo = new DataTable();
                DataTable UserInfo = new DataTable();

                obj_SYS_Role = new SYS_Role();
                obj_BAL_SYS_Role = new SYS_Role_BLogic();
                obj_SYS_Role.Username = txtUserName.Text;
                obj_SYS_Role.Password = txtUserPassword.Text;
                //obj_SYS_Role.roleid = Convert.ToInt16(DdlRole.SelectedValue);

                dtLogin = obj_BAL_SYS_Role.BAL_SYS_Active_Login(obj_SYS_Role);
                LoginInfo = dtLogin.Tables[0];

                if (LoginInfo.Rows.Count > 0 && LoginInfo != null && LoginInfo.Rows[0]["Status"].ToString().Equals("1"))
                {
                    if (dtLogin.Tables[1].Rows[0]["RoleID"].ToString() != "3")
                    {
                        bool AllowMultipleSession = false;
                        UserInfo = dtLogin.Tables[1];
                        if (UserInfo.Rows.Count > 0 && UserInfo != null)
                        {

                            AppSessions.AppUserType = "School";
                            AppSessions.EmpolyeeID = int.Parse(UserInfo.Rows[0]["EmployeeID"].ToString());
                            AppSessions.RoleID = int.Parse(UserInfo.Rows[0]["RoleID"].ToString());
                            AppSessions.SchoolID = int.Parse(UserInfo.Rows[0]["SchoolID"].ToString());
                            AppSessions.UserName = UserInfo.Rows[0]["FirstName"].ToString();
                            AppSessions.SchoolName = UserInfo.Rows[0]["Name"].ToString();
                            AppSessions.Role = UserInfo.Rows[0]["Role"].ToString();

                            AllowMultipleSession = Convert.ToBoolean(UserInfo.Rows[0]["AllowMultipleSession"].ToString());
                            TrackLog_Utils.Log(Convert.ToInt32(AppSessions.SchoolID), Convert.ToInt32(AppSessions.EmpolyeeID), Convert.ToInt16(AppSessions.DivisionID), "LoginPage", "btnLogin", "Click", Convert.ToDateTime(System.DateTime.Now), HttpContext.Current.Session.SessionID, StringEnum.stringValueOf(EnumFile.Activity.LoginSuccess), "LoginId: " + txtUserName.Text, 0);
                        }

                        if (AllowMultipleSession == false)
                        {
                            Hashtable sessions = (Hashtable)Application["WEB_SESSIONS_OBJECT"];
                            if (sessions == null)
                            {
                                sessions = new Hashtable();
                            }

                            ////////getting the pointer to the Session of the current logged in user
                            HttpSessionState existingUserSession = (HttpSessionState)sessions[Session["EmpolyeeID"].ToString()];
                            if (existingUserSession != null)
                            {
                                ////existingUserSession[Session["EmpolyeeID"].ToString()] = null;
                                //logout current logged in user
                                lblError1.Visible = true;
                            }
                            else
                            {
                                yourLoginMethod(UserInfo);
                                ProceedToRedirectPage(UserInfo);
                            }
                        }
                        else
                        {
                            yourLoginMethod(UserInfo);
                            ProceedToRedirectPage(UserInfo);
                        }
                    }
                    else
                    {
                        // For Teacher Redirection

                        bool AllowMultipleSession = false;
                        UserInfo = dtLogin.Tables[1];
                        if (UserInfo.Rows.Count > 0 && UserInfo != null)
                        {
                            Session["UserInfoTable"] = UserInfo;

                            ViewState["AppUserType"] = "School";
                            ViewState["EmpolyeeID"] = int.Parse(UserInfo.Rows[0]["EmployeeID"].ToString());
                            ViewState["RoleID"] = int.Parse(UserInfo.Rows[0]["RoleID"].ToString());
                            ViewState["SchoolID"] = int.Parse(UserInfo.Rows[0]["SchoolID"].ToString());
                            ViewState["UserName"] = UserInfo.Rows[0]["FirstName"].ToString();
                            ViewState["SchoolName"] = UserInfo.Rows[0]["Name"].ToString();
                            ViewState["Role"] = UserInfo.Rows[0]["Role"].ToString();

                            AllowMultipleSession = Convert.ToBoolean(UserInfo.Rows[0]["AllowMultipleSession"].ToString());
                            TrackLog_Utils.Log(Convert.ToInt32(ViewState["SchoolID"]), Convert.ToInt32(ViewState["EmpolyeeID"]), Convert.ToInt16(AppSessions.DivisionID), "LoginMasterPage.master", "btnGo", "Click", Convert.ToDateTime(System.DateTime.Now), HttpContext.Current.Session.SessionID, StringEnum.stringValueOf(EnumFile.Activity.LoginSuccess), ViewState["UserName"] + " (" + txtUserName.Text + ") From " + ViewState["SchoolName"] + " school Logged in.", 0);
                        }

                        if (AllowMultipleSession == false)
                        {
                            Hashtable sessions = (Hashtable)Application["WEB_SESSIONS_OBJECT"];
                            if (sessions == null)
                            {
                                sessions = new Hashtable();
                            }
                            ////////getting the pointer to the Session of the current logged in user
                            // HttpSessionState existingUserSession = (HttpSessionState)sessions[Session["EmpolyeeID"].ToString()];
                            HttpSessionState existingUserSession = (HttpSessionState)sessions[ViewState["EmpolyeeID"].ToString()];
                            if (existingUserSession != null)
                            {
                                ////existingUserSession[Session["EmpolyeeID"].ToString()] = null;
                                //logout current logged in user
                                //lblError1.Visible = true;
                                WebMsg.Show("This user is already logged in");
                            }
                            else
                            {
                                yourLoginMethod(UserInfo);
                                ProceedToRedirectPage(UserInfo);
                            }
                        }
                        else
                        {
                            yourLoginMethod(UserInfo);
                            ProceedToRedirectPage(UserInfo);
                        }
                    }
                }
                else
                {
                    TrackLog_Utils.Log(Convert.ToInt32(AppSessions.SchoolID), Convert.ToInt32(AppSessions.EmpolyeeID), Convert.ToInt16(AppSessions.DivisionID), "LoginPage", "btnLogin", "Click", Convert.ToDateTime(System.DateTime.Now), HttpContext.Current.Session.SessionID, StringEnum.stringValueOf(EnumFile.Activity.LoginFailed), "LoginId: " + txtUserName.Text + " , Password: " + txtUserPassword.Text, 0);
                    WebMsg.Show("Authentication Failed,unable to login");
                }

            }
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }
}
