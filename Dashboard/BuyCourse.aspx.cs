using System;
using Udev.UserMasterPage.Classes;
using System.Globalization;

public partial class Dashboard_BuyCourse : System.Web.UI.Page
{

   # region "Variables" 
   # endregion

   # region "Properties"
   # endregion

   # region "Page events"
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    # endregion

   # region "Control events"
    protected void btnCombo_Click(object sender, EventArgs e)
    {
        try
        {
            pnlCombo.Visible = true;
            pnlSingle.Visible = false;
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }
   
    protected void btnSingle_Click(object sender, EventArgs e)
    {
        try
        {
            pnlCombo.Visible = false;
            pnlSingle.Visible = true;
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }
    # endregion

   # region "User deined function"
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