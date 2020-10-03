using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UserList
/// </summary>
public class UserList
{
	public UserList()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    private int _schoolid;
    string _mode;
    string _searchcategory;
    string _searchcondition;
    int _employeeid;
    int _employeeroleid;
    int _standardid;
    int _divisionid;
    int _roleid;

    public int Employeeroleid
    {
        get { return _employeeroleid; }
        set { _employeeroleid = value; }
    }

    public int employeeid
    {
        get { return _employeeid; }
        set { _employeeid = value; }
    }

    public string searchcondition
    {
        get { return _searchcondition; }
        set { _searchcondition = value; }
    }

    public string searchcategory
    {
        get { return _searchcategory; }
        set { _searchcategory = value; }
    }

    public string mode
    {
        get { return _mode; }
        set { _mode = value; }
    }

    public int schoolid
    {
        get { return _schoolid; }
        set { _schoolid = value; }
    }
    public int Standardid
    {
        get { return _standardid; }
        set { _standardid = value; }
    }
    public int Divisionid
    {
        get { return _divisionid; }
        set { _divisionid = value; }
    }
    public int Roleid
    {
        get { return _roleid; }
        set { _roleid = value; }
    }
}