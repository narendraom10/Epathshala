using System;


public class SYS_Standard
{
    public SYS_Standard()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    int _standardid;
    string _standardidStr="";
    string _standard;
    string _code;
    string _description;
    bool _isactive;
    DateTime _createdon;
    int _createdby;
    DateTime _modifiedon;
    int _modifiedby;
    int _boardid;
    int _mediumid;
    int _userroleid;
    int _employeeid;
    int _schoolid;

    public int Schoolid
    {
        get { return _schoolid; }
        set { _schoolid = value; }
    }

    public int userroleid
    {
        get { return _userroleid; }
        set { _userroleid = value; }
    }
    public string standardidStr
    {
        get { return _standardidStr; }
        set { _standardidStr = value; }
    }
    

    public int employeeid
    {
        get { return _employeeid; }
        set { _employeeid = value; }
    }
    public int boardid
    {
        get { return _boardid; }
        set { _boardid = value; }
    }
    

    public int mediumid
    {
        get { return _mediumid; }
        set { _mediumid = value; }
    }

    public int standardid
    {
        get { return _standardid; }
        set { _standardid = value; }
    }


    public string standard
    {
        get { return _standard; }
        set { _standard = value; }
    }


    public string code
    {
        get { return _code; }
        set { _code = value; }
    }


    public string description
    {
        get { return _description; }
        set { _description = value; }
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