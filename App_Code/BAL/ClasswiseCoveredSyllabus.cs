using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;

public class ClasswiseCoveredSyllabus
{
    DataAccess Dal_ClasswiseCoveredSyllabus;
    ArrayList arrParameter;

    public DataSet GetClasswiseCoveredDetails(int SchoolID, int BoardID, int MediumID, int DivisionID, int StandardID, int SubjectID, int ChapterID, int TopicID)
    {
        try
        {
            this.Dal_ClasswiseCoveredSyllabus = new DataAccess();
            arrParameter = new ArrayList();


            arrParameter.Add(new parameter("SchoolID", SchoolID));
            arrParameter.Add(new parameter("BoardID", BoardID));
            arrParameter.Add(new parameter("MediumID", MediumID));
            arrParameter.Add(new parameter("DivisionID", DivisionID));
            arrParameter.Add(new parameter("StandardID", StandardID));
            arrParameter.Add(new parameter("SubjectID", SubjectID));
            arrParameter.Add(new parameter("ChapterID", ChapterID));
            arrParameter.Add(new parameter("TopicID", TopicID));

            return this.Dal_ClasswiseCoveredSyllabus.DAL_Select("Proc_ClasswiseCoveredSyllabus", arrParameter);
        }
        catch (Exception ex)
        {
            throw ex;
        }

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

    public DataSet GetChapterwiseCoveredSyllabusDetails(int BMSID, int SubjectID, int DivisionID, int SchoolID)
    {
        try
        {
            this.Dal_ClasswiseCoveredSyllabus = new DataAccess();
            arrParameter = new ArrayList();

            arrParameter.Add(new parameter("BMSID", BMSID));
            arrParameter.Add(new parameter("SubjectID", SubjectID));
            arrParameter.Add(new parameter("DivisionID", DivisionID));
            arrParameter.Add(new parameter("SchoolID", SchoolID));
            return this.Dal_ClasswiseCoveredSyllabus.DAL_Select("Proc_ChapterwiseCoveredSyllabus", arrParameter);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet GetSubjectwiseCoveredDetails(int BMSID, int SchoolID, int DivisionID)
    {
        try
        {
            this.Dal_ClasswiseCoveredSyllabus = new DataAccess();
            arrParameter = new ArrayList();

            arrParameter.Add(new parameter("BMSID", BMSID));
            arrParameter.Add(new parameter("SchoolID", SchoolID));
            arrParameter.Add(new parameter("DivisionID", DivisionID));
            return this.Dal_ClasswiseCoveredSyllabus.DAL_Select("Proc_SubjectwiseCoveredSyllabus", arrParameter);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet GetTopicwiseCoveredSyllavbus(int BMSID, int SubjectID, int DivisionID, int SchoolID, int ChapaterID)
    {
        try
        {
            this.Dal_ClasswiseCoveredSyllabus = new DataAccess();
            arrParameter = new ArrayList();

            arrParameter.Add(new parameter("BMSID", BMSID));
            arrParameter.Add(new parameter("SubjectID", SubjectID));
            arrParameter.Add(new parameter("DivisionID", DivisionID));
            arrParameter.Add(new parameter("SchoolID", SchoolID));
            arrParameter.Add(new parameter("ChapterID", ChapaterID));

            return this.Dal_ClasswiseCoveredSyllabus.DAL_Select("Proc_TopicwiseCoveredSyllabus", arrParameter);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}
