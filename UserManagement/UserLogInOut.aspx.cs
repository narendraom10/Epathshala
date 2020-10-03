/// <summary> 
/// <Description>FOR VIEW USER LOGIN </Description>
/// <DevelopedBy>"NARENDRASINH"</DevelopedBy>
/// <DevelopedDate></DevelopedDate>
/// <UpdatedBy>"NARENDRASINH"</UpdatedBy>
/// <UpdatedDate></UpdatedDate>
/// </summary>

using System;
using System.Collections;
using System.Data;
using System.Globalization;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using Udev.UserMasterPage.Classes;

public partial class UserManagement_UserLogInOut : System.Web.UI.Page
{
    # region Variables
    # endregion

    # region Properties
    # endregion

    # region Page events
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ibtnLogout.Attributes.Add("onclick", "if(confirm('Are you sure to logout user?')){}else{return false}");
            ConvertHastTableToDataTable();
        }

    }
    # endregion

    # region Control events
    protected void ibtnRefresh_Click(object sender, ImageClickEventArgs e)
    {
        ConvertHastTableToDataTable();
    }
    protected void btnSearchReset_Click(object sender, EventArgs e)
    {
        txtEmployeeName.Text = string.Empty;
        txtUserID.Text = string.Empty;
    }
    protected void ibtnLogout_Click(object sender, ImageClickEventArgs e)
    {
        foreach (GridViewRow gr in gvLogInOutDetails.Rows)
        {
            CheckBox chk = new CheckBox();
            chk = (CheckBox)gr.FindControl("chkSelect");
            if (chk.Checked == true)
            {
                string empID = gvLogInOutDetails.DataKeys[gr.RowIndex]["EmployeeID"].ToString();
                Hashtable sessions = (Hashtable)Application["WEB_SESSIONS_OBJECT"];
                if (sessions == null)
                {
                    sessions = new Hashtable();
                }
                HttpSessionState existingUserSession = (HttpSessionState)sessions[empID];
                sessions.Remove(empID);
                if (existingUserSession != null)
                {
                    existingUserSession = null;
                }


                // Application.Lock();
                //Application["WEB_SESSIONS_OBJECT"] = null;

                //Application.UnLock();

                //Session["temp"] = "sanganvateacher";
                //Session["temp"] = null;

            }
        }
        ConvertHastTableToDataTable();
    }
    protected void btnGo_Click(object sender, EventArgs e)
    {
        ConvertHastTableToDataTable();
    }
    #endregion

    # region User deined functions
    protected override void InitializeCulture()
    {
        string culture = Convert.ToString(Session[Global.SESSION_KEY_CULTURE]);
        // 'set culture to current thread 
        System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture);
        System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);
        //call base class 
        base.InitializeCulture();
    }
    private void ConvertHastTableToDataTable()
    {
        try
        {
            Hashtable hashtable = (Hashtable)Application["WEB_SESSIONS_OBJECT"];
            if (hashtable != null)
            {

                var dataTable = new DataTable(hashtable.GetType().Name);
                dataTable.Columns.Add("EmployeeID", typeof(object));
                IDictionaryEnumerator enumerator = hashtable.GetEnumerator();
                string strEmpID = string.Empty;
                while (enumerator.MoveNext())
                {
                    dataTable.Rows.Add(enumerator.Key);
                    if (strEmpID == string.Empty)
                    {
                        strEmpID = enumerator.Key.ToString();
                    }
                    else
                    {
                        strEmpID = strEmpID + ',' + enumerator.Key.ToString();
                    }
                }
                if (strEmpID != "")
                {
                    Employee_BLogic Employee = new Employee_BLogic();
                    DataSet dsEmployee = new DataSet();
                    dsEmployee = Employee.BAL_Employee_SelectBySchoolID(Convert.ToInt32(Session["SchoolID"].ToString()), "");
                    if (Convert.ToInt32(Session["SchoolID"].ToString()) == 13)
                    {
                        dsEmployee = Employee.BAL_Employee_SelectByStatus();
                    }
                    else
                    {
                        dsEmployee = Employee.BAL_Employee_SelectBySchoolID(Convert.ToInt32(Session["SchoolID"].ToString()), "");
                    }
                    DataView dv;
                    if (dsEmployee.Tables.Count > ((int)EnumFile.AssignValue.Zero))
                    {
                        dv = new DataView(dsEmployee.Tables[0]);

                        dv.RowFilter = "EmployeeID in(" + strEmpID + ") and LoginID like '%" + txtUserID.Text + "%' and employeeName like '%" + txtEmployeeName.Text + "%'";

                        DataTable dtempdetails = dv.ToTable();
                        gvLogInOutDetails.DataSource = dtempdetails;
                        gvLogInOutDetails.DataBind();
                    }
                }
                else
                {
                    gvLogInOutDetails.DataSource = null;
                    gvLogInOutDetails.DataBind();
                }
            }
            else
            {
                gvLogInOutDetails.DataSource = null;
                gvLogInOutDetails.DataBind();
            }
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
            Response.Redirect("..\\Default.aspx");
        }

    }
    # endregion
}