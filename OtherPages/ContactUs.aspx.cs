using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Text;

public partial class OtherPages_ContactUs : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnsubmitquery_Click(object sender, EventArgs e)
    {
        ArrayList MailTo = new ArrayList();
        MailTo.Add("info@epath.net.in");
        MailTo.Add("shailesh.vaishnav@epath.net.in");
        MailTo.Add("rahul.kashyap@epath.net.in");
        bool IssendSuccess = EmailUtility.SendEmail(MailTo, GetMailSubject(), GetMailBody(name.Value, email.Value, phone.Value, comment.Value));
        if (IssendSuccess)
            Response.Write("<script>alert('Thank you for getting in touch with us. We will reach out to you soon');</script>");
        else
            Response.Write("<script>alert('Sorry, we are not able to process your request at this time, Please try again later.');</script>");

    }

    private string GetMailBody(string name, string email, string phone, string comment)
    {
        StringBuilder oBuilder = new StringBuilder();
        oBuilder.Append("<div style='width: 700px; background-color: #71af32; padding:10px 0px 10px 10px; font-weight: bold;'>Query From ContactUs Page</div>");
        oBuilder.Append("<div style='width: 700px; background-color: #fff; padding:20px 0px 20px 8px; border: 1px solid #71af32;font-weight: bold;'>");
        oBuilder.Append("<table border='0' cellpadding='0' cellspacing='0'>");
        oBuilder.Append("<tr style='height:30px;'>");
        oBuilder.Append("<td style='width: 100px; text-align: right; padding-right: 10px;'>");
        oBuilder.Append("Name:");
        oBuilder.Append("</td>");
        oBuilder.Append("<td>");
        oBuilder.Append(name);
        oBuilder.Append("</td>");
        oBuilder.Append("</tr>");
        oBuilder.Append("<tr style='height:30px;'>");
        oBuilder.Append("<td style='width: 100px; text-align: right; padding-right: 10px;'>");
        oBuilder.Append("Email:");
        oBuilder.Append("</td>");
        oBuilder.Append("<td>");
        oBuilder.Append(email);
        oBuilder.Append("</td>");
        oBuilder.Append("</tr>");
        oBuilder.Append("<tr style='height:30px;'>");
        oBuilder.Append("<td style='width: 100px; text-align: right; padding-right: 10px;'>");
        oBuilder.Append("Phone:");
        oBuilder.Append("</td>");
        oBuilder.Append("<td>");
        oBuilder.Append(phone);
        oBuilder.Append("</td>");
        oBuilder.Append("</tr>");
        oBuilder.Append("<tr style='height:30px;'>");
        oBuilder.Append("<td style='width: 100px; text-align: right; padding-right: 10px; vertical-align: top;'>");
        oBuilder.Append("Comment:");
        oBuilder.Append("</td>");
        oBuilder.Append("<td style='vertical-align: top;'>");
        oBuilder.Append(comment);
        oBuilder.Append("</td>");
        oBuilder.Append("</tr>");
        oBuilder.Append("</table>");
        oBuilder.Append("</div>");

        return Convert.ToString(oBuilder);
    }
    public string GetMailSubject()
    {
        return "Query From ContactUs page: " + DateTime.Now.ToString("dd MMM, yyyy");
    }
}