using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Offers
/// </summary>
public class Offers
{
    public Offers()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    private string _offerid;
    public string OfferID
    {
        get { return _offerid; }
        set { _offerid = value; }
    }

    private string _offertext;
    public string OfferText
    {
        get { return _offertext; }
        set { _offertext = value; }
    }

    private string _offerlink;
    public string OfferLink
    {
        get { return _offerlink; }
        set { _offerlink = value; }
    }

    private int _validdays;
    public int Validity
    {
        get { return _validdays; }
        set { _validdays = value; }
    }



}