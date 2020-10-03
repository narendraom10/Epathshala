using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for TeacherNotes
/// </summary>
public class TeacherNotes
{

	public TeacherNotes()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    int _bmsId;
    int _bmssctID;
    string _note;
    int _employeeId;
    string _notes;

    public string Notes
    {
        get { return _notes; }
        set { _notes = value; }
    }


    public int BmssctID
    {
        get { return _bmssctID; }
        set { _bmssctID = value; }
    }
    public string Note
    {
        get { return _note; }
        set { _note = value; }
    }

    public int EmployeeId
    {
        get { return _employeeId; }
        set { _employeeId = value; }
    }

    public int BmsId
    {
        get { return _bmsId; }
        set { _bmsId = value; }
    }
}