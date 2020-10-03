<%@ WebHandler Language="C#" Class="SecurityHandler" %>

using System;
using System.Web;
using System.Data;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.IO;


//[WebService(Namespace = "http://tempuri.org/")]
//[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class SecurityHandler : IHttpHandler, System.Web.SessionState.IReadOnlySessionState
{
    public void ProcessRequest(HttpContext context)
    {
        using (System.IO.FileStream fs = new System.IO.FileStream(context.Server.MapPath(context.Session["ContentPath"].ToString()), FileMode.Open, FileAccess.Read))
        {
            WriteDataToOutputStream(fs, fs.Length, context.Server.MapPath(context.Session["ContentPath"].ToString()), context);
        }
    }


    protected void PrepareResponseStream(string clientFileName, HttpContext context, long sourceStreamLength)
    {
        context.Response.ClearHeaders();
        context.Response.Clear();
        context.Response.ContentType = Convert.ToString(context.Session["ContentType"]);
        context.Response.AddHeader("Content-Disposition", string.Format("filename=\"{0}\"", clientFileName));
        context.Response.Cache.SetCacheability(HttpCacheability.Private);
        context.Response.Buffer = false;
        context.Response.BufferOutput = false;
        context.Response.AddHeader("Content-Length", sourceStreamLength.ToString(System.Globalization.CultureInfo.InvariantCulture));
    }

    protected void WriteDataToOutputStream(Stream sourceStream, long sourceStreamLength, string clientFileName, HttpContext context)
    {
        try
        {
            PrepareResponseStream(clientFileName, context, sourceStreamLength);
            const int BlockSize = 4 * 1024 * 1024;
            //const int BlockSize = 4 * 1024 ;
            byte[] buffer;
            int bytesRead;

            Stream outStream = context.Response.OutputStream;

            buffer = new byte[BlockSize];
            while ((bytesRead = sourceStream.Read(buffer, 0, BlockSize)) > 0)
            {
                Teacher_Dashboard_BLogic obj_BAL_Teacher_Dashboard = new Teacher_Dashboard_BLogic();
                DataSet dsSettings = new DataSet();
                dsSettings = obj_BAL_Teacher_Dashboard.BAL_Select_CoveredUncoverChapterTopic_Settings("UseEncrytion");
                bool IsEncryption = Convert.ToBoolean(dsSettings.Tables[0].Rows[0]["value"].ToString());
                if (IsEncryption)
                {
                    byte[] intRc = new byte[501];
                    for (int j = 0; j <= 500; j++)
                    {
                        intRc[j] = buffer[j];
                    }

                    for (int i = 0; i <= 500; i++)
                    {
                        buffer[i] = intRc[500 - i];
                    }
                    intRc = null;
                }




                outStream.Write(buffer, 0, bytesRead);
            }
            outStream.Flush();
        }

         

        catch (Exception ex)
        {
            File.AppendAllText(@"D:\SecurityHandlerError.txt", "\r\n" + DateTime.Now + ": " + ex.ToString());
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


#region old code

//public void ProcessRequest(HttpContext context)
//   {
//       context.Response.Cache.SetCacheability(HttpCacheability.NoCache);
//       context.Response.Cache.SetNoStore();


//       byte[] content = null;
//       try
//       {
//           string a = context.Request.QueryString.Count.ToString();
//           context.Response.ContentType = context.Session["ContentType"].ToString();
//           using (System.IO.FileStream fs = new System.IO.FileStream(context.Server.MapPath(context.Session["ContentPath"].ToString()), FileMode.Open, FileAccess.Read))
//           {
//               content = new byte[fs.Length];
//               fs.Read(content, 0, Convert.ToInt32(fs.Length));
//           }

//           //byte[] intRc = new byte[500];
//           //intRc = content;
//           Teacher_Dashboard_BLogic obj_BAL_Teacher_Dashboard = new Teacher_Dashboard_BLogic();
//           DataSet dsSettings = new DataSet();
//           dsSettings = obj_BAL_Teacher_Dashboard.BAL_Select_CoveredUncoverChapterTopic_Settings("UseEncrytion");
//           bool IsEncryption = Convert.ToBoolean(dsSettings.Tables[0].Rows[0]["value"].ToString());
//           if (IsEncryption)
//           {
//               byte[] intRc = new byte[501];
//               for (int j = 0; j <= 500; j++)
//               {
//                   intRc[j] = content[j];
//               }

//               for (int i = 0; i <= 500; i++)
//               {
//                   content[i] = intRc[500 - i];
//               }
//               intRc = null;
//           }
//       }
//       catch (Exception ex)
//       {
//           File.AppendAllText(@"D:\SecurityHandlerError.txt", "\r\n" + DateTime.Now + ": " + ex.ToString());
//       }
//       context.Response.BinaryWrite(content);
//       context.Response.Flush();
//       context.Response.Close();


//   }

#endregion
