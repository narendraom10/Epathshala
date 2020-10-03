///<Summary>
///</Summary>

using System;
using System.Web.UI.WebControls;
using System.Data;

public partial class UserControl_ClassRoomWiseActivityRPT : System.Web.UI.UserControl
{
    #region Variables
    School_BLogic SchoolBLogic;
    #endregion

    # region Properties
    # endregion

    #region "Page events"
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
             BindAllDDLSchool();
        }
    }
    #endregion

    #region "User defined functions"

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
    #endregion

    #region "Control Events"

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
        ViewState["SchoolID"] = ddlSchool.SelectedValue;
        Session["SchoolNameReport"] = ddlSchool.SelectedItem.Text;
        Session["BoardReport"] = ddlBoard.SelectedItem.Text;
        Session["MediumReport"] = ddlMedium.SelectedItem.Text;

    }

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

    
    #endregion

 }