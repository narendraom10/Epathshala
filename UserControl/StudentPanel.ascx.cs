///<Summary>
///</Summary>

using System;
using System.Data;

public partial class UserControl_StudentPanel : System.Web.UI.UserControl
{
    # region Variables
    Student_DashBoard_BLogic BLogic_Student_DashBoard;
    StudentDash StudenDash;
    # endregion

    # region Properties
    # endregion

    # region Page events
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindSubjectList();
        }
    }
    # endregion

    # region Control events
    # endregion

    # region User defined functions
    protected void BindSubjectList()
    {
        try
        {
            BLogic_Student_DashBoard=new Student_DashBoard_BLogic();
            StudenDash = new StudentDash();
            StudenDash.BMSID = 18;
            DataSet ds = new DataSet();
            ds = BLogic_Student_DashBoard.BAL_Student_Subject_Select(StudenDash);
            if (ds.Tables[0].Rows.Count > 0 && ds != null)
            {
                rbSubjectList.DataSource = ds.Tables[0];
                rbSubjectList.DataValueField = "SubjectID";
                rbSubjectList.DataTextField = "Subject";
                rbSubjectList.DataBind();
            }
        }
        catch (Exception ex)
        {

        }
    }
    # endregion
}