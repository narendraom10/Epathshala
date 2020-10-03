using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
using System.Web.SessionState;

public partial class UserControl_LoginControl : System.Web.UI.UserControl
{
    SYS_Role obj_SYS_Role;
    SYS_Role_BLogic obj_BAL_SYS_Role;
    StudentDash StudentDash;
    Student_DashBoard_BLogic BLogic_Student;
    Employee OEmployee;
    Teacher_Dashboard_BLogic BAL_Forgetpassword;


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            uctxtUserName.Text = string.Empty;
            uctxtUserPassword.Text = string.Empty;
            ucinvalididpassword.Text = string.Empty;
            
            //uctxtUserPassword.Attributes.Add("onKeyPress", "javascript:if (event.keyCode == 13) __doPostBack('" + ucbtnGo.UniqueID + "','')");

            //uctxtUserName.Attributes.Add("onKeyPress", "javascript:if (event.keyCode == 13) __doPostBack('" + ucbtnGo.UniqueID + "','')");
            //    string strcurrentsession = HttpContext.Current.Session.SessionID;
            //    obj_BAL_SYS_Role = new SYS_Role_BLogic();

            //    DataSet dsLoginDetails = obj_BAL_SYS_Role.BAL_SYS_Select_IsLoggedIn(strcurrentsession);

