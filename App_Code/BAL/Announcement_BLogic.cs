/// <summary>               
/// <Description>Announcement_BLogic</Description>
/// <DevelopedBy>"Bhavesh Prajapati"</DevelopedBy>
/// <DevelopedDate>"30-Sept-2013"</DevelopedDate>
/// <UpdatedBy></UpdatedBy>
/// <UpdatedDate></UpdatedDate>
/// </summary>
using System.Collections;
using System.Data;

public class Announcement_BLogic
{
    DataAccess DAL_Announcement;
    ArrayList arrParameter;

    public Announcement_BLogic()
    {
        ////
        //// TODO: Add constructor logic here
        ////
    }

    public DataSet BAL_Announcement_Insert(Announcement Announcement, string mode)
    {
        this.DAL_Announcement = new DataAccess();
        this.arrParameter = new ArrayList();

        this.arrParameter.Add(new parameter("mode", mode));
        this.arrParameter.Add(new parameter("AnnouncementID", Announcement.announcementid));
        this.arrParameter.Add(new parameter("BMSID", Announcement.bmsid));
        this.arrParameter.Add(new parameter("DivisionID", Announcement.divisionstr));
        this.arrParameter.Add(new parameter("StartDate", Announcement.startdate));
        this.arrParameter.Add(new parameter("EndDate", Announcement.enddate));
        this.arrParameter.Add(new parameter("Announcement", Announcement.announcement));
        //// arrParameter.Add(new parameter("CreatedOn", Announcement.createdon));
        this.arrParameter.Add(new parameter("CreatedBy", Announcement.createdby));
        //// arrParameter.Add(new parameter("ModifiedOn", Announcement.modifiedon));
        this.arrParameter.Add(new parameter("ModifiedBy", Announcement.modifiedby));
        return this.DAL_Announcement.DAL_Select("Proc_AnnouncementInsertUpdate", this.arrParameter);
    }

    public DataSet BAL_Announcement_Update(Announcement Announcement, string mode)
    {
        this.DAL_Announcement = new DataAccess();
        this.arrParameter = new ArrayList();

        this.arrParameter.Add(new parameter("mode", mode));
        this.arrParameter.Add(new parameter("AnnouncementID", Announcement.announcementid));
        this.arrParameter.Add(new parameter("BMSID", Announcement.bmsid));
        this.arrParameter.Add(new parameter("DivisionID", Announcement.divisionstr));
        this.arrParameter.Add(new parameter("StartDate", Announcement.startdate));
        this.arrParameter.Add(new parameter("EndDate", Announcement.enddate));
        this.arrParameter.Add(new parameter("Announcement", Announcement.announcement));
        this.arrParameter.Add(new parameter("CreatedBy", Announcement.createdby));
        this.arrParameter.Add(new parameter("ModifiedBy", Announcement.modifiedby));
        return this.DAL_Announcement.DAL_Select("Proc_AnnouncementInsertUpdate", this.arrParameter);
    }

    public void BAL_Announcement_Delete(Announcement Announcement, int SchoolID, string mode)
    {
        this.DAL_Announcement = new DataAccess();
        this.arrParameter = new ArrayList();

        this.arrParameter.Add(new parameter("mode", mode));
        this.arrParameter.Add(new parameter("AnnouncementID", Announcement.announcementid));
        this.arrParameter.Add(new parameter("SchoolID", SchoolID));

        this.DAL_Announcement.DAL_Delete("Proc_AnnouncementSelectDelete", this.arrParameter);
    }

    public DataSet BAL_Announcement_Select(Announcement Announcement, string mode)
    {
        this.DAL_Announcement = new DataAccess();
        this.arrParameter = new ArrayList();

        this.arrParameter.Add(new parameter("mode", mode));
        this.arrParameter.Add(new parameter("AnnouncementID", Announcement.announcementid));
        this.arrParameter.Add(new parameter("BMSID", Announcement.bmsid));
        this.arrParameter.Add(new parameter("DivisionID", Announcement.divisionid));
        this.arrParameter.Add(new parameter("StartDate", Announcement.startdate));
        this.arrParameter.Add(new parameter("EndDate", Announcement.enddate));
        this.arrParameter.Add(new parameter("Announcement", Announcement.announcement));
        this.arrParameter.Add(new parameter("CreatedOn", Announcement.createdon));
        this.arrParameter.Add(new parameter("CreatedBy", Announcement.createdby));
        this.arrParameter.Add(new parameter("ModifiedOn", Announcement.modifiedon));
        this.arrParameter.Add(new parameter("ModifiedBy", Announcement.modifiedby));
        return this.DAL_Announcement.DAL_Select("Proc_AnnouncementSelectDelete", this.arrParameter);
    }

    public DataSet BAL_Announcement_SelectAll()
    {
        this.DAL_Announcement = new DataAccess();
        return this.DAL_Announcement.DAL_SelectALL("Proc_AnnouncementSELECTAll");
    }

    public DataSet BAL_SelectAnnouncementBySchoolID(int schoolid, string mode)
    {
        this.DAL_Announcement = new DataAccess();
        this.arrParameter = new ArrayList();
        this.arrParameter.Add(new parameter("SchoolID", schoolid));
        this.arrParameter.Add(new parameter("mode", mode));
        return this.DAL_Announcement.DAL_Select("Proc_AnnouncementSelectDelete", this.arrParameter);
    }

    public DataSet BAL_SelectAnnouncementForTeacher(int BMSID, int EmployeeID,string mode)
    {
        this.DAL_Announcement = new DataAccess();
        this.arrParameter = new ArrayList();
        this.arrParameter.Add(new parameter("BMSID", BMSID));
        this.arrParameter.Add(new parameter("EmployeeID", EmployeeID));
        this.arrParameter.Add(new parameter("DivisionID", AppSessions.DivisionID));
        this.arrParameter.Add(new parameter("mode", mode));
        return this.DAL_Announcement.DAL_Select("Proc_AnnouncementSelectDelete", this.arrParameter);
    }

    public DataSet BAL_SelectAnnouncementBySchoolID1(int schoolid, string SearchCondition)
    {
        this.DAL_Announcement = new DataAccess();
        this.arrParameter = new ArrayList();
        this.arrParameter.Add(new parameter("SchoolID", schoolid));
        this.arrParameter.Add(new parameter("SearchCondition", SearchCondition));
        return this.DAL_Announcement.DAL_Select("Proc_AnnouncementDetailsBySchoolID", this.arrParameter);
    }

    public DataTable FillCheckBox(int SchoolId, int BMSID)
    {
        this.DAL_Announcement = new DataAccess();
        this.arrParameter = new ArrayList();
        this.arrParameter.Add(new parameter("SchoolID", SchoolId));
        this.arrParameter.Add(new parameter("BMSID", BMSID));
        return this.DAL_Announcement.DAL_Select("Proc_fillDivisionBySchoolID", this.arrParameter).Tables[0];
    }
}