///<Summary>
///</Summary>

using System;
using System.Web.UI;

public partial class Dashboard_PartySignUpOnlineOffline : System.Web.UI.Page
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
    protected void lnkSBIICollect_Click(object sender, EventArgs e)
    {
        Page.RegisterStartupScript("Window", "<script language=\"javascript\">window.open('https://www.onlinesbi.com/prelogin/institutiontypedisplay.htm','','width=1000,height=760,left=1,top=1');</script>");
    }
    # endregion

    # region User defined functions
    # endregion

}