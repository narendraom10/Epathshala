using System;
using System.Data;
using System.IO;
using System.Net;
using System.Web.UI;
using System.Web.Services;
using System.Collections.Generic;

public partial class SchoolAdmin_SendMessage : System.Web.UI.Page
{
    #region "Declaration"
    Student_BLogic BAL_Student_BLogic = new Student_BLogic();
    Student Student = new Student();
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            DataSet ods = new DataSet();
            ods = BAL_Student_BLogic.BAL_Student_BySchoolid(AppSessions.SchoolID);
            totalstudent.InnerHtml = Convert.ToString(ods.Tables[0].Rows.Count);
            totalstudenttop.InnerHtml = Convert.ToString(ods.Tables[0].Rows.Count);
        }
    }
    #region SendMessage
    public static bool SendSMS(string Number, string Message, ref string strresponse)
    {
        bool SendStatus = false;
        try
        {
            string url = CreateURL(Number, Message);
            //string MyProxyHostString = "192.168.2.3";
            //int MyProxyPort = 4480;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            //request.Proxy = new WebProxy(MyProxyHostString, MyProxyPort);
            request.Method = "GET";
            request.ContentType = "application/x-www-form-urlencoded";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);

            string data = reader.ReadToEnd();
            strresponse = data;

            reader.Close();
            stream.Close();
            SendStatus = true;
        }
        catch (Exception e)
        {
            SendStatus = false;
            strresponse = e.Message.ToString();
        }
        return SendStatus;
    }
    public static string CreateURL(string Number, string Message)
    {
        return "http://dndopen.loyalsmsindia.co.in/api/web2sms.php?workingkey=A0d7b05b976821af4e76c5b909e43316e&to=" + Number + "&sender=EPAATH&message=" + Message + "&unicode=1";

    }
    #endregion

    #region WebMethod
    [WebMethod()]
    public static KeyValueData[] GETSTUDENTDATA()
    {
        List<KeyValueData> olst = new List<KeyValueData>();
        DataSet ods = new DataSet();
        Student_BLogic BAL_Student_BLogic = new Student_BLogic();
        ods = BAL_Student_BLogic.BAL_Student_BySchoolid(AppSessions.SchoolID);

        foreach (DataRow dr in ods.Tables[0].Rows)
        {
            KeyValueData okey = new KeyValueData();
            okey.Key = Convert.ToString(dr["StudentID"]);
            okey.Value = Convert.ToString(dr["MobileNo"]);
            olst.Add(okey);
        }
        return olst.ToArray();
    }
    [WebMethod()]
    public static bool SENDMESSAGE(string studentid, string number, string message)
    {
        bool IsSuccess = false;
        bool SendStatus = false;
        string strresponse = string.Empty;
        SendStatus = SendSMS(number, message, ref strresponse);
        if (SendStatus == true && strresponse.ToLower().Contains("message gid"))
            IsSuccess = true;

        #region Log Message
        Student_BLogic BAL_Student_BLogic = new Student_BLogic();
        BAL_Student_BLogic.BAL_MessageLog(studentid, number, message, strresponse, IsSuccess);
        #endregion

        return IsSuccess;
    }
    public class KeyValueData
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
    #endregion
}