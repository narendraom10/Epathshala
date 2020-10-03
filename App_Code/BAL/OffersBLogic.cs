using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Data;
/// <summary>
/// Summary description for OffersBLogic
/// </summary>
public class OffersBLogic
{
    DataAccess DA;
    ArrayList arrayparam;
    public OffersBLogic()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public void InsertOffer(Offers o)
    {
        DA = new DataAccess();
        arrayparam = new ArrayList();
        arrayparam.Add(new parameter("Operationtype", "I"));
        arrayparam.Add(new parameter("OfferID", o.OfferID));
        arrayparam.Add(new parameter("OfferDisplayText", o.OfferText));
        arrayparam.Add(new parameter("OfferLink", o.OfferLink));
        arrayparam.Add(new parameter("ValidDays", o.Validity));
        DA.DAL_InsertUpdate("tbloffer_manageoffers", arrayparam);
    }
    public void UpdateOffer(Offers o)
    {
        DA = new DataAccess();
        arrayparam = new ArrayList();
        arrayparam.Add(new parameter("Operationtype", "U"));
        arrayparam.Add(new parameter("OfferID", o.OfferID));
        arrayparam.Add(new parameter("OfferDisplayText", o.OfferText));
        arrayparam.Add(new parameter("OfferLink", o.OfferLink));
        arrayparam.Add(new parameter("ValidDays", o.Validity));
        DA.DAL_InsertUpdate("tbloffer_manageoffers", arrayparam);
    }
    public void DeleteOffer(Offers o)
    {
        DA = new DataAccess();
        arrayparam = new ArrayList();
        arrayparam.Add(new parameter("Operationtype", "D"));
        arrayparam.Add(new parameter("OfferID", o.OfferID));
        DA.DAL_InsertUpdate("tbloffer_manageoffers", arrayparam);
    }
    public DataSet GetOffer()
    {
        DA = new DataAccess();
        DataSet dsOffer = DA.DAL_Select("tbloffer_Get_offer_for_Grid", arrayparam);
        if (dsOffer.Tables.Count > 0 && dsOffer.Tables[0].Rows.Count > 0)
        {
            return dsOffer;
        }
        else
        {
            return null;
        }
    }
}