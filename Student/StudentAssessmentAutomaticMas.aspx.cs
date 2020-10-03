using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using Udev.UserMasterPage.Classes;
using System.Globalization;
using System.Collections;
using System.Text.RegularExpressions;
using System.Text;
using System.IO;

public partial class Student_StudentAssessmentAutomaticMas : System.Web.UI.Page
{
    #region "PageEvents"
    protected override void InitializeCulture()
    {
        string culture = Convert.ToString(Session[Global.SESSION_KEY_CULTURE]);
        // 'set culture to current thread 
        System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture);
        System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);
        //call base class 
        base.InitializeCulture();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //mp1.Show();
            if (Request.QueryString["BMSSCTID"].ToString() != "")
            {
                SYS_BMS_BLogic objBMSSCT = new SYS_BMS_BLogic();
                DataSet BmssctDs = new DataSet();
                if (!string.IsNullOrEmpty(Request.QueryString["GroupBMSSCT"].ToString()))
                {
                    BmssctDs = objBMSSCT.BAL_SYS_BMSSCT_ByGroupBMSSCTID(Request.QueryString["GroupBMSSCT"]);
                    if (BmssctDs.Tables.Count > 0)
                    {
                        StringBuilder ToolTiplblChapterValue = new StringBuilder();
                        StringBuilder ToolTiplblTopicValue = new StringBuilder();

                        foreach (DataRow odr in BmssctDs.Tables[0].Rows)
                        {
                            string BMSSCTNAME = odr["BMS_SCT"].ToString();
                            string[] lines = Regex.Split(BMSSCTNAME, ">>");
                            ToolTiplblChapterValue.Append(lines[lines.Length - 1]);
                            ToolTiplblChapterValue.Append(Environment.NewLine);

                            ToolTiplblTopicValue.Append(lines[lines.Length - 2]);
                            ToolTiplblTopicValue.Append(Environment.NewLine);
                        }
                        lblChapterValue.Text = "Multiple Chapter";
                        lblTopicValue.Text = "Multiple Topics";

                        lblChapterValue.ToolTip = ToolTiplblChapterValue.ToString();
                        lblTopicValue.ToolTip = ToolTiplblTopicValue.ToString();
                    }
                }
                else
                {
                    BmssctDs = objBMSSCT.BAL_SYS_BMSSCT_ByBMSSCTID(Convert.ToInt32(Request.QueryString["BMSSCTID"].ToString()));
                    if (BmssctDs.Tables.Count > 0)
                    {
                        if (BmssctDs.Tables[0].Rows.Count > 0)
                        {
                            string BMSSCTNAME = BmssctDs.Tables[0].Rows[0]["BMS_SCT"].ToString();
                            string[] lines = Regex.Split(BMSSCTNAME, ">>");
                            lblChapterValue.Text = lines[lines.Length - 1];
                            lblTopicValue.Text = lines[lines.Length - 2];
                            string ForTitle = "";
                            for (int Ti = 0; Ti < lines.Length - 2; Ti++)
                            {
                                if (Ti < lines.Length - 3)
                                {
                                    ForTitle = ForTitle + lines[Ti] + " >> ";
                                }
                                else
                                {
                                    ForTitle = ForTitle + lines[Ti];
                                }
                            }
                            lblExamStartOf.Text = "Your " + Request.QueryString["TestType"].ToString() + "  for " + ForTitle;
                        }
                        else
                        {
                            lblExamStartOf.Text = "Your " + Request.QueryString["TestType"].ToString() + "  for " + "";
                        }
                    }
                    else
                    {
                        lblExamStartOf.Text = "Your " + Request.QueryString["TestType"].ToString() + "  for" + "";
                    }
                }
                ViewState["TestTypeToTable"] = Request.QueryString["TestType"].ToString();
                //int Level = 0;
                //int NoOfQuestion = 0;
                //if (Request.QueryString["Level"].ToString() != "")
                //{
                //    Level = Convert.ToInt32(Request.QueryString["Level"].ToString());
                //}
                //if (Level == 0)
                //{
                //    NoOfQuestion = Convert.ToInt32(getConfigValue("MaxQuestionForAll"));
                //}
                //else
                //{
                //    NoOfQuestion = Convert.ToInt32(getConfigValue("MaxQuestionForLevelWise"));
                //}
                DataTable dt = new DataTable();

                QuestionMaster objQuestionMaster = new QuestionMaster();
                DataSet ds = new DataSet();


                DataSet dsExamAuto = null;

                Hashtable Question = (Hashtable)Application["Exam_TeacherSheResult"];
                if (Question == null)
                {
                    Question = new Hashtable();
                }
                else
                {
                    dsExamAuto = (DataSet)Question[Session["TrackLogID"].ToString()];
                }

                // ds = objQuestionMaster.SELECTAll_QuestionByBMSSCTID(RndmQuestion, Level, NoOfQuestion, Convert.ToInt32(Request.QueryString["BMSSCTID"].ToString()), Request.QueryString["TestType"]);
                // ds = objQuestionMaster.SELECTAll_QuestionByBMSSCTID(RndmQuestion, Level, NoOfQuestion, Convert.ToInt32(Request.QueryString["BMSSCTID"].ToString()), "MCQ");
                if (dsExamAuto != null)
                {
                    if (dsExamAuto.Tables.Count > 0)
                    {
                        if (dsExamAuto.Tables.Count > 1)
                        {
                            DataRow drStudentInfo = dsExamAuto.Tables[1].NewRow();
                            drStudentInfo["StudentID"] = AppSessions.StudentID;
                            drStudentInfo["StudentName"] = AppSessions.UserName;
                            drStudentInfo["RightAnswer"] = 0;
                            drStudentInfo["WrongAnswer"] = 0;
                            drStudentInfo["EmailID"] = AppSessions.EmailID;
                            dsExamAuto.Tables[1].Rows.Add(drStudentInfo);
                            dsExamAuto.Tables[1].AcceptChanges();

                            Question[Session["TrackLogID"].ToString()] = dsExamAuto;
                            Application.Lock(); //lock to prevent duplicate objects
                            Application["Exam_TeacherSheResult"] = Question;
                            Application.UnLock();

                        }
                        if (dsExamAuto.Tables[0].Rows.Count > 0)
                        {

                            DataTable dtExaAuto = dsExamAuto.Tables[0];
                            string RndoKey = "0";
                            RndoKey = getConfigValue("JumbleQuestion");
                            int RndmQuestion = Convert.ToInt32(RndoKey);

                            DataTable dtExaAutoRandom;
                            if (RndmQuestion == 1)
                            {

                                Random randNum = new Random();
                                int randomRow = 0;
                                List<int> numbers = new List<int>();
                                int num = 0;
                                int rowToEnter = 0;
                                num = randNum.Next(1, dtExaAuto.Rows.Count + 1);
                                while (numbers.Count < dtExaAuto.Rows.Count)
                                {
                                    if (numbers.Contains(num))
                                    {
                                        num = randNum.Next(1, dtExaAuto.Rows.Count + 1);
                                    }
                                    else
                                    {
                                        randomRow = num;
                                        numbers.Add(num);
                                        dtExaAuto.Rows[rowToEnter]["RandNum"] = num;
                                        dtExaAuto.AcceptChanges();
                                        rowToEnter = rowToEnter + 1;
                                    }
                                }

                                DataView dv = new DataView(dtExaAuto);
                                dv.Sort = "RandNum ASC";
                                dtExaAutoRandom = dv.ToTable();

                            }
                            else
                            {
                                DataView dv = new DataView(dtExaAuto);
                                dtExaAutoRandom = dv.ToTable();
                            }
                            ViewState["QuestionAnsDT"] = dtExaAutoRandom;
                            ViewState["CurQuestion"] = 0;
                            BindNextQuestion(dtExaAutoRandom);
                        }
                        else
                        {

                            BtnButton.Visible = false;
                            Session["ExamStarted"] = "";
                            Session["TrackLogID"] = "";
                            WebMsg.Show("No Question found!");
                            Response.Redirect("../Dashboard/StudentDashboard.aspx");
                        }
                    }
                    else
                    {

                        BtnButton.Visible = false;
                        Session["ExamStarted"] = "";
                        Session["TrackLogID"] = "";
                        WebMsg.Show("No Question found!");
                        Response.Redirect("../Dashboard/StudentDashboard.aspx");
                    }
                }
                else
                {
                    Session["ExamStarted"] = "";
                    Session["TrackLogID"] = "";
                    Response.Redirect("../Dashboard/StudentDashboard.aspx");
                }

            }
        }

    }
    #endregion
    #region userdefinedFunction
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
    private void BindNextQuestion(DataTable dt)
    {
        if (dt.Rows.Count > 0)
        {
            ltQuestionCount1.Text = Convert.ToString(Convert.ToInt32(ViewState["CurQuestion"]) + 1);
            ltQuestionCount3.Text = Convert.ToString(dt.Rows.Count.ToString());
            lblQuesNumber.Text = (Convert.ToInt32(ViewState["CurQuestion"]) + 1) + ". ";
            ltQuestion.Text = HttpUtility.HtmlDecode(dt.Rows[Convert.ToInt32(ViewState["CurQuestion"])]["Question"].ToString());
            rdb.Items.Clear();
            ListItem ltm;

            bool isRandomOption = false;

            string RndoKey = "0";
            RndoKey = getConfigValue("JumbleOption");

            if (RndoKey == "0")
            {
                RndoKey = "false";
            }
            else
            {
                RndoKey = "true";
            }
            isRandomOption = Convert.ToBoolean(RndoKey);

            if (isRandomOption)
            {

                Random randNum = new Random();
                int randomRow = 0;
                List<int> numbers = new List<int>();
                int num = 0;

                num = randNum.Next(1, 5);
                while (numbers.Count < 4)
                {
                    if (numbers.Contains(num))
                    {
                        num = randNum.Next(1, 5);
                    }
                    else
                    {
                        randomRow = num;
                        numbers.Add(num);
                        ltm = new ListItem(dt.Rows[Convert.ToInt32(ViewState["CurQuestion"])]["Option" + num].ToString(), dt.Rows[Convert.ToInt32(ViewState["CurQuestion"])]["Option" + num + "ID"].ToString());
                        rdb.Items.Add(ltm);
                    }
                }
            }
            else
            {
                ltm = new ListItem(dt.Rows[Convert.ToInt32(ViewState["CurQuestion"])]["Option1"].ToString(), dt.Rows[Convert.ToInt32(ViewState["CurQuestion"])]["Option1ID"].ToString());
                rdb.Items.Add(ltm);
                ltm = new ListItem(dt.Rows[Convert.ToInt32(ViewState["CurQuestion"])]["Option2"].ToString(), dt.Rows[Convert.ToInt32(ViewState["CurQuestion"])]["Option2ID"].ToString());
                rdb.Items.Add(ltm);
                ltm = new ListItem(dt.Rows[Convert.ToInt32(ViewState["CurQuestion"])]["Option3"].ToString(), dt.Rows[Convert.ToInt32(ViewState["CurQuestion"])]["Option3ID"].ToString());
                rdb.Items.Add(ltm);
                ltm = new ListItem(dt.Rows[Convert.ToInt32(ViewState["CurQuestion"])]["Option4"].ToString(), dt.Rows[Convert.ToInt32(ViewState["CurQuestion"])]["Option4ID"].ToString());
                rdb.Items.Add(ltm);
            }
        }
        else
        {
            Examtbl.Visible = false;
            WebMsg.Show("Question not available");
        }
    }
    #endregion
    #region ControlEventsF
    protected void BtnButton_Click(object sender, EventArgs e)
    {
        DataTable dt = (DataTable)ViewState["QuestionAnsDT"];
        int rightAnswer = 0;
        int wrongAnswer = 0;
        int QuestionBankID = 0;
        int i = Convert.ToInt32(ViewState["CurQuestion"]);
        QuestionBankID = Convert.ToInt32(dt.Rows[i]["QuestionBankID"].ToString());
        if (dt.Rows.Count - 2 == i)
        {
            dt.Rows[i]["GivenAnswer"] = rdb.SelectedItem.Text;
            dt.Rows[i]["GivenAnswerID"] = rdb.SelectedValue;

            if (rdb.SelectedValue.ToString() == dt.Rows[i]["AnswerID"].ToString())
            {
                rightAnswer = 1;
            }
            else
            {
                wrongAnswer = 1;
            }
            dt.AcceptChanges();
            BtnButton.Text = "Finish";
            i = i + 1;
            ViewState["CurQuestion"] = i;
            BindNextQuestion(dt);
        }
        else if (dt.Rows.Count - 1 != i)
        {
            dt.Rows[i]["GivenAnswer"] = rdb.SelectedItem.Text;
            dt.Rows[i]["GivenAnswerID"] = rdb.SelectedValue;
            if (rdb.SelectedValue.ToString() == dt.Rows[i]["AnswerID"].ToString())
            {
                rightAnswer = 1;
            }
            else
            {
                wrongAnswer = 1;
            }
            dt.AcceptChanges();
            i = i + 1;
            ViewState["CurQuestion"] = i;
            BindNextQuestion(dt);
        }
        else
        {
            dt.Rows[i]["GivenAnswerID"] = rdb.SelectedValue;
            dt.Rows[i]["GivenAnswer"] = rdb.SelectedItem.Text;
            if (rdb.SelectedValue.ToString() == dt.Rows[i]["AnswerID"].ToString())
            {
                rightAnswer = 1;
            }
            else
            {
                wrongAnswer = 1;
            }
            dt.AcceptChanges();
            int trueAns = 0, falseAns = 0;
            for (int AnsLoo = 0; AnsLoo < dt.Rows.Count; AnsLoo++)
            {

                if (dt.Rows[AnsLoo]["AnswerID"].ToString() == dt.Rows[AnsLoo]["GivenAnswerID"].ToString())
                {
                    trueAns = trueAns + 1;
                    dt.Rows[AnsLoo]["ResultTF"] = "True";
                    dt.AcceptChanges();
                }
                else
                {
                    falseAns = falseAns + 1;
                    dt.Rows[AnsLoo]["ResultTF"] = "False";
                    dt.AcceptChanges();
                }

            }
            lblTotalQues.Text = Convert.ToString(trueAns + falseAns);
            lblTrueAns.Text = Convert.ToString(trueAns);
            lblFalseAns.Text = Convert.ToString(falseAns);
            ExamResult.Visible = true;
            Examtbl.Visible = false;
            lbluserScoreValue.Text = lblTrueAns.Text + "/" + lblTotalQues.Text;
            ViewState["QuestionAnsDT"] = dt;
            Session["ExamStarted"] = "Finished";
            if (AppSessions.StudentID != null && AppSessions.StudentID != 0)
            {
                dt.TableName = "StudentResult";
                dt.AcceptChanges();
                QuestionMaster objQuestionMaster = new QuestionMaster();
                objQuestionMaster.BAL_StudentExamResult(Convert.ToInt32(dt.Rows[0]["BMSSCTID"].ToString()), AppSessions.StudentID, dt, ViewState["TestTypeToTable"].ToString());
            }
            ImageButton1.Visible = true;
            gvAnalysis.DataSource = dt;
            gvAnalysis.DataBind();
            //WebMsg.Show("Your Exam Finished");
            i = i + 1;
        }
        try
        {
            //For Save to Application to view Teacher
            DataSet dsExamAuto = null;

            Hashtable Question = (Hashtable)Application["Exam_TeacherSheResult"];
            if (Question == null)
            {
                Question = new Hashtable();
            }
            else
            {
                dsExamAuto = (DataSet)Question[Session["TrackLogID"].ToString()];
            }

            if (dsExamAuto != null)
            {
                DataTable dtExaAuto = null;
                if (dsExamAuto.Tables.Count > 0)
                {
                    if (dsExamAuto.Tables.Count > 0)
                    {
                        dtExaAuto = dsExamAuto.Tables[0];


                        Application.Lock(); //lock to prevent duplicate objects
                        //foreach (DataRow dr in dtExaAuto.Rows)
                        //{
                        DataRow dr = dsExamAuto.Tables[0].Select("QuestionBankID=" + QuestionBankID.ToString()).FirstOrDefault();
                        DataRow drStudentInfo = dsExamAuto.Tables[1].Select("StudentID=" + AppSessions.StudentID).FirstOrDefault();
                        if (dr["QuestionBankID"].ToString() == QuestionBankID.ToString())
                        {
                            drStudentInfo["RightAnswer"] = Convert.ToInt32(drStudentInfo["RightAnswer"].ToString()) + rightAnswer;
                            drStudentInfo["WrongAnswer"] = Convert.ToInt32(drStudentInfo["WrongAnswer"].ToString()) + wrongAnswer;
                            if (dr["RightAnswer"].ToString() != string.Empty)
                            {
                                dr["RightAnswer"] = Convert.ToInt32(dr["RightAnswer"].ToString()) + rightAnswer;

                            }
                            else
                            {
                                dr["RightAnswer"] = rightAnswer;
                                //drStudentInfo["RightAnswer"] = rightAnswer;
                            }
                            if (dr["WrongAnswer"].ToString() != string.Empty)
                            {
                                dr["WrongAnswer"] = Convert.ToInt32(dr["WrongAnswer"].ToString()) + wrongAnswer;

                            }
                            else
                            {
                                dr["WrongAnswer"] = wrongAnswer;
                                //drStudentInfo["WrongAnswer"] = wrongAnswer;
                            }
                            if (dr["Attendent"].ToString() != string.Empty)
                            {
                                dr["Attendent"] = Convert.ToInt32(dr["Attendent"].ToString()) + 1;
                            }
                            else
                            {
                                dr["Attendent"] = 1;
                            }
                        }
                        //}
                        dsExamAuto.Tables[1].AcceptChanges();
                        dsExamAuto.Tables[0].AcceptChanges();
                        Question[Session["TrackLogID"].ToString()] = dsExamAuto;

                        Application["Exam_TeacherSheResult"] = Question;
                        Application.UnLock();
                        if (dsExamAuto.Tables.Count > 2)
                        {
                            if (dsExamAuto.Tables[2].Rows[0]["Status"].ToString() == "1")
                            {
                                Session["ExamStarted"] = "Finished";
                                Response.Redirect("~/Dashboard/StudentDashboard.aspx");
                            }
                        }
                    }
                }
            }
            //For End Save to Application
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message.ToString());
        }
    }

    protected void gvAnalysis_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //get question and solution from ResultTbl
                //if (e.ro ==DataControlRowType.DataRow  )
                //{

                Literal ltQuestion = (Literal)e.Row.FindControl("ltQuestion");
                Literal lblCorrect = (Literal)e.Row.FindControl("lblCorrect");

                ltQuestion.Text = HttpUtility.HtmlDecode(DataBinder.Eval(e.Row.DataItem, "Question").ToString());
                lblCorrect.Text = HttpUtility.HtmlDecode(DataBinder.Eval(e.Row.DataItem, "Answer").ToString());

                Literal ltQues = (Literal)e.Row.FindControl("ltQues");
                Literal ltAns = (Literal)e.Row.FindControl("ltAns");

                ltQues.Text = HttpUtility.HtmlDecode(DataBinder.Eval(e.Row.DataItem, "Question").ToString());
                ltAns.Text = HttpUtility.HtmlDecode(DataBinder.Eval(e.Row.DataItem, "Solution").ToString());

                Literal lblGiven = (Literal)e.Row.FindControl("lblGiven");
                lblGiven.Text = HttpUtility.HtmlDecode(DataBinder.Eval(e.Row.DataItem, "GivenAnswer").ToString());

                Label lblResult = (Label)e.Row.FindControl("lblResult");
                lblResult.Text = HttpUtility.HtmlDecode(DataBinder.Eval(e.Row.DataItem, "ResultTF").ToString());

            }
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message.ToString());
        }
        finally
        {
        }
    }
    protected void btnClose_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/Dashboard/StudentDashboard.aspx");
    }
    #endregion
}