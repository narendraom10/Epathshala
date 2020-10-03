using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Hirs.Coverter;

public partial class Invoice : System.Web.UI.Page
{

    #region Declaration
    string TransactionID;
    #endregion

    #region Page Events
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string package = HttpUtility.UrlDecode(Request.QueryString[0]);
            string subject = HttpUtility.UrlDecode(Request.QueryString[1]);
            string ValidFrom = HttpUtility.UrlDecode(Request.QueryString[2]);
            string Price = HttpUtility.UrlDecode(Request.QueryString[3]);
            string NoOfMonth = HttpUtility.UrlDecode(Request.QueryString[4]);
            string ValidTill = HttpUtility.UrlDecode(Request.QueryString[5]);
            TransactionID = HttpUtility.UrlDecode(Request.QueryString[6]);
            string RegistrationDate = HttpUtility.UrlDecode(Request.QueryString[7]);
            RegistrationDate = Convert.ToDateTime(RegistrationDate).ToString("dd MMM, yyyy");

            lblstudentname.Text = "Name: " + AppSessions.UserName;
            lblpackagename.Text = package;
            lblsubject.Text = subject;
            lblfromdate.Text = Convert.ToDateTime(ValidFrom).ToString("dd MMM, yyyy");
            price.Text = Convert.ToDecimal(Price).ToString("00.00");
            lblvalidtill.Text = Convert.ToDateTime(ValidTill).ToString("dd MMM, yyyy");
            //lblmonth.Text = NoOfMonth;
            DateTime date1 = Convert.ToDateTime(ValidFrom) ;
            DateTime date2 = Convert.ToDateTime(ValidTill) ;
            lblmonth.Text = Convert.ToString(((date2.Year - date1.Year) * 12) + date2.Month - date1.Month);
            lbltotal.Text = price.Text;

            DataSet dsSettings = new DataSet();
            Teacher_Dashboard_BLogic obj_BAL_Teacher_Dashboard = new Teacher_Dashboard_BLogic();
            dsSettings = obj_BAL_Teacher_Dashboard.BAL_Select_CoveredUncoverChapterTopic_Settings("PaymentDiscout");
            string PaymentDiscout = dsSettings.Tables[0].Rows[0]["value"].ToString().Trim();

            dsSettings = obj_BAL_Teacher_Dashboard.BAL_Select_CoveredUncoverChapterTopic_Settings("PaymentTax");
            string PaymentTax = dsSettings.Tables[0].Rows[0]["value"].ToString().Trim();



            lbldiscount.Text = Convert.ToDecimal(PaymentDiscout).ToString("00.00");
            lbltax.Text = Convert.ToDecimal(PaymentTax).ToString("00.00"); ;
            //lblgrandtotal.Text = (Convert.ToDecimal(price.Text) - Convert.ToDecimal(lbldiscount.Text) + Convert.ToDecimal(lbltax.Text)).ToString();
            lblgrandtotal.Text = (Convert.ToDecimal(price.Text) - Convert.ToDecimal(lbldiscount.Text) + Convert.ToDecimal(lbltax.Text)).ToString();

            ConvertToWord(lblgrandtotal.Text);
            string source = AppSessions.BMS.ToString();
            string[] stringSeparators = new string[] { ">>" };
            string[] result;
            result = source.Split(stringSeparators, StringSplitOptions.None);
            lblboard.Text = "Board: " + result[0];
            lblmideum.Text = "Medium: " + result[1];
            lblstandard.Text = "Standard: " + result[2];
            lblinvoicedate.Text = "Invoice Date: " + RegistrationDate.ToString();
            GetInvoiceNumber();
          

        }
        catch (Exception ex)
        {

        }


    }
    #endregion

    #region Methods

    protected void ConvertToWord(string numericvalue)
    {
        try
        {
            MultiCurrency OMultiCurrency = new MultiCurrency(Criteria.Indian);

            string digit = numericvalue.Trim();
            string FinalValue = string.Empty;
            string[] decimlacount = digit.Split('.');
            if (decimlacount.Length > 2)
            {
                FinalValue = "Only one decimal point allowed";
            }
            else if (decimlacount.Length == 1)
            {
                FinalValue = OMultiCurrency.ConvertToWord(digit, System.Drawing.Color.Black);
            }
            else
            {
                if (decimlacount[1].ToString() == "00")
                {
                    FinalValue = OMultiCurrency.ConvertToWord(digit.Substring(0, digit.IndexOf('.')), System.Drawing.Color.Black) + "Rupees Only";
                }
                else
                {
                    FinalValue = OMultiCurrency.ConvertToWord(digit.Substring(0, digit.IndexOf('.')), System.Drawing.Color.Black);
                    FinalValue = FinalValue + "Rupees and ";
                    OMultiCurrency = new MultiCurrency(Criteria.Indian);
                    FinalValue = FinalValue + OMultiCurrency.ConvertToWord(digit.Substring(digit.IndexOf('.') + 1), System.Drawing.Color.Black);
                    FinalValue = FinalValue + "Paisa Only";
                }
            }
            lblnumericstring.Text += FinalValue;
        }
        catch (Exception ex)
        {
        }
    }

    protected void GetInvoiceNumber()
    {
        try
        {
            DataAccess ODataAccess = new DataAccess();
            DataTable dtInvoiceNo = new DataTable();
            dtInvoiceNo = ODataAccess.GetDataTable("Select InvoiceID,Amount from TransactionMaster where TransactionID = '" + TransactionID + "'");
            lblinvoicenumber.Text = "Invoice No: " + dtInvoiceNo.Rows[0]["InvoiceID"].ToString();
            //price.Text = dtInvoiceNo.Rows[0]["Amount"].ToString();
            price.Text = Convert.ToDecimal(dtInvoiceNo.Rows[0]["Amount"].ToString()).ToString("0.00");
            lbltotal.Text = price.Text;


        }
        catch (Exception ex)
        {
        }
    }

    #endregion
}
