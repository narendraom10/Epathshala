using System.Collections;
using System.Data;
using System.Web.UI.WebControls;
using System;

///// <summary>
///// Summary description for SYS_Board_BLogic
///// </summary>
/// <summary> 
/// <DevelopedBy>"NARENDRASINH"</DevelopedBy>
/// <DevelopedDate></DevelopedDate>
/// <UpdatedBy>"NARENDRASINH"</UpdatedBy>
/// <UpdatedDate></UpdatedDate>
/// </summary>

public class SYS_Board_BLogic
{
    DataAccess DAL_SYS_Board;
    ArrayList arrParameter;

    public SYS_Board_BLogic()
    {
        //
        // TODO: Add constructor logic here
        //
    }



    public int BAL_SYS_Board_Insert(SYS_Board SYS_Board, string mode)
    {
        DAL_SYS_Board = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("mode", mode));
        arrParameter.Add(new parameter("BoardID", Convert.ToInt32(EnumFile.AssignValue.Zero)));
        arrParameter.Add(new parameter("Board", SYS_Board.board));
        arrParameter.Add(new parameter("Code", SYS_Board.code));
        arrParameter.Add(new parameter("Description", SYS_Board.description));
        arrParameter.Add(new parameter("CreatedBy", SYS_Board.createdby));
        arrParameter.Add(new parameter("ModifiedBy", SYS_Board.modifiedby));
        return DAL_SYS_Board.DAL_InsertUpdate_Return("Proc_SYS_BoardInsertUpdate", arrParameter);
    }

    public int BAL_SYS_Board_Update(SYS_Board SYS_Board, string mode)
    {
        DAL_SYS_Board = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("mode", mode));
        arrParameter.Add(new parameter("BoardID", SYS_Board.boardid));
        arrParameter.Add(new parameter("Board", SYS_Board.board));
        arrParameter.Add(new parameter("Code", SYS_Board.code));
        arrParameter.Add(new parameter("Description", SYS_Board.description));
        arrParameter.Add(new parameter("CreatedBy", SYS_Board.createdby));
        arrParameter.Add(new parameter("ModifiedBy", SYS_Board.modifiedby));
        return DAL_SYS_Board.DAL_InsertUpdate_Return("Proc_SYS_BoardInsertUpdate", arrParameter);
    }

    public int BAL_SYS_Board_Delete(SYS_Board SYS_Board, string mode)
    {
        DAL_SYS_Board = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("mode", mode));
        arrParameter.Add(new parameter("BoardID", Convert.ToInt32(EnumFile.AssignValue.Zero)));
        arrParameter.Add(new parameter("BoardIDStr", SYS_Board.boardidStr));
        arrParameter.Add(new parameter("IsActive", SYS_Board.isactive));
        return DAL_SYS_Board.DAL_Delete_Return("SELECT_DELETE_SYS_Board", arrParameter);
    }

    public DataSet BAL_SYS_Board_Select(SYS_Board SYS_Board, string mode)
    {
        DAL_SYS_Board = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("mode", mode));
        arrParameter.Add(new parameter("BoardID", SYS_Board.boardid));
        arrParameter.Add(new parameter("BoardIDStr", ""));
        arrParameter.Add(new parameter("IsActive", SYS_Board.isactive));
        return DAL_SYS_Board.DAL_Select("SELECT_DELETE_SYS_Board", arrParameter);
    }

    public DataSet BAL_SYS_Board_BySchoolID(int schoolID)
    {
        DAL_SYS_Board = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("SchoolID", schoolID));
        return DAL_SYS_Board.DAL_Select("Proc_Select_BoardBySchoolID", arrParameter);
    }
    public DataSet BAL_SYS_Medium_BySchoolIDBoardID(int schoolID, int boardid)
    {
        DAL_SYS_Board = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("SchoolID", schoolID));
        arrParameter.Add(new parameter("BoardID", boardid));
        return DAL_SYS_Board.DAL_Select("Proc_Select_MediumBySchoolIDBoardID", arrParameter);
    }
    public DataSet BAL_SYS_StdSubChapTopic_BySchoolIDBoardIDMediumid(int schoolID, int boardid, int mediumid, int standardId, int subjectid, int chapterid)
    {
        DAL_SYS_Board = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("SchoolID", schoolID));
        arrParameter.Add(new parameter("BoardID", boardid));
        arrParameter.Add(new parameter("Mediumid", mediumid));
        arrParameter.Add(new parameter("StandardID", standardId));
        arrParameter.Add(new parameter("SubjectID", subjectid));
        arrParameter.Add(new parameter("ChapterID", chapterid));
        return DAL_SYS_Board.DAL_Select("Proc_Select_StdSubChpTopicBySchoolIDBoardIDMediumID", arrParameter);
    }
    public DataSet BAL_SYS_Std_BySchoolIDBoardIDMediumid(int schoolID, int boardid, int mediumid, int standardId)
    {
        DAL_SYS_Board = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("SchoolID", schoolID));
        arrParameter.Add(new parameter("BoardID", boardid));
        arrParameter.Add(new parameter("Mediumid", mediumid));
        arrParameter.Add(new parameter("StandardID", standardId));
        return DAL_SYS_Board.DAL_Select("Proc_Select_StdSubChpTopicBySchoolIDBoardIDMediumID", arrParameter);
    }

    public DataSet BAL_SYS_Board_SelectAll()
    {
        DAL_SYS_Board = new DataAccess();
        return DAL_SYS_Board.DAL_SelectALL("SELECTAll_SYS_Board");
    }


}