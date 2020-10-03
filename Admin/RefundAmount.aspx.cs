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
using System.Globalization;

public partial class Admin_RefundAmount : System.Web.UI.Page
{

    DataSet dsSettings = new DataSet();
    Teacher_Dashboard_BLogic obj_BAL_Teacher_Dashboard = new Teacher_Dashboard_BLogic();
    string ATOMRefundPaymentURL;
    string AtomPassword;
    string AtomProductID;
    string ATOMLoginID;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {

                dsSettings = obj_BAL_Teacher_Dashboard.BAL_Select_CoveredUncoverChapterTopic_Settings("ATOMRefundPaymentURL");
                ATOMRefundPaymentURL = dsSettings.Tables[0].Rows[0]["value"].ToString().Trim();

                dsSettings = obj_BAL_Teacher_Dashboard.BAL_Select_CoveredUncoverChapterTopic_Settings("ATOMPassword");
                AtomPassword = dsSettings.Tables[0].Rows[0]["value"].ToString().Trim();

                dsSettings = obj_BAL_Teacher_Dashboard.BAL_Select_CoveredUncoverChapterTopic_Settings("ATOMProductID");
                AtomProductID = dsSettings.Tables[0].Rows[0]["value"].ToString().Trim();

                dsSettings = obj_BAL_Teacher_Dashboard.BAL_Select_CoveredUncoverChapterTopic_Settings("ATOMLoginID");
                ATOMLoginID = dsSettings.Tables[0].Rows[0]["value"].ToString().Trim();

                FillAllTansaction();
            }
        }
        catch (Exception)
        {
        }
    }

    public void FillAllTansaction()
    {
        try
        {
            DataSet dtAllTransaction = new DataSet();
            Package_BLogic oPackageData = new Package_BLogic();
            dtAllTransaction = oPackageData.GetAllTransaction();
            gvalltransaction.DataSource = dtAllTransaction;
            gvalltransaction.DataBind();
        }
        catch (Exception)
        {
        }
    }


    protected void btnrefund_Click1(object sender, EventArgs e)
    {
        try
        {
            string RequestURLForRefund = string.Empty;

            dsSettings = obj_BAL_Teacher_Dashboard.BAL_Select_CoveredUncoverChapterTopic_Settings("ATOMRefundPaymentURL");
            ATOMRefundPaymentURL = dsSettings.Tables[0].Rows[0]["value"].ToString().Trim();

            dsSettings = obj_BAL_Teacher_Dashboard.BAL_Select_CoveredUncoverChapterTopic_Settings("ATOMPassword");
            AtomPassword = dsSettings.Tables[0].Rows[0]["value"].ToString().Trim();

            dsSettings = obj_BAL_Teacher_Dashboard.BAL_Select_CoveredUncoverChapterTopic_Settings("ATOMProductID");
            AtomProductID = dsSettings.Tables[0].Rows[0]["value"].ToString().Trim();

            dsSettings = obj_BAL_Teacher_Dashboard.BAL_Select_CoveredUncoverChapterTopic_Settings("ATOMLoginID");
            ATOMLoginID = dsSettings.Tables[0].Rows[0]["value"].ToString().Trim();
            

            string Password = Base64Encode(AtomPassword);
            RefundAmt = gvalltransaction.SelectedRow.Cells[3].Text;
            
            txndate = DateTime.Parse(gvalltransaction.SelectedRow.Cells[4].Text.Trim()).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
            
            
            Label lblATOMTransactionID = (Label)gvalltransaction.SelectedRow.FindControl("lblATOMTransactionID");
            ATOMTxnID = lblATOMTransactionID.Text;


            RequestURLForRefund = ATOMRefundPaymentURL + "merchantid=" + ATOMLoginID + "&pwd=" + Password + "&atomtxnid=" + ATOMTxnID + "&refundamt=" + RefundAmt + "&txndate=" + txndate;
            ServicePointManager.ServerCertificateValidationCallback += new System.Net.Security.RemoteCertificateValidationCallback((s, ce, ch, ssl) => true);
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(RequestURLForRefund);
            request.Method = "POST";
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
            string merchantid = xmlDoc.ChildNodes[1].ChildNodes[0].InnerText;
            string txnid = xmlDoc.ChildNodes[1].ChildNodes[1].InnerText;
            string amount = xmlDoc.ChildNodes[1].ChildNodes[2].InnerText;
            string statuscode = xmlDoc.ChildNodes[1].ChildNodes[3].InnerText;
            string statusmessage = xmlDoc.ChildNodes[1].ChildNodes[4].InnerText;

            InsertIntoRefundMaster(merchantid, txnid, amount, statuscode, statusmessage);
            //WebMsg.Show("Redund done sucessfully, Please check your account");
        }
        catch (Exception)
        {
        }
    }

    public void InsertIntoRefundMaster(string merchantid, string txnid, string amount, string statuscode, string statusmessage)
    {
        try
        {
            Package_BLogic OPackage_Blogic = new Package_BLogic();
            Package_BLogic oPackageData = new Package_BLogic();
            Package Opackage = new Package();
            Opackage.MerchantID = merchantid;
            Opackage.TXNID = txnid;
            Opackage.Amount = amount;
            Opackage.StatusCode = statuscode;
            Opackage.StatusMessage = statusmessage;
            int result = oPackageData.InsertRefundDetails(Opackage);
            if (result > 1)
            {
                WebMsg.Show("Refund done sucessfully");
            }
            else
            {
                WebMsg.Show("Refund not done sucessfully");
            }
        }
        catch (Exception)
        {
        }
    }

    public static string Base64Encode(string plainText)
    {
        var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
        return System.Convert.ToBase64String(plainTextBytes);
    }

    string MerchantProdID = string.Empty;
    string ATOMTxnID = string.Empty;
    string RefundAmt = string.Empty;
    string txndate = string.Empty;
    protected void gvalltransaction_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            //txtstudentname.Text = gvalltransaction.SelectedRow.Cells[0].Text;
            //txtamount.Text = gvalltransaction.SelectedRow.Cells[3].Text;
            RefundAmt = gvalltransaction.SelectedRow.Cells[3].Text;

            //RefundAmt = DateTime.Parse(gvalltransaction.SelectedRow.Cells[4].Text.Trim()).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
            //txtcreatedon.Text = gvalltransaction.SelectedRow.Cells[4].Text;
            txndate = DateTime.Parse(gvalltransaction.SelectedRow.Cells[4].Text.Trim()).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
            
            //txtpackagename.Text = gvalltransaction.SelectedRow.Cells[1].Text;

            Label lblTransactionid = (Label)gvalltransaction.SelectedRow.FindControl("lblTransactionid");
            //txtmerchanttxnID.Text = lblTransactionid.Text;

            Label lblATOMTransactionID = (Label)gvalltransaction.SelectedRow.FindControl("lblATOMTransactionID");
            ATOMTxnID = lblATOMTransactionID.Text;
            //txtatomtxnid.Text = lblATOMTransactionID.Text;

            Label lblproductid = (Label)gvalltransaction.SelectedRow.FindControl("lblproductid");
            MerchantProdID = lblproductid.Text;

            Label lblbankname = (Label)gvalltransaction.SelectedRow.FindControl("lblbankname");
            //txtbankname.Text = lblbankname.Text;

            Label lblbanktransactionID = (Label)gvalltransaction.SelectedRow.FindControl("lblbanktransactionID");
            //txtbanktransactionID.Text = lblbanktransactionID.Text;

            Label lblcustomername = (Label)gvalltransaction.SelectedRow.FindControl("lblcustomername");
            //txtcustomername.Text = lblcustomername.Text;

            Label lblcustomeremailid = (Label)gvalltransaction.SelectedRow.FindControl("lblcustomeremailid");
            //txtcustomeremailid.Text = lblcustomeremailid.Text;

            Label lblcustomermobileno = (Label)gvalltransaction.SelectedRow.FindControl("lblcustomermobileno");
            //txtcustomermobilenumber.Text = lblcustomermobileno.Text;

            //Label lblBillingAddress = (Label)gvalltransaction.SelectedRow.FindControl("lblBillingAddress");
            //txtcustomerbillingaddress.Text = lblBillingAddress.Text;

            Label lblEMIMerchantDataBankName = (Label)gvalltransaction.SelectedRow.FindControl("lblEMIMerchantDataBankName");
            //txtEMIMerchantDataBankName.Text = lblEMIMerchantDataBankName.Text;

            Label lblEMITenure = (Label)gvalltransaction.SelectedRow.FindControl("lblEMITenure");
            //txtEMITenure.Text = lblEMITenure.Text;

            Label lblsubjects = (Label)gvalltransaction.SelectedRow.FindControl("lblsubjects");
            // txtsubject.Text = lblsubjects.Text;

            Label lblNoOfMonth = (Label)gvalltransaction.SelectedRow.FindControl("lblNoOfMonth");
            //txtnoofmonth.Text = lblNoOfMonth.Text;

            Label lblvalidfrom = (Label)gvalltransaction.SelectedRow.FindControl("lblvalidfrom");
            //txtvalidfrom.Text = DateTime.Parse(lblvalidfrom.Text.Trim()).ToString("dd MMM, yyyy", CultureInfo.InvariantCulture);

            Label lblvalidtill = (Label)gvalltransaction.SelectedRow.FindControl("lblvalidtill");
            //txtvalidtill.Text = DateTime.Parse(lblvalidtill.Text.Trim()).ToString("dd MMM, yyyy", CultureInfo.InvariantCulture);


            Label lblpackageid = (Label)gvalltransaction.SelectedRow.FindControl("lblpackageid");
            Label lblinvoiceid = (Label)gvalltransaction.SelectedRow.FindControl("lblinvoiceid");
            Label lblstatus = (Label)gvalltransaction.SelectedRow.FindControl("lblstatus");
            Label lblEchoBankParameter = (Label)gvalltransaction.SelectedRow.FindControl("lblEchoBankParameter");
            Label lblbmsid = (Label)gvalltransaction.SelectedRow.FindControl("lblbmsid");


            step2.Visible = true;
            dvdetailcontent.Visible = true;

            string content = RefundContent(gvalltransaction.SelectedRow.Cells[0].Text, gvalltransaction.SelectedRow.Cells[1].Text, lblsubjects.Text, gvalltransaction.SelectedRow.Cells[3].Text, lblNoOfMonth.Text, lblTransactionid.Text, lblATOMTransactionID.Text, lblbanktransactionID.Text, lblbankname.Text, lblEMIMerchantDataBankName.Text, lblEMITenure.Text, lblcustomername.Text, lblcustomeremailid.Text, lblcustomermobileno.Text, gvalltransaction.SelectedRow.Cells[4].Text, DateTime.Parse(lblvalidfrom.Text.Trim()).ToString("dd MMM, yyyy", CultureInfo.InvariantCulture), DateTime.Parse(lblvalidtill.Text.Trim()).ToString("dd MMM, yyyy", CultureInfo.InvariantCulture));

            ltcontent.Text = content;

        }
        catch (Exception)
        {

        }
    }

    protected string RefundContent(string studentname, string packagename, string subjects, string amt, string NoOfDays, string MerchantTxnID, string ATOMtxnID, string BankTxnID, string BankName, string EMIMerchantDataBankName, string EMITenure, string customername, string customerEmailID, string customerMobileNo, string PaymentDate, string ValidFrom, string ValidTill)
    {
        StringBuilder oBuilder = new StringBuilder();
        try
        {
            oBuilder.Append("<!DOCTYPE html><html><head>  <style type=text/css> .style3 { width: 300; } .style5 { width: 250; } </style> </head><body>");

            oBuilder.Append("<table cellspacing=10 cellpadding=5 style='margin: 10px; width: 98%; border-collapse: collapse; border: 1px solid black;'>");
            oBuilder.Append("<tr> <td style='padding: 5px;'  width = 300px>Student Name: </td> <td style='padding: 5px; font-weight: bold;'  width= 300px> " + studentname + " </td> <td style='padding: 5px;' width = 300px> Package Name: </td> <td style='padding: 5px; font-weight: bold;' width = 300px> " + packagename + " </td> </tr>");
            oBuilder.Append("<tr><td style='padding: 5px;' width = 300px>Subject:</td><td style='padding: 5px; font-weight: bold;' colspan=3>" + subjects + "</td></tr>");

            oBuilder.Append("<tr> <td style='padding: 5px;' width = 300px>Amount: </td> <td style='padding: 5px; font-weight: bold;' width = 300px> " + amt + " </td> <td style='padding: 5px;' width = 300px> No Of Days: </td> <td style='padding: 5px; font-weight: bold;' width = 300px> " + NoOfDays + " </td> </tr>");
            oBuilder.Append("<tr> <td style='padding: 5px;' width = 300px>Merchant Transaction ID: </td> <td style='padding: 5px; font-weight: bold;' width = 300px> " + MerchantTxnID + " </td> <td style='padding: 5px;' width = 300px> Atom Transaction ID: </td> <td style='padding: 5px; font-weight: bold;' width = 300px> " + ATOMtxnID + " </td> </tr>");
            oBuilder.Append("<tr> <td style='padding: 5px;' width = 300px>Bank Transaction ID: </td> <td style='padding: 5px;font-weight: bold;' width = 300px> " + BankTxnID + " </td> <td style='padding: 5px;' width = 300px> Bank Name: </td> <td style='padding: 5px; font-weight: bold;' width = 300px> " + BankName + " </td> </tr>");
            oBuilder.Append("<tr> <td style='padding: 5px;' width = 300px>EMI Merchant Data Bank Name: </td> <td style='padding: 5px;font-weight: bold;' width = 300px> " + EMIMerchantDataBankName + " </td> <td style='padding: 5px;' width = 300px> EMI Tenure: </td> <td style='padding: 5px; font-weight: bold;' width = 300px> " + EMITenure + " </td> </tr>");
            oBuilder.Append("<tr> <td style='padding: 5px;' width = 300px>Customer Name: </td> <td style='padding: 5px;font-weight: bold;' width = 300px> " + customername + " </td> <td style='padding: 5px;' width = 300px> Customer Email ID: </td> <td style='padding: 5px; font-weight: bold; ' width = 300px> " + customerEmailID + " </td> </tr>");
            oBuilder.Append("<tr> <td style='padding: 5px;' width = 300px>Customer Mobile Number: </td> <td style='padding: 5px;font-weight: bold;' width = 300px> " + customerMobileNo + " </td> <td style='padding: 5px;' width = 300px> Payment Date: </td> <td style='padding: 5px; font-weight: bold;' width = 300px> " + PaymentDate + " </td> </tr>");
            oBuilder.Append("<tr> <td style='padding: 5px;' width = 300px>Valid From: </td> <td style='padding: 5px; font-weight: bold;' width = 300px> " + ValidFrom + " </td> <td style='padding: 5px;' width = 300px> Valid Till: </td> <td style='padding: 5px;font-weight: bold;' width = 300px> " + ValidTill + " </td> </tr>");


            oBuilder.Append("</body></html>");

        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
        return oBuilder.ToString();
    }
    protected void gvalltransaction_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {


            //e.Row.Attributes["onmouseover"] =
            //    "javascript:setMouseOverColor(this);";
            //e.Row.Attributes["onmouseout"] =
            //    "javascript:setMouseOutColor(this);";
            e.Row.Attributes["onclick"] =
            ClientScript.GetPostBackClientHyperlink
                (this.gvalltransaction, "Select$" + e.Row.RowIndex);
        }
    }
    //protected void btnrefund_Click1(object sender, EventArgs e)
    //{

    //}
}