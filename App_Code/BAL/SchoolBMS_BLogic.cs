using System.Data;
using System.Collections;

/// <summary> 
/// <DevelopedBy>"NARENDRASINH"</DevelopedBy>
/// <DevelopedDate></DevelopedDate>
/// <UpdatedBy>"NARENDRASINH"</UpdatedBy>
/// <UpdatedDate></UpdatedDate>
/// </summary>


public class SchoolBMS_BLogic
{
    DataAccess obj_DAL_SchoolBMS;
    ArrayList obj_arrParameter;
    public SchoolBMS_BLogic()
    {
        //
        // TODO: Add constructor logic here
        //
    }



    public void BAL_SchoolBMS_Insert(SchoolBMS obj_SchoolBMS, string mode)
    {
        obj_DAL_SchoolBMS = new DataAccess();
        obj_arrParameter = new ArrayList();

        obj_arrParameter.Add(new parameter("mode", mode));
        obj_arrParameter.Add(new parameter("Tmp_SchRegBMSID", obj_SchoolBMS.schregbmsid));
        obj_arrParameter.Add(new parameter("Tmp_SchoolTypeID", obj_SchoolBMS.schooltypeid));
        obj_arrParameter.Add(new parameter("Tmp_BMSID", obj_SchoolBMS.bmsid));
        obj_arrParameter.Add(new parameter("Tmp_SchRegID", obj_SchoolBMS.schregid));
        obj_arrParameter.Add(new parameter("Tmp_NoOfStudents", obj_SchoolBMS.noofstudents));
        obj_arrParameter.Add(new parameter("Tmp_StartTime", obj_SchoolBMS.starttime));
        obj_arrParameter.Add(new parameter("Tmp_EndTime", obj_SchoolBMS.endtime));
        obj_arrParameter.Add(new parameter("Tmp_IsApprove", obj_SchoolBMS.StatusID));
        obj_DAL_SchoolBMS.DAL_InsertUpdate("INSERT_UPDATE_SchoolBMS", obj_arrParameter);
    }

    public void BAL_SchoolBMS_Update(SchoolBMS obj_SchoolBMS, string mode)
    {
        obj_DAL_SchoolBMS = new DataAccess();
        obj_arrParameter = new ArrayList();

        obj_arrParameter.Add(new parameter("mode", mode));
        obj_arrParameter.Add(new parameter("Tmp_SchRegBMSID", obj_SchoolBMS.schregbmsid));
        obj_arrParameter.Add(new parameter("Tmp_SchoolTypeID", obj_SchoolBMS.schooltypeid));
        obj_arrParameter.Add(new parameter("Tmp_BMSID", obj_SchoolBMS.bmsid));
        obj_arrParameter.Add(new parameter("Tmp_SchRegID", obj_SchoolBMS.schregid));
        obj_arrParameter.Add(new parameter("Tmp_NoOfStudents", obj_SchoolBMS.noofstudents));
        obj_arrParameter.Add(new parameter("Tmp_StartTime", obj_SchoolBMS.starttime));
        obj_arrParameter.Add(new parameter("Tmp_EndTime", obj_SchoolBMS.endtime));
        obj_arrParameter.Add(new parameter("Tmp_IsApprove", obj_SchoolBMS.StatusID));
        obj_DAL_SchoolBMS.DAL_InsertUpdate("INSERT_UPDATE_SchoolBMS", obj_arrParameter);
    }
    public void BAL_SchoolBMS_UpdateStatus(SchoolBMS obj_SchoolBMS, string mode)
    {
        obj_DAL_SchoolBMS = new DataAccess();
        obj_arrParameter = new ArrayList();

        obj_arrParameter.Add(new parameter("mode", mode));
        obj_arrParameter.Add(new parameter("Tmp_SchBMSIDStr", obj_SchoolBMS.schregbmsidStr));       
        obj_arrParameter.Add(new parameter("Tmp_Status", obj_SchoolBMS.StatusID));
       obj_DAL_SchoolBMS.DAL_InsertUpdate("UPDATE_SchoolBMSStatus", obj_arrParameter);
    }
    
    public void BAL_SchoolBMS_Delete(SchoolBMS obj_SchoolBMS, string mode)
    {
        obj_DAL_SchoolBMS = new DataAccess();
        obj_arrParameter = new ArrayList();

        obj_arrParameter.Add(new parameter("mode", mode));
        obj_arrParameter.Add(new parameter("Tmp_SchRegBMSID", obj_SchoolBMS.schregbmsid));
        obj_arrParameter.Add(new parameter("Tmp_SchoolTypeID", obj_SchoolBMS.schooltypeid));
        obj_arrParameter.Add(new parameter("Tmp_BMSID", obj_SchoolBMS.bmsid));
        obj_arrParameter.Add(new parameter("Tmp_SchRegID", obj_SchoolBMS.schregid));
        obj_arrParameter.Add(new parameter("Tmp_NoOfStudents", obj_SchoolBMS.noofstudents));
        obj_arrParameter.Add(new parameter("Tmp_StartTime", obj_SchoolBMS.starttime));
        obj_arrParameter.Add(new parameter("Tmp_EndTime", obj_SchoolBMS.endtime));
        obj_arrParameter.Add(new parameter("Tmp_IsApprove", obj_SchoolBMS.StatusID));
        obj_DAL_SchoolBMS.DAL_Delete("SELECT_DELETE_SchoolBMS", obj_arrParameter);
    }

    public DataSet BAL_SchoolBMS_Select(SchoolBMS obj_SchoolBMS, string mode,string SearchCondition)
    {
        obj_DAL_SchoolBMS = new DataAccess();
        obj_arrParameter = new ArrayList();

        obj_arrParameter.Add(new parameter("mode", mode));
        obj_arrParameter.Add(new parameter("Tmp_SchBMSID", obj_SchoolBMS.schregbmsid));
        obj_arrParameter.Add(new parameter("SearchCondition", SearchCondition));
        return obj_DAL_SchoolBMS.DAL_Select("Proc_SchoolBMSSelectDelete", obj_arrParameter);
    }

    public DataSet BAL_SchoolBMS_SelectAll()
    {
        obj_DAL_SchoolBMS = new DataAccess();
        return obj_DAL_SchoolBMS.DAL_SelectALL("SELECTAll_SchoolBMS");
    }
}