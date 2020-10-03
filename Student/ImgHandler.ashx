<%@ WebHandler Language="C#" Class="ImgHandler" %>

using System;
using System.Web;

public class ImgHandler : IHttpHandler, System.Web.SessionState.IRequiresSessionState
{

    public void ProcessRequest(HttpContext context)
    {
        Byte[] imgByte = null;
        Student Student = new Student();
        Student_BLogic BAL_Student = new Student_BLogic();
        Student.studentid = AppSessions.StudentID;
        System.Data.DataSet dsSelect = new System.Data.DataSet();
        dsSelect = BAL_Student.BAL_Student_Select(Student, "SelectByID");
        if (dsSelect.Tables[0].Rows.Count > 0)
        {
            context.Response.ContentType = "image/jpg";
            try
            {
                imgByte = ((byte[])dsSelect.Tables[0].Rows[0]["Picture"]);
                context.Response.BinaryWrite(imgByte);
            }
            catch
            {
                string imgpath = System.IO.Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/App_Themes/Green/Images"), "nophoto.png");
                imgByte = System.IO.File.ReadAllBytes(imgpath);
                context.Response.BinaryWrite(imgByte);
            }
        }
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}