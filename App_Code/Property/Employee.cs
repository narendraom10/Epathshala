using System;


public class Employee
{
    public Employee()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    int _employeeid;
    string _code;
    int _roleid;
    int _schoolid;
    string _firstname;
    string _middlename;
    string _lastname;
    char _gender;
    DateTime _dateofbirth;
    string _bloodgroup;
    string _address;
    string _emailid;
    Int32 _contactno;
    string _qualification;
    string _designation;
    int _securityquestion;
    string _securityanswer;
    string _loginid;
    string _password;
    byte _image;
    DateTime _lastlogindate;
    int _attemptcount;
    bool _isactive;
    DateTime _createdon;
    int _createdby;
    DateTime _modifiedon;
    int _modifiedby;
    string _userid;
    bool _status;
    string _studentlist;
    string _MobileNumber;

    public string Studentlist
    {
        get { return _studentlist; }
        set { _studentlist = value; }
    }

    public string userid
    {
        get { return _userid; }
        set { _userid = value; }
    }

    public bool status
    {
        get { return _status; }
        set { _status = value; }
    }



    public int employeeid
    {
        get { return _employeeid; }
        set { _employeeid = value; }
    }


    public string code
    {
        get { return _code; }
        set { _code = value; }
    }


    public int roleid
    {
        get { return _roleid; }
        set { _roleid = value; }
    }


    public int schoolid
    {
        get { return _schoolid; }
        set { _schoolid = value; }
    }


    public string firstname
    {
        get { return _firstname; }
        set { _firstname = value; }
    }


    public string middlename
    {
        get { return _middlename; }
        set { _middlename = value; }
    }


    public string lastname
    {
        get { return _lastname; }
        set { _lastname = value; }
    }


    public char gender
    {
        get { return _gender; }
        set { _gender = value; }
    }


    public DateTime dateofbirth
    {
        get { return _dateofbirth; }
        set { _dateofbirth = value; }
    }


    public string bloodgroup
    {
        get { return _bloodgroup; }
        set { _bloodgroup = value; }
    }


    public string address
    {
        get { return _address; }
        set { _address = value; }
    }


    public string emailid
    {
        get { return _emailid; }
        set { _emailid = value; }
    }


    public Int32 contactno
    {
        get { return _contactno; }
        set { _contactno = value; }
    }


    public string qualification
    {
        get { return _qualification; }
        set { _qualification = value; }
    }


    public string designation
    {
        get { return _designation; }
        set { _designation = value; }
    }


    public int securityquestion
    {
        get { return _securityquestion; }
        set { _securityquestion = value; }
    }


    public string securityanswer
    {
        get { return _securityanswer; }
        set { _securityanswer = value; }
    }


    public string loginid
    {
        get { return _loginid; }
        set { _loginid = value; }
    }


    public string password
    {
        get { return _password; }
        set { _password = value; }
    }

    byte[] _image1 = new byte[1024];
    public byte[] image1
    {
        get { return _image1; }
        set { _image1 = value; }
    }

    public byte image
    {
        get { return _image; }
        set { _image = value; }
    }


    public DateTime lastlogindate
    {
        get { return _lastlogindate; }
        set { _lastlogindate = value; }
    }


    public int attemptcount
    {
        get { return _attemptcount; }
        set { _attemptcount = value; }
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
    public string MobileNumber
    {
        get { return _MobileNumber; }
        set { _MobileNumber = value; }
    }

}
