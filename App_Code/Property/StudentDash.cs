using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for StudentDashBoard
/// </summary>
public class StudentDash
{
	public StudentDash()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    Int64 _BMSID;
    Int64 _StudentID;
    Int16 _DivisionID;
    Int16 _SubjectID;
    Int64 _ChapterID;
    Int64 _TopicID;
    Int64 _SchoolID;
    Int16 _Month;
    Int32 _Year;
    string _ExamName;
    Int32 _TotalQues;
    Int32 _TotalMarks;
    Int64 _BMSSCTID;
    Int64 _ExamID;
    string _SubjectIDStr;
    string _mode;
    string _packageFDID;

    public string PackageFDID
    {
        get { return _packageFDID; }
        set { _packageFDID = value; }
    }

    public string Mode
    {
        get { return _mode; }
        set { _mode = value; }
    }

    public string SubjectIDStr
    {
        get { return _SubjectIDStr; }
        set { _SubjectIDStr = value; }
    }

    public Int64 BMSID
    {
        get { return _BMSID; }
        set { _BMSID = value; }
    }

    public Int64 SchoolID
    {
        get { return _SchoolID; }
        set { _SchoolID = value; }
    }

    public Int64 StudentID
    {
        get { return _StudentID; }
        set { _StudentID = value; }
    }

    public Int16 DivisionID
    {
        get { return _DivisionID; }
        set { _DivisionID = value; }
    }

    public Int16 SubjectID
    {
        get { return _SubjectID; }
        set { _SubjectID = value; }
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

    public Int16 Month
    {
        get { return _Month; }
        set { _Month = value; }
    }

    public Int32 Year
    {
        get { return _Year; }
        set { _Year = value; }
    }

    public string ExamName
    {
        get { return _ExamName; }
        set { _ExamName = value; }
    }

    public Int32 TotalQues
    {
        get { return _TotalQues; }
        set { _TotalQues = value; }
    }

    public Int32 TotalMarks
    {
        get { return _TotalMarks; }
        set { _TotalMarks = value; }
    }
    public Int64 BMSSCTID
    {
        get { return _BMSSCTID; }
        set { _BMSSCTID = value; }
    }

    public Int64 ExamID
    {
        get { return _ExamID; }
        set { _ExamID = value; }
    }
}