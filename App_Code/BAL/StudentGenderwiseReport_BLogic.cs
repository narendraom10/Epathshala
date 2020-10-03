using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;

/// <summary>
/// Summary description for StudentGenderwiseReport_BLogic
/// </summary>
public class StudentGenderwiseReport_BLogic
{
    //DataAccessEpathshalaStudent StudentwiseGenderReport;
    DataAccess StudentwiseGenderReport;
    ArrayList arrParameter;
    public StudentGenderwiseReport_BLogic()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public System.Data.DataSet GetSchoolwiseStudentGenderReport(int SchoolID)
    {
        try
        {
            //this.StudentwiseGenderReport = new DataAccessEpathshalaStudent();
            this.StudentwiseGenderReport = new DataAccess();
            arrParameter = new ArrayList();

            arrParameter.Add(new parameter("SchoolID", SchoolID));
            return this.StudentwiseGenderReport.DAL_Select("Proc_SchoolwiseStudentGenderReport", arrParameter);

        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    public System.Data.DataSet GetBMSwiseStudentGenderReport(int SchoolID, int BoardID, int MediumID, int StandardID, string AcademicYear)
    {
        try
        {
            //this.StudentwiseGenderReport = new DataAccessEpathshalaStudent();
            this.StudentwiseGenderReport = new DataAccess();

            arrParameter = new ArrayList();

            arrParameter.Add(new parameter("SchoolID", SchoolID));
            arrParameter.Add(new parameter("BoardID", BoardID));
            arrParameter.Add(new parameter("MediumID", MediumID));
            arrParameter.Add(new parameter("StandardID", StandardID));
            arrParameter.Add(new parameter("AcademicYear", AcademicYear));
            return this.StudentwiseGenderReport.DAL_Select("Proc_StudentGenderReportByBMSID", arrParameter);
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    public System.Data.DataSet GetStudentListBySchoolBMSGenderDivisionID(int SchoolID, int BMSID, int DivisionID, string AcademicYear)
    {
        try
        {
            //this.StudentwiseGenderReport = new DataAccessEpathshalaStudent();
            this.StudentwiseGenderReport = new DataAccess();

            arrParameter = new ArrayList();

            arrParameter.Add(new parameter("SchoolID", SchoolID));
            arrParameter.Add(new parameter("BMSID", BMSID));
            arrParameter.Add(new parameter("DivisionID", DivisionID));
            arrParameter.Add(new parameter("AcademicYear", AcademicYear));
            return this.StudentwiseGenderReport.DAL_Select("Proc_StudentListByBMSIDSchoolIDAcademicYear", arrParameter);
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    public System.Data.DataTable GetStudentDetailsByStudentIDAcademicYear(int StudentID, string AcademicYear)
    {
        try
        {
            //this.StudentwiseGenderReport = new DataAccessEpathshalaStudent();
            this.StudentwiseGenderReport = new DataAccess();

            arrParameter = new ArrayList();

            arrParameter.Add(new parameter("StudentID", StudentID));
            arrParameter.Add(new parameter("AcademicYear", AcademicYear));
            return this.StudentwiseGenderReport.DAL_Select("Proc_GetStudentDetailsByStudentIdAcademicYear", arrParameter).Tables[0];
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
}