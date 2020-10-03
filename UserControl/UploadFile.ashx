<%@ WebHandler Language="C#" Class="UploadFile" %>

using System;
using System.Web;

public class UploadFile : IHttpHandler
{
    public void ProcessRequest(HttpContext context)
    {
        string fileName = string.Empty;
        string path = string.Empty;

        if (context.Request.Files.Count > 0)
        {
            HttpPostedFile file = context.Request.Files[0];
            if (file.ContentLength > 0)
            {
                fileName = System.IO.Path.GetFileName(file.FileName);
                path = System.IO.Path.Combine(context.Server.MapPath("~\\Documents\\Attachment"), fileName);
                file.SaveAs(path);
            }
        }
        var response = "{\"filename\":\"" + fileName + "\",\"filepath\":\"" + path.Replace("\\", "\\\\") + "\"}";
        context.Response.ContentType = "text/plain";
        context.Response.Write(response);
    }
    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
}