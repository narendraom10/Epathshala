///<Summary>
///</Summary>

using System;
using System.Text;
using System.Web;
using Udev.UserMasterPage.Classes;
using System.Globalization;
using System.Data;
using System.IO;
//using System.Runtime.Caching;



public partial class Dashboard_OpenFlv : System.Web.UI.Page
{
    # region Variables
    public string path = String.Empty;
    # endregion

    # region Properties
    # endregion

    # region Page events
    protected void Page_Load(object sender, EventArgs e)
    {

        Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Cache.SetNoStore();


        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        if (!IsPostBack)
        {
            SimplerAES objeAes = new SimplerAES();


            lterResource.Visible = false;

            string ext = Request.QueryString["ext"].ToString();

            string FullPath = Request.QueryString["FullPath"].ToString();

            if (FullPath != string.Empty)
            {
                //Source1.Attributes.Add("src", FullPath);

                //param1.Attributes.Add("value", FullPath);
                //  emtag.Attributes.Add("src", FullPath);
                if (ext.ToString().Equals(".flv"))
                {
                    lterResource.Visible = true;
                    //Media_Player_Control1.Visible = true;
                    //Media_Player_Control1.MovieURL = FullPath;

                    string FlashHelpUrl = string.Empty;
                    //path = "EduResource/1/01 Video Presentation/AParts of plants.flv";
                    FlashHelpUrl = "<a  href=\"" + FullPath + "\" style=\"display:block;width:1024px;height:650px\" id=\"player\">	</a> <script>flowplayer(\"player\",\"../FlowPlayer/flowplayer-3.2.7.swf\");</script>";
                    lterResource.Text = HttpUtility.HtmlDecode(FlashHelpUrl);

                }
                else if (ext.ToString().Equals(".avi"))
                {
                    // Media_Player_Control1.Visible = true;
                    //Media_Player_Control1.MovieURL = FullPath;
                }
                else if (ext.ToString().Equals(".mp4"))
                {

             

                    lterResource.Visible = true;
                    StringBuilder builder = new StringBuilder();


                    Session["ContentPath"] = FullPath;
                    Session["ContentType"] = "video/mp4";
                    HttpContext.Current.Session["ContentType"] = "video/mp4";



                    builder.Append("<div style=\"position:absolute; height:100%; width:100%; overflow:hidden;\">");
                    builder.Append("<video width=\"100%\" height=\"auto\" style=\"max-height:100%\" preload  controls autoplay>");
                    builder.Append("<source type=\"video/mp4\" codecs=\"avc1.42E01E, mp4a.40.2\" SRC=\"SecurityHandler.ashx?param=" + DateTime.Now.Ticks.ToString() + "\" >");
                    builder.Append("<OBJECT CLASSID=\"clsid:02BF25D5-8C17-4B23-BC80-D3488ABDDC6B\"  WIDTH=\"950\" HEIGHT=\"630\" CODEBASE=\"http://www.apple.com/qtactivex/qtplugin.cab\">");
                    builder.Append("<PARAM name=\"SRC\" VALUE=\"" + "SecurityHandler.ashx?param=" + DateTime.Now.Ticks.ToString() + "" + "\">");
                    builder.Append("<PARAM name=\"AUTOPLAY\" VALUE=\"true\">");
                    builder.Append("<PARAM name=\"CONTROLLER\" VALUE=\"false\">");
                    builder.Append("<EMBED SRC=\"" + "SecurityHandler.ashx?param=" + DateTime.Now.Ticks.ToString() + "" + "\" WIDTH=\"950\" HEIGHT=\"630\" AUTOPLAY=\"true\" CONTROLLER=\"false\" PLUGINSPAGE=\"http://www.apple.com/quicktime/download/\">");
                    builder.Append("</EMBED></OBJECT>");
                    builder.Append("</video>");
                    builder.Append("</div>");
                    lterResource.Text = HttpUtility.HtmlDecode(builder.ToString());

                    //lterResource.Visible = true;
                    //string FlashHelpUrl = string.Empty;
                    //path = "EduResource/1/01 Video Presentation/AParts of plants.flv";
                    //FlashHelpUrl = "<a  href=\"" + FullPath + "\" style=\"display:block;width:800px;height:500px\" id=\"player\">	</a> <script>flowplayer(\"player\",\"../FlowPlayer/flowplayer-3.2.7.swf\");</script>";
                    //lterResource.Text = HttpUtility.HtmlDecode(FlashHelpUrl);
                    //lterResource.Text = builder.ToString();//HttpUtility.HtmlDecode(builder.ToString());
                }
                else if (ext.ToString().Equals(".wmv"))
                {
                    //Media_Player_Control1.Visible = true;
                    //Media_Player_Control1.MovieURL = FullPath;
                }
                else if (ext.ToString().Equals(".swf"))
                {
                    string filepath = FullPath;

                    Session["ContentPath"] = FullPath;
                    Session["ContentType"] = "video/x-flv";
                    HttpContext.Current.Session["ContentType"] = "video/x-flv";

                    Teacher_Dashboard_BLogic obj_BAL_Teacher_Dashboard = new Teacher_Dashboard_BLogic();
                    DataSet dsSettings = new DataSet();
                    dsSettings = obj_BAL_Teacher_Dashboard.BAL_Select_CoveredUncoverChapterTopic_Settings("UseEncrytion");
                    bool IsEncryption = Convert.ToBoolean(dsSettings.Tables[0].Rows[0]["value"].ToString());
                    if (IsEncryption)
                    {
                        lterResource.Visible = true;
                        StringBuilder builder = new StringBuilder();
                        builder.Append("<div style=\"position:absolute; height:50%; width:100%; overflow:hidden;\">");
                        builder.Append("<object id=\"myVideo1\" width=\"100%\" height=\"90%\" data=\"SecurityHandler.ashx?param=" + DateTime.Now.Ticks.ToString() + "\" type=\"application/x-shockwave-flash\">");
                        builder.Append("<param value=\"sameDomain\" name=\"allowScriptAccess\" />");
                        builder.Append("<param name=\"movie\" value=\"SecurityHandler.ashx?param=" + DateTime.Now.Ticks.ToString() + "\" />");
                        builder.Append("<param name=\"quality\" value=\"best\" />");
                        builder.Append("<param value=\"true\" name=\"controller\" />");
                        builder.Append("<param name=\"play\" value=\"true\" />");
                        builder.Append("<param name=\"loop\" value=\"true\" />");
                        builder.Append("<param name=\"wmode\" value=\"window\" />");
                        builder.Append("<param name=\"scale\" value=\"default\" />");
                        builder.Append("<param name=\"menu\" value=\"true\" />");
                        builder.Append("<param name=\"devicefont\" value=\"false\" />");
                        builder.Append("<param name=\"salign\" value=\"\" />");
                        builder.Append("<param name=\"allowScriptAccess\" value=\"sameDomain\" />");
                        builder.Append("</object>");
                        builder.Append("</div>");
                        lterResource.Text = HttpUtility.HtmlDecode(builder.ToString());
                    }
                    else
                    {
                        string baseUrl = Context.Request.Url.Authority + Context.Request.ApplicationPath.TrimEnd('/');
                        string fp = "http://" + baseUrl + filepath.Substring(2);
                        Response.Redirect(fp);
                    }
                }
                else if (ext.ToString().Equals(".pdf"))
                {
                    lterResource.Visible = true;
                    StringBuilder builder = new StringBuilder();
                    string filepath = FullPath;

                    Session["ContentPath"] = FullPath;
                    Session["ContentType"] = "application/pdf";
                    HttpContext.Current.Session["ContentType"] = "application/pdf";

                    builder.Append("<embed src=\"SecurityHandler.ashx?param=" + DateTime.Now.Ticks.ToString() + "\" width=\"100%\" height=\"550\"></embed>");

                    lterResource.Text = HttpUtility.HtmlDecode(builder.ToString());
                }
                else
                {
                    WebMsg.Show("Given File formate is not supporting.");
                }
            }
            else
            {
                WebMsg.Show("No File Available.");
            }
        }
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

