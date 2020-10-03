using System.Data;
using System.Collections;

/// <summary> 
/// <DevelopedBy>"NARENDRASINH"</DevelopedBy>
/// <DevelopedDate></DevelopedDate>
/// <UpdatedBy>"NARENDRASINH"</UpdatedBy>
/// <UpdatedDate></UpdatedDate>
/// </summary>


public class School_BLogic
{
    DataAccess DAL_School;
    ArrayList arrParameter;
    public School_BLogic()
    {
        //
        // TODO: Add constructor logic here
        //
    }



    public void BAL_School_Insert(School School, string mode)
    {
        DAL_School = new DataAccess();
        arrParameter = new ArrayList();
          
        arrParameter.Add(new parameter("mode", mode));
       // arrParameter.Add(new parameter("SchoolID", School.schoolid));//
        arrParameter.Add(new parameter("Name", School.name));
        arrParameter.Add(new parameter("PloteNo", School.ploteno));
        arrParameter.Add(new parameter("BlockNo", School.blockno));
        arrParameter.Add(new parameter("Address", School.address));
        arrParameter.Add(new parameter("CountryID", School.countryid));
        arrParameter.Add(new parameter("StateID", School.stateid));
        arrParameter.Add(new parameter("DistrictID", School.districtid));
        arrParameter.Add(new parameter("City", School.city));
        arrParameter.Add(new parameter("PinCode", School.pincode));
        arrParameter.Add(new parameter("LandLineNo", School.landlineno));
        arrParameter.Add(new parameter("FaxNo", School.faxno));
        arrParameter.Add(new parameter("MobileNo", School.mobileno));
        arrParameter.Add(new parameter("EmailID", School.emailid));
        arrParameter.Add(new parameter("WebSiteURL", School.websiteurl));
        arrParameter.Add(new parameter("SchoolStartYear", School.schoolstartyear));
        arrParameter.Add(new parameter("Comment", School.comment));
        //arrParameter.Add(new parameter("StatusID", School.StatusID));//
        //arrParameter.Add(new parameter("StartDate", School.startdate));//
        //arrParameter.Add(new parameter("CountDay", School.countday));//
        //arrParameter.Add(new parameter("TotalDays", School.totaldays));//
        //arrParameter.Add(new parameter("CreatedOn", School.createdon));
        arrParameter.Add(new parameter("CreatedBy", School.createdby));
        //arrParameter.Add(new parameter("ModifiedOn", School.modifiedon));
        arrParameter.Add(new parameter("ModifiedBy", School.modifiedby));
        arrParameter.Add(new parameter("SchoolBMS", School.schoolregbms));
        DAL_School.DAL_InsertUpdate("Proc_SchoolInsertUpdate", arrParameter);
    }
    public void BAL_School_UpdateDetails(School School, string mode)
    {
        DAL_School = new DataAccess();
        arrParameter = new ArrayList();
    
	
	
	
        arrParameter.Add(new parameter("SchoolID", School.schoolid));
        arrParameter.Add(new parameter("Name", School.name));
        arrParameter.Add(new parameter("PloteNo", School.ploteno));
        arrParameter.Add(new parameter("BlockNo", School.blockno));
        arrParameter.Add(new parameter("Address", School.address));
        //arrParameter.Add(new parameter("CountryID", School.countryid));
        //arrParameter.Add(new parameter("StateID", School.stateid));
        //arrParameter.Add(new parameter("DistrictID", School.districtid));
        arrParameter.Add(new parameter("City", School.city));
        arrParameter.Add(new parameter("PinCode", School.pincode));
        arrParameter.Add(new parameter("LandLineNo", School.landlineno));
        arrParameter.Add(new parameter("FaxNo", School.faxno));
        arrParameter.Add(new parameter("MobileNo", School.mobileno));
        arrParameter.Add(new parameter("EmailID", School.emailid));
        arrParameter.Add(new parameter("WebSiteURL", School.websiteurl));
        arrParameter.Add(new parameter("SchoolStartYear", School.schoolstartyear));       
        arrParameter.Add(new parameter("ModifiedBy", School.modifiedby));
        DAL_School.DAL_InsertUpdate("Proc_SchoolUpdate", arrParameter);
    }

    public void BAL_School_UpdateStatus(School School, string mode)
    {
        DAL_School = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("mode", mode));
        arrParameter.Add(new parameter("schoolidStr", School.schoolidStr));
        arrParameter.Add(new parameter("StatusID", School.StatusID));
        arrParameter.Add(new parameter("modifiedby",School.modifiedby));
        DAL_School.DAL_InsertUpdate("Proc_SchoolstatusUpdate", arrParameter);
    }

    public DataSet BAL_SchoolAllName()
    {
        DAL_School = new DataAccess();  
        return DAL_School.DAL_SelectALL("Proc_SchoolAllNameSelect");
    }

    public DataSet BAL_SchoolAllNameWithID(string Mode)
    {
        DAL_School = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("mode", Mode));
        return DAL_School.DAL_Select("Proc_UserList_SchooName_WithID", arrParameter);
    }

    public DataSet BAL_AllAcademicYear()
    {
        DAL_School = new DataAccess();
        return DAL_School.DAL_SelectALL("Proc_SelectAcademicYear");
    }

    public DataSet BAL_SelectSchoolPerformance(string schoolid , string academicyear)
    {
        DAL_School = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("SchoolID1", schoolid.ToString().Trim()));
        arrParameter.Add(new parameter("AcademicYear", academicyear.ToString().Trim()));
        return DAL_School.DAL_Select("Proc_SchoolPerformanceReport", arrParameter);
    }


    public DataSet BAL_School_SelectAllOrBySchRegID(string mode, int schid,string SearchCondition)
    {

        DAL_School = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("mode", mode));
        arrParameter.Add(new parameter("Tmp_SchoolID", schid));
        arrParameter.Add(new parameter("SearchCondition",SearchCondition));
        return DAL_School.DAL_Select("SELECTAll_School", arrParameter);
    }

    public DataSet BAL_School_SelectByID(int SchoolID)
    {
        DAL_School = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("SchoolID", SchoolID));
        return DAL_School.DAL_Select("proc_Select_SchoolByID", arrParameter);
    }

    public DataTable BAL_SelectSubjectList(string SqlQuery)
    {
        DAL_School = new DataAccess();
        arrParameter = new ArrayList();

        return DAL_School.GetDataTable(SqlQuery);
    }

    public DataSet BAL_SelectSubjestwiseSchoolPerformance(string schoolid, string acedemicyear,string  subjectiduery)
    {
        
      DAL_School = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("SchoolID1", schoolid));
        arrParameter.Add(new parameter("AcademicYear", acedemicyear));
        arrParameter.Add(new parameter("SubjectID", subjectiduery));
        return DAL_School.DAL_Select("Proc_SubjectWiseSchoolPerformanceReport", arrParameter);
    }

    
}