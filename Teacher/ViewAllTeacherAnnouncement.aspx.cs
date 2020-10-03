///<Summary>
///</Summary>

using System;
using System.Data;
using System.Globalization;
using System.Text;
using Udev.UserMasterPage.Classes;

public partial class Teacher_ViewAllTeacherAnnouncement : System.Web.UI.Page
{
    # region Variables
    Teacher_Dashboard obj_Teacher_Dashboard;
    Announcement_BLogic BAL_Announcement = new Announcement_BLogic();
    # endregion

    # region Properties
    # endregion

    # region Page events
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillTeacherAnnouncement();
        }
    }
    # endregion

    # region Control events
    # endregion

    # region User defined functions
    protected void FillTeacherAnnouncement()
    {
        DataSet dsSelect = new DataSet();
        dsSelect = BAL_Announcement.BAL_SelectAnnouncementForTeacher(AppSessions.BMSID, AppSessions.EmpolyeeID, "SelectAllForTeacher");
        if (dsSelect.Tables[0].Rows.Count > 0)
        {
            dlAnnouncement.DataSource = dsSelect.Tables[0];
            dlAnnouncement.DataBind();
        }
    }
    protected string Limit(object Desc, int length)
    {
        StringBuilder strDesc = new StringBuilder();
        strDesc.Insert(0, Desc.ToString());

        if (strDesc.Length > length)
        {
            return strDesc.ToString().Substring(0, length) + "...";
        }
        else
        {
            return strDesc.ToString();
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