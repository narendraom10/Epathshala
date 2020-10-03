/// <summary> 
/// <DevelopedBy>"NARENDRASINH"</DevelopedBy>
/// <DevelopedDate></DevelopedDate>
/// <UpdatedBy>"NARENDRASINH"</UpdatedBy>
/// <UpdatedDate></UpdatedDate>
/// </summary>
using System;

public class SYS_Medium
{
    public SYS_Medium()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    int _mediumid;
    string _mediumidStr="";
    string _medium;
    string _code;
    string _description;
    bool _isactive;
    DateTime _createdon;
    int _createdby;
    DateTime _modifiedon;
    int _modifiedby;
    int _boardid;

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
    public string mediumidStr
    {
        get { return _mediumidStr; }
        set { _mediumidStr = value; }
    }

    public string medium
    {
        get { return _medium; }
        set { _medium = value; }
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