using System;


public class Student
{
    public Student()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    string _studentidStr;
    int _studentid;
    int _schoolid;
    int _bmsid;
    int _divisionid;
    int _roleid;
    string _studentcode;
    string _loginid;
    string _password;
    string _firstname;
    string _middlename;
    string _lastname;
    Int16 _rollno;
    Int64 _contactno;

    //string _contactno;
    Int64 _mobileno;
    string _mobilenostring;
    string _emailid;
    string _grno;
    DateTime _dateofbirth;
    char _gender;
    string _bloodgroup;
    bool _isactive;
    DateTime _createdon;
    int _createdby;
    DateTime _modifiedon;
    int _modifiedby;
    string _address;
    char _paymentType;
    Byte[] picture;

    string _fathername;
    string _fathercontact;
    string _fatheremail;
    string _mothername;
    string _mothercontact;
    string _motheremail;
    string _guardianname;
    string _guardiancontact;
    string _guardianemail;
    string _city;
    string _zipcode;
    string _schoolname;
    string _schoolcontact;
    string _schoolemail;
    string _state;
    string _country;

    public char PaymentType
    {
        get { return _paymentType; }
        set { _paymentType = value; }
    }

    public string Address
    {
        get { return _address; }
        set { _address = value; }
    }


    public string studentidStr
    {
        get { return _studentidStr; }
        set { _studentidStr = value; }
    }


    public int studentid
    {
        get { return _studentid; }
        set { _studentid = value; }
    }


    public int schoolid
    {
        get { return _schoolid; }
        set { _schoolid = value; }
    }


    public int bmsid
    {
        get { return _bmsid; }
        set { _bmsid = value; }
    }


    public int divisionid
    {
        get { return _divisionid; }
        set { _divisionid = value; }
    }


    public int roleid
    {
        get { return _roleid; }
        set { _roleid = value; }
    }


    public string studentcode
    {
        get { return _studentcode; }
        set { _studentcode = value; }
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


    public Int16 rollno
    {
        get { return _rollno; }
        set { _rollno = value; }
    }

    public Int64 contactno
    {
        get { return _contactno; }
        set { _contactno = value; }
    }

    public Int64 mobileno
    {
        get { return _mobileno; }
        set { _mobileno = value; }
    }

    public string mobilenostring
    {
        get { return _mobilenostring; }
        set { _mobilenostring = value; }
    }


    public string emailid
    {
        get { return _emailid; }
        set { _emailid = value; }
    }

    public string schoolname
    {
        get { return _schoolname; }
        set { _schoolname = value; }
    }


    public string grno
    {
        get { return _grno; }
        set { _grno = value; }
    }


    public DateTime dateofbirth
    {
        get { return _dateofbirth; }
        set { _dateofbirth = value; }
    }


    public char gender
    {
        get { return _gender; }
        set { _gender = value; }
    }


    public string bloodgroup
    {
        get { return _bloodgroup; }
        set { _bloodgroup = value; }
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
    public Byte[] Picture
    {
        get { return picture; }
        set { picture = value; }
    }

    public string FatherName
    {
        get { return _fathername; }
        set { _fathername = value; }
    }

    public string FatherContact
    {
        get { return _fathercontact; }
        set { _fathercontact = value; }
    }

    public string FatherEmail
    {
        get { return _fatheremail; }
        set { _fatheremail = value; }
    }

    public string MotherName
    {
        get { return _mothername; }
        set { _mothername = value; }
    }

    public string MotherContact
    {
        get { return _mothercontact; }
        set { _mothercontact = value; }
    }

    public string MotherEmail
    {
        get { return _motheremail; }
        set { _motheremail = value; }
    }

    public string GuardianName
    {
        get { return _guardianname; }
        set { _guardianname = value; }
    }

    public string GuardianContact
    {
        get { return _guardiancontact; }
        set { _guardiancontact = value; }
    }

    public string GuardianEmail
    {
        get { return _guardianemail; }
        set { _guardianemail = value; }
    }

    public string SchoolContact
    {
        get { return _schoolcontact; }
        set { _schoolcontact = value; }
    }

    public string SchoolEmail
    {
        get { return _schoolemail; }
        set { _schoolemail = value; }
    }

    public string City
    {
        get { return _city; }
        set { _city = value; }
    }

    public string Zipcode
    {
        get { return _zipcode; }
        set { _zipcode = value; }
    }

    public string State
    {
        get { return _state; }
        set { _state = value; }
    }

    public string Country
    {
        get { return _country; }
        set { _country = value; }
    }


}