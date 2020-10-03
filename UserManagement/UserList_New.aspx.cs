/// <DevelopedBy>"Arpit Patel"</DevelopedBy>
/// </summary>

using System;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web.UI.WebControls;
using Udev.UserMasterPage.Classes;
using System.Web.UI;
using System.Web;

public partial class UserManage_UserList : System.Web.UI.Page
{
    #region "Declarations"
    UserList_BLogic BUserList = new UserList_BLogic();
    UserList PUserList = new UserList();
    DropDownFill DFill = new DropDownFill();
    SYS_Role_BLogic BSysRole = new SYS_Role_BLogic();
    SYS_Role PSysRole = new SYS_Role();
    SYS_Standard_BLogic BSysStandard = new SYS_Standard_BLogic();
    SYS_Standard PSysStandard = new SYS_Standard();
    School_BLogic BSchool = new School_BLogic();
    Employee_BLogic BEmployee = new Employee_BLogic();
    Employee PEmployee = new Employee();
    CheckBoxFill Cfill;
    int EmployeeID = 0;
    string GridCondition = string.Empty;
    #endregion

    #region "Properties"
    string SortDirection
    {
        get
        {
            object o = this.ViewState["SortDirection"];
            if (o == null)
            {
                return string.Empty;
            }
            else
            {
                return (string)o;
            }
        }

        set
        {
            this.ViewState["SortDirection"] = value;
        }
    }

    string SortField
    {
        get
        {
            object o = this.ViewState["SortField"];
            if (o == null)
            {
                return string.Empty;
            }
            else
            {
                return (string)o;
            }
        }

        set
        {
            this.ViewState["SortField"] = value;
        }
    }

    #endregion

