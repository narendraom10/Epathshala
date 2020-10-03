using System;

/// <summary> 
/// <DevelopedBy>"NARENDRASINH"</DevelopedBy>
/// <DevelopedDate></DevelopedDate>
/// <UpdatedBy>"NARENDRASINH"</UpdatedBy>
/// <UpdatedDate></UpdatedDate>
/// </summary>
public class SYS_Subject
{
    public SYS_Subject()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    int _subjectid;
    string _subjectidStr;
    string _subject;
    string _code;
    string _description;
    bool _isactive;
    DateTime _createdon;
    int _createdby;
    DateTime _modifiedon;
    int _modifiedby;


    public int subjectid
    {
        get { return _subjectid; }
        set { _subjectid = value; }
    }
    public string subjectidStr
    {
        get { return _subjectidStr; }
        set { _subjectidStr = value; }
    }

    public string subject
    {
        get { return _subject; }
        set { _subject = value; }
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