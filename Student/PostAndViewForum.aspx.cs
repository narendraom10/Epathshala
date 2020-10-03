using System;
using System.Data;
using System.Web.UI;

public partial class Student_PostAndViewForum : System.Web.UI.Page
{
    #region "Declaration"

    Forum_BAL oForum_BAL;
    Forum oForum;

    #endregion

    #region Properties

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

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindPostGrid();
        }
    }
    private void BindPostGrid()
    {
        oForum = new Forum();
        oForum_BAL = new Forum_BAL();

        DataSet ods = oForum_BAL.Forum_Select_All(oForum);

        GridViewOperations GrvOperation = new GridViewOperations();
        GrvOperation.BindGridWithSorting(this.GvPost, ods, this.SortField, this.SortDirection);
    }
    protected void btnpost_Click(object sender, EventArgs e)
    {
        oForum_BAL = new Forum_BAL();
        oForum = new Forum();

        oForum.Post = TxtForum.Value;
        oForum.PostedBy = AppSessions.StudentID;

        bool IsInsert = oForum_BAL.Forum_Insert(oForum);

        if (IsInsert)
        {
            WebMsg.Show("Post has been created successfully.");
            ResetControl();
        }
        else
            WebMsg.Show("There is some problem to create post, please try again.");
    }
    private void ResetControl()
    {
        TxtForum.Value = "";
    }
}