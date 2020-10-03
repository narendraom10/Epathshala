/// <summary> 
/// <DevelopedBy>"NARENDRASINH"</DevelopedBy>
/// <DevelopedDate></DevelopedDate>
/// <UpdatedBy>"NARENDRASINH"</UpdatedBy>
/// <UpdatedDate></UpdatedDate>
/// </summary>
using System;


public class SYS_Division
{
    public SYS_Division()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    string _divisionidStr="";
    int _divisionid=0;
    string _division="";
    string _description;
    bool _isactive;
    DateTime _createdon;
    int _createdby;
    DateTime _modifiedon;
    int _modifiedby;


    public string divisionidStr
    {
        get { return _divisionidStr; }
        set { _divisionidStr = value; }
    }


    public int divisionid
    {
        get { return _divisionid; }
        set { _divisionid = value; }
    }


    public string division
    {
        get { return _division; }
        set { _division = value; }
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