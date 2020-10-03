using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Data;

/// <summary> 
/// <DevelopedBy>"NARENDRASINH"</DevelopedBy>
/// <DevelopedDate></DevelopedDate>
/// <UpdatedBy>"NARENDRASINH"</UpdatedBy>
/// <UpdatedDate></UpdatedDate>
/// </summary>
public class SYS_Chapter_BLogic
{
    DataAccess obj_DAL_SYS_Chapter;
    ArrayList obj_arrParameter;

	public SYS_Chapter_BLogic()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public int BAL_SYS_Chapter_Insert_Admin(SYS_Chapter obj_SYS_Chapter,string Mode)
    {
        obj_DAL_SYS_Chapter = new DataAccess();
        obj_arrParameter = new ArrayList();

        obj_arrParameter.Add(new parameter("mode", Mode));
        obj_arrParameter.Add(new parameter("BMSID", obj_SYS_Chapter.bmsid));
        obj_arrParameter.Add(new parameter("SubjectID", obj_SYS_Chapter.subjectid));
        obj_arrParameter.Add(new parameter("ChapterIndex", obj_SYS_Chapter.chapterindex));
        obj_arrParameter.Add(new parameter("Chapter", obj_SYS_Chapter.chapter));
        obj_arrParameter.Add(new parameter("Code", obj_SYS_Chapter.code));
        obj_arrParameter.Add(new parameter("Description", obj_SYS_Chapter.description));
        obj_arrParameter.Add(new parameter("CreatedBy", obj_SYS_Chapter.employeeid));

        return obj_DAL_SYS_Chapter.executescalre("Proc_SYS_ChapterInsertUpdate", obj_arrParameter);
    }

    public int BAL_SYS_Chapter_Insert(SYS_Chapter obj_SYS_Chapter)
    {
        obj_DAL_SYS_Chapter = new DataAccess();
        obj_arrParameter = new ArrayList();

        obj_arrParameter.Add(new parameter("BMSID", obj_SYS_Chapter.bmsid));
        obj_arrParameter.Add(new parameter("SubjectID", obj_SYS_Chapter.subjectid));
        obj_arrParameter.Add(new parameter("ChapterIndex", obj_SYS_Chapter.chapterindex));
        obj_arrParameter.Add(new parameter("Chapter", obj_SYS_Chapter.chapter));
        obj_arrParameter.Add(new parameter("EmployeeID", obj_SYS_Chapter.employeeid));

        return obj_DAL_SYS_Chapter.executescalre("PROC_Insert_Chapter", obj_arrParameter);
    }

  

    public int BAL_SYS_Topic_Insert(SYS_Chapter obj_SYS_Chapter)
    {
        obj_DAL_SYS_Chapter = new DataAccess();
        obj_arrParameter = new ArrayList();

        obj_arrParameter.Add(new parameter("ChapterID", obj_SYS_Chapter.chapterid));
        obj_arrParameter.Add(new parameter("TopicIndex", obj_SYS_Chapter.topicindex));
        obj_arrParameter.Add(new parameter("Topic", obj_SYS_Chapter.topic));
        obj_arrParameter.Add(new parameter("EmployeeID", obj_SYS_Chapter.employeeid));

        return obj_DAL_SYS_Chapter.executescalre("PROC_Insert_Topic", obj_arrParameter);
    }

    public int BAL_SYS_FileType_Insert(SYS_Chapter obj_SYS_Chapter)
    {
        obj_DAL_SYS_Chapter = new DataAccess();
        obj_arrParameter = new ArrayList();

        obj_arrParameter.Add(new parameter("FileType", obj_SYS_Chapter.filetype));
        obj_arrParameter.Add(new parameter("EmployeeID", obj_SYS_Chapter.employeeid));

        return obj_DAL_SYS_Chapter.executescalre("PROC_Insert_FileType", obj_arrParameter);
    }

    public int BAL_SYS_SCT_Insert(SYS_Chapter obj_SYS_Chapter)
    {
        obj_DAL_SYS_Chapter = new DataAccess();
        obj_arrParameter = new ArrayList();

        obj_arrParameter.Add(new parameter("SubjectID", obj_SYS_Chapter.subjectid));
        obj_arrParameter.Add(new parameter("ChapterID", obj_SYS_Chapter.chapterid));
        obj_arrParameter.Add(new parameter("TopicID", obj_SYS_Chapter.topicid));
        obj_arrParameter.Add(new parameter("EmployeeID", obj_SYS_Chapter.employeeid));

        return obj_DAL_SYS_Chapter.executescalre("PROC_INSERT_SCT", obj_arrParameter);
    }

    public int BAL_SYS_BMS_SCT_Insert(SYS_Chapter obj_SYS_Chapter)
    {
        obj_DAL_SYS_Chapter = new DataAccess();
        obj_arrParameter = new ArrayList();

        obj_arrParameter.Add(new parameter("BMSID", obj_SYS_Chapter.bmsid));
        obj_arrParameter.Add(new parameter("SCTID", obj_SYS_Chapter.sctid));
        obj_arrParameter.Add(new parameter("EmployeeID", obj_SYS_Chapter.employeeid));

        return obj_DAL_SYS_Chapter.executescalre("PROC_INSERT_BMSSCT", obj_arrParameter);
    }


