using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Udev.UserMasterPage.Classes;
using System.Web.UI;
using System.Web;
using System.Web.Services;
using System.Text.RegularExpressions;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Globalization;
using Udev.UserMasterPage.Classes;
using System.Collections;
using System.Web.Configuration;


public partial class NewPublic_materialMaster : System.Web.UI.MasterPage
{
    Student_DashBoard_BLogic obj_BAL_Student_Dashboard;
    StudentDash obj_Student_Dashboard;
    public string board, medium, standard,subject;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (AppSessions.RoleID != 0)
        {
            switch (AppSessions.RoleID)
            {
                case (int)EnumFile.Role.Student:
                    Mv_RolewiseMenus.ActiveViewIndex = 0;
                     
                     board=  AppSessions.Board.ToString();
                     medium =  AppSessions.Medium.ToString();
                    standard = AppSessions.Standard.ToString();
                    break;

                default:
                    break;
            }
            // GetStudentDetailBMS();

        }

        else
        {
            if (AppSessions.RoleID == null && AppSessions.RoleID == 0)
            { }


        }
    }

    public static DataTable dtSubjects;


    protected void lbtnSignOut_Click(object sender, EventArgs e)
    {
        //    // Hashtable sessions = (Hashtable)Application["WEB_SESSIONS_OBJECT"];
        //    //if (sessions == null)
        //    //{
        //    //    sessions = new Hashtable();
        //    //}

        //    if (Session["EmpolyeeID"] != null)
        //    {
        //        sessions.Remove(Session["EmpolyeeID"].ToString());
        //    }

        //    if (Session["StudentID"] != null)
        //    {
        //        sessions.Remove(Session["StudentID"].ToString());
        //    }

        //    Application.Lock();
        //    Application["WEB_SESSIONS_OBJECT"] = sessions;
        //    Application.UnLock();

        //    TrackLog_Utils.Log(Convert.ToInt32(AppSessions.SchoolID), Convert.ToInt32(AppSessions.EmpolyeeID), Convert.ToInt16(AppSessions.DivisionID), "LogoutPage", "btnLogout", "Click", Convert.ToDateTime(System.DateTime.Now), HttpContext.Current.Session.SessionID, StringEnum.stringValueOf(EnumFile.Activity.LogoutSuccess), "LoginId : " + Session["UserName"].ToString(), 0);

        //    HttpContext.Current.Session.Clear();
        //    HttpContext.Current.Session.Abandon();

        Session["StudentID"] = null;
        //    Session["EmpolyeeID"] = null;
        //    //Response.Redirect("../OtherPages/Login.aspx");
        //    //Response.Redirect("../OtherPages/Landing.aspx");
        Response.Redirect("../NewPublic/UserLogin.aspx");

    }
    
    public void logout_click()
    {
        HttpContext.Current.Session.Clear();
        Response.Redirect("../NewPublic/UserLogin.aspx");
    }

}