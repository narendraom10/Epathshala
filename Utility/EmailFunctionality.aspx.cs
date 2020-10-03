///<Summary>
///</Summary>

using System;
using Udev.UserMasterPage.Classes;
using System.Globalization;

public partial class Utility_EmailFunctionality : System.Web.UI.Page
{
    # region Variables
    # endregion

    # region Properties
    # endregion

    # region Page events
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    # endregion

    # region Control events
    # endregion

    # region User defined functions
    protected override void InitializeCulture()
    {
        string culture = Convert.ToString(Session[Global.SESSION_KEY_CULTURE]);
        //// 'set culture to current thread 
        System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture);
        System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);
        ////call base class 
        base.InitializeCulture();
    }
    # endregion
}