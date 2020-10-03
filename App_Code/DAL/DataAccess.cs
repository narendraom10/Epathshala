/// <summary>
/// <Description>Data Access Class</Description>
/// <DevelopedBy>"Narendra"</DevelopedBy>
/// <Created Date> 15-10-2013</Date>
/// <UpdatedBy>"Sheel"</UpdatedBy>
/// <Created Date></Date>
/// </summary>

using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections;
using System.IO;

public class DataAccess
{

    #region Variables
    DataSet ds;
    SqlConnection conn;
    SqlCommand comm;
    SqlDataAdapter adt;
    #endregion

    #region Constructor
    public DataAccess()
    {
    }
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
            conn.ConnectionString = ConfigurationManager.AppSettings["EpathshalaCon"];
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
    public bool DAL_InsertUpdateWithStatus(string storeProcedureName, ArrayList parameters)
    {
        bool status = false;
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
            status = true;
        }
        catch (SqlException SqlException)
        {
            status = false;
            if (comm != null && comm.Connection.State == ConnectionState.Open)
            {
                comm.Connection.Close();
            }
        }
        finally
        {
            comm.Connection.Close();
        }
        return status;
    }
    public int DAL_InsertUpdate_Return(string storeProcedureName, ArrayList parameters)
    {
        int t1 = 0;
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
            t1 = comm.ExecuteNonQuery();
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
        return t1;
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

    public int DAL_Delete_Return(string storeProcedureName, ArrayList parameters)
    {
        int status = 0;
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
            return status = Convert.ToInt32(comm.ExecuteNonQuery());
        }
        catch (SqlException SqlException)
        {
            if (comm != null && comm.Connection.State == ConnectionState.Open)
            {
                comm.Connection.Close();
            }
            SqlException.Errors[0].ToString();
            return status = 0;
        }
        finally
        {
            comm.Connection.Close();
        }
        return status;
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


    public SqlCommand GetCommandBySQL(string strSQL)
    {
        comm = new SqlCommand();
        try
        {
            comm.Connection = GetConnection();
            comm.Connection.Open();
            comm.CommandType = CommandType.Text;
            comm.CommandText = strSQL;
        }
        catch (SqlException SqlException)
        { }
        return comm;
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
    public int Excutenonquery(string strSQL)
    {
        DataTable dt = new DataTable();
        SqlCommand cmd = new SqlCommand(strSQL, GetConnection());
        cmd.Connection.Open();
        int value = 0;
        try
        {
            return cmd.ExecuteNonQuery();
        }
        catch (SqlException SqlException)
        {

        }

        return value;






    }

    public void DAL_InsertUpdateDataTable(string storeProcedureName, ArrayList parameters, DataTable dt)
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

    public string DAL_InsertWithOutParameter(string storeProcedureName, ArrayList parameters, string OutParameter)
    {
        string OutParameterValue = string.Empty;
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
            if (!string.IsNullOrEmpty(OutParameter))
            {
                SqlParameter OutputParameter = new SqlParameter();
                OutputParameter.ParameterName = "@" + OutParameter;
                OutputParameter.Direction = System.Data.ParameterDirection.Output;
                OutputParameter.SqlDbType = SqlDbType.VarChar;
                OutputParameter.Size = 100;
                comm.Parameters.Add(OutputParameter);

                comm.ExecuteNonQuery();

                OutParameterValue = OutputParameter.Value.ToString();
            }
            else
            {
                OutParameterValue = "";
            }
        }
        catch (SqlException SqlException)
        {
            OutParameterValue = string.Empty;
            if (comm != null && comm.Connection.State == ConnectionState.Open)
            {
                comm.Connection.Close();
            }
        }
        finally
        {
            comm.Connection.Close();
        }
        return OutParameterValue;
    }
    #endregion
}

public class parameter
{
    #region Varibales
    private string m_sParamName;
    private object m_oParamValue;
    #endregion

    #region Property
    public string SParamName
    {
        get
        {
            return m_sParamName;
        }
        set
        {
            m_sParamName = value;
        }
    }

    public object OParamValue
    {
        get
        {
            return m_oParamValue;
        }
        set
        {
            m_oParamValue = value;
        }
    }
    #endregion

    #region User Define Functions
    public parameter(string parameterName, object parameterValue)
    {
        this.m_sParamName = parameterName;
        this.m_oParamValue = parameterValue;
    }
    #endregion
}