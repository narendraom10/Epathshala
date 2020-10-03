using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Udev.UserMasterPage.Classes;
using System.Globalization;

public partial class Dashboard_Default : System.Web.UI.Page
{
    #region "Properties"
    string SortDirection
    {
        get
        {
            object o = ViewState["SortDirection"];
            if (o == null)
            {
                return string.Empty;
            }
            else
            {
                return (string)o;
            }
        }

        set
        {
            ViewState["SortDirection"] = value;
        }
    }
    string SortField
    {
        get
        {
            object o = ViewState["SortField"];
            if (o == null)
            {
                return string.Empty;
            }
            else
            {
                return (string)o;
            }
        }

        set
        {
            ViewState["SortField"] = value;
        }
    }
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

    #region "Page Load"
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                if (Session["Topic1"] != null)
                {
                    if (Session["Topic1"].ToString() != string.Empty)
                    {
                        int index = 0;
                        if (Request.QueryString.AllKeys.Contains("TestTypeID"))
                        {
                            if (Request.QueryString["TestTypeID"].ToString() != null || Request.QueryString["TestTypeID"].ToString() != string.Empty)
                            {
                                index = Convert.ToInt32(Request.QueryString["TestTypeID"].ToString());
                                if (index == 0)
                                {
                                    menuTestType.Items.RemoveAt(1);
                                }
                                else if (index == 1)
                                {
                                    menuTestType.Items.RemoveAt(0);
                                }
                            }
                        }
                        else
                        {
                            index = Convert.ToInt32(menuTestType.SelectedValue);
                        }
                        BindGridData(index);
                        lblBMSValue.Text = AppSessions.BMS.ToString();
                        lblTopicValue.Text = Session["Topic1"].ToString();
                        lblChapterValue.Text = Session["Chapter"].ToString();
                        lblSubjectValue.Text = Session["Subject"].ToString();
                    }
                }


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
    #endregion

    #region "User Defined Function"
    private void BindGridData(int index)
    {
        if (Session["Topic1"] != null)
        {
            DataSet dsResult = new DataSet();
            Student_DashBoard_BLogic Student_BAL = new Student_DashBoard_BLogic();
            int SubjectID = Convert.ToInt32(Session["SubjectID"].ToString());
            int ChapterID = Convert.ToInt32(Session["ChapterID"].ToString());
            int TopicID = Convert.ToInt32(Session["TopicID1"].ToString());

            int BMSID = Convert.ToInt32(Session["BMSID"].ToString());
            int StudentID = Convert.ToInt32(Session["StudentID"].ToString());
            string TestType = string.Empty;

            if (index == 0)
            {
                TestType = "Pretest";
            }
            else if (index == 1)
            {
                TestType = "Posttest";
            }

            dsResult = Student_BAL.BAL_SelectStudentTestResultwithDetails(SubjectID, ChapterID, TopicID, BMSID, StudentID, TestType);
            if (dsResult.Tables[0].Rows.Count > 0)
            {
                tblTestResult.Visible = true;
                trError.Visible = false;
                gvAnalysis.DataSource = dsResult;
                gvAnalysis.DataBind();
                int Right = 0;
                int Wrong = 0;
                int count = dsResult.Tables[0].Rows.Count;
                for (int i = 0; i < count; i++)
                {
                    if (dsResult.Tables[0].Rows[i]["Result"].ToString() == "True")
                    {
                        Right++;
                    }
                    else if (dsResult.Tables[0].Rows[i]["Result"].ToString() == "False")
                    {
                        Wrong++;
                    }
                }
                double per = Convert.ToDouble((100 * Right) / count);
                lblAverageValue.Text = per.ToString() + " %";

            }
            else
            {
                gvAnalysis.DataSource = null;
                gvAnalysis.DataBind();
                trError.Visible = true;
                tblTestResult.Visible = false;
            }

        }
    }
    #endregion

    #region "Control Events"
    protected void menuTestType_MenuItemClick(object sender, MenuEventArgs e)
    {
        int index = Convert.ToInt32(menuTestType.SelectedValue);
        BindGridData(index);
    }
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
                if ((DataBinder.Eval(e.Row.DataItem, "Option1ID").ToString() == DataBinder.Eval(e.Row.DataItem, "AnswerID").ToString()) && (DataBinder.Eval(e.Row.DataItem, "Option1ID").ToString() == DataBinder.Eval(e.Row.DataItem, "GivenAnswerID").ToString()))
                {
                    Option1.Text = Option1.Text + "color:Black;background-color:Green;";
                }
                else
                {
                    if (DataBinder.Eval(e.Row.DataItem, "Option1ID").ToString() == DataBinder.Eval(e.Row.DataItem, "AnswerID").ToString())
                    {
                        //Option1.Text = Option1.Text + "color:Green;";
                        Option1.Text = Option1.Text + "color:Black;background-color:Yellow;";
                    }
                    if (DataBinder.Eval(e.Row.DataItem, "Option1ID").ToString() == DataBinder.Eval(e.Row.DataItem, "GivenAnswerID").ToString())
                    {
                        Option1.Text = Option1.Text + "color:Black;background-color:Red;";
                    }
                }
                Option1.Text = Option1.Text + "min-width:20px\">A. " + HttpUtility.HtmlDecode(DataBinder.Eval(e.Row.DataItem, "Option1").ToString()) + "</div>";

