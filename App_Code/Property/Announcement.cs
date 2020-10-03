using System;


public class Announcement
{
    public Announcement()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    int _announcementid;
    int _bmsid;
    int _divisionid;
    DateTime _startdate;
    DateTime _enddate;
    string _announcement;
    DateTime _createdon;
    int _createdby;
    DateTime _modifiedon;
    int _modifiedby;
    string _divisionstr;


    public int announcementid
    {
        get { return _announcementid; }
        set { _announcementid = value; }
    }


    public int bmsid
    {
        get { return _bmsid; }
        set { _bmsid = value; }
    }


    public int divisionid
    {
        get { return _divisionid; }
        set { _divisionid = value; }
    }


    public DateTime startdate
    {
        get { return _startdate; }
        set { _startdate = value; }
    }


    public DateTime enddate
    {
        get { return _enddate; }
        set { _enddate = value; }
    }


    public string announcement
    {
        get { return _announcement; }
        set { _announcement = value; }
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

    public string divisionstr
    {
        get { return _divisionstr; }
        set { _divisionstr = value; }
    }
}