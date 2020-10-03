using System;
/// <summary> 
/// <DevelopedBy>"NARENDRASINH"</DevelopedBy>
/// <DevelopedDate></DevelopedDate>
/// <UpdatedBy>"NARENDRASINH"</UpdatedBy>
/// <UpdatedDate></UpdatedDate>
/// </summary>

public class EmployeeStandardDetail
{
    public EmployeeStandardDetail()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    int _empstdid;
    int _employeeid;
    int _bmsid;
    int _subjectid;
    int _divisionid;
    bool _isclassteacher;
    DateTime _createdon;
    int _createdby;
    string _subjectidstr;
    string _subjectidForDeletestr;
    string _divisionidstr;

    public int empstdid
    {
        get { return _empstdid; }
        set { _empstdid = value; }
    }


    public int employeeid
    {
        get { return _employeeid; }
        set { _employeeid = value; }
    }


    public int bmsid
    {
        get { return _bmsid; }
        set { _bmsid = value; }
    }


    public int subjectid
    {
        get { return _subjectid; }
        set { _subjectid = value; }
    }


    public string divisionidstr
    {
        get { return _divisionidstr; }
        set { _divisionidstr = value; }
    }
    public string subjectidstr
    {
        get { return _subjectidstr; }
        set { _subjectidstr = value; }
    }
    public string subjectidForDeletestr
    {
        get { return _subjectidForDeletestr; }
        set { _subjectidForDeletestr = value; }
    }

    public int divisionid
    {
        get { return _divisionid; }
        set { _divisionid = value; }
    }

    public bool isclassteacher
    {
        get { return _isclassteacher; }
        set { _isclassteacher = value; }
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