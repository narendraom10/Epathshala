using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Udev.UserMasterPage.Classes;
using System.Globalization;
using System.Collections;

public partial class Teacher_TeacherAssessment : System.Web.UI.Page
{
    #region Variables
    #endregion

    #region "Properties"
    #endregion

    #region "Page events"
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
            Timer1.Enabled = true;
            MenuItem m = new MenuItem("Exam", "0");
            m.ToolTip = "Exam";
            m.Value = "0";

            Menu1.Items.Add(m);

            MenuItem mR = new MenuItem("Result", "1");
            mR.ToolTip = "Result";
            mR.Value = "1";
            mR.Selected = true;
            Menu1.Items.Add(mR);
            if (Request.QueryString["BMSSCTID"].ToString() != "")
            {
                int Level = 0;
                int NoOfQuestion = 0;
                if (Request.QueryString["Level"].ToString() != "")
                {
                    Level = Convert.ToInt32(Request.QueryString["Level"].ToString());
                }
                if (Level == 0)
                {
                    NoOfQuestion = Convert.ToInt32(getConfigValue("MaxQuestionForAll"));
                }
                else
                {
                    NoOfQuestion = Convert.ToInt32(getConfigValue("MaxQuestionForLevelWise"));
                }
                DataTable dt = new DataTable();

                QuestionMaster objQuestionMaster = new QuestionMaster();
                DataSet ds = new DataSet();

                string RndoKey = "0";
                RndoKey = getConfigValue("JumbleQuestion");
                int RndmQuestion = Convert.ToInt32(RndoKey);
                ViewState["TestTypeToTable"] = Request.QueryString["TestType"].ToString();

                if (!string.IsNullOrEmpty(Convert.ToString(Request.QueryString["noq"])))
                    ds = objQuestionMaster.SELECTAll_QuestionByBMSSCTIDAutoExam(Request.QueryString["BMSSCTID"], Request.QueryString["TestType"], "dashboardtest", Convert.ToString(Request.QueryString["noq"]));
                else
                    ds = objQuestionMaster.SELECTAll_QuestionByBMSSCTIDAutoExam(Request.QueryString["BMSSCTID"], Request.QueryString["TestType"], "Preposttest", "");

                // ds = objQuestionMaster.SELECTAll_QuestionByBMSSCTID(RndmQuestion, Level, NoOfQuestion, Convert.ToInt32(Request.QueryString["BMSSCTID"].ToString()), "MCQ");
                if (ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0];
                    dt.Columns.Add("GivenAnswerID", typeof(Int64));
                    dt.Columns.Add("GivenAnswer", typeof(String));
                    dt.Columns.Add("ResultTF", typeof(String));
                    dt.Columns.Add("RightAnswer", typeof(Int64));
                    dt.Columns.Add("WrongAnswer", typeof(Int64));
                    dt.Columns.Add("Attendent", typeof(Int64));
                    dt.Columns.Add("RandNum", typeof(Int64));

                    //Data Table for Student Information
                    //Table zero contains the Question Information and Table one contains student information
                    DataSet dsExamInfor = new DataSet();
                    //Table For Student Information
                    DataTable dtStudentInfo = new DataTable("StudentInfo");
                    dtStudentInfo.Columns.Add("StudentID", typeof(Int64));
                    dtStudentInfo.Columns.Add("StudentName", typeof(String));
                    dtStudentInfo.Columns.Add("RightAnswer", typeof(Int64));
                    dtStudentInfo.Columns.Add("WrongAnswer", typeof(Int64));
                    dtStudentInfo.Columns.Add("EmailID", typeof(string));
                    //End Table For Student Information
                    //Information For exam Running or not
                    DataTable dtStudentExamStatus = new DataTable("StudentExamStatus");
                    //Status =0 then exam running status=1 means exam Stop
                    dtStudentExamStatus.Columns.Add("Status", typeof(Int64));
                    DataRow drStudentExamStatus = dtStudentExamStatus.NewRow();
                    drStudentExamStatus["Status"] = 0;
                    dtStudentExamStatus.Rows.Add(drStudentExamStatus);
                    dtStudentExamStatus.AcceptChanges();
                    //Information For exam Running or not
                    DataTable dtCopy = dt.Copy();
                    dsExamInfor.Tables.Add(dtCopy);
                    dsExamInfor.Tables.Add(dtStudentInfo);
                    dsExamInfor.Tables.Add(dtStudentExamStatus);
                    //END Data Table for Student Information
                    //* for Exam
                    Hashtable Question = (Hashtable)Application["Exam_TeacherSheResult"];
                    if (Question == null)
                    {
                        Question = new Hashtable();
                    }
                    Question[Convert.ToString(Session["TrackLogID"])] = dsExamInfor;
                    Application.Lock(); //lock to prevent duplicate objects
                    Application["Exam_TeacherSheResult"] = Question;
                    Application.UnLock();

                    DataSet dsTotalStudent = new DataSet();
                    dsTotalStudent = objQuestionMaster.SELECT_TotalNumStudents(Convert.ToInt32(Session["TrackLogID"].ToString()));
                    if (dsTotalStudent.Tables.Count > 0)
                    {
                        if (dsTotalStudent.Tables[0].Rows.Count > 0)
                        {
                            lblTotalStudentsValue.Text = dsTotalStudent.Tables[0].Rows[0][0].ToString();
                        }
                        else
                        {
                            lblTotalStudentsValue.Text = "0";
                        }

                    }
                    else
                    { lblTotalStudentsValue.Text = "0"; }
                    //*End For Exam
                    ViewState["QuestionAnsDT"] = dt;
                    ViewState["CurQuestion"] = 0;
                    BindNextQuestion(dt);
                }
                else
                {
                    BtnButton.Visible = false;
                    WebMsg.Show("No Question found!");
                }
            }
        }
    }
    #endregion

    #region "User defined functions"
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

            if (RndoKey == "1")
            {
                RndoKey = "true";
            }
            else
            {
                RndoKey = "false";
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

    #region "Control Events"
    protected void BtnButton_Click(object sender, EventArgs e)
    {
        DataTable dt = (DataTable)ViewState["QuestionAnsDT"];

        int i = Convert.ToInt32(ViewState["CurQuestion"]);
        if (dt.Rows.Count - 2 == i)
        {
            dt.Rows[i]["GivenAnswer"] = rdb.SelectedItem.Text;
            dt.Rows[i]["GivenAnswerID"] = rdb.SelectedValue;

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

            dt.AcceptChanges();
            i = i + 1;
            ViewState["CurQuestion"] = i;
            BindNextQuestion(dt);
        }
        else
        {
            dt.Rows[i]["GivenAnswerID"] = rdb.SelectedValue;
            dt.Rows[i]["GivenAnswer"] = rdb.SelectedItem.Text;

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
    protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
    {
        if (Menu1.SelectedValue.ToString() == "0")
        {
            MultiView1.ActiveViewIndex = 0;
        }
        if (Menu1.SelectedValue.ToString() == "1")
        {
            MultiView1.ActiveViewIndex = 1;
        }
    }
    protected void Timer1_Tick(object sender, EventArgs e)
    {
        try
        {
            DataSet dsExamAuto = null;
            //DataTable dtExaAuto = null;
            Hashtable Question = (Hashtable)Application["Exam_TeacherSheResult"];
            if (Question == null)
            {
                Question = new Hashtable();
            }
            else
            {
                dsExamAuto = (DataSet)Question[Session["TrackLogID"].ToString()];
            }
            if (dsExamAuto.Tables[0].Rows.Count > 0)
            {
                TblQuestionResult.Visible = true;
                timertbl.Visible = true;
            }
            grvStudentResultAuto.DataSource = dsExamAuto.Tables[0];
            grvStudentResultAuto.DataBind();
            grvStudentWiseResultAuto.DataSource = dsExamAuto.Tables[1];
            grvStudentWiseResultAuto.DataBind();
            double RightAnswer = Convert.ToDouble(dsExamAuto.Tables[0].Compute("Sum(RightAnswer)", ""));
            double WrongAnswer = Convert.ToDouble(dsExamAuto.Tables[0].Compute("Sum(WrongAnswer)", ""));
            int Attendent = Convert.ToInt32(dsExamAuto.Tables[0].Compute("max(Attendent)", ""));
            lblTotalStudentAttendingTestValue.Text = Convert.ToString(dsExamAuto.Tables[1].Rows.Count);
            double RightPercentage = (RightAnswer * 100) / (RightAnswer + WrongAnswer);
            double WrongPercentage = (WrongAnswer * 100) / (RightAnswer + WrongAnswer);
            lblAvergRightAnswerValue.Text = Convert.ToString(RightPercentage.ToString("n2")) + "%";
            lblAvergWrongAnswerValue.Text = Convert.ToString(WrongPercentage.ToString("n2")) + "%";
            lblAvergRightAnswerValue.Width = Unit.Percentage(RightPercentage);
            lblAvergWrongAnswerValue.Width = Unit.Percentage(WrongPercentage);
            if (lblTotalStudentsValue.Text == "0")
            {
                lblTotalStudentsValue.Text = Convert.ToString(dsExamAuto.Tables[1].Rows.Count);
            }
            BtnStopExam.Enabled = true;
        }
        catch (Exception ex)
        {

            WebMsg.Show("Please logout and login again");
        }
    }


    protected void grvStudentResultAuto_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[1].Text == "&nbsp;")
                {
                    e.Row.Cells[1].Text = "0";
                }
                if (e.Row.Cells[2].Text == "&nbsp;")
                {
                    e.Row.Cells[2].Text = "0";
                }
                if (e.Row.Cells[3].Text == "&nbsp;")
                {
                    e.Row.Cells[3].Text = "0";
                }
                Label LblRightAnswerChart = (Label)e.Row.FindControl("LblRightAnswerChart");
                Label LblWrongAnswerChart = (Label)e.Row.FindControl("LblWrongAnswerChart");
                double RightPercentage = 0;
                double WrongPercentage = 0;
                if (DataBinder.Eval(e.Row.DataItem, "RightAnswer").ToString() != string.Empty || DataBinder.Eval(e.Row.DataItem, "WrongAnswer").ToString() != string.Empty)
                {
                    RightPercentage = (((Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "RightAnswer").ToString())) * 100) / (Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "RightAnswer").ToString()) + Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "WrongAnswer").ToString())));
                    WrongPercentage = (((Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "WrongAnswer").ToString())) * 100) / (Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "RightAnswer").ToString()) + Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "WrongAnswer").ToString())));
                }
                LblRightAnswerChart.Text = RightPercentage.ToString("n2") + "%";
                LblWrongAnswerChart.Text = WrongPercentage.ToString("n2") + "%";
                LblRightAnswerChart.Width = Unit.Percentage(RightPercentage);
                LblWrongAnswerChart.Width = Unit.Percentage(WrongPercentage);
                //Literal PieChart = (Literal)e.Row.FindControl("PieChart");
                //string str = "<div class=\"user_outer\">";

                //str += " <div class=\"pie_outer\">";

                //str += "<div class=\"circle\">";
                //str += "<div class=\"triangle summer\"></div>";
                //str += "<div class=\"triangle autumn\"></div>";
                //str += "<div class=\"triangle autumn2\"></div>";
                //str += "<div class=\"triangle winter\"></div>";
                //str += "<div class=\"triangle winter2\"></div>";
                //str += "<div class=\"triangle spring\"></div>";

                //str += "<div class=\"center\"></div>";
                //str += "</div>";
                //str += "<span class=\"percent nobg purple\">" + RightPercentage + "%" + "</span>";
                //str += "<span class=\"percent nobg pink\">" + RightPercentage + "%" + "</span>";
                //str += "<span class=\"percent nobg turquoise\">" + WrongPercentage + "%" + "</span>";
                //str += "<span class=\"percent nobg blue_light\">" + RightPercentage + "%" + "</span>";

                //str += "<div class=\"center_circle\"></div>";

                //str += "</div></div>";

                //PieChart.Text = HttpUtility.HtmlDecode(str).ToString();
            }
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message.ToString());
        }
    }
    #endregion
    protected void BtnStopExam_Click(object sender, EventArgs e)
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
                if (dsExamAuto.Tables.Count > 2)
                {
                    Application.Lock(); //lock to prevent duplicate objects
                    dsExamAuto.Tables[2].Rows[0]["Status"] = 1;
                    dsExamAuto.Tables[2].AcceptChanges();
                    Question[Session["TrackLogID"].ToString()] = dsExamAuto;

                    Application["Exam_TeacherSheResult"] = Question;
                    Application.UnLock();

                    BtnStopExam.Enabled = false;
                    BtnStopExam.ForeColor = System.Drawing.Color.Red;
                }
            }
        }
    }
    protected void grvStudentWiseResultAuto_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label LblResultPerc = (Label)e.Row.FindControl("LblResultPerc");
                double Percentage = 0;

                if (DataBinder.Eval(e.Row.DataItem, "RightAnswer").ToString() != string.Empty || DataBinder.Eval(e.Row.DataItem, "WrongAnswer").ToString() != string.Empty)
                {
                    Percentage = (((Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "RightAnswer").ToString())) * 100) / (Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "RightAnswer").ToString()) + Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "WrongAnswer").ToString())));

                }
                LblResultPerc.Text = Percentage.ToString("n2") + "%";

                //LblRightAnswerChart.Width = Unit.Percentage(RightPercentage);
            }
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message.ToString());
        }
    }




    private void RegisterPostBackControl()
    {
        foreach (GridViewRow row in GridView1.Rows)
        {
            LinkButton lnkViewResult = row.FindControl("lnkViewResult") as LinkButton;
            ScriptManager.GetCurrent(this).RegisterPostBackControl(lnkViewResult);
        }
    }


    protected void ViewResult(object sender, EventArgs e)
    {
        using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
        {
            int totalquescnt = Convert.ToInt32(row.Cells[2].Text) + Convert.ToInt32(row.Cells[3].Text);
            Label lblstudentid = (Label)row.FindControl("lblstudentID");
            lbltotalquesstudent.Text = totalquescnt.ToString();
            int inttoatalquescnt = Convert.ToInt32(Request.QueryString["noq"]);
            Label lblresultperc = (Label)row.FindControl("lblresultperc");
            if (totalquescnt >= inttoatalquescnt)
            {
                lblcorrectans.Text = row.Cells[2].Text;
                lblwrongans.Text = row.Cells[3].Text;
                lblperc.Text = lblresultperc.Text;

                DataSet ds = new DataSet();
                ReportsForResult objRsultReport = new ReportsForResult();

                ds = objRsultReport.BAL_SYS_ResultRPTByStudentDetails(Convert.ToInt32(lblstudentid.Text), Convert.ToInt32(Request.QueryString["BMSSCTID"]), Convert.ToInt32(AppSessions.EmpolyeeID), DateTime.Now);
                lblstudentname.Text = "Detail Result of " + row.Cells[1].Text;
                GridView1.DataSource = ds.Tables[1];
                GridView1.DataBind();

                
                //dvMainstudentresult.Visible = false;
                dvMainstudentresult.Visible = true;
                
                
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Exam is running, you can view result after exam fininshed')", true);
                //WebMsg.Show("Exam is running, you can view result after exam fininshed");

            }




        }
    }

    protected void gvstudentresult_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                lbltotalquesstudent.Text = "5";

                lblcorrectans.Text = "2";
                lblwrongans.Text = "3";
                dvstudentresult.Visible = true;
                //get question and solution from ResultTbl
                //if (e.ro ==DataControlRowType.DataRow  )
                //{

                //Literal ltQuestion = (Literal)e.Row.FindControl("ltQuestion");
                //Literal lblCorrect = (Literal)e.Row.FindControl("lblCorrect");

                //ltQuestion.Text = HttpUtility.HtmlDecode(DataBinder.Eval(e.Row.DataItem, "Question").ToString());
                //lblCorrect.Text = HttpUtility.HtmlDecode(DataBinder.Eval(e.Row.DataItem, "Answer").ToString());

                //Literal ltQues = (Literal)e.Row.FindControl("ltQues");
                //Literal ltAns = (Literal)e.Row.FindControl("ltAns");

                //ltQues.Text = HttpUtility.HtmlDecode(DataBinder.Eval(e.Row.DataItem, "Question").ToString());
                //ltAns.Text = HttpUtility.HtmlDecode(DataBinder.Eval(e.Row.DataItem, "Solution").ToString());

                //Literal lblGiven = (Literal)e.Row.FindControl("lblGiven");
                //lblGiven.Text = HttpUtility.HtmlDecode(DataBinder.Eval(e.Row.DataItem, "GivenAnswer").ToString());

                //Label lblResult = (Label)e.Row.FindControl("lblResult");
                //lblResult.Text = HttpUtility.HtmlDecode(DataBinder.Eval(e.Row.DataItem, "ResultTF").ToString());

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
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Literal ltQuestion = (Literal)e.Row.FindControl("ltQuestion");
                Literal lblSolution = (Literal)e.Row.FindControl("lblSolution");
                Literal Option1 = (Literal)e.Row.FindControl("Option1");
                Literal Option2 = (Literal)e.Row.FindControl("Option2");
                Literal Option3 = (Literal)e.Row.FindControl("Option3");
                Literal Option4 = (Literal)e.Row.FindControl("Option4");

                ltQuestion.Text = HttpUtility.HtmlDecode(DataBinder.Eval(e.Row.DataItem, "Question").ToString());
                lblSolution.Text = HttpUtility.HtmlDecode(DataBinder.Eval(e.Row.DataItem, "Solution").ToString());

                Option1.Text = "<div style=\"";
                if (DataBinder.Eval(e.Row.DataItem, "Option1ID").ToString() == DataBinder.Eval(e.Row.DataItem, "AnswerID").ToString())
                {
                    Option1.Text = Option1.Text + "color:Red;";
                }
                if (DataBinder.Eval(e.Row.DataItem, "Option1ID").ToString() == DataBinder.Eval(e.Row.DataItem, "GivenAnswerID").ToString())
                {
                    Option1.Text = Option1.Text + "background-color:#ABBCAB;";
                }
                Option1.Text = Option1.Text + "min-width:20px\">A. " + HttpUtility.HtmlDecode(DataBinder.Eval(e.Row.DataItem, "Option1").ToString()) + "</div>";

                Option2.Text = "<div style=\"";
                if (DataBinder.Eval(e.Row.DataItem, "Option2ID").ToString() == DataBinder.Eval(e.Row.DataItem, "AnswerID").ToString())
                {
                    Option2.Text = Option2.Text + "color:Red;";
                }
                if (DataBinder.Eval(e.Row.DataItem, "Option2ID").ToString() == DataBinder.Eval(e.Row.DataItem, "GivenAnswerID").ToString())
                {
                    Option2.Text = Option2.Text + "background-color:#ABBCAB;";
                }
                Option2.Text = Option2.Text + "min-width:20px\">B. " + HttpUtility.HtmlDecode(DataBinder.Eval(e.Row.DataItem, "Option2").ToString()) + "</div>";


                Option3.Text = "<div style=\"";
                if (DataBinder.Eval(e.Row.DataItem, "Option3ID").ToString() == DataBinder.Eval(e.Row.DataItem, "AnswerID").ToString())
                {
                    Option3.Text = Option3.Text + "color:Red;";
                }
                if (DataBinder.Eval(e.Row.DataItem, "Option3ID").ToString() == DataBinder.Eval(e.Row.DataItem, "GivenAnswerID").ToString())
                {
                    Option3.Text = Option3.Text + "background-color:#ABBCAB;";
                }
                Option3.Text = Option3.Text + "min-width:20px\">C. " + HttpUtility.HtmlDecode(DataBinder.Eval(e.Row.DataItem, "Option3").ToString()) + "</div>";

                Option4.Text = "<div style=\"";
                if (DataBinder.Eval(e.Row.DataItem, "Option4ID").ToString() == DataBinder.Eval(e.Row.DataItem, "AnswerID").ToString())
                {
                    Option4.Text = Option4.Text + "color:Red;";
                }
                if (DataBinder.Eval(e.Row.DataItem, "Option4ID").ToString() == DataBinder.Eval(e.Row.DataItem, "GivenAnswerID").ToString())
                {
                    Option4.Text = Option4.Text + "background-color:#ABBCAB;";
                }
                Option4.Text = Option4.Text + "min-width:20px\">D. " + HttpUtility.HtmlDecode(DataBinder.Eval(e.Row.DataItem, "Option4").ToString()) + "</div>";

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
}