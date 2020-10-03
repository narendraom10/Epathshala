using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ClassRoomActivityLog
/// </summary>
public class ClassRoomActivityLog
{
    public ClassRoomActivityLog()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    Int64 _cralid;
    Int64 _bmssctid;
    Int64 _schoolid;
    Int64 _employeeid;
    Int16 _divisionid;
    Int64 _ReSchedulingID;
    Int64 _studentid;
    string _ActivityFeedback;

    int _FeedbackRating;
    public int FeedbackRating
    {
        get { return _FeedbackRating; }
        set { _FeedbackRating = value; }
    }


    public Int64 Studentid
    {
        get { return _studentid; }
        set { _studentid = value; }
    }
    Int64 _sReSchedulingID;

    public Int64 SReSchedulingID
    {
        get { return _sReSchedulingID; }
        set { _sReSchedulingID = value; }
    }

    public Int64 cralid
    {
        get { return _cralid; }
        set { _cralid = value; }
    }


    public Int64 bmssctid
    {
        get { return _bmssctid; }
        set { _bmssctid = value; }
    }

    public Int64 ReSchedulingID
    {
        get { return _ReSchedulingID; }
        set { _ReSchedulingID = value; }
    }


    public Int64 schoolid
    {
        get { return _schoolid; }
        set { _schoolid = value; }
    }


    public Int64 employeeid
    {
        get { return _employeeid; }
        set { _employeeid = value; }
    }


    public Int16 divisionid
    {
        get { return _divisionid; }
        set { _divisionid = value; }
    }
    public string ActivityFeedback
    {
        get { return _ActivityFeedback; }
        set { _ActivityFeedback = value; }
    }
}