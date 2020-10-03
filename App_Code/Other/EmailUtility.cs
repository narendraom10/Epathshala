/// <summary>
/// <DevelopedBy>"Arpit Patel"</DevelopedBy>
/// </summary>
using System;
using System.Collections;
using System.Data;
using System.Net.Mail;
using System.Web;

public class EmailUtility
{
    DataAccess DAL_SYS_Topic;
    ArrayList arrParameter;
    System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();

    /// <summary>
    /// Gets or sets smtp port number.
    /// </summary>
    public static int SMTPPORT
    {
        get
        {
            if (HttpContext.Current.Application["SMTP_Port"] == null || Convert.ToInt32(HttpContext.Current.Application["SMTP_Port"].ToString()) == 0)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(HttpContext.Current.Application["SMTP_Port"].ToString());
            }
        }

        set
        {
            HttpContext.Current.Application["SMTP_Port"] = value;
        }
    }

    /// <summary>
    /// Gets or sets smtp host address.
    /// </summary>
    public static string SMTPHOST
    {
        get
        {
            if (HttpContext.Current.Application["SMTP_Host"] == null || HttpContext.Current.Application["SMTP_Host"] == string.Empty)
            {
                return string.Empty;
            }
            else
            {
                return HttpContext.Current.Application["SMTP_Host"].ToString();
            }
        }

        set
        {
            HttpContext.Current.Application["SMTP_Host"] = value;
        }
    }

    /// <summary>
    /// Gets or sets smtp email address.
    /// </summary>
    public static string SMTPEmailAddress
    {
        get
        {
            if (HttpContext.Current.Application["SMTPEmailAddress"] == null || HttpContext.Current.Application["SMTPEmailAddress"] == string.Empty)
            {
                return string.Empty;
            }
            else
            {
                return HttpContext.Current.Application["SMTPEmailAddress"].ToString();
            }
        }

        set
        {
            HttpContext.Current.Application["SMTPEmailAddress"] = value;
        }
    }

    /// <summary>
    /// Gets or sets smtp username.
    /// </summary>
    public static string USERNAME
    {
        get
        {
            if (HttpContext.Current.Application["USERNAME"] == null || HttpContext.Current.Application["USERNAME"] == string.Empty)
            {
                return string.Empty;
            }
            else
            {
                return HttpContext.Current.Application["USERNAME"].ToString();
            }
        }

        set
        {
            HttpContext.Current.Application["USERNAME"] = value;
        }
    }

    /// <summary>
    /// Gets or sets  smtp password.
    /// </summary>
    public static string PASSWORD
    {
        get
        {
            if (HttpContext.Current.Application["Password"] == null || HttpContext.Current.Application["Password"] == string.Empty)
            {
                return string.Empty;
            }
            else
            {
                return HttpContext.Current.Application["Password"].ToString();
            }
        }

        set
        {
            HttpContext.Current.Application["Password"] = value;
        }
    }

    /// <summary>
    /// Gets or sets EnableSSL value.
    /// </summary>
    public static bool EnableSSL
    {
        get
        {
            if (HttpContext.Current.Application["EnableSSl"] == null || HttpContext.Current.Application["EnableSSl"].ToString() == string.Empty)
            {
                return false;
            }
            else
            {
                return Convert.ToBoolean(HttpContext.Current.Application["EnableSSl"]);
            }
        }

        set
        {
            HttpContext.Current.Application["EnableSSl"] = value;
        }
    }

    /// <summary>
    /// GetEmailSettings method will be used to get the email settings from database.
    /// </summary>
    public static void GetEmailSettings()
    {
        DataTable dt = new DataTable();
        DataAccess DAL_SYS_Topic = new DataAccess();
        ArrayList arrParameter = new ArrayList();
        try
        {
            dt = DAL_SYS_Topic.DAL_Select("Proc_Get_Sys_Cofig_Data", arrParameter).Tables[0];

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["Field"].ToString() == EnumFile.SMTP.SMTPHOST.ToString())
                    {
                        SMTPHOST = dt.Rows[i]["value"].ToString();
                    }
                    else if (dt.Rows[i]["Field"].ToString() == EnumFile.SMTP.SMTPPORT.ToString())
                    {
                        SMTPPORT = Convert.ToInt32(dt.Rows[i]["value"].ToString());
                    }
                    else if (dt.Rows[i]["Field"].ToString() == EnumFile.SMTP.SMTPEmailAddress.ToString())
                    {
                        SMTPEmailAddress = dt.Rows[i]["value"].ToString();
                    }
                    else if (dt.Rows[i]["Field"].ToString() == EnumFile.SMTP.PASSWORD.ToString())
                    {
                        PASSWORD = dt.Rows[i]["value"].ToString();
                    }
                    else if (dt.Rows[i]["Field"].ToString() == EnumFile.SMTP.ENABLESSL.ToString())
                    {
                        EnableSSL = (dt.Rows[i]["value"].ToString() == "0") ? false : true;
                    }
                    else if (dt.Rows[i]["Field"].ToString() == EnumFile.SMTP.USERNAME.ToString())
                    {
                        USERNAME = dt.Rows[i]["value"].ToString();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /// <summary>
    /// SendEmail method will be used to send email.
    /// </summary>
    /// <param name="aListEmailTo">User List</param>
    /// <param name="Subject">Email subject</param>
    /// <param name="Body"> Email body</param>
    /// <param name="aListAttachments">Email attachment</param>
    /// <param name="bodyHtml">Is email contain html body</param>
    /// <returns>Return true or false</returns>
    public static bool SendEmail(ArrayList aListEmailTo, string Subject, string Body, ArrayList aListAttachments = null, bool bodyHtml = true)
    {
        try
        {
            System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
            for (int i = 0; i < aListEmailTo.Count; i++)
            {
                msg.To.Add(aListEmailTo[i].ToString());
            }

            msg.From = new MailAddress(SMTPEmailAddress, USERNAME);
            msg.IsBodyHtml = bodyHtml;
            msg.Subject = Subject;
            msg.Body = Body;

            if (aListAttachments != null)
            {
                for (int i = 0; i < aListAttachments.Count; i++)
                {
                    Attachment at = new Attachment(aListAttachments[i].ToString());
                    msg.Attachments.Add(at);
                }
            }

            SmtpClient objMail = new SmtpClient();
            objMail.Host = SMTPHOST;
            objMail.Port = SMTPPORT;
            objMail.Credentials = new System.Net.NetworkCredential(SMTPEmailAddress, PASSWORD);
            objMail.DeliveryMethod = SmtpDeliveryMethod.Network;
            objMail.EnableSsl = EnableSSL;
            objMail.Send(msg);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    /// <summary>
    /// Method will be used to get SMTP Email settings data.
    /// </summary>
    /// <returns>Data table return</returns>
    public DataTable GetSMTPData()
    {
        DataTable dt = new DataTable();
        this.DAL_SYS_Topic = new DataAccess();
        this.arrParameter = new ArrayList();
        dt = this.DAL_SYS_Topic.DAL_Select("Proc_Get_Sys_Cofig_Data", this.arrParameter).Tables[0];
        return dt;
    }

    /// <summary>
    /// Method will be used to update email server config.
    /// </summary>
    /// <param name="Host">SMTP Host address</param>
    /// <param name="Port">SMTP Port number</param>
    /// <param name="Username">SMTP Username</param>
    /// <param name="Password">SMTP Password</param>
    /// <param name="EnableSSl">Is Server require SSL</param>
    public void Update_ServerConfig(string Host, string Port, string Username, string EmailAddress, string Password, string EnableSSl)
    {
        this.DAL_SYS_Topic = new DataAccess();
        this.arrParameter = new ArrayList();
        this.arrParameter.Add(new parameter("SmtpHost", Host));
        this.arrParameter.Add(new parameter("Port", Port));
        this.arrParameter.Add(new parameter("EmailAddress", EmailAddress));
        this.arrParameter.Add(new parameter("Username", Username));
        this.arrParameter.Add(new parameter("Password", Password));
        this.arrParameter.Add(new parameter("EnableSsl", EnableSSl));
        this.DAL_SYS_Topic.DAL_InsertUpdate("PROC_Update_Server_Config", this.arrParameter);
    }

    /// <summary>
    /// SendEmail method will be used to send email.
    /// </summary>
    /// <param name="aListEmailTo">User List</param>
    /// <param name="Subject">Email subject</param>
    /// <param name="Body"> Email body</param>
    /// <param name="aListAttachments">Email attachment</param>
    /// <param name="bodyHtml">Is email contain html body</param>
    /// <returns>Return true or false And Reason if send fail.</returns>
    public static bool SendEmail(ArrayList aListEmailTo, string Subject, string Body, out string FailiurReason, ArrayList aListAttachments = null, bool bodyHtml = true)
    {
        try
        {
            FailiurReason = string.Empty;
            System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
            for (int i = 0; i < aListEmailTo.Count; i++)
            {
                msg.To.Add(aListEmailTo[i].ToString());
            }

            msg.From = new MailAddress(SMTPEmailAddress, USERNAME);
            msg.IsBodyHtml = bodyHtml;
            msg.Subject = Subject;
            msg.Body = Body;

            if (aListAttachments != null)
            {
                for (int i = 0; i < aListAttachments.Count; i++)
                {
                    Attachment at = new Attachment(aListAttachments[i].ToString());
                    msg.Attachments.Add(at);
                }
            }

            SmtpClient objMail = new SmtpClient();
            objMail.Host = SMTPHOST;
            objMail.Port = SMTPPORT;
            objMail.Credentials = new System.Net.NetworkCredential(SMTPEmailAddress, PASSWORD);
            objMail.DeliveryMethod = SmtpDeliveryMethod.Network;
            objMail.EnableSsl = EnableSSL;
            objMail.Send(msg);
            return true;
        }
        catch (Exception ex)
        {
            FailiurReason = ex.ToString();
            return false;
        }
    }
}