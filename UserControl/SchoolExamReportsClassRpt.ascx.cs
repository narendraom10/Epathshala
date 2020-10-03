///<Summary>
///</Summary>

using System;
using System.Web.UI.WebControls;
using System.Data;

public partial class UserControl_SchoolExamReportsClassRpt : System.Web.UI.UserControl
{
    # region Variables
    # endregion

    #region "Properties"

    string SortDirection
    {
        get
        {
            object o = ViewState["SortDirection"];
            if (o == null)
                return String.Empty;
            else
                return (string)o;
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
                return String.Empty;
            else
                return (string)o;
        }
        set
        {
            ViewState["SortField"] = value;
        }
    }

    #endregion

    #region 'Page Event'
    protected void Page_Load(object sender, EventArgs e)
    {

        //if (!IsPostBack)
        //{ 
        if (AppSessions.SchoolIDRpt != string.Empty)
        {

            if (Session["SchoolNameReport"] != null)
                lblSchoolValue.Text = Session["SchoolNameReport"].ToString();

            if (Session["BoardReport"] != null)
                lblBoardValue.Text = Session["BoardReport"].ToString();

            if (Session["MediumReport"] != null)
                lblMediumValue.Text = Session["MediumReport"].ToString();


            BindGrvResultDetails1(1);
        }
        //}}
    }
    #endregion

    #region 'User Define Function'
    private void BindGrvResultDetails1(int FirstTime)
    {
        try
        {
            DataSet ds = new DataSet();
            ReportsForResult objRsultReport = new ReportsForResult();

            ds = objRsultReport.BAL_SYS_ResultClassroomwiseByFirRPT_Select(Convert.ToInt32(AppSessions.SchoolIDRpt), Convert.ToInt32(AppSessions.BMSSCTIDRpt), Convert.ToInt32(AppSessions.EmployeeIDRpt), Convert.ToInt32(AppSessions.DivisionIDRpt), Convert.ToDateTime(AppSessions.ExamDateRpt));

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
                        lblDateValue.Text = Convert.ToDateTime(AppSessions.ExamDateRpt).ToString();
                        lblteacherValue.Text = ds.Tables[0].Rows[0]["Teacher"].ToString();
                    }
                    FirstTime = 0;
                }
                GridViewOperations GrvOperation = new GridViewOperations();
                GrvOperation.BindGridWithSorting(GrvResultDetails1, ds, this.SortField, this.SortDirection);
            }
            else
            {
                GrvResultDetails1.DataSource = null;
                GrvResultDetails1.DataBind();
            }

        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }
    #endregion

    #region Control Event
    protected void GrvResultDetails1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            GrvResultDetails1.PageIndex = e.NewPageIndex;
            BindGrvResultDetails1(0);
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }

    }
    protected void GrvResultDetails1_RowCreated(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.Pager)
            {
                GridViewOperations GrvOperation = new GridViewOperations();
                GrvOperation.SetPagerButtonStates(GrvResultDetails1, e.Row, this.Page);
            }
            if (e.Row.RowType == System.Web.UI.WebControls.DataControlRowType.DataRow)
            {

                e.Row.Attributes.Add("onmouseover", "this.originalstyle=this.style.backgroundColor;this.style.backgroundColor='#95DDDD';this.style.cursor='pointer'");

                // when mouse leaves the row, change the bg color to its original value  
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalstyle;");


            }
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }
    protected void ddlPageSelector_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            GrvResultDetails1.PageIndex = ((DropDownList)sender).SelectedIndex;
            BindGrvResultDetails1(0);
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }
    protected void GrvResultDetails1_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            if (e.SortExpression.Trim() == this.SortField)
                this.SortDirection = (this.SortDirection == "descending" ? "ascending" : "descending");
            else
                this.SortDirection = "ascending";
            this.SortField = e.SortExpression;
            BindGrvResultDetails1(0);
            GridViewOperations GrvOperation = new GridViewOperations();
            GrvOperation.GrvSortingSetImage(e, GrvResultDetails1, this.SortDirection);
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }
    protected void GrvResultDetails1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                // e.Row.Cells[i].Text = "<a href='SchoolExamReportStudentRPT.aspx?StudentID=" + DataBinder.Eval(e.Row.DataItem, "StudentID").ToString() + "&BMSSCT=" + DataBinder.Eval(e.Row.DataItem, "BMSSCTID").ToString() + " &ExamDate=" + ViewState["ExamDate"].ToString() + "&EmployeeID=" + DataBinder.Eval(e.Row.DataItem, "EmployeeID").ToString() + "'>" + e.Row.Cells[i].Text + "</a>";
                //  ViewState["SchoolID"] BMSSCTID,DivisionID,StandardID, SubjectID ,ChapterID,TopicID
                e.Row.Attributes.Add("onclick", String.Format("javascript:__doPostBack('ctl00$ContentPlaceHolder1$SchoolExamReports1$GrvResultDetails1','Select${0}')", e.Row.RowIndex));



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
    protected void GrvResultDetails1_SelectedIndexChanged(object sender, EventArgs e)
    {
        //MyBaseControl uc1 = new MyBaseControl();

        //uc1.StudentID = GrvResultDetails1.SelectedDataKey.Values["StudentID"].ToString();
        //uc1.BMSSCTID = GrvResultDetails1.SelectedDataKey.Values["BMSSCTID"].ToString();        
        //uc1.ExamDate = ViewState["ExamDate"].ToString();
        //uc1.EmployeeID = GrvResultDetails1.SelectedDataKey.Values["EmployeeID"].ToString();






    }
    #endregion
}