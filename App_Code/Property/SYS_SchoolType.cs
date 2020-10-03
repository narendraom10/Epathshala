using System;

/// <summary> 
/// <DevelopedBy>"NARENDRASINH"</DevelopedBy>
/// <DevelopedDate></DevelopedDate>
/// <UpdatedBy>"NARENDRASINH"</UpdatedBy>
/// <UpdatedDate></UpdatedDate>
/// </summary>
public class SYS_SchoolType
{
    public SYS_SchoolType()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    int _schooltypeid;
    string _schooltypeidStr="";
    string _type;
    bool _isactive;
    DateTime _createdon;
    int _createdby;


    public int schooltypeid
    {
        get { return _schooltypeid; }
        set { _schooltypeid = value; }
    }

    public string schooltypeidStr
    {
        get { return _schooltypeidStr; }
        set { _schooltypeidStr = value; }
    }

    public string type
    {
        get { return _type; }
        set { _type = value; }
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