using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;


public partial class NewPublic_forgotpassword : System.Web.UI.Page
{
    SYS_Role obj_SYS_Role;
    SYS_Role_BLogic obj_BAL_SYS_Role;
    StudentDash StudentDash;
    Student_DashBoard_BLogic BLogic_Student;
    Employee OEmployee;
    Teacher_Dashboard_BLogic BAL_Forgetpassword;
    protected void Page_PreInit(object sender, EventArgs e)
    {
        //Page.StyleSheetTheme = "";
        Page.Theme = "";
    }

    protected void BttnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet ds = new DataSet();
            OEmployee = new Employee();
            BAL_Forgetpassword = new Teacher_Dashboard_BLogic();
            OEmployee.emailid = uctxtEmail.Text;
            ArrayList arrParameter = new ArrayList();
            string subjectEmail = "Login Information";
            arrParameter.Add(uctxtEmail.Text);
            ds = BAL_Forgetpassword.BAL_Emailid_Select(OEmployee);
            ViewState["PasswordData"] = ds;
            if (ds.Tables.Count > 0 & ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (EmailUtility.SendEmail(arrParameter, subjectEmail, GenerateMailBodyForgetPassword()))
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Password has been sent to your email successfully.');window.location ='Login.aspx';", true);
                        ClearControls();
                    }
                    else
                    {
                        WebMsg.Show("Email Failed");
                        ClearControls();
                    }
                }
                else if (ds.Tables[1].Rows.Count > 0)
                {
                    if (EmailUtility.SendEmail(arrParameter, subjectEmail, GenerateEmailBody()))
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Password has been sent to your email successfully.');window.location ='Login.aspx';", true);
                        ClearControls();
                    }
                    else
                    {
                        WebMsg.Show("Email Failed");
                        ClearControls();
                    }
                }
                else
                {
                    WebMsg.Show("Invalid Email");
                    ClearControls();
                }
            }
            else
            {
                WebMsg.Show("Invalid Email");
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }
    protected void ClearControls()
    {
        try
        {
            uctxtEmail.Text = string.Empty;
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }
    protected void btncancel_click(object sender, EventArgs e)
    {
        Response.Redirect("login.aspx");
    }

    protected string GenerateEmailBody()
    {
        DataSet ds = new DataSet();
        string Body = string.Empty;
        ds = (DataSet)ViewState["PasswordData"];
        try
        {
            string Pwd = ds.Tables[0].Rows[0]["Password"].ToString();
            string Name = ds.Tables[0].Rows[0]["FirstName"].ToString() + " " + ds.Tables[0].Rows[0]["LastName"].ToString();
            char[] separator = new char[] { '@' };
            //string[] strSplitArr = uctxtEmail.Text.Split(separator);
            // string username = strSplitArr[0];

            Body = "<b>Hello &nbsp;" + Name + ",<b/><br/><br/>";

            Body += "<b>Date:<b/>" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "<br/";
            //Body += "<b>Email:<b/>" + uctxtEmail.Text + "<br/>";
            Body += "<b>Password:<b/>" + Pwd + "<br/><br/><br/>";

            Body += "<b>Thank You,<b/><br/>";
            Body += "<b>" + EmailUtility.USERNAME + "<b/>";
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
        return Body;
    }

    protected string GenerateMailBodyForgetPassword()
    {
        string filename = AppDomain.CurrentDomain.BaseDirectory + "\\Mail Template\\ForgetPassword.txt";
        string MailFormat = System.IO.File.ReadAllText(filename);
        DataSet ds = new DataSet();
        string Body = string.Empty;
        ds = (DataSet)ViewState["PasswordData"];
        try
        {
            string Pwd = ds.Tables[0].Rows[0]["Password"].ToString();
            string Name = ds.Tables[0].Rows[0]["FirstName"].ToString() + " " + ds.Tables[0].Rows[0]["LastName"].ToString();
            Body = MailFormat;
            Body = Body.Replace("#username", Name);
            Body = Body.Replace("#loginid", uctxtEmail.Text);
            Body = Body.Replace("#password", Pwd);
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }

        return Body;
    }
}