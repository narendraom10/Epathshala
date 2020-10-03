using System.Data;
using System.Collections;
using System;
using System.Web.UI.WebControls;

/// <summary> 
/// <DevelopedBy>"NARENDRASINH"</DevelopedBy>
/// <DevelopedDate></DevelopedDate>
/// <UpdatedBy>"NARENDRASINH"</UpdatedBy>
/// <UpdatedDate></UpdatedDate>
/// </summary>

public class SYS_Role_BLogic
{
    DataAccess DAL_SYS_Role;
    ArrayList arrParameter;
    SYS_Role PRole = new SYS_Role();

    public SYS_Role_BLogic()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public int BAL_SYS_Role_Insert(SYS_Role SYS_Role, string mode)
    {
        DAL_SYS_Role = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("mode", mode));
        arrParameter.Add(new parameter("RoleID", SYS_Role.roleid));
        arrParameter.Add(new parameter("Role", SYS_Role.role));
        arrParameter.Add(new parameter("Description", SYS_Role.description));      
        arrParameter.Add(new parameter("CreatedBy", SYS_Role.createdby));  
        arrParameter.Add(new parameter("ModifiedBy", SYS_Role.modifiedby));
        return DAL_SYS_Role.DAL_InsertUpdate_Return("Proc_SYS_RoleInsertUpdate", arrParameter);
    }

    public int BAL_SYS_Role_Update(SYS_Role SYS_Role, string mode)
    {
        DAL_SYS_Role = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("mode", mode));
        arrParameter.Add(new parameter("RoleID", SYS_Role.roleid));
        arrParameter.Add(new parameter("Role", SYS_Role.role));
        arrParameter.Add(new parameter("Description", SYS_Role.description));       
        arrParameter.Add(new parameter("CreatedBy", SYS_Role.createdby));      
        arrParameter.Add(new parameter("ModifiedBy", SYS_Role.modifiedby));
        return DAL_SYS_Role.DAL_InsertUpdate_Return("Proc_SYS_RoleInsertUpdate", arrParameter);
    }

    public int BAL_SYS_Role_Delete(SYS_Role SYS_Role, string mode)
    {
        DAL_SYS_Role = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("mode", mode));
        arrParameter.Add(new parameter("RoleID", SYS_Role.roleid));
        arrParameter.Add(new parameter("RoleIDStr", SYS_Role.roleidStr));
        arrParameter.Add(new parameter("IsActive", SYS_Role.isactive));
        return DAL_SYS_Role.DAL_Delete_Return("Proc_SYS_RoleSelectDelete", arrParameter);
    }

    public DataSet BAL_SYS_Role_Select(SYS_Role SYS_Role, string mode)
    {
        DAL_SYS_Role = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("mode", mode));
        arrParameter.Add(new parameter("RoleID", SYS_Role.roleid));
        arrParameter.Add(new parameter("RoleIDStr", SYS_Role.roleidStr));
        return DAL_SYS_Role.DAL_Select("Proc_SYS_RoleSelectDelete", arrParameter);
    }

  
    public DataSet BAL_SYS_Role_SelectAll()
    {
        DAL_SYS_Role = new DataAccess();
        return DAL_SYS_Role.DAL_SelectALL("PROC_Select_Role");
    }



    public DataSet BAL_SYS_Active_Login(SYS_Role SYS_Role)
    {
        DAL_SYS_Role = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("UserName", SYS_Role.Username));
        arrParameter.Add(new parameter("Password", SYS_Role.Password));
        //arrParameter.Add(new parameter("RoleID", SYS_Role.roleid));

        return DAL_SYS_Role.DAL_Select("PROC_Select_ValidUser", arrParameter);
    }

    public DataSet BAL_SYS_Active_Login_Swayam(SYS_Role SYS_Role)
    {
        DAL_SYS_Role = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("UserName", SYS_Role.Username));
        arrParameter.Add(new parameter("Password", SYS_Role.Password));
        //arrParameter.Add(new parameter("RoleID", SYS_Role.roleid));

        return DAL_SYS_Role.DAL_Select("PROC_Select_ValidUser_Swayam", arrParameter);
    }

    public DataSet BAL_SYS_Check_Login(SYS_Role SYS_Role)
    {
        DAL_SYS_Role = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("UserName", SYS_Role.Username));
        arrParameter.Add(new parameter("Password", SYS_Role.Password));

        //return DAL_SYS_Role.DAL_Select("PROC_Select_Valid_login", arrParameter);
        return DAL_SYS_Role.DAL_Select("PROC_Select_Valid_login", arrParameter);
    }

    public DataSet BAL_SYS_Check_Login_studentportal(SYS_Role SYS_Role)
    {
        DAL_SYS_Role = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("UserName", SYS_Role.Username));
        arrParameter.Add(new parameter("Name", SYS_Role.Name));

        return DAL_SYS_Role.DAL_Select("Student_Portal_PROC_Select_Valid_login", arrParameter);
    }

    public DataSet BAL_SYS_Select_IsFreePackage(int StudentID)
    {
        DAL_SYS_Role = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("StudentID", StudentID));
        //arrParameter.Add(new parameter("RoleID", SYS_Role.roleid));

        return DAL_SYS_Role.DAL_Select("Select_IsFreePackage", arrParameter);
    }

    public DataSet BAL_SYS_Select_IsLoggedIn(string sessionid)
    {
        DAL_SYS_Role = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("SessionID", sessionid));
        //arrParameter.Add(new parameter("RoleID", SYS_Role.roleid));

        return DAL_SYS_Role.DAL_Select("Select_TodaySessionDetails", arrParameter);
    }

    public DataSet BAL_Select_Session_Details()
    {
        DAL_SYS_Role = new DataAccess();
        arrParameter = new ArrayList();

        return DAL_SYS_Role.DAL_Select("Select_TodaySessionDetails", arrParameter);
    
    }

    public DataSet BAL_SYS_Student_Login(SYS_Role SYS_Role)
    {
        DAL_SYS_Role = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("UserName", SYS_Role.Username));
        arrParameter.Add(new parameter("Password", SYS_Role.Password));
        //arrParameter.Add(new parameter("RoleID", SYS_Role.roleid));

        return DAL_SYS_Role.DAL_Select("Proc_Select_ValidStudent", arrParameter);
    }
    public DataSet BAL_SYS_Parent_Login(SYS_Role SYS_Role)
    {
        DAL_SYS_Role = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("UserName", SYS_Role.Username));
        arrParameter.Add(new parameter("Password", SYS_Role.Password));
        //arrParameter.Add(new parameter("RoleID", SYS_Role.roleid));

        return DAL_SYS_Role.DAL_Select("Proc_Select_ValidParent", arrParameter);
    }
    public DataSet BAL_SYS_Student_Information(int StudentID)
    {
        DAL_SYS_Role = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("StudentID", StudentID));        
        //arrParameter.Add(new parameter("RoleID", SYS_Role.roleid));

        return DAL_SYS_Role.DAL_Select("Proc_Select_StudentInformation", arrParameter);
    }
    public DataSet BAL_ACTIVE_BMS_SelectAll(Int64 EmpID)
    {
        DAL_SYS_Role = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("EmployeeID", EmpID));

        return DAL_SYS_Role.DAL_Select("PROC_Select_Active_BMS", arrParameter);
    }

    public DataSet BAL_Select_Employee_BMS_SelectAll(Int64 EmpID)
    {
        DAL_SYS_Role = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("EmployeeID", EmpID));

        return DAL_SYS_Role.DAL_Select("BAL_Select_Employee_BMS_SelectAll", arrParameter);
    }

    public DataSet BAL_ACTIVE_BMSS()
    {
        DAL_SYS_Role = new DataAccess();
        return DAL_SYS_Role.DAL_SelectALL("PROC_Select_Active_BMSS");
    }

    public DataSet BAL_Select_BMSList()
    {
        DAL_SYS_Role = new DataAccess();
        return DAL_SYS_Role.DAL_SelectALL("PROC_Select_BMSList");
    }

    public DataSet BAL_Allocated_Subject_Div(Int16 BoardID,Int16 MediumID, Int16 StandardID,Int64 EmpID)
    {
        DAL_SYS_Role = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("BoardID", BoardID));
        arrParameter.Add(new parameter("MediumID", MediumID));
        arrParameter.Add(new parameter("StandardID", StandardID));
        arrParameter.Add(new parameter("EmployeeID", EmpID));

        return DAL_SYS_Role.DAL_Select("PROC_Select_Allocated_Subject_Div", arrParameter);
    }

    public DataSet BAL_Allocated_Subject_Div_BasedonBMS(Int64 BMSID, Int64 EmpID)
    {
        DAL_SYS_Role = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("BMSID", BMSID));
        arrParameter.Add(new parameter("EmployeeID", EmpID));

        return DAL_SYS_Role.DAL_Select("PROC_Select_Allocated_Subject_Div_BasedonBMS", arrParameter);
    }

    public DataSet BAL_Select_Medium(Int16 BoardID)
    {
        DAL_SYS_Role = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("BoardID", BoardID));

        return DAL_SYS_Role.DAL_Select("Proc_Select_Medium", arrParameter);
    }

    public DataSet BAL_Select_Standard(Int16 BoardID,Int16 MediumID, Int64 EmpID)
    {
        DAL_SYS_Role = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("BoardID", BoardID));
        arrParameter.Add(new parameter("MediumID", MediumID));
        arrParameter.Add(new parameter("EmployeeID", EmpID));

        return DAL_SYS_Role.DAL_Select("Proc_Select_Standard", arrParameter);
    }

    public DataSet BAL_Select_StandardALL(Int16 BoardID, Int16 MediumID)
    {
        DAL_SYS_Role = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("BoardID", BoardID));
        arrParameter.Add(new parameter("MediumID", MediumID));

        return DAL_SYS_Role.DAL_Select("Proc_Select_Standard_ALL", arrParameter);
    }

    public int BAL_Select_BMS(Int16 BoardID, Int16 MediumID, Int16 StandardID)
    {
        DAL_SYS_Role = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("BoardID", BoardID));
        arrParameter.Add(new parameter("MediumID", MediumID));
        arrParameter.Add(new parameter("StandardID", StandardID));

        return DAL_SYS_Role.executescalre("PROC_Select_BMS", arrParameter);
    }

    public DataSet BAL_Select_Chapters(Int64 BMSID, Int32 SubjectID)
    {
        DAL_SYS_Role = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("BMSID", BMSID));
        arrParameter.Add(new parameter("SubjectID", SubjectID));

        return DAL_SYS_Role.DAL_Select("PROC_Select_Chapters", arrParameter);
    }

    public DataSet BAL_Select_FileType()
    {
        DAL_SYS_Role = new DataAccess();

        return DAL_SYS_Role.DAL_SelectALL("PROC_Select_FileType");
    }
    //public bool isValid_BMS_Employee()
    //{
    //    DAL_SYS_Role = new DataAccess();
    //    //return DAL_SYS_Role.executescalre("PROC_Select_Active_BMS");
    //}

    public DataSet BAL_SelectRoles_ForUserList(SYS_Role SYS_Role)
    {
        DAL_SYS_Role = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("RoleID", SYS_Role.roleid));

        return DAL_SYS_Role.DAL_Select("proc_Select_Role_ForUserList", arrParameter);
    }

    public void BindRolesForUserList(DropDownList DDl, SYS_Role Role)
    {
        DataSet dsRole = new DataSet();
        dsRole = this.BAL_SelectRoles_ForUserList(Role);
        if (dsRole.Tables[0].Rows.Count > 0)
        {
            DDl.DataSource = dsRole;
            DDl.DataTextField = "Role";
            DDl.DataValueField = "RoleID";
            DDl.DataBind();
        }
        DDl.Items.Insert(0, "-- Select --");
        DDl.Items[0].Value = "0";
    }
}