using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.Services;

public partial class DemoPages_ViewDemoContent : System.Web.UI.Page
{

    static string targetfiles;
    static string path;
    static string BMSSCTID;

    protected void Page_Load(object sender, EventArgs e)
    {
        path = Server.MapPath("~/EduResource");
    }

    [WebMethod]
    public static ContentData1[] GetContent(string content, string id)
    {



        List<ContentData1> details = new List<ContentData1>();


        if (content.ToString().ToLower() == "topic")
        {



            string targetDirectory = Path.Combine(path + "\\" + id);
            BMSSCTID = id.ToString();
            //string targetDirectory = content.ToString().Trim();
            //string targetDirectory = path;

            targetfiles = targetDirectory;
            string[] fileEntries = Directory.GetDirectories(targetDirectory);
            for (int i = 0; i < fileEntries.Count(); i++)
            {
                ContentData1 Content = new ContentData1();
                Content.ID = (i + 1).ToString();
                Content.Name = fileEntries[i].ToString();
                details.Add(Content);
            }



        }
        else if (content.ToString().ToLower() == "files")
        {
            if (id.ToString() == "0")
            {
                targetfiles = Path.Combine(targetfiles);
            }
            else
            {
                targetfiles = Path.Combine(targetfiles + "\\" + id.ToString());
            }

            ContentData1 Content = new ContentData1();

            string foldername = id.ToString();
            string[] fileEntries = Directory.GetFiles(targetfiles);
            //for (int i = 0; i < fileEntries.Count(); i++)
            //{
            string url = HttpContext.Current.Request.Url.Authority.ToString() + HttpContext.Current.Request.ApplicationPath.ToString() + "/EduResource/" + BMSSCTID.ToString().Trim() + "/" + foldername.ToString().Trim() + "/";
            Content.ID = "http://" + url;
            Content.Name = fileEntries[0].ToString().Substring(fileEntries[0].ToString().LastIndexOf('\\') + 1);
            details.Add(Content);

         

        }


        else if (content.ToString().ToLower() == "viewcontent")
        {

            ContentData1 Content = new ContentData1();
            string url = HttpContext.Current.Request.Url.Authority.ToString() + HttpContext.Current.Request.ApplicationPath.ToString() + "/EduResource/" + BMSSCTID.ToString().Trim() + "/" + id.ToString().Trim() + "/";
            Content.ID = "http://" + url;
            Content.Name = id.ToString();
            details.Add(Content);


        }




        return details.ToArray();
    }

    public class ContentData1
    {
        public string ID { get; set; }
        public string Name { get; set; }


    }
}