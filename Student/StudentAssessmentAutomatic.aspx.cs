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

public partial class Student_StudentAssessmentAutomatic : System.Web.UI.Page
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
            if (Request.QueryString["BMSSCTID"].ToString() != "")
            {
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

               

                DataTable dtExaAuto = null;
                Hashtable Question = (Hashtable)Application["Exam_TeacherSheResult"];
                if (Question == null)
                {
                    Question = new Hashtable();
                }
                else
                {
                    dtExaAuto = (DataTable)Question[Session["TrackLogID"].ToString()];
                }

                // ds = objQuestionMaster.SELECTAll_QuestionByBMSSCTID(RndmQuestion, Level, NoOfQuestion, Convert.ToInt32(Request.QueryString["BMSSCTID"].ToString()), Request.QueryString["TestType"]);
                // ds = objQuestionMaster.SELECTAll_QuestionByBMSSCTID(RndmQuestion, Level, NoOfQuestion, Convert.ToInt32(Request.QueryString["BMSSCTID"].ToString()), "MCQ");
                if (dtExaAuto != null)
                {
                    if (dtExaAuto.Rows.Count > 0)
                    {
                        //  dt = ds.Tables[0];
                        //   dt.Columns.Add("GivenAnswerID", typeof(Int64));
                        //   dt.Columns.Add("GivenAnswer", typeof(String));
                        //  dt.Columns.Add("ResultTF", typeof(String));
                        //Create RandomQuestion


                        

                        //' Now, add a random number for the RandNum value for each row

                        //Dim rndNum as New Random()
                        //For i = 0 to myDataTable.Rows.Count - 1
                        //    myDataTable.Rows(i)("RandNum") = rndNum.Next(10000)
                        //Next i

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
                        WebMsg.Show("No Question found!");
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
            lblQues.Text = "Question " + (Convert.ToInt32(ViewState["CurQuestion"]) + 1) + ": ";
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
            gvAnalysis.DataSource = dt;
            gvAnalysis.DataBind();
            //WebMsg.Show("Your Exam Finished");
            i = i + 1;
        }
        //For Save to Application to view Teacher
        DataTable dtExaAuto = null;
        Hashtable Question = (Hashtable)Application["Exam_TeacherSheResult"];
        if (Question == null)
        {
            Question = new Hashtable();
        }
        else
        {
            dtExaAuto = (DataTable)Question[Session["TrackLogID"].ToString()];
        }

        if (dtExaAuto != null)
        {


            Application.Lock(); //lock to prevent duplicate objects
            //foreach (DataRow dr in dtExaAuto.Rows)
            //{
            DataRow dr = dtExaAuto.Select("QuestionBankID=" + QuestionBankID.ToString()).FirstOrDefault();
                if (dr["QuestionBankID"].ToString() == QuestionBankID.ToString())
                {
                    if (dr["RightAnswer"].ToString() != string.Empty)
                    {
                        dr["RightAnswer"] = Convert.ToInt32(dr["RightAnswer"].ToString()) + rightAnswer;
                    }
                    else
                    {
                        dr["RightAnswer"] = rightAnswer;
                    }
                    if (dr["WrongAnswer"].ToString() != string.Empty)
                    {
                        dr["WrongAnswer"] = Convert.ToInt32(dr["WrongAnswer"].ToString()) + wrongAnswer;
                    }
                    else
                    {
                        dr["WrongAnswer"] = wrongAnswer;
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
            dtExaAuto.AcceptChanges();
            Question[Session["TrackLogID"].ToString()] = dtExaAuto;

            Application["Exam_TeacherSheResult"] = Question;
            Application.UnLock();
        }
        //For End Save to Application
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
    #endregion
}