using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Data;

/// <summary>
/// Summary description for Package_BLogic
/// </summary>
public class Package_BLogic
{
    DataAccess DAL_SYS_Package;
    ArrayList arrParameter;

	public Package_BLogic()
	{
		//
		// TODO: Add constructor logic here
		//
	}


    public int InsertTransactionDetails(Package package)
    {
        int Value = 0;

        this.DAL_SYS_Package = new DataAccess();
        this.arrParameter = new ArrayList();
        arrParameter.Add(new parameter("TransactionID", package.TransactionID));
        arrParameter.Add(new parameter("StudentID", package.StudentID));
        arrParameter.Add(new parameter("packageID", package.PackgeID));
        arrParameter.Add(new parameter("Amount", package.Price));
        arrParameter.Add(new parameter("Status", package.Status));
        arrParameter.Add(new parameter("BMSID", package.BMSID));
        arrParameter.Add(new parameter("BoardID", package.BoardID));
        arrParameter.Add(new parameter("MediumID", package.MediumID));
        arrParameter.Add(new parameter("StandardID", package.StandardID));
        arrParameter.Add(new parameter("ProductID", package.ProductID));
        Value = DAL_SYS_Package.DAL_InsertUpdate_Return("Insert_TransactionDetails", arrParameter);
        return Value;
    }


    public int BAL_Package_Insert(Package Package)
    {
        int value = 0;
        this.DAL_SYS_Package = new DataAccess();
        this.arrParameter = new ArrayList();

        arrParameter.Add(new parameter("PackageFD_ID", Package.PackageFD_ID));
        arrParameter.Add(new parameter("StudentID", Package.StudentID));
        value = this.DAL_SYS_Package.DAL_InsertUpdate_Return("Proc_Insert_Student_PackageDetail", arrParameter);
        return value;
    }

    public void  BAL_Student_Package_Insert(Package Package)
    {
        
        this.DAL_SYS_Package = new DataAccess();
        this.arrParameter = new ArrayList();

        arrParameter.Add(new parameter("PackageID", Package.PackageFD_ID));
        arrParameter.Add(new parameter("StudentID", Package.StudentID));
        arrParameter.Add(new parameter("Fromdate", Package.PackageActivationDate));
        arrParameter.Add(new parameter("ExpiryDate", Package.EndDate));
        arrParameter.Add(new parameter("TransactionID", Package.TransactionID));
        this.DAL_SYS_Package.DAL_InsertUpdate("Studentpackagesetails_Insert", arrParameter);

        
    }
    public int BAL_Student_TrialPackage_Insert(Package Package)
    {
        int value = 0;
        this.DAL_SYS_Package = new DataAccess();
        this.arrParameter = new ArrayList();

        arrParameter.Add(new parameter("PackageID", Package.PackageFD_ID));
        arrParameter.Add(new parameter("StudentID", Package.StudentID));

        value = this.DAL_SYS_Package.DAL_InsertUpdate_Return("StudentPackageDetails_InsertDetails", arrParameter);
         return value;
    }
    public void BAL_Student_Package_Update_TransactionMaster(Package Package, string TransactionStatus,string ATOMTransactionID,string ProductID,string BankName,string BankTransactionID,string CustomerName,string CustomerEmailID,string CustomerMobileNo,string BillingAddress,string EMIMerchantDataBankName,string EMITenure,string EchoBankParameter)
    {
        this.DAL_SYS_Package = new DataAccess();
        this.arrParameter = new ArrayList();

        arrParameter.Add(new parameter("TransactionID", Package.TransactionID));
        arrParameter.Add(new parameter("Status", Package.Status));
        arrParameter.Add(new parameter("InvoiceID", Package.InvoiceID));
        arrParameter.Add(new parameter("ReasonForFailTransaction", TransactionStatus));

        arrParameter.Add(new parameter("ATOMTransactionID", ATOMTransactionID));
        arrParameter.Add(new parameter("ProductID", ProductID));
        arrParameter.Add(new parameter("BankName", BankName));
        arrParameter.Add(new parameter("BankTransactionID", BankTransactionID));
        arrParameter.Add(new parameter("CustomerName", CustomerName));
        arrParameter.Add(new parameter("CustomerEmailID", CustomerEmailID));
        arrParameter.Add(new parameter("CustomerMobileNo", CustomerMobileNo));
        arrParameter.Add(new parameter("BillingAddress", BillingAddress));
        arrParameter.Add(new parameter("EMIMerchantDataBankName", EMIMerchantDataBankName));
        arrParameter.Add(new parameter("EMITenure", EMITenure));
        arrParameter.Add(new parameter("EchoBankParameter", EchoBankParameter));

        arrParameter.Add(new parameter("PaymentGateway", Package.PaymentGateway));
        arrParameter.Add(new parameter("PaymentMode", Package.PaymentMode));
        arrParameter.Add(new parameter("CardName", Package.CardName));
        arrParameter.Add(new parameter("StatusCode", Package.StatusCode));
        arrParameter.Add(new parameter("Currency", Package.Currency));
        arrParameter.Add(new parameter("Country", Package.Country));
        arrParameter.Add(new parameter("Vault", Package.Vault));
        arrParameter.Add(new parameter("OfferType", Package.OfferType));
        arrParameter.Add(new parameter("OfferCode", Package.OfferCode));
        arrParameter.Add(new parameter("Discount", Package.Discount));
        arrParameter.Add(new parameter("MerchantAmount", Package.MerchantAmount));
        arrParameter.Add(new parameter("ECIValue", Package.ECIValue));
        arrParameter.Add(new parameter("Retry", Package.Retry));
        arrParameter.Add(new parameter("ResponseCode", Package.ResponseCode));

        this.DAL_SYS_Package.DAL_InsertUpdate("Update_TransactionStatus", arrParameter);
    }

