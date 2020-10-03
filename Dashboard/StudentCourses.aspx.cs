using System;
using System.Data;
using System.Globalization;
using Udev.UserMasterPage.Classes;

public partial class Dashboard_StudentCourses : System.Web.UI.Page
{

    #region "Declarations"
    Teacher_Dashboard_BLogic obj_BAL_Teacher_Dashboard;
    Teacher_Dashboard obj_Teacher_Dashboard;
    Announcement_BLogic BAL_Announcement = new Announcement_BLogic();

    Student_DashBoard_BLogic obj_BAL_Student_Dashboard;
    StudentDash obj_Student_Dashboard;
    #endregion

    # region Properties
    # endregion

    #region "Page Events"

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
            if (Session["ShowPaymentPages"] == null)
            {
                BindSubjectList();
            }
            else
            {
                WebMsg.Show("No courses found.");
                Response.Redirect("~/Dashboard/StudentDashboard.aspx");
            }
        }
    }
    #endregion

    #region "Control Events"
    #endregion

    #region "User defined functions"

    protected void BindSubjectList()
    {
        try
        {
            GetStudentDetailBMS();
            obj_BAL_Student_Dashboard = new Student_DashBoard_BLogic();
            obj_Student_Dashboard = new StudentDash();

            if (ViewState["UserPackage"] == "Single")
            {
                obj_Student_Dashboard.StudentID = AppSessions.StudentID;
                obj_Student_Dashboard.Mode = "Single";
                DataSet ds = new DataSet();
                ds = obj_BAL_Student_Dashboard.BAL_Student_PackageFor_Notification(obj_Student_Dashboard);
                if (ds.Tables[0].Rows.Count > 0 && ds != null)
                {
                    gvStudentSubjects.Visible = true;
                    gvStudentSubjects.DataSource = ds.Tables[0];
                    gvStudentSubjects.DataBind();
                }
            }

            if (ViewState["UserPackage"] == "Combo")
            {
                obj_Student_Dashboard.StudentID = AppSessions.StudentID;
                obj_Student_Dashboard.Mode = "Combo";
                DataSet ds = new DataSet();
                ds = obj_BAL_Student_Dashboard.BAL_Student_PackageFor_Notification(obj_Student_Dashboard);
                if (ds.Tables[0].Rows.Count > 0 && ds != null)
                {
                    gvStudentCombo.Visible = true;
                    gvStudentCombo.DataSource = ds.Tables[0];
                    gvStudentCombo.DataBind();
                }
            }


        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }

    protected void GetStudentDetailBMS()
    {
        DataSet dsData = new DataSet();
        obj_BAL_Student_Dashboard = new Student_DashBoard_BLogic();
        obj_Student_Dashboard = new StudentDash();
        try
        {
            obj_Student_Dashboard.StudentID = AppSessions.StudentID;
            dsData = obj_BAL_Student_Dashboard.BAL_Validate_Student(obj_Student_Dashboard);
            if (dsData != null && dsData.Tables.Count > 0)
            {
                if (dsData.Tables[0].Rows.Count > 0)
                {
                    string SubjectID = dsData.Tables[0].Rows[0]["SubjectID"].ToString();
                    if (SubjectID != string.Empty)
                    {
                       
                        ViewState["UserPackage"] = "Single";
                    }
                    else
                    {

                        ViewState["UserPackage"] = "Combo";
                    }
                }
               
            }
           
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }
    #endregion

}