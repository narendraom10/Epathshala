/// <summary> 
/// <Description>CALL ON UNLOAD MASTERPAGE </Description>
/// <DevelopedBy>"NARENDRASINH"</DevelopedBy>
/// <DevelopedDate></DevelopedDate>
/// <UpdatedBy>"NARENDRASINH"</UpdatedBy>
/// <UpdatedDate></UpdatedDate>
/// </summary>

using System;
using System.Web;
using System.Collections;

public partial class Logout : System.Web.UI.Page
{
    # region Variables
    # endregion

    # region Properties
    # endregion

    # region Page events
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Hashtable sessions = (Hashtable)Application["WEB_SESSIONS_OBJECT"];
            if (sessions == null)
            {
                sessions = new Hashtable();
            }

            Session.Abandon();
             sessions.Remove(Session["EmpolyeeID"].ToString());
            
            Application.Lock();
            Application["WEB_SESSIONS_OBJECT"] = sessions;
            Application.UnLock();


            HttpContext.Current.Session.Clear();
            HttpContext.Current.Session.Abandon();
        }
        catch (Exception ex)
        {
        }
    }
    # endregion

    # region Control events
    # endregion
    
    # region User defined function
    # endregion
}