    public DataSet BAL_Teacher_Note_Select(TeacherNotes TeacherNotes, string Mode)
    {
        DAL_SYS_Package = new DataAccess();
        arrParameter = new ArrayList();
        arrParameter.Add(new parameter("BMSID", TeacherNotes.BmsId));
        arrParameter.Add(new parameter("Mode", Mode));
        return DAL_SYS_Package.DAL_Select("Proc_Select_TeacherNotes", arrParameter);
    }

    public DataSet VerifyPackage(Package Package)
    {
        this.DAL_SYS_Package = new DataAccess();
        this.arrParameter = new ArrayList();

        arrParameter.Add(new parameter("ID", Package.PackageFD_ID));
        arrParameter.Add(new parameter("StudentID", Package.StudentID));
        return DAL_SYS_Package.DAL_Select("Verify_Package", arrParameter);
    }

    public int InsertNewPackage(Package package)
    {
        int PackageId = 0;
        this.DAL_SYS_Package = new DataAccess();
        this.arrParameter = new ArrayList();

       // arrParameter.Add(new parameter("Name",package.Name));
        //arrParameter.Add(new parameter("Description", package.Description));
        arrParameter.Add(new parameter("Month", package.NoOfMonth));
        PackageId = DAL_SYS_Package.executescalre("Proc_InsertPackageType", arrParameter);
        return PackageId;

    
    }

    public int InsertPackageFeesDetail(Package package)
    {
        int Value = 0;

        this.DAL_SYS_Package = new DataAccess();
        this.arrParameter = new ArrayList();

        arrParameter.Add(new parameter("PackageName", package.PackageName));
        arrParameter.Add(new parameter("PackageDescription", package.PackageDescription));
        arrParameter.Add(new parameter("BMSID", package.BMSID));
        arrParameter.Add(new parameter("SubjectID", package.SubjectID));
        arrParameter.Add(new parameter("Subject", package.Subject));
        arrParameter.Add(new parameter("NoOfMonth", package.NoOfMonth));
        arrParameter.Add(new parameter("Price", package.Price));
        arrParameter.Add(new parameter("EndDate", package.EndDate));
        arrParameter.Add(new parameter("PackageType", package.PackageType));
        arrParameter.Add(new parameter("Isactive", package.IsActive));
        


        Value = DAL_SYS_Package.DAL_InsertUpdate_Return("InserPackageFeesDetails", arrParameter);
        return Value;
    }

