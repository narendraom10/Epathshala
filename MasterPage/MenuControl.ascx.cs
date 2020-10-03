/// <summary> 
/// <DevelopedBy>"NARENDRASINH"</DevelopedBy>
/// <DevelopedDate></DevelopedDate>
/// <UpdatedBy>"SOFTWARE TEAM ALL MEMBERS"</UpdatedBy>
/// <UpdatedDate></UpdatedDate>
/// </summary>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class MenuControl : System.Web.UI.UserControl
{
    # region variables
    # endregion

    # region Properties
    # endregion

    # region Page events
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["RoleID"] != null || Convert.ToString(Session["RoleID"]) != string.Empty)
            {
                if (Session["RoleID"].ToString() == Convert.ToString((int)EnumFile.Role.E_Admin))
                {
                    //EAdmin
                    MenuCtrl.ActiveViewIndex = Convert.ToInt32(EnumFile.AssignValue.Zero);
                }
                else if (Session["RoleID"].ToString() == Convert.ToString((int)EnumFile.Role.S_Admin))
                {
                    //SAdmin
                    MenuCtrl.ActiveViewIndex = Convert.ToInt32(EnumFile.AssignValue.One);
                }
                else if (Session["RoleID"].ToString() == Convert.ToString((int)EnumFile.Role.Teacher))
                {
                    //SAdmin
                    MenuCtrl.ActiveViewIndex = Convert.ToInt32(EnumFile.AssignValue.Two);
                }
                else if (Session["RoleID"].ToString() == Convert.ToString((int)EnumFile.Role.Student))
                {
                    //Student
                    if (AppSessions.AppUserType == "PStudent")
                    {
                        //Parent
                        MenuCtrl.ActiveViewIndex = Convert.ToInt32(EnumFile.AssignValue.Four);

                    }
                    else
                    {
                        MenuCtrl.ActiveViewIndex = Convert.ToInt32(EnumFile.AssignValue.Three);
                    }

                    if (Session["ShowPaymentPages"] != null)
                    {
                        liStudentPackage.Visible = false;
                        liSelectPackage.Visible = false;
                        liReport.Visible = false;
                    }

                }

                if (AppSessions.IsAISProject)
                {
                    //liStudentList.Visible = false;
                    liReschedulingChapterTopic.Visible = false;
                    liExam.Visible = false;
                    liTeacherNotes.Visible = false;
                }
                else
                {
                    //liStudentList.Visible = true;
                    liReschedulingChapterTopic.Visible = true;
                    liExam.Visible = true;
                    liTeacherNotes.Visible = true;
                }
            }
            else
            {
                Response.Redirect("~/Index.aspx");
            }
        }
        catch (Exception ex)
        {

            Response.Redirect("~/Index.aspx");
        }
    }
    # endregion

    # region Control events
    # endregion

    # region User defined functions
    # endregion
}