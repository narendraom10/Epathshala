using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Collections.Specialized;
using System.Data;
using System.Collections;
using System.Text;
using CCA.Util;

public partial class PaymentResponcePage : System.Web.UI.Page
{
    #region Declaration
    Package_BLogic Blogic_Package;
    Package PPackage;
    #endregion

    #region Page Events

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                if (Session["country_name"] != null)
                {
                    if (Session["country_name"].ToString().ToLower() == "india")
                    {
                        string transactionid = Session["TransactionID"].ToString();
                        NameValueCollection nvc = Request.Form;
                        string mmp_Transaction = nvc["mmp_txn"].ToString();
                        string PaymentStatus = nvc["f_code"].ToString();
                        string MerchantTransactionId = Request.Form["mer_txn"];
                        string Amount = Request.Form["amt"];
                        string Product = Request.Form["prod"];
                        string TransactionDate = Request.Form["date"];
                        string BankTransactionId = Request.Form["bank_txn"];
                        string ClientCode = Request.Form["clientcode"]; // Encrypted User Information
                        string BankName = Request.Form["bank_name"];

                        //User Details
                        string Udf1 = Request.Form["udf1"]; //First Name
                        string Udf2 = Request.Form["udf2"]; //Email
                        string Udf3 = Request.Form["udf3"]; //Mobile
                        string Udf4 = Request.Form["udf4"]; //Address
                        string Udf5 = Request.Form["udf5"]; //Bank Name
                        string Udf6 = Request.Form["udf6"]; //EMI Option

                        string strResponceIP = HttpContext.Current.Request.UserHostAddress;
                        //string strRemarks = "txnId:" + MerchantTransactionId + ", txnStatus:" + PaymentStatus + ", amount:" + Amount + ", pgTxnId:" + mmp_Transaction + ", BankTransactionId:" + BankTransactionId + ", Udf1:" + Udf1 + ", Udf2:" + Udf2 + ", Udf3:" + Udf3 + ", Udf4:" + Udf4 + ", Udf5:" + Udf5 + ", Udf6:" + Udf6;

                        DataSet dsSettings = new DataSet();
                        Teacher_Dashboard_BLogic obj_BAL_Teacher_Dashboard = new Teacher_Dashboard_BLogic();
                        dsSettings = obj_BAL_Teacher_Dashboard.BAL_Select_CoveredUncoverChapterTopic_Settings("ATOMPaymentIP");
                        string ATOMPaymentIP = dsSettings.Tables[0].Rows[0]["value"].ToString().Trim();
                        //Verify the Response Server
                        //if (Request.UrlReferrer.Host.Trim() != ATOMPaymentIP)
                        //{
                        //    lblthankyou.Text = " Sorry for inconvenience ";
                        //    lblthankyou.ForeColor = System.Drawing.Color.Red;

                        //    lblmessage1.Text = "Payment is not done sucessfully please try again....";
                        //    PPackage.TransactionID = transactionid;
                        //    PPackage.Status = "Fail";
                        //    Blogic_Package.BAL_Student_Package_Update_TransactionMaster(PPackage, "Responce server is not verify", mmp_Transaction, Product, BankName, BankTransactionId, Udf1, Udf2, Udf3, Udf4, Udf5, Udf6, "");
                        //    Response.AddHeader("REFRESH", "10;URL=SelectPackage.aspx");
                        //}

                        // CHECK THE PAYMENT STATUS AND VALIDATE THE TRANSACTION ID

                        if (PaymentStatus.ToUpper().Trim() == "OK" && transactionid.Trim() == MerchantTransactionId.Trim())
                        {
                            lblthankyou.Text = " Thank You ";
                            lblthankyou.ForeColor = System.Drawing.Color.Black;
                            lblmessage1.Text = " Your Transaction is successfull Please note down your Transaction number for further use. ";
                            lbltransactionnumber.Text = "Your Transaction Number is: " + transactionid;
                            transactionid = Session["TransactionID"].ToString();
                            Blogic_Package = new Package_BLogic();
                            PPackage = new Package();
                            DataTable dt = (DataTable)(Session["SelectedPackage"]);
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                PPackage.PackageFD_ID = Convert.ToInt64(dt.Rows[i]["PackageID"].ToString());
                                PPackage.StudentID = AppSessions.StudentID;
                                PPackage.PackageActivationDate = Convert.ToDateTime(dt.Rows[i]["ActivateOn"].ToString());
                                PPackage.EndDate = Convert.ToDateTime(dt.Rows[i]["ExpiryDate"].ToString());
                                PPackage.TransactionID = transactionid.ToString();

                                Blogic_Package.BAL_Student_Package_Insert(PPackage);
                            }

                            PPackage = new Package();
                            PPackage.TransactionID = transactionid;
                            PPackage.Status = "OK";
                            PPackage.InvoiceID = GetInvoiceID();
                            PPackage.Currency = "INR";
                            Blogic_Package.BAL_Student_Package_Update_TransactionMaster(PPackage, "Transaction Is Successfull", mmp_Transaction, Product, BankName, BankTransactionId, Udf1, Udf2, Udf3, Udf4, Udf5, Udf6, "");
                            SendTransactionDetails(BuildEmailBody("Epathshala", Udf1, Udf3, Udf2, Convert.ToDecimal(Amount), BankName, DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss"), PaymentStatus, transactionid, mmp_Transaction));
                            Response.AddHeader("REFRESH", "10;URL=../Report/StudentPackageReport.aspx");


                        }

                        else if (PaymentStatus.ToUpper().Trim() == "C")
                        {
                            lblthankyou.ForeColor = System.Drawing.Color.Black;
                            lblmessage1.Text = " You have cancelled transaction.";
                            PPackage = new Package();
                            Blogic_Package = new Package_BLogic();
                            PPackage.TransactionID = transactionid;
                            PPackage.Status = "Cancel";
                            PPackage.Currency = "INR";
                            Blogic_Package.BAL_Student_Package_Update_TransactionMaster(PPackage, "Transaction cancelled by user.", mmp_Transaction, Product, BankName, BankTransactionId, Udf1, Udf2, Udf3, Udf4, Udf5, Udf6, "");
                            SendTransactionDetails(BuildEmailBody("Epathshala", AppSessions.UserName, Session["MobileNumber"].ToString(), AppSessions.LoginID, Convert.ToDecimal(Amount), BankName, DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss"), "Transaction cancelled by user.", transactionid, mmp_Transaction));
                            RedirectPage();
                            //Response.AddHeader("REFRESH", "10;URL=../Dashboard/StudentDashboard.aspx");
                        }
                        else
                        {
                            //lblmessage.Text = "PAYMENT STATUS IS NOT SUCCESS OR TRANSACTION ID IS NOT VERIFIED";
                            lblthankyou.Text = " Sorry for inconvenience ";
                            lblthankyou.ForeColor = System.Drawing.Color.Red;
                            //lblmessage.ForeColor = System.Drawing.Color.Red;
                            lblmessage1.Text = "Transaction not successful please try again....";
                            lblmessage1.ForeColor = System.Drawing.Color.Red;
                            PPackage = new Package();
                            Blogic_Package = new Package_BLogic();
                            PPackage.TransactionID = transactionid;
                            PPackage.Status = "Fail";
                            PPackage.Currency = "INR";
                            //PPackage.InvoiceID = GetInvoiceID();
                            Blogic_Package.BAL_Student_Package_Update_TransactionMaster(PPackage, "Transaction not successful or transaction ID not varified", mmp_Transaction, Product, BankName, BankTransactionId, Udf1, Udf2, Udf3, Udf4, Udf5, Udf6, "");
                            SendTransactionDetails(BuildEmailBody("Epathshala", Udf1, Udf3, Udf2, Convert.ToDecimal(Amount), BankName, DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss"), "Fail", transactionid, mmp_Transaction));
                            RedirectPage();
                            //Response.AddHeader("REFRESH", "10;URL=SelectPackage.aspx");
                        }
                    }
                    else
                    {
                        CCAvenueTransation();
                    }
                }
                else
                {
                    Response.Redirect("StudentDashboard.aspx");

                }
            }

        }
        catch (Exception ex)
        {
        }
    }

    #endregion

    #region Methods

    protected void RedirectPage()
    {
        if (Session["RedirectPageName"] != null)
        {
            if (Session["RedirectPageName"].ToString() == "selectpackage")
            {
                Response.AddHeader("REFRESH", "10;URL=SelectPackage.aspx");
            }
            else if (Session["RedirectPageName"].ToString() == "buypackage")
            {
                Response.AddHeader("REFRESH", "10;URL=BuyPackage.aspx");
            }
        }
    }

    //protected void RedirectPage()
    //{
    //    try
    //    {
    //        Thread oThread = new Thread(delegate()
    //        {
    //            SomethingHappenedMethod();
    //        });
    //        oThread.SetApartmentState(ApartmentState.STA);
    //        oThread.IsBackground = true;
    //        oThread.Start();

    //        //Loading objloading = new Loading();
    //        //objloading.Show();

    //        while (oThread.IsAlive)
    //        {
    //            System.Windows.Forms.Application.DoEvents();
    //            //objloading.BringToFront();
    //        }

    //        //objloading.Close();

    //    }
    //    catch (Exception)
    //    {

    //        throw;
    //    }
    //}

    //public void SomethingHappenedMethod()
    //{ 
    //    if (Session["RedirectPageName"] != null)
    //    {
    //        if (Session["RedirectPageName"].ToString() == "selectpackage")
    //        {
    //            Thread.Sleep(5000);
    //            Response.Redirect("SelectPackage.aspx");
    //        }
    //        else if (Session["RedirectPageName"].ToString() == "buypackage")
    //        {
    //            Thread.Sleep(5000);
    //            Response.Redirect("BuyPackage.aspx");
    //        }
    //    }

    //}

    protected string GetInvoiceID()
    {
        string InvoiceID = string.Empty;

        DataAccess ODataAccess = new DataAccess();
        DataTable dtInvoiceNumber = new DataTable();

        dtInvoiceNumber = ODataAccess.GetDataTable("select Top(1) InvoiceID from TransactionMaster order by InvoiceID DESC");

        if (dtInvoiceNumber != null)
        {
            if (dtInvoiceNumber.Rows.Count > 0)
            {

                InvoiceID = dtInvoiceNumber.Rows[0]["InvoiceID"].ToString();
                if (InvoiceID != string.Empty)
                {
                    int NewInvoiceNumber = Convert.ToInt32(InvoiceID.Substring(6));
                    NewInvoiceNumber = NewInvoiceNumber + 1;

                    if (DateTime.Now.ToString("MM") == InvoiceID.Substring(0, 2).ToString())
                    {
                        InvoiceID = DateTime.Now.ToString("MM") + DateTime.Now.ToString("yyyy") + NewInvoiceNumber.ToString().PadLeft(4, '0');
                    }
                    else
                    {
                        InvoiceID = DateTime.Now.ToString("MM") + DateTime.Now.ToString("yyyy") + "0001";
                    }
                }
                else
                {
                    InvoiceID = DateTime.Now.ToString("MM") + DateTime.Now.ToString("yyyy") + "0001";
                }
                return InvoiceID;
            }

            else
            {
                InvoiceID = DateTime.Now.ToString("MM") + DateTime.Now.ToString("yyyy") + "0001";
            }
        }

        return InvoiceID;
    }

    protected void SendTransactionDetails(string BuildEmailBody)
    {
        DataSet dsSettings = new DataSet();
        Teacher_Dashboard_BLogic obj_BAL_Teacher_Dashboard = new Teacher_Dashboard_BLogic();
        dsSettings = obj_BAL_Teacher_Dashboard.BAL_Select_CoveredUncoverChapterTopic_Settings("TransactionMailID");
        string TransactionMailIDList = dsSettings.Tables[0].Rows[0]["value"].ToString().Trim();

        ArrayList alistEmailAddress = new ArrayList(TransactionMailIDList.Split(','));
        string response = SendMail(alistEmailAddress, "Transaction Detail ", BuildEmailBody);
    }

    protected string BuildEmailBody(string productname, string clientname, string mobilenumber, string Emailid, decimal amount, string BankName, string strDateTime, string transferstatus, string MerchantTransactionID, string AtomTransactionID)
    {
        StringBuilder oBuilder = new StringBuilder();
        try
        {
            oBuilder.Append("<div style=\'font-family: Calibri,Cambria,verdana; color: #4C3636;\'>");
            oBuilder.Append("<div style=\'font-family: Trebuchet MS,Georgia,Verdana,Tahoma; color: #4C3636;\'>");
            oBuilder.Append("<table width=72% style=\'margin: 10px; border: 5px SOLID SILVER; border-radius: 5px;\' border=0>");
            oBuilder.Append("<tr> <td> ");
            oBuilder.Append("<div style=\'background-color: #2f378e; height: 35px; font-size: 21px; font-weight: bold; padding: 10px;\'> <span style=\'color: white; display: block;\'>Transaction Response</span></div>");
            oBuilder.Append("</td></tr>");
            oBuilder.Append("<tr> <td style=\'font-size: 16px;\'>");
            oBuilder.Append("<div id=dvcontent style=\'font-size: 14px; padding: 20px; background-color: #F4F4F4;\'> ");
            oBuilder.Append("<div><table border=1 width=100% >");
            oBuilder.Append(" <tr> <td style=\' width: 235px;\'> Product </td> <td style=\' width: 235px;\'> " + productname + " </td> </tr>");
            oBuilder.Append("<tr> <td style=\' width: 235px;\'> Client Name </td> <td style=\' width: 235px;\'> " + clientname + " </td> </tr>");
            oBuilder.Append("<tr> <td style=\' width: 235px;\'> Mobile Number </td> <td style=\' width: 235px;\'> " + mobilenumber + " </td> </tr>");
            oBuilder.Append("<tr> <td style=\' width: 235px;\'> Email Address </td> <td style=\' width: 235px;\'> " + Emailid + " </td> </tr>");
            oBuilder.Append("<tr> <td style=\' width: 235px;\'> Amount Transferred </td> <td style=\' width: 235px;\'> " + amount.ToString("F") + " (" + Session["CurrencyType"].ToString() + ") </td> </tr>");
            oBuilder.Append("<tr> <td style=\' width: 235px;\'> Bank Name </td> <td style=\' width: 235px;\'> " + BankName + " </td> </tr>");
            oBuilder.Append("<tr> <td style=\' width: 235px;\'> Date and Time </td> <td style=\' width: 235px;\'> " + strDateTime + "  </td> </tr>");
            oBuilder.Append("<tr> <td> Funds Transfer Status </td> <td style=\' width: 235px;\'> " + transferstatus + "  </td> </tr>");
            oBuilder.Append("<tr> <td style=\' width: 235px;\'> Merchant Transaction ID </td> <td style=\' width: 235px;\'> " + MerchantTransactionID + " </td> </tr>");
            oBuilder.Append("<tr> <td style=\' width: 235px;\'> Transaction ID </td> <td style=\' width: 235px;\'> " + AtomTransactionID + " </td> </tr>");
            oBuilder.Append("</table> </div> </div></td></tr></table></div></div>");
        }
        catch
        {

        }
        return oBuilder.ToString();
    }

    private static string SendMail(ArrayList emailId, string mailSubject, string mailContent)
    {
        string Response = string.Empty;


        if (emailId.Count > 0)
        {
            bool IsSendSuccess = EmailUtility.SendEmail(emailId, mailSubject, mailContent);
            if (IsSendSuccess)
                Response = "Email Sent Successfully.";
            else
                Response = "Sending Email failed.";
        }
        return Response;
    }

    protected void CCAvenueTransation()
    {
        try
        {
            DataSet dsSettings = new DataSet();
            Teacher_Dashboard_BLogic obj_BAL_Teacher_Dashboard = new Teacher_Dashboard_BLogic();

            dsSettings = obj_BAL_Teacher_Dashboard.BAL_Select_CoveredUncoverChapterTopic_Settings("CCAvenue_Working_key");
            string CCAvenue_Working_key = dsSettings.Tables[0].Rows[0]["value"].ToString().Trim();

            string Working_key = CCAvenue_Working_key;
            CCACrypto ccaCrypto = new CCACrypto();
            string encResponse = ccaCrypto.Decrypt(Request.Form["encResp"], Working_key);
            NameValueCollection Params = new NameValueCollection();
            string[] segments = encResponse.Split('&');
            foreach (string seg in segments)
            {
                string[] parts = seg.Split('=');
                if (parts.Length > 0)
                {
                    string Key = parts[0].Trim();
                    string Value = parts[1].Trim();
                    Params.Add(Key, Value);
                }
            }

            string order_id = Params["order_id"];
            string tracking_id = Params["tracking_id"];
            string bank_ref_no = Params["bank_ref_no"];
            string order_status = Params["order_status"];
            string failure_message = Params["failure_message"];
            string payment_mode = Params["payment_mode"];
            string card_name = Params["card_name"];
            string status_code = Params["status_code"];
            string status_message = Params["status_message"];
            string currency = Params["currency"];
            string amount = Params["amount"];
            string billing_name = Params["billing_name"];
            string billing_address = Params["billing_address"];
            string billing_city = Params["billing_city"];
            string billing_state = Params["billing_state"];
            string billing_zip = Params["billing_zip"];
            string billing_country = Params["billing_country"];
            string billing_tel = Params["billing_tel"];
            string billing_email = Params["billing_email"];
            string delivery_name = Params["delivery_name"];
            string delivery_address = Params["delivery_address"];
            string delivery_city = Params["delivery_city"];
            string delivery_state = Params["delivery_state"];
            string delivery_zip = Params["delivery_zip"];
            string delivery_country = Params["delivery_country"];
            string delivery_tel = Params["delivery_tel"];
            string merchant_param1 = Params["merchant_param1"];
            string merchant_param2 = Params["merchant_param2"];
            string merchant_param3 = Params["merchant_param3"];
            string merchant_param4 = Params["merchant_param4"];
            string merchant_param5 = Params["merchant_param5"];
            string vault = Params["vault"];
            string offer_type = Params["offer_type"];
            string offer_code = Params["offer_code"];
            string discount_value = Params["discount_value"];
            string mer_amount = Params["mer_amount"];
            string eci_value = Params["eci_value"];
            string retry = Params["retry"];
            string response_code = Params["response_code"];
            PPackage = new Package();
            PPackage.TransactionID = order_id;
            PPackage.PaymentGateway = "CCAvenue";
            PPackage.PaymentMode = payment_mode;
            PPackage.CardName = card_name;
            PPackage.CCAvenueStatusCode = status_code;
            PPackage.Currency = currency;
            PPackage.Country = billing_country;
            PPackage.Vault = vault;
            PPackage.OfferType = offer_type;
            PPackage.OfferCode = offer_code;
            PPackage.Discount = Convert.ToDecimal(discount_value);
            PPackage.MerchantAmount = Convert.ToDecimal(mer_amount);
            PPackage.ECIValue = eci_value;
            PPackage.Retry = retry;
            PPackage.ResponseCode = response_code;

            if (order_status.ToUpper().Trim() != "FAILURE" && order_status.ToUpper().Trim() != "ABORTED")
            {
                lblthankyou.Text = " Thank You ";
                lblthankyou.ForeColor = System.Drawing.Color.Black;
                lblmessage1.Text = " Your Transaction is successfull Please note down your Transaction number for further use. ";
                lbltransactionnumber.Text = "Your Transaction Number is: " + order_id;
                order_id = Session["TransactionID"].ToString();
                Blogic_Package = new Package_BLogic();
                PPackage = new Package();
                DataTable dt = (DataTable)(Session["SelectedPackage"]);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    PPackage.PackageFD_ID = Convert.ToInt64(dt.Rows[i]["PackageID"].ToString());
                    PPackage.StudentID = AppSessions.StudentID;
                    PPackage.PackageActivationDate = Convert.ToDateTime(dt.Rows[i]["ActivateOn"].ToString());
                    PPackage.EndDate = Convert.ToDateTime(dt.Rows[i]["ExpiryDate"].ToString());
                    PPackage.TransactionID = order_id.ToString();
                    Blogic_Package.BAL_Student_Package_Insert(PPackage);
                }

                PPackage = new Package();
                PPackage.TransactionID = order_id;
                PPackage.Status = order_status;
                PPackage.InvoiceID = GetInvoiceID();
                Blogic_Package.BAL_Student_Package_Update_TransactionMaster(PPackage, "Transaction is successfull", tracking_id, "CCAvenue", "", bank_ref_no, delivery_name, billing_email, billing_tel, billing_address, "", "", "");
                SendTransactionDetails(BuildEmailBody("Epathshala", delivery_name, billing_tel, billing_email, Convert.ToDecimal(amount), card_name, DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss"), order_status.ToString(), order_id, tracking_id));
                Response.AddHeader("REFRESH", "10;URL=../Report/StudentPackageReport.aspx");
            }

            else if (order_status.ToUpper().Trim() == "ABORTED")
            {
                lblthankyou.ForeColor = System.Drawing.Color.Black;
                lblmessage1.Text = " You have cancelled transaction.";

                Blogic_Package = new Package_BLogic();
                PPackage.Status = order_status;
                Blogic_Package.BAL_Student_Package_Update_TransactionMaster(PPackage, "Transaction cancelled by user.", tracking_id, "CCAvenue", "", bank_ref_no, delivery_name, billing_email, billing_tel, billing_address, "", "", "");
                SendTransactionDetails(BuildEmailBody("Epathshala", AppSessions.UserName, Session["MobileNumber"].ToString(), AppSessions.LoginID, Convert.ToDecimal(amount), card_name, DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss"), "Transaction cancelled by user.", order_id, tracking_id));
                RedirectPage();
                //Response.AddHeader("REFRESH", "10;URL=../Dashboard/StudentDashboard.aspx");
            }
            else
            {
                lblthankyou.Text = " Sorry for inconvenience ";
                lblthankyou.ForeColor = System.Drawing.Color.Red;
                lblmessage1.Text = "Transaction is not successful please try again....";
                lblmessage1.ForeColor = System.Drawing.Color.Red;
                Blogic_Package = new Package_BLogic();
                PPackage.TransactionID = order_id;
                PPackage.Status = order_status;

                //PPackage.InvoiceID = GetInvoiceID();
                Blogic_Package.BAL_Student_Package_Update_TransactionMaster(PPackage, "Transaction is not successful", tracking_id, "CCAvenue", "", bank_ref_no, delivery_name, billing_email, billing_tel, billing_address, "", "", "");
                SendTransactionDetails(BuildEmailBody("Epathshala", delivery_name, billing_tel, billing_email, Convert.ToDecimal(amount), card_name, DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss"), "Fail", order_id, tracking_id));
                RedirectPage();
                //Response.AddHeader("REFRESH", "10;URL=SelectPackage.aspx");
            }
        }

        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "msg", "alert(" + ex.Message.ToString() + ")", true);
        }
    }
    #endregion
}