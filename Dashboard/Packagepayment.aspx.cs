using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Xml;
using System.Net.Security;

using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.IO;

public partial class Dashboard_Packagepayment : System.Web.UI.Page
{

    #region Declaration
    decimal PackagePrice;
    string TransactionID = string.Empty;
    #endregion

    #region Page Events
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["PackagePrice"] != null)
            {
                PackagePrice = Convert.ToDecimal(Session["PackagePrice"].ToString().Trim());
                txtamt.Text = PackagePrice.ToString();
            }
            else
            {
                Response.Redirect("StudentDashboard.aspx");
            }
        }
    }
    #endregion

    #region Control Events
    protected void btnpay_Click(object sender, EventArgs e)
    {
        ////AtomRequest();
        if (!chkcheck.Checked)
        {
            WebMsg.Show("Please indicate that you accept the Terms and Conditions");
            //Response.Write("<script>alert('Please indicate that you accept the Terms and Conditions');</script>");
        }
        else
        {
            BuyPackage();
        }
      

    }
    

    public bool AcceptAllCertifications(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certification, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
    {
        return true;
    }
    #endregion

    #region Methods

    protected void BuyPackage()
    {
        try
        {

            ServicePointManager.Expect100Continue = true;
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

            DataSet dsSettings = new DataSet();
            Teacher_Dashboard_BLogic obj_BAL_Teacher_Dashboard = new Teacher_Dashboard_BLogic();
            dsSettings = obj_BAL_Teacher_Dashboard.BAL_Select_CoveredUncoverChapterTopic_Settings("ATOMLoginID");
            string AtomLoginID = dsSettings.Tables[0].Rows[0]["value"].ToString().Trim();

            dsSettings = obj_BAL_Teacher_Dashboard.BAL_Select_CoveredUncoverChapterTopic_Settings("ATOMPassword");
            string AtomPassword = dsSettings.Tables[0].Rows[0]["value"].ToString().Trim();

            dsSettings = obj_BAL_Teacher_Dashboard.BAL_Select_CoveredUncoverChapterTopic_Settings("ATOMProductID");
            string AtomProductID = dsSettings.Tables[0].Rows[0]["value"].ToString().Trim();

            dsSettings = obj_BAL_Teacher_Dashboard.BAL_Select_CoveredUncoverChapterTopic_Settings("ATOMTransactionType");
            string AtomTransactionType = dsSettings.Tables[0].Rows[0]["value"].ToString().Trim();

            dsSettings = obj_BAL_Teacher_Dashboard.BAL_Select_CoveredUncoverChapterTopic_Settings("ATOMTransactionServiceAmount");
            string ATOMTransactionServiceAmount = dsSettings.Tables[0].Rows[0]["value"].ToString().Trim();


            dsSettings = obj_BAL_Teacher_Dashboard.BAL_Select_CoveredUncoverChapterTopic_Settings("ATOMCustomerAccountNumber");
            string ATOMCustomerAccountNumber = dsSettings.Tables[0].Rows[0]["value"].ToString().Trim();

            dsSettings = obj_BAL_Teacher_Dashboard.BAL_Select_CoveredUncoverChapterTopic_Settings("ATOMPaymentIP");
            string ATOMPaymentIP = dsSettings.Tables[0].Rows[0]["value"].ToString().Trim();


            Uri navigateUri = new Uri(System.Web.HttpContext.Current.Request.Url, "PaymentResponseATOM.aspx");
            string ReturnUrl = navigateUri.ToString();

            TransactionID = GetTransactionID();
            Session["TransactionID"] = TransactionID.ToString();

            string username = AppSessions.UserName.ToString();
            string userencodestring = Base64Encode(username.Trim());
            DataTable DTStudentDetails = new DataTable();
            DTStudentDetails = GetStudentDetails();
            string CustomerName = DTStudentDetails.Rows[0]["FirstName"].ToString() + " " + DTStudentDetails.Rows[0]["MiddleName"].ToString() + " " + DTStudentDetails.Rows[0]["LastName"].ToString();
            string CustomerEmailID = DTStudentDetails.Rows[0]["EmailID"].ToString();
            if (CustomerEmailID == string.Empty)
                CustomerEmailID = "0";
            string CustomerMobileNo = DTStudentDetails.Rows[0]["MobileNo"].ToString();
            if (CustomerMobileNo == string.Empty)
                CustomerMobileNo = "0";
            string BillingAddress = DTStudentDetails.Rows[0]["Address"].ToString();
            if (BillingAddress == string.Empty)
                BillingAddress = "0";

            //  This URL will send request on server and it will return below details:
            //  URL on which next request will be send.
            //  Transaction type NBFundTransfer or CCFundTransfer.
            //  Temporary transaction ID that we have to send on next request.
            // Stange here it will return 1.
            PackagePrice = Convert.ToDecimal(Session["PackagePrice"].ToString().Trim());

            string TransactionData = "https://payment.atomtech.in/paynetz/epi/fts?login=" + AtomLoginID + "&pass=" + AtomPassword + "&ttype=" + AtomTransactionType + "&prodid=" + AtomProductID + "&amt=" + PackagePrice + "&txncurr=INR&txnscamt=" + ATOMTransactionServiceAmount + "&clientcode=" + userencodestring + "&txnid=" + TransactionID + "&date=" + DateTime.Now.ToString("dd/MM/yyyy HH:MM:ss") + "&custacc=" + ATOMCustomerAccountNumber + "&mdd=" + rblfieldvalue.SelectedValue + "&ru=" + ReturnUrl + "&udf1=" + CustomerName + "&udf2=" + CustomerEmailID + "&udf3=" + CustomerMobileNo + "&udf4=" + BillingAddress + "";

            ServicePointManager.ServerCertificateValidationCallback += new System.Net.Security.RemoteCertificateValidationCallback((s, ce, ch, ssl) => true);
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
            //  ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(TransactionData);
            // Set credentials to use for this request.
            request.Credentials = CredentialCache.DefaultCredentials;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            // Get the stream associated with the response.
            Stream receiveStream = response.GetResponseStream();
            // Pipes the stream to a higher level stream reader with the required encoding format. 
            StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);

            XmlDocument xmlDoc = new XmlDocument();
            //xmlDoc.Load(TransactionData);
            xmlDoc.Load(readStream);
            string url = xmlDoc.ChildNodes[1].ChildNodes[0].ChildNodes[0].ChildNodes[0].InnerText;          // URL on wchich next request will send.
            string ttype = xmlDoc.ChildNodes[1].ChildNodes[0].ChildNodes[0].ChildNodes[1].InnerText;        // Transaction type as of now it will be NBFundTransfer.
            string tempTxnId = xmlDoc.ChildNodes[1].ChildNodes[0].ChildNodes[0].ChildNodes[2].InnerText;    // Temporary transaction ID
            string token = xmlDoc.ChildNodes[1].ChildNodes[0].ChildNodes[0].ChildNodes[3].InnerText;        // Tokan ID
            string txtStage = xmlDoc.ChildNodes[1].ChildNodes[0].ChildNodes[0].ChildNodes[4].InnerText;     // Stange here it will return 1
            string RedirectToPayment = "" + url + "?ttype=" + ttype.Trim() + "&tempTxnId=" + tempTxnId.Trim() + "&token=" + token.Trim() + "&txnStage=" + txtStage.Trim() + "";
            
            InsertIntoTransactionMaster();
            Response.Redirect(RedirectToPayment, false); // Send request with new URL.
        }
        catch (Exception ex)
        {
            //Response.Write("<script>alert('" + ex.Message + "');</script>");
        }
    }




    public static string Base64Encode(string plainText)
    {
        var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
        return System.Convert.ToBase64String(plainTextBytes);
    }
    protected DataTable GetStudentDetails()
    {
        DataTable DTStudent = new DataTable();
        try
        {
            //DataAccessEpathshalaStudent ODataAccessEpathshalaStudent = new DataAccessEpathshalaStudent();
            DataAccess ODataAccessEpathshalaStudent = new DataAccess();

            
            DTStudent = ODataAccessEpathshalaStudent.GetDataTable("select * from Student where StudentID = '" + AppSessions.StudentID + "'");
        }
        catch (Exception ex)
        {
        }
        return DTStudent;
    }
    protected void InsertIntoTransactionMaster()
    {
        try
        {
            DataTable dt = (DataTable)Session["SelectedPackage"];
            Package_BLogic OPackage_Blogic = new Package_BLogic();
            Package Opackage = new Package();
            string packageID = string.Empty;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                packageID += dt.Rows[i]["PackageID"].ToString() + ",";
            }
            Opackage.StudentID = Convert.ToInt32(AppSessions.StudentID);
            Opackage.PackgeID = packageID.Substring(0, packageID.Length - 1);
            Opackage.Price = PackagePrice;
            Opackage.Status = "In Progress";
            Opackage.TransactionID = TransactionID.ToString().Trim();
            OPackage_Blogic.InsertTransactionDetails(Opackage);
        }
        catch (Exception ex)
        {
        }
    }
    protected string GetTransactionID()
    {
        string NewTransactionID = string.Empty;
        try
        {
            DataAccess ODataAcess = new DataAccess();
            DataTable dtTransactionID = new DataTable();
            dtTransactionID = ODataAcess.GetDataTable("SELECT MAX(CAST(SUBSTRING(TransactionID,4,LEN(TransactionID) )  AS INT)) as TXNNO FROM TransactionMaster");
            if (dtTransactionID != null)
            {
                if (dtTransactionID.Rows.Count > 0)
                {
                    string strTransactionID = dtTransactionID.Rows[0]["TXNNO"].ToString();
                    if (strTransactionID.ToString().Trim() == string.Empty)
                    {
                        NewTransactionID = "TXN1";
                    }
                    else
                    {
                        int TransactionCount = Convert.ToInt32(strTransactionID);
                        TransactionCount = TransactionCount + 1;
                        NewTransactionID = "TXN" + TransactionCount.ToString().Trim();
                    }
                }
                else
                {
                    NewTransactionID = "TXN1";
                }
            }
        }
        catch (Exception ex)
        {
        }
        return NewTransactionID;
    }

    #endregion

    protected void chkcheck_CheckedChanged(object sender, EventArgs e)
    {
        //if (btnpay.Enabled)
        //    btnpay.Enabled = false;
        //else
        //    btnpay.Enabled = true;
    }
}

