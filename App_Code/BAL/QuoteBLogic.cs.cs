using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Data;
/// <summary>
/// Summary description for QuoteBLogic
/// </summary>
public class QuoteBLogic
{
    DataAccess DA;
    ArrayList arrayparam;
    public QuoteBLogic()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public void InsertQuote(Quotes o)
    {
        DA = new DataAccess();
        arrayparam = new ArrayList();
        arrayparam.Add(new parameter("Operationtype", "I"));
        arrayparam.Add(new parameter("QuoteText", o.Quote));
        arrayparam.Add(new parameter("ByWhom", o.ByWhom));
        DA.DAL_InsertUpdate("tblQuotes_managequotes", arrayparam);
    }
    public void UpdateQuote(Quotes o)
    {
        DA = new DataAccess();
        arrayparam = new ArrayList();
        arrayparam.Add(new parameter("Operationtype", "U"));
        arrayparam.Add(new parameter("QuoteId", o.QuoteID));
        arrayparam.Add(new parameter("QuoteText", o.Quote));
        arrayparam.Add(new parameter("ByWhom", o.ByWhom));
        DA.DAL_InsertUpdate("tblQuotes_managequotes", arrayparam);
    }
    public void DeleteQuote(Quotes o)
    {
        DA = new DataAccess();
        arrayparam = new ArrayList();
        arrayparam.Add(new parameter("Operationtype", "D"));
        arrayparam.Add(new parameter("QuoteId", o.QuoteID));
        DA.DAL_InsertUpdate("tblQuotes_managequotes", arrayparam);
    }
    public DataSet GetAllQuotes()
    {
        DA = new DataAccess();
        arrayparam = new ArrayList();
        arrayparam.Add(new parameter("flag", "SA"));

        return DA.DAL_Select("tblQuote_GetQuote", arrayparam);
    }
    public DataSet GetQuoteOfDay()
    {
        DA = new DataAccess();
        arrayparam = new ArrayList();
        arrayparam.Add(new parameter("flag", "SS"));
        return DA.DAL_Select("tblQuote_GetQuote", arrayparam);
    }
}