/// <DevelopedBy>"Arpit Patel"</DevelopedBy>
/// <Date>4-December-2013</Date>
/// </summary>

using System;
using System.Data;
using System.Web.UI.WebControls;

public partial class UserControl_TeacherNotes : System.Web.UI.UserControl
{
    # region Variables
    TeacherNotes_BLogic BAL_TeacherNotes;
    TeacherNotes TeacherNotes;
    # endregion

    # region Properties
    # endregion

    # region Page events
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindTeacherNotes();
        }
    }
    #  endregion

    # region Control events
    protected void gvNotes_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvNotes.PageIndex = e.NewPageIndex;
            BindTeacherNotes();
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }
    protected void lnkViewAll_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Teacher/ViewAllTeacherNotes.aspx");
    }
    # endregion

    # region User defined functions
    protected void BindTeacherNotes()
    {
        try
        {
            BAL_TeacherNotes = new TeacherNotes_BLogic();
            TeacherNotes = new TeacherNotes();
            DataSet dsTeacherNotes = new DataSet();
            dsTeacherNotes = BAL_TeacherNotes.BAL_Teacher_Note_Select(TeacherNotes, "ViewAdmin");
            if (dsTeacherNotes.Tables[0].Rows.Count > 0)
            {
                gvNotes.DataSource = dsTeacherNotes.Tables[0];
                gvNotes.DataBind();
            }
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }
    protected void gvNotes_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {

            if (e.CommandName == "ViewNote")
            {
                int index = int.Parse(e.CommandArgument.ToString());

                lblPopUpNote.Text = gvNotes.DataKeys[index]["Note"].ToString();
                lblPopUpSchoolName.Text = gvNotes.DataKeys[index]["Name"].ToString();
                lblPopUpBMSSCT.Text = gvNotes.DataKeys[index]["BMS_SCT"].ToString();


                this.ModalPopUpNotes.Show();
                this.upPopUp.Update();
            }
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }
    # endregion
}