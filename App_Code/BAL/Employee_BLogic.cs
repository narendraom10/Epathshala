using System.Collections;
/// <summary>               
/// <Description>Summary description for Employee_BLogic</Description>
/// <DevelopedBy>"Narendrasinh Vaghela</DevelopedBy>
/// <DevelopedDate>"19-Sept-2013"</DevelopedDate>
/// <UpdatedBy>"Bhavesh Prajapati"</UpdatedBy>
/// <UpdatedDate>"22-Nov-2013"</UpdatedDate>
/// </summary>
using System.Data;
using System;

public class Employee_BLogic
{
    DataAccess DAL_Employee;
    ArrayList arrParameter;

    public Employee_BLogic()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public void BAL_Employee_Insert(Employee Employee, string mode)
    {
        this.DAL_Employee = new DataAccess();
        this.arrParameter = new ArrayList();

        this.arrParameter.Add(new parameter("mode", mode));
        ////arrParameter.Add(new parameter("EmployeeID", Employee.employeeid));
        this.arrParameter.Add(new parameter("Code", Employee.code));
        this.arrParameter.Add(new parameter("RoleID", Employee.roleid));
        this.arrParameter.Add(new parameter("SchoolID", Employee.schoolid));
        this.arrParameter.Add(new parameter("FirstName", Employee.firstname));
        this.arrParameter.Add(new parameter("MiddleName", Employee.middlename));
        this.arrParameter.Add(new parameter("LastName", Employee.lastname));
        this.arrParameter.Add(new parameter("Gender", Employee.gender));
        this.arrParameter.Add(new parameter("DateOfBirth", Employee.dateofbirth));
        this.arrParameter.Add(new parameter("BloodGroup", Employee.bloodgroup));
        this.arrParameter.Add(new parameter("Address", Employee.address));
        this.arrParameter.Add(new parameter("EmailID", Employee.emailid));
        this.arrParameter.Add(new parameter("ContactNo", Employee.contactno));
        this.arrParameter.Add(new parameter("Qualification", Employee.qualification));
        this.arrParameter.Add(new parameter("Designation", Employee.designation));
        this.arrParameter.Add(new parameter("SecurityQuestion", Employee.securityquestion));
        this.arrParameter.Add(new parameter("SecurityAnswer", Employee.securityanswer));
        this.arrParameter.Add(new parameter("LoginID", Employee.loginid));
        this.arrParameter.Add(new parameter("Password", Employee.password));
        this.arrParameter.Add(new parameter("Image", Employee.image1));
        ////arrParameter.Add(new parameter("LastLoginDate", Employee.lastlogindate));
        ////arrParameter.Add(new parameter("AttemptCount", Employee.attemptcount));
        ////arrParameter.Add(new parameter("IsActive", Employee.isactive));
        ////arrParameter.Add(new parameter("CreatedOn", Employee.createdon));
        this.arrParameter.Add(new parameter("CreatedBy", Employee.createdby));
        ////arrParameter.Add(new parameter("ModifiedOn", Employee.modifiedon));
        this.arrParameter.Add(new parameter("ModifiedBy", Employee.modifiedby));
        this.DAL_Employee.DAL_InsertUpdate("Proc_EmployeeInsertUpdate", this.arrParameter);
    }

