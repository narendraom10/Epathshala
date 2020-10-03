/// <summary> 
/// <DevelopedBy>"NARENDRASINH"</DevelopedBy>
/// <DevelopedDate></DevelopedDate>
/// <UpdatedBy>"NARENDRASINH"</UpdatedBy>
/// <UpdatedDate></UpdatedDate>
/// </summary>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SYS_Chapter
/// </summary>
public class SYS_Chapter
{

    Int64 _chapterid;
    Int64 _bmsid;
    Int16 _subjectid;
    Int16 _chapterindex;
    string _chapter;
    Int64 _employeeid;
    string _topic;
    Int64 _topicid;
    Int64 _sctid;
    Int16 _topicindex;
    string _filetype;
    string _code;
    string _description;
    bool _isactive;
    DateTime _createdon;
    int _createdby;
    DateTime _modifiedon;
    int _modifiedby;
    string _mode;
    int _schoolid;
    string _chpateridlist;

    public string Chpateridlist
    {
        get { return _chpateridlist; }
        set { _chpateridlist = value; }
    }

    public int Schoolid
    {
        get { return _schoolid; }
        set { _schoolid = value; }
    }

    public string Mode
    {
        get { return _mode; }
        set { _mode = value; }
    }

    public Int64 chapterid
    {
        get { return _chapterid; }
        set { _chapterid = value; }
    }

    public Int64 topicid
    {
        get { return _topicid; }
        set { _topicid = value; }
    }

    public Int64 sctid
    {
        get { return _sctid; }
        set { _sctid = value; }
    }

    public Int64 bmsid
    {
        get { return _bmsid; }
        set { _bmsid = value; }
    }

    public Int64 employeeid
    {
        get { return _employeeid; }
        set { _employeeid = value; }
    }

    public Int16 subjectid
    {
        get { return _subjectid; }
        set { _subjectid = value; }
    }

    public Int16 chapterindex
    {
        get { return _chapterindex; }
        set { _chapterindex = value; }
    }

    public Int16 topicindex
    {
        get { return _topicindex; }
        set { _topicindex = value; }
    }

    public string chapter
    {
        get { return _chapter; }
        set { _chapter = value; }
    }

    public string topic
    {
        get { return _topic; }
        set { _topic = value; }
    }

    public string filetype
    {
        get { return _filetype; }
        set { _filetype = value; }
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