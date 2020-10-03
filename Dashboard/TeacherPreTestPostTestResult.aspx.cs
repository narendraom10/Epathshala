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
                if (Session["Topic1"].ToString() != null || Session["Topic1"].ToString() != string.Empty)
                {
                    int index = Convert.ToInt32(menuTestType.SelectedValue);

                    BindGridData(index);
                    lblBMSValue.Text = AppSessions.BMS.ToString();
                    lblTopicValue.Text = Session["Topic1"].ToString();
                    lblChapterValue.Text = Session["Chapter"].ToString();
                    lblSubjectValue.Text = Session["Subject"].ToString();
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
        DataSet dsResult = new DataSet();
        Teacher_Dashboard_BLogic Teacher_BAL = new Teacher_Dashboard_BLogic();
        string TestType = string.Empty;
        lblBMSValue.Text = AppSessions.BMS.ToString();
        lblDivisionValue.Text = AppSessions.Division.ToString();
        lblSubjectValue.Text = AppSessions.Subject.ToString();

        int SchoolID = AppSessions.SchoolID;
        int ChapterID = Convert.ToInt32(Session["ChapterID"].ToString());
        int TopicID = Convert.ToInt32(Session["TopicID1"].ToString());
        int EmployeeID = AppSessions.EmpolyeeID;
        int DivisionID = AppSessions.DivisionID;
        int BMSID = AppSessions.BMSID;
        int SubjectID = AppSessions.SubjectID;
        if (index == 0)
        {
            TestType = "Pretest";
        }
        else if (index == 1)
        {
            TestType = "Posttest";
        }

        dsResult = Teacher_BAL.SelectTeacherTestResult(SchoolID, BMSID, EmployeeID, DivisionID, ChapterID, TopicID, SubjectID, TestType);
        if (dsResult.Tables.Count > 0)
        {
            if (dsResult.Tables[0].Rows.Count > 0)
            {
                tblTestResult.Visible = true;
                trError.Visible = false;
                grTestResult.DataSource = dsResult;
                grTestResult.DataBind();
            }
            else
            {
                tblTestResult.Visible = false;
                trError.Visible = true;
                grTestResult.DataSource = null;
                grTestResult.DataBind();
            }
        }
        else
        {
            grTestResult.DataSource = null;
            grTestResult.DataBind();
            trError.Visible = true;
            tblTestResult.Visible = false;
        }
    }
    #endregion

    #region "Control Events"
    protected void menuTestType_MenuItemClick(object sender, MenuEventArgs e)
    {
        int index = Convert.ToInt32(menuTestType.SelectedValue);
        BindGridData(index);
    }
    protected void DdlPageSelector_SelectedIndexChanged(object sender, EventArgs e)
    {
        grTestResult.PageIndex = ((DropDownList)sender).SelectedIndex;
        int index = Convert.ToInt32(menuTestType.SelectedValue);
        BindGridData(index);
    }
    #endregion


    protected void grTestResult_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grTestResult.PageIndex = e.NewPageIndex;
        int index = Convert.ToInt32(menuTestType.SelectedValue);
        BindGridData(index);
    }
    protected void grTestResult_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            for (int i = 1; i < e.Row.Cells.Count; i++)
            {
                //add css to GridViewrow based on rowState
                e.Row.CssClass = e.Row.RowState.ToString();
                //Add onclick attribute to select row.
                e.Row.Attributes.Add("onclick", String.Format("javascript:__doPostBack('grTestResult','Select${0}')", e.Row.RowIndex));
            }
        }
    }
    protected void grTestResult_Sorting(object sender, GridViewSortEventArgs e)
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
        GrvOperation.GrvSortingSetImage(e, grTestResult, this.SortDirection);
    }
    protected void grTestResult_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Pager)
        {
            GridViewOperations GrvOperation = new GridViewOperations();
            GrvOperation.SetPagerButtonStates(grTestResult, e.Row, this.Page);
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // when mouse is over the row, save original color to new attribute, and change it to highlight color
            e.Row.Attributes.Add("onmouseover", "this.originalstyle=this.style.backgroundColor;this.style.backgroundColor='#95DDDD';this.style.cursor='pointer'");

            // when mouse leaves the row, change the bg color to its original value  
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalstyle;");
        }
    }
    protected void btnClose_Click1(object sender, EventArgs e)
    {
        Response.Redirect("TeacherDashboard.aspx");
    }
    protected void grTestResult_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (grTestResult.SelectedDataKey.Values["StudentID"].ToString() != "" && (grTestResult.SelectedDataKey.Values["ExamID"].ToString() != "" || grTestResult.SelectedDataKey.Values["ExamID"].ToString() != string.Empty))
        {
            int StudentID = Convert.ToInt32(grTestResult.SelectedDataKey.Values["StudentID"].ToString());
            int ExamID = Convert.ToInt32(grTestResult.SelectedDataKey.Values["ExamID"].ToString());

            Session["StudentID"] = StudentID;
            Session["ExamID"] = ExamID;
            int TestTypeID = Convert.ToInt32(menuTestType.SelectedValue);
            Response.Redirect("StudentPreTestPostTestResult.aspx?Type=Teacher&TestTypeID=" + TestTypeID);
        }
    }
}