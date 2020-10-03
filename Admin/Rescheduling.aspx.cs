///<Summary>
///</Summary>
using System;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
using Udev.UserMasterPage.Classes;
using System.Globalization;

public partial class Admin_Rescheduling : System.Web.UI.Page
{
    #region "Variables"
    SYS_Rescheduling Prop_SYS_Rescheduling = new SYS_Rescheduling();
    SYS_Rescheduling_BLogic BLogic_SYS_Rescheduling = new SYS_Rescheduling_BLogic();
    Employee_BLogic EmployeeBlogic;
    #endregion

    #region "Properties"
    #endregion

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
        if (Request["ID"] != null)
        {
            ViewState["ID"] = Request["ID"].ToString();
        }

        BindGridAttandance();
    }
    #endregion

    #region "Control Events"

    #region Gridview Events

    protected ArrayList GenerateEmailAddress(Int64 EmployeeID)
    {
        ArrayList AlistEmailID = new ArrayList();
        DataSet dsEmail = new DataSet();
        EmployeeBlogic = new Employee_BLogic();
        try
        {
            dsEmail = EmployeeBlogic.SelectEmployeeDetailByEmployeeID(EmployeeID);
            if (dsEmail != null & dsEmail.Tables.Count > 0)
            {
                if (dsEmail.Tables[0].Rows.Count > 0)
                {
                    AlistEmailID.Add(dsEmail.Tables[0].Rows[0]["EmailID"].ToString());
                    ViewState["TempEmp"] = dsEmail.Tables[0].Rows[0]["FirstName"].ToString();
                }
            }

        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
        return AlistEmailID;
    }

    protected string GenerateEmailBody(string Subject, string Standard, string Division, string Chapter, string Topic, string Validity)
    {
        string Body = string.Empty;
        try
        {
            Body = "<b>Hello " + ViewState["TempEmp"].ToString() + ",<b/><br/><br/>";
            Body += "<table border='1' width='100%'>";
            Body += "<tr><td colspan='6' align='center'><b>Rescheduling request approved<b/></td></tr>";
            Body += "<tr><th>Subject</th><th>Standard</th><th>Division</th><th>Chapter</th><th>Topic</th><th>Valid Till</th>";
            Body += "<tr><td>" + Subject + "</td><td>" + Standard + "</td><td>" + Division + "Division</td><td>" + Chapter + "</td><td>" + Topic + "</td><td>" + Validity + "</td>";
            Body += "</table><br/>";
            Body += "<a href='" + Session["LoginURL"].ToString() + "'>Please click here to login.<a/><br/><br/>";
            Body += "<b>Regards,<b/><br/>";
            Body += "<b>" + EmailUtility.USERNAME + "<b/>";
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
        return Body;
    }

    protected void grdRescheduling_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Approve")
        {
            LinkButton lb = (LinkButton)e.CommandSource;
            GridViewRow gvr = (GridViewRow)lb.NamingContainer;
            Int64 BMSSCTID = Convert.ToInt64(grdRescheduling.DataKeys[gvr.RowIndex].Values["BMSSCTID"].ToString());
            Int64 ReSchedulingID = Convert.ToInt64(grdRescheduling.DataKeys[gvr.RowIndex].Values["ReSchedulingID"].ToString());
            Int64 EmployeeID = Convert.ToInt64(grdRescheduling.DataKeys[gvr.RowIndex].Values["EmployeeID"].ToString());
            TextBox txt1 = (TextBox)grdRescheduling.Rows[gvr.RowIndex].Cells[8].FindControl("txtStartDate");
            DateTime StartDate = DateTime.ParseExact(txt1.Text, "dd-MM-yyyy", null);
            TextBox txt2 = (TextBox)grdRescheduling.Rows[gvr.RowIndex].Cells[9].FindControl("txtEndDate");
            DateTime EndDate = DateTime.ParseExact(txt2.Text, "dd-MM-yyyy", null);
            string Subject = grdRescheduling.DataKeys[gvr.RowIndex].Values["Subject"].ToString();
            string Standard = grdRescheduling.DataKeys[gvr.RowIndex].Values["Standard"].ToString();
            string Division = grdRescheduling.DataKeys[gvr.RowIndex].Values["Division"].ToString();
            string Chapter = grdRescheduling.DataKeys[gvr.RowIndex].Values["Chapter"].ToString();
            string Topic = grdRescheduling.DataKeys[gvr.RowIndex].Values["Topic"].ToString();

            ArrayList alistEmailAddress = GenerateEmailAddress(EmployeeID);
            if (alistEmailAddress.Count > 0)
            {
                string Body = GenerateEmailBody(Subject, Standard, Division, Chapter, Topic, EndDate.ToString("dd-MMM-yyyy"));
                EmailUtility.SendEmail(alistEmailAddress, "Rescheduling request Approval", Body);
            }
            if (IsValidDates(StartDate, EndDate))
            {
                BLogic_SYS_Rescheduling = new SYS_Rescheduling_BLogic();
                Prop_SYS_Rescheduling = new SYS_Rescheduling();
                Prop_SYS_Rescheduling.ReSchedulingID = ReSchedulingID;
                Prop_SYS_Rescheduling.BMSSCTID = BMSSCTID;
                Prop_SYS_Rescheduling.EmployeeID = EmployeeID;
                Prop_SYS_Rescheduling.StartDate = StartDate;
                Prop_SYS_Rescheduling.EndDate = EndDate;

                BLogic_SYS_Rescheduling.BAL_SYS_Rescheduling_Update(Prop_SYS_Rescheduling);
                ViewState["ID"] = null;
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
        if (ViewState["ID"] != null)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridViewRow gr = e.Row;
                Label lb = (Label)gr.FindControl("lblReschedulingID");
                if (lb.Text == ViewState["ID"].ToString())
                {
                    e.Row.BackColor = System.Drawing.Color.Aqua;
                }
            }
        }

        if (grdRescheduling.Rows.Count > 0)
        {
            for (int i = 0; i < grdRescheduling.Rows.Count; i++)
            {
                TextBox txt1 = (TextBox)grdRescheduling.Rows[i].Cells[8].FindControl("txtStartDate");
                txt1.Text = System.DateTime.Now.ToString("dd-MM-yyyy");
                TextBox txt2 = (TextBox)grdRescheduling.Rows[i].Cells[9].FindControl("txtEndDate");
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
        ds1 = BLogic_SYS_Rescheduling.BAL_SYS_Rescheduling_Details(Prop_SYS_Rescheduling, "");
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