using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

/// <summary> 
/// <DevelopedBy>"NARENDRASINH"</DevelopedBy>
/// <DevelopedDate></DevelopedDate>
/// <UpdatedBy>"NARENDRASINH"</UpdatedBy>
/// <UpdatedDate></UpdatedDate>
/// </summary>
public class SYS_Role
{
    public SYS_Role()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    int _roleid;
    string _roleidStr="";
    string _role;
    string _description;
    bool _isactive;
    DateTime _createdon;
    int _createdby;
    DateTime _modifiedon;
    int _modifiedby;

    string _Username;
    string _Password;

    string _Name;
    public int roleid
    {
        get { return _roleid; }
        set { _roleid = value; }
    }
    public string roleidStr
    {
        get { return _roleidStr; }
        set { _roleidStr = value; }
    }

    public string role
    {
        get { return _role; }
        set { _role = value; }
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

    public string Username
    {
        get { return _Username; }
        set { _Username = value; }
    }

    public string Password
    {
        get { return _Password; }
        set { _Password = value; }
    }
    public string Name
        {
        get { return _Name; }
        set { _Name = value; }
        }
    }
