using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

/// <summary>
/// Summary description for GetConnectionStringSTRING
/// </summary>
public class GetConnectionStringSTRING
{
    DataAccess dataaccess;
	public GetConnectionStringSTRING()
	{
       
		//
		// TODO: Add constructor logic here
		//
	}
    public string BAL_EpathshalaString()
    {
        dataaccess = new DataAccess();
        SqlConnection SQLConn = dataaccess.GetConnection();
        return SQLConn.ConnectionString.ToString();
    }
    public string BAL_EpathshalaStudentString()
    {
        DataAccessEpathshalaStudent dataaccessEpathshala = new DataAccessEpathshalaStudent();
        SqlConnection SQLConn = dataaccessEpathshala.GetConnection();
        return SQLConn.ConnectionString.ToString();
    }
}