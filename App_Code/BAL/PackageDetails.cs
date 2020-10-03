using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Collections;

/// <summary>
/// Summary description for PackageDeta
/// </summary>
public class PackageDeta
{

    DataAccess DAL_SYS_Package;
    ArrayList arrParameter;
	public PackageDeta()
	{
		//
		// TODO: Add constructor logic here
		//
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
}