using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary> 
/// <DevelopedBy>"SHAILENDRASINH"</DevelopedBy>
/// <DevelopedDate></DevelopedDate>
/// <UpdatedBy>"SHAILENDRASINH"</UpdatedBy>
/// <UpdatedDate></UpdatedDate>
/// </summary>
public class SYS_Rescheduling
{
    public SYS_Rescheduling()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    Int64 _ReSchedulingID;
    Int64 _BMSSCTID;
    Int64 _ChapterID;
    Int64 _TopicID;
    Int64 _SchoolID;
    Int64 _EmployeeID;
    Int16 _DivisionID;
    DateTime _StartDate;
    DateTime _EndDate;
    Int64 _StudentID;
    Int64 _SReSchedulingID;



    public Int64 SReSchedulingID
    {
        get { return _SReSchedulingID; }
        set { _SReSchedulingID = value; }
    }

    public Int64 StudentID
    {
        get { return _StudentID; }
        set { _StudentID = value; }
    }


    public Int64 ReSchedulingID
    {
        get { return _ReSchedulingID; }
        set { _ReSchedulingID = value; }
    }

    public Int64 BMSSCTID
    {
        get { return _BMSSCTID; }
        set { _BMSSCTID = value; }
    }

    public Int64 ChapterID
    {
        get { return _ChapterID; }
        set { _ChapterID = value; }
    }

    public Int64 TopicID
    {
        get { return _TopicID; }
        set { _TopicID = value; }
    }

    public Int64 SchoolID
    {
        get { return _SchoolID; }
        set { _SchoolID = value; }
    }

    public Int64 EmployeeID
    {
        get { return _EmployeeID; }
        set { _EmployeeID = value; }
    }

    public Int16 DivisionID
    {
        get { return _DivisionID; }
        set { _DivisionID = value; }
    }

    public DateTime StartDate
    {
        get { return _StartDate; }
        set { _StartDate = value; }
    }

    public DateTime EndDate
    {
        get { return _EndDate; }
        set { _EndDate = value; }
    }
}
