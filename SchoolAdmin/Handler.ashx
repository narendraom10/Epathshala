<%@ WebHandler Language="C#" Class="Handler" %>

using System;
using System.Web;
using System.IO;
public class Handler : IHttpHandler
{


    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "application/jpeg";
        context.Response.Cache.SetCacheability(HttpCacheability.Public);
        context.Response.BufferOutput = false;

        string EMP_ID;
        Stream stream = null;

        if (context.Request.QueryString["EmployeeID"] != null || context.Request.QueryString["EmployeeID"] != "")
        {
            EMP_ID = Convert.ToString(context.Request.QueryString["EmployeeID"]);
            stream = GetImage(EMP_ID);

        }
        const int buffersize = 2048 * 32;
        byte[] buffer = new byte[buffersize];
        int count = stream.Read(buffer, 0, buffersize);
        while (count > 0)
        {
            context.Response.OutputStream.Write(buffer, 0, count);
            count = stream.Read(buffer, 0, buffersize);
        }
        ////return count;
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
    public Stream GetImage(string EMPID)
    {
        string queryString = "Select Image from Employee where EmployeeID = '" + EMPID + "'";
        return (executeScalar(queryString));
    }
    public Stream executeScalar(string querystr1)
    {
        System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection();
        conn.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["EpathshalaCon"];
        System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(querystr1, conn);
        conn.Open();
        object result = cmd.ExecuteScalar();
        try
        {
            return new MemoryStream((byte[])result);
        }
        catch
        {
            return null;
        }
        finally
        {

        }
    }

}