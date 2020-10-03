using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ProductLicense
/// </summary>
public class ProductLicense
{
    string code;

    public string Code
    {
        get { return code; }
        set { code = value; }
    }

    string oldcode;

    public string Oldcode
    {
        get { return oldcode; }
        set { oldcode = value; }
    }

   

    string productKey;

    public string ProductKey
    {
        get { return productKey; }
        set { productKey = value; }
    }

    int count1;

    public int Count1
    {
        get { return count1; }
        set { count1 = value; }
    }

    int count2;

    public int Count2
    {
        get { return count2; }
        set { count2 = value; }
    }

    int remainingDays;

    public int RemainingDays
    {
        get { return remainingDays; }
        set { remainingDays = value; }
    }
}