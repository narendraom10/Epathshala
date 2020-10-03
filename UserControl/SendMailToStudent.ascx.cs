using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
using System.Text;
using System.IO;

public partial class UserControl_SendMailToStudent : System.Web.UI.UserControl
{

    #region variable

    Student_BLogic obj_Student_BLogic;
    SYS_Role_BLogic obj_BAL_SYS_Role;
    SYS_Role obj_SYS_Role;

    #endregion

    # region Properties

    public int SchoolID
    {
        get
        {
            object o = this.ViewState["SchoolID"];
            if (o == null)
            {
                return 0;
            }
            else
            {
                return (int)o;
            }
        }
        set
        {
            this.ViewState["SchoolID"] = value;
        }
    }
    public int BMSID
    {
        get
        {
            object o = this.ViewState["BMSID"];
            if (o == null)
            {
                return 0;
            }
            else
            {
                return (int)o;
            }
        }
        set
        {
            this.ViewState["BMSID"] = value;
        }
    }
    public int DivisionID
    {
        get
        {
            object o = this.ViewState["DivisionID"];
            if (o == null)
            {
                return 0;
            }
            else
            {
                return (int)o;
            }
        }
        set
        {
            this.ViewState["DivisionID"] = value;
        }
    }
    public string Subject { get; set; }
    public string MailBody { get; set; }
    public string PageTitle { get; set; }
    ArrayList _Attachment = new ArrayList();

    public ArrayList Attachment
    {
        get { return _Attachment; }
        set { _Attachment = value; }
    }

    string SortDirection
    {
        get
        {
            object o = this.ViewState["SortDirection"];
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
            this.ViewState["SortDirection"] = value;
        }
    }
    string SortField
    {
        get
        {
            object o = this.ViewState["SortField"];
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
            this.ViewState["SortField"] = value;
        }
    }

    #endregion

