///<Summary
///</Summary>

using System;
using System.Data;
using System.Collections;
using System.Xml;

public partial class Dashboard_License : System.Web.UI.Page
{
    #region "Declarations"
    ProductLicense_Blogic BLogic_Product;
    ProductLicense Property_Product;
    VarnindraClient.Prepaid objPrepaid;
    VarnindraClient.enmErrorCode ErrorCode;
    #endregion

    # region "Properties"
    # endregion

    #region "Page Events"
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            objPrepaid = new VarnindraClient.Prepaid();
            ErrorCode = new VarnindraClient.enmErrorCode();
            DataSet dsProductInfo = new DataSet();
            string ProductKey = string.Empty;
            string OldCode = string.Empty;
            try
            {
                string ProductID = CommonUtility.GetProductID();
                ViewState["ProductID"] = ProductID;
                dsProductInfo = CommonUtility.GetProductInfoFromXML();
                if (dsProductInfo.Tables.Count > 0 & dsProductInfo != null)
                {
                    if (dsProductInfo.Tables[0].Rows.Count > 0)
                    {
                        ProductKey = dsProductInfo.Tables[0].Rows[0]["ProductKey"].ToString();
                        OldCode = dsProductInfo.Tables[0].Rows[0]["OldCode"].ToString();
                        ViewState["OldCode"] = OldCode;
                    }
                }
                string strCode = objPrepaid.GetSystemInfo(ProductID, OldCode);
                ViewState["Code"] = strCode;
                txtCode1.Text = strCode.Substring(0, 5);
                txtCode2.Text = strCode.Substring(5, 10);
                ErrorCode = objPrepaid.CheckRegistration(strCode, ProductKey, ProductID, DateTime.Now, "1", "1");
            }
            catch (Exception ex)
            {
                WebMsg.Show(ex.Message);
            }
        }

    }
    #endregion

    #region "Control events"
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        objPrepaid = new VarnindraClient.Prepaid();
        ErrorCode = new VarnindraClient.enmErrorCode();
        DataSet dsProductInfo = new DataSet();
        string OldCode = string.Empty;
        try
        {
            string Key = txtKey.Text.Replace(" - ", "");
            string Code = txtCode1.Text + txtCode2.Text;
            if (CommonUtility.GetLicenseInfo(ViewState["ProductID"].ToString(), Key, Code))
            {
                if (ViewState["OldCode"] != null)
                {
                    OldCode = ViewState["OldCode"].ToString();
                }

                if (StoreKeyInXML(txtCode1.Text + txtCode2.Text, Key, OldCode, 0, 0, 0))
                {
                    Response.Redirect("~/Default.aspx");
                }
            }
            else
            {
                CommonUtility.RemoveKeyFromXML();
                WebMsg.Show("Invalid Key.");
            }

        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }
    protected bool StoreKeyInXML(string Code, string Key, string OldCode, int Count1, int Count2, int Remaining)
    {
        #region "SchemaCode"
        //string ProductID = CommonUtility.GetProductID();
        //ViewState["ProductID"] = ProductID;
        //DataSet  dsProductInfo = CommonUtility.GetProductInfo();
        //dsProductInfo.Tables[0].WriteXmlSchema(@"E:\AllDevelopmentNew\All_Source_VSS\Epathshala\Epathshala\Epathshala\Epathshala\Dashboard\KeySchema.xml");
        //dsProductInfo.Tables[0].WriteXml(@"E:\AllDevelopmentNew\All_Source_VSS\Epathshala\Epathshala\Epathshala\Epathshala\Dashboard\Key.xml");
        #endregion

        DataSet dt = new DataSet();
        dt.ReadXmlSchema(Server.MapPath("KeySchema.xml"));
        dt.ReadXml(Server.MapPath("Key.xml"));
        dt.Tables[0].Rows[0]["Code"] = Code;
        dt.Tables[0].Rows[0]["ProductKey"] = Key;
        dt.Tables[0].Rows[0]["OldCode"] = OldCode;
        dt.Tables[0].Rows[0]["Count1"] = Count1;
        dt.Tables[0].Rows[0]["Count2"] = Count2;
        dt.Tables[0].Rows[0]["RemainingDays"] = Remaining;
        dt.AcceptChanges();
        dt.WriteXml(Server.MapPath("Key.xml"));
        if (dt != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    protected void btnSendEmail_Click(object sender, EventArgs e)
    {
        try
        {
            ArrayList alistEmailContacts = CommonUtility.GetEmailAddress("Admin");
            string Body = this.GenerateBody();
            if (EmailUtility.SendEmail(alistEmailContacts, "Request for product key.", Body))
            {
                WebMsg.Show("Email has been sent successfully");
            }
            else
            {
                WebMsg.Show("Email failed.");
            }
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }
    #endregion

    # region "User defined functions"

    protected string GenerateBody()
    {
        string Body = string.Empty;
        try
        {
            Body = "<b>Hello Admin,<b/><br/><br/>";

            Body += "<table border='1' width='100%'>";

            Body += "<tr><td colspan='2' align='center'><b>Request for product key.<b/></td></tr>";
            Body += "<tr><td><b>Product ID:<b/></td><td>" + ViewState["ProductID"].ToString() + "</td></tr>";
            Body += "<tr><td><b>Product Code:<b/></td><td>" + ViewState["Code"].ToString() + "</td></tr>";


            Body += "</table><br/>";
            Body += "<b>Regards,<b/><br/>";
            Body += "<b>User<b/>";
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }

        return Body;
    }

    # endregion

}