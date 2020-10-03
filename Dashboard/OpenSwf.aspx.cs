///<Summary>
///</Summary>

using System;
using Udev.UserMasterPage.Classes;
using System.Globalization;

public partial class Dashboard_OpenSwf : System.Web.UI.Page
{
    # region Variables
    # endregion

    # region Properties
    # endregion

    # region Page events
    protected void Page_Load(object sender, EventArgs e)
    {
        SimplerAES objeAes = new SimplerAES();

        //if (Request.QueryString["URL"].ToString() != string.Empty)
        //{
        //    string Fp = objeAes.Decrypt(Request.QueryString["URL"].ToString());
        //    string baseUrl = Context.Request.Url.Authority + Context.Request.ApplicationPath.TrimEnd('/');
        //    string filePath = "http://" + baseUrl + Fp;

        //    Context.RewritePath(System.Web.VirtualPathUtility.Combine("/EpathShala/" , Fp));

        ////     StringBuilder builder = new StringBuilder();

        ////     string filepath = Request.QueryString["FullPath"].ToString();
        ////     builder.Append("<object classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\" codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=5,0,0,0\" width=\"800\" height=\"600\" >");
        ////     builder.Append("<param name=\"movie\" value=\"" + filepath + "\">");
        ////     builder.Append("<param name=\"quality\" value=\"high\">");
        ////     builder.Append("<param name=\"LOOP\" value=\"false\">");
        ////     builder.Append("<embed src=\"" + filepath + "\" width=\"800\" height=\"600\"  loop=\"false\" quality=\"high\" pluginspage=\"http://www.macromedia.com/shockwave/download/index.cgi?P1_Prod_Version=ShockwaveFlash\" type=\"application/x-shockwave-flash\">");
        ////     builder.Append("</embed>");
        ////     builder.Append("</object>");

        ////     lterResource.Text = builder.ToString();
        //}
        //else
        //{
        //    WebMsg.Show("No File Available");
        //}
    }
    # endregion

    # region Control events
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