using System;
using System.Data;

/// <summary> 
/// <DevelopedBy>"NARENDRASINH"</DevelopedBy>
/// <DevelopedDate></DevelopedDate>
/// <UpdatedBy>"NARENDRASINH"</UpdatedBy>
/// <UpdatedDate></UpdatedDate>
/// </summary>
public class School
{
    public School()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    int _schoolid;
    string _schoolidStr;
    string _name;
    string _ploteno;
    string _blockno;
    string _address;
    int _countryid;
    int _stateid;
    int _districtid;
    string _city;
    Int64 _pincode;
    Int64 _landlineno;
    Int64 _faxno;
    Int64 _mobileno;
    string _emailid;
    string _websiteurl;
    string _schoolstartyear;
    string _comment;
    int _StatusID;
    DateTime _createdon;
    int _createdby;
    DateTime _modifiedon;
    int _modifiedby;
    string _schoolregbms;
    DateTime _startdate;
    int _countday;
    int _totaldays;

    public DateTime startdate
    {
        get { return _startdate; }
        set { _startdate = value; }
    }
    public int countday
    {
        get { return _countday; }
        set { _countday = value; }
    }

    public int totaldays
    {
        get { return _totaldays; }
        set { _totaldays = value; }
    }

    public string schoolregbms
    {
        get { return _schoolregbms; }
        set { _schoolregbms = value; }
    }


    public int schoolid
    {
        get { return _schoolid; }
        set { _schoolid = value; }
    }
    public string schoolidStr
    {
        get { return _schoolidStr; }
        set { _schoolidStr = value; }
    }


    public string name
    {
        get { return _name; }
        set { _name = value; }
    }


    public string ploteno
    {
        get { return _ploteno; }
        set { _ploteno = value; }
    }


    public string blockno
    {
        get { return _blockno; }
        set { _blockno = value; }
    }


    public string address
    {
        get { return _address; }
        set { _address = value; }
    }


    public int countryid
    {
        get { return _countryid; }
        set { _countryid = value; }
    }


    public int stateid
    {
        get { return _stateid; }
        set { _stateid = value; }
    }


    public int districtid
    {
        get { return _districtid; }
        set { _districtid = value; }
    }


    public string city
    {
        get { return _city; }
        set { _city = value; }
    }


    public Int64 pincode
    {
        get { return _pincode; }
        set { _pincode = value; }
    }


    public Int64 landlineno
    {
        get { return _landlineno; }
        set { _landlineno = value; }
    }


    public Int64 faxno
    {
        get { return _faxno; }
        set { _faxno = value; }
    }


    public Int64 mobileno
    {
        get { return _mobileno; }
        set { _mobileno = value; }
    }


    public string emailid
    {
        get { return _emailid; }
        set { _emailid = value; }
    }


    public string websiteurl
    {
        get { return _websiteurl; }
        set { _websiteurl = value; }
    }


    public string schoolstartyear
    {
        get { return _schoolstartyear; }
        set { _schoolstartyear = value; }
    }


    public string comment
    {
        get { return _comment; }
        set { _comment = value; }
    }


    public int StatusID
    {
        get { return _StatusID; }
        set { _StatusID = value; }
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


    public DateTime modifiedon
    {
        get { return _modifiedon; }
        set { _modifiedon = value; }
    }


    public int modifiedby
    {
        get { return _modifiedby; }
        set { _modifiedby = value; }
    }

}
