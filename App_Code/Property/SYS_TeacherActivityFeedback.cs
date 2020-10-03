using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary> 
/// <DevelopedBy>"Shailendrasinh"</DevelopedBy>
/// <DevelopedDate></DevelopedDate>
/// <UpdatedBy>"Shailendrasinh"</UpdatedBy>
/// <UpdatedDate></UpdatedDate>
/// </summary>
public class SYS_TeacherActivityFeedback
{
    public SYS_TeacherActivityFeedback()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    int _ActivityFeedbackID;
    int _SchoolID;
    int _BMSSCTID;
    int _EmployeeID;
    int _DivisionID;
    string _Feedback;
    DateTime _CreatedOn;
    int _CreatedBy;
    string _FeedbackQuestion;
    int _StudentID;

    public int StudentID
    {
        get { return _StudentID; }
        set { _StudentID = value; }
    }

    public string FeedbackQuestion
    {
        get { return _FeedbackQuestion; }
        set { _FeedbackQuestion = value; }
    }

    public int ActivityFeedbackID
    {
        get { return _ActivityFeedbackID; }
        set { _ActivityFeedbackID = value; }
    }

    public int SchoolID
    {
        get { return _SchoolID; }
        set { _SchoolID = value; }
    }

    public int BMSSCTID
    {
        get { return _BMSSCTID; }
        set { _BMSSCTID = value; }
    }

    public int EmployeeID
    {
        get { return _EmployeeID; }
        set { _EmployeeID = value; }
    }

    public int DivisionID
    {
        get { return _DivisionID; }
        set { _DivisionID = value; }
    }

    public string Feedback
    {
        get { return _Feedback; }
        set { _Feedback = value; }
    }

    public DateTime CreatedOn
    {
        get { return _CreatedOn; }
        set { _CreatedOn = value; }
    }

    public int CreatedBy
    {
        get { return _CreatedBy; }
        set { _CreatedBy = value; }
    }


}