    public void BAL_Employee_Update(Employee Employee, string mode)
    {
        this.DAL_Employee = new DataAccess();
        this.arrParameter = new ArrayList();

        this.arrParameter.Add(new parameter("mode", mode));
        this.arrParameter.Add(new parameter("EmployeeID", Employee.employeeid));
        ////arrParameter.Add(new parameter("Code", Employee.code));
        this.arrParameter.Add(new parameter("RoleID", Employee.roleid));
        this.arrParameter.Add(new parameter("SchoolID", Employee.schoolid));
        this.arrParameter.Add(new parameter("FirstName", Employee.firstname));
        this.arrParameter.Add(new parameter("MiddleName", Employee.middlename));
        this.arrParameter.Add(new parameter("LastName", Employee.lastname));
        this.arrParameter.Add(new parameter("Gender", Employee.gender));
        this.arrParameter.Add(new parameter("DateOfBirth", Employee.dateofbirth));
        this.arrParameter.Add(new parameter("BloodGroup", Employee.bloodgroup));
        this.arrParameter.Add(new parameter("Address", Employee.address));
        this.arrParameter.Add(new parameter("EmailID", Employee.emailid));
        this.arrParameter.Add(new parameter("ContactNo", Employee.contactno));
        this.arrParameter.Add(new parameter("Qualification", Employee.qualification));
        this.arrParameter.Add(new parameter("Designation", Employee.designation));
        this.arrParameter.Add(new parameter("SecurityQuestion", Employee.securityquestion));
        this.arrParameter.Add(new parameter("SecurityAnswer", Employee.securityanswer));
        ////arrParameter.Add(new parameter("LoginID", Employee.loginid));
        ////arrParameter.Add(new parameter("Password", Employee.password));
        this.arrParameter.Add(new parameter("Image", Employee.image1));
        ////arrParameter.Add(new parameter("LastLoginDate", Employee.lastlogindate));
        ////arrParameter.Add(new parameter("AttemptCount", Employee.attemptcount));
        ////arrParameter.Add(new parameter("IsActive", Employee.isactive));
        ////arrParameter.Add(new parameter("CreatedOn", Employee.createdon));
        this.arrParameter.Add(new parameter("CreatedBy", Employee.createdby));
        ////arrParameter.Add(new parameter("ModifiedOn", Employee.modifiedon));
        this.arrParameter.Add(new parameter("ModifiedBy", Employee.modifiedby));
        this.DAL_Employee.DAL_InsertUpdate("Proc_EmployeeInsertUpdate", this.arrParameter);
    }

    public void BAL_Employee_Delete(Employee Employee, int SchoolID, string mode)
    {
        this.DAL_Employee = new DataAccess();
        this.arrParameter = new ArrayList();

        this.arrParameter.Add(new parameter("mode", mode));
        this.arrParameter.Add(new parameter("EmployeeID", Employee.employeeid));
        this.arrParameter.Add(new parameter("SchoolID", SchoolID));
        this.DAL_Employee.DAL_Delete("Proc_EmployeeSelectDelete", this.arrParameter);
    }

    public void BAL_Employee_ChangeStatus(int employeeid, int SchoolID, Boolean status)
    {
        this.DAL_Employee = new DataAccess();
        this.arrParameter = new ArrayList();
        this.arrParameter.Add(new parameter("EmployeeID", employeeid));
        this.arrParameter.Add(new parameter("SchoolID", SchoolID));
        this.arrParameter.Add(new parameter("Status", status));
        this.DAL_Employee.DAL_Delete("proc_Update_Employee_Status", this.arrParameter);
    }

    ////public DataSet BAL_Employee_Select(Employee Employee, string mode)
    ////{
    ////    DAL_Employee = new DataAccess();
    ////    arrParameter = new ArrayList();

    ////    arrParameter.Add(new parameter("mode", mode));
    ////    arrParameter.Add(new parameter("EmployeeID", Employee.employeeid));
    ////    arrParameter.Add(new parameter("Code", Employee.code));
    ////    arrParameter.Add(new parameter("RoleID", Employee.roleid));
    ////    arrParameter.Add(new parameter("SchoolID", Employee.schoolid));
    ////    arrParameter.Add(new parameter("FirstName", Employee.firstname));
    ////    arrParameter.Add(new parameter("MiddleName", Employee.middlename));
    ////    arrParameter.Add(new parameter("LastName", Employee.lastname));
    ////    arrParameter.Add(new parameter("Gender", Employee.gender));
    ////    arrParameter.Add(new parameter("DateOfBirth", Employee.dateofbirth));
    ////    arrParameter.Add(new parameter("BloodGroup", Employee.bloodgroup));
    ////    arrParameter.Add(new parameter("Address", Employee.address));
    ////    arrParameter.Add(new parameter("EmailID", Employee.emailid));
    ////    arrParameter.Add(new parameter("ContactNo", Employee.contactno));
    ////    arrParameter.Add(new parameter("Qualification", Employee.qualification));
    ////    arrParameter.Add(new parameter("Designation", Employee.designation));
    ////    arrParameter.Add(new parameter("SecurityQuestion", Employee.securityquestion));
    ////    arrParameter.Add(new parameter("SecurityAnswer", Employee.securityanswer));
    ////    arrParameter.Add(new parameter("LoginID", Employee.loginid));
    ////    arrParameter.Add(new parameter("Password", Employee.password));
    ////    arrParameter.Add(new parameter("Image", Employee.image));
    ////    arrParameter.Add(new parameter("LastLoginDate", Employee.lastlogindate));
    ////    arrParameter.Add(new parameter("AttemptCount", Employee.attemptcount));
    ////    arrParameter.Add(new parameter("IsActive", Employee.isactive));
    ////    arrParameter.Add(new parameter("CreatedOn", Employee.createdon));
    ////    arrParameter.Add(new parameter("CreatedBy", Employee.createdby));
    ////    arrParameter.Add(new parameter("ModifiedOn", Employee.modifiedon));
    ////    arrParameter.Add(new parameter("ModifiedBy", Employee.modifiedby));
    ////    return DAL_Employee.DAL_Select("Proc_EmployeeSelectDelete", arrParameter);
    ////}
    public DataSet BAL_Employee_SelectBySchoolID(int schoolid, string mode)
    {
        this.DAL_Employee = new DataAccess();
        this.arrParameter = new ArrayList();
        this.arrParameter.Add(new parameter("SchoolID", schoolid));
        return this.DAL_Employee.DAL_Select("Proc_EmployeeSelectBySchoolID", this.arrParameter);
    }


