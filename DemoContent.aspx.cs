using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Services;
using System.Data;
using System.IO;

public partial class DemoContent : System.Web.UI.Page
{
    //static string sysboardid;
    static string boardid1;
    static string mediumid;
    static string standardid;
    static string subjectid;
    static string chapterid;
    static string topicid;
    static string bmsid;
    static string path;
    static string path1;
    static string targetfiles;
    static string foldername;
    static string BMSSCTID;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            path = Server.MapPath("~/EduResource");
        }
        //  sysboardid = "1";
        //sysboardid = hdboardid.Value.ToString();
        //boardid1 = HiddenField1.Value.ToString();
        //mediumid = hdmediumid.Value.ToString();
        //standardid = hdstandardid.Value.ToString();

        //WebMsg.Show(path.ToString());

    }
    protected void btnexit_Click(object sender, EventArgs e)
    {
        Response.Redirect("Login.aspx", false);
    }

    [WebMethod]
    public static ContentData1[] GetContent(string content, string id)
    {


        DataTable dt = new DataTable();
        List<ContentData1> details = new List<ContentData1>();
        //List<string> details1 = new List<string>();


        using (SqlConnection con = new SqlConnection(@"Data Source=192.168.2.154\SQLEXPRESS;Initial Catalog=EPATHSHALA; User ID=sa;Password=swayam@123;"))
        {
            if (content.ToString().ToLower() == "board")
            {

                boardid1 = id;
                using (SqlCommand cmd = new SqlCommand("SELECT MediumID, Medium FROM SYS_Medium WHERE(IsActive = 1)", con))
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    foreach (DataRow dtrow in dt.Rows)
                    {

                        ContentData1 Content = new ContentData1();
                        Content.ID = dtrow["MediumID"].ToString();
                        Content.Name = dtrow["Medium"].ToString();

                        details.Add(Content);
                    }
                }

            }
            else if (content.ToString().ToLower() == "medium")
            {

                mediumid = id;
                using (SqlCommand cmd = new SqlCommand("SELECT StandardID, Standard FROM SYS_Standard WHERE(IsActive = 1) ORDER BY Code", con))
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dtrow in dt.Rows)
                        {

                            ContentData1 Content = new ContentData1();
                            Content.ID = dtrow["StandardID"].ToString();
                            Content.Name = dtrow["Standard"].ToString();

                            details.Add(Content);
                        }
                    }
                }

            }

            else if (content.ToString().ToLower() == "standard")
            {
                standardid = id;
                using (SqlCommand cmd = new SqlCommand("SELECT SubjectID, Subject FROM SYS_Subject WHERE(IsActive = 1)", con))
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dtrow in dt.Rows)
                        {

                            ContentData1 Content = new ContentData1();
                            Content.ID = dtrow["SubjectID"].ToString();
                            Content.Name = dtrow["Subject"].ToString();

                            details.Add(Content);
                        }
                    }
                }

            }

            else if (content.ToString().ToLower() == "subject")
            {
                subjectid = id;
                string query = "select bmsid from sys_bms where Boardid='" + boardid1 + "' and MediumID = '" + mediumid + "' and StandardID = '" + standardid + "'  ";
                SqlCommand cmd1 = new SqlCommand(query, con);
                con.Open();
                SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                da1.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    bmsid = dt.Rows[0]["BMSID"].ToString();


                    using (SqlCommand cmd = new SqlCommand("SELECT chapterid, chapter FROM SYS_Chapter WHERE(IsActive = 1 and BMSID='" + bmsid + "' and subjectid='" + id + "')", con))
                    {

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        dt = new DataTable();
                        da.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            foreach (DataRow dtrow in dt.Rows)
                            {

                                ContentData1 Content = new ContentData1();
                                Content.ID = dtrow["chapterid"].ToString();
                                Content.Name = dtrow["chapter"].ToString();

                                details.Add(Content);
                            }
                        }

                    }
                }


            }

            else if (content.ToString().ToLower() == "chapter")
            {
                chapterid = id;
                using (SqlCommand cmd = new SqlCommand("SELECT TopicID, Topic FROM SYS_Topic WHERE(IsActive = 1 and ChapterID = '" + id + "')", con))
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    foreach (DataRow dtrow in dt.Rows)
                    {

                        ContentData1 Content = new ContentData1();
                        Content.ID = dtrow["TopicID"].ToString();
                        Content.Name = dtrow["Topic"].ToString();

                        details.Add(Content);
                    }
                }

            }

            else if (content.ToString().ToLower() == "topic")
            {
                topicid = id;
                string query = "select sctid from sys_sct where subjectid='" + subjectid + "' and chapterid = '" + chapterid + "' and TopicID = '" + topicid + "'  ";
                SqlCommand cmd1 = new SqlCommand(query, con);
                con.Open();
                SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                dt = new DataTable();
                da1.Fill(dt);
                if (dt.Rows.Count > 0)
                {

                    string sctid = dt.Rows[0]["SCTID"].ToString();



                    query = "select BMSSCTID, IsAllowForDemo from SYS_BMS_SCT where bmsid='" + bmsid + "' and sctid = '" + sctid + "' and subjectid = '" + subjectid + "'  ";
                    cmd1 = new SqlCommand(query, con);
                    //con.Open();

                    da1 = new SqlDataAdapter(cmd1);
                    dt = new DataTable();
                    da1.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        string bmssctid = dt.Rows[0]["BMSSCTID"].ToString();
                        string IsAllowForDemo = dt.Rows[0]["IsAllowForDemo"].ToString();
                        BMSSCTID = bmssctid; ;
                        //string path = HttpContext.Current.Request.Url.Authority.ToString() + HttpContext.Current.Request.ApplicationPath.ToString() + "/EduResource/" + bmssctid.ToString().Trim();

                        if (IsAllowForDemo.ToString().ToLower() == "true")
                        {
                            string targetDirectory = Path.Combine(path + "\\" + bmssctid);
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
                        else
                        {
                            ContentData1 Content = new ContentData1();
                            Content.ID = "false";
                            Content.Name = "Demo not available " + Environment.NewLine + "Please register";
                            details.Add(Content);
                        }
                    }
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

                foldername = id.ToString();
                string[] fileEntries = Directory.GetFiles(targetfiles);
                //for (int i = 0; i < fileEntries.Count(); i++)
                //{
                string url = HttpContext.Current.Request.Url.Authority.ToString() + HttpContext.Current.Request.ApplicationPath.ToString() + "/EduResource/" + BMSSCTID.ToString().Trim() + "/" + foldername.ToString().Trim() + "/";
                Content.ID = "http://" + url;
                Content.Name = fileEntries[0].ToString().Substring(fileEntries[0].ToString().LastIndexOf('\\') + 1);
                details.Add(Content);

                //ContentData1 Content = new ContentData1();
                //Content.ID = (i + 1).ToString();
                //Content.Name = fileEntries[i].ToString();
                //details.Add(Content);
                //}

            }

            else if (content.ToString().ToLower() == "viewcontent")
            {

                ContentData1 Content = new ContentData1();

                //Content.ID = targetfiles + "\\";
                //string url = HttpContext.Current.Request.Url.AbsoluteUri;
                string url = HttpContext.Current.Request.Url.Authority.ToString() + HttpContext.Current.Request.ApplicationPath.ToString() + "/EduResource/" + BMSSCTID.ToString().Trim() + "/" + foldername.ToString().Trim() + "/";
                Content.ID = "http://" + url;
                Content.Name = id.ToString();
                details.Add(Content);


            }



        }
        return details.ToArray();
    }

    public class ContentData1
    {
        public string ID { get; set; }
        public string Name { get; set; }


    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        string path = string.Empty;

    }
}