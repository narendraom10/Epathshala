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

public class SYS_State
{
    public SYS_State()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    int _stateid;
    string _stateidStr="";
    int _countryid;
    string _state;
    bool _isactive;
    DateTime _createdon;
    int _createdby;


    public int stateid
    {
        get { return _stateid; }
        set { _stateid = value; }
    }
    public string stateidStr
    {
        get { return _stateidStr; }
        set { _stateidStr = value; }
    }

    public int countryid
    {
        get { return _countryid; }
        set { _countryid = value; }
    }


    public string state
    {
        get { return _state; }
        set { _state = value; }
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