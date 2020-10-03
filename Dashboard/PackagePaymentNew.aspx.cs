using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Net;
using System.IO;
using System.Xml;
using System.Text;
using System.Web.Script.Serialization;
using CCA.Util;

public partial class PackagePaymentNew : System.Web.UI.Page
{
    #region Declaration
    decimal PackagePrice;
    string TransactionID = string.Empty;
    string Pageindex = string.Empty;
    #endregion

    #region Page Events
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataTable dt = (DataTable)(Session["SelectedPackage"]);
            Session["PackagePrice"] = Convert.ToInt32(Convert.ToDouble(dt.Rows[0]["Price"].ToString()));
            if (Session["PackagePrice"] != null)
            {
                PackagePrice = Convert.ToDecimal(Session["PackagePrice"].ToString().Trim());

                txtamt.Text = PackagePrice.ToString("F") + " (" + Session["CurrencyType"].ToString() + ") ";
                GetStudentDetails1();
                if (Request.QueryString["PageIndex"] != null)
                    Pageindex = Request.QueryString["PageIndex"].ToString();

                if (Session["country_name"].ToString().ToLower() == "india")
                    paymentmode.Visible = true;
                else
                    paymentmode.Visible = false;
            }
            else
            {
                Response.Redirect("StudentDashboard.aspx");
            }
        }
    }

    protected void GetStudentDetails1()
    {
        DataTable DTStudent = new DataTable();
        try
        {
            DataAccess ODataAccessEpathshalaStudent = new DataAccess();
            DTStudent = ODataAccessEpathshalaStudent.GetDataTable("select * from Student where StudentID = '" + AppSessions.StudentID + "'");
            txtfirstname.Text = DTStudent.Rows[0]["FirstName"].ToString();
            txtemail.Text = AppSessions.LoginID;
            if (DTStudent.Rows[0]["MobileNo"].ToString() != "0")
            {
                txtmobile.Text = DTStudent.Rows[0]["MobileNo"].ToString();
            }
            txtaddress.Text = DTStudent.Rows[0]["Address"].ToString();


            DataTable dt = (DataTable)(Session["SelectedPackage"]);

            lblpackagename.Text = dt.Rows[0]["PackageName"].ToString();
            lblsubject.Text = dt.Rows[0]["Subject"].ToString();
            lblmonth.Text = dt.Rows[0]["NoOfMonth"].ToString();
            lblexpirydate.Text = Convert.ToDateTime(dt.Rows[0]["ExpiryDate"]).ToString("dd MMM,yyyy");
            PackagePrice = Convert.ToDecimal(Session["PackagePrice"].ToString().Trim());
            lblamount.Text = PackagePrice.ToString("F") + " (" + Session["CurrencyType"].ToString() + ") ";
        }
        catch (Exception)
        {
        }

    }

    #endregion
    string transactiontype = string.Empty;
    protected void btncontinue_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["country_name"].ToString().ToLower() == "india")
            {
                transactiontype = hftransactiontype.Value.ToString();
                if (transactiontype.ToString() != string.Empty)
                    BuyPackage();
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "msg", "alert('Please select transaction type.')", true);
                }
            }
            else
            {
                DataSet dsSettings = new DataSet();
                Teacher_Dashboard_BLogic obj_BAL_Teacher_Dashboard = new Teacher_Dashboard_BLogic();

                dsSettings = obj_BAL_Teacher_Dashboard.BAL_Select_CoveredUncoverChapterTopic_Settings("CCAvenue_access_code");
                string CCAvenue_access_code = dsSettings.Tables[0].Rows[0]["value"].ToString().Trim();

                dsSettings = obj_BAL_Teacher_Dashboard.BAL_Select_CoveredUncoverChapterTopic_Settings("CCAvenue_Working_key");
                string CCAvenue_Working_key = dsSettings.Tables[0].Rows[0]["value"].ToString().Trim();

                dsSettings = obj_BAL_Teacher_Dashboard.BAL_Select_CoveredUncoverChapterTopic_Settings("CCAvenue_merchant_id");
                string CCAvenue_merchant_id = dsSettings.Tables[0].Rows[0]["value"].ToString().Trim();

                dsSettings = obj_BAL_Teacher_Dashboard.BAL_Select_CoveredUncoverChapterTopic_Settings("CCAvenue_URL");
                string CCAvenue_URL = dsSettings.Tables[0].Rows[0]["value"].ToString().Trim();

                string merchant_id = CCAvenue_merchant_id; //"99522";
                string access_code = CCAvenue_access_code;  //"AVFW65DE39BV30WFVB";
                string Working_key = CCAvenue_Working_key;  //"E85FE1783919FA34A4758580E844135A";
                string amount = PackagePrice.ToString();  //"1";
                string requesturl = "";
                string ccaRequest = "";
                CCACrypto ccaCrypto = new CCACrypto();
                string strEncRequest = "";
                //string redirect_url = "http://localhost:16480/Epathshala/Dashboard/PaymentResponseCCAvenue.aspx";
                //string cancel_url = "http://localhost:16480/Epathshala/Dashboard/PaymentResponseCCAvenue.aspx";

                Uri redirect_Uri = new Uri(System.Web.HttpContext.Current.Request.Url, "PaymentResponseATOM.aspx");
                string redirect_url = redirect_Uri.ToString();

                Uri cancel_Uri = new Uri(System.Web.HttpContext.Current.Request.Url, "BuyPackage.aspx");
                string cancel_url = cancel_Uri.ToString();


                //string ccaRequest = "tid=1&merchant_id=" + merchant_id + "&order_id=1&amount=1.00&currency=INR&redirect_url=" + redirect_url + "&cancel_url=" + cancel_url + "&billing_name=Arraycom&billing_address=Gandhinagar&billing_city=Gandhinagar&billing_state=Gujarat&billing_zip=425001&billing_country=Dubai&billing_tel=9327035124&billing_email=disha.vaghela@epath.net.in&delivery_name=Disha&merchant_param1=additional Info.&merchant_param2=additional Info.&merchant_param3=additional Info.&merchant_param4=additional Info.&merchant_param5=additional Info.&integration_type=iframe_normal&promo_code=&customer_identifier=&";
                PackagePrice = Convert.ToDecimal(Session["PackagePrice"].ToString().Trim());
                TransactionID = GetTransactionID("CCAvenue");
                ccaRequest = "tid=" + TransactionID + "&merchant_id=" + merchant_id + "&order_id=" + TransactionID + "&amount=" + PackagePrice + "&currency=" + Session["CurrencyType"].ToString() + "&redirect_url=" + redirect_url + "&cancel_url=" + cancel_url;

                strEncRequest = ccaCrypto.Encrypt(ccaRequest, Working_key);
                //requesturl = "https://secure.ccavenue.com/transaction/transaction.do?command=initiateTransaction&encRequest=" + strEncRequest + "&access_code=" + access_code;
                requesturl = CCAvenue_URL + strEncRequest + "&access_code=" + access_code;
                InsertIntoTransactionMaster("CCAvenue");
                Response.Redirect(requesturl, false);
            }
        }
        catch (Exception)
        {
        }
    }

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

            dsSettings = obj_BAL_Teacher_Dashboard.BAL_Select_CoveredUncoverChapterTopic_Settings("ATOMPaymentURL");
            string ATOMPaymentURL = dsSettings.Tables[0].Rows[0]["value"].ToString().Trim();

            dsSettings = obj_BAL_Teacher_Dashboard.BAL_Select_CoveredUncoverChapterTopic_Settings("IsOriginalURL");
            string IsOriginalURL = dsSettings.Tables[0].Rows[0]["value"].ToString().Trim();
            //IsOriginalURL = "no";

            Uri navigateUri = new Uri(System.Web.HttpContext.Current.Request.Url, "PaymentResponseATOM.aspx");
            string ReturnUrl = navigateUri.ToString();

            TransactionID = GetTransactionID(AtomProductID);
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
            Session["MobileNumber"] = txtmobile.Text;
            //string TransactionData = "https://payment.atomtech.in/paynetz/epi/fts?login=" + AtomLoginID + "&pass=" + AtomPassword + "&ttype=" + AtomTransactionType + "&prodid=" + AtomProductID + "&amt=" + PackagePrice + "&txncurr=INR&txnscamt=" + ATOMTransactionServiceAmount + "&clientcode=" + userencodestring + "&txnid=" + TransactionID + "&date=" + DateTime.Now.ToString("dd/MM/yyyy HH:MM:ss") + "&custacc=" + ATOMCustomerAccountNumber + "&mdd=" + rblfieldvalue.SelectedValue + "&ru=" + ReturnUrl + "&udf1=" + txtfirstname.Text + "&udf2=" + txtemail.Text + "&udf3=" + txtmobile.Text + "&udf4=" + txtaddress.Text + "";

            string TransactionData = string.Empty;

            if (IsOriginalURL.ToString().ToLower() == "yes")
            {
                //Orignal URL
                TransactionData = ATOMPaymentURL + "login=" + AtomLoginID + "&pass=" + AtomPassword + "&ttype=" + AtomTransactionType + "&prodid=" + AtomProductID + "&amt=" + PackagePrice + "&txncurr=INR&txnscamt=" + ATOMTransactionServiceAmount + "&clientcode=" + userencodestring + "&txnid=" + TransactionID + "&date=" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss").Replace("-", "/") + "&custacc=" + ATOMCustomerAccountNumber + "&mdd=" + rblfieldvalue.SelectedValue + "&ru=" + ReturnUrl + "&udf1=" + txtfirstname.Text + "&udf2=" + txtemail.Text + "&udf3=" + txtmobile.Text + "&udf4=" + txtaddress.Text + "";
            }
            else
            {
                //Dummy URL for internal use
                TransactionData = "https://paynetzuat.atomtech.in/paynetz/epi/fts?login=160&pass=Test@123&ttype=NBFundTransfer&prodid=NSE&amt=" + PackagePrice + "&txncurr=INR&txnscamt=" + ATOMTransactionServiceAmount + "&clientcode=" + userencodestring + "&txnid=" + TransactionID + "&date=" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss").Replace("-", "/") + "&custacc=" + ATOMCustomerAccountNumber + "&mdd=" + transactiontype + "&ru=" + ReturnUrl + "&udf1=" + txtfirstname.Text + "&udf2=" + txtemail.Text + "&udf3=" + txtmobile.Text + "&udf4=" + txtaddress.Text + "";
            }

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

            InsertIntoTransactionMaster(AtomProductID);
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
    protected void InsertIntoTransactionMaster(string Productid)
    {
        try
        {
            DataTable dt = (DataTable)Session["SelectedPackage"];
            Session["EndDate"] = dt.Rows[0]["ExpiryDate"].ToString();
            Package_BLogic OPackage_Blogic = new Package_BLogic();
            Package Opackage = new Package();
            string packageID = string.Empty;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                packageID += dt.Rows[i]["PackageID"].ToString() + ",";
            }
            Opackage.StudentID = Convert.ToInt32(AppSessions.StudentID);
            Opackage.PackgeID = packageID.Substring(0, packageID.Length - 1);
            PackagePrice = Convert.ToDecimal(Session["PackagePrice"].ToString().Trim());
            Opackage.Price = PackagePrice;
            Opackage.Status = "In Progress";

            Session["TransactionID"] = TransactionID.ToString();
            Opackage.TransactionID = TransactionID.ToString().Trim();
            Opackage.BMSID = AppSessions.BMSID;
            Opackage.BoardID = AppSessions.BoardID;
            Opackage.MediumID = AppSessions.MediumID;
            Opackage.StandardID = AppSessions.StandardID;
            Opackage.ProductID = Productid.ToString();


            OPackage_Blogic.InsertTransactionDetails(Opackage);
        }
        catch (Exception ex)
        {
        }
    }
    protected string GetTransactionID(string ProductID)
    {
        string NewTransactionID = string.Empty;
        //string CCavenueTransactionID = string.Empty;
        try
        {
            Package_BLogic OPackageBlogic = new Package_BLogic();
            DataSet dsTransactionID = new DataSet();

            dsTransactionID = OPackageBlogic.BAL_Select_TransactionID(ProductID);
            if (dsTransactionID != null)
            {
                if (dsTransactionID.Tables[0].Rows.Count > 0)
                {
                    if (ProductID.ToString().ToLower() == "ccavenue")
                    {

                        NewTransactionID = dsTransactionID.Tables[0].Rows[0]["TXNNO"].ToString();
                        if (NewTransactionID != string.Empty)
                        {
                            int NewTransactionNumber = Convert.ToInt32(NewTransactionID.Substring(6));
                            NewTransactionNumber = NewTransactionNumber + 1;

                            if (DateTime.Now.ToString("dd") == NewTransactionID.Substring(4, 2).ToString())
                            {
                                NewTransactionID = DateTime.Now.ToString("yy") + DateTime.Now.ToString("MM") + DateTime.Now.ToString("dd") + NewTransactionNumber.ToString().PadLeft(5, '0');
                            }
                            else
                            {
                                NewTransactionID = DateTime.Now.ToString("yy") + DateTime.Now.ToString("MM") + DateTime.Now.ToString("dd") + "00001";
                            }

                        }
                        else
                        {
                            NewTransactionID = DateTime.Now.ToString("yy") + DateTime.Now.ToString("MM") + DateTime.Now.ToString("dd") + "00001";

                        }

                    }
                    else
                    {
                        string strTransactionID = dsTransactionID.Tables[0].Rows[0]["TXNNO"].ToString();

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
                }
                else
                {
                    if (ProductID.ToString().ToLower() == "ccavenue")
                    {
                        NewTransactionID = DateTime.Now.ToString("yy") + DateTime.Now.ToString("MM") + DateTime.Now.ToString("dd") + "000001";
                    }
                    else
                    {
                        NewTransactionID = "TXN1";
                    }
                }
            }
            return NewTransactionID;
        }
        catch (Exception ex)
        {
            return "";
        }

    }

    #endregion
    protected void btngoback_Click(object sender, EventArgs e)
    {
        if (Pageindex == "0")

            Response.Redirect("SelectPackage.aspx", false);
        else
            Response.Redirect("BuyPackage.aspx", false);
    }

    /* Code for CCAvenue integration. START*/
    public string GetClientIPAddress()
    {
        //The X-Forwarded-For (XFF) HTTP header field is a de facto standard for identifying the originating IP address of a
        //client connecting to a web server through an HTTP proxy or load balancer
        string ip = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

        if (string.IsNullOrEmpty(ip))
        {
            ip = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
        }
        return ip;
    }

    public string GetCountryName()
    {
        string ipAddress = GetClientIPAddress();
        string url = "http://freegeoip.net/json/" + ipAddress;
        Location location;
        using (WebClient client = new WebClient())
        {
            string json = client.DownloadString(url);
            location = new JavaScriptSerializer().Deserialize<Location>(json);
            List<Location> locations = new List<Location>();
            locations.Add(location);
        }

        return location.country_name.ToString();
    }

    /* END */

}
public class Location
{
    public string ip { get; set; }
    public string country_name { get; set; }
    public string region_code { get; set; }
    public string City { get; set; }
    public string region_name { get; set; }
    public string zip_code { get; set; }
    public string Latitude { get; set; }
    public string Longitude { get; set; }
    public string time_zone { get; set; }
}