    public DataSet BAL_Employee_SelectByStatus()
    {
        this.DAL_Employee = new DataAccess();
        this.arrParameter = new ArrayList();
        return this.DAL_Employee.DAL_SelectALL("Employee_SelectEmployeeByStatus");
    }

    public DataSet BAL_Employee_SelectBySchoolStandard(int SchoolID, int BMSID, string mode)
    {
        this.DAL_Employee = new DataAccess();
        this.arrParameter = new ArrayList();
        this.arrParameter.Add(new parameter("SchoolID", SchoolID));
        this.arrParameter.Add(new parameter("BMSID", BMSID));
        this.arrParameter.Add(new parameter("Mode", mode));
        return this.DAL_Employee.DAL_Select("Proc_Get_Employee_School_StandardWise", this.arrParameter);
    }

    ////public DataSet BAL_Employee_SelectAll()
    ////{
    ////    DAL_Employee = new DataAccess();
    ////    return DAL_Employee.DAL_SelectALL("Proc_EmployeeSELECTAll");
    ////}

    //public void BAL_Employee_ActiveStatus_Update(Employee Employee)
    public void BAL_Employee_ActiveStatus_Update(string employeeid, string StudentIDs, Boolean status)
    {
        this.DAL_Employee = new DataAccess();
        this.arrParameter = new ArrayList();

        //this.arrParameter.Add(new parameter("RoleID", Employee.roleid));
        //this.arrParameter.Add(new parameter("UserID", Employee.userid));
        this.arrParameter.Add(new parameter("EmployeeIDs", employeeid));
        this.arrParameter.Add(new parameter("StudentIDs", StudentIDs));
        this.arrParameter.Add(new parameter("Status", status));
        //this.arrParameter.Add(new parameter("SchoolID", Employee.schoolid));

        //this.arrParameter.Add(new parameter("modifiedby", Employee.modifiedby));
        this.DAL_Employee.DAL_InsertUpdate("proc_SetUserActivation", this.arrParameter);
    }

    public void BAL_Employee_Password_Update(Employee Employee)
    {
        this.DAL_Employee = new DataAccess();
        this.arrParameter = new ArrayList();

        this.arrParameter.Add(new parameter("RoleID", Employee.roleid));
        this.arrParameter.Add(new parameter("UserID", Employee.userid));
        this.arrParameter.Add(new parameter("StudentList", Employee.Studentlist));
        this.arrParameter.Add(new parameter("Password", Employee.password));
        this.arrParameter.Add(new parameter("modifiedby", Employee.modifiedby));
        this.DAL_Employee.DAL_InsertUpdate("proc_Update_Employee_Password", this.arrParameter);
    }

    public DataSet BAL_EmployeeDetailsBySchoolID(int schoolID, string SearchCondition)
    {
        this.DAL_Employee = new DataAccess();
        this.arrParameter = new ArrayList();

        this.arrParameter.Add(new parameter("SchoolID", schoolID));
        this.arrParameter.Add(new parameter("SearchCondition", SearchCondition));
        return this.DAL_Employee.DAL_Select("proc_EmployeeDetailsBySchoolID", this.arrParameter);
    }

