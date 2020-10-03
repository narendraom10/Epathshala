using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Teacher_SubjectWiseTestStepOne : System.Web.UI.Page
{
    #region variable

    Teacher_Dashboard_BLogic obj_BAL_Teacher_Dashboard;
    Teacher_Dashboard obj_Teacher_Dashboard;

    #endregion

    #region Page events

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            btnsearcksubmit.Enabled = false;
            lblBMS.Text = AppSessions.BMS;
            lblsubject.Text = AppSessions.Subject;
            lbldivision.Text = AppSessions.Division;
            lblBMSID.Text = Convert.ToString(Session["BMSID"]);
            lblsubjectID.Text = Convert.ToString(Session["SubjectID"]);
            lbldivisionID.Text = Convert.ToString(Session["DivisionID"]);
        }
    }

    #endregion

    #region Control Event
    
    protected void ddlselectoption_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(ddlselectoption.SelectedItem.Value))
        {
            obj_BAL_Teacher_Dashboard = new Teacher_Dashboard_BLogic();
            obj_Teacher_Dashboard = new Teacher_Dashboard();

            obj_Teacher_Dashboard.BMSID = Convert.ToInt64(Session["BMSID"]);
            obj_Teacher_Dashboard.SubjectID = Convert.ToInt16(Session["SubjectID"]);
            obj_Teacher_Dashboard.EmployeeID = AppSessions.EmpolyeeID;

            DataSet dsSelect = new DataSet();
            dsSelect = obj_BAL_Teacher_Dashboard.BAL_Select_Chapters_Topics_By_CoveredStatus(obj_Teacher_Dashboard, ddlselectoption.SelectedItem.Value);

            GVChapter.DataSource = dsSelect.Tables[0];
            GVChapter.DataBind();

            if (dsSelect.Tables[0].Rows.Count > 0)
                btnsearcksubmit.Enabled = true;
            else
                btnsearcksubmit.Enabled = false;
        }
        else
        {
            GVChapter.DataSource = null;
            GVChapter.DataBind();
            btnsearcksubmit.Enabled = false;
        }
    }
    protected void btnsearcksubmit_Click(object sender, EventArgs e)
    {
        obj_BAL_Teacher_Dashboard = new Teacher_Dashboard_BLogic();
        string strBMSSCTID = string.Empty;
        foreach (GridViewRow row in GVChapter.Rows)
        {
            CheckBox chk = (CheckBox)row.FindControl("chkSelect");
            if (chk.Checked)
            {
                HiddenField hdn = (HiddenField)row.FindControl("hdnBMSSCTID");
                strBMSSCTID += hdn.Value + ",";
            }
        }
        if (strBMSSCTID.Length > 1)
        {
            strBMSSCTID = strBMSSCTID.Substring(0, strBMSSCTID.Length - 1);
            SetFirstBMSSCTIDInSession(strBMSSCTID);
            if (!string.IsNullOrEmpty(strBMSSCTID))
                Response.Redirect("SubjectWiseTestStepTwo.aspx?rdu=" + HttpUtility.UrlEncode("../Teacher/TeacherAssessment.aspx?Level=0&TestType=Posttest&BMSSCTID=" + strBMSSCTID + "&noq=" + txtNumQue.Text.Trim() + "") + "");
        }
    }
    protected void GVChapter_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label oLable = (Label)e.Row.FindControl("GV_Lbltq");
            if (Convert.ToInt32(oLable.Text) == 0)
                e.Row.Enabled = false;
        }
    }

    #endregion

    #region User defined functions

    private void SetFirstBMSSCTIDInSession(string strBMSSCTID)
    {
        string[] BMSSCTIIDlist = strBMSSCTID.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
        Session["BMSSCTID"] = BMSSCTIIDlist[0];
        Session["BMSSCTIIDlist"] = strBMSSCTID;
    }

    #endregion
}