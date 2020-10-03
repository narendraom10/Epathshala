using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using Udev.UserMasterPage.Classes;
using System.Collections;

public partial class Blank : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {

                ddlLanguage12.SelectedValue = Session["LANG"].ToString();
                if (Session["UserName"] != null || Session["UserName"] != "")
                {
                    //lblWelcome.Text = 
                    lblWelcome.Text = Session["UserName"].ToString();

                    if (AppSessions.AppUserType != "Student")
                    {
                        lblschool.Visible = true;
                        lblSchoolName.Text = lblSchoolName.Text + " " + Session["SchoolName"].ToString();
                        lblUserType.Visible = true;
                        lblUserType.Text = lblUserType.Text + " " + AppSessions.Role;
                    }
                }
            }
            catch (Exception)
            {
                Response.Redirect("~/Login.aspx");
            }
        }
    }

    protected void lbtnSignOut_Click(object sender, EventArgs e)
    {
        Hashtable sessions = (Hashtable)Application["WEB_SESSIONS_OBJECT"];
        if (sessions == null)
        {
            sessions = new Hashtable();
        }

        if (Session["EmpolyeeID"] != null)
        {
            sessions.Remove(Session["EmpolyeeID"].ToString());
        }

        if (Session["StudentID"] != null)
        {
            sessions.Remove(Session["StudentID"].ToString());
        }

        Application.Lock();
        Application["WEB_SESSIONS_OBJECT"] = sessions;
        Application.UnLock();

        TrackLog_Utils.Log(Convert.ToInt32(AppSessions.SchoolID), Convert.ToInt32(AppSessions.EmpolyeeID), Convert.ToInt16(AppSessions.DivisionID), "LogoutPage", "btnLogout", "Click", Convert.ToDateTime(System.DateTime.Now), HttpContext.Current.Session.SessionID, StringEnum.stringValueOf(EnumFile.Activity.LogoutSuccess), "LoginId : " + Session["UserName"].ToString(), 0);

        HttpContext.Current.Session.Clear();
        HttpContext.Current.Session.Abandon();

        Response.Redirect("..\\Login.aspx");
    }
    protected void ddlLanguage12_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlLanguage12.SelectedValue.ToString().Equals("En"))
            {
                Session["LANG"] = ddlLanguage12.SelectedValue;
                Session["langid"] = ((int)EnumFile.Language.English).ToString();
            }
            else if (ddlLanguage12.SelectedValue.ToString().Equals("Gu"))
            {
                Session["LANG"] = ddlLanguage12.SelectedValue;
                Session["langid"] = ((int)EnumFile.Language.Gujarati).ToString();
            }
            else if (ddlLanguage12.SelectedValue.ToString().Equals("Hi"))
            {
                Session["LANG"] = ddlLanguage12.SelectedValue;
                Session["langid"] = ((int)EnumFile.Language.Hindi).ToString();
            }
            Session[Global.SESSION_KEY_CULTURE] = ddlLanguage12.SelectedValue;
            Session["LANG"] = ddlLanguage12.SelectedValue;

            System.Threading.Thread.CurrentThread.CurrentCulture =
               CultureInfo.CreateSpecificCulture(Session["LANG"].ToString());
            System.Threading.Thread.CurrentThread.CurrentUICulture = new
            CultureInfo(ddlLanguage12.SelectedValue);

            //Response.Redirect(Request.ServerVariables["SCRIPT_NAME"].ToString());
            Response.Redirect(Request.Url.AbsoluteUri);
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }
}
