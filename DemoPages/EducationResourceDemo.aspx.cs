using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data;
using System.Text.RegularExpressions;
using System.IO;

public partial class DemoPages_EducationResourceDemo : System.Web.UI.Page
{

    SimplerAES objeAes;
    SYS_TeacherActivityFeedback_BLogic objTA = new SYS_TeacherActivityFeedback_BLogic();
    SYS_TeacherActivityFeedback Obj_TeacherActivityFeedback = new SYS_TeacherActivityFeedback();
    DataTable dtChapterDemo = new DataTable();
    DataTable dtTopicDemo = new DataTable();


    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["dtChapterDemo"] != null)
        {
            dtChapterDemo = (DataTable)Session["dtChapterDemo"];
            dtTopicDemo = (DataTable)Session["dtTopicDemo"];
        }
        else
        {
            if (dtChapterDemo.Columns.Contains("Chapter"))
            {
            }
            else
            {
                dtChapterDemo.Columns.Add("ChapterID", typeof(string));
                dtChapterDemo.Columns.Add("Chapter", typeof(string));
                dtTopicDemo.Columns.Add("ChapterID", typeof(string));
                dtTopicDemo.Columns.Add("TopicID", typeof(string));
                dtTopicDemo.Columns.Add("Topic", typeof(string));
            }
        }

        if (!IsPostBack)
        {
            if (Session["DemoUserName"] != null)
            {
                lblWelcome.Text = "Welcome " + Session["DemoUserName"];
                FillResource();
            }
            else
            {
                Response.Redirect("Home.aspx");
            }


        }

    }

    protected void FillResource()
    {
        try
        {
            DataSet dsSettings = new DataSet();
            Teacher_Dashboard_BLogic obj_BAL_Teacher_Dashboard = new Teacher_Dashboard_BLogic();

            //TrackLog_Utils.Log(Convert.ToInt32(AppSessions.SchoolID), Convert.ToInt32(AppSessions.EmpolyeeID), Convert.ToInt16(AppSessions.DivisionID), "EducationResourcepage", "Page", "Load", Convert.ToDateTime(System.DateTime.Now), HttpContext.Current.Session.SessionID, StringEnum.stringValueOf(EnumFile.Activity.EducationResourcePage), "Education Resource Page  Loaded.", Convert.ToInt32(Session["BMSSCTID"]));

            lblSiteMap.Text = Session["DEMOBMSSDNameEduResource"].ToString();
            LblChapterTopic.Text = Session["DEMOChapterTopic"].ToString();
            objeAes = new SimplerAES();
            Int64 bmssctid = Convert.ToInt64(Session["DEMOBMSSCTID"]);
            String Path1 = Server.MapPath("../EduResource/" + bmssctid);

            lblSiteMap.ToolTip = bmssctid.ToString();
            if (Directory.Exists(Path1) == false)
            {
                Path1 = Server.MapPath("../EduResource/NoContent");
            }

            if (Directory.Exists(Path1))
            {
                string[] dirName = Directory.GetDirectories(Path1);
                int PathLen = Path1.Length + 1;

                DataTable dt = new DataTable();
                dt.Columns.Add("ResourcePath");
                dt.Columns.Add("Resource");
                dt.Columns.Add("Ext");
                DataRow dr;
                string strText = string.Empty;

                // Raff

                //bool Pretest;
                //if (getConfigValue("Pretest") == "1")
                //{
                //    Pretest = true;
                //}
                //else
                //{
                //    Pretest = false;
                //}
                //if (Pretest)
                //{
                //    if (AppSessions.StudentID != null && AppSessions.StudentID != 0)
                //    {
                //        dr = dt.NewRow();
                //        dr["Resource"] = "Pretest";
                //        dr["ResourcePath"] = "../Student/StudentAssessment.aspx?Level=0&TestType=Pretest";
                //        dr["Ext"] = ".Test";
                //        dt.Rows.Add(dr);
                //    }
                //    else
                //    {
                //        dr = dt.NewRow();
                //        dr["Resource"] = "Pretest";
                //        dr["ResourcePath"] = "../Teacher/TeacherAssessment.aspx?Level=0&TestType=Pretest";
                //        dr["Ext"] = ".Test";
                //        dt.Rows.Add(dr);
                //    }
                //}

                // Raff

                foreach (string st in dirName)
                {
                    string FullPath = string.Empty;
                    //string FullPath1 = string.Empty;
                    string FileName = string.Empty;
                    string ext = string.Empty;

                    string[] Files = Directory.GetFiles(Path1 + "\\" + st.Substring(PathLen) + "\\");

                    if (Files.Length > 0)
                    {
                        //FullPath1 = Path1 + "\\" + st.Substring(PathLen) + Files[0];
                        FileName = Path.GetFileName(Files[0]);
                        ext = Path.GetExtension(Files[0]);
                        ext = ext.ToLower();

                        if (ext.ToString().Equals(".scc"))
                        {
                            FileName = Path.GetFileName(Files[1]);
                            ext = Path.GetExtension(Files[1]);
                        }

                        FullPath = st + "\\" + FileName;


                        if (FileName != string.Empty)
                        {
                            dr = dt.NewRow();

                            if (FullPath.Contains("NoContent\\"))
                            {
                                FullPath = "../EduResource/" + "NoContent" + "/" + st.Substring(PathLen) + "/" + FileName;
                            }
                            else
                            {
                                FullPath = "../EduResource/" + bmssctid + "/" + st.Substring(PathLen) + "/" + FileName;
                            }

                            ext = ext.ToLower();
                            if (ext.ToString().Equals(".pdf"))
                            {
                                //strText += "<a href=\"../PDFViewer/web/viewer.html?lank=" + FullPath + " target=\"_blank\">" + st.Substring(PathLen) + "</a><br/><br/>";
                                //strText += "<a href=\"OpenPdf.aspx?FullPath=" + objeAes.Encrypt(FullPath) + "&FileName=" + objeAes.Encrypt(FileName) + "&DirName=" + objeAes.Encrypt(st.Substring(PathLen)) + "\" target=\"_blank\">" + st.Substring(PathLen) + "</a><br/><br/>";
                                dr["Resource"] = st.Substring(PathLen);
                                dr["ResourcePath"] = FullPath;
                                dr["Ext"] = ext;


                            }
                            else if (ext.ToString().Equals(".flv"))
                            {
                                // FullPath = "../EduResource/" + bmssctid + "/" + st.Substring(PathLen) + "/" + FileName;
                                //strText += "<a href=\"OpenFlv.aspx?FullPath=" + objeAes.Encrypt(FullPath) + "&ext=" + objeAes.Encrypt(ext) + "\" target=\"_blank\">" + st.Substring(PathLen) + "</a><br/><br/>";
                                dr["Resource"] = st.Substring(PathLen);
                                dr["ResourcePath"] = FullPath;
                                dr["Ext"] = ext;
                            }
                            else if (ext.ToString().Equals(".avi"))
                            {
                                //strText += "<a href=\"OpenFlv.aspx?FullPath=" + objeAes.Encrypt(FullPath) + "&ext=" + objeAes.Encrypt(ext) + "\" target=\"_blank\">" + st.Substring(PathLen) + "</a><br/><br/>";
                                dr["Resource"] = st.Substring(PathLen);
                                dr["ResourcePath"] = FullPath;
                                dr["Ext"] = ext;
                            }
                            else if (ext.ToString().Equals(".wmv"))
                            {
                                //strText += "<a href=\"OpenFlv.aspx?FullPath=" + objeAes.Encrypt(FullPath) + "&ext=" + objeAes.Encrypt(ext) + "\" target=\"_blank\">" + st.Substring(PathLen) + "</a><br/><br/>";
                                dr["Resource"] = st.Substring(PathLen);
                                dr["ResourcePath"] = FullPath;
                                dr["Ext"] = ext;
                            }
                            //else if (ext.ToString().Equals(".mp4"))
                            //{
                            //    //strText += "<a href=\"OpenFlv.aspx?FullPath=" + objeAes.Encrypt(FullPath) + "&ext=" + objeAes.Encrypt(ext) + "\" target=\"_blank\">" + st.Substring(PathLen) + "</a><br/><br/>";
                            //    dr["Resource"] = st.Substring(PathLen);
                            //    dr["ResourcePath"] = FullPath;
                            //    dr["Ext"] = ext;
                            //}
                            else if (ext.ToString().Equals(".swf") || ext.ToString().Equals(".mp4"))
                            {
                                dsSettings = obj_BAL_Teacher_Dashboard.BAL_Select_CoveredUncoverChapterTopic_Settings("UseEncrytion");
                                bool IsEncryption = Convert.ToBoolean(dsSettings.Tables[0].Rows[0]["value"].ToString());
                                if (IsEncryption)
                                {

                                    DirectoryInfo d = new DirectoryInfo(st);

                                    int i = 1;
                                    foreach (var file in Files)
                                    {
                                        FileName = Path.GetFileName(file);
                                        ext = Path.GetExtension(file);
                                        ext = ext.ToLower();

                                        if (ext.ToString().Equals(".scc"))
                                        {
                                            FileName = Path.GetFileName(file);
                                            ext = Path.GetExtension(file);
                                        }
                                        FullPath = st + "\\" + FileName;

                                        if (FullPath.Contains("NoContent\\"))
                                        {
                                            FullPath = "../EduResource/" + "NoContent" + "/" + st.Substring(PathLen) + "/" + FileName;
                                        }
                                        else
                                        {
                                            FullPath = "../EduResource/" + bmssctid + "/" + st.Substring(PathLen) + "/" + FileName;
                                        }

                                        dr = dt.NewRow();
                                        dr["Resource"] = st.Substring(PathLen) + " Part - " + i;
                                        dr["ResourcePath"] = FullPath;
                                        dr["Ext"] = ext;
                                        dt.Rows.Add(dr);
                                        i++;
                                    }
                                }
                                else
                                {
                                    dr["Resource"] = st.Substring(PathLen);
                                    dr["ResourcePath"] = FullPath;
                                    dr["Ext"] = ext;
                                    dt.Rows.Add(dr);
                                }
                            }
                            else if (ext.ToString().Equals(".htm") || ext.ToString().Equals(".html"))
                            {
                                dr["Resource"] = st.Substring(PathLen);
                                dr["ResourcePath"] = FullPath;
                                dr["Ext"] = ext;
                            }
                            else
                            {
                                dr = null;
                            }

                            if (dr != null)
                            {
                                if (!ext.ToString().Equals(".swf") && !ext.ToString().Equals(".mp4"))
                                    dt.Rows.Add(dr);
                            }
                        }
                    }
                }
                bool AllLevel;
                if (getConfigValue("AllLevel") == "0")
                {
                    AllLevel = true;
                }
                else
                {
                    AllLevel = false;
                }
                //bool PosttestAllow;
                //if (getConfigValue("Posttest") == "1")
                //{
                //    PosttestAllow = true;
                //}
                //else
                //{
                //    PosttestAllow = false;
                //}
                //if (PosttestAllow)
                //{
                //    if (AllLevel)
                //    {
                //        if (AppSessions.StudentID != null && AppSessions.StudentID != 0)
                //        {
                //            dr = dt.NewRow();
                //            dr["Resource"] = "Posttest";
                //            dr["ResourcePath"] = "../Student/StudentAssessment.aspx?Level=0&TestType=Posttest";
                //            dr["Ext"] = ".Test";
                //            dt.Rows.Add(dr);
                //        }
                //        else
                //        {
                //            dr = dt.NewRow();
                //            dr["Resource"] = "Posttest";
                //            dr["ResourcePath"] = "../Teacher/TeacherAssessment.aspx?Level=0&TestType=Posttest";
                //            dr["Ext"] = ".Test";
                //            dt.Rows.Add(dr);
                //        }
                //    }
                //    else
                //    {
                //        for (int n = 1; n < 4; n++)
                //        {
                //            if (AppSessions.StudentID != null && AppSessions.StudentID != 0)
                //            {
                //                dr = dt.NewRow();
                //                dr["Resource"] = "Posttest Level-" + n;
                //                dr["ResourcePath"] = "../Student/StudentAssessment.aspx?Level=" + n + "&TestType=Posttest";
                //                dr["Ext"] = ".Test";
                //                dt.Rows.Add(dr);
                //            }
                //            else
                //            {
                //                if (n == 1)
                //                {
                //                    dr = dt.NewRow();
                //                    dr["Resource"] = "Posttest Level-" + n;
                //                    dr["ResourcePath"] = "../Teacher/TeacherAssessment.aspx?Level=" + n + "&TestType=Posttest";
                //                    dr["Ext"] = ".Test";
                //                    dt.Rows.Add(dr);
                //                }
                //            }
                //        }
                //    }
                //}

                #region Filter By Sign - Note: $ for Student _ for teacher and Blank for All

                /*Step-1: Separate rows for student, teacher and common and remove sign*/
                /*Step-2: Identify login role*/
                /*Step-3: remove all other role's row*/

                List<DataRow> CommonFolder = new List<DataRow>();
                List<DataRow> TeacherFolder = new List<DataRow>();
                List<DataRow> StudentFolder = new List<DataRow>();

                foreach (DataRow oDr in dt.Rows)
                {
                    string foldername = Convert.ToString(oDr["Resource"]);
                    char cLastCharacter = foldername[foldername.Length - 1];

                    switch (cLastCharacter)
                    {
                        case '$':
                            oDr["Resource"] = foldername.Substring(0, foldername.Length - 1);
                            StudentFolder.Add(oDr);
                            break;
                        case '_':
                            oDr["Resource"] = foldername.Substring(0, foldername.Length - 1);
                            TeacherFolder.Add(oDr);
                            break;
                        default:
                            CommonFolder.Add(oDr);
                            break;
                    }
                }
                if (AppSessions.Role == "Teacher")
                {
                    foreach (DataRow drstudent in StudentFolder)
                    {
                        dt.Rows.Remove(drstudent);
                    }
                }
                else if (AppSessions.Role == "Student")
                {
                    foreach (DataRow drteacher in TeacherFolder)
                    {
                        dt.Rows.Remove(drteacher);
                    }
                }

                #endregion

                lrLinks.Text = HttpUtility.HtmlDecode(strText);
                ViewState["GridDt"] = dt;

                gvrecords.DataSource = (DataTable)ViewState["GridDt"];
                gvrecords.DataBind();
                //  AddNewFileSetting();
            }

        }
        catch (Exception ex)
        {

        }
    }

    private static string getConfigValue(string value)
    {
        string RndoKey = "";
        DataSet dsConfigSettings = new DataSet();

        SYS_TeacherActivityFeedback_BLogic objGetConfigValue = new SYS_TeacherActivityFeedback_BLogic();
        dsConfigSettings = objGetConfigValue.BAL_Select_IsActivityFeedback_Settings(value);

        if (dsConfigSettings.Tables.Count > 0)
        {
            if (dsConfigSettings.Tables[0].Rows.Count > 0)
            {
                RndoKey = dsConfigSettings.Tables[0].Rows[0]["value"].ToString();
            }
        }
        return RndoKey;
    }
    protected void btnupload_Click(object sender, EventArgs e)
    {

    }
    protected void btnreset2_Click(object sender, EventArgs e)
    {

    }

    protected void btnDisplay_Click(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.ToString().Equals("View"))
        {
            myframe.Attributes["style"] = "";
            mp1.Show();
            LblDisplay.Text = Session["DEMOChapterTopic"].ToString();
            Session["DashboardTopic"] = LblDisplay.Text;
            LinkButton lb = (LinkButton)e.CommandSource;
            GridViewRow gvr = (GridViewRow)lb.NamingContainer;
            string src = string.Empty;
            objeAes = new SimplerAES();
            try
            {
                string value = gvrecords.DataKeys[gvr.RowIndex].Values["ResourcePath"].ToString();
                string[] lines = Regex.Split(value, "/");
                string Actvty = lines[lines.Length - 2].ToString();
              //  bool IsNotAssessment = true;

                ViewState["FileName"] = lines[lines.Length - 1].ToString();

                //  TrackLog_Utils obj = new TrackLog_Utils();
                //  DataSet dsCheckLog = new DataSet();
                //  bool AllowToAssessment = false;
                //if (!IsNotAssessment)
                //{
                //    if (AppSessions.StudentID == 0)
                //    {
                //        dsCheckLog = obj.SELECTExamTrackLogOtherEmployee(AppSessions.BMSID, AppSessions.SchoolID, AppSessions.DivisionID, AppSessions.EmpolyeeID);
                //        if (dsCheckLog.Tables.Count > 0)
                //        {
                //            if (dsCheckLog.Tables[0].Rows.Count > 0)
                //            {
                //                if (dsCheckLog.Tables[0].Rows[0]["Activity"].ToString() == "Assessment" || dsCheckLog.Tables[0].Rows[0]["Activity"].ToString() == "Pretest")
                //                {
                //                    AllowToAssessment = false;
                //                    mp1.Hide();
                //                    WebMsg.Show("Assessment for the class is alredy running");
                //                }
                //                else
                //                {
                //                    AllowToAssessment = true;
                //                }
                //            }
                //            else
                //            {
                //                AllowToAssessment = true;
                //            }
                //        }
                //    }
                //    else { AllowToAssessment = true; }
                //}

                //if (AllowToAssessment || IsNotAssessment)
                //{

                //TrackLog_Utils.Log(Convert.ToInt32(AppSessions.SchoolID), Convert.ToInt32(AppSessions.EmpolyeeID), Convert.ToInt16(AppSessions.DivisionID), "EducationResourcepage", "lnkDisplay", "Click", Convert.ToDateTime(System.DateTime.Now), HttpContext.Current.Session.SessionID, Actvty, "View the " + lines[lines.Length - 1].ToString() + " File.", Convert.ToInt32(Session["BMSSCTID"]));
                Session["src"] = gvrecords.DataKeys[gvr.RowIndex].Values["ResourcePath"].ToString();
                Session["ext"] = gvrecords.DataKeys[gvr.RowIndex].Values["Ext"].ToString();

                if (gvrecords.DataKeys[gvr.RowIndex].Values["Ext"].ToString().Equals(".pdf"))
                {
                    //Session["ContentPath"] = gvrecords.DataKeys[gvr.RowIndex].Values["ResourcePath"].ToString();
                    //Session["ContentType"] = "application/pdf";
                    //HttpContext.Current.Session["ContentType"] = "application/pdf";

                    src = "../PDFViewer/web/viewer.html?lank=" + gvrecords.DataKeys[gvr.RowIndex].Values["ResourcePath"].ToString();
                    myframe.Attributes["src"] = src;
                    Session["myframesrc"] = src;
                    //src = "OpenFlv.aspx?FullPath=" + gvrecords.DataKeys[gvr.RowIndex].Values["ResourcePath"].ToString() + "&ext=" + gvrecords.DataKeys[gvr.RowIndex].Values["Ext"].ToString();
                    //myframe.Attributes["src"] = src;
                }
                else if (gvrecords.DataKeys[gvr.RowIndex].Values["Ext"].ToString().Equals(".flv"))
                {
                    src = "OpenFLVDemo.aspx?FullPath=" + gvrecords.DataKeys[gvr.RowIndex].Values["ResourcePath"].ToString() + "&ext=" + gvrecords.DataKeys[gvr.RowIndex].Values["Ext"].ToString();
                    myframe.Attributes["src"] = src;
                    Session["myframesrc"] = src;

                }
                else if (gvrecords.DataKeys[gvr.RowIndex].Values["Ext"].ToString().Equals(".swf"))
                {
                    src = "OpenFLVDemo.aspx?FullPath=" + gvrecords.DataKeys[gvr.RowIndex].Values["ResourcePath"].ToString() + "&ext=" + gvrecords.DataKeys[gvr.RowIndex].Values["Ext"].ToString();
                    myframe.Attributes["src"] = src;
                    Session["myframesrc"] = src;

                }
                else if (gvrecords.DataKeys[gvr.RowIndex].Values["Ext"].ToString().Equals(".avi"))
                {
                    src = "OpenFLVDemo.aspx?FullPath=" + gvrecords.DataKeys[gvr.RowIndex].Values["ResourcePath"].ToString() + "&ext=" + gvrecords.DataKeys[gvr.RowIndex].Values["Ext"].ToString();
                    myframe.Attributes["src"] = src;
                    Session["myframesrc"] = src;

                }

                else if (gvrecords.DataKeys[gvr.RowIndex].Values["Ext"].ToString().Equals(".mp4"))
                {
                    src = "OpenFLVDemo.aspx?FullPath=" + gvrecords.DataKeys[gvr.RowIndex].Values["ResourcePath"].ToString() + "&ext=" + gvrecords.DataKeys[gvr.RowIndex].Values["Ext"].ToString();
                    myframe.Attributes["src"] = src;
                    Session["myframesrc"] = src;

                    //string filename = "test.mp4";
                    //getExtension(filename);


                }
                else if (gvrecords.DataKeys[gvr.RowIndex].Values["Ext"].ToString().Equals(".html") || gvrecords.DataKeys[gvr.RowIndex].Values["Ext"].ToString().Equals(".htm"))
                {
                    src = gvrecords.DataKeys[gvr.RowIndex].Values["ResourcePath"].ToString();
                    myframe.Attributes["src"] = src;
                    Session["myframesrc"] = src;


                }
                //else if (gvrecords.DataKeys[gvr.RowIndex].Values["Ext"].ToString().Equals(".Test") || gvrecords.DataKeys[gvr.RowIndex].Values["Ext"].ToString().Equals(".Test"))
                //{
                //    DataSet dsCheckLogToTrackLog = new DataSet();
                //    dsCheckLogToTrackLog = obj.SELECTExamTrackLogOtherEmployee(AppSessions.BMSID, AppSessions.SchoolID, AppSessions.DivisionID, AppSessions.EmpolyeeID);
                //    if (dsCheckLogToTrackLog.Tables.Count > 0)
                //    {
                //        if (dsCheckLogToTrackLog.Tables[0].Rows.Count > 0)
                //        {
                //            if (dsCheckLogToTrackLog.Tables[0].Rows[0]["Activity"].ToString() == "Posttest" || dsCheckLogToTrackLog.Tables[0].Rows[0]["Activity"].ToString() == "Pretest")
                //            {
                //                Hashtable Question = (Hashtable)Application["Exam_TeacherSheResult"];
                //                if (Question == null)
                //                {
                //                    Question = new Hashtable();
                //                }
                //                else
                //                {
                //                    if (Session["TrackLogID"] != null)
                //                    {
                //                        try
                //                        {
                //                            Question.Remove(Session["TrackLogID"].ToString());
                //                            Application.Lock();
                //                            Application["Exam_TeacherSheResult"] = Question;
                //                            Application.UnLock();
                //                        }
                //                        catch (Exception ex)
                //                        { }
                //                    }

                //                }

                //                Session["TrackLogID"] = dsCheckLogToTrackLog.Tables[0].Rows[0]["TrackLogID"].ToString();

                //            }
                //        }
                //    }
                //    src = gvrecords.DataKeys[gvr.RowIndex].Values["ResourcePath"].ToString() + "&BMSSCTID=" + Convert.ToInt32(Session["BMSSCTID"]) + "";


                //    myframe.Attributes["src"] = src;
                //    if (AppSessions.StudentID == 0)
                //    { myframe.Style.Add("height", "550px"); }
                //    else
                //    {
                //        myframe.Style.Add("height", "450px");
                //    }
                //}
                //}
                //else
                //{
                //    //WebMsg.Show("Selected class exam alredy running");
                //  }


            }
            catch (FileNotFoundException ex)
            {
                WebMsg.Show("No File Exists" + ex.StackTrace);
            }
            catch (Exception ex)
            {
                WebMsg.Show("No File Exists");
            }
        }
    }

    protected void gvrecords_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string Activity = Covered();


            ////Literal ltQuestion = (Literal)e.Row.FindControl("ltQuestion");
            ////Literal lblCorrect = (Literal)e.Row.FindControl("lblCorrect");

            ////ltQuestion.Text = 

            GridViewRow gr = e.Row;
            Label lb = (Label)gr.FindControl("lblResourcePath");
            string[] lines = Regex.Split(lb.Text, "/");
            string Actvty = lines[lines.Length - 2].ToString();
            if (Actvty == "Student" || Actvty == "Teacher")
            {
                Actvty = "Posttest";
            }
            if (Activity.Contains(Actvty))
            {
                if (DataBinder.Eval(e.Row.DataItem, "Resource").ToString() != "Pretest")
                {
                    // Label lblStatus = (Label)gr.FindControl("lblmsg");
                    //lblStatus.Text = "Covered";
                    //lblStatus.Text += "" + "<img src='http://localhost:34301/Epathshala/App_Themes/Images/Tick_mark_green_3d.png'>";
                    //ImageButton img = (ImageButton)gr.FindControl("BtnQuesSave");
                    //img.Visible = true;
                }

            }
            if (Activity == DataBinder.Eval(e.Row.DataItem, "Resource").ToString())
            {
                //Label lblStatus = (Label)gr.FindControl("lblmsg");
                //lblStatus.Text = "Covered";
                //lblStatus.Text += "" + "<img src='http://localhost:34301/Epathshala/App_Themes/Images/Tick_mark_green_3d.png'>";
            }
        }
    }

    private string Covered()
    {
        Obj_TeacherActivityFeedback.BMSSCTID = Convert.ToInt32(Session["BMSSCTID"]);
        Obj_TeacherActivityFeedback.DivisionID = AppSessions.DivisionID;
        return objTA.Covered(Obj_TeacherActivityFeedback);
    }




    protected void btnFinishActStudent_Click(object sender, EventArgs e)
    {

        DataRow dtrow = dtChapterDemo.NewRow();
        DataRow dtrow1 = dtTopicDemo.NewRow();

        var found = dtChapterDemo.Select("Chapter = '" + Session["DemoChapter"].ToString() + "'");
        if (found.Length != 0)
        {

        }
        else
        {
            dtrow["ChapterID"] = Session["DemoChapterID"];
            dtrow["Chapter"] = Session["DemoChapter"].ToString();
            dtChapterDemo.Rows.Add(dtrow);
            Session["dtChapterDemo"] = dtChapterDemo;
            Session["LastDemoChapter"] = Session["DemoChapter"].ToString();


        }

        var found1 = dtTopicDemo.Select("Topic = '" + Session["DemoTopic"].ToString() + "'");
        if (found1.Length != 0)
        {

        }
        else
        {
            dtrow1["ChapterID"] = Session["DemoChapterID"];
            dtrow1["TopicID"] = Session["DemoTopicID"].ToString();
            dtrow1["Topic"] = Session["DemoTopic"];
            dtTopicDemo.Rows.Add(dtrow1);
            Session["dtTopicDemo"] = dtTopicDemo;
            Session["LastDemoTopic"] = Session["DemoTopic"].ToString();
        }

        WebMsg.Show("This topic covered sucessfully");
        Response.Redirect("../Dashboard/StudentDashboardDemo.aspx");
    }

    private void StudentFeedbackQuestionBind(GridView dvFeedback, TextBox Feedback)
    {
        DataTable dt = new DataTable();
        Feedback_BLogic objFeedback = new Feedback_BLogic();
        Obj_TeacherActivityFeedback.SchoolID = AppSessions.SchoolID;
        Obj_TeacherActivityFeedback.BMSSCTID = Convert.ToInt32(Session["DEMOBMSSCTID"]);
        Obj_TeacherActivityFeedback.StudentID = AppSessions.StudentID;
        Obj_TeacherActivityFeedback.DivisionID = AppSessions.DivisionID;
        Obj_TeacherActivityFeedback.CreatedBy = AppSessions.StudentID;

        dt = objFeedback.GetFeedbackDetailStudent(Obj_TeacherActivityFeedback);
        if (dt.Rows.Count > 0)
        {
            Feedback.Text = dt.Rows[0]["Feedback"].ToString();

            dvFeedback.DataSource = dt;
            dvFeedback.DataBind();
        }
        else
        {
            dvFeedback.DataSource = null;
            dvFeedback.DataBind();
        }
    }
    //protected void btnFeedback_Click(object sender, EventArgs e)
    //{

    //}
    //protected void btnBack_Click(object sender, EventArgs e)
    //{

    //}
    //protected void btnClose_Click(object sender, ImageClickEventArgs e)
    //{

    //}
    //protected void btnOK_Click(object sender, EventArgs e)
    //{

    //}
    //protected void btnReset_Click(object sender, EventArgs e)
    //{

    //}
    //protected void btnOK1_Click(object sender, EventArgs e)
    //{

    //}
    //protected void btnReset1_Click(object sender, EventArgs e)
    //{

    //}
    protected void lbtnSignOut_Click(object sender, EventArgs e)
    {
        Session["dtChapterDemo"] = null;
        Session["dtTopicDemo"] = null;

        Response.Redirect("../DemoPages/Home.aspx");

    }
}