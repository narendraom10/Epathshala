using System;
using System.IO;
using System.Globalization;
using Udev.UserMasterPage.Classes;
using System.Web;
using System.Web.UI.WebControls;
using System.Data;
using System.Text.RegularExpressions;
using System.Configuration;
using System.Web.UI;
using System.Collections;
using System.Web.Configuration;
using System.Collections.Generic;
using System.Text;
using System.Collections.Specialized;


public partial class Dashboard_EducationalResource : System.Web.UI.Page
{
    #region Variables

    ClassRoomActivityLog_BLogic BAL_ClassRoomActivityLog;
    ClassRoomActivityLog ClassRoomActivityLog;
    SimplerAES objeAes;
    DataSet dsSettings = new DataSet();
    Teacher_Dashboard_BLogic obj_BAL_Teacher_Dashboard = new Teacher_Dashboard_BLogic();
    SYS_TeacherActivityFeedback_BLogic objTA = new SYS_TeacherActivityFeedback_BLogic();
    SYS_TeacherActivityFeedback Obj_TeacherActivityFeedback = new SYS_TeacherActivityFeedback();

    #endregion

    #region Culture

    protected override void InitializeCulture()
    {
        string culture = Convert.ToString(Session[Global.SESSION_KEY_CULTURE]);
        // 'set culture to current thread 
        System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture);
        System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);
        //call base class 
        base.InitializeCulture();
    }

    #endregion

    #region Prpperties

    ArrayList _AttchmentList = new ArrayList();
    public string _Templatetitle = string.Empty;

    public ArrayList AttchmentList
    {
        get { return _AttchmentList; }
        set { _AttchmentList = value; }
    }
    public string Templatetitle
    {
        get { return _Templatetitle; }
        set { _Templatetitle = value; }
    }

    #endregion

    #region Page Load

    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        if (!IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["frm"]))
            {
                if (Request.QueryString["frm"] == "oxford")
                {
                    LblDisplay.Text = AppSessions.BMS + " >> " + AppSessions.Subject;
                    ViewState["oxford"] = "oxford";

                    
                    

                    //myframe.Style.Add("border","none;");
                    //myframe.Style.Add("min-height", "100%");

                    //myframe.Style.Add("overflow", "auto");
                    //myframe.Style.Add("min-height", "375px");
                    //myframe.Style.Add("max-height", "850px");
                    //myframe.Style.Add("overflow-y", "scroll");
                    //myframe.Style.Add("display", "block");
                    //myframe.Style.Add("border", "none");
                    //myframe.Style.Add("min-height", "100%");

                    mp1.Show();

                    string[] standard = AppSessions.Board.Split(new string[] { ">>" }, StringSplitOptions.RemoveEmptyEntries);
                    string path = Server.MapPath("../EduResource/oxford/" + standard[2].Trim() + "/" + AppSessions.Subject);

                    string[] Files = Directory.GetFiles(path);

                    if (Files.Length > 0)
                    {
                        string FileName = Path.GetFileName(Files[0]);
                        string ext = Path.GetExtension(Files[0]);
                        ext = ext.ToLower();
                        if (ext.Equals(".html"))
                        {
                            myframe.Attributes["src"] = string.Concat("../EduResource/oxford/", standard[2].Trim(), "/", AppSessions.Subject, "/", FileName);
                        }
                        else if (ext.Equals(".swf"))
                        {
                            myframe.Attributes["src"] = "OpenFlv.aspx?FullPath=" + string.Concat("../EduResource/oxford/", standard[2].Trim(), "/", AppSessions.Subject, "/", FileName) + "&ext=" + ext;
                        }
                        else
                        {
                            WebMsg.Show("Files should be html or swf.");
                        }
                    }
                    else
                    {
                        WebMsg.Show("Content not available in folder.");
                    }
                }
                else
                {
                    ViewState["oxford"] = "";
                    FillResource();
                }
            }
            else
            {
                ViewState["oxford"] = "";
                FillResource();
            }
            BindActionGrid();
            if (AppSessions.IsAllowSendEmail)
                btnchooseAction.Visible = true;
            else
                btnchooseAction.Visible = false;
        }
    }

    private void BindActionGrid()
    {
        Template_BLogic BAL_Template = new Template_BLogic();
        Template oTemplate = new Template();

        oTemplate.Templatepath = Server.MapPath("~/Template");

        gvtemplate.DataSource = BAL_Template.BAL_Template_SelectALL(oTemplate);
        gvtemplate.DataBind();
    }

    #endregion

    #region Control Events

    protected void btnFinishActivity_Click(object sender, EventArgs e)
    {
        dsSettings = objTA.BAL_Select_IsActivityFeedback_Settings("IsActivityFeedback");

        object datatype = dsSettings.Tables[0].Rows[0]["Type"].ToString();
        object val = dsSettings.Tables[0].Rows[0]["value"].ToString();
        if (Convert.ToBoolean(Convert.ToInt16(val)))
        {
            LblDisplay.Text = "Teacher Feedback";
            LblDisplay.CssClass = "right_left";
            this.mpfeedback.Show();
            BindFeedbackQuestion(grdFeedback, txtFeedback);
        }
        else
        {
            SaveFinishActivity();
        }
    }
    protected void btnFinishActStudent_Click(object sender, EventArgs e)
    {
        dsSettings = objTA.BAL_Select_IsActivityFeedback_Settings("IsActivityFeedbackForStudent");

        object datatype = dsSettings.Tables[0].Rows[0]["Type"].ToString();
        object val = dsSettings.Tables[0].Rows[0]["value"].ToString();
        if (Convert.ToBoolean(Convert.ToInt16(val)))
        {
            this.mpfeedback.Show();
            BindFeedbackQuestion(grdFeedback, txtFeedback);
        }
        else
        {
            SaveStudentFinishActivity();
        }
    }
    protected void btnReset1_Click(object sender, EventArgs e)
    {
        ResetFeedbackControls(grdFeedback1, txtFeedback1);
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        ResetFeedbackControls(grdFeedback, txtFeedback);
    }
    protected void btnSend_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in gvrecords.Rows)
        {
            CheckBox chk = (CheckBox)row.FindControl("chkSelect");
            if (chk.Checked)
            {
                Label lblpath = (Label)row.FindControl("lblResourcePath");
                AttchmentList.Add(Server.MapPath(lblpath.Text));
            }
        }

        foreach (GridViewRow row in gvtemplate.Rows)
        {
            CheckBox chk = (CheckBox)row.FindControl("chkSelecttemplate");
            if (chk.Checked)
            {
                Label lblpath = (Label)row.FindControl("GV_LblTemplateName");
                Templatetitle = lblpath.Text;
            }
        }
    }
    protected void btnClose_Click(object sender, EventArgs e)
    {
        if (AppSessions.StudentID == 0)
        {
            Hashtable Question = (Hashtable)Application["Exam_TeacherSheResult"];
            if (Question == null)
            {
                Question = new Hashtable();
            }
            else
            {
                if (Session["TrackLogID"] != null)
                {
                    try
                    {
                        Question.Remove(Session["TrackLogID"].ToString());
                        Application.Lock();
                        Application["Exam_TeacherSheResult"] = Question;
                        Application.UnLock();
                    }
                    catch (Exception ex)
                    { }
                }

            }
        }
        if (Convert.ToString(ViewState["oxford"]) == "oxford")
        {
            myframe.Attributes["src"] = null;
            myframe.InnerHtml = "";
            myframe.InnerText = "";
            myframe.Dispose();
            mp1.Hide();

            if (AppSessions.Role == "Teacher")
                Response.Redirect("TeacherDashboard.aspx");
            else if (AppSessions.Role == "Student")
                Response.Redirect("StudentDashboard.aspx");
        }
        else
        {
            gvrecords.DataSource = (DataTable)ViewState["GridDt"];
            gvrecords.DataBind();
            if (ViewState["FileName"] != null)
                TrackLog_Utils.Log(Convert.ToInt32(AppSessions.SchoolID), Convert.ToInt32(AppSessions.EmpolyeeID), Convert.ToInt16(AppSessions.DivisionID), "EducationResourcepage", "btnClose", "Click", Convert.ToDateTime(System.DateTime.Now), HttpContext.Current.Session.SessionID, StringEnum.stringValueOf(EnumFile.Activity.ActivityClosed), "Close Activity : " + ViewState["FileName"].ToString(), Convert.ToInt32(Session["BMSSCTID"]));
            myframe.Attributes["src"] = null;
            myframe.InnerHtml = "";
            myframe.InnerText = "";
            myframe.Dispose();
            mp1.Hide();
        }
    }
    protected void btnOK_Click(object sender, EventArgs e)
    {
        try
        {
            if (ViewState["UserType"].ToString() == "Student")
            {
                SaveStudentFinishActivity();
            }
            else if (ViewState["UserType"].ToString() == "Teacher")
            {
                SaveFinishActivity();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnFeedback_Click(object sender, EventArgs e)
    {
        this.mpFeedback1.Show();
        BindFeedbackQuestion(grdFeedback1, txtFeedback1);
    }
    protected void btnOK1_Click(object sender, EventArgs e)
    {
        try
        {
            if (ViewState["UserType"].ToString() == "Teacher")
            {
                ClassRoomActivityLog = new ClassRoomActivityLog();
                BAL_ClassRoomActivityLog = new ClassRoomActivityLog_BLogic();

                ClassRoomActivityLog.bmssctid = Convert.ToInt64(Session["BMSSCTID"]);
                ClassRoomActivityLog.schoolid = Convert.ToInt64(Session["SchoolID"]);
                ClassRoomActivityLog.employeeid = Convert.ToInt64(Session["EmpolyeeID"]);
                ClassRoomActivityLog.divisionid = Convert.ToInt16(Session["DivisionID"]);

                TrackLog_Utils.Log(Convert.ToInt32(AppSessions.SchoolID), Convert.ToInt32(AppSessions.EmpolyeeID), Convert.ToInt16(AppSessions.DivisionID), "EducationResourcepage", "btnFinishActivity", "Click", Convert.ToDateTime(System.DateTime.Now), HttpContext.Current.Session.SessionID, StringEnum.stringValueOf(EnumFile.Activity.AllActivityFinished), "Feedback on BMSSCT ID : " + Convert.ToInt32(Session["BMSSCTID"]), Convert.ToInt32(Session["BMSSCTID"]));
            }

            InsertFeedback(grdFeedback1, txtFeedback1);

            WebMsg.Show("Thank you for your feedback.");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("SearchResult.aspx?key=" + ViewState["key"] + "");
    }
    protected void btnupload_Click(object sender, EventArgs e)
    {

        //  Response.Write("button click");
        try
        {

            //string filepath = Server.MapPath(FileUpload1.FileName);
            //WebMsg.Show("upload click");

            if ((FileUpload1.PostedFile != null) && (FileUpload1.PostedFile.ContentLength > 0))
            {
                string fileExtension = System.IO.Path.GetExtension(FileUpload1.PostedFile.FileName).ToLower();
                string[] allowedExtensions = { ".mp4", ".swf", ".pdf" };
                string validfile = "false";

                string fn = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
                //Response.Write(fn);
                //string DestinationLocation = Convert.ToString(Session["BMSSCTID"]);
                //string SaveLocation = Server.MapPath("..\\EduResource") + "\\" + DestinationLocation;


                for (int i = 0; i < allowedExtensions.Length; i++)
                {
                    if (fileExtension == allowedExtensions[i])
                    {
                        string DestinationLocation = Convert.ToString(Session["BMSSCTID"]);
                        string dirpath;
                        if (rbstudent.Checked)
                            dirpath = Path.Combine(Server.MapPath("..\\EduResource\\" + DestinationLocation + "\\" + txtfoldername.Text + "$"));
                        else if (rbteacher.Checked)
                            dirpath = Path.Combine(Server.MapPath("..\\EduResource\\" + DestinationLocation + "\\" + txtfoldername.Text + "_"));
                        else
                            dirpath = Path.Combine(Server.MapPath("..\\EduResource\\" + DestinationLocation + "\\" + txtfoldername.Text));

                        //Response.Write(dirpath);
                        if (!Directory.Exists(dirpath))
                        {
                            //Response.Write(dirpath);
                            Directory.CreateDirectory(dirpath);
                            string fileName = Path.Combine(dirpath, System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName));
                            //Response.Write(fileName);
                            //FileUpload1.PostedFile.SaveAs(
                            //WebMsg.Show(fileName);
                            FileUpload1.PostedFile.SaveAs(fileName);
                            validfile = "true";

                            //if (validfile != "true")
                            //{
                            //    WebMsg.Show("Please select valid file");
                            //}
                            //else
                            //{
                            WebMsg.Show("File uploaded sucessfully");
                            FillResource();
                            txtfoldername.Text = string.Empty;
                            pnladdfile.Collapsed = true;
                            pnladdfile.ClientState = "true";
                            //  }
                            //WebMsg.Show(dirpath);
                        }
                        else
                        {
                            //validfile = "true";
                            WebMsg.Show("This resource already exist please select again....");


                        }


                        //Response.Write(dirpath);

                        ////FileUpload1.SaveAs(fileName);
                        //validfile = "true";
                    }
                }


            }

            else
            {
                WebMsg.Show("Please select file....");
            }


            //if (FileUpload1.HasFile)
            //{
            //    string fileExtension = System.IO.Path.GetExtension(FileUpload1.FileName).ToLower();
            //    string[] allowedExtensions = { ".mp4", ".swf", ".pdf" };
            //    string validfile = "false";
            //    Response.Write(fileExtension);
            //    for (int i = 0; i < allowedExtensions.Length; i++)
            //    {
            //        if (fileExtension == allowedExtensions[i])
            //        {
            //            string DestinationLocation = Convert.ToString(Session["BMSSCTID"]);
            //            string dirpath;
            //            if (rbstudent.Checked)
            //                dirpath = Path.Combine(Server.MapPath("~/EduResource/" + DestinationLocation + "/" + txtfoldername.Text + "$"));
            //            else if (rbteacher.Checked)
            //                dirpath = Path.Combine(Server.MapPath("~/EduResource/" + DestinationLocation + "/" + txtfoldername.Text + "_"));
            //            else
            //                dirpath = Path.Combine(Server.MapPath("~/EduResource/" + DestinationLocation + "/" + txtfoldername.Text));
            //            if (!Directory.Exists(dirpath))
            //            {

            //                Directory.CreateDirectory(dirpath);

            //                Response.Write(dirpath);
            //                WebMsg.Show(dirpath);
            //            }


            //            Response.Write(dirpath);
            //            string fileName = Path.Combine(dirpath, FileUpload1.FileName);
            //            Response.Write(fileName);
            //            WebMsg.Show(fileName);

            //            FileUpload1.SaveAs(fileName);
            //            validfile = "true";
            //        }
            //    }

            //    if (validfile != "true")
            //    {
            //        WebMsg.Show("Please select valid file");
            //    }
            //    else
            //    {
            //        WebMsg.Show("File uploaded sucessfully");
            //        FillResource();
            //        txtfoldername.Text = string.Empty;
            //        pnladdfile.Collapsed = true;
            //        pnladdfile.ClientState = "true";



            //        //gvrecords.DataSource = (DataTable)ViewState["GridDt"];
            //        //gvrecords.DataBind();
            //    }
            //}
            //else
            //{
            //    WebMsg.Show("Please select file....");
            //}
        }
        catch (Exception ex)
        {

        }

    }
    protected void btnreset2_Click(object sender, EventArgs e)
    {
        ClearAddContentControls();
    }

    protected void btnDisplay_Click(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.ToString().Equals("View"))
        {
            myframe.Attributes["style"] = "";
            mp1.Show();
            LblDisplay.Text = Session["ChapterTopic"].ToString();
            LinkButton lb = (LinkButton)e.CommandSource;
            GridViewRow gvr = (GridViewRow)lb.NamingContainer;
            string src = string.Empty;
            objeAes = new SimplerAES();
            try
            {
                string value = gvrecords.DataKeys[gvr.RowIndex].Values["ResourcePath"].ToString();
                string[] lines = Regex.Split(value, "/");
                string Actvty = lines[lines.Length - 2].ToString();
                bool IsNotAssessment = true;
                if (Actvty == "Student" || Actvty == "Teacher")
                {
                    if (gvrecords.DataKeys[gvr.RowIndex].Values["Resource"].ToString() == "Pretest")
                    {
                        Actvty = "Pretest";
                    }
                    else
                    {
                        Actvty = "Posttest";
                    }
                    IsNotAssessment = false;
                }
                ViewState["FileName"] = lines[lines.Length - 1].ToString();
                //AppSessions.BMSID
                //
                //
                //
                //
                //
                TrackLog_Utils obj = new TrackLog_Utils();
                DataSet dsCheckLog = new DataSet();
                bool AllowToAssessment = false;
                if (!IsNotAssessment)
                {
                    if (AppSessions.StudentID == 0)
                    {
                        dsCheckLog = obj.SELECTExamTrackLogOtherEmployee(AppSessions.BMSID, AppSessions.SchoolID, AppSessions.DivisionID, AppSessions.EmpolyeeID);
                        if (dsCheckLog.Tables.Count > 0)
                        {
                            if (dsCheckLog.Tables[0].Rows.Count > 0)
                            {
                                if (dsCheckLog.Tables[0].Rows[0]["Activity"].ToString() == "Assessment" || dsCheckLog.Tables[0].Rows[0]["Activity"].ToString() == "Pretest")
                                {
                                    AllowToAssessment = false;
                                    mp1.Hide();
                                    WebMsg.Show("Assessment for the class is alredy running");
                                }
                                else
                                {
                                    AllowToAssessment = true;
                                }
                            }
                            else
                            {
                                AllowToAssessment = true;
                            }
                        }
                    }
                    else { AllowToAssessment = true; }
                }

                if (AllowToAssessment || IsNotAssessment)
                {

                    TrackLog_Utils.Log(Convert.ToInt32(AppSessions.SchoolID), Convert.ToInt32(AppSessions.EmpolyeeID), Convert.ToInt16(AppSessions.DivisionID), "EducationResourcepage", "lnkDisplay", "Click", Convert.ToDateTime(System.DateTime.Now), HttpContext.Current.Session.SessionID, Actvty, "View the " + lines[lines.Length - 1].ToString() + " File.", Convert.ToInt32(Session["BMSSCTID"]));

                    if (gvrecords.DataKeys[gvr.RowIndex].Values["Ext"].ToString().Equals(".pdf"))
                    {
                        //Session["ContentPath"] = gvrecords.DataKeys[gvr.RowIndex].Values["ResourcePath"].ToString();
                        //Session["ContentType"] = "application/pdf";
                        //HttpContext.Current.Session["ContentType"] = "application/pdf";

                        src = "../PDFViewer/web/viewer.html?lank=" + gvrecords.DataKeys[gvr.RowIndex].Values["ResourcePath"].ToString();
                        myframe.Attributes["src"] = src;
                        //src = "OpenFlv.aspx?FullPath=" + gvrecords.DataKeys[gvr.RowIndex].Values["ResourcePath"].ToString() + "&ext=" + gvrecords.DataKeys[gvr.RowIndex].Values["Ext"].ToString();
                        //myframe.Attributes["src"] = src;
                    }
                    else if (gvrecords.DataKeys[gvr.RowIndex].Values["Ext"].ToString().Equals(".flv"))
                    {
                        src = "OpenFlv.aspx?FullPath=" + gvrecords.DataKeys[gvr.RowIndex].Values["ResourcePath"].ToString() + "&ext=" + gvrecords.DataKeys[gvr.RowIndex].Values["Ext"].ToString();
                        myframe.Attributes["src"] = src;
                    }
                    else if (gvrecords.DataKeys[gvr.RowIndex].Values["Ext"].ToString().Equals(".swf"))
                    {
                        src = "OpenFlv.aspx?FullPath=" + gvrecords.DataKeys[gvr.RowIndex].Values["ResourcePath"].ToString() + "&ext=" + gvrecords.DataKeys[gvr.RowIndex].Values["Ext"].ToString();
                        myframe.Attributes["src"] = src;
                    }
                    else if (gvrecords.DataKeys[gvr.RowIndex].Values["Ext"].ToString().Equals(".avi"))
                    {
                        src = "OpenFlv.aspx?FullPath=" + gvrecords.DataKeys[gvr.RowIndex].Values["ResourcePath"].ToString() + "&ext=" + gvrecords.DataKeys[gvr.RowIndex].Values["Ext"].ToString();
                        myframe.Attributes["src"] = src;
                    }

                    else if (gvrecords.DataKeys[gvr.RowIndex].Values["Ext"].ToString().Equals(".mp4"))
                    {
                        src = "OpenFlv.aspx?FullPath=" + gvrecords.DataKeys[gvr.RowIndex].Values["ResourcePath"].ToString() + "&ext=" + gvrecords.DataKeys[gvr.RowIndex].Values["Ext"].ToString();
                        myframe.Attributes["src"] = src;
                        //string filename = "test.mp4";
                        //getExtension(filename);


                    }
                    else if (gvrecords.DataKeys[gvr.RowIndex].Values["Ext"].ToString().Equals(".html") || gvrecords.DataKeys[gvr.RowIndex].Values["Ext"].ToString().Equals(".htm"))
                    {
                        src = gvrecords.DataKeys[gvr.RowIndex].Values["ResourcePath"].ToString();
                        myframe.Attributes["src"] = src;
                    }
                    else if (gvrecords.DataKeys[gvr.RowIndex].Values["Ext"].ToString().Equals(".Test") || gvrecords.DataKeys[gvr.RowIndex].Values["Ext"].ToString().Equals(".Test"))
                    {
                        DataSet dsCheckLogToTrackLog = new DataSet();
                        dsCheckLogToTrackLog = obj.SELECTExamTrackLogOtherEmployee(AppSessions.BMSID, AppSessions.SchoolID, AppSessions.DivisionID, AppSessions.EmpolyeeID);
                        if (dsCheckLogToTrackLog.Tables.Count > 0)
                        {
                            if (dsCheckLogToTrackLog.Tables[0].Rows.Count > 0)
                            {
                                if (dsCheckLogToTrackLog.Tables[0].Rows[0]["Activity"].ToString() == "Posttest" || dsCheckLogToTrackLog.Tables[0].Rows[0]["Activity"].ToString() == "Pretest")
                                {
                                    Hashtable Question = (Hashtable)Application["Exam_TeacherSheResult"];
                                    if (Question == null)
                                    {
                                        Question = new Hashtable();
                                    }
                                    else
                                    {
                                        if (Session["TrackLogID"] != null)
                                        {
                                            try
                                            {
                                                Question.Remove(Session["TrackLogID"].ToString());
                                                Application.Lock();
                                                Application["Exam_TeacherSheResult"] = Question;
                                                Application.UnLock();
                                            }
                                            catch (Exception ex)
                                            { }
                                        }

                                    }

                                    Session["TrackLogID"] = dsCheckLogToTrackLog.Tables[0].Rows[0]["TrackLogID"].ToString();

                                }
                            }
                        }
                        src = gvrecords.DataKeys[gvr.RowIndex].Values["ResourcePath"].ToString() + "&BMSSCTID=" + Convert.ToInt32(Session["BMSSCTID"]) + "";
                        myframe.Attributes["src"] = src;
                        if (AppSessions.StudentID == 0)
                        { myframe.Style.Add("height", "550px"); }
                        else
                        {
                            myframe.Style.Add("overflow-x", "auto");
                            myframe.Style.Add("border", "none");
                            myframe.Style.Add("min-height", "95%");
    
                        }
                    }
                }
                else
                {
                    WebMsg.Show("Selected class exam alredy running");
                }
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
            if (Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Ext")).ToLower() != ".pdf")
            {
                CheckBox chk = (CheckBox)e.Row.FindControl("chkSelect");
                chk.Enabled = false;
            }
        }

        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    string Activity = Covered();


        //    ////Literal ltQuestion = (Literal)e.Row.FindControl("ltQuestion");
        //    ////Literal lblCorrect = (Literal)e.Row.FindControl("lblCorrect");

        //    ////ltQuestion.Text = 

        //    GridViewRow gr = e.Row;
        //    Label lb = (Label)gr.FindControl("lblResourcePath");
        //    string[] lines = Regex.Split(lb.Text, "/");
        //    string Actvty = lines[lines.Length - 2].ToString();
        //    if (Actvty == "Student" || Actvty == "Teacher")
        //    {
        //        Actvty = "Posttest";
        //    }
        //    if (Activity.Contains(Actvty))
        //    {
        //        if (DataBinder.Eval(e.Row.DataItem, "Resource").ToString() != "Pretest")
        //        {
        //            // Label lblStatus = (Label)gr.FindControl("lblmsg");
        //            //lblStatus.Text = "Covered";
        //            //lblStatus.Text += "" + "<img src='http://localhost:34301/Epathshala/App_Themes/Images/Tick_mark_green_3d.png'>";
        //            //ImageButton img = (ImageButton)gr.FindControl("BtnQuesSave");
        //            //img.Visible = true;
        //        }

        //    }
        //    if (Activity == DataBinder.Eval(e.Row.DataItem, "Resource").ToString())
        //    {
        //        //Label lblStatus = (Label)gr.FindControl("lblmsg");
        //        //lblStatus.Text = "Covered";
        //        //lblStatus.Text += "" + "<img src='http://localhost:34301/Epathshala/App_Themes/Images/Tick_mark_green_3d.png'>";
        //    }
        //}
    }

    #endregion

    #region User define function

    protected void AddNewFileSetting()
    {

        if (AppSessions.RoleID.ToString() == Convert.ToString((int)EnumFile.Role.E_Admin) || AppSessions.RoleID.ToString() == Convert.ToString((int)EnumFile.Role.S_Admin) || AppSessions.RoleID.ToString() == Convert.ToString((int)EnumFile.Role.Teacher))
        {
            DataSet dsResourceSettings = new DataSet();
            dsResourceSettings = obj_BAL_Teacher_Dashboard.BAL_Select_CoveredUncoverChapterTopic_Settings("AllowTeacherToUploadResources");
            bool IsAllowed = Convert.ToBoolean(dsResourceSettings.Tables[0].Rows[0]["value"].ToString());

            if (IsAllowed)
            {
                pnlClick.Visible = true;
                pnlCollapsable.Visible = true;
            }
            else
            {
                pnlClick.Visible = false;
                pnlCollapsable.Visible = false;
            }
        }
        else
        {
            pnlCollapsable.Visible = false;
            pnlClick.Visible = false;
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
    private void BindFeedbackQuestion(GridView dvFeedback, TextBox Feedback)
    {
        if (ViewState["UserType"].ToString() == "Student")
        {
            StudentFeedbackQuestionBind(dvFeedback, Feedback);
        }
        else if (ViewState["UserType"].ToString() == "Teacher")
        {
            TeacherFeedbackQuestionBind(dvFeedback, Feedback);
        }
    }
    private void StudentFeedbackQuestionBind(GridView dvFeedback, TextBox Feedback)
    {
        DataTable dt = new DataTable();
        Feedback_BLogic objFeedback = new Feedback_BLogic();
        Obj_TeacherActivityFeedback.SchoolID = AppSessions.SchoolID;
        Obj_TeacherActivityFeedback.BMSSCTID = Convert.ToInt32(Session["BMSSCTID"]);
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
    private void TeacherFeedbackQuestionBind(GridView dvFeedback, TextBox Feedback)
    {
        DataTable dt = new DataTable();
        Feedback_BLogic objFeedback = new Feedback_BLogic();
        Obj_TeacherActivityFeedback.SchoolID = AppSessions.SchoolID;
        Obj_TeacherActivityFeedback.BMSSCTID = Convert.ToInt32(Session["BMSSCTID"]);
        Obj_TeacherActivityFeedback.EmployeeID = AppSessions.EmpolyeeID;
        Obj_TeacherActivityFeedback.DivisionID = AppSessions.DivisionID;
        Obj_TeacherActivityFeedback.CreatedBy = AppSessions.EmpolyeeID;

        dt = objFeedback.GetFeedbackDetail(Obj_TeacherActivityFeedback);
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
    private void ResetFeedbackControls(GridView grdFeedback, TextBox txtFeedback)
    {
        for (int i = 0; i < grdFeedback.Rows.Count; i++)
        {
            AjaxControlToolkit.Rating rating = (AjaxControlToolkit.Rating)grdFeedback.Rows[i].FindControl("ratingFeedback");
            txtFeedback.Text = string.Empty;
            rating.CurrentRating = 0;
        }
    }
    public void SaveFinishActivity()
    {

        ClassRoomActivityLog = new ClassRoomActivityLog();
        BAL_ClassRoomActivityLog = new ClassRoomActivityLog_BLogic();

        ClassRoomActivityLog.bmssctid = Convert.ToInt64(Session["BMSSCTID"]);
        ClassRoomActivityLog.schoolid = Convert.ToInt64(Session["SchoolID"]);
        ClassRoomActivityLog.employeeid = Convert.ToInt64(Session["EmpolyeeID"]);
        ClassRoomActivityLog.divisionid = Convert.ToInt16(Session["DivisionID"]);

        TrackLog_Utils.Log(Convert.ToInt32(AppSessions.SchoolID), Convert.ToInt32(AppSessions.EmpolyeeID), Convert.ToInt16(AppSessions.DivisionID), "EducationResourcepage", "btnFinishActivity", "Click", Convert.ToDateTime(System.DateTime.Now), HttpContext.Current.Session.SessionID, StringEnum.stringValueOf(EnumFile.Activity.AllActivityFinished), "Activity Finished of BMSSCT ID : " + Convert.ToInt32(Session["BMSSCTID"]), Convert.ToInt32(Session["BMSSCTID"]));

        //TO DO: Sent Logic here

        int result;
        if (Convert.ToBoolean(Session["FromRescheduling"]))
        {
            ClassRoomActivityLog.ReSchedulingID = Convert.ToInt64(Session["ReSchedulingID"]);
            BAL_ClassRoomActivityLog.BAL_ReScheduling_ActivityLog_Update(ClassRoomActivityLog);
            //Response.Redirect("~/Dashboard/TeacherDashboard.aspx");
            if (AppSessions.IsAllowSendEmail)
                ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "alert('Finish Activity Successfully.'); window.location='" + Request.ApplicationPath + "/Dashboard/SendFinishActivityMail.aspx';", true);
            else
                ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "alert('Finish Activity Successfully.'); window.location='" + Request.ApplicationPath + "/Dashboard/TeacherDashboard.aspx';", true);

        }
        else
        {
            result = BAL_ClassRoomActivityLog.BAL_ClassRoomActivityLog_Insert(ClassRoomActivityLog);
            if (result == Convert.ToInt32(EnumFile.Result.TopicNotCovered))
            {
                InsertFeedback(grdFeedback, txtFeedback);
                //Literal1.Text = "Thank you for your feedback. <script> setTimeout(function() { window.location='TeacherDashboard.aspx';},2000); </script>";
                if (AppSessions.IsAllowSendEmail)
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "alert('Finish Activity Successfully.'); window.location='" + Request.ApplicationPath + "/Dashboard/SendFinishActivityMail.aspx';", true);
                else
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "alert('Finish Activity Successfully.'); window.location='" + Request.ApplicationPath + "/Dashboard/TeacherDashboard.aspx';", true);
            }
            else if (result == Convert.ToInt32(EnumFile.Result.TopicCovered))
            {
                if (AppSessions.IsAllowSendEmail)
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "alert('This Topic has been already covered.'); window.location='" + Request.ApplicationPath + "/Dashboard/SendFinishActivityMail.aspx';", true);
                else
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "alert('This Topic has been already covered.'); window.location='" + Request.ApplicationPath + "/Dashboard/TeacherDashboard.aspx';", true);
            }
        }
    }
    private void SaveStudentFinishActivity()
    {
        ClassRoomActivityLog = new ClassRoomActivityLog();
        BAL_ClassRoomActivityLog = new ClassRoomActivityLog_BLogic();

        ClassRoomActivityLog.bmssctid = Convert.ToInt64(Session["BMSSCTID"]);
        ClassRoomActivityLog.Studentid = Convert.ToInt64(Session["StudentID"]);
        TrackLog_Utils.Log(Convert.ToInt32(AppSessions.SchoolID), Convert.ToInt32(AppSessions.StudentID), Convert.ToInt16(AppSessions.DivisionID), "EducationResourcepage", "btnClose", "Click", Convert.ToDateTime(System.DateTime.Now), Session.SessionID, "Exit", "Exit From Educational Resource Page.", 0);
        //SendActivityComplateMailToStudent();

        int result;
        if (Convert.ToBoolean(Session["StudentFromRescheduling"]))
        {
            ClassRoomActivityLog.SReSchedulingID = Convert.ToInt64(Session["StudentReSchedulingID"]);
            BAL_ClassRoomActivityLog.BAL_ReScheduling_ActivityLog_Update_Student(ClassRoomActivityLog);
            //Response.Redirect("~/Dashboard/StudentDashboard.aspx");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "alert('Thank you for your feedback.'); window.location='" + Request.ApplicationPath + "/Dashboard/StudentDashboard.aspx';", true);
        }
        else
        {
            result = BAL_ClassRoomActivityLog.BAL_ClassRoomActivityLog_Insert_Student(ClassRoomActivityLog);
            if (result == Convert.ToInt32(EnumFile.Result.TopicNotCovered))
            {
                //Response.Redirect("~/Dashboard/StudentDashboard.aspx");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "alert('Thank you for your feedback.'); window.location='" + Request.ApplicationPath + "/Dashboard/StudentDashboard.aspx';", true);
            }
            else if (result == Convert.ToInt32(EnumFile.Result.TopicCovered))
            {
                //WebMsg.Show("This Topic was Already Covered.");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "alert('This Topic was Already Covered.\\nThank you for your feedback.'); window.location='" + Request.ApplicationPath + "/Dashboard/StudentDashboard.aspx';", true);
            }
        }
    }
    private void InsertFeedback(GridView feeback, TextBox txtFB)
    {
        try
        {
            if (ViewState["UserType"].ToString() == "Teacher")
            {
                obj_BAL_Teacher_Dashboard = new Teacher_Dashboard_BLogic();
                objTA = new SYS_TeacherActivityFeedback_BLogic();

                Obj_TeacherActivityFeedback.SchoolID = AppSessions.SchoolID;
                Obj_TeacherActivityFeedback.BMSSCTID = Convert.ToInt32(Session["BMSSCTID"]);
                Obj_TeacherActivityFeedback.EmployeeID = AppSessions.EmpolyeeID;
                Obj_TeacherActivityFeedback.DivisionID = AppSessions.DivisionID;
                Obj_TeacherActivityFeedback.Feedback = txtFB.Text;
                Obj_TeacherActivityFeedback.CreatedBy = AppSessions.EmpolyeeID;
                String xmlData = FeedbackDetails(feeback);
                Obj_TeacherActivityFeedback.FeedbackQuestion = xmlData;
                objTA.FachTopicwiseResult(Obj_TeacherActivityFeedback);
            }
            else if (ViewState["UserType"].ToString() == "Student")
            {
                obj_BAL_Teacher_Dashboard = new Teacher_Dashboard_BLogic();
                objTA = new SYS_TeacherActivityFeedback_BLogic();

                Obj_TeacherActivityFeedback.SchoolID = AppSessions.SchoolID;
                Obj_TeacherActivityFeedback.BMSSCTID = Convert.ToInt32(Session["BMSSCTID"]);
                Obj_TeacherActivityFeedback.StudentID = AppSessions.StudentID;
                Obj_TeacherActivityFeedback.DivisionID = AppSessions.DivisionID;
                Obj_TeacherActivityFeedback.Feedback = txtFB.Text;
                Obj_TeacherActivityFeedback.CreatedBy = AppSessions.StudentID;
                String xmlData = FeedbackDetails(feeback);
                Obj_TeacherActivityFeedback.FeedbackQuestion = xmlData;
                objTA.SaveStudentFeeback(Obj_TeacherActivityFeedback);

            }
            txtFB.Text = "";

        }
        catch (Exception ex)
        {

            throw ex;
        }

    }
    private String FeedbackDetails(GridView Feedback)
    {
        DataTable dt = new DataTable();
        DataColumn dcFQ = dt.Columns.Add("Question", typeof(string));
        DataColumn dcFQID = dt.Columns.Add("QuestionID", typeof(int));
        DataColumn dcRating = dt.Columns.Add("Rating", typeof(int));
        DataRow dr;
        for (int i = 0; i < Feedback.Rows.Count; i++)
        {
            AjaxControlToolkit.Rating rating = (AjaxControlToolkit.Rating)Feedback.Rows[i].FindControl("ratingFeedback");
            if (rating.CurrentRating != 0)
            {
                dr = dt.NewRow();
                Label lblFeedbackQuestion = (Label)Feedback.Rows[i].FindControl("lblFeedBackQuestion");
                dr["Question"] = lblFeedbackQuestion.Text.ToString();
                rating = (AjaxControlToolkit.Rating)Feedback.Rows[i].FindControl("ratingFeedback");
                dr["Rating"] = Convert.ToInt32(rating.CurrentRating);
                dr["QuestionID"] = Convert.ToInt32(Feedback.DataKeys[i].Value);
                dt.Rows.Add(dr);
            }

        }


        String xmlData;
        StringWriter sw = new StringWriter();

        dt.TableName = "Feedback";
        dt.WriteXml(sw);
        xmlData = sw.ToString();
        return xmlData;
    }
    private string Covered()
    {
        Obj_TeacherActivityFeedback.BMSSCTID = Convert.ToInt32(Session["BMSSCTID"]);
        Obj_TeacherActivityFeedback.DivisionID = AppSessions.DivisionID;
        return objTA.Covered(Obj_TeacherActivityFeedback);
    }
    protected void ClearAddContentControls()
    {
        txtfoldername.Text = "";
        FileUpload1.Attributes.Clear();
        rbteacherstudent.Checked = true;
        rbteacher.Checked = false;
        rbstudent.Checked = false;
    }
    private void SendActivityComplateMailToStudent()
    {
        try
        {
            Teacher_Dashboard_BLogic obj_BAL_Teacher_Dashboard = new Teacher_Dashboard_BLogic();
            DataSet dsSettings = new DataSet();
            dsSettings = obj_BAL_Teacher_Dashboard.BAL_Select_CoveredUncoverChapterTopic_Settings("IsFinishActivityAlertSentFromStudentLogin");

            if (dsSettings.Tables.Count > 0)
            {
                if (dsSettings.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToBoolean(dsSettings.Tables[0].Rows[0]["value"].ToString()))
                    {
                        ArrayList alistEmailAddress = GenerateEmailAddress(AppSessions.StudentID);
                        if (alistEmailAddress.Count > 0)
                        {
                            string Body = GenerateEmailBody();
                            EmailUtility.SendEmail(alistEmailAddress, "Today Activity Alert - " + DateTime.Now.ToString("MMM dd, yyyy") + "", Body);
                        }
                    }
                }
            }
        }
        catch (Exception)
        {

        }
    }
    protected ArrayList GenerateEmailAddress(Int64 studentID)
    {
        ArrayList AlistEmailID = new ArrayList();
        DataSet dsEmail = new DataSet();
        Student_BLogic oStudent_BLogic = new Student_BLogic();
        dsEmail = oStudent_BLogic.BAL_Student_Select_EmailID(AppSessions.StudentID);
        if (dsEmail != null & dsEmail.Tables.Count > 0)
        {
            if (dsEmail.Tables[0].Rows.Count > 0)
            {
                AlistEmailID.Add(dsEmail.Tables[0].Rows[0]["EmailID"].ToString());
                ViewState["TempEmp"] = dsEmail.Tables[0].Rows[0]["FirstName"].ToString();
            }
        }
        return AlistEmailID;
    }
    protected string GenerateEmailBody()
    {
        StringBuilder oBuilder = new StringBuilder();

        oBuilder.Append("<!DOCTYPE html><html><head><title>Finish Activity</title></head><body>");
        oBuilder.Append("<div style='border: 0px Solid #F0F0F0; background-color: #f9f9f9;margin: 10px; font-family: Cambria,Calibri,Times New Roman; font-size: medium;  box-shadow: 0px 0px 4px #909090;border-top: 8px Solid #522675;border-bottom: 4px Solid #522675;'>");
        oBuilder.Append("<div style='background-color:#F0F0F0  ;height:70px;'><div class='logo' style='text-align: center;color:#80262e;padding:20px;'>");
        oBuilder.Append("<h3 style='margin:0;'>#SCHOOLNAME#</h3>");
        oBuilder.Append("</div></div>");
        oBuilder.Append("<div style='border-bottom: 3px Solid #E8E8E8; padding: 20px; border-top: 2px Solid #522675;color: #909090;'>");
        oBuilder.Append("<p>Dear Parent,<br /><br />Today chapter \"#CHAPTER#\" of subject \"#SUBJECT#\" has been completed in class \"#STANDARD#\" at #TIME#.<br /><br /><br /><br />Best Regards,<br />#USERNAME#.</p>");
        oBuilder.Append("</div></div>");
        oBuilder.Append("</body></html>");

        oBuilder.Replace("#SCHOOLNAME#", AppSessions.SchoolName);
        oBuilder.Replace("#CHAPTER#", Convert.ToString(Session["Chapter"]));
        oBuilder.Replace("#SUBJECT#", AppSessions.Subject);
        oBuilder.Replace("#STANDARD#", AppSessions.Board + " - " + AppSessions.Division);
        oBuilder.Replace("#TIME#", DateTime.Now.ToString("hh:mm tt"));
        oBuilder.Replace("#USERNAME#", EmailUtility.USERNAME);

        return oBuilder.ToString();
    }
    protected void FillResource()
    {
        try
        {
            DataSet dsSettings = new DataSet();
            Teacher_Dashboard_BLogic obj_BAL_Teacher_Dashboard = new Teacher_Dashboard_BLogic();
            dsSettings = obj_BAL_Teacher_Dashboard.BAL_Select_CoveredUncoverChapterTopic_Settings("ShowICICILogo");
            bool IsVisible = Convert.ToBoolean(dsSettings.Tables[0].Rows[0]["value"].ToString());


            if (IsVisible)
            {
                dvICICI.Visible = true;
                //ActivityHeader1.Style.Add("background-color", "White");
            }
            else
            {
                dvICICI.Visible = false;
            }

            if (Request.QueryString["frm"] != null && Request.QueryString["key"] != null)
            {
                if (Request.QueryString["frm"] != string.Empty && Request.QueryString["key"] != string.Empty)
                {
                    ViewState["key"] = Request.QueryString["key"];
                    btnBack.Visible = true;
                }
            }

            if (Request.QueryString["Type"] != string.Empty)
            {
                ViewState["UserType"] = Request.QueryString["Type"].ToString();
            }
            if (ViewState["UserType"].ToString() == "Student")
            {
                btnFinishActStudent.Visible = true;
            }
            else if (ViewState["UserType"].ToString() == "Teacher")
            {
                btnFinishActivity.Visible = true;

                dsSettings = objTA.BAL_Select_IsActivityFeedback_Settings("IsActivityFeedback");

                object datatype = dsSettings.Tables[0].Rows[0]["Type"].ToString();
                object val = dsSettings.Tables[0].Rows[0]["value"].ToString();
                if (Convert.ToBoolean(Convert.ToInt16(val)))
                {
                    btnFeedback.Visible = true;
                }
            }
            TrackLog_Utils.Log(Convert.ToInt32(AppSessions.SchoolID), Convert.ToInt32(AppSessions.EmpolyeeID), Convert.ToInt16(AppSessions.DivisionID), "EducationResourcepage", "Page", "Load", Convert.ToDateTime(System.DateTime.Now), HttpContext.Current.Session.SessionID, StringEnum.stringValueOf(EnumFile.Activity.EducationResourcePage), "Education Resource Page  Loaded.", Convert.ToInt32(Session["BMSSCTID"]));

            lblSiteMap.Text = Session["BMSSDNameEduResource"].ToString();
            LblChapterTopic.Text = Session["ChapterTopic"].ToString();
            objeAes = new SimplerAES();
            Int64 bmssctid = Convert.ToInt64(Session["BMSSCTID"]);
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

                bool Pretest, IsPostTest = false;
                Teacher_Dashboard_BLogic td = new Teacher_Dashboard_BLogic();
                Int64 count = td.BAL_Select_QuestionBankIDCount(bmssctid, IsPostTest);
                if (getConfigValue("Pretest") == "1" && count > 0)
                {
                    Pretest = true;
                }
                else
                {
                    Pretest = false;
                }
                if (Pretest)
                {
                    if (AppSessions.StudentID != null && AppSessions.StudentID != 0)
                    {
                        dr = dt.NewRow();
                        dr["Resource"] = "Pretest";
                        dr["ResourcePath"] = "../Student/StudentAssessment.aspx?Level=0&TestType=Pretest";
                        dr["Ext"] = ".Test";
                        dt.Rows.Add(dr);
                    }
                    else
                    {
                        dr = dt.NewRow();
                        dr["Resource"] = "Pretest";
                        dr["ResourcePath"] = "../Teacher/TeacherAssessment.aspx?Level=0&TestType=Pretest";
                        dr["Ext"] = ".Test";
                        dt.Rows.Add(dr);
                    }
                }

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
                bool PosttestAllow;
                IsPostTest = true;
                Int64 countpost = td.BAL_Select_QuestionBankIDCount(bmssctid, IsPostTest);
                if (getConfigValue("Posttest") == "1" && countpost > 0)
                {
                    PosttestAllow = true;
                }
                else
                {
                    PosttestAllow = false;
                }
                if (PosttestAllow)
                {
                    if (AllLevel)
                    {
                        if (AppSessions.StudentID != null && AppSessions.StudentID != 0)
                        {
                            dr = dt.NewRow();
                            dr["Resource"] = "Posttest";
                            dr["ResourcePath"] = "../Student/StudentAssessment.aspx?Level=0&TestType=Posttest";
                            dr["Ext"] = ".Test";
                            dt.Rows.Add(dr);
                        }
                        else
                        {
                            dr = dt.NewRow();
                            dr["Resource"] = "Posttest";
                            dr["ResourcePath"] = "../Teacher/TeacherAssessment.aspx?Level=0&TestType=Posttest";
                            dr["Ext"] = ".Test";
                            dt.Rows.Add(dr);
                        }
                    }
                    else
                    {
                        for (int n = 1; n < 4; n++)
                        {
                            if (AppSessions.StudentID != null && AppSessions.StudentID != 0)
                            {
                                dr = dt.NewRow();
                                dr["Resource"] = "Posttest Level-" + n;
                                dr["ResourcePath"] = "../Student/StudentAssessment.aspx?Level=" + n + "&TestType=Posttest";
                                dr["Ext"] = ".Test";
                                dt.Rows.Add(dr);
                            }
                            else
                            {
                                if (n == 1)
                                {
                                    dr = dt.NewRow();
                                    dr["Resource"] = "Posttest Level-" + n;
                                    dr["ResourcePath"] = "../Teacher/TeacherAssessment.aspx?Level=" + n + "&TestType=Posttest";
                                    dr["Ext"] = ".Test";
                                    dt.Rows.Add(dr);
                                }
                            }
                        }
                    }
                }

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
                AddNewFileSetting();
            }

        }
        catch (Exception ex)
        {

        }
    }

    #endregion
    protected void btnbackEduResource_Click(object sender, EventArgs e)
    {
        Response.Redirect("StudentDashboard.aspx",false);
    }
    protected void btnfeedbackback_Click(object sender, EventArgs e)
    {
        mpFeedback1.Hide();
    }
    protected void btnback_FinishActivity_Click(object sender, EventArgs e)
    {
        mpfeedback.Hide();
    }
}