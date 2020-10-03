using System.Data;
using System.Collections;
using System;

/// <summary> 
/// <DevelopedBy>"NARENDRASINH"</DevelopedBy>
/// <DevelopedDate></DevelopedDate>
/// <UpdatedBy>"NARENDRASINH"</UpdatedBy>
/// <UpdatedDate></UpdatedDate>
/// </summary>


public class SYS_Subject_BLogic
{
    DataAccess DAL_SYS_Subject;
    ArrayList arrParameter;
    public SYS_Subject_BLogic()
    {
        //
        // TODO: Add constructor logic here
        //
    }



    public int BAL_SYS_Subject_Insert(SYS_Subject SYS_Subject, string mode)
    {
        DAL_SYS_Subject = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("mode", mode));
        arrParameter.Add(new parameter("SubjectID", SYS_Subject.subjectid));
        arrParameter.Add(new parameter("Subject", SYS_Subject.subject));
        arrParameter.Add(new parameter("Code", SYS_Subject.code));
        arrParameter.Add(new parameter("Description", SYS_Subject.description));
        arrParameter.Add(new parameter("CreatedBy", SYS_Subject.createdby));
        arrParameter.Add(new parameter("ModifiedBy", SYS_Subject.modifiedby));
        return DAL_SYS_Subject.DAL_InsertUpdate_Return("Proc_SYS_SubjectInsertUpdate", arrParameter);
    }



    public int BAL_SYS_Subject_Update(SYS_Subject SYS_Subject, string mode)
    {
        DAL_SYS_Subject = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("mode", mode));
        arrParameter.Add(new parameter("SubjectID", SYS_Subject.subjectid));
        arrParameter.Add(new parameter("Subject", SYS_Subject.subject));
        arrParameter.Add(new parameter("Code", SYS_Subject.code));
        arrParameter.Add(new parameter("Description", SYS_Subject.description));
        arrParameter.Add(new parameter("CreatedBy", SYS_Subject.createdby));
        arrParameter.Add(new parameter("ModifiedBy", SYS_Subject.modifiedby));
        return DAL_SYS_Subject.DAL_InsertUpdate_Return("Proc_SYS_SubjectInsertUpdate", arrParameter);
    }

    public int BAL_SYS_Subject_Delete(SYS_Subject SYS_Subject, string mode)
    {
        DAL_SYS_Subject = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("mode", mode));
        arrParameter.Add(new parameter("SubjectID", SYS_Subject.subjectid));
        arrParameter.Add(new parameter("SubjectIDStr", SYS_Subject.subjectidStr));
        arrParameter.Add(new parameter("IsActive", SYS_Subject.isactive));
        return DAL_SYS_Subject.DAL_Delete_Return("Proc_SYS_SubjectSelectDelete", arrParameter);
    }
    public DataSet BAL_SYS_Subject_Select(SYS_Subject SYS_Subject, string mode)
    {
        DAL_SYS_Subject = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("mode", mode));
        arrParameter.Add(new parameter("SubjectID", SYS_Subject.subjectid));
        arrParameter.Add(new parameter("SubjectIDStr", SYS_Subject.subjectidStr));
        return DAL_SYS_Subject.DAL_Select("Proc_SYS_SubjectSelectDelete", arrParameter);
    }
    public DataSet BAL_SYS_Subject_SelectByBMSID(Int64 BMSID)
    {
        DAL_SYS_Subject = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("BMSID", BMSID));

        return DAL_SYS_Subject.DAL_Select("Proc_SYS_SubjectByBMSID", arrParameter);
    }

    public DataSet BAL_SYS_Subject_Select_Admin(string Mode)
    {
        DAL_SYS_Subject = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("mode", Mode));

        return DAL_SYS_Subject.DAL_Select("Proc_SYS_SubjectSelectDelete", arrParameter);
    }
    //public DataSet BAL_SYS_Subject_SelectAll()
    //{
    //    DAL_SYS_Subject = new DataAccess();
    //    return DAL_SYS_Subject.DAL_SelectALL("Proc_SYS_SubjectSELECTAll");
    //}

}