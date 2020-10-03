///<Summary>
///</Summary>

using System;
using System.Data;
using System.Globalization;
using Udev.UserMasterPage.Classes;

public partial class Teacher_TeacherActivityFeedback : System.Web.UI.Page
{
    # region Variables
    Teacher_Dashboard_BLogic obj_BAL_Teacher_Dashboard = new Teacher_Dashboard_BLogic();
    SYS_TeacherActivityFeedback Obj_TeacherActivityFeedback = new SYS_TeacherActivityFeedback();
    # endregion
    
    # region Page event
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    # endregion

    # region Properties
    # endregion

    # region Control events
    protected void btnOK_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet ds = new DataSet();
            obj_BAL_Teacher_Dashboard = new Teacher_Dashboard_BLogic();
            Obj_TeacherActivityFeedback = new SYS_TeacherActivityFeedback();

            Obj_TeacherActivityFeedback.SchoolID = AppSessions.SchoolID;
            Obj_TeacherActivityFeedback.BMSSCTID = Convert.ToInt32(Session["BMSSCTID"]);
            Obj_TeacherActivityFeedback.EmployeeID = AppSessions.EmpolyeeID;
            Obj_TeacherActivityFeedback.DivisionID = AppSessions.DivisionID;
            Obj_TeacherActivityFeedback.Feedback = txtFeedback.Text;
            Obj_TeacherActivityFeedback.CreatedBy = AppSessions.EmpolyeeID;
            obj_BAL_Teacher_Dashboard.FachTopicwiseResult(Obj_TeacherActivityFeedback);

            WebMsg.Show("Teacher Feedback Send Sucessfully.");
            txtFeedback.Text = "";
            SaveFinishActivity();

        }
        catch (Exception)
        {
            throw;
        }
    }
    # endregion

    # region User defined functions
    public void SaveFinishActivity()
    {

        ClassRoomActivityLog ClassRoomActivityLog = new ClassRoomActivityLog();
        ClassRoomActivityLog_BLogic BAL_ClassRoomActivityLog = new ClassRoomActivityLog_BLogic();

        ClassRoomActivityLog.bmssctid = Convert.ToInt64(Session["BMSSCTID"]);
        ClassRoomActivityLog.schoolid = Convert.ToInt64(Session["SchoolID"]);
        ClassRoomActivityLog.employeeid = Convert.ToInt64(Session["EmpolyeeID"]);
        ClassRoomActivityLog.divisionid = Convert.ToInt16(Session["DivisionID"]);

        TrackLog_Utils.Log(Convert.ToInt32(AppSessions.SchoolID), Convert.ToInt32(AppSessions.EmpolyeeID), Convert.ToInt16(AppSessions.DivisionID), "EducationResourcepage", "btnFinishActivity", "Click", Convert.ToDateTime(System.DateTime.Now), Session.SessionID, "Click on Finish Activity Button", "Activity Finished Successfully.", Convert.ToInt32(Session["BMSSCTID"]));

        int result;
        if (Convert.ToBoolean(Session["FromRescheduling"]))
        {
            ClassRoomActivityLog.ReSchedulingID = Convert.ToInt64(Session["ReSchedulingID"]);
            BAL_ClassRoomActivityLog.BAL_ReScheduling_ActivityLog_Update(ClassRoomActivityLog);
            

        }
        else
        {
            result = BAL_ClassRoomActivityLog.BAL_ClassRoomActivityLog_Insert(ClassRoomActivityLog);
            if (result == Convert.ToInt32(EnumFile.Result.TopicNotCovered))
            {
            
            }
            else if (result == Convert.ToInt32(EnumFile.Result.TopicCovered))
            {
                WebMsg.Show("This Topic was Already Covered.");
            }
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

}