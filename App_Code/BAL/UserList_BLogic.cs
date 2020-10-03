using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Data;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for UserList_BLogic
/// </summary>
public class UserList_BLogic
{
    UserList PUserList = new UserList();
    DataAccess DAL_UserList;
    ArrayList arrParameter;

    public UserList_BLogic()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataSet BAL_UserList_Select(UserList UserList)
    {
        DAL_UserList = new DataAccess();
        arrParameter = new ArrayList();
        arrParameter.Add(new parameter("EmployeeID", UserList.employeeid));
        arrParameter.Add(new parameter("SchoolID", UserList.schoolid));
        arrParameter.Add(new parameter("Mode", UserList.mode));
        arrParameter.Add(new parameter("SearchCategory", UserList.searchcategory));
        arrParameter.Add(new parameter("SearchCondition", UserList.searchcondition));
        return DAL_UserList.DAL_Select("Proc_UserListDisplay", arrParameter);
    }

    public void BindGrid(GridView GV, UserList PUserList, string sortfield, string sortdirection, string IsActive)
    {
        DataSet dsGrid = new DataSet();
        dsGrid = this.BAL_UserList_Select(PUserList);
        if (dsGrid.Tables[0].Rows.Count > 0 && dsGrid.Tables[0] != null)
        {
            DataView dv = new DataView(dsGrid.Tables[0]);
            DataSet ds = new DataSet();
            if (IsActive == "Yes")
            {
                dv.RowFilter = "IsActive ='Yes'";
                ds.Tables.Add(dv.ToTable());
            }
            else if (IsActive == "No")
            {
                dv.RowFilter = "IsActive ='No'";
                ds.Tables.Add(dv.ToTable());
            }
            else
            {
                ds = dsGrid;
            }
            GridViewOperations GrvOperation = new GridViewOperations();
            GrvOperation.BindGridWithSorting(GV, ds, sortfield, sortdirection);
        }
    }
    public void BindGridNew(GridView GV, UserList PUserList, string sortfield, string sortdirection, string IsActive)
    {
        DataSet dsGrid = new DataSet();
        dsGrid = this.BAL_UserList_SelectNew(PUserList);
        if (dsGrid.Tables[0].Rows.Count > 0 && dsGrid.Tables[0] != null)
        {
            DataView dv = new DataView(dsGrid.Tables[0]);
            DataSet ds = new DataSet();
            if (IsActive == "Yes")
            {
                dv.RowFilter = "IsActive ='Yes'";
                ds.Tables.Add(dv.ToTable());
            }
            else if (IsActive == "No")
            {
                dv.RowFilter = "IsActive ='No'";
                ds.Tables.Add(dv.ToTable());
            }
            else
            {
                ds = dsGrid;
            }
            GridViewOperations GrvOperation = new GridViewOperations();
            GrvOperation.BindGridWithSorting(GV, ds, sortfield, sortdirection);
        }

    }
    public DataSet BAL_UserList_SelectNew(UserList UserList)
    {
        DAL_UserList = new DataAccess();
        arrParameter = new ArrayList();
        arrParameter.Add(new parameter("EmployeeID", UserList.employeeid));
        arrParameter.Add(new parameter("SchoolID", UserList.schoolid));
        arrParameter.Add(new parameter("Mode", UserList.mode));
        arrParameter.Add(new parameter("SearchCategory", UserList.searchcategory));
        arrParameter.Add(new parameter("SearchCondition", UserList.searchcondition));
        arrParameter.Add(new parameter("EmployeeRoleID", UserList.Employeeroleid));
        arrParameter.Add(new parameter("Roleid", UserList.Roleid));
        arrParameter.Add(new parameter("StandardID", UserList.Standardid));
        arrParameter.Add(new parameter("DivisionID", UserList.Divisionid));
        return DAL_UserList.DAL_Select("Proc_UserListDisplayNew", arrParameter);
    }

}