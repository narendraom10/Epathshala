using System;
/// <summary> 
/// <DevelopedBy>"NARENDRASINH"</DevelopedBy>
/// <DevelopedDate></DevelopedDate>
/// <UpdatedBy>"NARENDRASINH"</UpdatedBy>
/// <UpdatedDate></UpdatedDate>
/// </summary>
public class SYS_Topic
{
    public SYS_Topic()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    string _topicidStr;
    int _topicid;
    int _chapterid;
    int _topicindex;
    string _topic;
    bool _isactive;
    DateTime _createdon;
    int _createdby;
    string _topicidlist;

    string _tlist;

    public string Tlist
    {
        get { return _tlist; }
        set { _tlist = value; }
    }

    public string Topicidlist
    {
        get { return _topicidlist; }
        set { _topicidlist = value; }
    }

    public string topicidStr
    {
        get { return _topicidStr; }
        set { _topicidStr = value; }
    }


    public int topicid
    {
        get { return _topicid; }
        set { _topicid = value; }
    }


    public int chapterid
    {
        get { return _chapterid; }
        set { _chapterid = value; }
    }


    public int topicindex
    {
        get { return _topicindex; }
        set { _topicindex = value; }
    }


    public string topic
    {
        get { return _topic; }
        set { _topic = value; }
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