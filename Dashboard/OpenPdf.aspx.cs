///<Summary
///</Summary>

using System;
using Udev.UserMasterPage.Classes;
using System.Globalization;

public partial class Dashboard_OpenPdf : System.Web.UI.Page
{
    # region Variables
    # endregion

    # region Properties
    # endregion

    # region Page events
    protected void Page_Load(object sender, EventArgs e)
    {
        //Int64 bmssctid = Convert.ToInt64(Session["BMSSCTID"]);
        //SimplerAES objeAes = new SimplerAES();

        //String FullPath = String.Empty;
        //String FileName = String.Empty;
        //String DirName = String.Empty;


        //FullPath = objeAes.Decrypt(Request.QueryString["FullPath"].ToString());
        //FileName =  objeAes.Decrypt(Request.QueryString["FileName"].ToString());
        //DirName =  objeAes.Decrypt(Request.QueryString["DirName"].ToString());

        //String Path1 = Server.MapPath("../EduResource/" + bmssctid + "/" +DirName + "/");

        ////string finalerPfad = Pfad + myFileName;
        //string fileLength;
        //FileInfo myFileInfo = new FileInfo(FullPath);
        //fileLength = myFileInfo.Length.ToString();

        //Response.Clear();

        //Response.AddHeader("Accept-Ranges", "ascii");
        //Response.AddHeader("Content-Length", fileLength);
        //Response.AddHeader("Cache-Control", "post-check=0, pre-check=0");
        //Response.ContentType = "application/pdf";
        //Response.AddHeader("Content-Disposition", "inline; filename=\"" + FileName + "\"");
        //Response.AddHeader("Cache-Control", "no-store, no-cache, must-revalidate");
        //Response.AddHeader("Pragma", "no-cache");

        //Response.Flush();
        //Response.WriteFile(Path1 + FileName);
        //Response.End();
    }
    # endregion

    # region Control events
    # endregion

    # region User defined function
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