///<Summary>
///</Summary>

using System;
using Udev.UserMasterPage.Classes;
using System.Globalization;

public partial class Admin_SchoolExamReports : System.Web.UI.Page
{
    # region "Variables"
    # endregion

    # region "Properties"
    # endregion

    # region "Page event"
    protected void Page_Load(object sender, EventArgs e)
    {
        if (AppSessions.SchoolIDRpt != string.Empty)
        {
            SchoolExamReports2.Visible = false;
        }
        else
        {
            SchoolExamReports2.Visible = true;
        }
    }
    # endregion

    # region "Control event"
    # endregion

    # region "User defined function"
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
