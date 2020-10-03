/// <summary> 
/// <DevelopedBy>"NARENDRASINH"</DevelopedBy>
/// <DevelopedDate></DevelopedDate>
/// <UpdatedBy>"NARENDRASINH"</UpdatedBy>
/// <UpdatedDate></UpdatedDate>
/// </summary>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SYS_Country
/// </summary>
public class SYS_Country
{
    public SYS_Country()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    int _countryid;
    string _countryidStr="";
    string _country;
    bool _isactive;
    DateTime _createdon;
    int _createdby;
    


    public int countryid
    {
        get { return _countryid; }
        set { _countryid = value; }
    }
    public string countryidStr
    {
        get { return _countryidStr; }
        set { _countryidStr = value; }
    }


    public string country
    {
        get { return _country; }
        set { _country = value; }
    }


    public bool isactive
    {
        get { return _isactive; }
        set { _isactive = value; }
    }


    public DateTime createdon
    {
        get { return _createdon; }
        set { _createdon = value; }
    }


    public int createdby
    {
        get { return _createdby; }
        set { _createdby = value; }
    }
}