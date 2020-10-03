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
using System.Text;

/// <summary> 
/// <DevelopedBy></DevelopedBy>
/// <DevelopedDate></DevelopedDate>
/// <UpdatedBy>"SHEEL"</UpdatedBy>
/// <UpdatedDate></UpdatedDate>
/// </summary>
public partial class Login : System.Web.UI.Page
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

    #region "PageEvents"

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SetProjectValueInSession();
            // SetOfferText();
            //if (CommonUtility.GetLicenseInfo())
            //{
            //GetBMS();
            AppSessions.RoleID = 0;
            Session["LoginURl"] = Request.Url.AbsoluteUri;
            //}
            //else
            //{
            //    CommonUtility.RemoveKeyFromXML();
            //    CommonUtility.LogoutMethod();
            //    HttpContext.Current.Response.Redirect("~/Dashboard/License.aspx");
            //}

        }
    }

    #endregion

    #region "Control Events"

    protected void ibtnRefresh_Click(object sender, ImageClickEventArgs e)
    {
        // Captcha1.CaptchaLineNoise = MSCaptcha.CaptchaImage.LineNoiseLevel.None;
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

    //protected bool verifyLoginID()
    //{
    //    bool Flag = true;
    //    try
    //    {
    //        BAL_Student = new Student_BLogic();
    //        Student = new Student();
    //        DataSet ds = new DataSet();

    //        Student.loginid = txtEmail.Text;
    //        ds = BAL_Student.BAL_Verify_Student(Student);
    //        if (ds.Tables[0].Rows.Count > 0 && ds != null)
    //        {
    //            string LoginID = ds.Tables[0].Rows[0]["LoginID"].ToString();
    //            if (LoginID != string.Empty)
    //            {
    //                Flag = false;
    //                WebMsg.Show("LoginID already exist..");
    //            }
    //        }

    //    }
    //    catch (Exception ex)
    //    {
    //        WebMsg.Show(ex.Message);
    //    }
    //    return Flag;
    //}

    //protected void ClearRegisterControls()
    //{
    //    try
    //    {
    //        ddlBMS.SelectedValue = "0";
    //        ddlGender.SelectedValue = "0";
    //        txtEmail.Text = string.Empty;
    //        txtPassword.Text = string.Empty;
    //        txtFirstName.Text = string.Empty;
    //        txtLastName.Text = string.Empty;
    //        txtContactNo.Text = string.Empty;
    //        txtBirthdate.Text = string.Empty;
    //    }
    //    catch (Exception ex)
    //    {
    //        WebMsg.Show(ex.Message);
    //    }
    //}

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

    protected override void InitializeCulture()
    {
        if (ViewState["A"] != null)
        {
            String selectedLanguage = ViewState["A"].ToString();
            this.UICulture = selectedLanguage;
            this.Culture = selectedLanguage;

            Session[Global.SESSION_KEY_CULTURE] = selectedLanguage;
            Session["LANG"] = selectedLanguage;
            System.Threading.Thread.CurrentThread.CurrentCulture =
            CultureInfo.CreateSpecificCulture(selectedLanguage);
            System.Threading.Thread.CurrentThread.CurrentUICulture = new
            CultureInfo(selectedLanguage);
        }
        else
        {
            if (Request.Form["ddlLanguage"] != null)
            {
                String selectedLanguage = Request.Form["ddlLanguage"];
                this.UICulture = selectedLanguage;
                this.Culture = selectedLanguage;
                Session[Global.SESSION_KEY_CULTURE] = selectedLanguage;
                Session["LANG"] = selectedLanguage;
                System.Threading.Thread.CurrentThread.CurrentCulture =
                CultureInfo.CreateSpecificCulture(selectedLanguage);
                System.Threading.Thread.CurrentThread.CurrentUICulture = new
                CultureInfo(selectedLanguage);
            }
        }
        base.InitializeCulture();

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

        //sessions[Session["EmpolyeeID"].ToString()] = Session;
        sessions[ViewState["EmpolyeeID"].ToString()] = Session;
        Application.Lock(); //lock to prevent duplicate objects
        Application["WEB_SESSIONS_OBJECT"] = sessions;
        Application.UnLock();
    }

    //protected int cusCustom_ServerValidate(object sender, ServerValidateEventArgs e)
    //{
    //    Captcha1.ValidateCaptcha(TxtBxCap.Text.Trim());
    //    if (Captcha1.UserValidated)
    //    {
    //        e.IsValid = true;
    //        return 1;
    //    }
    //    else
    //    {
    //        e.IsValid = false;
    //    }
    //    return 0;
    //}

    private void SetProjectValueInSession()
    {
        DataSet dsSettings;
        Teacher_Dashboard_BLogic obj_BAL_Teacher_Dashboard;


        obj_BAL_Teacher_Dashboard = new Teacher_Dashboard_BLogic();
        dsSettings = new DataSet();

        dsSettings = obj_BAL_Teacher_Dashboard.BAL_Select_CoveredUncoverChapterTopic_Settings("EpathshalaForAIS");

        if (dsSettings.Tables[0].Rows.Count > 0)
        {
            if (Convert.ToBoolean(dsSettings.Tables[0].Rows[0]["value"].ToString()))
            {
                AppSessions.IsAISProject = true;
                //imgcompanylogo.ImageUrl = "~/App_Themes/AISSlideshow/images/ais-logo.jpg";
                //imgcompanylogo.Style["Width"] = "200px";
            }
            else
            {
                AppSessions.IsAISProject = false;
            }
        }
        else
        {
            AppSessions.IsAISProject = false;
        }


        obj_BAL_Teacher_Dashboard = new Teacher_Dashboard_BLogic();
        dsSettings = new DataSet();

        dsSettings = obj_BAL_Teacher_Dashboard.BAL_Select_CoveredUncoverChapterTopic_Settings("ShowICICILogo");

        if (dsSettings.Tables[0].Rows.Count > 0)
        {
            if (Convert.ToBoolean(dsSettings.Tables[0].Rows[0]["value"].ToString()))
            {
                //imgcompanylogo.ImageUrl = "~/App_Themes/AISSlideshow/images/icicic-logo.png";
            }
        }
    }

    #endregion
}
