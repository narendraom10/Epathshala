using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;
using Udev.UserMasterPage.Classes;
using System.Web.Services;

public partial class Index : System.Web.UI.Page
{
    #region "Declarations"
    SYS_BMS_BLogic BSysBMS;
    Student_BLogic BAL_Student;
    Student Student;
    #endregion

    #region "Page Events"
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request.QueryString["frm"]))
        {
            if (Convert.ToString(Request.QueryString["frm"]) == "cp")
            {
                WebMsg.Show("Change password successfully, please login with new password");
            }
        }
    }
    #endregion

    #region "User Defined Function"

    [WebMethod()]
    protected static string[] GetBMS()
    {
        List<string> bmsList = new List<string>();
        SYS_BMS_BLogic BSysBMS = new SYS_BMS_BLogic();
        DataSet dsBMS = new DataSet();
        try
        {
            dsBMS = BSysBMS.BAL_SYS_BMS_SelectAll();

            foreach (DataRow dr in dsBMS.Tables[0].Rows)
            {
                bmsList.Add(dr["BMS"].ToString());
            }
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
        return bmsList.ToArray();
    }


    //string FirstName, string LastName
    // 
    //protected static int InsertStudent(int BMSID,string LoginID,string Password,string FirstName,string LastName,int ContactNo,string Email,string Gender,string Country)
    [WebMethod]
    public static int InsertStudent(int BMSID, string LoginID, string Password, string FirstName, string LastName, int ContactNo, string Gender)
    {
        Student Student = new Student();
        Student_BLogic BAL_Student = new Student_BLogic();
        int t1 = 0;
        try
        {
            Student.bmsid = BMSID;
            Student.loginid = LoginID;
            Student.password = Password;
            Student.firstname = FirstName;
            Student.lastname = LastName;
            Student.contactno = ContactNo;
            Student.emailid = LoginID;
            if (Gender == "1")
            {
                Student.gender = 'M';
            }
            else if (Gender == "2")
            {
                Student.gender = 'F';
            }

            Student.PaymentType = 'I';


            t1 = BAL_Student.BAL_Student_Insert_Online(Student, "OnlineReg");

        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
        return t1;
    }


    [WebMethod()]
    public static bool verifyLoginID(string LoginID)
    {
        bool Flag = true;
        try
        {
            Student_BLogic BAL_Student = new Student_BLogic();
            Student Student = new Student();
            DataSet ds = new DataSet();

            Student.loginid = LoginID;
            ds = BAL_Student.BAL_Verify_Student(Student);
            if (ds.Tables[0].Rows.Count > 0 && ds != null)
            {
                string UserLoginID = ds.Tables[0].Rows[0]["LoginID"].ToString();
                if (UserLoginID != string.Empty)
                {
                    Flag = false;
                }
            }
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
        return Flag;
    }

    #endregion
}