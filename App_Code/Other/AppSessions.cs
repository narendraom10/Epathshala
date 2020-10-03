using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for AppSessions
/// </summary>
public class AppSessions
{
    public AppSessions()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public static string SessionID
    {
        get
        {
            if (HttpContext.Current.Session.SessionID == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session.SessionID;
            }
        }
    }

    public static int SchoolID
    {
        get
        {
            if (HttpContext.Current.Session["SchoolID"] == null || Convert.ToInt32(HttpContext.Current.Session["SchoolID"].ToString()) == 0)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(HttpContext.Current.Session["SchoolID"].ToString());
            }
        }

        set
        {
            HttpContext.Current.Session["SchoolID"] = value;
        }
    }


    public static int EmployeeOrStudentID
    {
        get
        {

            if (AppSessions.RoleID == 4)
            {
                return AppSessions.StudentID;
            }
            else
            {
                return AppSessions.EmpolyeeID;
            }

        }

    }

    public static int RoleID
    {
        get
        {
            if (HttpContext.Current.Session["RoleID"] == null || Convert.ToInt32(HttpContext.Current.Session["RoleID"].ToString()) == 0)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(HttpContext.Current.Session["RoleID"].ToString());
            }
        }

        set
        {
            HttpContext.Current.Session["RoleID"] = value;
        }
    }

    public static string Role
    {
        get
        {
            if (HttpContext.Current.Session["Role"] == null || HttpContext.Current.Session["Role"].ToString() == string.Empty)
            {
                return string.Empty;
            }
            else
            {
                return HttpContext.Current.Session["Role"].ToString();
            }
        }

        set
        {
            HttpContext.Current.Session["Role"] = value;
        }
    }

    public static int EmpolyeeID
    {
        get
        {
            if (HttpContext.Current.Session["EmpolyeeID"] == null || Convert.ToInt32(HttpContext.Current.Session["EmpolyeeID"].ToString()) == 0)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(HttpContext.Current.Session["EmpolyeeID"].ToString());
            }
        }

        set
        {
            HttpContext.Current.Session["EmpolyeeID"] = value;
        }
    }

    public static int StudentID
    {
        get
        {
            if (HttpContext.Current.Session["StudentID"] == null || Convert.ToInt32(HttpContext.Current.Session["StudentID"].ToString()) == 0)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(HttpContext.Current.Session["StudentID"].ToString());
            }
        }

        set
        {
            HttpContext.Current.Session["StudentID"] = value;
        }
    }


    public static string UserName
    {
        get
        {
            if (HttpContext.Current.Session["UserName"] == null || HttpContext.Current.Session["UserName"].ToString() == string.Empty)
            {
                return string.Empty;
            }
            else
            {
                return HttpContext.Current.Session["UserName"].ToString();
            }
        }

        set
        {
            HttpContext.Current.Session["UserName"] = value;
        }
    }

    public static string LoginID
    {
        get
        {
            if (HttpContext.Current.Session["LoginID"] == null || HttpContext.Current.Session["LoginID"].ToString() == string.Empty)
            {
                return string.Empty;
            }
            else
            {
                return HttpContext.Current.Session["LoginID"].ToString();
            }
        }

        set
        {
            HttpContext.Current.Session["LoginID"] = value;
        }
    }

    public static string EmailID
    {
        get
        {
            if (HttpContext.Current.Session["EmailID"] == null || HttpContext.Current.Session["EmailID"].ToString() == string.Empty)
            {
                return string.Empty;
            }
            else
            {
                return HttpContext.Current.Session["EmailID"].ToString();
            }
        }

        set
        {
            HttpContext.Current.Session["EmailID"] = value;
        }
    }

    public static string SchoolName
    {
        get
        {
            if (HttpContext.Current.Session["SchoolName"] == null || HttpContext.Current.Session["SchoolName"].ToString() == string.Empty)
            {
                return string.Empty;
            }
            else
            {
                return HttpContext.Current.Session["SchoolName"].ToString();
            }
        }

        set
        {
            HttpContext.Current.Session["SchoolName"] = value;
        }
    }

    public static int BoardID
    {
        get
        {
            if (HttpContext.Current.Session["BoardID"] == null || Convert.ToInt32(HttpContext.Current.Session["BoardID"].ToString()) == 0)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(HttpContext.Current.Session["BoardID"].ToString());
            }
        }

        set
        {
            HttpContext.Current.Session["BoardID"] = value;
        }
    }


    public static string Board
    {
        get
        {
            if (HttpContext.Current.Session["Board"] == null || HttpContext.Current.Session["Board"].ToString() == string.Empty)
            {
                return string.Empty;
            }
            else
            {
                return HttpContext.Current.Session["Board"].ToString();
            }
        }

        set
        {
            HttpContext.Current.Session["Board"] = value;
        }
    }

    public static int MediumID
    {
        get
        {
            if (HttpContext.Current.Session["MediumID"] == null || Convert.ToInt32(HttpContext.Current.Session["MediumID"].ToString()) == 0)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(HttpContext.Current.Session["MediumID"].ToString());
            }
        }

        set
        {
            HttpContext.Current.Session["MediumID"] = value;
        }
    }

    public static string Medium
    {
        get
        {
            if (HttpContext.Current.Session["Medium"] == null || HttpContext.Current.Session["Medium"].ToString() == string.Empty)
            {
                return string.Empty;
            }
            else
            {
                return HttpContext.Current.Session["Medium"].ToString();
            }
        }

        set
        {
            HttpContext.Current.Session["Medium"] = value;
        }
    }

    public static int StandardID
    {
        get
        {
            if (HttpContext.Current.Session["StandardID"] == null || Convert.ToInt32(HttpContext.Current.Session["StandardID"].ToString()) == 0)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(HttpContext.Current.Session["StandardID"].ToString());
            }
        }

        set
        {
            HttpContext.Current.Session["StandardID"] = value;
        }
    }

    public static string Standard
    {
        get
        {
            if (HttpContext.Current.Session["Standard"] == null || HttpContext.Current.Session["Standard"].ToString() == string.Empty)
            {
                return string.Empty;
            }
            else
            {
                return HttpContext.Current.Session["Standard"].ToString();
            }
        }

        set
        {
            HttpContext.Current.Session["Standard"] = value;
        }
    }

    public static int SubjectID
    {
        get
        {
            if (HttpContext.Current.Session["SubjectID"] == null || Convert.ToInt32(HttpContext.Current.Session["SubjectID"].ToString()) == 0)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(HttpContext.Current.Session["SubjectID"].ToString());
            }
        }

        set
        {
            HttpContext.Current.Session["SubjectID"] = value;
        }
    }

    public static string Subject
    {
        get
        {
            if (HttpContext.Current.Session["Subject"] == null || HttpContext.Current.Session["Subject"].ToString() == string.Empty)
            {
                return string.Empty;
            }
            else
            {
                return HttpContext.Current.Session["Subject"].ToString();
            }
        }

        set
        {
            HttpContext.Current.Session["Subject"] = value;
        }
    }

    public static int DivisionID
    {
        get
        {
            if (HttpContext.Current.Session["DivisionID"] == null || Convert.ToInt32(HttpContext.Current.Session["DivisionID"].ToString()) == 0)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(HttpContext.Current.Session["DivisionID"].ToString());
            }
        }

        set
        {
            HttpContext.Current.Session["DivisionID"] = value;
        }
    }

    public static string Division
    {
        get
        {
            if (HttpContext.Current.Session["Division"] == null || HttpContext.Current.Session["Division"].ToString() == string.Empty)
            {
                return string.Empty;
            }
            else
            {
                return HttpContext.Current.Session["Division"].ToString();
            }
        }

        set
        {
            HttpContext.Current.Session["Division"] = value;
        }
    }

    public static int BMSID
    {
        get
        {
            if (HttpContext.Current.Session["BMSID"] == null || Convert.ToInt32(HttpContext.Current.Session["BMSID"].ToString()) == 0)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(HttpContext.Current.Session["BMSID"].ToString());
            }
        }

        set
        {
            HttpContext.Current.Session["BMSID"] = value;
        }
    }
    public static int BMSSCTID
    {
        get
        {
            if (HttpContext.Current.Session["BMSSCTID"] == null || Convert.ToInt32(HttpContext.Current.Session["BMSSCTID"].ToString()) == 0)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(HttpContext.Current.Session["BMSSCTID"].ToString());
            }
        }

        set
        {
            HttpContext.Current.Session["BMSSCTID"] = value;
        }
    }

    public static string BMS
    {
        get
        {
            if (HttpContext.Current.Session["BMSSDNameEduResource"] == null || HttpContext.Current.Session["BMSSDNameEduResource"].ToString() == string.Empty)
            {
                return string.Empty;
            }
            else
            {
                return HttpContext.Current.Session["BMSSDNameEduResource"].ToString();
            }
        }

        set
        {
            HttpContext.Current.Session["BMSSDNameEduResource"] = value;
        }
    }

    public static string AppUserType
    {
        get
        {
            if (HttpContext.Current.Session["AppUserType"] == null || HttpContext.Current.Session["AppUserType"].ToString() == string.Empty)
            {
                return string.Empty;
            }
            else
            {
                return HttpContext.Current.Session["AppUserType"].ToString();
            }
        }

        set
        {
            HttpContext.Current.Session["AppUserType"] = value;
        }
    }

    public static string SchoolIDRpt
    {
        get
        {

            if (HttpContext.Current.Session["SchoolIDRpt"] == null || HttpContext.Current.Session["SchoolIDRpt"].ToString() == string.Empty)
            {
                return string.Empty;
            }
            else
            {
                return HttpContext.Current.Session["SchoolIDRpt"].ToString();
            }

        }
        set { HttpContext.Current.Session["SchoolIDRpt"] = value; }
    }
    public static string BMSSCTIDRpt
    {

        get
        {
            if (HttpContext.Current.Session["BMSSCTIDRpt"] == null || HttpContext.Current.Session["BMSSCTIDRpt"].ToString() == string.Empty)
            {
                return string.Empty;
            }
            else
            {
                return HttpContext.Current.Session["BMSSCTIDRpt"].ToString();
            }

        }
        set { HttpContext.Current.Session["BMSSCTIDRpt"] = value; }
    }
    public static string DivisionIDRpt
    {
        get
        {
            if (HttpContext.Current.Session["DivisionIDRpt"] == null || HttpContext.Current.Session["DivisionIDRpt"].ToString() == string.Empty)
            {
                return string.Empty;
            }
            else
            {
                return HttpContext.Current.Session["DivisionIDRpt"].ToString();
            }

        }
        set { HttpContext.Current.Session["DivisionIDRpt"] = value; }
    }
    public static string ExamDateRpt
    {
        get
        {
            if (HttpContext.Current.Session["ExamDateRpt"] == null || HttpContext.Current.Session["ExamDateRpt"].ToString() == string.Empty)
            {
                return string.Empty;
            }
            else
            {
                return HttpContext.Current.Session["ExamDateRpt"].ToString();
            }


        }
        set { HttpContext.Current.Session["ExamDateRpt"] = value; }
    }
    public static string EmployeeIDRpt
    {
        get
        {
            if (HttpContext.Current.Session["EmployeeIDRpt"] == null || HttpContext.Current.Session["EmployeeIDRpt"].ToString() == string.Empty)
            {
                return string.Empty;
            }
            else
            {
                return HttpContext.Current.Session["EmployeeIDRpt"].ToString();
            }


        }
        set { HttpContext.Current.Session["EmployeeIDRpt"] = value; }
    }
    public static string StudentIDRpt
    {
        get
        {
            if (HttpContext.Current.Session["StudentIDRpt"] == null || HttpContext.Current.Session["StudentIDRpt"].ToString() == string.Empty)
            {
                return string.Empty;
            }
            else
            {
                return HttpContext.Current.Session["StudentIDRpt"].ToString();
            }

        }
        set { HttpContext.Current.Session["StudentIDRpt"] = value; }
    }
    public static bool IsAISProject
    {
        get
        {
            if (string.IsNullOrEmpty(Convert.ToString(HttpContext.Current.Session["IsAISProject"])))
            {
                return false;
            }
            else
            {
                return Convert.ToBoolean(HttpContext.Current.Session["IsAISProject"]);
            }
        }
        set { HttpContext.Current.Session["IsAISProject"] = value; }
    }
    public static bool IsAllowSendEmail
    {
        get
        {
            if (string.IsNullOrEmpty(Convert.ToString(HttpContext.Current.Session["IsAllowSendEmail"])))
            {
                return false;
            }
            else
            {
                return Convert.ToBoolean(HttpContext.Current.Session["IsAllowSendEmail"]);
            }
        }
        set { HttpContext.Current.Session["IsAllowSendEmail"] = value; }
    }

    public static string IsFreePackage
    {
        get
        {
            if (string.IsNullOrEmpty(Convert.ToString(HttpContext.Current.Session["IsFreePackage"])))
            {
                return string.Empty;
            }
            else
            {
                return HttpContext.Current.Session["IsFreePackage"].ToString();
            }
        }
        set { HttpContext.Current.Session["IsFreePackage"] = value; }
    }

    //public static bool IsAllowPackgeOffer
    //{
    //    get
    //    {
    //        if (HttpContext.Current.Session["IsAllowPackgeOffer"] == null || HttpContext.Current.Session["IsAllowPackgeOffer"].ToString() == string.Empty)
    //        {
    //            return false;
    //        }
    //        else
    //        {
    //            return Convert.ToBoolean(HttpContext.Current.Session["IsAllowPackgeOffer"].ToString());
    //        }
    //    }

    //    set
    //    {
    //        HttpContext.Current.Session["IsAllowPackgeOffer"] = value;
    //    }
    //}


}