                Option2.Text = "<div style=\"";
                if ((DataBinder.Eval(e.Row.DataItem, "Option2ID").ToString() == DataBinder.Eval(e.Row.DataItem, "AnswerID").ToString()) && (DataBinder.Eval(e.Row.DataItem, "Option2ID").ToString() == DataBinder.Eval(e.Row.DataItem, "GivenAnswerID").ToString()))
                {
                    Option2.Text = Option2.Text + "color:Black;background-color:Green;";
                }
                else
                {

                    if (DataBinder.Eval(e.Row.DataItem, "Option2ID").ToString() == DataBinder.Eval(e.Row.DataItem, "AnswerID").ToString())
                    {
                        //Option2.Text = Option2.Text + "color:Green;";
                        Option2.Text = Option2.Text + "color:Black;background-color:Yellow;";
                    }
                    if (DataBinder.Eval(e.Row.DataItem, "Option2ID").ToString() == DataBinder.Eval(e.Row.DataItem, "GivenAnswerID").ToString())
                    {
                        Option2.Text = Option2.Text + "color:Black;background-color:Red;";
                    }
                }
                Option2.Text = Option2.Text + "min-width:20px\">B. " + HttpUtility.HtmlDecode(DataBinder.Eval(e.Row.DataItem, "Option2").ToString()) + "</div>";


                Option3.Text = "<div style=\"";
                if ((DataBinder.Eval(e.Row.DataItem, "Option3ID").ToString() == DataBinder.Eval(e.Row.DataItem, "AnswerID").ToString()) && (DataBinder.Eval(e.Row.DataItem, "Option3ID").ToString() == DataBinder.Eval(e.Row.DataItem, "GivenAnswerID").ToString()))
                {
                    Option3.Text = Option3.Text + "color:Black;background-color:Green;";
                }
                else
                {
                    if (DataBinder.Eval(e.Row.DataItem, "Option3ID").ToString() == DataBinder.Eval(e.Row.DataItem, "AnswerID").ToString())
                    {
                        //Option3.Text = Option3.Text + "color:Green;";
                        Option3.Text = Option3.Text + "color:Black;background-color:Yellow;";
                    }
                    if (DataBinder.Eval(e.Row.DataItem, "Option3ID").ToString() == DataBinder.Eval(e.Row.DataItem, "GivenAnswerID").ToString())
                    {
                        Option3.Text = Option3.Text + "color:Black;background-color:Red;";
                    }
                }
                Option3.Text = Option3.Text + "min-width:20px\">C. " + HttpUtility.HtmlDecode(DataBinder.Eval(e.Row.DataItem, "Option3").ToString()) + "</div>";

                Option4.Text = "<div style=\"";
                if ((DataBinder.Eval(e.Row.DataItem, "Option4ID").ToString() == DataBinder.Eval(e.Row.DataItem, "AnswerID").ToString()) && (DataBinder.Eval(e.Row.DataItem, "Option4ID").ToString() == DataBinder.Eval(e.Row.DataItem, "GivenAnswerID").ToString()))
                {
                    Option4.Text = Option4.Text + "color:Black;background-color:Green;";
                }
                else
                {
                    if (DataBinder.Eval(e.Row.DataItem, "Option4ID").ToString() == DataBinder.Eval(e.Row.DataItem, "AnswerID").ToString())
                    {
                        //Option4.Text = Option4.Text + "color:Green;";
                        Option4.Text = Option4.Text + "color:Black;background-color:Yellow;";
                    }
                    if (DataBinder.Eval(e.Row.DataItem, "Option4ID").ToString() == DataBinder.Eval(e.Row.DataItem, "GivenAnswerID").ToString())
                    {
                        Option4.Text = Option4.Text + "color:Black;background-color:Red;";
                    }
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
    protected void DdlPageSelector_SelectedIndexChanged(object sender, EventArgs e)
    {
        gvAnalysis.PageIndex = ((DropDownList)sender).SelectedIndex;
        int index = Convert.ToInt32(menuTestType.SelectedValue);
        BindGridData(index);
    }
    protected void gvAnalysis_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvAnalysis.PageIndex = e.NewPageIndex;
        int index = Convert.ToInt32(menuTestType.SelectedValue);
        BindGridData(index);
    }
    protected void gvAnalysis_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Pager)
        {
            GridViewOperations GrvOperation = new GridViewOperations();
            GrvOperation.SetPagerButtonStates(gvAnalysis, e.Row, this.Page);
        }
    }
    protected void gvAnalysis_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (e.SortExpression.Trim() == this.SortField)
        {
            this.SortDirection = (this.SortDirection == "descending" ? "ascending" : "descending");
        }
        else
        {
            this.SortDirection = "ascending";
            this.SortField = e.SortExpression;
            int index = Convert.ToInt32(menuTestType.SelectedValue);
            BindGridData(index);
        }

        GridViewOperations GrvOperation = new GridViewOperations();
        GrvOperation.GrvSortingSetImage(e, gvAnalysis, this.SortDirection);
    }
    #endregion
    protected void btnClose_Click(object sender, EventArgs e)
    {
        string Type = Request.QueryString["Type"].ToString();
        if (Type == "Teacher")
        {
            Response.Redirect("TeacherPreTestPostTestResult.aspx");
        }
        else if (Type == "Student")
        {
            Response.Redirect("StudentDashboard.aspx");
        }
    }
}