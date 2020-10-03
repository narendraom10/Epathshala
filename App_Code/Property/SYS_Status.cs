using System;

/// <summary> 
/// <DevelopedBy>"NARENDRASINH"</DevelopedBy>
/// <DevelopedDate></DevelopedDate>
/// <UpdatedBy>"NARENDRASINH"</UpdatedBy>
/// <UpdatedDate></UpdatedDate>
/// </summary>
public class SYS_Status
{
    public SYS_Status()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    int _statusid;
    string _status;


    public int statusid
    {
        get { return _statusid; }
        set { _statusid = value; }
    }


    public string status
    {
        get { return _status; }
        set { _status = value; }
    }

}
