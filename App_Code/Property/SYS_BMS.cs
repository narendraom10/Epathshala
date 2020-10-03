using System;

/// <summary> 
/// <DevelopedBy>"NARENDRASINH"</DevelopedBy>
/// <DevelopedDate></DevelopedDate>
/// <UpdatedBy>"NARENDRASINH"</UpdatedBy>
/// <UpdatedDate></UpdatedDate>
/// </summary>
public class SYS_BMS
{
    public SYS_BMS()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    int _bmsid;
    string _bmsidStr;
    int _boardid;
    int _mediumid;
    int _standardid;
    bool _issemester;
    DateTime _createdon;
    int _createdby;


    public int bmsid
    {
        get { return _bmsid; }
        set { _bmsid = value; }
    }
    public string bmsidStr
    {
        get { return _bmsidStr; }
        set { _bmsidStr = value; }
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


    public bool issemester
    {
        get { return _issemester; }
        set { _issemester = value; }
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