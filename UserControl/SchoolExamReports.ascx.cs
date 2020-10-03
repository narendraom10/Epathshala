///<Summary>
///</Summary>

using System;
using System.Data;
using System.Web.UI.WebControls;

public partial class UserControl_SchoolExamReports : System.Web.UI.UserControl
{
    #region Variables
    School_BLogic SchoolBLogic;
    #endregion

    #region "Page events"
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DateTime startOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            DateTime endOfMonth = startOfMonth.AddMonths(1).AddDays(-1);
            txtfromdate.Text = string.Format("{0:dd-MMM-yyyy}", startOfMonth);
            txttodate.Text = string.Format("{0:dd-MMM-yyyy}", endOfMonth);
            ViewState["SchoolID"] = "";
            Session["SchoolNameReport"] = "";
            Session["BoardReport"] = "";
            Session["MediumReport"] = "";
            BindAllDDLSchool();

        }

    }
    #endregion

    #region "User defined functions"
    private void BindAllDDLSchool()
    {
        SchoolBLogic = new School_BLogic();
        DataTable dt = new DataTable();
        dt = SchoolBLogic.BAL_SchoolAllNameWithID("Normal").Tables[0];
        if (dt != null)
        {
            if (dt.Rows.Count > 0)
            {
                DropDownFill DdlFilling = new DropDownFill();
                DdlFilling.BindDropDownByTable(ddlSchool, dt, "Name", "SchoolID");
                ddlSchool.Items.Insert(Convert.ToInt32(EnumFile.AssignValue.Zero), "-- Select --");
                ddlSchool.Items[0].Value = Convert.ToString((int)EnumFile.AssignValue.Zero);
            }

        }
        DDLDisable(ddlBoard, false);

    }
    private void DDLDisable(DropDownList ddl, bool enbDsbl)
    {
        ddl.SelectedIndex = 0;
        ddl.Enabled = enbDsbl;
    }
    private void BindSubjectChapterTopic(int Step)
    {

        DataSet ds = new DataSet();

        SYS_Board_BLogic objSys_Board = new SYS_Board_BLogic();
        ds = objSys_Board.BAL_SYS_StdSubChapTopic_BySchoolIDBoardIDMediumid(Convert.ToInt32(ddlSchool.SelectedValue), Convert.ToInt32(ddlBoard.SelectedValue), Convert.ToInt32(ddlMedium.SelectedValue), Convert.ToInt32(ddlStandard.SelectedValue), Convert.ToInt32(ddlsubject.SelectedValue), Convert.ToInt32(ddlchapter.SelectedValue));

        DropDownFill DdlFilling = new DropDownFill();
        if (Step <= 1)
        {
            if (ds.Tables.Count > 0)
            {
                DdlFilling.BindDropDownByTable(ddlStandard, ds.Tables[0], "Standard", "StandardID");
                DDLDisable(ddlStandard, true);
            }
        }
        if (Step <= 2)
        {
            if (ds.Tables.Count > 1)
            {
                DdlFilling.BindDropDownByTable(ddlsubject, ds.Tables[1], "Subject", "SubjectID");
                DDLDisable(ddlsubject, true);
                DDLDisable(ddlchapter, true);
                DDLDisable(ddltopic, true);
            }
        }
        if (Step <= 3)
        {
            if (ds.Tables.Count > 2)
            {
                DdlFilling.BindDropDownByTable(ddlchapter, ds.Tables[2], "Chapter", "ChapterID");
                DDLDisable(ddlchapter, true);
                DDLDisable(ddltopic, true);
            }
        }
        if (Step <= 4)
        {
            if (ds.Tables.Count > 3)
            {
                DdlFilling.BindDropDownByTable(ddltopic, ds.Tables[3], "Topic", "TopicID");
                DDLDisable(ddltopic, true);
            }
        }





    }
    private void BindGrvResultDetails()
    {
        DataSet ds = new DataSet();
        ReportsForResult objRsultReport = new ReportsForResult();

        ds = objRsultReport.BAL_SYS_ResultClassroomwise_Select(Convert.ToInt32(ddlSchool.SelectedValue), Convert.ToInt32(ddlBoard.SelectedValue), Convert.ToInt32(ddlMedium.SelectedValue), Convert.ToInt32(ddlStandard.SelectedValue), Convert.ToInt32(ddlsubject.SelectedValue), Convert.ToInt32(ddlchapter.SelectedValue), Convert.ToInt32(ddltopic.SelectedValue), Convert.ToDateTime(txtfromdate.Text), Convert.ToDateTime(txttodate.Text));

        if (ds.Tables.Count > 0)
        {
            GridViewOperations GrvOperation = new GridViewOperations();
            GrvOperation.BindGridWithSorting(GrvResultDetails, ds, this.SortField, this.SortDirection);
        }
        else
        {
            GrvResultDetails.DataSource = null;
            GrvResultDetails.DataBind();
        }


    }
    #endregion

    #region "Control Events"
    protected void ddlSchool_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (ddlSchool.SelectedValue != "0")
        {
            DataSet ds = new DataSet();

            SYS_Board_BLogic objSys_Board = new SYS_Board_BLogic();
            ds = objSys_Board.BAL_SYS_Board_BySchoolID(Convert.ToInt32(ddlSchool.SelectedValue));

            DropDownFill DdlFilling = new DropDownFill();
            DdlFilling.BindDropDownByTable(ddlBoard, ds.Tables[0], "Board", "BoardID");

            DDLDisable(ddlBoard, true);
            DDLDisable(ddlMedium, false);
            DDLDisable(ddlStandard, false);
            DDLDisable(ddlsubject, false);
            DDLDisable(ddltopic, false);
            DDLDisable(ddlchapter, false);
        }
        else
        {
            DDLDisable(ddlBoard, false);
            DDLDisable(ddlMedium, false);
            DDLDisable(ddlStandard, false);
            DDLDisable(ddlsubject, false);
            DDLDisable(ddltopic, false);
            DDLDisable(ddlchapter, false);
        }
    }
    protected void ddlBoard_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlBoard.SelectedValue != "0")
        {
            DataSet ds = new DataSet();

            SYS_Board_BLogic objSys_Board = new SYS_Board_BLogic();
            ds = objSys_Board.BAL_SYS_Medium_BySchoolIDBoardID(Convert.ToInt32(ddlSchool.SelectedValue), Convert.ToInt32(ddlBoard.SelectedValue));

            DropDownFill DdlFilling = new DropDownFill();
            DdlFilling.BindDropDownByTable(ddlMedium, ds.Tables[0], "Medium", "MediumID");



            DDLDisable(ddlMedium, true);
            DDLDisable(ddlStandard, false);
            DDLDisable(ddlsubject, false);
            DDLDisable(ddltopic, false);
            DDLDisable(ddlchapter, false);
        }
        else
        {

            DDLDisable(ddlMedium, false);
            DDLDisable(ddlStandard, false);
            DDLDisable(ddlsubject, false);
            DDLDisable(ddltopic, false);
            DDLDisable(ddlchapter, false);
        }

    }
    protected void ddlMedium_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlMedium.SelectedValue != "0")
        {
            BindSubjectChapterTopic(1);
        }
        else
        {

            DDLDisable(ddlStandard, false);
            DDLDisable(ddlsubject, false);
            DDLDisable(ddltopic, false);
            DDLDisable(ddlchapter, false);
        }
    }
    protected void ddlStandard_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindSubjectChapterTopic(2);
    }
    protected void ddlsubject_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindSubjectChapterTopic(3);
    }
    protected void ddlchapter_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindSubjectChapterTopic(4);
    }
    protected void ddltopic_SelectedIndexChanged(object sender, EventArgs e)
    {
        //BindSubjectChapterTopic(5);
    }
    protected void btnview_Click(object sender, EventArgs e)
    {
        AppSessions.SchoolIDRpt = string.Empty;
        ViewState["SchoolID"] = ddlSchool.SelectedValue;
        Session["SchoolNameReport"] = ddlSchool.SelectedItem.Text;
        Session["BoardReport"] = ddlBoard.SelectedItem.Text;
        Session["MediumReport"] = ddlMedium.SelectedItem.Text;
        BindGrvResultDetails();
    }
    protected void GrvResultDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            GrvResultDetails.PageIndex = e.NewPageIndex;
            BindGrvResultDetails();
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }

    }
    protected void GrvResultDetails_RowCreated(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.Pager)
            {
                GridViewOperations GrvOperation = new GridViewOperations();
                GrvOperation.SetPagerButtonStates(GrvResultDetails, e.Row, this.Page);
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
            GrvResultDetails.PageIndex = ((DropDownList)sender).SelectedIndex;
            BindGrvResultDetails();
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }
    protected void GrvResultDetails_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            if (e.SortExpression.Trim() == this.SortField)
                this.SortDirection = (this.SortDirection == "descending" ? "ascending" : "descending");
            else
                this.SortDirection = "ascending";
            this.SortField = e.SortExpression;
            BindGrvResultDetails();
            GridViewOperations GrvOperation = new GridViewOperations();
            GrvOperation.GrvSortingSetImage(e, GrvResultDetails, this.SortDirection);
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }
    protected void GrvResultDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //for (int i = 1; i < e.Row.Cells.Count; i++)
                //{
                //    e.Row.Cells[i].Text = "<a href='SchoolExamReportsClasswiseDetails.aspx?Sc=" + ViewState["SchoolID"].ToString() + "&BMSSCT=" + DataBinder.Eval(e.Row.DataItem, "BMSSCTID").ToString() + "&DivisionID=" + DataBinder.Eval(e.Row.DataItem, "DivisionID").ToString() + " &ExamDate=" + DataBinder.Eval(e.Row.DataItem, "ExamDate").ToString() + "&EmployeeID=" + DataBinder.Eval(e.Row.DataItem, "EmployeeID").ToString() + "'>" + e.Row.Cells[i].Text + "</a>";
                //    //  ViewState["SchoolID"] BMSSCTID,DivisionID,StandardID, SubjectID ,ChapterID,TopicID

                //}

                //add css to GridViewrow based on rowState
                e.Row.CssClass = e.Row.RowState.ToString();
                //Add onclick attribute to select row.
                e.Row.Attributes.Add("onclick", String.Format("javascript:__doPostBack('ctl00$ContentPlaceHolder1$SchoolExamReports1$GrvResultDetails','Select${0}')", e.Row.RowIndex));

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
    protected void GrvResultDetails_SelectedIndexChanged(object sender, EventArgs e)
    {
        AppSessions.SchoolIDRpt = ViewState["SchoolID"].ToString();
        AppSessions.BMSSCTIDRpt = GrvResultDetails.SelectedDataKey.Values["BMSSCTID"].ToString();
        AppSessions.DivisionIDRpt = GrvResultDetails.SelectedDataKey.Values["DivisionID"].ToString();
        AppSessions.ExamDateRpt = GrvResultDetails.SelectedDataKey.Values["ExamDate"].ToString();
        AppSessions.EmployeeIDRpt = GrvResultDetails.SelectedDataKey.Values["EmployeeID"].ToString();
    }
    #endregion   
  
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
    public bool AllowFilter
    {
        get
        {
            return tblFilter.Visible;
        }
        set
        {
            tblFilter.Visible = value;
        }
    }

    #endregion
 }