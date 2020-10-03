///<Summary>
///</Summary>

using System;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;

public partial class UserControl_NewTeacherPanel : System.Web.UI.UserControl
{
    #region Variables
    SYS_Role_BLogic obj_BAL_SYS_Role;

    //SYS_Role obj_SYS_Role;

    public event EventHandler TeacherPanelEvent;
    public event EventHandler TeacherPanelDDLEvent;

    #endregion

    # region Properties
    # endregion

    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        DataSet ds_BMS = new DataSet();
        DataSet ds_Subject = new DataSet();

        if (!IsPostBack)
        {
            ds_BMS = (DataSet)Session["ds_BMS"];
            ds_Subject = (DataSet)Session["subjectList"];

            ddlBoard.DataSource = ds_BMS.Tables[0];
            ddlBoard.DataTextField = "BMS";
            ddlBoard.DataValueField = "BMSID";
            ddlBoard.DataBind();
            ddlBoard.Items.Insert(((int)EnumFile.AssignValue.Zero), new ListItem("-- Select --"));

            if (ds_Subject != null)
            {
                ddlSubject.DataSource = ds_Subject.Tables[0];
                ddlSubject.DataTextField = "Subject";
                ddlSubject.DataValueField = "SubjectID";
                ddlSubject.DataBind();
                ddlSubject.Items.Insert(((int)EnumFile.AssignValue.Zero), new ListItem("-- Select --"));

                ddlDivision.DataSource = ds_BMS.Tables[2];
                ddlDivision.DataTextField = "Division";
                ddlDivision.DataValueField = "DivisionID";
                ddlDivision.DataBind();
                ddlDivision.Items.Insert(((int)EnumFile.AssignValue.Zero), new ListItem("-- Select --"));

                ddlBoard.SelectedValue = Convert.ToString(Session["BoardID"]);
                ddlSubject.SelectedValue = Convert.ToString(Session["SubjectID"]);
                ddlDivision.SelectedValue = Convert.ToString(Session["DivisionID"]);
                LblPageTitle.Text = ddlBoard.SelectedItem.Text + " >> " + ddlSubject.SelectedItem.Text + " >> " + ddlDivision.SelectedItem.Text;
                SessionName();
            }
        }
    }
    #endregion

    #region Control Events

    #region DropDown Events
    protected void ddlBoard_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlBoard.SelectedIndex > ((int)EnumFile.AssignValue.Zero))
        {
            DropDownList[] disddl = { ddlSubject, ddlDivision };
            DisableDropDwon(disddl);

            obj_BAL_SYS_Role = new SYS_Role_BLogic();
            //Int16 BoardID = Convert.ToInt16(ddlBoard.SelectedValue);
            Int64 BMSID = Convert.ToInt64(ddlBoard.SelectedValue);
            DataSet dsSelect = new DataSet();

            dsSelect = obj_BAL_SYS_Role.BAL_Allocated_Subject_Div_BasedonBMS(BMSID, Convert.ToInt64(Session["EmpolyeeID"]));

            if (dsSelect.Tables.Count > ((int)EnumFile.AssignValue.Zero) && dsSelect.Tables[0].Rows.Count > ((int)EnumFile.AssignValue.Zero))
            {
                ddlSubject.DataSource = dsSelect.Tables[0];
                ddlSubject.DataTextField = "Subject";
                ddlSubject.DataValueField = "SubjectID";
                ddlSubject.DataBind();
                ddlSubject.Items.Insert(((int)EnumFile.AssignValue.Zero), new ListItem("-- Select --"));

                ddlDivision.DataSource = dsSelect.Tables[1];
                ddlDivision.DataTextField = "Division";
                ddlDivision.DataValueField = "DivisionID";
                ddlDivision.DataBind();
                ddlDivision.Items.Insert(((int)EnumFile.AssignValue.Zero), new ListItem("-- Select --"));

                DropDownList[] disddl1 = { ddlSubject, ddlDivision };
                EnableDropDwon(disddl1);
            }
        }
        else
        {
            DropDownList[] disddl = { ddlSubject, ddlDivision };
            DisableDropDwon(disddl);
        }
    }
    #endregion

    #region Button Events
    protected void btnOk_Click(object sender, EventArgs e)
    {
        if (TeacherPanelEvent != null)
        {
            AppSessions.BoardID = int.Parse(ddlBoard.SelectedValue);
            AppSessions.Board = ddlBoard.SelectedItem.Text;
            AppSessions.SubjectID = int.Parse(ddlSubject.SelectedValue);
            AppSessions.Subject = ddlSubject.SelectedItem.Text;
            AppSessions.DivisionID = int.Parse(ddlDivision.SelectedValue);
            AppSessions.Division = ddlDivision.SelectedItem.Text;

            Session["BMSID"] = ddlBoard.SelectedValue;
            Session["SubjectID"] = ddlSubject.SelectedValue;
            Session["DivisionID"] = ddlDivision.SelectedValue;

            LblPageTitle.Text = ddlBoard.SelectedItem.Text + " >> " + ddlSubject.SelectedItem.Text + " >> " + ddlDivision.SelectedItem.Text;
            SessionName();

            HttpCookie myCookie = new HttpCookie(Convert.ToString(AppSessions.EmpolyeeID) + "TeacherDropDown");
            myCookie["BoardVal"] = ddlBoard.SelectedValue;
            myCookie["SubjectVal"] = ddlSubject.SelectedValue;
            myCookie["DivisionVal"] = ddlDivision.SelectedValue;
            myCookie.Expires = DateTime.Now.AddDays(7);
            Response.Cookies.Add(myCookie);

            obj_BAL_SYS_Role = new SYS_Role_BLogic();

            Session["subjectList"] = obj_BAL_SYS_Role.BAL_Allocated_Subject_Div_BasedonBMS(Convert.ToInt64(ddlBoard.SelectedValue), Convert.ToInt64(Session["EmpolyeeID"]));

            TrackLog_Utils.Log(Convert.ToInt32(AppSessions.SchoolID), Convert.ToInt32(AppSessions.EmpolyeeID), Convert.ToInt16(AppSessions.DivisionID), "TeacherPanel", "btnOk", "Click", Convert.ToDateTime(System.DateTime.Now), HttpContext.Current.Session.SessionID, StringEnum.stringValueOf(EnumFile.Activity.ActivityChanged), "BMS : " + AppSessions.Board + " , Division : " + AppSessions.Division + " , Subject : " + AppSessions.Subject + " , Teacher : " + AppSessions.UserName, 0);

            TeacherPanelEvent(sender, e);
        }
    }
    #endregion

    #endregion

    #region user Define Functions

    private void SessionName()
    {
        AppSessions.BMS = ddlBoard.SelectedItem.Text;
    }

    public void DisableDropDwon(DropDownList[] disddl)
    {
        foreach (DropDownList dl in disddl)
        {
            dl.Enabled = false;
            dl.SelectedIndex = Convert.ToInt32(EnumFile.AssignValue.Zero);
        }
    }

    public void EnableDropDwon(DropDownList[] disddl)
    {
        foreach (DropDownList dl in disddl)
        {
            dl.Enabled = true;
            dl.SelectedIndex = Convert.ToInt32(EnumFile.AssignValue.Zero);
        }
    }
    #endregion
}