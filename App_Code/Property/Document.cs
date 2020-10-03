using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Template
/// </summary>
public class MailDocument
{
    public MailDocument()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    string _Documentpath;
    string _title;
    string _body;
    
    public string Documentpath
    {
        get { return _Documentpath; }
        set { _Documentpath = value; }
    }
    public string Title
    {
        get { return _title; }
        set { _title = value; }
    }
    public string Body
    {
        get { return _body; }
        set { _body = value; }
    }
}