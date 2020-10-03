using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SYS_Attendance
/// </summary>
public class SYS_Attendance
{
	public SYS_Attendance()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    int _StudentId;
    int _rollno;
    string _FirstName;
    int _DivisionId;
    string _DivisionIdstr = "";
    int _BMSID;
    int _EmployeeID;
    char _Status;
    string _MiddleName;
    string _LastName;
    string _FullName;
    string _AttedanceDetails;
    int _SchoolID;
    int _StandardID;
    int _BoardID;
    DateTime _AttendanceDate;
    string _SortBy;
    DateTime _StartDate;
    DateTime _EndDate;
    

    public DateTime EndDate
    {
        get { return _EndDate; }
        set { _EndDate = value; }
    }

    public DateTime StartDate
    {
        get { return _StartDate; }
        set { _StartDate = value; }
    }
   

    public string SortBy
    {
        get { return _SortBy; }
        set { _SortBy = value; }
    }

    public DateTime AttendanceDate
    {
        get { return _AttendanceDate; }
        set { _AttendanceDate = value; }
    }

    

    public int BoardID
    {
        get { return _BoardID; }
        set { _BoardID = value; }
    }

    public int SchoolID
    {
        get { return _SchoolID; }
        set { _SchoolID = value; }
    }

    public int StandardID
    {
        get { return _StandardID; }
        set { _StandardID = value; }
    }

    public string AttedanceDetails
    {
        get { return _AttedanceDetails; }
        set { _AttedanceDetails = value; }
    }

    public string FullName
    {
        get { return _FullName; }
        set { _FullName = value; }
    }

    public string LastName
    {
        get { return _LastName; }
        set { _LastName = value; }
    }

    public string MiddleName
    {
        get { return _MiddleName; }
        set { _MiddleName = value; }
    }

    public char Status
    {
        get { return _Status; }
        set { _Status = value; }
    }

    public int EmployeeID
    {
        get { return _EmployeeID; }
        set { _EmployeeID = value; }
    }

    public int BMSID
    {
        get { return _BMSID; }
        set { _BMSID = value; }
    }

    public int DivisionId
    {
        get { return _DivisionId; }
        set { _DivisionId = value; }
    }
    public string DivisionIdstr
    {
        get { return _DivisionIdstr; }
        set { _DivisionIdstr = value; }
    }
    public int StudentId
    {
        get { return _StudentId; }
        set { _StudentId = value; }
    }
   

    public string FirstName
    {
        get { return _FirstName; }
        set { _FirstName = value; }
    }

    public int Rollno
    {
        get { return _rollno; }
        set { _rollno = value; }
    }
   
}