    public int UpdatePackageDetail(Package package)
    {
        int Value = 0;
        this.DAL_SYS_Package = new DataAccess();
        this.arrParameter = new ArrayList();
        arrParameter.Add(new parameter("PackageID", package.PackageFD_ID));
        arrParameter.Add(new parameter("PackageDecription", package.PackageDescription));
        arrParameter.Add(new parameter("NoOfMonth", package.NoOfMonth));
        arrParameter.Add(new parameter("Price", package.Price));
        arrParameter.Add(new parameter("EndDate", package.EndDate));
        arrParameter.Add(new parameter("isactive", package.IsActive));

        Value = DAL_SYS_Package.DAL_InsertUpdate_Return("PackageDetails_UpdatePackage", arrParameter);
        return Value;

    }

    public bool CheckPackageAvailablity(string pacagename)
    {
        DataSet PackageDetail = new DataSet();
        this.DAL_SYS_Package = new DataAccess();
        this.arrParameter = new ArrayList();
        this.arrParameter.Add(new parameter("PackageName", pacagename));
        PackageDetail = this.DAL_SYS_Package.DAL_Select("Proc_Select_PackageDetailByPackageName", arrParameter);
        if (PackageDetail.Tables[0].Rows.Count > 0)
            return true;
        else
            return false;
    }

    public void BAL_Student_Purchased_Package_Insert(int packageid , int studentid , DateTime fromdate, DateTime enddate)
    {
        this.DAL_SYS_Package = new DataAccess();
        this.arrParameter = new ArrayList();

        arrParameter.Add(new parameter("PackageID", packageid));
        arrParameter.Add(new parameter("StudentID", studentid));
        arrParameter.Add(new parameter("Fromdate", fromdate));
        arrParameter.Add(new parameter("ExpiryDate", enddate));
        this.DAL_SYS_Package.DAL_InsertUpdate("Studentpackagesetails_Insert", arrParameter);
    }



    public DataSet GetPackageDetailByPackageId(string packageid)
    {

        this.DAL_SYS_Package = new DataAccess();
        this.arrParameter = new ArrayList();

        arrParameter.Add(new parameter("Packageid", packageid));
        return DAL_SYS_Package.DAL_Select("Proc_Select_PackageDetailByPackageid", arrParameter);
    }

    public DataSet GetAllTransaction()
    {
        this.DAL_SYS_Package = new DataAccess();

        return DAL_SYS_Package.DAL_SelectALL("TransactionMaster_TransactionOperation");
    }


    public int InsertRefundDetails(Package package)
    {
        int Value = 0;

        this.DAL_SYS_Package = new DataAccess();
        this.arrParameter = new ArrayList();
        arrParameter.Add(new parameter("MerchantID", package.MerchantID));
        arrParameter.Add(new parameter("TxnID", package.TXNID));
        arrParameter.Add(new parameter("Amount", package.Price));
        arrParameter.Add(new parameter("StatusCode", package.StatusCode));
        arrParameter.Add(new parameter("StatusMessage", package.StatusMessage));
        Value = DAL_SYS_Package.DAL_InsertUpdate_Return("tblATOMRefund_Operation", arrParameter);
        return Value;

    }

    public DataSet BAL_Select_TransactionID(string ProductID)
    {
        DAL_SYS_Package = new DataAccess();
        arrParameter = new ArrayList();
        arrParameter.Add(new parameter("ProductID", ProductID));
        return DAL_SYS_Package.DAL_Select("Proc_SelectMaxTransactionID", arrParameter);
    }

}