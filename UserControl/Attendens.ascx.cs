///<Summary>
///</Summary>

using System;
using System.Data;

public partial class Attendens : System.Web.UI.UserControl
{
    # region Variables
    SYS_Attendance_BLogic BAttendance = new SYS_Attendance_BLogic();
    SYS_Attendance PSysAttendance = new SYS_Attendance();
    # endregion

    # region Properties
    # endregion

    # region Page events
    protected void Page_Load(object sender, EventArgs e)
    {
        DataSet ds_BMS = new DataSet();

        if (!IsPostBack)
        {
            SYS_Board PBoard = new SYS_Board();
            SYS_Board_BLogic BLBoard = new SYS_Board_BLogic();
            DataSet dsBoards = new DataSet();
            PBoard.boardid = Convert.ToInt32(EnumFile.AssignValue.Zero);
            dsBoards = BLBoard.BAL_SYS_Board_Select(PBoard, "Select");
            ddlBoard.DataSource = dsBoards;
            ddlBoard.DataTextField = dsBoards.Tables[0].Columns["Board"].ToString();
            ddlBoard.DataValueField = dsBoards.Tables[0].Columns["BoardID"].ToString();
            ddlBoard.DataBind();
            ddlBoard.Items.Insert(Convert.ToInt32(EnumFile.AssignValue.Zero), "-- Select --");
            ddlBoard.Items[0].Value = Convert.ToString((int)EnumFile.AssignValue.Zero);
        }
    }
    # endregion

    # region Control events
    
    protected void btnOk_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        PSysAttendance.BoardID = int.Parse(ddlBoard.SelectedValue);
        ds = BAttendance.BAL_SYS_Attendance_SchoolAdmin(PSysAttendance, "");
        gvAttandance.DataSource = ds;
        gvAttandance.DataBind();
    }
    
    # endregion

    # region User defined function
    # endregion
}