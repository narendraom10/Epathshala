///<Summary>
///</Summary>

using System;
using System.Data;
using System.Globalization;
using Udev.UserMasterPage.Classes;

public partial class Utility_ManageServerConfig : System.Web.UI.Page
{
    #region "Declarations"

    EmailUtility Eu = new EmailUtility();

    #endregion

    # region Properties
    # endregion

    #region "Page Events"
    protected override void InitializeCulture()
    {
        string culture = Convert.ToString(Session[Global.SESSION_KEY_CULTURE]);
        //// 'set culture to current thread 
        System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture);
        System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);
        ////call base class 
        base.InitializeCulture();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            this.GetData();
        }
    }

    #endregion

    #region "Control Events"
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            string Host = txtHost.Text;
            string Port = txtPort.Text;
            string Username = txtUserName.Text;
            string Password = txtPassword.Text;
            string EnableSSl = string.Empty;
            string EmailAddress = txtEmailAddress.Text;
            if (ddlEnableSSl.SelectedValue == "0")
            {
                EnableSSl = "0";
            }
            else if (ddlEnableSSl.SelectedValue == "1")
            {
                EnableSSl = "1";
            }

            this.Eu.Update_ServerConfig(Host, Port, Username, EmailAddress, Password, EnableSSl);
            this.GetData();
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }
    #endregion

    #region "User defined functions"
    protected void GetData()
    {
        try
        {
            DataTable dt = new DataTable();
            dt = this.Eu.GetSMTPData();

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["Field"].ToString() == EnumFile.SMTP.SMTPHOST.ToString())
                    {
                        txtHost.Text = dt.Rows[i]["value"].ToString();
                    }
                    else if (dt.Rows[i]["Field"].ToString() == EnumFile.SMTP.SMTPPORT.ToString())
                    {
                        txtPort.Text = dt.Rows[i]["value"].ToString();
                    }
                    else if (dt.Rows[i]["Field"].ToString() == EnumFile.SMTP.SMTPEmailAddress.ToString())
                    {
                        txtEmailAddress.Text = dt.Rows[i]["value"].ToString();
                    }
                    else if (dt.Rows[i]["Field"].ToString() == EnumFile.SMTP.PASSWORD.ToString())
                    {
                        txtPassword.Text = dt.Rows[i]["value"].ToString();
                    }
                    else if (dt.Rows[i]["Field"].ToString() == EnumFile.SMTP.ENABLESSL.ToString())
                    {
                        ddlEnableSSl.SelectedValue = (dt.Rows[i]["value"].ToString() == "0") ? "0" : "1";
                    }
                    else if (dt.Rows[i]["Field"].ToString() == EnumFile.SMTP.USERNAME.ToString())
                    {
                        txtUserName.Text = dt.Rows[i]["value"].ToString();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }
    #endregion
}