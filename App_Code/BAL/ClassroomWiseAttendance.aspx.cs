using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Data;

/// <summary>
/// Summary description for ClassroomWiseAttendance
/// </summary>
public class ClassroomWiseAttendance
{
     DataAccess Dal_ClasswiseCoveredSyllabus;
     ArrayList arrParameter;

     public DataSet GetClasswiseAttendance(int SchoolID, int BoardID, int MediumID, int StandardID, int DivisionID, DateTime Date)
    {
        this.Dal_ClasswiseCoveredSyllabus = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("SchoolID", SchoolID));
        arrParameter.Add(new parameter("BoardID", BoardID));
        arrParameter.Add(new parameter("MediumID", MediumID));     
        arrParameter.Add(new parameter("StandardID", StandardID));
        arrParameter.Add(new parameter("DivisionID", DivisionID));
        arrParameter.Add(new parameter("Date", Date));

        return this.Dal_ClasswiseCoveredSyllabus.DAL_Select("Proc_ClassroomWiseAttendance", arrParameter);
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


     public DataSet GetAttendance(int SchoolID,DateTime Date,int BMSID)
     {
         this.Dal_ClasswiseCoveredSyllabus = new DataAccess();
         arrParameter = new ArrayList();

         arrParameter.Add(new parameter("SchoolID", SchoolID));
         arrParameter.Add(new parameter("CreatedOn", Date));
         arrParameter.Add(new parameter("BMSID", BMSID));

         return this.Dal_ClasswiseCoveredSyllabus.DAL_Select("Proc_ClassroomAttendace", arrParameter);
     }

     public DataSet GetClasswiseMonthlyAttendance(int SchoolID, DateTime Date, Int64 BMSID, int DivisionID)
     {
         this.Dal_ClasswiseCoveredSyllabus = new DataAccess();
         arrParameter = new ArrayList();

         arrParameter.Add(new parameter("SchoolID", SchoolID));
         arrParameter.Add(new parameter("CreatedOn", Date));
         arrParameter.Add(new parameter("BMSID", BMSID));
         arrParameter.Add(new parameter("DivisionID", DivisionID));

         return this.Dal_ClasswiseCoveredSyllabus.DAL_Select("Proc_ClassroomMonthlyAttendace", arrParameter);
     }
}