///<Summary>
///</Summary>

using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControl_SchoolExamReportsStudentRpt : System.Web.UI.UserControl
{
    # region Variables
    # endregion

    #region Property
    public int StudentID
    {
        get
        {
            if (ViewState["StudentID"] == null || ViewState["StudentID"].ToString() == string.Empty)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(ViewState["StudentID"].ToString());
            }
        }

        set
        {
            ViewState["StudentID"] = value;
        }
    }
    public int BMSSCTID
    {
        get
        {
            if (ViewState["BMSSCTID"] == null || ViewState["BMSSCTID"].ToString() == string.Empty)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(ViewState["BMSSCTID"].ToString());
            }
        }

        set
        {
            ViewState["BMSSCTID"] = value;
        }
    }
    public int EmployeeID
    {
        get
        {
            if (ViewState["EmployeeID"] == null || ViewState["EmployeeID"].ToString() == string.Empty)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(ViewState["EmployeeID"].ToString());
            }
        }

        set
        {
            ViewState["EmployeeID"] = value;
        }
    }
    public DateTime ExamDate
    {
        get
        {
            if (ViewState["ExamDate"] == null || ViewState["ExamDate"].ToString() == string.Empty)
            {
                return DateTime.Now.Date;
            }
            else
            {
                return Convert.ToDateTime(ViewState["ExamDate"].ToString());
            }
        }

        set
        {
            ViewState["ExamDate"] = value;
        }
    }
    #endregion

    #region PageEvents
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            if (Session["SchoolNameReport"] != null)
                lblSchoolValue.Text = Session["SchoolNameReport"].ToString();

            if (Session["BoardReport"] != null)
                lblBoardValue.Text = Session["BoardReport"].ToString();

            if (Session["MediumReport"] != null)
                lblMediumValue.Text = Session["MediumReport"].ToString();

            BindGrvResultDetails(1);
        }

    }
#endregion

    #region ControlEvents
    protected void gvAnalysis_RowDataBound(object sender, GridViewRowEventArgs e)
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
    #endregion

    #region UserDefinedFunction
    private void BindGrvResultDetails(int FirstTime)
    {
        try
        {
            DataSet ds = new DataSet();
            ReportsForResult objRsultReport = new ReportsForResult();

            ds = objRsultReport.BAL_SYS_ResultRPTByStudentDetails(this.StudentID, this.BMSSCTID, this.EmployeeID, this.ExamDate);

            if (ds.Tables.Count > 0)
            {
                if (FirstTime == 1)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        lblStandardValue.Text = ds.Tables[0].Rows[0]["Standard"].ToString();
                        lblsubjectValue.Text = ds.Tables[0].Rows[0]["Subject"].ToString();
                        lblChapterValue.Text = ds.Tables[0].Rows[0]["Chapter"].ToString();
                        lbltopicValue.Text = ds.Tables[0].Rows[0]["Topic"].ToString();
                        lblDateValue.Text = ViewState["ExamDate"].ToString();
                        lblteacherValue.Text = ds.Tables[0].Rows[0]["Teacher"].ToString();
                        lblStudentValue.Text = ds.Tables[0].Rows[0]["FirstName"].ToString();
                        lblTrueAnsValue.Text = ds.Tables[0].Rows[0]["True"].ToString();
                        lblFalseAnsValue.Text = ds.Tables[0].Rows[0]["False"].ToString();
                        lblResultValue.Text = ds.Tables[0].Rows[0]["Perc"].ToString();

                        Label1.Text = ds.Tables[0].Rows[0]["True"].ToString();
                        Label2.Text = ds.Tables[0].Rows[0]["False"].ToString();
                        lblTotalQues.Text = (Convert.ToInt32(ds.Tables[0].Rows[0]["True"].ToString()) + Convert.ToInt32(ds.Tables[0].Rows[0]["False"].ToString())).ToString();
                        lbluserScoreValue.Text = Label1.Text + "/" + lblTotalQues.Text;
                    }
                    FirstTime = 0;
                }
                gvAnalysis.DataSource = ds.Tables[1];
                gvAnalysis.DataBind();
            }
            else
            {
                gvAnalysis.DataSource = null;
                gvAnalysis.DataBind();
            }

        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }
    #endregion
}