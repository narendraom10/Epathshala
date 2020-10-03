///<Summary>
///</Summary>

using System;
using System.Globalization;
using Udev.UserMasterPage.Classes;

public partial class Dashboard_SineupPayment : System.Web.UI.Page
{

    # region Variables
    # endregion

    # region Properties
    # endregion

    # region Page events

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

        }
    }

    # endregion

    # region Control events

    protected void rbtnIcollect_CheckedChanged(object sender, EventArgs e)
    {
        Response.Redirect("PartySignUpOnlineOffline.aspx");
    }

    protected void rbtnPayPalPayment_CheckedChanged(object sender, EventArgs e)
    {
        Response.Redirect("Payment.html");
    }
    # endregion

    # region User defined functions

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