using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for GetStudentInfo
/// </summary>
public class GetStudentInfo
{
	public GetStudentInfo()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public string GetStudentInformation(int studentID, string ValueField)
    {
        SYS_Role_BLogic obj_BAL_SYS_Role = new SYS_Role_BLogic();
        DataSet dtLogin = new DataSet();
        DataTable LoginInfo = new DataTable();
        dtLogin = obj_BAL_SYS_Role.BAL_SYS_Student_Information(2);
        LoginInfo = dtLogin.Tables[0];
        string returnValue = "";
        if (LoginInfo.Rows.Count > 0 && LoginInfo != null)
        {
            if (ValueField == "StudentID")
            {
                returnValue = LoginInfo.Rows[0]["StudentID"].ToString();
            }
            else if (ValueField == "StudentName")
            {
                returnValue = LoginInfo.Rows[0]["FirstName"].ToString();
            }
            else if (ValueField == "BMSID")
            {
                returnValue = LoginInfo.Rows[0]["BMSID"].ToString();
            }
            else if (ValueField == "BMS")
            {
                returnValue = LoginInfo.Rows[0]["BMS"].ToString();
            }
            else if (ValueField == "BoardID")
            {
                returnValue = LoginInfo.Rows[0]["BoardID"].ToString();
            }
            else if (ValueField == "Board")
            {

                returnValue = LoginInfo.Rows[0]["Board"].ToString();
            }
            else if (ValueField == "MediumID")
            {
                returnValue = LoginInfo.Rows[0]["MediumID"].ToString();
            }
            else if (ValueField == "Medium")
            {
                returnValue = LoginInfo.Rows[0]["Medium"].ToString();
            }
            else if (ValueField == "StandardID")
            {
                returnValue = LoginInfo.Rows[0]["StandardID"].ToString();
            }
            else if (ValueField == "Standard")
            {
                returnValue = LoginInfo.Rows[0]["Standard"].ToString();
            }
            else if (ValueField == "DivisionID")
            {
                returnValue = LoginInfo.Rows[0]["DivisionID"].ToString();
            }
            else if (ValueField == "SchoolID")
            {
                returnValue = LoginInfo.Rows[0]["SchoolID"].ToString();
            }
            else if (ValueField == "Role")
            {
                returnValue = LoginInfo.Rows[0]["Role"].ToString();
            }
            else if (ValueField == "RoleID")
            { returnValue = LoginInfo.Rows[0]["RoleID"].ToString(); }
            else
            {
            }

        }
        return returnValue;
    }
}