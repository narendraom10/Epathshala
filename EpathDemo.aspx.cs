using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.IO;
using System.Web.UI.HtmlControls;
using System.Data;

public partial class EpathDemo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string VideoPath = Server.MapPath("~/EpathDemoVideo");
        string VideoFolder = string.Empty;
        DataTable oDataTable = new DataTable();
        if (!IsPostBack)
        {
            oDataTable.Columns.Add("DiaplayName", typeof(string));
            oDataTable.Columns.Add("ValueURL", typeof(string));
            oDataTable.Columns.Add("ImageURL", typeof(string));

            string ID = string.Empty;

            if (Request.QueryString["Id"] != null)
            {
                ID = Request.QueryString["Id"].ToString();
            }

            switch (ID)
            {
                case "GUJ":
                    VideoFolder = "GujaratBoard";
                    break;
                case "NCERT":
                    VideoFolder = "NCERTBoard";
                    break;
                case "CBSE":
                    VideoFolder = "CBSEBoard";
                    break;
                case "UP":
                    VideoFolder = "UPBoard";
                    break;
                default:
                    VideoFolder = "GujaratBoard";
                    break;
            }
            if (Directory.Exists(Path.Combine(VideoPath, VideoFolder)))
            {
                string[] Files = Directory.GetFiles(Path.Combine(VideoPath, VideoFolder));
                foreach (var file in Files)
                {
                    string FileNameExtention = Path.GetExtension(file);
                    string FileName = Path.GetFileName(file);
                    if (FileNameExtention == ".mp4")
                    {
                        oDataTable.Rows.Add(FileName.Replace(".mp4", ""), "EpathDemoVideo/" + VideoFolder + "/" + FileName + "", "EpathDemoVideo/" + VideoFolder + "/" + FileName.Replace(".mp4", "") + ".png");
                    }
                    else if (FileNameExtention == ".swf")
                    {
                        oDataTable.Rows.Add(FileName.Replace(".swf", ""), "EpathDemoVideo/" + VideoFolder + "/" + FileName + "", "EpathDemoVideo/" + VideoFolder + "/" + FileName.Replace(".swf", "") + ".png");
                    }
                }
            }
            grvList.DataSource = oDataTable;
            grvList.DataBind();
            if (oDataTable.Rows.Count > 1)
            {
                string url = Convert.ToString(oDataTable.Rows[0]["ValueURL"]);
                BindMainVideo(url);
            }
        }
    }
    private void BindMainVideo(string url)
    {
        if (url.Contains(".mp4"))
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("<video controls WIDTH='100%' HEIGHT='70%'>");
            builder.Append("<source type='video/mp4' src='" + url + "'></source>");
            builder.Append("</video>");
            dvMainVideo.InnerHtml = builder.ToString();

        }
        else if (url.Contains(".swf"))
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("<object id=\"myVideo1\" width=\"600\" height=\"450\" data=\"" + url + "\" type=\"application/x-shockwave-flash\">");
            builder.Append("<param value=\"sameDomain\" name=\"allowSc+riptAccess\" />");
            builder.Append("<param name=\"movie\" value=\"" + url + "\" />");
            builder.Append("<param name=\"quality\" value=\"best\" />");
            builder.Append("<param value=\"true\" name=\"controller\" />");
            builder.Append("<param name=\"play\" value=\"true\" />");
            builder.Append("<param name=\"loop\" value=\"true\" />");
            builder.Append("<param name=\"wmode\" value=\"window\" />");
            builder.Append("<param name=\"scale\" value=\"showall\" />");
            builder.Append("<param name=\"menu\" value=\"true\" />");
            builder.Append("<param name=\"devicefont\" value=\"false\" />");
            builder.Append("<param name=\"salign\" value=\"\" />");
            builder.Append("<param name=\"allowScriptAccess\" value=\"sameDomain\" />");
            builder.Append("</object>");
            dvMainVideo.InnerHtml = builder.ToString();
        }
    }
    protected void grvList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "ShowVideo")
        {
            ImageButton lb = (ImageButton)e.CommandSource;
            GridViewRow gvr = (GridViewRow)lb.NamingContainer;
            string url = Convert.ToString(e.CommandArgument);
            BindMainVideo(url);
        }
    }
}