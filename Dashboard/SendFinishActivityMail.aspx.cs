using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Collections;

public partial class Dashboard_SendFinishActivityMail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        stdlist.Subject = "Today Activity Alert";
        stdlist.BMSID = AppSessions.BMSID;
        stdlist.DivisionID = AppSessions.DivisionID;
        stdlist.SchoolID = AppSessions.SchoolID;
        stdlist.PageTitle = "Finish Activity Mail";

        //ArrayList array = new ArrayList();
        //array.Add("d:\\Attachment01.pdf");
        //array.Add("d:\\Attachment02.pdf");
        //array.Add("d:\\Attachment03.gif");
        //stdlist.Attachment = array;

        StringBuilder oBuilder = new StringBuilder();

        oBuilder.Append("<!DOCTYPE html><html><head><title>Finish Activity</title></head><body>");
        oBuilder.Append("<div style='border: 0px Solid #F0F0F0; background-color: #f9f9f9;margin: 10px; font-family: Cambria,Calibri,Times New Roman; font-size: medium;  box-shadow: 0px 0px 4px #909090;border-top: 8px Solid #522675;border-bottom: 4px Solid #522675;'>");
        oBuilder.Append("<div style='background-color:#F0F0F0  ;height:70px;'><div class='logo' style='text-align: center;color:#80262e;padding:20px;'>");
        oBuilder.Append("<h3 style='margin:0;'>#SCHOOLNAME#</h3>");
        oBuilder.Append("</div></div>");
        oBuilder.Append("<div style='border-bottom: 3px Solid #E8E8E8; padding: 20px; border-top: 2px Solid #522675;color: #909090;'>");
        oBuilder.Append("<p>Dear Parent,<br /><br />Today chapter \"#CHAPTER#\" of subject \"#SUBJECT#\" has been completed in class \"#STANDARD#\" at #TIME#.<br /><br /><br /><br />Best Regards,<br />#USERNAME#.</p>");
        oBuilder.Append("</div></div>");
        oBuilder.Append("</body></html>");

        oBuilder.Replace("#SCHOOLNAME#", AppSessions.SchoolName);
        oBuilder.Replace("#CHAPTER#", Convert.ToString(Session["Chapter"]));
        oBuilder.Replace("#SUBJECT#", AppSessions.Subject);

        string[] standard = AppSessions.Board.Split(new string[] { ">>" }, StringSplitOptions.RemoveEmptyEntries);

        oBuilder.Replace("#STANDARD#", standard[2].Trim() + " - " + AppSessions.Division);
        oBuilder.Replace("#TIME#", DateTime.Now.ToString("hh:mm tt"));
        oBuilder.Replace("#USERNAME#", AppSessions.UserName);

        stdlist.MailBody = oBuilder.ToString();
    }
}