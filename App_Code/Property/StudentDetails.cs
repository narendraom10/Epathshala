using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for Myclass
/// </summary>
public class StudentDetails
{
    public StudentDetails()
	{
		//
		// TODO: Add constructor logic here
		//

	}
    private string firstname;
    private string lastname;
    private Int64 contactno;
    private DateTime dateofbirth;
    private char gender;
    private int schoolid;
    private string school;
    private string loginid;
    private int boardid;
    private int mediumid;
    private int standardid;
    private string password;

    public string FirstName
    {
        get { return firstname; }
        set { firstname = value; }
    }

    public string LastName
    {
        set { lastname = value; }
        get { return lastname; }
    }

    public Int64 ContactNo
    {
        set { contactno = value; }
        get { return contactno; }
    }

    public DateTime DateOfBirth
    {
        set { dateofbirth = value; }
        get { return dateofbirth; }
    }

    public char Gender
    {
        set { gender = value; }
        get { return gender; }
    }
    public int SchoolID
    {
        set { schoolid = value; }
        get { return schoolid; }
    }
    public string School
    {
        set { school = value; }
        get { return school; }
    }
    public string LoginID
    {
        set { loginid = value; }
        get { return loginid; }
    }
    public int BoardID
    {
        set { boardid = value; }
        get { return boardid; }
    }
    public int MediumID
    {
        set { mediumid = value; }
        get { return mediumid; }
    }

    public int StandardID
    {
        set { standardid = value; }
        get { return standardid; }
    }
    public string Password
    {
        set { password = value;}
        get { return password; }
    }
    
}