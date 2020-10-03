using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Configuration;
using System.IO;

/// <summary>
/// Summary description for DataAccessEpathshalaStudent
/// </summary>
public class DataAccessEpathshalaStudent
{
	public DataAccessEpathshalaStudent()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    #region Variables
    DataSet ds;
    SqlConnection conn;
    SqlCommand comm;
    SqlDataAdapter adt;
    #endregion

   

    #region User Define Functions

    private SqlCommand GetCommand(string storedProcedureName)
    {
        comm = new SqlCommand();
        try
        {
            comm.Connection = GetConnection();
            comm.Connection.Open();
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = storedProcedureName;
        }
        catch (SqlException SqlException)
        { }
        return comm;
    }

    public SqlConnection GetConnection()
    {
        try
        {
            conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.AppSettings["EpathshalaStudentCon"];
            return conn;
        }
        catch (SqlException SqlException)
        {
            throw SqlException;
        }
    }

    public void DAL_InsertUpdate(string storeProcedureName, ArrayList parameters)
    {
        try
        {
            comm = GetCommand(storeProcedureName);
            if (parameters != null && parameters.Count > 0)
            {
                foreach (parameter parameter in parameters)
                {
                    comm.Parameters.AddWithValue("@" + parameter.SParamName, parameter.OParamValue);
                }
            }
            comm.ExecuteNonQuery();
        }
            catch (SqlException SqlException)
        {
            if (comm != null && comm.Connection.State == ConnectionState.Open)
            {
                comm.Connection.Close();
            }
        }
        finally
        {
            comm.Connection.Close();
        }
    }
    public void DAL_InsertUpdateDataTable(string storeProcedureName, ArrayList parameters,DataTable dt)
    {
        try
        {
            comm = GetCommand(storeProcedureName);
            if (parameters != null && parameters.Count > 0)
            {
                foreach (parameter parameter in parameters)
                {
                    comm.Parameters.AddWithValue("@" + parameter.SParamName, parameter.OParamValue);
                }

                String xmldata;
                StringWriter sw = new StringWriter();
                dt.WriteXml(sw);
                xmldata = sw.ToString();

                SqlParameter param = new SqlParameter("@TbResult", SqlDbType.Xml);
                param.Value = xmldata;
                comm.Parameters.Add(param);
            }
            comm.ExecuteNonQuery();
        }
        catch (SqlException SqlException)
        {
            if (comm != null && comm.Connection.State == ConnectionState.Open)
            {
                comm.Connection.Close();
            }
        }
        finally
        {
            comm.Connection.Close();
        }
    }

    public string DAL_Delete(string storeProcedureName, ArrayList parameters)
    {
        try
        {
            comm = GetCommand(storeProcedureName);
            if (parameters != null && parameters.Count > 0)
            {
                foreach (parameter parameter in parameters)
                {
                    comm.Parameters.AddWithValue("@" + parameter.SParamName, parameter.OParamValue);
                }
            }
            comm.ExecuteNonQuery();
        }
        catch (SqlException SqlException)
        {
            if (comm != null && comm.Connection.State == ConnectionState.Open)
            {
                comm.Connection.Close();
            }
            SqlException.Errors[0].ToString();
            return Convert.ToString(SqlException.Message);
        }
        finally
        {
            comm.Connection.Close();
        }
        return string.Empty;
    }

    public DataSet DAL_Select(string storeProcedureName, ArrayList parameters)
    {
        try
        {
            adt = new SqlDataAdapter();
            ds = new DataSet();
            comm = GetCommand(storeProcedureName);
            adt.SelectCommand = comm;
            if (parameters != null && parameters.Count > 0)
            {
                foreach (parameter parameter in parameters)
                {
                    comm.Parameters.AddWithValue("@" + parameter.SParamName, parameter.OParamValue);
                }
            }
            adt.Fill(ds);
        }
        catch (SqlException SqlException)
        {
            if (comm != null && comm.Connection.State == ConnectionState.Open)
            {
                comm.Connection.Close();
            }
        }
        finally
        {
            comm.Connection.Close();
        }
        return ds;
    }

    public DataSet DAL_SelectALL(string storeProcedureName)
    {
        try
        {
            adt = new SqlDataAdapter();
            ds = new DataSet();
            comm = GetCommand(storeProcedureName);
            adt.SelectCommand = comm;
           
            adt.Fill(ds);
        }
        catch (SqlException SqlException)
        {
            if (comm != null && comm.Connection.State == ConnectionState.Open)
            {
                comm.Connection.Close();
            }
        }
        finally
        {
            comm.Connection.Close();
        }
        return ds;
    }

    public int executescalre(string storeProcedureName)
    {
        int val = 0;
        try
        {
            comm = GetCommand(storeProcedureName);
            val = Convert.ToInt32(comm.ExecuteScalar());
        }
        catch (SqlException SqlException)
        {
            if (comm != null && comm.Connection.State == ConnectionState.Open)
            {
                comm.Connection.Close();
            }
        }
        finally
        {
            comm.Connection.Close();
        }
        
        return val;
    }

    public int executescalre(string storeProcedureName, ArrayList parameters)
    {
        int val = 0;
        try
        {
            comm = GetCommand(storeProcedureName);
            if (parameters != null && parameters.Count > 0)
            {
                foreach (parameter parameter in parameters)
                {
                    comm.Parameters.AddWithValue("@" + parameter.SParamName, parameter.OParamValue);
                }
            }
            val = Convert.ToInt32(comm.ExecuteScalar());
        }
        catch (SqlException SqlException)
        {
            if (comm != null && comm.Connection.State == ConnectionState.Open)
            {
                comm.Connection.Close();
            }
        }
        finally
        {
            comm.Connection.Close();
        }

        return val;
    }


    public DataTable GetDataTable(string strSQL)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(strSQL, GetConnection());
        try
        {
            da.Fill(dt);
        }
        catch (SqlException SqlException)
        {
            SqlException = null;
            return null;
        }
        return dt;
    }


    #endregion
}