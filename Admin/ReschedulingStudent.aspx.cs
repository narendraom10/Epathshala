///<Summary>
///</Summary>

using System;
using System.Web.UI.WebControls;
using System.Data;
using Udev.UserMasterPage.Classes;
using System.Globalization;

public partial class Admin_ReschedulingStudent : System.Web.UI.Page
{
    #region "Variables"
    SYS_Rescheduling Prop_SYS_Rescheduling = new SYS_Rescheduling();
    SYS_Rescheduling_BLogic BLogic_SYS_Rescheduling = new SYS_Rescheduling_BLogic();
    #endregion

    # region "Properties"
    # endregion

    #region "Page Event"

    protected override void InitializeCulture()
    {
        string culture = Convert.ToString(Session[Global.SESSION_KEY_CULTURE]);
        //// 'set culture to current thread 
        System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture);
        System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);
        ////call base class 
        base.InitializeCulture();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        BindGridAttandance();
    }
    #endregion

    #region "Control Events"

    #region Gridview Events

    protected void grdRescheduling_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Approve")
        {
            LinkButton lb = (LinkButton)e.CommandSource;
            GridViewRow gvr = (GridViewRow)lb.NamingContainer;
            Int64 BMSSCTID = Convert.ToInt64(grdRescheduling.DataKeys[gvr.RowIndex].Values["BMSSCTID"].ToString());
            Int64 SReSchedulingID = Convert.ToInt64(grdRescheduling.DataKeys[gvr.RowIndex].Values["SReSchedulingID"].ToString());
            Int64 StudentID = Convert.ToInt64(grdRescheduling.DataKeys[gvr.RowIndex].Values["StudentID"].ToString());
            TextBox txt1 = (TextBox)grdRescheduling.Rows[gvr.RowIndex].Cells[7].FindControl("txtStartDate");
            DateTime StartDate = DateTime.ParseExact(txt1.Text, "dd-MM-yyyy", null);
            TextBox txt2 = (TextBox)grdRescheduling.Rows[gvr.RowIndex].Cells[8].FindControl("txtEndDate");
            DateTime EndDate = DateTime.ParseExact(txt2.Text, "dd-MM-yyyy", null);
            if (IsValidDates(StartDate, EndDate))
            {
                BLogic_SYS_Rescheduling = new SYS_Rescheduling_BLogic();
                Prop_SYS_Rescheduling = new SYS_Rescheduling();
                Prop_SYS_Rescheduling.SReSchedulingID = SReSchedulingID;
                Prop_SYS_Rescheduling.BMSSCTID = BMSSCTID;
                Prop_SYS_Rescheduling.StudentID = StudentID;
                Prop_SYS_Rescheduling.StartDate = StartDate;
                Prop_SYS_Rescheduling.EndDate = EndDate;

                BLogic_SYS_Rescheduling.BAL_SYS_Rescheduling_Update_Student(Prop_SYS_Rescheduling);
                BindGridAttandance();
            }
            else
            {
                WebMsg.Show("2 Days Difference is must");
            }
        }
    }

    protected void grdRescheduling_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (grdRescheduling.Rows.Count > 0)
        {
            for (int i = 0; i < grdRescheduling.Rows.Count; i++)
            {
                TextBox txt1 = (TextBox)grdRescheduling.Rows[i].Cells[7].FindControl("txtStartDate");
                txt1.Text = System.DateTime.Now.ToString("dd-MM-yyyy");
                TextBox txt2 = (TextBox)grdRescheduling.Rows[i].Cells[8].FindControl("txtEndDate");
                txt2.Text = System.DateTime.Now.AddDays(2).ToString("dd-MM-yyyy");
            }
        }
    }

    #endregion

    #endregion

    #region "User Define Functions"
    private void BindGridAttandance()
    {
        DataSet ds1 = new DataSet();
        ds1 = BLogic_SYS_Rescheduling.BAL_SYS_Rescheduling_Details_Student(Prop_SYS_Rescheduling, "");
        grdRescheduling.DataSource = ds1;
        grdRescheduling.DataBind();
    }

    public bool IsValidDates(DateTime SD, DateTime ED)
    {
        TimeSpan t = ED - SD;
        double NrOfDays = t.TotalDays;
        bool result = false;
        if (NrOfDays >= 2)
        {
            result = true;
        }
        else
        {
            result = false;
            
        }
        return result;
    }

    #endregion
}