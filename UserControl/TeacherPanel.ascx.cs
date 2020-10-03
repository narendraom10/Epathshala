///<Summary>
///</Summary>

using System;
using System.Data;
using System.Web.UI.WebControls;

public partial class UserControl_TeacherPanel : System.Web.UI.UserControl
{
    # region Variables
    SYS_Role_BLogic obj_BAL_SYS_Role;
    SYS_Role obj_SYS_Role;
    # endregion

    # region Properties
    # endregion

    # region Page events
    protected void Page_Load(object sender, EventArgs e)
    {
        DataSet ds_BMS = new DataSet();

        if (!IsPostBack)
        {
            //DropDownList[] disddl = { ddlMedium, ddlStandard, ddlSubject, ddlDivision };
            //DisableDropDwon(disddl);

            ds_BMS = (DataSet)Session["ds_BMS"];

            ddlBoard.DataSource = ds_BMS.Tables[0];
            ddlBoard.DataTextField = "Board";
            ddlBoard.DataValueField = "BoardID";
            ddlBoard.DataBind();
            ddlBoard.Items.Insert(((int)EnumFile.AssignValue.Zero), new ListItem("-- Select --"));

            ddlMedium.DataSource = ds_BMS.Tables[1];
            ddlMedium.DataTextField = "Medium";
            ddlMedium.DataValueField = "MediumID";
            ddlMedium.DataBind();
            ddlMedium.Items.Insert(((int)EnumFile.AssignValue.Zero), new ListItem("-- Select --"));

            ddlStandard.DataSource = ds_BMS.Tables[2];
            ddlStandard.DataTextField = "Standard";
            ddlStandard.DataValueField = "StandardID";
            ddlStandard.DataBind();
            ddlStandard.Items.Insert(((int)EnumFile.AssignValue.Zero), new ListItem("-- Select --"));


            ddlSubject.DataSource = ds_BMS.Tables[3];
            ddlSubject.DataTextField = "Subject";
            ddlSubject.DataValueField = "SubjectID";
            ddlSubject.DataBind();
            ddlSubject.Items.Insert(((int)EnumFile.AssignValue.Zero), new ListItem("-- Select --"));

            ddlDivision.DataSource = ds_BMS.Tables[4];
            ddlDivision.DataTextField = "Division";
            ddlDivision.DataValueField = "DivisionID";
            ddlDivision.DataBind();
            ddlDivision.Items.Insert(((int)EnumFile.AssignValue.Zero), new ListItem("-- Select --"));

            ddlBoard.SelectedValue = Convert.ToString(Session["BoardID"]);
            ddlMedium.SelectedValue = Convert.ToString(Session["MediumID"]);
            ddlStandard.SelectedValue = Convert.ToString(Session["StandardID"]);
            ddlSubject.SelectedValue = Convert.ToString(Session["SubjectID"]);
            ddlDivision.SelectedValue = Convert.ToString(Session["DivisionID"]);

            SessionName();
        }
    }
    # endregion

    # region Control events
    protected void btnOk_Click(object sender, EventArgs e)
    {
        if (TeacherPanelEvent != null)
        {
            Session["BoardID"] = ddlBoard.SelectedValue;
            Session["MediumID"] = ddlMedium.SelectedValue;
            Session["StandardID"] = ddlStandard.SelectedValue;
            Session["SubjectID"] = ddlSubject.SelectedValue;
            Session["DivisionID"] = ddlDivision.SelectedValue;

            SessionName();

            //TeacherPanelEvent.Invoke(this, new EventArgs());
            TeacherPanelEvent(sender, e);
        }
    }

