   using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Web.SessionState;
using System.Data;
using System.Text.RegularExpressions;

public partial class ResponsiveLogin : System.Web.UI.Page
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

    #region "Page Load"
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!IsPostBack)
        //{
        //GetBMS();
        AppSessions.RoleID = 0;
        //Session["LoginURl"] = Request.Url.AbsoluteUri;

        //if (ddlLanguage.SelectedValue.ToString().Equals("en-US"))
        //{
        //    Session["LANG"] = ddlLanguage.SelectedValue;
        //    Session["langid"] = ((int)EnumFile.Language.English).ToString();
        //}
        //else if (ddlLanguage.SelectedValue.ToString().Equals("gu-IN"))
        //{
        //    Session["LANG"] = ddlLanguage.SelectedValue;
        //    Session["langid"] = ((int)EnumFile.Language.Gujarati).ToString();
        //}
        //else if (ddlLanguage.SelectedValue.ToString().Equals("hi-IN"))
        //{
        //    Session["LANG"] = ddlLanguage.SelectedValue;
        //    Session["langid"] = ((int)EnumFile.Language.Hindi).ToString();
        //}

        if (Request.Cookies["loginCookie"] != null)
        {
            if (Request.Cookies["loginCookie"]["UserName"] != null)
            {
                txtUserName.Text = Request.Cookies["loginCookie"]["UserName"];
            }

            if (Request.Cookies["loginCookie"]["Password"] != null)
            {
                txtUserPassword.Text = Request.Cookies["loginCookie"]["Password"];
            }

            chkRememberMe.Checked = true;
        }
        //}
    }
    #endregion


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

    #region Control Events"
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

                    yourLoginMethodStudent(LoginInfo);

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
                   // ds = BLogic_Student.BAL_Validate_Student(StudentDash);
                    ds = BLogic_Student.BAL_Validate_Student_Package(StudentDash);


                    if (AllowPayment == true)
                    {
                        if (ds != null && dtLogin.Tables.Count > 0)
                        {
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                Session["CheckValidity"] = "Yes";
                                ProceedToRedirect();
                            }
                            else
                            {
                                Response.Redirect("~/DashBoard/SelectPackage.aspx");
                            }
                        }
                        else
                        {
                            Response.Redirect("~/DashBoard/SelectPackage.aspx");
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
                            // HttpSessionState existingUserSession = (HttpSessionState)sessions[Session["EmpolyeeID"].ToString()];
                            HttpSessionState existingUserSession = (HttpSessionState)sessions[ViewState["EmpolyeeID"].ToString()];
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
    protected void btnOk_Click(object sender, EventArgs e)
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
        this.InitializeCulture();


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
        }

        AppSessions.BoardID = int.Parse(ddlBoard.SelectedValue);
        AppSessions.Board = ddlBoard.SelectedItem.Text;
        AppSessions.SubjectID = int.Parse(ddlSubject.SelectedValue);
        AppSessions.Subject = ddlSubject.SelectedItem.Text;
        AppSessions.DivisionID = int.Parse(ddlDivision.SelectedValue);
        AppSessions.Division = ddlDivision.SelectedItem.Text;

        string EmpID = AppSessions.EmpolyeeID.ToString();

        HttpCookie myCookie = new HttpCookie(EmpID + "TeacherDropDown");
        myCookie["BoardVal"] = ddlBoard.SelectedValue;
        myCookie["SubjectVal"] = ddlSubject.SelectedValue;
        myCookie["DivisionVal"] = ddlDivision.SelectedValue;
        myCookie.Expires = DateTime.Now.AddDays(7);
        Response.Cookies.Add(myCookie);

        TrackLog_Utils.Log(Convert.ToInt32(AppSessions.SchoolID), Convert.ToInt32(AppSessions.EmpolyeeID), Convert.ToInt16(AppSessions.DivisionID), "LoginPage", "btnOk", "Click", Convert.ToDateTime(System.DateTime.Now), HttpContext.Current.Session.SessionID, StringEnum.stringValueOf(EnumFile.Activity.ActivitySelected), "BMS : " + AppSessions.Board + " , Division : " + AppSessions.Division + " , Subject : " + AppSessions.Subject + " , Teacher : " + AppSessions.UserName, 0);

        Response.Redirect("~/Dashboard/TeacherDashboard.aspx");
    }
    protected void btnClose_Click(object sender, EventArgs e)
    {
        mp1.Hide();
    }
    #endregion

    #region "User Defined Function"
    //protected void GetBMS()
    //{
    //    DropDownFill DdlFilling = new DropDownFill();
    //    DataSet dsBMS = new DataSet();
    //    dsBMS = BSysBMS.BAL_SYS_BMS_SelectAll();
    //    if (dsBMS.Tables[0].Rows.Count > 0)
    //    {
    //        DdlFilling.BindDropDownByTable(ddlBMS, dsBMS.Tables[0], "BMS", "BMSID");
    //        ddlBMS.Items.Insert(Convert.ToInt32(EnumFile.AssignValue.Zero), "-- Select --");
    //        ddlBMS.Items[0].Value = Convert.ToString((int)EnumFile.AssignValue.Zero);
    //        ddlBMS.Enabled = true;
    //    }
    //}
    private void ProceedToRedirect()
    {
        Response.Redirect("~/Dashboard/StudentDashboard.aspx",false);
        //Response.Redirect("Default3.aspx");
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
        //Session["EmpolyeeID"] = UserInfo.Rows[0]["EmployeeID"].ToString();
        //Session["StudentID"] = UserInfo.Rows[0]["StudentID"].ToString();

        ////sessions[Session["EmpolyeeID"].ToString()] = Session;
        ////sessions[Session["StudentID"].ToString()] = Session;

        //sessions[Session["EmpolyeeID"].ToString()] = Session;
        ////sessions[ViewState["EmpolyeeID"].ToString()] = Session;
        //Application.Lock(); //lock to prevent duplicate objects
        //Application["WEB_SESSIONS_OBJECT"] = sessions;
        //Application.UnLock();

        //Session["StudentID"] = UserInfo.Rows[0]["StudentID"].ToString();

        //putting the user in the session
        Session["EmpolyeeID"] = UserInfo.Rows[0]["EmployeeID"].ToString();

        sessions[Session["EmpolyeeID"].ToString()] = Session;
        //sessions[Session["StudentID"].ToString()] = Session;
        Application.Lock(); //lock to prevent duplicate objects
        Application["WEB_SESSIONS_OBJECT"] = sessions;
        Application.UnLock();
    }

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

    private void ProceedToRedirectPage(DataTable UserInfo)
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


            // string EmployeeID = AppSessions.EmpolyeeID.ToString();

            string EmployeeID = ViewState["EmpolyeeID"].ToString();



            if (Request.Cookies[EmployeeID + "TeacherDropDown"] != null)
            {
                string MyVal;
                if (Request.Cookies[EmployeeID + "TeacherDropDown"]["BoardVal"] != null)
                {
                    MyVal = Request.Cookies[EmployeeID + "TeacherDropDown"]["BoardVal"];
                    ddlBoard.SelectedValue = MyVal;
                }

                //if (Request.Cookies[EmployeeID + "TeacherDropDown"]["MediumVal"] != null)
                //{
                //    MyVal = Request.Cookies[EmployeeID + "TeacherDropDown"]["MediumVal"];
                //    ddlMedium.SelectedValue = MyVal;
                //}

                //if (Request.Cookies[EmployeeID + "TeacherDropDown"]["StandardVal"] != null)
                //{
                //    MyVal = Request.Cookies[EmployeeID + "TeacherDropDown"]["StandardVal"];
                //    ddlStandard.SelectedValue = MyVal;
                //}

                if (Request.Cookies[EmployeeID + "TeacherDropDown"]["SubjectVal"] != null)
                {
                    //Int16 BoardID = Convert.ToInt16(ddlBoard.SelectedValue);
                    //Int16 MediumID = Convert.ToInt16(ddlMedium.SelectedValue);
                    //Int16 StandardID = Convert.ToInt16(ddlStandard.SelectedValue);
                    Int64 BMSID = Convert.ToInt64(ddlBoard.SelectedValue);
                    //Int64 EmpID = Convert.ToInt64(Session["EmpolyeeID"]);
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

                        //Session["BMSID"] = dsSelect.Tables[2].Rows[0]["BMSID"].ToString();
                        Session["BMSID"] = BMSID;

                        ddlBoard.Enabled = true;
                        //ddlMedium.Enabled = true;
                        //ddlStandard.Enabled = true;
                        ddlSubject.Enabled = true;
                        ddlDivision.Enabled = true;
                    }
                    else
                    {
                        DropDownList[] disddl2 = { ddlSubject, ddlDivision };
                        DisableDropDwon(disddl2);
                    }

                    MyVal = Request.Cookies[EmployeeID + "TeacherDropDown"]["SubjectVal"];
                    ddlSubject.SelectedValue = MyVal;
                }

                if (Request.Cookies[EmployeeID + "TeacherDropDown"]["DivisionVal"] != null)
                {
                    MyVal = Request.Cookies[EmployeeID + "TeacherDropDown"]["DivisionVal"];
                    ddlDivision.SelectedValue = MyVal;
                }
            }
        }
        else if (UserInfo.Rows[0]["RoleID"].ToString().Equals(Convert.ToString((int)EnumFile.Role.Student))) // Student
        {
            Response.Redirect("~/Dashboard/StudentDashboard.aspx");
        }
    }
    public void DisableDropDwon(DropDownList[] disddl)
    {
        foreach (DropDownList dl in disddl)
        {
            dl.Enabled = false;
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
        mp1.Show();
        //upSelectBMS.Update();
        ddlSubject.SelectedIndex = ((int)EnumFile.AssignValue.Zero);
        ddlSubject.Enabled = false;
        ddlDivision.SelectedIndex = ((int)EnumFile.AssignValue.Zero);
        ddlDivision.Enabled = false;
    }
    #endregion

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
            this.InitializeCulture();

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
    public void EnableDropDwon(DropDownList[] disddl)
    {
        foreach (DropDownList dl in disddl)
        {
            dl.Enabled = true;
            dl.SelectedIndex = ((int)EnumFile.AssignValue.Zero);
        }
    }
    #endregion
}