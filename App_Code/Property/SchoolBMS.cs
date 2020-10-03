/// <summary> 
/// <DevelopedBy>"NARENDRASINH"</DevelopedBy>
/// <DevelopedDate></DevelopedDate>
/// <UpdatedBy>"NARENDRASINH"</UpdatedBy>
/// <UpdatedDate></UpdatedDate>
/// </summary>

public class SchoolBMS
{
    public SchoolBMS()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    int _schregbmsid;
    string _schregbmsidStr;
    int _schooltypeid;
    int _bmsid;
    int _schregid;
    int _noofstudents;
    string _starttime;
    string _endtime;
    int _StatusID;


    public int schregbmsid
    {
        get { return _schregbmsid; }
        set { _schregbmsid = value; }
    }
    public string schregbmsidStr
    {
        get { return _schregbmsidStr; }
        set { _schregbmsidStr = value; }
    }


    public int schooltypeid
    {
        get { return _schooltypeid; }
        set { _schooltypeid = value; }
    }


    public int bmsid
    {
        get { return _bmsid; }
        set { _bmsid = value; }
    }


    public int schregid
    {
        get { return _schregid; }
        set { _schregid = value; }
    }


    public int noofstudents
    {
        get { return _noofstudents; }
        set { _noofstudents = value; }
    }


    public string starttime
    {
        get { return _starttime; }
        set { _starttime = value; }
    }


    public string endtime
    {
        get { return _endtime; }
        set { _endtime = value; }
    }


    public int StatusID
    {
        get { return _StatusID; }
        set { _StatusID = value; }
    }

}