using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services;

public partial class Admin_AddUser : System.Web.UI.Page
{
    #region "Declaration"
    Employee_BLogic BAL_Employee = new Employee_BLogic();
    Employee Employee = new Employee();
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            Page.Title = "Manage User";

            if (Request.QueryString["SchoolID"] != null)
            {
                this.ViewState["SchoolID"] = Request.QueryString["SchoolID"];
            }
            if (Request.QueryString["SchoolName"] != null)
            {
                this.ViewState["SchoolName"] = Request.QueryString["SchoolName"];
            }
            lblAddTitle.Text = "Add User For School: " + this.ViewState["SchoolName"];

            SYS_Role_BLogic obj_BAL_SYS_Role = new SYS_Role_BLogic();
            DataSet dsSelect = new DataSet();
            dsSelect = obj_BAL_SYS_Role.BAL_SYS_Role_SelectAll();

            if (Session["RoleID"].ToString() == Convert.ToString((int)EnumFile.Role.E_Admin))
            {
                //EAdmin
                foreach (DataRow dr in dsSelect.Tables[0].Rows)
                {
                    if ((Convert.ToString(dr["RoleID"]) == "2") || Convert.ToString(dr["RoleID"]) == "3")
                    {
                        ListItem oList = new ListItem(Convert.ToString(dr["Role"]), Convert.ToString(dr["RoleID"]));
                        ddlRole.Items.Add(oList);
                    }
                }
            }
            else if (Session["RoleID"].ToString() == Convert.ToString((int)EnumFile.Role.S_Admin))
            {
                //SAdmin
                foreach (DataRow dr in dsSelect.Tables[0].Rows)
                {
                    if (Convert.ToString(dr["RoleID"]) == "3")
                    {
                        ListItem oList = new ListItem(Convert.ToString(dr["Role"]), Convert.ToString(dr["RoleID"]));
                        ddlRole.Items.Add(oList);
                    }
                }
            }
            //ddlRole.DataSource = dsSelect.Tables[0];
            //ddlRole.DataTextField = "Role";
            //ddlRole.DataValueField = "RoleID";
            //ddlRole.DataBind();
            ddlRole.Items.Insert(((int)EnumFile.AssignValue.Zero), new ListItem("-- Select --", "0"));


        }
    }
    protected void btnAddSave_Click(object sender, EventArgs e)
    {
        try
        {
            string schoolName = Convert.ToString(this.ViewState["SchoolName"]);
            string IFormat = "dd-MMM-yyyy";

            this.Employee.code = string.Empty;
            this.Employee.roleid = Convert.ToInt32(ddlRole.SelectedItem.Value);
            this.Employee.schoolid = Convert.ToInt32(this.ViewState["SchoolID"]);
            this.Employee.firstname = txtAddFirstName.Text;
            this.Employee.middlename = txtAddMiddleName.Text;
            this.Employee.lastname = txtAddLastName.Text;
            if (rlstAddGender.SelectedIndex == (int)EnumFile.AssignValue.Zero)
            {
                this.Employee.gender = 'M';
            }
            else if (rlstAddGender.SelectedIndex == (int)EnumFile.AssignValue.One)
            {
                this.Employee.gender = 'F';
            }
            this.Employee.dateofbirth = Convert.ToDateTime(DateTime.Parse(txtAddDOB.Text).ToString(IFormat));
            this.Employee.bloodgroup = txtAddBloodGroup.Text;
            this.Employee.address = txtAddPermanentAddress.Text;
            this.Employee.emailid = txtAddEmail.Text;
            this.Employee.MobileNumber = txtAddContactNumber.Text;
            this.Employee.qualification = txtAddQualification.Text;
            this.Employee.designation = txtAddDesignation.Text;
            this.Employee.securityquestion = ddlAddSecurityQues.SelectedIndex;
            this.Employee.securityanswer = txtAddSecAns.Text;
            this.Employee.loginid = tLoginId.Text;
            this.Employee.password = tpassword.Text;

            string UserName = txtAddFirstName.Text + "_" + txtAddLastName.Text;
            string FileName = schoolName + "_" + UserName;
            string UserName1 = txtAddFirstName.Text + "_" + txtAddMiddleName.Text + "_" + txtAddLastName.Text;
            string FileName1 = schoolName + "_" + UserName1;

            byte[] mybytes = (byte[])ViewState["url"];
            this.Employee.image1 = mybytes;

            this.Employee.createdby = AppSessions.EmpolyeeID;
            this.Employee.modifiedby = AppSessions.EmpolyeeID;

            //this.Employee.modifiedon = Convert.ToDateTime(DateTime.Parse(DateTime.Now.ToString()).ToString(IFormat));

            bool status = this.BAL_Employee.BAL_Employee_Insert_FromEpathAdmin(this.Employee);

            if (status)
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Recodrd inserted sucessfully');", true);
            else
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Recodrd inserted Failed');", true);

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
        }
    }

    #region WebMethod
    [WebMethod()]
    public static string CheckUserID(string UserID)
    {
        Employee_BLogic BAL_Employee = new Employee_BLogic();
        bool IsExists = BAL_Employee.BAL_Employee_CheckLogin(UserID);
        if (IsExists)
            return "True";
        else
            return "False";
    }
    #endregion
}