using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;

public class StudentWiseCoveredSyllabus
{
    DataAccess Dal_StudentWiseCoveredSyllabus;
    ArrayList arrParameter;

    public DataSet BAL_GetStudentWiseCoveredDetails(int studentID, int bmssctID)
    {
        try
        {
            this.Dal_StudentWiseCoveredSyllabus = new DataAccess();
            arrParameter = new ArrayList();

            arrParameter.Add(new parameter("studentID", studentID));
            arrParameter.Add(new parameter("bmssctID", bmssctID));

            return this.Dal_StudentWiseCoveredSyllabus.DAL_Select("Proc_StudentWiseCoveredSyllabus", arrParameter);
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    public Boolean BAL_InsertStudentWiseCoveredDetails(int studentID, int bmssctID, string resource, Boolean isCovered, string note = "")
    {
        try
        {
            this.Dal_StudentWiseCoveredSyllabus = new DataAccess();
            arrParameter = new ArrayList();

            arrParameter.Add(new parameter("studentID", studentID));
            arrParameter.Add(new parameter("bmssctID", bmssctID));
            arrParameter.Add(new parameter("isCovered", isCovered));
            arrParameter.Add(new parameter("note", note));

            this.Dal_StudentWiseCoveredSyllabus.DAL_InsertUpdate("Proc_Insert_StudentWiseCoveredSyllabus", arrParameter);
            return true;
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    public Boolean BAL_UpdateStudentWiseCoveredDetails(int studentID, int bmssctID, string resource, Boolean isCovered, string note = "")
    {
        try
        {
            this.Dal_StudentWiseCoveredSyllabus = new DataAccess();
            arrParameter = new ArrayList();

            arrParameter.Add(new parameter("studentID", studentID));
            arrParameter.Add(new parameter("bmssctID", bmssctID));
            arrParameter.Add(new parameter("isCovered", isCovered));
            arrParameter.Add(new parameter("note", note));

            this.Dal_StudentWiseCoveredSyllabus.DAL_InsertUpdate("Proc_Update_StudentWiseCoveredSyllabus", arrParameter);
            return true;
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    public Boolean BAL_AppendStudentWiseCoveredDetails(int studentID, int bmssctID, string resource, string resourceType, Boolean isCovered, string note = "")
    {
        try
        {
            this.Dal_StudentWiseCoveredSyllabus = new DataAccess();
            arrParameter = new ArrayList();

            arrParameter.Add(new parameter("studentID", studentID));
            arrParameter.Add(new parameter("bmssctID", bmssctID));
            arrParameter.Add(new parameter("isCovered", isCovered));
            arrParameter.Add(new parameter("resource", resource));
            arrParameter.Add(new parameter("resourceType", resourceType));
            arrParameter.Add(new parameter("note", note));

            this.Dal_StudentWiseCoveredSyllabus.DAL_InsertUpdate("Proc_Append_StudentWiseCoveredSyllabus", arrParameter);
            return true;
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    public Boolean BAL_IsResourceTypeCovered(int studentID, int bmssctID, resourceType resourceType)
    {
        try
        {

            arrParameter = new ArrayList();

            arrParameter.Add(new parameter("studentID", studentID));
            arrParameter.Add(new parameter("bmssctID", bmssctID));
            arrParameter.Add(new parameter("resourceType", resourceType.ToString()));

            DataAccess da = new DataAccess();
            if (da.executescalre("PROC_IsResourceTypeCovered", arrParameter) == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception)
        {
            return false;
            throw;
        }
    }

    //_GET_SubjectWiseCoveredPercentage

    public DataSet BAL_GET_SubjectWiseCoveredPercentage(int studentID, int bmsID, int subjectID)
    {
        try
        {
            arrParameter = new ArrayList();

            arrParameter.Add(new parameter("studentID", studentID));
            arrParameter.Add(new parameter("bmsID", bmsID));
            arrParameter.Add(new parameter("subjectID", subjectID));

            DataAccess da = new DataAccess();
            //return Convert.ToInt16(da.executescalre("Proc_GET_SubjectWiseCoveredPercentage", arrParameter));

            return da.DAL_Select("Proc_GET_SubjectWiseCoveredPercentage", arrParameter);
        }
        catch (Exception)
        {
            return null;
        }
    }


}


public enum resourceType { Video, Test }