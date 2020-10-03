using System.Data;
using System.Collections;

/// <summary> 
/// <DevelopedBy>"NARENDRASINH"</DevelopedBy>
/// <DevelopedDate></DevelopedDate>
/// <UpdatedBy>"NARENDRASINH"</UpdatedBy>
/// <UpdatedDate></UpdatedDate>
/// </summary>


public class SYS_Topic_BLogic
{
    DataAccess DAL_SYS_Topic;
    ArrayList arrParameter;
    public SYS_Topic_BLogic()
    {
        //
        // TODO: Add constructor logic here
        //
    }



    public int BAL_SYS_Topic_Insert(SYS_Topic SYS_Topic, string mode)
    {
        DAL_SYS_Topic = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("mode", mode));
        arrParameter.Add(new parameter("TopicID", SYS_Topic.topicid));
        arrParameter.Add(new parameter("ChapterID", SYS_Topic.chapterid));
        arrParameter.Add(new parameter("TopicIndex", SYS_Topic.topicindex));
        arrParameter.Add(new parameter("Topic", SYS_Topic.topic));
        arrParameter.Add(new parameter("CreatedBy", SYS_Topic.createdby));
        return DAL_SYS_Topic.DAL_InsertUpdate_Return("Proc_SYS_TopicInsertUpdate", arrParameter);
    }

    public void BAL_SYS_Topic_Update(SYS_Topic SYS_Topic, string mode)
    {
        DAL_SYS_Topic = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("mode", mode));
        arrParameter.Add(new parameter("TopicID", SYS_Topic.topicid));
        arrParameter.Add(new parameter("ChapterID", SYS_Topic.chapterid));
        arrParameter.Add(new parameter("TopicIndex", SYS_Topic.topicindex));
        arrParameter.Add(new parameter("Topic", SYS_Topic.topic));
        arrParameter.Add(new parameter("IsActive", SYS_Topic.isactive));
        arrParameter.Add(new parameter("CreatedOn", SYS_Topic.createdon));
        arrParameter.Add(new parameter("CreatedBy", SYS_Topic.createdby));
        DAL_SYS_Topic.DAL_InsertUpdate("Proc_SYS_TopicInsertUpdate", arrParameter);
    }

    public int BAL_SYS_Topic_Update_Admin_Topic(SYS_Topic SYS_Topic, string mode)
    {
        DAL_SYS_Topic = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("mode", mode));
        arrParameter.Add(new parameter("TopicID", SYS_Topic.topicid));
        arrParameter.Add(new parameter("TopicIndex", SYS_Topic.topicindex));
        arrParameter.Add(new parameter("Topic", SYS_Topic.topic));
        arrParameter.Add(new parameter("ChapterID", SYS_Topic.chapterid));
        arrParameter.Add(new parameter("IsActive", SYS_Topic.isactive));
        return DAL_SYS_Topic.DAL_InsertUpdate_Return("Proc_SYS_TopicInsertUpdate", arrParameter);
    }

    public int BAL_SYS_Topic_ActivateDeActivate_Admin_Topic(SYS_Topic SYS_Topic, string mode)
    {
        DAL_SYS_Topic = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("mode", mode));
        arrParameter.Add(new parameter("topicidStr", SYS_Topic.topicidStr));
        arrParameter.Add(new parameter("IsActive", SYS_Topic.isactive));
        return DAL_SYS_Topic.DAL_InsertUpdate_Return("Proc_SYS_TopicInsertUpdate", arrParameter);
    }

    public void BAL_SYS_Topic_Delete(SYS_Topic SYS_Topic, string mode)
    {
        DAL_SYS_Topic = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("mode", mode));
        arrParameter.Add(new parameter("TopicID", SYS_Topic.topicid));
        arrParameter.Add(new parameter("TopicIDStr", SYS_Topic.chapterid));    
        DAL_SYS_Topic.DAL_Delete("Proc_SYS_TopicSelectDelete", arrParameter);
    }

    public DataSet BAL_SYS_Topic_Select(SYS_Topic SYS_Topic, string mode)
    {
        DAL_SYS_Topic = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("mode", mode));
        arrParameter.Add(new parameter("TopicID", SYS_Topic.topicid));
        arrParameter.Add(new parameter("TopicIDStr", ""));      
        return DAL_SYS_Topic.DAL_Select("Proc_SYS_TopicSelectDelete", arrParameter);
    }

    public DataSet BAL_SYS_Topic_SelectAll()
    {
        DAL_SYS_Topic = new DataAccess();
        return DAL_SYS_Topic.DAL_SelectALL("Proc_SYS_TopicSELECTAll");
    }
}