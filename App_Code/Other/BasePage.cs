using System;
using System.Globalization;
using System.Threading;
using System.Web.UI;

namespace Udev.UserMasterPage.Classes
{
    /// <summary>
    /// Custom base page used for all web forms.
    /// </summary>
    public class BasePage : Page
    {
        protected override void InitializeCulture()
        {
            //retrieve culture information from session
            string culture = Convert.ToString(Session[Global.SESSION_KEY_CULTURE]);

            //check whether a culture is stored in the session
            if (culture.Length > 0) Culture = culture;

            //set culture to current thread
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);

            //call base class
            base.InitializeCulture();
        }

       
        public int BoardID
        {
            get { return BoardID; }
            set { BoardID = value; }
        }
    }
}