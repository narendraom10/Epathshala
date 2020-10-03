using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Data;

/// <summary>
/// Summary description for AgewiseStudentReport
/// </summary>
public class AgewiseStudentReport
{
    DataAccess Dal_ClasswiseCoveredSyllabus;
    //DataAccessEpathshalaStudent Dal_DataAccessEpathshalaStudent;
    DataAccess Dal_DataAccessEpathshalaStudent;
    ArrayList arrParameter;

    //public DataSet GetAgewiseStudentReport(int SchoolID, int BoardID, int MediumID, string GroupName, string Year)
    public DataSet GetAgewiseStudentReport(int schoolid, int BoardID, int MediumID, string GroupName, string Year)
    {
        //this.Dal_DataAccessEpathshalaStudent = new DataAccessEpathshalaStudent();
        this.Dal_DataAccessEpathshalaStudent = new DataAccess();

        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("SchoolID", schoolid));
        arrParameter.Add(new parameter("BoardID", BoardID));
        arrParameter.Add(new parameter("MediumID", MediumID));
        arrParameter.Add(new parameter("GroupName", GroupName));
        arrParameter.Add(new parameter("Year", Year));


        return this.Dal_DataAccessEpathshalaStudent.DAL_Select("Proc_AgewiseStudentReportNew", arrParameter);
    }
    public DataSet GetAgewise(int SchoolID, int BoardID, int MediumID, string GroupName, string Year, int StudentAgeGropIDPara)
    {
        //this.Dal_DataAccessEpathshalaStudent = new DataAccessEpathshalaStudent();

        this.Dal_DataAccessEpathshalaStudent = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("SchoolID", SchoolID));
        arrParameter.Add(new parameter("BoardID", BoardID));
        arrParameter.Add(new parameter("MediumID", MediumID));
        arrParameter.Add(new parameter("GroupName", GroupName));
        arrParameter.Add(new parameter("Year", Year));
        arrParameter.Add(new parameter("StudentAgeGropIDPara", StudentAgeGropIDPara));

        return this.Dal_DataAccessEpathshalaStudent.DAL_Select("Proc_AgewiseStudentReportSecond", arrParameter);
    }
    public DataSet GetAgewiseStudent(int SchoolID, int BoardID, int MediumID, string GroupName, string Year, int BMSID, int DivisionID, string Description)
    {
        //this.Dal_DataAccessEpathshalaStudent = new DataAccessEpathshalaStudent();
        this.Dal_DataAccessEpathshalaStudent = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("SchoolID", SchoolID));
        arrParameter.Add(new parameter("BoardID", BoardID));
        arrParameter.Add(new parameter("MediumID", MediumID));
        arrParameter.Add(new parameter("GroupName", GroupName));
        arrParameter.Add(new parameter("Year", Year));
        arrParameter.Add(new parameter("BMSID", BMSID));
        arrParameter.Add(new parameter("DivisionID", DivisionID));
        arrParameter.Add(new parameter("Description", Description));
        return this.Dal_DataAccessEpathshalaStudent.DAL_Select("Proc_AgewiseStudentReporThird", arrParameter);
    }
    public DataSet SelectBMS(int BMSID)
    {
        try
        {
            this.Dal_ClasswiseCoveredSyllabus = new DataAccess();
            arrParameter = new ArrayList();

            arrParameter.Add(new parameter("BMSID", BMSID));
            return this.Dal_ClasswiseCoveredSyllabus.DAL_Select("Proc_SelectBoardMediumStandardIDbyBMSID", arrParameter);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataSet SelectDivision(int DivisionID)
    {
        try
        {
            this.Dal_ClasswiseCoveredSyllabus = new DataAccess();
            arrParameter = new ArrayList();

            arrParameter.Add(new parameter("DivisionID", DivisionID));
            return this.Dal_ClasswiseCoveredSyllabus.DAL_Select("Proc_SelectDivisionbyDivisionID", arrParameter);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataSet SelectStudentAgeGrop(int StudentAgeGropID)
    {
        try
        {
            //this.Dal_DataAccessEpathshalaStudent = new DataAccessEpathshalaStudent();
            this.Dal_DataAccessEpathshalaStudent = new DataAccess();
            arrParameter = new ArrayList();

            arrParameter.Add(new parameter("StudentAgeGroupID", StudentAgeGropID));
            return this.Dal_DataAccessEpathshalaStudent.DAL_Select("Proc_SelectStudentAgeGrop", arrParameter);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}