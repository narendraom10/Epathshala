using System.Data;
using System.Collections;

/// <summary> 
/// <DevelopedBy>"NARENDRASINH"</DevelopedBy>
/// <DevelopedDate></DevelopedDate>
/// <UpdatedBy>"NARENDRASINH"</UpdatedBy>
/// <UpdatedDate></UpdatedDate>
/// </summary>


public class EmployeeStandardDetail_BLogic
{
    DataAccess DAL_EmployeeStandardDetail;
    ArrayList arrParameter;
    public EmployeeStandardDetail_BLogic()
    {
        //
        // TODO: Add constructor logic here
        //
    }



    public DataSet BAL_EmployeeStandardDetail_InsertUpdate(EmployeeStandardDetail EmployeeStandardDetail, string mode)
    {
        DAL_EmployeeStandardDetail = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("mode", mode));
        //arrParameter.Add(new parameter("EmpStdID", EmployeeStandardDetail.empstdid));
        arrParameter.Add(new parameter("EmployeeID", EmployeeStandardDetail.employeeid));
        arrParameter.Add(new parameter("BMSID", EmployeeStandardDetail.bmsid));
        arrParameter.Add(new parameter("SubjectID", EmployeeStandardDetail.subjectidstr));
        arrParameter.Add(new parameter("SubjectIDDelete", EmployeeStandardDetail.subjectidForDeletestr));
        arrParameter.Add(new parameter("DivisionID", EmployeeStandardDetail.divisionidstr));        
        //arrParameter.Add(new parameter("CreatedOn", EmployeeStandardDetail.createdon));
        //arrParameter.Add(new parameter("CreatedBy", EmployeeStandardDetail.createdby));
        return DAL_EmployeeStandardDetail.DAL_Select("Proc_EmployeeStandardDetailInsertUpdate", arrParameter);
    }

    //public void BAL_EmployeeStandardDetail_Update(EmployeeStandardDetail EmployeeStandardDetail, string mode)
    //{
    //    DAL_EmployeeStandardDetail = new DataAccess();
    //    arrParameter = new ArrayList();

    //    arrParameter.Add(new parameter("mode", mode));
    //    arrParameter.Add(new parameter("EmpStdID", EmployeeStandardDetail.empstdid));
    //    arrParameter.Add(new parameter("EmployeeID", EmployeeStandardDetail.employeeid));
    //    arrParameter.Add(new parameter("BMSID", EmployeeStandardDetail.bmsid));
    //    arrParameter.Add(new parameter("SubjectID", EmployeeStandardDetail.subjectid));
    //    arrParameter.Add(new parameter("DivisionID", EmployeeStandardDetail.divisionid));
    //    arrParameter.Add(new parameter("IsClassTeacher", EmployeeStandardDetail.isclassteacher));
    //    arrParameter.Add(new parameter("CreatedOn", EmployeeStandardDetail.createdon));
    //    arrParameter.Add(new parameter("CreatedBy", EmployeeStandardDetail.createdby));
    //    DAL_EmployeeStandardDetail.DAL_InsertUpdate("Proc_EmployeeStandardDetailInsertUpdate", arrParameter);
    //}

    public void BAL_EmployeeStandardDetail_Delete(string EmpStdID)
    {
        DAL_EmployeeStandardDetail = new DataAccess();
        arrParameter = new ArrayList();

       
        arrParameter.Add(new parameter("EmpStdID",EmpStdID));
      
        DAL_EmployeeStandardDetail.DAL_Delete("Proc_EmployeeStandardDetailDelete", arrParameter);
    }
    public void BAL_EmployeeStandardDetailUpdateTeachrType(EmployeeStandardDetail EmployeeStandardDetail)
    {
        DAL_EmployeeStandardDetail = new DataAccess();
        arrParameter = new ArrayList();


        arrParameter.Add(new parameter("EmployeeID", EmployeeStandardDetail.employeeid));
        arrParameter.Add(new parameter("BMSID", EmployeeStandardDetail.bmsid));
        arrParameter.Add(new parameter("DivisionID", EmployeeStandardDetail.divisionid));
        arrParameter.Add(new parameter("isclassteacher", EmployeeStandardDetail.isclassteacher));
        DAL_EmployeeStandardDetail.DAL_Delete("Proc_EmployeeTeacherTypeUpdateByEmployeeID", arrParameter);
    }
    public DataSet BAL_EmployeeStandardDetail_SelectBySchoolID(int SchoolID, string SearchCondition)
    {
        DAL_EmployeeStandardDetail = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("Schoolid", SchoolID));
        arrParameter.Add(new parameter("SearchCondition", SearchCondition));
        return DAL_EmployeeStandardDetail.DAL_Select("Proc_EmployeeStdSubDetailsBySchoolID", arrParameter);
    }

    //public DataSet BAL_EmployeeStandardDetail_SelectAll()
    //{
    //    DAL_EmployeeStandardDetail = new DataAccess();
    //    return DAL_EmployeeStandardDetail.DAL_SelectALL("Proc_EmployeeStandardDetailSELECTAll");
    //}
}