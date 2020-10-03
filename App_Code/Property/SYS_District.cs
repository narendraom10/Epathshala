/// <summary> 
/// <DevelopedBy>"NARENDRASINH"</DevelopedBy>
/// <DevelopedDate></DevelopedDate>
/// <UpdatedBy>"NARENDRASINH"</UpdatedBy>
/// <UpdatedDate></UpdatedDate>
/// </summary>
using System;


public class SYS_District
{
    public SYS_District()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    int _districtid;
    string _districtidStr="";
    int _stateid;
    int _countryid;
    string _district;
    bool _isactive;
    DateTime _createdon;
    int _createdby;


    public int districtid
    {
        get { return _districtid; }
        set { _districtid = value; }
    }
    public string districtidStr
    {
        get { return _districtidStr; }
        set { _districtidStr = value; }
    }

    public int stateid
    {
        get { return _stateid; }
        set { _stateid = value; }
    }


    public int countryid
    {
        get { return _countryid; }
        set { _countryid = value; }
    }


    public string district
    {
        get { return _district; }
        set { _district = value; }
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