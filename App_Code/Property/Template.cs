using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Template
/// </summary>
public class Template
{
    public Template()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    string _templatepath;
    string _title;
    string _subject;
    string _body;
    int _createdby;
    int _modifiedby;

    public string Templatepath
    {
        get { return _templatepath; }
        set { _templatepath = value; }
    }
    public string Title
    {
        get { return _title; }
        set { _title = value; }
    }
    public string Subject
    {
        get { return _subject; }
        set { _subject = value; }
    }
    public string Body
    {
        get { return _body; }
        set { _body = value; }
    }
    public int CreatedBy
    {
        get { return _createdby; }
        set { _createdby = value; }
    }
    public int Modifiedby
    {
        get { return _modifiedby; }
        set { _modifiedby = value; }
    }
}