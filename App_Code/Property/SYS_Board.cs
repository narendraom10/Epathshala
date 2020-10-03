/// <summary> 
/// <DevelopedBy>"NARENDRASINH"</DevelopedBy>
/// <DevelopedDate></DevelopedDate>
/// <UpdatedBy>"NARENDRASINH"</UpdatedBy>
/// <UpdatedDate></UpdatedDate>
/// </summary>
using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;


public class SYS_Board
{
    public SYS_Board()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    int _boardid;
    string _boardidStr;
    string _board;
    string _code;
    string _description;
    bool _isactive=false;
    DateTime _createdon;
    int _createdby;
    DateTime _modifiedon;
    int _modifiedby;


    public int boardid
    {
        get { return _boardid; }
        set { _boardid = value; }
    }
    public string boardidStr
    {
        get { return _boardidStr; }
        set { _boardidStr = value; }
    }
    

    public string board
    {
        get { return _board; }
        set { _board = value; }
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