    #region "Page Events"

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
        try
        {
            if (!this.IsPostBack)
            {
                PnlSearch.Visible = true;
                BindSchoolDropDown();
                this.ViewState["UserRoleID"] = AppSessions.RoleID;
                if (Request.QueryString["SchoolID"] != "0" & Request.QueryString["SchoolID"] != null)
                {
                    this.ViewState["SchoolID"] = Request.QueryString["SchoolID"];
                }
                else
                {
                    this.ViewState["SchoolID"] = AppSessions.SchoolID;
                }

                LtSchoolID.Text = this.ViewState["SchoolID"].ToString();
                this.ViewState["SchoolName"] = AppSessions.SchoolName;
                
                if (this.ViewState["UserRoleID"].ToString() == "1")
                {
                    ddlSchool.Enabled = true;
                }
                else
                {
                    ddlSchool.SelectedValue = Convert.ToString(this.ViewState["SchoolID"]);
                }
                if (this.ViewState["UserRoleID"].ToString() == "1" || this.ViewState["UserRoleID"].ToString() == "2")
                {
                    ibtnAdd.Visible = true;
                    ibtnEdit.Visible = true;
                }
                this.EmployeeID = AppSessions.EmpolyeeID;
                this.ViewState["EmployeeID"] = this.EmployeeID;

                if (AppSessions.BoardID != 0)
                {
                    this.ViewState["BoardID"] = AppSessions.BoardID;
                }

                if (AppSessions.MediumID != 0)
                {
                    this.ViewState["MediumID"] = AppSessions.MediumID;
                }

                this.BindRoles(int.Parse(this.ViewState["UserRoleID"].ToString()));
                this.ViewState["GridCondition"] = this.GridCondition;
                this.BindGridData();

            }
        }
        catch (Exception Ex)
        {
            WebMsg.Show(Ex.Message);
        }
    }

    #endregion

    #region "Controls Events"

    protected void DdlRole_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            if (DdlRole.SelectedValue != Convert.ToString((int)EnumFile.Role.Zero))
            {
                if (DdlRole.SelectedValue != Convert.ToString((int)EnumFile.Role.S_Admin))
                {
                    this.BindStandards();
                    DdlStandard.Enabled = true;
                    DdlDivision.Items.Clear();
                    DdlDivision.Items.Insert(0, "-- Select --");
                    DdlDivision.Items[0].Value = Convert.ToString((int)EnumFile.AssignValue.Zero);
                    DdlDivision.Enabled = false;
                }
                else if (DdlRole.SelectedValue == Convert.ToString((int)EnumFile.Role.S_Admin))
                {
                    DdlStandard.Enabled = false;
                    DdlDivision.Enabled = false;
                }
            }
            else if (DdlRole.SelectedValue == Convert.ToString((int)EnumFile.AssignValue.Zero))
            {
                DdlStandard.Items.Clear();
                DdlStandard.Items.Insert((int)EnumFile.AssignValue.Zero, "-- Select --");
                DdlStandard.Items[0].Value = Convert.ToString((int)EnumFile.AssignValue.Zero);
                DdlStandard.Enabled = false;

                DdlDivision.Items.Clear();
                DdlDivision.Items.Insert((int)EnumFile.AssignValue.Zero, "-- Select --");
                DdlDivision.Items[0].Value = Convert.ToString((int)EnumFile.AssignValue.Zero);
                DdlDivision.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }

    protected void DdlStandard_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (DdlStandard.SelectedValue != Convert.ToString((int)EnumFile.AssignValue.Zero))
            {
                this.Cfill = new CheckBoxFill();
                DdlDivision.Items.Clear();
                if (int.Parse(ViewState["UserRoleID"].ToString()) == 1)
                {
                    this.DFill.BindDropDownByDynamic(this.DdlDivision, "SYS_Division", "Division", "DivisionID", string.Empty);
                }
                else
                {
                    this.Cfill.FillDivisionBySchoolBMSID(this.DdlDivision, int.Parse(ViewState["SchoolID"].ToString()));
                }

                DdlDivision.Items.Insert((int)EnumFile.AssignValue.Zero, "-- Select --");
                DdlDivision.Items[0].Value = Convert.ToString((int)EnumFile.AssignValue.Zero);
                DdlDivision.Enabled = true;
            }
            else if (DdlStandard.SelectedValue == Convert.ToString((int)EnumFile.AssignValue.Zero))
            {
                DdlDivision.Items.Clear();
                DdlDivision.Items.Insert((int)EnumFile.AssignValue.Zero, "-- Select --");
                DdlDivision.Items[0].Value = Convert.ToString((int)EnumFile.AssignValue.Zero);
                DdlDivision.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }

    protected void BtnGo_Click(object sender, EventArgs e)
    {
        try
        {
            this.GvUserList.DataSource = null;
            this.GvUserList.DataBind();

            this.GridCondition = this.CreateGridCondition();
            this.ViewState["GridCondition"] = this.GridCondition;
            this.BindGridData();
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }

    protected void ImgBtnActivate_Click(object sender, System.Web.UI.ImageClickEventArgs e)
    {
        try
        {
            int Count = 0;

            if (PnlActivateDeactivate.Visible == true)
            {
                PnlActivateDeactivate.Visible = false;
                PnlSearch.Visible = true;
                PnlResetPassword.Visible = false;
            }
            else
            {
                Count = this.GetCheckedData();
            }

            if (Count > ((int)EnumFile.AssignValue.Zero))
            {
                PnlActivateDeactivate.Visible = true;
                PnlSearch.Visible = false;
                PnlResetPassword.Visible = false;
                this.GvUserList.Enabled = false;
            }
            else
            {
                WebMsg.Show("Please select atleast one record.");
            }
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }

    protected void ImgBtnResetPassword_Click(object sender, System.Web.UI.ImageClickEventArgs e)
    {
        try
        {
            int Count = (int)EnumFile.AssignValue.Zero;
            if (PnlResetPassword.Visible == true)
            {
                PnlActivateDeactivate.Visible = false;
                PnlSearch.Visible = true;
                PnlResetPassword.Visible = false;
            }
            else
            {
                Count = this.GetCheckedData();
            }

            if (Count > ((int)EnumFile.AssignValue.Zero))
            {
                PnlActivateDeactivate.Visible = false;
                PnlSearch.Visible = false;
                PnlResetPassword.Visible = true;
                this.GvUserList.Enabled = false;
            }
            else
            {
                WebMsg.Show("Please select atleast one record.");
            }
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }

    protected void ImgBtnRefresh_Click(object sender, System.Web.UI.ImageClickEventArgs e)
    {
        try
        {
            this.ClearControls();
            this.ViewState["GridCondition"] = string.Empty;
            this.BindGridData();
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }

    protected void BtnReset_Click(object sender, EventArgs e)
    {
        try
        {
            this.GvUserList.DataSource = null;
            this.GvUserList.DataBind();
            DdlRole.SelectedValue = Convert.ToString((int)EnumFile.AssignValue.Zero);
            DdlStandard.Items.Clear();
            DdlStandard.Items.Insert((int)EnumFile.AssignValue.Zero, "-- Select --");
            DdlStandard.Items[0].Value = Convert.ToString((int)EnumFile.AssignValue.Zero);
            DdlStandard.SelectedValue = Convert.ToString((int)EnumFile.AssignValue.Zero);
            DdlStandard.Enabled = false;
            DdlDivision.Items.Clear();
            DdlDivision.Items.Insert((int)EnumFile.AssignValue.Zero, "-- Select --");
            DdlDivision.Items[0].Value = Convert.ToString((int)EnumFile.AssignValue.Zero);
            DdlDivision.SelectedValue = Convert.ToString((int)EnumFile.AssignValue.Zero);
            DdlDivision.Enabled = false;
            this.ViewState["GridCondition"] = string.Empty;
            rlstActive.ClearSelection();
            this.BindGridData();
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }

    protected void BtnActDeactSub_Click(object sender, EventArgs e)
    {
        try
        {
            if (this.ViewState["ActiveDeactiveUsers"] != null || this.ViewState["ActiveDeactiveStudents"] != null)
            {
                Boolean TempStatus = false;
                //string TempStatus = "'0'";

                if (RdbActive.Checked == true)
                {
                    TempStatus = true;
                }

                if (RdbDeactive.Checked == true)
                {
                    TempStatus = false;
                }

                //this.PEmployee.roleid = int.Parse(DdlRole.SelectedValue);
                //this.PEmployee.userid = this.ViewState["ActiveDeactiveUsers"].ToString();
                this.PEmployee.Studentlist = this.ViewState["ActiveDeactiveStudents"].ToString();
                //this.PEmployee.status = TempStatus;
                //string employeeid = "'" + this.ViewState["ActiveDeactiveUsers"].ToString() + "'";
                string employeeid = this.ViewState["ActiveDeactiveUsers"].ToString();
                string studentid = this.ViewState["ActiveDeactiveStudents"].ToString();
                //this.PEmployee.modifiedby = int.Parse(this.ViewState["EmployeeID"].ToString());
                this.BEmployee.BAL_Employee_ActiveStatus_Update(employeeid, studentid, TempStatus);
                string status = string.Empty;
                if (RdbActive.Checked == true)
                {
                    status = "Active.";
                }
                else if (RdbDeactive.Checked == true)
                {
                    status = "Deactive.";
                }
                string message = string.Format("Selected records have been successfully {0}", status);
                WebMsg.Show(message);

                PnlSearch.Visible = true;
                PnlResetPassword.Visible = false;
                PnlActivateDeactivate.Visible = false;
                //this.ClearControls();
                this.GridCondition = CreateGridCondition();
                this.ViewState["GridCondition"] = GridCondition;
                this.BindGridData();
            }
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }

    protected void BtnSubmitPassword_Click(object sender, EventArgs e)
    {
        try
        {
            if (this.ViewState["ActiveDeactiveUsers"] != null || this.ViewState["ActiveDeactiveStudents"] != null)
            {
                this.PEmployee.roleid = int.Parse(DdlRole.SelectedValue);
                this.PEmployee.userid = this.ViewState["ActiveDeactiveUsers"].ToString();
                this.PEmployee.Studentlist = this.ViewState["ActiveDeactiveStudents"].ToString();
                this.PEmployee.password = TxtPassword.Text;
                this.PEmployee.modifiedby = int.Parse(this.ViewState["EmployeeID"].ToString());
                this.BEmployee.BAL_Employee_Password_Update(this.PEmployee);
                WebMsg.Show("Given command completed successfully.");
                PnlSearch.Visible = true;
                PnlResetPassword.Visible = false;
                PnlActivateDeactivate.Visible = false;
                this.ClearControls();
                this.ViewState["GridCondition"] = string.Empty;
                this.BindGridData();
            }
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }

    protected void grvEmpStdSubAllocationDetails_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            if (e.SortExpression.Trim() == this.SortField)
            {
                this.SortDirection = this.SortDirection == "descending" ? "ascending" : "descending";
            }
            else
            {
                this.SortDirection = "ascending";
            }

            this.SortField = e.SortExpression;
            this.BindGridData();

            GridViewOperations GrvOperation = new GridViewOperations();
            GrvOperation.GrvSortingSetImage(e, this.GvUserList, this.SortDirection);
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }

    protected void GvUserList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            DropDownList DDLSelectPage = (DropDownList)this.GvUserList.BottomPagerRow.FindControl("ddlPageSelector");
            DDLSelectPage.SelectedIndex = e.NewPageIndex;
            this.GvUserList.PageIndex = e.NewPageIndex;
            this.BindGridData();
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }

    protected void grvEmpStdSubAllocationDetails_RowCreated(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.Pager)
            {
                GridViewOperations GrvOperation = new GridViewOperations();
                GrvOperation.SetPagerButtonStates(this.GvUserList, e.Row, this.Page);
            }
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }

    protected void ddlPageSelector_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            this.GvUserList.PageIndex = ((DropDownList)sender).SelectedIndex;
            this.BindGridData();
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }

    //protected void TxtSchoolName_TextChanged(object sender, EventArgs e)
    //{
    //    if (TxtSchoolName.Text != string.Empty)
    //    {
    //        string Name = TxtSchoolName.Text;
    //        int k = Name.IndexOf("(");
    //        int l = Name.IndexOf(")");

    //        if (k > 0 & l > 0)
    //        {
    //            LtSchoolID.Text = Name.Substring(k + 1, (l - k) - 1);
    //            this.ViewState["SchoolID"] = LtSchoolID.Text;
    //            this.ViewState["SchoolName"] = Name.Substring(0, k);
    //        }
    //        else
    //        {
    //            WebMsg.Show("Please select a proper school name.");
    //        }
    //    }
    //}

    #endregion

    #region "User Defined Functions"

    /// <summary>
    /// Method will be used to create grid condition based on the selected criteria.
    /// </summary>
    /// <returns>Return GridCondition</returns>
    protected string CreateGridCondition()
    {
        string Condition = string.Empty;
        string AndCondtion = " And";
        string ESchool = "dbo.Employee.SchoolID";
        string ERole = "dbo.Employee.RoleID";
        string EStandard = "dbo.SYS_Standard.StandardID";
        string EDivision = "dbo.SYS_Division.DivisionID";

        string SSchool = "Stud.SchoolID";
        string SRole = "Stud.RoleID";
        string SDivision = "Stud.DivisionID";
        string SysBmsStandard = "SYS_BMS.StandardID";

        try
        {
            if (DdlRole.SelectedValue == Convert.ToString((int)EnumFile.Role.Teacher) || DdlRole.SelectedValue == Convert.ToString((int)EnumFile.Role.S_Admin))
            {
                // Role ID 3 Indicates Teacher.
                if (LtSchoolID.Text != string.Empty)
                {
                    Condition = string.Format("{0}={1}", ESchool, int.Parse(LtSchoolID.Text));
                }

                if (DdlRole.SelectedValue != Convert.ToString((int)EnumFile.AssignValue.Zero))
                {
                    Condition = Condition + string.Format("{0} {1}={2}", AndCondtion, ERole, DdlRole.SelectedValue);
                }

                if (DdlStandard.SelectedValue != Convert.ToString((int)EnumFile.AssignValue.Zero))
                {
                    Condition = Condition + string.Format("{0} {1}={2}", AndCondtion, EStandard, DdlStandard.SelectedValue);
                }

                if (DdlDivision.SelectedValue != Convert.ToString((int)EnumFile.AssignValue.Zero))
                {
                    Condition = Condition + string.Format("{0} {1}={2}", AndCondtion, EDivision, DdlDivision.SelectedValue);
                }
            }
            else if (DdlRole.SelectedValue == Convert.ToString((int)EnumFile.Role.Student))
            {
                // Role Id 4 indicates student.
                if (LtSchoolID.Text != string.Empty)
                {
                    Condition = string.Format("{0}={1}", SSchool, int.Parse(LtSchoolID.Text));
                }

                if (DdlRole.SelectedValue != Convert.ToString((int)EnumFile.AssignValue.Zero))
                {
                    Condition = Condition + string.Format("{0} {1}={2}", AndCondtion, SRole, DdlRole.SelectedValue);
                }

                if (int.Parse(ViewState["UserRoleID"].ToString()) != Convert.ToInt32(EnumFile.Role.Teacher))
                {
                    if (DdlStandard.SelectedValue != Convert.ToString((int)EnumFile.AssignValue.Zero))
                    {
                        ////string B = "Stud.BMSID in (Select BMSID from SYS_BMS  where SYS_BMS.BoardID=" + BoardID + " and SYS_BMS.MediumID=" + MediumID + " and SYS_BMS.StandardID=" + DdlStandard.SelectedValue + ")";
                        ////Condition = Condition + string.Format("{0} {1}", AndCondtion, B);
                        Condition = Condition + string.Format("{0} {1}={2}", AndCondtion, SysBmsStandard, DdlStandard.SelectedValue);
                    }

                    if (DdlDivision.SelectedValue != Convert.ToString((int)EnumFile.AssignValue.Zero))
                    {
                        Condition = Condition + string.Format("{0} {1}={2}", AndCondtion, SDivision, DdlDivision.SelectedValue);
                    }
                }
                else if (int.Parse(ViewState["UserRoleID"].ToString()) == Convert.ToInt32(EnumFile.Role.Teacher))
                {
                    if (DdlStandard.SelectedValue != Convert.ToString((int)EnumFile.AssignValue.Zero))
                    {
                        string B = "Stud.BMSID in (Select DISTINCT BMSID from EmployeeStandardDetail ESD   where ESD.EmployeeID=" + int.Parse(this.ViewState["EmployeeID"].ToString()) + " and Sbms.BMSID=ESD.BMSID and Std.StandardID=" + DdlStandard.SelectedValue + ")";
                        Condition = Condition + string.Format("{0} {1}", AndCondtion, B);
                    }

                    if (DdlDivision.SelectedValue != Convert.ToString((int)EnumFile.AssignValue.Zero))
                    {
                        string B = "Stud.DivisionID in (Select DISTINCT DivisionID from EmployeeStandardDetail  where EmployeeStandardDetail.EmployeeID=" + int.Parse(this.ViewState["EmployeeID"].ToString()) + "and Div.DivisionID=" + DdlDivision.SelectedValue + ")";
                        Condition = Condition + string.Format("{0} {1}", AndCondtion, B);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }

        return Condition;
    }

    private string SetActiveValue(string Active)
    {
        if (rlstActive.SelectedValue == "1")
        {
            Active = "Yes";
        }
        else
        {
            Active = "No";
        }
        return Active;
    }

    /// <summary>
    /// Method will be used to bind roles to the drop down. 
    /// </summary>
    /// <param name="RoleID">Role ID</param>
    protected void BindRoles(int RoleID)
    {
        try
        {
            this.PSysRole.roleid = RoleID;
            DdlRole.Items.Clear();
            this.BSysRole.BindRolesForUserList(this.DdlRole, this.PSysRole);
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }

    /// <summary>
    /// Method will be used to clear controls of the page.
    /// </summary>
    protected void ClearControls()
    {
        try
        {
            TxtPassword.Text = string.Empty;
            this.GvUserList.DataSource = null;
            this.GvUserList.DataBind();
            DdlRole.SelectedValue = Convert.ToString((int)EnumFile.AssignValue.Zero);
            DdlStandard.Items.Clear();
            DdlStandard.Items.Insert((int)EnumFile.AssignValue.Zero, "-- Select --");
            DdlStandard.Items[0].Value = Convert.ToString((int)EnumFile.AssignValue.Zero);
            DdlStandard.SelectedValue = Convert.ToString((int)EnumFile.AssignValue.Zero);
            DdlDivision.Items.Clear();
            DdlDivision.Items.Insert((int)EnumFile.AssignValue.Zero, "-- Select --");
            DdlDivision.Items[0].Value = Convert.ToString((int)EnumFile.AssignValue.Zero);
            DdlDivision.SelectedValue = Convert.ToString((int)EnumFile.AssignValue.Zero);
            PnlSearch.Visible = true;
            PnlActivateDeactivate.Visible = false;
            PnlResetPassword.Visible = false;
            RdbDeactive.Checked = false;
            RdbActive.Checked = true;
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }

    /// <summary>
    /// Method will be used to bind grid view.
    /// </summary>
    protected void BindGridData()
    {
        string IsActive = string.Empty;
        if (rlstActive.SelectedValue == "0")
        {
            IsActive = "No";
        }
        else if (rlstActive.SelectedValue == "1")
        {
            IsActive = "Yes";
        }
        else
        {
            IsActive = string.Empty;
        }

        if (DdlRole.SelectedItem != null)
        {
            if (DdlRole.SelectedItem.Value != "0")
                this.PUserList.Roleid = Convert.ToInt16(DdlRole.SelectedItem.Value);
        }
        if (DdlStandard.SelectedItem != null)
        {
            if (DdlStandard.SelectedItem.Value != "0")
                this.PUserList.Standardid = Convert.ToInt16(DdlStandard.SelectedItem.Value);
        }
        if (DdlDivision.SelectedItem != null)
        {
            if (DdlDivision.SelectedItem.Value != "0")
                this.PUserList.Divisionid = Convert.ToInt16(DdlDivision.SelectedItem.Value);
        }

        if (this.ViewState["GridCondition"] != null && this.ViewState["GridCondition"].ToString() != string.Empty)
        {
            if (int.Parse(ViewState["UserRoleID"].ToString()) == Convert.ToInt32(EnumFile.Role.S_Admin))
            {
                this.PUserList.schoolid = int.Parse(ViewState["SchoolID"].ToString());
                this.PUserList.mode = "School Admin";
                this.PUserList.searchcondition = this.ViewState["GridCondition"].ToString();
                if (DdlRole.SelectedValue == Convert.ToString((int)EnumFile.Role.Teacher))
                {
                    this.PUserList.searchcategory = "Employee";
                }
                else if (DdlRole.SelectedValue == Convert.ToString((int)EnumFile.Role.Student))
                {
                    this.PUserList.searchcategory = "Student";
                }
            }
            else if (int.Parse(ViewState["UserRoleID"].ToString()) == Convert.ToInt32(EnumFile.Role.Teacher))
            {
                this.PUserList.schoolid = int.Parse(ViewState["SchoolID"].ToString());
                this.PUserList.mode = "School Teacher";
                this.PUserList.searchcondition = this.ViewState["GridCondition"].ToString();
                this.PUserList.searchcategory = "Student";
            }
            else if (int.Parse(ViewState["UserRoleID"].ToString()) == Convert.ToInt32(EnumFile.Role.E_Admin))
            {
                this.PUserList.schoolid = int.Parse(ViewState["SchoolID"].ToString());
                this.PUserList.mode = "Epath Admin";
                this.PUserList.searchcondition = this.ViewState["GridCondition"].ToString();
                if (DdlRole.SelectedValue == Convert.ToString((int)EnumFile.Role.Teacher))
                {
                    this.PUserList.searchcategory = "Employee";
                }
                else if (DdlRole.SelectedValue == Convert.ToString((int)EnumFile.Role.Student))
                {
                    this.PUserList.searchcategory = "Student";
                }
                else if (DdlRole.SelectedValue == Convert.ToString((int)EnumFile.Role.S_Admin))
                {
                    this.PUserList.searchcategory = "SAdmin";
                }
            }

            this.GvUserList.Enabled = true;
            this.BUserList.BindGridNew(this.GvUserList, this.PUserList, this.SortField, this.SortDirection, IsActive);
        }
        else
        {
            this.PUserList.schoolid = int.Parse(ViewState["SchoolID"].ToString());
            this.PUserList.searchcondition = this.ViewState["GridCondition"].ToString();
            this.PUserList.searchcategory = "Default";
            if (ViewState["UserRoleID"].ToString() == Convert.ToString((int)EnumFile.Role.E_Admin))
            {
                this.PUserList.mode = "Epath Admin";
            }
            else if (ViewState["UserRoleID"].ToString() == Convert.ToString((int)EnumFile.Role.S_Admin))
            {
                this.PUserList.Employeeroleid = int.Parse(ViewState["UserRoleID"].ToString());
                this.PUserList.mode = "School Admin";
            }
            else if (ViewState["UserRoleID"].ToString() == Convert.ToString((int)EnumFile.Role.Teacher))
            {
                this.PUserList.employeeid = int.Parse(ViewState["EmployeeID"].ToString());
                this.PUserList.mode = "School Teacher";
            }

            this.GvUserList.Enabled = true;
            this.BUserList.BindGridNew(this.GvUserList, this.PUserList, this.SortField, this.SortDirection, IsActive);
        }
    }

    /// <summary>
    /// Method will be used to get checkbox checked data.
    /// </summary>
    /// <returns>Return checkbox checked data</returns>
    protected int GetCheckedData()
    {
        int Flag = 0;
        string ActiveDeactive = string.Empty;
        string ActiveDeactiveStudent = string.Empty;
        int Count = (int)EnumFile.AssignValue.Zero;
        int SCount = (int)EnumFile.AssignValue.Zero;

        try
        {
            foreach (GridViewRow gr in this.GvUserList.Rows)
            {
                CheckBox Chk = (CheckBox)gr.FindControl("ChkUserID");

                if (Chk.Checked == true)
                {
                    if (this.GvUserList.DataKeys[gr.RowIndex]["RoleID"].ToString() == "4")
                    {
                        if (SCount == 0)
                        {
                            ActiveDeactiveStudent = this.GvUserList.DataKeys[gr.RowIndex]["UserID"].ToString();
                        }
                        else
                        {
                            ActiveDeactiveStudent = ActiveDeactiveStudent + "," + this.GvUserList.DataKeys[gr.RowIndex]["UserID"].ToString();
                        }

                        SCount = SCount + 1;
                    }
                    else
                    {
                        if (Count == 0)
                        {
                            ActiveDeactive = this.GvUserList.DataKeys[gr.RowIndex]["UserID"].ToString();
                        }
                        else
                        {
                            ActiveDeactive = ActiveDeactive + "," + this.GvUserList.DataKeys[gr.RowIndex]["UserID"].ToString();
                        }

                        Count = Count + 1;
                    }
                }
            }

            if (Count > 0 || SCount > 0)
            {
                Flag = 1;
                this.ViewState["ActiveDeactiveUsers"] = ActiveDeactive;
                this.ViewState["ActiveDeactiveStudents"] = ActiveDeactiveStudent;
            }



        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }

        return Flag;
    }

    /// <summary>
    /// Method will be used to bind standards to the drop down.
    /// </summary>
    protected void BindStandards()
    {
        DdlStandard.Items.Clear();
        this.PSysStandard.userroleid = int.Parse(ViewState["UserRoleID"].ToString());
        this.PSysStandard.employeeid = int.Parse(ViewState["EmployeeID"].ToString());
        this.PSysStandard.Schoolid = int.Parse(ViewState["SchoolID"].ToString());
        this.BSysStandard.BindStandardListForUserList(this.DdlStandard, this.PSysStandard);
    }

    #endregion

    #region "Web Service Method"

    [System.Web.Services.WebMethodAttribute, System.Web.Script.Services.ScriptMethodAttribute]
    public static string[] GetSchoolName(string prefixText, int count, string contextKey)
    {
        School_BLogic SchoolBLogic = new School_BLogic();
        DataTable dt = new DataTable();
        dt = SchoolBLogic.BAL_SchoolAllNameWithID("AutoCompelete").Tables[0];

        int i = Convert.ToInt32(EnumFile.AssignValue.Zero);
        string expression;
        expression = "Name like '%" + prefixText + "%'";
        DataRow[] foundRows;
        foundRows = dt.Select(expression);
        string[] item = new string[foundRows.Count()];
        foreach (DataRow dr in foundRows)
        {
            item.SetValue(dr["Name"].ToString(), i);
            i++;
        }

        return item;
    }

    #endregion
    protected void ImgBtnSearch_Click(object sender, System.Web.UI.ImageClickEventArgs e)
    {
        try
        {
            ClearControls();
            BindGridData();
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }
    protected void ibtnAdd_Click(object sender, ImageClickEventArgs e)
    {
        string schoolid = Convert.ToString(this.ViewState["SchoolID"]);
        string schoolname = Convert.ToString(this.ViewState["SchoolName"]);
        if (!string.IsNullOrEmpty(schoolid) && !string.IsNullOrEmpty(schoolid))
        {
            Response.Redirect("../Admin/AddUser.aspx?SchoolID=" + schoolid + "&SchoolName=" + schoolname + "");
        }
    }
    protected void ibtnEdit_Click(object sender, ImageClickEventArgs e)
    {
        string Employeeid = string.Empty;
        string schoolid = Convert.ToString(this.ViewState["SchoolID"]);
        string schoolname = Convert.ToString(this.ViewState["SchoolName"]);
        foreach (GridViewRow gr in this.GvUserList.Rows)
        {
            CheckBox Chk = (CheckBox)gr.FindControl("ChkUserID");
            if (Chk.Checked == true)
            {
                if (this.GvUserList.DataKeys[gr.RowIndex]["RoleID"].ToString() != "4")
                {
                    Employeeid = this.GvUserList.DataKeys[gr.RowIndex]["UserID"].ToString();
                    break;
                }
            }
        }
        if (!string.IsNullOrEmpty(Employeeid))
        {
            Response.Redirect("../Admin/UpdateUser.aspx?Employeeid=" + Employeeid + "&schoolid=" + schoolid + "");
        }
    }

    public void BindSchoolDropDown()
    {
        School_BLogic SchoolBLogic = new School_BLogic();
        DataTable dt = new DataTable();
        dt = SchoolBLogic.BAL_SchoolAllNameWithID("Normal").Tables[0];

        if (dt.Rows.Count > 0)
        {
            ddlSchool.DataSource = dt;
            ddlSchool.DataTextField = "Name";
            ddlSchool.DataValueField = "SchoolID";
            ddlSchool.DataBind();
        }
        ddlSchool.Items.Insert(0, "-- Select --");
        ddlSchool.Items[0].Value = "0";

    }
    protected void ddlSchool_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.ViewState["SchoolID"] = ddlSchool.SelectedItem.Value;
        this.ViewState["SchoolName"] = ddlSchool.SelectedItem.Text;
    }
}