using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
using System.Text;
using System.Globalization;
using System.Web.SessionState;
using System.Text.RegularExpressions;

public partial class Registration : System.Web.UI.Page
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
    string strpassword = string.Empty;
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            strpassword = System.Web.Security.Membership.GeneratePassword(6, 0);

            Random rnd = new Random();
            strpassword = Regex.Replace(strpassword, @"[^a-zA-Z0-9]", m => "" + rnd.Next(1, 9) + "");

            ViewState["strpassword"] = strpassword;
            SetProjectValueInSession();
            GetBMS();
            Get_Boards();
            AppSessions.RoleID = 0;
            Session["LoginURl"] = Request.Url.AbsoluteUri;
            //txtBirthdate.Attributes.Add("readonly", "readonly");
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
                //if (!CheckPasswordComplexcity())
                //{
                //    WebMsg.Show("Invalid password format, please enter minimum 6 alphanumeric character with @ # $ %. Sign.");
                //    return;
                //}
                /*if (txtPassword.Text.Length < 6)
                {
                    WebMsg.Show("Minimum 6 character required in password");
                    return;
                }*/
                Student = new Student();
                BAL_Student = new Student_BLogic();
                Student.schoolid = GetDefaultSchoolID();
                Student.divisionid = 1;
                Student.bmsid = (int)ViewState["BMSID"];
                //ViewState["BMSID"] = int.Parse(ddlBMS.SelectedValue);
                Student.loginid = txtEmail.Text;
                //Student.password = txtPassword.Text;
                Student.password = ViewState["strpassword"].ToString();
                Student.firstname = txtFirstName.Text;
                Student.lastname = txtLastName.Text;
                Student.schoolname = txtSchoolname.Text;
                //Student.contactno = Convert.ToInt64(txtContactNo.Text);
                Student.mobilenostring = txtContactNo.Text;
                Student.emailid = txtEmail.Text;

                //DateTime fromdatetime;

                //string d = txtBirthdate.Text;
                //d = d.Replace("-", "/");
                //DateTime dt;
                //try
                //{
                //    dt = DateTime.ParseExact(d, "d/M/yyyy", CultureInfo.InvariantCulture);
                //}
                //catch (Exception)
                //{
                //    dt = DateTime.ParseExact(d, "M/d/yyyy", CultureInfo.InvariantCulture); ;
                //}

                //= DateTime.ParseExact(d, "d/M/yyyy", CultureInfo.InvariantCulture);
                // for both "1/1/2000" or "25/1/2000" formats
                //string newString = dt.ToString("dd/MMM/yyyy");
                //Student.dateofbirth = dt;
                //if (DateTime.TryParse(txtBirthdate.Text, out fromdatetime))
                //{
                //    Student.dateofbirth = fromdatetime;
                //}

                //if (RlstGender.SelectedValue == "1")
                //{
                //    Student.gender = 'M';
                //}
                //else if (RlstGender.SelectedValue == "2")
                //{
                //    Student.gender = 'F';
                //}
                Student.PaymentType = 'I';
                //if (Captcha1.UserValidated)
                //{
                t1 = BAL_Student.BAL_Student_Insert_Online(Student, "OnlineReg");
                InsertIntoStudentPackageDetails(t1);
                //}
                //else
                //{
                //    WebMsg.Show("Please enter the correct Captcha code");

                //}
                if (t1 > 0)
                {
                    //ScriptManager.RegisterStartupScript(this.Page, GetType(), "Message", "You are successfully registered", false);
                    //string MailContent = DefaultEmailBody();
                    //string strResponce = SendMail(txtEmail.Text, "New Registration Details:", MailContent);

                    //WebMsg.Show("Your registration was successfull. We have sent your Login details on your registered Email Address.");
                    // ShowMessage("Your registration was successfull. We have sent your Login details on your registered Email Address.");
                    RedirectToDashboard();
                    //AppSessions.StudentID = t1;
                    //AppSessions.BMSID = (int)ViewState["BMSID"];
                    //Response.Redirect("~/Dashboard/StudentDashboard.aspx", false);



                    //WebMsg.Show(strResponce);
                    //ClearRegisterControls();
                    //Response.Redirect("Login.aspx");
                }
                ClearRegisterControls();
            }
            else
            {
                WebMsg.Show("LoginID already exist..");
            }
        }
        catch (FormatException fe)
        {
            //WebMsg.Show("Invalid birthdate");
            //txtBirthdate.Focus();
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
        finally
        { }

        //}
        //else
        //{
        //    WebMsg.Show("Please enter code");

        //}

    }

    //public void ShowMessage(string message)
    //{
    //    this.lblMessage.Text = message;
    //    ModalMessageExtender.Show();
    //}

    protected void RedirectToDashboard()
    {
        try
        {
            // 0 Indicates Student

            StudentDash = new StudentDash();
            BLogic_Student = new Student_DashBoard_BLogic();

            DataSet dtLogin = new DataSet();
            DataTable LoginInfo = new DataTable();
            DataTable UserInfo = new DataTable();

            obj_SYS_Role = new SYS_Role();
            obj_BAL_SYS_Role = new SYS_Role_BLogic();
            obj_SYS_Role.Username = txtEmail.Text;
            obj_SYS_Role.Password = ViewState["strpassword"].ToString();

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
                        WebMsg.Show("you are already logged in.");
                        return;
                    }
                }

                ////////getting the pointer to the Session of the current logged in user
                yourLoginMethodStudent(LoginInfo);
                //ProceedToRedirectPage(LoginInfo);

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
                TrackLog_Utils.Log(Convert.ToInt32(AppSessions.SchoolID), Convert.ToInt32(AppSessions.EmployeeOrStudentID), Convert.ToInt16(AppSessions.DivisionID), "Login", "btnLogin", "Click", Convert.ToDateTime(System.DateTime.Now), HttpContext.Current.Session.SessionID, StringEnum.stringValueOf(EnumFile.Activity.LoginSuccess), "LoginId: " + txtEmail.Text, 0);


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

                            ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('We have sent your Login details on your registered Email Address, kindly check your Email to get your Password.  ');window.open('../DashBoard/StudentDashboard.aspx','_self');", true);
                            //Response.Redirect("~/DashBoard/StudentDashboard.aspx", false);
                            //ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('Congratulation! You got free trial for 30 days. \\n We have sent your Login details on your registered Email Address.  ');window.open('../DashBoard/StudentDashboard.aspx','_self');", true);
                            TrackLog_Utils.Log(Convert.ToInt32(AppSessions.SchoolID), Convert.ToInt32(AppSessions.EmployeeOrStudentID), Convert.ToInt16(AppSessions.DivisionID), "Login", "btnLogin", "Click", Convert.ToDateTime(System.DateTime.Now), HttpContext.Current.Session.SessionID, StringEnum.stringValueOf(EnumFile.Activity.PackageSelection), "LoginId: " + txtEmail.Text, 0);
                        }
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('We have sent your Login details on your registered Email Address, kindly check your Email to get your Password.  ');window.open('../DashBoard/StudentDashboard.aspx','_self');", true);
                        //Response.Redirect("~/DashBoard/StudentDashboard.aspx", false);
                        TrackLog_Utils.Log(Convert.ToInt32(AppSessions.SchoolID), Convert.ToInt32(AppSessions.EmployeeOrStudentID), Convert.ToInt16(AppSessions.DivisionID), "Login", "btnLogin", "Click", Convert.ToDateTime(System.DateTime.Now), HttpContext.Current.Session.SessionID, StringEnum.stringValueOf(EnumFile.Activity.PackageSelection), "LoginId: " + txtEmail.Text, 0);

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
        catch (Exception)
        {


        }
    }
    private void ProceedToRedirect()
    {

        ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('We have sent your Login details on your registered Email Address, kindly check your Email to get your Password.  ');window.open('../DashBoard/StudentDashboard.aspx','_self');", true);
        //ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('Congratulation! You got free trial for 30 days. \\n We have sent your Login details on your registered Email Address.  ');window.open('../DashBoard/StudentDashboard.aspx','_self');", true);
        //Response.Redirect("~/Dashboard/StudentDashboard.aspx", false);
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


    protected string DefaultEmailBody(string ISFreeTrial = null)
    {
        StringBuilder oBuilder = new StringBuilder();
        try
        {
            oBuilder.Append("<!DOCTYPE html><html><head>");
            oBuilder.Append("<style type=text/css> th {color: #685858;} table tr:nth-child(odd) { background-color: #DBDBDB; border-bottom: 1px SOLID GRAY; }  p { text-align:justify; line-height:1.4em; }  </style> ");
            oBuilder.Append("</head><body>");

            //oBuilder.Append("<div style='font-family: Calibri,Cambria,verdana; color: #4C3636;'>");
            oBuilder.Append("<div style='font-family:Trebuchet MS,Georgia,Verdana,Tahoma;color:#4C3636;'>");
            oBuilder.Append("<table width=72% style='margin: 10px; border: 5px SOLID SILVER; border-radius: 5px;' border=0>");
            oBuilder.Append("<tr><td><div style='background-color: #2f378e; height: 30px; font-size: 21px; font-weight: bold;padding: 10px;'><span style='color: white; display: block;'>EPATHSHALA</span></div></td></tr>");
            oBuilder.Append("<tr><td style='font-size: 16px;'>");
            oBuilder.Append("<div id=dvcontent style='font-size: 14px; padding: 20px; background-color: #F4F4F4;'>");
            oBuilder.Append("Dear " + txtFirstName.Text + ",  <p> Thank you for registering with ePathshala. We welcome you to the world of experiential learning to make your learning process efficient and effective.</p> ");

            //oBuilder.Append("Dear " + txtFirstName.Text + "<br /><br />Thank you for registering with E-Pathshala. We welcome you to the world of experiential learning so as to make learning interesting for you.<br /><br />We have different packages for " + ddlBMS.SelectedItem.Text + " as below:<br /><br /><center> ");
            //oBuilder.Append("<table border=0 cellpadding=5 cellspacing=0 width=80% style='border: 1px SOLID #9B9B9B;'>");
            //oBuilder.Append("<tr style='background-color: #CECECE;'><th>BMS</th><th>Subject</th><th>Price</th></tr>");
            //// Dynamice for available packages
            //oBuilder.Append("<tr><td>Gujarat Board>> Gujarati Medium >> Standar-08</td><td>English</td><td style='text-align: right;'>200</td></tr>");
            //oBuilder.Append("<tr><td style='width: 60%;'>Gujarat Board>> Gujarati Medium >> Standar-08</td><td style='width: 30%;'>English</td><td style='width: 10%; text-align: right;'>200</td></tr>");
            //oBuilder.Append("</table></center><br />");

            if (ISFreeTrial != null && ISFreeTrial.ToString().ToLower() == "yes")
            {
                DataTable dtTrialPackage = (DataTable)Session["dsTrailPAckage"];
                string strBMS = ddlBMS.SelectedItem.Text.Replace(">>", ">");
                string[] BMS = strBMS.Split('>');
                string Board = ddlBoard.SelectedItem.ToString();
                string Medium = ddlMedium.SelectedItem.ToString(); ;
                string Standard = ddlStandard.SelectedItem.ToString();

                //oBuilder.Append(" <p> We are pleased to provide you access to ePathshala package for " + dtTrialPackage.Rows[0]["NoOfMonth"].ToString() + " days for " + Board + " Board " + Medium + " Medium " + Standard + ". ");
                oBuilder.Append(" <p> We are pleased to provide you access to ePathshala package for " + dtTrialPackage.Rows[0]["NoOfMonth"].ToString() + " day(s) as an introductory promotional offer for selected standard.");
                oBuilder.Append("<br />Discover how E-Pathshala helps you like a teacher/friend. </p>");
                oBuilder.Append("<div><center>");
                oBuilder.Append("<table border=0 cellpadding=5 cellspacing=0 style='border-collapse: collapse; border: 1px SOLID #9B9B9B; width=80%'>");
                oBuilder.Append("<tr style='background-color: #CECECE;'><th>Package Name</th><th>Subject</th><th>Start From</th><th>Valid Till</th> </tr>");

                for (int i = 0; i < dtTrialPackage.Rows.Count; i++)
                {
                    oBuilder.Append("<tr><td>" + dtTrialPackage.Rows[i]["PackageName"].ToString() + "</td><td>" + dtTrialPackage.Rows[i]["Subject"].ToString() + "</td><td style='text-align: center;'>" + DateTime.Now.ToString("dd MMM, yyyy") + "</td><td style='text-align: center;'>" + DateTime.Now.AddDays(Convert.ToInt32(dtTrialPackage.Rows[0]["NoOfMonth"].ToString())).ToString("dd MMM, yyyy") + "</td></tr>");
                }
                oBuilder.Append("</table> </center></div><br />");
            }

            //oBuilder.Append("<div><p> We wish you happy learning and also wish to strengthen your knowledge, increase your confidence and achieve better performance.<br />We look forward to a wonderful learning experience with us and relationship with us.  </p> <b>Your Login details are as below:  </b></div><br/>");
            oBuilder.Append("<div><p>We look forward to a wonderful learning experience and relationship with us.  </p> <b>Your Login details are as below:  </b></div><br/>");

            oBuilder.Append("<div><table border=0 cellpadding=5 cellspacing=3 style='border-collapse: collapse;border: 1px SOLID #9B9B9B; margin-left: 90px; width=40%'>");
            oBuilder.Append("<tr><td>Visit:</td><td>http://epathshala.co.in/</td></tr>");
            oBuilder.Append("<tr><td class=style2>Login ID:</td><td class=style1><b>" + txtEmail.Text + "</b></td></tr>");
            oBuilder.Append("<tr><td class=style2>Password:</td><td class=style1><b>" + ViewState["strpassword"].ToString() + "</b></td></tr>");
            oBuilder.Append("<tr><td class=style2 colspan=2>Please do reach us on info@epath.net.in for your queries or suggestion.</td></tr>");
            oBuilder.Append("</table></div><br />");
            oBuilder.Append("<div>Thank You,<br />ePathshala - Support Team.</div></div>");
            oBuilder.Append("</td></tr>");
            oBuilder.Append("<tr><td><div style='background-color: #E4722B; height: 24px; font-size: 18px; font-weight: bold;padding: 5px;'>");
            oBuilder.Append("<div><table border=0 cellpadding=0 cellspacing=0 style='background:none;color:Black;'>");
            oBuilder.Append("<tr  style='background:none;color:Black;'><td><span style='color: white; display: block;'>FOLLOW US!</span></td>");
            oBuilder.Append("<td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>");
            oBuilder.Append("<td>&nbsp;<a href=https://www.facebook.com/myepathshala><img src=https://cdn3.iconfinder.com/data/icons/peelicons-vol-1/50/Facebook-48.png height=36 /></a></td>");
            oBuilder.Append("<td>&nbsp;<a href=https://twitter.com/EpathshalaEpath><img src=https://cdn3.iconfinder.com/data/icons/peelicons-vol-1/50/Twitter-48.png height=36 /></a></td>");

            oBuilder.Append("</tr></table></div></div></td></tr>");

            //oBuilder.Append("<span style='color: white; display: block;'>FOLLOW US!</span> <a href=https://www.facebook.com/myepathshala> <img alt=Epathshala width=26px height=23px src=App_Themes/Images/FBIcon.png /> <a>  <a href=https://twitter.com/EpathshalaEpath> <img alt=Epathshala width=26px height=23px src=App_Themes/Images/twitter.png /> <a> </div> </td> </tr>");
            oBuilder.Append("<tr> <td style='padding: 20px;'> Please do not reply this message. Queries? Contact. Customer Support. <br /> Arraycom India Ltd. 13, GIDC, Gandhinagar, 382025. </td></tr>");
            oBuilder.Append(" </table></div>");



            //oBuilder.Append("<p>Thank you for registration in Epathshala <br /><br />");
            //oBuilder.Append("Best Regards,<br />Admin.</p>");
            //oBuilder.Append("</div></div>");
            //oBuilder.Append("</body></html>");

        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
        return oBuilder.ToString();
    }


    private int GetDefaultSchoolID()
    {
        int schoolid = 0;

        DataSet dsSettings;
        Teacher_Dashboard_BLogic obj_BAL_Teacher_Dashboard;

        obj_BAL_Teacher_Dashboard = new Teacher_Dashboard_BLogic();
        dsSettings = new DataSet();

        dsSettings = obj_BAL_Teacher_Dashboard.BAL_Select_CoveredUncoverChapterTopic_Settings("DefaultSchoolID");

        if (dsSettings.Tables[0].Rows.Count > 0)
            schoolid = Convert.ToInt32(Convert.ToString(dsSettings.Tables[0].Rows[0]["value"]));
        else
            schoolid = 0;

        return schoolid;
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("Login.aspx");
    }

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
                    // WebMsg.Show("LoginID already exist..");
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
            //ddlBMS.SelectedValue = "0";

            txtEmail.Text = string.Empty;
            //txtPassword.Text = string.Empty;
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtContactNo.Text = string.Empty;
            txtSchoolname.Text = string.Empty;
            ddlBoard.SelectedIndex = 0;
            ddlMedium.SelectedIndex = 0;
            ddlStandard.SelectedIndex = 0;
            ddlMedium.DataSource = null; ddlMedium.DataBind(); ddlMedium.Enabled = false;
            ddlStandard.DataSource = null; ddlStandard.DataBind(); ddlStandard.Enabled = false;

            //txtBirthdate.Text = string.Empty;
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }

    //public bool CheckPasswordComplexcity()
    //{
    //    bool flag = false;
    //    BLogic_Student = new Student_DashBoard_BLogic();
    //    DataSet dsResult = new DataSet();
    //    dsResult = BLogic_Student.BAL_Select_PaymentPagesInfo("Password");

    //    string Complexcity = dsResult.Tables[0].Rows[0]["value"].ToString();

    //    if (txtPassword.Text.Length > 0)
    //    {
    //        if (System.Text.RegularExpressions.Regex.IsMatch(txtPassword.Text, Complexcity))
    //        {

    //            //WebMsg.Show("Valid Password");
    //            flag = true;
    //        }
    //        else
    //        {
    //            //WebMsg.Show("Invalid Password");
    //            flag = false;
    //        }
    //    }
    //    return flag;
    //}

    //public void InsertIntoStudentPackageDetails(int studentid)
    //{
    //    try
    //    {
    //        //Student = new Student();
    //        BAL_Student = new Student_BLogic();
    //        Package_BLogic Blogic_Package = new Package_BLogic();
    //        //Student.bmsid = Convert.ToInt32(ViewState["BMSID"]);
    //        int BMSID = Convert.ToInt32(ViewState["BMSID"]);
    //        DataSet dsPackageID = BAL_Student.BAL_Student_SelectPackageID(BMSID);

    //        if (dsPackageID != null && dsPackageID.Tables.Count > 0)
    //        {
    //            Package Opackage = new Package();

    //            Opackage.StudentID = studentid;
    //            Opackage.PackageFD_ID = Convert.ToInt64(dsPackageID.Tables[0].Rows[0]["PackageID"].ToString());
    //            int result = Blogic_Package.BAL_Student_TrialPackage_Insert(Opackage);
    //            if (result > 0)
    //            {
    //                string MailContent = DefaultEmailBody("yes");
    //                string strResponce = SendMail(txtEmail.Text, "New Registration Details", MailContent);
    //                WebMsg.Show("Congratulation! You got free trial for 7 days");
    //            }
    //            else
    //            {
    //                string MailContent = DefaultEmailBody();
    //                string strResponce = SendMail(txtEmail.Text, "New Registration Details", MailContent);
    //            }
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //    }
    //}

    public void InsertIntoStudentPackageDetails(int studentid)
    {
        try
        {
            //Student = new Student();
            BAL_Student = new Student_BLogic();
            Package_BLogic Blogic_Package = new Package_BLogic();
            //Student.bmsid = Convert.ToInt32(ViewState["BMSID"]);
            int BMSID = Convert.ToInt32(ViewState["BMSID"]);
            DataSet dsPackageID = BAL_Student.BAL_Student_SelectPackageID(BMSID);

            if (dsPackageID != null && dsPackageID.Tables.Count > 0)
            {
                if (dsPackageID.Tables[0].Rows.Count > 0)
                {

                    Session["dsTrailPAckage"] = dsPackageID.Tables[0];
                    Package Opackage = new Package();

                    Opackage.StudentID = studentid;
                    Opackage.PackageFD_ID = Convert.ToInt64(dsPackageID.Tables[0].Rows[0]["PackageID"].ToString());
                    int result = Blogic_Package.BAL_Student_TrialPackage_Insert(Opackage);
                    if (result > 0)
                    {
                        string MailContent = DefaultEmailBody("yes");
                        string strResponce = SendMail(txtEmail.Text, "New Registration Details", MailContent);
                        //ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('Your message.');window.open('AnotherPage.aspx','_self');", true);
                        //WebMsg.Show("Congratulation! You got free trial for 30 days");
                    }
                }
                else
                {
                    string MailContent = DefaultEmailBody();
                    string strResponce = SendMail(txtEmail.Text, "New Registration Details", MailContent);
                }
            }
        }
        catch (Exception ex)
        {
        }
    }


    private string SendMail(string emailid, string mailsubject, string mailcontent)
    {
        string Response = string.Empty;
        if (!string.IsNullOrEmpty(emailid))
        {
            ArrayList alistEmailAddress = new ArrayList();
            alistEmailAddress.Add(emailid);
            if (alistEmailAddress.Count > 0)
            {
                bool IsSendSuccess = EmailUtility.SendEmail(alistEmailAddress, mailsubject, mailcontent);
                if (IsSendSuccess)
                    Response = "Send email successfully.";
                else
                    Response = "Send email failed.";
            }
        }
        else
        {
            Response = "Send email failed.[Email address is empty]";
        }
        return Response;
    }

    //protected string DefaultEmailBody(string strgreetingmsg = null)
    //{
    //    StringBuilder oBuilder = new StringBuilder();
    //    try
    //    {
    //        oBuilder.Append("<!DOCTYPE html><html><head></head><body>");

    //        oBuilder.Append("<div style='border: 0px Solid #F0F0F0; background-color: #f9f9f9;margin: 10px; font-family: Cambria,Calibri,Times New Roman; font-size: medium;  box-shadow: 0px 0px 4px #909090;border-top: 8px Solid #522675;border-bottom: 4px Solid #522675;'>");
    //        oBuilder.Append("<div style='background-color:#F0F0F0  ;height:70px;'><div class='logo' style='text-align: center;color:#80262e;padding:20px;'>");
    //        oBuilder.Append("</div></div>");
    //        oBuilder.Append("<div style='border-bottom: 3px Solid #E8E8E8; padding: 20px; border-top: 2px Solid #522675;color: #909090;'>");

    //        oBuilder.Append("<p>Dear " + txtFirstName.Text + ",<br /><br />");
    //        oBuilder.Append("<p>You are successfully registered in Epathshala.<br /><br />");

    //        if (strgreetingmsg.ToLower() == "yes")
    //        {
    //            oBuilder.Append("<p>Congratulation! You have got free trial of Education Resource for 7 days for " + ddlBMS.SelectedItem.Text + ". It will be valid up to " + DateTime.Now.AddDays(8).ToString("dd MMM yyyy") + "<br /><br />");
    //        }

    //        oBuilder.Append("<p>Your Login details are as below: <br /><br />");
    //        oBuilder.Append("LoginID:  " + txtEmail.Text + " .<br />");
    //        oBuilder.Append("Password:  " + txtPassword.Text + " <br />");
    //        oBuilder.Append("Website: www.epathshala.co.in <br /><br />");

    //        oBuilder.Append("<p>Thank you for registration in Epathshala <br /><br />");
    //        oBuilder.Append("Best Regards,<br />Admin.</p>");
    //        oBuilder.Append("</div></div>");
    //        oBuilder.Append("</body></html>");

    //    }
    //    catch (Exception ex)
    //    {
    //        WebMsg.Show(ex.Message);
    //    }
    //    return oBuilder.ToString();
    //}
    private void SetProjectValueInSession()
    {
        DataSet dsSettings;
        Teacher_Dashboard_BLogic obj_BAL_Teacher_Dashboard;


        obj_BAL_Teacher_Dashboard = new Teacher_Dashboard_BLogic();
        dsSettings = new DataSet();

        dsSettings = obj_BAL_Teacher_Dashboard.BAL_Select_CoveredUncoverChapterTopic_Settings("EpathshalaForAIS");

        //if (dsSettings.Tables[0].Rows.Count > 0)
        //{
        //    if (Convert.ToBoolean(dsSettings.Tables[0].Rows[0]["value"].ToString()))
        //    {
        //        AppSessions.IsAISProject = true;
        //        imgcompanylogo.ImageUrl = "~/App_Themes/AISSlideshow/images/ais-logo.jpg";
        //        imgcompanylogo.Style["Width"] = "200px";
        //    }
        //    else
        //    {
        //        AppSessions.IsAISProject = false;
        //    }
        //}
        //else
        //{
        //    AppSessions.IsAISProject = false;
        //}


        obj_BAL_Teacher_Dashboard = new Teacher_Dashboard_BLogic();
        dsSettings = new DataSet();

        dsSettings = obj_BAL_Teacher_Dashboard.BAL_Select_CoveredUncoverChapterTopic_Settings("ShowICICILogo");

        //if (dsSettings.Tables[0].Rows.Count > 0)
        //{
        //    if (Convert.ToBoolean(dsSettings.Tables[0].Rows[0]["value"].ToString()))
        //    {
        //        imgcompanylogo.ImageUrl = "~/App_Themes/AISSlideshow/images/icicic-logo.png";
        //    }
        //}
    }


    public void Get_Boards()
    {
        DropDownFill DdlFilling = new DropDownFill();
        DataSet dsBoard = new DataSet();
        dsBoard = BSysBMS.Get_AllBoards();
        if (dsBoard.Tables[0].Rows.Count > 0)
        {
            ddlBoard.DataSource = dsBoard;
            ddlBoard.DataTextField = "Board";
            ddlBoard.DataValueField = "BoardID";
            ddlBoard.DataBind();
            ddlBoard.Items.Insert(0, "--Select Board--");
        }
    }

    #endregion
    protected void ddlBoard_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlBoard != null && ddlBoard.SelectedIndex > 0)
        {
            DataSet dsmedium = new DataSet();
            dsmedium = BSysBMS.Get_AllMediumByBoardID(int.Parse(ddlBoard.SelectedValue));
            if (dsmedium.Tables[0].Rows.Count > 0)
            {
                ddlMedium.DataSource = dsmedium;
                ddlMedium.DataTextField = "Medium";
                ddlMedium.DataValueField = "MediumID";
                ddlMedium.DataBind();
                ddlMedium.Items.Insert(0, "--Select Medium--");
                ddlMedium.Enabled = true;
            }
        }


    }
    protected void ddlMedium_SelectedIndexChanged(object sender, EventArgs e)
    {
        if ((ddlBoard != null && ddlBoard.SelectedIndex > 0) && (ddlMedium != null && ddlMedium.SelectedIndex > 0))
        {
            DataSet dsstandard = new DataSet();
            dsstandard = BSysBMS.Get_AllStandardByBoardMediumID(int.Parse(ddlBoard.SelectedValue), int.Parse(ddlMedium.SelectedValue));
            if (dsstandard.Tables[0].Rows.Count > 0)
            {
                ddlStandard.DataSource = dsstandard;
                ddlStandard.DataTextField = "Standard";
                ddlStandard.DataValueField = "StandardId";
                ddlStandard.DataBind();
                ddlStandard.Items.Insert(0, "--Select Standard--");
                ddlStandard.Enabled = true;
            }
        }

    }
    protected void ddlStandard_SelectedIndexChanged(object sender, EventArgs e)
    {
        if ((ddlBoard != null && ddlBoard.SelectedIndex > 0) && (ddlMedium != null && ddlMedium.SelectedIndex > 0) && (ddlStandard != null && ddlStandard.SelectedIndex > 0))
        {
            SYS_Division_BLogic obj_DivBlogic = new SYS_Division_BLogic();

            int param_boardsid = int.Parse(ddlBoard.SelectedValue);
            int param_mediumid = int.Parse(ddlMedium.SelectedValue);
            int param_standardid = int.Parse(ddlStandard.SelectedValue);

            ViewState["BMSID"] = obj_DivBlogic.BAL_SYS_SelectBMSID(param_boardsid, param_mediumid, param_standardid);
        }

    }
}