    public DataSet BAL_SYS_ChapterSeq_Select(SYS_Chapter obj_SYS_Chapter)
    {
        obj_DAL_SYS_Chapter = new DataAccess();
        obj_arrParameter = new ArrayList();

        obj_arrParameter.Add(new parameter("BMSID", obj_SYS_Chapter.bmsid));
        obj_arrParameter.Add(new parameter("SubjectID", obj_SYS_Chapter.subjectid));

        return obj_DAL_SYS_Chapter.DAL_Select("PROC_Select_Chapter_Topic_List", obj_arrParameter);
    }
    public DataSet BAL_SYS_Chapter_Select(SYS_Chapter SYS_Chapter, string mode)
    {
        obj_DAL_SYS_Chapter = new DataAccess();
        obj_arrParameter = new ArrayList();

        obj_arrParameter.Add(new parameter("mode", mode));
        return obj_DAL_SYS_Chapter.DAL_Select("Proc_SYS_ChapterSelectDelete", obj_arrParameter);
    }

    public void BAL_SYS_Chapter_Delete(SYS_Chapter SYS_Chapter, string mode)
    {
        obj_DAL_SYS_Chapter = new DataAccess();
        obj_arrParameter = new ArrayList();

        obj_arrParameter.Add(new parameter("mode", mode));
        obj_arrParameter.Add(new parameter("ChapterID", SYS_Chapter.chapterid));
        obj_arrParameter.Add(new parameter("BMSID", SYS_Chapter.bmsid));
        obj_arrParameter.Add(new parameter("SubjectID", SYS_Chapter.subjectid));
        obj_arrParameter.Add(new parameter("ChapterIndex", SYS_Chapter.chapterindex));
        obj_arrParameter.Add(new parameter("Chapter", SYS_Chapter.chapter));
        obj_arrParameter.Add(new parameter("Code", SYS_Chapter.code));
        obj_arrParameter.Add(new parameter("Description", SYS_Chapter.description));
        obj_arrParameter.Add(new parameter("IsActive", SYS_Chapter.isactive));
        obj_arrParameter.Add(new parameter("CreatedOn", SYS_Chapter.createdon));
        obj_arrParameter.Add(new parameter("CreatedBy", SYS_Chapter.createdby));
        obj_arrParameter.Add(new parameter("ModifiedOn", SYS_Chapter.modifiedon));
        obj_arrParameter.Add(new parameter("ModifiedBy", SYS_Chapter.modifiedby));
        obj_DAL_SYS_Chapter.DAL_Delete("Proc_SYS_ChapterSelectDelete", obj_arrParameter);
    }

    public int BAL_SYS_Chapter_ActivateDeActivate_Admin_Chapter(SYS_Chapter SYS_Chapter, string mode)
    {
        obj_DAL_SYS_Chapter = new DataAccess();
        obj_arrParameter = new ArrayList();

        obj_arrParameter.Add(new parameter("mode", mode));
        obj_arrParameter.Add(new parameter("ChapterIDList", SYS_Chapter.Chpateridlist));
        obj_arrParameter.Add(new parameter("IsActive", SYS_Chapter.isactive));
        return obj_DAL_SYS_Chapter.DAL_InsertUpdate_Return("Proc_SYS_ChapterInsertUpdate", obj_arrParameter);
    }

    public void BAL_SYS_Chapter_Delete_Admin(SYS_Chapter SYS_Chapter, string mode)
    {
        obj_DAL_SYS_Chapter = new DataAccess();
        obj_arrParameter = new ArrayList();

        obj_arrParameter.Add(new parameter("mode", mode));
        obj_arrParameter.Add(new parameter("ChapterID", SYS_Chapter.chapterid));
        obj_DAL_SYS_Chapter.DAL_Delete("Proc_SYS_ChapterSelectDelete", obj_arrParameter);
    }

    public int BAL_SYS_Chapter_Update(SYS_Chapter SYS_Chapter, string mode)
    {
        obj_DAL_SYS_Chapter = new DataAccess();
        obj_arrParameter = new ArrayList();

        obj_arrParameter.Add(new parameter("mode", mode));
        obj_arrParameter.Add(new parameter("ChapterID", SYS_Chapter.chapterid));
        obj_arrParameter.Add(new parameter("BMSID", SYS_Chapter.bmsid));
        obj_arrParameter.Add(new parameter("SubjectID", SYS_Chapter.subjectid));
        obj_arrParameter.Add(new parameter("ChapterIndex", SYS_Chapter.chapterindex));
        obj_arrParameter.Add(new parameter("Chapter", SYS_Chapter.chapter));
        obj_arrParameter.Add(new parameter("Code", SYS_Chapter.code));
        obj_arrParameter.Add(new parameter("Description", SYS_Chapter.description));
        obj_arrParameter.Add(new parameter("ModifiedBy", SYS_Chapter.modifiedby));
        obj_arrParameter.Add(new parameter("IsActive", SYS_Chapter.isactive));
        return obj_DAL_SYS_Chapter.DAL_InsertUpdate_Return("Proc_SYS_ChapterInsertUpdate", obj_arrParameter);
    }

    public void BAL_SYS_ChapterSeq_Update(String xmldata)
    {
        obj_DAL_SYS_Chapter = new DataAccess();
        obj_arrParameter = new ArrayList();

        obj_arrParameter.Add(new parameter("TbBmsSct", xmldata));
        obj_DAL_SYS_Chapter.DAL_InsertUpdate("PROC_UPDATE_SEQUENCENUMBER", obj_arrParameter);
    }

    public DataSet BAL_SYS_Chapter_Select_Admin_Topic(SYS_Chapter SYS_Chapter, string mode)
    {
        obj_DAL_SYS_Chapter = new DataAccess();
        obj_arrParameter = new ArrayList();

        obj_arrParameter.Add(new parameter("mode", mode));
        obj_arrParameter.Add(new parameter("BMSID", SYS_Chapter.bmsid));
        obj_arrParameter.Add(new parameter("SubjectID", SYS_Chapter.subjectid));
        return obj_DAL_SYS_Chapter.DAL_Select("Proc_SYS_ChapterSelectDelete", obj_arrParameter);
    }
}