    protected void ddlStandard_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlBoard.SelectedIndex > Convert.ToInt32(EnumFile.AssignValue.Zero) && ddlMedium.SelectedIndex > Convert.ToInt32(EnumFile.AssignValue.Zero) && ddlStandard.SelectedIndex > Convert.ToInt32(EnumFile.AssignValue.Zero))
        {
            DropDownList[] disddl = { ddlSubject, ddlDivision };
            DisableDropDwon(disddl);

            obj_BAL_SYS_Role = new SYS_Role_BLogic();

            Int16 BoardID = Convert.ToInt16(ddlBoard.SelectedValue);
            Int16 MediumID = Convert.ToInt16(ddlMedium.SelectedValue);
            Int16 StandardID = Convert.ToInt16(ddlStandard.SelectedValue);
            Int64 EmpID = Convert.ToInt64(Session["EmpolyeeID"]);

            DataSet dsSelect = new DataSet();

            dsSelect = obj_BAL_SYS_Role.BAL_Allocated_Subject_Div(BoardID, MediumID, StandardID, EmpID);

            if (dsSelect.Tables.Count > Convert.ToInt32(EnumFile.AssignValue.Zero) && dsSelect.Tables[0].Rows.Count > Convert.ToInt32(EnumFile.AssignValue.Zero))
            {

                ddlSubject.DataSource = dsSelect.Tables[0];
                ddlSubject.DataTextField = "Subject";
                ddlSubject.DataValueField = "SubjectID";
                ddlSubject.DataBind();
                ddlSubject.Items.Insert(Convert.ToInt32(EnumFile.AssignValue.Zero), new ListItem("-- Select --"));

                ddlDivision.DataSource = dsSelect.Tables[1];
                ddlDivision.DataTextField = "Division";
                ddlDivision.DataValueField = "DivisionID";
                ddlDivision.DataBind();
                ddlDivision.Items.Insert(Convert.ToInt32(EnumFile.AssignValue.Zero), new ListItem("-- Select --"));

                Session["BMSID"] = dsSelect.Tables[2].Rows[0]["BMSID"].ToString();

                DropDownList[] disddl1 = { ddlSubject, ddlDivision };
                EnableDropDwon(disddl1);

            }
            else
            {
                DropDownList[] disddl2 = { ddlSubject, ddlDivision };
                DisableDropDwon(disddl2);
            }
        }
        else
        {
            DropDownList[] disddl = { ddlSubject, ddlDivision };
            DisableDropDwon(disddl);
        }

    }

    protected void ddlBoard_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (ddlBoard.SelectedIndex > ((int)EnumFile.AssignValue.Zero))
        {

            DropDownList[] disddl = { ddlMedium, ddlStandard, ddlSubject, ddlDivision };
            DisableDropDwon(disddl);

            obj_BAL_SYS_Role = new SYS_Role_BLogic();
            Int16 BoardID = Convert.ToInt16(ddlBoard.SelectedValue);
            DataSet dsSelect = new DataSet();

            dsSelect = obj_BAL_SYS_Role.BAL_Select_Medium(BoardID);
            if (dsSelect.Tables.Count > ((int)EnumFile.AssignValue.Zero) && dsSelect.Tables[0].Rows.Count > ((int)EnumFile.AssignValue.Zero))
            {
                ddlMedium.DataSource = dsSelect.Tables[0];
                ddlMedium.DataTextField = "Medium";
                ddlMedium.DataValueField = "MediumID";
                ddlMedium.DataBind();
                ddlMedium.Items.Insert(((int)EnumFile.AssignValue.Zero), new ListItem("-- Select --"));

                DropDownList[] disddl1 = { ddlMedium };
                EnableDropDwon(disddl1);
            }
        }
        else
        {
            DropDownList[] disddl = { ddlMedium, ddlStandard, ddlSubject, ddlDivision };
            DisableDropDwon(disddl);
        }
    }

    protected void ddlMedium_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlMedium.SelectedIndex > ((int)EnumFile.AssignValue.Zero))
        {
            DropDownList[] disddl = { ddlStandard, ddlSubject, ddlDivision };
            DisableDropDwon(disddl);

            obj_BAL_SYS_Role = new SYS_Role_BLogic();
            Int16 BoardID = Convert.ToInt16(ddlBoard.SelectedValue);
            Int16 MediumID = Convert.ToInt16(ddlMedium.SelectedValue);
            Int64 EmpID = Convert.ToInt64(Session["EmpolyeeID"]);

            DataSet dsSelect = new DataSet();

            dsSelect = obj_BAL_SYS_Role.BAL_Select_Standard(BoardID, MediumID, EmpID);

            if (dsSelect.Tables.Count > ((int)EnumFile.AssignValue.Zero) && dsSelect.Tables[0].Rows.Count > ((int)EnumFile.AssignValue.Zero))
            {
                ddlStandard.DataSource = dsSelect.Tables[0];
                ddlStandard.DataTextField = "Standard";
                ddlStandard.DataValueField = "StandardID";
                ddlStandard.DataBind();
                ddlStandard.Items.Insert(((int)EnumFile.AssignValue.Zero), new ListItem("-- Select --"));

                DropDownList[] disddl1 = { ddlStandard };
                EnableDropDwon(disddl1);
            }
        }
        else
        {
            DropDownList[] disddl = { ddlStandard, ddlSubject, ddlDivision };
            DisableDropDwon(disddl);
        }
    }
    # endregion

    #region user Define Functions

    //public delegate void TeacherPan(object sender, EventArgs e);
    //public event EventHandler TeacherPan TeacherPanelEvent;
    public event EventHandler TeacherPanelEvent;

    private void SessionName()
    {
        AppSessions.BMS = ddlBoard.SelectedItem.Text + " >> " + ddlMedium.SelectedItem.Text + " >> " + ddlStandard.SelectedItem.Text + " >> " + ddlSubject.SelectedItem.Text + " >> " + ddlDivision.SelectedItem.Text;
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