    #region Page events

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindAttachment();
            BindBoardDropDown();
            ddlBoard.SelectedValue = Convert.ToString(BMSID);
            BindDivisionDropDown();
            ddlDivision.SelectedValue = Convert.ToString(DivisionID);
            txtsubject.Text = Subject;
            txtmail.Content = MailBody;
            lblTitle.Text = PageTitle;
            BindStudentGrid();
        }
    }

    #endregion

    #region Control Event

    protected void btnsendmail_Click(object sender, EventArgs e)
    {
        Attachment.Clear();
        string[] AttachmmentList = hdnAttachment.Value.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
        foreach (string strAttachment in AttachmmentList)
        {
            Attachment.Add(strAttachment);
        }
        gvresult.Visible = true;

        DataTable dt = new DataTable();
        dt.Columns.Add("Roll No", typeof(string));
        dt.Columns.Add("Name", typeof(string));
        dt.Columns.Add("EmailID", typeof(string));
        dt.Columns.Add("Status", typeof(string));

        foreach (GridViewRow row in gvstudent.Rows)
        {
            CheckBox chk = (CheckBox)row.FindControl("chkSelect");
            if (chk.Checked)
            {
                HiddenField hdn = (HiddenField)row.FindControl("hdnEmailID");
                Label lblRollNo = (Label)row.FindControl("GV_LblSRNO");
                Label lblName = (Label)row.FindControl("GV_LblStudentName");
                string Response = SendMail(hdn.Value, txtsubject.Text, ReplaceTag(txtmail.Content, lblName.Text), "", Attachment);
                dt.Rows.Add(lblRollNo.Text, lblName.Text, hdn.Value, Response);
            }
        }
        gvresult.DataSource = dt;
        gvresult.DataBind();

        BindAttachment();

        mdlresult.Show();

        mainpanel.Attributes["class"] = "dvcollapsed";

        gvresult.Focus();
    }
    protected void ddlBoard_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlBoard.SelectedIndex > ((int)EnumFile.AssignValue.Zero))
        {
            BindDivisionDropDown();
        }
        else
        {
            ddlDivision.Items.Clear();
            ddlDivision.DataSource = null;
            ddlDivision.DataBind();
            ddlDivision.Items.Insert(((int)EnumFile.AssignValue.Zero), new ListItem("-- Select --"));
        }
        gvstudent.DataSource = null;
        gvstudent.DataBind();
    }
    protected void gvstudent_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (e.SortExpression.Trim() == this.SortField)
        {
            this.SortDirection = this.SortDirection == "descending" ? "ascending" : "descending";
        }
        else
        {
            this.SortDirection = "ascending";
        }
        this.SortField = e.SortExpression;

        GridViewOperations GrvOperation = new GridViewOperations();
        GrvOperation.GrvSortingSetImage(e, this.gvstudent, this.SortDirection);

        BMSID = Convert.ToInt32(ddlBoard.SelectedItem.Value);
        DivisionID = Convert.ToInt32(ddlDivision.SelectedItem.Value);

        BindStudentGrid();
    }
    protected void btngo_Click(object sender, EventArgs e)
    {
        BMSID = Convert.ToInt32(ddlBoard.SelectedItem.Value);
        DivisionID = Convert.ToInt32(ddlDivision.SelectedItem.Value);
        BindStudentGrid();

        gvresult.DataSource = null;
        gvresult.DataBind();

        gvresult.Visible = false;
    }
    protected void gvstudent_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label oLable = (Label)e.Row.FindControl("GV_LblEmail");
            if (string.IsNullOrEmpty(oLable.Text))
                e.Row.Enabled = false;
        }
    }
    protected void btnclose_Click(object sender, EventArgs e)
    {
        if (AppSessions.Role == "Teacher")
            Response.Redirect("TeacherDashboard.aspx");
    }

    #endregion

    #region "User defined functions"

    private void BindStudentGrid()
    {
        obj_Student_BLogic = new Student_BLogic();

        DataSet ds = new DataSet();
        ds = obj_Student_BLogic.BAL_Student_SelectBMSDIV(SchoolID, BMSID, DivisionID);

        GridViewOperations GrvOperation = new GridViewOperations();
        GrvOperation.BindGridWithSorting(this.gvstudent, ds, this.SortField, this.SortDirection);
    }
    public void BindBoardDropDown()
    {
        obj_SYS_Role = new SYS_Role();
        obj_BAL_SYS_Role = new SYS_Role_BLogic();

        DataSet dsSelect = new DataSet();
        dsSelect = obj_BAL_SYS_Role.BAL_Select_Employee_BMS_SelectAll(Convert.ToInt64(Session["EmpolyeeID"]));

        if (dsSelect.Tables.Count > ((int)EnumFile.AssignValue.Zero))
        {
            ddlBoard.DataSource = dsSelect.Tables[0];
            ddlBoard.DataTextField = "BMS";
            ddlBoard.DataValueField = "BMSID";
            ddlBoard.DataBind();
            ddlBoard.Items.Insert(((int)EnumFile.AssignValue.Zero), new ListItem("-- Select --", "0"));
        }
    }
    private void BindDivisionDropDown()
    {
        BMSID = Convert.ToInt32(ddlBoard.SelectedItem.Value);

        if (BMSID > ((int)EnumFile.AssignValue.Zero))
        {
            obj_BAL_SYS_Role = new SYS_Role_BLogic();
            DataSet dsSelect = new DataSet();

            dsSelect = obj_BAL_SYS_Role.BAL_Allocated_Subject_Div_BasedonBMS(BMSID, Convert.ToInt64(Session["EmpolyeeID"]));

            if (dsSelect.Tables[0].Rows.Count > ((int)EnumFile.AssignValue.Zero))
            {
                ddlDivision.Items.Clear();
                ddlDivision.DataSource = dsSelect.Tables[1];
                ddlDivision.DataTextField = "Division";
                ddlDivision.DataValueField = "DivisionID";
                ddlDivision.DataBind();
                ddlDivision.Items.Insert(((int)EnumFile.AssignValue.Zero), new ListItem("-- Select --", "0"));
            }
        }
    }
    private void BindAttachment()
    {
        StringBuilder oBuilder = new StringBuilder();
        if (Attachment.Count != 0)
        {
            for (int i = 0; i < Attachment.Count; i++)
            {
                FileInfo fileinfo = new FileInfo(Convert.ToString(Attachment[i]));

                oBuilder.Append("<div class='dvupload' id='dvupload" + i + "'>");
                oBuilder.Append("<div class='fileName'>");
                oBuilder.Append("<span class='attchfilename' title='" + fileinfo.Length / 1024 + " KB'>" + fileinfo.Name + "</span>");
                oBuilder.Append("<span class='attchfilenamepath' style='display:none;'>" + fileinfo.FullName + "</span>");
                oBuilder.Append("</div>");
                oBuilder.Append("<div class='closebtn'>");
                oBuilder.Append("<a href=\"javascript:deletedvupload('dvupload" + i + "');\">");
                oBuilder.Append("<img border='0' src='../App_Themes/Responsive/web/cancel.png' style='cursor:pointer'>");
                oBuilder.Append("</a>");
                oBuilder.Append("</div>");
                oBuilder.Append("</div>");
            }
            ltrAttachment.Text = oBuilder.ToString();
        }
    }
    private string SendMail(string emailid, string mailsubject, string mailcontent, string comment, ArrayList SelectedAttachment)
    {
        string Response = string.Empty;
        if (!string.IsNullOrEmpty(emailid))
        {
            ArrayList alistEmailAddress = new ArrayList();
            alistEmailAddress.Add(emailid);
            if (alistEmailAddress.Count > 0)
            {
                bool IsSendSuccess = EmailUtility.SendEmail(alistEmailAddress, mailsubject, mailcontent, SelectedAttachment);
                if (IsSendSuccess)
                    Response = "Send email successfully.";
                else
                    Response = "Send email failed.";
            }
        }
        else
        {
            Response = "Send email failed.[Email address is empty]";
        }
        return Response;
    }
    private string ReplaceTag(string mailbody, string studentname)
    {
        mailbody = mailbody.Replace("#STUDENTNAME#", studentname);
        return mailbody.Replace("#TEACHERNAME#", AppSessions.UserName);
    }

    #endregion
}