    public DataSet SelectEmployeeDetailByEmployeeID(Int64 EmployeeID)
    {
        this.DAL_Employee = new DataAccess();
        this.arrParameter = new ArrayList();
        this.arrParameter.Add(new parameter("EmployeeID", EmployeeID));
        return this.DAL_Employee.DAL_Select("Proc_Select_EmployeeDetailByEmployeeID", this.arrParameter);
    }

    public bool BAL_Employee_CheckLogin(string UserID)
    {
        DataSet oDs = new DataSet();
        this.DAL_Employee = new DataAccess();
        this.arrParameter = new ArrayList();
        this.arrParameter.Add(new parameter("UserID", UserID));
        oDs = this.DAL_Employee.DAL_Select("Proc_Select_EmployeeDetailByUserID", this.arrParameter);
        if (oDs.Tables[0].Rows.Count > 0)
            return true;
        else
            return false;
    }

    public bool BAL_Employee_Insert_FromEpathAdmin(Employee Employee)
    {
        this.DAL_Employee = new DataAccess();
        this.arrParameter = new ArrayList();

        this.arrParameter.Add(new parameter("RoleID", Employee.roleid));
        this.arrParameter.Add(new parameter("SchoolID", Employee.schoolid));
        this.arrParameter.Add(new parameter("FirstName", Employee.firstname));
        this.arrParameter.Add(new parameter("MiddleName", Employee.middlename));
        this.arrParameter.Add(new parameter("LastName", Employee.lastname));
        this.arrParameter.Add(new parameter("Gender", Employee.gender));
        this.arrParameter.Add(new parameter("DateOfBirth", Employee.dateofbirth));
        this.arrParameter.Add(new parameter("BloodGroup", Employee.bloodgroup));
        this.arrParameter.Add(new parameter("Address", Employee.address));
        this.arrParameter.Add(new parameter("EmailID", Employee.emailid));
        this.arrParameter.Add(new parameter("ContactNo", Employee.MobileNumber));
        this.arrParameter.Add(new parameter("Qualification", Employee.qualification));
        this.arrParameter.Add(new parameter("Designation", Employee.designation));
        this.arrParameter.Add(new parameter("SecurityQuestion", Employee.securityquestion));
        this.arrParameter.Add(new parameter("SecurityAnswer", Employee.securityanswer));
        this.arrParameter.Add(new parameter("LoginID", Employee.loginid));
        this.arrParameter.Add(new parameter("Password", Employee.password));
        this.arrParameter.Add(new parameter("Image", Employee.image1));
        this.arrParameter.Add(new parameter("CreatedBy", Employee.createdby));
        this.arrParameter.Add(new parameter("ModifiedBy", Employee.modifiedby));
        return this.DAL_Employee.DAL_InsertUpdateWithStatus("Proc_Employee_Insert", this.arrParameter);
    }

    public bool BAL_Employee_Update_FromEpathAdmin(Employee Employee)
    {
        this.DAL_Employee = new DataAccess();
        this.arrParameter = new ArrayList();

        this.arrParameter.Add(new parameter("EmployeeID", Employee.employeeid));
        this.arrParameter.Add(new parameter("RoleID", Employee.roleid));
        this.arrParameter.Add(new parameter("FirstName", Employee.firstname));
        this.arrParameter.Add(new parameter("MiddleName", Employee.middlename));
        this.arrParameter.Add(new parameter("LastName", Employee.lastname));
        this.arrParameter.Add(new parameter("Gender", Employee.gender));
        this.arrParameter.Add(new parameter("DateOfBirth", Employee.dateofbirth));
        this.arrParameter.Add(new parameter("BloodGroup", Employee.bloodgroup));
        this.arrParameter.Add(new parameter("Address", Employee.address));
        this.arrParameter.Add(new parameter("EmailID", Employee.emailid));
        this.arrParameter.Add(new parameter("ContactNo", Employee.MobileNumber));
        this.arrParameter.Add(new parameter("Qualification", Employee.qualification));
        this.arrParameter.Add(new parameter("Designation", Employee.designation));
        this.arrParameter.Add(new parameter("LoginID", Employee.loginid));
        this.arrParameter.Add(new parameter("Image", Employee.image1));
        this.arrParameter.Add(new parameter("CreatedBy", Employee.createdby));
        this.arrParameter.Add(new parameter("ModifiedOn", Employee.modifiedon));
        this.arrParameter.Add(new parameter("ModifiedBy", Employee.modifiedby));
        return this.DAL_Employee.DAL_InsertUpdateWithStatus("Proc_Employee_Update", this.arrParameter);
    }
}