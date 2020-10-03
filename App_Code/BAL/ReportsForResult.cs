using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Data;

/// <summary>
/// Summary description for ReportsForResult
/// </summary>
public class ReportsForResult
{
    //DataAccessEpathshalaStudent DAL_SYS_Board;
    DataAccess DAL_SYS_Board;
    ArrayList arrParameter;
    public ReportsForResult()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public DataSet BAL_SYS_ResultClassroomwise_Select(int schoolid, int boardid, int mediumid, int standardid, int subjectid, int chapterid, int topicid, DateTime FromDate, DateTime ToDate)
    {
        //DAL_SYS_Board = new DataAccessEpathshalaStudent();
        DAL_SYS_Board = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("SchoolID", schoolid));
        arrParameter.Add(new parameter("BoardID", boardid));
        arrParameter.Add(new parameter("MediumID", mediumid));
        arrParameter.Add(new parameter("StandardID", standardid));
        arrParameter.Add(new parameter("SubjectID", subjectid));
        arrParameter.Add(new parameter("ChapterID", chapterid));
        arrParameter.Add(new parameter("ToicID", topicid));
        arrParameter.Add(new parameter("FrmDate", FromDate));
        arrParameter.Add(new parameter("ToDate", ToDate));      
        return DAL_SYS_Board.DAL_Select("PROC_Select_StudentResultReportBySchool", arrParameter);
    }
    public DataSet BAL_SYS_ResultSubjectwise_Select(int schoolid, int boardid, int mediumid, int standardid, int subjectid, DateTime FromDate, DateTime ToDate)
    {
        DAL_SYS_Board = new DataAccess();
        arrParameter = new ArrayList();
        arrParameter.Add(new parameter("SchoolID", schoolid));
        arrParameter.Add(new parameter("BoardID", boardid));
        arrParameter.Add(new parameter("MediumID", mediumid));
        arrParameter.Add(new parameter("StandardID", standardid));
        arrParameter.Add(new parameter("SubjectID", subjectid));      
        arrParameter.Add(new parameter("FrmDate", FromDate));
        arrParameter.Add(new parameter("ToDate", ToDate));
        return DAL_SYS_Board.DAL_Select("PROC_Select_SubjectwiseResultReportBySchool", arrParameter);
    }

    public DataSet BAL_SYS_ResultStudentwise_Select(int schoolid, int boardid, int mediumid, int standardid, int subjectid, DateTime FromDate, DateTime ToDate,int studentid)
    {
        //DAL_SYS_Board = new DataAccessEpathshalaStudent();
        DAL_SYS_Board = new DataAccess();
        arrParameter = new ArrayList();
        arrParameter.Add(new parameter("SchoolID", schoolid));
        arrParameter.Add(new parameter("BoardID", boardid));
        arrParameter.Add(new parameter("MediumID", mediumid));
        arrParameter.Add(new parameter("StandardID", standardid));
        arrParameter.Add(new parameter("SubjectID", subjectid));
        arrParameter.Add(new parameter("FrmDate", FromDate));
        arrParameter.Add(new parameter("ToDate", ToDate));
        arrParameter.Add(new parameter("StudentID", studentid));
        return DAL_SYS_Board.DAL_Select("PROC_Select_SubjectwiseResultReportByStudent", arrParameter);
    }
    public DataSet BAL_SYS_ResultStudentwise_Select(int schoolid, int boardid, int mediumid, int standardid, int subjectid,int div, DateTime FromDate, DateTime ToDate)
    {
        //DAL_SYS_Board = new DataAccessEpathshalaStudent();
        DAL_SYS_Board = new DataAccess();

        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("SchoolID", schoolid));
        arrParameter.Add(new parameter("BoardID", boardid));
        arrParameter.Add(new parameter("MediumID", mediumid));
        arrParameter.Add(new parameter("StandardID", standardid));
        arrParameter.Add(new parameter("SubjectID", subjectid));
        arrParameter.Add(new parameter("DivisionID", div));
        arrParameter.Add(new parameter("FrmDate", FromDate));
        arrParameter.Add(new parameter("ToDate", ToDate));
        return DAL_SYS_Board.DAL_Select("PROC_Select_StudentwiseResultReportBySchool", arrParameter);
    }


    public DataSet BAL_SYS_ResultStudentwise_Select1(int schoolid, int boardid, int mediumid, int standardid, int subjectid, int div)
    {
        //DAL_SYS_Board = new DataAccessEpathshalaStudent();
        DAL_SYS_Board = new DataAccess();

        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("SchoolID", schoolid));
        arrParameter.Add(new parameter("BoardID", boardid));
        arrParameter.Add(new parameter("MediumID", mediumid));
        arrParameter.Add(new parameter("StandardID", standardid));
        arrParameter.Add(new parameter("SubjectID", subjectid));
        arrParameter.Add(new parameter("DivisionID", div));
        
        return DAL_SYS_Board.DAL_Select("PROC_Select_StudentwiseResultReportBySchool1", arrParameter);
    }

    public DataSet BAL_SYS_ResultSubjectwiseSecond_Select(int schoolid, int boardid, int mediumid,int standardid, int subjectid, DateTime FromDate, DateTime ToDate)
    {
        //DAL_SYS_Board = new DataAccessEpathshalaStudent();
        DAL_SYS_Board = new DataAccess();

        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("SchoolID", schoolid));
        arrParameter.Add(new parameter("BoardID", boardid));
        arrParameter.Add(new parameter("MediumID", mediumid));
        arrParameter.Add(new parameter("StandardID", standardid));
        arrParameter.Add(new parameter("SubjectID", subjectid));
        arrParameter.Add(new parameter("FrmDate", FromDate));
        arrParameter.Add(new parameter("ToDate", ToDate));
        return DAL_SYS_Board.DAL_Select("PROC_Select_SubjectwiseResultReportSecondBySchool", arrParameter);
    }

    public DataSet BAL_SYS_ResultSubjectwiseStudentSecond_Select(int schoolid, int boardid, int mediumid, int standardid, int subjectid, DateTime FromDate, DateTime ToDate,int studentid)
    {
        //DAL_SYS_Board = new DataAccessEpathshalaStudent();
        DAL_SYS_Board = new DataAccess();

        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("SchoolID", schoolid));
        arrParameter.Add(new parameter("BoardID", boardid));
        arrParameter.Add(new parameter("MediumID", mediumid));
        arrParameter.Add(new parameter("StandardID", standardid));
        arrParameter.Add(new parameter("SubjectID", subjectid));
        arrParameter.Add(new parameter("FrmDate", FromDate));
        arrParameter.Add(new parameter("ToDate", ToDate));
        arrParameter.Add(new parameter("StudentID", studentid));
        return DAL_SYS_Board.DAL_Select("PROC_Select_SubjectwiseResultReportSecondByStudent", arrParameter);
    }


    public DataSet BAL_SYS_ResultSubjectwiseThird_Select(int schoolid, int BMSID,int subjectid,int empid,int divid, DateTime FromDate, DateTime ToDate)
    {
        //DAL_SYS_Board = new DataAccessEpathshalaStudent();
        DAL_SYS_Board = new DataAccess();

        arrParameter = new ArrayList();
            

        arrParameter.Add(new parameter("SchoolID", schoolid));
        arrParameter.Add(new parameter("BMSID", BMSID));       
        arrParameter.Add(new parameter("SubjectID", subjectid));
        arrParameter.Add(new parameter("EmpID", empid));
        arrParameter.Add(new parameter("DivisionID", divid));
        arrParameter.Add(new parameter("FrmDate", FromDate));
        arrParameter.Add(new parameter("ToDate", ToDate));
        return DAL_SYS_Board.DAL_Select("PROC_Select_SubjectwiseResultReportThirdBySchool", arrParameter);
    }
    public DataSet BAL_SYS_ResultstudentwiseThird_Select(int schoolid, int BMSID, int subjectid, int empid, int divid, DateTime FromDate, DateTime ToDate,int studentid)
    {
        //DAL_SYS_Board = new DataAccessEpathshalaStudent();
        DAL_SYS_Board = new DataAccess();

        arrParameter = new ArrayList();


        arrParameter.Add(new parameter("SchoolID", schoolid));
        arrParameter.Add(new parameter("BMSID", BMSID));
        arrParameter.Add(new parameter("SubjectID", subjectid));
        arrParameter.Add(new parameter("EmpID", empid));
        arrParameter.Add(new parameter("DivisionID", divid));
        arrParameter.Add(new parameter("FrmDate", FromDate));
        arrParameter.Add(new parameter("ToDate", ToDate));
        arrParameter.Add(new parameter("StudentID", studentid));
        return DAL_SYS_Board.DAL_Select("PROC_Select_SubjectwiseResultReportThirdByStudent", arrParameter);
    }
    public DataSet BAL_SYS_ResultStudentwiseSecond_Select(int schoolid,int StudentID, int BMSID, int subjectid,int divid, DateTime FromDate, DateTime ToDate)
    {
        //DAL_SYS_Board = new DataAccessEpathshalaStudent();
        DAL_SYS_Board = new DataAccess();

        arrParameter = new ArrayList();


        arrParameter.Add(new parameter("SchoolID", schoolid));       
        arrParameter.Add(new parameter("StudentID", StudentID));
        arrParameter.Add(new parameter("BMSID", BMSID));
        arrParameter.Add(new parameter("SubjectID", subjectid));
        arrParameter.Add(new parameter("DivisionID", divid));
        arrParameter.Add(new parameter("FrmDate", FromDate));
        arrParameter.Add(new parameter("ToDate", ToDate));
        return DAL_SYS_Board.DAL_Select("PROC_Select_StudentwiseResultReportSecondBySchool", arrParameter);
    }
    public DataSet BAL_SYS_ResultStudentwiseFourth_Select(int schoolid, int BMSID, int subjectid, int empid, int divid,int studentid, DateTime FromDate, DateTime ToDate)
    {
        //DAL_SYS_Board = new DataAccessEpathshalaStudent();
        DAL_SYS_Board = new DataAccess();

        arrParameter = new ArrayList();


        arrParameter.Add(new parameter("SchoolID", schoolid));
        arrParameter.Add(new parameter("BMSID", BMSID));
        arrParameter.Add(new parameter("SubjectID", subjectid));
        arrParameter.Add(new parameter("EmpID", empid));
        arrParameter.Add(new parameter("DivisionID", divid));
        arrParameter.Add(new parameter("StudentID", studentid));
        arrParameter.Add(new parameter("FrmDate", FromDate));
        arrParameter.Add(new parameter("ToDate", ToDate));
        return DAL_SYS_Board.DAL_Select("PROC_Select_SubjectwiseResultReportFourthByStudent", arrParameter);
    }

    public DataSet BAL_SYS_ResultSubjectwiseFourth_Select(int schoolid, int BMSID, int subjectid, int empid, int divid, int studentid, DateTime FromDate, DateTime ToDate)
    {
        //DAL_SYS_Board = new DataAccessEpathshalaStudent();
        DAL_SYS_Board = new DataAccess();

        arrParameter = new ArrayList();


        arrParameter.Add(new parameter("SchoolID", schoolid));
        arrParameter.Add(new parameter("BMSID", BMSID));
        arrParameter.Add(new parameter("SubjectID", subjectid));
        arrParameter.Add(new parameter("EmpID", empid));
        arrParameter.Add(new parameter("DivisionID", divid));
        arrParameter.Add(new parameter("StudentID", studentid));
        arrParameter.Add(new parameter("FrmDate", FromDate));
        arrParameter.Add(new parameter("ToDate", ToDate));
        return DAL_SYS_Board.DAL_Select("PROC_Select_SubjectwiseResultReportFourthBySchool", arrParameter);
    }
    public DataSet BAL_SYS_ResultClassroomwiseByFirRPT_Select(int schoolid, int bmssctid, int empid, int Divisionid, DateTime ExamDate)
    {
        //DAL_SYS_Board = new DataAccessEpathshalaStudent();
        DAL_SYS_Board = new DataAccess();

        arrParameter = new ArrayList();
    
        arrParameter.Add(new parameter("SchoolID", schoolid));
        arrParameter.Add(new parameter("BMSSCTID", bmssctid));
        arrParameter.Add(new parameter("EmpID", empid));
        arrParameter.Add(new parameter("ExamDate", ExamDate));
        arrParameter.Add(new parameter("DivisionID", Divisionid));
        
        return DAL_SYS_Board.DAL_Select("PROC_Select_StudentResultDetailsByFirRPT", arrParameter);
    }
    public DataSet BAL_SYS_ResultRPTByStudentDetails(int StudentID, int bmssctid, int empid,DateTime ExamDate)
    {
        //DAL_SYS_Board = new DataAccessEpathshalaStudent();
        DAL_SYS_Board = new DataAccess();

        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("StudentID", StudentID));
        arrParameter.Add(new parameter("BMSSCTID", bmssctid));
        arrParameter.Add(new parameter("EmpID", empid));
        arrParameter.Add(new parameter("ExamDate", ExamDate));       

        return DAL_SYS_Board.DAL_Select("PROC_Select_StudentResRPTByStudentDetails", arrParameter);
    }

    //for generating chapterwise performance report for student
    public DataSet BAL_SYS_ResultRPTByStudentSubDetails(int studentid, int subjectid)
    {
        //DAL_SYS_Board = new DataAccessEpathshalaStudent();
        DAL_SYS_Board = new DataAccess();

        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("studentID", studentid));
        arrParameter.Add(new parameter("subjectID", subjectid));
        


        return DAL_SYS_Board.DAL_Select("Proc_Student_Chapterwise_performance", arrParameter);
    }
    public DataSet BAL_SYS_Student_Performance_Chart(int studentid, int subjectid, int bmsid)
    {
        //DAL_SYS_Board = new DataAccessEpathshalaStudent();
        DAL_SYS_Board = new DataAccess();

        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("studentID", studentid));
        arrParameter.Add(new parameter("subjectID", subjectid));
        arrParameter.Add(new parameter("bmsID", bmsid));


        return DAL_SYS_Board.DAL_Select("Proc_Student_performance_Chart", arrParameter);
    }
    public DataSet BAL_SYS_GetResultByExamid(int ExamID)
    {
        //DAL_SYS_Board = new DataAccessEpathshalaStudent();
        DAL_SYS_Board = new DataAccess();

        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("ExamID", ExamID));



        return DAL_SYS_Board.DAL_Select("Proc_GetResultByExamID", arrParameter);
    }

}