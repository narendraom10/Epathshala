using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Quotes
/// </summary>
public class Quotes
{
    public Quotes()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    #region Properties
    private string _quoteid;
    public string QuoteID
    {
        get { return _quoteid; }
        set { _quoteid = value; }
    }

    private string _quote;
    public string Quote
    {
        get { return _quote; }
        set { _quote = value; }
    }

    private string _bywhom;
    public string ByWhom
    {
        get { return _bywhom; }
        set { _bywhom = value; }
    }
    #endregion

}