            //    if ( Convert.ToInt32(dsLoginDetails.Tables[0].Rows[0]["SessionCount"]) > 0 )
            //    {
            //        Response.Redirect("../Dashboard/StudentDashboard.aspx");
            //    }
        }
    }


    protected void btnGo_Click(object sender, EventArgs e)
    {
        try
        {
            
            if (uctxtUserName.Text == string.Empty || uctxtUserPassword.Text == string.Empty)
            {
                WebMsg.Show("Please enter User ID and Password");
            }
            else
            {

                StoreCookie();

                int status = CheckLogin();
                //if (ddlUserType.SelectedValue == "0")
                if (status == 2)
                {
                    //WebMsg.Show("invalid username or password");
                    uctxtUserName.Text = string.Empty;
                    uctxtUserPassword.Text = string.Empty;
                    ucinvalididpassword.Text = "Invalid User ID or Password";
                    
                    //Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('FiveDot File uploaded successfully'); ", true);
                    
                    //Response.Write("<script>alert('my message');</script> ");
                    //ScriptManager.RegisterClientScriptBlock(ucbtnGo, this.GetType(), "Alert Message", "<script> alert('invalid username or password');</script>", true);
                    
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
                    obj_SYS_Role.Username = uctxtUserName.Text;
                    obj_SYS_Role.Password = uctxtUserPassword.Text;
                    //obj_SYS_Role.roleid = Convert.ToInt16(DdlRole.SelectedValue);
                    //if (uctxtEmail.Text != "" && uctxtpass.Text != "")
                    //{

                    dtLogin = obj_BAL_SYS_Role.BAL_SYS_Student_Login(obj_SYS_Role);
                    LoginInfo = dtLogin.Tables[0];
                    //}
                    if (LoginInfo.Rows.Count > 0 && LoginInfo != null)
                    {
                        AppSessions.AppUserType = "Student";

                        AppSessions.StudentID = Convert.ToInt32(LoginInfo.Rows[0]["StudentID"].ToString());
                        AppSessions.UserName = LoginInfo.Rows[0]["FirstName"].ToString();

                        AppSessions.LoginID = LoginInfo.Rows[0]["LoginID"].ToString();

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

                        AppSessions.IsFreePackage = IsFreePackage();


                        //AppSessions.EmailID = Convert.ToString(LoginInfo.Rows[0]["EmailID"]);

                        //yourLoginMethodStudent(LoginInfo);
                        bool AllowMultipleSession = false;
                        AllowMultipleSession = Convert.ToBoolean(LoginInfo.Rows[0]["AllowMultipleSession"].ToString());


                        //Hashtable sessions1 = (Hashtable)Application["WEB_SESSIONS_OBJECT"];
                        //HttpSessionState existingUserSession1 = (HttpSessionState)sessions1[Session["StudentID"].ToString()];
                        //if (existingUserSession1 != null)
                        //{
                        //    Response.Redirect("../Dashboard/StudentDashboard.aspx");
                        //}

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
                                ////existingUserSession[Session["EmpolyeeID"].ToString()] = null;
                                //logout current logged in user
                                Session["StudentID"] = null;
                                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", "<script>alert('You are already Logged In.')</script>", false);
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
                        TrackLog_Utils.Log(Convert.ToInt32(AppSessions.SchoolID), Convert.ToInt32(AppSessions.EmployeeOrStudentID), Convert.ToInt16(AppSessions.DivisionID), "Login", "btnLogin", "Click", Convert.ToDateTime(System.DateTime.Now), HttpContext.Current.Session.SessionID, StringEnum.stringValueOf(EnumFile.Activity.LoginSuccess), "LoginId: " + uctxtUserName.Text, 0);


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
                                    TrackLog_Utils.Log(Convert.ToInt32(AppSessions.SchoolID), Convert.ToInt32(AppSessions.EmployeeOrStudentID), Convert.ToInt16(AppSessions.DivisionID), "Login", "btnLogin", "Click", Convert.ToDateTime(System.DateTime.Now), HttpContext.Current.Session.SessionID, StringEnum.stringValueOf(EnumFile.Activity.PackageSelection), "LoginId: " + uctxtUserName.Text, 0);

                                }
                            }
                            else
                            {
                                Response.Redirect("~/DashBoard/SelectPackage.aspx", false);
                                TrackLog_Utils.Log(Convert.ToInt32(AppSessions.SchoolID), Convert.ToInt32(AppSessions.EmployeeOrStudentID), Convert.ToInt16(AppSessions.DivisionID), "Login", "btnLogin", "Click", Convert.ToDateTime(System.DateTime.Now), HttpContext.Current.Session.SessionID, StringEnum.stringValueOf(EnumFile.Activity.PackageSelection), "LoginId: " + uctxtUserName.Text, 0);

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

                //else if (ddlUserType.SelectedValue == "1")
                else if (status == 1)
                {
                    // 1 Indicates Teacher
                    DataSet dtLogin = new DataSet();
                    DataTable LoginInfo = new DataTable();
                    DataTable UserInfo = new DataTable();

                    obj_SYS_Role = new SYS_Role();
                    obj_BAL_SYS_Role = new SYS_Role_BLogic();
                    obj_SYS_Role.Username = uctxtUserName.Text;
                    obj_SYS_Role.Password = uctxtUserPassword.Text;
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
                                TrackLog_Utils.Log(Convert.ToInt32(AppSessions.SchoolID), Convert.ToInt32(AppSessions.EmpolyeeID), Convert.ToInt16(AppSessions.DivisionID), "LoginPage", "btnLogin", "Click", Convert.ToDateTime(System.DateTime.Now), HttpContext.Current.Session.SessionID, StringEnum.stringValueOf(EnumFile.Activity.LoginSuccess), "LoginId: " + uctxtUserName.Text, 0);
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
                                TrackLog_Utils.Log(Convert.ToInt32(ViewState["SchoolID"]), Convert.ToInt32(ViewState["EmpolyeeID"]), Convert.ToInt16(AppSessions.DivisionID), "LoginMasterPage.master", "ucbtnGo", "Click", Convert.ToDateTime(System.DateTime.Now), HttpContext.Current.Session.SessionID, StringEnum.stringValueOf(EnumFile.Activity.LoginSuccess), ViewState["UserName"] + " (" + uctxtUserName.Text + ") From " + ViewState["SchoolName"] + " school Logged in.", 0);
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
                        TrackLog_Utils.Log(Convert.ToInt32(AppSessions.SchoolID), Convert.ToInt32(AppSessions.EmpolyeeID), Convert.ToInt16(AppSessions.DivisionID), "LoginPage", "btnLogin", "Click", Convert.ToDateTime(System.DateTime.Now), HttpContext.Current.Session.SessionID, StringEnum.stringValueOf(EnumFile.Activity.LoginFailed), "LoginId: " + uctxtUserName.Text + " , Password: " + uctxtUserPassword.Text, 0);
                        WebMsg.Show("Authentication Failed,unable to login");
                    }
                }

                uctxtUserName.Text = string.Empty;
                uctxtUserPassword.Text = string.Empty;
            }
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }

    private void ProceedToRedirect()
    {
        Response.Redirect("~/Dashboard/StudentDashboard.aspx", false);
    }

    void yourLoginMethod(DataTable UserInfo)
    {
        try
        {
            Hashtable sessions = (Hashtable)Application["WEB_SESSIONS_OBJECT"];
            if (sessions == null)
            {
                sessions = new Hashtable();
            }
            Session["EmpolyeeID"] = UserInfo.Rows[0]["EmployeeID"].ToString();
            sessions[Session["EmpolyeeID"].ToString()] = Session;
            Application.Lock(); //lock to prevent duplicate objects
            Application["WEB_SESSIONS_OBJECT"] = sessions;
            Application.UnLock();
        }
        catch (Exception)
        {
        }
    }

    private void ProceedToRedirectPage(DataTable UserInfo)
    {
        /*  try
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
          }
          catch (Exception ex)
          {
          }
      }

      private void ProceedToRedirect()
      {
          Response.Redirect("~/Dashboard/StudentDashboard.aspx", false);
          //Response.Redirect("Default3.aspx");
      }
      void yourLoginMethod(DataTable UserInfo)
      {
          Hashtable sessions = (Hashtable)Application["WEB_SESSIONS_OBJECT"];
          try
          {
              if (sessions == null)
              {
                  sessions = new Hashtable();
              }
              Session["EmpolyeeID"] = UserInfo.Rows[0]["EmployeeID"].ToString();
              sessions[Session["EmpolyeeID"].ToString()] = Session;
              Application.Lock(); //lock to prevent duplicate objects
              Application["WEB_SESSIONS_OBJECT"] = sessions;
              Application.UnLock();
          }
          catch (Exception)
          {
            
            
          }*/


    }

    void yourLoginMethodStudent(DataTable UserInfo)
    {
        try
        {
            Hashtable sessions = (Hashtable)Application["WEB_SESSIONS_OBJECT"];
            if (sessions == null)
            {
                sessions = new Hashtable();
            }

            Session["StudentID"] = UserInfo.Rows[0]["StudentID"].ToString();

            sessions[Session["StudentID"].ToString()] = Session;
            Application.Lock(); //lock to prevent duplicate objects
            Application["WEB_SESSIONS_OBJECT"] = sessions;
            Application.UnLock();
        }
        catch (Exception)
        {


        }

    }

    protected void StoreCookie()
    {
        try
        {
            if (ucchkRememberMe.Checked == true)
            {
                HttpCookie loginCookie = new HttpCookie("loginCookie");
                loginCookie["UserName"] = uctxtUserName.Text;
                loginCookie["Password"] = uctxtUserPassword.Text;
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

    protected void btnSubFrgtpswd_Click(object sender, EventArgs e)
    {

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
                //AppSessions.BoardID = int.Parse(ddlBoard.SelectedValue);
                //AppSessions.Board = ddlBoard.SelectedItem.Text;
                //AppSessions.SubjectID = int.Parse(ddlSubject.SelectedValue);
                //AppSessions.Subject = ddlSubject.SelectedItem.Text;
                //AppSessions.DivisionID = int.Parse(ddlDivision.SelectedValue);
                //AppSessions.Division = ddlDivision.SelectedItem.Text;

                //HttpCookie myCookie = new HttpCookie(Convert.ToString(AppSessions.EmpolyeeID) + "TeacherDropDown");
                //myCookie["BoardVal"] = ddlBoard.SelectedValue;
                //myCookie["SubjectVal"] = ddlSubject.SelectedValue;
                //myCookie["DivisionVal"] = ddlDivision.SelectedValue;
                //myCookie.Expires = DateTime.Now.AddDays(7);
                //Response.Cookies.Add(myCookie);

                //TrackLog_Utils.Log(Convert.ToInt32(AppSessions.SchoolID), Convert.ToInt32(AppSessions.EmpolyeeID), Convert.ToInt16(AppSessions.DivisionID), "LoginMasterPage.master", "btnOk", "Click", Convert.ToDateTime(System.DateTime.Now), HttpContext.Current.Session.SessionID, StringEnum.stringValueOf(EnumFile.Activity.ActivitySelected), "BMS ID: " + AppSessions.BoardID.ToString() + ", BMS: " + AppSessions.Board + " , DivisionID: " + AppSessions.DivisionID + ", Division : " + AppSessions.Division + " , SubjectID: " + AppSessions.SubjectID + ", Subject : " + AppSessions.Subject + " , Teacher : " + AppSessions.UserName, 0);

                //Response.Redirect("~/Dashboard/TeacherDashboard.aspx");
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



    public int CheckLogin()
    {
        obj_SYS_Role = new SYS_Role();
        obj_BAL_SYS_Role = new SYS_Role_BLogic();
        obj_SYS_Role.Username = uctxtUserName.Text;
        obj_SYS_Role.Password = uctxtUserPassword.Text;

        DataSet dtLogin = new DataSet();
        DataTable LoginInfo = new DataTable();

        dtLogin = obj_BAL_SYS_Role.BAL_SYS_Check_Login(obj_SYS_Role);
        LoginInfo = dtLogin.Tables[0];

        int status = Convert.ToInt16(LoginInfo.Rows[0]["Status"].ToString());

        return status;

    }

    public void CheckSession()
    {
        DataSet dtLogin = new DataSet();
        DataTable LoginInfo = new DataTable();

        dtLogin = obj_BAL_SYS_Role.BAL_Select_Session_Details();

        //int status = Convert.ToInt16(LoginInfo.Rows[0]["Status"].ToString());
        //return status;

    }

    protected void BttnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet ds = new DataSet();
            OEmployee = new Employee();
            BAL_Forgetpassword = new Teacher_Dashboard_BLogic();
            OEmployee.emailid = uctxtEmail.Text;
            ArrayList arrParameter = new ArrayList();
            string subjectEmail = "Login Information";
            arrParameter.Add(uctxtEmail.Text);
            ds = BAL_Forgetpassword.BAL_Emailid_Select(OEmployee);
            ViewState["PasswordData"] = ds;
            if (ds.Tables.Count > 0 & ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (EmailUtility.SendEmail(arrParameter, subjectEmail, GenerateMailBodyForgetPassword()))
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
            string Name = ds.Tables[0].Rows[0]["FirstName"].ToString() + " " + ds.Tables[0].Rows[0]["LastName"].ToString();
            char[] separator = new char[] { '@' };
            string[] strSplitArr = uctxtEmail.Text.Split(separator);
            string username = strSplitArr[0];

            Body = "<b>Hello &nbsp;" + Name + ",<b/><br/><br/>";

            Body += "<b>Date:<b/>" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "<br/";
            Body += "<b>Email:<b/>" + uctxtEmail.Text + "<br/>";
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

    protected string GenerateMailBodyForgetPassword()
    {
        string filename = AppDomain.CurrentDomain.BaseDirectory + "\\Mail Template\\ForgetPassword.txt";
        string MailFormat = System.IO.File.ReadAllText(filename);
        DataSet ds = new DataSet();
        string Body = string.Empty;
        ds = (DataSet)ViewState["PasswordData"];
        try
        {
            string Pwd = ds.Tables[0].Rows[0]["Password"].ToString();
            string Name = ds.Tables[0].Rows[0]["FirstName"].ToString() + " " + ds.Tables[0].Rows[0]["LastName"].ToString();

            Body = MailFormat;
            Body = Body.Replace("#username", Name);
            Body = Body.Replace("#loginid", uctxtEmail.Text);
            Body = Body.Replace("#password", Pwd);

            //Body += "<b>" + EmailUtility.USERNAME + "<b/>";


        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }

        return Body;
    }

    protected string IsFreePackage()
    {
        try
        {
            string strresult = string.Empty;
            //obj_SYS_Role = new SYS_Role();
            obj_BAL_SYS_Role = new SYS_Role_BLogic();
            DataSet dtPackageDetails = new DataSet();
            dtPackageDetails = obj_BAL_SYS_Role.BAL_SYS_Select_IsFreePackage(Convert.ToInt32(AppSessions.StudentID));
            double packageprice = Convert.ToDouble(dtPackageDetails.Tables[0].Rows[0]["Price"].ToString());
            if (packageprice > 0)
            {
                strresult = "paid";
            }
            else
            {
                strresult = "free";
            }

            return strresult;


        }
        catch (Exception)
        {
            return string.Empty;

        }
    }
    protected void ClearControls()
    {
        try
        {
            uctxtEmail.Text = string.Empty;
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }
    protected void btncancel_Click(object sender, EventArgs e)
    {
        uctxtUserName.Text = string.Empty;
        uctxtUserPassword.Text = string.Empty;
        ucinvalididpassword.Text = string.Empty;
    }
}